using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Pug.UnityExtensions
{
	[GenerateTestsForBurstCompatibility]
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(NativePriorityQueueDebugView<>))]
	public struct NativePriorityQueue<T> : IDisposable where T : unmanaged
	{
		internal struct Node
		{
			public float Priority { get; set; }

			public T Value { get; set; }
		}

		private struct SharedData
		{
			[NativeDisableUnsafePtrRestriction]
			public unsafe Node* NodeBuffer;

			public int Count { get; set; }

			public int Capacity { get; set; }
		}

		[NativeDisableUnsafePtrRestriction]
		private unsafe SharedData* _sharedData;

		private readonly AllocatorManager.AllocatorHandle _allocator;

		private static readonly int rootNodeIndex = 1;

		public unsafe bool IsCreated => _sharedData != null;

		public bool IsEmpty => Count == 0;

		public int Count => CountInternal;

		public int Capacity => CapacityInternal;

		public T First => this[rootNodeIndex].Value;

		private unsafe int CountInternal
		{
			get
			{
				return _sharedData->Count;
			}
			set
			{
				_sharedData->Count = value;
			}
		}

		private unsafe int CapacityInternal
		{
			get
			{
				return _sharedData->Capacity;
			}
			set
			{
				_sharedData->Capacity = value;
			}
		}

		private unsafe Node this[int index]
		{
			get
			{
				return _sharedData->NodeBuffer[index];
			}
			set
			{
				_sharedData->NodeBuffer[index] = value;
			}
		}

		public unsafe NativePriorityQueue(int initialCapacity, AllocatorManager.AllocatorHandle allocator)
		{
			_allocator = allocator;
			_sharedData = AllocatorManager.Allocate<SharedData>(allocator);
			_sharedData->Count = 0;
			_sharedData->Capacity = initialCapacity;
			_sharedData->NodeBuffer = AllocatorManager.Allocate<Node>(allocator, initialCapacity + 1);
		}

		public unsafe void Dispose()
		{
			AllocatorManager.Free(_allocator, _sharedData->NodeBuffer, CapacityInternal + 1);
			_sharedData->NodeBuffer = null;
			AllocatorManager.Free(_allocator, _sharedData, 2);
			_sharedData = null;
		}

		public unsafe void Resize(int newCapacity)
		{
			Node* ptr = AllocatorManager.Allocate<Node>(_allocator, newCapacity + 1);
			int num = Math.Min(newCapacity, CountInternal);
			UnsafeUtility.MemCpy(ptr, _sharedData->NodeBuffer, UnsafeUtility.SizeOf<Node>() * (num + 1));
			AllocatorManager.Free(_allocator, _sharedData->NodeBuffer, CapacityInternal + 1);
			_sharedData->NodeBuffer = ptr;
			CapacityInternal = newCapacity;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Clear()
		{
			CountInternal = 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Enqueue(T value, float priority)
		{
			if (CountInternal == CapacityInternal)
			{
				Resize(CapacityInternal * 2);
			}
			int index = ++CountInternal;
			this[index] = new Node
			{
				Priority = priority,
				Value = value
			};
			CascadeUp(index);
		}

		public bool TryDequeue(out T value, out float priority)
		{
			if (CountInternal <= 0)
			{
				value = default(T);
				priority = 0f;
				return false;
			}
			value = Dequeue(out priority);
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T Dequeue(out float priority)
		{
			Node node = this[rootNodeIndex];
			if (CountInternal == 1)
			{
				CountInternal = 0;
				priority = node.Priority;
				return node.Value;
			}
			this[rootNodeIndex] = this[CountInternal];
			int countInternal = CountInternal - 1;
			CountInternal = countInternal;
			CascadeDown(rootNodeIndex);
			priority = node.Priority;
			return node.Value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CascadeUp(int index)
		{
			if (IsRoot(index))
			{
				return;
			}
			Node lower = this[index];
			Node higher = this[ParentIndex(index)];
			if (HasHigherOrEqualPriority(in higher, in lower))
			{
				return;
			}
			this[index] = higher;
			index = ParentIndex(index);
			while (!IsRoot(index))
			{
				higher = this[ParentIndex(index)];
				if (HasHigherOrEqualPriority(in higher, in lower))
				{
					break;
				}
				this[index] = higher;
				index = ParentIndex(index);
			}
			this[index] = lower;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CascadeDown(int index)
		{
			if (IsLeaf(index))
			{
				return;
			}
			Node lower = this[index];
			Node higher = this[LeftChildIndex(index)];
			if (HasHigherPriority(in higher, in lower))
			{
				if (!HasRightChild(index))
				{
					this[index] = higher;
					this[LeftChildIndex(index)] = lower;
					return;
				}
				Node lower2 = this[RightChildIndex(index)];
				if (HasHigherPriority(in higher, in lower2))
				{
					this[index] = higher;
					index = LeftChildIndex(index);
				}
				else
				{
					this[index] = lower2;
					index = RightChildIndex(index);
				}
			}
			else
			{
				if (!HasRightChild(index))
				{
					return;
				}
				Node higher2 = this[RightChildIndex(index)];
				if (!HasHigherPriority(in higher2, in lower))
				{
					return;
				}
				this[index] = higher2;
				index = RightChildIndex(index);
			}
			while (true)
			{
				if (!HasLeftChild(index))
				{
					this[index] = lower;
					return;
				}
				higher = this[LeftChildIndex(index)];
				if (HasHigherPriority(in higher, in lower))
				{
					if (!HasRightChild(index))
					{
						this[index] = higher;
						this[LeftChildIndex(index)] = lower;
						return;
					}
					Node lower3 = this[RightChildIndex(index)];
					if (HasHigherPriority(in higher, in lower3))
					{
						this[index] = higher;
						index = LeftChildIndex(index);
					}
					else
					{
						this[index] = lower3;
						index = RightChildIndex(index);
					}
				}
				else
				{
					if (!HasRightChild(index))
					{
						this[index] = lower;
						return;
					}
					Node higher3 = this[RightChildIndex(index)];
					if (!HasHigherPriority(in higher3, in lower))
					{
						break;
					}
					this[index] = higher3;
					index = RightChildIndex(index);
				}
			}
			this[index] = lower;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool HasHigherPriority(in Node higher, in Node lower)
		{
			return higher.Priority < lower.Priority;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool HasHigherOrEqualPriority(in Node higher, in Node lower)
		{
			return higher.Priority <= lower.Priority;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool HasLeftChild(int parentIndex)
		{
			return LeftChildIndex(parentIndex) <= CountInternal;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool HasRightChild(int parentIndex)
		{
			return RightChildIndex(parentIndex) <= CountInternal;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static int LeftChildIndex(int parentIndex)
		{
			return parentIndex << 1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static int RightChildIndex(int parentIndex)
		{
			return (parentIndex << 1) + 1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static int ParentIndex(int childIndex)
		{
			return childIndex >> 1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool IsRoot(int nodeIndex)
		{
			return nodeIndex == rootNodeIndex;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool IsLeaf(int nodeIndex)
		{
			return !HasLeftChild(nodeIndex);
		}

		internal Node[] ToArray()
		{
			Node[] array = new Node[CountInternal];
			for (int i = 0; i < CountInternal; i++)
			{
				array[i] = this[rootNodeIndex + i];
			}
			return array;
		}

		public bool IsValidQueue()
		{
			for (int i = rootNodeIndex; i <= CountInternal; i++)
			{
				_ = this[i];
				if (HasLeftChild(i) && HasHigherPriority(this[LeftChildIndex(i)], this[i]))
				{
					return false;
				}
				if (HasRightChild(i) && HasHigherPriority(this[RightChildIndex(i)], this[i]))
				{
					return false;
				}
			}
			return true;
		}

		[BurstDiscard]
		public static void CheckIsBlittable()
		{
			if (!UnsafeUtility.IsBlittable<T>())
			{
				throw new ArgumentException("Type must be blittable", "T");
			}
		}
	}
}
