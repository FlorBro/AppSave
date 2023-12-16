using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using System.IO;

using classe;
using static classe.Log;
using static classe.FileProcessor;
using System.Globalization;
using System.Net.NetworkInformation;
using static classe.SaveTools;

class Program
{
    public static LanguageBase lang; // Utilisez une classe de base pour la variable lang
    public static FileProcessor fileproc;

    static void Main()
    {
        Config config = Config.LoadConfig();
        fileproc = new FileProcessor();
        MessageAccueil.Menu();

        // language choice
        string langue = LanguageTools.SelectLanguage(config.Langue);
        config.Langue = langue;

        Config.SaveConfig(config);
        // number of file
        JsonTemplate.Json(langue, "SaveN");

        int nbr_save = LanguageTools.GetNumberOfFolders();

        for (int i = 0; i < nbr_save; i++)
        {
            JsonTemplate.Json(langue, "nsave");
            LanguageTools.PrintFolderIndex(i); // nbr of save

            LanguageTools.ChooseCutCopy(lang); // cut or copy off save nbr i
            LanguageTools.t_save();// inc ou comp save
            SaveTools.save(LanguageTools.sauvegardetype, LanguageTools.temp_lang_cc, i, langue);

        }
    }
}
