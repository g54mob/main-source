using System;
using Rewired;
using Rewired.Utils;
using UnityEngine;

internal class xiFtgBJFkEGohisLDEUCdkVzqFfqA : wBImtGgUUHGcxRqFgTQfzPwwtEhH, yTxKLgtyFntzrmhxUvcIusyQEikI, MwhtVuoJUxjrhNamguNYJdmfgjPz, IDisposable
{
	public readonly int gYJyqrEKRmMuQnMfRfCQwLiQRAbl;

	public readonly int MoKRZpAvhGItcwTSomHTowvzlOaA;

	public readonly int HWtdANWTDRnyLjRQnlzCeyyjWrwh;

	public readonly int NbcpzHCjyspgocSagZdmKRzoiYec;

	public readonly short[] lrROXAXcELDscMaQJztnfAeEiXifA;

	private readonly ButtonLoopSet RGQAUFVTBxBuzobLMFRhKtmFkhmGA;

	public readonly short[] FQPFIyKvXTHDmfbupZNwYKRjfnGR;

	public readonly short[] hMAlLjwDZwMZGgjChyCMplEyTvoE;

	private bool BbbKlrdSssDCUfobkjtXLSgbsfCJ;

	public bool[] wkyOjalYybbJCuquffYSUFvbStTS
	{
		get
		{
			if (RGQAUFVTBxBuzobLMFRhKtmFkhmGA.Current == null)
			{
				return null;
			}
			return RGQAUFVTBxBuzobLMFRhKtmFkhmGA.Current.effectiveValue;
		}
	}

	int yTxKLgtyFntzrmhxUvcIusyQEikI.wlEUBuyjiYQefAOEJWmETSaCBESC => qYkXMFqPLnbmvnIcqTbdJjmnnkdJ;

	int yTxKLgtyFntzrmhxUvcIusyQEikI.iyAEqSCFgCbMlDwLCyYQNtstCKSzb => gYJyqrEKRmMuQnMfRfCQwLiQRAbl;

	int yTxKLgtyFntzrmhxUvcIusyQEikI.IWbOmSPeUeqlQMAgxcdXYaUbZFqw => MoKRZpAvhGItcwTSomHTowvzlOaA;

	int yTxKLgtyFntzrmhxUvcIusyQEikI.VicKNVWvbwnZmLGOxCQBhrsnMvmw => HWtdANWTDRnyLjRQnlzCeyyjWrwh;

	int yTxKLgtyFntzrmhxUvcIusyQEikI.pwfkbYagkEHtdrbnAEaIgSCWfBCpA => NbcpzHCjyspgocSagZdmKRzoiYec;

	bool yTxKLgtyFntzrmhxUvcIusyQEikI.LzLJNkuDIZCeZwYErLcyMsgxyYbF
	{
		get
		{
			if (gYJyqrEKRmMuQnMfRfCQwLiQRAbl <= 0 && MoKRZpAvhGItcwTSomHTowvzlOaA <= 0 && HWtdANWTDRnyLjRQnlzCeyyjWrwh <= 0)
			{
				return NbcpzHCjyspgocSagZdmKRzoiYec > 0;
			}
			return true;
		}
	}

	InputSource yTxKLgtyFntzrmhxUvcIusyQEikI.sEGymECmULCcAGgvPmhZiuoNVygTA => InputSource.SDL2;

	bool yTxKLgtyFntzrmhxUvcIusyQEikI.RezEQvkgruNsDRznSYUvqEjciwwc => BbbKlrdSssDCUfobkjtXLSgbsfCJ;

	public xiFtgBJFkEGohisLDEUCdkVzqFfqA(qdGECWatufyXebprdISidsHKfSMVB P_0, MWycXiczxePqggmPLkAztFDmLRbg P_1)
		: this(P_0, P_1, KCMunaFkaNgqWgRslCbmdwchwrklb.Joystick)
	{
	}

	protected xiFtgBJFkEGohisLDEUCdkVzqFfqA(qdGECWatufyXebprdISidsHKfSMVB P_0, MWycXiczxePqggmPLkAztFDmLRbg P_1, KCMunaFkaNgqWgRslCbmdwchwrklb P_2)
		: this(P_0, P_1, P_2, P_1.SNdcbdYtNYkfkfGDLQmDHeUbZRGS, P_1.sZLGptAODsnrqiIJtnjdvBBrbAcGA, P_1.UIAkrlYLZROlnCyQelrtPCPMeCDm, P_1.wMYdfxvfWvvLbEhVEajhVwWqGcOx)
	{
	}

