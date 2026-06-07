using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal class sqAgHCGSTufLGSbmNmRVmFKjyzhk : IDisposable
{
	private class unIqySHtLsophEBSBdVhXrRRgRGj
	{
		public int FcMHGJqbxdPkaimHBuBXIkqHKezQ;

		public int TruJXrogLdNSkKBYUghcwZMYcPoB;

		public uint gtyHNCXdoXKePYsclVWCvSVTBbTP;

		public object aZSKqATRjqiZBjgrMJfkzDsVixFs;

		public void peomBpKgJtBwVFtqTnlcaXUulWvhA(int P_0, int P_1, uint P_2, object P_3)
		{
			FcMHGJqbxdPkaimHBuBXIkqHKezQ = P_0;
			TruJXrogLdNSkKBYUghcwZMYcPoB = P_1;
			gtyHNCXdoXKePYsclVWCvSVTBbTP = P_2;
			aZSKqATRjqiZBjgrMJfkzDsVixFs = P_3;
		}

		public void efdJrDEnKTZKTBgGCkppVaZpwUUV()
		{
			aZSKqATRjqiZBjgrMJfkzDsVixFs = null;
		}
	}

	[Serializable]
	private sealed class NVQCaVKwwJJChuAQMwoKdUnpoaxFA
	{
		public static readonly NVQCaVKwwJJChuAQMwoKdUnpoaxFA _003C_003E9 = new NVQCaVKwwJJChuAQMwoKdUnpoaxFA();

		public static Func<unIqySHtLsophEBSBdVhXrRRgRGj> _003C_003E9__6_0;

		public static Action<unIqySHtLsophEBSBdVhXrRRgRGj> _003C_003E9__6_1;

		internal unIqySHtLsophEBSBdVhXrRRgRGj vqUGYLksLIlgwWQSmginORFFuXzk()
		{
			return new unIqySHtLsophEBSBdVhXrRRgRGj();
		}

		internal void pDaqftMcljQUZeQCugOjrTfQEcfBA(unIqySHtLsophEBSBdVhXrRRgRGj P_0)
		{
			P_0.efdJrDEnKTZKTBgGCkppVaZpwUUV();
		}
	}

	private ApaQDWoTItssTokgoNghFnZLeADU fraLbaWXvYctmCkFCgHkAXOzKTYN;

	private ObjectPool<unIqySHtLsophEBSBdVhXrRRgRGj> JfYbIlXBpHNMqfCEVnSVecoWaVcN;

	private Queue<unIqySHtLsophEBSBdVhXrRRgRGj> wZljLZNorIcgmitbTJXyCgRgTEgYA;

	private Action<object> OQogataokUafuchjuKNqOboLSlruA;

	private bool zNcZDXpilLnMwdAjlfuRSBRPpaBA;

	public bool cZQPiSKyzooJAlWTLiggXKJFLCtF => jJqbGodMxTfJzepIjFHPotjldGvMA();

	public sqAgHCGSTufLGSbmNmRVmFKjyzhk(int P_0, int P_1, Action<object> P_2 = null)
	{
		if (P_0 <= 0)
		{
			throw new ArgumentOutOfRangeException("capacity");
		}
		fraLbaWXvYctmCkFCgHkAXOzKTYN = new ApaQDWoTItssTokgoNghFnZLeADU(P_0);
		JfYbIlXBpHNMqfCEVnSVecoWaVcN = new ObjectPool<unIqySHtLsophEBSBdVhXrRRgRGj>(P_1, NVQCaVKwwJJChuAQMwoKdUnpoaxFA._003C_003E9.vqUGYLksLIlgwWQSmginORFFuXzk, NVQCaVKwwJJChuAQMwoKdUnpoaxFA._003C_003E9.pDaqftMcljQUZeQCugOjrTfQEcfBA);
		wZljLZNorIcgmitbTJXyCgRgTEgYA = new Queue<unIqySHtLsophEBSBdVhXrRRgRGj>(P_1);
		OQogataokUafuchjuKNqOboLSlruA = P_2;
	}

	public unsafe bool twTIsKhCyxXpPXrIFwNSmauEFJuiA(byte* P_0, int P_1, object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return false;
		}
		if (fraLbaWXvYctmCkFCgHkAXOzKTYN.yxhnHWbFcTsxtijGLUHgHLyecUCy(P_0, P_1, P_1, out var num, out var num2) < P_1)
		{
			return false;
		}
		unIqySHtLsophEBSBdVhXrRRgRGj unIqySHtLsophEBSBdVhXrRRgRGj2 = JfYbIlXBpHNMqfCEVnSVecoWaVcN.Get();
		unIqySHtLsophEBSBdVhXrRRgRGj2.peomBpKgJtBwVFtqTnlcaXUulWvhA(num, P_1, num2, P_2);
		wZljLZNorIcgmitbTJXyCgRgTEgYA.Enqueue(unIqySHtLsophEBSBdVhXrRRgRGj2);
		return true;
	}

	public unsafe bool IhEMmZCsRFCXBCcHgkDoYtZMeRc(byte* P_0, int P_1)
	{
		return twTIsKhCyxXpPXrIFwNSmauEFJuiA(P_0, P_1, null);
	}

	public unsafe bool wlLFuEvWKwBBWKwLkdewNMeSBPvy(IntPtr P_0, int P_1, object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			return false;
		}
		return twTIsKhCyxXpPXrIFwNSmauEFJuiA((byte*)(void*)P_0, P_1, P_2);
	}

	public bool rFuErghMXAtDsCnsdiZfrrHlddHo(IntPtr P_0, int P_1)
	{
		return wlLFuEvWKwBBWKwLkdewNMeSBPvy(P_0, P_1, null);
	}

	public unsafe bool jggxVNvvborbFJiQYVtCRjEiRxKv(byte[] P_0, int P_1, object P_2, int P_3 = 0)
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
			return twTIsKhCyxXpPXrIFwNSmauEFJuiA(ptr2, P_1, P_2);
		}
	}

	public bool ysxBTiIczbMGXzcAaNpWeTYoLfLYA(byte[] P_0, int P_1, int P_2 = 0)
	{
		return jggxVNvvborbFJiQYVtCRjEiRxKv(P_0, P_1, null, P_2);
	}

	public unsafe int FzOBnSFZewhvHljTDiwXDxLOEaAb(byte* P_0, int P_1, out object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		unIqySHtLsophEBSBdVhXrRRgRGj unIqySHtLsophEBSBdVhXrRRgRGj2 = jkwCWnnPvQAegvuKzmKmqFDfRRbw(false);
		if (unIqySHtLsophEBSBdVhXrRRgRGj2 == null)
		{
			P_2 = null;
			return -1;
		}
		if (P_1 < unIqySHtLsophEBSBdVhXrRRgRGj2.TruJXrogLdNSkKBYUghcwZMYcPoB)
		{
			Logger.LogError("The buffer is too small to hold the data. Call PeekDataLength before calling Peek to get the data length.", requiredThreadSafety: true);
			P_2 = null;
			return -1;
		}
		int num = fraLbaWXvYctmCkFCgHkAXOzKTYN.YfxSsOdgELUaOjMVeZjXTfIjilCm(P_0, P_1, unIqySHtLsophEBSBdVhXrRRgRGj2.TruJXrogLdNSkKBYUghcwZMYcPoB, unIqySHtLsophEBSBdVhXrRRgRGj2.FcMHGJqbxdPkaimHBuBXIkqHKezQ);
		if (num != unIqySHtLsophEBSBdVhXrRRgRGj2.TruJXrogLdNSkKBYUghcwZMYcPoB)
		{
			Logger.LogError("Failure reading data from buffer!", requiredThreadSafety: true);
			num = 0;
			P_2 = null;
			return -1;
		}
		P_2 = unIqySHtLsophEBSBdVhXrRRgRGj2.aZSKqATRjqiZBjgrMJfkzDsVixFs;
		return num;
	}

	public unsafe int XFcoHddzeMHrbOXXNEZggGwuWycr(byte* P_0, int P_1)
	{
		object obj;
		return FzOBnSFZewhvHljTDiwXDxLOEaAb(P_0, P_1, out obj);
	}

	public unsafe int HFcbWRbBvZhbAEpvkhpLUYiTqVpOb(IntPtr P_0, int P_1, out object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		return FzOBnSFZewhvHljTDiwXDxLOEaAb((byte*)(void*)P_0, P_1, out P_2);
	}

	public int pHjcpzBZZlMNIfSnlkBHNEVIkOWbb(IntPtr P_0, int P_1)
	{
		object obj;
		return HFcbWRbBvZhbAEpvkhpLUYiTqVpOb(P_0, P_1, out obj);
	}

	public unsafe int JekjzodCujcxILErnbvWDfEvzcIi(byte[] P_0, out object P_1)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			P_1 = null;
			return -1;
		}
		fixed (byte* ptr = P_0)
		{
			return FzOBnSFZewhvHljTDiwXDxLOEaAb(ptr, P_0.Length, out P_1);
		}
	}

	public int pgjabHtXoKqdpAYRmnpqERcpawSu(byte[] P_0)
	{
		object obj;
		return JekjzodCujcxILErnbvWDfEvzcIi(P_0, out obj);
	}

	public int FyydnJjyPAtmfeaHOzSqAZctpbLg()
	{
		return jkwCWnnPvQAegvuKzmKmqFDfRRbw(false)?.TruJXrogLdNSkKBYUghcwZMYcPoB ?? (-1);
	}

	public unsafe int TrVSSgUDviKqQRbXdURwscLXjgQEA(byte* P_0, int P_1, out object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		unIqySHtLsophEBSBdVhXrRRgRGj unIqySHtLsophEBSBdVhXrRRgRGj2 = jkwCWnnPvQAegvuKzmKmqFDfRRbw(true);
		if (unIqySHtLsophEBSBdVhXrRRgRGj2 == null)
		{
			P_2 = null;
			return -1;
		}
		if (P_1 < unIqySHtLsophEBSBdVhXrRRgRGj2.TruJXrogLdNSkKBYUghcwZMYcPoB)
		{
			Logger.LogError("The buffer is too small to hold the data. Call PeekDataLength before calling Dequeue to get the data length.", requiredThreadSafety: true);
			P_2 = null;
			xfrBOHbCfwTslMNOGSgLtlZJwtQeA(unIqySHtLsophEBSBdVhXrRRgRGj2, true);
			return -1;
		}
		int num = fraLbaWXvYctmCkFCgHkAXOzKTYN.YfxSsOdgELUaOjMVeZjXTfIjilCm(P_0, P_1, unIqySHtLsophEBSBdVhXrRRgRGj2.TruJXrogLdNSkKBYUghcwZMYcPoB, unIqySHtLsophEBSBdVhXrRRgRGj2.FcMHGJqbxdPkaimHBuBXIkqHKezQ);
		if (num != unIqySHtLsophEBSBdVhXrRRgRGj2.TruJXrogLdNSkKBYUghcwZMYcPoB)
		{
			Logger.LogError("Failure reading data from buffer!", requiredThreadSafety: true);
			P_2 = null;
			xfrBOHbCfwTslMNOGSgLtlZJwtQeA(unIqySHtLsophEBSBdVhXrRRgRGj2, true);
			return -1;
		}
		P_2 = unIqySHtLsophEBSBdVhXrRRgRGj2.aZSKqATRjqiZBjgrMJfkzDsVixFs;
		xfrBOHbCfwTslMNOGSgLtlZJwtQeA(unIqySHtLsophEBSBdVhXrRRgRGj2, false);
		return num;
	}

	public unsafe int bPWFvHJnGTEOOceshGxlfugBAypEc(byte* P_0, int P_1)
	{
		object obj;
		return TrVSSgUDviKqQRbXdURwscLXjgQEA(P_0, P_1, out obj);
	}

	public unsafe int dXeIcCvoQOHtkVDHgtbcLIOSHMvJA(IntPtr P_0, int P_1, out object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		return TrVSSgUDviKqQRbXdURwscLXjgQEA((byte*)(void*)P_0, P_1, out P_2);
	}

	public int UTvaFJEsNXElUakRDRfjvbTfIgVZA(IntPtr P_0, int P_1)
	{
		object obj;
		return dXeIcCvoQOHtkVDHgtbcLIOSHMvJA(P_0, P_1, out obj);
	}

	public unsafe int fvDRAtjijvvCZSSmhaWHuobpgWfO(byte[] P_0, out object P_1)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			P_1 = null;
			return -1;
		}
		fixed (byte* ptr = P_0)
		{
			return TrVSSgUDviKqQRbXdURwscLXjgQEA(ptr, P_0.Length, out P_1);
		}
	}

	public int ntzBKKvNLxcXFxIVzUhWserIGNeq(byte[] P_0)
	{
		object obj;
		return fvDRAtjijvvCZSSmhaWHuobpgWfO(P_0, out obj);
	}

	public void HPYxmfLwFSGuxglWLyQnXzIqkWHi()
	{
		fraLbaWXvYctmCkFCgHkAXOzKTYN.AEVEWEMEZxaLIpGdzcbFhXppfHcr();
		while (wZljLZNorIcgmitbTJXyCgRgTEgYA.Count > 0)
		{
			xfrBOHbCfwTslMNOGSgLtlZJwtQeA(wZljLZNorIcgmitbTJXyCgRgTEgYA.Dequeue(), true);
		}
	}

	private unIqySHtLsophEBSBdVhXrRRgRGj jkwCWnnPvQAegvuKzmKmqFDfRRbw(bool P_0)
	{
		while (wZljLZNorIcgmitbTJXyCgRgTEgYA.Count > 0)
		{
			unIqySHtLsophEBSBdVhXrRRgRGj unIqySHtLsophEBSBdVhXrRRgRGj2 = (P_0 ? wZljLZNorIcgmitbTJXyCgRgTEgYA.Dequeue() : wZljLZNorIcgmitbTJXyCgRgTEgYA.Peek());
			if (fraLbaWXvYctmCkFCgHkAXOzKTYN.pMiPoeCGKcBAMDOFdIozCvbKchdrA(unIqySHtLsophEBSBdVhXrRRgRGj2.FcMHGJqbxdPkaimHBuBXIkqHKezQ, unIqySHtLsophEBSBdVhXrRRgRGj2.gtyHNCXdoXKePYsclVWCvSVTBbTP))
			{
				return unIqySHtLsophEBSBdVhXrRRgRGj2;
			}
			if (!P_0)
			{
				unIqySHtLsophEBSBdVhXrRRgRGj2 = wZljLZNorIcgmitbTJXyCgRgTEgYA.Dequeue();
			}
			xfrBOHbCfwTslMNOGSgLtlZJwtQeA(unIqySHtLsophEBSBdVhXrRRgRGj2, true);
		}
		return null;
	}

	private bool jJqbGodMxTfJzepIjFHPotjldGvMA()
	{
		return jkwCWnnPvQAegvuKzmKmqFDfRRbw(false) != null;
	}

	private void xfrBOHbCfwTslMNOGSgLtlZJwtQeA(unIqySHtLsophEBSBdVhXrRRgRGj P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1 && OQogataokUafuchjuKNqOboLSlruA != null && P_0.aZSKqATRjqiZBjgrMJfkzDsVixFs != null)
			{
				OQogataokUafuchjuKNqOboLSlruA(P_0.aZSKqATRjqiZBjgrMJfkzDsVixFs);
			}
			JfYbIlXBpHNMqfCEVnSVecoWaVcN.Return(P_0);
		}
	}

	public void Dispose()
	{
		IYbiTDtSWuSkmwazJxpSkrIsKpPv(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void nGmKbvGngeZvjAemgVzQZVfSmZGb()
	{
		try
		{
			IYbiTDtSWuSkmwazJxpSkrIsKpPv(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected void IYbiTDtSWuSkmwazJxpSkrIsKpPv(bool P_0)
	{
		if (zNcZDXpilLnMwdAjlfuRSBRPpaBA)
		{
			return;
		}
		if (P_0)
		{
			HPYxmfLwFSGuxglWLyQnXzIqkWHi();
			if (fraLbaWXvYctmCkFCgHkAXOzKTYN != null)
			{
				fraLbaWXvYctmCkFCgHkAXOzKTYN.Dispose();
			}
		}
		zNcZDXpilLnMwdAjlfuRSBRPpaBA = true;
	}

	public static bool PhCnYdPkIXZPNMugYhVOUjPIiIZC(sqAgHCGSTufLGSbmNmRVmFKjyzhk P_0, sqAgHCGSTufLGSbmNmRVmFKjyzhk P_1)
	{
		if (P_0 == null || P_1 == null)
		{
			return false;
		}
		MiscTools.Swap(ref P_0.fraLbaWXvYctmCkFCgHkAXOzKTYN, ref P_1.fraLbaWXvYctmCkFCgHkAXOzKTYN);
		MiscTools.Swap(ref P_0.JfYbIlXBpHNMqfCEVnSVecoWaVcN, ref P_1.JfYbIlXBpHNMqfCEVnSVecoWaVcN);
		MiscTools.Swap(ref P_0.wZljLZNorIcgmitbTJXyCgRgTEgYA, ref P_1.wZljLZNorIcgmitbTJXyCgRgTEgYA);
		return true;
	}
}
