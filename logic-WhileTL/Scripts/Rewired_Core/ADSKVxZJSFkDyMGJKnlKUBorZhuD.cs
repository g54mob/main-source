using System;
using Rewired;
using Rewired.Utils;
using UnityEngine;

internal class ADSKVxZJSFkDyMGJKnlKUBorZhuD : RfFMKuqZhISUwrYUdqXdXiowfWsg, IDisposable, tGuhVMgjQuttsfzYtqPAxiAztnUe, LjmiwQfcsmzrgAYaHEMKGLaOgKjY
{
	public readonly int yrHZhNoSpLMEzcgptuOphbaHHcuiA;

	public readonly int jhazYdoXweuxJmcAJnlflvXbFGyT;

	public readonly int UHjJkIgmjqCHCDkouUWAlcntNjAwA;

	public readonly int AKICkIcAdkhbleuthiWOLIXZQYwrB;

	public readonly short[] LSYDeKrFvijfzfACzZugiGtChHjeA;

	private readonly ButtonLoopSet pojMmbknKWFDvUZlPyBZQXhYyakC;

	public readonly short[] gUswxWwWIOziAgeKWExkyoKyWpYJ;

	public readonly short[] bNGrQoPVIKjtLbcsZMvSHkzZOcUr;

	private bool pfESQMflewZfzKfYXhoSMGpQFgFkA;

	public bool[] UmnYtEFpTnMxrLPPvjrPmmJjZJsS
	{
		get
		{
			if (pojMmbknKWFDvUZlPyBZQXhYyakC.Current == null)
			{
				return null;
			}
			return pojMmbknKWFDvUZlPyBZQXhYyakC.Current.effectiveValue;
		}
	}

	int LjmiwQfcsmzrgAYaHEMKGLaOgKjY.ZKOJoCbGYCFJRapdwLXBYyKWqOaFA => zEDIuMMjZVfjCnadvapadpKgQekjA;

	int LjmiwQfcsmzrgAYaHEMKGLaOgKjY.JVbQQuOQHNEfCeDatYqbXWSpjigo => yrHZhNoSpLMEzcgptuOphbaHHcuiA;

	int LjmiwQfcsmzrgAYaHEMKGLaOgKjY.QIkbAdXQeDUvOIbnNgsPKkBYsPNEA => jhazYdoXweuxJmcAJnlflvXbFGyT;

	int LjmiwQfcsmzrgAYaHEMKGLaOgKjY.xllVtNnMCTvELjBoxAaiEMrUHepX => UHjJkIgmjqCHCDkouUWAlcntNjAwA;

	int LjmiwQfcsmzrgAYaHEMKGLaOgKjY.PQNOLVcFFdEMknPzGalHRmNHWgGe => AKICkIcAdkhbleuthiWOLIXZQYwrB;

	bool LjmiwQfcsmzrgAYaHEMKGLaOgKjY.xlVNFZHlkekyykMpUqLLILPsaFSD
	{
		get
		{
			if (yrHZhNoSpLMEzcgptuOphbaHHcuiA <= 0 && jhazYdoXweuxJmcAJnlflvXbFGyT <= 0 && UHjJkIgmjqCHCDkouUWAlcntNjAwA <= 0)
			{
				return AKICkIcAdkhbleuthiWOLIXZQYwrB > 0;
			}
			return true;
		}
	}

	InputSource LjmiwQfcsmzrgAYaHEMKGLaOgKjY.EPyfSrSomRsxmlVBttAjtBtiqyoN => InputSource.SDL2;

	bool LjmiwQfcsmzrgAYaHEMKGLaOgKjY.BFKBjOiPeqPvmoXfkMsienbYNVrOA => pfESQMflewZfzKfYXhoSMGpQFgFkA;

	public ADSKVxZJSFkDyMGJKnlKUBorZhuD(TWLwCilJIoPozLulqzpoQBubYmDC P_0, dpvxMMmJEhBJrUwdSFTnDVVoyLgw P_1)
		: this(P_0, P_1, zbJLZSTqDWgGDxfpkJCsEboqOzbu.Joystick)
	{
	}

	protected ADSKVxZJSFkDyMGJKnlKUBorZhuD(TWLwCilJIoPozLulqzpoQBubYmDC P_0, dpvxMMmJEhBJrUwdSFTnDVVoyLgw P_1, zbJLZSTqDWgGDxfpkJCsEboqOzbu P_2)
		: this(P_0, P_1, P_2, P_1.yrHZhNoSpLMEzcgptuOphbaHHcuiA, P_1.jhazYdoXweuxJmcAJnlflvXbFGyT, P_1.UHjJkIgmjqCHCDkouUWAlcntNjAwA, P_1.AKICkIcAdkhbleuthiWOLIXZQYwrB)
	{
	}

