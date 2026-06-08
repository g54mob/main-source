using System;
using System.Runtime.CompilerServices;
using System.Threading;

internal abstract class bmLmBCpqnyTtLeIFgDTVIITYzQAA : IDisposable
{
	private EventHandler<EventArgs> ndejLiIlBzQWwXlfnpZLukciGBW;

	private EventHandler<EventArgs> YyWjNyxDDEGIYjwMdqzDzyecqKy;

	[CompilerGenerated]
	private bool BCVLRJdilVFQWHhWMLoKDxtqIZmb;

	public bool IsDisposed
	{
		[CompilerGenerated]
		get
		{
			return BCVLRJdilVFQWHhWMLoKDxtqIZmb;
		}
		[CompilerGenerated]
		private set
		{
			BCVLRJdilVFQWHhWMLoKDxtqIZmb = value;
		}
	}

	public event EventHandler<EventArgs> Disposing
	{
		add
		{
			EventHandler<EventArgs> eventHandler = ndejLiIlBzQWwXlfnpZLukciGBW;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref ndejLiIlBzQWwXlfnpZLukciGBW, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler<EventArgs> eventHandler = ndejLiIlBzQWwXlfnpZLukciGBW;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref ndejLiIlBzQWwXlfnpZLukciGBW, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<EventArgs> Disposed
	{
		add
		{
			EventHandler<EventArgs> eventHandler = YyWjNyxDDEGIYjwMdqzDzyecqKy;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref YyWjNyxDDEGIYjwMdqzDzyecqKy, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler<EventArgs> eventHandler = YyWjNyxDDEGIYjwMdqzDzyecqKy;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref YyWjNyxDDEGIYjwMdqzDzyecqKy, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	~bmLmBCpqnyTtLeIFgDTVIITYzQAA()
	{
		IJTMtYKBXlXEOfPdSHVhiiEaucI(false);
	}

	public void Dispose()
	{
		IJTMtYKBXlXEOfPdSHVhiiEaucI(true);
	}

	private void IJTMtYKBXlXEOfPdSHVhiiEaucI(bool P_0)
	{
		if (!IsDisposed)
		{
			ndejLiIlBzQWwXlfnpZLukciGBW?.Invoke(this, EventArgs.Empty);
			WYoEhOBxiSjIYKwbsCHdGOUBXDbi(P_0);
			GC.SuppressFinalize(this);
			IsDisposed = true;
			YyWjNyxDDEGIYjwMdqzDzyecqKy?.Invoke(this, EventArgs.Empty);
		}
	}

	protected abstract void WYoEhOBxiSjIYKwbsCHdGOUBXDbi(bool P_0);
}
