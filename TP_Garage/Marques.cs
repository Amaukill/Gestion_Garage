using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Garage
{
    public enum Marque
    {
        Null,
        BMW,
        Renault,
        Volkswagen,
    }
    [Serializable]
    public class Marques
    {
        public Marque Marque { get; set; }

        public Marques(Marque marque)
        {
            Marque = marque;
        }

    }
}
