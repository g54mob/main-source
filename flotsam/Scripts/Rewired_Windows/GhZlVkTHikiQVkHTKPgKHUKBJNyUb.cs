using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal class GhZlVkTHikiQVkHTKPgKHUKBJNyUb : IDisposable
{
	private unsafe byte* YVEAtKBhPBkawqvBwcFyqbTLbHAVA;

	private int PwmMxGueOjUqSwncrJSeUPdGjiyDA;

	private bool fNTCrOEPPSWrMgaXaYQojuDvCmMW;

	public unsafe byte* JxOKMjszjXEcsdjoHXCGymCuSMC => YVEAtKBhPBkawqvBwcFyqbTLbHAVA;

	public unsafe IntPtr YSSxgaImOklYZpafogNhItelQMlJ => (IntPtr)YVEAtKBhPBkawqvBwcFyqbTLbHAVA;

	public int eXvjyKBrHizododLUSRvQykorQsg => PwmMxGueOjUqSwncrJSeUPdGjiyDA;

	public unsafe byte MXdiSvuIOjIYRgdXamykasqAWxFwb
	{
		get
		{
			if (P_0 < 0 || P_0 >= PwmMxGueOjUqSwncrJSeUPdGjiyDA)
			{
				throw new IndexOutOfRangeException();
			}
			return YVEAtKBhPBkawqvBwcFyqbTLbHAVA[P_0];
		}
		set
		{
			if (num < 0 || num >= PwmMxGueOjUqSwncrJSeUPdGjiyDA)
			{
				throw new IndexOutOfRangeException();
			}
			YVEAtKBhPBkawqvBwcFyqbTLbHAVA[num] = b;
		}
	}

	public GhZlVkTHikiQVkHTKPgKHUKBJNyUb(int P_0)
	{
		qOUJpxCpwfNoFhPHejlAFHMuKUiHA(P_0);
	}

	public unsafe IntPtr oJhUMuABWwJQPMoJPLRvrNylypVu(int P_0 = 0)
	{
		if (P_0 == 0)
		{
			return (IntPtr)YVEAtKBhPBkawqvBwcFyqbTLbHAVA;
		}
		if (P_0 < 0 || P_0 >= PwmMxGueOjUqSwncrJSeUPdGjiyDA)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		return (IntPtr)(YVEAtKBhPBkawqvBwcFyqbTLbHAVA + P_0);
	}

	public unsafe string RubDSeJFTpulHgpVRqulFObmgpMgb()
	{
		string text = "";
		for (int i = 0; i < PwmMxGueOjUqSwncrJSeUPdGjiyDA; i++)
		{
			text = text + YVEAtKBhPBkawqvBwcFyqbTLbHAVA[i].ToString("x2") + " ";
		}
		return text;
	}

	public unsafe bool mpzgqNEmZVVFKsrBjufAfPsDOBtKA(int P_0, byte P_1)
	{
		if (1 + P_0 > PwmMxGueOjUqSwncrJSeUPdGjiyDA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (YVEAtKBhPBkawqvBwcFyqbTLbHAVA[P_0] & (1 << (int)P_1)) != 0;
	}

	public unsafe byte vZtBoWuwbjXHJcabyqmpojtgedpg(int P_0)
	{
		if (1 + P_0 > PwmMxGueOjUqSwncrJSeUPdGjiyDA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return YVEAtKBhPBkawqvBwcFyqbTLbHAVA[P_0];
	}

	public unsafe short DsBqJMJxHeRcXBXceswbcddieIeIA(int P_0)
	{
		if (2 + P_0 > PwmMxGueOjUqSwncrJSeUPdGjiyDA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(short*)(YVEAtKBhPBkawqvBwcFyqbTLbHAVA + P_0);
	}

	public unsafe ushort jNxaSSDHzFwuwgVzqdvYXLoSdIipA(int P_0)
	{
		if (2 + P_0 > PwmMxGueOjUqSwncrJSeUPdGjiyDA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ushort*)(YVEAtKBhPBkawqvBwcFyqbTLbHAVA + P_0);
	}

	public unsafe int nYaCAJaDaQUBpEiOXCVVqtXYVrtG(int P_0)
	{
		if (4 + P_0 > PwmMxGueOjUqSwncrJSeUPdGjiyDA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(int*)(YVEAtKBhPBkawqvBwcFyqbTLbHAVA + P_0);
	}

	public unsafe uint iyHAnhlcYjGATHWZNcgHlliyOKqC(int P_0)
	{
		if (4 + P_0 > PwmMxGueOjUqSwncrJSeUPdGjiyDA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(uint*)(YVEAtKBhPBkawqvBwcFyqbTLbHAVA + P_0);
	}

	public unsafe long SYevnUpAeNiFeCZwlVKkxphBPcgK(int P_0)
	{
		if (8 + P_0 > PwmMxGueOjUqSwncrJSeUPdGjiyDA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(long*)(YVEAtKBhPBkawqvBwcFyqbTLbHAVA + P_0);
	}

	public unsafe ulong ssZEHtkXrChJxWpVdBhcJTaIANxCA(int P_0)
	{
		if (8 + P_0 > PwmMxGueOjUqSwncrJSeUPdGjiyDA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ulong*)(YVEAtKBhPBkawqvBwcFyqbTLbHAVA + P_0);
	}

	public unsafe float ewfvEhIghPCnacyxPCiVoTUFdhrCb(int P_0)
	{
		if (4 + P_0 > PwmMxGueOjUqSwncrJSeUPdGjiyDA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(float*)(YVEAtKBhPBkawqvBwcFyqbTLbHAVA + P_0);
	}

	public unsafe double vjQpEEPXPJhbFXwkeRvDlZZBIGrH(int P_0)
	{
		if (8 + P_0 > PwmMxGueOjUqSwncrJSeUPdGjiyDA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(double*)(YVEAtKBhPBkawqvBwcFyqbTLbHAVA + P_0);
	}

	public unsafe void wFZpfDRPZLdllDhJKcZDRqstRpTF(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > PwmMxGueOjUqSwncrJSeUPdGjiyDA)
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
		if (P_2 >= PwmMxGueOjUqSwncrJSeUPdGjiyDA)
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
		if (P_1 + P_2 > PwmMxGueOjUqSwncrJSeUPdGjiyDA)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory((IntPtr)YVEAtKBhPBkawqvBwcFyqbTLbHAVA, P_0, P_2, P_3, P_1);
	}

	public unsafe void XWlsYwWawndQNeicNUTSQxFrVdHP(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > PwmMxGueOjUqSwncrJSeUPdGjiyDA)
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
		if (P_3 >= PwmMxGueOjUqSwncrJSeUPdGjiyDA)
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
		if (P_2 + P_3 > PwmMxGueOjUqSwncrJSeUPdGjiyDA)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		YeypUSYzjFxvMCDxNtGmgYXVPZRT.CcBZvVACfBcSKwyrnAlMhQJagBzm(YVEAtKBhPBkawqvBwcFyqbTLbHAVA, P_0, P_3, P_4, P_2);
	}

	public unsafe void mMDdinZexxRhxpQdgyMIPQPofUMD(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		XWlsYwWawndQNeicNUTSQxFrVdHP((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int QDtfhmaQLpRxSaDcUfOnDlgjCCgsA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_2 >= PwmMxGueOjUqSwncrJSeUPdGjiyDA)
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
		if (P_2 + P_1 > PwmMxGueOjUqSwncrJSeUPdGjiyDA)
		{
			P_1 = PwmMxGueOjUqSwncrJSeUPdGjiyDA - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		NativeTools.CopyMemory((IntPtr)YVEAtKBhPBkawqvBwcFyqbTLbHAVA, P_0, P_2, P_3, P_1);
		return P_1;
	}

	public unsafe int dYEOgYKtkAECkwwmJQRJpztnrJSU(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= PwmMxGueOjUqSwncrJSeUPdGjiyDA)
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
		if (P_3 + P_2 > PwmMxGueOjUqSwncrJSeUPdGjiyDA)
		{
			P_2 = PwmMxGueOjUqSwncrJSeUPdGjiyDA - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		YeypUSYzjFxvMCDxNtGmgYXVPZRT.CcBZvVACfBcSKwyrnAlMhQJagBzm(YVEAtKBhPBkawqvBwcFyqbTLbHAVA, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public unsafe int pozFZTwpREYRbAGHNAazivNjvGKY(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0;
		}
		return dYEOgYKtkAECkwwmJQRJpztnrJSU((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe void wdOmIdGavwSAIZjPtuDYrcOHDjQHA(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > PwmMxGueOjUqSwncrJSeUPdGjiyDA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			byte* num = YVEAtKBhPBkawqvBwcFyqbTLbHAVA + P_0;
			*num |= (byte)(1 << (int)P_1);
		}
		else
		{
			byte* num2 = YVEAtKBhPBkawqvBwcFyqbTLbHAVA + P_0;
			*num2 &= (byte)(~(1 << (int)P_1));
		}
	}

	public unsafe void nYrKeyqIAIMWNdRCirpXXXrJgJqN(byte P_0, int P_1)
	{
		if (1 + P_1 > PwmMxGueOjUqSwncrJSeUPdGjiyDA || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		YVEAtKBhPBkawqvBwcFyqbTLbHAVA[P_1] = P_0;
	}

	public unsafe void cRPeUxblDLyLTwnbxYAYPNvhcauvA(short P_0, int P_1)
	{
		if (2 + P_1 > PwmMxGueOjUqSwncrJSeUPdGjiyDA || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(short*)(YVEAtKBhPBkawqvBwcFyqbTLbHAVA + P_1) = P_0;
	}

	public unsafe void OMTdFpjgVhpHVnqYUcphUuqMqLCN(ushort P_0, int P_1)
	{
		if (2 + P_1 > PwmMxGueOjUqSwncrJSeUPdGjiyDA || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ushort*)(YVEAtKBhPBkawqvBwcFyqbTLbHAVA + P_1) = P_0;
	}

	public unsafe void piaYFPutTeYLyeebJcAkhGgvDpojA(int P_0, int P_1)
	{
		if (4 + P_1 > PwmMxGueOjUqSwncrJSeUPdGjiyDA || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(int*)(YVEAtKBhPBkawqvBwcFyqbTLbHAVA + P_1) = P_0;
	}

	public unsafe void PEeAwfojRgPsdFkuYxiiMgdLYDTi(uint P_0, int P_1)
	{
		if (4 + P_1 > PwmMxGueOjUqSwncrJSeUPdGjiyDA || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(uint*)(YVEAtKBhPBkawqvBwcFyqbTLbHAVA + P_1) = P_0;
	}

	public unsafe void MdyKYxYWtIJOhHlgGHRvinExopiG(long P_0, int P_1)
	{
		if (8 + P_1 > PwmMxGueOjUqSwncrJSeUPdGjiyDA || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(long*)(YVEAtKBhPBkawqvBwcFyqbTLbHAVA + P_1) = P_0;
	}

	public unsafe void JHNOFECHZuNVpdffeBUQBJiZuqvJ(ulong P_0, int P_1)
	{
		if (8 + P_1 > PwmMxGueOjUqSwncrJSeUPdGjiyDA || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ulong*)(YVEAtKBhPBkawqvBwcFyqbTLbHAVA + P_1) = P_0;
	}

	public unsafe void dShNfpDDknyQizeeDILRSYrguoFk(float P_0, int P_1)
	{
		if (4 + P_1 > PwmMxGueOjUqSwncrJSeUPdGjiyDA || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(float*)(YVEAtKBhPBkawqvBwcFyqbTLbHAVA + P_1) = P_0;
	}

	public unsafe void hnfytIVDzXivOFacpjPAMIDvYpOc(double P_0, int P_1)
	{
		if (8 + P_1 > PwmMxGueOjUqSwncrJSeUPdGjiyDA || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(double*)(YVEAtKBhPBkawqvBwcFyqbTLbHAVA + P_1) = P_0;
	}

	public unsafe void oqBpsgXYNFpVrjyItdHVmVZGdNMO(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > PwmMxGueOjUqSwncrJSeUPdGjiyDA)
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
		if (P_2 >= PwmMxGueOjUqSwncrJSeUPdGjiyDA)
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
		if (P_1 + P_2 > PwmMxGueOjUqSwncrJSeUPdGjiyDA)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, (IntPtr)YVEAtKBhPBkawqvBwcFyqbTLbHAVA, P_3, P_2, P_1);
	}

	public unsafe void gTCauczcINXdQHvQpibrefcbegll(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > PwmMxGueOjUqSwncrJSeUPdGjiyDA)
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
		if (P_3 >= PwmMxGueOjUqSwncrJSeUPdGjiyDA)
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
		if (P_2 + P_3 > PwmMxGueOjUqSwncrJSeUPdGjiyDA)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		YeypUSYzjFxvMCDxNtGmgYXVPZRT.CcBZvVACfBcSKwyrnAlMhQJagBzm(P_0, YVEAtKBhPBkawqvBwcFyqbTLbHAVA, P_4, P_3, P_2);
	}

	public unsafe void FeKVCvHIKODpPqbZzIviuhMBzITc(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		gTCauczcINXdQHvQpibrefcbegll((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int PWfFxfukFeCwpnTNnygVdHkysVMJ(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= PwmMxGueOjUqSwncrJSeUPdGjiyDA)
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
		if (P_1 + P_2 > PwmMxGueOjUqSwncrJSeUPdGjiyDA)
		{
			P_1 = PwmMxGueOjUqSwncrJSeUPdGjiyDA - P_2;
		}
		NativeTools.CopyMemory(P_0, (IntPtr)YVEAtKBhPBkawqvBwcFyqbTLbHAVA, P_3, P_2, P_1);
		return P_1;
	}

	public unsafe int rVnRAFsWehqlFQbNihQwfOFZQBsiA(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= PwmMxGueOjUqSwncrJSeUPdGjiyDA)
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
		if (P_2 + P_3 > PwmMxGueOjUqSwncrJSeUPdGjiyDA)
		{
			P_2 = PwmMxGueOjUqSwncrJSeUPdGjiyDA - P_3;
		}
		YeypUSYzjFxvMCDxNtGmgYXVPZRT.CcBZvVACfBcSKwyrnAlMhQJagBzm(P_0, YVEAtKBhPBkawqvBwcFyqbTLbHAVA, P_4, P_3, P_2);
		return P_2;
	}

	public unsafe int xcjrJitMJrIbfNjWpEOUAlrqgPkX(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		return rVnRAFsWehqlFQbNihQwfOFZQBsiA((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool qOUJpxCpwfNoFhPHejlAFHMuKUiHA(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("size");
		}
		if (PwmMxGueOjUqSwncrJSeUPdGjiyDA == P_0)
		{
			return true;
		}
		VLOFEObvnzdMQYPpXCmBtRvKtTjbA();
		if (P_0 == 0)
		{
			return true;
		}
		PwmMxGueOjUqSwncrJSeUPdGjiyDA = P_0;
		YVEAtKBhPBkawqvBwcFyqbTLbHAVA = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		dGxFxUGmzSpzHhVPtWfGhVdGqnyib();
		return true;
	}

	public unsafe void dGxFxUGmzSpzHhVPtWfGhVdGqnyib()
	{
		if (PwmMxGueOjUqSwncrJSeUPdGjiyDA != 0)
		{
			YeypUSYzjFxvMCDxNtGmgYXVPZRT.xbOwmZQwGJcjNgOZBaSqHPiiakDW(YVEAtKBhPBkawqvBwcFyqbTLbHAVA, PwmMxGueOjUqSwncrJSeUPdGjiyDA);
		}
	}

	public unsafe void VLOFEObvnzdMQYPpXCmBtRvKtTjbA()
	{
		if (PwmMxGueOjUqSwncrJSeUPdGjiyDA == 0)
		{
			return;
		}
		try
		{
			if (YVEAtKBhPBkawqvBwcFyqbTLbHAVA != null)
			{
				Marshal.FreeHGlobal(YSSxgaImOklYZpafogNhItelQMlJ);
			}
		}
		catch
		{
		}
		YVEAtKBhPBkawqvBwcFyqbTLbHAVA = null;
		PwmMxGueOjUqSwncrJSeUPdGjiyDA = 0;
	}

	public virtual string WgIPferFmJnVgHuBofCQObdBetUL()
	{
		string text = "";
		for (int i = 0; i < PwmMxGueOjUqSwncrJSeUPdGjiyDA; i++)
		{
			text = text + vZtBoWuwbjXHJcabyqmpojtgedpg(i).ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		eQSVqcliOwBFfbhtBSjWSbvgtxhg(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void RrDcCVutEIeQejSnCEXKZwhdBcwhA()
	{
		try
		{
			eQSVqcliOwBFfbhtBSjWSbvgtxhg(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void eQSVqcliOwBFfbhtBSjWSbvgtxhg(bool P_0)
	{
		if (!fNTCrOEPPSWrMgaXaYQojuDvCmMW)
		{
			VLOFEObvnzdMQYPpXCmBtRvKtTjbA();
			fNTCrOEPPSWrMgaXaYQojuDvCmMW = true;
		}
	}

	[SpecialName]
	public unsafe static IntPtr sMzpVHLhNJhxYbjCJKIburwcqApD(GhZlVkTHikiQVkHTKPgKHUKBJNyUb P_0)
	{
		if (P_0 == null)
		{
			return IntPtr.Zero;
		}
		return (IntPtr)P_0.YVEAtKBhPBkawqvBwcFyqbTLbHAVA;
	}

	[SpecialName]
	public unsafe static void* sMzpVHLhNJhxYbjCJKIburwcqApD(GhZlVkTHikiQVkHTKPgKHUKBJNyUb P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		return P_0.YVEAtKBhPBkawqvBwcFyqbTLbHAVA;
	}

	public unsafe static bool sOlMEeyKqiBGITsImqWHeXyTcICh(GhZlVkTHikiQVkHTKPgKHUKBJNyUb P_0, GhZlVkTHikiQVkHTKPgKHUKBJNyUb P_1)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("source");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("destination");
		}
		if (P_0.PwmMxGueOjUqSwncrJSeUPdGjiyDA == 0)
		{
			P_1.VLOFEObvnzdMQYPpXCmBtRvKtTjbA();
			return true;
		}
		if (P_1.qOUJpxCpwfNoFhPHejlAFHMuKUiHA(P_0.PwmMxGueOjUqSwncrJSeUPdGjiyDA))
		{
			P_1.gTCauczcINXdQHvQpibrefcbegll(P_0.YVEAtKBhPBkawqvBwcFyqbTLbHAVA, P_0.PwmMxGueOjUqSwncrJSeUPdGjiyDA, P_0.PwmMxGueOjUqSwncrJSeUPdGjiyDA);
			return true;
		}
		return false;
	}
}
