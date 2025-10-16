using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI_TPmoyennes
{
    class Classe
    {
        // Nom de la classe
        public string nomClasse { get; set; }

        // Liste élèves et matières
        public List<Eleve> eleves { get; set; } = new List<Eleve>();
        public List<string> matieres { get; set; } = new List<string>();

        // Constructeur
        public Classe(string nom) 
        { 
            nomClasse = nom; 
        }

        // Ajouter un élève
        public void ajouterEleve(string prenom, string nom) 
        {
          if (eleves.Count < 30)
            {
                eleves.Add(new Eleve(prenom, nom));
            }
          else
            {
                Console.WriteLine("Impossible d'ajouter l'élève : limite d'élèves par classe atteinte");
            }

        }

        // Ajouter une matière
        public void ajouterMatiere(string matiere)
        {
            if (matieres.Count < 10)
            {
                matieres.Add(matiere);
            }
            else
            {
                Console.WriteLine("Impossible d'ajouter la matière : limité de matières par classe atteinte");
            }
     
        }

        // Calculer la moyenne de la classe pour chaque matière
        public float moyenneMatiere(int indexMatiere)
        {
            float moyenne = 0f;

            if (eleves.Count > 0 && indexMatiere >= 0 && indexMatiere < matieres.Count)
            {
                float sommeMoyennes = 0f;

                foreach (var eleve in eleves)
                {
                    sommeMoyennes += eleve.moyenneMatiere(indexMatiere);
                }

                moyenne = sommeMoyennes / eleves.Count;

                moyenne = (int)(moyenne * 100) / 100f;
            }
            return moyenne;
        }

        // Calculer la moyenne générale de la classe 
        public float moyenneGeneral()
        {
            float moyenne = 0f;

            if (eleves.Count > 0 && matieres.Count > 0)
            {
                float sommeMoyennesMatieres = 0f;

                for (int i = 0; i < matieres.Count; i++)
                {
                    sommeMoyennesMatieres += moyenneMatiere(i);
                }

                moyenne = sommeMoyennesMatieres / matieres.Count;

                moyenne = (int)(moyenne * 100) / 100f;
            }
            return moyenne;
        }
    }
}
