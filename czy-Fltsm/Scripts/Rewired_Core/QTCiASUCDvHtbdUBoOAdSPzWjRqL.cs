using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal sealed class QTCiASUCDvHtbdUBoOAdSPzWjRqL<_0001> where _0001 : class
{
	private const float ulPMOhpviPjcVLiYmLgtQVQGTpVP = 60f;

	private readonly IndexedDictionary<Bytes20, List<WeakReference>> CpusnyELAkjMDDaPFhAWBPajPHsLc;

	private float WJJkmQLFCtjuqURvAAHfeJpIBULtA;

	private double WrCqGChiLfnjJuIjazYNskpkvSoG;

	private Func<_0001, _0001, bool> eflWIdijWgEtVeqYJKbCrkhoccPxA;

	public float rzogcPneJTIZqQhMlgXTPaAUGudb
	{
		get
		{
			return WJJkmQLFCtjuqURvAAHfeJpIBULtA;
		}
		set
		{
			if (num < 0f)
			{
				num = 0f;
			}
			WJJkmQLFCtjuqURvAAHfeJpIBULtA = num;
		}
	}

	public QTCiASUCDvHtbdUBoOAdSPzWjRqL(Func<_0001, _0001, bool> P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException();
		}
		eflWIdijWgEtVeqYJKbCrkhoccPxA = P_0;
		WJJkmQLFCtjuqURvAAHfeJpIBULtA = 60f;
		CpusnyELAkjMDDaPFhAWBPajPHsLc = new IndexedDictionary<Bytes20, List<WeakReference>>();
		CpusnyELAkjMDDaPFhAWBPajPHsLc.KeyComparer = EqualityComparerNoAlloc<Bytes20>.Default;
	}

	public _0001 jmbCpDDBCpCHqKMftVWBFAAjqwiI(Bytes20 P_0, _0001 P_1)
	{
		if (XeiOWkonFmtJDikoHyyLMWSuTCbj(P_0, P_1, out var result))
		{
			return result;
		}
		oKikmsntPJTPfJPjjdAXQftayNjT(P_0, P_1);
		return P_1;
	}

	public bool XeiOWkonFmtJDikoHyyLMWSuTCbj(Bytes20 P_0, _0001 P_1, out _0001 P_2)
	{
		if (P_1 == null)
		{
			P_2 = null;
			return false;
		}
		yUHduvedNGZSGUGlWKTIrSBONNJeb();
		if (!CpusnyELAkjMDDaPFhAWBPajPHsLc.TryGetValue(P_0, out var value))
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
			else if (eflWIdijWgEtVeqYJKbCrkhoccPxA(P_1, val))
			{
				P_2 = val;
				return true;
			}
		}
		P_2 = null;
		return false;
	}

	public void oKikmsntPJTPfJPjjdAXQftayNjT(Bytes20 P_0, _0001 P_1)
	{
		if (P_1 != null)
		{
			yUHduvedNGZSGUGlWKTIrSBONNJeb();
			if (!CpusnyELAkjMDDaPFhAWBPajPHsLc.TryGetValue(P_0, out var value))
			{
				value = new List<WeakReference>();
				CpusnyELAkjMDDaPFhAWBPajPHsLc.Add(P_0, value);
			}
			value.Add(new WeakReference(P_1, trackResurrection: false));
		}
	}

	public void CcoutLreyADxSwBdqNEEpQjsneIl()
	{
		for (int num = CpusnyELAkjMDDaPFhAWBPajPHsLc.Count - 1; num >= 0; num--)
		{
			List<WeakReference> list = CpusnyELAkjMDDaPFhAWBPajPHsLc[num];
			for (int num2 = list.Count - 1; num2 >= 0; num2--)
			{
				if (!list[num2].IsAlive)
				{
					list.RemoveAt(num2);
				}
			}
			if (list.Count == 0)
			{
				CpusnyELAkjMDDaPFhAWBPajPHsLc.RemoveAt(num);
			}
		}
		WrCqGChiLfnjJuIjazYNskpkvSoG = ReInput.unscaledTime + (double)rzogcPneJTIZqQhMlgXTPaAUGudb;
	}

	private void yUHduvedNGZSGUGlWKTIrSBONNJeb()
	{
		if (WJJkmQLFCtjuqURvAAHfeJpIBULtA != 0f && !(ReInput.unscaledTime < WrCqGChiLfnjJuIjazYNskpkvSoG))
		{
			CcoutLreyADxSwBdqNEEpQjsneIl();
		}
	}
}
