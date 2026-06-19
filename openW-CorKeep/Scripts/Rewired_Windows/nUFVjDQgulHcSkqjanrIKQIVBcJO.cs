using System;
using System.Runtime.CompilerServices;
using System.Threading;

internal abstract class nUFVjDQgulHcSkqjanrIKQIVBcJO : IDisposable
{
	[CompilerGenerated]
	private EventHandler<EventArgs> m_bFqqmrYTDvxHLedIKCHYIBmVaPs;

	[CompilerGenerated]
	private EventHandler<EventArgs> m_eCUubSwPAYgMdjALGDUalZLWsBfrA;

	[CompilerGenerated]
	private bool GEXPdVNIikEYvSIQAhZqsFJvGZBJ;

	public bool zhWqZqEDzgNoliaQNteLqxnqKrEf
	{
		[CompilerGenerated]
		get
		{
			return GEXPdVNIikEYvSIQAhZqsFJvGZBJ;
		}
		[CompilerGenerated]
		private set
		{
			GEXPdVNIikEYvSIQAhZqsFJvGZBJ = gEXPdVNIikEYvSIQAhZqsFJvGZBJ;
		}
	}

	public event EventHandler<EventArgs> bFqqmrYTDvxHLedIKCHYIBmVaPs
	{
		[CompilerGenerated]
		add
		{
			EventHandler<EventArgs> eventHandler = this.m_bFqqmrYTDvxHLedIKCHYIBmVaPs;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, b);
				eventHandler = Interlocked.CompareExchange(ref this.m_bFqqmrYTDvxHLedIKCHYIBmVaPs, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<EventArgs> eventHandler = this.m_bFqqmrYTDvxHLedIKCHYIBmVaPs;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value3);
				eventHandler = Interlocked.CompareExchange(ref this.m_bFqqmrYTDvxHLedIKCHYIBmVaPs, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<EventArgs> eCUubSwPAYgMdjALGDUalZLWsBfrA
	{
		[CompilerGenerated]
		add
		{
			EventHandler<EventArgs> eventHandler = this.m_eCUubSwPAYgMdjALGDUalZLWsBfrA;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, b);
				eventHandler = Interlocked.CompareExchange(ref this.m_eCUubSwPAYgMdjALGDUalZLWsBfrA, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<EventArgs> eventHandler = this.m_eCUubSwPAYgMdjALGDUalZLWsBfrA;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value3);
				eventHandler = Interlocked.CompareExchange(ref this.m_eCUubSwPAYgMdjALGDUalZLWsBfrA, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	protected virtual void jKqOLpUARtyNLuayHgXjMPFtCnfFA()
	{
		try
		{
			SbHBFUbqQpQHkmEYbjkrwHvWBzmzA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	public void Dispose()
	{
		SbHBFUbqQpQHkmEYbjkrwHvWBzmzA(true);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	private void SbHBFUbqQpQHkmEYbjkrwHvWBzmzA(bool P_0)
	{
		if (!zhWqZqEDzgNoliaQNteLqxnqKrEf)
		{
			this.bFqqmrYTDvxHLedIKCHYIBmVaPs?.Invoke(this, EventArgs.Empty);
			TRbvbGGsiwEepyVCfxXqzIyHBCvI(P_0);
			GC.SuppressFinalize(this);
			zhWqZqEDzgNoliaQNteLqxnqKrEf = true;
			this.eCUubSwPAYgMdjALGDUalZLWsBfrA?.Invoke(this, EventArgs.Empty);
		}
	}

	protected abstract void TRbvbGGsiwEepyVCfxXqzIyHBCvI(bool P_0);
}