	protected ADSKVxZJSFkDyMGJKnlKUBorZhuD(NhrfGoMHswTOhjaTEzxQNlazmLzs P_0, dpvxMMmJEhBJrUwdSFTnDVVoyLgw P_1, zbJLZSTqDWgGDxfpkJCsEboqOzbu P_2, int P_3, int P_4, int P_5, int P_6)
		: base(P_0, P_1, P_2)
	{
		yrHZhNoSpLMEzcgptuOphbaHHcuiA = P_3;
		jhazYdoXweuxJmcAJnlflvXbFGyT = P_4;
		UHjJkIgmjqCHCDkouUWAlcntNjAwA = P_5;
		AKICkIcAdkhbleuthiWOLIXZQYwrB = P_6;
		if (P_4 > 0)
		{
			LSYDeKrFvijfzfACzZugiGtChHjeA = new short[P_4];
		}
		pojMmbknKWFDvUZlPyBZQXhYyakC = new ButtonLoopSet(ReInput.UserData.ConfigVars.updateLoop, P_3);
		if (P_5 > 0)
		{
			gUswxWwWIOziAgeKWExkyoKyWpYJ = new short[P_5];
		}
		if (P_6 > 0)
		{
			bNGrQoPVIKjtLbcsZMvSHkzZOcUr = new short[P_6 * 2];
		}
	}

	public void oZQllQxQuNaPXytzirxUjNaKuQtr(PfGsjQeDIWurWNVMIWGjsffAaCvbA P_0, byte P_1, short P_2, double P_3)
	{
		pfESQMflewZfzKfYXhoSMGpQFgFkA = true;
		switch (P_0)
		{
		case PfGsjQeDIWurWNVMIWGjsffAaCvbA.Button:
			if (P_1 < yrHZhNoSpLMEzcgptuOphbaHHcuiA)
			{
				pojMmbknKWFDvUZlPyBZQXhYyakC.SetValue(P_1, P_2 > 0, P_3);
			}
			break;
		case PfGsjQeDIWurWNVMIWGjsffAaCvbA.Axis:
			if (P_1 < jhazYdoXweuxJmcAJnlflvXbFGyT)
			{
				LSYDeKrFvijfzfACzZugiGtChHjeA[P_1] = P_2;
			}
			break;
		case PfGsjQeDIWurWNVMIWGjsffAaCvbA.Hat:
			if (P_1 < UHjJkIgmjqCHCDkouUWAlcntNjAwA)
			{
				gUswxWwWIOziAgeKWExkyoKyWpYJ[P_1] = P_2;
			}
			break;
		case PfGsjQeDIWurWNVMIWGjsffAaCvbA.Ball:
			if (P_1 < AKICkIcAdkhbleuthiWOLIXZQYwrB)
			{
				bNGrQoPVIKjtLbcsZMvSHkzZOcUr[P_1] = P_2;
			}
			break;
		default:
			throw new NotImplementedException();
		}
	}

	public virtual void sOLNzBCCbZmFXkMugfndpShqgrUP(UpdateLoopType P_0)
	{
		pojMmbknKWFDvUZlPyBZQXhYyakC.SetUpdateLoop(P_0);
	}

	public virtual void OJwRTvWKOprkrbxNjAvuBwrxssUE()
	{
		pojMmbknKWFDvUZlPyBZQXhYyakC.Current.ClearWasTrueThisFrame();
	}

	public float oPUqHQlcsmYpoqEbnvDqDlLXDAzJ(int P_0)
	{
		if (P_0 < 0 || P_0 >= jhazYdoXweuxJmcAJnlflvXbFGyT)
		{
			return 0f;
		}
		return vmDuXgugbnrLNmebZHQOEAZlrYcFA(LSYDeKrFvijfzfACzZugiGtChHjeA[P_0]);
	}

	float LjmiwQfcsmzrgAYaHEMKGLaOgKjY.oPUqHQlcsmYpoqEbnvDqDlLXDAzJ(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in oPUqHQlcsmYpoqEbnvDqDlLXDAzJ
		return this.oPUqHQlcsmYpoqEbnvDqDlLXDAzJ(P_0);
	}

	public int UGeLHrRzdPsJcsRnELxCPlnuRYHN(int P_0)
	{
		if (P_0 < 0 || P_0 >= jhazYdoXweuxJmcAJnlflvXbFGyT)
		{
			return 0;
		}
		return LSYDeKrFvijfzfACzZugiGtChHjeA[P_0];
	}

	int LjmiwQfcsmzrgAYaHEMKGLaOgKjY.UGeLHrRzdPsJcsRnELxCPlnuRYHN(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in UGeLHrRzdPsJcsRnELxCPlnuRYHN
		return this.UGeLHrRzdPsJcsRnELxCPlnuRYHN(P_0);
	}

