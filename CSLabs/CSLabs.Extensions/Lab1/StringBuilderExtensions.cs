using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLabs.Extensions.Lab1
{
    public static class StringBuilderExtensions
    {
        private static void AddLines(this StringBuilder geneData, int number)
        {
            geneData.AppendLine("--------------------------------------------------------------------------");
            geneData.Append(string.Format("{0:d3}", number));
        }

        //failure
        public static void AddGeneDataSearch(
            this StringBuilder geneData,
            int number,
            string sequence)
        {
            geneData.AddLines(number);
            geneData.Append($"\tsearch\t{sequence} \r\n");
            geneData.AppendLine("organism                 protein \r\n");
            geneData.Append("NOT FOUND");
        }

        //success
        public static void AddGeneDataSearch(
            this StringBuilder geneData,
            int number,
            string sequence,
            string organism,
            string protein)
        {
            geneData.AddLines(number);
            geneData.Append($"\tsearch\t{sequence} \r\n");
            geneData.Append("organism\t\t\t\tprotein \r\n");
            geneData.Append($"{organism}\t\t{protein}\r\n");
        }


        public static void AddGeneDataDiffSuccess(this StringBuilder geneData, int number)
        {

        }
    }
}
