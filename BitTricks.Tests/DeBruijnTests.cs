using System;
using System.Linq;
using Xunit;

public class DeBruijnTests
{
    [Fact]
    public void ForWhatever()
    {
        ulong n = 1, b = 0;
        ulong l, m;
        byte i = 0;

        const ulong B64 = 0x8000000000000000uL;
        var rnd = new Random();

        for (; i < 32; i++)
        {
            Assert.Equal(i, n.GetLeastSignificantBit());
            Assert.Equal(i, n.GetMostSignificantBit());
            Assert.Equal(i, ((long)n).GetLeastSignificantBit());
            Assert.Equal(i, ((long)n).GetMostSignificantBit());

            Assert.Equal(i, ((uint)n).GetLeastSignificantBit());
            Assert.Equal(i, ((uint)n).GetMostSignificantBit());
            Assert.Equal(i, ((int)n).GetLeastSignificantBit());
            Assert.Equal(i, ((int)n).GetMostSignificantBit());

            l = ~b;
            Assert.Equal(i, l.GetLeastSignificantBit());
            Assert.Equal(i, ((long)l).GetLeastSignificantBit());

            Assert.Equal(i, ((uint)l).GetLeastSignificantBit());
            Assert.Equal(i, ((int)l).GetLeastSignificantBit());

            b = b << 1 | 1;

            m = b;
            Assert.Equal(i, m.GetMostSignificantBit());
            Assert.Equal(i, ((long)m).GetMostSignificantBit());

            Assert.Equal(i, ((uint)m).GetMostSignificantBit());
            Assert.Equal(i, ((int)m).GetMostSignificantBit());

            var d = rnd.NextDouble();

            l = l & (ulong)(B64 * d) | n | B64;
            Assert.Equal(i, l.GetLeastSignificantBit());
            Assert.Equal(i, ((long)l).GetLeastSignificantBit());

            Assert.Equal(i, ((uint)l).GetLeastSignificantBit());
            Assert.Equal(i, ((int)l).GetLeastSignificantBit());

            m = n | (ulong)(n * d);

            Assert.Equal(i, m.GetMostSignificantBit());
            Assert.Equal(i, ((long)m).GetMostSignificantBit());

            Assert.Equal(i, ((uint)m).GetMostSignificantBit());
            Assert.Equal(i, ((int)m).GetMostSignificantBit());

            n <<= 1;
        }

        for (; i < 64; i++)
        {
            Assert.Equal(i, n.GetLeastSignificantBit());
            Assert.Equal(i, n.GetMostSignificantBit());
            Assert.Equal(i, ((long)n).GetLeastSignificantBit());
            Assert.Equal(i, ((long)n).GetMostSignificantBit());

            l = ~b;
            Assert.Equal(i, l.GetLeastSignificantBit());
            Assert.Equal(i, ((long)l).GetLeastSignificantBit());

            b = b << 1 | 1;

            m = b;
            Assert.Equal(i, m.GetMostSignificantBit());
            Assert.Equal(i, ((long)m).GetMostSignificantBit());

            var d = rnd.NextDouble();

            l = l & (ulong)(B64 * d) | n | B64;
            Assert.Equal(i, l.GetLeastSignificantBit());
            Assert.Equal(i, ((long)l).GetLeastSignificantBit());

            m = n | (ulong)(n * d);

            Assert.Equal(i, m.GetMostSignificantBit());
            Assert.Equal(i, ((long)m).GetMostSignificantBit());

            n <<= 1;
        }
    }
}
