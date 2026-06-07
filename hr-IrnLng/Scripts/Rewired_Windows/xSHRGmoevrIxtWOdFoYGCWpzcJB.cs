using System;
using System.Runtime.CompilerServices;
using System.Threading;

internal abstract class xSHRGmoevrIxtWOdFoYGCWpzcJB : IDisposable
{
	private EventHandler<EventArgs> fxkolWXNVsIEAbtNYknEkWQRZKX;

	private EventHandler<EventArgs> QsUmXWegXRCYcRDcEBeSBbATzXpS;

	[CompilerGenerated]
	private bool PvVeErsitUUCcXyevRzZjcTJBMx;

	public bool IsDisposed
	{
		[CompilerGenerated]
		get
		{
			return PvVeErsitUUCcXyevRzZjcTJBMx;
		}
		[CompilerGenerated]
		private set
		{
			PvVeErsitUUCcXyevRzZjcTJBMx = value;
		}
	}

	public event EventHandler<EventArgs> Disposing
	{
		add
		{
			EventHandler<EventArgs> eventHandler = fxkolWXNVsIEAbtNYknEkWQRZKX;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref fxkolWXNVsIEAbtNYknEkWQRZKX, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler<EventArgs> eventHandler = fxkolWXNVsIEAbtNYknEkWQRZKX;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref fxkolWXNVsIEAbtNYknEkWQRZKX, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<EventArgs> Disposed
	{
		add
		{
			EventHandler<EventArgs> eventHandler = QsUmXWegXRCYcRDcEBeSBbATzXpS;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref QsUmXWegXRCYcRDcEBeSBbATzXpS, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler<EventArgs> eventHandler = QsUmXWegXRCYcRDcEBeSBbATzXpS;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref QsUmXWegXRCYcRDcEBeSBbATzXpS, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	~xSHRGmoevrIxtWOdFoYGCWpzcJB()
	{
		EQLsmeJqPsIYibDTjmWyqeqBdnJI(false);
	}

	public void Dispose()
	{
		EQLsmeJqPsIYibDTjmWyqeqBdnJI(true);
	}

	private void EQLsmeJqPsIYibDTjmWyqeqBdnJI(bool P_0)
	{
		if (!IsDisposed)
		{
			fxkolWXNVsIEAbtNYknEkWQRZKX?.Invoke(this, EventArgs.Empty);
			KRgasgBmyLeCeDGJhNGqwMeOqCwJ(P_0);
			GC.SuppressFinalize(this);
			IsDisposed = true;
			QsUmXWegXRCYcRDcEBeSBbATzXpS?.Invoke(this, EventArgs.Empty);
		}
	}

	protected abstract void KRgasgBmyLeCeDGJhNGqwMeOqCwJ(bool P_0);
}
