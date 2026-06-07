using System;
using System.Runtime.CompilerServices;
using System.Threading;

internal abstract class MrEUOKZGxwGprvYYmmmawcJDWRFN : IDisposable
{
	[CompilerGenerated]
	private EventHandler<EventArgs> m_CLlgkksZHbHIQEXqvVYwYJyzPvRk;

	[CompilerGenerated]
	private EventHandler<EventArgs> m_biNPmkJoHWGOmIqJbUEksHwpfFzlA;

	[CompilerGenerated]
	private bool coEAWFZNzVKVimrBAFkdRAbtYfbm;

	public bool XmVNjbgSBayLTtXtkJQoKqCpxhnB
	{
		[CompilerGenerated]
		get
		{
			return coEAWFZNzVKVimrBAFkdRAbtYfbm;
		}
		[CompilerGenerated]
		private set
		{
			coEAWFZNzVKVimrBAFkdRAbtYfbm = flag;
		}
	}

	public event EventHandler<EventArgs> CLlgkksZHbHIQEXqvVYwYJyzPvRk
	{
		[CompilerGenerated]
		add
		{
			EventHandler<EventArgs> eventHandler = this.m_CLlgkksZHbHIQEXqvVYwYJyzPvRk;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, b);
				eventHandler = Interlocked.CompareExchange(ref this.m_CLlgkksZHbHIQEXqvVYwYJyzPvRk, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<EventArgs> eventHandler = this.m_CLlgkksZHbHIQEXqvVYwYJyzPvRk;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value3);
				eventHandler = Interlocked.CompareExchange(ref this.m_CLlgkksZHbHIQEXqvVYwYJyzPvRk, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<EventArgs> biNPmkJoHWGOmIqJbUEksHwpfFzlA
	{
		[CompilerGenerated]
		add
		{
			EventHandler<EventArgs> eventHandler = this.m_biNPmkJoHWGOmIqJbUEksHwpfFzlA;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, b);
				eventHandler = Interlocked.CompareExchange(ref this.m_biNPmkJoHWGOmIqJbUEksHwpfFzlA, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<EventArgs> eventHandler = this.m_biNPmkJoHWGOmIqJbUEksHwpfFzlA;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value3);
				eventHandler = Interlocked.CompareExchange(ref this.m_biNPmkJoHWGOmIqJbUEksHwpfFzlA, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	protected virtual void jRFgxQCVBGrNmzQBGWfdjtLVACefA()
	{
		try
		{
			rTWwlMqfTdbIqodeWMaCYCQbmxFM(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	public void Dispose()
	{
		rTWwlMqfTdbIqodeWMaCYCQbmxFM(true);
	}

	private void rTWwlMqfTdbIqodeWMaCYCQbmxFM(bool P_0)
	{
		if (!XmVNjbgSBayLTtXtkJQoKqCpxhnB)
		{
			this.CLlgkksZHbHIQEXqvVYwYJyzPvRk?.Invoke(this, EventArgs.Empty);
			hIlanWXkrCYfgvCyascUuCUOCBcL(P_0);
			GC.SuppressFinalize(this);
			XmVNjbgSBayLTtXtkJQoKqCpxhnB = true;
			this.biNPmkJoHWGOmIqJbUEksHwpfFzlA?.Invoke(this, EventArgs.Empty);
		}
	}

	protected abstract void hIlanWXkrCYfgvCyascUuCUOCBcL(bool P_0);
}
