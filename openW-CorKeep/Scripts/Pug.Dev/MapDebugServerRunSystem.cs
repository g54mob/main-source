using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pug.UnityExtensions;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class MapDebugServerRunSystem : PugSimulationSystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct MapDebugServerRunSystem_25D5CCD7_LambdaJob_0_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_00000094_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_00000094_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00000094_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(ref EntityQuery query, IntPtr jobPtr)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref EntityQuery, IntPtr, void>)functionPointer)(ref query, jobPtr);
						return;
					}
				}
				RunWithoutJobSystem_0024BurstManaged(ref query, jobPtr);
			}
		}

		public EntityCommandBuffer ecb;

		public NativeReference<Entity> requesterLocal;

		public NativePriorityQueue<Entity> mapsToUpdateLocal;

		public NativeReference<int> totalMapsToUpdateLocal;

		public EntityQuery subMapQLocal;

		public Entity tileUpdateBufferEntity;

		public BufferLookup<TileUpdateBuffer> tileUpdateBufferLookup;

		public WorldInfoCD worldInfoLookup;

		public ComponentLookup<ConnectionAdminLevelCD> connectionAdminLookup;

		[ReadOnly]
		public EntityTypeHandle __eTypeHandle;

		public ComponentTypeHandle<RevealWholeMapRequest> __requestTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ReceiveRpcCommandRequest> __rpcRequestTypeHandle;

		[ReadOnly]
		public ComponentLookup<SubMapCD> __SubMapCD_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity e, [NoAlias] ref RevealWholeMapRequest request, [NoAlias] in ReceiveRpcCommandRequest rpcRequest)
		{
			int num = (connectionAdminLookup.HasComponent(rpcRequest.SourceConnection) ? connectionAdminLookup[rpcRequest.SourceConnection].adminPrivileges : 0);
			if (!worldInfoLookup.hostConsoleEnabled || num <= 0)
			{
				ecb.DestroyEntity(e);
				return;
			}
			if (request.generationRadius > 0)
			{
				DynamicBuffer<TileUpdateBuffer> dynamicBuffer = tileUpdateBufferLookup[tileUpdateBufferEntity];
				for (int i = 0; i <= request.generationRadius; i += 64)
				{
					for (int j = 0; j <= request.generationRadius; j += 64)
					{
						for (int k = -1; k <= 1; k += 2)
						{
							for (int l = -1; l <= 1; l += 2)
							{
								dynamicBuffer.Add(new TileUpdateBuffer
								{
									command = TileUpdateBuffer.Command.Add,
									position = request.playerPosition + new int2(i * k, j * l)
								});
							}
						}
					}
				}
				request.generationRadius = 0;
				return;
			}
			ecb.DestroyEntity(e);
			if (!mapsToUpdateLocal.IsEmpty && requesterLocal.Value != rpcRequest.SourceConnection)
			{
				return;
			}
			mapsToUpdateLocal.Clear();
			requesterLocal.Value = rpcRequest.SourceConnection;
			using NativeArray<Entity> nativeArray = subMapQLocal.ToEntityArray(Allocator.Temp);
			mapsToUpdateLocal.Resize(nativeArray.Length);
			foreach (Entity item in nativeArray)
			{
				float priority = math.length((__SubMapCD_ComponentLookup[item].index << 6) - request.playerPosition);
				mapsToUpdateLocal.Enqueue(item, priority);
			}
			totalMapsToUpdateLocal.Value = mapsToUpdateLocal.Count;
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __eTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __requestTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __rpcRequestTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RevealWholeMapRequest>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr3, i));
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int j = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
				{
					for (; j < nextRangeEnd; j++)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RevealWholeMapRequest>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr3, j));
					}
				}
				return;
			}
			ulong num = chunkEnabledMask.ULong0;
			int num2 = math.min(64, count);
			for (int k = 0; k < num2; k++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RevealWholeMapRequest>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr3, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RevealWholeMapRequest>(nativeArrayPtr2, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr3, l));
				}
				num >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00000094_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_00000094_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<MapDebugServerRunSystem_25D5CCD7_LambdaJob_0_Job>(jobPtr), ref query);
		}
	}

	[NoAlias]
	[BurstCompile]
	private struct MapDebugServerRunSystem_25D5CCD7_LambdaJob_1_Job : IJob
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_00000098_0024PostfixBurstDelegate(IntPtr jobPtr);

		internal static class RunWithoutJobSystem_00000098_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00000098_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(IntPtr jobPtr)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<IntPtr, void>)functionPointer)(jobPtr);
						return;
					}
				}
				RunWithoutJobSystem_0024BurstManaged(jobPtr);
			}
		}

		public PugColorARGB32 timestampColor;

		public int2 textureOffset;

		public NativeArray<PugColorARGB32> mapTextureData;

		public NativeArray<PugColorARGB32> mapTimestampData;

		public TileTypeColorLookupSystem.LookupHelper tileColorLookup;

		[ReadOnly]
		public NativeArray<TileCD> mapTiles;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody()
		{
			for (int i = 0; i < mapTextureData.Length; i++)
			{
				mapTextureData[i] = default(PugColorARGB32);
			}
			for (int j = 0; j < mapTimestampData.Length; j++)
			{
				mapTimestampData[j] = default(PugColorARGB32);
			}
			for (int k = 0; k < 64; k++)
			{
				for (int l = 0; l < 64; l++)
				{
					TileCD tileCD = mapTiles[k * 64 + l];
					int index = (k + textureOffset.y) * 256 + (l + textureOffset.x);
					mapTextureData[index] = tileColorLookup.GetTrueColorByTileType(tileCD.tileset, tileCD.tileType);
					mapTimestampData[index] = timestampColor;
				}
			}
		}

		public void Execute()
		{
			OriginalLambdaBody();
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00000098_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(IntPtr jobPtr)
		{
			RunWithoutJobSystem_00000098_0024BurstDirectCall.Invoke(jobPtr);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(IntPtr jobPtr)
		{
			InternalCompilerInterface.UnsafeAsRef<MapDebugServerRunSystem_25D5CCD7_LambdaJob_1_Job>(jobPtr).Execute();
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_902204076_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr Entity_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public QueryEnumerableWithEntity<ReceiveRpcCommandRequest> Get(int index)
			{
				return new QueryEnumerableWithEntity<ReceiveRpcCommandRequest>(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<ReceiveRpcCommandRequest>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<ReceiveRpcCommandRequest> item1_ComponentTypeHandle_RO;

			private EntityTypeHandle Entity_TypeHandle;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<ReceiveRpcCommandRequest>(isReadOnly: true);
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

		public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<ReceiveRpcCommandRequest>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public QueryEnumerableWithEntity<ReceiveRpcCommandRequest> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRO<ReceiveRpcCommandRequest>();
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_902204076_1
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public BufferAccessor<SubMapLayerBuffer> item2_BufferAccessor;

			public IntPtr Entity_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<SubMapCD>, DynamicBuffer<SubMapLayerBuffer>> Get(int index)
			{
				return new QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<SubMapCD>, DynamicBuffer<SubMapLayerBuffer>>(InternalCompilerInterface.UnsafeGetUncheckedRefRW<SubMapCD>(item1_IntPtr, index), item2_BufferAccessor[index], InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			private ComponentTypeHandle<SubMapCD> item1_ComponentTypeHandle_RW;

			private BufferTypeHandle<SubMapLayerBuffer> item2_BufferTypeHandle_RW;

			private EntityTypeHandle Entity_TypeHandle;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<SubMapCD>();
				item2_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<SubMapLayerBuffer>();
				Entity_TypeHandle = systemState.GetEntityTypeHandle();
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW.Update(ref systemState);
				item2_BufferTypeHandle_RW.Update(ref systemState);
				Entity_TypeHandle.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RW),
					item2_BufferAccessor = archetypeChunk.GetBufferAccessor(ref item2_BufferTypeHandle_RW),
					Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
				};
			}
		}

		public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<SubMapCD>, DynamicBuffer<SubMapLayerBuffer>>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<SubMapCD>, DynamicBuffer<SubMapLayerBuffer>> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRW<SubMapCD>();
			state.EntityManager.CompleteDependencyBeforeRW<SubMapLayerBuffer>();
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_902204076_2
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ProceduralSpawnArea Get(int index)
			{
				return InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<ProceduralSpawnArea>(item1_IntPtr, index);
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<ProceduralSpawnArea> item1_ComponentTypeHandle_RO;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<ProceduralSpawnArea>(isReadOnly: true);
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RO)
				};
			}
		}

		public struct Enumerator : IEnumerator<ProceduralSpawnArea>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public ProceduralSpawnArea Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRO<ProceduralSpawnArea>();
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		public ComponentTypeHandle<RevealWholeMapRequest> __RevealWholeMapRequest_RW_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ReceiveRpcCommandRequest> __Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentLookup<SubMapCD> __SubMapCD_RO_ComponentLookup;

		public IFE_902204076_0.TypeHandle __IFE_902204076_0_TypeHandle;

		public IFE_902204076_1.TypeHandle __IFE_902204076_1_TypeHandle;

		public IFE_902204076_2.TypeHandle __IFE_902204076_2_TypeHandle;

		public BufferLookup<TileUpdateBuffer> __TileUpdateBuffer_RW_BufferLookup;

		[ReadOnly]
		public ComponentLookup<ConnectionAdminLevelCD> __ConnectionAdminLevelCD_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__RevealWholeMapRequest_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RevealWholeMapRequest>();
			__Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ReceiveRpcCommandRequest>(isReadOnly: true);
			__SubMapCD_RO_ComponentLookup = state.GetComponentLookup<SubMapCD>(isReadOnly: true);
			__IFE_902204076_0_TypeHandle = new IFE_902204076_0.TypeHandle(ref state);
			__IFE_902204076_1_TypeHandle = new IFE_902204076_1.TypeHandle(ref state);
			__IFE_902204076_2_TypeHandle = new IFE_902204076_2.TypeHandle(ref state);
			__TileUpdateBuffer_RW_BufferLookup = state.GetBufferLookup<TileUpdateBuffer>();
			__ConnectionAdminLevelCD_RO_ComponentLookup = state.GetComponentLookup<ConnectionAdminLevelCD>(isReadOnly: true);
		}
	}

	private const NetworkingManager.SideChannel SIDE_CHANNEL = NetworkingManager.SideChannel.MapData;

	private const float UPDATE_PROGRESS_EVERY_N_SECONDS = 1f;

	private const int MAX_SUBMAP_RETRIES_PER_TICK = 50;

	private NativePriorityQueue<Entity> _mapsToUpdate;

	private NativeReference<int> _totalMapsToUpdate;

	private NativeReference<Entity> _requester;

	private double _lastProgressUpdateTime;

	private MapDebugExtractSubmapSystem _extractSubmapSystem;

	private TileTypeColorLookupSystem _tileTypeColorLookupSystem;

	private EntityQuery _subMapQ;

	private Texture2D _mapTexture;

	private Texture2D _timestampTexture;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_902204076_0;

	private EntityQuery __query_902204076_1;

	private EntityQuery __query_902204076_2;

	private EntityQuery __query_902204076_3;

	private EntityQuery __query_902204076_4;

	private EntityQuery __query_902204076_5;

	private EntityQuery __query_902204076_6;

	private EntityQuery __query_902204076_7;

	[Preserve]
	protected override void OnCreate()
	{
		UpdatesInRunGroup();
		NeedTileUpdateBuffer();
		_subMapQ = GetEntityQuery(new EntityQueryDesc
		{
			All = new ComponentType[1] { ComponentType.ReadOnly<SubMapCD>() },
			Options = EntityQueryOptions.IncludeDisabledEntities
		});
		_mapsToUpdate = new NativePriorityQueue<Entity>(1, Allocator.Persistent);
		_totalMapsToUpdate = new NativeReference<int>(Allocator.Persistent);
		_requester = new NativeReference<Entity>(Allocator.Persistent);
		_mapTexture = new Texture2D(256, 256, TextureFormat.ARGB32, mipChain: false, linear: false)
		{
			name = "MapDebugServerRunSystem_MapTexture"
		};
		_timestampTexture = new Texture2D(256, 256, TextureFormat.ARGB32, mipChain: false, linear: false)
		{
			name = "MapDebugServerRunSystem_TimestampTexture"
		};
		_extractSubmapSystem = base.World.GetOrCreateSystemManaged<MapDebugExtractSubmapSystem>();
		_tileTypeColorLookupSystem = base.World.GetOrCreateSystemManaged<TileTypeColorLookupSystem>();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnDestroy()
	{
		_mapsToUpdate.Dispose();
		_totalMapsToUpdate.Dispose();
		_requester.Dispose();
		UnityEngine.Object.Destroy(_mapTexture);
		UnityEngine.Object.Destroy(_timestampTexture);
		base.OnDestroy();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		EntityCommandBuffer ecb = CreateCommandBuffer();
		EntityQuery _query_902204076_ = __query_902204076_4;
		if (!_query_902204076_.IsEmpty)
		{
			bool flag = !__query_902204076_5.IsEmpty;
			Entity entity;
			foreach (QueryEnumerableWithEntity<ReceiveRpcCommandRequest> item4 in IFE_902204076_0.Query(__query_902204076_1, __TypeHandle.__IFE_902204076_0_TypeHandle, ref base.CheckedStateRef))
			{
				item4.Deconstruct(out var item, out entity);
				ReceiveRpcCommandRequest receiveRpcCommandRequest = item;
				Entity e = entity;
				Entity e2 = ecb.CreateEntity();
				ecb.AddComponent(e2, new SendRpcCommandRequest
				{
					TargetConnection = receiveRpcCommandRequest.SourceConnection
				});
				ecb.AddComponent(e2, new RegenerateTerrainResponse
				{
					Success = !flag
				});
				if (!flag)
				{
					ecb.RemoveComponent<RegenerateTerrainRequest>(e);
					ecb.AddComponent<RevealWholeMapRequest>(e);
				}
				else
				{
					ecb.DestroyEntity(e);
				}
			}
			if (!flag)
			{
				foreach (QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<SubMapCD>, DynamicBuffer<SubMapLayerBuffer>> item5 in IFE_902204076_1.Query(__query_902204076_2, __TypeHandle.__IFE_902204076_1_TypeHandle, ref base.CheckedStateRef))
				{
					item5.Deconstruct(out var item2, out var item3, out entity);
					InternalCompilerInterface.UncheckedRefRW<SubMapCD> uncheckedRefRW = item2;
					DynamicBuffer<SubMapLayerBuffer> dynamicBuffer = item3;
					Entity e3 = entity;
					dynamicBuffer.Clear();
					ecb.RemoveComponent<ProceduralSpawnArea>(e3);
					uncheckedRefRW.ValueRW.wasCreatedThisSession = true;
				}
				ecb.DestroyEntity(__query_902204076_6);
				base.OnUpdate();
				return;
			}
		}
		NativeReference<Entity> requesterLocal = _requester;
		NativePriorityQueue<Entity> mapsToUpdateLocal = _mapsToUpdate;
		NativeReference<int> totalMapsToUpdateLocal = _totalMapsToUpdate;
		EntityQuery subMapQLocal = _subMapQ;
		Entity tileUpdateBufferEntity = tileUpdateBufferSingletonEntity;
		BufferLookup<TileUpdateBuffer> tileUpdateBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__TileUpdateBuffer_RW_BufferLookup, ref base.CheckedStateRef);
		WorldInfoCD worldInfoLookup = __query_902204076_7.GetSingleton<WorldInfoCD>();
		ComponentLookup<ConnectionAdminLevelCD> connectionAdminLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ConnectionAdminLevelCD_RO_ComponentLookup, ref base.CheckedStateRef);
		MapDebugServerRunSystem_25D5CCD7_LambdaJob_0_Execute(ref ecb, ref requesterLocal, ref mapsToUpdateLocal, ref totalMapsToUpdateLocal, ref subMapQLocal, ref tileUpdateBufferEntity, ref tileUpdateBufferLookup, ref worldInfoLookup, ref connectionAdminLookup);
		if (_extractSubmapSystem.SubmapEntity.Value != Entity.Null)
		{
			Entity value = _extractSubmapSystem.SubmapEntity.Value;
			_extractSubmapSystem.SubmapEntity.Value = Entity.Null;
			PugColorARGB32 timestampColor = MapUI.CurrentMapTimestampColor;
			int2 obj = GetComponent<SubMapCD>(value).index << 6;
			Vector2Int v257 = MapUI.WorldPositionToMapPartIndex(obj);
			int2 textureOffset = MapUI.WorldPositionToMapPartPosition(obj);
			NativeArray<PugColorARGB32> mapTextureData = _mapTexture.GetPixelData<PugColorARGB32>(0);
			NativeArray<PugColorARGB32> mapTimestampData = _timestampTexture.GetPixelData<PugColorARGB32>(0);
			TileTypeColorLookupSystem.LookupHelper tileColorLookup = _tileTypeColorLookupSystem.CreateLookupHelper();
			NativeArray<TileCD> mapTiles = _extractSubmapSystem.MapTiles;
			MapDebugServerRunSystem_25D5CCD7_LambdaJob_1_Execute(ref timestampColor, ref textureOffset, ref mapTextureData, ref mapTimestampData, ref tileColorLookup, ref mapTiles);
			_mapTexture.Apply();
			_timestampTexture.Apply();
			MapPartSerialized mapPart = new MapPartSerialized
			{
				png = _mapTexture.EncodeToPNG(),
				timestampPng = _timestampTexture.EncodeToPNG()
			};
			mapPart.RecomputeTimestampHash();
			byte[] data = MapPackingHelper.PackIntoBuffer(v257.ToInt2(), mapPart);
			Manager.networking.SendSideChannel(requesterLocal.Value, base.World, NetworkingManager.SideChannel.MapData, isServer: true, data);
		}
		if (!_mapsToUpdate.IsEmpty && _extractSubmapSystem.SubmapEntity.Value == Entity.Null)
		{
			Entity value2 = Entity.Null;
			int num = math.min(_mapsToUpdate.Count, 50);
			for (int i = 0; i < num; i++)
			{
				float priority;
				Entity entity2 = _mapsToUpdate.Dequeue(out priority);
				int2 int5 = GetComponent<SubMapCD>(entity2).index * 64;
				bool flag2 = false;
				foreach (ProceduralSpawnArea item6 in IFE_902204076_2.Query(__query_902204076_3, __TypeHandle.__IFE_902204076_2_TypeHandle, ref base.CheckedStateRef))
				{
					if (math.all(item6.Position <= int5) && math.all(item6.Position + item6.Size >= int5 + 64))
					{
						flag2 = true;
						break;
					}
				}
				if (flag2)
				{
					_mapsToUpdate.Enqueue(entity2, priority + 64f);
					continue;
				}
				value2 = entity2;
				break;
			}
			_extractSubmapSystem.SubmapEntity.Value = value2;
		}
		if ((_extractSubmapSystem.SubmapEntity.Value != Entity.Null || !_mapsToUpdate.IsEmpty) && (mapsToUpdateLocal.IsEmpty || _lastProgressUpdateTime + 1.0 < base.CheckedStateRef.WorldUnmanaged.Time.ElapsedTime))
		{
			Entity e4 = ecb.CreateEntity();
			ecb.AddComponent(e4, new SendRpcCommandRequest
			{
				TargetConnection = _requester.Value
			});
			ecb.AddComponent(e4, new RevealWholeMapProgressUpdate
			{
				SubmapsUpdated = totalMapsToUpdateLocal.Value - mapsToUpdateLocal.Count,
				TotalSubMapsToUpdate = totalMapsToUpdateLocal.Value
			});
			_lastProgressUpdateTime = base.CheckedStateRef.WorldUnmanaged.Time.ElapsedTime;
		}
		base.OnUpdate();
	}

	private void MapDebugServerRunSystem_25D5CCD7_LambdaJob_0_Execute(ref EntityCommandBuffer ecb, ref NativeReference<Entity> requesterLocal, ref NativePriorityQueue<Entity> mapsToUpdateLocal, ref NativeReference<int> totalMapsToUpdateLocal, ref EntityQuery subMapQLocal, ref Entity tileUpdateBufferEntity, ref BufferLookup<TileUpdateBuffer> tileUpdateBufferLookup, ref WorldInfoCD worldInfoLookup, ref ComponentLookup<ConnectionAdminLevelCD> connectionAdminLookup)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__RevealWholeMapRequest_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__SubMapCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		MapDebugServerRunSystem_25D5CCD7_LambdaJob_0_Job value = new MapDebugServerRunSystem_25D5CCD7_LambdaJob_0_Job
		{
			ecb = ecb,
			requesterLocal = requesterLocal,
			mapsToUpdateLocal = mapsToUpdateLocal,
			totalMapsToUpdateLocal = totalMapsToUpdateLocal,
			subMapQLocal = subMapQLocal,
			tileUpdateBufferEntity = tileUpdateBufferEntity,
			tileUpdateBufferLookup = tileUpdateBufferLookup,
			worldInfoLookup = worldInfoLookup,
			connectionAdminLookup = connectionAdminLookup,
			__eTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__requestTypeHandle = __TypeHandle.__RevealWholeMapRequest_RW_ComponentTypeHandle,
			__rpcRequestTypeHandle = __TypeHandle.__Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentTypeHandle,
			__SubMapCD_ComponentLookup = __TypeHandle.__SubMapCD_RO_ComponentLookup
		};
		if (!__query_902204076_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			MapDebugServerRunSystem_25D5CCD7_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_902204076_0, jobPtr);
		}
		ecb = value.ecb;
		requesterLocal = value.requesterLocal;
		mapsToUpdateLocal = value.mapsToUpdateLocal;
		totalMapsToUpdateLocal = value.totalMapsToUpdateLocal;
		subMapQLocal = value.subMapQLocal;
		tileUpdateBufferEntity = value.tileUpdateBufferEntity;
		tileUpdateBufferLookup = value.tileUpdateBufferLookup;
		worldInfoLookup = value.worldInfoLookup;
		connectionAdminLookup = value.connectionAdminLookup;
	}

	private void MapDebugServerRunSystem_25D5CCD7_LambdaJob_1_Execute(ref PugColorARGB32 timestampColor, ref int2 textureOffset, ref NativeArray<PugColorARGB32> mapTextureData, ref NativeArray<PugColorARGB32> mapTimestampData, ref TileTypeColorLookupSystem.LookupHelper tileColorLookup, ref NativeArray<TileCD> mapTiles)
	{
		MapDebugServerRunSystem_25D5CCD7_LambdaJob_1_Job value = new MapDebugServerRunSystem_25D5CCD7_LambdaJob_1_Job
		{
			timestampColor = timestampColor,
			textureOffset = textureOffset,
			mapTextureData = mapTextureData,
			mapTimestampData = mapTimestampData,
			tileColorLookup = tileColorLookup,
			mapTiles = mapTiles
		};
		base.CheckedStateRef.CompleteDependency();
		MapDebugServerRunSystem_25D5CCD7_LambdaJob_1_Job.RunWithoutJobSystem(InternalCompilerInterface.AddressOf(ref value));
		timestampColor = value.timestampColor;
		textureOffset = value.textureOffset;
		mapTextureData = value.mapTextureData;
		mapTimestampData = value.mapTimestampData;
		tileColorLookup = value.tileColorLookup;
		mapTiles = value.mapTiles;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ReceiveRpcCommandRequest>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RevealWholeMapRequest>();
		__query_902204076_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<RegenerateTerrainRequest>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<ReceiveRpcCommandRequest>();
		__query_902204076_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ProceduralSpawnArea>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SubMapCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SubMapLayerBuffer>();
		__query_902204076_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithNone<SpawnEnvironmentObjectsInAreaCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<BlockSaveCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<ProceduralSpawnArea>();
		__query_902204076_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<RegenerateTerrainRequest>();
		__query_902204076_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BlockSaveCD, ProceduralSpawnArea>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<SpawnEnvironmentObjectsInAreaCD>();
		__query_902204076_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ObjectDataCD, LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<PlayerGhost>();
		__query_902204076_6 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_902204076_7 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	protected override void OnCreateForCompiler()
	{
		base.OnCreateForCompiler();
		__AssignQueries(ref base.CheckedStateRef);
		__TypeHandle.__AssignHandles(ref base.CheckedStateRef);
	}

	[Preserve]
	public MapDebugServerRunSystem()
	{
	}
}
