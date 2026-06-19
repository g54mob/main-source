using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(StateUpdateGroup))]
public struct MeleeAttackStateSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[BurstCompile]
	[WithAll(new Type[]
	{
		typeof(AnimationOrientationCD),
		typeof(AnimationBuffer),
		typeof(AnimationBufferPointer)
	})]
	private struct MeleeAttackStateJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<MeleeAttackStateCD> __MeleeAttackStateCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<AttackCooldownTimerCD> __AttackCooldownTimerCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<BehaviourTagsCD> __BehaviourTagsCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ObjectPropertiesCD> __Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__StateInfoCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>();
					__MeleeAttackStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MeleeAttackStateCD>();
					__AttackCooldownTimerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AttackCooldownTimerCD>();
					__BehaviourTagsCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<BehaviourTagsCD>(isReadOnly: true);
					__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectPropertiesCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__StateInfoCD_RW_ComponentTypeHandle.Update(ref state);
					__MeleeAttackStateCD_RW_ComponentTypeHandle.Update(ref state);
					__AttackCooldownTimerCD_RW_ComponentTypeHandle.Update(ref state);
					__BehaviourTagsCD_RO_ComponentTypeHandle.Update(ref state);
					__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<BehaviourTagsCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectPropertiesCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<AnimationOrientationCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<AnimationBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<AnimationBufferPointer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StateInfoCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MeleeAttackStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AttackCooldownTimerCD>();
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
			public void Run(ref MeleeAttackStateJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref MeleeAttackStateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref MeleeAttackStateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref MeleeAttackStateJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref MeleeAttackStateJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref MeleeAttackStateJob job, EntityManager entityManager)
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

		public TileAccessor tileLookup;

		public AttackSystem.Helper attackHelper;

		[ReadOnly]
		public BufferLookup<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBufferLookup;

		[ReadOnly]
		public ComponentLookup<CombatRadiusCD> combatRadiusLookup;

		[ReadOnly]
		public CollisionWorld collisionWorld;

		[ReadOnly]
		public ComponentLookup<PlayerGhostExtrapolated> playerGhostExtrapolatedLookup;

		[ReadOnly]
		public BufferLookup<NewCombatantsBuffer> newCombatantsBufferLookup;

		[ReadOnly]
		public ComponentLookup<IndestructibleCD> indestructibleLookup;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		public EntityCommandBuffer ecb;

		public Entity effectEventBufferSingleton;

		public Entity tileDamageBufferEntity;

		public Entity updatedTilesSingleton;

		public int attackAnimID;

		public NetworkTick currentTick;

		public double time;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref StateInfoCD stateInfo, ref MeleeAttackStateCD meleeState, ref AttackCooldownTimerCD cooldownTimer, in BehaviourTagsCD attackTags, in ObjectPropertiesCD properties)
		{
			if (!stateInfo.IsCurrentState(StateID.MeleeAttack))
			{
				return;
			}
			LocalTransform localTransform = attackHelper.localTransformLookup[entity];
			ref AnimationOrientationCD valueRW = ref attackHelper.animationOrientationLookup.GetRefRW(entity).ValueRW;
			DynamicBuffer<AnimationBuffer> animationBuffer = attackHelper.animationBufferLookup[entity];
			ref AnimationBufferPointer valueRW2 = ref attackHelper.animationBufferPointerLookup.GetRefRW(entity).ValueRW;
			float3 x = meleeState.hitDirection;
			if (meleeState.aimingAtEntity != Entity.Null && attackHelper.localTransformLookup.TryGetComponent(meleeState.aimingAtEntity, out var componentData))
			{
				bool flag = properties.Has(848748550);
				bool flag2 = properties.Has(-1825197047);
				bool flag3 = properties.Has(1014900390);
				bool flag4 = meleeState.internalState == 0 || meleeState.internalState == 1;
				if ((meleeState.internalState == 2 && !flag) || (flag4 && !flag2))
				{
					float3 position = localTransform.Position;
					x = componentData.Position - position;
					if (flag3)
					{
						x = ((math.abs(x.x) > math.abs(x.z)) ? new float3(math.sign(x.x), 0f, 0f) : new float3(0f, 0f, math.sign(x.z)));
					}
					meleeState.hitDirection = math.normalizesafe(x);
					valueRW.SetFacingDirectionFromVector(meleeState.hitDirection);
				}
			}
			if (meleeState.internalState == 0 && !meleeState.internalTimer.isRunning)
			{
				float newLifespan = properties.Get<float>(-1905185935);
				AnimationUtilities.TriggerAnimation(attackAnimID, currentTick, animationBuffer, ref valueRW2);
				valueRW.SetFacingDirectionFromVector(meleeState.hitDirection);
				meleeState.internalTimer.Start(time, newLifespan);
				meleeState.internalState = 1;
			}
			else if (meleeState.internalState == 1 && meleeState.internalTimer.isRunning && meleeState.internalTimer.IsTimerElapsed(time))
			{
				float newLifespan2 = properties.Get<float>(1367151486);
				bool num = properties.Has(-1515951795);
				float num2 = properties.Get<float>(1170370443);
				meleeState.internalTimer.Start(time, newLifespan2);
				meleeState.internalState = 2;
				CombatRadiusCD componentData2;
				float num3 = (combatRadiusLookup.TryGetComponent(meleeState.aimingAtEntity, out componentData2) ? componentData2.radius : 0f);
				float num4 = math.length(x) - num3;
				float num5 = 1f;
				if (summarizedConditionEffectsBufferLookup.HasComponent(entity))
				{
					num5 = EntityUtility.GetActiveMovementSpeedMultiplier(summarizedConditionEffectsBufferLookup[entity]);
				}
				float num6 = 0f;
				num6 = ((!num) ? ((num4 <= 0.5f) ? 0f : (num2 * num5 * math.clamp(math.length(x), 0f, 1f))) : (num2 * num5));
				if (attackHelper.physicsVelocityAccessor.TryGetComponent(entity, out var componentData3))
				{
					componentData3.SetLinear2D(meleeState.hitDirection * num6);
					ecb.SetComponent(entity, componentData3);
				}
				Hit(meleeState, properties, entity, ecb, effectEventBufferSingleton, attackHelper, attackTags, out var _, isStartHit: true);
				PlayerGhostExtrapolated componentData4;
				Entity entity2 = (playerGhostExtrapolatedLookup.TryGetComponent(meleeState.aimingAtEntity, out componentData4) ? componentData4.playerGhost : meleeState.aimingAtEntity);
				if (newCombatantsBufferLookup.HasComponent(entity2))
				{
					ecb.AppendToBuffer(entity2, new NewCombatantsBuffer
					{
						Target = entity
					});
				}
			}
			else if (meleeState.internalState == 2 && meleeState.internalTimer.isRunning && !meleeState.internalTimer.IsTimerElapsed(time))
			{
				float num7 = properties.Get<float>(545957351);
				if (meleeState.hitDone || !(meleeState.internalTimer.GetElapsedTime(time) >= num7))
				{
					return;
				}
				bool num8 = properties.Has(-2072102458);
				meleeState.hitDone = true;
				Hit(meleeState, properties, entity, ecb, effectEventBufferSingleton, attackHelper, attackTags, out var attackParams2, isStartHit: false);
				if (!num8)
				{
					return;
				}
				int damage = properties.Get<int>(-1854640576);
				ObjectID objectID = properties.Get<ObjectID>(2111390772);
				float3 center = localTransform.Position + attackParams2.attackOffset;
				bool num9 = attackParams2.boxHalfHorizontalWidth > 0f;
				float num10 = (num9 ? (attackParams2.boxHalfHorizontalWidth / 2f) : attackParams2.radius);
				float num11 = (num9 ? (attackParams2.boxHalfVerticalWidth / 2f) : attackParams2.radius);
				int2 int5 = new float3(center.x - num10, 0f, center.z - num11).RoundToInt2();
				int2 int6 = new float3(center.x + num10, 0f, center.z + num11).RoundToInt2();
				NativeList<int2> nativeList = new NativeList<int2>(Allocator.Temp);
				for (int i = int5.x; i <= int6.x; i++)
				{
					for (int j = int5.y; j <= int6.y; j++)
					{
						nativeList.Add(new int2(i, j));
					}
				}
				bool flag5 = false;
				NativeList<ColliderCastHit> outHits = new NativeList<ColliderCastHit>(Allocator.Temp);
				if (collisionWorld.BoxCastAll(center, quaternion.identity, new float3(num10, 1f, num11), float3.zero, 0f, ref outHits, new CollisionFilter
				{
					BelongsTo = uint.MaxValue,
					CollidesWith = 1024u
				}))
				{
					for (int k = 0; k < outHits.Length; k++)
					{
						if (indestructibleLookup.HasAndIsComponentEnabled(outHits[k].Entity))
						{
							flag5 = true;
							break;
						}
					}
				}
				for (int l = 0; l < nativeList.Length; l++)
				{
					int2 int7 = nativeList[l];
					ecb.AppendToBuffer(tileDamageBufferEntity, new TileDamageBuffer
					{
						damage = damage,
						position = int7,
						skipWallAndRootsLootDropOnDestroy = true,
						canHitGround = false,
						causedByEntity = entity,
						dontHitBridges = true,
						canHitLowColliders = true
					});
					if (!flag5)
					{
						TileCD top = tileLookup.GetTop(int7);
						if (top.tileType == TileType.ground && PugDatabase.TileExists(top.tileset, TileType.dugUpGround, databaseBankCD.databaseBankBlob))
						{
							ecb.AppendToBuffer(updatedTilesSingleton, new TileUpdateBuffer
							{
								command = TileUpdateBuffer.Command.Add,
								position = int7,
								tile = new TileCD
								{
									tileset = top.tileset,
									tileType = TileType.dugUpGround
								}
							});
						}
					}
					if (objectID == ObjectID.None || !tileLookup.GetTop(int7).tileType.IsWalkableTile())
					{
						continue;
					}
					bool flag6 = false;
					NativeList<ColliderCastHit> outHits2 = new NativeList<ColliderCastHit>(Allocator.Temp);
					if (collisionWorld.SphereCastAll(new float3(int7.x, 0f, int7.y), 0.49f, float3.zero, 0f, ref outHits2, new CollisionFilter
					{
						BelongsTo = uint.MaxValue,
						CollidesWith = 512u
					}))
					{
						for (int m = 0; m < outHits2.Length; m++)
						{
							if (attackHelper.objectDataLookup.TryGetComponent(outHits2[m].Entity, out var componentData5) && componentData5.objectID == objectID)
							{
								flag6 = true;
								break;
							}
						}
					}
					outHits2.Dispose();
					if (!flag6)
					{
						Entity e = EntityUtility.CreateEntity(ecb, objectID, 1, databaseBankCD.databaseBankBlob);
						ecb.SetComponent(e, LocalTransform.FromPosition(new float3(int7.x, 0f, int7.y)));
					}
				}
			}
			else if (meleeState.internalState == 2 && meleeState.internalTimer.isRunning && meleeState.internalTimer.IsTimerElapsed(time))
			{
				int num12 = properties.Get<int>(-1371537553);
				float min = properties.Get<float>(1106828234);
				float max = properties.Get<float>(-1913282363);
				meleeState.amountOfHitsDone++;
				if (meleeState.amountOfHitsDone >= num12)
				{
					Unity.Mathematics.Random random = Unity.Mathematics.Random.CreateFromIndex((uint)((double)(entity.Index + 1) + time * 1000000.0));
					float num13 = 1f / (1f + (summarizedConditionEffectsBufferLookup.HasComponent(entity) ? ((float)summarizedConditionEffectsBufferLookup[entity][40].value / 1000f + (float)summarizedConditionEffectsBufferLookup[entity][65].value / 1000f) : 0f));
					float newLifespan3 = random.NextFloat(min, max) * num13;
					cooldownTimer.Value.Start(time, newLifespan3);
					stateInfo.LeaveState();
				}
				else
				{
					meleeState.internalState = 0;
					meleeState.internalTimer.Stop();
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__StateInfoCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__MeleeAttackStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AttackCooldownTimerCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__BehaviourTagsCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MeleeAttackStateCD>(nativeArrayPtr3, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AttackCooldownTimerCD>(nativeArrayPtr4, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr5, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr6, i));
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
						Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MeleeAttackStateCD>(nativeArrayPtr3, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AttackCooldownTimerCD>(nativeArrayPtr4, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr5, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr6, nextRangeBegin));
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
					Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MeleeAttackStateCD>(nativeArrayPtr3, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AttackCooldownTimerCD>(nativeArrayPtr4, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr5, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr6, j));
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
					Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MeleeAttackStateCD>(nativeArrayPtr3, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AttackCooldownTimerCD>(nativeArrayPtr4, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr5, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr6, k));
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
		public BufferLookup<SummarizedConditionEffectsBuffer> __SummarizedConditionEffectsBuffer_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<CombatRadiusCD> __CombatRadiusCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhostExtrapolated> __PlayerGhostExtrapolated_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<NewCombatantsBuffer> __NewCombatantsBuffer_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<IndestructibleCD> __IndestructibleCD_RO_ComponentLookup;

		public MeleeAttackStateJob.InternalCompilerQueryAndHandleData __MeleeAttackStateSystem_MeleeAttackStateJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__SummarizedConditionEffectsBuffer_RO_BufferLookup = state.GetBufferLookup<SummarizedConditionEffectsBuffer>(isReadOnly: true);
			__CombatRadiusCD_RO_ComponentLookup = state.GetComponentLookup<CombatRadiusCD>(isReadOnly: true);
			__PlayerGhostExtrapolated_RO_ComponentLookup = state.GetComponentLookup<PlayerGhostExtrapolated>(isReadOnly: true);
			__NewCombatantsBuffer_RO_BufferLookup = state.GetBufferLookup<NewCombatantsBuffer>(isReadOnly: true);
			__IndestructibleCD_RO_ComponentLookup = state.GetComponentLookup<IndestructibleCD>(isReadOnly: true);
			__MeleeAttackStateSystem_MeleeAttackStateJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_00003B43_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_00003B43_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00003B43_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_00003B44_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00003B44_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00003B44_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnStartRunning_00003B45_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_00003B45_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_00003B45_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnStopRunning_00003B46_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStopRunning_00003B46_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_00003B46_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
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

	private AttackSystem.Helper _attackHelper;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_123778454_0;

	private EntityQuery __query_123778454_1;

	private EntityQuery __query_123778454_2;

	private EntityQuery __query_123778454_3;

	private EntityQuery __query_123778454_4;

	private EntityQuery __query_123778454_5;

	private EntityQuery __query_123778454_6;

	private EntityQuery __query_123778454_7;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
		state.RequireForUpdate<ClientServerTickRate>();
		state.RequireForUpdate<EffectEventBuffer>();
		state.RequireForUpdate<WorldInfoCD>();
		state.RequireForUpdate<MeleeAttackStateCD>();
	}

	[BurstCompile]
	public void OnStartRunning(ref SystemState state)
	{
		_attackHelper = new AttackSystem.Helper(ref state, __query_123778454_0.GetSingleton<ClientServerTickRate>().SimulationTickRate);
	}

	[BurstCompile]
	public void OnStopRunning(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		__query_123778454_1.TryGetSingleton<NetworkTime>(out var value);
		_attackHelper.Update(ref state, value.ServerTick, (uint)__query_123778454_0.GetSingleton<ClientServerTickRate>().SimulationTickRate);
		EntityCommandBuffer ecb = __query_123778454_2.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		MeleeAttackStateJob job = new MeleeAttackStateJob
		{
			tileLookup = _attackHelper.GetTileAccessor(),
			attackHelper = _attackHelper,
			collisionWorld = __query_123778454_3.GetSingleton<PhysicsWorldSingleton>().CollisionWorld,
			summarizedConditionEffectsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionEffectsBuffer_RO_BufferLookup, ref state),
			combatRadiusLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CombatRadiusCD_RO_ComponentLookup, ref state),
			playerGhostExtrapolatedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerGhostExtrapolated_RO_ComponentLookup, ref state),
			newCombatantsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__NewCombatantsBuffer_RO_BufferLookup, ref state),
			indestructibleLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__IndestructibleCD_RO_ComponentLookup, ref state),
			databaseBankCD = __query_123778454_4.GetSingleton<PugDatabase.DatabaseBankCD>(),
			ecb = ecb,
			effectEventBufferSingleton = __query_123778454_5.GetSingletonEntity(),
			tileDamageBufferEntity = __query_123778454_6.GetSingletonEntity(),
			updatedTilesSingleton = __query_123778454_7.GetSingletonEntity(),
			attackAnimID = 1203776827,
			currentTick = value.ServerTick,
			time = state.WorldUnmanaged.Time.ElapsedTime
		};
		state.Dependency = __ScheduleViaJobChunkExtension_0(ref job, __TypeHandle.__MeleeAttackStateSystem_MeleeAttackStateJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	private static void Hit(MeleeAttackStateCD meleeState, ObjectPropertiesCD properties, Entity entity, EntityCommandBuffer ecb, Entity effectEventBufferSingleton, AttackSystem.Helper attackHelper, BehaviourTagsCD attackTags, out AttackSystem.Helper.Parameters attackParams, bool isStartHit)
	{
		float num = properties.Get<float>(-1904742027);
		float3 float5 = properties.Get<float3>(1999023340);
		float num2 = properties.Get<float>(1153104871);
		float num3 = properties.Get<float>(-1811254130);
		float radius = properties.Get<float>(357566566);
		float pushback = properties.Get<float>(365293100);
		bool canHitLowTriggers = properties.Has(-342045033);
		bool bypassMaxDamagePerHit = properties.Has(-2060036972);
		bool flag = properties.Has(306671878);
		float3 attackOffset = new float3(0f, 0.5f, 0f) + meleeState.hitDirection * num + float5;
		float boxHalfHorizontalWidth = 0f;
		float boxHalfVerticalWidth = 0f;
		if (num3 > 0f && num2 > 0f)
		{
			bool num4 = math.abs(meleeState.hitDirection.x) > math.abs(meleeState.hitDirection.z);
			boxHalfHorizontalWidth = (num4 ? num3 : num2);
			boxHalfVerticalWidth = (num4 ? num2 : num3);
		}
		int damage = ((!isStartHit) ? meleeState.meleeDamage : 0);
		attackParams = new AttackSystem.Helper.Parameters
		{
			effectEventBufferSingleton = effectEventBufferSingleton,
			attacker = entity,
			attackOffset = attackOffset,
			radius = radius,
			boxHalfHorizontalWidth = boxHalfHorizontalWidth,
			boxHalfVerticalWidth = boxHalfVerticalWidth,
			damage = damage,
			playerDamage = meleeState.meleeDamage,
			pushback = pushback,
			skipWallAndRootsLootDropOnDestroy = true,
			canHitLowTriggers = canHitLowTriggers,
			bypassMaxDamagePerHit = bypassMaxDamagePerHit,
			canOnlyAttackType = (flag ? CanOnlyAttackType.EnemyAndPlayer : CanOnlyAttackType.All),
			behaviourTags = attackTags
		};
		attackHelper.Attack(ecb, in attackParams);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(ref MeleeAttackStateJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__MeleeAttackStateSystem_MeleeAttackStateJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__MeleeAttackStateSystem_MeleeAttackStateJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__MeleeAttackStateSystem_MeleeAttackStateJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__MeleeAttackStateSystem_MeleeAttackStateJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_123778454_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_123778454_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_123778454_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_123778454_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_123778454_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EffectEventBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_123778454_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileDamageBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_123778454_6 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileUpdateBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_123778454_7 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_00003B43_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00003B44_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_00003B45_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStopRunning_00003B46_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((MeleeAttackStateSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((MeleeAttackStateSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((MeleeAttackStateSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((MeleeAttackStateSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((MeleeAttackStateSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}
}