	protected xiFtgBJFkEGohisLDEUCdkVzqFfqA(oEsAkEGDHvEMgDTALUASwjobUTaNA P_0, MWycXiczxePqggmPLkAztFDmLRbg P_1, KCMunaFkaNgqWgRslCbmdwchwrklb P_2, int P_3, int P_4, int P_5, int P_6)
		: base(P_0, P_1, P_2)
	{
		gYJyqrEKRmMuQnMfRfCQwLiQRAbl = P_3;
		MoKRZpAvhGItcwTSomHTowvzlOaA = P_4;
		HWtdANWTDRnyLjRQnlzCeyyjWrwh = P_5;
		NbcpzHCjyspgocSagZdmKRzoiYec = P_6;
		if (P_4 > 0)
		{
			lrROXAXcELDscMaQJztnfAeEiXifA = new short[P_4];
		}
		RGQAUFVTBxBuzobLMFRhKtmFkhmGA = new ButtonLoopSet(ReInput.UserData.ConfigVars.updateLoop, P_3);
		if (P_5 > 0)
		{
			FQPFIyKvXTHDmfbupZNwYKRjfnGR = new short[P_5];
		}
		if (P_6 > 0)
		{
			hMAlLjwDZwMZGgjChyCMplEyTvoE = new short[P_6 * 2];
		}
	}

	public void PIhcMdQVQdlBSRKlQLLHdPmnujlf(obZZMcwXxLpzVzsHXvFvGghQECsv P_0, byte P_1, short P_2, double P_3)
	{
		BbbKlrdSssDCUfobkjtXLSgbsfCJ = true;
		switch (P_0)
		{
		case obZZMcwXxLpzVzsHXvFvGghQECsv.Button:
			if (P_1 < gYJyqrEKRmMuQnMfRfCQwLiQRAbl)
			{
				RGQAUFVTBxBuzobLMFRhKtmFkhmGA.SetValue(P_1, P_2 > 0, P_3);
			}
			break;
		case obZZMcwXxLpzVzsHXvFvGghQECsv.Axis:
			if (P_1 < MoKRZpAvhGItcwTSomHTowvzlOaA)
			{
				lrROXAXcELDscMaQJztnfAeEiXifA[P_1] = P_2;
			}
			break;
		case obZZMcwXxLpzVzsHXvFvGghQECsv.Hat:
			if (P_1 < HWtdANWTDRnyLjRQnlzCeyyjWrwh)
			{
				FQPFIyKvXTHDmfbupZNwYKRjfnGR[P_1] = P_2;
			}
			break;
		case obZZMcwXxLpzVzsHXvFvGghQECsv.Ball:
			if (P_1 < NbcpzHCjyspgocSagZdmKRzoiYec)
			{
				hMAlLjwDZwMZGgjChyCMplEyTvoE[P_1] = P_2;
			}
			break;
		default:
			throw new NotImplementedException();
		}
	}

	public override void zmiQJSLOuISAArGdgdjGJoKMUfgA(UpdateLoopType P_0)
	{
		RGQAUFVTBxBuzobLMFRhKtmFkhmGA.SetUpdateLoop(P_0);
	}

	public override void LZNaDNvDzUOQcNPUpSnaFWtEMWuS()
	{
		RGQAUFVTBxBuzobLMFRhKtmFkhmGA.Current.ClearWasTrueThisFrame();
	}

	public float DWpXcPhQNfBOzRfRzBoNKQvjuSgk(int P_0)
	{
		if (P_0 < 0 || P_0 >= MoKRZpAvhGItcwTSomHTowvzlOaA)
		{
			return 0f;
		}
		return rggfAfiVDpqdFRJCQHfBJIKRPbsG(lrROXAXcELDscMaQJztnfAeEiXifA[P_0]);
	}

	float yTxKLgtyFntzrmhxUvcIusyQEikI.DWpXcPhQNfBOzRfRzBoNKQvjuSgk(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in DWpXcPhQNfBOzRfRzBoNKQvjuSgk
		return this.DWpXcPhQNfBOzRfRzBoNKQvjuSgk(P_0);
	}

	public int KvSDPVBCwlluwJrVQNTvtrWdBaAz(int P_0)
	{
		if (P_0 < 0 || P_0 >= MoKRZpAvhGItcwTSomHTowvzlOaA)
		{
			return 0;
		}
		return lrROXAXcELDscMaQJztnfAeEiXifA[P_0];
	}

	int yTxKLgtyFntzrmhxUvcIusyQEikI.KvSDPVBCwlluwJrVQNTvtrWdBaAz(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in KvSDPVBCwlluwJrVQNTvtrWdBaAz
		return this.KvSDPVBCwlluwJrVQNTvtrWdBaAz(P_0);
	}

	public bool JswvfwtLZJgUUfDbwpVbDIBrVULP(int P_0)
	{
		if (P_0 < 0 || P_0 >= gYJyqrEKRmMuQnMfRfCQwLiQRAbl)
		{
			return false;
		}
		return RGQAUFVTBxBuzobLMFRhKtmFkhmGA.Current.effectiveValue[P_0];
	}

