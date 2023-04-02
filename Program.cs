// See https://aka.ms/new-console-template for more information
using Linq;

LinqQueries queries=new LinqQueries();

//Resltado de consultas con linq


//todos los libros
//ImprimirLibros(queries.MostrarLibros());

//Libros publicados luego del 2000

//ImprimirLibros(queries.LisbrosDespues2000());
//Libros de mas de 250 paginas y el titulo contiene in Action
//ImprimirLibros(queries.ListaLibrosGrandres());

//Console.WriteLine($"Todos los libros tienen estatus? -{queries.TodosLosLibrosTienenEstatus()}");
//Console.WriteLine($"¿Hay libros del 2005? -  {queries.FechaPublicacion()}");

//ImprimirLibros(queries.LisbrosPhyton());

//ImprimirLibros(queries.LisbrosJavaPorNombre());

//ImprimirLibros(queries.LibrosMasDe450PaginasOrdenadosDecendentemente());
//ImprimirLibros(queries.TresPrimerosOrdenadosPorFecha());
//ImprimirLibros(queries.DosPrimerosLibrosDeMasDe400Paginas());
//ImprimirLibros(queries.TresprimeroLibrosTituloYCantidadDePaginas());
//Console.WriteLine($"los lisbros que cumplen esta condición son: {queries.cantidadDelibrosPagina()}");
//Console.WriteLine($"los lisbros que cumplen esta condición son: {queries.FechaDeUltimaPublicación()}");
//Console.WriteLine($"lisbro con mas páginas: {queries.LbroMayorNumeroPaginas()}");
//ImprimirLibro(queries.LibrosMenorPaginasMayorA0());
//ImprimirLibro(queries.LibrosMayorFechaPublicacion());
//Console.WriteLine($"Suma de los libros que tienen entre 0 y 500 páginas: {queries.SumaCantidadPaginas()}");
//Console.WriteLine(queries.LibrosDespues2015Concatenados());
//ImprimirLibrosAgrupados(queries.LibrosAgrupadosPorAno());
//improme consultas que devuelven una lista de liboros

//var diccionario=queries.DiccionariosLibrosPorLetraTitulo();
//ImprimirDiccionario(diccionario,'A');
ImprimirLibros(queries.LibrosDespues2005MasDe500Paginas());


void ImprimirDiccionario(ILookup<char, Book> listalibros,char letra)
         {
           Console.WriteLine("{0,-60}{1,15}{2,11}\n","Titulo","N° de Páginas","  Fecha de publicación");

            foreach (var item in listalibros[letra])
           {
        Console.WriteLine("{0,-60}{1,15}{2,11}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
           }
            }
        
void ImprimirLibros(IEnumerable<Book> listalibros)
{
Console.WriteLine("{0,-60}{1,15}{2,11}\n","Titulo","N° de Páginas","  Fecha de publicación");

    foreach (var item in listalibros)
    {
        Console.WriteLine("{0,-60}{1,15}{2,11}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}



//Imprime consultas que devuelven un solo libro

void ImprimirLibro(Book libro){
    Console.WriteLine("{0,-60}{1,15}{2,11}\n","Titulo","N° de Páginas","  Fecha de publicación");

    
    
        Console.WriteLine("{0,-60}{1,15}{2,11}", libro.Title, libro.PageCount, libro.PublishedDate.ToShortDateString());
    }

    //Implime una lista de libros agrupada por un parámetro

    void ImprimirLibrosAgrupados(IEnumerable<IGrouping<int,Book>> listalibros){
        foreach (var grupo in listalibros)

        {
            Console.WriteLine("");
            Console.WriteLine($"Grupo: {grupo.Key}");
            Console.WriteLine("{0,-60}{1,15}{2,11}\n","Titulo","N° de Páginas","  Fecha de publicación"); 
             foreach (var item in grupo)
             {
               Console.WriteLine("{0,-60}{1,15}{2,11}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
            } 


            //Imprime diccionario de titulos de libros

           

           void ImprimirDiccionario(ILookup<char, Book> listalibros,char letra)
         {
           Console.WriteLine("{0,-60}{1,15}{2,11}\n","Titulo","N° de Páginas","  Fecha de publicación");

            foreach (var item in listalibros[letra])
           {
        Console.WriteLine("{0,-60}{1,15}{2,11}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
           }
            }
        }
    

   
}
