using Microsoft.AspNetCore.Http; // تأكد من إضافة هذا الاستيراد لـ IFormFile
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace CMSApp.ViewModels
{
    public class CreateTansactionsViewModel
    {
        [Key]
        [Required(ErrorMessage = "رقم المعاملة مطلوب.")]
        public string TransactionNumber { get; set; }  // رقم المعاملة

        [Required(ErrorMessage = "نوع المعاملة مطلوب.")]
        public string TransactionType { get; set; }  // نوع المعاملة

        [Required(ErrorMessage = "حالة المعاملة مطلوبة.")]
        public string TransactionStatus { get; set; }  // حالة المعاملة

        [Required(ErrorMessage = "طبيعة المعاملة مطلوبة.")]
        public string TransactionNature { get; set; }  // طبيعة المعاملة

        [Required(ErrorMessage = "جهة المستقبل مطلوبة.")]
        public string ?SelectedRecipientId { get; set; } // لتخزين المعرف للمستلم المحدد

        public string? RecipientName { get; set; } // لتخزين اسم المستلم

        public string? RecipientJobTitle { get; set; } // إضافة المسمى الوظيفي
        public IFormFile? Attachments { get; set; }  // المرفقات

        [Display(Name = "ملاحظات")]
        public string? Notes { get; set; }  // الملاحظات

        public List<SelectListItem> AvailableRecipients { get; set; } = new List<SelectListItem>();
    }
}
