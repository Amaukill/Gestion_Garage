using System;
using System.Collections.Generic;
using System.Text;


namespace TP_Garage
{
    [Serializable]
    public class Camion : Vehicule
    {
       
        protected int Essieux { get; set; }
        protected decimal Poids { get; set; }
        protected decimal Volume { get; set; }
        public Camion(int essieux, int poids, int volume, string nom, decimal prix, Marques marque, Moteur moteur)
            : base(nom, prix, marque, moteur)
        {
            _options = new List<Option>();
            Essieux = essieux;
            Poids = poids;
            Volume = volume;
        }
        public override void Affichage()
        {
            base.Affichage();
            Console.WriteLine("Nombres d'essieux : {0}", Essieux);
            Console.WriteLine("Poids : {0}", Poids);
            Console.WriteLine("Volume : {0}", Volume);
            Console.WriteLine("Prix HT: {0}", Prix);
            Console.WriteLine("Prix TTC: {0}", CalculTaxe());
        }
        public decimal CalculTaxe()
        {
            decimal prixOption = 0;
            foreach (Option option in _options)
            {
                prixOption = prixOption + option.Prix;
            }
            return Prix + (Essieux * 50) + prixOption;
        }   

    }
}
