using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal class rHwkAaoOGEKwKhHAimeNtnfUrGQR : IDisposable
{
	private readonly byte[] JgYnehdedkfeJKAiXVdjSoIuNXsh;

	public readonly int TrSpFvIvMXeBQJtclHercjQMIipp;

	private GCHandle JAiVkVbEYzDeyJoLnJwCsZnWxbjQA;

	private bool AIgFyNAtEJhUvtMTtrvICxmuxUzN;

	public bool AuLkHNmObQAkOUutFroJbcAPJgJj => JAiVkVbEYzDeyJoLnJwCsZnWxbjQA.IsAllocated;

	public byte PlDyZJUcFxYEQvuCfHAHBmrKTBQW
	{
		get
		{
			return JgYnehdedkfeJKAiXVdjSoIuNXsh[P_0];
		}
		set
		{
			JgYnehdedkfeJKAiXVdjSoIuNXsh[num] = b;
		}
	}

	public rHwkAaoOGEKwKhHAimeNtnfUrGQR(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("size must be > 0");
		}
		TrSpFvIvMXeBQJtclHercjQMIipp = P_0;
		JgYnehdedkfeJKAiXVdjSoIuNXsh = new byte[P_0];
	}

	public IntPtr HnmdrEgyMgwHIKRraWrWPfzzDQYpA()
	{
		if (JAiVkVbEYzDeyJoLnJwCsZnWxbjQA.IsAllocated)
		{
			return JAiVkVbEYzDeyJoLnJwCsZnWxbjQA.AddrOfPinnedObject();
		}
		JAiVkVbEYzDeyJoLnJwCsZnWxbjQA = GCHandle.Alloc(JgYnehdedkfeJKAiXVdjSoIuNXsh, GCHandleType.Pinned);
		return JAiVkVbEYzDeyJoLnJwCsZnWxbjQA.AddrOfPinnedObject();
	}

	public void jPDlSSKccsgmUDZFhgQoUGcelVjA()
	{
		if (JAiVkVbEYzDeyJoLnJwCsZnWxbjQA.IsAllocated)
		{
			JAiVkVbEYzDeyJoLnJwCsZnWxbjQA.Free();
		}
	}

	public string WmoictiwVHQXQvrgHrIIvmCbcbQS()
	{
		string text = "";
		for (int i = 0; i < TrSpFvIvMXeBQJtclHercjQMIipp; i++)
		{
			text = text + JgYnehdedkfeJKAiXVdjSoIuNXsh[i].ToString("x2") + " ";
		}
		return text;
	}

	public bool QizBNXJzJqDTCNIamgvYYMTEohsBb(int P_0, byte P_1)
	{
		if (1 + P_0 > TrSpFvIvMXeBQJtclHercjQMIipp || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (JgYnehdedkfeJKAiXVdjSoIuNXsh[P_0] & (1 << (int)P_1)) != 0;
	}

	public byte HzRNdlxrGAPVErvkbeIjdRmkbUlW(int P_0)
	{
		if (1 + P_0 > TrSpFvIvMXeBQJtclHercjQMIipp || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return JgYnehdedkfeJKAiXVdjSoIuNXsh[P_0];
	}

	public unsafe short THXnwyLblMpkPxLALsdJEbMcJktm(int P_0)
	{
		if (2 + P_0 > TrSpFvIvMXeBQJtclHercjQMIipp || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* jgYnehdedkfeJKAiXVdjSoIuNXsh = JgYnehdedkfeJKAiXVdjSoIuNXsh)
		{
			return *(short*)(jgYnehdedkfeJKAiXVdjSoIuNXsh + P_0);
		}
	}

	public unsafe ushort yzwfzMNBQxbRnybtbftwTYrsDmuV(int P_0)
	{
		if (2 + P_0 > TrSpFvIvMXeBQJtclHercjQMIipp || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* jgYnehdedkfeJKAiXVdjSoIuNXsh = JgYnehdedkfeJKAiXVdjSoIuNXsh)
		{
			return *(ushort*)(jgYnehdedkfeJKAiXVdjSoIuNXsh + P_0);
		}
	}

	public unsafe int VXOxfekXPHUSXUeHWrBUkLVmFeTA(int P_0)
	{
		if (4 + P_0 > TrSpFvIvMXeBQJtclHercjQMIipp || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* jgYnehdedkfeJKAiXVdjSoIuNXsh = JgYnehdedkfeJKAiXVdjSoIuNXsh)
		{
			return *(int*)(jgYnehdedkfeJKAiXVdjSoIuNXsh + P_0);
		}
	}

	public unsafe uint FRujruleOsdyxsXufIKjzBOFucnh(int P_0)
	{
		if (4 + P_0 > TrSpFvIvMXeBQJtclHercjQMIipp || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* jgYnehdedkfeJKAiXVdjSoIuNXsh = JgYnehdedkfeJKAiXVdjSoIuNXsh)
		{
			return *(uint*)(jgYnehdedkfeJKAiXVdjSoIuNXsh + P_0);
		}
	}

	public unsafe long RerSQIakBzpQAOnLBqNeOzjQSWUK(int P_0)
	{
		if (8 + P_0 > TrSpFvIvMXeBQJtclHercjQMIipp || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* jgYnehdedkfeJKAiXVdjSoIuNXsh = JgYnehdedkfeJKAiXVdjSoIuNXsh)
		{
			return *(long*)(jgYnehdedkfeJKAiXVdjSoIuNXsh + P_0);
		}
	}

	public unsafe ulong GPOBCTwVEfDShVLifxDnlgDgIXUJ(int P_0)
	{
		if (8 + P_0 > TrSpFvIvMXeBQJtclHercjQMIipp || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* jgYnehdedkfeJKAiXVdjSoIuNXsh = JgYnehdedkfeJKAiXVdjSoIuNXsh)
		{
			return *(ulong*)(jgYnehdedkfeJKAiXVdjSoIuNXsh + P_0);
		}
	}

	public void VvFalHfbrqGdRCbrouuknEwbxEVb(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > TrSpFvIvMXeBQJtclHercjQMIipp)
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
		if (P_2 >= TrSpFvIvMXeBQJtclHercjQMIipp)
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
		if (P_1 + P_2 > TrSpFvIvMXeBQJtclHercjQMIipp)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		Array.Copy(JgYnehdedkfeJKAiXVdjSoIuNXsh, P_2, P_0, P_3, P_1);
	}

	public void cYrmnXteLgFEjtgHNgUTBlUQXgAMA(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > TrSpFvIvMXeBQJtclHercjQMIipp)
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
		if (P_3 >= TrSpFvIvMXeBQJtclHercjQMIipp)
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
		if (P_2 + P_3 > TrSpFvIvMXeBQJtclHercjQMIipp)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(JgYnehdedkfeJKAiXVdjSoIuNXsh, P_0, P_3, P_4, P_2);
	}

	public int qHwBEtfuvYMobwVEzEjnCFPWbMkxA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_2 >= TrSpFvIvMXeBQJtclHercjQMIipp)
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
		if (P_2 + P_1 > TrSpFvIvMXeBQJtclHercjQMIipp)
		{
			P_1 = TrSpFvIvMXeBQJtclHercjQMIipp - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		Array.Copy(JgYnehdedkfeJKAiXVdjSoIuNXsh, P_2, P_0, P_3, P_1);
		return P_1;
	}

	public int TYrzbvEParuPrBXQGGIdjmQhaRMO(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= TrSpFvIvMXeBQJtclHercjQMIipp)
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
		if (P_3 + P_2 > TrSpFvIvMXeBQJtclHercjQMIipp)
		{
			P_2 = TrSpFvIvMXeBQJtclHercjQMIipp - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		NativeTools.CopyMemory(JgYnehdedkfeJKAiXVdjSoIuNXsh, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public void yEeRSpYXxEmWkvQqBHdbtcQPcqNCA(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > TrSpFvIvMXeBQJtclHercjQMIipp || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			JgYnehdedkfeJKAiXVdjSoIuNXsh[P_0] |= (byte)(1 << (int)P_1);
		}
		else
		{
			JgYnehdedkfeJKAiXVdjSoIuNXsh[P_0] &= (byte)(~(1 << (int)P_1));
		}
	}

	public void SavMCPlCtjDZIBTLVBBNanWadcyLB(byte P_0, int P_1)
	{
		if (1 + P_1 > TrSpFvIvMXeBQJtclHercjQMIipp || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		JgYnehdedkfeJKAiXVdjSoIuNXsh[P_1] = P_0;
	}

	public unsafe void HytHlxljCjizHIFSwvAbwffZinpCA(short P_0, int P_1)
	{
		if (2 + P_1 > TrSpFvIvMXeBQJtclHercjQMIipp || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* jgYnehdedkfeJKAiXVdjSoIuNXsh = JgYnehdedkfeJKAiXVdjSoIuNXsh)
		{
			*(short*)(jgYnehdedkfeJKAiXVdjSoIuNXsh + P_1) = P_0;
		}
	}

	public unsafe void PWvUJfLBnxSrdUJOyGKXAVZcPuYvA(ushort P_0, int P_1)
	{
		if (2 + P_1 > TrSpFvIvMXeBQJtclHercjQMIipp || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* jgYnehdedkfeJKAiXVdjSoIuNXsh = JgYnehdedkfeJKAiXVdjSoIuNXsh)
		{
			*(ushort*)(jgYnehdedkfeJKAiXVdjSoIuNXsh + P_1) = P_0;
		}
	}

	public unsafe void vJtluJvcMyxJmcMEljekeOrzEeMab(int P_0, int P_1)
	{
		if (4 + P_1 > TrSpFvIvMXeBQJtclHercjQMIipp || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* jgYnehdedkfeJKAiXVdjSoIuNXsh = JgYnehdedkfeJKAiXVdjSoIuNXsh)
		{
			*(int*)(jgYnehdedkfeJKAiXVdjSoIuNXsh + P_1) = P_0;
		}
	}

	public unsafe void cNUrNJBcNYAhwBJoUZPPmDJgDSxZ(uint P_0, int P_1)
	{
		if (4 + P_1 > TrSpFvIvMXeBQJtclHercjQMIipp || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* jgYnehdedkfeJKAiXVdjSoIuNXsh = JgYnehdedkfeJKAiXVdjSoIuNXsh)
		{
			*(uint*)(jgYnehdedkfeJKAiXVdjSoIuNXsh + P_1) = P_0;
		}
	}

	public unsafe void QDOqkkLOeZMVueIFMJorjSEDlKlV(long P_0, int P_1)
	{
		if (8 + P_1 > TrSpFvIvMXeBQJtclHercjQMIipp || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* jgYnehdedkfeJKAiXVdjSoIuNXsh = JgYnehdedkfeJKAiXVdjSoIuNXsh)
		{
			*(long*)(jgYnehdedkfeJKAiXVdjSoIuNXsh + P_1) = P_0;
		}
	}

	public unsafe void raezPSBiLoFWRkwMauVhmYdrWOdx(ulong P_0, int P_1)
	{
		if (8 + P_1 > TrSpFvIvMXeBQJtclHercjQMIipp || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* jgYnehdedkfeJKAiXVdjSoIuNXsh = JgYnehdedkfeJKAiXVdjSoIuNXsh)
		{
			*(ulong*)(jgYnehdedkfeJKAiXVdjSoIuNXsh + P_1) = P_0;
		}
	}

	public void sqqoNvDxbQaJieidyCLizvmKAkYFA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > TrSpFvIvMXeBQJtclHercjQMIipp)
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
		if (P_2 >= TrSpFvIvMXeBQJtclHercjQMIipp)
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
		if (P_1 + P_2 > TrSpFvIvMXeBQJtclHercjQMIipp)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		Array.Copy(P_0, P_3, JgYnehdedkfeJKAiXVdjSoIuNXsh, P_2, P_1);
	}

	public void ecLrhSKwRHVniqzGtVxcNxXYqSBD(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > TrSpFvIvMXeBQJtclHercjQMIipp)
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
		if (P_3 >= TrSpFvIvMXeBQJtclHercjQMIipp)
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
		if (P_2 + P_3 > TrSpFvIvMXeBQJtclHercjQMIipp)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, JgYnehdedkfeJKAiXVdjSoIuNXsh, P_4, P_3, P_2);
	}

	public int QCnvPQWGjrDZKVKzYLezUByljGMW(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= TrSpFvIvMXeBQJtclHercjQMIipp)
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
		if (P_1 + P_2 > TrSpFvIvMXeBQJtclHercjQMIipp)
		{
			P_1 = TrSpFvIvMXeBQJtclHercjQMIipp - P_2;
		}
		Array.Copy(P_0, P_3, JgYnehdedkfeJKAiXVdjSoIuNXsh, P_2, P_1);
		return P_1;
	}

	public int gLOMMEkNiOvxgPHZAhXjRONfuWQc(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= TrSpFvIvMXeBQJtclHercjQMIipp)
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
		if (P_2 + P_3 > TrSpFvIvMXeBQJtclHercjQMIipp)
		{
			P_2 = TrSpFvIvMXeBQJtclHercjQMIipp - P_3;
		}
		NativeTools.CopyMemory(P_0, JgYnehdedkfeJKAiXVdjSoIuNXsh, P_4, P_3, P_2);
		return P_2;
	}

	public void zJDWfKzDbmdtRzqWTHNxzPibBYNu()
	{
		Array.Clear(JgYnehdedkfeJKAiXVdjSoIuNXsh, 0, TrSpFvIvMXeBQJtclHercjQMIipp);
	}

	public virtual string WJIHwVtGCMqkQSGpvcrFiqAedjZx()
	{
		string text = "";
		for (int i = 0; i < TrSpFvIvMXeBQJtclHercjQMIipp; i++)
		{
			text = text + this.sAhHGQJpnZDfjCjNsLFoPIAUPVIL(i).ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		hgExNOaajRLyuilfApGGUAedbKYZ(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void PrqftHGxBrLbiWVmCAUIAMhIXifkb()
	{
		try
		{
			hgExNOaajRLyuilfApGGUAedbKYZ(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void hgExNOaajRLyuilfApGGUAedbKYZ(bool P_0)
	{
		if (!AIgFyNAtEJhUvtMTtrvICxmuxUzN)
		{
			if (JAiVkVbEYzDeyJoLnJwCsZnWxbjQA.IsAllocated)
			{
				JAiVkVbEYzDeyJoLnJwCsZnWxbjQA.Free();
			}
			AIgFyNAtEJhUvtMTtrvICxmuxUzN = true;
		}
	}

	public static void TPlQbyIGqwOxwJtOSyRYmByTBfeI(rHwkAaoOGEKwKhHAimeNtnfUrGQR P_0, rHwkAaoOGEKwKhHAimeNtnfUrGQR P_1, int P_2)
	{
		Array.Copy(P_0.JgYnehdedkfeJKAiXVdjSoIuNXsh, P_1.JgYnehdedkfeJKAiXVdjSoIuNXsh, P_2);
	}

	public static void dmXfCbRDmWlayDbzHkNJpezWYbWR(rHwkAaoOGEKwKhHAimeNtnfUrGQR P_0, int P_1, rHwkAaoOGEKwKhHAimeNtnfUrGQR P_2, int P_3, int P_4)
	{
		Array.Copy(P_0.JgYnehdedkfeJKAiXVdjSoIuNXsh, P_1, P_2.JgYnehdedkfeJKAiXVdjSoIuNXsh, P_3, P_4);
	}
}
