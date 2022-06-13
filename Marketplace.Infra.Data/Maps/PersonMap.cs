using Marketplace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marketplace.Infra.Data.Maps
{
    internal class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("person");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .UseIdentityColumn();

            builder.Property(c => c.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Document)
                .HasColumnName("document")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(c => c.Phone)
                .HasColumnName("phone")
                .HasMaxLength(20)
                .IsRequired();

            builder.HasMany(c => c.Purchases)
                .WithOne(p => p.Person)
                .HasForeignKey(c => c.PersonId);
        }
    }
}