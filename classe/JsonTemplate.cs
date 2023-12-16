using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace classe
{
    public class JsonTemplate
    {
 

        public static void Json(string inputlanguage,string state)
        {

            // Obtenir le répertoire du projet (répertoire du fichier source)
            string repertoireProjet = AppContext.BaseDirectory;

            // Remonter de quatre niveaux pour obtenir le répertoire du projet
            for (int i = 0; i < 4; i++)
            {
                repertoireProjet = Directory.GetParent(repertoireProjet).FullName;
            }

            // Construire le chemin d'accès au fichier JSON en utilisant le répertoire du projet
            string cheminFichier; //= Path.Combine(repertoireProjet, inputlanguage == "FR" ? "language_fr.json" : (inputlanguage == "ENG" ? "lang_eng.json" : "default_lang.json"));
            switch (inputlanguage)
            {
                case "FR":
                    cheminFichier = Path.Combine(repertoireProjet, "language_fr.json");
                    break;
                case "ENG":
                    cheminFichier = Path.Combine(repertoireProjet, "lang_eng.json");
                    break;
                case "DE":
                    cheminFichier = Path.Combine(repertoireProjet, "De_de.json");
                    break;
                default:
                    throw new ArgumentException("Invalid language. Please choose between FR, ENG, or DE.");
            }

            string jsonContent = File.ReadAllText(cheminFichier);
            JsonDocument jsonDoc = JsonDocument.Parse(jsonContent);
            JsonElement root = jsonDoc.RootElement;
            // Utilisation d'un dictionnaire pour stocker les états et leurs valeurs associées
            var stateDictionary = new Dictionary<string, string>
            {
                { "setlang", "setlang" }, //associe chaque clé (state) à une valeur correspondant à celle du Json.
                { "choicecutcopy", "choicecutcopy" },
                { "validationchoicecut", "validationchoicecut" },
                { "validationchoicecopy", "validationchoicecopy" },
                { "choicestainname", "choicestainname" },
                { "inputmessages", "inputmessages" },
                { "inputerrormessages", "inputerrormessages" },
                { "inputmessage", "inputmessage" },
                { "savetype", "savetype" },
                { "nsave", "nsave" },
                { "sucess", "sucess" },
                { "SaveN", "SaveN" },
                {"defaultlang", "defaultlang" }
            };

            // Vérifier si l'état existe dans le dictionnaire avant d'afficher
            if (stateDictionary.ContainsKey(state))
            {
                Console.WriteLine(root.GetProperty(state).GetString());
            }
        }
    }
}