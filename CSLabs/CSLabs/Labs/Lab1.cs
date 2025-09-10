using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLabs.Labs;
public class Lab1()
{
    public void Func1()
    {
        Console.WriteLine("Введите последовательность");
        string sequence = Console.ReadLine()!;
        if (sequence.Any(c => new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' }.Contains(c)))
        {
            string decodedSequence = RLDecoding(sequence);
            Console.WriteLine($"Раскодированная последовательность: {decodedSequence}");
        }
        else
        {
            string encodedSequence = RLEncoding(sequence);
            Console.WriteLine($"Закодированная последовательность: {encodedSequence}");

        }
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

}

