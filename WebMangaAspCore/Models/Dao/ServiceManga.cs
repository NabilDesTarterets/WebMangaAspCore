using System.Data;
using WebMangaAspCore.Models.Persistance;
using WebMangasAspCoreModels.MesExceptions;
namespace WebMangaAspCore.Models.Dao;
{
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
}}