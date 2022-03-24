using Bogus;
using ExpectedObjects;
using LocaSys.Domain;
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
            var clienteEsperado = new
            {
                Id = _id,
                Nome = _nome,
                CPF = _cpf,
                DtNascimento = _dtNascimento
            };

            Cliente cliente = new Cliente(clienteEsperado.Id, clienteEsperado.Nome, clienteEsperado.CPF, clienteEsperado.DtNascimento);

            clienteEsperado.ToExpectedObject().ShouldMatch(cliente);
        }
    }
}
