using System;
using Rewired.Internal;
using Rewired.Internal.Glyphs;
using Rewired.Utils.Classes.Data;

internal sealed class awrViSzSdJenxOiWAZboqHxpzxSK : IPrefetch, IDisposable
{
	private Action HYMSdFAxTBNLFhhloYoCJwsoqtQD;

	private Id lshyqnRulvhYRdodzmNDKwNeFPLj;

	private bool YKrplpOPKKCsRForRiKMxeXYceEh;

	public awrViSzSdJenxOiWAZboqHxpzxSK(Action P_0)
	{
		HYMSdFAxTBNLFhhloYoCJwsoqtQD = P_0;
		lshyqnRulvhYRdodzmNDKwNeFPLj = 0u;
		GlyphManager.Add(this, ref lshyqnRulvhYRdodzmNDKwNeFPLj);
	}

	void IPrefetch.Prefetch()
	{
		HYMSdFAxTBNLFhhloYoCJwsoqtQD();
	}

	private void TglSZhmhrrrWUtVqHDKncqLwHOMr(bool P_0)
	{
		if (!YKrplpOPKKCsRForRiKMxeXYceEh)
		{
			if (P_0)
			{
				GlyphManager.Remove(ref lshyqnRulvhYRdodzmNDKwNeFPLj);
			}
			YKrplpOPKKCsRForRiKMxeXYceEh = true;
		}
	}

	public void Dispose()
	{
		TglSZhmhrrrWUtVqHDKncqLwHOMr(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}
}
