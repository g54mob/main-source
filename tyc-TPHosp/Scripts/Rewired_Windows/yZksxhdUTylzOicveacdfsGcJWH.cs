using System;
using System.Runtime.CompilerServices;
using System.Threading;

internal abstract class yZksxhdUTylzOicveacdfsGcJWH : IDisposable
{
	private EventHandler<EventArgs> mIFRUBSlbrcMhLAXzQIxLMbCePH;

	private EventHandler<EventArgs> JDpjQPtnvKnIPnKyhbGrAsxCQBn;

	[CompilerGenerated]
	private bool EkyyKwdXTFMzDxgqYHVoAkuCSOf;

	public bool IsDisposed
	{
		[CompilerGenerated]
		get
		{
			return EkyyKwdXTFMzDxgqYHVoAkuCSOf;
		}
		[CompilerGenerated]
		private set
		{
			EkyyKwdXTFMzDxgqYHVoAkuCSOf = value;
		}
	}

	public event EventHandler<EventArgs> Disposing
	{
		add
		{
			EventHandler<EventArgs> eventHandler = mIFRUBSlbrcMhLAXzQIxLMbCePH;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref mIFRUBSlbrcMhLAXzQIxLMbCePH, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler<EventArgs> eventHandler = mIFRUBSlbrcMhLAXzQIxLMbCePH;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref mIFRUBSlbrcMhLAXzQIxLMbCePH, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<EventArgs> Disposed
	{
		add
		{
			EventHandler<EventArgs> eventHandler = JDpjQPtnvKnIPnKyhbGrAsxCQBn;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref JDpjQPtnvKnIPnKyhbGrAsxCQBn, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler<EventArgs> eventHandler = JDpjQPtnvKnIPnKyhbGrAsxCQBn;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref JDpjQPtnvKnIPnKyhbGrAsxCQBn, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	~yZksxhdUTylzOicveacdfsGcJWH()
	{
		VxcMVfGtbtYdNtIHEdkTPKVYBnLI(false);
	}

	public void Dispose()
	{
		VxcMVfGtbtYdNtIHEdkTPKVYBnLI(true);
	}

	private void VxcMVfGtbtYdNtIHEdkTPKVYBnLI(bool P_0)
	{
		if (!IsDisposed)
		{
			mIFRUBSlbrcMhLAXzQIxLMbCePH?.Invoke(this, EventArgs.Empty);
			LLOFbzNISIbRkZTwkaVnsPpYig(P_0);
			GC.SuppressFinalize(this);
			IsDisposed = true;
			JDpjQPtnvKnIPnKyhbGrAsxCQBn?.Invoke(this, EventArgs.Empty);
		}
	}

	protected abstract void LLOFbzNISIbRkZTwkaVnsPpYig(bool P_0);
}
