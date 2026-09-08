# LH-Pets — Sistema de Cadastro de Clientes (Balti)

Sistema de cadastro de clientes (pessoas fisicas e juridicas) desenvolvido em C# para a plataforma online de gestao de clinicas veterinarias da empresa Balti. Este projeto implementa a modelagem orientada a objetos, as regras de negocio de validacao de clientes, o calculo de imposto sobre servicos e a geracao de arquivos de registro por cliente — atividades avaliativas 3 a 7 da unidade curricular Codificacao para BackEnd.

## Funcionalidades

- Modelagem orientada a objetos com uma classe abstrata Pessoa e duas especializacoes: PessoaFisica e PessoaJuridica.
- Cadastro de pessoa fisica com validacao de idade minima (18 anos) a partir da data de nascimento.
- Cadastro de pessoa juridica com validacao basica de formato do CNPJ (14 digitos).
- Registro de endereco (residencial ou comercial) associado a cada cliente.
- Calculo do imposto (3%) sobre o valor de um servico, para clientes marcados como contribuintes.
- Geracao automatica de um arquivo .txt, nomeado com o nome do cliente, contendo seus dados cadastrais.

## Tecnologias utilizadas

- C# (.NET 8.0)
- Console Application (dotnet run)

## Organizacao do projeto

```
lhpets-cadastro-clientes/
├── README.md
├── diagrama-classes.png
├── diagrama-classes.svg
├── exemplo-saida/
│   ├── Moises Silveira.txt
│   └── Clinica Vida Animal.txt
└── src/
    ├── LHPetsCadastro.csproj
    ├── Program.cs
    ├── Pessoa.cs
    ├── PessoaFisica.cs
    ├── PessoaJuridica.cs
    ├── Endereco.cs
    └── TipoEndereco.cs
```

## Pre-requisitos

- .NET SDK 8.0 ou superior instalado na maquina (https://dotnet.microsoft.com/download).

## Execucao da aplicacao

```bash
cd src
dotnet run
```

O programa cadastra um cliente pessoa fisica e um cliente pessoa juridica de exemplo, exibe os dados no console, calcula o imposto de 3% sobre um valor de servico e salva um arquivo .txt para cada cliente na pasta clientes/ (criada automaticamente na primeira execucao).

## Erros comuns

- ArgumentException: Pessoa fisica deve ter no minimo 18 anos: ocorre ao tentar cadastrar uma pessoa fisica com menos de 18 anos. Ajuste a data de nascimento informada.
- ArgumentException: CNPJ invalido: ocorre quando o CNPJ informado nao possui 14 digitos numericos.
- dotnet: command not found: o SDK do .NET nao esta instalado ou nao esta no PATH. Instale o .NET SDK 8.0 antes de executar o projeto.
- Erro de permissao ao salvar o arquivo .txt: verifique se o usuario tem permissao de escrita na pasta onde o projeto esta sendo executado.

## Contribuidores

- Moises Silveira — desenvolvimento e documentacao
