namespace classe
{
    public class Language_eng : LanguageBase
    {

        public override string setlang()
        {
            return "Language set to english";
        }
        public override string choicecutcopy()
        {
            return "Do you want to COPY or CUT the file ? ";
        }
        public override string validationchoicecut()
        {
            return "Ok let's erase the orignial file";
        }
        public override string validationchoicecopy()
        {
            return "Ok let's keep the orignial file";
        }
        public override string choicestainname()
        {
            return "Please choose the stain name : ";
        }
        public override string inputmessages()
        {
            return "Please choose the repo to save : ";
        }
        public override string inputmessage()
        {
            return "Please choose the repo where you want to save : ";
        }
        public override string inputerrormessages()
        {
            return "No please choose a valid repo : ";
        }
    }
}
