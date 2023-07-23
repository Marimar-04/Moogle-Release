namespace MoogleEngine;


public static class Moogle
{
    public static SearchResult Query(string query) {
        // Modifique este método para responder a la búsqueda

        SearchItem[] items = Search(query);

        return new SearchResult(items, query);
    }
    

    public static SearchItem[] Search(string query){
        Document qyd = new Document("query", Matriz.StringList(query));
        List<SearchItem> resultado = new List<SearchItem>();
        foreach(Document d in Matriz.Documentos){
            double score = Prodacal(qyd, d);
            if (score>0){
                resultado.Add(new SearchItem(d.Name(), score.ToString(), ((float)score)));
            }

        }
        return resultado.OrderByDescending(x=>x.Score).ToArray();
    }
    public static double Prodacal(Document d1, Document d2){
        double result = 0;
        foreach(string word in d1.TF.Keys){
            if(Matriz.IDF.ContainsKey(word)&& d2.TF.ContainsKey(word)){
                double idf = Math.Log(Matriz.Documentos.Count/Matriz.IDF[word]);
                result += ((d1.TF[word]/d1.listwords.Count)*idf) * ((d2.TF[word]/d2.listwords.Count)*idf);
            }

        }
        return result;
    }
    
}
 