namespace AutoInsurance
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AutoInsurance : DbContext
    {
        public AutoInsurance()
            : base("name=AutoInsurance")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public virtual DbSet<Drivers> Drivers { get; set; }
    }
}
