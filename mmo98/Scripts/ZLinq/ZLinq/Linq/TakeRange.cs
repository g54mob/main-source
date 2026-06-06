using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct TakeRange<TEnumerator, TSource> : IValueEnumerator<TSource>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		private RangeProcessor rangeProcessor;

		private RefBox<ValueQueue<TSource>>? q;

		public TakeRange(TEnumerator source, Range range)
		{
			q = null;
			this.source = source;
			rangeProcessor = new RangeProcessor(range);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void Init()
		{
			if (rangeProcessor.Remains == -2)
			{
				if (source.TryGetNonEnumeratedCount(out var count))
				{
					rangeProcessor.Initialize(count);
				}
				else
				{
					rangeProcessor.Initialize();
				}
				if (rangeProcessor.FromEndQueueSize > 0)
				{
					q = new RefBox<ValueQueue<TSource>>(new ValueQueue<TSource>(Math.Min(rangeProcessor.FromEndQueueSize, 16)));
				}
			}
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			if (!source.TryGetNonEnumeratedCount(out count))
			{
				return false;
			}
			if (rangeProcessor.Remains == -2)
			{
				rangeProcessor.Initialize(count);
			}
			if (rangeProcessor.Remains >= 0)
			{
				count = rangeProcessor.Remains;
				return true;
			}
			count = 0;
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<TSource> span)
		{
			Init();
			if (rangeProcessor.Remains >= 0 && source.TryGetSpan(out span))
			{
				span = span.Slice(rangeProcessor.SkipIndex, rangeProcessor.Remains);
				return true;
			}
			span = default(ReadOnlySpan<TSource>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<TSource> destination, Index offset)
		{
			Init();
			if (rangeProcessor.Remains < 0 || !source.TryGetNonEnumeratedCount(out var count))
			{
				return false;
			}
			var (num, num2) = rangeProcessor.CalculateCopyParameters(count, destination.Length, offset);
			if (num2 <= 0)
			{
				return false;
			}
			return source.TryCopyTo(destination.Slice(0, num2), rangeProcessor.SkipIndex + num);
		}

		public bool TryGetNext(out TSource current)
		{
			int remains = rangeProcessor.Remains;
			if (remains == -2)
			{
				Init();
			}
			if (remains == 0)
			{
				Unsafe.SkipInit<TSource>(out current);
				return false;
			}
			if (q != null)
			{
				return TryGetNextWithQueue(out current);
			}
			return TryGetNextSimple(out current);
		}

		private bool TryGetNextSimple(out TSource current)
		{
			ref RangeProcessor reference = ref rangeProcessor;
			while (reference.Index < reference.SkipIndex)
			{
				if (!source.TryGetNext(out TSource _))
				{
					reference.Remains = 0;
					Unsafe.SkipInit<TSource>(out current);
					return false;
				}
				reference.Index++;
			}
			if (reference.Remains > 0 && source.TryGetNext(out current))
			{
				if (reference.Remains != int.MaxValue)
				{
					reference.Remains--;
				}
				return true;
			}
			reference.Remains = 0;
			Unsafe.SkipInit<TSource>(out current);
			return false;
		}

		private bool TryGetNextWithQueue(out TSource current)
		{
			ref RangeProcessor reference = ref rangeProcessor;
			ref ValueQueue<TSource> valueRef = ref q.GetValueRef();
			if (reference.Remains <= 0 || valueRef.Count <= 0)
			{
				bool flag = !reference.Range.Start.IsFromEnd && reference.Range.End.IsFromEnd;
				while (source.TryGetNext(out current))
				{
					if (reference.Index++ < reference.SkipIndex)
					{
						continue;
					}
					if (valueRef.Count == reference.FromEndQueueSize)
					{
						TSource val = valueRef.Dequeue();
						if (flag)
						{
							valueRef.Enqueue(current);
							current = val;
							return true;
						}
					}
					valueRef.Enqueue(current);
				}
				if (valueRef.Count == 0 || flag)
				{
					goto IL_00fd;
				}
				if (reference.Remains == -1)
				{
					reference.SkipQueue(ref valueRef);
				}
			}
			if (reference.Remains > 0)
			{
				current = valueRef.Dequeue();
				reference.Remains--;
				return true;
			}
			goto IL_00fd;
			IL_00fd:
			reference.Remains = 0;
			Unsafe.SkipInit<TSource>(out current);
			return false;
		}

		public void Dispose()
		{
			q?.Dispose();
			source.Dispose();
		}
	}
}
