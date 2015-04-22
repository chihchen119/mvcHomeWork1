//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace mvcHomeWork1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    
    public partial class 客戶聯絡人
    {
        public int Id { get; set; }
        public int 客戶Id { get; set; }
        public string 職稱 { get; set; }
        [Required]
        public string 姓名 { get; set; }
        [Required]
        [EmailAddress]
        [Unique(ErrorMessage = "同一個客戶下的聯絡人，其 Email 不能重複。")]
        public string Email { get; set; }
        [Required]
        [RegularExpression("\\d{4}-\\d{6}", ErrorMessage = "手機號碼格式錯誤( e.g. 0987-654321 )")]
        public string 手機 { get; set; }
        public string 電話 { get; set; }
        public Nullable<bool> 是否已刪除 { get; set; }
    
        public virtual 客戶資料 客戶資料 { get; set; }
    }

    public class UniqueAttribute : ValidationAttribute
    {
        private 客戶資料Entities db = new 客戶資料Entities();

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var valueAsString = value.ToString();
                var data = db.客戶聯絡人.Where(d => d.Email.Equals(valueAsString));
                if (data.ToList().Count > 0)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
                
            }
            return ValidationResult.Success;
        }
    }


}
