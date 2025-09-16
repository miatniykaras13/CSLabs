using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLabs.Extensions
{
    public static class StringBuilderExtension
    {
        public static StringBuilder AddLine(this StringBuilder sb)
        {
            sb.AppendLine("--------------------------------------------------------------------------\n");
            return sb;
        }

        public static StringBuilder AddCommandNumber(this StringBuilder sb, int number)
        {
            sb.Append(string.Format("{0:d3}\t", number));
            return sb;
        }

        public static StringBuilder AppendSearch(this StringBuilder sb, string sequence, int number)
        {
            sb.AddLine();
            sb.AddCommandNumber(number);
            sb.Append($"\tsearch\t{sequence}\n");
            sb.Append("organism\t\t\t\t\t\t\tprotein");
            return sb;
        }

        public static StringBuilder AppendDiff(this StringBuilder sb, string protein1, string protein2, int number)
        {
            sb.AddLine();
            sb.AddCommandNumber(number);
            sb.Append($"\tdiff\t{protein1}\t{protein2}\n");
            sb.Append("amino-acids difference:\n");
            return sb;
        }
    }
}
