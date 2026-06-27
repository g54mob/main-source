using System;
using System.Collections.Generic;

internal struct erefJZIkoTOfSssNfhmcOuCBTiqFA<_0001> : IDisposable
{
	private JQNlELbfVFGwHHheXAmaPuklJHcc WXgIZfikKbGYomejhCqkAnCGnLjVA;

	private _0001 HMQdVvsSDkfhJBUXaKoRWQLKwqPNA;

	private IEnumerator<global::GhbVzDummGhxlPrAqTUgxaJOajDJ<_0001>> PSESCIbxUDsfvEiLDEfFDOIEpIEP;

	private bool sbgeZuIljUcjidpnCIAHWhEpYrfKA;

	public JQNlELbfVFGwHHheXAmaPuklJHcc VFcSAMuRlrvxKxdXsQxScoIFapTU => WXgIZfikKbGYomejhCqkAnCGnLjVA;

	public _0001 SRHVdVZsupNykMVytpaFpOHRXogB => HMQdVvsSDkfhJBUXaKoRWQLKwqPNA;

	public erefJZIkoTOfSssNfhmcOuCBTiqFA(IEnumerable<global::GhbVzDummGhxlPrAqTUgxaJOajDJ<_0001>> P_0)
	{
		WXgIZfikKbGYomejhCqkAnCGnLjVA = JQNlELbfVFGwHHheXAmaPuklJHcc.Idle;
		HMQdVvsSDkfhJBUXaKoRWQLKwqPNA = default(_0001);
		PSESCIbxUDsfvEiLDEfFDOIEpIEP = P_0.GetEnumerator();
		sbgeZuIljUcjidpnCIAHWhEpYrfKA = false;
	}

	public bool VYlamyuCRzddeCchlXzGFpljRmxUA()
	{
		if (!PSESCIbxUDsfvEiLDEfFDOIEpIEP.MoveNext())
		{
			return true;
		}
		global::GhbVzDummGhxlPrAqTUgxaJOajDJ<_0001> current = PSESCIbxUDsfvEiLDEfFDOIEpIEP.Current;
		WXgIZfikKbGYomejhCqkAnCGnLjVA = current.gGDIVZfXTgKoJhYetWIGxJPdMebX;
		HMQdVvsSDkfhJBUXaKoRWQLKwqPNA = current.JEjEnXWlVButwvhkAgFAInXvJLfhb;
		return false;
	}

	public void Dispose()
	{
		rvOPSXcMbxfhvDylEWMRUuSsCAJdb(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	private void rvOPSXcMbxfhvDylEWMRUuSsCAJdb(bool P_0)
	{
		if (!sbgeZuIljUcjidpnCIAHWhEpYrfKA)
		{
			sbgeZuIljUcjidpnCIAHWhEpYrfKA = true;
		}
	}
}
