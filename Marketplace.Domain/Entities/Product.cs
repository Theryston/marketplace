using Marketplace.Domain.Validations;

namespace Marketplace.Domain.Entities
{
    public sealed class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string CodeErp { get; private set; }
        public decimal Price { get; private set; }

        public Product(string name, string codeErp, decimal price)
        {
            Validation(name, codeErp, price);

            Name = name;
            CodeErp = codeErp;
            Price = price;
        }

        public Product(int id, string name, string codeErp, decimal price)
        {
            Validation(name, codeErp, price, id);

            Name = name;
            CodeErp = codeErp;
            Price = price;
            Id = id;
        }

        private void Validation(string name, string codErp, decimal price, int? id = null)
        {
            if (id != null)
            {
                DomainValidationException.When(id <= 0, "Id is required");
            }

            DomainValidationException.When(string.IsNullOrEmpty(name), "name is required");
            DomainValidationException.When(string.IsNullOrEmpty(codErp), "codeErp is required");
            DomainValidationException.When(price < 0, "price is required");
        }
    }
}
