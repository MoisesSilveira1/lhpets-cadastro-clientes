using System;
using System.IO;

namespace LHPetsCadastro
{
    /// <summary>
    /// Cliente pessoa física (tutor de animal) cadastrado na plataforma Balti.
    /// </summary>
    public class PessoaFisica : Pessoa
    {
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }

        /// <summary>
        /// Percentual de imposto cobrado sobre o valor dos serviços/produtos,
        /// conforme definido na Avaliação 5 (Projeto Prático - Parte 2).
        /// </summary>
        private const decimal PercentualImposto = 0.03m; // 3%

        public PessoaFisica(string nome, string cpf, DateTime dataNascimento, Endereco endereco, bool pagaImposto)
            : base(nome, endereco, pagaImposto)
        {
            CPF = cpf;
            DataNascimento = dataNascimento;

            if (!ValidarIdadeMinima())
            {
                throw new ArgumentException("Pessoa física deve ter no mínimo 18 anos para ser cadastrada.");
            }
        }

        /// <summary>
        /// Verifica se a pessoa física possui, no mínimo, 18 anos de idade,
        /// considerando a data de nascimento em relação à data atual.
        /// </summary>
        public bool ValidarIdadeMinima()
        {
            int idade = DateTime.Today.Year - DataNascimento.Year;
            if (DataNascimento.Date > DateTime.Today.AddYears(-idade))
            {
                idade--;
            }
            return idade >= 18;
        }

        /// <summary>
        /// Calcula e retorna o valor do imposto (3%) sobre um valor informado,
        /// caso a pessoa física esteja marcada como contribuinte (PagaImposto).
        /// </summary>
        public decimal PagarImposto(decimal valor)
        {
            if (!PagaImposto)
            {
                return 0m;
            }

            return valor * PercentualImposto;
        }

        /// <summary>
        /// Salva um arquivo .txt com o mesmo nome do cliente, contendo seus
        /// dados cadastrais — conforme exigido na Avaliação 6.
        /// </summary>
        public void SalvarArquivoTxt(string pastaDestino = "clientes")
        {
            Directory.CreateDirectory(pastaDestino);
            string caminho = Path.Combine(pastaDestino, $"{Nome}.txt");

            using (StreamWriter writer = new StreamWriter(caminho))
            {
                writer.WriteLine($"Nome: {Nome}");
                writer.WriteLine($"CPF: {CPF}");
                writer.WriteLine($"Data de Nascimento: {DataNascimento:dd/MM/yyyy}");
                writer.WriteLine($"Endereço: {Endereco}");
                writer.WriteLine($"Paga imposto: {(PagaImposto ? "Sim" : "Não")}");
            }

            Console.WriteLine($"Arquivo salvo em: {caminho}");
        }

        public override void ExibirDados()
        {
            base.ExibirDados();
            Console.WriteLine($"CPF: {CPF}");
            Console.WriteLine($"Data de Nascimento: {DataNascimento:dd/MM/yyyy}");
        }
    }
}
