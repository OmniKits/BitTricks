using System;
using Xunit;

public class GetSignPatternTests
{
    private const int RandomTestCount = 0x1000;

    [Fact]
    public void ForSByte()
    {
        sbyte b;
        for (b = 0; b < sbyte.MaxValue; b++)
            Assert.Equal((sbyte)0, b.GetSignPattern());
        Assert.Equal(0, sbyte.MaxValue.GetSignPattern());
        b = 0;
        while (b-- > sbyte.MinValue)
            Assert.Equal((sbyte)-1, b.GetSignPattern());
    }

    [Fact]
    public void ForInt16()
    {
        short s;
        for (s = 0; s < short.MaxValue; s++)
            Assert.Equal((short)0, s.GetSignPattern());
        Assert.Equal(0, short.MaxValue.GetSignPattern());
        s = 0;
        while (s-- > short.MinValue)
            Assert.Equal((short)-1, s.GetSignPattern());
    }


    [Fact]
    public void ForInt16Alive()
    {
        Assert.Equal(0, short.MaxValue.GetSignPattern());
        Assert.Equal(0, ((short)1).GetSignPattern());
        Assert.Equal(0, ((short)0).GetSignPattern());
        Assert.Equal(-1, ((short)-1).GetSignPattern());
        Assert.Equal(-1, short.MinValue.GetSignPattern());

        var rnd = new Random();
        for (var i = 0; i < RandomTestCount; i++)
        {
            var v = (short)(short.MaxValue * rnd.NextDouble()) + 1;
            Assert.Equal(0, v.GetSignPattern());
            Assert.Equal(-1, (-v).GetSignPattern());
        }
    }

    [Fact]
    public void ForInt32()
    {
        Assert.Equal(0, int.MaxValue.GetSignPattern());
        Assert.Equal(0, 1.GetSignPattern());
        Assert.Equal(0, 0.GetSignPattern());
        Assert.Equal(-1, (-1).GetSignPattern());
        Assert.Equal(-1, int.MinValue.GetSignPattern());

        var rnd = new Random();
        for (var i = 0; i < RandomTestCount; i++)
        {
            var v = rnd.Next() + 1;
            Assert.Equal(0, v.GetSignPattern());
            Assert.Equal(-1, (-v).GetSignPattern());
        }
    }

    [Fact]
    public void ForInt64()
    {
        Assert.Equal(0, long.MaxValue.GetSignPattern());
        Assert.Equal(0, ((long)1).GetSignPattern());
        Assert.Equal(0, ((long)0).GetSignPattern());
        Assert.Equal(-1, ((long)-1).GetSignPattern());
        Assert.Equal(-1, long.MinValue.GetSignPattern());

        var rnd = new Random();
        for (var i = 0; i < RandomTestCount; i++)
        {
            var v = (long)(long.MaxValue * rnd.NextDouble()) + 1;
            Assert.Equal(0, v.GetSignPattern());
            Assert.Equal(-1, (-v).GetSignPattern());
        }
    }
}
