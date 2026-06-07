using System;
using Rewired.Internal.Localization;
using Rewired.Utils.Classes.Data;

internal sealed class dXkbKlACvOfIDvWcTAscoLeMLyzQA : IDisposable, gPdbPvViIcfmuVJElIIVfiLqZVrDA
{
	private Action mSbbhWBMaxxWyVZSmvaTtOONOAah;

	private Id kqvbpTxWGdGtrNRdxLepeZkwTJDn;

	private bool ZEucKeKlveETZGcCGvBfVqUuxSvEB;

	public dXkbKlACvOfIDvWcTAscoLeMLyzQA(Action P_0)
	{
		mSbbhWBMaxxWyVZSmvaTtOONOAah = P_0;
		kqvbpTxWGdGtrNRdxLepeZkwTJDn = 0u;
		LocalizationManager.Add(this, ref kqvbpTxWGdGtrNRdxLepeZkwTJDn);
	}

	void gPdbPvViIcfmuVJElIIVfiLqZVrDA.Localize()
	{
		mSbbhWBMaxxWyVZSmvaTtOONOAah();
	}

	private void IqfGwssNeOuHmhjiKHsCvtuZOnrU(bool P_0)
	{
		if (!ZEucKeKlveETZGcCGvBfVqUuxSvEB)
		{
			if (P_0)
			{
				LocalizationManager.Remove(ref kqvbpTxWGdGtrNRdxLepeZkwTJDn);
			}
			ZEucKeKlveETZGcCGvBfVqUuxSvEB = true;
		}
	}

	public void Dispose()
	{
		IqfGwssNeOuHmhjiKHsCvtuZOnrU(true);
		GC.SuppressFinalize(this);
	}
}
