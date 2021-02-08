using CsvHelper;
using FlutterTest.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FlutterTest
{
    public static class StaticMethods
    {
        public static List<Stat> GetStatFromCSV(string path)
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<Stat>().ToList();
            }
        }

        public static List<MetaData> GetMetaDataFromCSV(string path)
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<MetaData>().ToList();
            }
        }
    }
}
