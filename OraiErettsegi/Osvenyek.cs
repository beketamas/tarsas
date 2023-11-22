
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OraiErettsegi
{
    internal class Osvenyek
    {
        string sorok;
        public Osvenyek(string sor)
        {
            this.sorok = sor;
        }

        public string Sorok => sorok;
    }
}
