using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PlayerState;
using Pug.Automation;
using Pug.Properties;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;

[BurstCompile]
[UpdateAfter(typeof(SetEntitiesDestroyedSystem))]
[UpdateBefore(typeof(DropLootSystem))]
[UpdateInGroup(typeof(PredictedSimulationSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public struct ExplosiveSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[BurstCompile]
	private struct ExplodeJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ObjectPropertiesCD> __Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectPropertiesCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectPropertiesCD>();
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
			public void Run(ref ExplodeJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref ExplodeJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref ExplodeJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref ExplodeJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref ExplodeJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref ExplodeJob job, EntityManager entityManager)
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

		[ReadOnly]
		public ComponentLookup<ElectricityCD> electricityLookup;

		[ReadOnly]
		public ComponentLookup<ProximityTriggerCD> proximityTriggerLookup;

		[ReadOnly]
		public ComponentLookup<ExplosionCD> explosionLookup;

		[ReadOnly]
		public BufferLookup<LevelEntitiesBuffer> levelEntitiesLookup;

		[ReadOnly]
		public ComponentLookup<LevelCD> levelLookup;

		[ReadOnly]
		public ComponentLookup<OwnerReferenceCD> ownerLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionEffectsBuffer> summarizedConditionsEffectsBufferLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionsBuffer> summarizedConditionsBufferLookup;

		[ReadOnly]
		public ComponentLookup<ProjectileSourceCD> projectileSourceLookup;

		[ReadOnly]
		public ComponentLookup<GhostOwner> ghostOwnerLookup;

		[ReadOnly]
		public ComponentLookup<IsExplosiveCD> isExplosiveLookup;

		[ReadOnly]
		public ComponentLookup<GroundBouncableProjectileCD> groundBouncableProjectileLookup;

		[ReadOnly]
		public ComponentLookup<FactionCD> factionLookup;

		[ReadOnly]
		public ComponentLookup<GodModeCD> godModeLookup;

		[ReadOnly]
		public ComponentLookup<KilledByPlayerCD> killedByPlayerLookup;

		[ReadOnly]
		public ComponentLookup<DirectionCD> directionLookup;

		[ReadOnly]
		public ComponentLookup<DestroyTimerCD> destroyTimerLookup;

		[ReadOnly]
		public ComponentLookup<CurrentBiomeCD> currentBiomeLookup;

		public ComponentLookup<ObjectDataCD> objectDataLookup;

		public ComponentLookup<DontDropSelfCD> dontDropSelfLookup;

		public ComponentLookup<DontDropLootCD> dontDropLootLookup;

		public ComponentLookup<HasExplodedCD> hasExplodedLookup;

		public ComponentLookup<RandomCD> randomLookup;

		public ComponentLookup<ManaCD> manaLookup;

		public BufferLookup<GhostEffectEventBuffer> ghostEffectEventBufferLookup;

		public ComponentLookup<GhostEffectEventBufferPointerCD> ghostEffectEventBufferPointerLookup;

		public EntityCommandBuffer ecb;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		public bool IsFirstTimeFullyPredictingTick;

		public NetworkTick currentTick;

		public uint tickRate;

		public TileAccessor tileAccessor;

		public FishingTableCD fishingTableCD;

		public LootTableBankCD lootTableBank;

		public CollisionWorld collisionWorld;

		public bool isServer;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in LocalTransform transform, in ObjectPropertiesCD properties)
		{
			IsExplosiveCD isExplosiveCD = isExplosiveLookup[entity];
			hasExplodedLookup.SetComponentEnabled(entity, value: true);
			if (isExplosiveCD.ignoreExploding)
			{
				return;
			}
			if (groundBouncableProjectileLookup.TryGetComponent(entity, out var componentData))
			{
				if (!componentData.CanExplode(currentTick, tickRate))
				{
					if (ghostEffectEventBufferLookup.TryGetBuffer(entity, out var bufferData))
					{
						ghostEffectEventBufferPointerLookup.TryGetComponent(entity, out var componentData2);
						DynamicBuffer<GhostEffectEventBuffer> buffer = bufferData;
						GhostEffectEventBuffer item = new GhostEffectEventBuffer
						{
							Tick = currentTick,
							value = new EffectEventCD
							{
								effectID = EffectID.EchoExplosion,
								position1 = transform.Position
							}
						};
						buffer.AddToRingBuffer(ref componentData2, in item);
					}
					return;
				}
				if (componentData.fallingInWater)
				{
					CreateFishLootFromExplosion(entity, in transform);
				}
			}
			ProximityTriggerCD componentData5;
			KilledByPlayerCD componentData6;
			if (electricityLookup.TryGetComponent(entity, out var componentData3) && !componentData3.hasEnoughElectricityToPowerStuff && !isExplosiveCD.wasKilledByAnotherExplosive)
			{
				if (dontDropSelfLookup.HasComponent(entity) && (!killedByPlayerLookup.TryGetComponent(entity, out var componentData4) || !godModeLookup.HasAndIsComponentEnabled(componentData4.playerEntity)))
				{
					dontDropSelfLookup.SetComponentEnabled(entity, value: false);
				}
				if (dontDropLootLookup.HasComponent(entity))
				{
					dontDropLootLookup.SetComponentEnabled(entity, value: false);
				}
			}
			else if (proximityTriggerLookup.TryGetComponent(entity, out componentData5) && !isExplosiveCD.wasKilledByAnotherExplosive && !componentData5.explodedFromTrigger && killedByPlayerLookup.TryGetComponent(entity, out componentData6) && killedByPlayerLookup.IsComponentEnabled(entity))
			{
				if (dontDropSelfLookup.HasComponent(entity) && !godModeLookup.HasAndIsComponentEnabled(componentData6.playerEntity))
				{
					dontDropSelfLookup.SetComponentEnabled(entity, value: false);
				}
				if (dontDropLootLookup.HasComponent(entity))
				{
					dontDropLootLookup.SetComponentEnabled(entity, value: false);
				}
			}
			else
			{
				ObjectDataCD objectDataCD = objectDataLookup[entity];
				ProjectileSourceCD componentData7;
				bool flag = projectileSourceLookup.TryGetComponent(entity, out componentData7);
				GetLevelAndDamage(entity, flag, isExplosiveCD, componentData7, objectDataCD, levelLookup, levelEntitiesLookup, isExplosiveLookup, out var level, out var damage, out var tileDamage);
				directionLookup.TryGetComponent(entity, out var componentData8);
				CreateExplosion(entity, transform.Position, isExplosiveCD.explosionID, isExplosiveCD.explosionVariation, ecb, damage, tileDamage, level, canSalvage: true, isExplosiveCD, objectDataCD, componentData7, properties, flag, databaseBankCD, explosionLookup, ownerLookup, manaLookup, factionLookup, ghostOwnerLookup, randomLookup, destroyTimerLookup, summarizedConditionsBufferLookup, summarizedConditionsEffectsBufferLookup, directionLookup, componentData8.direction, 0.1f, tickRate, currentTick, !flag, IsFirstTimeFullyPredictingTick);
			}
		}

		private void CreateFishLootFromExplosion(Entity entity, in LocalTransform localTransform)
		{
			RefRW<RandomCD> refRWOptional = randomLookup.GetRefRWOptional(entity);
			if (!refRWOptional.IsValid || !ownerLookup.TryGetComponent(entity, out var componentData) || !currentBiomeLookup.TryGetComponent(componentData.owner, out var componentData2) || !summarizedConditionsBufferLookup.HasBuffer(componentData.owner))
			{
				return;
			}
			float3 position = localTransform.Position;
			int2 worldPosition = localTransform.Position.RoundToInt2();
			Tileset tileset = (Tileset)tileAccessor.GetTop(worldPosition).tileset;
			fishingTableCD.GetFishingStats(tileset, componentData2.biome, out var fishingInfo, out var _);
			float num = (float)EntityUtility.GetConditionValue(ConditionID.IncreasedChanceToGetFish, componentData.owner, summarizedConditionsBufferLookup) / 100f;
			num -= (float)EntityUtility.GetConditionValue(ConditionID.IncreasedChanceToGetFishLoot, componentData.owner, summarizedConditionsBufferLookup) / 100f;
			Entity entity2 = Entity.Null;
			NativeList<ColliderCastHit> outHits = new NativeList<ColliderCastHit>(Allocator.Temp);
			CollisionFilter filter = new CollisionFilter
			{
				BelongsTo = 2u,
				CollidesWith = 8192u
			};
			if (collisionWorld.SphereCastAll(position + new float3(0f, 2f, 0f), 0.5f, new float3(0f, -1f, 0f), 3f, ref outHits, filter))
			{
				for (int i = 0; i < outHits.Length; i++)
				{
					ColliderCastHit colliderCastHit = outHits[i];
					if (objectDataLookup.TryGetComponent(colliderCastHit.Entity, out var componentData3) && componentData3.objectID == ObjectID.FishShoal)
					{
						entity2 = colliderCastHit.Entity;
					}
				}
			}
			Fishing.CatchFishFromShoal(entity2, ecb, objectDataLookup, randomLookup, isServer);
			bool num2 = entity2 != Entity.Null;
			int num3 = refRWOptional.ValueRW.Value.NextInt(0, 2);
			if (num3 > 0 && refRWOptional.ValueRW.Value.NextFloat() < num + 0.4f)
			{
				num3++;
			}
			if (num2)
			{
				num3++;
			}
			bool flag = false;
			for (int j = 0; j < num3; j++)
			{
				int amount = 1;
				float num4 = (float)EntityUtility.GetConditionValue(ConditionID.ChanceToGetDoubleFish, componentData.owner, summarizedConditionsBufferLookup) / 100f;
				if (randomLookup.GetRefRW(entity).ValueRW.Value.NextFloat() < num4)
				{
					amount = 2;
				}
				Rarity minimumRarity = Rarity.Poor;
				float num5 = (float)EntityUtility.GetConditionValue(ConditionID.IncreasedChanceForHigherRarityFish, componentData.owner, summarizedConditionsBufferLookup) / 100f;
				if (refRWOptional.ValueRW.Value.NextFloat() < num5)
				{
					minimumRarity = Rarity.Uncommon;
				}
				using NativeList<PugDatabase.EntityLootData> nativeList = PugDatabase.GetRandomLoot(fishingInfo.fishLootTableID, ref refRWOptional.ValueRW.Value, lootTableBank.Value, databaseBankCD.databaseBankBlob, componentData2.biome, 1f, minimumRarity);
				if (nativeList.Length != 0)
				{
					float3 float5 = localTransform.Position + refRWOptional.ValueRW.Value.NextFloat2Direction().ToFloat3() * refRWOptional.ValueRW.Value.NextFloat(0f, 2f);
					if (tileAccessor.GetTop(float5.RoundToInt2()).tileType != TileType.water)
					{
						float5 = localTransform.Position;
					}
					if (IsFirstTimeFullyPredictingTick)
					{
						EntityUtility.CreateAndDropItem(nativeList[0].objectID, 0, amount, float5, componentData.owner, databaseBankCD.databaseBankBlob, ecb);
						flag = true;
					}
				}
			}
			if (flag)
			{
				PlayerController.AddSkill(componentData.owner, SkillID.Fishing, 1, ecb, isServer);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr3, i));
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
						Entity entity2 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, nextRangeBegin);
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr3, nextRangeBegin));
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
					Entity entity3 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j);
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr3, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity4 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k);
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr3, k));
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

	[BurstCompile]
	[WithChangeFilter(new Type[] { typeof(ElectricityCD) })]
	[WithOptions(EntityQueryOptions.IncludeDisabledEntities)]
	[WithAll(new Type[] { typeof(IsExplosiveCD) })]
	[WithNone(new Type[] { typeof(HasExplodedCD) })]
	private struct TriggerExplosivesByElectricityJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<HealthCD> __HealthCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<IsExplosiveCD> __IsExplosiveCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ElectricityCD> __Pug_Automation_ElectricityCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__HealthCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<HealthCD>();
					__IsExplosiveCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<IsExplosiveCD>(isReadOnly: true);
					__Pug_Automation_ElectricityCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ElectricityCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__HealthCD_RW_ComponentTypeHandle.Update(ref state);
					__IsExplosiveCD_RO_ComponentTypeHandle.Update(ref state);
					__Pug_Automation_ElectricityCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<HasExplodedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<IsExplosiveCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ElectricityCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<HealthCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
				DefaultQuery = entityQueryBuilder2.Build(ref state);
				entityQueryBuilder.Reset();
				DefaultQuery.SetChangedVersionFilter(new ComponentType[1]
				{
					new ComponentType(typeof(ElectricityCD))
				});
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
			public void Run(ref TriggerExplosivesByElectricityJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref TriggerExplosivesByElectricityJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref TriggerExplosivesByElectricityJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref TriggerExplosivesByElectricityJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref TriggerExplosivesByElectricityJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref TriggerExplosivesByElectricityJob job, EntityManager entityManager)
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

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref HealthCD health, in IsExplosiveCD isExplosiveCD, in ElectricityCD electricity)
		{
			if (electricity.hasEnoughElectricityToPowerStuff)
			{
				health.health = 0;
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__HealthCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__IsExplosiveCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Automation_ElectricityCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<IsExplosiveCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityCD>(nativeArrayPtr4, i));
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
						Entity entity2 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, nextRangeBegin);
						Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<IsExplosiveCD>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityCD>(nativeArrayPtr4, nextRangeBegin));
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
					Entity entity3 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j);
					Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<IsExplosiveCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityCD>(nativeArrayPtr4, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity4 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k);
					Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<IsExplosiveCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityCD>(nativeArrayPtr4, k));
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

	[BurstCompile]
	[WithAll(new Type[]
	{
		typeof(IsExplosiveCD),
		typeof(Simulate)
	})]
	private struct SequencedExplosionsJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				public ComponentTypeHandle<SequenceExplosiveCD> __SequenceExplosiveCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ObjectDataCD> __ObjectDataCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ObjectPropertiesCD> __Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__SequenceExplosiveCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<SequenceExplosiveCD>();
					__ObjectDataCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectDataCD>(isReadOnly: true);
					__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectPropertiesCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__SequenceExplosiveCD_RW_ComponentTypeHandle.Update(ref state);
					__ObjectDataCD_RO_ComponentTypeHandle.Update(ref state);
					__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectDataCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectPropertiesCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<IsExplosiveCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SequenceExplosiveCD>();
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
			public void Run(ref SequencedExplosionsJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref SequencedExplosionsJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref SequencedExplosionsJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref SequencedExplosionsJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref SequencedExplosionsJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref SequencedExplosionsJob job, EntityManager entityManager)
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

		public PugDatabase.DatabaseBankCD databaseBankCD;

		private float3 castDirection;

		public BufferLookup<AnimationBuffer> animationBufferLookup;

		public ComponentLookup<AnimationBufferPointer> animationBufferPointerLookup;

		[ReadOnly]
		public ComponentLookup<DirectionCD> directionLookup;

		public ComponentLookup<RandomCD> randomLookup;

		[ReadOnly]
		public ComponentLookup<GhostOwner> ghostOwnerLookup;

		[ReadOnly]
		public ComponentLookup<IsExplosiveCD> isExplosiveLookup;

		[ReadOnly]
		public ComponentLookup<ExplosionCD> explosionLookup;

		[ReadOnly]
		public ComponentLookup<OwnerReferenceCD> ownerLookup;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> destroyedLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionEffectsBuffer> summarizedConditionsEffectsBufferLookup;

		[ReadOnly]
		public ComponentLookup<FactionCD> factionLookup;

		[ReadOnly]
		public BufferLookup<LevelEntitiesBuffer> levelEntitiesLookup;

		[ReadOnly]
		public ComponentLookup<LevelCD> levelLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionsBuffer> summarizedConditionsBufferLookup;

		[ReadOnly]
		public ComponentLookup<ProjectileSourceCD> projectileSourceLookup;

		[ReadOnly]
		public ComponentLookup<DestroyTimerCD> destroyTimerLookup;

		[ReadOnly]
		public ComponentLookup<MortarProjectileCD> mortarProjectileLookup;

		public ComponentLookup<ManaCD> manaLookup;

		public bool isFirstTimeFullyPredictingTick;

		public NetworkTick currentTick;

		public uint tickRate;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in LocalTransform transform, ref SequenceExplosiveCD sequenceExplosive, in ObjectDataCD objectDataCD, in ObjectPropertiesCD properties)
		{
			ref SequenceExplosiveBlobData value = ref sequenceExplosive.sequenceExplosiveData.Value;
			if (sequenceExplosive.hasSpawnedCharges || (value.triggerOnDeath && !destroyedLookup.IsComponentEnabled(entity)) || (sequenceExplosive.internalTimer.isRunning && !sequenceExplosive.internalTimer.IsTimerElapsed(currentTick)) || (mortarProjectileLookup.TryGetComponent(entity, out var componentData) && (int)componentData.internalState < 4))
			{
				return;
			}
			if (!sequenceExplosive.internalTimer.isRunning)
			{
				sequenceExplosive.internalTimer.Start(currentTick, value.beforeAnimationInitialDelay, tickRate);
				return;
			}
			if (animationBufferLookup.TryGetBuffer(entity, out var bufferData) && animationBufferPointerLookup.HasComponent(entity))
			{
				RefRW<AnimationBufferPointer> refRW = animationBufferPointerLookup.GetRefRW(entity);
				AnimationUtilities.TriggerAnimation(1490946511, currentTick, bufferData, ref refRW.ValueRW);
			}
			ProjectileSourceCD componentData2;
			bool flag = projectileSourceLookup.TryGetComponent(entity, out componentData2);
			IsExplosiveCD isExplosiveCD = isExplosiveLookup[entity];
			float3 float5 = new float3(1f, 0f, 0f);
			if (value.useDirection && directionLookup.TryGetComponent(entity, out var componentData3))
			{
				float5 = componentData3.direction;
			}
			float3 v257 = float5;
			ref RandomCD valueRW = ref randomLookup.GetRefRW(entity).ValueRW;
			ref BlobArray<SequenceChargeBlobData> value2 = ref sequenceExplosive.sequenceChargesData.Value;
			sbyte b = sbyte.MaxValue;
			if (componentData2.sequenceExplosionTotalExplosions >= 0 && properties.Has(1743293565))
			{
				b = componentData2.sequenceExplosionTotalExplosions;
			}
			float num = value.animationInitialDelay;
			float num2 = 0f;
			for (int i = 0; i < value2.Length; i++)
			{
				if (b <= 0)
				{
					break;
				}
				ref SequenceChargeBlobData reference = ref value2[i];
				num += reference.delayFromPrevious;
				num2 += reference.spreadFromPreviousDistance;
				switch (reference.directionType)
				{
				case SequenceExplosionChargeDirectionType.Base:
					v257 = float5;
					break;
				case SequenceExplosionChargeDirectionType.Random:
					v257 = valueRW.Value.NextFloat2Direction().ToFloat3();
					break;
				}
				int num3 = math.min(reference.amountToSpawn, b);
				if (num3 != 0)
				{
					float num4 = MathF.PI * 2f / (float)num3;
					for (int j = 0; j < num3; j++)
					{
						float3 float6 = math.mul(quaternion.RotateY(num4 * (float)j + reference.offsetRadians), v257);
						GetLevelAndDamage(entity, flag, isExplosiveCD, componentData2, objectDataCD, levelLookup, levelEntitiesLookup, isExplosiveLookup, out var level, out var damage, out var tileDamage);
						bool canSalvage = i == 0;
						CreateExplosion(entity, transform.Position + float6 * num2, reference.explosionID, reference.explosionVariation, ecb, damage, tileDamage, level, canSalvage, isExplosiveCD, objectDataCD, componentData2, properties, flag, databaseBankCD, explosionLookup, ownerLookup, manaLookup, factionLookup, ghostOwnerLookup, randomLookup, destroyTimerLookup, summarizedConditionsBufferLookup, summarizedConditionsEffectsBufferLookup, directionLookup, float6, num, tickRate, currentTick, !flag, isFirstTimeFullyPredictingTick);
						b--;
					}
				}
			}
			sequenceExplosive.hasSpawnedCharges = true;
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__SequenceExplosiveCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SequenceExplosiveCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr4, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr5, i));
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
						Entity entity2 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, nextRangeBegin);
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SequenceExplosiveCD>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr4, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr5, nextRangeBegin));
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
					Entity entity3 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j);
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SequenceExplosiveCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr4, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr5, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity4 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k);
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SequenceExplosiveCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr4, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr5, k));
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

	[BurstCompile]
	[WithAll(new Type[]
	{
		typeof(IsExplosiveCD),
		typeof(Simulate)
	})]
	[WithNone(new Type[] { typeof(HasExplodedCD) })]
	private struct ProximityExplosionCheck : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				public ComponentTypeHandle<ProximityTriggerCD> __ProximityTriggerCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<HealthCD> __HealthCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__ProximityTriggerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ProximityTriggerCD>();
					__HealthCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<HealthCD>();
					__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
					__AnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__ProximityTriggerCD_RW_ComponentTypeHandle.Update(ref state);
					__HealthCD_RW_ComponentTypeHandle.Update(ref state);
					__AnimationBuffer_RW_BufferTypeHandle.Update(ref state);
					__AnimationBufferPointer_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<HasExplodedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<IsExplosiveCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ProximityTriggerCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<HealthCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
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
			public void Run(ref ProximityExplosionCheck job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref ProximityExplosionCheck job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref ProximityExplosionCheck job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref ProximityExplosionCheck job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref ProximityExplosionCheck job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref ProximityExplosionCheck job, EntityManager entityManager)
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

		[ReadOnly]
		public ComponentLookup<FactionCD> FactionLookup;

		[ReadOnly]
		public WorldInfoCD worldInfo;

		[ReadOnly]
		public ComponentLookup<EnemyCD> EnemyLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhost> PlayerLookup;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> EntityDestroyedLookup;

		[ReadOnly]
		public ComponentLookup<EnemyActAsDestructibleCD> EnemyActAsDestructibleLookup;

		[ReadOnly]
		public CollisionWorld CollisionWorld;

		public double time;

		public NetworkTick currentTick;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		[BurstCompile]
		private void Execute(Entity entity, in LocalTransform transform, ref ProximityTriggerCD proximityTriggerCD, ref HealthCD healthCD, DynamicBuffer<AnimationBuffer> animationBuffer, ref AnimationBufferPointer animationBufferPointer)
		{
			if (!proximityTriggerCD.internalTimer.isRunning)
			{
				FactionLookup.TryGetComponent(entity, out var componentData);
				CollisionFilter filter = new CollisionFilter
				{
					BelongsTo = uint.MaxValue,
					CollidesWith = 29u
				};
				NativeList<DistanceHit> outHits = new NativeList<DistanceHit>(Allocator.Temp);
				if (CollisionWorld.OverlapSphere(transform.Position, proximityTriggerCD.radius, ref outHits, filter))
				{
					for (int i = 0; i < outHits.Length; i++)
					{
						Entity entity2 = outHits[i].Entity;
						if (!(entity2 == entity))
						{
							FactionLookup.TryGetComponent(entity2, out var componentData2);
							if (componentData.CanAttack(componentData2, worldInfo) && (EnemyLookup.HasComponent(entity2) || PlayerLookup.HasComponent(entity2) || EnemyActAsDestructibleLookup.HasComponent(entity2)) && (!EntityDestroyedLookup.HasComponent(entity2) || !EntityDestroyedLookup.IsComponentEnabled(entity2)))
							{
								AnimationUtilities.TriggerAnimation(-1225259135, currentTick, animationBuffer, ref animationBufferPointer);
								proximityTriggerCD.internalTimer.Start(time, proximityTriggerCD.delayTime);
								break;
							}
						}
					}
				}
			}
			if (proximityTriggerCD.internalTimer.isRunning && proximityTriggerCD.internalTimer.IsTimerElapsed(time))
			{
				proximityTriggerCD.explodedFromTrigger = true;
				healthCD.health = 0;
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__ProximityTriggerCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__HealthCD_RW_ComponentTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref LocalTransform transform = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, i);
					ref ProximityTriggerCD proximityTriggerCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProximityTriggerCD>(nativeArrayPtr3, i);
					ref HealthCD healthCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr4, i);
					DynamicBuffer<AnimationBuffer> animationBuffer = bufferAccessor[i];
					Execute(entity, in transform, ref proximityTriggerCD, ref healthCD, animationBuffer, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr5, i));
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
						Entity entity2 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, nextRangeBegin);
						ref LocalTransform transform2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, nextRangeBegin);
						ref ProximityTriggerCD proximityTriggerCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProximityTriggerCD>(nativeArrayPtr3, nextRangeBegin);
						ref HealthCD healthCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr4, nextRangeBegin);
						DynamicBuffer<AnimationBuffer> animationBuffer2 = bufferAccessor[nextRangeBegin];
						Execute(entity2, in transform2, ref proximityTriggerCD2, ref healthCD2, animationBuffer2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr5, nextRangeBegin));
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
					Entity entity3 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j);
					ref LocalTransform transform3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, j);
					ref ProximityTriggerCD proximityTriggerCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProximityTriggerCD>(nativeArrayPtr3, j);
					ref HealthCD healthCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr4, j);
					DynamicBuffer<AnimationBuffer> animationBuffer3 = bufferAccessor[j];
					Execute(entity3, in transform3, ref proximityTriggerCD3, ref healthCD3, animationBuffer3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr5, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity4 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k);
					ref LocalTransform transform4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, k);
					ref ProximityTriggerCD proximityTriggerCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProximityTriggerCD>(nativeArrayPtr3, k);
					ref HealthCD healthCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr4, k);
					DynamicBuffer<AnimationBuffer> animationBuffer4 = bufferAccessor[k];
					Execute(entity4, in transform4, ref proximityTriggerCD4, ref healthCD4, animationBuffer4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr5, k));
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
		public TriggerExplosivesByElectricityJob.InternalCompilerQueryAndHandleData __ExplosiveSystem_TriggerExplosivesByElectricityJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<ElectricityCD> __Pug_Automation_ElectricityCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ProximityTriggerCD> __ProximityTriggerCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ExplosionCD> __ExplosionCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<LevelEntitiesBuffer> __LevelEntitiesBuffer_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<LevelCD> __LevelCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<OwnerReferenceCD> __OwnerReferenceCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionEffectsBuffer> __SummarizedConditionEffectsBuffer_RO_BufferLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<ProjectileSourceCD> __ProjectileSourceCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<GhostOwner> __Unity_NetCode_GhostOwner_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<IsExplosiveCD> __IsExplosiveCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<CurrentBiomeCD> __CurrentBiomeCD_RO_ComponentLookup;

		public ComponentLookup<DontDropSelfCD> __DontDropSelfCD_RW_ComponentLookup;

		public ComponentLookup<DontDropLootCD> __DontDropLootCD_RW_ComponentLookup;

		public ComponentLookup<HasExplodedCD> __HasExplodedCD_RW_ComponentLookup;

		public ComponentLookup<RandomCD> __RandomCD_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<GroundBouncableProjectileCD> __GroundBouncableProjectileCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<FactionCD> __FactionCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<GodModeCD> __GodModeCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<KilledByPlayerCD> __KilledByPlayerCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DirectionCD> __DirectionCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DestroyTimerCD> __DestroyTimerCD_RO_ComponentLookup;

		public ComponentLookup<ObjectDataCD> __ObjectDataCD_RW_ComponentLookup;

		public ComponentLookup<ManaCD> __ManaCD_RW_ComponentLookup;

		public BufferLookup<GhostEffectEventBuffer> __GhostEffectEventBuffer_RW_BufferLookup;

		public ComponentLookup<GhostEffectEventBufferPointerCD> __GhostEffectEventBufferPointerCD_RW_ComponentLookup;

		public ExplodeJob.InternalCompilerQueryAndHandleData __ExplosiveSystem_ExplodeJob_WithoutDefaultQuery_JobEntityTypeHandle;

		public BufferLookup<AnimationBuffer> __AnimationBuffer_RW_BufferLookup;

		public ComponentLookup<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<MortarProjectileCD> __MortarProjectileCD_RO_ComponentLookup;

		public SequencedExplosionsJob.InternalCompilerQueryAndHandleData __ExplosiveSystem_SequencedExplosionsJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<EnemyCD> __EnemyCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhost> __PlayerGhost_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<EnemyActAsDestructibleCD> __EnemyActAsDestructibleCD_RO_ComponentLookup;

		public ProximityExplosionCheck.InternalCompilerQueryAndHandleData __ExplosiveSystem_ProximityExplosionCheck_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__ExplosiveSystem_TriggerExplosivesByElectricityJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__Pug_Automation_ElectricityCD_RO_ComponentLookup = state.GetComponentLookup<ElectricityCD>(isReadOnly: true);
			__ProximityTriggerCD_RO_ComponentLookup = state.GetComponentLookup<ProximityTriggerCD>(isReadOnly: true);
			__ExplosionCD_RO_ComponentLookup = state.GetComponentLookup<ExplosionCD>(isReadOnly: true);
			__LevelEntitiesBuffer_RO_BufferLookup = state.GetBufferLookup<LevelEntitiesBuffer>(isReadOnly: true);
			__LevelCD_RO_ComponentLookup = state.GetComponentLookup<LevelCD>(isReadOnly: true);
			__OwnerReferenceCD_RO_ComponentLookup = state.GetComponentLookup<OwnerReferenceCD>(isReadOnly: true);
			__SummarizedConditionEffectsBuffer_RO_BufferLookup = state.GetBufferLookup<SummarizedConditionEffectsBuffer>(isReadOnly: true);
			__SummarizedConditionsBuffer_RO_BufferLookup = state.GetBufferLookup<SummarizedConditionsBuffer>(isReadOnly: true);
			__ProjectileSourceCD_RO_ComponentLookup = state.GetComponentLookup<ProjectileSourceCD>(isReadOnly: true);
			__Unity_NetCode_GhostOwner_RO_ComponentLookup = state.GetComponentLookup<GhostOwner>(isReadOnly: true);
			__IsExplosiveCD_RO_ComponentLookup = state.GetComponentLookup<IsExplosiveCD>(isReadOnly: true);
			__CurrentBiomeCD_RO_ComponentLookup = state.GetComponentLookup<CurrentBiomeCD>(isReadOnly: true);
			__DontDropSelfCD_RW_ComponentLookup = state.GetComponentLookup<DontDropSelfCD>();
			__DontDropLootCD_RW_ComponentLookup = state.GetComponentLookup<DontDropLootCD>();
			__HasExplodedCD_RW_ComponentLookup = state.GetComponentLookup<HasExplodedCD>();
			__RandomCD_RW_ComponentLookup = state.GetComponentLookup<RandomCD>();
			__GroundBouncableProjectileCD_RO_ComponentLookup = state.GetComponentLookup<GroundBouncableProjectileCD>(isReadOnly: true);
			__FactionCD_RO_ComponentLookup = state.GetComponentLookup<FactionCD>(isReadOnly: true);
			__GodModeCD_RO_ComponentLookup = state.GetComponentLookup<GodModeCD>(isReadOnly: true);
			__KilledByPlayerCD_RO_ComponentLookup = state.GetComponentLookup<KilledByPlayerCD>(isReadOnly: true);
			__DirectionCD_RO_ComponentLookup = state.GetComponentLookup<DirectionCD>(isReadOnly: true);
			__DestroyTimerCD_RO_ComponentLookup = state.GetComponentLookup<DestroyTimerCD>(isReadOnly: true);
			__ObjectDataCD_RW_ComponentLookup = state.GetComponentLookup<ObjectDataCD>();
			__ManaCD_RW_ComponentLookup = state.GetComponentLookup<ManaCD>();
			__GhostEffectEventBuffer_RW_BufferLookup = state.GetBufferLookup<GhostEffectEventBuffer>();
			__GhostEffectEventBufferPointerCD_RW_ComponentLookup = state.GetComponentLookup<GhostEffectEventBufferPointerCD>();
			__ExplosiveSystem_ExplodeJob_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
			__AnimationBuffer_RW_BufferLookup = state.GetBufferLookup<AnimationBuffer>();
			__AnimationBufferPointer_RW_ComponentLookup = state.GetComponentLookup<AnimationBufferPointer>();
			__EntityDestroyedCD_RO_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
			__MortarProjectileCD_RO_ComponentLookup = state.GetComponentLookup<MortarProjectileCD>(isReadOnly: true);
			__ExplosiveSystem_SequencedExplosionsJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__EnemyCD_RO_ComponentLookup = state.GetComponentLookup<EnemyCD>(isReadOnly: true);
			__PlayerGhost_RO_ComponentLookup = state.GetComponentLookup<PlayerGhost>(isReadOnly: true);
			__EnemyActAsDestructibleCD_RO_ComponentLookup = state.GetComponentLookup<EnemyActAsDestructibleCD>(isReadOnly: true);
			__ExplosiveSystem_ProximityExplosionCheck_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_00001E46_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_00001E46_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00001E46_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_00001E47_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00001E47_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00001E47_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnStartRunning_00001E48_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_00001E48_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_00001E48_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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

	private TileAccessor _tileAccessor;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1046339164_0;

	private EntityQuery __query_1046339164_1;

	private EntityQuery __query_1046339164_2;

	private EntityQuery __query_1046339164_3;

	private EntityQuery __query_1046339164_4;

	private EntityQuery __query_1046339164_5;

	private EntityQuery __query_1046339164_6;

	private EntityQuery __query_1046339164_7;

	private EntityQuery __query_1046339164_8;

	private EntityQuery __query_1046339164_9;

	private EntityQuery __query_1046339164_10;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void GetLevelAndDamage(Entity entity, bool explodeFromProjectile, IsExplosiveCD isExplosiveCD, ProjectileSourceCD projectileSourceCD, ObjectDataCD objectDataCD, ComponentLookup<LevelCD> levelLookup, BufferLookup<LevelEntitiesBuffer> levelEntitiesLookup, ComponentLookup<IsExplosiveCD> isExplosiveLookup, out int level, out float damage, out float tileDamage)
	{
		level = (explodeFromProjectile ? projectileSourceCD.weaponLevel : objectDataCD.variation);
		if (level == 0)
		{
			levelLookup.TryGetComponent(entity, out var componentData);
			level = componentData.level;
		}
		int maxLevel = LevelScaling.GetMaxLevel();
		level = math.min(maxLevel, level);
		damage = isExplosiveCD.damage;
		tileDamage = isExplosiveCD.tileDamage;
		if (levelEntitiesLookup.TryGetBuffer(entity, out var bufferData))
		{
			Entity entity2 = bufferData[level].entity;
			IsExplosiveCD componentData2;
			if (explodeFromProjectile && entity2 == Entity.Null)
			{
				UnityEngine.Debug.LogError("levelEntity is Null. Projectile likely needs to be marked with 'mayExplodeWithWindup.'");
			}
			else if (isExplosiveLookup.TryGetComponent(entity2, out componentData2))
			{
				damage = componentData2.damage;
				tileDamage = componentData2.tileDamage;
			}
		}
		else if (explodeFromProjectile)
		{
			UnityEngine.Debug.LogError("levelEntity is Null. Projectile likely needs to be marked with 'mayExplodeWithWindup.'");
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void CreateExplosion(Entity entity, float3 position, ObjectID explosionID, int explosionVariation, EntityCommandBuffer ecb, float damage, float tileDamage, int level, bool canSalvage, IsExplosiveCD isExplosiveCD, ObjectDataCD objectDataCD, ProjectileSourceCD projectileSourceCD, ObjectPropertiesCD properties, bool explodeFromProjectile, PugDatabase.DatabaseBankCD databaseBankCD, ComponentLookup<ExplosionCD> explosionLookup, ComponentLookup<OwnerReferenceCD> ownerLookup, ComponentLookup<ManaCD> manaLookup, ComponentLookup<FactionCD> factionLookup, ComponentLookup<GhostOwner> ghostOwnerLookup, ComponentLookup<RandomCD> randomLookup, ComponentLookup<DestroyTimerCD> destroyTimerLookup, BufferLookup<SummarizedConditionsBuffer> summarizedConditionsBufferLookup, BufferLookup<SummarizedConditionEffectsBuffer> summarizedConditionsEffectsBufferLookup, ComponentLookup<DirectionCD> directionLookup, float3 dir, float explosionDelay, uint tickRate, NetworkTick currentTick, bool cameFromBomb, bool isFirstTimeFullyPredictingTick)
	{
		if (!isFirstTimeFullyPredictingTick)
		{
			RefRW<RandomCD> refRWOptional = randomLookup.GetRefRWOptional(entity);
			if (summarizedConditionsBufferLookup.TryGetBuffer(entity, out var _))
			{
				refRWOptional.ValueRW.Value.NextFloat();
				refRWOptional.ValueRW.Value.NextFloat();
			}
			PugRandom.InheritRngFromEntity(ref refRWOptional.ValueRW.Value);
			return;
		}
		Entity prefabEntity;
		Entity entity2 = EntityUtility.CreateEntity(ecb, position, explosionID, 1, databaseBankCD.databaseBankBlob, out prefabEntity, explosionVariation);
		if (!explosionLookup.TryGetComponent(prefabEntity, out var componentData))
		{
			return;
		}
		Entity entity3 = Entity.Null;
		if (entity3 == Entity.Null && ownerLookup.TryGetComponent(entity, out var componentData2))
		{
			entity3 = componentData2.owner;
		}
		float num = 1f;
		float num2 = 1f;
		float num3 = ((explodeFromProjectile && properties.Has(885676563)) ? 0.3f : 1f);
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		int napalmIncreasedBurningDamagePercentage = 0;
		if (entity3 != Entity.Null)
		{
			ecb.SetComponent(entity2, new OwnerReferenceCD
			{
				owner = entity3
			});
			if (isExplosiveCD.explosionInheritsFaction && factionLookup.HasComponent(prefabEntity))
			{
				EntityUtility.InheritFaction(ecb, entity3, entity2, factionLookup);
			}
			if (ghostOwnerLookup.HasComponent(prefabEntity) && ghostOwnerLookup.TryGetComponent(entity3, out var componentData3))
			{
				ecb.SetComponent(entity2, componentData3);
			}
			if (summarizedConditionsBufferLookup.TryGetBuffer(entity3, out var bufferData2))
			{
				int value = bufferData2[310].value;
				if (value > 0)
				{
					PlayerController.ApplyPlayerManaChange(in entity3, in manaLookup, value);
				}
				int value2 = bufferData2[312].value;
				if (value2 > 0)
				{
					EntityUtility.AddNewCondition(entity3, ecb, new ConditionData
					{
						conditionID = ConditionID.MeleeDamageIncrease,
						duration = 2f,
						value = value2 * 10
					});
				}
			}
		}
		else
		{
			ecb.SetComponent(entity2, new OwnerReferenceCD
			{
				owner = entity
			});
		}
		if (summarizedConditionsEffectsBufferLookup.TryGetBuffer(entity, out var bufferData3))
		{
			num = 1f + (float)bufferData3[46].value / 100f;
			if (explodeFromProjectile && projectileSourceCD.shotFromReinforcedWeapon)
			{
				num *= 1.15f;
				num2 *= 1.15f;
			}
			float num4 = (float)bufferData3[120].value / 100f;
			componentData.radius += componentData.radius * num4;
		}
		if (summarizedConditionsBufferLookup.TryGetBuffer(entity, out var bufferData4))
		{
			RefRW<RandomCD> refRWOptional2 = randomLookup.GetRefRWOptional(entity);
			flag = refRWOptional2.ValueRW.Value.NextFloat() < (float)bufferData4[306].value / 100f;
			flag2 = refRWOptional2.ValueRW.Value.NextFloat() < (float)bufferData4[313].value / 100f;
			flag3 = bufferData4[346].value != 0;
			napalmIncreasedBurningDamagePercentage = bufferData4[314].value + math.sign(bufferData4[16].value * bufferData4[345].value);
			EntityUtility.InheritConditionsForExplosion(ecb, entity, entity2, summarizedConditionsBufferLookup);
		}
		if (destroyTimerLookup.TryGetComponent(prefabEntity, out var componentData4))
		{
			componentData4.timer.targetTicks += NetworkTimeUtilities.SecondsToTicks(explosionDelay, tickRate);
			ecb.SetComponent(entity2, componentData4);
		}
		componentData.damage = (int)math.round(num * num3 * damage);
		componentData.tileDamage = (int)math.round(num2 * num3 * tileDamage);
		componentData.delayTimer.Start(currentTick, explosionDelay, tickRate);
		componentData.triggerEntityToIgnoreExplosionDamage = entity;
		componentData.nonSyncedTriggerEntityToIgnoreExplosionDamage = entity;
		componentData.level = level;
		componentData.spawnNapalmObjectID = (flag2 ? ObjectID.Napalm : ObjectID.None);
		componentData.spawnNapalmVariation = (isExplosiveCD.useSmallNapalmVariant ? 1 : 0);
		componentData.napalmIncreasedBurningDamagePercentage = napalmIncreasedBurningDamagePercentage;
		componentData.cameFromExplosive = true;
		componentData.cameFromBomb = cameFromBomb;
		componentData.explosionPushback = isExplosiveCD.explosionPushback;
		ecb.SetComponent(entity2, componentData);
		RefRW<RandomCD> refRWOptional3 = randomLookup.GetRefRWOptional(entity);
		if (!refRWOptional3.IsValid)
		{
			UnityEngine.Debug.LogError($"Missing RandomCD for entity: {entity.Index} in GetDamageInfo");
		}
		ecb.SetComponent(entity2, new RandomCD
		{
			Value = PugRandom.InheritRngFromEntity(ref refRWOptional3.ValueRW.Value)
		});
		if (flag3)
		{
			ConditionsTableCD conditionsTable = default(ConditionsTableCD);
			ComponentLookup<BehaviourTagsCD> behaviourTagsLookup = default(ComponentLookup<BehaviourTagsCD>);
			RefRW<RandomCD> refRWOptional4 = randomLookup.GetRefRWOptional(entity);
			EntityUtility.SpawnExplosion(ecb, position, databaseBankCD.databaseBankBlob, ObjectID.OilExplosion, 0, 0, entity, 2f, conditionsTable, ref refRWOptional4.ValueRW.Value, factionLookup, behaviourTagsLookup, summarizedConditionsBufferLookup, summarizedConditionsEffectsBufferLookup);
		}
		if (directionLookup.HasComponent(prefabEntity))
		{
			ecb.SetComponent(entity2, new DirectionCD
			{
				direction = dir
			});
		}
		if (!(flag && canSalvage))
		{
			return;
		}
		ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(objectDataCD.objectID, databaseBankCD.databaseBankBlob);
		for (int i = 0; i < entityObjectInfo.requiredObjectsToCraft.Length; i++)
		{
			ObjectWithAmount objectWithAmount = entityObjectInfo.requiredObjectsToCraft[i];
			if ((int)math.round(objectWithAmount.amount) > 0)
			{
				EntityUtility.DropNewEntity(ecb, new ContainedObjectsBuffer
				{
					objectData = new ObjectDataCD
					{
						objectID = objectWithAmount.objectID,
						amount = math.max(1, objectWithAmount.amount),
						variation = 0
					}
				}, position + i * new float3(0.25f, 0f, 0f), databaseBankCD.databaseBankBlob, Entity.Null);
			}
		}
	}

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		state.RequireForUpdate<WorldInfoCD>();
		state.RequireForUpdate<PhysicsWorldSingleton>();
		state.RequireForUpdate<ClientServerTickRate>();
		state.RequireForUpdate<LootTableBankCD>();
		state.RequireForUpdate<FishingTableCD>();
		state.RequireForUpdate(__query_1046339164_0);
	}

	[BurstCompile]
	public void OnStartRunning(ref SystemState state)
	{
		_tileAccessor = new TileAccessor(ref state);
	}

	public void OnStopRunning(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		_tileAccessor.Update(ref state);
		state.Dependency = __ScheduleViaJobChunkExtension_0(default(TriggerExplosivesByElectricityJob), __TypeHandle.__ExplosiveSystem_TriggerExplosivesByElectricityJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		BeginSimulationEntityCommandBufferSystem.Singleton singleton = __query_1046339164_3.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>();
		__query_1046339164_4.TryGetSingleton<NetworkTime>(out var value);
		ExplodeJob job = new ExplodeJob
		{
			electricityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_ElectricityCD_RO_ComponentLookup, ref state),
			proximityTriggerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ProximityTriggerCD_RO_ComponentLookup, ref state),
			explosionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ExplosionCD_RO_ComponentLookup, ref state),
			levelEntitiesLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__LevelEntitiesBuffer_RO_BufferLookup, ref state),
			levelLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__LevelCD_RO_ComponentLookup, ref state),
			ownerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__OwnerReferenceCD_RO_ComponentLookup, ref state),
			summarizedConditionsEffectsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionEffectsBuffer_RO_BufferLookup, ref state),
			summarizedConditionsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferLookup, ref state),
			projectileSourceLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ProjectileSourceCD_RO_ComponentLookup, ref state),
			ghostOwnerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_NetCode_GhostOwner_RO_ComponentLookup, ref state),
			isExplosiveLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__IsExplosiveCD_RO_ComponentLookup, ref state),
			currentBiomeLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CurrentBiomeCD_RO_ComponentLookup, ref state),
			dontDropSelfLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DontDropSelfCD_RW_ComponentLookup, ref state),
			dontDropLootLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DontDropLootCD_RW_ComponentLookup, ref state),
			hasExplodedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HasExplodedCD_RW_ComponentLookup, ref state),
			randomLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__RandomCD_RW_ComponentLookup, ref state),
			groundBouncableProjectileLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__GroundBouncableProjectileCD_RO_ComponentLookup, ref state),
			factionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__FactionCD_RO_ComponentLookup, ref state),
			godModeLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__GodModeCD_RO_ComponentLookup, ref state),
			killedByPlayerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__KilledByPlayerCD_RO_ComponentLookup, ref state),
			directionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DirectionCD_RO_ComponentLookup, ref state),
			destroyTimerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DestroyTimerCD_RO_ComponentLookup, ref state),
			objectDataLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectDataCD_RW_ComponentLookup, ref state),
			manaLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ManaCD_RW_ComponentLookup, ref state),
			ghostEffectEventBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__GhostEffectEventBuffer_RW_BufferLookup, ref state),
			ghostEffectEventBufferPointerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__GhostEffectEventBufferPointerCD_RW_ComponentLookup, ref state),
			ecb = singleton.CreateCommandBuffer(state.WorldUnmanaged),
			databaseBankCD = __query_1046339164_5.GetSingleton<PugDatabase.DatabaseBankCD>(),
			IsFirstTimeFullyPredictingTick = value.IsFirstTimeFullyPredictingTick,
			currentTick = value.ServerTick,
			tickRate = (uint)__query_1046339164_6.GetSingleton<ClientServerTickRate>().SimulationTickRate,
			tileAccessor = _tileAccessor,
			lootTableBank = __query_1046339164_7.GetSingleton<LootTableBankCD>(),
			fishingTableCD = __query_1046339164_8.GetSingleton<FishingTableCD>(),
			collisionWorld = __query_1046339164_9.GetSingleton<PhysicsWorldSingleton>().CollisionWorld,
			isServer = state.WorldUnmanaged.IsServer()
		};
		state.Dependency = __ScheduleViaJobChunkExtension_1(job, __query_1046339164_1, state.Dependency, ref state, hasUserDefinedQuery: true);
		state.Dependency = __ScheduleViaJobChunkExtension_2(job, __query_1046339164_2, state.Dependency, ref state, hasUserDefinedQuery: true);
		state.Dependency = __ScheduleViaJobChunkExtension_3(new SequencedExplosionsJob
		{
			ecb = singleton.CreateCommandBuffer(state.WorldUnmanaged),
			databaseBankCD = __query_1046339164_5.GetSingleton<PugDatabase.DatabaseBankCD>(),
			animationBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__AnimationBuffer_RW_BufferLookup, ref state),
			animationBufferPointerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__AnimationBufferPointer_RW_ComponentLookup, ref state),
			directionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DirectionCD_RO_ComponentLookup, ref state),
			summarizedConditionsEffectsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionEffectsBuffer_RO_BufferLookup, ref state),
			factionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__FactionCD_RO_ComponentLookup, ref state),
			explosionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ExplosionCD_RO_ComponentLookup, ref state),
			ownerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__OwnerReferenceCD_RO_ComponentLookup, ref state),
			ghostOwnerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_NetCode_GhostOwner_RO_ComponentLookup, ref state),
			isExplosiveLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__IsExplosiveCD_RO_ComponentLookup, ref state),
			randomLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__RandomCD_RW_ComponentLookup, ref state),
			destroyedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentLookup, ref state),
			levelEntitiesLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__LevelEntitiesBuffer_RO_BufferLookup, ref state),
			levelLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__LevelCD_RO_ComponentLookup, ref state),
			summarizedConditionsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferLookup, ref state),
			projectileSourceLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ProjectileSourceCD_RO_ComponentLookup, ref state),
			destroyTimerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DestroyTimerCD_RO_ComponentLookup, ref state),
			mortarProjectileLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MortarProjectileCD_RO_ComponentLookup, ref state),
			manaLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ManaCD_RW_ComponentLookup, ref state),
			isFirstTimeFullyPredictingTick = value.IsFirstTimeFullyPredictingTick,
			currentTick = value.ServerTick,
			tickRate = (uint)__query_1046339164_6.GetSingleton<ClientServerTickRate>().SimulationTickRate
		}, __TypeHandle.__ExplosiveSystem_SequencedExplosionsJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		if (state.WorldUnmanaged.IsServer())
		{
			state.Dependency = __ScheduleViaJobChunkExtension_4(new ProximityExplosionCheck
			{
				EnemyLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EnemyCD_RO_ComponentLookup, ref state),
				PlayerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerGhost_RO_ComponentLookup, ref state),
				EntityDestroyedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentLookup, ref state),
				FactionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__FactionCD_RO_ComponentLookup, ref state),
				EnemyActAsDestructibleLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EnemyActAsDestructibleCD_RO_ComponentLookup, ref state),
				worldInfo = __query_1046339164_10.GetSingleton<WorldInfoCD>(),
				CollisionWorld = __query_1046339164_9.GetSingleton<PhysicsWorldSingleton>().CollisionWorld,
				time = state.WorldUnmanaged.Time.ElapsedTime,
				currentTick = value.ServerTick
			}, __TypeHandle.__ExplosiveSystem_ProximityExplosionCheck_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(TriggerExplosivesByElectricityJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__ExplosiveSystem_TriggerExplosivesByElectricityJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__ExplosiveSystem_TriggerExplosivesByElectricityJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__ExplosiveSystem_TriggerExplosivesByElectricityJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__ExplosiveSystem_TriggerExplosivesByElectricityJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_1(ExplodeJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__ExplosiveSystem_ExplodeJob_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__ExplosiveSystem_ExplodeJob_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__ExplosiveSystem_ExplodeJob_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__ExplosiveSystem_ExplodeJob_WithoutDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_2(ExplodeJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__ExplosiveSystem_ExplodeJob_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__ExplosiveSystem_ExplodeJob_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__ExplosiveSystem_ExplodeJob_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__ExplosiveSystem_ExplodeJob_WithoutDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_3(SequencedExplosionsJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__ExplosiveSystem_SequencedExplosionsJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__ExplosiveSystem_SequencedExplosionsJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__ExplosiveSystem_SequencedExplosionsJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__ExplosiveSystem_SequencedExplosionsJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_4(ProximityExplosionCheck job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__ExplosiveSystem_ProximityExplosionCheck_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__ExplosiveSystem_ProximityExplosionCheck_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__ExplosiveSystem_ProximityExplosionCheck_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__ExplosiveSystem_ProximityExplosionCheck_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<IsExplosiveCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<HasExplodedCD>();
		__query_1046339164_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform, ObjectPropertiesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<HasExplodedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<IsExplosiveCD, Simulate, ObjectDataCD, EntityDestroyedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAbsent<MortarProjectileEffectTriggerCD>();
		__query_1046339164_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform, ObjectPropertiesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<HasExplodedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<IsExplosiveCD, Simulate, ObjectDataCD, MortarProjectileEffectTriggerCD>();
		__query_1046339164_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1046339164_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1046339164_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1046339164_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1046339164_6 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<LootTableBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1046339164_7 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<FishingTableCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1046339164_8 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1046339164_9 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1046339164_10 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_00001E46_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00001E47_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_00001E48_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		((ExplosiveSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((ExplosiveSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ExplosiveSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ExplosiveSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ExplosiveSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}
}
