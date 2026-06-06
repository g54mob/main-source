using System;
using System.Buffers;
using LitMotion.Collections;

namespace LitMotion
{
	internal sealed class MotionSequenceSource : ILinkedPoolNode<MotionSequenceSource>
	{
		private static LinkedPool<MotionSequenceSource> pool;

		private readonly Action onCompleteDelegate;

		private readonly Action onCancelDelegate;

		private MotionSequenceSource next;

		private MotionHandle handle;

		private MotionSequenceItem[] itemBuffer;

		private int itemCount;

		private double duration;

		private double time;

		public ref MotionSequenceSource NextNode => ref next;

		public Action OnCompleteDelegate => onCompleteDelegate;

		public Action OnCancelDelegate => onCancelDelegate;

		public ReadOnlySpan<MotionSequenceItem> Items => itemBuffer.AsSpan(0, itemCount);

		public double Time
		{
			get
			{
				return time;
			}
			set
			{
				time = value;
				ReadOnlySpan<MotionSequenceItem> items = Items;
				int num;
				for (num = items.Length - 1; num >= 0; num--)
				{
					MotionSequenceItem motionSequenceItem = items[num];
					if (motionSequenceItem.Position < time)
					{
						break;
					}
					MotionManager.SetTime(motionSequenceItem.Handle, time - motionSequenceItem.Position, checkIsInSequence: false);
				}
				ReadOnlySpan<MotionSequenceItem> readOnlySpan = items;
				ReadOnlySpan<MotionSequenceItem> readOnlySpan2 = readOnlySpan.Slice(0, num + 1);
				for (int i = 0; i < readOnlySpan2.Length; i++)
				{
					MotionSequenceItem motionSequenceItem2 = readOnlySpan2[i];
					MotionManager.SetTime(motionSequenceItem2.Handle, time - motionSequenceItem2.Position, checkIsInSequence: false);
				}
			}
		}

		public double Duration => duration;

		public static MotionSequenceSource Rent()
		{
			if (!pool.TryPop(out var result))
			{
				return new MotionSequenceSource();
			}
			return result;
		}

		public static void Return(MotionSequenceSource source)
		{
			if (source.itemBuffer != null)
			{
				ArrayPool<MotionSequenceItem>.Shared.Return(source.itemBuffer);
				source.itemBuffer = null;
			}
			source.itemCount = 0;
			source.duration = 0.0;
			source.time = 0.0;
			pool.TryPush(source);
		}

		public void Initialize(MotionHandle handle, MotionSequenceItem[] itemBuffer, int itemCount, double duration)
		{
			this.handle = handle;
			this.itemCount = itemCount;
			this.itemBuffer = itemBuffer;
			this.duration = duration;
			time = 0.0;
			if (itemBuffer != null)
			{
				Array.Sort(itemBuffer, 0, itemCount);
			}
		}

		private MotionSequenceSource()
		{
			onCompleteDelegate = OnComplete;
			onCancelDelegate = OnCancel;
		}

		private void OnComplete()
		{
			if (handle.IsValid() && !MotionManager.GetDataRef(handle, checkIsInSequence: false).State.IsPreserved)
			{
				ReadOnlySpan<MotionSequenceItem> items = Items;
				for (int i = 0; i < items.Length; i++)
				{
					MotionManager.Cancel(items[i].Handle, checkIsInSequence: false);
				}
				Return(this);
			}
		}

		private void OnCancel()
		{
			ReadOnlySpan<MotionSequenceItem> items = Items;
			for (int i = 0; i < items.Length; i++)
			{
				MotionManager.Cancel(items[i].Handle, checkIsInSequence: false);
			}
			Return(this);
		}
	}
}
