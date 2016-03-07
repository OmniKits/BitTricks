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
            var bits = Convert.ToString(b, 2).PadLeft(8, '0');
            var flip = Convert.ToString(b.FlipBits(), 2).PadLeft(8, '0');

            Assert.Equal(bits, string.Join("", flip.Reverse()));
        }
    }

    [Fact]
    public void ForSByte()
    {
        for (sbyte s = sbyte.MinValue; s < sbyte.MaxValue; s++)
        {
            var b = (byte)s;

            var bits = Convert.ToString(b, 2);
            bits = bits.PadLeft(8, '0');

            b = (byte)(s.FlipBits());

            var flip = Convert.ToString(b, 2);
            flip = flip.PadLeft(8, '0');

            flip = flip[0] + string.Join("", flip.Skip(1).Reverse());

            Assert.Equal(bits, flip);
        }
    }

    [Fact]
    public void ForUInt16()
    {
        for (ushort u = 0; u < ushort.MaxValue; u++)
        {
            var bits = Convert.ToString((short)u, 2).PadLeft(16, '0');
            var flip = Convert.ToString((short)u.FlipBits(), 2).PadLeft(16, '0');

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

            var bits = Convert.ToString((short)u, 2).PadLeft(16, '0');
            var flip = Convert.ToString((short)u.FlipBits(), 2).PadLeft(16, '0');

            Assert.Equal(bits, string.Join("", flip.Reverse()));
        }
    }

    [Fact]
    public void ForInt16()
    {
        for (short s = short.MinValue; s < short.MaxValue; s++)
        {
            var u = (ushort)s;

            var bits = Convert.ToString((short)u, 2);
            bits = bits.PadLeft(16, '0');

            u = (ushort)(s.FlipBits());

            var flip = Convert.ToString((short)u, 2);
            flip = flip.PadLeft(16, '0');

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

            var bits = Convert.ToString((short)u, 2);
            bits = bits.PadLeft(16, '0');

            u = (ushort)(s.FlipBits());

            var flip = Convert.ToString((short)u, 2);
            flip = flip.PadLeft(16, '0');

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

            var bits = Convert.ToString((int)u, 2).PadLeft(32, '0');
            var flip = Convert.ToString((int)u.FlipBits(), 2).PadLeft(32, '0');

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

            var bits = Convert.ToString((int)u, 2);
            bits = bits.PadLeft(32, '0');

            u = (uint)(s.FlipBits());

            var flip = Convert.ToString((int)u, 2);
            flip = flip.PadLeft(32, '0');

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

            var bits = Convert.ToString((long)u, 2).PadLeft(64, '0');
            var flip = Convert.ToString((long)u.FlipBits(), 2).PadLeft(64, '0');

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

            var bits = Convert.ToString((long)u, 2);
            bits = bits.PadLeft(64, '0');

            u = (ulong)(s.FlipBits());

            var flip = Convert.ToString((long)u, 2);
            flip = flip.PadLeft(64, '0');

            flip = flip[0] + string.Join("", flip.Skip(1).Reverse());

            Assert.Equal(bits, flip);
        }
    }
}
