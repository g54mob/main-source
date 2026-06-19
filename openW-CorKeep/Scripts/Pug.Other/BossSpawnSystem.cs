using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pug.UnityExtensions;
using PugWorldGen;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class BossSpawnSystem : PugSimulationSystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct BossSpawnSystem_78AA7B8_LambdaJob_0_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_00000659_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_00000659_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00000659_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
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

		public NativeHashSet<int> existingSoulOrbs;

		[ReadOnly]
		public ComponentTypeHandle<SoulOrbCD> __soulOrbTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody([NoAlias] in SoulOrbCD soulOrb)
		{
			existingSoulOrbs.Add((int)soulOrb.givesSoul);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __soulOrbTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SoulOrbCD>(nativeArrayPtr, i));
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
						OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SoulOrbCD>(nativeArrayPtr, j));
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
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SoulOrbCD>(nativeArrayPtr, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SoulOrbCD>(nativeArrayPtr, l));
				}
				num >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00000659_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_00000659_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<BossSpawnSystem_78AA7B8_LambdaJob_0_Job>(jobPtr), ref query);
		}
	}

	[NoAlias]
	[BurstCompile]
	private struct BossSpawnSystem_78AA7B8_LambdaJob_1_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_0000065D_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_0000065D_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_0000065D_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
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

		public BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal;

		public bool spawnBirdBoss;

		public bool spawnOctopusBoss;

		public bool spawnScarabBoss;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __transformTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<BossSpawnLocationCD> __bossSpawnLocationTypeHandle;

		[ReadOnly]
		public ComponentLookup<DisablePhysicsCD> __DisablePhysicsCD_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody([NoAlias] in LocalTransform transform, [NoAlias] in BossSpawnLocationCD bossSpawnLocation)
		{
			if ((spawnBirdBoss && bossSpawnLocation.bossID == ObjectID.BirdBoss) || (spawnOctopusBoss && bossSpawnLocation.bossID == ObjectID.OctopusBoss) || (spawnScarabBoss && bossSpawnLocation.bossID == ObjectID.ScarabBoss))
			{
				Entity prefabEntity;
				Entity e = EntityUtility.CreateEntity(ecb, new float3(transform.Position.x, 0f, transform.Position.z), bossSpawnLocation.bossID, 1, databaseLocal, out prefabEntity);
				if (__DisablePhysicsCD_ComponentLookup.HasComponent(prefabEntity))
				{
					ecb.SetComponentEnabled<DisablePhysicsCD>(e, value: true);
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __transformTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __bossSpawnLocationTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BossSpawnLocationCD>(nativeArrayPtr2, i));
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
						OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BossSpawnLocationCD>(nativeArrayPtr2, j));
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
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BossSpawnLocationCD>(nativeArrayPtr2, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BossSpawnLocationCD>(nativeArrayPtr2, l));
				}
				num >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_0000065D_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_0000065D_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<BossSpawnSystem_78AA7B8_LambdaJob_1_Job>(jobPtr), ref query);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public ComponentTypeHandle<SoulOrbCD> __SoulOrbCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<BossSpawnLocationCD> __BossSpawnLocationCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentLookup<DisablePhysicsCD> __DisablePhysicsCD_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__SoulOrbCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<SoulOrbCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
			__BossSpawnLocationCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<BossSpawnLocationCD>(isReadOnly: true);
			__DisablePhysicsCD_RO_ComponentLookup = state.GetComponentLookup<DisablePhysicsCD>(isReadOnly: true);
		}
	}

	private const float SYSTEM_UPDATE_COOLDOWN = 60f;

	private float systemTimer;

	private const int CLASSIC_HYDRA_SPAWN_DISTANCE = 800;

	private const int CLASSIC_SNAKE_SPAWN_DISTANCE = 900;

	private const float FULL_RELEASE_RELATIVE_HYDRA_SPAWN_DISTANCE = 0.4f;

	private const float FULL_RELEASE_RELATIVE_SNAKE_SPAWN_DISTANCE = 0.6f;

	private EntityQuery birdBossQ;

	private EntityQuery octopusBossQ;

	private EntityQuery scarabBossQ;

	private EntityQuery hydraBossNatureQ;

	private EntityQuery hydraBossSeaQ;

	private EntityQuery hydraBossDesertQ;

	private EntityQuery hydraBossVoidQ;

	private int _ring2StartDistance;

	private int _ring2EndDistance;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_775170482_0;

	private EntityQuery __query_775170482_1;

	private EntityQuery __query_775170482_2;

	private EntityQuery __query_775170482_3;

	private EntityQuery __query_775170482_4;

	private EntityQuery __query_775170482_5;

	private EntityQuery __query_775170482_6;

	[Preserve]
	protected override void OnCreate()
	{
		NeedDatabase();
		RequireForUpdate(__query_775170482_2);
		EntityQueryDesc entityQueryDesc = new EntityQueryDesc();
		entityQueryDesc.All = new ComponentType[1] { typeof(BirdBossAppearStateCD) };
		entityQueryDesc.Options = EntityQueryOptions.IncludeDisabledEntities;
		EntityQueryDesc entityQueryDesc2 = entityQueryDesc;
		birdBossQ = GetEntityQuery(entityQueryDesc2);
		entityQueryDesc = new EntityQueryDesc();
		entityQueryDesc.All = new ComponentType[1] { typeof(OctopusBossAppearStateCD) };
		entityQueryDesc.Options = EntityQueryOptions.IncludeDisabledEntities;
		EntityQueryDesc entityQueryDesc3 = entityQueryDesc;
		octopusBossQ = GetEntityQuery(entityQueryDesc3);
		entityQueryDesc = new EntityQueryDesc();
		entityQueryDesc.All = new ComponentType[1] { typeof(ScarabBossAppearStateCD) };
		entityQueryDesc.Options = EntityQueryOptions.IncludeDisabledEntities;
		EntityQueryDesc entityQueryDesc4 = entityQueryDesc;
		scarabBossQ = GetEntityQuery(entityQueryDesc4);
		entityQueryDesc = new EntityQueryDesc();
		entityQueryDesc.All = new ComponentType[1] { typeof(HydraBossNatureCD) };
		entityQueryDesc.Options = EntityQueryOptions.IncludeDisabledEntities;
		EntityQueryDesc entityQueryDesc5 = entityQueryDesc;
		hydraBossNatureQ = GetEntityQuery(entityQueryDesc5);
		entityQueryDesc = new EntityQueryDesc();
		entityQueryDesc.All = new ComponentType[1] { typeof(HydraBossSeaCD) };
		entityQueryDesc.Options = EntityQueryOptions.IncludeDisabledEntities;
		EntityQueryDesc entityQueryDesc6 = entityQueryDesc;
		hydraBossSeaQ = GetEntityQuery(entityQueryDesc6);
		entityQueryDesc = new EntityQueryDesc();
		entityQueryDesc.All = new ComponentType[1] { typeof(HydraBossDesertCD) };
		entityQueryDesc.Options = EntityQueryOptions.IncludeDisabledEntities;
		EntityQueryDesc entityQueryDesc7 = entityQueryDesc;
		hydraBossDesertQ = GetEntityQuery(entityQueryDesc7);
		entityQueryDesc = new EntityQueryDesc();
		entityQueryDesc.All = new ComponentType[1] { typeof(HydraBossVoidCD) };
		entityQueryDesc.Options = EntityQueryOptions.IncludeDisabledEntities;
		EntityQueryDesc entityQueryDesc8 = entityQueryDesc;
		hydraBossVoidQ = GetEntityQuery(entityQueryDesc8);
		base.OnCreate();
	}

	[Preserve]
	protected override void OnStartRunning()
	{
		base.OnStartRunning();
		CoreKeeperWorldParameters worldGenerationParametersReference = Manager.saves.GetWorldGenerationParametersReference();
		_ring2StartDistance = (int)math.ceil(worldGenerationParametersReference.ring2Size * worldGenerationParametersReference.worldScale);
		_ring2EndDistance = (int)math.ceil(worldGenerationParametersReference.ring3Size * worldGenerationParametersReference.worldScale);
	}

	[Preserve]
	protected override void OnUpdate()
	{
		systemTimer -= base.CheckedStateRef.WorldUnmanaged.Time.DeltaTime;
		if (systemTimer > 0f)
		{
			base.OnUpdate();
			return;
		}
		WorldGenerationType value = __query_775170482_4.GetSingleton<WorldGenerationTypeCD>().Value;
		if (value == WorldGenerationType.Creative)
		{
			base.OnUpdate();
			return;
		}
		EntityCommandBuffer ecb = CreateCommandBuffer();
		BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal = database;
		NativeHashSet<int> existingSoulOrbs = new NativeHashSet<int>(7, base.World.UpdateAllocator.ToAllocator);
		BiomeSamplesCD value2;
		BiomeLookup biomeLookup = (__query_775170482_5.TryGetSingleton<BiomeSamplesCD>(out value2) ? new BiomeLookup(value2) : new BiomeLookup(__query_775170482_6.GetSingleton<BiomeRangesCD>().Value, Allocator.Temp));
		BossSpawnSystem_78AA7B8_LambdaJob_0_Execute(ref existingSoulOrbs);
		bool spawnBirdBoss = !existingSoulOrbs.Contains(1) && birdBossQ.IsEmpty;
		bool spawnOctopusBoss = !existingSoulOrbs.Contains(2) && octopusBossQ.IsEmpty;
		bool spawnScarabBoss = !existingSoulOrbs.Contains(3) && scarabBossQ.IsEmpty;
		if (spawnBirdBoss || spawnOctopusBoss || spawnScarabBoss)
		{
			BossSpawnSystem_78AA7B8_LambdaJob_1_Execute(ref ecb, ref databaseLocal, ref spawnBirdBoss, ref spawnOctopusBoss, ref spawnScarabBoss);
		}
		if (__query_775170482_3.IsEmpty)
		{
			int distanceFromCore = ((value == WorldGenerationType.Classic) ? 900 : ((int)math.round(math.lerp(_ring2StartDistance, _ring2EndDistance, 0.6f))));
			SpawnBossRandomlyInBiome(ecb, ObjectID.SnakeBossSegment, Biome.Sea, distanceFromCore, biomeLookup, databaseLocal);
		}
		int distanceFromCore2 = ((value == WorldGenerationType.Classic) ? 800 : ((int)math.round(math.lerp(_ring2StartDistance, _ring2EndDistance, 0.4f))));
		if (!existingSoulOrbs.Contains(4) && hydraBossNatureQ.IsEmpty)
		{
			SpawnBossRandomlyInBiome(ecb, ObjectID.HydraBossNature, Biome.Nature, distanceFromCore2, biomeLookup, databaseLocal);
		}
		if (!existingSoulOrbs.Contains(5) && hydraBossSeaQ.IsEmpty)
		{
			SpawnBossRandomlyInBiome(ecb, ObjectID.HydraBossSea, Biome.Sea, distanceFromCore2, biomeLookup, databaseLocal);
		}
		if (!existingSoulOrbs.Contains(6) && hydraBossDesertQ.IsEmpty)
		{
			SpawnBossRandomlyInBiome(ecb, ObjectID.HydraBossDesert, Biome.Desert, distanceFromCore2, biomeLookup, databaseLocal);
		}
		if (value == WorldGenerationType.FullRelease && hydraBossVoidQ.IsEmpty)
		{
			SpawnBossRandomlyInBiome(ecb, ObjectID.HydraBossVoid, Biome.Excavation, 1450, biomeLookup, databaseLocal);
		}
		systemTimer = 60f;
		biomeLookup.Dispose();
		base.OnUpdate();
	}

	private void SpawnBossRandomlyInBiome(EntityCommandBuffer ecb, ObjectID bossId, Biome biome, int distanceFromCore, BiomeLookup biomeLookup, BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal)
	{
		Unity.Mathematics.Random rng = PugRandom.GetRng();
		int2 result;
		bool flag = biomeLookup.TryGetRandomPositionInBiome(biome, ref rng, out result, distanceFromCore, distanceFromCore);
		if (!flag)
		{
			Debug.LogWarning($"Failed to find an ideal spawn position for {bossId} in biome {biome}, trying again with relaxed constraints");
			flag = biomeLookup.TryGetRandomPositionInBiome(biome, ref rng, out result);
		}
		if (!flag)
		{
			Debug.LogError($"Failed to find any spot for {bossId} in biome {biome}.");
		}
		else
		{
			EntityUtility.CreateEntity(ecb, result.ToFloat3(), bossId, 1, databaseLocal);
		}
	}

	private void BossSpawnSystem_78AA7B8_LambdaJob_0_Execute(ref NativeHashSet<int> existingSoulOrbs)
	{
		__TypeHandle.__SoulOrbCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		BossSpawnSystem_78AA7B8_LambdaJob_0_Job value = new BossSpawnSystem_78AA7B8_LambdaJob_0_Job
		{
			existingSoulOrbs = existingSoulOrbs,
			__soulOrbTypeHandle = __TypeHandle.__SoulOrbCD_RO_ComponentTypeHandle
		};
		if (!__query_775170482_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			BossSpawnSystem_78AA7B8_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_775170482_0, jobPtr);
		}
		existingSoulOrbs = value.existingSoulOrbs;
	}

	private void BossSpawnSystem_78AA7B8_LambdaJob_1_Execute(ref EntityCommandBuffer ecb, ref BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal, ref bool spawnBirdBoss, ref bool spawnOctopusBoss, ref bool spawnScarabBoss)
	{
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__BossSpawnLocationCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__DisablePhysicsCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		BossSpawnSystem_78AA7B8_LambdaJob_1_Job value = new BossSpawnSystem_78AA7B8_LambdaJob_1_Job
		{
			ecb = ecb,
			databaseLocal = databaseLocal,
			spawnBirdBoss = spawnBirdBoss,
			spawnOctopusBoss = spawnOctopusBoss,
			spawnScarabBoss = spawnScarabBoss,
			__transformTypeHandle = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle,
			__bossSpawnLocationTypeHandle = __TypeHandle.__BossSpawnLocationCD_RO_ComponentTypeHandle,
			__DisablePhysicsCD_ComponentLookup = __TypeHandle.__DisablePhysicsCD_RO_ComponentLookup
		};
		if (!__query_775170482_1.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			BossSpawnSystem_78AA7B8_LambdaJob_1_Job.RunWithoutJobSystem(ref __query_775170482_1, jobPtr);
		}
		ecb = value.ecb;
		databaseLocal = value.databaseLocal;
		spawnBirdBoss = value.spawnBirdBoss;
		spawnOctopusBoss = value.spawnOctopusBoss;
		spawnScarabBoss = value.spawnScarabBoss;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<SoulOrbCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
		__query_775170482_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<BossSpawnLocationCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
		__query_775170482_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAny<BiomeRangesCD, BiomeSamplesCD>();
		__query_775170482_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<SnakeBossCD>();
		__query_775170482_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldGenerationTypeCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_775170482_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeSamplesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_775170482_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeRangesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_775170482_6 = entityQueryBuilder2.Build(ref state);
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
	public BossSpawnSystem()
	{
	}
}
