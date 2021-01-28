using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace TP_Garage
{
    public class MenuException : Exception
    {
        public MenuException() : base("Le choix n'est pas compris entre 0 et 11")
        {

        }
    }
    public class Menu
    {
        protected Garage Garage { get; set; }
        private int Selection { get; set; }
        public Menu ( Garage garage)
        {
            Garage = garage;
            Selection = -1;
        }
        public void Start()
        {
            int choix = -1;
            while (choix < 0 || choix > 11)
            {
               
                try
                {

                    
                    Console.WriteLine("1. Afficher les véhicules");
                    Console.WriteLine("2. Ajouter un véhicule");
                    Console.WriteLine("3. Supprimer un véhicule");
                    Console.WriteLine("4. Sélectionner un véhicule");
                    Console.WriteLine("5. Afficher les options du véhicule");
                    Console.WriteLine("6. Ajouter des options au véhicule");
                    Console.WriteLine("7. Supprimer des options au véhicule");
                    Console.WriteLine("8. Afficher les options");
                    Console.WriteLine("9. Afficher les marques");
                    Console.WriteLine("10. Afficher les types de moteurs");
                    Console.WriteLine("11. Sauvegarder le garage");
                    Console.WriteLine("0. Quitter l'application ");
                    Console.WriteLine();
                    if (Selection != -1)
                    {
                        Garage.SelectionVehicule(Selection);
                       
                    }
                    Console.WriteLine();
                    choix = GetChoixMenu();


                }
                catch (FormatException erreur)
                {
                    Console.Clear();
                    Console.WriteLine(erreur.Message);

                }
                catch (MenuException erreur)
                {
                    Console.Clear();
                    Console.WriteLine(erreur.Message);


                }
                switch (choix)
                {
                    case 0: break;
                    case 1:
                        Console.Clear();
                        AfficherVoiture();
                        break;
                    case 2:
                        Console.Clear();
                        AjouterVehicule();
                        break;
                    case 3:
                        Console.Clear();
                        SupprimmerVehicule();
                        break;
                    case 4:
                        Console.Clear();
                        SelectionnerVehicule();
                        break;
                        
                    case 5:
                        Console.Clear();
                        AfficherOptions();
                        break;
                    case 6:
                        Console.Clear();
                        AjouterOption();
                        break;
                    case 7:
                        Console.Clear();
                        SupprimmerOption();
                        break;
                    case 8:
                        Console.Clear();
                            AfficherAllOption();
                        break;
                    case 9:
                        Console.Clear();
                        AfficherAllMarque();
                        break;
                    case 10:
                        Console.Clear();
                        AfficherAllMoteur();
                        break;
                    case 11:
                        Console.Clear();
                        Save();
                        break;

                    default: break;
                }
                
            }

        }
       
        // OPTION 1 : 
        public void AfficherVoiture()
        {
            string retour = "n";
            while (retour == "n")
            {
                try
                {
                    Garage.AfficherVehicules();
                  
                   retour = Retour();
                }
                catch(FormatException erreur)
                {
                    Console.Clear();
                    Console.WriteLine(erreur.Message);
                }
                if (retour == "o")
                {
                    Console.Clear();
                    Start();
                }
            }
        }
        // OPTION 2 
        public void AjouterVehicule()
        {
            
                Console.WriteLine("Ajout d'un vehicule");
                Console.WriteLine("Quel type de véhicule (moto/camion/voiture)");
                string typeV = "";
                while (typeV != "moto" && typeV != "camion" && typeV != "voiture")
                {
                    try
                    {
                        typeV = TypeVehicule();
                    }
                    catch (FormatException erreurTypeV)
                    {
                        Console.Clear();
                        Console.WriteLine(erreurTypeV.Message);
                    }
                }
                Console.WriteLine("Entrer le nom du véhicule :");
                string nom = Console.ReadLine();
                decimal prix = 0;
                while (prix <= 0)
                {
                    try
                    {
                        Console.WriteLine("Prix du véhicule :");
                        prix = GetChoix();
                    }
                    catch (FormatException erreur)
                    {
                        Console.Clear();
                        Console.WriteLine(erreur.Message);
                    }
                }
                Marques marque = Garage.AjoutMarques();
                Moteur Moteur = Garage.AjoutMoteur();
                switch (typeV)
                {
                    case "moto":
                    double cylindre = 0;
                    while (cylindre <= 0)
                    {
                        try
                        {
                            Console.WriteLine("Cylindre :");
                            cylindre = Convert.ToDouble(GetChoix());
                        }
                        catch (FormatException erreur)
                        {
                            Console.WriteLine(erreur.Message);
                        }
                    }
                       
                        Moto moto = new Moto(cylindre, nom, prix, marque, Moteur);
                        Garage.AjoutVehicule(moto);
                        Console.WriteLine("La moto a été ajouté ");
                        Start();
                        break;
                    case "voiture":
                    int essieux = 0;
                    int portes = 0;
                         int sieges = 0;
                         int coffre = 0;
                    while (essieux <= 0 && portes <= 0 && sieges <= 0 && coffre <= 0)
                    {
                        try
                        {
                            Console.WriteLine("Nombres d'essieux :");
                            essieux = GetChoix();
                            Console.WriteLine("Nombres de portes");
                            portes = GetChoix();
                            Console.WriteLine("Nombres de sièges");
                            sieges = GetChoix();
                            Console.WriteLine("Volume du coffre");
                            coffre = GetChoix();
                        }
                        catch (FormatException erreur)
                        {
                            Console.WriteLine(erreur.Message);
                        }
                    }
                    Voiture voiture = new Voiture(essieux, portes, sieges, coffre, nom, prix, marque, Moteur);
                    Garage.AjoutVehicule(voiture);
                    Console.WriteLine("La voiture a été ajouté ");
                    Start();
                    break;
                    case "camion":
                    essieux = 0;
                    int volume=0;
                    int poids=0;
                    while (essieux <= 0 && poids <= 0 && volume <= 0){
                        try
                        {
                            Console.WriteLine("Nombres d'essieux :");
                            essieux = GetChoix();
                            Console.WriteLine("Nombres de poids");
                            poids = GetChoix();
                            Console.WriteLine("Volume");
                            volume = GetChoix();
                        }
                        catch (FormatException erreur)
                        {                       
                            Console.WriteLine(erreur.Message);
                        }
                    }
                    Camion camion = new Camion(essieux, poids, volume, nom, prix, marque, Moteur);
                    Garage.AjoutVehicule(camion);
                    Console.WriteLine("Le camion a été ajouté ");
                    Start();
                    break;
                }
         }
        
           
        public string TypeVehicule()
        {
            string typeV="";
            try
            {
                 typeV = Console.ReadLine();
            }
            catch (FormatException erreurTypeV) when (typeV != "moto" && typeV != "camion" && typeV != "voiture")
            {
                throw new FormatException("Veuillez entrer 'moto' , 'camion' ou 'voiture' seulement ");
            }
            return typeV;
        }
        //OPTION 3 
        public void SupprimmerVehicule()
        {
            int selection = 0;
            string retour = "n";
            while (retour == "n")
            {
                try
                {

                    Garage.AfficherVehicules();
                    Console.WriteLine("Entrer L'ID du véhicule à supprimer");
                    selection = GetChoix();

                }
                catch (FormatException erreur)
                {
                    Console.Clear();
                    Console.WriteLine(erreur.Message);

                }
                try
                {
                    Console.Clear();
                    Garage.DeleteVehicule(selection);
                }
                catch (ArgumentOutOfRangeException erreur)
                {
                    Console.Clear();
                    Console.WriteLine(erreur.Message);
                }
                try
                {
                   
                    retour = Retour();
                    Console.Clear();
                }
                catch (FormatException erreur)
                {
                    Console.Clear();
                    Console.WriteLine(erreur.Message);
                }
                if(Selection == selection)
                {
                    Selection = -1;
                }
                if (retour == "o")
                {
                    Console.Clear();
                    Start();
                }
            }
        }
    
        // OPTION 4
        public void SelectionnerVehicule()
        {
            int selection = 0;
            string retour = "n";
            while (retour == "n")
            {
                try
                {

                    Garage.AfficherVehicules();
                    Console.WriteLine("Entrer L'ID du véhicule choisi");
                    selection = GetChoix();

                }
                catch (FormatException erreur)
                {
                    Console.Clear();
                    Console.WriteLine(erreur.Message);

                }
                try
                {
                    Console.Clear();
                    Garage.SelectionVehicule(selection);
                }
                catch (ArgumentOutOfRangeException erreur)
                {
                    Console.Clear();
                    Console.WriteLine(erreur.Message);
                }
                try
                {
             
                    retour = Retour();
                    Console.Clear();
                }
                catch (FormatException erreur)
                {
                    Console.Clear();
                    Console.WriteLine(erreur.Message);
                }
                if (retour == "o")
                {
                    Selection = selection;
                    Console.Clear();
                    Start();
                }
            }
        }
        //OPTION 5
        public void AfficherOptions()
        {
            string retour = "n";
            while (retour == "n")
            {
                try
                {
                    Garage.afficherOption(Selection);
                }
                catch (ArgumentOutOfRangeException erreur)
                {
                    Console.Clear();
                    Console.WriteLine(erreur.Message);
                    Start();
                }
                try
                {
                    
                    retour = Retour();
                    Console.Clear();
                }
                catch (FormatException erreur)
                {
                    Console.Clear();
                    Console.WriteLine(erreur.Message);
                }
                if (retour == "o")
                {
                    
                    Console.Clear();
                    Start();
                }
            }
        }
        // OPTION 6
        public void AjouterOption()
        {
            string retour = "n";
            while (retour == "n")
            {
                try
                {
                    Garage.AjouterOption(Selection);
                }
                catch (ArgumentOutOfRangeException erreur)
                {
                    Console.Clear();
                    Console.WriteLine(erreur.Message);
                    Start();
                }
                catch (FormatException erreur)
                {
                    Console.WriteLine(erreur.Message);
                    AfficherOptions();
                }
                try
                {
                  
                    retour = Retour();
                    Console.Clear();
                }
                catch (FormatException erreur)
                {
                    Console.Clear();
                    Console.WriteLine(erreur.Message);
                }
                if (retour == "o")
                {

                    Console.Clear();
                    Start();
                }
            }
        }
        // OPTION 7
        public void SupprimmerOption()
        {
            string retour = "n";
            while (retour == "n")
            {
                try
                {
                    Garage.DeleteOption(Selection);
                }
                catch (ArgumentOutOfRangeException erreur)
                {
                    Console.Clear();
                    Console.WriteLine(erreur.Message);
                    Start();
                }
                catch (FormatException erreur)
                {
                    Console.WriteLine(erreur.Message);
                    AfficherOptions();
                }
                try
                {
                   
                    retour = Retour();
                    Console.Clear();
                }
                catch (FormatException erreur)
                {
                    Console.Clear();
                    Console.WriteLine(erreur.Message);
                }
                if (retour == "o")
                {

                    Console.Clear();
                    Start();
                }
            }
        }
        // OPTION 8 
        public void AfficherAllOption()
        {
            Console.WriteLine("Options disponible: ");
            Console.WriteLine(ListOption.ABS);
            Console.WriteLine(ListOption.ESP);
            Console.WriteLine(ListOption.climatisation);
            Console.WriteLine(ListOption.airbags);
        }
        // OPTION 9
        public void AfficherAllMarque()
        {
            string retour = "n";
            while (retour == "n")
            {
                Console.WriteLine("Marque disponible : ");
            Console.WriteLine(Marque.BMW);
            Console.WriteLine(Marque.Renault);
            Console.WriteLine(Marque.Volkswagen);
                try
                {

                    retour = Retour();
                    Console.Clear();
                }
                catch (FormatException erreur)
                {
                    Console.Clear();
                    Console.WriteLine(erreur.Message);
                }
                if (retour == "o")
                {

                    Console.Clear();
                    Start();
                }
            }
        }
        //OPTION 10
        public void AfficherAllMoteur()
        {
            string retour = "n";
            while (retour == "n")
            {
                Console.WriteLine("Type de moteur : ");
                Console.WriteLine(Type.diesel);
                Console.WriteLine(Type.essence);
                Console.WriteLine(Type.hybride);
                Console.WriteLine(Type.electrique);
                try
                {

                    retour = Retour();
                    Console.Clear();
                }
                catch (FormatException erreur)
                {
                    Console.Clear();
                    Console.WriteLine(erreur.Message);
                }
                if (retour == "o")
                {

                    Console.Clear();
                    Start();
                }
            }
        }
        //OPTION 11
        public void Save()
        {
            Stream stream = File.Open(@"C:\\Data\\garage.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, Garage);
            Garage.SaveVehicule();
            stream.Close();
            Console.WriteLine("Le garage a bien été sauvegardé");
            Start();
            
        }
        // Fonctionnalité Menu
        public int GetChoixMenu()
        {
            int choix = 0;


            choix = GetChoix();

            if (choix < 0 || choix > 11)
            {
                throw new MenuException();
            }
            return choix;
        }
        public int GetChoix()
        {

            string choixSaisi = Console.ReadLine();
            int choix = 0;
            try
            {
                choix = Convert.ToInt32(choixSaisi);
            }
            catch (FormatException erreur)
            {
                throw new FormatException("Le choix saisie n'est pas un nombre");
            }
            return choix;
        }
        public string Retour()
        {
            Console.WriteLine("Voulez vous retourner dans le menu oui [o] ou non [n]");
            string retour = Console.ReadLine();
            if (retour != "n" && retour != "o")
            {
                throw new FormatException("Appuyer seulement sur [o] ou [n] ");
            }
            return retour;
        }
        public void charger()
        {
            Stream stream = File.Open(@"C:\\Data\\garage.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, Garage);
            Garage.ChargerVehicule();
            stream.Close();
            Console.WriteLine("Le garage {0} a bien été chargé",Garage.Nom);
            
        }  
    }
}
