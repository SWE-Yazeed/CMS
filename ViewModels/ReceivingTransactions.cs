using System;

namespace CMSApp.ViewModels
{
    public class ReceivingTransactions
    {
        public string TransactionNumber { get; set; }  // رقم المعاملة
        public string TransactionStatus { get; set; }   // حالة المعاملة
        public string Recipient { get; set; }            // الإدارة المرسلة
        public DateTime ReceptionDate { get; set; }      // تاريخ الاستقبال

        public bool IsAccepted { get; set; }
        public bool IsReturned { get; set; }
        public bool IsRejected { get; set; }

        public string RejectionReason { get; set; }


    }
}



