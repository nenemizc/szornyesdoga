using System;
using System.Collections.Generic;
using System.Text;

namespace szornyesdoga
{
    internal class Szornyelemzo
    {
        private List<Szorny> szornyek;

        public Szornyelemzo(List<Szorny> szornyek)
        {
            this.szornyek = szornyek;
        }

        public int OsszesSzornySzama()
        {
            return szornyek.Count();
        }

        public IEnumerable<string> VeszelyesSzornyekNevei()
        {
            return szornyek.Where(szorny => szorny.VeszelyesE).Select(szorny => szorny.Nev);
        }

        public IEnumerable<string> EgyediElohelyek()
        {
            return szornyek.Select(szorny => szorny.Elohely).Distinct();
        }

        public double AtlagosVeszelyesseg()
        {
            return szornyek.Average(szorny => szorny.VeszelyessegiSzint);
        }

        public IEnumerable<Szorny> LegveszelyesebbSzornyek()
        {
            return szornyek.Where(szorny => szorny.VeszelyessegiSzint == szornyek.Max(szorny => szorny.VeszelyessegiSzint));
        }

        public IEnumerable<Szorny> MocsariVeszelyesSzornyek()
        {
            return szornyek.Where(szorny => szorny.Elohely == "Fekete Mocsár" && szorny.VeszelyessegiSzint >= 5).OrderByDescending(szorny => szorny.VeszelyessegiSzint);
        }

        public bool VenExtremTuzGyengeSzorny()
        {
            return szornyek.Any(szorny => szorny.FoGyengeseg == "Tűz" && szorny.VeszelyessegiSzint >= 9);
        }

        public IEnumerable<string> SzornyekSzamaElohelyenkent()
        {
            return szornyek.GroupBy(szorny => szorny.Elohely).Select(hely => $"{hely.Key}: {hely.Count()}");
        }
    }
}
