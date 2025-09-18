using CSLabs.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLabs.Lab;
public class Lab1()
{
    private string _commands;
    private string _sequences;
    private StringBuilder _genedata = new();
    private List<GeneticData> _proteins;
    private int _commandNumber = 1;



    public void Func1()
    {
        string sequencePath = @"C:\Users\Admin\source\repos\miatniykaras13\CSLabs\CSLabs\CSLabs\sequences.txt";
        string commandsPath = @"C:\Users\Admin\source\repos\miatniykaras13\CSLabs\CSLabs\CSLabs\commands.txt";
        string genedataPath = @"C:\Users\Admin\source\repos\miatniykaras13\CSLabs\CSLabs\CSLabs\genedata.txt";

        string sequences = File.ReadAllText(sequencePath);
        string commands = File.ReadAllText(commandsPath);

        _commands = commands;
        _sequences = sequences;
        _proteins = GetAllGeneData();


        _genedata.AppendLine("Vladislav Gaiduk\nGenetic Search");

        var commandsList = commands.Split("\r\n").ToList();

        foreach (var command in commandsList)
        {
            var commandComponents = command.Split("\t");
            switch (commandComponents[0])
            {
                case "search":
                    Search(commandComponents[1]);
                    _commandNumber++;
                    break;
                case "diff":
                    Diff(commandComponents[1], commandComponents[2]);
                    _commandNumber++;
                    break;
                case "mode":
                    Mode(commandComponents[1]);
                    _commandNumber++;
                    break;
            }
        }
        _genedata.AddLine();
        File.WriteAllLines(genedataPath, _genedata.ToString().Split("\n"));
    }

    private void Mode(string protein)
    {
        _genedata.AppendMode(_commandNumber, protein);
        if (!TryFindByProtein(protein, out var gene))
        {
            _genedata.AppendLine("MISSING");
        }
        string aminoAcid = gene.AminoAcids;
        string distinctProtein = new(aminoAcid.ToCharArray().Distinct().ToArray());
        var occurrences = distinctProtein.Select(c => aminoAcid.Count(r => r == c));
        var aminoAcids = distinctProtein.Zip<char, int>(occurrences).ToList();

        aminoAcids = aminoAcids.OrderByDescending(c => c.Item2).ToList();
        var mostRecent = new List<(char, int)>
        {
            aminoAcids[0]
        };

        int i = 1;
        while (aminoAcids[i].Item2 == aminoAcids[i - 1].Item2)
        {
            mostRecent.Add(aminoAcids[i]);
            i++;
        }
        mostRecent = mostRecent.OrderBy(c => c.Item1).ToList();
        _genedata.AppendLine($"{mostRecent[0].Item1}\t\t{mostRecent[0].Item2}");
    }

    private void Diff(string protein1, string protein2)
    {
        _genedata.AppendDiff(protein1, protein2, _commandNumber);
        int diff = 0;
        if (!TryFindByProtein(protein1, protein2, out var gene1, out var gene2))
        {
            _genedata.AppendLine("MISSING");
            return;
        }

        string acid1 = RLDecoding(gene1.AminoAcids);
        string acid2 = RLDecoding(gene2.AminoAcids);

        if (acid1.Length > acid2.Length)
        {
            for (int i = 0; i < acid2.Length; i++)
            {
                if (acid1[i] != acid2[i])
                    diff++;
            }
        }
        else
        {
            for (int i = 0; i < acid1.Length; i++)
            {
                if (acid1[i] != acid2[i])
                    diff++;
            }
        }
        diff += Math.Abs(acid1.Length - acid2.Length);
        _genedata.AppendLine(diff.ToString());
    }

    public string RLEncoding(string sequence)
    {
        StringBuilder sequenceSB = new();
        for (int i = 0; i < sequence.Length; i++)
        {
            char c = sequence[i];
            int end = i;
            while (end < sequence.Length && sequence[i] == sequence[end])
            {
                end++;
            }
            int length = end - i;
            if (length > 2)
            {
                i += length - 1;
                sequenceSB.Append(length);
            }
            sequenceSB.Append(c);
        }

        return sequenceSB.ToString();
    }

    private void Search(string sequence)
    {

        string decodedSequence = sequence;
        if (IsEncoded(sequence))
        {
            decodedSequence = RLDecoding(sequence);
        }
        _genedata.AppendSearch(decodedSequence, _commandNumber);
        for (int i = 0; i < _proteins.Count; i++)
        {
            if (_proteins[i].AminoAcids.Contains(decodedSequence))
            {
                _genedata.AppendLine($"\n{_proteins[i].Organism}\t\t\t{_proteins[i].Protein}");
                return;
            }
        }
        _genedata.AppendLine($"\nNOT FOUND");

    }

    private bool TryFindByProtein(string protein1, string protein2, out GeneticData gene1, out GeneticData gene2)
    {
        gene1 = default;
        gene2 = default;
        foreach (var geneticData in _proteins)
        {
            if (string.Equals(geneticData.Protein, protein1))
                gene1 = geneticData;
            if (string.Equals(geneticData.Protein, protein2))
                gene2 = geneticData;
        }
        if (EqualityComparer<GeneticData>.Default.Equals(gene1, default) ||
            EqualityComparer<GeneticData>.Default.Equals(gene2, default))
        {
            return false;
        }
        return true;

    }

    private bool TryFindByProtein(string protein, out GeneticData gene)
    {
        gene = default;
        foreach (var geneticData in _proteins)
        {
            if (string.Equals(geneticData.Protein, protein))
                gene = geneticData;
        }
        if (EqualityComparer<GeneticData>.Default.Equals(gene, default))
        {
            return false;
        }
        return true;

    }



    public string RLDecoding(string sequence)
    {
        StringBuilder sequenceSB = new();
        for (int i = 0; i < sequence.Length; i++)
        {
            if (int.TryParse(sequence[i].ToString(), out int n))
            {
                sequenceSB.Append(sequence[i + 1], n);
                i++;
            }
            else
            {
                sequenceSB.Append(sequence[i]);
            }
        }
        return sequenceSB.ToString();
    }

    private List<GeneticData> GetAllGeneData()
    {
        List<GeneticData> list = new();
        var geneData = _sequences.Split("\r\n");
        foreach (var proteinData in geneData)
        {
            var proteinDataList = proteinData.Split("\t");
            if (!IsValidSequence(proteinDataList[2]))
            {
                Console.WriteLine("Неверный формат аминокислоты.");
            }
            list.Add(new(proteinDataList[0], proteinDataList[1], proteinDataList[2]));
        }
        return list;
    }

    private bool IsEncoded(string sequence) => sequence.Any(c => char.IsDigit(c));

    private bool IsValidSequence(string sequence) => !sequence.Any(c => new[] { 'B', 'J', 'O', 'U', 'X', 'Z'}.Contains(c)); 
}

