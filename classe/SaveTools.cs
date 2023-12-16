using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace classe
{
    public class SaveTools
    {
        public static LanguageBase lang = new LanguageBase(); // Utilisez une classe de base pour la variable lang
        public static FileProcessor fileproc = new FileProcessor();
        public static string CreateFolder(string baseDirectory)
        {
            DateTime currentDate = DateTime.Now;
            string formattedDate = currentDate.ToString("yyyy-MM-dd HH-mm");
            string folderName = formattedDate;

            string folderPath = Path.Combine(baseDirectory, folderName);

            if (!Directory.Exists(folderPath))
            {
                // Créez le dossier
                Directory.CreateDirectory(folderPath);
            }
            else
            {
                Console.WriteLine("Le dossier existe déjà.");
            }

            return folderPath;
        }
        public static void save(bool temp_lang_cc, bool sauvegardetype, int nbr_save, string langue)
        {
            // Choice of sauvegarde name
            JsonTemplate.Json(langue, "choicestainname");
            fileproc.sauvegardename = Console.ReadLine();
            fileproc.sauvegardename = fileproc.sauvegardename + '_' + nbr_save;
            // Choice off sauvegarde repos
            // C:\Users\Hugo\Desktop\fichier a sauvegarde
            FileProcessor fileProcessor = new FileProcessor();
            string sourceDir = fileProcessor.checksource(langue);

            // C:\Users\Hugo\Desktop\fichier sauvegarder
            //FileProcessor fileProcessor = new FileProcessor();
            string backupDir = fileProcessor.checktarget(langue);

            List<string[]> fileInfoList = fileProcessor.GetFileInfo(sourceDir);

            //Console.WriteLine("debut de la sauvegarde");
            DateTime time_start = DateTime.Now;
            long data = 0;
            Console.WriteLine("Progress:");
            int totalFiles = fileInfoList.Count;
            int currentFileIndex = 0;
            foreach (string[] fileInfo in fileInfoList)
            {
                

                string fName = fileInfo[0];
                string sourceFilePath = Path.Combine(sourceDir, fName);
                string destinationFilePath1 = CreateFolder(backupDir);
                string destinationFilePath = Path.Combine(destinationFilePath1, fName);
                Console.WriteLine(fileInfo[2]);
                currentFileIndex++;
                double progressPercentage = (double)currentFileIndex / totalFiles * 100;
                Console.Write($"\r[{new string('=', (int)progressPercentage / 2)}{new string(' ', 50 - (int)progressPercentage / 2)}] {progressPercentage:F2}%");
                foreach (string[] currentFile in fileInfoList)
                {
                    Console.WriteLine($"Nom: {currentFile[0]}, Extension: {currentFile[1]}, Taille: {currentFile[2]}");

                    data += long.Parse(currentFile[2]);
                }
                // la sauvegarde on la lance en dessous 
                Log fonc_logreel = new Log();

                if (fileproc.sauvegardetype == true)
                {                    
                    // sauvegarde incrémentiel
                    try
                    {
                        File.Copy(sourceFilePath, destinationFilePath, false);
                        Console.WriteLine("try succes");
                        fonc_logreel.logtempreel(fileproc.sauvegardename, "success", "NONE", sourceDir, backupDir, fileInfo.Length, data, 2);
                    }
                    catch (IOException copyError)
                    {
                        Console.WriteLine(copyError.Message); // Catch exception if the file was already copied.
                        Console.WriteLine("try error");
                        fonc_logreel.logtempreel(fileproc.sauvegardename, "success", "Error incremente", sourceDir, backupDir, fileInfo.Length, data, 2);
                    }
                    if (lang.cutcopy == true) { File.Delete(sourceFilePath); }
                }

                else // sauvegardetype = false
                {
                    // sauvegarde compléte
                    try
                    {
                        if (File.Exists(destinationFilePath))
                        {
                            File.Delete(destinationFilePath);
                            Console.WriteLine($"Fichier existant '{fName}' supprimé avant la copie.");
                        }

                        File.Copy(sourceFilePath, destinationFilePath, true);
                        Console.WriteLine($"Fichier '{fName}' copié avec succès.");
                        fonc_logreel.logtempreel(fileproc.sauvegardename, "success", "NONE", sourceDir, backupDir, fileInfo.Length, data, 2);
                    }
                    catch (IOException copyError)
                    {
                        Console.WriteLine($"Erreur lors de la copie de '{fName}': {copyError.Message}");
                        fonc_logreel.logtempreel(fileproc.sauvegardename, "success", "Error incremente", sourceDir, backupDir, fileInfo.Length, data, 2);
                    }
                    if (lang.cutcopy == true) { File.Delete(sourceFilePath); }
                }
            }
            DateTime time_stop = DateTime.Now;
            TimeSpan duration = time_start - time_stop;

            Console.WriteLine(fileInfoList);

            Log fonc_log = new Log();
            fonc_log.logcomplet(
                fileproc.sauvegardename,
            "SUCCED",
                "Cut original file = " + lang.cutcopy + "test.sauvegardetype : " + fileproc.sauvegardetype,
                sourceDir,
                backupDir,
                duration,
                data); //fileInfo in fileInfoList
        }
    }
}
