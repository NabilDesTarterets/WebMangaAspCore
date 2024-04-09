using System.Data;
using WebMangaAspCore.Models.Persistance;
using WebMangasAspCoreModels.MesExceptions;
namespace WebMangaAspCore.Models.Dao;

public class ServiceManga
{
    public static DataTable GetTousLesManga()
    {
        DataTable mesMangas;
        Serreurs er = new Serreurs("Erreur sur lecture des Mangas.", "Manga.getMangas()");
        try
        {
            String mysql = "Select id_manga,lib_genre,nom_dessinateur,non_scenariste,dateParution, prix, couverture ";
            mysql += "from Manga join genre on manga.id_genre = genre.id_genre ";
            mysql += "join dessinateur on manga.id_dessinateur = dessinateur.id_dessinateur";
            mysql += "join scenariste on manga.id_scenariste = scenariste.id_scenariste ";
            mesMangas = DBInterface.Lecture(mysql, er);
            return mesMangas;
        }
        catch (MonException e)
        {
            throw new MonException(er.MessageUtilisateur(), er.MessageApplication(), e.Message);
        }
    }
    public static Manga GetunManga(string id)
    {
        DataTable dt;
        Manga unManga = null;
        Serreurs er = new Serreurs("Erreur sur lecture des Mangas", "ServiceManga.getunManga()");
        try
        {
            string mysql = "Select id_manga,id_genre,id_dessinateur,id_scenariste,titre,dateParution,prix,couverture";
            mysql += " from Manga ";
            mysql += " where id_manga = " + id;
            dt = DBInterface.Lecture(mysql, er);
            if (dt.IsInitialized && dt.Rows.Count > 0)
            {
                unManga = new Manga();
                DataRow dataRow = dt.Rows[0];
                unManga.Id_manga = int.Parse(dataRow[0].ToString());
                unManga.Id_genre = int.Parse(dataRow[1].ToString());
                unManga.Id_dessinateur = int.Parse(dataRow[2].ToString());
                unManga.Id_scenariste = int.Parse(dataRow[3].ToString());
                unManga.Titre = int.Parse(dataRow[4].ToString());
                unManga.DateParution = int.Parse(dataRow[5].ToString());
                unManga.Prix = int.Parse(dataRow[6].ToString());
                unManga.Couverture = int.Parse(dataRow[7].ToString());
                return unManga;
            }
            else
            {
                return null;
            }
            catch (MonException e)
        {
            throw new MonException(er.MessageUtilisateur(), er.MessageApplication, e.Message);
        }
    }
}

