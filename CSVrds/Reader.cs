using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Zadanie2.Models;

namespace Zadanie2.CSVrds
{
    public class Reader
    {
        string path;
        List<Student> list;

        public Reader(string path) 
        {
            this.path = path;
        }

        public List<Student> ReadCsvFile()
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                 list = csv.GetRecords<Student>().ToList();
            }

            return list;
        }

        public void WriteCsvFile()
        {
            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(list);
            }
        }
    }
}
