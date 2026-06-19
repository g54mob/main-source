using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using UnityEngine;

[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(EndPredictedSimulationSystemGroup))]
[BurstCompile]
public struct UpdateSubMapClientSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[BurstCompile]
	private struct FilterJob : IJob
	{
		public Entity tileUpdateSingleton;

		public BufferLookup<TileUpdateBuffer> tileUpdateBufferLookup;

		public NativeList<TileUpdateBuffer> addList;

		public NativeList<TileUpdateBuffer> clearList;

		public NativeList<TileUpdateBuffer> removeList;

		public void Execute()
		{
			DynamicBuffer<TileUpdateBuffer> dynamicBuffer = tileUpdateBufferLookup[tileUpdateSingleton];
			NativeArray<TileUpdateBuffer> tileUpdates = dynamicBuffer.AsNativeArray();
			UpdateSubMapCommon.EnvironmentalDecorationUpdates(in tileUpdates, ref removeList, ref addList);
			UpdateSubMapCommon.FilterUpdates(in tileUpdates, ref clearList, ref removeList, ref addList);
			dynamicBuffer.Clear();
		}
	}

	[BurstCompile]
	private struct ApplyJob : IJob
	{
		[ReadOnly]
		public NativeParallelHashMap<ulong, int> singleBitIndexLookup;

		[ReadOnly]
		public NativeList<TileUpdateBuffer> addList;

		[ReadOnly]
		public NativeList<TileUpdateBuffer> clearList;

		[ReadOnly]
		public NativeList<TileUpdateBuffer> removeList;

		public NativeList<ClientSubMapLayerCD> clientSubMapLayerCDArray;

		public NativeList<PlayerGhost> localPlayerGhost;

		public bool isPlaying;

		public void Execute()
		{
			int2 viewPoint = ((localPlayerGhost.Length > 0) ? localPlayerGhost[0].cameraPosition.RoundToInt2() : int2.zero);
			ApplyClear(clientSubMapLayerCDArray, in clearList);
			ApplyRemove(clientSubMapLayerCDArray, in removeList);
			ApplyAdd(clientSubMapLayerCDArray, in addList, isPlaying, viewPoint);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool IsInsideView(in ClientSubMapLayerCD clientSubMapLayerCD, int2 pos, out int2 subMapPos)
		{
			subMapPos = default(int2);
			int2 int5 = new int2(64, 48);
			int2 int6 = clientSubMapLayerCD.data.viewPoint - int5 / 2;
			int2 int7 = pos - int6;
			ulong num = (ulong)(1L << int7.x);
			if (num == 0L)
			{
				return false;
			}
			subMapPos.x = singleBitIndexLookup[num];
			subMapPos.y = int7.y;
			if (math.all(subMapPos >= 0))
			{
				return math.all(subMapPos < int5);
			}
			return false;
		}

		private unsafe void ApplyClear(NativeArray<ClientSubMapLayerCD> layers, in NativeList<TileUpdateBuffer> tileUpdates)
		{
			for (int i = 0; i < tileUpdates.Length; i++)
			{
				int2 position = tileUpdates[i].position;
				for (int num = layers.Length - 1; num >= 0; num--)
				{
					ref ClientSubMapLayerCD reference = ref UnsafeUtility.ArrayElementAsRef<ClientSubMapLayerCD>(layers.GetUnsafePtr(), num);
					if (IsInsideView(in reference, position, out var subMapPos) && !reference.layer.tileType.IsIgnoreClear())
					{
						reference.data.Unset(subMapPos);
					}
				}
			}
		}

		private unsafe void ApplyRemove(NativeArray<ClientSubMapLayerCD> layers, in NativeList<TileUpdateBuffer> tileUpdates)
		{
			for (int i = 0; i < tileUpdates.Length; i++)
			{
				int2 position = tileUpdates[i].position;
				for (int num = layers.Length - 1; num >= 0; num--)
				{
					ref ClientSubMapLayerCD reference = ref UnsafeUtility.ArrayElementAsRef<ClientSubMapLayerCD>(layers.GetUnsafePtr(), num);
					if (IsInsideView(in reference, position, out var subMapPos) && reference.layer.tileType == tileUpdates[i].tile.tileType)
					{
						reference.data.Unset(subMapPos);
					}
				}
			}
		}

		private unsafe void ApplyAdd(NativeList<ClientSubMapLayerCD> layers, in NativeList<TileUpdateBuffer> tileUpdates, bool isPlaying, int2 viewPoint)
		{
			NativeList<TileType> neededTile = new NativeList<TileType>(4, Allocator.Temp);
			NativeList<TileType> invalidTile = new NativeList<TileType>(4, Allocator.Temp);
			for (int num = tileUpdates.Length - 1; num >= 0; num--)
			{
				if (tileUpdates[num].tile.tileType != TileType.none)
				{
					int2 position = tileUpdates[num].position;
					neededTile.Clear();
					tileUpdates[num].tile.tileType.GetNeededTile(ref neededTile);
					invalidTile.Clear();
					tileUpdates[num].tile.tileType.GetInvalidTile(ref invalidTile);
					int num2 = -1;
					int2 subMapPos = int2.zero;
					bool flag = neededTile.Length == 0;
					bool flag2 = false;
					for (int num3 = layers.Length - 1; num3 >= 0; num3--)
					{
						ref ClientSubMapLayerCD reference = ref UnsafeUtility.ArrayElementAsRef<ClientSubMapLayerCD>(layers.GetUnsafePtr(), num3);
						if (IsInsideView(in reference, position, out var subMapPos2))
						{
							if (reference.layer.Equals(tileUpdates[num].tile))
							{
								num2 = num3;
								subMapPos = subMapPos2;
							}
							for (int i = 0; i < neededTile.Length; i++)
							{
								if (reference.layer.tileType == neededTile[i] && reference.data.GetByRef(subMapPos2))
								{
									flag = true;
								}
							}
							for (int j = 0; j < invalidTile.Length; j++)
							{
								if (reference.layer.tileType == invalidTile[j] && reference.data.GetByRef(subMapPos2))
								{
									flag2 = true;
								}
							}
						}
					}
					if (!isPlaying || (flag && !flag2))
					{
						if (num2 == -1)
						{
							ClientSubMapLayerCD value = new ClientSubMapLayerCD
							{
								data = 
								{
									viewPoint = viewPoint
								},
								layer = tileUpdates[num].tile
							};
							if (IsInsideView(in value, position, out subMapPos))
							{
								value.data.Set(subMapPos);
								layers.Add(in value);
							}
						}
						else
						{
							UnsafeUtility.ArrayElementAsRef<ClientSubMapLayerCD>(layers.GetUnsafePtr(), num2).data.Set(subMapPos);
						}
					}
				}
			}
		}
	}

	[BurstCompile]
	private struct UpdateJob : IJob
	{
		public NativeList<Entity> existingClientSubMapLayerEntities;

		public NativeList<ClientSubMapLayerCD> clientSubMapLayerCDList;

		public ComponentLookup<ClientSubMapLayerCD> clientSubMapLayerCDLookup;

		public EntityCommandBuffer ecb;

		public Entity clientSubmapPrefabEntity;

		public bool isFirstTimeFullyPredictingTick;

		public void Execute()
		{
			for (int i = 0; i < existingClientSubMapLayerEntities.Length; i++)
			{
				clientSubMapLayerCDLookup[existingClientSubMapLayerEntities[i]] = clientSubMapLayerCDList[i];
			}
			if (isFirstTimeFullyPredictingTick)
			{
				for (int j = existingClientSubMapLayerEntities.Length; j < clientSubMapLayerCDList.Length; j++)
				{
					Entity e = ecb.Instantiate(clientSubmapPrefabEntity);
					ecb.SetComponent(e, clientSubMapLayerCDList[j]);
				}
			}
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public ComponentLookup<ClientSubMapLayerCD> __ClientSubMapLayerCD_RO_ComponentLookup;

		public BufferLookup<TileUpdateBuffer> __TileUpdateBuffer_RW_BufferLookup;

		public ComponentLookup<ClientSubMapLayerCD> __ClientSubMapLayerCD_RW_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__ClientSubMapLayerCD_RO_ComponentLookup = state.GetComponentLookup<ClientSubMapLayerCD>(isReadOnly: true);
			__TileUpdateBuffer_RW_BufferLookup = state.GetBufferLookup<TileUpdateBuffer>();
			__ClientSubMapLayerCD_RW_ComponentLookup = state.GetComponentLookup<ClientSubMapLayerCD>();
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_0000450D_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_0000450D_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_0000450D_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
			__codegen__OnCreate_0024BurstManaged(self, state);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_0000450E_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_0000450E_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_0000450E_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnDestroy_0000450F_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnDestroy_0000450F_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnDestroy_0000450F_0024PostfixBurstDelegate>(__codegen__OnDestroy).Value;
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
			__codegen__OnDestroy_0024BurstManaged(self, state);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnStartRunning_00004510_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_00004510_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_00004510_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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
			__codegen__OnStartRunning_0024BurstManaged(self, state);
		}
	}

	private Entity _clientSubmapPrefabEntity;

	private EntityQuery _clientSubMapLayerQuery;

	private NativeParallelHashMap<ulong, int> _singleBitIndexLookup;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1502957281_0;

	private EntityQuery __query_1502957281_1;

	private EntityQuery __query_1502957281_2;

	private EntityQuery __query_1502957281_3;

	private EntityQuery __query_1502957281_4;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		_clientSubMapLayerQuery = state.GetEntityQuery(ComponentType.ReadWrite<ClientSubMapLayerCD>());
		state.RequireForUpdate(_clientSubMapLayerQuery);
		state.RequireForUpdate(state.GetEntityQuery(ComponentType.ReadWrite<TileUpdateBuffer>()));
		state.RequireForUpdate<PugPrefabBuffer>();
		_singleBitIndexLookup = new NativeParallelHashMap<ulong, int>(64, Allocator.Persistent);
		for (int i = 0; i < 64; i++)
		{
			ulong key = (ulong)(1L << i);
			_singleBitIndexLookup.Add(key, i);
		}
		if (state.GetEntityQuery(ComponentType.ReadOnly<TileUpdateBuffer>()).IsEmpty)
		{
			Entity entity = state.EntityManager.CreateEntity();
			state.EntityManager.AddBuffer<TileUpdateBuffer>(entity);
		}
	}

	[BurstCompile]
	public void OnDestroy(ref SystemState state)
	{
		_singleBitIndexLookup.Dispose();
	}

	[BurstCompile]
	public void OnStartRunning(ref SystemState state)
	{
		if (_clientSubmapPrefabEntity != Entity.Null)
		{
			return;
		}
		DynamicBuffer<PugPrefabBuffer> singletonBuffer = __query_1502957281_1.GetSingletonBuffer<PugPrefabBuffer>();
		for (int i = 0; i < singletonBuffer.Length; i++)
		{
			if (InternalCompilerInterface.HasComponentAfterCompletingDependency(ref __TypeHandle.__ClientSubMapLayerCD_RO_ComponentLookup, ref state, singletonBuffer[i].Value))
			{
				_clientSubmapPrefabEntity = singletonBuffer[i].Value;
				break;
			}
		}
	}

	public void OnStopRunning(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		Entity singletonEntity = __query_1502957281_2.GetSingletonEntity();
		NativeList<TileUpdateBuffer> addList = new NativeList<TileUpdateBuffer>(4096, state.WorldUpdateAllocator);
		NativeList<TileUpdateBuffer> clearList = new NativeList<TileUpdateBuffer>(128, state.WorldUpdateAllocator);
		NativeList<TileUpdateBuffer> removeList = new NativeList<TileUpdateBuffer>(128, state.WorldUpdateAllocator);
		bool isPlaying = Application.isPlaying;
		JobHandle job = IJobExtensions.Schedule(new FilterJob
		{
			tileUpdateSingleton = singletonEntity,
			tileUpdateBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__TileUpdateBuffer_RW_BufferLookup, ref state),
			addList = addList,
			clearList = clearList,
			removeList = removeList
		}, state.Dependency);
		JobHandle outJobHandle;
		NativeList<Entity> existingClientSubMapLayerEntities = _clientSubMapLayerQuery.ToEntityListAsync(state.WorldUpdateAllocator, state.Dependency, out outJobHandle);
		JobHandle outJobHandle2;
		NativeList<ClientSubMapLayerCD> nativeList = _clientSubMapLayerQuery.ToComponentDataListAsync<ClientSubMapLayerCD>(state.WorldUpdateAllocator, state.Dependency, out outJobHandle2);
		JobHandle outJobHandle3;
		NativeList<PlayerGhost> localPlayerGhost = __query_1502957281_0.ToComponentDataListAsync<PlayerGhost>(state.WorldUpdateAllocator, state.Dependency, out outJobHandle3);
		state.Dependency = JobHandle.CombineDependencies(JobHandle.CombineDependencies(job, outJobHandle, outJobHandle2), outJobHandle3);
		state.Dependency = IJobExtensions.Schedule(new ApplyJob
		{
			addList = addList,
			clearList = clearList,
			removeList = removeList,
			clientSubMapLayerCDArray = nativeList,
			localPlayerGhost = localPlayerGhost,
			isPlaying = isPlaying,
			singleBitIndexLookup = _singleBitIndexLookup
		}, state.Dependency);
		__query_1502957281_3.TryGetSingleton<NetworkTime>(out var value);
		EntityCommandBuffer ecb = __query_1502957281_4.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		state.Dependency = IJobExtensions.Schedule(new UpdateJob
		{
			existingClientSubMapLayerEntities = existingClientSubMapLayerEntities,
			clientSubMapLayerCDList = nativeList,
			clientSubMapLayerCDLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ClientSubMapLayerCD_RW_ComponentLookup, ref state),
			clientSubmapPrefabEntity = _clientSubmapPrefabEntity,
			isFirstTimeFullyPredictingTick = value.IsFirstTimeFullyPredictingTick,
			ecb = ecb
		}, state.Dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PlayerGhost, GhostOwnerIsLocal>();
		__query_1502957281_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<PugPrefabBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1502957281_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileUpdateBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1502957281_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1502957281_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1502957281_4 = entityQueryBuilder2.Build(ref state);
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
	internal static void __codegen__OnCreate(IntPtr self, IntPtr state)
	{
		__codegen__OnCreate_0000450D_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_0000450E_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnDestroy(IntPtr self, IntPtr state)
	{
		__codegen__OnDestroy_0000450F_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_00004510_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		((UpdateSubMapClientSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((UpdateSubMapClientSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((UpdateSubMapClientSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((UpdateSubMapClientSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnDestroy_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((UpdateSubMapClientSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((UpdateSubMapClientSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}
}
