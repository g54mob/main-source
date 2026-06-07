using System;
using System.Runtime.CompilerServices;
using System.Threading;

internal abstract class BoWDhsOlRuuSewMsxfGDRjABgwGbA : IDisposable
{
	[CompilerGenerated]
	private EventHandler<EventArgs> m_DGYaUJareCUTxPPyJjfAhJFGaqATB;

	[CompilerGenerated]
	private EventHandler<EventArgs> m_OSFLbjyXfRabDUECFBpnGOBQjHkZ;

	[CompilerGenerated]
	private bool aJCMbgPRHrsqBQLTVfIlBhFhnEYDA;

	public bool PhVlQZEjQrXjFiADScOSilfqQCReb
	{
		[CompilerGenerated]
		get
		{
			return aJCMbgPRHrsqBQLTVfIlBhFhnEYDA;
		}
		[CompilerGenerated]
		private set
		{
			aJCMbgPRHrsqBQLTVfIlBhFhnEYDA = flag;
		}
	}

	public event EventHandler<EventArgs> DGYaUJareCUTxPPyJjfAhJFGaqATB
	{
		[CompilerGenerated]
		add
		{
			EventHandler<EventArgs> eventHandler = this.m_DGYaUJareCUTxPPyJjfAhJFGaqATB;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, b);
				eventHandler = Interlocked.CompareExchange(ref this.m_DGYaUJareCUTxPPyJjfAhJFGaqATB, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<EventArgs> eventHandler = this.m_DGYaUJareCUTxPPyJjfAhJFGaqATB;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value3);
				eventHandler = Interlocked.CompareExchange(ref this.m_DGYaUJareCUTxPPyJjfAhJFGaqATB, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<EventArgs> OSFLbjyXfRabDUECFBpnGOBQjHkZ
	{
		[CompilerGenerated]
		add
		{
			EventHandler<EventArgs> eventHandler = this.m_OSFLbjyXfRabDUECFBpnGOBQjHkZ;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, b);
				eventHandler = Interlocked.CompareExchange(ref this.m_OSFLbjyXfRabDUECFBpnGOBQjHkZ, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<EventArgs> eventHandler = this.m_OSFLbjyXfRabDUECFBpnGOBQjHkZ;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value3);
				eventHandler = Interlocked.CompareExchange(ref this.m_OSFLbjyXfRabDUECFBpnGOBQjHkZ, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	protected virtual void TKtjRQUoyelLfsvTEcewRLHlveof()
	{
		try
		{
			wUCvOhgJfupOWCVTsZUyGobOnrnf(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	public void Dispose()
	{
		wUCvOhgJfupOWCVTsZUyGobOnrnf(true);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	private void wUCvOhgJfupOWCVTsZUyGobOnrnf(bool P_0)
	{
		if (!PhVlQZEjQrXjFiADScOSilfqQCReb)
		{
			this.DGYaUJareCUTxPPyJjfAhJFGaqATB?.Invoke(this, EventArgs.Empty);
			rRsMTzOJJvcyZcAJeGMleLmNeBkx(P_0);
			GC.SuppressFinalize(this);
			PhVlQZEjQrXjFiADScOSilfqQCReb = true;
			this.OSFLbjyXfRabDUECFBpnGOBQjHkZ?.Invoke(this, EventArgs.Empty);
		}
	}

	protected abstract void rRsMTzOJJvcyZcAJeGMleLmNeBkx(bool P_0);
}
