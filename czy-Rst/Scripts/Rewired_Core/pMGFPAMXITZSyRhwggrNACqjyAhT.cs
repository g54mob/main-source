using System;
using Rewired.Internal;
using Rewired.Internal.Glyphs;
using Rewired.Utils.Classes.Data;

internal sealed class pMGFPAMXITZSyRhwggrNACqjyAhT : IPrefetch, IDisposable
{
	private Action KFtPYVfCORCdSaeFCWunorduIRvEb;

	private Id ovAgqtBcYdqHQwiNVxOqpyYkMwoqA;

	private bool RQCafbFrbUgoWOONjwWznLnMrRzoA;

	public pMGFPAMXITZSyRhwggrNACqjyAhT(Action P_0)
	{
		KFtPYVfCORCdSaeFCWunorduIRvEb = P_0;
		ovAgqtBcYdqHQwiNVxOqpyYkMwoqA = 0u;
		GlyphManager.Add(this, ref ovAgqtBcYdqHQwiNVxOqpyYkMwoqA);
	}

	void IPrefetch.Prefetch()
	{
		KFtPYVfCORCdSaeFCWunorduIRvEb();
	}

	private void CcQTwrLZUlwcFaEOvEyIOgMaivlN(bool P_0)
	{
		if (!RQCafbFrbUgoWOONjwWznLnMrRzoA)
		{
			if (P_0)
			{
				GlyphManager.Remove(ref ovAgqtBcYdqHQwiNVxOqpyYkMwoqA);
			}
			RQCafbFrbUgoWOONjwWznLnMrRzoA = true;
		}
	}

	public void Dispose()
	{
		CcQTwrLZUlwcFaEOvEyIOgMaivlN(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}
}
