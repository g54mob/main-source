using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal class CPWLzYXKHJYVsYzNxyjZRVJpFxgi : IDisposable
{
	private readonly byte[] iLwGJVQlLzJmzfxFCPipkgmHMOMI;

	public readonly int qmcEcNniDGslaoXhqCujECuvMpZM;

	private GCHandle uuAhBpICDcxAGtFKudqMFzFfjwJEc;

	private bool dSOuDbIVXCmiHlfWazTOsjGRkHVQ;

	public bool paxBHfRJsBDmiDteYOtPeFiaaAjlc => uuAhBpICDcxAGtFKudqMFzFfjwJEc.IsAllocated;

	public byte ypbcerKpYcPywkIZuxWHrqVvvOku
	{
		get
		{
			return iLwGJVQlLzJmzfxFCPipkgmHMOMI[P_0];
		}
		set
		{
			iLwGJVQlLzJmzfxFCPipkgmHMOMI[num] = b;
		}
	}

	public CPWLzYXKHJYVsYzNxyjZRVJpFxgi(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("size must be > 0");
		}
		qmcEcNniDGslaoXhqCujECuvMpZM = P_0;
		iLwGJVQlLzJmzfxFCPipkgmHMOMI = new byte[P_0];
	}

	public IntPtr gBMBOwIDBrPbcfeakzfOFRHXYRqhB()
	{
		if (uuAhBpICDcxAGtFKudqMFzFfjwJEc.IsAllocated)
		{
			return uuAhBpICDcxAGtFKudqMFzFfjwJEc.AddrOfPinnedObject();
		}
		uuAhBpICDcxAGtFKudqMFzFfjwJEc = GCHandle.Alloc(iLwGJVQlLzJmzfxFCPipkgmHMOMI, GCHandleType.Pinned);
		return uuAhBpICDcxAGtFKudqMFzFfjwJEc.AddrOfPinnedObject();
	}

	public void CArQPwhpGfChWaUvUwVCAsODaYhC()
	{
		if (uuAhBpICDcxAGtFKudqMFzFfjwJEc.IsAllocated)
		{
			uuAhBpICDcxAGtFKudqMFzFfjwJEc.Free();
		}
	}

	public string hYCQVXHKWCPzsIurGOGIVqmCRaso()
	{
		string text = "";
		for (int i = 0; i < qmcEcNniDGslaoXhqCujECuvMpZM; i++)
		{
			text = text + iLwGJVQlLzJmzfxFCPipkgmHMOMI[i].ToString("x2") + " ";
		}
		return text;
	}

	public bool tzZvqnYbSfYvursffApGsxhxDaIq(int P_0, byte P_1)
	{
		if (1 + P_0 > qmcEcNniDGslaoXhqCujECuvMpZM || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (iLwGJVQlLzJmzfxFCPipkgmHMOMI[P_0] & (1 << (int)P_1)) != 0;
	}

	public byte yftEEHQGLTtxgEyveBGbFlSZRVXR(int P_0)
	{
		if (1 + P_0 > qmcEcNniDGslaoXhqCujECuvMpZM || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return iLwGJVQlLzJmzfxFCPipkgmHMOMI[P_0];
	}

	public unsafe short ctpAKGqNaREVvMqBWpoDqqwPYdTs(int P_0)
	{
		if (2 + P_0 > qmcEcNniDGslaoXhqCujECuvMpZM || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = iLwGJVQlLzJmzfxFCPipkgmHMOMI)
		{
			return *(short*)(ptr + P_0);
		}
	}

	public unsafe ushort VROQWoyMBsJJNXPccfxcfuRVdzGv(int P_0)
	{
		if (2 + P_0 > qmcEcNniDGslaoXhqCujECuvMpZM || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = iLwGJVQlLzJmzfxFCPipkgmHMOMI)
		{
			return *(ushort*)(ptr + P_0);
		}
	}

	public unsafe int wDnGqXBOKWkFmpFvUxdZAcdahCAY(int P_0)
	{
		if (4 + P_0 > qmcEcNniDGslaoXhqCujECuvMpZM || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = iLwGJVQlLzJmzfxFCPipkgmHMOMI)
		{
			return *(int*)(ptr + P_0);
		}
	}

	public unsafe uint wZACGfSbPnBRJPOmiYtkFvekjcLD(int P_0)
	{
		if (4 + P_0 > qmcEcNniDGslaoXhqCujECuvMpZM || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = iLwGJVQlLzJmzfxFCPipkgmHMOMI)
		{
			return *(uint*)(ptr + P_0);
		}
	}

	public unsafe long chVhpuFtEqtswzUUENDiwdXzTHww(int P_0)
	{
		if (8 + P_0 > qmcEcNniDGslaoXhqCujECuvMpZM || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = iLwGJVQlLzJmzfxFCPipkgmHMOMI)
		{
			return *(long*)(ptr + P_0);
		}
	}

	public unsafe ulong jYsskvJzNunjVySngzElXprZHbyK(int P_0)
	{
		if (8 + P_0 > qmcEcNniDGslaoXhqCujECuvMpZM || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = iLwGJVQlLzJmzfxFCPipkgmHMOMI)
		{
			return *(ulong*)(ptr + P_0);
		}
	}

	public void gcfTWLGypxeYLjynpwDgBmNGwVuD(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > qmcEcNniDGslaoXhqCujECuvMpZM)
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
		if (P_2 >= qmcEcNniDGslaoXhqCujECuvMpZM)
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
		if (P_1 + P_2 > qmcEcNniDGslaoXhqCujECuvMpZM)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		Array.Copy(iLwGJVQlLzJmzfxFCPipkgmHMOMI, P_2, P_0, P_3, P_1);
	}

	public void XpPVtvIQEncmRIUQWSANLuidzauL(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > qmcEcNniDGslaoXhqCujECuvMpZM)
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
		if (P_3 >= qmcEcNniDGslaoXhqCujECuvMpZM)
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
		if (P_2 + P_3 > qmcEcNniDGslaoXhqCujECuvMpZM)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(iLwGJVQlLzJmzfxFCPipkgmHMOMI, P_0, P_3, P_4, P_2);
	}

	public int TZAVjDPcgVRAJJnLkNpvbklbCZES(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_2 >= qmcEcNniDGslaoXhqCujECuvMpZM)
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
		if (P_2 + P_1 > qmcEcNniDGslaoXhqCujECuvMpZM)
		{
			P_1 = qmcEcNniDGslaoXhqCujECuvMpZM - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		Array.Copy(iLwGJVQlLzJmzfxFCPipkgmHMOMI, P_2, P_0, P_3, P_1);
		return P_1;
	}

	public int opTdQJdldsXjNnqFRICzRVyYDGmOA(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= qmcEcNniDGslaoXhqCujECuvMpZM)
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
		if (P_3 + P_2 > qmcEcNniDGslaoXhqCujECuvMpZM)
		{
			P_2 = qmcEcNniDGslaoXhqCujECuvMpZM - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		NativeTools.CopyMemory(iLwGJVQlLzJmzfxFCPipkgmHMOMI, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public void LSKDrTvIoDGeUeEbMipdfFuBejvIc(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > qmcEcNniDGslaoXhqCujECuvMpZM || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			iLwGJVQlLzJmzfxFCPipkgmHMOMI[P_0] |= (byte)(1 << (int)P_1);
		}
		else
		{
			iLwGJVQlLzJmzfxFCPipkgmHMOMI[P_0] &= (byte)(~(1 << (int)P_1));
		}
	}

	public void lKVovvORwqNrieVUGBrZXCaEfdKr(byte P_0, int P_1)
	{
		if (1 + P_1 > qmcEcNniDGslaoXhqCujECuvMpZM || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		iLwGJVQlLzJmzfxFCPipkgmHMOMI[P_1] = P_0;
	}

	public unsafe void sFVLSREKPsBXnrJDvvWhYWNcLcHQ(short P_0, int P_1)
	{
		if (2 + P_1 > qmcEcNniDGslaoXhqCujECuvMpZM || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = iLwGJVQlLzJmzfxFCPipkgmHMOMI)
		{
			*(short*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void uKRbeNfyioWLNTxJjyAZerrPIxwNA(ushort P_0, int P_1)
	{
		if (2 + P_1 > qmcEcNniDGslaoXhqCujECuvMpZM || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = iLwGJVQlLzJmzfxFCPipkgmHMOMI)
		{
			*(ushort*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void KURhTbWRXngfChHRoHeyMkTYQngLA(int P_0, int P_1)
	{
		if (4 + P_1 > qmcEcNniDGslaoXhqCujECuvMpZM || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = iLwGJVQlLzJmzfxFCPipkgmHMOMI)
		{
			*(int*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void DhsOuxaoYTFwGyNlVLHFGphZBWRh(uint P_0, int P_1)
	{
		if (4 + P_1 > qmcEcNniDGslaoXhqCujECuvMpZM || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = iLwGJVQlLzJmzfxFCPipkgmHMOMI)
		{
			*(uint*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void tTsEJMgZfMVxGDfULJylVZywuFLX(long P_0, int P_1)
	{
		if (8 + P_1 > qmcEcNniDGslaoXhqCujECuvMpZM || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = iLwGJVQlLzJmzfxFCPipkgmHMOMI)
		{
			*(long*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void ChIAekevYdAktEVDvJZjsWHAUTPqA(ulong P_0, int P_1)
	{
		if (8 + P_1 > qmcEcNniDGslaoXhqCujECuvMpZM || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = iLwGJVQlLzJmzfxFCPipkgmHMOMI)
		{
			*(ulong*)(ptr + P_1) = P_0;
		}
	}

	public void BvSkuXoaoPUhGXFsxCBifPGtOjgwA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > qmcEcNniDGslaoXhqCujECuvMpZM)
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
		if (P_2 >= qmcEcNniDGslaoXhqCujECuvMpZM)
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
		if (P_1 + P_2 > qmcEcNniDGslaoXhqCujECuvMpZM)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		Array.Copy(P_0, P_3, iLwGJVQlLzJmzfxFCPipkgmHMOMI, P_2, P_1);
	}

	public void DqjKMevbxQzvUPsouRcwhRYdlpmb(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > qmcEcNniDGslaoXhqCujECuvMpZM)
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
		if (P_3 >= qmcEcNniDGslaoXhqCujECuvMpZM)
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
		if (P_2 + P_3 > qmcEcNniDGslaoXhqCujECuvMpZM)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, iLwGJVQlLzJmzfxFCPipkgmHMOMI, P_4, P_3, P_2);
	}

	public int lYXULmvvcuhpcuSeJiJjoxSKLAeK(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= qmcEcNniDGslaoXhqCujECuvMpZM)
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
		if (P_1 + P_2 > qmcEcNniDGslaoXhqCujECuvMpZM)
		{
			P_1 = qmcEcNniDGslaoXhqCujECuvMpZM - P_2;
		}
		Array.Copy(P_0, P_3, iLwGJVQlLzJmzfxFCPipkgmHMOMI, P_2, P_1);
		return P_1;
	}

	public int JWadnmHKhVFJGJwUNPdjOlwSNdqeA(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= qmcEcNniDGslaoXhqCujECuvMpZM)
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
		if (P_2 + P_3 > qmcEcNniDGslaoXhqCujECuvMpZM)
		{
			P_2 = qmcEcNniDGslaoXhqCujECuvMpZM - P_3;
		}
		NativeTools.CopyMemory(P_0, iLwGJVQlLzJmzfxFCPipkgmHMOMI, P_4, P_3, P_2);
		return P_2;
	}

	public void AevnTeMEupGVfGATQMDpXkGOsNvu()
	{
		Array.Clear(iLwGJVQlLzJmzfxFCPipkgmHMOMI, 0, qmcEcNniDGslaoXhqCujECuvMpZM);
	}

	public virtual string pryyVlQjRZaAqrvkshjZMvmZiqhT()
	{
		string text = "";
		for (int i = 0; i < qmcEcNniDGslaoXhqCujECuvMpZM; i++)
		{
			text = text + this.PrFamwgovWtoPfIJfDbafwrlYowe(i).ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		GOwfssBZgSjYKHLwHqOCgmUGkZgcb(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void oDCxSrGJUgeTIDkpZHSGxkTkRhFoA()
	{
		try
		{
			GOwfssBZgSjYKHLwHqOCgmUGkZgcb(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void GOwfssBZgSjYKHLwHqOCgmUGkZgcb(bool P_0)
	{
		if (!dSOuDbIVXCmiHlfWazTOsjGRkHVQ)
		{
			if (uuAhBpICDcxAGtFKudqMFzFfjwJEc.IsAllocated)
			{
				uuAhBpICDcxAGtFKudqMFzFfjwJEc.Free();
			}
			dSOuDbIVXCmiHlfWazTOsjGRkHVQ = true;
		}
	}

	public static void ePsxAtutvlaAqjNRuyOEHAegYQT(CPWLzYXKHJYVsYzNxyjZRVJpFxgi P_0, CPWLzYXKHJYVsYzNxyjZRVJpFxgi P_1, int P_2)
	{
		Array.Copy(P_0.iLwGJVQlLzJmzfxFCPipkgmHMOMI, P_1.iLwGJVQlLzJmzfxFCPipkgmHMOMI, P_2);
	}

	public static void MsrofJqPzPhCUklgUwBDFKLfdykW(CPWLzYXKHJYVsYzNxyjZRVJpFxgi P_0, int P_1, CPWLzYXKHJYVsYzNxyjZRVJpFxgi P_2, int P_3, int P_4)
	{
		Array.Copy(P_0.iLwGJVQlLzJmzfxFCPipkgmHMOMI, P_1, P_2.iLwGJVQlLzJmzfxFCPipkgmHMOMI, P_3, P_4);
	}
}
