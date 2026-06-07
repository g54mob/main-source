using System;
using System.Runtime.InteropServices;
using Rewired.Utils;

internal class SbUIvncwPygDdWhgMeEVPFknbZc : IDisposable
{
	private unsafe byte* cdCFllFuKnaFteUUiDaHTeGMzno;

	private int AXtmKkXZtGTHjIdccYNdudRTNUY;

	private bool nNxUslIcGUpqKgpPZYhuimcvWyC;

	public unsafe byte* UnsafePointer
	{
		get
		{
			return cdCFllFuKnaFteUUiDaHTeGMzno;
		}
	}

	public unsafe IntPtr Pointer
	{
		get
		{
			return (IntPtr)cdCFllFuKnaFteUUiDaHTeGMzno;
		}
	}

	public int Length
	{
		get
		{
			return AXtmKkXZtGTHjIdccYNdudRTNUY;
		}
	}

	public unsafe byte this[int index]
	{
		get
		{
			if (index < 0 || index >= AXtmKkXZtGTHjIdccYNdudRTNUY)
			{
				throw new IndexOutOfRangeException();
			}
			return cdCFllFuKnaFteUUiDaHTeGMzno[index];
		}
		set
		{
			if (index < 0 || index >= AXtmKkXZtGTHjIdccYNdudRTNUY)
			{
				throw new IndexOutOfRangeException();
			}
			cdCFllFuKnaFteUUiDaHTeGMzno[index] = value;
		}
	}

	public SbUIvncwPygDdWhgMeEVPFknbZc(int size)
	{
		SPuHKELaAJVLAexJrJVkeakSxe(size);
	}

	public unsafe IntPtr phwoPMfJjZHvTmWUsajASuNTIsc(int P_0 = 0)
	{
		if (P_0 == 0)
		{
			return (IntPtr)cdCFllFuKnaFteUUiDaHTeGMzno;
		}
		if (P_0 < 0 || P_0 >= AXtmKkXZtGTHjIdccYNdudRTNUY)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		return (IntPtr)(cdCFllFuKnaFteUUiDaHTeGMzno + P_0);
	}

	public unsafe string GeJEdtHYBBuKoOHHeFNQionhboNM()
	{
		string text = "";
		for (int i = 0; i < AXtmKkXZtGTHjIdccYNdudRTNUY; i++)
		{
			text = text + cdCFllFuKnaFteUUiDaHTeGMzno[i].ToString("x2") + " ";
		}
		return text;
	}

