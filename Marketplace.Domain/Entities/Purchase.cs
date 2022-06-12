using Marketplace.Domain.Validations;

namespace Marketplace.Domain.Entities
{
    public sealed class Purchase
    {
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int PersonId { get; private set; }
        public DateTime Date { get; private set; }
        public Person Person { get; set; }
        public Product Product { get; set; }

        public Purchase(int productId, int personId, DateTime? date)
        {
            Validation(productId, personId, date);
        }

        public Purchase(int id, int productId, int personId, DateTime? date)
        {
            Validation(productId, personId, date, id);
        }

        private void Validation(int productId, int personId, DateTime? date, int? id = null)
        {
            if (id != null)
            {
                DomainValidationException.When(id <= 0, "Id is required");
            }
            DomainValidationException.When(productId <= 0, "ProductId is required");
            DomainValidationException.When(personId <= 0, "PersonId is required");
            DomainValidationException.When(date == null, "Date is required");
        }
    }
}
