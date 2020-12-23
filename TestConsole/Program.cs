using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;


namespace TestConsole
{
    class Program
    {
        private static void Main(string[] args)
        {
            IRepository Repository = new Modelo.Repository();
            var Categorias = Repository.FindEntitySet<Category>(c => true);
            var Category1 = Repository.Create(new Category
            {
                CategoryName = "Educacion"
            });
            var Customer1 = Repository.Create(new Customer
            {
                CustomerID="PUCE",
                CompanyName="PUCESE"
            });

            Console.WriteLine("Precione enter para finalizar");
            Console.ReadLine();
        }
    }

    internal class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
    }
}
