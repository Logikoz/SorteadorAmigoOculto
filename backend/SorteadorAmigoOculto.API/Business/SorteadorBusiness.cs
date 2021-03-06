using SorteadorAmigoOculto.API.Business.Interfaces;
using SorteadorAmigoOculto.Helpers;
using SorteadorAmigoOculto.Models.Entity;

using System;
using System.Collections.Generic;
using System.Linq;

namespace SorteadorAmigoOculto.Business
{
    public class SorteadorBusiness : ISorteadorBusiness
    {
        public Dictionary<Pessoa, Pessoa> SorteiaAmigoOculto(List<Pessoa> pessoas)
        {
            if (pessoas == null)
            {
                throw new ArgumentNullException(nameof(pessoas));
            }

            if (pessoas.Count == 0)
            {
                throw new InvalidOperationException("The list passed as argument is empty.");
            }

            if (pessoas.Count == 1)
            {
                throw new InvalidOperationException("The list passed has only one person.");
            }

            var listaSorteada = new Dictionary<Pessoa, Pessoa>();

            var pessoasASeremTiradas = pessoas.Select(x => x).ToList();

            while (pessoas.Count != 0)
            {
                pessoas.Shuffle();
                pessoasASeremTiradas.Shuffle();
                Pessoa pessoaTirou = pessoas.First();
                Pessoa pessoaTirada = pessoasASeremTiradas.First();

                if (pessoaTirou.Equals(pessoaTirada)) continue;

                listaSorteada.Add(pessoaTirou, pessoaTirada);

                pessoas.Remove(pessoaTirou);
                pessoasASeremTiradas.Remove(pessoaTirada);
            }

            return listaSorteada;
        }
    }
}