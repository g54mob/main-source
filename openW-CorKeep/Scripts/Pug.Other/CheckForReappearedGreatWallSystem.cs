using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PugTilemap;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using UnityEngine;

[BurstCompile]
[DisableAutoCreation]
public struct CheckForReappearedGreatWallSystem : ISystem, ISystemCompilerGenerated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_1600541817_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public BufferAccessor<ContainedObjectsSerializedBuffer> item2_BufferAccessor;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public (InternalCompilerInterface.UncheckedRefRO<ObjectDataSerializedCD>, DynamicBuffer<ContainedObjectsSerializedBuffer>) Get(int index)
			{
				return (InternalCompilerInterface.UnsafeGetUncheckedRefRO<ObjectDataSerializedCD>(item1_IntPtr, index), item2_BufferAccessor[index]);
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<ObjectDataSerializedCD> item1_ComponentTypeHandle_RO;

			private BufferTypeHandle<ContainedObjectsSerializedBuffer> item2_BufferTypeHandle_RW;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<ObjectDataSerializedCD>(isReadOnly: true);
				item2_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<ContainedObjectsSerializedBuffer>();
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO.Update(ref systemState);
				item2_BufferTypeHandle_RW.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RO),
					item2_BufferAccessor = archetypeChunk.GetBufferAccessor(ref item2_BufferTypeHandle_RW)
				};
			}
		}

		public struct Enumerator : IEnumerator<(InternalCompilerInterface.UncheckedRefRO<ObjectDataSerializedCD>, DynamicBuffer<ContainedObjectsSerializedBuffer>)>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public (InternalCompilerInterface.UncheckedRefRO<ObjectDataSerializedCD>, DynamicBuffer<ContainedObjectsSerializedBuffer>) Current => _resolvedChunk.Get(_currentEntityIndex);

			object IEnumerator.Current
			{
				get
				{
					throw new NotImplementedException();
				}
			}

			public Enumerator(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
			{
				if (!entityQuery.IsEmptyIgnoreFilter)
				{
					CompleteDependencies(ref state);
					typeHandle.Update(ref state);
				}
				_entityQueryEnumerator = new InternalEntityQueryEnumerator(entityQuery);
				_currentEntityIndex = -1;
				_endEntityIndex = -1;
				_typeHandle = typeHandle;
				_resolvedChunk = default(ResolvedChunk);
			}

			public void Dispose()
			{
				_entityQueryEnumerator.Dispose();
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool MoveNext()
			{
				_currentEntityIndex++;
				if (_currentEntityIndex >= _endEntityIndex)
				{
					if (_entityQueryEnumerator.MoveNextEntityRange(out var movedToNewChunk, out var chunk, out var entityStartIndex, out var entityEndIndex))
					{
						if (movedToNewChunk)
						{
							_resolvedChunk = _typeHandle.Resolve(chunk);
						}
						_currentEntityIndex = entityStartIndex;
						_endEntityIndex = entityEndIndex;
						return true;
					}
					return false;
				}
				return true;
			}

			public Enumerator GetEnumerator()
			{
				return this;
			}

			public void Reset()
			{
				throw new NotImplementedException();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Enumerator Query(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
		{
			return new Enumerator(entityQuery, typeHandle, ref state);
		}

		public static void CompleteDependencies(ref SystemState state)
		{
			state.EntityManager.CompleteDependencyBeforeRO<ObjectDataSerializedCD>();
			state.EntityManager.CompleteDependencyBeforeRW<ContainedObjectsSerializedBuffer>();
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_1600541817_1
	{
		public struct ResolvedChunk
		{
			public BufferAccessor<SubMapLayerSerializedBuffer> item1_BufferAccessor;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public DynamicBuffer<SubMapLayerSerializedBuffer> Get(int index)
			{
				return item1_BufferAccessor[index];
			}
		}

		public struct TypeHandle
		{
			private BufferTypeHandle<SubMapLayerSerializedBuffer> item1_BufferTypeHandle_RW;

			public TypeHandle(ref SystemState systemState)
			{
				item1_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<SubMapLayerSerializedBuffer>();
			}

			public void Update(ref SystemState systemState)
			{
				item1_BufferTypeHandle_RW.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_BufferAccessor = archetypeChunk.GetBufferAccessor(ref item1_BufferTypeHandle_RW)
				};
			}
		}

		public struct Enumerator : IEnumerator<DynamicBuffer<SubMapLayerSerializedBuffer>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public DynamicBuffer<SubMapLayerSerializedBuffer> Current => _resolvedChunk.Get(_currentEntityIndex);

			object IEnumerator.Current
			{
				get
				{
					throw new NotImplementedException();
				}
			}

			public Enumerator(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
			{
				if (!entityQuery.IsEmptyIgnoreFilter)
				{
					CompleteDependencies(ref state);
					typeHandle.Update(ref state);
				}
				_entityQueryEnumerator = new InternalEntityQueryEnumerator(entityQuery);
				_currentEntityIndex = -1;
				_endEntityIndex = -1;
				_typeHandle = typeHandle;
				_resolvedChunk = default(ResolvedChunk);
			}

			public void Dispose()
			{
				_entityQueryEnumerator.Dispose();
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool MoveNext()
			{
				_currentEntityIndex++;
				if (_currentEntityIndex >= _endEntityIndex)
				{
					if (_entityQueryEnumerator.MoveNextEntityRange(out var movedToNewChunk, out var chunk, out var entityStartIndex, out var entityEndIndex))
					{
						if (movedToNewChunk)
						{
							_resolvedChunk = _typeHandle.Resolve(chunk);
						}
						_currentEntityIndex = entityStartIndex;
						_endEntityIndex = entityEndIndex;
						return true;
					}
					return false;
				}
				return true;
			}

			public Enumerator GetEnumerator()
			{
				return this;
			}

			public void Reset()
			{
				throw new NotImplementedException();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Enumerator Query(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
		{
			return new Enumerator(entityQuery, typeHandle, ref state);
		}

		public static void CompleteDependencies(ref SystemState state)
		{
			state.EntityManager.CompleteDependencyBeforeRW<SubMapLayerSerializedBuffer>();
		}
	}

	private struct TypeHandle
	{
		public IFE_1600541817_0.TypeHandle __IFE_1600541817_0_TypeHandle;

		public IFE_1600541817_1.TypeHandle __IFE_1600541817_1_TypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_1600541817_0_TypeHandle = new IFE_1600541817_0.TypeHandle(ref state);
			__IFE_1600541817_1_TypeHandle = new IFE_1600541817_1.TypeHandle(ref state);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_000033AC_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_000033AC_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_000033AC_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(IntPtr self, IntPtr state)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
					return;
				}
			}
			__codegen__OnUpdate_0024BurstManaged(self, state);
		}
	}

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1600541817_0;

	private EntityQuery __query_1600541817_1;

	private EntityQuery __query_1600541817_2;

	private EntityQuery __query_1600541817_3;

	private EntityQuery __query_1600541817_4;

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		state.Enabled = false;
		if (__query_1600541817_2.TryGetSingleton<WorldVersionSerializedCD>(out var value) && value.Version >= 2)
		{
			return;
		}
		Debug.Log("Converting world to version 2; fixing great wall not being lowered");
		if (__query_1600541817_3.TryGetSingletonEntity<TheGreatWallHasBeenLoweredCD>(out var value2))
		{
			state.EntityManager.RemoveComponent<TheGreatWallHasBeenLoweredCD>(value2);
			state.EntityManager.AddComponentData(value2, new TheGreatWallStatusSerializedCD
			{
				HasBeenLowered = true
			});
			Debug.Log("Replaced TheGreatWallHasBeenLoweredCD with serialized counterpart, no further actions needed");
			return;
		}
		if (__query_1600541817_4.HasSingleton<TheGreatWallStatusSerializedCD>())
		{
			Debug.LogWarning("TheGreatWallStatusSerializedCD was unexpectedly found, no further actions");
			return;
		}
		int num = 0;
		foreach (var item3 in IFE_1600541817_0.Query(__query_1600541817_0, __TypeHandle.__IFE_1600541817_0_TypeHandle, ref state))
		{
			InternalCompilerInterface.UncheckedRefRO<ObjectDataSerializedCD> item = item3.Item1;
			DynamicBuffer<ContainedObjectsSerializedBuffer> item2 = item3.Item2;
			ObjectID objectID = item.ValueRO.ObjectID;
			if (objectID == ObjectID.SlimeBossStatue || objectID == ObjectID.LarvaBossStatue || objectID == ObjectID.LarvaHiveBossStatue)
			{
				if (item2.Length < 1)
				{
					Debug.LogWarning("found boss statue without inventory");
				}
				else if (item2[0].ObjectData.ObjectID != ObjectID.None)
				{
					num++;
				}
			}
		}
		bool flag = num >= 3;
		if (num < 3)
		{
			Debug.Log($"Do not remove great wall: only {num}/3 boss statues are active");
		}
		if (flag)
		{
			int num2 = 0;
			foreach (DynamicBuffer<SubMapLayerSerializedBuffer> item4 in IFE_1600541817_1.Query(__query_1600541817_1, __TypeHandle.__IFE_1600541817_1_TypeHandle, ref state))
			{
				for (int num3 = item4.Length - 1; num3 >= 0; num3--)
				{
					if (item4[num3].data.layer.tileType == TileType.greatWall)
					{
						item4.RemoveAtSwapBack(num3);
						num2++;
					}
				}
			}
			Debug.Log($"Removed {num2} great wall layers");
		}
		Entity entity = state.EntityManager.CreateEntity();
		state.EntityManager.AddComponentData(entity, new TheGreatWallStatusSerializedCD
		{
			HasBeenLowered = flag
		});
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ObjectDataSerializedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ContainedObjectsSerializedBuffer>();
		__query_1600541817_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<SubMapLayerSerializedBuffer>();
		__query_1600541817_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldVersionSerializedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1600541817_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TheGreatWallHasBeenLoweredCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1600541817_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TheGreatWallStatusSerializedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1600541817_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	public void OnCreateForCompiler(ref SystemState state)
	{
		__AssignQueries(ref state);
		__TypeHandle.__AssignHandles(ref state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_000033AC_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((CheckForReappearedGreatWallSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((CheckForReappearedGreatWallSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
