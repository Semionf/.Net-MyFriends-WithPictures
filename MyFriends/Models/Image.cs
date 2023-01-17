using System.ComponentModel.DataAnnotations;

namespace MyFriends.Models
{
    public class Image
    {
        public Image() { }
        [Key]
        public int ID { get; set; }
        //[Required]
        public Friend Friend { get; set; }
        [Display (Name = "תמונה")]
        public byte[] MyImage { get; set; }

        // תכונת הוספה של תמונה
        public IFormFile SetImage
        {
            set
            {
                // בדיקה
                if (value == null) return;
                // יצירת מקום בזיכרון המכיל קובץ
                MemoryStream stream = new MemoryStream ();
                // העתקת קובץ מהמשתמש למקום שנוצר בזיכרון
                value.CopyTo(stream);
                // הפיכת הזיכרון למערך כדי שיוכל להכנס למוסד נתונים
                MyImage= stream.ToArray ();
                
            }
        }
    }
}
