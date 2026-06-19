using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.Properties;
using Pug.UnityExtensions;
using PugTilemap.Quads;
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
[UpdateInGroup(typeof(StateUpdateGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
public struct ChaseStateSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[BurstCompile]
	[WithAll(new Type[]
	{
		typeof(LocalTransform),
		typeof(MovementSpeedCD)
	})]
	private struct ChaseStateJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<ChaseStateCD> __ChaseStateCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<GhostInstance> __Unity_NetCode_GhostInstance_RO_ComponentTypeHandle;

				public ComponentTypeHandle<PhysicsVelocity> __Unity_Physics_PhysicsVelocity_RW_ComponentTypeHandle;

				public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentTypeHandle;

				public ComponentTypeHandle<AnimationOrientationCD> __AnimationOrientationCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<RandomCD> __RandomCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ObjectPropertiesCD> __Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__StateInfoCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>();
					__ChaseStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ChaseStateCD>();
					__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle = state.GetComponentTypeHandle<GhostInstance>(isReadOnly: true);
					__Unity_Physics_PhysicsVelocity_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PhysicsVelocity>();
					__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
					__AnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>();
					__AnimationOrientationCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationOrientationCD>();
					__RandomCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RandomCD>();
					__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectPropertiesCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__StateInfoCD_RW_ComponentTypeHandle.Update(ref state);
					__ChaseStateCD_RW_ComponentTypeHandle.Update(ref state);
					__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle.Update(ref state);
					__Unity_Physics_PhysicsVelocity_RW_ComponentTypeHandle.Update(ref state);
					__AnimationBuffer_RW_BufferTypeHandle.Update(ref state);
					__AnimationBufferPointer_RW_ComponentTypeHandle.Update(ref state);
					__AnimationOrientationCD_RW_ComponentTypeHandle.Update(ref state);
					__RandomCD_RW_ComponentTypeHandle.Update(ref state);
					__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<GhostInstance>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectPropertiesCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<MovementSpeedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StateInfoCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ChaseStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PhysicsVelocity>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationOrientationCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RandomCD>();
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
			public void Run(ref ChaseStateJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref ChaseStateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref ChaseStateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref ChaseStateJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref ChaseStateJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref ChaseStateJob job, EntityManager entityManager)
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
		public TileAccessor tileAccessor;

		[ReadOnly]
		public ComponentLookup<FactionCD> factionLookup;

		[ReadOnly]
		public ComponentLookup<EntityPartCD> entityPartLookup;

		[ReadOnly]
		public ComponentLookup<BreedStateCD> breedStateLookup;

		[ReadOnly]
		public ComponentLookup<EatStateCD> eatStateLookup;

		[ReadOnly]
		public ComponentLookup<MealsEatenCD> mealsEatenLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> objectDataLookup;

		[ReadOnly]
		public ComponentLookup<BehaviourTagsCD> behaviourTagsLookup;

		[ReadOnly]
		public ComponentLookup<LeashedCD> leashedLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> localTranslationLookup;

		[ReadOnly]
		public ComponentLookup<EquippedObjectCD> equippedObjectLookup;

		[ReadOnly]
		public ComponentLookup<ObjectCategoryTagsCD> objectCategoryTagsGroup;

		[ReadOnly]
		public BufferLookup<ContainedObjectsBuffer> containedObjectsBufferLookup;

		[ReadOnly]
		public ComponentLookup<OwnerReferenceCD> ownerLookup;

		[ReadOnly]
		public BufferLookup<NewCombatantsBuffer> newCombatantsBuffer;

		[ReadOnly]
		public ComponentLookup<MovementSpeedCD> movementSpeedGroup;

		[ReadOnly]
		public BufferLookup<CombatantsTrackerBuffer> combatantsTrackerBufferLookup;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

		[ReadOnly]
		public ComponentLookup<PetCD> petLookup;

		[ReadOnly]
		public ComponentLookup<ShieldCD> shieldLookup;

		[ReadOnly]
		public ComponentLookup<DisablePhysicsCD> disablePhysicsLookup;

		[ReadOnly]
		public ComponentLookup<CombatRadiusCD> combatRadiusLookup;

		[ReadOnly]
		public ComponentLookup<PathFindCD> pathFindLookup;

		[ReadOnly]
		public ComponentLookup<MinionCD> minionLookup;

		[ReadOnly]
		public ComponentLookup<HealthCD> healthLookup;

		[ReadOnly]
		public BufferLookup<PathFindNodeBuffer> pathFindNodeBufferLookup;

		[ReadOnly]
		public CollisionWorld collisionWorld;

		public WorldInfoCD worldInfo;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		public EntityCommandBuffer ecb;

		public NetworkTick currentTick;

		public double time;

		public float deltaTime;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref StateInfoCD stateInfo, ref ChaseStateCD chaseState, in GhostInstance ghostInstance, ref PhysicsVelocity velocity, ref DynamicBuffer<AnimationBuffer> animationBuffer, ref AnimationBufferPointer animationBufferPointer, ref AnimationOrientationCD orientationCD, ref RandomCD randomCD, in ObjectPropertiesCD properties)
		{
			if (!stateInfo.IsCurrentState(StateID.Chase))
			{
				return;
			}
			Entity pathFindEntity = chaseState.pathFindEntity;
			factionLookup.TryGetComponent(entity, out var componentData);
			Entity entity2 = chaseState.targetEntity;
			Entity entity3 = entity2;
			bool flag = false;
			bool flag2 = false;
			if (entity2 != Entity.Null)
			{
				if (entityPartLookup.TryGetComponent(entity2, out var componentData2))
				{
					entity2 = componentData2.mainEntity;
				}
				factionLookup.TryGetComponent(entity2, out var componentData3);
				behaviourTagsLookup.TryGetComponent(entity, out var componentData4);
				flag2 = leashedLookup.TryGetComponent(entity, out var componentData5) && componentData5.leashedToEntity == chaseState.targetEntity;
				objectDataLookup.TryGetComponent(entity, out var componentData6);
				EatStateCD componentData7;
				bool flag3 = eatStateLookup.TryGetComponent(entity, out componentData7);
				ObjectDataCD componentData8;
				bool flag4 = objectDataLookup.TryGetComponent(entity2, out componentData8);
				bool flag5 = false;
				BreedStateCD componentData9 = default(BreedStateCD);
				MealsEatenCD componentData10 = default(MealsEatenCD);
				if (!flag2 && breedStateLookup.TryGetComponent(entity, out componentData9) && flag3 && mealsEatenLookup.TryGetComponent(entity, out componentData10) && flag4 && componentData8.objectID == componentData6.objectID && breedStateLookup.TryGetComponent(entity2, out var componentData11) && eatStateLookup.TryGetComponent(entity2, out var componentData12) && mealsEatenLookup.TryGetComponent(entity2, out var componentData13))
				{
					bool num = componentData9.HasEatenEnough(componentData10);
					bool flag6 = componentData11.HasEatenEnough(componentData13);
					bool flag7 = componentData6.amount >= componentData7.maxFoodUntilFull;
					bool flag8 = componentData8.amount >= componentData12.maxFoodUntilFull;
					if (num && flag6 && flag7 && flag8)
					{
						flag5 = true;
					}
				}
				bool flag9 = false;
				int amount = componentData6.amount;
				if (!flag2 && !flag5 && equippedObjectLookup.TryGetComponent(entity2, out var componentData14))
				{
					ContainedObjectsBuffer containedObject = componentData14.containedObject;
					if (containedObject.objectID != ObjectID.None)
					{
						flag9 = objectCategoryTagsGroup.TryGetComponent(componentData14.equipmentPrefab, out var componentData15) && BehaviourTagsCD.Eats(componentData4, componentData15);
						if (!flag9 && properties.TryGetList(158600710, out NativeArray<ObjectID> value, (AllocatorManager.AllocatorHandle)Allocator.Temp))
						{
							for (int i = 0; i < value.Length; i++)
							{
								if (value[i] == containedObject.objectID)
								{
									flag9 = true;
									break;
								}
							}
						}
					}
				}
				int num2 = ((!flag3) ? 1 : componentData7.maxFoodUntilFull);
				bool flag10 = false;
				if (!flag2 && !flag5 && !flag9 && amount < num2 && flag4 && componentData8.objectID == ObjectID.CattleFeedTray && containedObjectsBufferLookup.TryGetBuffer(chaseState.targetEntity, out var bufferData))
				{
					for (int j = 0; j < bufferData.Length; j++)
					{
						Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(bufferData[j].objectID, databaseBankCD.databaseBankBlob);
						if (objectCategoryTagsGroup.TryGetComponent(primaryPrefabEntity, out var componentData16) && BehaviourTagsCD.Eats(componentData4, componentData16))
						{
							flag10 = true;
							break;
						}
					}
				}
				bool flag11 = true;
				if (!minionLookup.HasComponent(entity) && ownerLookup.TryGetComponent(entity, out var componentData17))
				{
					Entity owner = componentData17.owner;
					if (combatantsTrackerBufferLookup.HasComponent(owner))
					{
						flag11 = false;
						for (int k = 0; k < combatantsTrackerBufferLookup[owner].Length; k++)
						{
							if (combatantsTrackerBufferLookup[owner][k].Target == chaseState.targetEntity)
							{
								flag11 = true;
								break;
							}
						}
					}
				}
				ShieldCD componentData18;
				bool flag12 = !petLookup.HasComponent(entity) || !shieldLookup.TryGetComponent(entity2, out componentData18) || !componentData18.active;
				ObjectCategoryTagsCD componentData19;
				bool flag13 = flag2 || flag5 || flag9 || flag10 || (objectCategoryTagsGroup.TryGetComponent(entity2, out componentData19) && ((BehaviourTagsCD.WantsToAndCanAttack(componentData4, componentData19) && componentData.CanAttack(componentData3, worldInfo) && flag12) || (BehaviourTagsCD.Eats(componentData4, componentData19) && amount < num2)));
				flag = entity2 != Entity.Null && localTranslationLookup.HasComponent(entity2) && (!entityDestroyedLookup.HasComponent(entity2) || !entityDestroyedLookup.IsComponentEnabled(entity2)) && !disablePhysicsLookup.HasAndIsComponentEnabled(entity3) && healthLookup.HasComponent(entity2) && (float)healthLookup[entity2].health > 0f && flag13 && flag11;
			}
			if (!flag)
			{
				chaseState.targetEntity = Entity.Null;
			}
			CombatRadiusCD componentData20;
			float num3 = (combatRadiusLookup.TryGetComponent(chaseState.targetEntity, out componentData20) ? componentData20.radius : 0f);
			float3 position = localTranslationLookup[entity].Position;
			float3 float5 = (flag ? localTranslationLookup[chaseState.targetEntity].Position : position);
			float3 x = float5 - position;
			float5 -= math.normalizesafe(x, float3.zero) * num3;
			x = float5 - position;
			float3 float6 = math.normalizesafe(x, new float3(0f, 0f, -1f));
			if (chaseState.internalState == 0)
			{
				float num4 = properties.Get<float>(-1339077920);
				if (num4 > 0f)
				{
					orientationCD.SetFacingDirectionFromVector(float6);
					AnimationUtilities.TriggerAnimation(2074276498, currentTick, animationBuffer, ref animationBufferPointer);
					chaseState.phaseChaseTimer.Start(time, num4);
				}
				else
				{
					chaseState.phaseChaseTimer.Stop();
				}
				chaseState.internalState = 1;
			}
			if (chaseState.phaseChaseTimer.isRunning && !chaseState.phaseChaseTimer.IsTimerElapsed(time))
			{
				return;
			}
			bool flag14 = !flag;
			if (!flag2 && !flag14 && chaseState.chaseTimer.isRunning && chaseState.chaseTimer.IsTimerElapsed(time) && !chaseState.neverTimeoutChasing)
			{
				chaseState.cooldownTimer.Start(time, randomCD.Value.NextFloat(3f, 5f));
				flag14 = true;
			}
			float num5 = math.lengthsq(x);
			if (!flag2 && !flag14)
			{
				float num6 = (chaseState.isMinionCommandTarget ? 400f : chaseState.chaseAtDistanceSq);
				if (chaseState.isChasingByLastAttacker)
				{
					num6 = 400f;
				}
				if (num5 > num6)
				{
					PathFindCD pathFindCD = pathFindLookup[pathFindEntity];
					DynamicBuffer<PathFindNodeBuffer> pathFindNodeBuffer = pathFindNodeBufferLookup[pathFindEntity];
					if (!PathFindUtility.GetDirection(in pathFindCD, pathFindNodeBuffer, position.ToFloat2(), out var _))
					{
						chaseState.targetEntity = Entity.Null;
						flag14 = true;
					}
				}
			}
			float num7 = 0f;
			float3 float7 = 0;
			bool flag15 = true;
			TileCD tile;
			if (!flag14)
			{
				if (!flag2 && !properties.Has(-1004432830))
				{
					PathFindCD pathFindCD2 = pathFindLookup[pathFindEntity];
					DynamicBuffer<PathFindNodeBuffer> pathFindNodeBuffer2 = pathFindNodeBufferLookup[pathFindEntity];
					float2 direction3;
					bool direction2 = PathFindUtility.GetDirection(in pathFindCD2, pathFindNodeBuffer2, position.ToFloat2(), out direction3);
					bool flag16 = properties.Has(1667637084);
					if (direction2)
					{
						float7 = direction3.ToFloat3();
						if (chaseState.lastAttackerCheckCooldownTimer.isRunning && chaseState.isChasingByLastAttacker)
						{
							chaseState.lastAttackerCheckCooldownTimer.Stop();
						}
					}
					float3 float8 = localTranslationLookup[entity].Position + new float3(0f, 0.5f, 0f);
					float3 float9 = localTranslationLookup[chaseState.targetEntity].Position + new float3(0f, 0.5f, 0f);
					uint layerMaskCollidesWith = (flag16 ? 1u : 131329u);
					RaycastInput raycastInput = PhysicsManager.GetRaycastInput(float8, float9, uint.MaxValue, layerMaskCollidesWith);
					flag15 = !collisionWorld.CastRay(raycastInput, out var closestHit) || closestHit.Entity == chaseState.targetEntity;
					if (flag15)
					{
						int2 int5 = float8.RoundToInt2();
						int2 end = float9.RoundToInt2();
						int2 pos = int5;
						int num8 = 0;
						do
						{
							if (tileAccessor.TryGetBlockingTile(pos, out tile, !flag16))
							{
								flag15 = false;
								break;
							}
						}
						while (++num8 < 50 && MathUtilities.NextPosOnLine(int5, end, ref pos));
						if (num8 >= 50)
						{
							UnityEngine.Debug.LogError("Chase state was checking entity way too far away");
						}
					}
					if (!flag15 && chaseState.hadTargetInSight)
					{
						chaseState.invertSideStepDirection = !chaseState.invertSideStepDirection;
					}
					chaseState.hadTargetInSight = flag15;
					if (properties.Has(897405507) && !direction2)
					{
						chaseState.targetEntity = Entity.Null;
						flag14 = true;
					}
					else if (direction2 && ((math.dot(float7.ToFloat2(), float6.ToFloat2()) >= 0f && properties.Has(-1891009192)) || !flag15))
					{
						num7 = 1000f;
						float6 = float7;
					}
					else if (!flag15)
					{
						chaseState.targetEntity = Entity.Null;
						flag14 = true;
					}
				}
				else if (chaseState.lastAttackerCheckCooldownTimer.isRunning && chaseState.isChasingByLastAttacker)
				{
					chaseState.lastAttackerCheckCooldownTimer.Stop();
				}
			}
			if (flag14)
			{
				if ((chaseState.internalState == 1 && chaseState.phaseChaseTimer.IsTimerElapsed(time)) || chaseState.internalState == 2)
				{
					float num9 = properties.Get<float>(-1328972107);
					if (num9 > 0f)
					{
						AnimationUtilities.TriggerAnimation(618391746, currentTick, animationBuffer, ref animationBufferPointer);
						chaseState.phaseChaseTimer.Start(time, num9);
					}
					else
					{
						chaseState.phaseChaseTimer.Stop();
					}
					chaseState.internalState = 3;
				}
				if (chaseState.internalState == 3 && (!chaseState.phaseChaseTimer.isRunning || chaseState.phaseChaseTimer.IsTimerElapsed(time)))
				{
					AnimationUtilities.TriggerAnimation(-601574123, currentTick, animationBuffer, ref animationBufferPointer);
					chaseState.internalState = 4;
					stateInfo.LeaveState();
				}
				return;
			}
			if (chaseState.internalState == 0 || (chaseState.internalState == 1 && chaseState.phaseChaseTimer.IsTimerElapsed(time)))
			{
				chaseState.internalState = 2;
				AnimationUtilities.TriggerAnimation(-281135240, currentTick, animationBuffer, ref animationBufferPointer);
			}
			if (chaseState.internalState == 2)
			{
				float num10 = properties.Get<float>(743376721);
				if (num10 > 0f && chaseState.idleCooldownTimer.isRunning && chaseState.idleCooldownTimer.IsTimerElapsed(time) && flag15)
				{
					AnimationUtilities.TriggerAnimation(-601574123, currentTick, animationBuffer, ref animationBufferPointer);
					chaseState.idleTimer.Start(time, num10);
					chaseState.idleCooldownTimer.Stop();
				}
				if (chaseState.idleTimer.isRunning)
				{
					if (!chaseState.idleTimer.IsTimerElapsed(time))
					{
						return;
					}
					AnimationUtilities.TriggerAnimation(-281135240, currentTick, animationBuffer, ref animationBufferPointer);
					chaseState.idleCooldownTimer.Start(time, properties.Get<float>(1953737544));
					chaseState.idleTimer.Stop();
					orientationCD.SetFacingDirectionFromVector(float6);
				}
			}
			float3 float10 = -float6;
			float t = (noise.pnoise(new float2((float)time, (float)time) * 0.5f, new float2(0.34f, 0.34f) * (ghostInstance.ghostId + 1)) + 1f) / 2f;
			float num11 = properties.Get<float>(-1788873190);
			float num12 = properties.Get<float>(-2133581080);
			float num13 = math.lerp(num11, num12, 0.5f);
			if (!chaseState.distanceToKeepNoiseDisabled)
			{
				num13 = math.lerp(num11, num12, t);
				num11 = num13;
				num12 = num13;
			}
			float3 obj = float5 + float10 * num13;
			float num14 = math.distance(obj, position);
			float num15 = math.clamp(num14 / 2f, 0f, 1f);
			num15 = ((num14 < 0.1f) ? 0f : num15);
			float3 float11 = math.normalizesafe(obj - position);
			float num16 = num11 * num11;
			float num17 = num12 * num12;
			if (num5 < num17 && flag15)
			{
				num7 = 0f;
				if (num5 > num16 && chaseState.distanceToKeepNoiseDisabled)
				{
					num15 = 0f;
				}
			}
			float3 float12 = float3.zero;
			float num18 = 0f;
			float num19 = properties.Get<float>(-120064328);
			if (num19 > 0f)
			{
				float num20 = math.sign(noise.pnoise(new float2((float)time, (float)time) * 0.1f, new float2(0.23f, 0.23f) * (ghostInstance.ghostId + 1)));
				if (chaseState.invertSideStepDirection)
				{
					num20 *= -1f;
				}
				num18 = 1f - math.clamp((num5 - num19) / num19, 0f, 1f);
				float12 = num20 * math.cross(float6, new float3(0f, 1f, 0f));
			}
			float3 float13 = float3.zero;
			float num21 = 0f;
			float num22 = properties.Get<float>(1890784898);
			if (num22 > 0f)
			{
				float3 float14 = new float3(0f, 0.5f, 0f);
				CollisionFilter filter = new CollisionFilter
				{
					BelongsTo = uint.MaxValue,
					CollidesWith = 131329u
				};
				for (int l = 0; l < AdjacentDir.fourWay.Length; l++)
				{
					float3 float15 = AdjacentDir.GetFloat3(AdjacentDir.fourWay[l]);
					RaycastInput input = new RaycastInput
					{
						Start = localTranslationLookup[entity].Position + float14,
						End = localTranslationLookup[entity].Position + float14 + float15 * num22,
						Filter = filter
					};
					if (collisionWorld.CastRay(input, out var closestHit2))
					{
						float13 += closestHit2.SurfaceNormal;
						float13.y = 0f;
						num21 += num22 / (math.distance(localTranslationLookup[entity].Position, closestHit2.Position) + 1f);
						continue;
					}
					for (int m = 1; (float)m < num22 * 2f; m++)
					{
						float3 float16 = float15 * 0.5f * m;
						int2 worldPosition = (localTranslationLookup[entity].Position + float16).RoundToInt2();
						bool includeLowColliders = !properties.Has(1667637084);
						if (tileAccessor.TryGetBlockingTile(worldPosition, out tile, includeLowColliders))
						{
							float13 -= float15;
							float13.y = 0f;
							num21 += num22 / (1f + math.length(float16));
							break;
						}
					}
				}
				if (math.any(float13 != float3.zero))
				{
					float13 = math.normalize(float13);
				}
			}
			float num23 = num7 + num18 + num15 + num21;
			num7 /= num23;
			num18 /= num23;
			num15 /= num23;
			num21 /= num23;
			float3 float17 = float7 * num7 + float11 * num15 + float12 * num18 + float13 * num21;
			if (num23 > 0f)
			{
				MovementSpeedCD movementSpeedCD = movementSpeedGroup[entity];
				float num24 = ChaseStateUtility.CalculateMovementSpeed(movementSpeedMultiplier: properties.Get<float>(1477335750), speed: movementSpeedCD.speed, isLeashed: flag2);
				velocity.AddLinear2D(float17 * (num24 * deltaTime));
			}
			orientationCD.SetFacingDirectionFromVector(float6);
			if (num5 < 16f && newCombatantsBuffer.HasComponent(chaseState.targetEntity))
			{
				ecb.AppendToBuffer(chaseState.targetEntity, new NewCombatantsBuffer
				{
					Target = entity
				});
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__StateInfoCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__ChaseStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Unity_Physics_PhysicsVelocity_RW_ComponentTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr7 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AnimationOrientationCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr8 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RandomCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr9 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref StateInfoCD stateInfo = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, i);
					ref ChaseStateCD chaseState = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ChaseStateCD>(nativeArrayPtr3, i);
					ref GhostInstance ghostInstance = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr4, i);
					ref PhysicsVelocity velocity = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocity>(nativeArrayPtr5, i);
					DynamicBuffer<AnimationBuffer> animationBuffer = bufferAccessor[i];
					Execute(entity, ref stateInfo, ref chaseState, in ghostInstance, ref velocity, ref animationBuffer, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr6, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr7, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr8, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr9, i));
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
						ref StateInfoCD stateInfo2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, nextRangeBegin);
						ref ChaseStateCD chaseState2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ChaseStateCD>(nativeArrayPtr3, nextRangeBegin);
						ref GhostInstance ghostInstance2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr4, nextRangeBegin);
						ref PhysicsVelocity velocity2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocity>(nativeArrayPtr5, nextRangeBegin);
						DynamicBuffer<AnimationBuffer> animationBuffer2 = bufferAccessor[nextRangeBegin];
						Execute(entity2, ref stateInfo2, ref chaseState2, in ghostInstance2, ref velocity2, ref animationBuffer2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr6, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr7, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr8, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr9, nextRangeBegin));
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
					ref StateInfoCD stateInfo3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, j);
					ref ChaseStateCD chaseState3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ChaseStateCD>(nativeArrayPtr3, j);
					ref GhostInstance ghostInstance3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr4, j);
					ref PhysicsVelocity velocity3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocity>(nativeArrayPtr5, j);
					DynamicBuffer<AnimationBuffer> animationBuffer3 = bufferAccessor[j];
					Execute(entity3, ref stateInfo3, ref chaseState3, in ghostInstance3, ref velocity3, ref animationBuffer3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr6, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr7, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr8, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr9, j));
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
					ref StateInfoCD stateInfo4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, k);
					ref ChaseStateCD chaseState4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ChaseStateCD>(nativeArrayPtr3, k);
					ref GhostInstance ghostInstance4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr4, k);
					ref PhysicsVelocity velocity4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocity>(nativeArrayPtr5, k);
					DynamicBuffer<AnimationBuffer> animationBuffer4 = bufferAccessor[k];
					Execute(entity4, ref stateInfo4, ref chaseState4, in ghostInstance4, ref velocity4, ref animationBuffer4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr6, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr7, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr8, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr9, k));
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
		[ReadOnly]
		public ComponentLookup<FactionCD> __FactionCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<EntityPartCD> __EntityPartCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<BreedStateCD> __BreedStateCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<EatStateCD> __EatStateCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<MealsEatenCD> __MealsEatenCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> __ObjectDataCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<BehaviourTagsCD> __BehaviourTagsCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LeashedCD> __LeashedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<EquippedObjectCD> __EquippedObjectCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ObjectCategoryTagsCD> __ObjectCategoryTagsCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<ContainedObjectsBuffer> __ContainedObjectsBuffer_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<OwnerReferenceCD> __OwnerReferenceCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<NewCombatantsBuffer> __NewCombatantsBuffer_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<MovementSpeedCD> __MovementSpeedCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<CombatantsTrackerBuffer> __CombatantsTrackerBuffer_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PetCD> __PetCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ShieldCD> __ShieldCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DisablePhysicsCD> __DisablePhysicsCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<CombatRadiusCD> __CombatRadiusCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PathFindCD> __PathFindCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<MinionCD> __MinionCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<HealthCD> __HealthCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<PathFindNodeBuffer> __PathFindNodeBuffer_RO_BufferLookup;

		public ChaseStateJob.InternalCompilerQueryAndHandleData __ChaseStateSystem_ChaseStateJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__FactionCD_RO_ComponentLookup = state.GetComponentLookup<FactionCD>(isReadOnly: true);
			__EntityPartCD_RO_ComponentLookup = state.GetComponentLookup<EntityPartCD>(isReadOnly: true);
			__BreedStateCD_RO_ComponentLookup = state.GetComponentLookup<BreedStateCD>(isReadOnly: true);
			__EatStateCD_RO_ComponentLookup = state.GetComponentLookup<EatStateCD>(isReadOnly: true);
			__MealsEatenCD_RO_ComponentLookup = state.GetComponentLookup<MealsEatenCD>(isReadOnly: true);
			__ObjectDataCD_RO_ComponentLookup = state.GetComponentLookup<ObjectDataCD>(isReadOnly: true);
			__BehaviourTagsCD_RO_ComponentLookup = state.GetComponentLookup<BehaviourTagsCD>(isReadOnly: true);
			__LeashedCD_RO_ComponentLookup = state.GetComponentLookup<LeashedCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__EquippedObjectCD_RO_ComponentLookup = state.GetComponentLookup<EquippedObjectCD>(isReadOnly: true);
			__ObjectCategoryTagsCD_RO_ComponentLookup = state.GetComponentLookup<ObjectCategoryTagsCD>(isReadOnly: true);
			__ContainedObjectsBuffer_RO_BufferLookup = state.GetBufferLookup<ContainedObjectsBuffer>(isReadOnly: true);
			__OwnerReferenceCD_RO_ComponentLookup = state.GetComponentLookup<OwnerReferenceCD>(isReadOnly: true);
			__NewCombatantsBuffer_RO_BufferLookup = state.GetBufferLookup<NewCombatantsBuffer>(isReadOnly: true);
			__MovementSpeedCD_RO_ComponentLookup = state.GetComponentLookup<MovementSpeedCD>(isReadOnly: true);
			__CombatantsTrackerBuffer_RO_BufferLookup = state.GetBufferLookup<CombatantsTrackerBuffer>(isReadOnly: true);
			__EntityDestroyedCD_RO_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
			__PetCD_RO_ComponentLookup = state.GetComponentLookup<PetCD>(isReadOnly: true);
			__ShieldCD_RO_ComponentLookup = state.GetComponentLookup<ShieldCD>(isReadOnly: true);
			__DisablePhysicsCD_RO_ComponentLookup = state.GetComponentLookup<DisablePhysicsCD>(isReadOnly: true);
			__CombatRadiusCD_RO_ComponentLookup = state.GetComponentLookup<CombatRadiusCD>(isReadOnly: true);
			__PathFindCD_RO_ComponentLookup = state.GetComponentLookup<PathFindCD>(isReadOnly: true);
			__MinionCD_RO_ComponentLookup = state.GetComponentLookup<MinionCD>(isReadOnly: true);
			__HealthCD_RO_ComponentLookup = state.GetComponentLookup<HealthCD>(isReadOnly: true);
			__PathFindNodeBuffer_RO_BufferLookup = state.GetBufferLookup<PathFindNodeBuffer>(isReadOnly: true);
			__ChaseStateSystem_ChaseStateJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_0000398B_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_0000398B_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_0000398B_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_0000398C_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_0000398C_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_0000398C_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnStartRunning_0000398D_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_0000398D_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_0000398D_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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

	private const float DISTANCESQ_TO_BE_CONSIDERED_COMBATANT = 16f;

	private TileAccessor _tileAccessor;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1517739097_0;

	private EntityQuery __query_1517739097_1;

	private EntityQuery __query_1517739097_2;

	private EntityQuery __query_1517739097_3;

	private EntityQuery __query_1517739097_4;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
		state.RequireForUpdate<WorldInfoCD>();
		state.RequireForUpdate<PhysicsWorldSingleton>();
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		state.RequireForUpdate<ChaseStateCD>();
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
		__query_1517739097_0.TryGetSingleton<NetworkTime>(out var value);
		EntityCommandBuffer ecb = __query_1517739097_1.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		state.Dependency = __ScheduleViaJobChunkExtension_0(new ChaseStateJob
		{
			tileAccessor = _tileAccessor,
			factionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__FactionCD_RO_ComponentLookup, ref state),
			entityPartLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityPartCD_RO_ComponentLookup, ref state),
			breedStateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BreedStateCD_RO_ComponentLookup, ref state),
			eatStateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EatStateCD_RO_ComponentLookup, ref state),
			mealsEatenLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MealsEatenCD_RO_ComponentLookup, ref state),
			objectDataLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectDataCD_RO_ComponentLookup, ref state),
			behaviourTagsLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BehaviourTagsCD_RO_ComponentLookup, ref state),
			leashedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__LeashedCD_RO_ComponentLookup, ref state),
			localTranslationLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
			equippedObjectLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EquippedObjectCD_RO_ComponentLookup, ref state),
			objectCategoryTagsGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectCategoryTagsCD_RO_ComponentLookup, ref state),
			containedObjectsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ContainedObjectsBuffer_RO_BufferLookup, ref state),
			ownerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__OwnerReferenceCD_RO_ComponentLookup, ref state),
			newCombatantsBuffer = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__NewCombatantsBuffer_RO_BufferLookup, ref state),
			movementSpeedGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MovementSpeedCD_RO_ComponentLookup, ref state),
			combatantsTrackerBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__CombatantsTrackerBuffer_RO_BufferLookup, ref state),
			entityDestroyedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentLookup, ref state),
			petLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PetCD_RO_ComponentLookup, ref state),
			shieldLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ShieldCD_RO_ComponentLookup, ref state),
			disablePhysicsLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DisablePhysicsCD_RO_ComponentLookup, ref state),
			combatRadiusLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CombatRadiusCD_RO_ComponentLookup, ref state),
			pathFindLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PathFindCD_RO_ComponentLookup, ref state),
			minionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MinionCD_RO_ComponentLookup, ref state),
			healthLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HealthCD_RO_ComponentLookup, ref state),
			pathFindNodeBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__PathFindNodeBuffer_RO_BufferLookup, ref state),
			collisionWorld = __query_1517739097_2.GetSingleton<PhysicsWorldSingleton>().CollisionWorld,
			worldInfo = __query_1517739097_3.GetSingleton<WorldInfoCD>(),
			databaseBankCD = __query_1517739097_4.GetSingleton<PugDatabase.DatabaseBankCD>(),
			ecb = ecb,
			currentTick = value.ServerTick,
			time = state.WorldUnmanaged.Time.ElapsedTime,
			deltaTime = state.WorldUnmanaged.Time.DeltaTime
		}, __TypeHandle.__ChaseStateSystem_ChaseStateJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(ChaseStateJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__ChaseStateSystem_ChaseStateJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__ChaseStateSystem_ChaseStateJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__ChaseStateSystem_ChaseStateJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__ChaseStateSystem_ChaseStateJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1517739097_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1517739097_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1517739097_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1517739097_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1517739097_4 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_0000398B_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_0000398C_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_0000398D_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		((ChaseStateSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((ChaseStateSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ChaseStateSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ChaseStateSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ChaseStateSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}
}
