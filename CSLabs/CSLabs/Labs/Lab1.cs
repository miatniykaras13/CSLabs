using CSLabs.Extensions.Lab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLabs.Labs;
public class Lab1(string SequencesText, string CommandsText)
{
    private readonly List<string> _proteinDataList = SequencesText.Split("\r\n").ToList();

    private StringBuilder _geneData = new();

    private int _commandCount = 1;

    public string Func1()
    {
        var commandList = CommandsText.Split("\r\n").ToList();

        foreach (string command in commandList)
        {
            var commandComponents = command.Split("\t");
            switch (commandComponents[0])
            {
                case "search":
                    Search(commandComponents[1]);
                    break;
                case "diff":
                    Diff(commandComponents[1], commandComponents[2]);
                    break;
                    //case "mode":
                    //    Mode(commandComponents[1]);
                    //    break;

            }
        }
        return _geneData.ToString();
    }

    private void Search(string sequence)
    {
        foreach (var proteinData in _proteinDataList)
        {
            var dataComponents = proteinData.Split("\t");
            if (dataComponents[2].Contains(sequence))
            {
                _geneData.AddGeneDataSearch(_commandCount, sequence, organism: dataComponents[1], protein: dataComponents[0]);
                _commandCount++;
                return;
            }
        }
        _geneData.AddGeneDataSearch(_commandCount, sequence);

    }

    private int Diff(string protein1, string protein2)
    {
        return 1;
    }

    //private List<(string, int)> Mode(string protein)
    //{

    //}
}

