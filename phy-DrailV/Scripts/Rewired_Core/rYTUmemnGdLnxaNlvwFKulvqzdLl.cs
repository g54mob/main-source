using System;
using Rewired.Internal;
using Rewired.Internal.Glyphs;
using Rewired.Utils.Classes.Data;

internal sealed class rYTUmemnGdLnxaNlvwFKulvqzdLl : IDisposable, IPrefetch
{
	private Action mSbbhWBMaxxWyVZSmvaTtOONOAah;

	private Id kqvbpTxWGdGtrNRdxLepeZkwTJDn;

	private bool ZEucKeKlveETZGcCGvBfVqUuxSvEB;

	public rYTUmemnGdLnxaNlvwFKulvqzdLl(Action P_0)
	{
		mSbbhWBMaxxWyVZSmvaTtOONOAah = P_0;
		kqvbpTxWGdGtrNRdxLepeZkwTJDn = 0u;
		GlyphManager.Add(this, ref kqvbpTxWGdGtrNRdxLepeZkwTJDn);
	}

	void IPrefetch.Prefetch()
	{
		mSbbhWBMaxxWyVZSmvaTtOONOAah();
	}

	private void IqfGwssNeOuHmhjiKHsCvtuZOnrU(bool P_0)
	{
		if (!ZEucKeKlveETZGcCGvBfVqUuxSvEB)
		{
			if (P_0)
			{
				GlyphManager.Remove(ref kqvbpTxWGdGtrNRdxLepeZkwTJDn);
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
