using System;
using classe;

using static classe.JsonTemplate;

public class LanguageTools
{
    public static string lang_str { get; set; }
    public static bool temp_lang_cc { get; set; }
    public static bool sauvegardetype { get; set; }


    public static string SelectLanguage(string default_lang)
    {
        while (true)
        {
            //lang_str = default_lang;
            JsonTemplate.Json(default_lang, "defaultlang");
            string inputLanguage = Console.ReadLine();

            string choiceMessage = SetLanguage(inputLanguage);

            if (choiceMessage.StartsWith("Langue non prise"))
            {
                //Console.WriteLine(choiceMessage);
                return "";
            }
            else
            {
                JsonTemplate.Json(inputLanguage, "setlang");
                //Console.WriteLine(choiceMessage);
                lang_str = inputLanguage;
                return inputLanguage;
                //break;
            }
        }
    }

    private static string SetLanguage(string inputLanguage)
    {
        switch (inputLanguage)
        {
            case "FR":
                return "Langue fran�aise s�lectionn�e.";

            case "ENG":
                return "English language selected.";

            case "DE":
                return "Deutsche Sprache ausgew�hlt.";

            default:
                return "Langue non prise en charge, veuillez s�lectionner FR, ENG ou DE.";
        }
    }
    public static void PrintNumberOfFolders()
    {
        Console.WriteLine("Combien de dossiers : ");
    }

    public static int GetNumberOfFolders()
    {
        int nbr_save;
        while (true)
        {
            Console.Write("Veuillez entrer un nombre valide : ");

            if (int.TryParse(Console.ReadLine(), out nbr_save) && nbr_save > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Entr�e invalide. Veuillez entrer un nombre entier positif.");
            }
        }
        return nbr_save;
    }

    public static void PrintFolderIndex(int index)
    {
        Console.WriteLine($"{index + 1}");
    }

    public static void ChooseCutCopy(LanguageBase lang)
    {
        while (true)
        {
            JsonTemplate.Json(lang_str, "choicecutcopy");
            string inputstart = Console.ReadLine();
            inputstart = inputstart.ToUpper();

            if (inputstart == "COPY" || inputstart == "COPIER" || inputstart == "KOPIEREN" || inputstart == "KOPIE")
            {
                temp_lang_cc = false;
                JsonTemplate.Json(lang_str, "validationchoicecopy");
            }
            else if (inputstart == "CUT" || inputstart == "COUPER" || inputstart == "SCHNEIDEN")
            {
                temp_lang_cc = true;
                JsonTemplate.Json(lang_str, "validationchoicecut");
            }
            else
            {
                Console.WriteLine("Choix non valide. Veuillez r�essayer.");
                continue; // Retourne au d�but de la boucle
            }
            break;
        }
    }
    // type off save
    public static void t_save()
    {
        while (true)
        {
            JsonTemplate.Json(lang_str, "savetype");
            string save_type = Console.ReadLine();
            save_type = save_type.ToUpper();

            if (save_type == "COMPLETE" || save_type == "COMP" || save_type == "C" || save_type == "VOLLST�NDIGES" || save_type == "V")
            {
                sauvegardetype = false;
            }
            else if (save_type == "DIFFERENTIEL" || save_type == "DIF" || save_type == "D" || save_type == "DIFFERENTIAL" || save_type == "DIFFERENTIELLES")
            {
                sauvegardetype = true;
            }
            else
            {
                continue; // Retourne au d�but de la boucle
            }
            break;
        }
    }
}
