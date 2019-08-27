using Microsoft.EntityFrameworkCore;
using Microsoft.Libraries.DataAccess.Interfaces;
using Microsoft.Libraries.Models;
using System;

namespace Microsoft.Libraries.DataAccess.Impl
{
    /// <summary>
    /// Credit Card Info Context Interface
    /// </summary>
    public class CreditCardInfoContext : DbContext, ICreditCardInfoContext
    {
        public CreditCardInfoContext(DbContextOptions<CreditCardInfoContext> dbContextOptions) : base(dbContextOptions) { }
        public DbSet<CreditCardInfo> CreditCardInfo { get; set; }

        /// <summary>
        /// Gets Access to Credit Card Info Entity
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<CreditCardInfo>(
                new CreditCardInfoEntityTypeConfiguration());
        }
    }
}
