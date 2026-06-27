using System;
using Rewired.Internal.Localization;
using Rewired.Utils.Classes.Data;

internal sealed class pdzTLPmqpuLIOpAzKgpvnBvFeTFbA : goyuORzVCSsvhefHsgPEBCMfboVoA, IDisposable
{
	private Action yTxLXUnqKdvHYShspMFnrtAHdReB;

	private Id BVqAurCltenmZkLehNqUbeRFWqhXA;

	private bool wpnfdmVWIkQJggTpdHbiUoDWPBfT;

	public pdzTLPmqpuLIOpAzKgpvnBvFeTFbA(Action P_0)
	{
		yTxLXUnqKdvHYShspMFnrtAHdReB = P_0;
		BVqAurCltenmZkLehNqUbeRFWqhXA = 0u;
		LocalizationManager.Add(this, ref BVqAurCltenmZkLehNqUbeRFWqhXA);
	}

	void goyuORzVCSsvhefHsgPEBCMfboVoA.Localize()
	{
		yTxLXUnqKdvHYShspMFnrtAHdReB();
	}

	private void YEbOAmWZijexCwctcTfiisYlBkXO(bool P_0)
	{
		if (!wpnfdmVWIkQJggTpdHbiUoDWPBfT)
		{
			if (P_0)
			{
				LocalizationManager.Remove(ref BVqAurCltenmZkLehNqUbeRFWqhXA);
			}
			wpnfdmVWIkQJggTpdHbiUoDWPBfT = true;
		}
	}

	public void Dispose()
	{
		YEbOAmWZijexCwctcTfiisYlBkXO(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}
}
