using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ImageSelectTest
{
    public class PhotoRepository
    {
        SQLiteConnection database;
        public PhotoRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Photo>();
        }
        public IEnumerable<Photo> GetItems()
        {
            return database.Table<Photo>().ToList();
        }
        public Photo GetItem(int id)
        {
            return database.Get<Photo>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Photo>(id);
        }
        public void SaveItem(Photo item)
        {
            database.Insert(item);
        }
    }
}
