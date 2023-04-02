using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linq
{
    public class LinqQueries
    {
        private List<Book> libros=new List<Book>();
        public LinqQueries()
        {
            using (StreamReader reader=new StreamReader("books.json"))
            {

            string json=reader.ReadToEnd();
            this.libros=System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json,new System.Text.Json.JsonSerializerOptions(){PropertyNameCaseInsensitive=true})!;
            
        }
    }
    public IEnumerable<Book> MostrarLibros(){
        return libros;
    }

    public IEnumerable<Book> LisbrosDespues2000(){
        //EXTESION METEDO
        //return libros.Where(p=>p.PublishedDate.Year>2000);

        //Query expresion

        return from l in libros where l.PublishedDate.Year>2000 select l;
    }

    public IEnumerable<Book> ListaLibrosGrandres(){
         //EXTESION METEDO
       
       // return libros.Where(p=>p.PageCount>250 && p.Title.Contains("in Action"));

       return from l in libros where  l.PageCount>250 && l.Title.Contains("in Action")select l;
    }

    // public bool TodosLosLibrosTienenEstatus(){
    //     //Extension Method
    //     return libros.All(p=>p.Status!=string.Empty);
    // }

    public bool FechaPublicacion(){
        return libros.Any(p=>p.PublishedDate.Year==2005);
    }

    public IEnumerable<Book> LisbrosPhyton(){
        return libros.Where(p=>p.Categories.Contains("Python"));
    }

    public IEnumerable<Book> LisbrosJavaPorNombre(){
      
        return libros.Where(p=>p.Categories.Contains("Java")).OrderBy(p=>p.Title);
    }

    public IEnumerable<Book> LibrosMasDe450PaginasOrdenadosDecendentemente(){
        return libros.Where(p=>p.PageCount>450).OrderByDescending(p=>p.PageCount);
    }

    public IEnumerable<Book> TresPrimerosOrdenadosPorFecha(){
        return  libros.Where(p=>p.Categories.Contains("Java")).Take(3).OrderBy(p=>p.PublishedDate.Year);
    }

    public IEnumerable<Book>DosPrimerosLibrosDeMasDe400Paginas(){
        return libros.Where(p=>p.PageCount>400).Take(4).Skip(2);
    }

    public IEnumerable<Book> TresprimeroLibrosTituloYCantidadDePaginas(){
        return libros.Take(3).
        Select(p=>new Book{Title=p.Title, PageCount=p.PageCount});
    }

    public int cantidadDelibrosPagina(){
        return  libros.Where(p=>p.PageCount>=200 && p.PageCount<=500).Count();
    }
    public DateTime FechaDeUltimaPublicación(){
        return libros.Min(p=>p.PublishedDate);

    }

    public int LbroMayorNumeroPaginas(){
        return libros.Max(p=>p.PageCount);

    }

    public Book LibrosMenorPaginasMayorA0(){
        return libros.Where(p=>p.PageCount>0).MinBy(P=>P.PageCount);
    }

    public Book LibrosMayorFechaPublicacion(){
        return libros.MaxBy(P=>P.PublishedDate);
    }

    public int SumaCantidadPaginas(){
        return libros.Where(p=>p.PageCount>=0 && p.PageCount<=500).Sum(p=>p.PageCount);
    }

    public string LibrosDespues2015Concatenados(){
        return libros.Where(p=>p.PublishedDate.Year>2015).
        Aggregate("",(TituloLibro,next)=>{

            if (TituloLibro!=string.Empty)
            {
                TituloLibro="-"+ next.Title;
            }else{
                TituloLibro=next.Title;
            }

            return TituloLibro;


        });
    }

    public double PromedioCaracteresLibrosMayor100(){
        return libros.Where(p=>p.PageCount>=100).Average(p=>p.Title.Length);
    }

    public IEnumerable<IGrouping<int,Book>> LibrosAgrupadosPorAno(){

        return libros.Where(p=>p.PublishedDate.Year>200 && p.PageCount>=100).GroupBy(p=>p.PublishedDate.Year);
    }

    public ILookup<char,Book> DiccionariosLibrosPorLetraTitulo(){
        return libros.ToLookup(p=>p.Title[0], p=>p);
    } 

    public IEnumerable<Book> LibrosDespues2005MasDe500Paginas(){
        var LibrosDespuesDe2005=libros.Where(p=>p.PublishedDate.Year>2005);
        var librosMas500Paginas=libros.Where(p=>p.PageCount>500);
        return  librosMas500Paginas.Join(LibrosDespuesDe2005,p=>p.Title,x=>x.Title,(p,x)=>p);
    }
}
}