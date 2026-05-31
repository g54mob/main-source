using System;
using Rewired;
using Rewired.Utils;
using UnityEngine;

internal class OUgdcHhQmlMrDebWxXeQGqHzlPyU : ZSbdmKbjMusBLUcKAUfzndyuuva, IDisposable, jICFRufzUQekBJMtUUbIENujmvCQ, PECWzsyRHQmqJrheqhVEuVmEOuh
{
	public readonly int qrXpdbCUzFLCBfjCDTfPHyJCus;

	public readonly int rGEuFEtJcMmFaLOCcsmbRHUjSpy;

	public readonly int EgZAgydUSUMAbFugLVPACbffArM;

	public readonly int YheYnwPCtGgZIFrqJXlGuLcCMmg;

	public readonly short[] PvuOVimuAQgJAQyUWlqeUstKFYp;

	private readonly ButtonLoopSet nbNicLBnOsnGWdvRistPFsFkCmsA;

	public readonly short[] qVQjAufJvuMgvVrWncZyChSwoIA;

	public readonly short[] riqcPAOabocemGigaHiMfrpHHeAa;

	private bool lIckeksaZUISOlJWqVjEgKdCPmH;

	public bool[] ButtonValues
	{
		get
		{
			if (nbNicLBnOsnGWdvRistPFsFkCmsA.Current == null)
			{
				return null;
			}
			return nbNicLBnOsnGWdvRistPFsFkCmsA.Current.effectiveValue;
		}
	}

	public int JoystickId => rtfomaLcybcuzWrpSDyohFWaFege;

	public int ButtonCount => qrXpdbCUzFLCBfjCDTfPHyJCus;

	public int AxisCount => rGEuFEtJcMmFaLOCcsmbRHUjSpy;

	public int HatCount => EgZAgydUSUMAbFugLVPACbffArM;

	public int BallCount => YheYnwPCtGgZIFrqJXlGuLcCMmg;

	public bool HasElements
	{
		get
		{
			if (qrXpdbCUzFLCBfjCDTfPHyJCus <= 0 && rGEuFEtJcMmFaLOCcsmbRHUjSpy <= 0 && EgZAgydUSUMAbFugLVPACbffArM <= 0)
			{
				return YheYnwPCtGgZIFrqJXlGuLcCMmg > 0;
			}
			return true;
		}
	}

	public InputSource InputSource => InputSource.SDL2;

	public bool HasEverReceivedInput => lIckeksaZUISOlJWqVjEgKdCPmH;

	public OUgdcHhQmlMrDebWxXeQGqHzlPyU(HrrSCSuLeAJEIoHkHDmudoDhKKXF nativeJoystick, nNuVsdZxHYtWhtbvImxtnLaTgc joystickInfo)
		: this(nativeJoystick, joystickInfo, bMxiloYqykvdyCGpFmJwyDskEhdH.SRzHntXksMAdDsrLdjhLausTYzs)
	{
	}

	protected OUgdcHhQmlMrDebWxXeQGqHzlPyU(HrrSCSuLeAJEIoHkHDmudoDhKKXF nativeJoystick, nNuVsdZxHYtWhtbvImxtnLaTgc joystickInfo, bMxiloYqykvdyCGpFmJwyDskEhdH type)
		: this(nativeJoystick, joystickInfo, type, joystickInfo.qrXpdbCUzFLCBfjCDTfPHyJCus, joystickInfo.rGEuFEtJcMmFaLOCcsmbRHUjSpy, joystickInfo.EgZAgydUSUMAbFugLVPACbffArM, joystickInfo.YheYnwPCtGgZIFrqJXlGuLcCMmg)
	{
	}

	protected OUgdcHhQmlMrDebWxXeQGqHzlPyU(BPRcDYVxLODpAYBLlyGWdzkrRkv nativeDevice, nNuVsdZxHYtWhtbvImxtnLaTgc joystickInfo, bMxiloYqykvdyCGpFmJwyDskEhdH type, int buttonCount, int axisCount, int hatCount, int ballCount)
		: base(nativeDevice, joystickInfo, type)
	{
		qrXpdbCUzFLCBfjCDTfPHyJCus = buttonCount;
		rGEuFEtJcMmFaLOCcsmbRHUjSpy = axisCount;
		EgZAgydUSUMAbFugLVPACbffArM = hatCount;
		YheYnwPCtGgZIFrqJXlGuLcCMmg = ballCount;
		if (axisCount > 0)
		{
			PvuOVimuAQgJAQyUWlqeUstKFYp = new short[axisCount];
		}
		nbNicLBnOsnGWdvRistPFsFkCmsA = new ButtonLoopSet(ReInput.UserData.ConfigVars.updateLoop, buttonCount);
		if (hatCount > 0)
		{
			qVQjAufJvuMgvVrWncZyChSwoIA = new short[hatCount];
		}
		if (ballCount > 0)
		{
			riqcPAOabocemGigaHiMfrpHHeAa = new short[ballCount * 2];
		}
	}

