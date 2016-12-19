using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace KoloryWPF.Model
{
    static class Ustawienia
    {
        public static Kolor Czytaj()
        {
            Properties.Settings s = Properties.Settings.Default;
            return new Kolor(s.R, s.G, s.B);
        }

        public static void Zapisz(Kolor kolor)
        {
            Properties.Settings s = Properties.Settings.Default;
            s.R = kolor.R;
            s.G = kolor.G;
            s.B = kolor.B;
            s.Save();
        }
    }
}
