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
            Assert.Equal(i, n.GetLeastSignificantBitNonZero());
            Assert.Equal(i, n.GetMostSignificantBitNonZero());
            Assert.Equal(i, ((long)n).GetLeastSignificantBitNonZero());
            Assert.Equal(i, ((long)n).GetMostSignificantBitNonZero());

            Assert.Equal(i, ((uint)n).GetLeastSignificantBitNonZero());
            Assert.Equal(i, ((uint)n).GetMostSignificantBitNonZero());
            Assert.Equal(i, ((int)n).GetLeastSignificantBitNonZero());
            Assert.Equal(i, ((int)n).GetMostSignificantBitNonZero());

            l = ~b;
            Assert.Equal(i, l.GetLeastSignificantBitNonZero());
            Assert.Equal(i, ((long)l).GetLeastSignificantBitNonZero());

            Assert.Equal(i, ((uint)l).GetLeastSignificantBitNonZero());
            Assert.Equal(i, ((int)l).GetLeastSignificantBitNonZero());

            b = b << 1 | 1;

            m = b;
            Assert.Equal(i, m.GetMostSignificantBitNonZero());
            Assert.Equal(i, ((long)m).GetMostSignificantBitNonZero());

            Assert.Equal(i, ((uint)m).GetMostSignificantBitNonZero());
            Assert.Equal(i, ((int)m).GetMostSignificantBitNonZero());

            var d = rnd.NextDouble();

            l = l & (ulong)(B64 * d) | n | B64;
            Assert.Equal(i, l.GetLeastSignificantBitNonZero());
            Assert.Equal(i, ((long)l).GetLeastSignificantBitNonZero());

            Assert.Equal(i, ((uint)l).GetLeastSignificantBitNonZero());
            Assert.Equal(i, ((int)l).GetLeastSignificantBitNonZero());

            m = n | (ulong)(n * d);

            Assert.Equal(i, m.GetMostSignificantBitNonZero());
            Assert.Equal(i, ((long)m).GetMostSignificantBitNonZero());

            Assert.Equal(i, ((uint)m).GetMostSignificantBitNonZero());
            Assert.Equal(i, ((int)m).GetMostSignificantBitNonZero());

            n <<= 1;
        }

        for (; i < 64; i++)
        {
            Assert.Equal(i, n.GetLeastSignificantBitNonZero());
            Assert.Equal(i, n.GetMostSignificantBitNonZero());
            Assert.Equal(i, ((long)n).GetLeastSignificantBitNonZero());
            Assert.Equal(i, ((long)n).GetMostSignificantBitNonZero());

            l = ~b;
            Assert.Equal(i, l.GetLeastSignificantBitNonZero());
            Assert.Equal(i, ((long)l).GetLeastSignificantBitNonZero());

            b = b << 1 | 1;

            m = b;
            Assert.Equal(i, m.GetMostSignificantBitNonZero());
            Assert.Equal(i, ((long)m).GetMostSignificantBitNonZero());

            var d = rnd.NextDouble();

            l = l & (ulong)(B64 * d) | n | B64;
            Assert.Equal(i, l.GetLeastSignificantBitNonZero());
            Assert.Equal(i, ((long)l).GetLeastSignificantBitNonZero());

            m = n | (ulong)(n * d);

            Assert.Equal(i, m.GetMostSignificantBitNonZero());
            Assert.Equal(i, ((long)m).GetMostSignificantBitNonZero());

            n <<= 1;
        }
    }
}
