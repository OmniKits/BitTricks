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
        Assert.Equal(0u, (+0).Zig());
        Assert.Equal(1u, (-1).Zig());
        Assert.Equal(2u, (+1).Zig());
        Assert.Equal(3u, (-2).Zig());

        Assert.Equal(uint.MaxValue - 1, int.MaxValue.Zig());
        Assert.Equal(uint.MaxValue - 0, int.MinValue.Zig());

        Assert.Equal(+0, 0u.Zag());
        Assert.Equal(-1, 1u.Zag());
        Assert.Equal(+1, 2u.Zag());
        Assert.Equal(-2, 3u.Zag());

        Assert.Equal(int.MaxValue, (uint.MaxValue - 1).Zag());
        Assert.Equal(int.MinValue, (uint.MaxValue - 0).Zag());

        var rnd = new Random();
        for (var i = 0; i < RandomTestCount; i++)
        {
            var v = (int)(uint)(rnd.NextDouble() * uint.MaxValue) + 1;
            var vBits = v.ToBinaryString();

            var z = v.Zig();
            var zBits = z.ToBinaryString();

            var r = z.Zag();
            var rBits = r.ToBinaryString();

            Assert.Equal(vBits, rBits);
            Assert.Equal(v, r);
            Assert.Equal(v, ZagRefImpl(z));
        }
    }

    [Fact]
    public void ForInt64()
    {
        Assert.Equal(0uL, (+0L).Zig());
        Assert.Equal(1uL, (-1L).Zig());
        Assert.Equal(2uL, (+1L).Zig());
        Assert.Equal(3uL, (-2L).Zig());

        Assert.Equal(ulong.MaxValue - 1, long.MaxValue.Zig());
        Assert.Equal(ulong.MaxValue - 0, long.MinValue.Zig());

        Assert.Equal(+0L, 0uL.Zag());
        Assert.Equal(-1L, 1uL.Zag());
        Assert.Equal(+1L, 2uL.Zag());
        Assert.Equal(-2L, 3uL.Zag());

        Assert.Equal(long.MaxValue, (ulong.MaxValue - 1).Zag());
        Assert.Equal(long.MinValue, (ulong.MaxValue - 0).Zag());

        var rnd = new Random();
        for (var i = 0; i < RandomTestCount; i++)
        {
            var v = (long)(ulong)(rnd.NextDouble() * ulong.MaxValue) + 1;
            var vBits = v.ToBinaryString();

            var z = v.Zig();
            var zBits = z.ToBinaryString();

            var r = z.Zag();
            var rBits = r.ToBinaryString();

            Assert.Equal(vBits, rBits);
            Assert.Equal(v, r);
            Assert.Equal(v, ZagRefImpl(z));
        }
    }
}
