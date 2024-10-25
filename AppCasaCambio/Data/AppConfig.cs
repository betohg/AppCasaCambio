using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCasaCambio.Data
{
    public class AppConfig
    {
        public string AppTitle { get; set; }
        public string WelcomeMessage { get; set; }

        public string WelcomeTitle { get; set; }
        public ScreenTitles ScreenTitles { get; set; }
        public User User { get; set; }
        public ScreenMessages ScreenMessages { get; set;}
        public Navbar Navbar { get; set; }
    }

    public class ScreenTitles
    {
        public string Home { get; set; }
        public string Configuration { get; set; }
        public string Operations { get; set; }
        public string RegisterCoin { get; set; }

    }

    public class User
    {
        public string Name { get; set; }
        public string Greeting { get; set; }
    }
    public class ScreenMessages
    {
        public string ConfigurationMessage { get; set; }
    }

    public class Navbar
    {
        public string Home { get; set; }
        public string Configuration { get; set; }
        public string Register { get; set; }
        public string Operations { get; set; }
    }
}
