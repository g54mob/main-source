using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pug.UnityExtensions;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class SpawnGroupSystem : PugSimulationSystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct SpawnGroupSystem_699D001C_LambdaJob_0_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_000037CD_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_000037CD_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_000037CD_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
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

		public CollisionWorld collisionWorld;

		public NativeList<DistanceHit> hits;

		public Unity.Mathematics.Random rng;

		public CollisionFilter collisionFilter;

		public BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal;

		public BlobAssetReference<SpawnGroupsTable> spawnGroupsTableLocal;

		public Entity killedEnemiesBufferEntityLocal;

		public float playerScaling;

		[ReadOnly]
		public ComponentTypeHandle<SpawnGroupCD> __spawnGroupTypeHandle;

		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<FactionCD> __FactionCD_ComponentLookup;

		public BufferLookup<KilledEnemiesBuffer> __KilledEnemiesBuffer_BufferLookup;

		[ReadOnly]
		public ComponentLookup<DistanceToPlayerCD> __DistanceToPlayerCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> __ObjectDataCD_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody([NoAlias] in SpawnGroupCD spawnGroup)
		{
			if (!__Unity_Transforms_LocalTransform_ComponentLookup.HasComponent(spawnGroup.spawner))
			{
				Debug.LogError("entity destroyed before spawning group ?");
				return;
			}
			float3 position = __Unity_Transforms_LocalTransform_ComponentLookup[spawnGroup.spawner].Position;
			FactionID factionID = FactionID.None;
			if (__FactionCD_ComponentLookup.HasComponent(spawnGroup.spawner))
			{
				factionID = __FactionCD_ComponentLookup[spawnGroup.spawner].faction;
			}
			if ((int)factionID >= spawnGroupsTableLocal.Value.factionSpawnGroups.Length)
			{
				Debug.LogError("spawnerfaction");
				return;
			}
			ref FactionSpawnGroup reference = ref spawnGroupsTableLocal.Value.factionSpawnGroups[(int)factionID];
			DynamicBuffer<KilledEnemiesBuffer> buffer = __KilledEnemiesBuffer_BufferLookup[killedEnemiesBufferEntityLocal];
			int num = 0;
			int i;
			for (i = 0; i < reference.spawnGroups.Length; i++)
			{
				num += reference.spawnGroups[i].weight;
			}
			int num2 = rng.NextInt(num);
			while (true)
			{
				int num3 = 0;
				for (i = 0; i < reference.spawnGroups.Length; i++)
				{
					num3 += reference.spawnGroups[i].weight;
					if (num2 < num3)
					{
						EntityUtility.FindSorted(ref buffer, new KilledEnemiesBuffer
						{
							objectData = reference.spawnGroups[i].killRequirement
						}, default(KilledEnemiesBufferComparer), out var exists);
						if (exists)
						{
							break;
						}
					}
				}
				if (i < reference.spawnGroups.Length || num2 == 0)
				{
					break;
				}
				num2 = 0;
			}
			if (i == reference.spawnGroups.Length)
			{
				Debug.Log("found no spawn group");
				return;
			}
			InstancedSpawnGroup instance = reference.spawnGroups[i].GetInstance(ref rng, playerScaling * spawnGroup.spawnSize);
			hits.Clear();
			if (!collisionWorld.OverlapSphere(position, 15f, ref hits, collisionFilter))
			{
				return;
			}
			for (int j = 0; j < hits.Length; j++)
			{
				FactionID factionID2 = FactionID.None;
				if (__FactionCD_ComponentLookup.HasComponent(hits[j].Entity))
				{
					factionID2 = __FactionCD_ComponentLookup[hits[j].Entity].faction;
				}
				if (factionID2 != factionID || !__DistanceToPlayerCD_ComponentLookup.HasComponent(hits[j].Entity))
				{
					continue;
				}
				if (!__DistanceToPlayerCD_ComponentLookup[hits[j].Entity].isVisible)
				{
					Entity entity = hits[j].Entity;
					__Unity_Transforms_LocalTransform_ComponentLookup[entity] = LocalTransform.FromPosition(position);
				}
				ObjectDataCD objectDataCD = __ObjectDataCD_ComponentLookup[hits[j].Entity];
				for (int k = 0; k < instance.spawnObjects.Length; k++)
				{
					if (instance.spawnObjects[k] == objectDataCD.objectID && instance.spawnObjectAmounts[k] > 0)
					{
						instance.spawnObjectAmounts[k]--;
						break;
					}
				}
			}
			for (int l = 0; l < instance.spawnObjects.Length; l++)
			{
				while (instance.spawnObjectAmounts[l] > 0)
				{
					instance.spawnObjectAmounts[l]--;
					EntityUtility.CreateEntity(ecb, position, instance.spawnObjects[l], 1, databaseLocal);
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __spawnGroupTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnGroupCD>(nativeArrayPtr, i));
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
						OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnGroupCD>(nativeArrayPtr, j));
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
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnGroupCD>(nativeArrayPtr, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnGroupCD>(nativeArrayPtr, l));
				}
				num >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_000037CD_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_000037CD_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<SpawnGroupSystem_699D001C_LambdaJob_0_Job>(jobPtr), ref query);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public ComponentTypeHandle<SpawnGroupCD> __SpawnGroupCD_RO_ComponentTypeHandle;

		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<FactionCD> __FactionCD_RO_ComponentLookup;

		public BufferLookup<KilledEnemiesBuffer> __KilledEnemiesBuffer_RW_BufferLookup;

		[ReadOnly]
		public ComponentLookup<DistanceToPlayerCD> __DistanceToPlayerCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> __ObjectDataCD_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__SpawnGroupCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<SpawnGroupCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RW_ComponentLookup = state.GetComponentLookup<LocalTransform>();
			__FactionCD_RO_ComponentLookup = state.GetComponentLookup<FactionCD>(isReadOnly: true);
			__KilledEnemiesBuffer_RW_BufferLookup = state.GetBufferLookup<KilledEnemiesBuffer>();
			__DistanceToPlayerCD_RO_ComponentLookup = state.GetComponentLookup<DistanceToPlayerCD>(isReadOnly: true);
			__ObjectDataCD_RO_ComponentLookup = state.GetComponentLookup<ObjectDataCD>(isReadOnly: true);
		}
	}

	private const float gatherRadius = 15f;

	private EntityQuery query;

	private EntityQuery playerQ;

	private Entity killedEnemiesBufferEntity;

	private BlobAssetReference<SpawnGroupsTable> spawnGroupsTable;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1715386547_0;

	private EntityQuery __query_1715386547_1;

	private EntityQuery __query_1715386547_2;

	[Preserve]
	protected override void OnCreate()
	{
		UpdatesInRunGroup();
		NeedDatabase();
		NeedSpawnGroupsTable();
		RequireForUpdate<SpawnGroupsTableCD>();
		RequireForUpdate<KilledEnemiesBuffer>();
		playerQ = GetEntityQuery(ComponentType.ReadOnly<PlayerGhost>(), ComponentType.Exclude<DisablePhysicsCD>());
		base.OnCreate();
	}

	[Preserve]
	protected override void OnStartRunning()
	{
		killedEnemiesBufferEntity = __query_1715386547_1.GetSingletonEntity();
		spawnGroupsTable = __query_1715386547_2.GetSingleton<SpawnGroupsTableCD>().Value;
		base.OnStartRunning();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		EntityCommandBuffer ecb = new EntityCommandBuffer(Allocator.Temp);
		CollisionWorld collisionWorld = GetPhysicsWorld().CollisionWorld;
		NativeList<DistanceHit> hits = new NativeList<DistanceHit>(Allocator.Temp);
		Unity.Mathematics.Random rng = PugRandom.GetRng();
		CollisionFilter collisionFilter = new CollisionFilter
		{
			BelongsTo = uint.MaxValue,
			CollidesWith = 8u
		};
		BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal = database;
		BlobAssetReference<SpawnGroupsTable> spawnGroupsTableLocal = spawnGroupsTable;
		Entity killedEnemiesBufferEntityLocal = killedEnemiesBufferEntity;
		float playerScaling = 1f + math.min(1f, (float)(playerQ.CalculateEntityCount() - 1) / 4f);
		SpawnGroupSystem_699D001C_LambdaJob_0_Execute(ref ecb, ref collisionWorld, ref hits, ref rng, ref collisionFilter, ref databaseLocal, ref spawnGroupsTableLocal, ref killedEnemiesBufferEntityLocal, ref playerScaling);
		base.EntityManager.DestroyEntity(query);
		ecb.Playback(base.EntityManager);
		ecb.Dispose();
		hits.Dispose();
		base.OnUpdate();
	}

	private void SpawnGroupSystem_699D001C_LambdaJob_0_Execute(ref EntityCommandBuffer ecb, ref CollisionWorld collisionWorld, ref NativeList<DistanceHit> hits, ref Unity.Mathematics.Random rng, ref CollisionFilter collisionFilter, ref BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal, ref BlobAssetReference<SpawnGroupsTable> spawnGroupsTableLocal, ref Entity killedEnemiesBufferEntityLocal, ref float playerScaling)
	{
		__TypeHandle.__SpawnGroupCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__FactionCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__KilledEnemiesBuffer_RW_BufferLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__DistanceToPlayerCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__ObjectDataCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		SpawnGroupSystem_699D001C_LambdaJob_0_Job value = new SpawnGroupSystem_699D001C_LambdaJob_0_Job
		{
			ecb = ecb,
			collisionWorld = collisionWorld,
			hits = hits,
			rng = rng,
			collisionFilter = collisionFilter,
			databaseLocal = databaseLocal,
			spawnGroupsTableLocal = spawnGroupsTableLocal,
			killedEnemiesBufferEntityLocal = killedEnemiesBufferEntityLocal,
			playerScaling = playerScaling,
			__spawnGroupTypeHandle = __TypeHandle.__SpawnGroupCD_RO_ComponentTypeHandle,
			__Unity_Transforms_LocalTransform_ComponentLookup = __TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentLookup,
			__FactionCD_ComponentLookup = __TypeHandle.__FactionCD_RO_ComponentLookup,
			__KilledEnemiesBuffer_BufferLookup = __TypeHandle.__KilledEnemiesBuffer_RW_BufferLookup,
			__DistanceToPlayerCD_ComponentLookup = __TypeHandle.__DistanceToPlayerCD_RO_ComponentLookup,
			__ObjectDataCD_ComponentLookup = __TypeHandle.__ObjectDataCD_RO_ComponentLookup
		};
		if (!__query_1715386547_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			SpawnGroupSystem_699D001C_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_1715386547_0, jobPtr);
		}
		ecb = value.ecb;
		collisionWorld = value.collisionWorld;
		hits = value.hits;
		rng = value.rng;
		collisionFilter = value.collisionFilter;
		databaseLocal = value.databaseLocal;
		spawnGroupsTableLocal = value.spawnGroupsTableLocal;
		killedEnemiesBufferEntityLocal = value.killedEnemiesBufferEntityLocal;
		playerScaling = value.playerScaling;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<SpawnGroupCD>();
		query = (__query_1715386547_0 = entityQueryBuilder2.Build(ref state));
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<KilledEnemiesBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1715386547_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<SpawnGroupsTableCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1715386547_2 = entityQueryBuilder2.Build(ref state);
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
	public SpawnGroupSystem()
	{
	}
}
