using ConsultaCep.Servico.Modelo;
using Newtonsoft.Json;
using System.Net;

namespace ConsultaCep.Servico
{
    public class ViaCepServico
    {
        private static string _enderecoUrl = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string novoEnderecoUrl = string.Format(_enderecoUrl, cep);
            var wc = new WebClient();
            string conteudo = wc.DownloadString(novoEnderecoUrl);
            var end = JsonConvert.DeserializeObject<Endereco>(conteudo);
            return end.cep == null ? null : end;
        }

    }
}
