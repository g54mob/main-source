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
	public struct EntityJobStoreQuery<T> : IDisposable where T : unmanaged, IEntityJobComponent
	{
		internal struct Store
		{
			public UnsafeList<EntityKey> Keys;

			public UnsafeList<T> Components;
		}

		public readonly int TypeIndex;

		public readonly EntityQueryFlags flags;

		private readonly Allocator _allocator;

		[NativeDisableUnsafePtrRestriction]
		internal unsafe UnsafeList<Store>* Stores;

		internal int m_Length;

		public unsafe bool IsCreated
		{
			get
			{
				if (Stores != null)
				{
					return Stores->IsCreated;
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

		public int Count
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return m_Length;
			}
		}

		internal unsafe EntityJobStoreQuery(EntityQueryFlags flags, int typeIndex, int capacity, Allocator allocator)
		{
			this.flags = flags;
			TypeIndex = typeIndex;
			Stores = (UnsafeList<Store>*)UnsafeUtility.Malloc(UnsafeUtility.SizeOf<UnsafeList<Store>>(), UnsafeUtility.AlignOf<UnsafeList<Store>>(), allocator);
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

		public unsafe NativeArray<EntityKey>.ReadOnly GetEntities(int storeIndex)
		{
			Store store = (*Stores)[storeIndex];
			return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<EntityKey>(store.Keys.Ptr, store.Keys.Length, Allocator.None).AsReadOnly();
		}

		public unsafe NativeArray<T> GetComponents(int storeIndex)
		{
			Store store = (*Stores)[storeIndex];
			return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<T>(store.Components.Ptr, store.Components.Length, Allocator.None);
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckIndexRange(int index)
		{
		}

		public unsafe void Dispose()
		{
			if (IsCreated)
			{
				Stores->Dispose();
				UnsafeUtility.Free(Stores, _allocator);
				Stores = null;
			}
		}
	}
}
