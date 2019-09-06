using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MaxSumTriangle
{
    public static class Input
    {

        public static async Task<List<string[]>> ReadLines(string path)
        {
            try
            {
                StreamReader file = new StreamReader(path);
                string line;
                var triangle = new List<string[]>();
                while ((line = await file.ReadLineAsync()) != null)
                {
                    triangle.Add(line.Trim().Split(' '));
                }
                return triangle;
            }
            catch (Exception ex)
            {
                return null;
            }
             
        }
    }


}
