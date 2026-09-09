using System;
using System.IO;
using System.Linq;

namespace LHPetsCadastro
{
    /// <summary>
    /// Cliente pessoa jurídica (empresa/clínica parceira) cadastrado na
    /// plataforma Balti.
    /// </summary>
    public class PessoaJuridica : Pessoa
    {
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }

        public PessoaJuridica(string nome, string cnpj, string razaoSocial, Endereco endereco, bool pagaImposto)
            : base(nome, endereco, pagaImposto)
        {
            if (!ValidarCNPJ(cnpj))
            {
                throw new ArgumentException("CNPJ inválido: deve conter 14 dígitos numéricos.");
            }

            CNPJ = cnpj;
            RazaoSocial = razaoSocial;
        }

        /// <summary>
        /// Validação simples de formato do CNPJ: exige exatamente 14 dígitos
        /// numéricos (ignorando pontuação como "." "/" "-").
        /// </summary>
        public static bool ValidarCNPJ(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
            {
                return false;
            }

            string apenasDigitos = new string(cnpj.Where(char.IsDigit).ToArray());
            return apenasDigitos.Length == 14;
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
                writer.WriteLine($"CNPJ: {CNPJ}");
                writer.WriteLine($"Razão Social: {RazaoSocial}");
                writer.WriteLine($"Endereço: {Endereco}");
                writer.WriteLine($"Paga imposto: {(PagaImposto ? "Sim" : "Não")}");
            }

            Console.WriteLine($"Arquivo salvo em: {caminho}");
        }

        public override void ExibirDados()
        {
            base.ExibirDados();
            Console.WriteLine($"CNPJ: {CNPJ}");
            Console.WriteLine($"Razão Social: {RazaoSocial}");
        }
    }
}
