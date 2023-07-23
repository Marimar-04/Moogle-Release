namespace MoogleEngine;
public class Document{
   
   public string Path;
   public List<string> listwords;
   public Dictionary<string, double> TF = new Dictionary<string, double>();
   public Document(string Path, List<string> listwords){
        
        this.Path = Path;
        this.listwords = listwords;
        ParaTF();
        if(Path!="query")
            Matriz.Documentos.Add(this);
    }
    public void ParaTF(){
        foreach(string word in listwords){
            if(!TF.ContainsKey(word)){
                TF[word] = 1;
                if(Matriz.IDF.ContainsKey(word)&&Path!="query")
                    Matriz.IDF[word]++;
                else
                    Matriz.IDF[word] = 1;
            }
            else{
                TF[word]++;
            }     
        }
    }
    public string Name(){
        return Path.Substring(Path.LastIndexOf('/')+1,Path.IndexOf(".txt")-Path.LastIndexOf('/')-1);
    }
}