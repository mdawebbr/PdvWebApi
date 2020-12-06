﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PDVApi.Context;

namespace PDVApi.Migrations
{
    [DbContext(typeof(PDVContext))]
    partial class PDVContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PDVApi.Models.PDV", b =>
                {
                    b.Property<int>("PDVId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NotasMoedas");

                    b.Property<double>("Pagamento");

                    b.Property<double>("Preco");

                    b.Property<double>("Troco");

                    b.HasKey("PDVId");

                    b.ToTable("PDVS");
                });
#pragma warning restore 612, 618
        }
    }
}
