using LocaSys.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocaSys.DomainTest.Builders
{
    public class ClienteBuilder
    {
        private int _id = 0;
        private string _nome = "Magno Bastos";
        private string _cpf = "01584654660";
        private string _dtNascimento = "18/05/1988";

        public static ClienteBuilder CriarBuilder()
        {
            return new ClienteBuilder();
        }

        public ClienteBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public ClienteBuilder ComCpf(string cpf)
        {
            _cpf = cpf;
            return this;
        }

        public ClienteBuilder ComDataNascimento(string dtNascimento)
        {
            _dtNascimento = dtNascimento;
            return this;
        }

        public Cliente Build()
        {
            return new Cliente(_id, _nome, _cpf, _dtNascimento);
        }
    }
}
