using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal sealed class frkDecQuGtqloMwKYmMMIfIonbfk<_0001> where _0001 : class
{
	private const float TphrpBbpvXzvIgnRABGKjKreUpQwA = 60f;

	private readonly IndexedDictionary<Bytes20, List<WeakReference>> hCWaASCYNuWZMROEjzezVSHhhZlo;

	private float fJtiDeZVXbtxrrEwwazOHKGkAICS;

	private double byHJestfhHuIaNigCRuuqUwElbYb;

	private Func<_0001, _0001, bool> PsHwzDaKBqakCNOBnKDviZCKCmKV;

	public float AIWHWYzjCPZQlnmiPWimHPYgKtkb
	{
		get
		{
			return fJtiDeZVXbtxrrEwwazOHKGkAICS;
		}
		set
		{
			if (num < 0f)
			{
				num = 0f;
			}
			fJtiDeZVXbtxrrEwwazOHKGkAICS = num;
		}
	}

	public frkDecQuGtqloMwKYmMMIfIonbfk(Func<_0001, _0001, bool> P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException();
		}
		PsHwzDaKBqakCNOBnKDviZCKCmKV = P_0;
		fJtiDeZVXbtxrrEwwazOHKGkAICS = 60f;
		hCWaASCYNuWZMROEjzezVSHhhZlo = new IndexedDictionary<Bytes20, List<WeakReference>>();
		hCWaASCYNuWZMROEjzezVSHhhZlo.KeyComparer = EqualityComparerNoAlloc<Bytes20>.Default;
	}

	public _0001 WiXlndVHOhDtrdahVzEwBbrFiFlF(Bytes20 P_0, _0001 P_1)
	{
		if (ygSxKCwLEisnUFvjzYlmWjzWgFws(P_0, P_1, out var result))
		{
			return result;
		}
		BJUFZEhwGLMUmyBgFeUcAyOMNcmk(P_0, P_1);
		return P_1;
	}

	public bool ygSxKCwLEisnUFvjzYlmWjzWgFws(Bytes20 P_0, _0001 P_1, out _0001 P_2)
	{
		if (P_1 == null)
		{
			P_2 = null;
			return false;
		}
		DEzcHFcbSWZDZblmkIttFOcgsTUVb();
		if (!hCWaASCYNuWZMROEjzezVSHhhZlo.TryGetValue(P_0, out var value))
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
			else if (PsHwzDaKBqakCNOBnKDviZCKCmKV(P_1, val))
			{
				P_2 = val;
				return true;
			}
		}
		P_2 = null;
		return false;
	}

	public void BJUFZEhwGLMUmyBgFeUcAyOMNcmk(Bytes20 P_0, _0001 P_1)
	{
		if (P_1 != null)
		{
			DEzcHFcbSWZDZblmkIttFOcgsTUVb();
			if (!hCWaASCYNuWZMROEjzezVSHhhZlo.TryGetValue(P_0, out var value))
			{
				value = new List<WeakReference>();
				hCWaASCYNuWZMROEjzezVSHhhZlo.Add(P_0, value);
			}
			value.Add(new WeakReference(P_1, trackResurrection: false));
		}
	}

	public void pPSZwhpunQKBHDGuIBbpfkUKypJP()
	{
		for (int num = hCWaASCYNuWZMROEjzezVSHhhZlo.Count - 1; num >= 0; num--)
		{
			List<WeakReference> list = hCWaASCYNuWZMROEjzezVSHhhZlo[num];
			for (int num2 = list.Count - 1; num2 >= 0; num2--)
			{
				if (!list[num2].IsAlive)
				{
					list.RemoveAt(num2);
				}
			}
			if (list.Count == 0)
			{
				hCWaASCYNuWZMROEjzezVSHhhZlo.RemoveAt(num);
			}
		}
		byHJestfhHuIaNigCRuuqUwElbYb = ReInput.unscaledTime + (double)AIWHWYzjCPZQlnmiPWimHPYgKtkb;
	}

	private void DEzcHFcbSWZDZblmkIttFOcgsTUVb()
	{
		if (fJtiDeZVXbtxrrEwwazOHKGkAICS != 0f && !(ReInput.unscaledTime < byHJestfhHuIaNigCRuuqUwElbYb))
		{
			pPSZwhpunQKBHDGuIBbpfkUKypJP();
		}
	}
}
