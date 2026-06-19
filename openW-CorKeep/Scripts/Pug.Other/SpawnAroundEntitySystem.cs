using System;
using System.Runtime.CompilerServices;
using Pug.Properties;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SimulationSystemGroup))]
public class SpawnAroundEntitySystem : PugSimulationSystemBase
{
	private struct CritterSpawnObject
	{
		public ObjectDataCD ObjectData;

		public Biome Biome;

		public Tileset Tileset;
	}

	[NoAlias]
	[BurstCompile]
	private struct SpawnAroundEntitySystem_5A923F29_LambdaJob_0_Job : IJobChunk
	{
		public NativeList<LocalTransform> playerPositions;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __transformTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody([NoAlias] in LocalTransform transform)
		{
			playerPositions.Add(in transform);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __transformTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, i));
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
						OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, j));
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
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, l));
				}
				num >>= 1;
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[NoAlias]
	[BurstCompile]
	private struct SpawnAroundEntitySystem_5A923F29_LambdaJob_1_Job : IJobChunk
	{
		public float deltaTime;

		public Unity.Mathematics.Random rng;

		public EntityCommandBuffer ecb;

		public BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal;

		[ReadOnly]
		public CollisionWorld collisionWorld;

		[ReadOnly]
		public TileAccessor tileLookup;

		public NativeList<CritterSpawnObject> crittersToSpawnLocal;

		[ReadOnly]
		public NativeList<LocalTransform> playerPositions;

		[ReadOnly]
		public BiomeLookup biomeLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionsBuffer> conditionsBufferLookup;

		public ComponentTypeHandle<SpawnEntitiesAroundEntityCD> __spawnerTypeHandle;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<Disabled> __Unity_Entities_Disabled_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<HealthCD> __HealthCD_ComponentLookup;

		public ComponentLookup<CritterCD> __CritterCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<IsPersistentCritterCD> __IsPersistentCritterCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> __ObjectDataCD_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody([NoAlias] ref SpawnEntitiesAroundEntityCD spawner)
		{
			if (spawner.limitNumberSpawned == 0 || !__Unity_Transforms_LocalTransform_ComponentLookup.HasComponent(spawner.mainEntity) || __Unity_Entities_Disabled_ComponentLookup.HasComponent(spawner.mainEntity) || (__HealthCD_ComponentLookup.HasComponent(spawner.mainEntity) && __HealthCD_ComponentLookup[spawner.mainEntity].health <= 0))
			{
				return;
			}
			spawner.timer -= deltaTime;
			if (spawner.timer > 0f)
			{
				return;
			}
			spawner.timer = rng.NextFloat(spawner.minSpawnCooldown, spawner.maxSpawnCooldown);
			if (spawner.requiredCondition != ConditionID.None && conditionsBufferLookup.HasComponent(spawner.mainEntity) && (float)conditionsBufferLookup[spawner.mainEntity][(int)spawner.requiredCondition].value < 0.1f)
			{
				return;
			}
			LocalTransform localTransform = __Unity_Transforms_LocalTransform_ComponentLookup[spawner.mainEntity];
			NativeParallelHashSet<Entity> nativeParallelHashSet = new NativeParallelHashSet<Entity>(spawner.limitNumberSpawned * 3, Allocator.Temp);
			NativeList<DistanceHit> outHits = new NativeList<DistanceHit>(Allocator.Temp);
			if (spawner.spawnCrittersInsteadOfObject)
			{
				if (collisionWorld.OverlapSphere(localTransform.Position, spawner.critterDespawnDistance, ref outHits, _critterCollisionFilter))
				{
					for (int i = 0; i < outHits.Length; i++)
					{
						if (__CritterCD_ComponentLookup.HasComponent(outHits[i].Entity) && !__IsPersistentCritterCD_ComponentLookup.HasComponent(outHits[i].Entity))
						{
							nativeParallelHashSet.Add(outHits[i].Entity);
							CritterCD value = __CritterCD_ComponentLookup[outHits[i].Entity];
							value.destroyTimer = 0f;
							Entity entity = outHits[i].Entity;
							__CritterCD_ComponentLookup[entity] = value;
						}
					}
				}
			}
			else if (collisionWorld.OverlapSphere(localTransform.Position, spawner.maxSpawnDistance, ref outHits, _enemyCollisionFilter))
			{
				for (int j = 0; j < outHits.Length; j++)
				{
					if (__ObjectDataCD_ComponentLookup.HasComponent(outHits[j].Entity) && __ObjectDataCD_ComponentLookup[outHits[j].Entity].objectID == spawner.objectToSpawn.objectID)
					{
						if (spawner.avoidSpawnCloseToObject != ObjectID.None && __ObjectDataCD_ComponentLookup[outHits[j].Entity].objectID == spawner.avoidSpawnCloseToObject)
						{
							return;
						}
						nativeParallelHashSet.Add(outHits[j].Entity);
					}
				}
			}
			outHits.Dispose();
			int num = nativeParallelHashSet.Count();
			nativeParallelHashSet.Dispose();
			if (num >= spawner.limitNumberSpawned)
			{
				return;
			}
			if (spawner.spawnCounter >= spawner.limitNumberSpawned)
			{
				spawner.spawnCounter = 0;
				if (spawner.minReachedLimitCooldown > 0f || spawner.maxReachedLimitCooldown > 0f)
				{
					spawner.timer = rng.NextFloat(spawner.minReachedLimitCooldown, spawner.maxReachedLimitCooldown);
					return;
				}
			}
			float2 float5 = rng.NextFloat2Direction();
			float num2 = rng.NextFloat(0f, spawner.maxSpawnDistance);
			int2 int5 = (localTransform.Position.ToFloat2() + num2 * float5).RoundToInt2();
			Biome biome = biomeLookup.GetBiome(int5);
			if (spawner.spawnCrittersInsteadOfObject)
			{
				if (!tileLookup.GetTop(int5).tileType.CanSpawnCritter() || collisionWorld.SphereCast(int5.ToFloat3(), 0.4f, 0, 0f, _critterCollisionFilter))
				{
					return;
				}
			}
			else if (tileLookup.GetTop(int5).tileType != TileType.ground || collisionWorld.SphereCast(int5.ToFloat3(), 0.4f, 0, 0f, _objectsCollisionFilter))
			{
				return;
			}
			if ((spawner.spawnsInBiomeBitMask != 0L && !HasBiome(spawner.spawnsInBiomeBitMask, biome)) || (spawner.playerNeedsToBeInsideBiome && !biomeLookup.IsOnlyBiomeInRange(localTransform.Position.ToFloat2().RoundToInt2(), 31, biome)))
			{
				return;
			}
			bool flag = false;
			for (int k = 0; k < playerPositions.Length; k++)
			{
				float num3 = math.distancesq(playerPositions[k].Position, int5.ToFloat3());
				if (!spawner.spawnCloseToPlayers)
				{
					if (num3 < 441f)
					{
						spawner.timer = spawner.minSpawnCooldown;
						return;
					}
				}
				else if (num3 < 441f)
				{
					flag = true;
				}
				if (flag)
				{
					break;
				}
			}
			if (spawner.spawnCloseToPlayers && !flag)
			{
				return;
			}
			if (spawner.spawnCrittersInsteadOfObject)
			{
				int num4 = -1;
				NativeList<int> nativeList = new NativeList<int>(crittersToSpawnLocal.Length, Allocator.Temp);
				Tileset tileset = (Tileset)tileLookup.GetTop(int5).tileset;
				TileType tileType = tileLookup.GetTop(int5).tileType;
				for (int l = 0; l < crittersToSpawnLocal.Length; l++)
				{
					if (crittersToSpawnLocal[l].Biome == Biome.None && crittersToSpawnLocal[l].Tileset == Tileset.MAX_VALUE)
					{
						num4 = l;
					}
					else if (crittersToSpawnLocal[l].Biome == Biome.None && crittersToSpawnLocal[l].Tileset == tileset && tileType == TileType.ground)
					{
						nativeList.Add(in l);
					}
					else if (crittersToSpawnLocal[l].Biome == biome && tileset != Tileset.Crystal)
					{
						nativeList.Add(in l);
					}
				}
				if (nativeList.Length > 0)
				{
					ObjectDataCD objectData = crittersToSpawnLocal[nativeList[rng.NextInt(nativeList.Length)]].ObjectData;
					Entity e = EntityUtility.CreateEntity(ecb, objectData.objectID, 1, databaseLocal, objectData.variation);
					ecb.SetComponent(e, LocalTransform.FromPosition(int5.ToFloat3()));
				}
				else if (num4 != -1)
				{
					ObjectDataCD objectData2 = crittersToSpawnLocal[num4].ObjectData;
					Entity e2 = EntityUtility.CreateEntity(ecb, objectData2.objectID, 1, databaseLocal, objectData2.variation);
					ecb.SetComponent(e2, LocalTransform.FromPosition(int5.ToFloat3()));
				}
				nativeList.Dispose();
			}
			else
			{
				spawner.spawnCounter++;
				ObjectDataCD objectToSpawn = spawner.objectToSpawn;
				Entity e3 = EntityUtility.CreateEntity(ecb, objectToSpawn.objectID, spawner.objectToSpawn.amount, databaseLocal, objectToSpawn.variation);
				ecb.SetComponent(e3, LocalTransform.FromPosition(int5.ToFloat3()));
				if (!spawner.objectIsPersistent)
				{
					ecb.AddComponent(e3, new DestroyEntityWhenNoNearbyPlayerCD
					{
						distanceSq = ((spawner.maxSpawnDistance > 0f) ? (spawner.maxSpawnDistance * spawner.maxSpawnDistance) : 100f),
						destroyDelay = 0.1f
					});
				}
				if (spawner.addAffixConditionOnSpawn.conditionID != ConditionID.None)
				{
					ecb.AppendToBuffer(e3, new ActiveAffixConditionsBuffer
					{
						conditionData = spawner.addAffixConditionOnSpawn
					});
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __spawnerTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnEntitiesAroundEntityCD>(nativeArrayPtr, i));
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
						OriginalLambdaBody(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnEntitiesAroundEntityCD>(nativeArrayPtr, j));
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
					OriginalLambdaBody(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnEntitiesAroundEntityCD>(nativeArrayPtr, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnEntitiesAroundEntityCD>(nativeArrayPtr, l));
				}
				num >>= 1;
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[NoAlias]
	[BurstCompile]
	private struct SpawnAroundEntitySystem_5A923F29_LambdaJob_2_Job : IJobChunk
	{
		public float deltaTime;

		public EntityCommandBuffer ecb;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public ComponentTypeHandle<CritterCD> __critterTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] ref CritterCD critter)
		{
			if (critter.destroyTimer > 4f)
			{
				ecb.DestroyEntity(entity);
			}
			else
			{
				critter.destroyTimer += deltaTime;
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __critterTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CritterCD>(nativeArrayPtr2, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CritterCD>(nativeArrayPtr2, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CritterCD>(nativeArrayPtr2, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CritterCD>(nativeArrayPtr2, l));
				}
				num >>= 1;
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

		public ComponentTypeHandle<SpawnEntitiesAroundEntityCD> __SpawnEntitiesAroundEntityCD_RW_ComponentTypeHandle;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<Disabled> __Unity_Entities_Disabled_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<HealthCD> __HealthCD_RO_ComponentLookup;

		public ComponentLookup<CritterCD> __CritterCD_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<IsPersistentCritterCD> __IsPersistentCritterCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> __ObjectDataCD_RO_ComponentLookup;

		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		public ComponentTypeHandle<CritterCD> __CritterCD_RW_ComponentTypeHandle;

		[ReadOnly]
		public BufferLookup<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
			__SpawnEntitiesAroundEntityCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<SpawnEntitiesAroundEntityCD>();
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__Unity_Entities_Disabled_RO_ComponentLookup = state.GetComponentLookup<Disabled>(isReadOnly: true);
			__HealthCD_RO_ComponentLookup = state.GetComponentLookup<HealthCD>(isReadOnly: true);
			__CritterCD_RW_ComponentLookup = state.GetComponentLookup<CritterCD>();
			__IsPersistentCritterCD_RO_ComponentLookup = state.GetComponentLookup<IsPersistentCritterCD>(isReadOnly: true);
			__ObjectDataCD_RO_ComponentLookup = state.GetComponentLookup<ObjectDataCD>(isReadOnly: true);
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__CritterCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<CritterCD>();
			__SummarizedConditionsBuffer_RO_BufferLookup = state.GetBufferLookup<SummarizedConditionsBuffer>(isReadOnly: true);
		}
	}

	private const float PLAYER_SPAWN_DISTANCE_SQ = 441f;

	private NativeList<CritterSpawnObject> _crittersToSpawn;

	private WorldInfoSystem _worldInfoSystem;

	private BiomeLookup _biomeLookup;

	private static readonly CollisionFilter _critterCollisionFilter = new CollisionFilter
	{
		BelongsTo = uint.MaxValue,
		CollidesWith = 33792u
	};

	private static readonly CollisionFilter _enemyCollisionFilter = new CollisionFilter
	{
		BelongsTo = uint.MaxValue,
		CollidesWith = 1040u
	};

	private static readonly CollisionFilter _objectsCollisionFilter = new CollisionFilter
	{
		BelongsTo = uint.MaxValue,
		CollidesWith = 1024u
	};

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1625070027_0;

	private EntityQuery __query_1625070027_1;

	private EntityQuery __query_1625070027_2;

	private EntityQuery __query_1625070027_3;

	private EntityQuery __query_1625070027_4;

	private EntityQuery __query_1625070027_5;

	[Preserve]
	protected override void OnCreate()
	{
		NeedDatabase();
		RequireForUpdate(__query_1625070027_3);
		_worldInfoSystem = base.World.GetExistingSystemManaged<WorldInfoSystem>();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnStartRunning()
	{
		base.OnStartRunning();
		if (_crittersToSpawn.IsCreated)
		{
			return;
		}
		_biomeLookup = (__query_1625070027_4.TryGetSingleton<BiomeSamplesCD>(out var value) ? new BiomeLookup(value) : new BiomeLookup(__query_1625070027_5.GetSingleton<BiomeRangesCD>().Value, Allocator.Persistent));
		_crittersToSpawn = new NativeList<CritterSpawnObject>(Allocator.Persistent);
		using NativeArray<Entity> nativeArray = GetEntityQuery(typeof(CritterCD), typeof(Prefab)).ToEntityArray(Allocator.Temp);
		for (int i = 0; i < nativeArray.Length; i++)
		{
			ObjectDataCD component = GetComponent<ObjectDataCD>(nativeArray[i]);
			ObjectPropertiesCD component2 = GetComponent<ObjectPropertiesCD>(nativeArray[i]);
			if (!PugDatabase.HasObject(component.objectID, database, component.variation) || !component2.Has(-1692145636))
			{
				continue;
			}
			NativeArray<Biome> value3;
			if (component2.TryGetList(396300893, out NativeArray<Tileset> value2, (AllocatorManager.AllocatorHandle)Allocator.Temp))
			{
				for (int j = 0; j < value2.Length; j++)
				{
					_crittersToSpawn.Add(new CritterSpawnObject
					{
						ObjectData = GetComponent<ObjectDataCD>(nativeArray[i]),
						Biome = Biome.None,
						Tileset = value2[j]
					});
				}
				value2.Dispose();
			}
			else if (component2.TryGetList(-393935444, out value3, (AllocatorManager.AllocatorHandle)Allocator.Temp))
			{
				for (int k = 0; k < value3.Length; k++)
				{
					_crittersToSpawn.Add(new CritterSpawnObject
					{
						ObjectData = GetComponent<ObjectDataCD>(nativeArray[i]),
						Biome = value3[k],
						Tileset = Tileset.MAX_VALUE
					});
				}
				value3.Dispose();
			}
		}
	}

	[Preserve]
	protected override void OnDestroy()
	{
		if (_crittersToSpawn.IsCreated)
		{
			_crittersToSpawn.Dispose();
			_biomeLookup.Dispose();
		}
		base.OnDestroy();
	}

	private static bool HasBiome(ulong biomes, Biome tag)
	{
		ulong num = (ulong)(1L << (int)tag);
		return (biomes & num) != 0;
	}

	[Preserve]
	protected override void OnUpdate()
	{
		if (_worldInfoSystem.WorldInfo.simulationDisabled || Manager.prefs.enemiesDisabled)
		{
			base.OnUpdate();
			return;
		}
		float deltaTime = base.CheckedStateRef.WorldUnmanaged.Time.DeltaTime;
		Unity.Mathematics.Random rng = PugRandom.GetRng();
		EntityCommandBuffer ecb = CreateCommandBuffer();
		BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal = database;
		CollisionWorld collisionWorld = GetPhysicsWorld().CollisionWorld;
		TileAccessor tileLookup = CreateTileAccessor();
		NativeList<CritterSpawnObject> crittersToSpawn = _crittersToSpawn;
		NativeList<LocalTransform> playerPositions = new NativeList<LocalTransform>(base.World.UpdateAllocator.ToAllocator);
		BiomeLookup biomeLookup = _biomeLookup;
		BufferLookup<SummarizedConditionsBuffer> bufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferLookup, ref base.CheckedStateRef);
		SpawnAroundEntitySystem_5A923F29_LambdaJob_0_Execute(playerPositions);
		SpawnAroundEntitySystem_5A923F29_LambdaJob_1_Execute(deltaTime, rng, ecb, databaseLocal, collisionWorld, tileLookup, crittersToSpawn, playerPositions, biomeLookup, bufferLookup);
		SpawnAroundEntitySystem_5A923F29_LambdaJob_2_Execute(deltaTime, ecb);
		base.OnUpdate();
	}

	private void SpawnAroundEntitySystem_5A923F29_LambdaJob_0_Execute(NativeList<LocalTransform> playerPositions)
	{
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		SpawnAroundEntitySystem_5A923F29_LambdaJob_0_Job jobData = new SpawnAroundEntitySystem_5A923F29_LambdaJob_0_Job
		{
			playerPositions = playerPositions,
			__transformTypeHandle = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle
		};
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_1625070027_0, base.CheckedStateRef.Dependency);
	}

	private void SpawnAroundEntitySystem_5A923F29_LambdaJob_1_Execute(float deltaTime, Unity.Mathematics.Random rng, EntityCommandBuffer ecb, BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal, CollisionWorld collisionWorld, TileAccessor tileLookup, NativeList<CritterSpawnObject> crittersToSpawnLocal, NativeList<LocalTransform> playerPositions, BiomeLookup biomeLookup, BufferLookup<SummarizedConditionsBuffer> conditionsBufferLookup)
	{
		__TypeHandle.__SpawnEntitiesAroundEntityCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Entities_Disabled_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__HealthCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__CritterCD_RW_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__IsPersistentCritterCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__ObjectDataCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		SpawnAroundEntitySystem_5A923F29_LambdaJob_1_Job jobData = new SpawnAroundEntitySystem_5A923F29_LambdaJob_1_Job
		{
			deltaTime = deltaTime,
			rng = rng,
			ecb = ecb,
			databaseLocal = databaseLocal,
			collisionWorld = collisionWorld,
			tileLookup = tileLookup,
			crittersToSpawnLocal = crittersToSpawnLocal,
			playerPositions = playerPositions,
			biomeLookup = biomeLookup,
			conditionsBufferLookup = conditionsBufferLookup,
			__spawnerTypeHandle = __TypeHandle.__SpawnEntitiesAroundEntityCD_RW_ComponentTypeHandle,
			__Unity_Transforms_LocalTransform_ComponentLookup = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup,
			__Unity_Entities_Disabled_ComponentLookup = __TypeHandle.__Unity_Entities_Disabled_RO_ComponentLookup,
			__HealthCD_ComponentLookup = __TypeHandle.__HealthCD_RO_ComponentLookup,
			__CritterCD_ComponentLookup = __TypeHandle.__CritterCD_RW_ComponentLookup,
			__IsPersistentCritterCD_ComponentLookup = __TypeHandle.__IsPersistentCritterCD_RO_ComponentLookup,
			__ObjectDataCD_ComponentLookup = __TypeHandle.__ObjectDataCD_RO_ComponentLookup
		};
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_1625070027_1, base.CheckedStateRef.Dependency);
	}

	private void SpawnAroundEntitySystem_5A923F29_LambdaJob_2_Execute(float deltaTime, EntityCommandBuffer ecb)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__CritterCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		SpawnAroundEntitySystem_5A923F29_LambdaJob_2_Job jobData = new SpawnAroundEntitySystem_5A923F29_LambdaJob_2_Job
		{
			deltaTime = deltaTime,
			ecb = ecb,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__critterTypeHandle = __TypeHandle.__CritterCD_RW_ComponentTypeHandle
		};
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_1625070027_2, base.CheckedStateRef.Dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlayerGhost>();
		__query_1625070027_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<SpawnEntitiesAroundEntityCD>();
		__query_1625070027_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithNone<IsPersistentCritterCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<CritterCD>();
		__query_1625070027_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAny<BiomeRangesCD, BiomeSamplesCD>();
		__query_1625070027_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeSamplesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1625070027_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeRangesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1625070027_5 = entityQueryBuilder2.Build(ref state);
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
	public SpawnAroundEntitySystem()
	{
	}
}
