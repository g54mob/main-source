using System;
using System.Runtime.InteropServices;
using Rewired.Utils;

internal class xvZAvdFfRZINTpffxllXZueGpRMQ : IDisposable
{
	private readonly byte[] BnTkMddEMRIYxgTpcAWVDYoOLbph;

	public readonly int SlBxfwphnVHsjNDErEqTEkWknTm;

	private GCHandle YWmAVJbZBqgWDutqPRyfuhoYjwFw;

	private bool nNxUslIcGUpqKgpPZYhuimcvWyC;

	public bool IsPinned
	{
		get
		{
			return YWmAVJbZBqgWDutqPRyfuhoYjwFw.IsAllocated;
		}
	}

	public byte this[int index]
	{
		get
		{
			return BnTkMddEMRIYxgTpcAWVDYoOLbph[index];
		}
		set
		{
			BnTkMddEMRIYxgTpcAWVDYoOLbph[index] = value;
		}
	}

	public xvZAvdFfRZINTpffxllXZueGpRMQ(int size)
	{
		if (size < 0)
		{
			throw new ArgumentOutOfRangeException("size must be > 0");
		}
		SlBxfwphnVHsjNDErEqTEkWknTm = size;
		BnTkMddEMRIYxgTpcAWVDYoOLbph = new byte[size];
	}

	public IntPtr AcyswfNGudArvCjSPDOVhYuLVvR()
	{
		if (YWmAVJbZBqgWDutqPRyfuhoYjwFw.IsAllocated)
		{
			return YWmAVJbZBqgWDutqPRyfuhoYjwFw.AddrOfPinnedObject();
		}
		YWmAVJbZBqgWDutqPRyfuhoYjwFw = GCHandle.Alloc(BnTkMddEMRIYxgTpcAWVDYoOLbph, GCHandleType.Pinned);
		return YWmAVJbZBqgWDutqPRyfuhoYjwFw.AddrOfPinnedObject();
	}

	public void dMjyFZAzrpJBoIPFBpiiGYaWKpi()
	{
		if (YWmAVJbZBqgWDutqPRyfuhoYjwFw.IsAllocated)
		{
			YWmAVJbZBqgWDutqPRyfuhoYjwFw.Free();
		}
	}

	public string GeJEdtHYBBuKoOHHeFNQionhboNM()
	{
		string text = "";
		for (int i = 0; i < SlBxfwphnVHsjNDErEqTEkWknTm; i++)
		{
			text = text + BnTkMddEMRIYxgTpcAWVDYoOLbph[i].ToString("x2") + " ";
		}
		return text;
	}

