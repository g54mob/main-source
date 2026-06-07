using System;
using Rewired;
using Rewired.Utils.Classes.Data;

internal sealed class NQPwJDdoBKzgXcGsAuaFYHhxxYfw<_0001> where _0001 : class
{
	private readonly IndexedDictionary<uint, WeakReference> xoqXaiKKtSJeHCHXPbHqnjKvfGpp;

	private Id uPYgQTclbDtQqEfaxTfTeSGxCLuKA;

	private double ydywHeTKTUhvzpVaiCZjGoFyLVBF;

	private float gUyifNjuJloNuNLnBCpBleuYArBy;

	public NQPwJDdoBKzgXcGsAuaFYHhxxYfw()
	{
		xoqXaiKKtSJeHCHXPbHqnjKvfGpp = new IndexedDictionary<uint, WeakReference>();
		uPYgQTclbDtQqEfaxTfTeSGxCLuKA = 1u;
	}

	public NQPwJDdoBKzgXcGsAuaFYHhxxYfw(float P_0)
		: this()
	{
		gUyifNjuJloNuNLnBCpBleuYArBy = P_0;
	}

	public bool NEMNJMcirueiRvtpzMeNRlITFIYU(uint P_0, out _0001 P_1)
	{
		if (!xoqXaiKKtSJeHCHXPbHqnjKvfGpp.TryGetValue(P_0, out var value))
		{
			P_1 = null;
			return false;
		}
		if (!(value.Target is _0001 val))
		{
			xoqXaiKKtSJeHCHXPbHqnjKvfGpp.Remove(P_0);
			P_1 = null;
			return false;
		}
		P_1 = val;
		return true;
	}

	public uint fyeqCafQbFyflbNbajUvornPxfgy(_0001 P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException();
		}
		NgyBxFBfbIsSVCvbvkFXltkFOpLN();
		xoqXaiKKtSJeHCHXPbHqnjKvfGpp.SetValue(uPYgQTclbDtQqEfaxTfTeSGxCLuKA.id, new WeakReference(P_0, trackResurrection: false));
		uPYgQTclbDtQqEfaxTfTeSGxCLuKA.Increment();
		return uPYgQTclbDtQqEfaxTfTeSGxCLuKA.id;
	}

	public bool QCWdrwUdFoEQDLjAeGnqtGDjBvyCA(uint P_0)
	{
		NgyBxFBfbIsSVCvbvkFXltkFOpLN();
		return xoqXaiKKtSJeHCHXPbHqnjKvfGpp.Remove(P_0);
	}

	public void XldwkgfODhsAMdkotkEWhrHBlCPR()
	{
		for (int num = xoqXaiKKtSJeHCHXPbHqnjKvfGpp.Count - 1; num >= 0; num--)
		{
			if (!xoqXaiKKtSJeHCHXPbHqnjKvfGpp[num].IsAlive)
			{
				xoqXaiKKtSJeHCHXPbHqnjKvfGpp.RemoveAt(num);
			}
		}
		ydywHeTKTUhvzpVaiCZjGoFyLVBF = ReInput.unscaledTime + (double)gUyifNjuJloNuNLnBCpBleuYArBy;
	}

	public void CjjkaOYoURdeyiGrstLwvNNvLyrAA(Action<_0001> P_0)
	{
		for (int num = xoqXaiKKtSJeHCHXPbHqnjKvfGpp.Count - 1; num >= 0; num--)
		{
			if (!(xoqXaiKKtSJeHCHXPbHqnjKvfGpp[num].Target is _0001 obj))
			{
				xoqXaiKKtSJeHCHXPbHqnjKvfGpp.RemoveAt(num);
			}
			else
			{
				P_0(obj);
			}
		}
		ydywHeTKTUhvzpVaiCZjGoFyLVBF = ReInput.unscaledTime + (double)gUyifNjuJloNuNLnBCpBleuYArBy;
	}

	private void NgyBxFBfbIsSVCvbvkFXltkFOpLN()
	{
		if (!(gUyifNjuJloNuNLnBCpBleuYArBy <= 0f) && ReInput.unscaledTime > ydywHeTKTUhvzpVaiCZjGoFyLVBF)
		{
			XldwkgfODhsAMdkotkEWhrHBlCPR();
		}
	}
}