	public void aYsFvoceHxJCyLcdXQiYPSoYSvl(LMwPWmrezsdezcEObLBzCJnGuOt P_0, byte P_1, short P_2, double P_3)
	{
		lIckeksaZUISOlJWqVjEgKdCPmH = true;
		switch (P_0)
		{
		case LMwPWmrezsdezcEObLBzCJnGuOt.gjOGkVMUluYrFYtpSEboScqlrct:
			if (P_1 < qrXpdbCUzFLCBfjCDTfPHyJCus)
			{
				nbNicLBnOsnGWdvRistPFsFkCmsA.SetValue(P_1, P_2 > 0, P_3);
			}
			break;
		case LMwPWmrezsdezcEObLBzCJnGuOt.vOLImljxsbFUhrkbOfeHLOkwnVi:
			if (P_1 < rGEuFEtJcMmFaLOCcsmbRHUjSpy)
			{
				PvuOVimuAQgJAQyUWlqeUstKFYp[P_1] = P_2;
			}
			break;
		case LMwPWmrezsdezcEObLBzCJnGuOt.NOHEmYGKydBMlibSUApaFiXclRMS:
			if (P_1 < EgZAgydUSUMAbFugLVPACbffArM)
			{
				qVQjAufJvuMgvVrWncZyChSwoIA[P_1] = P_2;
			}
			break;
		case LMwPWmrezsdezcEObLBzCJnGuOt.jyUOCcUCbqHezJJbQMYZEVVePuSi:
			if (P_1 < YheYnwPCtGgZIFrqJXlGuLcCMmg)
			{
				riqcPAOabocemGigaHiMfrpHHeAa[P_1] = P_2;
			}
			break;
		default:
			throw new NotImplementedException();
		}
	}

	public override void iAnBBfDdWbgOiFHwNWqxFDtiXzYA(UpdateLoopType P_0)
	{
		nbNicLBnOsnGWdvRistPFsFkCmsA.SetUpdateLoop(P_0);
	}

	void jICFRufzUQekBJMtUUbIENujmvCQ.iAnBBfDdWbgOiFHwNWqxFDtiXzYA(UpdateLoopType P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in iAnBBfDdWbgOiFHwNWqxFDtiXzYA
		this.iAnBBfDdWbgOiFHwNWqxFDtiXzYA(P_0);
	}

	public override void AOQgnFcBlXraMNObOnRwRhydWuOc()
	{
		nbNicLBnOsnGWdvRistPFsFkCmsA.Current.ClearWasTrueThisFrame();
	}

	void jICFRufzUQekBJMtUUbIENujmvCQ.AOQgnFcBlXraMNObOnRwRhydWuOc()
	{
		//ILSpy generated this explicit interface implementation from .override directive in AOQgnFcBlXraMNObOnRwRhydWuOc
		this.AOQgnFcBlXraMNObOnRwRhydWuOc();
	}

	public float cgmAKoDiHUFFXhNnFYmsRnBjTDvK(int P_0)
	{
		if (P_0 < 0 || P_0 >= rGEuFEtJcMmFaLOCcsmbRHUjSpy)
		{
			return 0f;
		}
		return vHxjHIdWAVICgVFdsDbSkUBzYmi(PvuOVimuAQgJAQyUWlqeUstKFYp[P_0]);
	}

	float PECWzsyRHQmqJrheqhVEuVmEOuh.cgmAKoDiHUFFXhNnFYmsRnBjTDvK(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in cgmAKoDiHUFFXhNnFYmsRnBjTDvK
		return this.cgmAKoDiHUFFXhNnFYmsRnBjTDvK(P_0);
	}

	public int WOUbxNWwEzHUTNGnvIgSvstyvOT(int P_0)
	{
		if (P_0 < 0 || P_0 >= rGEuFEtJcMmFaLOCcsmbRHUjSpy)
		{
			return 0;
		}
		return PvuOVimuAQgJAQyUWlqeUstKFYp[P_0];
	}

	int PECWzsyRHQmqJrheqhVEuVmEOuh.WOUbxNWwEzHUTNGnvIgSvstyvOT(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in WOUbxNWwEzHUTNGnvIgSvstyvOT
		return this.WOUbxNWwEzHUTNGnvIgSvstyvOT(P_0);
	}

