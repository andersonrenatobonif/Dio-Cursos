﻿//using CatalogoJogos.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace CatalogoJogos.Repositorio
//{
//    public class JogoRepository : IJogoRepository
//    {
//        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>();
//        //{
//        //    { }
//        //};

//        public Task<List<Jogo>> Obter(int pagina, int quantidade)
//        {
//            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
//        }

//        public Task<Jogo> Obter(Guid id)
//        {
//            if (!jogos.ContainsKey(id))
//                return null;

//            return Task.FromResult(jogos[id]);
//        }

//        //public Task<List<Jogo>> Obter(string nome, string produtora)
//        //{
//        //    return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
//        //}

//        public Task<List<Jogo>> ObterSemLambda(string nome, string produtora)
//        {
//            var retorno = new List<Jogo>();

//            foreach (var jogo in jogos.Values)
//            {
//                if (jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora))
//                    retorno.Add(jogo);
//            }

//            return Task.FromResult(retorno);
//        }

//        public Task Inserir(Jogo jogos)
//        {
//            jogos.Add(jogos.Id, jogos);
//            return Task.CompletedTask;
//        }

//        public Task Atualizar(Jogo jogo)
//        {
//            jogos[jogo.Id] = jogo;
//            return Task.CompletedTask;
//        }

//        public Task Remover(Guid id)
//        {
//            jogos.Remove(id);
//            return Task.CompletedTask;
//        }

//        public void Dispose()
//        {
//            //trecho conexão com o banco
//        }

//        public Task<List<Jogo>> Obter(string nome, string produtora)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
