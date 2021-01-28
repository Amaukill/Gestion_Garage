using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Garage
{
    public enum Type
    {
        diesel,
        essence,
        hybride,
        electrique
    }
    [Serializable]
    public class Moteur
    {
        public Type Type { get; set; }
        public int Puissance { get; set; }
        public Moteur(Type type , int puissance)
        {
            Type = type;
            Puissance = puissance;
        }
        
        
    }
}
