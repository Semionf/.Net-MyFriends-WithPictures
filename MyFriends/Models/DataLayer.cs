using System.Data.Entity;

namespace MyFriends.Models
{
    public class DataLayer: DbContext
    {
        // יצירת מודל פנימי סטטי
        private static DataLayer data;
        private DataLayer() : base("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Friends;Data Source=MSI\\SQLEXPRESS")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataLayer>());
            // כאשר מסד הנתונים ריק, מפעיל את הפונקציה הזורעת
            if (Friends.Count() == 0) Seed();
        }

        // פונקציה הזורעת את מסד הנתונים בפעם הראשונה
        private void Seed()
        {
            // יצירת חבר ראשוני בטבלה
            Friend friend = new Friend { FirstName = "סמיון", LastName = "פורלנדר", City = "כרמיאל"};
            // הוספת החבר לטבלה
            Friends.Add(friend);
            // שמירת שינויים
            SaveChanges();
        }
        // קישור למודל הפנימי
        public static DataLayer Data
        {
            // איתחול בפעם הראשונה בלבד
            get 
            { 
                if (data == null) data= new DataLayer(); 
                return data; 
            }
        }
        // טבלת חברים
        public DbSet<Friend> Friends { get;set; }
        // טבלת תמונות
        public DbSet<Image> Images { get;set; }
    }
}
