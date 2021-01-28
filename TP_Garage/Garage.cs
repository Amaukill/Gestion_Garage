using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace TP_Garage
{
    [Serializable]
    public class Garage
    {
        public string Nom { get; set; }
        protected Vehicule Vehicule { get; set; }
        protected Moteur moteur { get; set; }
        protected Option option { get; set; }
        protected Marque marque { get; set; }

        protected List<Vehicule> _vehicules;


        public Garage(string nom)
        {
            Nom = nom;
            _vehicules = new List<Vehicule>();
        }
        public void AjoutVehicule(Vehicule vehicule)
        {

            _vehicules.Add(vehicule);

        }
        public void TriVehicule()
        {
            _vehicules.Sort();
            Console.WriteLine("Du moins cher au plus cher", Nom);
        }
        public void AfficherVehicules()
        {
            Console.WriteLine("L'ensemble des véhicules du garage {0}", Nom);

            foreach (Vehicule vehicule in _vehicules)
            {
                vehicule.Affichage();
            }

        }
        public void SelectionVehicule(int index)
        {
            try
            {
                index--;
                Console.WriteLine("La voiture que vous avez selectionner est : ");
                _vehicules[index].Affichage();
            }
            catch (ArgumentOutOfRangeException erreur)
            {
                throw new ArgumentOutOfRangeException("Veuillez selectionné un véhicule existant");
            }

        }
        public void DeleteVehicule(int index)
        {
            try
            {
                index--;

                Console.WriteLine("La voiture que vous avez selectionner est : ");
                _vehicules[index].Affichage();
                Console.WriteLine(" A bien été suprimmer");
                _vehicules.Remove(_vehicules[index]);
            }
            catch (ArgumentOutOfRangeException erreur)
            {
                throw new ArgumentOutOfRangeException("Veuillez selectionné un véhicule existant");
            }
        }
        public void afficherOption(int index)
        {
            try
            {
                index--;
                _vehicules[index].AfficherOption();
            }
            catch (ArgumentOutOfRangeException erreur)
            {
                throw new ArgumentOutOfRangeException("Veuillez selectionné un véhicule existant dans Selectionner un véhicule");
            }
        }
        public void AjouterOption(int index)
        {
            try
            {
                index--;
                _vehicules[index].AjoutOption();
            }
            catch (ArgumentOutOfRangeException erreur)
            {
                throw new ArgumentOutOfRangeException("Veuillez selectionné un véhicule existant dans Selectionner un véhicule");
            }
        }
        public void DeleteOption(int index)
        {
            int option = 0;
            try
            {
                index--;
                _vehicules[index].AfficherOption();
                if (_vehicules[index]._options.Count() == 1)
                {
                    _vehicules[index].DeleteOption(1);
                }
                else if (_vehicules[index]._options.Count() > 1)
                {
                    try
                    {
                        Console.WriteLine("Choisissez quelle option supprimmer");
                        option = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException erreur)
                    {
                        throw new FormatException("Le choix saisie n'est pas un nombre");
                    }
                    _vehicules[index].DeleteOption(option);
                }

            }
            catch (ArgumentOutOfRangeException erreur)
            {
                throw new ArgumentOutOfRangeException("Veuillez selectionné un véhicule existant dans Selectionner un véhicule");
            }
        }
       
        public Marques AjoutMarques()
        {
            string marque = "";
            Marque selec;
            Marques selecMarque;
            while (marque != "bmw" && marque != "renault" && marque != "volkswagen")
            {
                Console.WriteLine("Entrer la marque du véhicule (bmw/renault/volkswagen)");
                try
                {
                    marque = Console.ReadLine();
                }
                catch (FormatException erreurMarque) when (marque != "bmw" && marque != "renault" && marque != "volkswagen")
                {
                    new FormatException("Veuillez entrer 'bmw' , 'renault' ou 'volkswagen' seulement ");
                    Console.WriteLine(erreurMarque.Message);
                }
            }
            switch (marque)
            {
                case "bmw":
                    selec= Marque.BMW;
                     selecMarque = new Marques(selec);
                    return selecMarque;

                case "renault":
                    selec = Marque.Renault;
                     selecMarque = new Marques(selec);
                    return selecMarque;

                case "volkswagen":
                    selec= Marque.Volkswagen;
                     selecMarque = new Marques(selec);
                    return selecMarque;
                default: return selecMarque = new Marques(Marque.Null); ;

            }

        }
        public Moteur AjoutMoteur()
        {
            string type = "";
            Type typeMoteur;
            Moteur moteur;
            while (type != "diesel" && type != "essence" && type != "hybride" && type != "électrique")
            {
                Console.WriteLine("Type du moteur (essence/hybride/essence/electrique)");
                try
                {
                    type = Console.ReadLine();
                }
                catch (FormatException erreurMoteur) when (type != "diesel" && type != "hybride" && type != "essence" && type != "electrique")
                {
                    new FormatException("Veuillez entrer 'diesel' , 'hybride' , 'essence' ou 'electrique' seulement ");
                    Console.WriteLine(erreurMoteur.Message);
                }
            }
            int puissance = 0;
            while (puissance <= 0)
            {
                Console.WriteLine("Puissance du moteur : ");
                try
                {
                    puissance = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException erreur)
                {
                     new FormatException("Le choix saisie n'est pas un nombre");
                    Console.WriteLine(erreur.Message);
                }
                catch (Exception erreurpuissance) when (puissance <= 0)
                {
                    new Exception("La puissance doit être supérieur à 0");
                    Console.WriteLine(erreurpuissance.Message);
                }
            }

                if (type == "diesel")
                {
                    typeMoteur = Type.diesel;
                return moteur = new Moteur(typeMoteur, puissance);
                }
                else if (type == "essence") 
                { 
                typeMoteur = Type.essence;
                return moteur = new Moteur(typeMoteur, puissance);
                 }
                else if (type == "hybride") { typeMoteur = Type.hybride; return moteur = new Moteur(typeMoteur, puissance); }
                else   { typeMoteur = Type.electrique; return moteur = new Moteur(typeMoteur, puissance); }
                

            }
          public void SaveVehicule()
        {
            Stream stream = File.Open(@"C:\\Data\\vehicule.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, _vehicules);
            stream.Close();

        }
        public void ChargerVehicule()
        {
            Stream stream = File.Open(@"C:\\Data\\vehicule.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            BinaryFormatter formatter = new BinaryFormatter();
            List<Vehicule> vehicules = (List<Vehicule>)formatter.Deserialize(stream);
            _vehicules = vehicules;
            stream.Close();
        }
    }
}


