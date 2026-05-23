using System;
using Rewired.Internal;
using Rewired.Internal.Glyphs;
using Rewired.Utils.Classes.Data;

internal sealed class LSZgSpTkKDvpCWjrrDwcvUKyRuBp : IPrefetch, IDisposable
{
	private Action oTwlwemAQBaCqhvURpxUOcPpQrHw;

	private Id KbBPXQnjOxsDkpoUGRkZZAanYZUG;

	private bool ddDEUWwhzWVFoDYzyZeSuJpZrVTD;

	public LSZgSpTkKDvpCWjrrDwcvUKyRuBp(Action P_0)
	{
		oTwlwemAQBaCqhvURpxUOcPpQrHw = P_0;
		KbBPXQnjOxsDkpoUGRkZZAanYZUG = 0u;
		GlyphManager.Add(this, ref KbBPXQnjOxsDkpoUGRkZZAanYZUG);
	}

	void IPrefetch.Prefetch()
	{
		oTwlwemAQBaCqhvURpxUOcPpQrHw();
	}

	private void uMNPqIIcYnZVttKTqTfdvNylDJXK(bool P_0)
	{
		if (!ddDEUWwhzWVFoDYzyZeSuJpZrVTD)
		{
			if (P_0)
			{
				GlyphManager.Remove(ref KbBPXQnjOxsDkpoUGRkZZAanYZUG);
			}
			ddDEUWwhzWVFoDYzyZeSuJpZrVTD = true;
		}
	}

	public void Dispose()
	{
		uMNPqIIcYnZVttKTqTfdvNylDJXK(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}
}
