using System;
using Microsoft.EntityFrameworkCore;


namespace ConsoleApplication
{
    public class Program
    {
        public class StatusBookContext : DbContext {
            public DbSet<WorkOrder> WorkOrders { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
                optionsBuilder.UseSqlite("Filename=./StatusBook.db");
            }
        }
        public class WorkOrder {
            public string Id { get; set; }
            public string Title { get; set; }
            public string Desc { get; set; }
            public DateTime StartDt { get; set; }
            public DateTime EndDt { get; set; }
            public status State { get; set; }
         }
    public enum status {
        NotStarted,
        InProgress,
        Pending,
        Complete
        
    }
        public static void Main(string[] args)
        {
            Console.WriteLine("   STATUS BOOK APPLICATION   ");
            Console.WriteLine("******************************");
            Console.WriteLine(" A. List your current status");
            Console.WriteLine(" B. Add a new task");
            Console.WriteLine(" C. Update a new task");
            Console.WriteLine(" D. Exit");



            using(var db=new StatusBookContext()){
             var choice = Console.ReadLine().ToUpper();

            switch (choice) {
               case "A" :
                Console.WriteLine($"STATUS REPORT AS OF {DateTime.Now}");
                foreach (var WorkOrder in db.WorkOrders){
                    Console.WriteLine($" - {WorkOrder.Id} - {WorkOrder.Title}");
                }
                    break;
               case "B" :
           
                        var _newworkorder = new WorkOrder();
                            _newworkorder.Id = Guid.NewGuid().ToString("N");
                            Console.Write("Title:");
                            _newworkorder.Title = Console.ReadLine();
                            Console.Write("Description:");
                            _newworkorder.Desc = Console.ReadLine();
                            _newworkorder.StartDt = DateTime.Now;
                            _newworkorder.EndDt = DateTime.Now.AddDays(2);
                            _newworkorder.State = status.InProgress;
                            db.WorkOrders.Add(_newworkorder);
                            var count = db.SaveChanges();
                            Console.WriteLine($"{count} record saved.");
                            Console.WriteLine();
                            break;
            case "D" :          
                Console.WriteLine("Thanks for using StatusBook Application. See you soon!");
                break;    
                    default:
                   break;
            }
        

            }
            
        }
    }
}