	public bool YkbkFPCFEvZkXFmauWArEBZdXhq(int P_0)
	{
		if (P_0 < 0 || P_0 >= qrXpdbCUzFLCBfjCDTfPHyJCus)
		{
			return false;
		}
		return nbNicLBnOsnGWdvRistPFsFkCmsA.Current.effectiveValue[P_0];
	}

	bool PECWzsyRHQmqJrheqhVEuVmEOuh.YkbkFPCFEvZkXFmauWArEBZdXhq(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in YkbkFPCFEvZkXFmauWArEBZdXhq
		return this.YkbkFPCFEvZkXFmauWArEBZdXhq(P_0);
	}

	public int fSCEutveMhGuUVKBWGzWxSRAfCfE(int P_0)
	{
		if (P_0 < 0 || P_0 >= EgZAgydUSUMAbFugLVPACbffArM)
		{
			return -1;
		}
		return rQKyztCqGtBcXTHttchMbRJDHhHg(qVQjAufJvuMgvVrWncZyChSwoIA[P_0]);
	}

	int PECWzsyRHQmqJrheqhVEuVmEOuh.fSCEutveMhGuUVKBWGzWxSRAfCfE(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in fSCEutveMhGuUVKBWGzWxSRAfCfE
		return this.fSCEutveMhGuUVKBWGzWxSRAfCfE(P_0);
	}

	public Vector2 YmsToycFpfNqxBeGgCgGeZujSoE(int P_0)
	{
		return Vector2.zero;
	}

	Vector2 PECWzsyRHQmqJrheqhVEuVmEOuh.YmsToycFpfNqxBeGgCgGeZujSoE(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in YmsToycFpfNqxBeGgCgGeZujSoE
		return this.YmsToycFpfNqxBeGgCgGeZujSoE(P_0);
	}

	protected void cslyQyqMhKPZthIXyQishkApvqs(HrrSCSuLeAJEIoHkHDmudoDhKKXF P_0)
	{
		if (!base.IsValid || blqhAICLjdxoAhSwtLtZkkXVbevB.UtfdXQaHoUMCbfrGzFATxXguqoHf(P_0) <= 0)
		{
			return;
		}
		IntPtr intPtr = blqhAICLjdxoAhSwtLtZkkXVbevB.foSBVygyFgpmkVkFopOJpURozyiR(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return;
		}
		if (blqhAICLjdxoAhSwtLtZkkXVbevB.QMcNsWAronojZMeKlHqlgdLqJXH(intPtr) != 0)
		{
			blqhAICLjdxoAhSwtLtZkkXVbevB.UPdeXYfjFGoFPRPwbNensRAFzutp(intPtr);
			return;
		}
		mScXfSMjCTaLGxFYQUcUOJNXsDe = new ErseYZKFEJyAQVagmkofLfyfLAx(intPtr);
		GzeDIZTvavkstRpMvjbGDbndPQjz = true;
		BcmefZCoJzXXbWISfbIeazkAKywO = blqhAICLjdxoAhSwtLtZkkXVbevB.cmoBUIrCHJmFLNRscUrjEokVrAo(mScXfSMjCTaLGxFYQUcUOJNXsDe) > 0;
		if (BcmefZCoJzXXbWISfbIeazkAKywO)
		{
			HSFfOkgYdavTAaqGDaWBzgNaSgu = 2;
		}
		UujTDJFBsuGslhSVUAlsnQWiWlvm = new float[HSFfOkgYdavTAaqGDaWBzgNaSgu];
	}

	protected override void wOxjwNmMSFgmfhRhRwhJSiFHGIO()
	{
		cslyQyqMhKPZthIXyQishkApvqs(plCidLTgAlebxCBrULnLIYCDloQo as HrrSCSuLeAJEIoHkHDmudoDhKKXF);
	}

	protected override void nriMwKbADzIwxiMwrNbEHMFyNTOT()
	{
		if (plCidLTgAlebxCBrULnLIYCDloQo != null && plCidLTgAlebxCBrULnLIYCDloQo.IsValid)
		{
			if (!BolQJaIhWbYYEqhgMprqjmvhWgM())
			{
				plCidLTgAlebxCBrULnLIYCDloQo.Clear();
				return;
			}
			blqhAICLjdxoAhSwtLtZkkXVbevB.nDWEPuIsNPGyaCccDQhVeqlCNdFc(plCidLTgAlebxCBrULnLIYCDloQo);
			plCidLTgAlebxCBrULnLIYCDloQo.Clear();
		}
	}

	private float vHxjHIdWAVICgVFdsDbSkUBzYmi(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.ValueInNewRange(P_0, -32767f, 32768f, -1f, 1f);
	}

	private int rQKyztCqGtBcXTHttchMbRJDHhHg(short P_0)
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
