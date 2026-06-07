using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal class IhzpAyaByaMuzcwQEkKbXPFboblX : IDisposable
{
	private class OgLFUFPNEXLeuJDKtPcduTIPRrlt
	{
		public int PukFLJJZfSGCbGUvnEIgxnQGLopmA;

		public int hjeNJuYLJqeDJCeIUZZTXxvQdjNu;

		public uint AtMAXNxBfGvMnqLrCsFDvOhbbFXBA;

		public object vMgFqfoMwqkWBziLcBOtbzTNPNYL;

		public void JmYowTdKGEJxLnFQCevRTbWRAzAR(int P_0, int P_1, uint P_2, object P_3)
		{
			PukFLJJZfSGCbGUvnEIgxnQGLopmA = P_0;
			hjeNJuYLJqeDJCeIUZZTXxvQdjNu = P_1;
			AtMAXNxBfGvMnqLrCsFDvOhbbFXBA = P_2;
			vMgFqfoMwqkWBziLcBOtbzTNPNYL = P_3;
		}

		public void NyiCFgDkZafiQvjEnfOJNvXQIukN()
		{
			vMgFqfoMwqkWBziLcBOtbzTNPNYL = null;
		}
	}

	[Serializable]
	private sealed class uToaNdYrzYlQKgBxuleXILJVjSDI
	{
		public static readonly uToaNdYrzYlQKgBxuleXILJVjSDI _003C_003E9 = new uToaNdYrzYlQKgBxuleXILJVjSDI();

		public static Func<OgLFUFPNEXLeuJDKtPcduTIPRrlt> _003C_003E9__6_0;

		public static Action<OgLFUFPNEXLeuJDKtPcduTIPRrlt> _003C_003E9__6_1;

		internal OgLFUFPNEXLeuJDKtPcduTIPRrlt UEBydkDsDNOoqEQxIPlErTmqvCOm()
		{
			return new OgLFUFPNEXLeuJDKtPcduTIPRrlt();
		}

		internal void BYffSDbaCYcgINvBFQHmTNKhmaol(OgLFUFPNEXLeuJDKtPcduTIPRrlt P_0)
		{
			P_0.NyiCFgDkZafiQvjEnfOJNvXQIukN();
		}
	}

	private DvHHuxsqxRwcGFxtArJeHIKLKLNU gUwqndIYaWlUwVBGrIlMlQNYShSE;

	private ObjectPool<OgLFUFPNEXLeuJDKtPcduTIPRrlt> xToPQLiVCYVSzojRLVmiwDvIGiRT;

	private Queue<OgLFUFPNEXLeuJDKtPcduTIPRrlt> iIYJbaZnuVFOJfwrZmSZRICwGkSJA;

	private Action<object> AqmdxIHLpryvPMRMJFGnGwJFPaKZB;

	private bool PjMgQrhEwJhohHufzxHVGfLSmXWoA;

	public bool kukzQnPiEzVeIfLVSaMkivAFFRRU => HtLDScjTTlAUThnbfPkKOJzzVRIE();

	public IhzpAyaByaMuzcwQEkKbXPFboblX(int P_0, int P_1, Action<object> P_2 = null)
	{
		if (P_0 <= 0)
		{
			throw new ArgumentOutOfRangeException("capacity");
		}
		gUwqndIYaWlUwVBGrIlMlQNYShSE = new DvHHuxsqxRwcGFxtArJeHIKLKLNU(P_0);
		xToPQLiVCYVSzojRLVmiwDvIGiRT = new ObjectPool<OgLFUFPNEXLeuJDKtPcduTIPRrlt>(P_1, uToaNdYrzYlQKgBxuleXILJVjSDI._003C_003E9.UEBydkDsDNOoqEQxIPlErTmqvCOm, uToaNdYrzYlQKgBxuleXILJVjSDI._003C_003E9.BYffSDbaCYcgINvBFQHmTNKhmaol);
		iIYJbaZnuVFOJfwrZmSZRICwGkSJA = new Queue<OgLFUFPNEXLeuJDKtPcduTIPRrlt>(P_1);
		AqmdxIHLpryvPMRMJFGnGwJFPaKZB = P_2;
	}

	public unsafe bool zkRtETezLMxJVTaxYebSDWLeeUbB(byte* P_0, int P_1, object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return false;
		}
		if (gUwqndIYaWlUwVBGrIlMlQNYShSE.iQIIuAstRkEKsYbQTzGmmzrSZabE(P_0, P_1, P_1, out var num, out var num2) < P_1)
		{
			return false;
		}
		OgLFUFPNEXLeuJDKtPcduTIPRrlt ogLFUFPNEXLeuJDKtPcduTIPRrlt = xToPQLiVCYVSzojRLVmiwDvIGiRT.Get();
		ogLFUFPNEXLeuJDKtPcduTIPRrlt.JmYowTdKGEJxLnFQCevRTbWRAzAR(num, P_1, num2, P_2);
		iIYJbaZnuVFOJfwrZmSZRICwGkSJA.Enqueue(ogLFUFPNEXLeuJDKtPcduTIPRrlt);
		return true;
	}

	public unsafe bool LNMPsAnbrczWpitiNkcMQXHMvUdL(byte* P_0, int P_1)
	{
		return zkRtETezLMxJVTaxYebSDWLeeUbB(P_0, P_1, null);
	}

	public unsafe bool IWmzKmJDJXUqLlKeWMgZxSPURkS(IntPtr P_0, int P_1, object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			return false;
		}
		return zkRtETezLMxJVTaxYebSDWLeeUbB((byte*)(void*)P_0, P_1, P_2);
	}

	public bool vSKDEjaoxFmpHnmQanrXcXwiPjUqB(IntPtr P_0, int P_1)
	{
		return IWmzKmJDJXUqLlKeWMgZxSPURkS(P_0, P_1, null);
	}

	public unsafe bool PuhOdpcACfTSwwfXOGQhElkYQyZe(byte[] P_0, int P_1, object P_2, int P_3 = 0)
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
			return zkRtETezLMxJVTaxYebSDWLeeUbB(ptr2, P_1, P_2);
		}
	}

	public bool xnXSVhfkdDcUmiCJpPuMXnCQEBhkA(byte[] P_0, int P_1, int P_2 = 0)
	{
		return PuhOdpcACfTSwwfXOGQhElkYQyZe(P_0, P_1, null, P_2);
	}

	public unsafe int YQPRlfwgcpkaogZApYZZRtWKjAuj(byte* P_0, int P_1, out object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		OgLFUFPNEXLeuJDKtPcduTIPRrlt ogLFUFPNEXLeuJDKtPcduTIPRrlt = ZmOnLkSQocAUnFWbNrirXBhbcoPy(false);
		if (ogLFUFPNEXLeuJDKtPcduTIPRrlt == null)
		{
			P_2 = null;
			return -1;
		}
		if (P_1 < ogLFUFPNEXLeuJDKtPcduTIPRrlt.hjeNJuYLJqeDJCeIUZZTXxvQdjNu)
		{
			Logger.LogError("The buffer is too small to hold the data. Call PeekDataLength before calling Peek to get the data length.", requiredThreadSafety: true);
			P_2 = null;
			return -1;
		}
		int num = gUwqndIYaWlUwVBGrIlMlQNYShSE.SihYvtUeOhGPxfelfgIcmFrWjQRl(P_0, P_1, ogLFUFPNEXLeuJDKtPcduTIPRrlt.hjeNJuYLJqeDJCeIUZZTXxvQdjNu, ogLFUFPNEXLeuJDKtPcduTIPRrlt.PukFLJJZfSGCbGUvnEIgxnQGLopmA);
		if (num != ogLFUFPNEXLeuJDKtPcduTIPRrlt.hjeNJuYLJqeDJCeIUZZTXxvQdjNu)
		{
			Logger.LogError("Failure reading data from buffer!", requiredThreadSafety: true);
			num = 0;
			P_2 = null;
			return -1;
		}
		P_2 = ogLFUFPNEXLeuJDKtPcduTIPRrlt.vMgFqfoMwqkWBziLcBOtbzTNPNYL;
		return num;
	}

	public unsafe int cOaPsBccNKWelSPbDbnDfjURVOW(byte* P_0, int P_1)
	{
		object obj;
		return YQPRlfwgcpkaogZApYZZRtWKjAuj(P_0, P_1, out obj);
	}

	public unsafe int btsbkUHMuwXgPnSxgCWVhJCMnoDc(IntPtr P_0, int P_1, out object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		return YQPRlfwgcpkaogZApYZZRtWKjAuj((byte*)(void*)P_0, P_1, out P_2);
	}

	public int LCEINSTCfzWwPjhyYreUcbgZkBEq(IntPtr P_0, int P_1)
	{
		object obj;
		return btsbkUHMuwXgPnSxgCWVhJCMnoDc(P_0, P_1, out obj);
	}

	public unsafe int sqlOkPzezEpFlYFKUgHpcKhRvvHW(byte[] P_0, out object P_1)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			P_1 = null;
			return -1;
		}
		fixed (byte* ptr = P_0)
		{
			return YQPRlfwgcpkaogZApYZZRtWKjAuj(ptr, P_0.Length, out P_1);
		}
	}

	public int AcHZwGBgnXpVvDVxYoObIXHuihci(byte[] P_0)
	{
		object obj;
		return sqlOkPzezEpFlYFKUgHpcKhRvvHW(P_0, out obj);
	}

	public int VToVMRhzIlbRTVoNLyyYfTuQsPV()
	{
		return ZmOnLkSQocAUnFWbNrirXBhbcoPy(false)?.hjeNJuYLJqeDJCeIUZZTXxvQdjNu ?? (-1);
	}

	public unsafe int FoejAhhBofAaBCHuxpsPAjnrwPDN(byte* P_0, int P_1, out object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		OgLFUFPNEXLeuJDKtPcduTIPRrlt ogLFUFPNEXLeuJDKtPcduTIPRrlt = ZmOnLkSQocAUnFWbNrirXBhbcoPy(true);
		if (ogLFUFPNEXLeuJDKtPcduTIPRrlt == null)
		{
			P_2 = null;
			return -1;
		}
		if (P_1 < ogLFUFPNEXLeuJDKtPcduTIPRrlt.hjeNJuYLJqeDJCeIUZZTXxvQdjNu)
		{
			Logger.LogError("The buffer is too small to hold the data. Call PeekDataLength before calling Dequeue to get the data length.", requiredThreadSafety: true);
			P_2 = null;
			WwYnMUwTQmLtcZCxNoRjcCdYlrWt(ogLFUFPNEXLeuJDKtPcduTIPRrlt, true);
			return -1;
		}
		int num = gUwqndIYaWlUwVBGrIlMlQNYShSE.SihYvtUeOhGPxfelfgIcmFrWjQRl(P_0, P_1, ogLFUFPNEXLeuJDKtPcduTIPRrlt.hjeNJuYLJqeDJCeIUZZTXxvQdjNu, ogLFUFPNEXLeuJDKtPcduTIPRrlt.PukFLJJZfSGCbGUvnEIgxnQGLopmA);
		if (num != ogLFUFPNEXLeuJDKtPcduTIPRrlt.hjeNJuYLJqeDJCeIUZZTXxvQdjNu)
		{
			Logger.LogError("Failure reading data from buffer!", requiredThreadSafety: true);
			P_2 = null;
			WwYnMUwTQmLtcZCxNoRjcCdYlrWt(ogLFUFPNEXLeuJDKtPcduTIPRrlt, true);
			return -1;
		}
		P_2 = ogLFUFPNEXLeuJDKtPcduTIPRrlt.vMgFqfoMwqkWBziLcBOtbzTNPNYL;
		WwYnMUwTQmLtcZCxNoRjcCdYlrWt(ogLFUFPNEXLeuJDKtPcduTIPRrlt, false);
		return num;
	}

	public unsafe int WGWtMaNmAvjFZCLdHmAMAiNBMqIKc(byte* P_0, int P_1)
	{
		object obj;
		return FoejAhhBofAaBCHuxpsPAjnrwPDN(P_0, P_1, out obj);
	}

	public unsafe int cTalKyCDlqaAVfJTSIGKrndNYvNQ(IntPtr P_0, int P_1, out object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		return FoejAhhBofAaBCHuxpsPAjnrwPDN((byte*)(void*)P_0, P_1, out P_2);
	}

	public int qYCLUygazrXiQeaQXeDDKpqFrOzN(IntPtr P_0, int P_1)
	{
		object obj;
		return cTalKyCDlqaAVfJTSIGKrndNYvNQ(P_0, P_1, out obj);
	}

	public unsafe int jdSQbwySXdelZZXPSKLensvPUHlu(byte[] P_0, out object P_1)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			P_1 = null;
			return -1;
		}
		fixed (byte* ptr = P_0)
		{
			return FoejAhhBofAaBCHuxpsPAjnrwPDN(ptr, P_0.Length, out P_1);
		}
	}

	public int ZjVHGjtVgztEbkWsvTFjcnziqNvJ(byte[] P_0)
	{
		object obj;
		return jdSQbwySXdelZZXPSKLensvPUHlu(P_0, out obj);
	}

	public void AXvxpvUBEvsxWKhEGiKlBxTVlMBn()
	{
		gUwqndIYaWlUwVBGrIlMlQNYShSE.XYlsKNrPJSlWtnkDYuKCBYklIikD();
		while (iIYJbaZnuVFOJfwrZmSZRICwGkSJA.Count > 0)
		{
			WwYnMUwTQmLtcZCxNoRjcCdYlrWt(iIYJbaZnuVFOJfwrZmSZRICwGkSJA.Dequeue(), true);
		}
	}

	private OgLFUFPNEXLeuJDKtPcduTIPRrlt ZmOnLkSQocAUnFWbNrirXBhbcoPy(bool P_0)
	{
		while (iIYJbaZnuVFOJfwrZmSZRICwGkSJA.Count > 0)
		{
			OgLFUFPNEXLeuJDKtPcduTIPRrlt ogLFUFPNEXLeuJDKtPcduTIPRrlt = (P_0 ? iIYJbaZnuVFOJfwrZmSZRICwGkSJA.Dequeue() : iIYJbaZnuVFOJfwrZmSZRICwGkSJA.Peek());
			if (gUwqndIYaWlUwVBGrIlMlQNYShSE.LDVWKhoizDDTLUyVwqjpNzdyZBuH(ogLFUFPNEXLeuJDKtPcduTIPRrlt.PukFLJJZfSGCbGUvnEIgxnQGLopmA, ogLFUFPNEXLeuJDKtPcduTIPRrlt.AtMAXNxBfGvMnqLrCsFDvOhbbFXBA))
			{
				return ogLFUFPNEXLeuJDKtPcduTIPRrlt;
			}
			if (!P_0)
			{
				ogLFUFPNEXLeuJDKtPcduTIPRrlt = iIYJbaZnuVFOJfwrZmSZRICwGkSJA.Dequeue();
			}
			WwYnMUwTQmLtcZCxNoRjcCdYlrWt(ogLFUFPNEXLeuJDKtPcduTIPRrlt, true);
		}
		return null;
	}

	private bool HtLDScjTTlAUThnbfPkKOJzzVRIE()
	{
		return ZmOnLkSQocAUnFWbNrirXBhbcoPy(false) != null;
	}

	private void WwYnMUwTQmLtcZCxNoRjcCdYlrWt(OgLFUFPNEXLeuJDKtPcduTIPRrlt P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1 && AqmdxIHLpryvPMRMJFGnGwJFPaKZB != null && P_0.vMgFqfoMwqkWBziLcBOtbzTNPNYL != null)
			{
				AqmdxIHLpryvPMRMJFGnGwJFPaKZB(P_0.vMgFqfoMwqkWBziLcBOtbzTNPNYL);
			}
			xToPQLiVCYVSzojRLVmiwDvIGiRT.Return(P_0);
		}
	}

	public void Dispose()
	{
		kRQyOJDbdzGsMwWCUmktjptlnfif(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void wVjxGGBbBHshOWiozNCEpuoOkFWt()
	{
		try
		{
			kRQyOJDbdzGsMwWCUmktjptlnfif(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected void kRQyOJDbdzGsMwWCUmktjptlnfif(bool P_0)
	{
		if (PjMgQrhEwJhohHufzxHVGfLSmXWoA)
		{
			return;
		}
		if (P_0)
		{
			AXvxpvUBEvsxWKhEGiKlBxTVlMBn();
			if (gUwqndIYaWlUwVBGrIlMlQNYShSE != null)
			{
				gUwqndIYaWlUwVBGrIlMlQNYShSE.Dispose();
			}
		}
		PjMgQrhEwJhohHufzxHVGfLSmXWoA = true;
	}

	public static bool MMaekBghnoFrYAdgcfwZtniFeXKkA(IhzpAyaByaMuzcwQEkKbXPFboblX P_0, IhzpAyaByaMuzcwQEkKbXPFboblX P_1)
	{
		if (P_0 == null || P_1 == null)
		{
			return false;
		}
		MiscTools.Swap(ref P_0.gUwqndIYaWlUwVBGrIlMlQNYShSE, ref P_1.gUwqndIYaWlUwVBGrIlMlQNYShSE);
		MiscTools.Swap(ref P_0.xToPQLiVCYVSzojRLVmiwDvIGiRT, ref P_1.xToPQLiVCYVSzojRLVmiwDvIGiRT);
		MiscTools.Swap(ref P_0.iIYJbaZnuVFOJfwrZmSZRICwGkSJA, ref P_1.iIYJbaZnuVFOJfwrZmSZRICwGkSJA);
		return true;
	}
}
