using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;

namespace KoloryWPF.ViewModel
{
    public class EdycjaKoloru : INotifyPropertyChanged
    {
        private Model.Kolor model = Model.Ustawienia.Czytaj();

        public byte R
        {
            get
            {
                return model.R;
            }
            set
            {
                model.R = value;
                OnPropertyChanged("R");
                OnPropertyChanged("Color");
            }
        }

        public byte G
        {
            get
            {
                return model.G;
            }
            set
            {
                model.G = value;
                OnPropertyChanged("G");
                OnPropertyChanged("Color");
            }
        }

        public byte B
        {
            get
            {
                return model.B;
            }
            set
            {
                model.B = value;
                OnPropertyChanged("B");
                OnPropertyChanged("Color");
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string nazwaWłasności)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(nazwaWłasności));
        }
        #endregion

        private ICommand resetujCommand;

        public ICommand Resetuj
        {
            get
            {
                if (resetujCommand == null)
                    resetujCommand = new MvvmCommand(
                        (object parametr) => { R = 0; G = 0; B = 0; }, 
                        (object param) => { return R != 0 || G != 0 || B != 0; }
                        );
                return resetujCommand;
            }
        }

        private ICommand zapiszCommand;

        public ICommand Zapisz
        {
            get
            {
                if (zapiszCommand == null)
                    zapiszCommand = new MvvmCommand(arg => { Model.Ustawienia.Zapisz(model); });
                return zapiszCommand;
            }
        }
    }

    static class KolorExtensions
    {
        public static Color ToColor(this Model.Kolor kolor)
        {
            return Color.FromRgb(kolor.R, kolor.G, kolor.B);
        }
    }
}