	public bool OzzanGOzVaCzvyIfaqNhIQGusRb(int P_0, byte P_1)
	{
		if (1 + P_0 > SlBxfwphnVHsjNDErEqTEkWknTm || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (BnTkMddEMRIYxgTpcAWVDYoOLbph[P_0] & (1 << (int)P_1)) != 0;
	}

	public byte ahLlsXrfrUcEXCMOyOIJTWrmrLBW(int P_0)
	{
		if (1 + P_0 > SlBxfwphnVHsjNDErEqTEkWknTm || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return BnTkMddEMRIYxgTpcAWVDYoOLbph[P_0];
	}

	public unsafe short brIyYpeHlIhKBPPTmqfkhwsNTzX(int P_0)
	{
		if (2 + P_0 > SlBxfwphnVHsjNDErEqTEkWknTm || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* bnTkMddEMRIYxgTpcAWVDYoOLbph = BnTkMddEMRIYxgTpcAWVDYoOLbph)
		{
			return *(short*)(bnTkMddEMRIYxgTpcAWVDYoOLbph + P_0);
		}
	}

	public unsafe ushort dryLaEtYJfUzzmNxgszXJatJacgB(int P_0)
	{
		if (2 + P_0 > SlBxfwphnVHsjNDErEqTEkWknTm || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* bnTkMddEMRIYxgTpcAWVDYoOLbph = BnTkMddEMRIYxgTpcAWVDYoOLbph)
		{
			return *(ushort*)(bnTkMddEMRIYxgTpcAWVDYoOLbph + P_0);
		}
	}

	public unsafe int qoaYCzLCrimOnaGJQHHgnvpFjsO(int P_0)
	{
		if (4 + P_0 > SlBxfwphnVHsjNDErEqTEkWknTm || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* bnTkMddEMRIYxgTpcAWVDYoOLbph = BnTkMddEMRIYxgTpcAWVDYoOLbph)
		{
			return *(int*)(bnTkMddEMRIYxgTpcAWVDYoOLbph + P_0);
		}
	}

	public unsafe uint SLEkbWnZuvHCSsDIBUOUzicDgpe(int P_0)
	{
		if (4 + P_0 > SlBxfwphnVHsjNDErEqTEkWknTm || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* bnTkMddEMRIYxgTpcAWVDYoOLbph = BnTkMddEMRIYxgTpcAWVDYoOLbph)
		{
			return *(uint*)(bnTkMddEMRIYxgTpcAWVDYoOLbph + P_0);
		}
	}

	public unsafe long PtXtEoCRvMIegHtqVFomnyUczBy(int P_0)
	{
		if (8 + P_0 > SlBxfwphnVHsjNDErEqTEkWknTm || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* bnTkMddEMRIYxgTpcAWVDYoOLbph = BnTkMddEMRIYxgTpcAWVDYoOLbph)
		{
			return *(long*)(bnTkMddEMRIYxgTpcAWVDYoOLbph + P_0);
		}
	}

	public unsafe ulong JbQoAZevdUbILdVvHktOuVkKts(int P_0)
	{
		if (8 + P_0 > SlBxfwphnVHsjNDErEqTEkWknTm || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* bnTkMddEMRIYxgTpcAWVDYoOLbph = BnTkMddEMRIYxgTpcAWVDYoOLbph)
		{
			return *(ulong*)(bnTkMddEMRIYxgTpcAWVDYoOLbph + P_0);
		}
	}

	public void BzRDvjvAQHKNUfdBiARKBsCcKkSL(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > SlBxfwphnVHsjNDErEqTEkWknTm)
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
		if (P_2 >= SlBxfwphnVHsjNDErEqTEkWknTm)
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
		if (P_1 + P_2 > SlBxfwphnVHsjNDErEqTEkWknTm)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		Array.Copy(BnTkMddEMRIYxgTpcAWVDYoOLbph, P_2, P_0, P_3, P_1);
	}

	public void BzRDvjvAQHKNUfdBiARKBsCcKkSL(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero)
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
		if (P_2 > SlBxfwphnVHsjNDErEqTEkWknTm)
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
		if (P_3 >= SlBxfwphnVHsjNDErEqTEkWknTm)
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
		if (P_2 + P_3 > SlBxfwphnVHsjNDErEqTEkWknTm)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(BnTkMddEMRIYxgTpcAWVDYoOLbph, P_0, P_3, P_4, P_2);
	}

	public int KOXpOMjFyJDqRjvdDHjWBnAkNgXn(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_2 >= SlBxfwphnVHsjNDErEqTEkWknTm)
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
		if (P_2 + P_1 > SlBxfwphnVHsjNDErEqTEkWknTm)
		{
			P_1 = SlBxfwphnVHsjNDErEqTEkWknTm - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		Array.Copy(BnTkMddEMRIYxgTpcAWVDYoOLbph, P_2, P_0, P_3, P_1);
		return P_1;
	}

