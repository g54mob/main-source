using System;
using Rewired;
using Rewired.Utils.Classes.Data;

internal sealed class KzfQCuMWKcBHvhIjiQIELWzVhLyv<_0001> where _0001 : class
{
	private readonly IndexedDictionary<uint, WeakReference> CECmevSXyMWxLdugnquDEOcCalf;

	private Id NHifDEGekboOaIJCzPGZGjecNMrKc;

	private double CZCxPZWswvHgswmyGUrBmNHJgDzg;

	private float ByxKVBVCDfkPvdLQtvUBUrvIcLyo;

	public KzfQCuMWKcBHvhIjiQIELWzVhLyv()
	{
		CECmevSXyMWxLdugnquDEOcCalf = new IndexedDictionary<uint, WeakReference>();
		NHifDEGekboOaIJCzPGZGjecNMrKc = 1u;
	}

	public KzfQCuMWKcBHvhIjiQIELWzVhLyv(float P_0)
		: this()
	{
		ByxKVBVCDfkPvdLQtvUBUrvIcLyo = P_0;
	}

	public bool GoNxOpDMYzQDZIhLfFoLkqUNJgjNA(uint P_0, out _0001 P_1)
	{
		if (!CECmevSXyMWxLdugnquDEOcCalf.TryGetValue(P_0, out var value))
		{
			P_1 = null;
			return false;
		}
		if (!(value.Target is _0001 val))
		{
			CECmevSXyMWxLdugnquDEOcCalf.Remove(P_0);
			P_1 = null;
			return false;
		}
		P_1 = val;
		return true;
	}

	public uint hIvovHVycAsETKhbyBaTjGTJZfpk(_0001 P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException();
		}
		RgLFOdHLsFmREjnbGCLoRoKyqYST();
		CECmevSXyMWxLdugnquDEOcCalf.SetValue(NHifDEGekboOaIJCzPGZGjecNMrKc.id, new WeakReference(P_0, trackResurrection: false));
		NHifDEGekboOaIJCzPGZGjecNMrKc.Increment();
		return NHifDEGekboOaIJCzPGZGjecNMrKc.id;
	}

	public bool mWWzFZepvjeRDDpPaQhsUmEzGyxyA(uint P_0)
	{
		RgLFOdHLsFmREjnbGCLoRoKyqYST();
		return CECmevSXyMWxLdugnquDEOcCalf.Remove(P_0);
	}

	public void QBBfslHhUSFaibroWpVWnhhNeeBH()
	{
		for (int num = CECmevSXyMWxLdugnquDEOcCalf.Count - 1; num >= 0; num--)
		{
			if (!CECmevSXyMWxLdugnquDEOcCalf[num].IsAlive)
			{
				CECmevSXyMWxLdugnquDEOcCalf.RemoveAt(num);
			}
		}
		CZCxPZWswvHgswmyGUrBmNHJgDzg = ReInput.unscaledTime + (double)ByxKVBVCDfkPvdLQtvUBUrvIcLyo;
	}

	public void cDSrTXhbnOhragUUBjpNUNZmnQXY(Action<_0001> P_0)
	{
		for (int num = CECmevSXyMWxLdugnquDEOcCalf.Count - 1; num >= 0; num--)
		{
			if (!(CECmevSXyMWxLdugnquDEOcCalf[num].Target is _0001 obj))
			{
				CECmevSXyMWxLdugnquDEOcCalf.RemoveAt(num);
			}
			else
			{
				P_0(obj);
			}
		}
		CZCxPZWswvHgswmyGUrBmNHJgDzg = ReInput.unscaledTime + (double)ByxKVBVCDfkPvdLQtvUBUrvIcLyo;
	}

	private void RgLFOdHLsFmREjnbGCLoRoKyqYST()
	{
		if (!(ByxKVBVCDfkPvdLQtvUBUrvIcLyo <= 0f) && ReInput.unscaledTime > CZCxPZWswvHgswmyGUrBmNHJgDzg)
		{
			QBBfslHhUSFaibroWpVWnhhNeeBH();
		}
	}
}
