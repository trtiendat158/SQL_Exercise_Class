using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement
{
    public class ClassManagement
    {
        public Class[] GetClass()
        {
            var db = new OOPCSEntities();
            var classes = db.Classes.ToArray();
            return classes;
        }
        public void AddClass(string name, string description)
        {
            var newclass = new Class();
            newclass.Name = name;
            newclass.Description = description;

            var db = new OOPCSEntities();
            db.Classes.Add(newclass);
            db.SaveChanges();
        }
        public void EditClass(int id, string name, string description)
        {
            var db = new OOPCSEntities();
            var oldclass = db.Classes.Find(id);
            oldclass.Name = name;
            oldclass.Description = description;

            db.Entry(oldclass).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteClass(int id)
        {
            var db = new OOPCSEntities();
            var cclass = db.Classes.Find(id);
            db.Classes.Remove(cclass);
            db.SaveChanges();
        }
        public Class GetClass(int id)
        {
            var db = new OOPCSEntities();
            var @class = db.Classes.Find(id);
            return @class;
        }
    }
}
