using Bogus;
using ExpectedObjects;
using LocaSys.Domain;
using LocaSys.DomainTest.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LocaSys.DomainTest.Clientes
{
    public class ClienteTest: IDisposable
    {
        private int _id;
        private string _nome;
        private string _cpf;
        private DateTime _dtNascimento;

        public ClienteTest()
        {
            Faker faker = new Faker();

            _id = 0;
            _nome = $"{faker.Person.FirstName} {faker.Person.LastName}";
            _cpf = faker.Random.ReplaceNumbers("###########");
            _dtNascimento = faker.Person.DateOfBirth;
        }

        public void Dispose()
        {
            
        }

        [Fact]
        public void DeveGravarCliente()
        {
            //TODO: Descobrir o motivo pelo qual este teste não está passando.
            var clienteEsperado = new
            {
                Id = _id,
                Nome = _nome,
                CPF = _cpf,
                DtNascimento = _dtNascimento
            };

            Cliente cliente = new Cliente(clienteEsperado.Id, clienteEsperado.Nome, clienteEsperado.CPF, clienteEsperado.DtNascimento.ToString());

            clienteEsperado.ToExpectedObject().ShouldMatch(cliente);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DadoNomeVazioOuNuloEhLancadoUmaArgumentException(string nome)
        {
            string mensagemException = Assert.Throws<ArgumentException>(() =>
                ClienteBuilder.CriarBuilder().ComNome(nome).Build()).Message;

            Assert.Equal("Nome é obrigatório.", mensagemException);
        }

        [Fact]
        public void DadoNomeComMaisDe200CaracteresEhLancadaUmaArgumentException()
        {
            string mensagemException = Assert.Throws<ArgumentException>(() =>
                ClienteBuilder.CriarBuilder().ComNome(String.Concat(Enumerable.Repeat("a", 201))).Build()).Message;

            Assert.Equal("Nome não pode conter mais de 200 caracteres.", mensagemException);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DadoCpfVazioOuNuloEhLancadoUmaArgumentException(string cpf)
        {
            string mensagemException = Assert.Throws<ArgumentException>(() =>
                ClienteBuilder.CriarBuilder().ComCpf(cpf).Build()).Message;

            Assert.Equal("Cpf é obrigatório.", mensagemException);
        }
        
        [Fact]
        public void DadoCpfMaiorQue11CaracteresEhLancadaUmaArgumentException()
        {
            string mensagemException = Assert.Throws<ArgumentException>(() =>
                ClienteBuilder.CriarBuilder().ComCpf("123456789012").Build()).Message;

            Assert.Equal("Cpf inválido.", mensagemException);
        }

        [Theory]
        [InlineData("32/03/2022")]
        [InlineData("30/02/2022")]
        [InlineData("29/02/2022")]
        [InlineData("29/13/2022")]
        public void DadoDtNascimentoInvalidaEhLancadaUmaException(string dtNascimento)
        {
            string mensagemException = Assert.Throws<ArgumentException>(() =>
                ClienteBuilder.CriarBuilder().ComDataNascimento(dtNascimento).Build()).Message;

            Assert.Equal("Data de nascimento inválida.", mensagemException);
        }
    }
}
