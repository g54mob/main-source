using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using UnityEngine;

[BurstCompile]
[DisableAutoCreation]
public struct FixDuplicateSubMapConvertSystem : ISystem, ISystemCompilerGenerated
{
	private struct SubMapToCleanUp
	{
		public Entity Entity;

		public Entity MainSubMap;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_1094371526_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr Entity_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRO<SubMapSerializedCD>> Get(int index)
			{
				return new QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRO<SubMapSerializedCD>>(InternalCompilerInterface.UnsafeGetUncheckedRefRO<SubMapSerializedCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<SubMapSerializedCD> item1_ComponentTypeHandle_RO;

			private EntityTypeHandle Entity_TypeHandle;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<SubMapSerializedCD>(isReadOnly: true);
				Entity_TypeHandle = systemState.GetEntityTypeHandle();
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO.Update(ref systemState);
				Entity_TypeHandle.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RO),
					Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
				};
			}
		}

		public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRO<SubMapSerializedCD>>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRO<SubMapSerializedCD>> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRO<SubMapSerializedCD>();
		}
	}

	private struct TypeHandle
	{
		public IFE_1094371526_0.TypeHandle __IFE_1094371526_0_TypeHandle;

		public BufferLookup<SubMapLayerSerializedBuffer> __SubMapLayerSerializedBuffer_RW_BufferLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_1094371526_0_TypeHandle = new IFE_1094371526_0.TypeHandle(ref state);
			__SubMapLayerSerializedBuffer_RW_BufferLookup = state.GetBufferLookup<SubMapLayerSerializedBuffer>();
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_000034AB_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_000034AB_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_000034AB_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	private EntityQuery __query_1094371526_0;

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		using NativeHashMap<int2, Entity> nativeHashMap = new NativeHashMap<int2, Entity>(1000, Allocator.Temp);
		NativeList<SubMapToCleanUp> nativeList = new NativeList<SubMapToCleanUp>(0, Allocator.Temp);
		try
		{
			foreach (var (uncheckedRefRO2, entity2) in IFE_1094371526_0.Query(__query_1094371526_0, __TypeHandle.__IFE_1094371526_0_TypeHandle, ref state))
			{
				if (nativeHashMap.ContainsKey(uncheckedRefRO2.ValueRO.Position))
				{
					SubMapToCleanUp value = new SubMapToCleanUp
					{
						Entity = entity2,
						MainSubMap = nativeHashMap[uncheckedRefRO2.ValueRO.Position]
					};
					nativeList.Add(in value);
				}
				else
				{
					nativeHashMap.Add(uncheckedRefRO2.ValueRO.Position, entity2);
				}
			}
			if (nativeList.Length == 0)
			{
				return;
			}
			Debug.LogError("found multiple submaps at same position; merging");
			BufferLookup<SubMapLayerSerializedBuffer> bufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SubMapLayerSerializedBuffer_RW_BufferLookup, ref state);
			foreach (SubMapToCleanUp item in nativeList)
			{
				if (!bufferLookup.HasBuffer(item.Entity) || !bufferLookup.HasBuffer(item.MainSubMap))
				{
					Debug.LogError("missing submap layer buffer");
					continue;
				}
				DynamicBuffer<SubMapLayer> dynamicBuffer = bufferLookup[item.Entity].Reinterpret<SubMapLayer>();
				DynamicBuffer<SubMapLayer> dynamicBuffer2 = bufferLookup[item.MainSubMap].Reinterpret<SubMapLayer>();
				for (int i = 0; i < dynamicBuffer.Length; i++)
				{
					ref SubMapLayer reference = ref dynamicBuffer.ElementAt(i);
					int j;
					for (j = 0; j < dynamicBuffer2.Length; j++)
					{
						if (reference.layer.Equals(dynamicBuffer2[j].layer))
						{
							dynamicBuffer2[j] = dynamicBuffer2[j].Merge(reference);
							break;
						}
					}
					if (j == dynamicBuffer2.Length)
					{
						dynamicBuffer2.Add(reference);
						dynamicBuffer2 = bufferLookup[item.MainSubMap].Reinterpret<SubMapLayer>();
					}
				}
			}
			foreach (SubMapToCleanUp item2 in nativeList)
			{
				state.EntityManager.DestroyEntity(item2.Entity);
			}
		}
		finally
		{
			((IDisposable)nativeList/*cast due to .constrained prefix*/).Dispose();
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		__query_1094371526_0 = entityQueryBuilder.WithAll<SubMapSerializedCD>().Build(ref state);
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
		__codegen__OnUpdate_000034AB_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((FixDuplicateSubMapConvertSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((FixDuplicateSubMapConvertSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
