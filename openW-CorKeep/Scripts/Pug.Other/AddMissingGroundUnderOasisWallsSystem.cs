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

[DisableAutoCreation]
[BurstCompile]
public struct AddMissingGroundUnderOasisWallsSystem : ISystem, ISystemCompilerGenerated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_1636442636_0
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
		public IFE_1636442636_0.TypeHandle __IFE_1636442636_0_TypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_1636442636_0_TypeHandle = new IFE_1636442636_0.TypeHandle(ref state);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_00003399_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00003399_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00003399_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	private EntityQuery __query_1636442636_0;

	private EntityQuery __query_1636442636_1;

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		state.Enabled = false;
		if (__query_1636442636_1.TryGetSingleton<WorldVersionSerializedCD>(out var value) && value.Version >= 7)
		{
			return;
		}
		Debug.Log($"World version is {value.Version} < 7, adding missing oasis ground under walls");
		foreach (DynamicBuffer<SubMapLayerSerializedBuffer> item in IFE_1636442636_0.Query(__query_1636442636_0, __TypeHandle.__IFE_1636442636_0_TypeHandle, ref state))
		{
			int num = FindLayerIndex(item, new TileCD
			{
				tileType = TileType.wall,
				tileset = 66
			});
			if (num < 0)
			{
				continue;
			}
			SubMapLayer data = item[num].data;
			SubMapLayer walkableTiles = GetWalkableTiles(item);
			SubMapLayer sl = data.Intersect(walkableTiles.Invert());
			if (sl.IsAnySet())
			{
				int num2 = FindLayerIndex(item, new TileCD
				{
					tileType = TileType.ground,
					tileset = 66
				});
				if (num2 < 0)
				{
					num2 = item.Length;
					item.Add(new SubMapLayerSerializedBuffer
					{
						data = new SubMapLayer
						{
							layer = new TileCD
							{
								tileType = TileType.ground,
								tileset = 66
							}
						}
					});
				}
				SubMapLayer data2 = item[num2].data;
				data2 = data2.Merge(sl);
				item.ElementAt(num2).data = data2;
			}
		}
	}

	private static int FindLayerIndex(DynamicBuffer<SubMapLayerSerializedBuffer> layers, TileCD layer)
	{
		for (int i = 0; i < layers.Length; i++)
		{
			if (layer.Equals(layers[i].data.layer))
			{
				return i;
			}
		}
		return -1;
	}

	private static SubMapLayer GetWalkableTiles(DynamicBuffer<SubMapLayerSerializedBuffer> layers)
	{
		SubMapLayer subMapLayer = default(SubMapLayer);
		foreach (SubMapLayerSerializedBuffer item in layers)
		{
			if (item.data.layer.tileType.IsWalkableTile())
			{
				subMapLayer = subMapLayer.Merge(item.data);
			}
		}
		return subMapLayer;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAllRW<SubMapLayerSerializedBuffer>();
		__query_1636442636_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldVersionSerializedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1636442636_1 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnUpdate_00003399_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((AddMissingGroundUnderOasisWallsSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((AddMissingGroundUnderOasisWallsSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
