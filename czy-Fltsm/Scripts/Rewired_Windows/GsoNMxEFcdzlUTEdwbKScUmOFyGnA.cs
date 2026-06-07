using System;
using System.Runtime.CompilerServices;
using System.Threading;

internal abstract class GsoNMxEFcdzlUTEdwbKScUmOFyGnA : IDisposable
{
	[CompilerGenerated]
	private EventHandler<EventArgs> m_ICaydGtBLHioLBebKAvFvSlbpoOcA;

	[CompilerGenerated]
	private EventHandler<EventArgs> m_HwdemccbCAFZjtgVAQfoDvjJcFiq;

	[CompilerGenerated]
	private bool jgekSrFmsiAXbApUKTSwJqjouQUMA;

	public bool YdxIvSQwlqjCrJRWRQCJojJnOSRm
	{
		[CompilerGenerated]
		get
		{
			return jgekSrFmsiAXbApUKTSwJqjouQUMA;
		}
		[CompilerGenerated]
		private set
		{
			jgekSrFmsiAXbApUKTSwJqjouQUMA = flag;
		}
	}

	public event EventHandler<EventArgs> ICaydGtBLHioLBebKAvFvSlbpoOcA
	{
		[CompilerGenerated]
		add
		{
			EventHandler<EventArgs> eventHandler = this.m_ICaydGtBLHioLBebKAvFvSlbpoOcA;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, b);
				eventHandler = Interlocked.CompareExchange(ref this.m_ICaydGtBLHioLBebKAvFvSlbpoOcA, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<EventArgs> eventHandler = this.m_ICaydGtBLHioLBebKAvFvSlbpoOcA;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value3);
				eventHandler = Interlocked.CompareExchange(ref this.m_ICaydGtBLHioLBebKAvFvSlbpoOcA, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<EventArgs> HwdemccbCAFZjtgVAQfoDvjJcFiq
	{
		[CompilerGenerated]
		add
		{
			EventHandler<EventArgs> eventHandler = this.m_HwdemccbCAFZjtgVAQfoDvjJcFiq;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, b);
				eventHandler = Interlocked.CompareExchange(ref this.m_HwdemccbCAFZjtgVAQfoDvjJcFiq, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<EventArgs> eventHandler = this.m_HwdemccbCAFZjtgVAQfoDvjJcFiq;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value3);
				eventHandler = Interlocked.CompareExchange(ref this.m_HwdemccbCAFZjtgVAQfoDvjJcFiq, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	protected virtual void WpLdITAvJhJOJLmmTFerGRtaSpeV()
	{
		try
		{
			tykGyFkAgrYmlzKIzFfqXHHPvjaB(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	public void Dispose()
	{
		tykGyFkAgrYmlzKIzFfqXHHPvjaB(true);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	private void tykGyFkAgrYmlzKIzFfqXHHPvjaB(bool P_0)
	{
		if (!YdxIvSQwlqjCrJRWRQCJojJnOSRm)
		{
			this.ICaydGtBLHioLBebKAvFvSlbpoOcA?.Invoke(this, EventArgs.Empty);
			iuWHogCWogsRpZuUhoGabfKMzLeS(P_0);
			GC.SuppressFinalize(this);
			YdxIvSQwlqjCrJRWRQCJojJnOSRm = true;
			this.HwdemccbCAFZjtgVAQfoDvjJcFiq?.Invoke(this, EventArgs.Empty);
		}
	}

	protected abstract void iuWHogCWogsRpZuUhoGabfKMzLeS(bool P_0);
}
