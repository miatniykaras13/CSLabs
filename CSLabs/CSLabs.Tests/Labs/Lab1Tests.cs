using CSLabs.Labs;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLabs.Tests.Labs
{
    public class Lab1Tests
    {
        public readonly Lab1 _lab;

        public Lab1Tests()
        {
            _lab = new Lab1();
        }

        [Theory]
        [InlineData("AAAAAAAATATTTCGCTTTTCAAAAATTGTCAGATGAGAGAAAAAATAAAA", "8ATA3TCGC4TC5ATTGTCAGATGAGAG6AT4A")]
        [InlineData("ATATCGCTCATGTCAGATGAGAGATA", "ATATCGCTCATGTCAGATGAGAGATA")]
        [InlineData("AATCCCCCTTTCAAAATTTTTGGTTCAGATGAGAGATA", "AAT5C3TC4A5TGGTTCAGATGAGAGATA")]
        public void Lab1_RLEncoding_ReturnString(string sequence, string expected)
        {
            var result = _lab.RLEncoding(sequence);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("8ATA3TCGC4TC5ATTGTCAGATGAGAG6AT4A", "AAAAAAAATATTTCGCTTTTCAAAAATTGTCAGATGAGAGAAAAAATAAAA")]
        [InlineData("ATATCGCTCATGTCAGATGAGAGATA", "ATATCGCTCATGTCAGATGAGAGATA")]
        [InlineData("AAT5C3TC4A5TGGTTCAGATGAGAGATA", "AATCCCCCTTTCAAAATTTTTGGTTCAGATGAGAGATA")]
        public void Lab1_RLDecoding_ReturnString(string sequence, string expected)
        {
            var result = _lab.RLDecoding(sequence);

            result.Should().Be(expected);
        }

    }
}
