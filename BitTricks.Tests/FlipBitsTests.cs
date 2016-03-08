using System;
using System.Linq;
using Xunit;

public class FlipBitsTests
{
    private const int RandomTestCount = 0x1000;


    [Fact]
    public void ForByte()
    {
        for (byte b = 0; b < byte.MaxValue; b++)
        {
            var bits = b.ToBinaryString();
            var flip = b.FlipBits().ToBinaryString();

            Assert.Equal(bits, string.Join("", flip.Reverse()));
        }
    }

    [Fact]
    public void ForSByte()
    {
        for (sbyte s = sbyte.MinValue; s < sbyte.MaxValue; s++)
        {
            var b = (byte)s;

            var bits = b.ToBinaryString();

            b = (byte)(s.FlipBits());

            var flip = b.ToBinaryString();

            flip = flip[0] + string.Join("", flip.Skip(1).Reverse());

            Assert.Equal(bits, flip);
        }
    }

    [Fact]
    public void ForUInt16()
    {
        for (ushort u = 0; u < ushort.MaxValue; u++)
        {
            var bits = u.ToBinaryString();
            var flip = u.FlipBits().ToBinaryString();

            Assert.Equal(bits, string.Join("", flip.Reverse()));
        }
    }

    [Fact]
    public void ForUInt16Alive()
    {
        var rnd = new Random();
        for (var i = 0; i < RandomTestCount; i++)
        {
            var u = (ushort)rnd.Next();

            var bits = u.ToBinaryString();
            var flip = u.FlipBits().ToBinaryString();

            Assert.Equal(bits, string.Join("", flip.Reverse()));
        }
    }

    [Fact]
    public void ForInt16()
    {
        for (short s = short.MinValue; s < short.MaxValue; s++)
        {
            var u = (ushort)s;

            var bits = u.ToBinaryString();

            u = (ushort)(s.FlipBits());

            var flip = u.ToBinaryString();

            flip = flip[0] + string.Join("", flip.Skip(1).Reverse());

            Assert.Equal(bits, flip);
        }
    }

    [Fact]
    public void ForInt16Alive()
    {
        var rnd = new Random();
        for (var i = 0; i < RandomTestCount; i++)
        {
            var u = (ushort)rnd.Next();
            var s = (short)u;

            var bits = u.ToBinaryString();

            u = (ushort)(s.FlipBits());

            var flip = u.ToBinaryString();

            flip = flip[0] + string.Join("", flip.Skip(1).Reverse());

            Assert.Equal(bits, flip);
        }
    }

    [Fact]
    public void ForUInt32()
    {
        var rnd = new Random();
        for (var i = 0; i < RandomTestCount; i++)
        {
            var u = (uint)(rnd.NextDouble() * uint.MaxValue) + 1;

            var bits = u.ToBinaryString();
            var flip = u.FlipBits().ToBinaryString();

            Assert.Equal(bits, string.Join("", flip.Reverse()));
        }
    }

    [Fact]
    public void ForInt32()
    {
        var rnd = new Random();
        for (var i = 0; i < RandomTestCount; i++)
        {
            var u = (uint)(rnd.NextDouble() * uint.MaxValue) + 1;
            var s = (int)u;

            var bits = u.ToBinaryString();

            u = (uint)(s.FlipBits());

            var flip = u.ToBinaryString();

            flip = flip[0] + string.Join("", flip.Skip(1).Reverse());

            Assert.Equal(bits, flip);
        }
    }

    [Fact]
    public void ForUlong64()
    {
        var rnd = new Random();
        for (var i = 0; i < RandomTestCount; i++)
        {
            var u = (ulong)(rnd.NextDouble() * ulong.MaxValue) + 1;

            var bits = u.ToBinaryString();
            var flip = u.FlipBits().ToBinaryString();

            Assert.Equal(bits, string.Join("", flip.Reverse()));
        }
    }

    [Fact]
    public void Forlong64()
    {
        var rnd = new Random();
        for (var i = 0; i < RandomTestCount; i++)
        {
            var u = (ulong)(rnd.NextDouble() * ulong.MaxValue) + 1;
            var s = (long)u;

            var bits = u.ToBinaryString();

            u = (ulong)(s.FlipBits());

            var flip = u.ToBinaryString();

            flip = flip[0] + string.Join("", flip.Skip(1).Reverse());

            Assert.Equal(bits, flip);
        }
    }
}
