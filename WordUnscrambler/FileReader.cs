using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WordUnscrambler
{
    class FileReader
    {
        public string[] Read(string filename) {
            string[] fileContent;
            try
            {
                fileContent = File.ReadAllLines(filename);
                return fileContent;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
