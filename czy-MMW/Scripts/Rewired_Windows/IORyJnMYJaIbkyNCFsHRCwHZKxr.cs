using System;
using System.Runtime.CompilerServices;

internal abstract class IORyJnMYJaIbkyNCFsHRCwHZKxr : IDisposable
{
	[CompilerGenerated]
	private EventHandler<EventArgs> UUSVMkEebdJToNHDyBREEDrgNCxib;

	[CompilerGenerated]
	private EventHandler<EventArgs> HvRyOOZEkkBsUiOhwKXdtStCZtVjA;

	[CompilerGenerated]
	private bool tOEkNLqQOAeDQYhwsyvxbTrzutzH;

	public bool WQVFughTTCvpCqmftyWUdRBeoroE
	{
		[CompilerGenerated]
		get
		{
			return tOEkNLqQOAeDQYhwsyvxbTrzutzH;
		}
		[CompilerGenerated]
		private set
		{
			tOEkNLqQOAeDQYhwsyvxbTrzutzH = flag;
		}
	}

	protected virtual void WctvszfjpPtlekMErOGeFmjpjXJW()
	{
		try
		{
			xrOQuKReqRmpXWlaNjhaKTTGfVIu(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	public void Dispose()
	{
		xrOQuKReqRmpXWlaNjhaKTTGfVIu(true);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	private void xrOQuKReqRmpXWlaNjhaKTTGfVIu(bool P_0)
	{
		if (!WQVFughTTCvpCqmftyWUdRBeoroE)
		{
			UUSVMkEebdJToNHDyBREEDrgNCxib?.Invoke(this, EventArgs.Empty);
			cGoULYxKvMujCmsEPylpyGZLbLJD(P_0);
			GC.SuppressFinalize(this);
			WQVFughTTCvpCqmftyWUdRBeoroE = true;
			HvRyOOZEkkBsUiOhwKXdtStCZtVjA?.Invoke(this, EventArgs.Empty);
		}
	}

	protected abstract void cGoULYxKvMujCmsEPylpyGZLbLJD(bool P_0);
}
