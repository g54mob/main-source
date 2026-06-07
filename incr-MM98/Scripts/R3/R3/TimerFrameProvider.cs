using System;
using System.Threading;
using R3.Collections;
using R3.Internal;

namespace R3
{
	public sealed class TimerFrameProvider : FrameProvider, IDisposable
	{
		private static readonly TimerCallback timerCallback = Run;

		private readonly object gate = new object();

		private long frameCount;

		private bool disposed;

		private FreeListCore<IFrameRunnerWorkItem> list;

		private ITimer timer;

		public TimerFrameProvider(TimeSpan period)
			: this(period, period, TimeProvider.System)
		{
		}

		public TimerFrameProvider(TimeSpan dueTime, TimeSpan period)
			: this(dueTime, period, TimeProvider.System)
		{
		}

		public TimerFrameProvider(TimeSpan dueTime, TimeSpan period, TimeProvider timeProvider)
		{
			list = new FreeListCore<IFrameRunnerWorkItem>(gate);
			timer = timeProvider.CreateStoppedTimer(timerCallback, this);
			timer.Change(dueTime, period);
		}

		public override long GetFrameCount()
		{
			ThrowHelper.ThrowObjectDisposedIf(disposed, typeof(TimerFrameProvider));
			return frameCount;
		}

		public override void Register(IFrameRunnerWorkItem callback)
		{
			ThrowHelper.ThrowObjectDisposedIf(disposed, typeof(TimerFrameProvider));
			list.Add(callback, out var _);
		}

		public void Dispose()
		{
			if (!disposed)
			{
				disposed = true;
				lock (gate)
				{
					timer.Dispose();
					list.Dispose();
				}
			}
		}

		private static void Run(object? state)
		{
			TimerFrameProvider timerFrameProvider = (TimerFrameProvider)state;
			if (timerFrameProvider.disposed)
			{
				return;
			}
			lock (timerFrameProvider.gate)
			{
				timerFrameProvider.frameCount++;
				ReadOnlySpan<IFrameRunnerWorkItem> readOnlySpan = timerFrameProvider.list.AsSpan();
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					ref readonly IFrameRunnerWorkItem reference = ref readOnlySpan[i];
					if (reference == null)
					{
						continue;
					}
					try
					{
						if (!reference.MoveNext(timerFrameProvider.frameCount))
						{
							timerFrameProvider.list.Remove(i);
						}
					}
					catch (Exception obj)
					{
						timerFrameProvider.list.Remove(i);
						try
						{
							ObservableSystem.GetUnhandledExceptionHandler()(obj);
						}
						catch
						{
						}
					}
				}
			}
		}
	}
}
