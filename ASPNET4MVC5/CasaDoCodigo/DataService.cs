using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;

namespace CasaDoCodigo
{
    interface IDataService
    {
        void InicializaDB();
    }

    class DataService : IDataService
    {
        private readonly ApplicationContext contexto;
        private readonly IProdutoRepository produtoRepository;

        public DataService(ApplicationContext contexto,
            IProdutoRepository produtoRepository)
        {
            this.contexto = contexto;
            this.produtoRepository = produtoRepository;
        }

        public void InicializaDB()
        {
            contexto.Database.CreateIfNotExists();

            List<Livro> livros = GetLivros();

            produtoRepository.SaveProdutos(livros);
        }

        private static List<Livro> GetLivros()
        {
            var json = File.ReadAllText(HostingEnvironment.MapPath(@"~/App_Data/livros.json"));
            var livros = JsonConvert.DeserializeObject<List<Livro>>(json);
            return livros;
        }
    }


}
