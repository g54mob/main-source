using System;

internal class taduRocAKxsZmmUPzHPoPEwuAaI : IDisposable
{
	private readonly DCzMZYjZMZbSBuYhLKaUQoUIzoZ MGmVOJiswkwnBAbvbGQwLtBdeEt;

	private bool[] aupGwJllbxcVmjTuqItRwKRtxMg;

	protected readonly int AaMPoXDquMudbJDKymvgkAgliFc;

	protected readonly int vtIobczDotOpllyixsFUaAwldJS;

	private bool euujVPFzGztViWDbYvUutBvFQFP;

	public int ValueBitSize => AaMPoXDquMudbJDKymvgkAgliFc;

	public int Length => vtIobczDotOpllyixsFUaAwldJS;

	public bool[] ValueWorkBuffer => aupGwJllbxcVmjTuqItRwKRtxMg ?? (aupGwJllbxcVmjTuqItRwKRtxMg = new bool[AaMPoXDquMudbJDKymvgkAgliFc]);

	public taduRocAKxsZmmUPzHPoPEwuAaI(int length, int valueBitSize)
	{
		if (length <= 0)
		{
			throw new ArgumentOutOfRangeException("length");
		}
		if (valueBitSize <= 0)
		{
			throw new ArgumentOutOfRangeException("entryBitSize");
		}
		vtIobczDotOpllyixsFUaAwldJS = length;
		AaMPoXDquMudbJDKymvgkAgliFc = valueBitSize;
		int num = length * valueBitSize;
		MGmVOJiswkwnBAbvbGQwLtBdeEt = new DCzMZYjZMZbSBuYhLKaUQoUIzoZ(num / 8 + ((num % 8 != 0) ? 1 : 0));
	}

	public unsafe void IzmYoCantdlEDbvheGAmRxNbwRb(int P_0, byte* P_1, int P_2)
	{
		if (P_0 < 0 || P_0 >= vtIobczDotOpllyixsFUaAwldJS)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (P_2 < AaMPoXDquMudbJDKymvgkAgliFc)
		{
			throw new Exception("Buffer is too small to hold the data. Must be at least " + AaMPoXDquMudbJDKymvgkAgliFc + " bits.");
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < AaMPoXDquMudbJDKymvgkAgliFc; i++)
		{
			gYYfUsdHnFXNKfqtbpWrRbjiutS(P_0, i, out var num3, out var b);
			P_1[i] = (MGmVOJiswkwnBAbvbGQwLtBdeEt.TXWAedgTpLjZfJInftZsrLTDnvGq(num3, b) ? ((byte)(P_1[num] | (1 << num2))) : ((byte)(P_1[num] & ~(1 << num2))));
			num2++;
			if (num2 >= 8)
			{
				num++;
				num2 = 0;
			}
		}
	}

