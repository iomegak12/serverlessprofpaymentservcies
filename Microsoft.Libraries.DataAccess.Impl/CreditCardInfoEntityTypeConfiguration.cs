using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Libraries.Models;

namespace Microsoft.Libraries.DataAccess.Impl
{
    internal class CreditCardInfoEntityTypeConfiguration : IEntityTypeConfiguration<CreditCardInfo>
    {
        public void Configure(EntityTypeBuilder<CreditCardInfo> builder)
        {
            builder.HasKey(model => model.CreditCardNumber);

            builder.ToTable("CreditCardDetails");
        }
    }
}