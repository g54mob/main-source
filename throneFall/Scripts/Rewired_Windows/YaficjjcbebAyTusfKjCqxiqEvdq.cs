using System;
using System.Runtime.CompilerServices;
using System.Threading;

internal abstract class YaficjjcbebAyTusfKjCqxiqEvdq : IDisposable
{
	[CompilerGenerated]
	private EventHandler<EventArgs> m_WPjHFQScEIZpfccaNdMForfTabfM;

	[CompilerGenerated]
	private EventHandler<EventArgs> m_PIkhIoNoNPAkTilKZJOcCbjpeGDZA;

	[CompilerGenerated]
	private bool zVpeTvuYftwfRvsNVjWuKJjILLdj;

	public bool MTmAHQhbmrGzFFLXQFvHpGNDPBoQA
	{
		[CompilerGenerated]
		get
		{
			return zVpeTvuYftwfRvsNVjWuKJjILLdj;
		}
		[CompilerGenerated]
		private set
		{
			zVpeTvuYftwfRvsNVjWuKJjILLdj = flag;
		}
	}

	public event EventHandler<EventArgs> WPjHFQScEIZpfccaNdMForfTabfM
	{
		[CompilerGenerated]
		add
		{
			EventHandler<EventArgs> eventHandler = this.m_WPjHFQScEIZpfccaNdMForfTabfM;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, b);
				eventHandler = Interlocked.CompareExchange(ref this.m_WPjHFQScEIZpfccaNdMForfTabfM, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<EventArgs> eventHandler = this.m_WPjHFQScEIZpfccaNdMForfTabfM;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value3);
				eventHandler = Interlocked.CompareExchange(ref this.m_WPjHFQScEIZpfccaNdMForfTabfM, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<EventArgs> PIkhIoNoNPAkTilKZJOcCbjpeGDZA
	{
		[CompilerGenerated]
		add
		{
			EventHandler<EventArgs> eventHandler = this.m_PIkhIoNoNPAkTilKZJOcCbjpeGDZA;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, b);
				eventHandler = Interlocked.CompareExchange(ref this.m_PIkhIoNoNPAkTilKZJOcCbjpeGDZA, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<EventArgs> eventHandler = this.m_PIkhIoNoNPAkTilKZJOcCbjpeGDZA;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value3);
				eventHandler = Interlocked.CompareExchange(ref this.m_PIkhIoNoNPAkTilKZJOcCbjpeGDZA, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	protected virtual void UaUlmNbNMkupzZhxKYBtkkhSOgNX()
	{
		try
		{
			pMldcoDDJqwlQBpXiBurqfDtImOYA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	public void Dispose()
	{
		pMldcoDDJqwlQBpXiBurqfDtImOYA(true);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	private void pMldcoDDJqwlQBpXiBurqfDtImOYA(bool P_0)
	{
		if (!MTmAHQhbmrGzFFLXQFvHpGNDPBoQA)
		{
			this.WPjHFQScEIZpfccaNdMForfTabfM?.Invoke(this, EventArgs.Empty);
			cdXbCaxqjftgPXkDqIlkFXYmQEXy(P_0);
			GC.SuppressFinalize(this);
			MTmAHQhbmrGzFFLXQFvHpGNDPBoQA = true;
			this.PIkhIoNoNPAkTilKZJOcCbjpeGDZA?.Invoke(this, EventArgs.Empty);
		}
	}

	protected abstract void cdXbCaxqjftgPXkDqIlkFXYmQEXy(bool P_0);
}
