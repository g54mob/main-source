using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace CommunityToolkit.HighPerformance.Helpers
{
	public static class ParallelHelper
	{
		private readonly struct ActionInvoker<TAction> where TAction : struct, IAction
		{
			private readonly int start;

			private readonly int end;

			private readonly int batchSize;

			private readonly TAction action;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ActionInvoker(int start, int end, int batchSize, in TAction action)
			{
				this.start = start;
				this.end = end;
				this.batchSize = batchSize;
				this.action = action;
			}

			public void Invoke(int i)
			{
				int num = i * batchSize;
				int num2 = start + num;
				int num3 = Math.Min(num2 + batchSize, end);
				for (int j = num2; j < num3; j++)
				{
					Unsafe.AsRef(in action).Invoke(j);
				}
			}
		}

		private readonly struct Action2DInvoker<TAction> where TAction : struct, IAction2D
		{
			private readonly int startY;

			private readonly int endY;

			private readonly int startX;

			private readonly int endX;

			private readonly int batchHeight;

			private readonly TAction action;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public Action2DInvoker(int startY, int endY, int startX, int endX, int batchHeight, in TAction action)
			{
				this.startY = startY;
				this.endY = endY;
				this.startX = startX;
				this.endX = endX;
				this.batchHeight = batchHeight;
				this.action = action;
			}

			public void Invoke(int i)
			{
				int num = i * batchHeight;
				int num2 = startY + num;
				int num3 = Math.Min(num2 + batchHeight, endY);
				for (int j = num2; j < num3; j++)
				{
					for (int k = startX; k < endX; k++)
					{
						Unsafe.AsRef(in action).Invoke(j, k);
					}
				}
			}
		}

		private readonly struct InActionInvoker<TItem, TAction> where TAction : struct, IInAction<TItem>
		{
			private readonly int batchSize;

			private readonly ReadOnlyMemory<TItem> memory;

			private readonly TAction action;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public InActionInvoker(int batchSize, ReadOnlyMemory<TItem> memory, in TAction action)
			{
				this.batchSize = batchSize;
				this.memory = memory;
				this.action = action;
			}

			public void Invoke(int i)
			{
				int num = i * batchSize;
				int elementOffset = Math.Min(num + batchSize, memory.Length);
				ref TItem reference = ref MemoryMarshal.GetReference(memory.Span);
				ref TItem reference2 = ref Unsafe.Add(ref reference, num);
				ref TItem right = ref Unsafe.Add(ref reference, elementOffset);
				while (Unsafe.IsAddressLessThan(ref reference2, ref right))
				{
					Unsafe.AsRef(in action).Invoke(in reference2);
					reference2 = ref Unsafe.Add(ref reference2, 1);
				}
			}
		}

		private readonly struct InActionInvokerWithReadOnlyMemory2D<TItem, TAction> where TAction : struct, IInAction<TItem>
		{
			private readonly int batchHeight;

			private readonly ReadOnlyMemory2D<TItem> memory;

			private readonly TAction action;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public InActionInvokerWithReadOnlyMemory2D(int batchHeight, ReadOnlyMemory2D<TItem> memory, in TAction action)
			{
				this.batchHeight = batchHeight;
				this.memory = memory;
				this.action = action;
			}

			public void Invoke(int i)
			{
				int num = i * batchHeight;
				nint num2 = num + batchHeight;
				int num3 = (int)((num2 <= memory.Height) ? num2 : memory.Height);
				int width = memory.Width;
				ReadOnlySpan2D<TItem> span = memory.Span;
				for (int j = num; j < num3; j++)
				{
					ref TItem reference = ref span.DangerousGetReferenceAt(j, 0);
					ref TItem right = ref Unsafe.Add(ref reference, width);
					while (Unsafe.IsAddressLessThan(ref reference, ref right))
					{
						Unsafe.AsRef(in action).Invoke(in reference);
						reference = ref Unsafe.Add(ref reference, 1);
					}
				}
			}
		}

		private readonly struct RefActionInvoker<TItem, TAction> where TAction : struct, IRefAction<TItem>
		{
			private readonly int batchSize;

			private readonly ReadOnlyMemory<TItem> memory;

			private readonly TAction action;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public RefActionInvoker(int batchSize, ReadOnlyMemory<TItem> memory, in TAction action)
			{
				this.batchSize = batchSize;
				this.memory = memory;
				this.action = action;
			}

			public void Invoke(int i)
			{
				int num = i * batchSize;
				int elementOffset = Math.Min(num + batchSize, memory.Length);
				ref TItem reference = ref MemoryMarshal.GetReference(memory.Span);
				ref TItem reference2 = ref Unsafe.Add(ref reference, num);
				ref TItem right = ref Unsafe.Add(ref reference, elementOffset);
				while (Unsafe.IsAddressLessThan(ref reference2, ref right))
				{
					Unsafe.AsRef(in action).Invoke(ref reference2);
					reference2 = ref Unsafe.Add(ref reference2, 1);
				}
			}
		}

		private readonly struct RefActionInvokerWithReadOnlyMemory2D<TItem, TAction> where TAction : struct, IRefAction<TItem>
		{
			private readonly int batchHeight;

			private readonly Memory2D<TItem> memory;

			private readonly TAction action;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public RefActionInvokerWithReadOnlyMemory2D(int batchHeight, Memory2D<TItem> memory, in TAction action)
			{
				this.batchHeight = batchHeight;
				this.memory = memory;
				this.action = action;
			}

			public void Invoke(int i)
			{
				int num = i * batchHeight;
				nint num2 = num + batchHeight;
				int num3 = (int)((num2 <= memory.Height) ? num2 : memory.Height);
				int width = memory.Width;
				ReadOnlySpan2D<TItem> readOnlySpan2D = memory.Span;
				for (int j = num; j < num3; j++)
				{
					ref TItem reference = ref readOnlySpan2D.DangerousGetReferenceAt(j, 0);
					ref TItem right = ref Unsafe.Add(ref reference, width);
					while (Unsafe.IsAddressLessThan(ref reference, ref right))
					{
						Unsafe.AsRef(in action).Invoke(ref reference);
						reference = ref Unsafe.Add(ref reference, 1);
					}
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void For<TAction>(Range range) where TAction : struct, IAction
		{
			For<TAction>(range, default(TAction), 1);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void For<TAction>(Range range, int minimumActionsPerThread) where TAction : struct, IAction
		{
			For<TAction>(range, default(TAction), minimumActionsPerThread);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void For<TAction>(Range range, in TAction action) where TAction : struct, IAction
		{
			For(range, in action, 1);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void For<TAction>(Range range, in TAction action, int minimumActionsPerThread) where TAction : struct, IAction
		{
			if (range.Start.IsFromEnd || range.End.IsFromEnd)
			{
				ThrowArgumentExceptionForRangeIndexFromEnd("range");
			}
			int value = range.Start.Value;
			int value2 = range.End.Value;
			For(value, value2, in action, minimumActionsPerThread);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void For<TAction>(int start, int end) where TAction : struct, IAction
		{
			For<TAction>(start, end, default(TAction), 1);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void For<TAction>(int start, int end, int minimumActionsPerThread) where TAction : struct, IAction
		{
			For<TAction>(start, end, default(TAction), minimumActionsPerThread);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void For<TAction>(int start, int end, in TAction action) where TAction : struct, IAction
		{
			For(start, end, in action, 1);
		}

		public static void For<TAction>(int start, int end, in TAction action, int minimumActionsPerThread) where TAction : struct, IAction
		{
			if (minimumActionsPerThread <= 0)
			{
				ThrowArgumentOutOfRangeExceptionForInvalidMinimumActionsPerThread();
			}
			if (start > end)
			{
				ThrowArgumentOutOfRangeExceptionForStartGreaterThanEnd();
			}
			if (start == end)
			{
				return;
			}
			int num = Math.Abs(start - end);
			int val = 1 + (num - 1) / minimumActionsPerThread;
			int processorCount = Environment.ProcessorCount;
			int num2 = Math.Min(val, processorCount);
			if (num2 == 1)
			{
				for (int i = start; i < end; i++)
				{
					Unsafe.AsRef(in action).Invoke(i);
				}
			}
			else
			{
				int batchSize = 1 + (num - 1) / num2;
				ActionInvoker<TAction> actionInvoker = new ActionInvoker<TAction>(start, end, batchSize, in action);
				Parallel.For(0, num2, new ParallelOptions
				{
					MaxDegreeOfParallelism = num2
				}, ((ActionInvoker<TAction>)actionInvoker).Invoke);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void For2D<TAction>(Range i, Range j) where TAction : struct, IAction2D
		{
			For2D<TAction>(i, j, default(TAction), 1);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void For2D<TAction>(Range i, Range j, int minimumActionsPerThread) where TAction : struct, IAction2D
		{
			For2D<TAction>(i, j, default(TAction), minimumActionsPerThread);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void For2D<TAction>(Range i, Range j, in TAction action) where TAction : struct, IAction2D
		{
			For2D(i, j, in action, 1);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void For2D<TAction>(Range i, Range j, in TAction action, int minimumActionsPerThread) where TAction : struct, IAction2D
		{
			if (i.Start.IsFromEnd || i.End.IsFromEnd)
			{
				ThrowArgumentExceptionForRangeIndexFromEnd("i");
			}
			if (j.Start.IsFromEnd || j.End.IsFromEnd)
			{
				ThrowArgumentExceptionForRangeIndexFromEnd("j");
			}
			int value = i.Start.Value;
			int value2 = i.End.Value;
			int value3 = j.Start.Value;
			int value4 = j.End.Value;
			For2D(value, value2, value3, value4, in action, minimumActionsPerThread);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void For2D<TAction>(Rectangle area) where TAction : struct, IAction2D
		{
			For2D<TAction>(area.Top, area.Bottom, area.Left, area.Right, default(TAction), 1);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void For2D<TAction>(Rectangle area, int minimumActionsPerThread) where TAction : struct, IAction2D
		{
			For2D<TAction>(area.Top, area.Bottom, area.Left, area.Right, default(TAction), minimumActionsPerThread);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void For2D<TAction>(Rectangle area, in TAction action) where TAction : struct, IAction2D
		{
			For2D(area.Top, area.Bottom, area.Left, area.Right, in action, 1);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void For2D<TAction>(Rectangle area, in TAction action, int minimumActionsPerThread) where TAction : struct, IAction2D
		{
			For2D(area.Top, area.Bottom, area.Left, area.Right, in action, minimumActionsPerThread);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void For2D<TAction>(int top, int bottom, int left, int right) where TAction : struct, IAction2D
		{
			For2D<TAction>(top, bottom, left, right, default(TAction), 1);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void For2D<TAction>(int top, int bottom, int left, int right, int minimumActionsPerThread) where TAction : struct, IAction2D
		{
			For2D<TAction>(top, bottom, left, right, default(TAction), minimumActionsPerThread);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void For2D<TAction>(int top, int bottom, int left, int right, in TAction action) where TAction : struct, IAction2D
		{
			For2D(top, bottom, left, right, in action, 1);
		}

		public static void For2D<TAction>(int top, int bottom, int left, int right, in TAction action, int minimumActionsPerThread) where TAction : struct, IAction2D
		{
			if (minimumActionsPerThread <= 0)
			{
				ThrowArgumentOutOfRangeExceptionForInvalidMinimumActionsPerThread();
			}
			if (top > bottom)
			{
				ThrowArgumentOutOfRangeExceptionForTopGreaterThanBottom();
			}
			if (left > right)
			{
				ThrowArgumentOutOfRangeExceptionForLeftGreaterThanRight();
			}
			if (top == bottom || left == right)
			{
				return;
			}
			int num = Math.Abs(top - bottom);
			int num2 = Math.Abs(left - right);
			int num3 = num * num2;
			int val = Math.Min(1 + (num3 - 1) / minimumActionsPerThread, num);
			int processorCount = Environment.ProcessorCount;
			int num4 = Math.Min(val, processorCount);
			if (num4 == 1)
			{
				for (int i = top; i < bottom; i++)
				{
					for (int j = left; j < right; j++)
					{
						Unsafe.AsRef(in action).Invoke(i, j);
					}
				}
			}
			else
			{
				int batchHeight = 1 + (num - 1) / num4;
				Action2DInvoker<TAction> action2DInvoker = new Action2DInvoker<TAction>(top, bottom, left, right, batchHeight, in action);
				Parallel.For(0, num4, new ParallelOptions
				{
					MaxDegreeOfParallelism = num4
				}, ((Action2DInvoker<TAction>)action2DInvoker).Invoke);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ForEach<TItem, TAction>(ReadOnlyMemory<TItem> memory) where TAction : struct, IInAction<TItem>
		{
			ForEach<TItem, TAction>(memory, default(TAction), 1);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ForEach<TItem, TAction>(ReadOnlyMemory<TItem> memory, int minimumActionsPerThread) where TAction : struct, IInAction<TItem>
		{
			ForEach<TItem, TAction>(memory, default(TAction), minimumActionsPerThread);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ForEach<TItem, TAction>(ReadOnlyMemory<TItem> memory, in TAction action) where TAction : struct, IInAction<TItem>
		{
			ForEach(memory, in action, 1);
		}

		public static void ForEach<TItem, TAction>(ReadOnlyMemory<TItem> memory, in TAction action, int minimumActionsPerThread) where TAction : struct, IInAction<TItem>
		{
			if (minimumActionsPerThread <= 0)
			{
				ThrowArgumentOutOfRangeExceptionForInvalidMinimumActionsPerThread();
			}
			if (memory.IsEmpty)
			{
				return;
			}
			int val = 1 + (memory.Length - 1) / minimumActionsPerThread;
			int processorCount = Environment.ProcessorCount;
			int num = Math.Min(val, processorCount);
			if (num == 1)
			{
				ReadOnlySpan<TItem> span = memory.Span;
				for (int i = 0; i < span.Length; i++)
				{
					TItem item = span[i];
					Unsafe.AsRef(in action).Invoke(in item);
				}
			}
			else
			{
				int batchSize = 1 + (memory.Length - 1) / num;
				InActionInvoker<TItem, TAction> inActionInvoker = new InActionInvoker<TItem, TAction>(batchSize, memory, in action);
				Parallel.For(0, num, new ParallelOptions
				{
					MaxDegreeOfParallelism = num
				}, ((InActionInvoker<TItem, TAction>)inActionInvoker).Invoke);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ForEach<TItem, TAction>(ReadOnlyMemory2D<TItem> memory) where TAction : struct, IInAction<TItem>
		{
			ForEach<TItem, TAction>(memory, default(TAction), 1);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ForEach<TItem, TAction>(ReadOnlyMemory2D<TItem> memory, int minimumActionsPerThread) where TAction : struct, IInAction<TItem>
		{
			ForEach<TItem, TAction>(memory, default(TAction), minimumActionsPerThread);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ForEach<TItem, TAction>(ReadOnlyMemory2D<TItem> memory, in TAction action) where TAction : struct, IInAction<TItem>
		{
			ForEach(memory, in action, 1);
		}

		public static void ForEach<TItem, TAction>(ReadOnlyMemory2D<TItem> memory, in TAction action, int minimumActionsPerThread) where TAction : struct, IInAction<TItem>
		{
			if (minimumActionsPerThread <= 0)
			{
				ThrowArgumentOutOfRangeExceptionForInvalidMinimumActionsPerThread();
			}
			if (!memory.IsEmpty)
			{
				nint num = 1 + (memory.Length - 1) / minimumActionsPerThread;
				IntPtr intPtr = ((num <= memory.Height) ? num : memory.Height);
				int processorCount = Environment.ProcessorCount;
				int num2 = (int)(((nint)intPtr <= processorCount) ? ((nint)intPtr) : ((nint)processorCount));
				int batchHeight = 1 + (memory.Height - 1) / num2;
				InActionInvokerWithReadOnlyMemory2D<TItem, TAction> inActionInvokerWithReadOnlyMemory2D = new InActionInvokerWithReadOnlyMemory2D<TItem, TAction>(batchHeight, memory, in action);
				if (num2 == 1)
				{
					inActionInvokerWithReadOnlyMemory2D.Invoke(0);
					return;
				}
				Parallel.For(0, num2, new ParallelOptions
				{
					MaxDegreeOfParallelism = num2
				}, ((InActionInvokerWithReadOnlyMemory2D<TItem, TAction>)inActionInvokerWithReadOnlyMemory2D).Invoke);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ForEach<TItem, TAction>(Memory<TItem> memory) where TAction : struct, IRefAction<TItem>
		{
			ForEach<TItem, TAction>(memory, default(TAction), 1);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ForEach<TItem, TAction>(Memory<TItem> memory, int minimumActionsPerThread) where TAction : struct, IRefAction<TItem>
		{
			ForEach<TItem, TAction>(memory, default(TAction), minimumActionsPerThread);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ForEach<TItem, TAction>(Memory<TItem> memory, in TAction action) where TAction : struct, IRefAction<TItem>
		{
			ForEach(memory, in action, 1);
		}

		public static void ForEach<TItem, TAction>(Memory<TItem> memory, in TAction action, int minimumActionsPerThread) where TAction : struct, IRefAction<TItem>
		{
			if (minimumActionsPerThread <= 0)
			{
				ThrowArgumentOutOfRangeExceptionForInvalidMinimumActionsPerThread();
			}
			if (memory.IsEmpty)
			{
				return;
			}
			int val = 1 + (memory.Length - 1) / minimumActionsPerThread;
			int processorCount = Environment.ProcessorCount;
			int num = Math.Min(val, processorCount);
			if (num == 1)
			{
				Span<TItem> span = memory.Span;
				for (int i = 0; i < span.Length; i++)
				{
					ref TItem item = ref span[i];
					Unsafe.AsRef(in action).Invoke(ref item);
				}
			}
			else
			{
				int batchSize = 1 + (memory.Length - 1) / num;
				RefActionInvoker<TItem, TAction> refActionInvoker = new RefActionInvoker<TItem, TAction>(batchSize, memory, in action);
				Parallel.For(0, num, new ParallelOptions
				{
					MaxDegreeOfParallelism = num
				}, ((RefActionInvoker<TItem, TAction>)refActionInvoker).Invoke);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ForEach<TItem, TAction>(Memory2D<TItem> memory) where TAction : struct, IRefAction<TItem>
		{
			ForEach<TItem, TAction>(memory, default(TAction), 1);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ForEach<TItem, TAction>(Memory2D<TItem> memory, int minimumActionsPerThread) where TAction : struct, IRefAction<TItem>
		{
			ForEach<TItem, TAction>(memory, default(TAction), minimumActionsPerThread);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ForEach<TItem, TAction>(Memory2D<TItem> memory, in TAction action) where TAction : struct, IRefAction<TItem>
		{
			ForEach(memory, in action, 1);
		}

		public static void ForEach<TItem, TAction>(Memory2D<TItem> memory, in TAction action, int minimumActionsPerThread) where TAction : struct, IRefAction<TItem>
		{
			if (minimumActionsPerThread <= 0)
			{
				ThrowArgumentOutOfRangeExceptionForInvalidMinimumActionsPerThread();
			}
			if (!memory.IsEmpty)
			{
				nint num = 1 + (memory.Length - 1) / minimumActionsPerThread;
				IntPtr intPtr = ((num <= memory.Height) ? num : memory.Height);
				int processorCount = Environment.ProcessorCount;
				int num2 = (int)(((nint)intPtr <= processorCount) ? ((nint)intPtr) : ((nint)processorCount));
				int batchHeight = 1 + (memory.Height - 1) / num2;
				RefActionInvokerWithReadOnlyMemory2D<TItem, TAction> refActionInvokerWithReadOnlyMemory2D = new RefActionInvokerWithReadOnlyMemory2D<TItem, TAction>(batchHeight, memory, in action);
				if (num2 == 1)
				{
					refActionInvokerWithReadOnlyMemory2D.Invoke(0);
					return;
				}
				Parallel.For(0, num2, new ParallelOptions
				{
					MaxDegreeOfParallelism = num2
				}, ((RefActionInvokerWithReadOnlyMemory2D<TItem, TAction>)refActionInvokerWithReadOnlyMemory2D).Invoke);
			}
		}

		private static void ThrowArgumentOutOfRangeExceptionForInvalidMinimumActionsPerThread()
		{
			throw new ArgumentOutOfRangeException("minimumActionsPerThread", "Each thread needs to perform at least one action");
		}

		private static void ThrowArgumentOutOfRangeExceptionForStartGreaterThanEnd()
		{
			throw new ArgumentOutOfRangeException("start", "The start parameter must be less than or equal to end");
		}

		private static void ThrowArgumentExceptionForRangeIndexFromEnd(string name)
		{
			throw new ArgumentException("The bounds of the range can't start from an end", name);
		}

		private static void ThrowArgumentOutOfRangeExceptionForTopGreaterThanBottom()
		{
			throw new ArgumentOutOfRangeException("top", "The top parameter must be less than or equal to bottom");
		}

		private static void ThrowArgumentOutOfRangeExceptionForLeftGreaterThanRight()
		{
			throw new ArgumentOutOfRangeException("left", "The left parameter must be less than or equal to right");
		}
	}
}
