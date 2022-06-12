using Marketplace.Domain.Validations;

namespace Marketplace.Domain.Entities
{
    public sealed class Person
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Phone { get; private set; }
        public ICollection<Purchase> Purchases { get; set; }

        public Person(string document, string name, string phone)
        {
            Validation(document, name, phone);

            Name = name;
            Document = document;
            Phone = phone;
        }

        public Person(int id, string document, string name, string phone)
        {
            Validation(document, name, phone, id);

            Name = name;
            Document = document;
            Phone = phone;
            Id = id;
        }

        private void Validation(string document, string name, string phone, int? id = null)
        {
            if (id != null)
            {
                DomainValidationException.When(id <= 0, "Id is required");
            }

            DomainValidationException.When(string.IsNullOrEmpty(name), "name is required");
            DomainValidationException.When(string.IsNullOrEmpty(document), "document is required");
            DomainValidationException.When(string.IsNullOrEmpty(phone), "phone is required");
        }

    }

}
