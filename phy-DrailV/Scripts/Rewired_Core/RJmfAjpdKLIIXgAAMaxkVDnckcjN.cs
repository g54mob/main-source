using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal sealed class RJmfAjpdKLIIXgAAMaxkVDnckcjN<_0001> where _0001 : class
{
	private const float CwAOSpBfTnhhWEgJbFZbsspaAcxA = 60f;

	private readonly IndexedDictionary<Bytes20, List<WeakReference>> xoqXaiKKtSJeHCHXPbHqnjKvfGpp;

	private float gUyifNjuJloNuNLnBCpBleuYArBy;

	private double rFpbePfPhcMIXJDDCvzHCwpZUaCC;

	private Func<_0001, _0001, bool> HBeoyQTGIqGbuYRxqQWvaLDRsrVU;

	public float veTqgTnvzwiLZfTPvgfxbiIIdRhE
	{
		get
		{
			return gUyifNjuJloNuNLnBCpBleuYArBy;
		}
		set
		{
			if (num < 0f)
			{
				num = 0f;
			}
			gUyifNjuJloNuNLnBCpBleuYArBy = num;
		}
	}

	public RJmfAjpdKLIIXgAAMaxkVDnckcjN(Func<_0001, _0001, bool> P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException();
		}
		HBeoyQTGIqGbuYRxqQWvaLDRsrVU = P_0;
		gUyifNjuJloNuNLnBCpBleuYArBy = 60f;
		xoqXaiKKtSJeHCHXPbHqnjKvfGpp = new IndexedDictionary<Bytes20, List<WeakReference>>();
		xoqXaiKKtSJeHCHXPbHqnjKvfGpp.KeyComparer = EqualityComparerNoAlloc<Bytes20>.Default;
	}

	public _0001 RGGJWIgQTGFjrbkplAhDgRPBiCkT(Bytes20 P_0, _0001 P_1)
	{
		if (XoWrPhuuoYdElFYmsPRgFLepADbg(P_0, P_1, out var result))
		{
			return result;
		}
		fyeqCafQbFyflbNbajUvornPxfgy(P_0, P_1);
		return P_1;
	}

	public bool XoWrPhuuoYdElFYmsPRgFLepADbg(Bytes20 P_0, _0001 P_1, out _0001 P_2)
	{
		if (P_1 == null)
		{
			P_2 = null;
			return false;
		}
		NgyBxFBfbIsSVCvbvkFXltkFOpLN();
		if (!xoqXaiKKtSJeHCHXPbHqnjKvfGpp.TryGetValue(P_0, out var value))
		{
			P_2 = null;
			return false;
		}
		for (int num = value.Count - 1; num >= 0; num--)
		{
			if (!(value[num].Target is _0001 val))
			{
				value.RemoveAt(num);
			}
			else if (HBeoyQTGIqGbuYRxqQWvaLDRsrVU(P_1, val))
			{
				P_2 = val;
				return true;
			}
		}
		P_2 = null;
		return false;
	}

	public void fyeqCafQbFyflbNbajUvornPxfgy(Bytes20 P_0, _0001 P_1)
	{
		if (P_1 != null)
		{
			NgyBxFBfbIsSVCvbvkFXltkFOpLN();
			if (!xoqXaiKKtSJeHCHXPbHqnjKvfGpp.TryGetValue(P_0, out var value))
			{
				value = new List<WeakReference>();
				xoqXaiKKtSJeHCHXPbHqnjKvfGpp.Add(P_0, value);
			}
			value.Add(new WeakReference(P_1, trackResurrection: false));
		}
	}

	public void XldwkgfODhsAMdkotkEWhrHBlCPR()
	{
		for (int num = xoqXaiKKtSJeHCHXPbHqnjKvfGpp.Count - 1; num >= 0; num--)
		{
			List<WeakReference> list = xoqXaiKKtSJeHCHXPbHqnjKvfGpp[num];
			for (int num2 = list.Count - 1; num2 >= 0; num2--)
			{
				if (!list[num2].IsAlive)
				{
					list.RemoveAt(num2);
				}
			}
			if (list.Count == 0)
			{
				xoqXaiKKtSJeHCHXPbHqnjKvfGpp.RemoveAt(num);
			}
		}
		rFpbePfPhcMIXJDDCvzHCwpZUaCC = ReInput.unscaledTime + (double)veTqgTnvzwiLZfTPvgfxbiIIdRhE;
	}

	private void NgyBxFBfbIsSVCvbvkFXltkFOpLN()
	{
		if (gUyifNjuJloNuNLnBCpBleuYArBy != 0f && !(ReInput.unscaledTime < rFpbePfPhcMIXJDDCvzHCwpZUaCC))
		{
			XldwkgfODhsAMdkotkEWhrHBlCPR();
		}
	}
}
