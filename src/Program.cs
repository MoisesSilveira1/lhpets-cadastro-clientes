using System;

namespace LHPetsCadastro
{
    /// <summary>
    /// Programa de demonstração do sistema de cadastro de clientes (pessoa
    /// física e pessoa jurídica) da plataforma de gestão de clínicas
    /// veterinárias da Balti — Avaliações 3 a 7 de Codificação para BackEnd.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Endereco enderecoTutor = new Endereco("Rua das Flores, 123", "Brasília", TipoEndereco.Residencial);
            PessoaFisica tutor = new PessoaFisica(
                nome: "Moises Silveira",
                cpf: "123.456.789-00",
                dataNascimento: new DateTime(1995, 5, 20),
                endereco: enderecoTutor,
                pagaImposto: true
            );

            Endereco enderecoClinica = new Endereco("Av. Principal, 500", "Brasília", TipoEndereco.Comercial);
            PessoaJuridica clinicaParceira = new PessoaJuridica(
                nome: "Clinica Vida Animal",
                cnpj: "12.345.678/0001-99",
                razaoSocial: "Vida Animal Servicos Veterinarios LTDA",
                endereco: enderecoClinica,
                pagaImposto: true
            );

            Console.WriteLine("===== Dados cadastrados =====");
            tutor.ExibirDados();
            Console.WriteLine();
            clinicaParceira.ExibirDados();
            Console.WriteLine();

            // Avaliação 5 - Projeto Prático - Parte 2: cálculo de imposto (3%)
            decimal valorServico = 250.00m;
            decimal imposto = tutor.PagarImposto(valorServico);
            Console.WriteLine($"Imposto sobre R$ {valorServico:F2} (3%): R$ {imposto:F2}");
            Console.WriteLine();

            // Avaliação 6 - Guardar um arquivo txt (nomeado com o nome do cliente)
            tutor.SalvarArquivoTxt();
            clinicaParceira.SalvarArquivoTxt();
        }
    }
}
