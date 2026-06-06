using System;
using System.Threading;
using R3.Collections;
using R3.Internal;

namespace R3
{
	public sealed class NewThreadSleepFrameProvider : FrameProvider, IDisposable
	{
		private readonly int sleepMilliseconds;

		private bool disposed;

		private long frameCount;

		private FreeListCore<IFrameRunnerWorkItem> list;

		private Thread thread;

		public NewThreadSleepFrameProvider()
			: this(1)
		{
		}

		public NewThreadSleepFrameProvider(int sleepMilliseconds)
		{
			this.sleepMilliseconds = sleepMilliseconds;
			list = new FreeListCore<IFrameRunnerWorkItem>(this);
			thread = new Thread(Run)
			{
				IsBackground = true
			};
			thread.Start();
		}

		public override long GetFrameCount()
		{
			ThrowHelper.ThrowObjectDisposedIf(disposed, typeof(NewThreadSleepFrameProvider));
			return frameCount;
		}

		public override void Register(IFrameRunnerWorkItem callback)
		{
			ThrowHelper.ThrowObjectDisposedIf(disposed, typeof(NewThreadSleepFrameProvider));
			list.Add(callback, out var _);
		}

		public void Dispose()
		{
			disposed = true;
		}

		private void Run()
		{
			while (!disposed)
			{
				frameCount++;
				ReadOnlySpan<IFrameRunnerWorkItem> readOnlySpan = list.AsSpan();
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					ref readonly IFrameRunnerWorkItem reference = ref readOnlySpan[i];
					if (reference == null)
					{
						continue;
					}
					try
					{
						if (!reference.MoveNext(frameCount))
						{
							list.Remove(i);
						}
					}
					catch (Exception obj)
					{
						list.Remove(i);
						try
						{
							ObservableSystem.GetUnhandledExceptionHandler()(obj);
						}
						catch
						{
						}
					}
				}
				Thread.Sleep(sleepMilliseconds);
			}
			list.Dispose();
		}
	}
}
