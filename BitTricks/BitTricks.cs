using System;

#if EXPOSE_EVERYTHING || EXPOSE_BITTRICKS
public
#endif
static class BitTricks
{
    #region MAGIC, NO TOUCH!

    // http://graphics.stanford.edu/~seander/bithacks.html#IntegerLogDeBruijn

    static readonly byte[] DeBruijnTable32 = new byte[]
    {
        0, 9, 1, 10, 13, 21, 2, 29, 11, 14, 16, 18, 22, 25, 3, 30,
        8, 12, 20, 28, 15, 17, 24, 7, 19, 27, 23, 6, 26, 5, 4, 31
    };
    const uint DeBruijnMultiplicator32 = 0x07C4ACDDu;
    static byte lookupDeBruijnTable32(uint value)
        => DeBruijnTable32[value * DeBruijnMultiplicator32 >> 27];
    public static byte GetLeastSignificantBitNonZero(this uint value)
    {
        value = value ^ (value - 1);

        return lookupDeBruijnTable32(value);
    }
    public static byte GetLeastSignificantBitNonZero(this int value)
        => GetLeastSignificantBitNonZero((uint)value);

    public static byte GetMostSignificantBitNonZero(this uint value)
    {
        value |= value >> 1;
        value |= value >> 2;
        value |= value >> 4;
        value |= value >> 8;
        value |= value >> 16;

        return lookupDeBruijnTable32(value);
    }
    public static byte GetMostSignificantBitNonZero(this int value)
        => GetMostSignificantBitNonZero((uint)value);

    // used generator from http://chessprogramming.wikispaces.com/De+Bruijn+Sequence+Generator
    static readonly byte[] DeBruijnTable64 = new byte[]
    {
	    0 ,	47,	1 ,	56,	48,	27,	2 ,	60,
	    57,	49,	41,	37,	28,	16,	3 ,	61,
	    54,	58,	35,	52,	50,	42,	21,	44,
	    38,	32,	29,	23,	17,	11,	4 ,	62,
	    46,	55,	26,	59,	40,	36,	15,	53,
	    34,	51,	20,	43,	31,	22,	10,	45,
	    25,	39,	14,	33,	19,	30,	9 ,	24,
	    13,	18,	8 ,	12,	7 ,	6 ,	5 ,	63,
    };
    // the cyclc number has to be in the last 16th of all possible values
    // any beyond the 62914560th(0x03C0_0000) should work for this purpose
    const ulong DeBruijnMultiplicator64 = 0x03F79D71B4CB0A89uL; // the last one
    static byte lookupDeBruijnTable64(ulong value)
        => DeBruijnTable64[value * DeBruijnMultiplicator64 >> 58];
    public static byte GetLeastSignificantBitNonZero(this ulong value)
    {
        value = value ^ (value - 1);

        return lookupDeBruijnTable64(value);
    }
    public static byte GetLeastSignificantBitNonZero(this long value)
        => GetLeastSignificantBitNonZero((ulong)value);

    public static byte GetMostSignificantBitNonZero(this ulong value)
    {
        value |= value >> 1;
        value |= value >> 2;
        value |= value >> 4;
        value |= value >> 8;
        value |= value >> 16;
        value |= value >> 32;

        return lookupDeBruijnTable64(value);
    }
    public static byte GetMostSignificantBitNonZero(this long value)
        => GetMostSignificantBitNonZero((ulong)value);

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
        => (sbyte)((value & 0x80) | (((byte)value).FlipBits() >> 1));

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
        => (short)((value & 0x8000) | (((ushort)value).FlipBits() >> 1));

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
        => (value & unchecked((int)0x80000000)) | (int)(((uint)value).FlipBits() >> 1);

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
        => (value & unchecked((long)0x8000000000000000)) | (long)(((ulong)value).FlipBits() >> 1);

    #endregion

    #region GetSignPattern

    public static sbyte GetSignPattern(this sbyte value)
        => (sbyte)(value >> 7);
    public static short GetSignPattern(this short value)
        => (short)(value >> 15);
    public static int GetSignPattern(this int value)
        => value >> 31;
    public static long GetSignPattern(this long value)
        => value >> 63;

    #endregion

    #region ToBinaryString

    public static string ToBinaryString(this byte value)
        => Convert.ToString(value, 2).PadLeft(8, '0');
    public static string ToBinaryString(this sbyte value)
        => ((byte)value).ToBinaryString();

    public static string ToBinaryString(this short value)
        => Convert.ToString(value, 2).PadLeft(16, '0');
    public static string ToBinaryString(this ushort value)
        => ((short)value).ToBinaryString();

    public static string ToBinaryString(this int value)
        => Convert.ToString(value, 2).PadLeft(32, '0');
    public static string ToBinaryString(this uint value)
        => ((int)value).ToBinaryString();

    public static string ToBinaryString(this long value)
        => Convert.ToString(value, 2).PadLeft(64, '0');
    public static string ToBinaryString(this ulong value)
        => ((long)value).ToBinaryString();

    #endregion

    #region ZigZag

    public static uint Zig(this int value)
        => (uint)(value.GetSignPattern() ^ value << 1);

    public static int Zag(this uint value)
        => ((int)value << 31).GetSignPattern() ^ (int)(value >> 1);

    public static ulong Zig(this long value)
        => (ulong)(value.GetSignPattern() ^ value << 1);

    public static long Zag(this ulong value)
        => ((long)value << 63).GetSignPattern() ^ (long)(value >> 1);

    #endregion
}
