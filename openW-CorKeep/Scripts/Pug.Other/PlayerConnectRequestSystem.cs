using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using UnityEngine;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(BeginSimulationSystemGroup))]
[UpdateAfter(typeof(PlayerDisconnectSystem))]
public struct PlayerConnectRequestSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[BurstCompile]
	private struct HandleConnectRequestJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<PlayerConnectRequestRPC> __PlayerConnectRequestRPC_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ReceiveRpcCommandRequest> __Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__PlayerConnectRequestRPC_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerConnectRequestRPC>(isReadOnly: true);
					__Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ReceiveRpcCommandRequest>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__PlayerConnectRequestRPC_RO_ComponentTypeHandle.Update(ref state);
					__Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PlayerConnectRequestRPC>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ReceiveRpcCommandRequest>();
				DefaultQuery = entityQueryBuilder2.Build(ref state);
				entityQueryBuilder.Reset();
				entityQueryBuilder.Dispose();
			}

			public void Init(ref SystemState state, bool assignDefaultQuery)
			{
				if (assignDefaultQuery)
				{
					__AssignQueries(ref state);
				}
				__TypeHandle.__AssignHandles(ref state);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Run(ref HandleConnectRequestJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref HandleConnectRequestJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref HandleConnectRequestJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref HandleConnectRequestJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref HandleConnectRequestJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref HandleConnectRequestJob job, EntityManager entityManager)
			{
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct InternalCompiler
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			public static void CheckForErrors(int scheduleType)
			{
			}
		}

		public EntityCommandBuffer ecb;

		public EntityArchetype playerConnectRpcArchetypeLocal;

		public Unity.Entities.Hash128 serverGuid;

		public Unity.Entities.Hash128 serverSessionId;

		public FixedString64Bytes serverName;

		public FixedString64Bytes serverVersionString;

		public uint serverSeed;

		public int Season;

		public WorldMode WorldMode;

		public WorldGenerationType WorldGenerationType;

		public bool hostReady;

		public ulong ghostCollectionHash;

		public uint localVersionHash;

		public uint localMinorVersionHash;

		public FixedArray64 biomeCompassDirections;

		public bool crossplayAllowed;

		public Platform AllowedPlatform;

		public bool streamIntegrationEnabled;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		public void Execute(Entity reqEnt, in PlayerConnectRequestRPC req, in ReceiveRpcCommandRequest reqSrc)
		{
			ecb.DestroyEntity(reqEnt);
			Entity e = ecb.CreateEntity(playerConnectRpcArchetypeLocal);
			PlayerConnectResponseRPC component = new PlayerConnectResponseRPC
			{
				serverGuid = serverGuid,
				serverSessionId = serverSessionId,
				serverName = serverName,
				serverSeed = serverSeed,
				season = Season,
				worldMode = WorldMode,
				worldGenerationType = WorldGenerationType,
				biomeCompassDirections = biomeCompassDirections
			};
			if (localVersionHash != 0 && req.serverVersion != 0 && localVersionHash != req.serverVersion)
			{
				component.rejected = true;
				component.reason = "BadProtocolVersion";
			}
			component.minorVersionMismatch = localMinorVersionHash != req.serverMinorVersion;
			component.streamIntegrationEnabled = streamIntegrationEnabled;
			component.serverVersionString = serverVersionString;
			if (!hostReady)
			{
				component.rejected = !req.isOwner;
				if (component.rejected)
				{
					component.reason = "HostNotReady";
				}
			}
			if (req.ghostCollectionHash != ghostCollectionHash)
			{
				component.rejected = true;
				component.reason = "BadProtocolVersion";
			}
			if (!req.allowCrossPlay && (crossplayAllowed || (Platform)req.platform != AllowedPlatform))
			{
				component.rejected = true;
				component.reason = "Consoles/MissingPrivilegeReason";
			}
			else if (!crossplayAllowed && (Platform)req.platform != AllowedPlatform)
			{
				component.rejected = true;
				component.reason = "Error/HostDoesNotAllowCrossplay";
			}
			if (component.rejected)
			{
				UnityEngine.Debug.Log("Rejected connect RPC");
			}
			else
			{
				UnityEngine.Debug.Log("Accepted connect RPC");
			}
			SendRpcCommandRequest component2 = new SendRpcCommandRequest
			{
				TargetConnection = reqSrc.SourceConnection
			};
			ecb.SetComponent(e, component);
			ecb.SetComponent(e, component2);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerConnectRequestRPC_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity reqEnt = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(reqEnt, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerConnectRequestRPC>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr3, i));
					num++;
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int nextRangeBegin = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out nextRangeBegin, out nextRangeEnd))
				{
					while (nextRangeBegin < nextRangeEnd)
					{
						Entity reqEnt2 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, nextRangeBegin);
						Execute(reqEnt2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerConnectRequestRPC>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr3, nextRangeBegin));
						nextRangeBegin++;
						num++;
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int j = 0; j < num3; j++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity reqEnt3 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j);
					Execute(reqEnt3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerConnectRequestRPC>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr3, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity reqEnt4 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k);
					Execute(reqEnt4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerConnectRequestRPC>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr3, k));
					num++;
				}
				num2 >>= 1;
			}
		}

		private JobHandle __ThrowCodeGenException()
		{
			throw new Exception("This method should have been replaced by source gen.");
		}

		public void Run()
		{
			__ThrowCodeGenException();
		}

		public void RunByRef()
		{
			__ThrowCodeGenException();
		}

		public void Run(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void RunByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle Schedule(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public void Schedule()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef()
		{
			__ThrowCodeGenException();
		}

		public void Schedule(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public void ScheduleParallel()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallel(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct TypeHandle
	{
		public HandleConnectRequestJob.InternalCompilerQueryAndHandleData __PlayerConnectRequestSystem_HandleConnectRequestJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__PlayerConnectRequestSystem_HandleConnectRequestJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_000025E9_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_000025E9_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_000025E9_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_000025EA_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_000025EA_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_000025EA_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnDestroy_000025EB_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnDestroy_000025EB_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnDestroy_000025EB_0024PostfixBurstDelegate>(__codegen__OnDestroy).Value;
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
	internal delegate void __codegen__OnStopRunning_000025ED_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStopRunning_000025ED_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_000025ED_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
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
			__codegen__OnStopRunning_0024BurstManaged(self, state);
		}
	}

	private EntityArchetype playerConnectRequestRpcArchetype;

	private FixedString64Bytes serverName;

	private FixedString64Bytes serverVersionString;

	private Unity.Entities.Hash128 serverSessionId;

	private int season;

	private WorldMode worldMode;

	private bool hostReady;

	private ulong ghostCollectionHash;

	private uint localVersionHash;

	private uint localMinorVersionHash;

	private Platform allowedPlatforms;

	private bool crossplayAllowed;

	private bool streamIntegrationEnabled;

	private FixedArray64 biomeCompassDirections;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1777890611_0;

	private EntityQuery __query_1777890611_1;

	private EntityQuery __query_1777890611_2;

	private EntityQuery __query_1777890611_3;

	private EntityQuery __query_1777890611_4;

	private EntityQuery __query_1777890611_5;

	private EntityQuery __query_1777890611_6;

	private EntityQuery __query_1777890611_7;

	private EntityQuery __query_1777890611_8;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		NativeList<ComponentType> nativeList = new NativeList<ComponentType>(Allocator.Temp);
		nativeList.Add(ComponentType.ReadOnly<PlayerConnectResponseRPC>());
		nativeList.Add(ComponentType.ReadOnly<SendRpcCommandRequest>());
		using NativeList<ComponentType> nativeList2 = nativeList;
		playerConnectRequestRpcArchetype = state.EntityManager.CreateArchetype(nativeList2);
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		state.RequireForUpdate<GhostCollectionPrefab>();
		state.RequireForUpdate<ServerSeedCD>();
		state.RequireForUpdate<ServerGuidCD>();
		state.RequireForUpdate<ServerSessionIdCD>();
		state.RequireForUpdate<PlayerConnectRequestRPC>();
		state.RequireForUpdate(__query_1777890611_0);
	}

	public void OnStartRunning(ref SystemState state)
	{
		serverName = Manager.saves.GetWorldName();
		serverVersionString = Manager.version + Manager.minorVersion;
		serverSessionId = __query_1777890611_1.GetSingleton<ServerSessionIdCD>().Value;
		season = (int)Manager.prefs.season;
		worldMode = Manager.saves.GetWorldMode();
		hostReady = Manager.sceneHandler != null && Manager.sceneHandler.isInGame;
		localVersionHash = PlayerConnectRequestRPC.GetVersionHash(Manager.version);
		localMinorVersionHash = PlayerConnectRequestRPC.GetVersionHash(Manager.minorVersion);
		crossplayAllowed = Manager.platform.parentalControlManager.AllowCrossPlay(showUI: false);
		allowedPlatforms = Manager.networking.AllowedPlatforms;
		streamIntegrationEnabled = Manager.stream != null && Manager.stream.IsStreamIntegrationEnabled;
		if (ghostCollectionHash == 0L)
		{
			DynamicBuffer<GhostCollectionPrefab> singletonBuffer = __query_1777890611_2.GetSingletonBuffer<GhostCollectionPrefab>();
			for (int i = 0; i < singletonBuffer.Length; i++)
			{
				ghostCollectionHash ^= singletonBuffer[i].Hash;
			}
			UnityEngine.Debug.Log($"server has ghost collection hash {ghostCollectionHash} for {singletonBuffer.Length} ghosts");
		}
		CompassDirection[] array = new CompassDirection[12];
		if (__query_1777890611_3.TryGetSingleton<BiomeCentroidsCD>(out var value))
		{
			NativeArray<int2> centroids = value.Centroids;
			for (int j = 0; j < centroids.Length; j++)
			{
				array[j] = CompassDirectionExtensions.CompassDirectionFromCore(centroids[j]);
			}
		}
		else
		{
			FixedList512Bytes<BiomeRanges> value2 = __query_1777890611_4.GetSingleton<BiomeRangesCD>().Value;
			for (int k = 0; k < value2.Length; k++)
			{
				float3 directionToMiddleOfBiome = BiomeRanges.GetDirectionToMiddleOfBiome(value2[k]);
				array[k] = CompassDirectionExtensions.CompassDirectionFromCore(directionToMiddleOfBiome.RoundToInt2());
			}
		}
		array[0] = CompassDirection.Undefined;
		biomeCompassDirections.Set(array);
	}

	[BurstCompile]
	public void OnStopRunning(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnDestroy(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		EntityCommandBuffer ecb = __query_1777890611_5.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		Unity.Entities.Hash128 value = __query_1777890611_6.GetSingleton<ServerGuidCD>().Value;
		uint value2 = __query_1777890611_7.GetSingleton<ServerSeedCD>().Value;
		state.Dependency.Complete();
		HandleConnectRequestJob job = new HandleConnectRequestJob
		{
			ecb = ecb,
			playerConnectRpcArchetypeLocal = playerConnectRequestRpcArchetype,
			serverGuid = value,
			serverSessionId = serverSessionId,
			serverName = serverName,
			serverVersionString = serverVersionString,
			serverSeed = value2,
			Season = season,
			WorldMode = worldMode,
			WorldGenerationType = __query_1777890611_8.GetSingleton<WorldGenerationTypeCD>().Value,
			hostReady = hostReady,
			ghostCollectionHash = ghostCollectionHash,
			localVersionHash = localVersionHash,
			localMinorVersionHash = localMinorVersionHash,
			biomeCompassDirections = biomeCompassDirections,
			AllowedPlatform = allowedPlatforms,
			crossplayAllowed = crossplayAllowed,
			streamIntegrationEnabled = streamIntegrationEnabled
		};
		__ScheduleViaJobChunkExtension_0(ref job, __TypeHandle.__PlayerConnectRequestSystem_HandleConnectRequestJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	public static Unity.Entities.Hash128 GenerateSessionID()
	{
		byte[] value = Guid.NewGuid().ToByteArray();
		return new Unity.Entities.Hash128(BitConverter.ToUInt32(value, 0), BitConverter.ToUInt32(value, 4), BitConverter.ToUInt32(value, 8), BitConverter.ToUInt32(value, 12));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __ScheduleViaJobChunkExtension_0(ref HandleConnectRequestJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		__TypeHandle.__PlayerConnectRequestSystem_HandleConnectRequestJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, ref state);
		__TypeHandle.__PlayerConnectRequestSystem_HandleConnectRequestJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__PlayerConnectRequestSystem_HandleConnectRequestJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		__TypeHandle.__PlayerConnectRequestSystem_HandleConnectRequestJob_WithDefaultQuery_JobEntityTypeHandle.Run(ref job, query);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAny<BiomeSamplesCD, BiomeRangesCD>();
		__query_1777890611_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ServerSessionIdCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1777890611_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<GhostCollectionPrefab>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1777890611_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeCentroidsCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1777890611_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeRangesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1777890611_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1777890611_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ServerGuidCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1777890611_6 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ServerSeedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1777890611_7 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldGenerationTypeCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1777890611_8 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_000025E9_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_000025EA_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnDestroy(IntPtr self, IntPtr state)
	{
		__codegen__OnDestroy_000025EB_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		((PlayerConnectRequestSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStopRunning_000025ED_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((PlayerConnectRequestSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((PlayerConnectRequestSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((PlayerConnectRequestSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnDestroy_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((PlayerConnectRequestSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((PlayerConnectRequestSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}
}
