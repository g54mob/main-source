using System;
using Rewired;
using Rewired.Utils;
using UnityEngine;

internal class miYPRdzpNwBIJFioiKeZgxqNyJM : pwTDQiUFvpemDXdsLGvmjhFSGdAg, IDisposable, ZRynwOEYvZqVXXkDHCvJHHVVthqL, foibGJXqBDBdLqGLpNATeBHsIxT
{
	public readonly int CtHmgLQvreiWMWnBZZLsTLZpuCY;

	public readonly int JDyNNdOScJLywOHcbmcaJdgZeIE;

	public readonly int ujudIdEbcBxpOOEDEHDZQOoRtUi;

	public readonly int quIzUGyDpRHLEYNLWYPNqooevEE;

	public readonly short[] nOMjACPnoBBjSDulDfcxUbWeZnZ;

	private readonly ButtonLoopSet ZlbqNhAutjDvOuKrbNbOgpomTqI;

	public readonly short[] URkXxIWTAjDVrAXmsNrpEHdKWMu;

	public readonly short[] RlKRRqdKLzFGyDHWzkmXdSSrghi;

	private bool NvMWNQFswZpXSwcgvfrXqxOwMyx;

	public bool[] ButtonValues
	{
		get
		{
			if (ZlbqNhAutjDvOuKrbNbOgpomTqI.Current == null)
			{
				return null;
			}
			return ZlbqNhAutjDvOuKrbNbOgpomTqI.Current.effectiveValue;
		}
	}

	public int JoystickId => LJXEHEIoXwILvMHVRPupoRnYJuSW;

	public int ButtonCount => CtHmgLQvreiWMWnBZZLsTLZpuCY;

	public int AxisCount => JDyNNdOScJLywOHcbmcaJdgZeIE;

	public int HatCount => ujudIdEbcBxpOOEDEHDZQOoRtUi;

	public int BallCount => quIzUGyDpRHLEYNLWYPNqooevEE;

	public bool HasElements
	{
		get
		{
			if (CtHmgLQvreiWMWnBZZLsTLZpuCY <= 0 && JDyNNdOScJLywOHcbmcaJdgZeIE <= 0 && ujudIdEbcBxpOOEDEHDZQOoRtUi <= 0)
			{
				return quIzUGyDpRHLEYNLWYPNqooevEE > 0;
			}
			return true;
		}
	}

	public InputSource InputSource => InputSource.SDL2;

	public bool HasEverReceivedInput => NvMWNQFswZpXSwcgvfrXqxOwMyx;

	public miYPRdzpNwBIJFioiKeZgxqNyJM(vKXepeHBBNWxQbCMEHitIcgRiAlb nativeJoystick, HLdBxKWeCCnyYemLsKrebKcAXOS joystickInfo)
		: this(nativeJoystick, joystickInfo, LzNTKMrXTpmUeRGPWpFpuLNCGzD.uiRYEFedDHmUTxShoQfUcCLjblSE)
	{
	}

	protected miYPRdzpNwBIJFioiKeZgxqNyJM(vKXepeHBBNWxQbCMEHitIcgRiAlb nativeJoystick, HLdBxKWeCCnyYemLsKrebKcAXOS joystickInfo, LzNTKMrXTpmUeRGPWpFpuLNCGzD type)
		: this(nativeJoystick, joystickInfo, type, joystickInfo.CtHmgLQvreiWMWnBZZLsTLZpuCY, joystickInfo.JDyNNdOScJLywOHcbmcaJdgZeIE, joystickInfo.ujudIdEbcBxpOOEDEHDZQOoRtUi, joystickInfo.quIzUGyDpRHLEYNLWYPNqooevEE)
	{
	}

	protected miYPRdzpNwBIJFioiKeZgxqNyJM(ptjPioycmViXANnKooDHvJNPPfD nativeDevice, HLdBxKWeCCnyYemLsKrebKcAXOS joystickInfo, LzNTKMrXTpmUeRGPWpFpuLNCGzD type, int buttonCount, int axisCount, int hatCount, int ballCount)
		: base(nativeDevice, joystickInfo, type)
	{
		CtHmgLQvreiWMWnBZZLsTLZpuCY = buttonCount;
		JDyNNdOScJLywOHcbmcaJdgZeIE = axisCount;
		ujudIdEbcBxpOOEDEHDZQOoRtUi = hatCount;
		quIzUGyDpRHLEYNLWYPNqooevEE = ballCount;
		if (axisCount > 0)
		{
			nOMjACPnoBBjSDulDfcxUbWeZnZ = new short[axisCount];
		}
		ZlbqNhAutjDvOuKrbNbOgpomTqI = new ButtonLoopSet(ReInput.UserData.ConfigVars.updateLoop, buttonCount);
		if (hatCount > 0)
		{
			URkXxIWTAjDVrAXmsNrpEHdKWMu = new short[hatCount];
		}
		if (ballCount > 0)
		{
			RlKRRqdKLzFGyDHWzkmXdSSrghi = new short[ballCount * 2];
		}
	}

