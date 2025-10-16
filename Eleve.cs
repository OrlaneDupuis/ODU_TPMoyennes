using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI_TPmoyennes
{
    class Eleve
    {
        // Nom et prénom de l'élève
        public string prenom { get; set; }
        public string nom { get; set; }

        // Liste de notes
        public List<Note> notes { get; set; } = new List<Note> ();

        // Constructeur
        public Eleve(string p, string n)
        { 
            prenom = p;
            nom = n;
        }

        // Ajouter une note
        public void ajouterNote(Note n)
        {
            if (notes.Count < 200)
            {
                notes.Add (n);
            }
            else
            {
                Console.WriteLine("Impossible d'ajouter la  note : limite de 200 notes atteinte.");
            }
        }

        // Calcul moyenne de l'élève dans une matière donnée 
        public float moyenneMatiere(int indexMatiere)
        {
            float somme = 0f;
            int nombreNotes = 0;

            foreach (var noteActuelle in notes)
            {
                if (noteActuelle.matiere == indexMatiere)
                {
                    somme += noteActuelle.note;
                    nombreNotes++;
                }
            }

            float moyenne = 0f;
            
            if (nombreNotes > 0)
            {
                moyenne = somme / nombreNotes;

                moyenne = (int)(moyenne * 100) / 100f;
            }

            return moyenne;
        }

        // Calcul moyenne générale d'un élève 
        public float moyenneGeneral()
        {
            float sommeMoyennes = 0f;
            int nombreMatieresAvecNotes = 0;

            for (int i = 0; i < 10; i++)
            {
                float moy = moyenneMatiere(i);

                if (moy > 0)
                {
                    sommeMoyennes += moy;
                    nombreMatieresAvecNotes++;
                }
            }

            float moyenneGeneral = 0f;

            if (nombreMatieresAvecNotes > 0)
            {
                moyenneGeneral = sommeMoyennes / nombreMatieresAvecNotes;

                moyenneGeneral = (int)(moyenneGeneral * 100) / 100f;
            }

            return moyenneGeneral;
        }
    }
}
