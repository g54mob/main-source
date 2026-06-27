using System;
using Rewired;
using Rewired.Utils.Classes.Data;

internal sealed class DKUUkxPGBuBtODzxLffUargekjJN<_0001> where _0001 : class
{
	private readonly IndexedDictionary<uint, WeakReference> XelbCvcaPoBgWWjlLQWwnuBNjiMqA;

	private Id KVNDxDvtZhquTpEQEbDFEvkyaiSD;

	private double VDtgjUdTbtKnZzUctMdBHZUBiMUVB;

	private float KmCoOWCFEpuhALxEIWzZpWmpBnNV;

	public DKUUkxPGBuBtODzxLffUargekjJN()
	{
		XelbCvcaPoBgWWjlLQWwnuBNjiMqA = new IndexedDictionary<uint, WeakReference>();
		KVNDxDvtZhquTpEQEbDFEvkyaiSD = 1u;
	}

	public DKUUkxPGBuBtODzxLffUargekjJN(float P_0)
		: this()
	{
		KmCoOWCFEpuhALxEIWzZpWmpBnNV = P_0;
	}

	public bool PoaSiUEJlPrwVoTMEFDtFPmKGYhb(uint P_0, out _0001 P_1)
	{
		if (!XelbCvcaPoBgWWjlLQWwnuBNjiMqA.TryGetValue(P_0, out var value))
		{
			P_1 = null;
			return false;
		}
		if (!(value.Target is _0001 val))
		{
			XelbCvcaPoBgWWjlLQWwnuBNjiMqA.Remove(P_0);
			P_1 = null;
			return false;
		}
		P_1 = val;
		return true;
	}

	public uint otMvaeITjObGwaebZFuDBIMyrbKIA(_0001 P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException();
		}
		MBeMIqIGrTbzdLcpzyUkkBLJhcfR();
		XelbCvcaPoBgWWjlLQWwnuBNjiMqA.SetValue(KVNDxDvtZhquTpEQEbDFEvkyaiSD.id, new WeakReference(P_0, trackResurrection: false));
		KVNDxDvtZhquTpEQEbDFEvkyaiSD.Increment();
		return KVNDxDvtZhquTpEQEbDFEvkyaiSD.id;
	}

	public bool jtIXMnMsdulgRWTRTGaHgHIXGSW(uint P_0)
	{
		MBeMIqIGrTbzdLcpzyUkkBLJhcfR();
		return XelbCvcaPoBgWWjlLQWwnuBNjiMqA.Remove(P_0);
	}

	public void LGsdbubURKsvZrBcnoMUgYqozOqvA()
	{
		for (int num = XelbCvcaPoBgWWjlLQWwnuBNjiMqA.Count - 1; num >= 0; num--)
		{
			if (!XelbCvcaPoBgWWjlLQWwnuBNjiMqA[num].IsAlive)
			{
				XelbCvcaPoBgWWjlLQWwnuBNjiMqA.RemoveAt(num);
			}
		}
		VDtgjUdTbtKnZzUctMdBHZUBiMUVB = ReInput.unscaledTime + (double)KmCoOWCFEpuhALxEIWzZpWmpBnNV;
	}

	public void rEvRuOqxuQPMRinSqAcXkjIDcEeH(Action<_0001> P_0)
	{
		for (int num = XelbCvcaPoBgWWjlLQWwnuBNjiMqA.Count - 1; num >= 0; num--)
		{
			if (!(XelbCvcaPoBgWWjlLQWwnuBNjiMqA[num].Target is _0001 obj))
			{
				XelbCvcaPoBgWWjlLQWwnuBNjiMqA.RemoveAt(num);
			}
			else
			{
				P_0(obj);
			}
		}
		VDtgjUdTbtKnZzUctMdBHZUBiMUVB = ReInput.unscaledTime + (double)KmCoOWCFEpuhALxEIWzZpWmpBnNV;
	}

	private void MBeMIqIGrTbzdLcpzyUkkBLJhcfR()
	{
		if (!(KmCoOWCFEpuhALxEIWzZpWmpBnNV <= 0f) && ReInput.unscaledTime > VDtgjUdTbtKnZzUctMdBHZUBiMUVB)
		{
			LGsdbubURKsvZrBcnoMUgYqozOqvA();
		}
	}
}