	public unsafe bool OzzanGOzVaCzvyIfaqNhIQGusRb(int P_0, byte P_1)
	{
		if (1 + P_0 > AXtmKkXZtGTHjIdccYNdudRTNUY || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (cdCFllFuKnaFteUUiDaHTeGMzno[P_0] & (1 << (int)P_1)) != 0;
	}

	public unsafe byte ahLlsXrfrUcEXCMOyOIJTWrmrLBW(int P_0)
	{
		if (1 + P_0 > AXtmKkXZtGTHjIdccYNdudRTNUY || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return cdCFllFuKnaFteUUiDaHTeGMzno[P_0];
	}

	public unsafe short brIyYpeHlIhKBPPTmqfkhwsNTzX(int P_0)
	{
		if (2 + P_0 > AXtmKkXZtGTHjIdccYNdudRTNUY || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(short*)(cdCFllFuKnaFteUUiDaHTeGMzno + P_0);
	}

	public unsafe ushort dryLaEtYJfUzzmNxgszXJatJacgB(int P_0)
	{
		if (2 + P_0 > AXtmKkXZtGTHjIdccYNdudRTNUY || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ushort*)(cdCFllFuKnaFteUUiDaHTeGMzno + P_0);
	}

	public unsafe int qoaYCzLCrimOnaGJQHHgnvpFjsO(int P_0)
	{
		if (4 + P_0 > AXtmKkXZtGTHjIdccYNdudRTNUY || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(int*)(cdCFllFuKnaFteUUiDaHTeGMzno + P_0);
	}

	public unsafe uint SLEkbWnZuvHCSsDIBUOUzicDgpe(int P_0)
	{
		if (4 + P_0 > AXtmKkXZtGTHjIdccYNdudRTNUY || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(uint*)(cdCFllFuKnaFteUUiDaHTeGMzno + P_0);
	}

	public unsafe long PtXtEoCRvMIegHtqVFomnyUczBy(int P_0)
	{
		if (8 + P_0 > AXtmKkXZtGTHjIdccYNdudRTNUY || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(long*)(cdCFllFuKnaFteUUiDaHTeGMzno + P_0);
	}

	public unsafe ulong JbQoAZevdUbILdVvHktOuVkKts(int P_0)
	{
		if (8 + P_0 > AXtmKkXZtGTHjIdccYNdudRTNUY || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ulong*)(cdCFllFuKnaFteUUiDaHTeGMzno + P_0);
	}

	public unsafe void BzRDvjvAQHKNUfdBiARKBsCcKkSL(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("bytes");
		}
		int num = P_0.Length;
		if (num <= 0)
		{
			throw new ArgumentOutOfRangeException("bytes.Length must be > 0.");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead must be > 0");
		}
		if (P_1 > num)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead must be <= bufferLength.");
		}
		if (P_1 > AXtmKkXZtGTHjIdccYNdudRTNUY)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead must be <= Length.");
		}
		if (P_3 >= num)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be < bufferLength.");
		}
		if (P_3 < 0)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
		}
		if (P_2 >= AXtmKkXZtGTHjIdccYNdudRTNUY)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be < Length.");
		}
		if (P_2 < 0)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
		}
		if (P_3 + P_1 > num)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex + numBytesToRead must be < bufferLength.");
		}
		if (P_1 + P_2 > AXtmKkXZtGTHjIdccYNdudRTNUY)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory((IntPtr)cdCFllFuKnaFteUUiDaHTeGMzno, P_0, P_2, P_3, P_1);
	}

	public unsafe void BzRDvjvAQHKNUfdBiARKBsCcKkSL(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("bytes");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("bufferLength must be > 0.");
		}
		if (P_2 <= 0)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead must be > 0");
		}
		if (P_2 > P_1)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead must be <= bufferLength.");
		}
		if (P_2 > AXtmKkXZtGTHjIdccYNdudRTNUY)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead must be <= Length.");
		}
		if (P_4 >= P_1)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be < bufferLength.");
		}
		if (P_4 < 0)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
		}
		if (P_3 >= AXtmKkXZtGTHjIdccYNdudRTNUY)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be < Length.");
		}
		if (P_3 < 0)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
		}
		if (P_4 + P_2 > P_1)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex + numBytesToRead must be < bufferLength.");
		}
		if (P_2 + P_3 > AXtmKkXZtGTHjIdccYNdudRTNUY)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		srQAjpRGjtjqkatjQItsCdtbKROA.jZaoqafpmcVnUamkQHboGxYtgDI(cdCFllFuKnaFteUUiDaHTeGMzno, P_0, P_3, P_4, P_2);
	}

	public unsafe void BzRDvjvAQHKNUfdBiARKBsCcKkSL(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		BzRDvjvAQHKNUfdBiARKBsCcKkSL((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int KOXpOMjFyJDqRjvdDHjWBnAkNgXn(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0)
		{
			return 0;
		}
		if (P_2 >= AXtmKkXZtGTHjIdccYNdudRTNUY)
		{
			return 0;
		}
		if (P_3 >= num)
		{
			return 0;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		if (P_3 < 0)
		{
			P_3 = 0;
		}
		if (P_2 + P_1 > AXtmKkXZtGTHjIdccYNdudRTNUY)
		{
			P_1 = AXtmKkXZtGTHjIdccYNdudRTNUY - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		NativeTools.CopyMemory((IntPtr)cdCFllFuKnaFteUUiDaHTeGMzno, P_0, P_2, P_3, P_1);
		return P_1;
	}

	public unsafe int KOXpOMjFyJDqRjvdDHjWBnAkNgXn(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= AXtmKkXZtGTHjIdccYNdudRTNUY)
		{
			return 0;
		}
		if (P_4 >= P_1)
		{
			return 0;
		}
		if (P_3 < 0)
		{
			P_3 = 0;
		}
		if (P_4 < 0)
		{
			P_4 = 0;
		}
		if (P_3 + P_2 > AXtmKkXZtGTHjIdccYNdudRTNUY)
		{
			P_2 = AXtmKkXZtGTHjIdccYNdudRTNUY - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		srQAjpRGjtjqkatjQItsCdtbKROA.jZaoqafpmcVnUamkQHboGxYtgDI(cdCFllFuKnaFteUUiDaHTeGMzno, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public unsafe int KOXpOMjFyJDqRjvdDHjWBnAkNgXn(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0;
		}
		return KOXpOMjFyJDqRjvdDHjWBnAkNgXn((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe void qphZcGYPkTxUyiRixeofeTKROcx(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > AXtmKkXZtGTHjIdccYNdudRTNUY || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			byte* intPtr = cdCFllFuKnaFteUUiDaHTeGMzno + P_0;
			*intPtr |= (byte)(1 << (int)P_1);
		}
		else
		{
			byte* intPtr2 = cdCFllFuKnaFteUUiDaHTeGMzno + P_0;
			*intPtr2 &= (byte)(~(1 << (int)P_1));
		}
	}

	public unsafe void uwRrXbrytlKXYWIOmlUkwmZqEzx(byte P_0, int P_1)
	{
		if (1 + P_1 > AXtmKkXZtGTHjIdccYNdudRTNUY || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		cdCFllFuKnaFteUUiDaHTeGMzno[P_1] = P_0;
	}

	public unsafe void uwRrXbrytlKXYWIOmlUkwmZqEzx(short P_0, int P_1)
	{
		if (2 + P_1 > AXtmKkXZtGTHjIdccYNdudRTNUY || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(short*)(cdCFllFuKnaFteUUiDaHTeGMzno + P_1) = P_0;
	}

	public unsafe void uwRrXbrytlKXYWIOmlUkwmZqEzx(ushort P_0, int P_1)
	{
		if (2 + P_1 > AXtmKkXZtGTHjIdccYNdudRTNUY || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ushort*)(cdCFllFuKnaFteUUiDaHTeGMzno + P_1) = P_0;
	}

	public unsafe void uwRrXbrytlKXYWIOmlUkwmZqEzx(int P_0, int P_1)
	{
		if (4 + P_1 > AXtmKkXZtGTHjIdccYNdudRTNUY || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(int*)(cdCFllFuKnaFteUUiDaHTeGMzno + P_1) = P_0;
	}

	public unsafe void uwRrXbrytlKXYWIOmlUkwmZqEzx(uint P_0, int P_1)
	{
		if (4 + P_1 > AXtmKkXZtGTHjIdccYNdudRTNUY || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(uint*)(cdCFllFuKnaFteUUiDaHTeGMzno + P_1) = P_0;
	}

	public unsafe void uwRrXbrytlKXYWIOmlUkwmZqEzx(long P_0, int P_1)
	{
		if (8 + P_1 > AXtmKkXZtGTHjIdccYNdudRTNUY || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(long*)(cdCFllFuKnaFteUUiDaHTeGMzno + P_1) = P_0;
	}

	public unsafe void uwRrXbrytlKXYWIOmlUkwmZqEzx(ulong P_0, int P_1)
	{
		if (8 + P_1 > AXtmKkXZtGTHjIdccYNdudRTNUY || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ulong*)(cdCFllFuKnaFteUUiDaHTeGMzno + P_1) = P_0;
	}

	public unsafe void uwRrXbrytlKXYWIOmlUkwmZqEzx(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("bytes");
		}
		int num = P_0.Length;
		if (num <= 0)
		{
			throw new ArgumentOutOfRangeException("bytes.Length must be > 0.");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite must be > 0");
		}
		if (P_1 > num)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite must be <= bufferLength.");
		}
		if (P_1 > AXtmKkXZtGTHjIdccYNdudRTNUY)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite must be <= Length.");
		}
		if (P_3 >= num)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be < bufferLength.");
		}
		if (P_3 < 0)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
		}
		if (P_2 >= AXtmKkXZtGTHjIdccYNdudRTNUY)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be < Length.");
		}
		if (P_2 < 0)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
		}
		if (P_3 + P_1 > num)
		{
			throw new ArgumentOutOfRangeException("readStartIndex + numBytesToWrite must be < bufferLength.");
		}
		if (P_1 + P_2 > AXtmKkXZtGTHjIdccYNdudRTNUY)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, (IntPtr)cdCFllFuKnaFteUUiDaHTeGMzno, P_3, P_2, P_1);
	}

	public unsafe void uwRrXbrytlKXYWIOmlUkwmZqEzx(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("bytes");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("bufferLength must be > 0.");
		}
		if (P_2 <= 0)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite must be > 0");
		}
		if (P_2 > P_1)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite must be <= bufferLength.");
		}
		if (P_2 > AXtmKkXZtGTHjIdccYNdudRTNUY)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite must be <= Length.");
		}
		if (P_4 >= P_1)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be < bufferLength.");
		}
		if (P_4 < 0)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
		}
		if (P_3 >= AXtmKkXZtGTHjIdccYNdudRTNUY)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be < Length.");
		}
		if (P_3 < 0)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
		}
		if (P_4 + P_2 > P_1)
		{
			throw new ArgumentOutOfRangeException("readStartIndex + numBytesToWrite must be < bufferLength.");
		}
		if (P_2 + P_3 > AXtmKkXZtGTHjIdccYNdudRTNUY)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		srQAjpRGjtjqkatjQItsCdtbKROA.jZaoqafpmcVnUamkQHboGxYtgDI(P_0, cdCFllFuKnaFteUUiDaHTeGMzno, P_4, P_3, P_2);
	}

	public unsafe void uwRrXbrytlKXYWIOmlUkwmZqEzx(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		uwRrXbrytlKXYWIOmlUkwmZqEzx((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int wZGHqvpqurPSaSLhSFRcXnpjBkE(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= AXtmKkXZtGTHjIdccYNdudRTNUY)
		{
			return 0;
		}
		if (P_3 < 0)
		{
			P_3 = 0;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 + P_2 > AXtmKkXZtGTHjIdccYNdudRTNUY)
		{
			P_1 = AXtmKkXZtGTHjIdccYNdudRTNUY - P_2;
		}
		NativeTools.CopyMemory(P_0, (IntPtr)cdCFllFuKnaFteUUiDaHTeGMzno, P_3, P_2, P_1);
		return P_1;
	}

	public unsafe int wZGHqvpqurPSaSLhSFRcXnpjBkE(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= AXtmKkXZtGTHjIdccYNdudRTNUY)
		{
			return 0;
		}
		if (P_4 < 0)
		{
			P_4 = 0;
		}
		if (P_3 < 0)
		{
			P_3 = 0;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		if (P_2 + P_3 > AXtmKkXZtGTHjIdccYNdudRTNUY)
		{
			P_2 = AXtmKkXZtGTHjIdccYNdudRTNUY - P_3;
		}
		srQAjpRGjtjqkatjQItsCdtbKROA.jZaoqafpmcVnUamkQHboGxYtgDI(P_0, cdCFllFuKnaFteUUiDaHTeGMzno, P_4, P_3, P_2);
		return P_2;
	}

	public unsafe int wZGHqvpqurPSaSLhSFRcXnpjBkE(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		return wZGHqvpqurPSaSLhSFRcXnpjBkE((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool SPuHKELaAJVLAexJrJVkeakSxe(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("size");
		}
		if (AXtmKkXZtGTHjIdccYNdudRTNUY == P_0)
		{
			return true;
		}
		HipnOxZiAwJosyWnuwVWSsABKhS();
		if (P_0 == 0)
		{
			return true;
		}
		AXtmKkXZtGTHjIdccYNdudRTNUY = P_0;
		cdCFllFuKnaFteUUiDaHTeGMzno = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		bVJfbjSJHtCUhxVYYaQYFCJuPMDE();
		return true;
	}

	public unsafe void bVJfbjSJHtCUhxVYYaQYFCJuPMDE()
	{
		if (AXtmKkXZtGTHjIdccYNdudRTNUY != 0)
		{
			srQAjpRGjtjqkatjQItsCdtbKROA.bThCwINQylQxFgoBLlhRRhQHrCe(cdCFllFuKnaFteUUiDaHTeGMzno, AXtmKkXZtGTHjIdccYNdudRTNUY);
		}
	}

	public unsafe void HipnOxZiAwJosyWnuwVWSsABKhS()
	{
		if (AXtmKkXZtGTHjIdccYNdudRTNUY == 0)
		{
			return;
		}
		try
		{
			if (cdCFllFuKnaFteUUiDaHTeGMzno != null)
			{
				Marshal.FreeHGlobal(Pointer);
			}
		}
		catch
		{
		}
		cdCFllFuKnaFteUUiDaHTeGMzno = null;
		AXtmKkXZtGTHjIdccYNdudRTNUY = 0;
	}

	public override string ToString()
	{
		string text = "";
		for (int i = 0; i < AXtmKkXZtGTHjIdccYNdudRTNUY; i++)
		{
			text = text + ahLlsXrfrUcEXCMOyOIJTWrmrLBW(i).ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		HtJdxRxaGggkmaMTSWUpHqjZLDV(true);
		GC.SuppressFinalize(this);
	}

	~SbUIvncwPygDdWhgMeEVPFknbZc()
	{
		HtJdxRxaGggkmaMTSWUpHqjZLDV(false);
	}

	protected virtual void HtJdxRxaGggkmaMTSWUpHqjZLDV(bool P_0)
	{
		if (!nNxUslIcGUpqKgpPZYhuimcvWyC)
		{
			HipnOxZiAwJosyWnuwVWSsABKhS();
			nNxUslIcGUpqKgpPZYhuimcvWyC = true;
		}
	}

	public unsafe static implicit operator IntPtr(SbUIvncwPygDdWhgMeEVPFknbZc buffer)
	{
		if (buffer == null)
		{
			return IntPtr.Zero;
		}
		return (IntPtr)buffer.cdCFllFuKnaFteUUiDaHTeGMzno;
	}

	public unsafe static implicit operator void*(SbUIvncwPygDdWhgMeEVPFknbZc buffer)
	{
		if (buffer == null)
		{
			return null;
		}
		return buffer.cdCFllFuKnaFteUUiDaHTeGMzno;
	}

	public unsafe static bool aMHEFIYjSoHPvxJgFESoklFxHoJM(SbUIvncwPygDdWhgMeEVPFknbZc P_0, SbUIvncwPygDdWhgMeEVPFknbZc P_1)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("source");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("destination");
		}
		if (P_0.AXtmKkXZtGTHjIdccYNdudRTNUY == 0)
		{
			P_1.HipnOxZiAwJosyWnuwVWSsABKhS();
			return true;
		}
		if (P_1.SPuHKELaAJVLAexJrJVkeakSxe(P_0.AXtmKkXZtGTHjIdccYNdudRTNUY))
		{
			P_1.uwRrXbrytlKXYWIOmlUkwmZqEzx(P_0.cdCFllFuKnaFteUUiDaHTeGMzno, P_0.AXtmKkXZtGTHjIdccYNdudRTNUY, P_0.AXtmKkXZtGTHjIdccYNdudRTNUY);
			return true;
		}
		return false;
	}
}
