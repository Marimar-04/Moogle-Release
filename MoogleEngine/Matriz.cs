namespace MoogleEngine;
public static class Matriz{
    public static List<Document> Documentos = new List<Document>();

    public static Dictionary<string, double> IDF = new Dictionary<string, double>(0);

    public static void Cargamento(){
        string content ="../Content/";
        string[] docs =Directory.GetFiles(content,"*.txt");
        
        foreach(string docPath in docs){
            string text= File.ReadAllText(docPath).ToLower();
            
            List<string> listwords = StringList(text);
            new Document(docPath, listwords);
        }
    }
    public static List<string> StringList (string s){
        char[] specialChars = {'!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '-', '.', '/',
        ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '^', '_', '`', '{', '|', '}', '~', '¡', '¢',
        '£', '¤', '¥', '¦', '§', '¨', '©', 'ª', '«', '¬', '®', '¯', '°', '±', '²', '³', '´', 'µ', '¶', '·',
        '¸', '¹', 'º', '»', '¼', '½', '¾', '¿', '×', '÷',' ','\n'};
       
        return s.Split(specialChars, StringSplitOptions.TrimEntries|StringSplitOptions.RemoveEmptyEntries).ToList();
    }


    
}