using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Aggro.Core
{
	[NativeContainer]
	[NativeContainerSupportsMinMaxWriteRestriction]
	public struct JobComponentQuery<T> : IDisposable where T : unmanaged, IEntityJobComponent
	{
		internal struct Entry
		{
			public int StoreIndex;

			public int ItemIndex;
		}

		internal struct Store
		{
			public UnsafeList<EntityKey> Keys;

			public UnsafeList<T> Components;
		}

		public readonly int TypeIndex;

		public readonly EntityQueryFlags flags;

		private readonly Allocator _allocator;

		[NativeDisableUnsafePtrRestriction]
		internal unsafe UnsafeList<Entry>* Entries;

		[NativeDisableUnsafePtrRestriction]
		internal unsafe UnsafeList<Store>* Stores;

		internal int m_Length;

		public unsafe bool IsCreated
		{
			get
			{
				if (Entries != null)
				{
					return Entries->IsCreated;
				}
				return false;
			}
		}

		public bool IsEmpty
		{
			get
			{
				if (IsCreated)
				{
					return m_Length == 0;
				}
				return true;
			}
		}

		public unsafe int Count
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return Entries->Length;
			}
		}

		internal unsafe JobComponentQuery(EntityQueryFlags flags, int typeIndex, int capacity, Allocator allocator)
		{
			this.flags = flags;
			TypeIndex = typeIndex;
			Entries = (UnsafeList<Entry>*)UnsafeUtility.Malloc(UnsafeUtility.SizeOf<UnsafeList<Entry>>(), UnsafeUtility.AlignOf<UnsafeList<Entry>>(), allocator);
			Stores = (UnsafeList<Store>*)UnsafeUtility.Malloc(UnsafeUtility.SizeOf<UnsafeList<Store>>(), UnsafeUtility.AlignOf<UnsafeList<Store>>(), allocator);
			*Entries = new UnsafeList<Entry>(capacity, allocator);
			*Stores = new UnsafeList<Store>(capacity, allocator);
			_allocator = allocator;
			m_Length = 0;
		}

		public void Run(EntityManager entityManager)
		{
			entityManager.RunQuery(ref this);
		}

		public void Run(EntityManager entityManager, EntityContext context)
		{
			entityManager.RunQuery(ref this, context);
		}

		public void Run(EntityManager entityManager, List<EntityContext> contexts)
		{
			entityManager.RunQuery(ref this, contexts);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe EntityKey GetEntity(int index)
		{
			Entry entry = (*Entries)[index];
			return (*Stores)[entry.StoreIndex].Keys[entry.ItemIndex];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe T GetComponent(int index)
		{
			Entry entry = (*Entries)[index];
			return (*Stores)[entry.StoreIndex].Components[entry.ItemIndex];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void SetComponent(int index, T comp)
		{
			Entry entry = (*Entries)[index];
			Store store = (*Stores)[entry.StoreIndex];
			store.Components[entry.ItemIndex] = comp;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe ref T ComponentAt(int index)
		{
			Entry entry = (*Entries)[index];
			return ref (*Stores)[entry.StoreIndex].Components.ElementAt(entry.ItemIndex);
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckIndexRange(int index)
		{
		}

		public unsafe void Dispose()
		{
			if (IsCreated)
			{
				Entries->Dispose();
				Stores->Dispose();
				UnsafeUtility.Free(Entries, _allocator);
				UnsafeUtility.Free(Stores, _allocator);
				Entries = null;
				Stores = null;
			}
		}
	}
}
