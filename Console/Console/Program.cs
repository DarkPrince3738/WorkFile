using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CON
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "../output.xml";
            Penal[] Things = new Penal[10];
            XmlSerializer formatter = new XmlSerializer(typeof(Penal[]));
            if (true)
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    Things = (Penal[])formatter.Deserialize(fs);
                }
            }
            for(int i = 0; i < 10; i++)
            {

                Console.WriteLine(Things[i].countofpens);
            }
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Things);
            }
            Console.ReadKey();
        }
    }
    public struct Penal
    {
        public int countofpens;
        public int countofpencils;
        public int rulerlength;
        public string compassize;
        public bool is_has_rubber;
        public Penal(int countofpens = 1, int rulerlength = 0)
        {
            this.countofpens = countofpens;
            countofpencils = 2;
            this.rulerlength = rulerlength;
            compassize = "small";
            is_has_rubber = true;
        }
    }
}
