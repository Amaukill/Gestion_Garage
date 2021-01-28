using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Garage
{
    [Serializable]
    public class Moto : Vehicule
    {
        protected double Cylindre { get; set; }

        public Moto(double cylindre, string nom, decimal prix, Marques marque, Moteur moteur)
            :base(nom, prix, marque, moteur)
        {
            _options = new List<Option>();
            Cylindre = cylindre;
        }
        public override void Affichage()
        {
            base.Affichage();
           
            Console.WriteLine("Cylindre : {0}", Cylindre);
            Console.WriteLine("Prix HT: {0}", Prix);
            Console.WriteLine("Prix TTC: {0}", CalculTaxe());
        }
        public double CalculTaxe()
        {
            decimal prixOption = 0;
            foreach (Option option in _options)
            {
                prixOption = prixOption + option.Prix;
            }
            double prix = Convert.ToDouble(Prix)+ Convert.ToDouble(prixOption);
            return (prix + (Cylindre * 0.3) );
        }
    }
}
