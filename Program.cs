using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Titulky
{
    class Program
    {

        static Dictionary<char, char> chars = new Dictionary<char, char>()
            {
                {'ø', 'ř'},
                {'Ø', 'Ř'},
                {'ì', 'ě'},
                {'ù', 'ů'},
                {'è', 'č'},
                {'È', 'Č'},
                {'ï', 'ď'},
                {'ò', 'ň'}
            };

        static void Main(string[] args)
        {

            try {
            string path = args[0];

            StreamReader sr = new StreamReader(path, Encoding.GetEncoding("Windows-1252"));


            using (FileStream fs = new FileStream("new.srt", FileMode.CreateNew, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(fs, Encoding.UTF8))
                {
                    string row;

                    while ((row = sr.ReadLine()) != null)
                    {
                        row = ReplaceWeirdChars(row);
                        writer.WriteLine(row);
                    }
                }
            }

                Console.Out.WriteLine("subtitles changed.");
                Console.Out.WriteLine("new.srt created at the same place as program");
            }
            catch (FileNotFoundException enotfound)
            {
                Console.Out.WriteLine("incorrect path");
            }
            catch (IOException eio)
            {
                Console.Out.WriteLine(eio.Message);
            }
            catch(Exception e)
            {
                Console.Out.WriteLine("something bad happened.. lol");
            }
        }

        static string ReplaceWeirdChars(string row)
        {
            foreach(KeyValuePair<char, char> x in chars){
                row = row.Replace(x.Key, x.Value);
            }

            return row;
        }
    }

    
}
