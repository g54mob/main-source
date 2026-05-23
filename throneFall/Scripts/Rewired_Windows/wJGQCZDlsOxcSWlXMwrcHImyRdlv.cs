using System;
using System.Collections.Generic;

internal struct wJGQCZDlsOxcSWlXMwrcHImyRdlv<_0001> : IDisposable
{
	private ZZkawQYJbYZGktLvVHEqgPGIIzWi CBQyAtJPSwRxuADjEevuKKghjYwgA;

	private _0001 HNilYvLePtsVBsBDBDvJfQldchGP;

	private IEnumerator<global::QJJWIHPqZByVprGOZAVkQbbhzVSD<_0001>> XFkhVQCqYQjwteYPyeaNgdsjyBFR;

	private bool cuEMYuvLlLaqsVQbvbDPQpuOAeqX;

	public ZZkawQYJbYZGktLvVHEqgPGIIzWi ZNIhTQNatiOeATRDXGiILIcsCuGDA => CBQyAtJPSwRxuADjEevuKKghjYwgA;

	public _0001 YbhQprqGceCGaiWPVbmsKjcsjWdn => HNilYvLePtsVBsBDBDvJfQldchGP;

	public wJGQCZDlsOxcSWlXMwrcHImyRdlv(IEnumerable<global::QJJWIHPqZByVprGOZAVkQbbhzVSD<_0001>> P_0)
	{
		CBQyAtJPSwRxuADjEevuKKghjYwgA = ZZkawQYJbYZGktLvVHEqgPGIIzWi.Idle;
		HNilYvLePtsVBsBDBDvJfQldchGP = default(_0001);
		XFkhVQCqYQjwteYPyeaNgdsjyBFR = P_0.GetEnumerator();
		cuEMYuvLlLaqsVQbvbDPQpuOAeqX = false;
	}

	public bool DwLnskTBFqwJgIjvMcsIYEFQbuqi()
	{
		if (!XFkhVQCqYQjwteYPyeaNgdsjyBFR.MoveNext())
		{
			return true;
		}
		global::QJJWIHPqZByVprGOZAVkQbbhzVSD<_0001> current = XFkhVQCqYQjwteYPyeaNgdsjyBFR.Current;
		CBQyAtJPSwRxuADjEevuKKghjYwgA = current.wNnyMHAhVpobXLggEjDEhCxGVpkxA;
		HNilYvLePtsVBsBDBDvJfQldchGP = current.LpZUkDtCBQZsgJIqpTYKQofUJYoU;
		return false;
	}

	public void Dispose()
	{
		lFcITDgXreygbGxxpzPLDokRfTAp(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	private void lFcITDgXreygbGxxpzPLDokRfTAp(bool P_0)
	{
		if (!cuEMYuvLlLaqsVQbvbDPQpuOAeqX)
		{
			cuEMYuvLlLaqsVQbvbDPQpuOAeqX = true;
		}
	}
}
