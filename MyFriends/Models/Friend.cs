using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFriends.Models
{
    public class Friend
    {
        public Friend() {  }
        [Key]
        public int ID { get; set; }
        [Display(Name = "שם פרטי")]
        public string FirstName { get; set; } = "";
        [Display(Name = "שם משפחה")]
        public string LastName { get; set; } = "";
        [Display (Name ="שם מלא")]
        public string FullName { get { return FirstName + " " + LastName; }  }
        [DataType(DataType.Date), Display (Name ="תאריך לידה")]
        public DateTime Date { get; set; }
        [Display(Name = "מספר טלפון"), Phone(ErrorMessage = "מספר הפלאפון אינו תקין")]
        public string Phone { get; set; }
        [Display(Name = "כתובת מייל"), EmailAddress(ErrorMessage = "כתובת המייל אינה תקינה")]
        public string Email { get; set; }

        [Display(Name = "עיר מגורים")]
        public string City { get; set; } = "";
        [Display(Name = "רחוב")]
        public string Street { get; set; } = "";
        [Display(Name = "מספר")]
        public string Number { get; set; } = "";
        [Display(Name = "כתובת מלאה"), NotMapped]
        public string Address { get { return City + " " + Street + " " + Number; } }
        public List<Image> Images { get; set; } = new List<Image>();

        // פונקציה המוסיפה תמונה לחבר
        public void AddImage(IFormFile file)
        {
            if (file == null) return;
            // יצירת תמונה חדשה והוספתה לרשימת התמונות
            Images.Add(new Image { Friend = this, SetImage = file}) ;
        }
            
    }
}
