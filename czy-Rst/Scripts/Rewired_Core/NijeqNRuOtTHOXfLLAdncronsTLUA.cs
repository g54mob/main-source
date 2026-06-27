using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal sealed class NijeqNRuOtTHOXfLLAdncronsTLUA<_0001> where _0001 : class
{
	private const float zWkbWoyzlBeOozzOPaLzrNNpIPejA = 60f;

	private readonly IndexedDictionary<Bytes20, List<WeakReference>> HNRhHhBTnkiHuWRpaziGudOsdGRC;

	private float VYywZNYDPdOnXqnfvgNncSgjayui;

	private double FlptgXgLrvETeGChXbWNNFaJZBFT;

	private Func<_0001, _0001, bool> dyASiqfRCwZuBKMwuGCiDyjHSawC;

	public float yDDxwxeCfFZmucHzQeJTHezthmJMA
	{
		get
		{
			return VYywZNYDPdOnXqnfvgNncSgjayui;
		}
		set
		{
			if (num < 0f)
			{
				num = 0f;
			}
			VYywZNYDPdOnXqnfvgNncSgjayui = num;
		}
	}

	public NijeqNRuOtTHOXfLLAdncronsTLUA(Func<_0001, _0001, bool> P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException();
		}
		dyASiqfRCwZuBKMwuGCiDyjHSawC = P_0;
		VYywZNYDPdOnXqnfvgNncSgjayui = 60f;
		HNRhHhBTnkiHuWRpaziGudOsdGRC = new IndexedDictionary<Bytes20, List<WeakReference>>();
		HNRhHhBTnkiHuWRpaziGudOsdGRC.KeyComparer = EqualityComparerNoAlloc<Bytes20>.Default;
	}

	public _0001 wxUbEGFQBfjePUsdQYoNnyHInQFpA(Bytes20 P_0, _0001 P_1)
	{
		if (SYZFKzfaOuaZyGqwgDHDIzPBmdSrA(P_0, P_1, out var result))
		{
			return result;
		}
		tsZmAlwqEXvBYjcnUbtXfqwZjrMo(P_0, P_1);
		return P_1;
	}

	public bool SYZFKzfaOuaZyGqwgDHDIzPBmdSrA(Bytes20 P_0, _0001 P_1, out _0001 P_2)
	{
		if (P_1 == null)
		{
			P_2 = null;
			return false;
		}
		rkyoeomgWUizbqUjriRYbpOtrccm();
		if (!HNRhHhBTnkiHuWRpaziGudOsdGRC.TryGetValue(P_0, out var value))
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
			else if (dyASiqfRCwZuBKMwuGCiDyjHSawC(P_1, val))
			{
				P_2 = val;
				return true;
			}
		}
		P_2 = null;
		return false;
	}

	public void tsZmAlwqEXvBYjcnUbtXfqwZjrMo(Bytes20 P_0, _0001 P_1)
	{
		if (P_1 != null)
		{
			rkyoeomgWUizbqUjriRYbpOtrccm();
			if (!HNRhHhBTnkiHuWRpaziGudOsdGRC.TryGetValue(P_0, out var value))
			{
				value = new List<WeakReference>();
				HNRhHhBTnkiHuWRpaziGudOsdGRC.Add(P_0, value);
			}
			value.Add(new WeakReference(P_1, trackResurrection: false));
		}
	}

	public void ZaVMgCgyzSfkfCapDivGGCiHFRfQ()
	{
		for (int num = HNRhHhBTnkiHuWRpaziGudOsdGRC.Count - 1; num >= 0; num--)
		{
			List<WeakReference> list = HNRhHhBTnkiHuWRpaziGudOsdGRC[num];
			for (int num2 = list.Count - 1; num2 >= 0; num2--)
			{
				if (!list[num2].IsAlive)
				{
					list.RemoveAt(num2);
				}
			}
			if (list.Count == 0)
			{
				HNRhHhBTnkiHuWRpaziGudOsdGRC.RemoveAt(num);
			}
		}
		FlptgXgLrvETeGChXbWNNFaJZBFT = ReInput.unscaledTime + (double)yDDxwxeCfFZmucHzQeJTHezthmJMA;
	}

	private void rkyoeomgWUizbqUjriRYbpOtrccm()
	{
		if (VYywZNYDPdOnXqnfvgNncSgjayui != 0f && !(ReInput.unscaledTime < FlptgXgLrvETeGChXbWNNFaJZBFT))
		{
			ZaVMgCgyzSfkfCapDivGGCiHFRfQ();
		}
	}
}