	public void GcIuKOHgXujXqCTdAuwBBVguUoX(pWCuWOCOMjTBfvspqDFuAKrmWrL P_0, byte P_1, short P_2, double P_3)
	{
		NvMWNQFswZpXSwcgvfrXqxOwMyx = true;
		switch (P_0)
		{
		case pWCuWOCOMjTBfvspqDFuAKrmWrL.MSkOFxndGdlYTXhRRInvAJPFWqV:
			if (P_1 < CtHmgLQvreiWMWnBZZLsTLZpuCY)
			{
				ZlbqNhAutjDvOuKrbNbOgpomTqI.SetValue(P_1, P_2 > 0, P_3);
			}
			break;
		case pWCuWOCOMjTBfvspqDFuAKrmWrL.ZEpADHaQXaPbbdiPXFeEtXVONrIe:
			if (P_1 < JDyNNdOScJLywOHcbmcaJdgZeIE)
			{
				nOMjACPnoBBjSDulDfcxUbWeZnZ[P_1] = P_2;
			}
			break;
		case pWCuWOCOMjTBfvspqDFuAKrmWrL.rKdSFgrHJoOfrtyiXMxbskeUTru:
			if (P_1 < ujudIdEbcBxpOOEDEHDZQOoRtUi)
			{
				URkXxIWTAjDVrAXmsNrpEHdKWMu[P_1] = P_2;
			}
			break;
		case pWCuWOCOMjTBfvspqDFuAKrmWrL.TEyGrCJrQheJliSViDEILDgflsHy:
			if (P_1 < quIzUGyDpRHLEYNLWYPNqooevEE)
			{
				RlKRRqdKLzFGyDHWzkmXdSSrghi[P_1] = P_2;
			}
			break;
		default:
			throw new NotImplementedException();
		}
	}

	public override void QTPiZFmnRsxmyQYmMuIoBQkOtfg(UpdateLoopType P_0)
	{
		ZlbqNhAutjDvOuKrbNbOgpomTqI.SetUpdateLoop(P_0);
	}

	void ZRynwOEYvZqVXXkDHCvJHHVVthqL.QTPiZFmnRsxmyQYmMuIoBQkOtfg(UpdateLoopType P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in QTPiZFmnRsxmyQYmMuIoBQkOtfg
		this.QTPiZFmnRsxmyQYmMuIoBQkOtfg(P_0);
	}

	public override void yBuuCvoSMWjNMRELDWTrhiPPkXs()
	{
		ZlbqNhAutjDvOuKrbNbOgpomTqI.Current.ClearWasTrueThisFrame();
	}

	void ZRynwOEYvZqVXXkDHCvJHHVVthqL.yBuuCvoSMWjNMRELDWTrhiPPkXs()
	{
		//ILSpy generated this explicit interface implementation from .override directive in yBuuCvoSMWjNMRELDWTrhiPPkXs
		this.yBuuCvoSMWjNMRELDWTrhiPPkXs();
	}

	public float QTYKdOZLkJEqXkCFTAyzbbojlRXP(int P_0)
	{
		if (P_0 < 0 || P_0 >= JDyNNdOScJLywOHcbmcaJdgZeIE)
		{
			return 0f;
		}
		return XyZKBsEvzMdgqWRJtXUHgAyDOfE(nOMjACPnoBBjSDulDfcxUbWeZnZ[P_0]);
	}

	float foibGJXqBDBdLqGLpNATeBHsIxT.QTYKdOZLkJEqXkCFTAyzbbojlRXP(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in QTYKdOZLkJEqXkCFTAyzbbojlRXP
		return this.QTYKdOZLkJEqXkCFTAyzbbojlRXP(P_0);
	}

	public int sSaCMjxEtovMROWRuqhNlTAUGMj(int P_0)
	{
		if (P_0 < 0 || P_0 >= JDyNNdOScJLywOHcbmcaJdgZeIE)
		{
			return 0;
		}
		return nOMjACPnoBBjSDulDfcxUbWeZnZ[P_0];
	}

	int foibGJXqBDBdLqGLpNATeBHsIxT.sSaCMjxEtovMROWRuqhNlTAUGMj(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in sSaCMjxEtovMROWRuqhNlTAUGMj
		return this.sSaCMjxEtovMROWRuqhNlTAUGMj(P_0);
	}

