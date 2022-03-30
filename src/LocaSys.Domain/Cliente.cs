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
        public Cliente(int id, string nome, string cpf, string dtNascimento)
        {
            if (nome is null || nome == String.Empty)
                throw new ArgumentException("Nome é obrigatório.");

            if (nome.Length > 200)
                throw new ArgumentException("Nome não pode conter mais de 200 caracteres.");

            if (cpf is null || cpf == String.Empty)
                throw new ArgumentException("Cpf é obrigatório.");

            if (cpf.Length > 11)
                throw new ArgumentException("Cpf inválido.");

            if(!IsDateTime(dtNascimento))
                throw new ArgumentException("Data de nascimento inválida.");

            Id = id;
            Nome = nome;
            CPF = cpf;
            DtNascimento = DateTime.Parse(dtNascimento);
        }

        private static bool IsDateTime(string date)
        {
            DateTime tempDate;
            return DateTime.TryParse(date, out tempDate);
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public DateTime DtNascimento { get; private set; }
    }
}
