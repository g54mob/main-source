using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal class hfzzZedzHVEtpwXVfiBYMbtQICUq : IDisposable
{
	private readonly byte[] dCDzzhECnslHjnkfvQjCsFqAFcgj;

	public readonly int MjQdKxoDGICpkBVEeFORuTAWlZiR;

	private GCHandle RfcrqSzJaPHBTCWCcHaijGWVeWjZ;

	private bool YRgGrskuIhyWTenpCAbXMKnMfNSjA;

	public bool TnCBhKgxfRRKLobgLJJzHnSZyoGcA => RfcrqSzJaPHBTCWCcHaijGWVeWjZ.IsAllocated;

	public byte gPYizyYElFAELrNNzZeMIoCAnsuG
	{
		get
		{
			return dCDzzhECnslHjnkfvQjCsFqAFcgj[P_0];
		}
		set
		{
			dCDzzhECnslHjnkfvQjCsFqAFcgj[num] = b;
		}
	}

	public hfzzZedzHVEtpwXVfiBYMbtQICUq(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("size must be > 0");
		}
		MjQdKxoDGICpkBVEeFORuTAWlZiR = P_0;
		dCDzzhECnslHjnkfvQjCsFqAFcgj = new byte[P_0];
	}

	public IntPtr nJalcrStVthnjCpkEaOqdLrjEGgDA()
	{
		if (RfcrqSzJaPHBTCWCcHaijGWVeWjZ.IsAllocated)
		{
			return RfcrqSzJaPHBTCWCcHaijGWVeWjZ.AddrOfPinnedObject();
		}
		RfcrqSzJaPHBTCWCcHaijGWVeWjZ = GCHandle.Alloc(dCDzzhECnslHjnkfvQjCsFqAFcgj, GCHandleType.Pinned);
		return RfcrqSzJaPHBTCWCcHaijGWVeWjZ.AddrOfPinnedObject();
	}

	public void dWKEwtDJvZTpWpZKIXsQrfNfGCmbA()
	{
		if (RfcrqSzJaPHBTCWCcHaijGWVeWjZ.IsAllocated)
		{
			RfcrqSzJaPHBTCWCcHaijGWVeWjZ.Free();
		}
	}

	public string uXJbpwgrqTIXwgadGJSaeyJmvYdpA()
	{
		string text = "";
		for (int i = 0; i < MjQdKxoDGICpkBVEeFORuTAWlZiR; i++)
		{
			text = text + dCDzzhECnslHjnkfvQjCsFqAFcgj[i].ToString("x2") + " ";
		}
		return text;
	}

	public bool hTBzKGFmaNncLmkCHIESYDvPinke(int P_0, byte P_1)
	{
		if (1 + P_0 > MjQdKxoDGICpkBVEeFORuTAWlZiR || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (dCDzzhECnslHjnkfvQjCsFqAFcgj[P_0] & (1 << (int)P_1)) != 0;
	}

	public byte UyDlCQfXOQRFxyEiXjpzuIjTRGJL(int P_0)
	{
		if (1 + P_0 > MjQdKxoDGICpkBVEeFORuTAWlZiR || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return dCDzzhECnslHjnkfvQjCsFqAFcgj[P_0];
	}

	public unsafe short FHhtbiNGCiOBhAuQIsYxVnxqCkTf(int P_0)
	{
		if (2 + P_0 > MjQdKxoDGICpkBVEeFORuTAWlZiR || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = dCDzzhECnslHjnkfvQjCsFqAFcgj)
		{
			return *(short*)(ptr + P_0);
		}
	}

	public unsafe ushort aKbgaNLaoixsIqWeovCBvkrrrbot(int P_0)
	{
		if (2 + P_0 > MjQdKxoDGICpkBVEeFORuTAWlZiR || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = dCDzzhECnslHjnkfvQjCsFqAFcgj)
		{
			return *(ushort*)(ptr + P_0);
		}
	}

	public unsafe int crcteFLmAqzMbrlCHexcSTXcYYyU(int P_0)
	{
		if (4 + P_0 > MjQdKxoDGICpkBVEeFORuTAWlZiR || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = dCDzzhECnslHjnkfvQjCsFqAFcgj)
		{
			return *(int*)(ptr + P_0);
		}
	}

	public unsafe uint remikseWBYcSOvmNptKBxPvNaXyQ(int P_0)
	{
		if (4 + P_0 > MjQdKxoDGICpkBVEeFORuTAWlZiR || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = dCDzzhECnslHjnkfvQjCsFqAFcgj)
		{
			return *(uint*)(ptr + P_0);
		}
	}

	public unsafe long vYmRcLMNNlzSPuxYOGYbNyiGbqMr(int P_0)
	{
		if (8 + P_0 > MjQdKxoDGICpkBVEeFORuTAWlZiR || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = dCDzzhECnslHjnkfvQjCsFqAFcgj)
		{
			return *(long*)(ptr + P_0);
		}
	}

	public unsafe ulong PQcCNLaruCQCtJRbdCAmBoadtUmxB(int P_0)
	{
		if (8 + P_0 > MjQdKxoDGICpkBVEeFORuTAWlZiR || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = dCDzzhECnslHjnkfvQjCsFqAFcgj)
		{
			return *(ulong*)(ptr + P_0);
		}
	}

	public void JwZcBsApdsaEucZXetbbOeWpdLQgB(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > MjQdKxoDGICpkBVEeFORuTAWlZiR)
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
		if (P_2 >= MjQdKxoDGICpkBVEeFORuTAWlZiR)
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
		if (P_1 + P_2 > MjQdKxoDGICpkBVEeFORuTAWlZiR)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		Array.Copy(dCDzzhECnslHjnkfvQjCsFqAFcgj, P_2, P_0, P_3, P_1);
	}

	public void cVUYUoyEWchRBgXQxzTcGKcECvzl(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > MjQdKxoDGICpkBVEeFORuTAWlZiR)
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
		if (P_3 >= MjQdKxoDGICpkBVEeFORuTAWlZiR)
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
		if (P_2 + P_3 > MjQdKxoDGICpkBVEeFORuTAWlZiR)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(dCDzzhECnslHjnkfvQjCsFqAFcgj, P_0, P_3, P_4, P_2);
	}

	public int vsJnobxUldhmiuVRKJqICLObnyw(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_2 >= MjQdKxoDGICpkBVEeFORuTAWlZiR)
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
		if (P_2 + P_1 > MjQdKxoDGICpkBVEeFORuTAWlZiR)
		{
			P_1 = MjQdKxoDGICpkBVEeFORuTAWlZiR - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		Array.Copy(dCDzzhECnslHjnkfvQjCsFqAFcgj, P_2, P_0, P_3, P_1);
		return P_1;
	}

	public int ljJHNszdRiIWPoguZszVpoOPWSVs(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= MjQdKxoDGICpkBVEeFORuTAWlZiR)
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
		if (P_3 + P_2 > MjQdKxoDGICpkBVEeFORuTAWlZiR)
		{
			P_2 = MjQdKxoDGICpkBVEeFORuTAWlZiR - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		NativeTools.CopyMemory(dCDzzhECnslHjnkfvQjCsFqAFcgj, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public void bferIJqCkgnBwrFosHuBBQdlaSsZ(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > MjQdKxoDGICpkBVEeFORuTAWlZiR || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			dCDzzhECnslHjnkfvQjCsFqAFcgj[P_0] |= (byte)(1 << (int)P_1);
		}
		else
		{
			dCDzzhECnslHjnkfvQjCsFqAFcgj[P_0] &= (byte)(~(1 << (int)P_1));
		}
	}

	public void crAjhbbiEgtCSNfYoCnadDDNrDcEb(byte P_0, int P_1)
	{
		if (1 + P_1 > MjQdKxoDGICpkBVEeFORuTAWlZiR || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		dCDzzhECnslHjnkfvQjCsFqAFcgj[P_1] = P_0;
	}

	public unsafe void TsercKrqLWphONTVCAguoFCykukR(short P_0, int P_1)
	{
		if (2 + P_1 > MjQdKxoDGICpkBVEeFORuTAWlZiR || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = dCDzzhECnslHjnkfvQjCsFqAFcgj)
		{
			*(short*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void qLykBgKnrvuDQmqOhmszwpDWEoGU(ushort P_0, int P_1)
	{
		if (2 + P_1 > MjQdKxoDGICpkBVEeFORuTAWlZiR || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = dCDzzhECnslHjnkfvQjCsFqAFcgj)
		{
			*(ushort*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void rOhqrRRrmqLZKHWsQBiPznzhVCtg(int P_0, int P_1)
	{
		if (4 + P_1 > MjQdKxoDGICpkBVEeFORuTAWlZiR || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = dCDzzhECnslHjnkfvQjCsFqAFcgj)
		{
			*(int*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void aWrxlPmCmNfsdvdmMTavdjLgAprA(uint P_0, int P_1)
	{
		if (4 + P_1 > MjQdKxoDGICpkBVEeFORuTAWlZiR || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = dCDzzhECnslHjnkfvQjCsFqAFcgj)
		{
			*(uint*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void qBpgrVlrsSNfdpGdmDgCMhPYyAMd(long P_0, int P_1)
	{
		if (8 + P_1 > MjQdKxoDGICpkBVEeFORuTAWlZiR || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = dCDzzhECnslHjnkfvQjCsFqAFcgj)
		{
			*(long*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void RiwbULULReohRuWSmfpWnsycdrXq(ulong P_0, int P_1)
	{
		if (8 + P_1 > MjQdKxoDGICpkBVEeFORuTAWlZiR || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = dCDzzhECnslHjnkfvQjCsFqAFcgj)
		{
			*(ulong*)(ptr + P_1) = P_0;
		}
	}

	public void cEnzUsQjLOlydXyORBfkpCPsaUIs(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > MjQdKxoDGICpkBVEeFORuTAWlZiR)
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
		if (P_2 >= MjQdKxoDGICpkBVEeFORuTAWlZiR)
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
		if (P_1 + P_2 > MjQdKxoDGICpkBVEeFORuTAWlZiR)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		Array.Copy(P_0, P_3, dCDzzhECnslHjnkfvQjCsFqAFcgj, P_2, P_1);
	}

	public void zZDXUKZoDRhZMfeaqWsIfbiNSmhq(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > MjQdKxoDGICpkBVEeFORuTAWlZiR)
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
		if (P_3 >= MjQdKxoDGICpkBVEeFORuTAWlZiR)
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
		if (P_2 + P_3 > MjQdKxoDGICpkBVEeFORuTAWlZiR)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, dCDzzhECnslHjnkfvQjCsFqAFcgj, P_4, P_3, P_2);
	}

	public int CiVRJkXJwPdRUyvcSUfrgiKTwaPr(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= MjQdKxoDGICpkBVEeFORuTAWlZiR)
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
		if (P_1 + P_2 > MjQdKxoDGICpkBVEeFORuTAWlZiR)
		{
			P_1 = MjQdKxoDGICpkBVEeFORuTAWlZiR - P_2;
		}
		Array.Copy(P_0, P_3, dCDzzhECnslHjnkfvQjCsFqAFcgj, P_2, P_1);
		return P_1;
	}

	public int virxfuEqWwFCLvnCstTAVNWMGRkBA(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= MjQdKxoDGICpkBVEeFORuTAWlZiR)
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
		if (P_2 + P_3 > MjQdKxoDGICpkBVEeFORuTAWlZiR)
		{
			P_2 = MjQdKxoDGICpkBVEeFORuTAWlZiR - P_3;
		}
		NativeTools.CopyMemory(P_0, dCDzzhECnslHjnkfvQjCsFqAFcgj, P_4, P_3, P_2);
		return P_2;
	}

	public void KjDLcgaOjFEndxSihliiNcJwzxTJ()
	{
		Array.Clear(dCDzzhECnslHjnkfvQjCsFqAFcgj, 0, MjQdKxoDGICpkBVEeFORuTAWlZiR);
	}

	public virtual string IccAKWYHBKTagTPpqvubWLiuaZsE()
	{
		string text = "";
		for (int i = 0; i < MjQdKxoDGICpkBVEeFORuTAWlZiR; i++)
		{
			text = text + this.bKOMJVOqKGICvAqENOLYfTSDwCFzA(i).ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		hSAIdniXrXabdokQHnvksUMTtSAV(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void eXGxCWOHbGgHLEEpVRbENmswovXNA()
	{
		try
		{
			hSAIdniXrXabdokQHnvksUMTtSAV(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void hSAIdniXrXabdokQHnvksUMTtSAV(bool P_0)
	{
		if (!YRgGrskuIhyWTenpCAbXMKnMfNSjA)
		{
			if (RfcrqSzJaPHBTCWCcHaijGWVeWjZ.IsAllocated)
			{
				RfcrqSzJaPHBTCWCcHaijGWVeWjZ.Free();
			}
			YRgGrskuIhyWTenpCAbXMKnMfNSjA = true;
		}
	}

	public static void qsVEgofgSCgIoltzHCwnVTxIFZmEb(hfzzZedzHVEtpwXVfiBYMbtQICUq P_0, hfzzZedzHVEtpwXVfiBYMbtQICUq P_1, int P_2)
	{
		Array.Copy(P_0.dCDzzhECnslHjnkfvQjCsFqAFcgj, P_1.dCDzzhECnslHjnkfvQjCsFqAFcgj, P_2);
	}

	public static void DxKCNjBVqwGHgRgoTCXoUqUOOBbHA(hfzzZedzHVEtpwXVfiBYMbtQICUq P_0, int P_1, hfzzZedzHVEtpwXVfiBYMbtQICUq P_2, int P_3, int P_4)
	{
		Array.Copy(P_0.dCDzzhECnslHjnkfvQjCsFqAFcgj, P_1, P_2.dCDzzhECnslHjnkfvQjCsFqAFcgj, P_3, P_4);
	}
}
