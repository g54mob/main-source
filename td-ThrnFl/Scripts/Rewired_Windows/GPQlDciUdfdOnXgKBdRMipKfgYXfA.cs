using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal class GPQlDciUdfdOnXgKBdRMipKfgYXfA : IDisposable
{
	private unsafe byte* KPCHMOeAWyDIdvUrMwsNDNzmKhu;

	private int RkdXZMBDNsHjogBxodhwcIrcAdLjA;

	private bool rxOjFUfxWZGGygOMrFfmJBNPSjfU;

	public unsafe byte* TPwBaYCCrshyOziijMuSAmuiwtpcA => KPCHMOeAWyDIdvUrMwsNDNzmKhu;

	public unsafe IntPtr MeBsLkhnFzRSjfjkdGNduTkRjLUhA => (IntPtr)KPCHMOeAWyDIdvUrMwsNDNzmKhu;

	public int msmrLCoySdhONgJYPdvffikOnaJUA => RkdXZMBDNsHjogBxodhwcIrcAdLjA;

	public unsafe byte KEgByvPRZmgbnrKCrHuaWEuqdkyn
	{
		get
		{
			if (P_0 < 0 || P_0 >= RkdXZMBDNsHjogBxodhwcIrcAdLjA)
			{
				throw new IndexOutOfRangeException();
			}
			return KPCHMOeAWyDIdvUrMwsNDNzmKhu[P_0];
		}
		set
		{
			if (num < 0 || num >= RkdXZMBDNsHjogBxodhwcIrcAdLjA)
			{
				throw new IndexOutOfRangeException();
			}
			KPCHMOeAWyDIdvUrMwsNDNzmKhu[num] = b;
		}
	}

	public GPQlDciUdfdOnXgKBdRMipKfgYXfA(int P_0)
	{
		oVNcHhdWfkCPlrSOtCYCvKCQsTLt(P_0);
	}

	public unsafe IntPtr uRiwmclJDnrLhCEwSknvRoSJgKsC(int P_0 = 0)
	{
		if (P_0 == 0)
		{
			return (IntPtr)KPCHMOeAWyDIdvUrMwsNDNzmKhu;
		}
		if (P_0 < 0 || P_0 >= RkdXZMBDNsHjogBxodhwcIrcAdLjA)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		return (IntPtr)(KPCHMOeAWyDIdvUrMwsNDNzmKhu + P_0);
	}

	public unsafe string ZXumayqQggInjdQcCNhhwjoCqOve()
	{
		string text = "";
		for (int i = 0; i < RkdXZMBDNsHjogBxodhwcIrcAdLjA; i++)
		{
			text = text + KPCHMOeAWyDIdvUrMwsNDNzmKhu[i].ToString("x2") + " ";
		}
		return text;
	}

	public unsafe bool svsAPXXUySysQfQeaKQytwvRGGDb(int P_0, byte P_1)
	{
		if (1 + P_0 > RkdXZMBDNsHjogBxodhwcIrcAdLjA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (KPCHMOeAWyDIdvUrMwsNDNzmKhu[P_0] & (1 << (int)P_1)) != 0;
	}

	public unsafe byte jpewrEHlraVoxgHezsBfWDlWPdCr(int P_0)
	{
		if (1 + P_0 > RkdXZMBDNsHjogBxodhwcIrcAdLjA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return KPCHMOeAWyDIdvUrMwsNDNzmKhu[P_0];
	}

	public unsafe short ZxGbFMeICfgFfBotdTBbSHpYHJDhA(int P_0)
	{
		if (2 + P_0 > RkdXZMBDNsHjogBxodhwcIrcAdLjA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(short*)(KPCHMOeAWyDIdvUrMwsNDNzmKhu + P_0);
	}

	public unsafe ushort xgOmGpqgAYJMlVexMKYMfccZDLAA(int P_0)
	{
		if (2 + P_0 > RkdXZMBDNsHjogBxodhwcIrcAdLjA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ushort*)(KPCHMOeAWyDIdvUrMwsNDNzmKhu + P_0);
	}

	public unsafe int lVrGyBVGUPBxFAMRCgvFoWZqBWApA(int P_0)
	{
		if (4 + P_0 > RkdXZMBDNsHjogBxodhwcIrcAdLjA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(int*)(KPCHMOeAWyDIdvUrMwsNDNzmKhu + P_0);
	}

	public unsafe uint iLGxirGtvkazhNZNSLrFDjnANODi(int P_0)
	{
		if (4 + P_0 > RkdXZMBDNsHjogBxodhwcIrcAdLjA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(uint*)(KPCHMOeAWyDIdvUrMwsNDNzmKhu + P_0);
	}

	public unsafe long IQdzTSMBnAWTYCvtmiQqLGtfIuRk(int P_0)
	{
		if (8 + P_0 > RkdXZMBDNsHjogBxodhwcIrcAdLjA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(long*)(KPCHMOeAWyDIdvUrMwsNDNzmKhu + P_0);
	}

	public unsafe ulong qjQdKzRCkZkyZAtAekEcvrqmiCSN(int P_0)
	{
		if (8 + P_0 > RkdXZMBDNsHjogBxodhwcIrcAdLjA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ulong*)(KPCHMOeAWyDIdvUrMwsNDNzmKhu + P_0);
	}

	public unsafe float gbouRxnBgGEFUkaiUaJFhHSbNcAW(int P_0)
	{
		if (4 + P_0 > RkdXZMBDNsHjogBxodhwcIrcAdLjA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(float*)(KPCHMOeAWyDIdvUrMwsNDNzmKhu + P_0);
	}

	public unsafe double rVHkxImGKCUqpJyfdmzVXsLhPJEK(int P_0)
	{
		if (8 + P_0 > RkdXZMBDNsHjogBxodhwcIrcAdLjA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(double*)(KPCHMOeAWyDIdvUrMwsNDNzmKhu + P_0);
	}

	public unsafe void aQAlLResKCaKBLDWRKDZbRcXgAqm(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > RkdXZMBDNsHjogBxodhwcIrcAdLjA)
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
		if (P_2 >= RkdXZMBDNsHjogBxodhwcIrcAdLjA)
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
		if (P_1 + P_2 > RkdXZMBDNsHjogBxodhwcIrcAdLjA)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory((IntPtr)KPCHMOeAWyDIdvUrMwsNDNzmKhu, P_0, P_2, P_3, P_1);
	}

	public unsafe void NIwyTelWfilzdkalMeQEqIXXiewH(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > RkdXZMBDNsHjogBxodhwcIrcAdLjA)
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
		if (P_3 >= RkdXZMBDNsHjogBxodhwcIrcAdLjA)
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
		if (P_2 + P_3 > RkdXZMBDNsHjogBxodhwcIrcAdLjA)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		EKnkiWpmsWIwmATuShvoOkPhQPyF.AnUHzRflyKdroulueRYYDxZIQpAg(KPCHMOeAWyDIdvUrMwsNDNzmKhu, P_0, P_3, P_4, P_2);
	}

	public unsafe void oCMHJbAwrwakLApTfdLMRzQTIyzCB(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		NIwyTelWfilzdkalMeQEqIXXiewH((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int KNwBIaTBYiEMekVzLlilPCcRXtLl(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_2 >= RkdXZMBDNsHjogBxodhwcIrcAdLjA)
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
		if (P_2 + P_1 > RkdXZMBDNsHjogBxodhwcIrcAdLjA)
		{
			P_1 = RkdXZMBDNsHjogBxodhwcIrcAdLjA - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		NativeTools.CopyMemory((IntPtr)KPCHMOeAWyDIdvUrMwsNDNzmKhu, P_0, P_2, P_3, P_1);
		return P_1;
	}

	public unsafe int vDFABYlAfFifOcJxALcFBtfBXMvw(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= RkdXZMBDNsHjogBxodhwcIrcAdLjA)
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
		if (P_3 + P_2 > RkdXZMBDNsHjogBxodhwcIrcAdLjA)
		{
			P_2 = RkdXZMBDNsHjogBxodhwcIrcAdLjA - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		EKnkiWpmsWIwmATuShvoOkPhQPyF.AnUHzRflyKdroulueRYYDxZIQpAg(KPCHMOeAWyDIdvUrMwsNDNzmKhu, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public unsafe int lRsbdDNWFTelVWUNUHWxDTjVHLzd(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0;
		}
		return vDFABYlAfFifOcJxALcFBtfBXMvw((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe void qrBcmhfqolxpaBWYkpoQBXEhlkpy(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > RkdXZMBDNsHjogBxodhwcIrcAdLjA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			byte* num = KPCHMOeAWyDIdvUrMwsNDNzmKhu + P_0;
			*num |= (byte)(1 << (int)P_1);
		}
		else
		{
			byte* num2 = KPCHMOeAWyDIdvUrMwsNDNzmKhu + P_0;
			*num2 &= (byte)(~(1 << (int)P_1));
		}
	}

	public unsafe void tLqbMoLDLRxjvfETzuKVpfdvOILr(byte P_0, int P_1)
	{
		if (1 + P_1 > RkdXZMBDNsHjogBxodhwcIrcAdLjA || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		KPCHMOeAWyDIdvUrMwsNDNzmKhu[P_1] = P_0;
	}

	public unsafe void gcWwjqUKEwitYjqwPvGbrzbZfZcb(short P_0, int P_1)
	{
		if (2 + P_1 > RkdXZMBDNsHjogBxodhwcIrcAdLjA || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(short*)(KPCHMOeAWyDIdvUrMwsNDNzmKhu + P_1) = P_0;
	}

	public unsafe void QXYinfGbYqxqrfBXPGQzeqsuFAtBb(ushort P_0, int P_1)
	{
		if (2 + P_1 > RkdXZMBDNsHjogBxodhwcIrcAdLjA || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ushort*)(KPCHMOeAWyDIdvUrMwsNDNzmKhu + P_1) = P_0;
	}

	public unsafe void vtzKyZRWUlSxOqAiUcvaHVkTEyJCb(int P_0, int P_1)
	{
		if (4 + P_1 > RkdXZMBDNsHjogBxodhwcIrcAdLjA || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(int*)(KPCHMOeAWyDIdvUrMwsNDNzmKhu + P_1) = P_0;
	}

	public unsafe void ZRvMepNlYpUsPFFtBrUisilzSHsm(uint P_0, int P_1)
	{
		if (4 + P_1 > RkdXZMBDNsHjogBxodhwcIrcAdLjA || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(uint*)(KPCHMOeAWyDIdvUrMwsNDNzmKhu + P_1) = P_0;
	}

	public unsafe void KrrdwlragBfcNDJnVEmzTIADmxRWA(long P_0, int P_1)
	{
		if (8 + P_1 > RkdXZMBDNsHjogBxodhwcIrcAdLjA || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(long*)(KPCHMOeAWyDIdvUrMwsNDNzmKhu + P_1) = P_0;
	}

	public unsafe void ZcIvkMrUAfpqDrqkphaIdLsfOlIU(ulong P_0, int P_1)
	{
		if (8 + P_1 > RkdXZMBDNsHjogBxodhwcIrcAdLjA || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ulong*)(KPCHMOeAWyDIdvUrMwsNDNzmKhu + P_1) = P_0;
	}

	public unsafe void jEcyrzyGtcmBApmtKahFkcrCXdcOA(float P_0, int P_1)
	{
		if (4 + P_1 > RkdXZMBDNsHjogBxodhwcIrcAdLjA || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(float*)(KPCHMOeAWyDIdvUrMwsNDNzmKhu + P_1) = P_0;
	}

	public unsafe void nKoaQrHkSqaHNrLthlGHPmEJoDGSA(double P_0, int P_1)
	{
		if (8 + P_1 > RkdXZMBDNsHjogBxodhwcIrcAdLjA || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(double*)(KPCHMOeAWyDIdvUrMwsNDNzmKhu + P_1) = P_0;
	}

	public unsafe void kDUMimeVCSuhVfMTwgkPCELqjEpq(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > RkdXZMBDNsHjogBxodhwcIrcAdLjA)
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
		if (P_2 >= RkdXZMBDNsHjogBxodhwcIrcAdLjA)
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
		if (P_1 + P_2 > RkdXZMBDNsHjogBxodhwcIrcAdLjA)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, (IntPtr)KPCHMOeAWyDIdvUrMwsNDNzmKhu, P_3, P_2, P_1);
	}

	public unsafe void iMXSIyIkpOqogNWcegLrShmHmjWy(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > RkdXZMBDNsHjogBxodhwcIrcAdLjA)
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
		if (P_3 >= RkdXZMBDNsHjogBxodhwcIrcAdLjA)
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
		if (P_2 + P_3 > RkdXZMBDNsHjogBxodhwcIrcAdLjA)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		EKnkiWpmsWIwmATuShvoOkPhQPyF.AnUHzRflyKdroulueRYYDxZIQpAg(P_0, KPCHMOeAWyDIdvUrMwsNDNzmKhu, P_4, P_3, P_2);
	}

	public unsafe void TsFmhnuPVZuSjsaIyGxiIPpphaln(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		iMXSIyIkpOqogNWcegLrShmHmjWy((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int XisUdxJEppLpLfiKcpDZXisSzxhv(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= RkdXZMBDNsHjogBxodhwcIrcAdLjA)
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
		if (P_1 + P_2 > RkdXZMBDNsHjogBxodhwcIrcAdLjA)
		{
			P_1 = RkdXZMBDNsHjogBxodhwcIrcAdLjA - P_2;
		}
		NativeTools.CopyMemory(P_0, (IntPtr)KPCHMOeAWyDIdvUrMwsNDNzmKhu, P_3, P_2, P_1);
		return P_1;
	}

	public unsafe int tJeaVLBTpqMBvOrKlhZqaBBfIdRI(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= RkdXZMBDNsHjogBxodhwcIrcAdLjA)
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
		if (P_2 + P_3 > RkdXZMBDNsHjogBxodhwcIrcAdLjA)
		{
			P_2 = RkdXZMBDNsHjogBxodhwcIrcAdLjA - P_3;
		}
		EKnkiWpmsWIwmATuShvoOkPhQPyF.AnUHzRflyKdroulueRYYDxZIQpAg(P_0, KPCHMOeAWyDIdvUrMwsNDNzmKhu, P_4, P_3, P_2);
		return P_2;
	}

	public unsafe int rmmpVeABScqzZDfPinbSkcdCpGDV(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		return tJeaVLBTpqMBvOrKlhZqaBBfIdRI((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool oVNcHhdWfkCPlrSOtCYCvKCQsTLt(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("size");
		}
		if (RkdXZMBDNsHjogBxodhwcIrcAdLjA == P_0)
		{
			return true;
		}
		JvVcQoGqPilavBaUuXHGrzauWMyA();
		if (P_0 == 0)
		{
			return true;
		}
		RkdXZMBDNsHjogBxodhwcIrcAdLjA = P_0;
		KPCHMOeAWyDIdvUrMwsNDNzmKhu = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		zQwDOXVqEHKzfXYyyEUGnhjesFdB();
		return true;
	}

	public unsafe void zQwDOXVqEHKzfXYyyEUGnhjesFdB()
	{
		if (RkdXZMBDNsHjogBxodhwcIrcAdLjA != 0)
		{
			EKnkiWpmsWIwmATuShvoOkPhQPyF.viXKbDlkVMGfteQQGzswfJwIvJei(KPCHMOeAWyDIdvUrMwsNDNzmKhu, RkdXZMBDNsHjogBxodhwcIrcAdLjA);
		}
	}

	public unsafe void JvVcQoGqPilavBaUuXHGrzauWMyA()
	{
		if (RkdXZMBDNsHjogBxodhwcIrcAdLjA == 0)
		{
			return;
		}
		try
		{
			if (KPCHMOeAWyDIdvUrMwsNDNzmKhu != null)
			{
				Marshal.FreeHGlobal(MeBsLkhnFzRSjfjkdGNduTkRjLUhA);
			}
		}
		catch
		{
		}
		KPCHMOeAWyDIdvUrMwsNDNzmKhu = null;
		RkdXZMBDNsHjogBxodhwcIrcAdLjA = 0;
	}

	public virtual string OYFtpaAtpKrOCVfEhMOKqhnxrtbQ()
	{
		string text = "";
		for (int i = 0; i < RkdXZMBDNsHjogBxodhwcIrcAdLjA; i++)
		{
			text = text + jpewrEHlraVoxgHezsBfWDlWPdCr(i).ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		oKXtruCHhlyqBpjeGTrYqobKIoOgA(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void XdMmoHZMHHcpWApeDJqInbnPqnHxA()
	{
		try
		{
			oKXtruCHhlyqBpjeGTrYqobKIoOgA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void oKXtruCHhlyqBpjeGTrYqobKIoOgA(bool P_0)
	{
		if (!rxOjFUfxWZGGygOMrFfmJBNPSjfU)
		{
			JvVcQoGqPilavBaUuXHGrzauWMyA();
			rxOjFUfxWZGGygOMrFfmJBNPSjfU = true;
		}
	}

	[SpecialName]
	public unsafe static IntPtr ghwWDZgcaAyQwxhiOEzvUChMhnWV(GPQlDciUdfdOnXgKBdRMipKfgYXfA P_0)
	{
		if (P_0 == null)
		{
			return IntPtr.Zero;
		}
		return (IntPtr)P_0.KPCHMOeAWyDIdvUrMwsNDNzmKhu;
	}

	[SpecialName]
	public unsafe static void* ghwWDZgcaAyQwxhiOEzvUChMhnWV(GPQlDciUdfdOnXgKBdRMipKfgYXfA P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		return P_0.KPCHMOeAWyDIdvUrMwsNDNzmKhu;
	}

	public unsafe static bool yCeiakBqfzzmsNuHzBTJMqkbpbjL(GPQlDciUdfdOnXgKBdRMipKfgYXfA P_0, GPQlDciUdfdOnXgKBdRMipKfgYXfA P_1)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("source");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("destination");
		}
		if (P_0.RkdXZMBDNsHjogBxodhwcIrcAdLjA == 0)
		{
			P_1.JvVcQoGqPilavBaUuXHGrzauWMyA();
			return true;
		}
		if (P_1.oVNcHhdWfkCPlrSOtCYCvKCQsTLt(P_0.RkdXZMBDNsHjogBxodhwcIrcAdLjA))
		{
			P_1.iMXSIyIkpOqogNWcegLrShmHmjWy(P_0.KPCHMOeAWyDIdvUrMwsNDNzmKhu, P_0.RkdXZMBDNsHjogBxodhwcIrcAdLjA, P_0.RkdXZMBDNsHjogBxodhwcIrcAdLjA);
			return true;
		}
		return false;
	}
}
