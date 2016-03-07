using System;
using Xunit;

public class ZigZagTests
{
    private const int RandomTestCount = 0x1000;


    static int ZagRefImpl(uint u)
        => (-(int)(u & 1)) ^ (int)(u >> 1);

    static long ZagRefImpl(ulong u)
        => (-(long)(u & 1)) ^ (long)(u >> 1);

    [Fact]
    public void ForInt32()
    {
        var rnd = new Random();
        for (var i = 0; i < RandomTestCount; i++)
        {
            var v = (int)(uint)(rnd.NextDouble() * uint.MaxValue) + 1;
            var vBits = Convert.ToString(v, 2).PadLeft(32, '0');

            var z = v.Zig();
            var zBits = Convert.ToString((int)z, 2).PadLeft(32, '0');

            var r = z.Zag();
            var rBits = Convert.ToString(r, 2).PadLeft(32, '0');

            Assert.Equal(v, r);
            Assert.Equal(v, ZagRefImpl(z));
        }
    }

    [Fact]
    public void ForInt64()
    {
        var rnd = new Random();
        for (var i = 0; i < RandomTestCount; i++)
        {
            var v = (long)(ulong)(rnd.NextDouble() * ulong.MaxValue) + 1;
            var vBits = Convert.ToString(v, 2).PadLeft(64, '0');

            var z = v.Zig();
            var zBits = Convert.ToString((long)z, 2).PadLeft(64, '0');

            var r = z.Zag();
            var rBits = Convert.ToString(r, 2).PadLeft(64, '0');

            Assert.Equal(v, r);
            Assert.Equal(v, ZagRefImpl(z));
        }
    }
}
