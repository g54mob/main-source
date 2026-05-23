using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class fviBsPibnZIXPweFTnYyOGgPmdAKA<_0001> : IDisposable where _0001 : struct
{
	private static readonly int wfHLiekriJEwnmCKZquWpMTjeAOr = Marshal.SizeOf(typeof(_0001));

	private GPQlDciUdfdOnXgKBdRMipKfgYXfA SuZdFBmgnqEtJAViwLtEoPyEJMYgb;

	private bool vILJYkcEkrHkWWpSGTswqyHOBDqS;

	public GPQlDciUdfdOnXgKBdRMipKfgYXfA tZHTTFeJUuMIafBxOHvDpPeWftgs => SuZdFBmgnqEtJAViwLtEoPyEJMYgb;

	public bool JdnBihFgtkMcnFyOZGRhZqBCBpYcA
	{
		get
		{
			if (SuZdFBmgnqEtJAViwLtEoPyEJMYgb != null)
			{
				return SuZdFBmgnqEtJAViwLtEoPyEJMYgb.MeBsLkhnFzRSjfjkdGNduTkRjLUhA != IntPtr.Zero;
			}
			return false;
		}
	}

	public unsafe _0001 DQhGuHkiLPiepdDMdWxlcsNDMVLKA
	{
		get
		{
			eAgqFzAkCbzYnHcWyEyYqlEVaPtb();
			return System.Runtime.CompilerServices.Unsafe.Read<_0001>((void*)SuZdFBmgnqEtJAViwLtEoPyEJMYgb.MeBsLkhnFzRSjfjkdGNduTkRjLUhA);
		}
		set
		{
			eAgqFzAkCbzYnHcWyEyYqlEVaPtb();
			_0001* ptr = &val;
			SuZdFBmgnqEtJAViwLtEoPyEJMYgb.rmmpVeABScqzZDfPinbSkcdCpGDV((IntPtr)ptr, wfHLiekriJEwnmCKZquWpMTjeAOr, wfHLiekriJEwnmCKZquWpMTjeAOr);
		}
	}

	public fviBsPibnZIXPweFTnYyOGgPmdAKA()
	{
		SuZdFBmgnqEtJAViwLtEoPyEJMYgb = new GPQlDciUdfdOnXgKBdRMipKfgYXfA(wfHLiekriJEwnmCKZquWpMTjeAOr);
	}

	private void esnjKCkCOhwumYsOYHtrDYgKsFbN()
	{
		if (SuZdFBmgnqEtJAViwLtEoPyEJMYgb == null)
		{
			SuZdFBmgnqEtJAViwLtEoPyEJMYgb.Dispose();
			SuZdFBmgnqEtJAViwLtEoPyEJMYgb = null;
		}
	}

	private void eAgqFzAkCbzYnHcWyEyYqlEVaPtb()
	{
		if (!JdnBihFgtkMcnFyOZGRhZqBCBpYcA)
		{
			throw new Exception("Memory not allocated.");
		}
	}

	private void SxGBMEXPwTtJtyCiSUXnCZVpNGvv(bool P_0)
	{
		if (!vILJYkcEkrHkWWpSGTswqyHOBDqS)
		{
			if (P_0)
			{
				esnjKCkCOhwumYsOYHtrDYgKsFbN();
			}
			vILJYkcEkrHkWWpSGTswqyHOBDqS = true;
		}
	}

	public void Dispose()
	{
		SxGBMEXPwTtJtyCiSUXnCZVpNGvv(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}
}
