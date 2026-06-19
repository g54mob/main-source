using System;
using Rewired;
using Rewired.Utils.Classes.Data;

internal sealed class McrWGzywssbBXMqJxDJhUtfikIyT<_0001> where _0001 : class
{
	private readonly IndexedDictionary<uint, WeakReference> UCAdIzJhmgSIBoVVnUeJIJGXLPfo;

	private Id HIefZLGUWrPOYeQmiuJayGmiBDdDA;

	private double CySxCOcAYrNpMRxQJXuwxjNupcxh;

	private float NriUYondzGNLwKcmrXgAXtBnCaWb;

	public McrWGzywssbBXMqJxDJhUtfikIyT()
	{
		UCAdIzJhmgSIBoVVnUeJIJGXLPfo = new IndexedDictionary<uint, WeakReference>();
		HIefZLGUWrPOYeQmiuJayGmiBDdDA = 1u;
	}

	public McrWGzywssbBXMqJxDJhUtfikIyT(float P_0)
		: this()
	{
		NriUYondzGNLwKcmrXgAXtBnCaWb = P_0;
	}

	public bool AjTOOgplobdBpHbfeczgdzEhmxxJB(uint P_0, out _0001 P_1)
	{
		if (!UCAdIzJhmgSIBoVVnUeJIJGXLPfo.TryGetValue(P_0, out var value))
		{
			P_1 = null;
			return false;
		}
		if (!(value.Target is _0001 val))
		{
			UCAdIzJhmgSIBoVVnUeJIJGXLPfo.Remove(P_0);
			P_1 = null;
			return false;
		}
		P_1 = val;
		return true;
	}

	public uint zOdcayhaCQLqdzGDlEGoDmPmrGtEA(_0001 P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException();
		}
		HfPFMsjfMBGNkpOLVIYLFAOkVRYEB();
		UCAdIzJhmgSIBoVVnUeJIJGXLPfo.SetValue(HIefZLGUWrPOYeQmiuJayGmiBDdDA.id, new WeakReference(P_0, trackResurrection: false));
		HIefZLGUWrPOYeQmiuJayGmiBDdDA.Increment();
		return HIefZLGUWrPOYeQmiuJayGmiBDdDA.id;
	}

	public bool wXGmDEAFNfELnKYttEiFilWASdzpA(uint P_0)
	{
		HfPFMsjfMBGNkpOLVIYLFAOkVRYEB();
		return UCAdIzJhmgSIBoVVnUeJIJGXLPfo.Remove(P_0);
	}

	public void EgJtVgbhmILaUKPMRuZxmnpgzHDG()
	{
		for (int num = UCAdIzJhmgSIBoVVnUeJIJGXLPfo.Count - 1; num >= 0; num--)
		{
			if (!UCAdIzJhmgSIBoVVnUeJIJGXLPfo[num].IsAlive)
			{
				UCAdIzJhmgSIBoVVnUeJIJGXLPfo.RemoveAt(num);
			}
		}
		CySxCOcAYrNpMRxQJXuwxjNupcxh = ReInput.unscaledTime + (double)NriUYondzGNLwKcmrXgAXtBnCaWb;
	}

	public void uHSsPAZdPIflOinwUJuyDGBTZTVZ(Action<_0001> P_0)
	{
		for (int num = UCAdIzJhmgSIBoVVnUeJIJGXLPfo.Count - 1; num >= 0; num--)
		{
			if (!(UCAdIzJhmgSIBoVVnUeJIJGXLPfo[num].Target is _0001 obj))
			{
				UCAdIzJhmgSIBoVVnUeJIJGXLPfo.RemoveAt(num);
			}
			else
			{
				P_0(obj);
			}
		}
		CySxCOcAYrNpMRxQJXuwxjNupcxh = ReInput.unscaledTime + (double)NriUYondzGNLwKcmrXgAXtBnCaWb;
	}

	private void HfPFMsjfMBGNkpOLVIYLFAOkVRYEB()
	{
		if (!(NriUYondzGNLwKcmrXgAXtBnCaWb <= 0f) && ReInput.unscaledTime > CySxCOcAYrNpMRxQJXuwxjNupcxh)
		{
			EgJtVgbhmILaUKPMRuZxmnpgzHDG();
		}
	}
}
