using System;
using Rewired;
using Rewired.Utils.Classes.Data;

internal sealed class nvBlnMElFudOyJAqIDsjvVIbYJjZ<_0001> where _0001 : class
{
	private readonly IndexedDictionary<uint, WeakReference> bQgjAOdTJmHGikqPWBcRFlsQWFsG;

	private Id sKSdeiDsfboDzReNVNkkxfVdQAsVA;

	private double hqwQzrSxffErnZfjwqdekeGzoveD;

	private float oaFArvZwAjlAsOQBDiwcQdIgxLlu;

	public nvBlnMElFudOyJAqIDsjvVIbYJjZ()
	{
		bQgjAOdTJmHGikqPWBcRFlsQWFsG = new IndexedDictionary<uint, WeakReference>();
		sKSdeiDsfboDzReNVNkkxfVdQAsVA = 1u;
	}

	public nvBlnMElFudOyJAqIDsjvVIbYJjZ(float P_0)
		: this()
	{
		oaFArvZwAjlAsOQBDiwcQdIgxLlu = P_0;
	}

	public bool tJzSrJHzDxfOGdCSLrOaeDrxEeukA(uint P_0, out _0001 P_1)
	{
		if (!bQgjAOdTJmHGikqPWBcRFlsQWFsG.TryGetValue(P_0, out var value))
		{
			P_1 = null;
			return false;
		}
		if (!(value.Target is _0001 val))
		{
			bQgjAOdTJmHGikqPWBcRFlsQWFsG.Remove(P_0);
			P_1 = null;
			return false;
		}
		P_1 = val;
		return true;
	}

	public uint KzNFDaXdZQnOsbknYnymfwQnPwRB(_0001 P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException();
		}
		uSdkrNJAdLWEBGBquatHHNlUTENRA();
		bQgjAOdTJmHGikqPWBcRFlsQWFsG.SetValue(sKSdeiDsfboDzReNVNkkxfVdQAsVA.id, new WeakReference(P_0, trackResurrection: false));
		sKSdeiDsfboDzReNVNkkxfVdQAsVA.Increment();
		return sKSdeiDsfboDzReNVNkkxfVdQAsVA.id;
	}

	public bool XUsTejstazeMUIrOUEBLcuzNrmoX(uint P_0)
	{
		uSdkrNJAdLWEBGBquatHHNlUTENRA();
		return bQgjAOdTJmHGikqPWBcRFlsQWFsG.Remove(P_0);
	}

	public void zmlKINPFJCScnWBdabJphDQrfoCKA()
	{
		for (int num = bQgjAOdTJmHGikqPWBcRFlsQWFsG.Count - 1; num >= 0; num--)
		{
			if (!bQgjAOdTJmHGikqPWBcRFlsQWFsG[num].IsAlive)
			{
				bQgjAOdTJmHGikqPWBcRFlsQWFsG.RemoveAt(num);
			}
		}
		hqwQzrSxffErnZfjwqdekeGzoveD = ReInput.unscaledTime + (double)oaFArvZwAjlAsOQBDiwcQdIgxLlu;
	}

	public void VQypiftOqKaitpdJhMReTskQUMET(Action<_0001> P_0)
	{
		for (int num = bQgjAOdTJmHGikqPWBcRFlsQWFsG.Count - 1; num >= 0; num--)
		{
			if (!(bQgjAOdTJmHGikqPWBcRFlsQWFsG[num].Target is _0001 obj))
			{
				bQgjAOdTJmHGikqPWBcRFlsQWFsG.RemoveAt(num);
			}
			else
			{
				P_0(obj);
			}
		}
		hqwQzrSxffErnZfjwqdekeGzoveD = ReInput.unscaledTime + (double)oaFArvZwAjlAsOQBDiwcQdIgxLlu;
	}

	private void uSdkrNJAdLWEBGBquatHHNlUTENRA()
	{
		if (!(oaFArvZwAjlAsOQBDiwcQdIgxLlu <= 0f) && ReInput.unscaledTime > hqwQzrSxffErnZfjwqdekeGzoveD)
		{
			zmlKINPFJCScnWBdabJphDQrfoCKA();
		}
	}
}
