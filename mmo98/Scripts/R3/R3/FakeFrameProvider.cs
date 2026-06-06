using System;
using R3.Collections;

namespace R3
{
	public sealed class FakeFrameProvider : FrameProvider
	{
		private long frameCount;

		private readonly object gate = new object();

		private FreeListCore<IFrameRunnerWorkItem> list;

		public FakeFrameProvider()
		{
			list = new FreeListCore<IFrameRunnerWorkItem>(gate);
			frameCount = 0L;
		}

		public FakeFrameProvider(long frameCount)
		{
			list = new FreeListCore<IFrameRunnerWorkItem>(gate);
			this.frameCount = frameCount;
		}

		public override long GetFrameCount()
		{
			return frameCount;
		}

		public override void Register(IFrameRunnerWorkItem callback)
		{
			list.Add(callback, out var _);
		}

		public void Advance()
		{
			Advance(1);
		}

		public void Advance(int advanceCount)
		{
			for (int i = 0; i < advanceCount; i++)
			{
				RunLoop();
			}
		}

		public int GetRegisteredCount()
		{
			ReadOnlySpan<IFrameRunnerWorkItem?> readOnlySpan = list.AsSpan();
			int num = 0;
			ReadOnlySpan<IFrameRunnerWorkItem> readOnlySpan2 = readOnlySpan;
			for (int i = 0; i < readOnlySpan2.Length; i++)
			{
				if (readOnlySpan2[i] != null)
				{
					num++;
				}
			}
			return num;
		}

		private void RunLoop()
		{
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
			frameCount++;
		}
	}
}
