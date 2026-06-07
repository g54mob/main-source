using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal class taxSODdctqbTKpDgPOsGTyaMgVSl : IDisposable
{
	private class lZtEvJgUjwVgvtTEDGCaiOvgexbGA
	{
		public int OPdLxWFOXpcJeBMFPsnSpWAarrQK;

		public int YHZtSOLjKrsVMjwLGJRoDSrpJliT;

		public uint dgFWVFsBENwPFlamlExFUSfcowgO;

		public object pobeNHuPNmHyVMPvAqohEOCsjqgFA;

		public void yRDUWirizfeqXANuVJKnudaPzDQw(int P_0, int P_1, uint P_2, object P_3)
		{
			OPdLxWFOXpcJeBMFPsnSpWAarrQK = P_0;
			YHZtSOLjKrsVMjwLGJRoDSrpJliT = P_1;
			dgFWVFsBENwPFlamlExFUSfcowgO = P_2;
			pobeNHuPNmHyVMPvAqohEOCsjqgFA = P_3;
		}

		public void tVMjOWnPgRYDHqAKYDGqAszGFLfFb()
		{
			pobeNHuPNmHyVMPvAqohEOCsjqgFA = null;
		}
	}

	[Serializable]
	private sealed class EFbdTYZWgFUCtnCHQDZZdPqOxVGD
	{
		public static readonly EFbdTYZWgFUCtnCHQDZZdPqOxVGD _003C_003E9 = new EFbdTYZWgFUCtnCHQDZZdPqOxVGD();

		public static Func<lZtEvJgUjwVgvtTEDGCaiOvgexbGA> _003C_003E9__6_0;

		public static Action<lZtEvJgUjwVgvtTEDGCaiOvgexbGA> _003C_003E9__6_1;

		internal lZtEvJgUjwVgvtTEDGCaiOvgexbGA uatBnOTHzSHyqlcYcDParbxqyvAy()
		{
			return new lZtEvJgUjwVgvtTEDGCaiOvgexbGA();
		}

		internal void kQFsQkrBHvEMVFoWigpkEEHlLdWbb(lZtEvJgUjwVgvtTEDGCaiOvgexbGA P_0)
		{
			P_0.tVMjOWnPgRYDHqAKYDGqAszGFLfFb();
		}
	}

	private ZzPGoDBJildkPPHmulNuiungQFoV cDFduznEPCQbopYROgalllyQGEpk;

	private ObjectPool<lZtEvJgUjwVgvtTEDGCaiOvgexbGA> CUhcuiHmTLHHiFSYDmCYDZSbvOHY;

	private Queue<lZtEvJgUjwVgvtTEDGCaiOvgexbGA> hLOOOAiLBQercMUxJgmhVbWPVxHC;

	private Action<object> LDFdhgHpGElaqQFbiwSvEfOaoxGK;

	private bool gmgzKWUSSjfjOOpUdXAfznhibkNCA;

	public bool jqjvKNnZMoqwSEKIXONneZismWYo => iZPnNbKxRTmTfWICbUiWOgJSGFSz();

	public taxSODdctqbTKpDgPOsGTyaMgVSl(int P_0, int P_1, Action<object> P_2 = null)
	{
		if (P_0 <= 0)
		{
			throw new ArgumentOutOfRangeException("capacity");
		}
		cDFduznEPCQbopYROgalllyQGEpk = new ZzPGoDBJildkPPHmulNuiungQFoV(P_0);
		CUhcuiHmTLHHiFSYDmCYDZSbvOHY = new ObjectPool<lZtEvJgUjwVgvtTEDGCaiOvgexbGA>(P_1, EFbdTYZWgFUCtnCHQDZZdPqOxVGD._003C_003E9.uatBnOTHzSHyqlcYcDParbxqyvAy, EFbdTYZWgFUCtnCHQDZZdPqOxVGD._003C_003E9.kQFsQkrBHvEMVFoWigpkEEHlLdWbb);
		hLOOOAiLBQercMUxJgmhVbWPVxHC = new Queue<lZtEvJgUjwVgvtTEDGCaiOvgexbGA>(P_1);
		LDFdhgHpGElaqQFbiwSvEfOaoxGK = P_2;
	}

	public unsafe bool eFgdrRGlKftANaeKXEgFRvQdJOTU(byte* P_0, int P_1, object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return false;
		}
		if (cDFduznEPCQbopYROgalllyQGEpk.zhIbMFIlOLdppNGAXWmhgXAFORrW(P_0, P_1, P_1, out var num, out var num2) < P_1)
		{
			return false;
		}
		lZtEvJgUjwVgvtTEDGCaiOvgexbGA lZtEvJgUjwVgvtTEDGCaiOvgexbGA2 = CUhcuiHmTLHHiFSYDmCYDZSbvOHY.Get();
		lZtEvJgUjwVgvtTEDGCaiOvgexbGA2.yRDUWirizfeqXANuVJKnudaPzDQw(num, P_1, num2, P_2);
		hLOOOAiLBQercMUxJgmhVbWPVxHC.Enqueue(lZtEvJgUjwVgvtTEDGCaiOvgexbGA2);
		return true;
	}

	public unsafe bool DtGxRrmPeZeDYEeOLdXIJTeeIXJKA(byte* P_0, int P_1)
	{
		return eFgdrRGlKftANaeKXEgFRvQdJOTU(P_0, P_1, null);
	}

	public unsafe bool vXsngBIvcwRxUpIBiREvcnYxMyWF(IntPtr P_0, int P_1, object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			return false;
		}
		return eFgdrRGlKftANaeKXEgFRvQdJOTU((byte*)(void*)P_0, P_1, P_2);
	}

	public bool aTJiMxOrpKLOqhexrggqMkxKmdyH(IntPtr P_0, int P_1)
	{
		return vXsngBIvcwRxUpIBiREvcnYxMyWF(P_0, P_1, null);
	}

	public unsafe bool oQJAaSCLVgfOVqQUUGBVaygBkunC(byte[] P_0, int P_1, object P_2, int P_3 = 0)
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
			return eFgdrRGlKftANaeKXEgFRvQdJOTU(ptr2, P_1, P_2);
		}
	}

	public bool tBSIIjZJJhUAXZPOeQOLgwWHuxkC(byte[] P_0, int P_1, int P_2 = 0)
	{
		return oQJAaSCLVgfOVqQUUGBVaygBkunC(P_0, P_1, null, P_2);
	}

	public unsafe int YJGXOikojygzpEIpRbJncgXCuZFLb(byte* P_0, int P_1, out object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		lZtEvJgUjwVgvtTEDGCaiOvgexbGA lZtEvJgUjwVgvtTEDGCaiOvgexbGA2 = wYTlZoIaPUSweIFEjptxDlnGCUOU(false);
		if (lZtEvJgUjwVgvtTEDGCaiOvgexbGA2 == null)
		{
			P_2 = null;
			return -1;
		}
		if (P_1 < lZtEvJgUjwVgvtTEDGCaiOvgexbGA2.YHZtSOLjKrsVMjwLGJRoDSrpJliT)
		{
			Logger.LogError("The buffer is too small to hold the data. Call PeekDataLength before calling Peek to get the data length.", requiredThreadSafety: true);
			P_2 = null;
			return -1;
		}
		int num = cDFduznEPCQbopYROgalllyQGEpk.HVKCRLBIMFdKGAWOcowUIoizIfbQB(P_0, P_1, lZtEvJgUjwVgvtTEDGCaiOvgexbGA2.YHZtSOLjKrsVMjwLGJRoDSrpJliT, lZtEvJgUjwVgvtTEDGCaiOvgexbGA2.OPdLxWFOXpcJeBMFPsnSpWAarrQK);
		if (num != lZtEvJgUjwVgvtTEDGCaiOvgexbGA2.YHZtSOLjKrsVMjwLGJRoDSrpJliT)
		{
			Logger.LogError("Failure reading data from buffer!", requiredThreadSafety: true);
			num = 0;
			P_2 = null;
			return -1;
		}
		P_2 = lZtEvJgUjwVgvtTEDGCaiOvgexbGA2.pobeNHuPNmHyVMPvAqohEOCsjqgFA;
		return num;
	}

	public unsafe int UsLCMyCOOGcjjpaNNVgdZqMTMvRP(byte* P_0, int P_1)
	{
		object obj;
		return YJGXOikojygzpEIpRbJncgXCuZFLb(P_0, P_1, out obj);
	}

	public unsafe int MqPJaGsJNFvaCWGzpfUErlWRqGMv(IntPtr P_0, int P_1, out object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		return YJGXOikojygzpEIpRbJncgXCuZFLb((byte*)(void*)P_0, P_1, out P_2);
	}

	public int wPEutygErhDOIlwtnyfMhohrXXvH(IntPtr P_0, int P_1)
	{
		object obj;
		return MqPJaGsJNFvaCWGzpfUErlWRqGMv(P_0, P_1, out obj);
	}

	public unsafe int WUThyxOeStFaGmQhfPYZmEyUCmlV(byte[] P_0, out object P_1)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			P_1 = null;
			return -1;
		}
		fixed (byte* ptr = P_0)
		{
			return YJGXOikojygzpEIpRbJncgXCuZFLb(ptr, P_0.Length, out P_1);
		}
	}

	public int cxEQsICmQGcjbGbTkWKnrbYEgnbGb(byte[] P_0)
	{
		object obj;
		return WUThyxOeStFaGmQhfPYZmEyUCmlV(P_0, out obj);
	}

	public int KQHGkOEQQERjvPRkOqGritjMWaiEb()
	{
		return wYTlZoIaPUSweIFEjptxDlnGCUOU(false)?.YHZtSOLjKrsVMjwLGJRoDSrpJliT ?? (-1);
	}

	public unsafe int YBwDgdpNVaoBImFIjeidFHdqppvJ(byte* P_0, int P_1, out object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		lZtEvJgUjwVgvtTEDGCaiOvgexbGA lZtEvJgUjwVgvtTEDGCaiOvgexbGA2 = wYTlZoIaPUSweIFEjptxDlnGCUOU(true);
		if (lZtEvJgUjwVgvtTEDGCaiOvgexbGA2 == null)
		{
			P_2 = null;
			return -1;
		}
		if (P_1 < lZtEvJgUjwVgvtTEDGCaiOvgexbGA2.YHZtSOLjKrsVMjwLGJRoDSrpJliT)
		{
			Logger.LogError("The buffer is too small to hold the data. Call PeekDataLength before calling Dequeue to get the data length.", requiredThreadSafety: true);
			P_2 = null;
			cqQNxSjPGacXvyGMKZZMWvRwgaze(lZtEvJgUjwVgvtTEDGCaiOvgexbGA2, true);
			return -1;
		}
		int num = cDFduznEPCQbopYROgalllyQGEpk.HVKCRLBIMFdKGAWOcowUIoizIfbQB(P_0, P_1, lZtEvJgUjwVgvtTEDGCaiOvgexbGA2.YHZtSOLjKrsVMjwLGJRoDSrpJliT, lZtEvJgUjwVgvtTEDGCaiOvgexbGA2.OPdLxWFOXpcJeBMFPsnSpWAarrQK);
		if (num != lZtEvJgUjwVgvtTEDGCaiOvgexbGA2.YHZtSOLjKrsVMjwLGJRoDSrpJliT)
		{
			Logger.LogError("Failure reading data from buffer!", requiredThreadSafety: true);
			P_2 = null;
			cqQNxSjPGacXvyGMKZZMWvRwgaze(lZtEvJgUjwVgvtTEDGCaiOvgexbGA2, true);
			return -1;
		}
		P_2 = lZtEvJgUjwVgvtTEDGCaiOvgexbGA2.pobeNHuPNmHyVMPvAqohEOCsjqgFA;
		cqQNxSjPGacXvyGMKZZMWvRwgaze(lZtEvJgUjwVgvtTEDGCaiOvgexbGA2, false);
		return num;
	}

	public unsafe int kdveTSaPkHWDWBnizGQeLsIjrrGG(byte* P_0, int P_1)
	{
		object obj;
		return YBwDgdpNVaoBImFIjeidFHdqppvJ(P_0, P_1, out obj);
	}

	public unsafe int mjVrqFGuwMnMoieFuYHtcAwjGTSw(IntPtr P_0, int P_1, out object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		return YBwDgdpNVaoBImFIjeidFHdqppvJ((byte*)(void*)P_0, P_1, out P_2);
	}

	public int RAUIpQfKxLbTSNJJHECsSavKCrkq(IntPtr P_0, int P_1)
	{
		object obj;
		return mjVrqFGuwMnMoieFuYHtcAwjGTSw(P_0, P_1, out obj);
	}

	public unsafe int aiaDwiOfJfaKVxqgtcxWLGLWPBQP(byte[] P_0, out object P_1)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			P_1 = null;
			return -1;
		}
		fixed (byte* ptr = P_0)
		{
			return YBwDgdpNVaoBImFIjeidFHdqppvJ(ptr, P_0.Length, out P_1);
		}
	}

	public int cFEfGRYahhgyHfYNlpjJKFZrqMZnA(byte[] P_0)
	{
		object obj;
		return aiaDwiOfJfaKVxqgtcxWLGLWPBQP(P_0, out obj);
	}

	public void AfLxuWuhCZahbBEFxNsQemVNdmWA()
	{
		cDFduznEPCQbopYROgalllyQGEpk.DusQZBlMntjuCQSndYSIAlXUrKRP();
		while (hLOOOAiLBQercMUxJgmhVbWPVxHC.Count > 0)
		{
			cqQNxSjPGacXvyGMKZZMWvRwgaze(hLOOOAiLBQercMUxJgmhVbWPVxHC.Dequeue(), true);
		}
	}

	private lZtEvJgUjwVgvtTEDGCaiOvgexbGA wYTlZoIaPUSweIFEjptxDlnGCUOU(bool P_0)
	{
		while (hLOOOAiLBQercMUxJgmhVbWPVxHC.Count > 0)
		{
			lZtEvJgUjwVgvtTEDGCaiOvgexbGA lZtEvJgUjwVgvtTEDGCaiOvgexbGA2 = (P_0 ? hLOOOAiLBQercMUxJgmhVbWPVxHC.Dequeue() : hLOOOAiLBQercMUxJgmhVbWPVxHC.Peek());
			if (cDFduznEPCQbopYROgalllyQGEpk.qcXqOzlxamiSKqZHfrPwCLBtFmYFA(lZtEvJgUjwVgvtTEDGCaiOvgexbGA2.OPdLxWFOXpcJeBMFPsnSpWAarrQK, lZtEvJgUjwVgvtTEDGCaiOvgexbGA2.dgFWVFsBENwPFlamlExFUSfcowgO))
			{
				return lZtEvJgUjwVgvtTEDGCaiOvgexbGA2;
			}
			if (!P_0)
			{
				lZtEvJgUjwVgvtTEDGCaiOvgexbGA2 = hLOOOAiLBQercMUxJgmhVbWPVxHC.Dequeue();
			}
			cqQNxSjPGacXvyGMKZZMWvRwgaze(lZtEvJgUjwVgvtTEDGCaiOvgexbGA2, true);
		}
		return null;
	}

	private bool iZPnNbKxRTmTfWICbUiWOgJSGFSz()
	{
		return wYTlZoIaPUSweIFEjptxDlnGCUOU(false) != null;
	}

	private void cqQNxSjPGacXvyGMKZZMWvRwgaze(lZtEvJgUjwVgvtTEDGCaiOvgexbGA P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1 && LDFdhgHpGElaqQFbiwSvEfOaoxGK != null && P_0.pobeNHuPNmHyVMPvAqohEOCsjqgFA != null)
			{
				LDFdhgHpGElaqQFbiwSvEfOaoxGK(P_0.pobeNHuPNmHyVMPvAqohEOCsjqgFA);
			}
			CUhcuiHmTLHHiFSYDmCYDZSbvOHY.Return(P_0);
		}
	}

	public void Dispose()
	{
		TkSOXCUwQciIgZjxXCERLrsZeDkk(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void szDZBapzJwwTjrdcalcuoJtAnxqU()
	{
		try
		{
			TkSOXCUwQciIgZjxXCERLrsZeDkk(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected void TkSOXCUwQciIgZjxXCERLrsZeDkk(bool P_0)
	{
		if (gmgzKWUSSjfjOOpUdXAfznhibkNCA)
		{
			return;
		}
		if (P_0)
		{
			AfLxuWuhCZahbBEFxNsQemVNdmWA();
			if (cDFduznEPCQbopYROgalllyQGEpk != null)
			{
				cDFduznEPCQbopYROgalllyQGEpk.Dispose();
			}
		}
		gmgzKWUSSjfjOOpUdXAfznhibkNCA = true;
	}

	public static bool GbzjqshiKLQJDMfaGrMVjzFxolsaA(taxSODdctqbTKpDgPOsGTyaMgVSl P_0, taxSODdctqbTKpDgPOsGTyaMgVSl P_1)
	{
		if (P_0 == null || P_1 == null)
		{
			return false;
		}
		MiscTools.Swap(ref P_0.cDFduznEPCQbopYROgalllyQGEpk, ref P_1.cDFduznEPCQbopYROgalllyQGEpk);
		MiscTools.Swap(ref P_0.CUhcuiHmTLHHiFSYDmCYDZSbvOHY, ref P_1.CUhcuiHmTLHHiFSYDmCYDZSbvOHY);
		MiscTools.Swap(ref P_0.hLOOOAiLBQercMUxJgmhVbWPVxHC, ref P_1.hLOOOAiLBQercMUxJgmhVbWPVxHC);
		return true;
	}
}