	bool yTxKLgtyFntzrmhxUvcIusyQEikI.JswvfwtLZJgUUfDbwpVbDIBrVULP(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in JswvfwtLZJgUUfDbwpVbDIBrVULP
		return this.JswvfwtLZJgUUfDbwpVbDIBrVULP(P_0);
	}

	public int fcrEERdKsnzBPsEiIjnLqIKILtAxA(int P_0)
	{
		if (P_0 < 0 || P_0 >= HWtdANWTDRnyLjRQnlzCeyyjWrwh)
		{
			return -1;
		}
		return kpUbjxcxgBpmCYKsRfuufNvFAPjI(FQPFIyKvXTHDmfbupZNwYKRjfnGR[P_0]);
	}

	int yTxKLgtyFntzrmhxUvcIusyQEikI.fcrEERdKsnzBPsEiIjnLqIKILtAxA(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in fcrEERdKsnzBPsEiIjnLqIKILtAxA
		return this.fcrEERdKsnzBPsEiIjnLqIKILtAxA(P_0);
	}

	public Vector2 YtYicQGYxbTFoBXdMcvgbLPylKEc(int P_0)
	{
		return Vector2.zero;
	}

	Vector2 yTxKLgtyFntzrmhxUvcIusyQEikI.YtYicQGYxbTFoBXdMcvgbLPylKEc(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in YtYicQGYxbTFoBXdMcvgbLPylKEc
		return this.YtYicQGYxbTFoBXdMcvgbLPylKEc(P_0);
	}

	protected void XuNWwgBFjhahFRUiuquRTqDBXXAU(qdGECWatufyXebprdISidsHKfSMVB P_0)
	{
		if (!base.IRRnpgMTjKrYzqGcetDvCWuKYEag || KwJRYYJfhUodsqflVvXZeiVRhqcU.CCLweBEAvoSHRlPfUbZWWBDmfBSN(P_0) <= 0)
		{
			return;
		}
		IntPtr intPtr = KwJRYYJfhUodsqflVvXZeiVRhqcU.dKGCTnGfnagPRgcreXNVsGYTpgPjB(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return;
		}
		if (KwJRYYJfhUodsqflVvXZeiVRhqcU.xfWJzYwdjlLmUNLOBFNHNzOmDWvL(intPtr) != 0)
		{
			KwJRYYJfhUodsqflVvXZeiVRhqcU.RFQXoegMLZOLILNqgvqPRlxJGZsk(intPtr);
			return;
		}
		cxZNwqOEwGTKpZrEjQXhVlcwcsOr = new dhNBkJNkAupQgKBtEaYfBkgdrQaM(intPtr);
		tuhLtnXvFnpxQQumoMZKfTUwrCLf = true;
		rexjHIrHeVdqNaTnWvfnWogNLlDSA = KwJRYYJfhUodsqflVvXZeiVRhqcU.uIbEZRKpixBbGHIgQvfjCvvJDjod(cxZNwqOEwGTKpZrEjQXhVlcwcsOr) > 0;
		if (rexjHIrHeVdqNaTnWvfnWogNLlDSA)
		{
			OTOXngfDJGOJgMKLHycRVIUlDLEiA = 2;
		}
		FTqbEXBZjPWWYgdvuOanPAHoSZaMA = new float[OTOXngfDJGOJgMKLHycRVIUlDLEiA];
	}

	protected virtual void rgPqhBTWTsCzmakNTNxyNpXQwRaH()
	{
		XuNWwgBFjhahFRUiuquRTqDBXXAU(hbkeCkEWYDflGcGVtIpQbnSbFosqB as qdGECWatufyXebprdISidsHKfSMVB);
	}

	protected virtual void tbMzXxygiKttJtoZRwLjrBVXnPMI()
	{
		if (hbkeCkEWYDflGcGVtIpQbnSbFosqB != null && hbkeCkEWYDflGcGVtIpQbnSbFosqB.IsValid)
		{
			if (!rFeFkHsFUPsveNMjKcrrdHgMqBtBA())
			{
				hbkeCkEWYDflGcGVtIpQbnSbFosqB.Clear();
				return;
			}
			KwJRYYJfhUodsqflVvXZeiVRhqcU.xMamJbspEgAsMmiOhfopWpsDAGQBA(hbkeCkEWYDflGcGVtIpQbnSbFosqB);
			hbkeCkEWYDflGcGVtIpQbnSbFosqB.Clear();
		}
	}

	private float rggfAfiVDpqdFRJCQHfBJIKRPbsG(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.ValueInNewRange(P_0, -32767f, 32768f, -1f, 1f);
	}

	private int kpUbjxcxgBpmCYKsRfuufNvFAPjI(short P_0)
	{
		return P_0 switch
		{
			0 => -1, 
			1 => 0, 
			3 => 4500, 
			2 => 9000, 
			6 => 13500, 
			4 => 18000, 
			12 => 22500, 
			8 => 27000, 
			9 => 31500, 
			_ => -1, 
		};
	}
}
