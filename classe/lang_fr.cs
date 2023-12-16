using System.Text.Json;
namespace classe
{
    public class Language_fr : LanguageBase
    {
        public override string setlang()
        {
            return "Langue reglé sur français";
        }
        public override string choicecutcopy()
        {
            return "Voulez vous COUPEZ ou COPIE le fichier initiale ?";
        }
        public override string validationchoicecut()
        {
            return "Ok on va effacer le fichier original";
        }
        public override string validationchoicecopy()
        {
            return "Ok on va garder le fichier original";
        }
        public override string choicestainname()
        {
            return "Choisissez le nom de la sauvegarde";
        }
        public override string inputmessages()
        {
            return "Choississez le depo a save : ";
        }
        public override string inputerrormessages()
        {
            return "Non, veuillez choisi un repo valide : ";
        }
        public override string inputmessage()
        {
            return "Choississez le depo ou vous voulez save : ";
        }
    }
}