	public int KOXpOMjFyJDqRjvdDHjWBnAkNgXn(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= SlBxfwphnVHsjNDErEqTEkWknTm)
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
		if (P_3 + P_2 > SlBxfwphnVHsjNDErEqTEkWknTm)
		{
			P_2 = SlBxfwphnVHsjNDErEqTEkWknTm - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		NativeTools.CopyMemory(BnTkMddEMRIYxgTpcAWVDYoOLbph, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public void qphZcGYPkTxUyiRixeofeTKROcx(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > SlBxfwphnVHsjNDErEqTEkWknTm || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			BnTkMddEMRIYxgTpcAWVDYoOLbph[P_0] |= (byte)(1 << (int)P_1);
		}
		else
		{
			BnTkMddEMRIYxgTpcAWVDYoOLbph[P_0] &= (byte)(~(1 << (int)P_1));
		}
	}

	public void uwRrXbrytlKXYWIOmlUkwmZqEzx(byte P_0, int P_1)
	{
		if (1 + P_1 > SlBxfwphnVHsjNDErEqTEkWknTm || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		BnTkMddEMRIYxgTpcAWVDYoOLbph[P_1] = P_0;
	}

	public unsafe void uwRrXbrytlKXYWIOmlUkwmZqEzx(short P_0, int P_1)
	{
		if (2 + P_1 > SlBxfwphnVHsjNDErEqTEkWknTm || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* bnTkMddEMRIYxgTpcAWVDYoOLbph = BnTkMddEMRIYxgTpcAWVDYoOLbph)
		{
			*(short*)(bnTkMddEMRIYxgTpcAWVDYoOLbph + P_1) = P_0;
		}
	}

	public unsafe void uwRrXbrytlKXYWIOmlUkwmZqEzx(ushort P_0, int P_1)
	{
		if (2 + P_1 > SlBxfwphnVHsjNDErEqTEkWknTm || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* bnTkMddEMRIYxgTpcAWVDYoOLbph = BnTkMddEMRIYxgTpcAWVDYoOLbph)
		{
			*(ushort*)(bnTkMddEMRIYxgTpcAWVDYoOLbph + P_1) = P_0;
		}
	}

	public unsafe void uwRrXbrytlKXYWIOmlUkwmZqEzx(int P_0, int P_1)
	{
		if (4 + P_1 > SlBxfwphnVHsjNDErEqTEkWknTm || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* bnTkMddEMRIYxgTpcAWVDYoOLbph = BnTkMddEMRIYxgTpcAWVDYoOLbph)
		{
			*(int*)(bnTkMddEMRIYxgTpcAWVDYoOLbph + P_1) = P_0;
		}
	}

	public unsafe void uwRrXbrytlKXYWIOmlUkwmZqEzx(uint P_0, int P_1)
	{
		if (4 + P_1 > SlBxfwphnVHsjNDErEqTEkWknTm || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* bnTkMddEMRIYxgTpcAWVDYoOLbph = BnTkMddEMRIYxgTpcAWVDYoOLbph)
		{
			*(uint*)(bnTkMddEMRIYxgTpcAWVDYoOLbph + P_1) = P_0;
		}
	}

	public unsafe void uwRrXbrytlKXYWIOmlUkwmZqEzx(long P_0, int P_1)
	{
		if (8 + P_1 > SlBxfwphnVHsjNDErEqTEkWknTm || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* bnTkMddEMRIYxgTpcAWVDYoOLbph = BnTkMddEMRIYxgTpcAWVDYoOLbph)
		{
			*(long*)(bnTkMddEMRIYxgTpcAWVDYoOLbph + P_1) = P_0;
		}
	}

	public unsafe void uwRrXbrytlKXYWIOmlUkwmZqEzx(ulong P_0, int P_1)
	{
		if (8 + P_1 > SlBxfwphnVHsjNDErEqTEkWknTm || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* bnTkMddEMRIYxgTpcAWVDYoOLbph = BnTkMddEMRIYxgTpcAWVDYoOLbph)
		{
			*(ulong*)(bnTkMddEMRIYxgTpcAWVDYoOLbph + P_1) = P_0;
		}
	}

	public void uwRrXbrytlKXYWIOmlUkwmZqEzx(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > SlBxfwphnVHsjNDErEqTEkWknTm)
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
		if (P_2 >= SlBxfwphnVHsjNDErEqTEkWknTm)
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
		if (P_1 + P_2 > SlBxfwphnVHsjNDErEqTEkWknTm)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		Array.Copy(P_0, P_3, BnTkMddEMRIYxgTpcAWVDYoOLbph, P_2, P_1);
	}

	public void uwRrXbrytlKXYWIOmlUkwmZqEzx(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero)
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
		if (P_2 > SlBxfwphnVHsjNDErEqTEkWknTm)
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
		if (P_3 >= SlBxfwphnVHsjNDErEqTEkWknTm)
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
		if (P_2 + P_3 > SlBxfwphnVHsjNDErEqTEkWknTm)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, BnTkMddEMRIYxgTpcAWVDYoOLbph, P_4, P_3, P_2);
	}

	public int wZGHqvpqurPSaSLhSFRcXnpjBkE(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= SlBxfwphnVHsjNDErEqTEkWknTm)
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
		if (P_1 + P_2 > SlBxfwphnVHsjNDErEqTEkWknTm)
		{
			P_1 = SlBxfwphnVHsjNDErEqTEkWknTm - P_2;
		}
		Array.Copy(P_0, P_3, BnTkMddEMRIYxgTpcAWVDYoOLbph, P_2, P_1);
		return P_1;
	}

	public int wZGHqvpqurPSaSLhSFRcXnpjBkE(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= SlBxfwphnVHsjNDErEqTEkWknTm)
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
		if (P_2 + P_3 > SlBxfwphnVHsjNDErEqTEkWknTm)
		{
			P_2 = SlBxfwphnVHsjNDErEqTEkWknTm - P_3;
		}
		NativeTools.CopyMemory(P_0, BnTkMddEMRIYxgTpcAWVDYoOLbph, P_4, P_3, P_2);
		return P_2;
	}

	public void bVJfbjSJHtCUhxVYYaQYFCJuPMDE()
	{
		Array.Clear(BnTkMddEMRIYxgTpcAWVDYoOLbph, 0, SlBxfwphnVHsjNDErEqTEkWknTm);
	}

	public override string ToString()
	{
		string text = "";
		for (int i = 0; i < SlBxfwphnVHsjNDErEqTEkWknTm; i++)
		{
			text = text + this[i].ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		HtJdxRxaGggkmaMTSWUpHqjZLDV(true);
		GC.SuppressFinalize(this);
	}

	~xvZAvdFfRZINTpffxllXZueGpRMQ()
	{
		HtJdxRxaGggkmaMTSWUpHqjZLDV(false);
	}

	protected virtual void HtJdxRxaGggkmaMTSWUpHqjZLDV(bool P_0)
	{
		if (!nNxUslIcGUpqKgpPZYhuimcvWyC)
		{
			if (YWmAVJbZBqgWDutqPRyfuhoYjwFw.IsAllocated)
			{
				YWmAVJbZBqgWDutqPRyfuhoYjwFw.Free();
			}
			nNxUslIcGUpqKgpPZYhuimcvWyC = true;
		}
	}

	public static void aMHEFIYjSoHPvxJgFESoklFxHoJM(xvZAvdFfRZINTpffxllXZueGpRMQ P_0, xvZAvdFfRZINTpffxllXZueGpRMQ P_1, int P_2)
	{
		Array.Copy(P_0.BnTkMddEMRIYxgTpcAWVDYoOLbph, P_1.BnTkMddEMRIYxgTpcAWVDYoOLbph, P_2);
	}

	public static void aMHEFIYjSoHPvxJgFESoklFxHoJM(xvZAvdFfRZINTpffxllXZueGpRMQ P_0, int P_1, xvZAvdFfRZINTpffxllXZueGpRMQ P_2, int P_3, int P_4)
	{
		Array.Copy(P_0.BnTkMddEMRIYxgTpcAWVDYoOLbph, P_1, P_2.BnTkMddEMRIYxgTpcAWVDYoOLbph, P_3, P_4);
	}
}
