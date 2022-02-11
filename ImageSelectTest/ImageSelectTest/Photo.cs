using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ImageSelectTest
{
    [Table("Photo")]
    public class Photo
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Path { get; set; }
    }
}
