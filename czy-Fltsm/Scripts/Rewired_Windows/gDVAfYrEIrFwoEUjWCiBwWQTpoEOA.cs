using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal class gDVAfYrEIrFwoEUjWCiBwWQTpoEOA : IDisposable
{
	private class aXJrSGqaSllNVIjZEoYbzxDxtuvL
	{
		public int JMZuuVFWgiFzQaDYWuEBkjgpvKII;

		public int JgpFzXXipiAykEGKNiRdqYHimzogA;

		public uint uevbzIcJvOkHpMGlyntMVlHfKwwO;

		public object oSTNoUsqqvpTvbBaRoeyFvglcsmu;

		public void nnldYvjeIgTlpvVfSKoytvOWRVKJ(int P_0, int P_1, uint P_2, object P_3)
		{
			JMZuuVFWgiFzQaDYWuEBkjgpvKII = P_0;
			JgpFzXXipiAykEGKNiRdqYHimzogA = P_1;
			uevbzIcJvOkHpMGlyntMVlHfKwwO = P_2;
			oSTNoUsqqvpTvbBaRoeyFvglcsmu = P_3;
		}

		public void qZkLxDnBNIuwvLfJTpCpxvNBqVbS()
		{
			oSTNoUsqqvpTvbBaRoeyFvglcsmu = null;
		}
	}

	[Serializable]
	private sealed class PBDKgZDpWMrNxQDbDLBGebyTbBWD
	{
		public static readonly PBDKgZDpWMrNxQDbDLBGebyTbBWD _003C_003E9 = new PBDKgZDpWMrNxQDbDLBGebyTbBWD();

		public static Func<aXJrSGqaSllNVIjZEoYbzxDxtuvL> _003C_003E9__6_0;

		public static Action<aXJrSGqaSllNVIjZEoYbzxDxtuvL> _003C_003E9__6_1;

		internal aXJrSGqaSllNVIjZEoYbzxDxtuvL fDRamNTPALaRKMCDndDvuTNvedQgA()
		{
			return new aXJrSGqaSllNVIjZEoYbzxDxtuvL();
		}

		internal void nTjTttllawpcpgIZjnOvPCxeanGn(aXJrSGqaSllNVIjZEoYbzxDxtuvL P_0)
		{
			P_0.qZkLxDnBNIuwvLfJTpCpxvNBqVbS();
		}
	}

	private EVrvaKNCRqfFbcZrfjDphsNdAVkW tfpFFmnQkLMyMGOVVwbmwIEBAArL;

	private ObjectPool<aXJrSGqaSllNVIjZEoYbzxDxtuvL> ZWLxRjsfyISoGzaXOdQTiQmimWTBb;

	private Queue<aXJrSGqaSllNVIjZEoYbzxDxtuvL> ePgCrPsngRHVYrEiIvoiEcPSgFVdA;

	private Action<object> ABvdKjJKbVFUAxnwxteuDvmxfgSX;

	private bool xICepPfEbyNOcavBiuUqBqNvtyVW;

	public bool uUBfnCAjxzhLoZdDUbXwVpWlnSUnA => rwrKuuILmOKmRvyByEoJBedBmHWq();

	public gDVAfYrEIrFwoEUjWCiBwWQTpoEOA(int P_0, int P_1, Action<object> P_2 = null)
	{
		if (P_0 <= 0)
		{
			throw new ArgumentOutOfRangeException("capacity");
		}
		tfpFFmnQkLMyMGOVVwbmwIEBAArL = new EVrvaKNCRqfFbcZrfjDphsNdAVkW(P_0);
		ZWLxRjsfyISoGzaXOdQTiQmimWTBb = new ObjectPool<aXJrSGqaSllNVIjZEoYbzxDxtuvL>(P_1, PBDKgZDpWMrNxQDbDLBGebyTbBWD._003C_003E9.fDRamNTPALaRKMCDndDvuTNvedQgA, PBDKgZDpWMrNxQDbDLBGebyTbBWD._003C_003E9.nTjTttllawpcpgIZjnOvPCxeanGn);
		ePgCrPsngRHVYrEiIvoiEcPSgFVdA = new Queue<aXJrSGqaSllNVIjZEoYbzxDxtuvL>(P_1);
		ABvdKjJKbVFUAxnwxteuDvmxfgSX = P_2;
	}

	public unsafe bool hJYCCYELxwdQtLENCPaKOvkgPKHX(byte* P_0, int P_1, object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return false;
		}
		if (tfpFFmnQkLMyMGOVVwbmwIEBAArL.gjslUCCEnAMqHuNZMmckdimSLPxl(P_0, P_1, P_1, out var num, out var num2) < P_1)
		{
			return false;
		}
		aXJrSGqaSllNVIjZEoYbzxDxtuvL aXJrSGqaSllNVIjZEoYbzxDxtuvL2 = ZWLxRjsfyISoGzaXOdQTiQmimWTBb.Get();
		aXJrSGqaSllNVIjZEoYbzxDxtuvL2.nnldYvjeIgTlpvVfSKoytvOWRVKJ(num, P_1, num2, P_2);
		ePgCrPsngRHVYrEiIvoiEcPSgFVdA.Enqueue(aXJrSGqaSllNVIjZEoYbzxDxtuvL2);
		return true;
	}

	public unsafe bool SPccsucwJMZigiLXUKJFHEGlqLHbA(byte* P_0, int P_1)
	{
		return hJYCCYELxwdQtLENCPaKOvkgPKHX(P_0, P_1, null);
	}

	public unsafe bool sUOYFESGFnFksWHCrIHuAfisfCGTA(IntPtr P_0, int P_1, object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			return false;
		}
		return hJYCCYELxwdQtLENCPaKOvkgPKHX((byte*)(void*)P_0, P_1, P_2);
	}

	public bool xQfTJoWfSRKcEKJdyDsxZQPVfmkdA(IntPtr P_0, int P_1)
	{
		return sUOYFESGFnFksWHCrIHuAfisfCGTA(P_0, P_1, null);
	}

	public unsafe bool rNfpxHUmCnCztLLMHWQxzGcUaavE(byte[] P_0, int P_1, object P_2, int P_3 = 0)
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
			return hJYCCYELxwdQtLENCPaKOvkgPKHX(ptr2, P_1, P_2);
		}
	}

	public bool omzsgNQuybRheVVbCsMzGAScgir(byte[] P_0, int P_1, int P_2 = 0)
	{
		return rNfpxHUmCnCztLLMHWQxzGcUaavE(P_0, P_1, null, P_2);
	}

	public unsafe int LNeavtCsGbYQRplqAlVmzblzKBNXA(byte* P_0, int P_1, out object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		aXJrSGqaSllNVIjZEoYbzxDxtuvL aXJrSGqaSllNVIjZEoYbzxDxtuvL2 = rVvIujQeeFyDCvFPeevafYNHHWWEA(false);
		if (aXJrSGqaSllNVIjZEoYbzxDxtuvL2 == null)
		{
			P_2 = null;
			return -1;
		}
		if (P_1 < aXJrSGqaSllNVIjZEoYbzxDxtuvL2.JgpFzXXipiAykEGKNiRdqYHimzogA)
		{
			Logger.LogError("The buffer is too small to hold the data. Call PeekDataLength before calling Peek to get the data length.", requiredThreadSafety: true);
			P_2 = null;
			return -1;
		}
		int num = tfpFFmnQkLMyMGOVVwbmwIEBAArL.YQsSuECVzIKxghIXfrgLbgQVBtrEA(P_0, P_1, aXJrSGqaSllNVIjZEoYbzxDxtuvL2.JgpFzXXipiAykEGKNiRdqYHimzogA, aXJrSGqaSllNVIjZEoYbzxDxtuvL2.JMZuuVFWgiFzQaDYWuEBkjgpvKII);
		if (num != aXJrSGqaSllNVIjZEoYbzxDxtuvL2.JgpFzXXipiAykEGKNiRdqYHimzogA)
		{
			Logger.LogError("Failure reading data from buffer!", requiredThreadSafety: true);
			num = 0;
			P_2 = null;
			return -1;
		}
		P_2 = aXJrSGqaSllNVIjZEoYbzxDxtuvL2.oSTNoUsqqvpTvbBaRoeyFvglcsmu;
		return num;
	}

	public unsafe int NNtvopMunRAhFSmSAyluADoAhlNI(byte* P_0, int P_1)
	{
		object obj;
		return LNeavtCsGbYQRplqAlVmzblzKBNXA(P_0, P_1, out obj);
	}

	public unsafe int LbiaThmmIAAkUfuqYMJmaoWFMKHb(IntPtr P_0, int P_1, out object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		return LNeavtCsGbYQRplqAlVmzblzKBNXA((byte*)(void*)P_0, P_1, out P_2);
	}

	public int vLmFhNcUfoqjcIediyfJcFZgJHzG(IntPtr P_0, int P_1)
	{
		object obj;
		return LbiaThmmIAAkUfuqYMJmaoWFMKHb(P_0, P_1, out obj);
	}

	public unsafe int FSpmVkQPfqOHcNZoorIMvtMJSmhW(byte[] P_0, out object P_1)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			P_1 = null;
			return -1;
		}
		fixed (byte* ptr = P_0)
		{
			return LNeavtCsGbYQRplqAlVmzblzKBNXA(ptr, P_0.Length, out P_1);
		}
	}

	public int hYoeBFKujPTEXAnSrrAycWoTDtfR(byte[] P_0)
	{
		object obj;
		return FSpmVkQPfqOHcNZoorIMvtMJSmhW(P_0, out obj);
	}

	public int DmpWHDGuzTSmFsbbPaSgaaNBUssy()
	{
		return rVvIujQeeFyDCvFPeevafYNHHWWEA(false)?.JgpFzXXipiAykEGKNiRdqYHimzogA ?? (-1);
	}

	public unsafe int FfUkTohgDnLOgJSXgwRcOPjdjqjE(byte* P_0, int P_1, out object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		aXJrSGqaSllNVIjZEoYbzxDxtuvL aXJrSGqaSllNVIjZEoYbzxDxtuvL2 = rVvIujQeeFyDCvFPeevafYNHHWWEA(true);
		if (aXJrSGqaSllNVIjZEoYbzxDxtuvL2 == null)
		{
			P_2 = null;
			return -1;
		}
		if (P_1 < aXJrSGqaSllNVIjZEoYbzxDxtuvL2.JgpFzXXipiAykEGKNiRdqYHimzogA)
		{
			Logger.LogError("The buffer is too small to hold the data. Call PeekDataLength before calling Dequeue to get the data length.", requiredThreadSafety: true);
			P_2 = null;
			fcHsXEroppBRIHPkTZTqDBdhgrcc(aXJrSGqaSllNVIjZEoYbzxDxtuvL2, true);
			return -1;
		}
		int num = tfpFFmnQkLMyMGOVVwbmwIEBAArL.YQsSuECVzIKxghIXfrgLbgQVBtrEA(P_0, P_1, aXJrSGqaSllNVIjZEoYbzxDxtuvL2.JgpFzXXipiAykEGKNiRdqYHimzogA, aXJrSGqaSllNVIjZEoYbzxDxtuvL2.JMZuuVFWgiFzQaDYWuEBkjgpvKII);
		if (num != aXJrSGqaSllNVIjZEoYbzxDxtuvL2.JgpFzXXipiAykEGKNiRdqYHimzogA)
		{
			Logger.LogError("Failure reading data from buffer!", requiredThreadSafety: true);
			P_2 = null;
			fcHsXEroppBRIHPkTZTqDBdhgrcc(aXJrSGqaSllNVIjZEoYbzxDxtuvL2, true);
			return -1;
		}
		P_2 = aXJrSGqaSllNVIjZEoYbzxDxtuvL2.oSTNoUsqqvpTvbBaRoeyFvglcsmu;
		fcHsXEroppBRIHPkTZTqDBdhgrcc(aXJrSGqaSllNVIjZEoYbzxDxtuvL2, false);
		return num;
	}

	public unsafe int xGTPEZcvTQvoygObiMbxIdksGjAs(byte* P_0, int P_1)
	{
		object obj;
		return FfUkTohgDnLOgJSXgwRcOPjdjqjE(P_0, P_1, out obj);
	}

	public unsafe int tnndSOCdHHhOWfLQjHUkHtUczDIUA(IntPtr P_0, int P_1, out object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		return FfUkTohgDnLOgJSXgwRcOPjdjqjE((byte*)(void*)P_0, P_1, out P_2);
	}

	public int CufQRrDMIINemGYSCUtPNPFfdmZ(IntPtr P_0, int P_1)
	{
		object obj;
		return tnndSOCdHHhOWfLQjHUkHtUczDIUA(P_0, P_1, out obj);
	}

	public unsafe int fKEyyxETsgvghAItuFtPOtpBaBES(byte[] P_0, out object P_1)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			P_1 = null;
			return -1;
		}
		fixed (byte* ptr = P_0)
		{
			return FfUkTohgDnLOgJSXgwRcOPjdjqjE(ptr, P_0.Length, out P_1);
		}
	}

	public int zDurbGWESoPVdnGEyNrSEyfadEDO(byte[] P_0)
	{
		object obj;
		return fKEyyxETsgvghAItuFtPOtpBaBES(P_0, out obj);
	}

	public void PvJUUjcHMXZRHoPLILlfdUWOjSsf()
	{
		tfpFFmnQkLMyMGOVVwbmwIEBAArL.YpAhaApVQylDyfCmixOFJSdJQtLl();
		while (ePgCrPsngRHVYrEiIvoiEcPSgFVdA.Count > 0)
		{
			fcHsXEroppBRIHPkTZTqDBdhgrcc(ePgCrPsngRHVYrEiIvoiEcPSgFVdA.Dequeue(), true);
		}
	}

	private aXJrSGqaSllNVIjZEoYbzxDxtuvL rVvIujQeeFyDCvFPeevafYNHHWWEA(bool P_0)
	{
		while (ePgCrPsngRHVYrEiIvoiEcPSgFVdA.Count > 0)
		{
			aXJrSGqaSllNVIjZEoYbzxDxtuvL aXJrSGqaSllNVIjZEoYbzxDxtuvL2 = (P_0 ? ePgCrPsngRHVYrEiIvoiEcPSgFVdA.Dequeue() : ePgCrPsngRHVYrEiIvoiEcPSgFVdA.Peek());
			if (tfpFFmnQkLMyMGOVVwbmwIEBAArL.nEheralvDlrbsDsQudFjTzxuwgGk(aXJrSGqaSllNVIjZEoYbzxDxtuvL2.JMZuuVFWgiFzQaDYWuEBkjgpvKII, aXJrSGqaSllNVIjZEoYbzxDxtuvL2.uevbzIcJvOkHpMGlyntMVlHfKwwO))
			{
				return aXJrSGqaSllNVIjZEoYbzxDxtuvL2;
			}
			if (!P_0)
			{
				aXJrSGqaSllNVIjZEoYbzxDxtuvL2 = ePgCrPsngRHVYrEiIvoiEcPSgFVdA.Dequeue();
			}
			fcHsXEroppBRIHPkTZTqDBdhgrcc(aXJrSGqaSllNVIjZEoYbzxDxtuvL2, true);
		}
		return null;
	}

	private bool rwrKuuILmOKmRvyByEoJBedBmHWq()
	{
		return rVvIujQeeFyDCvFPeevafYNHHWWEA(false) != null;
	}

	private void fcHsXEroppBRIHPkTZTqDBdhgrcc(aXJrSGqaSllNVIjZEoYbzxDxtuvL P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1 && ABvdKjJKbVFUAxnwxteuDvmxfgSX != null && P_0.oSTNoUsqqvpTvbBaRoeyFvglcsmu != null)
			{
				ABvdKjJKbVFUAxnwxteuDvmxfgSX(P_0.oSTNoUsqqvpTvbBaRoeyFvglcsmu);
			}
			ZWLxRjsfyISoGzaXOdQTiQmimWTBb.Return(P_0);
		}
	}

	public void Dispose()
	{
		KIiBtNWaRbwXWmbiKTAAYyWKcgcy(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void fdzewlfTqjzyFSNtztqlvZVZqxiS()
	{
		try
		{
			KIiBtNWaRbwXWmbiKTAAYyWKcgcy(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected void KIiBtNWaRbwXWmbiKTAAYyWKcgcy(bool P_0)
	{
		if (xICepPfEbyNOcavBiuUqBqNvtyVW)
		{
			return;
		}
		if (P_0)
		{
			PvJUUjcHMXZRHoPLILlfdUWOjSsf();
			if (tfpFFmnQkLMyMGOVVwbmwIEBAArL != null)
			{
				tfpFFmnQkLMyMGOVVwbmwIEBAArL.Dispose();
			}
		}
		xICepPfEbyNOcavBiuUqBqNvtyVW = true;
	}

	public static bool TCJxNzcfdKlerYOvJACSCehofdaAb(gDVAfYrEIrFwoEUjWCiBwWQTpoEOA P_0, gDVAfYrEIrFwoEUjWCiBwWQTpoEOA P_1)
	{
		if (P_0 == null || P_1 == null)
		{
			return false;
		}
		MiscTools.Swap(ref P_0.tfpFFmnQkLMyMGOVVwbmwIEBAArL, ref P_1.tfpFFmnQkLMyMGOVVwbmwIEBAArL);
		MiscTools.Swap(ref P_0.ZWLxRjsfyISoGzaXOdQTiQmimWTBb, ref P_1.ZWLxRjsfyISoGzaXOdQTiQmimWTBb);
		MiscTools.Swap(ref P_0.ePgCrPsngRHVYrEiIvoiEcPSgFVdA, ref P_1.ePgCrPsngRHVYrEiIvoiEcPSgFVdA);
		return true;
	}
}