	public bool QJBSSzPioDBMmqZkZEFzajPlEHwp(int P_0)
	{
		if (P_0 < 0 || P_0 >= yrHZhNoSpLMEzcgptuOphbaHHcuiA)
		{
			return false;
		}
		return pojMmbknKWFDvUZlPyBZQXhYyakC.Current.effectiveValue[P_0];
	}

	bool LjmiwQfcsmzrgAYaHEMKGLaOgKjY.QJBSSzPioDBMmqZkZEFzajPlEHwp(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in QJBSSzPioDBMmqZkZEFzajPlEHwp
		return this.QJBSSzPioDBMmqZkZEFzajPlEHwp(P_0);
	}

	public int ndeoaPoctPAhxDaPbxgStFXOlGvAA(int P_0)
	{
		if (P_0 < 0 || P_0 >= UHjJkIgmjqCHCDkouUWAlcntNjAwA)
		{
			return -1;
		}
		return zoRVHVjzJzloyVfCihAXOJVfpNI(gUswxWwWIOziAgeKWExkyoKyWpYJ[P_0]);
	}

	int LjmiwQfcsmzrgAYaHEMKGLaOgKjY.ndeoaPoctPAhxDaPbxgStFXOlGvAA(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in ndeoaPoctPAhxDaPbxgStFXOlGvAA
		return this.ndeoaPoctPAhxDaPbxgStFXOlGvAA(P_0);
	}

	public Vector2 QLOZdYxdMRnQUsvSVepUItqtCySN(int P_0)
	{
		return Vector2.zero;
	}

	Vector2 LjmiwQfcsmzrgAYaHEMKGLaOgKjY.QLOZdYxdMRnQUsvSVepUItqtCySN(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in QLOZdYxdMRnQUsvSVepUItqtCySN
		return this.QLOZdYxdMRnQUsvSVepUItqtCySN(P_0);
	}

	protected void kJyEMxEUufMCYTHVEpoPEGrbyyDA(TWLwCilJIoPozLulqzpoQBubYmDC P_0)
	{
		if (!base.LKcEAURAumgcFHtHkURWCAbgtWzMA || xfYwdkRYAVrddGoiGqMNEgTVIqto.WcVlxqKTPuDcUEAOGBNDddagooPf(P_0) <= 0)
		{
			return;
		}
		IntPtr intPtr = xfYwdkRYAVrddGoiGqMNEgTVIqto.lkebOCveqYteRJTNDTXPyITiglwk(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return;
		}
		if (xfYwdkRYAVrddGoiGqMNEgTVIqto.GDEzpYZMEDFjQIviYfSiEGxksJVac(intPtr) != 0)
		{
			xfYwdkRYAVrddGoiGqMNEgTVIqto.EcTppoqfqiMAqiOaOtRhvSCTqjfK(intPtr);
			return;
		}
		kXYsfcXkEhxshKiPfHBMynNHmrkl = new UWIIAtBOdpDpfAgqZwbpKxabtOzhA(intPtr);
		GXIsLjYnFLdUIkcQUaJEZbpvIuhF = true;
		RTIZFjxEuXUpKxeIAhVoZqkQtggM = xfYwdkRYAVrddGoiGqMNEgTVIqto.oJSlemacqrgOwjkqZestWuoPgGiuA(kXYsfcXkEhxshKiPfHBMynNHmrkl) > 0;
		if (RTIZFjxEuXUpKxeIAhVoZqkQtggM)
		{
			TvfyCOtyYKIlzJHUmJzZBRLesBkj = 2;
		}
		ETJbJfYTeYrfYpGFfiTeuSQsdXhH = new float[TvfyCOtyYKIlzJHUmJzZBRLesBkj];
	}

	protected override void qHXDHjpLdvonSISbuCvBadJTzSCo()
	{
		kJyEMxEUufMCYTHVEpoPEGrbyyDA(jfuDZbCNhViDSoBbrFeXwqMhraUn as TWLwCilJIoPozLulqzpoQBubYmDC);
	}

	protected override void pyEdAugSuZAnEzycIGsCcUXaRPEk()
	{
		if (jfuDZbCNhViDSoBbrFeXwqMhraUn != null && jfuDZbCNhViDSoBbrFeXwqMhraUn.IsValid)
		{
			if (!RHNlhOZBjLkLbRKmlCekFXbpaeAdb())
			{
				jfuDZbCNhViDSoBbrFeXwqMhraUn.Clear();
				return;
			}
			xfYwdkRYAVrddGoiGqMNEgTVIqto.pLazBODcgrltBHdkqihBCHrPhtBf(jfuDZbCNhViDSoBbrFeXwqMhraUn);
			jfuDZbCNhViDSoBbrFeXwqMhraUn.Clear();
		}
	}

	private float vmDuXgugbnrLNmebZHQOEAZlrYcFA(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.ValueInNewRange(P_0, -32767f, 32768f, -1f, 1f);
	}

	private int zoRVHVjzJzloyVfCihAXOJVfpNI(short P_0)
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
