using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal class eUdwdmCYUQDPVijJeOlJWyjwVbMu : IDisposable
{
	private class yvXgrVenaxSDAiNFVXFBBdcYkpEVA
	{
		public int BETeNIDDJXpqLnbINANlSidXaUBJ;

		public int MjlfOHCqHCxSEEcyLojwQICwQkyr;

		public uint TRrEaxmUruaXDDftoNnUCsVDSzJwb;

		public object pkWwRyOzQQtHxquwidxfzcMWIOMBA;

		public void NUzFOceieRtYgUBucdKscULgKGluB(int P_0, int P_1, uint P_2, object P_3)
		{
			BETeNIDDJXpqLnbINANlSidXaUBJ = P_0;
			MjlfOHCqHCxSEEcyLojwQICwQkyr = P_1;
			TRrEaxmUruaXDDftoNnUCsVDSzJwb = P_2;
			pkWwRyOzQQtHxquwidxfzcMWIOMBA = P_3;
		}

		public void PNnwosyJbZAkbwObisgdtMytZJol()
		{
			pkWwRyOzQQtHxquwidxfzcMWIOMBA = null;
		}
	}

	[Serializable]
	private sealed class GWqJvhgLFcMxswqXAUpvNphSfmvc
	{
		public static readonly GWqJvhgLFcMxswqXAUpvNphSfmvc _003C_003E9 = new GWqJvhgLFcMxswqXAUpvNphSfmvc();

		public static Func<yvXgrVenaxSDAiNFVXFBBdcYkpEVA> _003C_003E9__6_0;

		public static Action<yvXgrVenaxSDAiNFVXFBBdcYkpEVA> _003C_003E9__6_1;

		internal yvXgrVenaxSDAiNFVXFBBdcYkpEVA dtdiLfZkiWLxcRnuHFlBOSXLaAzM()
		{
			return new yvXgrVenaxSDAiNFVXFBBdcYkpEVA();
		}

		internal void WesCQIeOxXfvHObDJKMtoMqmOcPhb(yvXgrVenaxSDAiNFVXFBBdcYkpEVA P_0)
		{
			P_0.PNnwosyJbZAkbwObisgdtMytZJol();
		}
	}

	private xVZwRfIZmhFLiBymkMcWQqrSZgoh pshxLsVBaxPobdRQOPmmlqHPIgYt;

	private ObjectPool<yvXgrVenaxSDAiNFVXFBBdcYkpEVA> IyGJFiXsYFEHuBdliJOJPMvoYBUD;

	private Queue<yvXgrVenaxSDAiNFVXFBBdcYkpEVA> nAkAKpJpQlRxvVdsSchgVhAcluTS;

	private Action<object> cLnjDckmIWixjRcnYzHyHWxsQOGH;

	private bool TExNvhkEWsBWipIUjadCDaTpNNDG;

	public bool KYitJOHmEbUhxpDUwWaAHlIlPRzE => AmMfhOhLouNUEgjzSftMQxUawPnS();

	public eUdwdmCYUQDPVijJeOlJWyjwVbMu(int P_0, int P_1, Action<object> P_2 = null)
	{
		if (P_0 <= 0)
		{
			throw new ArgumentOutOfRangeException("capacity");
		}
		pshxLsVBaxPobdRQOPmmlqHPIgYt = new xVZwRfIZmhFLiBymkMcWQqrSZgoh(P_0);
		IyGJFiXsYFEHuBdliJOJPMvoYBUD = new ObjectPool<yvXgrVenaxSDAiNFVXFBBdcYkpEVA>(P_1, GWqJvhgLFcMxswqXAUpvNphSfmvc._003C_003E9.dtdiLfZkiWLxcRnuHFlBOSXLaAzM, GWqJvhgLFcMxswqXAUpvNphSfmvc._003C_003E9.WesCQIeOxXfvHObDJKMtoMqmOcPhb);
		nAkAKpJpQlRxvVdsSchgVhAcluTS = new Queue<yvXgrVenaxSDAiNFVXFBBdcYkpEVA>(P_1);
		cLnjDckmIWixjRcnYzHyHWxsQOGH = P_2;
	}

	public unsafe bool mPdlIFqjoxqpXUXmLokOkbcVfbGkA(byte* P_0, int P_1, object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return false;
		}
		if (pshxLsVBaxPobdRQOPmmlqHPIgYt.EGngQqDBRXlpYmNfKVeBqXohueYWA(P_0, P_1, P_1, out var num, out var num2) < P_1)
		{
			return false;
		}
		yvXgrVenaxSDAiNFVXFBBdcYkpEVA yvXgrVenaxSDAiNFVXFBBdcYkpEVA2 = IyGJFiXsYFEHuBdliJOJPMvoYBUD.Get();
		yvXgrVenaxSDAiNFVXFBBdcYkpEVA2.NUzFOceieRtYgUBucdKscULgKGluB(num, P_1, num2, P_2);
		nAkAKpJpQlRxvVdsSchgVhAcluTS.Enqueue(yvXgrVenaxSDAiNFVXFBBdcYkpEVA2);
		return true;
	}

	public unsafe bool mPdlIFqjoxqpXUXmLokOkbcVfbGkA(byte* P_0, int P_1)
	{
		return mPdlIFqjoxqpXUXmLokOkbcVfbGkA(P_0, P_1, null);
	}

	public unsafe bool mPdlIFqjoxqpXUXmLokOkbcVfbGkA(IntPtr P_0, int P_1, object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			return false;
		}
		return mPdlIFqjoxqpXUXmLokOkbcVfbGkA((byte*)(void*)P_0, P_1, P_2);
	}

	public bool mPdlIFqjoxqpXUXmLokOkbcVfbGkA(IntPtr P_0, int P_1)
	{
		return mPdlIFqjoxqpXUXmLokOkbcVfbGkA(P_0, P_1, null);
	}

	public unsafe bool mPdlIFqjoxqpXUXmLokOkbcVfbGkA(byte[] P_0, int P_1, object P_2, int P_3 = 0)
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
			return mPdlIFqjoxqpXUXmLokOkbcVfbGkA(ptr2, P_1, P_2);
		}
	}

	public bool mPdlIFqjoxqpXUXmLokOkbcVfbGkA(byte[] P_0, int P_1, int P_2 = 0)
	{
		return mPdlIFqjoxqpXUXmLokOkbcVfbGkA(P_0, P_1, null, P_2);
	}

	public unsafe int FdPABvgnOpXcjKQwUERAAVHYHfud(byte* P_0, int P_1, out object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		yvXgrVenaxSDAiNFVXFBBdcYkpEVA yvXgrVenaxSDAiNFVXFBBdcYkpEVA2 = nQBCiJkZqmtkYsBDHsAMmveujWuH(false);
		if (yvXgrVenaxSDAiNFVXFBBdcYkpEVA2 == null)
		{
			P_2 = null;
			return -1;
		}
		if (P_1 < yvXgrVenaxSDAiNFVXFBBdcYkpEVA2.MjlfOHCqHCxSEEcyLojwQICwQkyr)
		{
			Logger.LogError("The buffer is too small to hold the data. Call PeekDataLength before calling Peek to get the data length.", requiredThreadSafety: true);
			P_2 = null;
			return -1;
		}
		int num = pshxLsVBaxPobdRQOPmmlqHPIgYt.IoTsQYUEWkgltCZtieFiMPWUeNYUA(P_0, P_1, yvXgrVenaxSDAiNFVXFBBdcYkpEVA2.MjlfOHCqHCxSEEcyLojwQICwQkyr, yvXgrVenaxSDAiNFVXFBBdcYkpEVA2.BETeNIDDJXpqLnbINANlSidXaUBJ);
		if (num != yvXgrVenaxSDAiNFVXFBBdcYkpEVA2.MjlfOHCqHCxSEEcyLojwQICwQkyr)
		{
			Logger.LogError("Failure reading data from buffer!", requiredThreadSafety: true);
			num = 0;
			P_2 = null;
			return -1;
		}
		P_2 = yvXgrVenaxSDAiNFVXFBBdcYkpEVA2.pkWwRyOzQQtHxquwidxfzcMWIOMBA;
		return num;
	}

	public unsafe int FdPABvgnOpXcjKQwUERAAVHYHfud(byte* P_0, int P_1)
	{
		object obj;
		return FdPABvgnOpXcjKQwUERAAVHYHfud(P_0, P_1, out obj);
	}

	public unsafe int FdPABvgnOpXcjKQwUERAAVHYHfud(IntPtr P_0, int P_1, out object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		return FdPABvgnOpXcjKQwUERAAVHYHfud((byte*)(void*)P_0, P_1, out P_2);
	}

	public int FdPABvgnOpXcjKQwUERAAVHYHfud(IntPtr P_0, int P_1)
	{
		object obj;
		return FdPABvgnOpXcjKQwUERAAVHYHfud(P_0, P_1, out obj);
	}

	public unsafe int FdPABvgnOpXcjKQwUERAAVHYHfud(byte[] P_0, out object P_1)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			P_1 = null;
			return -1;
		}
		fixed (byte* ptr = P_0)
		{
			return FdPABvgnOpXcjKQwUERAAVHYHfud(ptr, P_0.Length, out P_1);
		}
	}

	public int FdPABvgnOpXcjKQwUERAAVHYHfud(byte[] P_0)
	{
		object obj;
		return FdPABvgnOpXcjKQwUERAAVHYHfud(P_0, out obj);
	}

	public int seFhqZpXhOeMLCTjSdSPdKqEwYJR()
	{
		return nQBCiJkZqmtkYsBDHsAMmveujWuH(false)?.MjlfOHCqHCxSEEcyLojwQICwQkyr ?? (-1);
	}

	public unsafe int lOcVIUimQiqZOCqjxBvLoOJLdVhI(byte* P_0, int P_1, out object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		yvXgrVenaxSDAiNFVXFBBdcYkpEVA yvXgrVenaxSDAiNFVXFBBdcYkpEVA2 = nQBCiJkZqmtkYsBDHsAMmveujWuH(true);
		if (yvXgrVenaxSDAiNFVXFBBdcYkpEVA2 == null)
		{
			P_2 = null;
			return -1;
		}
		if (P_1 < yvXgrVenaxSDAiNFVXFBBdcYkpEVA2.MjlfOHCqHCxSEEcyLojwQICwQkyr)
		{
			Logger.LogError("The buffer is too small to hold the data. Call PeekDataLength before calling Dequeue to get the data length.", requiredThreadSafety: true);
			P_2 = null;
			QcdecYxXweyrsuYwyneIGAAuVuxT(yvXgrVenaxSDAiNFVXFBBdcYkpEVA2, true);
			return -1;
		}
		int num = pshxLsVBaxPobdRQOPmmlqHPIgYt.IoTsQYUEWkgltCZtieFiMPWUeNYUA(P_0, P_1, yvXgrVenaxSDAiNFVXFBBdcYkpEVA2.MjlfOHCqHCxSEEcyLojwQICwQkyr, yvXgrVenaxSDAiNFVXFBBdcYkpEVA2.BETeNIDDJXpqLnbINANlSidXaUBJ);
		if (num != yvXgrVenaxSDAiNFVXFBBdcYkpEVA2.MjlfOHCqHCxSEEcyLojwQICwQkyr)
		{
			Logger.LogError("Failure reading data from buffer!", requiredThreadSafety: true);
			P_2 = null;
			QcdecYxXweyrsuYwyneIGAAuVuxT(yvXgrVenaxSDAiNFVXFBBdcYkpEVA2, true);
			return -1;
		}
		P_2 = yvXgrVenaxSDAiNFVXFBBdcYkpEVA2.pkWwRyOzQQtHxquwidxfzcMWIOMBA;
		QcdecYxXweyrsuYwyneIGAAuVuxT(yvXgrVenaxSDAiNFVXFBBdcYkpEVA2, false);
		return num;
	}

	public unsafe int lOcVIUimQiqZOCqjxBvLoOJLdVhI(byte* P_0, int P_1)
	{
		object obj;
		return lOcVIUimQiqZOCqjxBvLoOJLdVhI(P_0, P_1, out obj);
	}

	public unsafe int lOcVIUimQiqZOCqjxBvLoOJLdVhI(IntPtr P_0, int P_1, out object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		return lOcVIUimQiqZOCqjxBvLoOJLdVhI((byte*)(void*)P_0, P_1, out P_2);
	}

	public int lOcVIUimQiqZOCqjxBvLoOJLdVhI(IntPtr P_0, int P_1)
	{
		object obj;
		return lOcVIUimQiqZOCqjxBvLoOJLdVhI(P_0, P_1, out obj);
	}

	public unsafe int lOcVIUimQiqZOCqjxBvLoOJLdVhI(byte[] P_0, out object P_1)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			P_1 = null;
			return -1;
		}
		fixed (byte* ptr = P_0)
		{
			return lOcVIUimQiqZOCqjxBvLoOJLdVhI(ptr, P_0.Length, out P_1);
		}
	}

	public int lOcVIUimQiqZOCqjxBvLoOJLdVhI(byte[] P_0)
	{
		object obj;
		return lOcVIUimQiqZOCqjxBvLoOJLdVhI(P_0, out obj);
	}

	public void auNfBUgrkDddzhmMtDVjQBOyzhlCA()
	{
		pshxLsVBaxPobdRQOPmmlqHPIgYt.auNfBUgrkDddzhmMtDVjQBOyzhlCA();
		while (nAkAKpJpQlRxvVdsSchgVhAcluTS.Count > 0)
		{
			QcdecYxXweyrsuYwyneIGAAuVuxT(nAkAKpJpQlRxvVdsSchgVhAcluTS.Dequeue(), true);
		}
	}

	private yvXgrVenaxSDAiNFVXFBBdcYkpEVA nQBCiJkZqmtkYsBDHsAMmveujWuH(bool P_0)
	{
		while (nAkAKpJpQlRxvVdsSchgVhAcluTS.Count > 0)
		{
			yvXgrVenaxSDAiNFVXFBBdcYkpEVA yvXgrVenaxSDAiNFVXFBBdcYkpEVA2 = (P_0 ? nAkAKpJpQlRxvVdsSchgVhAcluTS.Dequeue() : nAkAKpJpQlRxvVdsSchgVhAcluTS.Peek());
			if (pshxLsVBaxPobdRQOPmmlqHPIgYt.RWcjmtEWOihCnICrbgbyOHewqpcW(yvXgrVenaxSDAiNFVXFBBdcYkpEVA2.BETeNIDDJXpqLnbINANlSidXaUBJ, yvXgrVenaxSDAiNFVXFBBdcYkpEVA2.TRrEaxmUruaXDDftoNnUCsVDSzJwb))
			{
				return yvXgrVenaxSDAiNFVXFBBdcYkpEVA2;
			}
			if (!P_0)
			{
				yvXgrVenaxSDAiNFVXFBBdcYkpEVA2 = nAkAKpJpQlRxvVdsSchgVhAcluTS.Dequeue();
			}
			QcdecYxXweyrsuYwyneIGAAuVuxT(yvXgrVenaxSDAiNFVXFBBdcYkpEVA2, true);
		}
		return null;
	}

	private bool AmMfhOhLouNUEgjzSftMQxUawPnS()
	{
		return nQBCiJkZqmtkYsBDHsAMmveujWuH(false) != null;
	}

	private void QcdecYxXweyrsuYwyneIGAAuVuxT(yvXgrVenaxSDAiNFVXFBBdcYkpEVA P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1 && cLnjDckmIWixjRcnYzHyHWxsQOGH != null && P_0.pkWwRyOzQQtHxquwidxfzcMWIOMBA != null)
			{
				cLnjDckmIWixjRcnYzHyHWxsQOGH(P_0.pkWwRyOzQQtHxquwidxfzcMWIOMBA);
			}
			IyGJFiXsYFEHuBdliJOJPMvoYBUD.Return(P_0);
		}
	}

	public void Dispose()
	{
		hIlanWXkrCYfgvCyascUuCUOCBcL(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void jRFgxQCVBGrNmzQBGWfdjtLVACefA()
	{
		try
		{
			hIlanWXkrCYfgvCyascUuCUOCBcL(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected void hIlanWXkrCYfgvCyascUuCUOCBcL(bool P_0)
	{
		if (TExNvhkEWsBWipIUjadCDaTpNNDG)
		{
			return;
		}
		if (P_0)
		{
			auNfBUgrkDddzhmMtDVjQBOyzhlCA();
			if (pshxLsVBaxPobdRQOPmmlqHPIgYt != null)
			{
				pshxLsVBaxPobdRQOPmmlqHPIgYt.Dispose();
			}
		}
		TExNvhkEWsBWipIUjadCDaTpNNDG = true;
	}

	public static bool KHeAMJZNnweDPJocjoKprNkbDjPGA(eUdwdmCYUQDPVijJeOlJWyjwVbMu P_0, eUdwdmCYUQDPVijJeOlJWyjwVbMu P_1)
	{
		if (P_0 == null || P_1 == null)
		{
			return false;
		}
		MiscTools.Swap(ref P_0.pshxLsVBaxPobdRQOPmmlqHPIgYt, ref P_1.pshxLsVBaxPobdRQOPmmlqHPIgYt);
		MiscTools.Swap(ref P_0.IyGJFiXsYFEHuBdliJOJPMvoYBUD, ref P_1.IyGJFiXsYFEHuBdliJOJPMvoYBUD);
		MiscTools.Swap(ref P_0.nAkAKpJpQlRxvVdsSchgVhAcluTS, ref P_1.nAkAKpJpQlRxvVdsSchgVhAcluTS);
		return true;
	}
}
