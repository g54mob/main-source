using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal sealed class CWEsnVafmhdWXWfXjHVMLtdvyjyd<_0001> where _0001 : class
{
	private const float uJFyQiPHYZtexqPybvvOLeSfkmPQ = 60f;

	private readonly IndexedDictionary<Bytes20, List<WeakReference>> MsoOvzsMugUQxDpbEAJjMUyoWYyS;

	private float EOFasPDrovrgOPfRVmMSAGxjPZViA;

	private double WWGkhTPFUvHzpPhHtNkgdlhRAuiU;

	private Func<_0001, _0001, bool> gbftYcSkgkvlvNLgQdqpanfNQbPYA;

	public float jDwaobXeEVCKdzAFeFfmiIavJHkqA
	{
		get
		{
			return EOFasPDrovrgOPfRVmMSAGxjPZViA;
		}
		set
		{
			if (num < 0f)
			{
				num = 0f;
			}
			EOFasPDrovrgOPfRVmMSAGxjPZViA = num;
		}
	}

	public CWEsnVafmhdWXWfXjHVMLtdvyjyd(Func<_0001, _0001, bool> P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException();
		}
		gbftYcSkgkvlvNLgQdqpanfNQbPYA = P_0;
		EOFasPDrovrgOPfRVmMSAGxjPZViA = 60f;
		MsoOvzsMugUQxDpbEAJjMUyoWYyS = new IndexedDictionary<Bytes20, List<WeakReference>>();
		MsoOvzsMugUQxDpbEAJjMUyoWYyS.KeyComparer = EqualityComparerNoAlloc<Bytes20>.Default;
	}

	public _0001 zIxKqErNejIXOzgHuQwaUJUUfHkH(Bytes20 P_0, _0001 P_1)
	{
		if (XFaGTtCzTwdlJVAzMnkTTCEPSjPB(P_0, P_1, out var result))
		{
			return result;
		}
		gjcCongZfDTPVoqTsiJgeVhLREbdb(P_0, P_1);
		return P_1;
	}

	public bool XFaGTtCzTwdlJVAzMnkTTCEPSjPB(Bytes20 P_0, _0001 P_1, out _0001 P_2)
	{
		if (P_1 == null)
		{
			P_2 = null;
			return false;
		}
		gOZFgwDInICGogpFHkMzfZRftERMc();
		if (!MsoOvzsMugUQxDpbEAJjMUyoWYyS.TryGetValue(P_0, out var value))
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
			else if (gbftYcSkgkvlvNLgQdqpanfNQbPYA(P_1, val))
			{
				P_2 = val;
				return true;
			}
		}
		P_2 = null;
		return false;
	}

	public void gjcCongZfDTPVoqTsiJgeVhLREbdb(Bytes20 P_0, _0001 P_1)
	{
		if (P_1 != null)
		{
			gOZFgwDInICGogpFHkMzfZRftERMc();
			if (!MsoOvzsMugUQxDpbEAJjMUyoWYyS.TryGetValue(P_0, out var value))
			{
				value = new List<WeakReference>();
				MsoOvzsMugUQxDpbEAJjMUyoWYyS.Add(P_0, value);
			}
			value.Add(new WeakReference(P_1, trackResurrection: false));
		}
	}

	public void WYqqdOPeQOTVoDFBvGCdsSnFyRQH()
	{
		for (int num = MsoOvzsMugUQxDpbEAJjMUyoWYyS.Count - 1; num >= 0; num--)
		{
			List<WeakReference> list = MsoOvzsMugUQxDpbEAJjMUyoWYyS[num];
			for (int num2 = list.Count - 1; num2 >= 0; num2--)
			{
				if (!list[num2].IsAlive)
				{
					list.RemoveAt(num2);
				}
			}
			if (list.Count == 0)
			{
				MsoOvzsMugUQxDpbEAJjMUyoWYyS.RemoveAt(num);
			}
		}
		WWGkhTPFUvHzpPhHtNkgdlhRAuiU = ReInput.unscaledTime + (double)jDwaobXeEVCKdzAFeFfmiIavJHkqA;
	}

	private void gOZFgwDInICGogpFHkMzfZRftERMc()
	{
		if (EOFasPDrovrgOPfRVmMSAGxjPZViA != 0f && !(ReInput.unscaledTime < WWGkhTPFUvHzpPhHtNkgdlhRAuiU))
		{
			WYqqdOPeQOTVoDFBvGCdsSnFyRQH();
		}
	}
}