	public unsafe void IzmYoCantdlEDbvheGAmRxNbwRb(int P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new ArgumentNullException("buffer");
		}
		IzmYoCantdlEDbvheGAmRxNbwRb(P_0, (byte*)(void*)P_1, P_2);
	}

	public unsafe void IzmYoCantdlEDbvheGAmRxNbwRb(int P_0, out byte P_1)
	{
		byte b = 0;
		byte* ptr = &b;
		IzmYoCantdlEDbvheGAmRxNbwRb(P_0, ptr, 64);
		P_1 = b;
	}

	public void IzmYoCantdlEDbvheGAmRxNbwRb(int P_0, out sbyte P_1)
	{
		IzmYoCantdlEDbvheGAmRxNbwRb(P_0, out byte b);
		P_1 = (sbyte)b;
	}

	public unsafe void IzmYoCantdlEDbvheGAmRxNbwRb(int P_0, out short P_1)
	{
		short num = 0;
		byte* ptr = (byte*)(&num);
		IzmYoCantdlEDbvheGAmRxNbwRb(P_0, ptr, 64);
		P_1 = num;
	}

	public void IzmYoCantdlEDbvheGAmRxNbwRb(int P_0, out ushort P_1)
	{
		IzmYoCantdlEDbvheGAmRxNbwRb(P_0, out short num);
		P_1 = (ushort)num;
	}

	public unsafe void IzmYoCantdlEDbvheGAmRxNbwRb(int P_0, out int P_1)
	{
		int num = 0;
		byte* ptr = (byte*)(&num);
		IzmYoCantdlEDbvheGAmRxNbwRb(P_0, ptr, 64);
		P_1 = num;
	}

	public void IzmYoCantdlEDbvheGAmRxNbwRb(int P_0, out uint P_1)
	{
		IzmYoCantdlEDbvheGAmRxNbwRb(P_0, out int num);
		P_1 = (uint)num;
	}

	public unsafe void IzmYoCantdlEDbvheGAmRxNbwRb(int P_0, out long P_1)
	{
		long num = 0L;
		byte* ptr = (byte*)(&num);
		IzmYoCantdlEDbvheGAmRxNbwRb(P_0, ptr, 64);
		P_1 = num;
	}

	public void IzmYoCantdlEDbvheGAmRxNbwRb(int P_0, out ulong P_1)
	{
		IzmYoCantdlEDbvheGAmRxNbwRb(P_0, out long num);
		P_1 = (ulong)num;
	}

	public void IzmYoCantdlEDbvheGAmRxNbwRb(int P_0, bool[] P_1)
	{
		if (P_0 < 0 || P_0 >= vtIobczDotOpllyixsFUaAwldJS)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("valueBuffer");
		}
		if (P_1.Length < AaMPoXDquMudbJDKymvgkAgliFc)
		{
			throw new Exception("valueBuffer.Length must be >= " + AaMPoXDquMudbJDKymvgkAgliFc);
		}
		for (int i = 0; i < AaMPoXDquMudbJDKymvgkAgliFc; i++)
		{
			gYYfUsdHnFXNKfqtbpWrRbjiutS(P_0, i, out var num, out var b);
			P_1[i] = MGmVOJiswkwnBAbvbGQwLtBdeEt.TXWAedgTpLjZfJInftZsrLTDnvGq(num, b);
		}
	}

	public unsafe void iPqCwAZeDSMUuyZPNmHIebwaSSn(int P_0, byte* P_1, int P_2)
	{
		if (P_0 < 0 || P_0 >= vtIobczDotOpllyixsFUaAwldJS)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (P_2 <= 0)
		{
			throw new Exception("bufferSize must be >= 0");
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < AaMPoXDquMudbJDKymvgkAgliFc; i++)
		{
			gYYfUsdHnFXNKfqtbpWrRbjiutS(P_0, i, out var num3, out var b);
			bool flag = i < P_2 && (flag = (P_1[num] & (1 << num2)) != 0);
			MGmVOJiswkwnBAbvbGQwLtBdeEt.vWMWKvHFGeWDgMauoWyodBVkfVY(num3, b, flag);
			num2++;
			if (num2 >= 8)
			{
				num++;
				num2 = 0;
			}
		}
	}

	public unsafe void iPqCwAZeDSMUuyZPNmHIebwaSSn(int P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new ArgumentNullException("buffer");
		}
		iPqCwAZeDSMUuyZPNmHIebwaSSn(P_0, (byte*)(void*)P_1, P_2);
	}

	public unsafe void iPqCwAZeDSMUuyZPNmHIebwaSSn(int P_0, byte P_1)
	{
		byte* ptr = &P_1;
		iPqCwAZeDSMUuyZPNmHIebwaSSn(P_0, ptr, 8);
	}

	public void iPqCwAZeDSMUuyZPNmHIebwaSSn(int P_0, sbyte P_1)
	{
		iPqCwAZeDSMUuyZPNmHIebwaSSn(P_0, (byte)P_1);
	}

	public unsafe void iPqCwAZeDSMUuyZPNmHIebwaSSn(int P_0, short P_1)
	{
		byte* ptr = (byte*)(&P_1);
		iPqCwAZeDSMUuyZPNmHIebwaSSn(P_0, ptr, 16);
	}

	public void iPqCwAZeDSMUuyZPNmHIebwaSSn(int P_0, ushort P_1)
	{
		iPqCwAZeDSMUuyZPNmHIebwaSSn(P_0, (short)P_1);
	}

	public unsafe void iPqCwAZeDSMUuyZPNmHIebwaSSn(int P_0, int P_1)
	{
		byte* ptr = (byte*)(&P_1);
		iPqCwAZeDSMUuyZPNmHIebwaSSn(P_0, ptr, 32);
	}

	public void iPqCwAZeDSMUuyZPNmHIebwaSSn(int P_0, uint P_1)
	{
		iPqCwAZeDSMUuyZPNmHIebwaSSn(P_0, (int)P_1);
	}

	public unsafe void iPqCwAZeDSMUuyZPNmHIebwaSSn(int P_0, long P_1)
	{
		byte* ptr = (byte*)(&P_1);
		iPqCwAZeDSMUuyZPNmHIebwaSSn(P_0, ptr, 64);
	}

	public void iPqCwAZeDSMUuyZPNmHIebwaSSn(int P_0, ulong P_1)
	{
		iPqCwAZeDSMUuyZPNmHIebwaSSn(P_0, (long)P_1);
	}

	public void iPqCwAZeDSMUuyZPNmHIebwaSSn(int P_0, bool[] P_1)
	{
		if (P_0 < 0 || P_0 >= vtIobczDotOpllyixsFUaAwldJS)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("valueBuffer");
		}
		if (P_1.Length < AaMPoXDquMudbJDKymvgkAgliFc)
		{
			throw new Exception("valueBuffer.Length must be >= " + AaMPoXDquMudbJDKymvgkAgliFc);
		}
		for (int i = 0; i < AaMPoXDquMudbJDKymvgkAgliFc; i++)
		{
			gYYfUsdHnFXNKfqtbpWrRbjiutS(P_0, i, out var num, out var b);
			MGmVOJiswkwnBAbvbGQwLtBdeEt.vWMWKvHFGeWDgMauoWyodBVkfVY(num, b, P_1[i]);
		}
	}

	private void gYYfUsdHnFXNKfqtbpWrRbjiutS(int P_0, int P_1, out int P_2, out byte P_3)
	{
		if (P_0 < 0 || P_0 >= vtIobczDotOpllyixsFUaAwldJS)
		{
			throw new IndexOutOfRangeException("entryIndex");
		}
		if (P_1 < 0 || P_1 >= AaMPoXDquMudbJDKymvgkAgliFc)
		{
			throw new ArgumentOutOfRangeException("bitOffset");
		}
		int num = P_0 * AaMPoXDquMudbJDKymvgkAgliFc + P_1;
		P_2 = num / AaMPoXDquMudbJDKymvgkAgliFc;
		P_3 = (byte)(num - P_2 * AaMPoXDquMudbJDKymvgkAgliFc);
	}

	private int cGltwCvstmwjNOStRnLrFxNZtPl(int P_0, out byte P_1)
	{
		if (P_0 < 0 || P_0 >= vtIobczDotOpllyixsFUaAwldJS * AaMPoXDquMudbJDKymvgkAgliFc)
		{
			throw new IndexOutOfRangeException("bitIndex");
		}
		int num = P_0 / AaMPoXDquMudbJDKymvgkAgliFc;
		P_1 = (byte)(P_0 - num * AaMPoXDquMudbJDKymvgkAgliFc);
		return num;
	}

	public void Dispose()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(true);
		GC.SuppressFinalize(this);
	}

	~taduRocAKxsZmmUPzHPoPEwuAaI()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(false);
	}

	protected virtual void KRgasgBmyLeCeDGJhNGqwMeOqCwJ(bool P_0)
	{
		if (!euujVPFzGztViWDbYvUutBvFQFP)
		{
			if (P_0 && MGmVOJiswkwnBAbvbGQwLtBdeEt != null)
			{
				MGmVOJiswkwnBAbvbGQwLtBdeEt.Dispose();
			}
			euujVPFzGztViWDbYvUutBvFQFP = true;
		}
	}
}