	public bool kAVHgdphgcHqDOwQpMCcCbwXpBK(int P_0)
	{
		if (P_0 < 0 || P_0 >= CtHmgLQvreiWMWnBZZLsTLZpuCY)
		{
			return false;
		}
		return ZlbqNhAutjDvOuKrbNbOgpomTqI.Current.effectiveValue[P_0];
	}

	bool foibGJXqBDBdLqGLpNATeBHsIxT.kAVHgdphgcHqDOwQpMCcCbwXpBK(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in kAVHgdphgcHqDOwQpMCcCbwXpBK
		return this.kAVHgdphgcHqDOwQpMCcCbwXpBK(P_0);
	}

	public int FFydkTOruaTjWQcdDbKNjjyoDOR(int P_0)
	{
		if (P_0 < 0 || P_0 >= ujudIdEbcBxpOOEDEHDZQOoRtUi)
		{
			return -1;
		}
		return XueIYXztdsFVZOaFsIdDifmfnvjl(URkXxIWTAjDVrAXmsNrpEHdKWMu[P_0]);
	}

	int foibGJXqBDBdLqGLpNATeBHsIxT.FFydkTOruaTjWQcdDbKNjjyoDOR(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in FFydkTOruaTjWQcdDbKNjjyoDOR
		return this.FFydkTOruaTjWQcdDbKNjjyoDOR(P_0);
	}

	public Vector2 kCEDeSLtSqtuxMWydlgDeMNLgyk(int P_0)
	{
		return Vector2.zero;
	}

	Vector2 foibGJXqBDBdLqGLpNATeBHsIxT.kCEDeSLtSqtuxMWydlgDeMNLgyk(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in kCEDeSLtSqtuxMWydlgDeMNLgyk
		return this.kCEDeSLtSqtuxMWydlgDeMNLgyk(P_0);
	}

	protected void IVFIzIJvYJoqtsnxvuqjfBdJEeSC(vKXepeHBBNWxQbCMEHitIcgRiAlb P_0)
	{
		if (!base.IsValid || BiWWxqvSWmGXOmGGsphCczktuxZ.ihXPyokvPBDxteAksPGMFcDYjara(P_0) <= 0)
		{
			return;
		}
		IntPtr intPtr = BiWWxqvSWmGXOmGGsphCczktuxZ.TRmmsYFlextJyvKnpHEUjGuKgiSY(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return;
		}
		if (BiWWxqvSWmGXOmGGsphCczktuxZ.gaKaQEjPSeTGtBPEgHWpqqUQLnt(intPtr) != 0)
		{
			BiWWxqvSWmGXOmGGsphCczktuxZ.qZFMqsWYePuaDMJOcTqaLWxxMmN(intPtr);
			return;
		}
		QOYytipvSCHmAwfxVdYJGuojHcW = new aINntfhbYTaQKAmfinwZBeBKqF(intPtr);
		cpQVjvupHyjLpGfkcdvBivUNnENG = true;
		tOEpKxVogqkVrFGkkIUzzYTieFG = BiWWxqvSWmGXOmGGsphCczktuxZ.AZGhkmOuVIkyRMKSfdBkUDyrQeO(QOYytipvSCHmAwfxVdYJGuojHcW) > 0;
		if (tOEpKxVogqkVrFGkkIUzzYTieFG)
		{
			hFnuhMXoYvgyCariIlYOShuWnqMq = 2;
		}
		sDNFsdyhHrHBvJDtFrvlqKzSgxBD = new float[hFnuhMXoYvgyCariIlYOShuWnqMq];
	}

	protected override void CSPUAvVthOHwviBOGixSYqqbAFo()
	{
		IVFIzIJvYJoqtsnxvuqjfBdJEeSC(RHeWMzmodaOUlWLBNkhSGZzZbgs as vKXepeHBBNWxQbCMEHitIcgRiAlb);
	}

	protected override void ZnQBRyDCmgpLrEVGoQfXyGsUCDcb()
	{
		if (RHeWMzmodaOUlWLBNkhSGZzZbgs != null && RHeWMzmodaOUlWLBNkhSGZzZbgs.IsValid)
		{
			if (!tEDHkWhnncgdEqnOLjfbOlQRoucd())
			{
				RHeWMzmodaOUlWLBNkhSGZzZbgs.Clear();
				return;
			}
			BiWWxqvSWmGXOmGGsphCczktuxZ.VWeogUlnoUvJwzMEGtbMyWQxGzt(RHeWMzmodaOUlWLBNkhSGZzZbgs);
			RHeWMzmodaOUlWLBNkhSGZzZbgs.Clear();
		}
	}

	private float XyZKBsEvzMdgqWRJtXUHgAyDOfE(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.ValueInNewRange(P_0, -32767f, 32768f, -1f, 1f);
	}

	private int XueIYXztdsFVZOaFsIdDifmfnvjl(short P_0)
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
