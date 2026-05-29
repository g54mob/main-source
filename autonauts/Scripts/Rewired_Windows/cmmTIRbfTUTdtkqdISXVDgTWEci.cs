using System;
using System.Runtime.CompilerServices;
using System.Threading;

internal abstract class cmmTIRbfTUTdtkqdISXVDgTWEci : IDisposable
{
	private EventHandler<EventArgs> swJSnjWwzNlyQRDTBKkBzFHyiYa;

	private EventHandler<EventArgs> RSfBjvfWtyXgefgsBMuRiITaXUA;

	[CompilerGenerated]
	private bool OUkHOJlZBrgoHbkcipHOiWWaTwQ;

	public bool IsDisposed
	{
		[CompilerGenerated]
		get
		{
			return OUkHOJlZBrgoHbkcipHOiWWaTwQ;
		}
		[CompilerGenerated]
		private set
		{
			OUkHOJlZBrgoHbkcipHOiWWaTwQ = value;
		}
	}

	public event EventHandler<EventArgs> Disposing
	{
		add
		{
			EventHandler<EventArgs> eventHandler = swJSnjWwzNlyQRDTBKkBzFHyiYa;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref swJSnjWwzNlyQRDTBKkBzFHyiYa, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler<EventArgs> eventHandler = swJSnjWwzNlyQRDTBKkBzFHyiYa;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref swJSnjWwzNlyQRDTBKkBzFHyiYa, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<EventArgs> Disposed
	{
		add
		{
			EventHandler<EventArgs> eventHandler = RSfBjvfWtyXgefgsBMuRiITaXUA;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref RSfBjvfWtyXgefgsBMuRiITaXUA, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler<EventArgs> eventHandler = RSfBjvfWtyXgefgsBMuRiITaXUA;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref RSfBjvfWtyXgefgsBMuRiITaXUA, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	~cmmTIRbfTUTdtkqdISXVDgTWEci()
	{
		HJepETUDbRsWwlnJuONxfxXguGa(false);
	}

	public void Dispose()
	{
		HJepETUDbRsWwlnJuONxfxXguGa(true);
	}

	private void HJepETUDbRsWwlnJuONxfxXguGa(bool P_0)
	{
		if (!IsDisposed)
		{
			EventHandler<EventArgs> eventHandler = swJSnjWwzNlyQRDTBKkBzFHyiYa;
			if (eventHandler != null)
			{
				eventHandler(this, EventArgs.Empty);
			}
			Dispose(P_0);
			GC.SuppressFinalize(this);
			IsDisposed = true;
			EventHandler<EventArgs> rSfBjvfWtyXgefgsBMuRiITaXUA = RSfBjvfWtyXgefgsBMuRiITaXUA;
			if (rSfBjvfWtyXgefgsBMuRiITaXUA != null)
			{
				rSfBjvfWtyXgefgsBMuRiITaXUA(this, EventArgs.Empty);
			}
		}
	}

	protected abstract void Dispose(bool P_0);
}
