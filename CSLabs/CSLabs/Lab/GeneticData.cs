using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLabs.Lab
{
    public struct GeneticData
    {
        public GeneticData(string protein, string organism, string aminoAcids) : this()
        {
            Protein = protein;
            Organism = organism;
            AminoAcids = aminoAcids;
        }

        public string Protein { get; set; }
        public string Organism { get; set; }
        public string AminoAcids { get; set; }

    }
}
