using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal class DZveWHiGfLkCsfAJtrJWuWvQQKPo : IDisposable
{
	private readonly byte[] peTGNGdwHteRzEUbEQusFLIfmRlnB;

	public readonly int rwBznQCtrMdjoTppyVqwxgKUqrqG;

	private GCHandle nedYyerrPuUgEoaMyTaTKXrClsyI;

	private bool kAnUqtzbEMoJVKIHqEZPVsYwCtsd;

	public bool cpIMMkcASBAumeUkWmSMYkEXOJEoA => nedYyerrPuUgEoaMyTaTKXrClsyI.IsAllocated;

	public byte faErlaEAmuirmpePedSOGEtGNNJG
	{
		get
		{
			return peTGNGdwHteRzEUbEQusFLIfmRlnB[P_0];
		}
		set
		{
			peTGNGdwHteRzEUbEQusFLIfmRlnB[num] = b;
		}
	}

	public DZveWHiGfLkCsfAJtrJWuWvQQKPo(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("size must be > 0");
		}
		rwBznQCtrMdjoTppyVqwxgKUqrqG = P_0;
		peTGNGdwHteRzEUbEQusFLIfmRlnB = new byte[P_0];
	}

	public IntPtr nkbXnCutqfdcQFkWvYDWwvPpMFgB()
	{
		if (nedYyerrPuUgEoaMyTaTKXrClsyI.IsAllocated)
		{
			return nedYyerrPuUgEoaMyTaTKXrClsyI.AddrOfPinnedObject();
		}
		nedYyerrPuUgEoaMyTaTKXrClsyI = GCHandle.Alloc(peTGNGdwHteRzEUbEQusFLIfmRlnB, GCHandleType.Pinned);
		return nedYyerrPuUgEoaMyTaTKXrClsyI.AddrOfPinnedObject();
	}

	public void HTOAZxiEFdtISVVOMOXZhnMqypWEA()
	{
		if (nedYyerrPuUgEoaMyTaTKXrClsyI.IsAllocated)
		{
			nedYyerrPuUgEoaMyTaTKXrClsyI.Free();
		}
	}

	public string ejlaWWeXsUqrahzzWJzBqbUnDdXz()
	{
		string text = "";
		for (int i = 0; i < rwBznQCtrMdjoTppyVqwxgKUqrqG; i++)
		{
			text = text + peTGNGdwHteRzEUbEQusFLIfmRlnB[i].ToString("x2") + " ";
		}
		return text;
	}

	public bool aiCxghmmhtdoKcdvRUHTjHOavpY(int P_0, byte P_1)
	{
		if (1 + P_0 > rwBznQCtrMdjoTppyVqwxgKUqrqG || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (peTGNGdwHteRzEUbEQusFLIfmRlnB[P_0] & (1 << (int)P_1)) != 0;
	}

	public byte zpKTKYxIjBteqjPfmdLeiakgSdoL(int P_0)
	{
		if (1 + P_0 > rwBznQCtrMdjoTppyVqwxgKUqrqG || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return peTGNGdwHteRzEUbEQusFLIfmRlnB[P_0];
	}

	public unsafe short rHClFVJdINQNrrNPUMRCTBCiMgeT(int P_0)
	{
		if (2 + P_0 > rwBznQCtrMdjoTppyVqwxgKUqrqG || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = peTGNGdwHteRzEUbEQusFLIfmRlnB)
		{
			return *(short*)(ptr + P_0);
		}
	}

	public unsafe ushort GbzDWrZctqHtTggkuAxzMebmFctw(int P_0)
	{
		if (2 + P_0 > rwBznQCtrMdjoTppyVqwxgKUqrqG || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = peTGNGdwHteRzEUbEQusFLIfmRlnB)
		{
			return *(ushort*)(ptr + P_0);
		}
	}

	public unsafe int pVSAPUKmgAmscdMlGoYOvvDZBVxtA(int P_0)
	{
		if (4 + P_0 > rwBznQCtrMdjoTppyVqwxgKUqrqG || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = peTGNGdwHteRzEUbEQusFLIfmRlnB)
		{
			return *(int*)(ptr + P_0);
		}
	}

	public unsafe uint bttuHLfhNhyFDqTGuKpqkJRJGgmr(int P_0)
	{
		if (4 + P_0 > rwBznQCtrMdjoTppyVqwxgKUqrqG || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = peTGNGdwHteRzEUbEQusFLIfmRlnB)
		{
			return *(uint*)(ptr + P_0);
		}
	}

	public unsafe long nUugzhovgyqCyWIYYkwnBzpICUZD(int P_0)
	{
		if (8 + P_0 > rwBznQCtrMdjoTppyVqwxgKUqrqG || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = peTGNGdwHteRzEUbEQusFLIfmRlnB)
		{
			return *(long*)(ptr + P_0);
		}
	}

	public unsafe ulong wpNrvkosbcfvLVbxanMakkLgkODw(int P_0)
	{
		if (8 + P_0 > rwBznQCtrMdjoTppyVqwxgKUqrqG || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = peTGNGdwHteRzEUbEQusFLIfmRlnB)
		{
			return *(ulong*)(ptr + P_0);
		}
	}

	public void bTMcIMDpWrMuNQSehhHvqiQxobNDA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > rwBznQCtrMdjoTppyVqwxgKUqrqG)
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
		if (P_2 >= rwBznQCtrMdjoTppyVqwxgKUqrqG)
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
		if (P_1 + P_2 > rwBznQCtrMdjoTppyVqwxgKUqrqG)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		Array.Copy(peTGNGdwHteRzEUbEQusFLIfmRlnB, P_2, P_0, P_3, P_1);
	}

	public void MBkiUgfxgdRmFvpSIMbWmXUQrgDs(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > rwBznQCtrMdjoTppyVqwxgKUqrqG)
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
		if (P_3 >= rwBznQCtrMdjoTppyVqwxgKUqrqG)
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
		if (P_2 + P_3 > rwBznQCtrMdjoTppyVqwxgKUqrqG)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(peTGNGdwHteRzEUbEQusFLIfmRlnB, P_0, P_3, P_4, P_2);
	}

	public int KrwgYeoCJDINiPZylOwImFErUtr(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_2 >= rwBznQCtrMdjoTppyVqwxgKUqrqG)
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
		if (P_2 + P_1 > rwBznQCtrMdjoTppyVqwxgKUqrqG)
		{
			P_1 = rwBznQCtrMdjoTppyVqwxgKUqrqG - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		Array.Copy(peTGNGdwHteRzEUbEQusFLIfmRlnB, P_2, P_0, P_3, P_1);
		return P_1;
	}

	public int xxkBOOWAHybZHHTLJrauisUdFXBH(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= rwBznQCtrMdjoTppyVqwxgKUqrqG)
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
		if (P_3 + P_2 > rwBznQCtrMdjoTppyVqwxgKUqrqG)
		{
			P_2 = rwBznQCtrMdjoTppyVqwxgKUqrqG - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		NativeTools.CopyMemory(peTGNGdwHteRzEUbEQusFLIfmRlnB, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public void IfhyFEEgANbyCxXjQcUqsaCPRcIP(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > rwBznQCtrMdjoTppyVqwxgKUqrqG || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			peTGNGdwHteRzEUbEQusFLIfmRlnB[P_0] |= (byte)(1 << (int)P_1);
		}
		else
		{
			peTGNGdwHteRzEUbEQusFLIfmRlnB[P_0] &= (byte)(~(1 << (int)P_1));
		}
	}

	public void ixscwyjTSkszaFtOQbkYurOhpybN(byte P_0, int P_1)
	{
		if (1 + P_1 > rwBznQCtrMdjoTppyVqwxgKUqrqG || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		peTGNGdwHteRzEUbEQusFLIfmRlnB[P_1] = P_0;
	}

	public unsafe void tPwHWObffqhPrMmLlQxepxbXfTyk(short P_0, int P_1)
	{
		if (2 + P_1 > rwBznQCtrMdjoTppyVqwxgKUqrqG || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = peTGNGdwHteRzEUbEQusFLIfmRlnB)
		{
			*(short*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void bVabaIBCSeHwVMtFbpHKKlHgyMLG(ushort P_0, int P_1)
	{
		if (2 + P_1 > rwBznQCtrMdjoTppyVqwxgKUqrqG || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = peTGNGdwHteRzEUbEQusFLIfmRlnB)
		{
			*(ushort*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void JfmSZafAvvrNQqZwkXgtLDpviJPL(int P_0, int P_1)
	{
		if (4 + P_1 > rwBznQCtrMdjoTppyVqwxgKUqrqG || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = peTGNGdwHteRzEUbEQusFLIfmRlnB)
		{
			*(int*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void QVZFLeXzmXmNODShTUgQdgVooKwP(uint P_0, int P_1)
	{
		if (4 + P_1 > rwBznQCtrMdjoTppyVqwxgKUqrqG || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = peTGNGdwHteRzEUbEQusFLIfmRlnB)
		{
			*(uint*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void sDJIzPPoHGdsKqfYNXBaswQFKqik(long P_0, int P_1)
	{
		if (8 + P_1 > rwBznQCtrMdjoTppyVqwxgKUqrqG || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = peTGNGdwHteRzEUbEQusFLIfmRlnB)
		{
			*(long*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void LpjtCpXhkzcmtkTJxuAeltzbGYge(ulong P_0, int P_1)
	{
		if (8 + P_1 > rwBznQCtrMdjoTppyVqwxgKUqrqG || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = peTGNGdwHteRzEUbEQusFLIfmRlnB)
		{
			*(ulong*)(ptr + P_1) = P_0;
		}
	}

	public void KGhlIIJrEVnSKiHqtsIfqhmIHiPw(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > rwBznQCtrMdjoTppyVqwxgKUqrqG)
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
		if (P_2 >= rwBznQCtrMdjoTppyVqwxgKUqrqG)
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
		if (P_1 + P_2 > rwBznQCtrMdjoTppyVqwxgKUqrqG)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		Array.Copy(P_0, P_3, peTGNGdwHteRzEUbEQusFLIfmRlnB, P_2, P_1);
	}

	public void UJWGFpjALCgnUouoibwxtQdSnkUOA(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > rwBznQCtrMdjoTppyVqwxgKUqrqG)
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
		if (P_3 >= rwBznQCtrMdjoTppyVqwxgKUqrqG)
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
		if (P_2 + P_3 > rwBznQCtrMdjoTppyVqwxgKUqrqG)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, peTGNGdwHteRzEUbEQusFLIfmRlnB, P_4, P_3, P_2);
	}

	public int alwEFnSeGodrmiBaReJoQVytQGRRA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= rwBznQCtrMdjoTppyVqwxgKUqrqG)
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
		if (P_1 + P_2 > rwBznQCtrMdjoTppyVqwxgKUqrqG)
		{
			P_1 = rwBznQCtrMdjoTppyVqwxgKUqrqG - P_2;
		}
		Array.Copy(P_0, P_3, peTGNGdwHteRzEUbEQusFLIfmRlnB, P_2, P_1);
		return P_1;
	}

	public int WlNNkdwbFFARCjZCLnIiWOEjMeTRA(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= rwBznQCtrMdjoTppyVqwxgKUqrqG)
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
		if (P_2 + P_3 > rwBznQCtrMdjoTppyVqwxgKUqrqG)
		{
			P_2 = rwBznQCtrMdjoTppyVqwxgKUqrqG - P_3;
		}
		NativeTools.CopyMemory(P_0, peTGNGdwHteRzEUbEQusFLIfmRlnB, P_4, P_3, P_2);
		return P_2;
	}

	public void DTIRmblMYxHWbfZRUqfccrgxCDOL()
	{
		Array.Clear(peTGNGdwHteRzEUbEQusFLIfmRlnB, 0, rwBznQCtrMdjoTppyVqwxgKUqrqG);
	}

	public virtual string qETLfqthbBvSwALwwhGYdHYqElKEA()
	{
		string text = "";
		for (int i = 0; i < rwBznQCtrMdjoTppyVqwxgKUqrqG; i++)
		{
			text = text + this.IIahrfFuUUDdBEKOfmmbBMAQgDFQA(i).ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		PUJtShsKUUQMQwigFhFFPcgvIVFI(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void voxLyMvaAgVMwHzhVlCLTruNwvue()
	{
		try
		{
			PUJtShsKUUQMQwigFhFFPcgvIVFI(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void PUJtShsKUUQMQwigFhFFPcgvIVFI(bool P_0)
	{
		if (!kAnUqtzbEMoJVKIHqEZPVsYwCtsd)
		{
			if (nedYyerrPuUgEoaMyTaTKXrClsyI.IsAllocated)
			{
				nedYyerrPuUgEoaMyTaTKXrClsyI.Free();
			}
			kAnUqtzbEMoJVKIHqEZPVsYwCtsd = true;
		}
	}

	public static void lbuxqTKTPdUiERLBNuFBxdiXcBrJA(DZveWHiGfLkCsfAJtrJWuWvQQKPo P_0, DZveWHiGfLkCsfAJtrJWuWvQQKPo P_1, int P_2)
	{
		Array.Copy(P_0.peTGNGdwHteRzEUbEQusFLIfmRlnB, P_1.peTGNGdwHteRzEUbEQusFLIfmRlnB, P_2);
	}

	public static void XDAaMWHBNBYwWPXkWooIklbQdxJj(DZveWHiGfLkCsfAJtrJWuWvQQKPo P_0, int P_1, DZveWHiGfLkCsfAJtrJWuWvQQKPo P_2, int P_3, int P_4)
	{
		Array.Copy(P_0.peTGNGdwHteRzEUbEQusFLIfmRlnB, P_1, P_2.peTGNGdwHteRzEUbEQusFLIfmRlnB, P_3, P_4);
	}
}
