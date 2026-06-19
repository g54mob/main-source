using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal class RvwroizoUjcbyrJrShXDOpgYwyRP : IDisposable
{
	private class BByaBcaGEnhKTnVLEXnzhjdibjeV
	{
		public int ePaqftVougQUIHAIWbXFdwQakrDaA;

		public int ygSqnvHznsnamdgWNyajGLldjodf;

		public uint TKWLuasczAuGbrotmVSGJXdmhmpO;

		public object PUqtkegAkhiSnUxeDlZeBLYcejnk;

		public void AaSIiJvHWwCYfGChOPbeDfeTFJZuA(int P_0, int P_1, uint P_2, object P_3)
		{
			ePaqftVougQUIHAIWbXFdwQakrDaA = P_0;
			ygSqnvHznsnamdgWNyajGLldjodf = P_1;
			TKWLuasczAuGbrotmVSGJXdmhmpO = P_2;
			PUqtkegAkhiSnUxeDlZeBLYcejnk = P_3;
		}

		public void FCPDwhxIHUMvvagVRwzllUnCtBgv()
		{
			PUqtkegAkhiSnUxeDlZeBLYcejnk = null;
		}
	}

	[Serializable]
	private sealed class wLyuLdDOhCfgFJlVTrwSyTBKfjXZ
	{
		public static readonly wLyuLdDOhCfgFJlVTrwSyTBKfjXZ _003C_003E9 = new wLyuLdDOhCfgFJlVTrwSyTBKfjXZ();

		public static Func<BByaBcaGEnhKTnVLEXnzhjdibjeV> _003C_003E9__6_0;

		public static Action<BByaBcaGEnhKTnVLEXnzhjdibjeV> _003C_003E9__6_1;

		internal BByaBcaGEnhKTnVLEXnzhjdibjeV OvmshlTiSNgOObpLrJevesxiSxBeA()
		{
			return new BByaBcaGEnhKTnVLEXnzhjdibjeV();
		}

		internal void UTOfCNznccsknFWJlpIvTbDnRtZM(BByaBcaGEnhKTnVLEXnzhjdibjeV P_0)
		{
			P_0.FCPDwhxIHUMvvagVRwzllUnCtBgv();
		}
	}

	private jCIiucNiFgpCzJLbdfgxfzvgbTvgA UGWJCGdKsTDVYxdGVnRecfcGjCkdA;

	private ObjectPool<BByaBcaGEnhKTnVLEXnzhjdibjeV> iolABhkiKElAyEHGThXiOYfQCKPA;

	private Queue<BByaBcaGEnhKTnVLEXnzhjdibjeV> XlHPcfwPsVbQOICwSmPaGUtcLNUlc;

	private Action<object> bNKMJZTJzDEDMWTevcXiHSMegyDHA;

	private bool CPjcPjIzukXgkSBJohUcmojeuxOi;

	public bool DfoqBufdpvAksUuDYuMwdcsmjMXO => GECdROEssMrvDGhRkLTVXgTKXWNG();

	public RvwroizoUjcbyrJrShXDOpgYwyRP(int P_0, int P_1, Action<object> P_2 = null)
	{
		if (P_0 <= 0)
		{
			throw new ArgumentOutOfRangeException("capacity");
		}
		UGWJCGdKsTDVYxdGVnRecfcGjCkdA = new jCIiucNiFgpCzJLbdfgxfzvgbTvgA(P_0);
		iolABhkiKElAyEHGThXiOYfQCKPA = new ObjectPool<BByaBcaGEnhKTnVLEXnzhjdibjeV>(P_1, wLyuLdDOhCfgFJlVTrwSyTBKfjXZ._003C_003E9.OvmshlTiSNgOObpLrJevesxiSxBeA, wLyuLdDOhCfgFJlVTrwSyTBKfjXZ._003C_003E9.UTOfCNznccsknFWJlpIvTbDnRtZM);
		XlHPcfwPsVbQOICwSmPaGUtcLNUlc = new Queue<BByaBcaGEnhKTnVLEXnzhjdibjeV>(P_1);
		bNKMJZTJzDEDMWTevcXiHSMegyDHA = P_2;
	}

	public unsafe bool QpnORuQqdahPpgiPIFVKfQStsYWFb(byte* P_0, int P_1, object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return false;
		}
		if (UGWJCGdKsTDVYxdGVnRecfcGjCkdA.RAFjeqWqpGpZBFaJGcHmffMJbPuDb(P_0, P_1, P_1, out var num, out var num2) < P_1)
		{
			return false;
		}
		BByaBcaGEnhKTnVLEXnzhjdibjeV bByaBcaGEnhKTnVLEXnzhjdibjeV = iolABhkiKElAyEHGThXiOYfQCKPA.Get();
		bByaBcaGEnhKTnVLEXnzhjdibjeV.AaSIiJvHWwCYfGChOPbeDfeTFJZuA(num, P_1, num2, P_2);
		XlHPcfwPsVbQOICwSmPaGUtcLNUlc.Enqueue(bByaBcaGEnhKTnVLEXnzhjdibjeV);
		return true;
	}

	public unsafe bool zwJhgOuTuQfCieNVAwIFEhswRCCk(byte* P_0, int P_1)
	{
		return QpnORuQqdahPpgiPIFVKfQStsYWFb(P_0, P_1, null);
	}

	public unsafe bool TSdoNaYXZpFdehnEvuuyrDKfrWLS(IntPtr P_0, int P_1, object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			return false;
		}
		return QpnORuQqdahPpgiPIFVKfQStsYWFb((byte*)(void*)P_0, P_1, P_2);
	}

	public bool IyONOISXMRnfSbBpwMRjLWlIDunQ(IntPtr P_0, int P_1)
	{
		return TSdoNaYXZpFdehnEvuuyrDKfrWLS(P_0, P_1, null);
	}

	public unsafe bool UOUfqziYypxNlnoFLKtIkdaZRaoiA(byte[] P_0, int P_1, object P_2, int P_3 = 0)
	{
		if (P_0 == null || P_1 > P_0.Length)
		{
			return false;
		}
		if (P_3 < 0)
		{
			P_3 = 0;
		}
		if (P_3 + P_1 > P_0.Length)
		{
			return false;
		}
		fixed (byte* ptr = P_0)
		{
			byte* ptr2 = ptr + P_3;
			return QpnORuQqdahPpgiPIFVKfQStsYWFb(ptr2, P_1, P_2);
		}
	}

	public bool PiZXwGZvgePolNwDzhhGzpwPBapFA(byte[] P_0, int P_1, int P_2 = 0)
	{
		return UOUfqziYypxNlnoFLKtIkdaZRaoiA(P_0, P_1, null, P_2);
	}

	public unsafe int gYPibHwAMrPBZKwuSiRafkPcNTOf(byte* P_0, int P_1, out object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		BByaBcaGEnhKTnVLEXnzhjdibjeV bByaBcaGEnhKTnVLEXnzhjdibjeV = GeKhKDQSqBAXSAnRoIBmSdjYGEXU(false);
		if (bByaBcaGEnhKTnVLEXnzhjdibjeV == null)
		{
			P_2 = null;
			return -1;
		}
		if (P_1 < bByaBcaGEnhKTnVLEXnzhjdibjeV.ygSqnvHznsnamdgWNyajGLldjodf)
		{
			Logger.LogError("The buffer is too small to hold the data. Call PeekDataLength before calling Peek to get the data length.", requiredThreadSafety: true);
			P_2 = null;
			return -1;
		}
		int num = UGWJCGdKsTDVYxdGVnRecfcGjCkdA.jSDnwjCvpKieGEDclVJFpqrKdHuD(P_0, P_1, bByaBcaGEnhKTnVLEXnzhjdibjeV.ygSqnvHznsnamdgWNyajGLldjodf, bByaBcaGEnhKTnVLEXnzhjdibjeV.ePaqftVougQUIHAIWbXFdwQakrDaA);
		if (num != bByaBcaGEnhKTnVLEXnzhjdibjeV.ygSqnvHznsnamdgWNyajGLldjodf)
		{
			Logger.LogError("Failure reading data from buffer!", requiredThreadSafety: true);
			num = 0;
			P_2 = null;
			return -1;
		}
		P_2 = bByaBcaGEnhKTnVLEXnzhjdibjeV.PUqtkegAkhiSnUxeDlZeBLYcejnk;
		return num;
	}

	public unsafe int mLGKeNCnpXnHRjtGKEPmIyOXszSl(byte* P_0, int P_1)
	{
		object obj;
		return gYPibHwAMrPBZKwuSiRafkPcNTOf(P_0, P_1, out obj);
	}

	public unsafe int wbGXrfqWmUiXuELqmanFucANPWZu(IntPtr P_0, int P_1, out object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		return gYPibHwAMrPBZKwuSiRafkPcNTOf((byte*)(void*)P_0, P_1, out P_2);
	}

	public int SmRYYNeZMwFrghYwquVHgqjpCDko(IntPtr P_0, int P_1)
	{
		object obj;
		return wbGXrfqWmUiXuELqmanFucANPWZu(P_0, P_1, out obj);
	}

	public unsafe int mWAAYKKYrafYasMquitQpumArcyw(byte[] P_0, out object P_1)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			P_1 = null;
			return -1;
		}
		fixed (byte* ptr = P_0)
		{
			return gYPibHwAMrPBZKwuSiRafkPcNTOf(ptr, P_0.Length, out P_1);
		}
	}

	public int AcLKFlKBtBCNXzMQzGjkByIGsbaGA(byte[] P_0)
	{
		object obj;
		return mWAAYKKYrafYasMquitQpumArcyw(P_0, out obj);
	}

	public int mNUQFhWxaLXuPNxqNlSmmfEIourE()
	{
		return GeKhKDQSqBAXSAnRoIBmSdjYGEXU(false)?.ygSqnvHznsnamdgWNyajGLldjodf ?? (-1);
	}

	public unsafe int kJfgzYdryzOAmykQqLFihGrkwhyAA(byte* P_0, int P_1, out object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		BByaBcaGEnhKTnVLEXnzhjdibjeV bByaBcaGEnhKTnVLEXnzhjdibjeV = GeKhKDQSqBAXSAnRoIBmSdjYGEXU(true);
		if (bByaBcaGEnhKTnVLEXnzhjdibjeV == null)
		{
			P_2 = null;
			return -1;
		}
		if (P_1 < bByaBcaGEnhKTnVLEXnzhjdibjeV.ygSqnvHznsnamdgWNyajGLldjodf)
		{
			Logger.LogError("The buffer is too small to hold the data. Call PeekDataLength before calling Dequeue to get the data length.", requiredThreadSafety: true);
			P_2 = null;
			QbVyztlXyrUkXibJHjcHNOhyesoIA(bByaBcaGEnhKTnVLEXnzhjdibjeV, true);
			return -1;
		}
		int num = UGWJCGdKsTDVYxdGVnRecfcGjCkdA.jSDnwjCvpKieGEDclVJFpqrKdHuD(P_0, P_1, bByaBcaGEnhKTnVLEXnzhjdibjeV.ygSqnvHznsnamdgWNyajGLldjodf, bByaBcaGEnhKTnVLEXnzhjdibjeV.ePaqftVougQUIHAIWbXFdwQakrDaA);
		if (num != bByaBcaGEnhKTnVLEXnzhjdibjeV.ygSqnvHznsnamdgWNyajGLldjodf)
		{
			Logger.LogError("Failure reading data from buffer!", requiredThreadSafety: true);
			P_2 = null;
			QbVyztlXyrUkXibJHjcHNOhyesoIA(bByaBcaGEnhKTnVLEXnzhjdibjeV, true);
			return -1;
		}
		P_2 = bByaBcaGEnhKTnVLEXnzhjdibjeV.PUqtkegAkhiSnUxeDlZeBLYcejnk;
		QbVyztlXyrUkXibJHjcHNOhyesoIA(bByaBcaGEnhKTnVLEXnzhjdibjeV, false);
		return num;
	}

	public unsafe int SHmQWnoZFApgcTtpqKltEZMrUjVp(byte* P_0, int P_1)
	{
		object obj;
		return kJfgzYdryzOAmykQqLFihGrkwhyAA(P_0, P_1, out obj);
	}

	public unsafe int GoApBuAzXLRQSmVOdfaifuwdXPHh(IntPtr P_0, int P_1, out object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		return kJfgzYdryzOAmykQqLFihGrkwhyAA((byte*)(void*)P_0, P_1, out P_2);
	}

	public int jhBZovxJWAaPsTZYIApbHrjUQbnP(IntPtr P_0, int P_1)
	{
		object obj;
		return GoApBuAzXLRQSmVOdfaifuwdXPHh(P_0, P_1, out obj);
	}

	public unsafe int OqlgtXAaimnejfypyhSJCEVSpRPq(byte[] P_0, out object P_1)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			P_1 = null;
			return -1;
		}
		fixed (byte* ptr = P_0)
		{
			return kJfgzYdryzOAmykQqLFihGrkwhyAA(ptr, P_0.Length, out P_1);
		}
	}

	public int ShVcquYAMsiSdWGGayUQYKBdaAIr(byte[] P_0)
	{
		object obj;
		return OqlgtXAaimnejfypyhSJCEVSpRPq(P_0, out obj);
	}

	public void qEyDTRbuGTMSLONPIPejpvwBmhxqA()
	{
		UGWJCGdKsTDVYxdGVnRecfcGjCkdA.vkbtvmjRQiSiyCByyEpZLCBSoUQN();
		while (XlHPcfwPsVbQOICwSmPaGUtcLNUlc.Count > 0)
		{
			QbVyztlXyrUkXibJHjcHNOhyesoIA(XlHPcfwPsVbQOICwSmPaGUtcLNUlc.Dequeue(), true);
		}
	}

	private BByaBcaGEnhKTnVLEXnzhjdibjeV GeKhKDQSqBAXSAnRoIBmSdjYGEXU(bool P_0)
	{
		while (XlHPcfwPsVbQOICwSmPaGUtcLNUlc.Count > 0)
		{
			BByaBcaGEnhKTnVLEXnzhjdibjeV bByaBcaGEnhKTnVLEXnzhjdibjeV = (P_0 ? XlHPcfwPsVbQOICwSmPaGUtcLNUlc.Dequeue() : XlHPcfwPsVbQOICwSmPaGUtcLNUlc.Peek());
			if (UGWJCGdKsTDVYxdGVnRecfcGjCkdA.AHQaXMbrBxwycalCqyOnNbLxeyDf(bByaBcaGEnhKTnVLEXnzhjdibjeV.ePaqftVougQUIHAIWbXFdwQakrDaA, bByaBcaGEnhKTnVLEXnzhjdibjeV.TKWLuasczAuGbrotmVSGJXdmhmpO))
			{
				return bByaBcaGEnhKTnVLEXnzhjdibjeV;
			}
			if (!P_0)
			{
				bByaBcaGEnhKTnVLEXnzhjdibjeV = XlHPcfwPsVbQOICwSmPaGUtcLNUlc.Dequeue();
			}
			QbVyztlXyrUkXibJHjcHNOhyesoIA(bByaBcaGEnhKTnVLEXnzhjdibjeV, true);
		}
		return null;
	}

	private bool GECdROEssMrvDGhRkLTVXgTKXWNG()
	{
		return GeKhKDQSqBAXSAnRoIBmSdjYGEXU(false) != null;
	}

	private void QbVyztlXyrUkXibJHjcHNOhyesoIA(BByaBcaGEnhKTnVLEXnzhjdibjeV P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1 && bNKMJZTJzDEDMWTevcXiHSMegyDHA != null && P_0.PUqtkegAkhiSnUxeDlZeBLYcejnk != null)
			{
				bNKMJZTJzDEDMWTevcXiHSMegyDHA(P_0.PUqtkegAkhiSnUxeDlZeBLYcejnk);
			}
			iolABhkiKElAyEHGThXiOYfQCKPA.Return(P_0);
		}
	}

	public void Dispose()
	{
		rfDmahEeLfYUIZJgAJjMBAeDIwtuA(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void SXEtSRdDkdloDhavnDLhfatUEfphA()
	{
		try
		{
			rfDmahEeLfYUIZJgAJjMBAeDIwtuA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected void rfDmahEeLfYUIZJgAJjMBAeDIwtuA(bool P_0)
	{
		if (CPjcPjIzukXgkSBJohUcmojeuxOi)
		{
			return;
		}
		if (P_0)
		{
			qEyDTRbuGTMSLONPIPejpvwBmhxqA();
			if (UGWJCGdKsTDVYxdGVnRecfcGjCkdA != null)
			{
				UGWJCGdKsTDVYxdGVnRecfcGjCkdA.Dispose();
			}
		}
		CPjcPjIzukXgkSBJohUcmojeuxOi = true;
	}

	public static bool mygIHJelCCfLrlfkBhOUuRgzrlwc(RvwroizoUjcbyrJrShXDOpgYwyRP P_0, RvwroizoUjcbyrJrShXDOpgYwyRP P_1)
	{
		if (P_0 == null || P_1 == null)
		{
			return false;
		}
		MiscTools.Swap(ref P_0.UGWJCGdKsTDVYxdGVnRecfcGjCkdA, ref P_1.UGWJCGdKsTDVYxdGVnRecfcGjCkdA);
		MiscTools.Swap(ref P_0.iolABhkiKElAyEHGThXiOYfQCKPA, ref P_1.iolABhkiKElAyEHGThXiOYfQCKPA);
		MiscTools.Swap(ref P_0.XlHPcfwPsVbQOICwSmPaGUtcLNUlc, ref P_1.XlHPcfwPsVbQOICwSmPaGUtcLNUlc);
		return true;
	}
}
