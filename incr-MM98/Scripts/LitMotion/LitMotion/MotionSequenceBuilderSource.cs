using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using LitMotion.Adapters;
using LitMotion.Collections;

namespace LitMotion
{
	internal sealed class MotionSequenceBuilderSource : ILinkedPoolNode<MotionSequenceBuilderSource>
	{
		private static LinkedPool<MotionSequenceBuilderSource> pool;

		private MotionSequenceBuilderSource next;

		private ushort version;

		private MotionSequenceItem[] buffer;

		private int count;

		private double tail;

		private double lastTail;

		private double duration;

		public ref MotionSequenceBuilderSource NextNode => ref next;

		public ushort Version => version;

		public static MotionSequenceBuilderSource Rent()
		{
			if (!pool.TryPop(out var result))
			{
				return new MotionSequenceBuilderSource();
			}
			return result;
		}

		public static void Return(MotionSequenceBuilderSource source)
		{
			if (source.buffer != null)
			{
				ArrayPool<MotionSequenceItem>.Shared.Return(source.buffer);
			}
			source.version++;
			source.buffer = null;
			source.tail = 0.0;
			source.lastTail = 0.0;
			source.count = 0;
			source.duration = 0.0;
			pool.TryPush(source);
		}

		public void Append(MotionHandle handle)
		{
			MotionManager.AddToSequence(handle, out var motionDuration);
			AddItem(new MotionSequenceItem(tail, handle));
			AppendInterval(motionDuration);
		}

		public void AppendInterval(double interval)
		{
			lastTail = tail;
			tail += interval;
			duration = Math.Max(duration, tail);
		}

		public void Insert(double position, MotionHandle handle)
		{
			MotionManager.AddToSequence(handle, out var motionDuration);
			AddItem(new MotionSequenceItem(position, handle));
			duration = Math.Max(duration, position + motionDuration);
		}

		public void Join(MotionHandle handle)
		{
			Insert(lastTail, handle);
		}

		public MotionHandle Schedule(Action<MotionBuilder<double, NoOptions, DoubleMotionAdapter>> configuration)
		{
			MotionSequenceSource motionSequenceSource = MotionSequenceSource.Rent();
			MotionBuilder<double, NoOptions, DoubleMotionAdapter> obj = LMotion.Create(0.0, duration, (float)duration).WithOnComplete(motionSequenceSource.OnCompleteDelegate).WithOnCancel(motionSequenceSource.OnCancelDelegate);
			configuration?.Invoke(obj);
			MotionHandle motionHandle = obj.Bind(motionSequenceSource, delegate(double x, MotionSequenceSource source)
			{
				source.Time = x;
			});
			motionSequenceSource.Initialize(motionHandle, buffer, count, duration);
			buffer = null;
			return motionHandle;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void AddItem(in MotionSequenceItem item)
		{
			if (buffer == null)
			{
				buffer = ArrayPool<MotionSequenceItem>.Shared.Rent(32);
			}
			else if (buffer.Length == count)
			{
				MotionSequenceItem[] array = ArrayPool<MotionSequenceItem>.Shared.Rent(count * 2);
				buffer.CopyTo(array.AsSpan(0, count));
				ArrayPool<MotionSequenceItem>.Shared.Return(buffer);
				buffer = array;
			}
			buffer[count] = item;
			count++;
		}
	}
}
