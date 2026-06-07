using System;
using Rewired.Internal.Localization;
using Rewired.Utils.Classes.Data;

internal sealed class HoegishJjcCukocqVPiQYVHCmbvt : IfopinoSAuQZnpEvFIfBnubyAxLB, IDisposable
{
	private Action YIazaqkHezoArVHaefZqcEDKAHlTA;

	private Id fHrFxMsdLaTGrShjazjfXlaUUSVe;

	private bool MEqQwRIFAgeCWrKkwaoTdPrXraDk;

	public HoegishJjcCukocqVPiQYVHCmbvt(Action P_0)
	{
		YIazaqkHezoArVHaefZqcEDKAHlTA = P_0;
		fHrFxMsdLaTGrShjazjfXlaUUSVe = 0u;
		LocalizationManager.Add(this, ref fHrFxMsdLaTGrShjazjfXlaUUSVe);
	}

	void IfopinoSAuQZnpEvFIfBnubyAxLB.Localize()
	{
		YIazaqkHezoArVHaefZqcEDKAHlTA();
	}

	private void yNcbhJJdwjYWodXmnryRZzaeMrjm(bool P_0)
	{
		if (!MEqQwRIFAgeCWrKkwaoTdPrXraDk)
		{
			if (P_0)
			{
				LocalizationManager.Remove(ref fHrFxMsdLaTGrShjazjfXlaUUSVe);
			}
			MEqQwRIFAgeCWrKkwaoTdPrXraDk = true;
		}
	}

	public void Dispose()
	{
		yNcbhJJdwjYWodXmnryRZzaeMrjm(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}
}
