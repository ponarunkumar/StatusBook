using System;

namespace ConsoleApplication{
    public class WorkOrder {
        public int WorkOrderId { get; set; }
        public string WorkOrderTitle { get; set; }
        public string WorkOrderDesc { get; set; }
        public DateTime WorkOrderStartDt { get; set; }

        public DateTime WorkOrderEndDt { get; set; }
        public status WorkOrderState { get; set; }
    }
    public enum status {
        NotStarted,
        InProgress,
        Pending,
        Complete
        
    }
}