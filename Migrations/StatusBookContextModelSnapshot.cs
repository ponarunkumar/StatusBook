using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ConsoleApplication;

namespace StatusBook.Migrations
{
    [DbContext(typeof(Program.StatusBookContext))]
    partial class StatusBookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("ConsoleApplication.Program+WorkOrder", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Desc");

                    b.Property<DateTime>("EndDt");

                    b.Property<DateTime>("StartDt");

                    b.Property<int>("State");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("WorkOrders");
                });
        }
    }
}
