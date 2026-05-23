using System;
using System.Runtime.CompilerServices;
using System.Threading;

internal abstract class whSGMljKVQaOqipJrvAXBUmGuWoe : IDisposable
{
	private EventHandler<EventArgs> eVxwANrjqTzeJKftsgENyXXYWKy;

	private EventHandler<EventArgs> JARaeNAodyvPfyhWecWTbCDKbYK;

	[CompilerGenerated]
	private bool OCSUYiWeFbtrpeyUFJvOpnCAFPO;

	public bool IsDisposed
	{
		[CompilerGenerated]
		get
		{
			return OCSUYiWeFbtrpeyUFJvOpnCAFPO;
		}
		[CompilerGenerated]
		private set
		{
			OCSUYiWeFbtrpeyUFJvOpnCAFPO = value;
		}
	}

	public event EventHandler<EventArgs> Disposing
	{
		add
		{
			EventHandler<EventArgs> eventHandler = eVxwANrjqTzeJKftsgENyXXYWKy;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eVxwANrjqTzeJKftsgENyXXYWKy, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler<EventArgs> eventHandler = eVxwANrjqTzeJKftsgENyXXYWKy;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eVxwANrjqTzeJKftsgENyXXYWKy, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<EventArgs> Disposed
	{
		add
		{
			EventHandler<EventArgs> eventHandler = JARaeNAodyvPfyhWecWTbCDKbYK;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref JARaeNAodyvPfyhWecWTbCDKbYK, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler<EventArgs> eventHandler = JARaeNAodyvPfyhWecWTbCDKbYK;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref JARaeNAodyvPfyhWecWTbCDKbYK, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	~whSGMljKVQaOqipJrvAXBUmGuWoe()
	{
		BfKgopBddXobxuSbXYUfiUpIfqa(false);
	}

	public void Dispose()
	{
		BfKgopBddXobxuSbXYUfiUpIfqa(true);
	}

	private void BfKgopBddXobxuSbXYUfiUpIfqa(bool P_0)
	{
		if (!IsDisposed)
		{
			EventHandler<EventArgs> eventHandler = eVxwANrjqTzeJKftsgENyXXYWKy;
			if (eventHandler != null)
			{
				eventHandler(this, EventArgs.Empty);
			}
			Dispose(P_0);
			GC.SuppressFinalize(this);
			IsDisposed = true;
			EventHandler<EventArgs> jARaeNAodyvPfyhWecWTbCDKbYK = JARaeNAodyvPfyhWecWTbCDKbYK;
			if (jARaeNAodyvPfyhWecWTbCDKbYK != null)
			{
				jARaeNAodyvPfyhWecWTbCDKbYK(this, EventArgs.Empty);
			}
		}
	}

	protected abstract void Dispose(bool P_0);
}
