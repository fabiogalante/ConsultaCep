using System;
using System.ComponentModel;
using ConsultaCep.Servico;
using ConsultaCep.Servico.Modelo;
using Xamarin.Forms;

namespace ConsultaCep
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BotaoBuscarCep.Clicked += OnBuscarCep;
        }

        private void OnBuscarCep(object sender, EventArgs e)
        {
            string cep = Cep.Text;

            if (OnIsValidCep(cep))
            {
                try
                {
                    var end = ViaCepServico.BuscarEnderecoViaCEP(cep.Trim());

                    if (end != null)
                    {
                        Result.Text = $"Endereço: {end.Logradouro} de {end.bairro} {end.localidade},{end.uf} ";
                    }
                    else
                    {
                        DisplayAlert("ERRO", $"O endereço não foi encontrado para o CEP informado: {cep}", "OK");
                    }

                }
                catch (Exception ex)
                {
                    DisplayAlert("ERRO CRÍTICO", ex.Message, "OK");
                }
            }
        }

        private bool OnIsValidCep(string cep)
        {
            if (string.IsNullOrEmpty(cep) || cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP inválido! O CEP deve conter 8 caracteres.", "OK");
                return false ;
            }


            if (!int.TryParse(cep, out _))
            {
                DisplayAlert("ERRO", "CEP inválido! O CEP deve ser composto apenas por números.", "OK");
                return false;
            }


            return true;
        }
    }
}
