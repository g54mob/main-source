using System;
using System.Runtime.CompilerServices;
using System.Threading;

internal abstract class WNBjgzUjlnPGavciWqTGDYCLcoqE : IDisposable
{
	[CompilerGenerated]
	private EventHandler<EventArgs> m_AaJFQWbfEXoGjAisyzVTVcZiAmiZ;

	[CompilerGenerated]
	private EventHandler<EventArgs> m_BlESBemJPEGxThBCaINkRORQZXImA;

	[CompilerGenerated]
	private bool duJfJlXEbgfKDRFHgGwibNJraOuQ;

	public bool KbEMEEMmmgmaDjUNtuILxjlkGCbk
	{
		[CompilerGenerated]
		get
		{
			return duJfJlXEbgfKDRFHgGwibNJraOuQ;
		}
		[CompilerGenerated]
		private set
		{
			duJfJlXEbgfKDRFHgGwibNJraOuQ = flag;
		}
	}

	public event EventHandler<EventArgs> AaJFQWbfEXoGjAisyzVTVcZiAmiZ
	{
		[CompilerGenerated]
		add
		{
			EventHandler<EventArgs> eventHandler = this.m_AaJFQWbfEXoGjAisyzVTVcZiAmiZ;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, b);
				eventHandler = Interlocked.CompareExchange(ref this.m_AaJFQWbfEXoGjAisyzVTVcZiAmiZ, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<EventArgs> eventHandler = this.m_AaJFQWbfEXoGjAisyzVTVcZiAmiZ;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value3);
				eventHandler = Interlocked.CompareExchange(ref this.m_AaJFQWbfEXoGjAisyzVTVcZiAmiZ, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<EventArgs> BlESBemJPEGxThBCaINkRORQZXImA
	{
		[CompilerGenerated]
		add
		{
			EventHandler<EventArgs> eventHandler = this.m_BlESBemJPEGxThBCaINkRORQZXImA;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, b);
				eventHandler = Interlocked.CompareExchange(ref this.m_BlESBemJPEGxThBCaINkRORQZXImA, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<EventArgs> eventHandler = this.m_BlESBemJPEGxThBCaINkRORQZXImA;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value3);
				eventHandler = Interlocked.CompareExchange(ref this.m_BlESBemJPEGxThBCaINkRORQZXImA, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	protected virtual void IucVlBGUKdOwjnIvrmMxXTPhLtMV()
	{
		try
		{
			znDlhsoALjTaOJwBRGjpIahYnfRo(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	public void Dispose()
	{
		znDlhsoALjTaOJwBRGjpIahYnfRo(true);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	private void znDlhsoALjTaOJwBRGjpIahYnfRo(bool P_0)
	{
		if (!KbEMEEMmmgmaDjUNtuILxjlkGCbk)
		{
			this.AaJFQWbfEXoGjAisyzVTVcZiAmiZ?.Invoke(this, EventArgs.Empty);
			wpzJkyEjJgniHzbBFkHqeyqDPBSl(P_0);
			GC.SuppressFinalize(this);
			KbEMEEMmmgmaDjUNtuILxjlkGCbk = true;
			this.BlESBemJPEGxThBCaINkRORQZXImA?.Invoke(this, EventArgs.Empty);
		}
	}

	protected abstract void wpzJkyEjJgniHzbBFkHqeyqDPBSl(bool P_0);
}
