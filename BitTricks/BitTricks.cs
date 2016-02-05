static partial class BitTricks
{
    #region Abs

    public static sbyte GetAbs(this sbyte value)
    {
        var mask = value >> 15;
        return (sbyte)((value + mask) ^ mask);
    }

    public static short GetAbs(this short value)
    {
        var mask = value >> 15;
        return (short)((value + mask) ^ mask);
    }

    public static int GetAbs(this int value)
    {
        var mask = value >> 31;
        return (value + mask) ^ mask;
    }

    public static long GetAbs(this long value)
    {
        var mask = value >> 63;
        return (value + mask) ^ mask;
    }

    #endregion

    #region FlipBits

    public static byte FlipBits(this byte value)
    {
        uint v = value;
        v = ((v & 0x55) << 1) | ((v >> 1) & 0x55);
        v = ((v & 0x33) << 2) | ((v >> 2) & 0x33);
        v = (v >> 4) | (v << 4);
        return (byte)v;
    }
    public static sbyte FlipBits(this sbyte value)
        => (sbyte)((byte)value).FlipBits();
    public static sbyte FlipBits7(this sbyte value)
        => (sbyte)(((byte)value).FlipBits() >> 1);

    public static ushort FlipBits(this ushort value)
    {
        uint v = value;
        v = ((v & 0x5555) << 1) | ((v >> 1) & 0x5555);
        v = ((v & 0x3333) << 2) | ((v >> 2) & 0x3333);
        v = ((v & 0x0F0F) << 4) | ((v >> 4) & 0x0F0F);
        v = (v >> 8) | (v << 8);
        return (ushort)v;
    }
    public static short FlipBits(this short value)
        => (short)((ushort)value).FlipBits();
    public static short FlipBits15(this short value)
        => (short)(((ushort)value).FlipBits() >> 1);

    public static uint FlipBits(this uint value)
    {
        value = ((value & 0x55555555) << 1) | ((value >> 1) & 0x55555555);
        value = ((value & 0x33333333) << 2) | ((value >> 2) & 0x33333333);
        value = ((value & 0x0F0F0F0F) << 4) | ((value >> 4) & 0x0F0F0F0F);
        value = ((value & 0x00FF00FF) << 8) | ((value >> 8) & 0x00FF00FF);
        value = (value >> 16) | (value << 16);
        return value;
    }
    public static int FlipBits(this int value)
        => (int)((uint)value).FlipBits();
    public static int FlipBits31(this int value)
        => (int)(((uint)value).FlipBits() >> 1);

    public static ulong FlipBits(this ulong value)
    {
        value = ((value & 0x5555555555555555) << 0x01) | ((value >> 0x01) & 0x5555555555555555);
        value = ((value & 0x3333333333333333) << 0x02) | ((value >> 0x02) & 0x3333333333333333);
        value = ((value & 0x0F0F0F0F0F0F0F0F) << 0x04) | ((value >> 0x04) & 0x0F0F0F0F0F0F0F0F);
        value = ((value & 0x00FF00FF00FF00FF) << 0x08) | ((value >> 0x08) & 0x00FF00FF00FF00FF);
        value = ((value & 0x0000FFFF0000FFFF) << 0x10) | ((value >> 0x10) & 0x0000FFFF0000FFFF);
        value = (value >> 32) | (value << 32);
        return value;
    }
    public static long FlipBits(this long value)
        => (long)((ulong)value).FlipBits();
    public static long FlipBits63(this long value)
        => (long)(((ulong)value).FlipBits() >> 1);

    #endregion

    #region GetSign

    public static sbyte GetSign(this sbyte value)
        => (sbyte)(value >> 7);
    public static short GetSign(this short value)
        => (short)(value >> 15);
    public static int GetSign(this int value)
        => value >> 31;
    public static long GetSign(this long value)
        => value >> 63;

    #endregion
}
