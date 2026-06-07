using System;
using Rewired.Internal;
using Rewired.Internal.Glyphs;
using Rewired.Utils.Classes.Data;

internal sealed class orzPQTDZxByPDnmaNCwVbdJOcdWe : IPrefetch, IDisposable
{
	private Action BEEAUWwMPFvTpAQVxDrvMDiRAbGR;

	private Id fnpgNujHdhjBpAFFipPsVMJTSBFk;

	private bool MndzTmodmIQjnkRPAvmnykgzflAK;

	public orzPQTDZxByPDnmaNCwVbdJOcdWe(Action P_0)
	{
		BEEAUWwMPFvTpAQVxDrvMDiRAbGR = P_0;
		fnpgNujHdhjBpAFFipPsVMJTSBFk = 0u;
		GlyphManager.Add(this, ref fnpgNujHdhjBpAFFipPsVMJTSBFk);
	}

	void IPrefetch.Prefetch()
	{
		BEEAUWwMPFvTpAQVxDrvMDiRAbGR();
	}

	private void NddRHmKvBnHKyOPSIEHWpyPPFRQS(bool P_0)
	{
		if (!MndzTmodmIQjnkRPAvmnykgzflAK)
		{
			if (P_0)
			{
				GlyphManager.Remove(ref fnpgNujHdhjBpAFFipPsVMJTSBFk);
			}
			MndzTmodmIQjnkRPAvmnykgzflAK = true;
		}
	}

	public void Dispose()
	{
		NddRHmKvBnHKyOPSIEHWpyPPFRQS(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}
}
