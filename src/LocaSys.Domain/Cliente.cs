using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocaSys.Domain
{
    public class Cliente
    {
        public Cliente(int id, string nome, string cpf, DateTime dtNascimento)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentNullException("Nome é obrigatório.");

            if (nome.Length > 200)
                throw new ArgumentException("Nome não pode conter mais de 200 caracteres.");

            if (string.IsNullOrEmpty(cpf))
                throw new ArgumentNullException("Cpf é obrigatório.");

            if (cpf.Length > 11)
                throw new ArgumentException("Cpf inválido.");

            if (dtNascimento == DateTime.MinValue)
                throw new ArgumentException("Data inválida.");

            Id = id;
            Nome = nome;
            CPF = cpf;
            DtNascimento = dtNascimento;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public DateTime DtNascimento { get; private set; }
    }
}
