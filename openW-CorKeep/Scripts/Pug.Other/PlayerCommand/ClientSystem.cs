#define PUG_ACHIEVEMENTS
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Inventory;
using PlayerState;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Scripting;

namespace PlayerCommand
{
	[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(RunSimulationSystemGroup))]
	public class ClientSystem : PugSimulationSystemBase
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private readonly struct IFE_1290591591_0
		{
			public struct ResolvedChunk
			{
				public IntPtr item1_IntPtr;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public Rpc Get(int index)
				{
					return InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Rpc>(item1_IntPtr, index);
				}
			}

			public struct TypeHandle
			{
				[ReadOnly]
				private ComponentTypeHandle<Rpc> item1_ComponentTypeHandle_RO;

				public TypeHandle(ref SystemState systemState)
				{
					item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<Rpc>(isReadOnly: true);
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

			public struct Enumerator : IEnumerator<Rpc>, IEnumerator, IDisposable
			{
				private InternalEntityQueryEnumerator _entityQueryEnumerator;

				private TypeHandle _typeHandle;

				private ResolvedChunk _resolvedChunk;

				private int _currentEntityIndex;

				private int _endEntityIndex;

				public Rpc Current => _resolvedChunk.Get(_currentEntityIndex);

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
				state.EntityManager.CompleteDependencyBeforeRO<Rpc>();
			}
		}

		private struct TypeHandle
		{
			public IFE_1290591591_0.TypeHandle __IFE_1290591591_0_TypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__IFE_1290591591_0_TypeHandle = new IFE_1290591591_0.TypeHandle(ref state);
			}
		}

		private NativeQueue<Rpc> rpcQueue;

		private NativeQueue<DebugRpc> debugRpcQueue;

		private int textRpcCount;

		private NativeQueue<TextRpc> textRpcQueue;

		private EntityArchetype rpcArchetype;

		private EntityArchetype debugRpcArchetype;

		private EntityArchetype textRpcArchetype;

		private EntityArchetype updatePlayerCustomizationRpcArchetype;

		private BeginSimulationEntityCommandBufferSystem ecbSystem;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_1290591591_0;

		private EntityQuery __query_1290591591_1;

		[Preserve]
		protected override void OnCreate()
		{
			UpdatesInRunGroup();
			rpcQueue = new NativeQueue<Rpc>(Allocator.Persistent);
			debugRpcQueue = new NativeQueue<DebugRpc>(Allocator.Persistent);
			textRpcQueue = new NativeQueue<TextRpc>(Allocator.Persistent);
			rpcArchetype = base.EntityManager.CreateArchetype(typeof(Rpc), typeof(SendRpcCommandRequest));
			debugRpcArchetype = base.EntityManager.CreateArchetype(typeof(DebugRpc), typeof(SendRpcCommandRequest));
			textRpcArchetype = base.EntityManager.CreateArchetype(typeof(TextRpc), typeof(SendRpcCommandRequest));
			updatePlayerCustomizationRpcArchetype = base.EntityManager.CreateArchetype(typeof(UpdatePlayerCustomizationRpc), typeof(SendRpcCommandRequest));
			ecbSystem = base.World.GetOrCreateSystemManaged<BeginSimulationEntityCommandBufferSystem>();
			base.OnCreate();
		}

		[Preserve]
		protected override void OnDestroy()
		{
			rpcQueue.Dispose();
			debugRpcQueue.Dispose();
			textRpcQueue.Dispose();
			base.OnDestroy();
		}

		[Preserve]
		protected override void OnUpdate()
		{
			EntityCommandBuffer entityCommandBuffer = ecbSystem.CreateCommandBuffer();
			Rpc item;
			while (rpcQueue.TryDequeue(out item))
			{
				Entity e = entityCommandBuffer.CreateEntity(rpcArchetype);
				entityCommandBuffer.SetComponent(e, item);
			}
			DebugRpc item2;
			while (debugRpcQueue.TryDequeue(out item2))
			{
				Entity e2 = entityCommandBuffer.CreateEntity(debugRpcArchetype);
				entityCommandBuffer.SetComponent(e2, item2);
			}
			TextRpc item3;
			while (textRpcQueue.TryDequeue(out item3))
			{
				Entity e3 = entityCommandBuffer.CreateEntity(textRpcArchetype);
				entityCommandBuffer.SetComponent(e3, item3);
			}
			foreach (Rpc item4 in IFE_1290591591_0.Query(__query_1290591591_0, __TypeHandle.__IFE_1290591591_0_TypeHandle, ref base.CheckedStateRef))
			{
				switch (item4.command)
				{
				case Command.MapPing:
				{
					PlayerController playerController2 = Manager.memory.GetEntityMono(item4.entity0) as PlayerController;
					if (playerController2 != Manager.main.player && playerController2 != null)
					{
						Manager.ui.mapUI.Ping(playerController2, item4.position0.ToFloat2());
					}
					break;
				}
				case Command.ResetSkillTalentTree:
				{
					PlayerController playerController = Manager.memory.GetEntityMono(item4.entity0) as PlayerController;
					if (playerController != null && playerController.isLocal)
					{
						Manager.saves.ResetTalentTree((SkillID)item4.int0);
					}
					break;
				}
				case Command.Message:
					Manager.ui.chatWindow.AddInfoText((ChatWindow.MessageTextType)item4.int0);
					break;
				case Command.ServerSavedNotification:
				{
					PlayerController player = Manager.main.player;
					if (player != null && player.isLocal && Manager.networking != null)
					{
						Manager.saves.SetLastActiveSession(new Unity.Entities.Hash128(Manager.networking.serverSessionId));
					}
					break;
				}
				case Command.AchievementUnlocked:
				{
					AchievementID int5 = (AchievementID)item4.int0;
					Manager.achievements.TriggerAchievement(int5);
					break;
				}
				default:
					Debug.LogError("Received unexpected player command rpc on client");
					break;
				}
			}
			base.EntityManager.DestroyEntity(__query_1290591591_1);
			base.OnUpdate();
		}

		public static void DealDamageToEntity(in PlayerAttackAspect playerAttackAspect, in PlayerAttackShared playerAttackShared, in PlayerAttackLookups playerAttackLookups, Entity entity, float3 position, bool shouldShowHitFeedbackOnHitEntityPart, Entity hitEntityPart, NativeArray<SummarizedConditionsBuffer> conditionsAtHit, NativeArray<SummarizedConditionEffectsBuffer> conditionEffectsAtHit, int damage, bool isRanged, bool isMagic, Entity damagedByEntity, float3 damagePosition, out int attackerHealthChange, out int ownerHealthChange, out int attackerManaChange, out int damageAfterReduction, out bool shouldBeKnockedback, out bool spawnThunderBeam, out bool spawnOctopusBossProjectile, out bool spawnScarabBossProjectile, out bool wasKilled, bool showDamageNumber = true, bool isExplosive = false, bool isDigging = false, bool attackWoundup = false, bool bypassMaxDamagePerHit = false, bool godMode = false, bool isReverseDamage = false)
		{
			NativeList<ConditionData> conditionsToApply = new NativeList<ConditionData>(Allocator.Temp);
			NativeList<ConditionData> conditionsToApplyToAttacker = new NativeList<ConditionData>(Allocator.Temp);
			NativeList<ConditionID> conditionsToRemove = new NativeList<ConditionID>(Allocator.Temp);
			NativeList<ConditionID> conditionsToRemoveFromAttacker = new NativeList<ConditionID>(Allocator.Temp);
			playerAttackLookups.factionLookup.TryGetComponent(damagedByEntity, out var componentData);
			EntityUtility.GetDamageInfo(in playerAttackAspect, in playerAttackShared, in playerAttackLookups, entity, damagedByEntity, damage, damagePosition.RoundToInt2(), isRanged, isMagic, isReverseDamage, conditionsAtHit, conditionEffectsAtHit, out damageAfterReduction, out var damageDoneBeforeReduction, out wasKilled, out var _, conditionsToApply, conditionsToApplyToAttacker, conditionsToRemove, conditionsToRemoveFromAttacker, componentData, out var didCrit, out var didDodge, out attackerHealthChange, out ownerHealthChange, out attackerManaChange, out spawnThunderBeam, out spawnOctopusBossProjectile, out spawnScarabBossProjectile, out shouldBeKnockedback, out var spawnMinion, isExplosive, isDigging, attackWoundup, bypassMaxDamagePerHit, godMode);
			if (playerAttackLookups.moveToPredictedByCombatInteractionLookup.HasComponent(entity))
			{
				playerAttackLookups.moveToPredictedByCombatInteractionLookup.GetRefRW(entity).ValueRW.SetLastInteractionTick(playerAttackShared.currentTick);
			}
			if (playerAttackLookups.playerGhostLookup.HasComponent(entity))
			{
				float3 position2 = playerAttackLookups.localTransformLookup[entity].Position;
				Entity entity2 = playerAttackAspect.entity;
				AttackPlayerSystem.RegisterPlayerHitShared registerPlayerHitShared = new AttackPlayerSystem.RegisterPlayerHitShared
				{
					ecb = playerAttackShared.ecb,
					currentTick = playerAttackShared.currentTick,
					databaseBank = playerAttackShared.databaseBank,
					physicsWorld = playerAttackShared.physicsWorld,
					physicsWorldHistory = playerAttackShared.physicsWorldHistory,
					worldInfo = playerAttackShared.worldInfo,
					conditionsTableCD = playerAttackShared.conditionsTableCD,
					isFirstTimeFullyPredictingTick = playerAttackShared.isFirstTimeFullyPredictingTick,
					tickRate = playerAttackShared.tickRate,
					inventoryChangeBufferEntity = playerAttackShared.inventoryChangeBufferEntity
				};
				AttackPlayerSystem.RegisterPlayerHitLookup registerPlayerHitLookup = new AttackPlayerSystem.RegisterPlayerHitLookup
				{
					playerStateLookup = playerAttackLookups.playerStateLookup,
					summarizeConiditionsLookup = playerAttackLookups.summarizeConiditionsLookup,
					factionLookup = playerAttackLookups.factionLookup,
					localTransformLookup = playerAttackLookups.localTransformLookup,
					objectCategoryTagsLookup = playerAttackLookups.objectCategoryTagsLookup,
					entityPartLookup = playerAttackLookups.entityPartLookup,
					ghostInstanceLookup = playerAttackLookups.ghostInstanceLookup,
					healthLookup = playerAttackLookups.healthLookup,
					objectTypeLookup = playerAttackLookups.objectTypeLookup,
					summarizeConiditionsEffectsLookup = playerAttackLookups.summarizeConiditionsEffectsLookup,
					conditionsBufferLookup = playerAttackLookups.conditionsBufferLookup,
					useOffHandStateLookup = playerAttackLookups.useOffHandStateLookup,
					animationOrientationLookup = playerAttackLookups.animationOrientationLookup,
					immuneToPushBackLookup = playerAttackLookups.immuneToPushBackLookup,
					physicsVelocityLookup = playerAttackLookups.physicsVelocityLookup,
					immuneToDamageLookup = playerAttackLookups.immuneToDamageLookup,
					attackContinuouslyLookup = playerAttackLookups.attackContinuouslyLookup,
					projectileLookup = playerAttackLookups.projectileLookup,
					destroyTimerLookup = playerAttackLookups.destroyTimerLookup,
					ghostOwnerLookup = playerAttackLookups.ghostOwnerLookup,
					behaviourTagsLookup = playerAttackLookups.behaviourTagsLookup,
					playerInvincibilityLookup = playerAttackLookups.playerInvincibilityLookup,
					physicsMassLookup = playerAttackLookups.physicsMassLookup,
					ghostEffectEventBufferLookup = playerAttackLookups.ghostEffectEventBufferLookup,
					ghostEffectEventBufferPointerLookup = playerAttackLookups.ghostEffectEventBufferPointerLookup,
					manaLookup = playerAttackLookups.manaLookup,
					magicBarrierLookup = playerAttackLookups.magicBarrierLookup,
					lastDamageTakenTimeLookup = playerAttackLookups.lastDamageTakenTimeLookup,
					randomLookup = playerAttackLookups.randomLookup,
					mortarProjectileLookup = playerAttackLookups.mortarProjectileLookup,
					reduceDurabilityOfAllEquipmentTriggerLookup = playerAttackLookups.reduceDurabilityOfAllEquipmentTriggerLookup,
					godModeLookup = playerAttackLookups.godModeLookup,
					objectDataLookup = playerAttackLookups.objectDataLookup,
					ownerLookup = playerAttackLookups.ownerLookup,
					inventoryChangeBuffer = playerAttackLookups.inventoryChangeBufferLookup,
					equipmentLookup = playerAttackLookups.equipmentLookup,
					dealDamageToEntityBuffer = playerAttackLookups.dealDamageToEntityBufferLookup,
					animationBufferLookup = playerAttackLookups.animationBufferLookup,
					animationBufferPointerLookup = playerAttackLookups.animationBufferPointerLookup,
					containedObjectsBuffer = playerAttackLookups.containedObjectsBufferLookup,
					receivedPushbackLookup = playerAttackLookups.receivedPushbackLookup,
					moveToPredictedByCombatInteractionLookup = playerAttackLookups.moveToPredictedByCombatInteractionLookup,
					moveToPredictedByPushbackLookup = playerAttackLookups.moveToPredictedByPushbackLookup,
					phaseTransitionStateLookup = playerAttackLookups.phaseTransitionStateLookup,
					simulateLookup = playerAttackLookups.simulateLookup,
					playerGhostLookup = playerAttackLookups.playerGhostLookup,
					mortarProjectileDamageEffectLookup = playerAttackLookups.mortarProjectileDamageEffectLookup,
					piercingProjectileLookup = playerAttackLookups.piercingProjectileLookup,
					petLookup = playerAttackLookups.petLookup,
					minionLookup = playerAttackLookups.minionLookup,
					bossLookup = playerAttackLookups.bossLookup,
					enemyLookup = playerAttackLookups.enemyLookup
				};
				if (!AttackPlayerSystem.RegisterPlayerHit(entity, entity2, in registerPlayerHitShared, in registerPlayerHitLookup, damagedByEntity, position, damagePosition, position2, playerAttackShared.tileAccessor, damage, DamageEffectType.None, float3.zero, 0, ref playerAttackLookups.randomLookup.GetRefRW(playerAttackAspect.entity).ValueRW.Value, 0f, 0f, isExplosive, isExplosiveDamageFromBomb: false, out var _, 0, isRanged: false, isBoss: false, isMinion: false, isPet: false, treatDodgeAsHit: false, checkVisibility: false, isReverseDamage))
				{
					shouldBeKnockedback = false;
				}
				return;
			}
			if (playerAttackLookups.animationBufferLookup.HasComponent(entity))
			{
				bool flag = playerAttackLookups.isExplosiveLookup.HasComponent(entity);
				bool flag2 = playerAttackLookups.bossLookup.HasComponent(entity);
				if (wasKilled && playerAttackLookups.dontDestroyOnZeroHealthLookup.TryGetComponent(entity, out var componentData2) && !componentData2.disabled)
				{
					if (playerAttackLookups.animateDontDestroyOnZeroHealthLookup.HasComponent(entity))
					{
						AnimationUtilities.TriggerAnimation(2053665356, playerAttackShared.currentTick, playerAttackLookups.animationBufferLookup[entity], ref playerAttackLookups.animationBufferPointerLookup.GetRefRW(entity).ValueRW);
					}
				}
				else if (wasKilled && !flag && !flag2)
				{
					ref LocalTransform valueRW = ref playerAttackLookups.localTransformLookup.GetRefRW(entity).ValueRW;
					if ((!(hitEntityPart != Entity.Null) || !(hitEntityPart != entity)) && playerAttackLookups.enemyLookup.HasComponent(entity))
					{
						valueRW.Position = position;
					}
					if (playerAttackLookups.physicsVelocityLookup.HasComponent(entity))
					{
						playerAttackLookups.physicsVelocityLookup.GetRefRW(entity).ValueRW = default(PhysicsVelocity);
					}
				}
				else if (damageAfterReduction > 0 && spawnMinion)
				{
					if (damagedByEntity == playerAttackAspect.entity)
					{
						MinionHandlerSystem.SpawnMinion(playerAttackAspect.entity, in playerAttackAspect.equippedObjectCD.ValueRO, playerAttackLookups.localTransformLookup[playerAttackAspect.entity].Position + new float3(0f, 0f, 0.4f), playerAttackLookups.levelLookup, playerAttackLookups.secondaryUseLookup, in playerAttackShared.databaseBank.databaseBankBlob, playerAttackShared.ecb, playerAttackLookups.healthLookup, playerAttackLookups.randomLookup);
					}
					else
					{
						Debug.LogError("Not supporting enemy deal damage that should spawn minion");
					}
				}
			}
			for (int i = 0; i < conditionsToApply.Length; i++)
			{
				EntityUtility.AddOrRefreshCondition(conditionsToApply[i], playerAttackLookups.conditionsBufferLookup[entity], playerAttackShared.conditionsTableCD, playerAttackShared.currentTick, playerAttackShared.tickRate, playerAttackLookups.summarizeConiditionsLookup[entity]);
				if (conditionsToApply[i].conditionID == ConditionID.Poisoned)
				{
					int conditionValue = EntityUtility.GetConditionValue(ConditionID.IncreaseCritChanceAfterPoisonApply, damagedByEntity, playerAttackLookups.summarizeConiditionsLookup);
					if (conditionValue > 0)
					{
						EntityUtility.AddOrRefreshCondition(new ConditionData
						{
							conditionID = ConditionID.CritChanceIncreaseFromPoisonApply,
							value = conditionValue,
							duration = 5f
						}, playerAttackLookups.conditionsBufferLookup[damagedByEntity], playerAttackShared.conditionsTableCD, playerAttackShared.currentTick, playerAttackShared.tickRate, playerAttackLookups.summarizeConiditionsLookup[damagedByEntity]);
					}
				}
			}
			conditionsToApply.Dispose();
			for (int j = 0; j < conditionsToApplyToAttacker.Length; j++)
			{
				EntityUtility.AddOrRefreshCondition(conditionsToApplyToAttacker[j], playerAttackLookups.conditionsBufferLookup[damagedByEntity], playerAttackShared.conditionsTableCD, playerAttackShared.currentTick, playerAttackShared.tickRate, playerAttackLookups.summarizeConiditionsLookup[damagedByEntity]);
			}
			conditionsToApplyToAttacker.Dispose();
			for (int k = 0; k < conditionsToRemove.Length; k++)
			{
				EntityUtility.RemoveCondition(conditionsToRemove[k], playerAttackLookups.conditionsBufferLookup[entity]);
			}
			conditionsToRemove.Dispose();
			for (int l = 0; l < conditionsToRemoveFromAttacker.Length; l++)
			{
				EntityUtility.RemoveCondition(conditionsToRemoveFromAttacker[l], playerAttackLookups.conditionsBufferLookup[damagedByEntity]);
			}
			conditionsToRemoveFromAttacker.Dispose();
			if (playerAttackLookups.dropAllItemsOnHitLookup.TryGetComponent(entity, out var componentData3))
			{
				float3 position3 = playerAttackLookups.localTransformLookup[entity].Position + componentData3.dropOffset;
				playerAttackLookups.inventoryChangeBufferLookup[playerAttackShared.inventoryChangeBufferEntity].Add(new InventoryChangeBuffer
				{
					playerEntity = playerAttackAspect.entity,
					inventoryChangeData = Create.DropAllItems(entity, position3, default(Entity), randomOffset: true)
				});
			}
			if (showDamageNumber && !godMode)
			{
				ObjectDataCD objectDataCD = playerAttackLookups.objectDataLookup[entity];
				ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(objectDataCD.objectID, playerAttackShared.databaseBank.databaseBankBlob, objectDataCD.variation);
				if (damagedByEntity != Entity.Null && (damageAfterReduction > 0 || didDodge) && !playerAttackLookups.destructibleObjectLookup.HasComponent(entity) && (entityObjectInfo.objectType == ObjectType.Creature || entityObjectInfo.objectType == ObjectType.PlayerType) && playerAttackLookups.ghostEffectEventBufferLookup.TryGetBuffer(entity, out var bufferData))
				{
					Entity entity3 = entity;
					if (shouldShowHitFeedbackOnHitEntityPart && hitEntityPart != Entity.Null)
					{
						entity3 = hitEntityPart;
					}
					RefRW<GhostEffectEventBufferPointerCD> refRW = playerAttackLookups.ghostEffectEventBufferPointerLookup.GetRefRW(entity);
					bufferData.AddToRingBuffer(ref refRW.ValueRW, new GhostEffectEventBuffer
					{
						Tick = playerAttackShared.currentTick,
						value = new EffectEventCD
						{
							entity = entity3,
							effectID = (didDodge ? EffectID.Dodge : (didCrit ? EffectID.CritNumber : EffectID.WhiteDamageNumber)),
							value1 = damageAfterReduction,
							value2 = 0,
							entity2 = damagedByEntity
						}
					});
				}
			}
			EntityUtility.DealDamage(in playerAttackAspect, in playerAttackShared, in playerAttackLookups, entity, hitEntityPart, damagedByEntity, damageDoneBeforeReduction, damagePosition, shouldBeKnockedback ? 1 : 0, new float3((!isExplosive && !isRanged) ? 1 : 0, bypassMaxDamagePerHit ? 1 : 0, 0f), wasKilled, isExplosive);
		}

		public void DebugMarkConsoleCommandUsed()
		{
			debugRpcQueue.Enqueue(new DebugRpc
			{
				command = DebugCommand.ConsoleCommandUsed
			});
		}

		public void DebugSetHealth(Entity entity, int health, bool isPermaDeath = false)
		{
			debugRpcQueue.Enqueue(new DebugRpc
			{
				command = DebugCommand.SetPlayerHealth,
				entity0 = entity,
				int0 = health,
				int1 = (isPermaDeath ? 1 : 0)
			});
		}

		public void DebugCreateAndDropEntity(ObjectID objectID, float3 worldPosition, int amount = 1, Entity pullTowardsPlayerEntity = default(Entity), int variation = 0)
		{
			debugRpcQueue.Enqueue(new DebugRpc
			{
				command = DebugCommand.CreateAndDropItem,
				int0 = (int)objectID,
				position0 = worldPosition,
				int1 = variation,
				entity0 = pullTowardsPlayerEntity,
				position1 = new float3(amount, 0f, 0f)
			});
		}

		public void DebugSetPlayerImmuneToDamage(Entity entity, bool immune)
		{
			debugRpcQueue.Enqueue(new DebugRpc
			{
				command = DebugCommand.SetPlayerImmuneToDamage,
				entity0 = entity,
				bool0 = immune
			});
		}

		public void DebugSetSkillValue(Entity entity, SkillID skillID, int amount)
		{
			debugRpcQueue.Enqueue(new DebugRpc
			{
				command = DebugCommand.SetSkillValue,
				entity0 = entity,
				int0 = (int)skillID,
				int1 = amount
			});
		}

		public void DebugSetPlayerState(Entity entity, PlayerStateEnum playerState, bool locked = false)
		{
			debugRpcQueue.Enqueue(new DebugRpc
			{
				command = DebugCommand.SetPlayerState,
				entity0 = entity,
				int0 = (int)playerState,
				bool0 = locked
			});
		}

		public void DebugSetGodMode(Entity entity, bool enabled)
		{
			debugRpcQueue.Enqueue(new DebugRpc
			{
				command = DebugCommand.SetGodMode,
				bool0 = enabled,
				entity0 = entity
			});
		}

		public void DebugSetMana(Entity entity, int mana)
		{
			debugRpcQueue.Enqueue(new DebugRpc
			{
				command = DebugCommand.SetPlayerMana,
				entity0 = entity,
				int0 = mana
			});
		}

		public void SetHealthForStreamIntegration(Entity entity, int health, bool isPermaDeath = false)
		{
			rpcQueue.Enqueue(new Rpc
			{
				command = Command.SetPlayerHealth,
				entity0 = entity,
				int0 = health,
				int1 = (isPermaDeath ? 1 : 0)
			});
		}

		public void DebugSetBaseMaxHealth(Entity entity, int maxHealth)
		{
			debugRpcQueue.Enqueue(new DebugRpc
			{
				command = DebugCommand.SetPlayerBaseMaxHealth,
				entity0 = entity,
				int0 = maxHealth
			});
		}

		public void SetPlayerManaForStreamIntegration(Entity entity, int mana)
		{
			rpcQueue.Enqueue(new Rpc
			{
				command = Command.SetPlayerManaForStreamIntegration,
				entity0 = entity,
				int0 = mana
			});
		}

		public void DebugSetHunger(Entity entity, int hunger)
		{
			debugRpcQueue.Enqueue(new DebugRpc
			{
				command = DebugCommand.SetPlayerHunger,
				entity0 = entity,
				int0 = hunger
			});
		}

		public void SetName(Entity entity, string name)
		{
			textRpcQueue.Enqueue(new TextRpc
			{
				command = Command.SetName,
				entity = entity,
				rpcId = ++textRpcCount,
				text = name
			});
		}

		public void SetAuthor(Entity entity, string author)
		{
			textRpcQueue.Enqueue(new TextRpc
			{
				command = Command.SetAuthor,
				entity = entity,
				rpcId = ++textRpcCount,
				text = author
			});
		}

		public void SetWorldLabelVisibility(Entity entity, int index)
		{
			rpcQueue.Enqueue(new Rpc
			{
				command = Command.SetWorldLabelVisibility,
				entity0 = entity,
				int0 = index
			});
		}

		public void SetCattleBreedable(Entity entity, int index)
		{
			rpcQueue.Enqueue(new Rpc
			{
				command = Command.SetCattleBreedable,
				entity0 = entity,
				bool0 = (index != 0)
			});
		}

		public void SetDescription(Entity entity, string description)
		{
			int num = 0;
			int num2 = description.Length;
			int rpcId = ++textRpcCount;
			TextRpc value = new TextRpc
			{
				command = Command.SetDescription,
				entity = entity,
				rpcId = rpcId
			};
			while (num2 >= 0)
			{
				value.text = description.Substring(num, math.min(value.text.Capacity, num2));
				textRpcQueue.Enqueue(value);
				num += value.text.Capacity;
				num2 -= value.text.Capacity;
			}
		}

		public void CreateMapUI(float3 worldPosition, int activeUserMapMarkerType)
		{
			rpcQueue.Enqueue(new Rpc
			{
				command = Command.CreateMapUI,
				int0 = activeUserMapMarkerType,
				position0 = worldPosition
			});
		}

		public void DebugCreateEntity(ObjectID objectID, float3 worldPosition, int variation = 0)
		{
			debugRpcQueue.Enqueue(new DebugRpc
			{
				command = DebugCommand.CreateEntity,
				int0 = (int)objectID,
				int1 = variation,
				position0 = worldPosition
			});
		}

		public void CreateEntityForStreamIntegration(ObjectID objectID, float3 position, int variation = 0)
		{
			rpcQueue.Enqueue(new Rpc
			{
				command = Command.CreateEntityForStreamIntegration,
				int0 = (int)objectID,
				int1 = variation,
				position0 = EntityMonoBehaviour.ToWorldFromRender(position)
			});
		}

		public void CreateMortarEntityForStreamIntegration(ObjectID objectID, float3 position, int damage, int variation = 0)
		{
			rpcQueue.Enqueue(new Rpc
			{
				command = Command.CreateMortarEntityForStreamIntegration,
				int0 = (int)objectID,
				int1 = variation,
				int2 = damage,
				position0 = EntityMonoBehaviour.ToWorldFromRender(position)
			});
		}

		public void DestroyAllEntitiesForStreamIntegration(float3 position)
		{
			rpcQueue.Enqueue(new Rpc
			{
				command = Command.DestroyAllEntitiesForStreamIntegration,
				position0 = EntityMonoBehaviour.ToWorldFromRender(position)
			});
		}

		public void EnableSuperManForStreamIntegration(Entity entity, float multiple, float duration)
		{
			rpcQueue.Enqueue(new Rpc
			{
				command = Command.EnableSuperManForStreamIntegration,
				entity0 = entity,
				position0 = new float3(multiple, 0f, 0f),
				float0 = duration
			});
		}

		public void CreateAndDropEntity(ObjectID objectID, float3 worldPosition, int amount = 1, Entity pullTowardsPlayerEntity = default(Entity), int variation = 0)
		{
			rpcQueue.Enqueue(new Rpc
			{
				command = Command.CreateAndDropItem,
				int0 = (int)objectID,
				position0 = worldPosition,
				int1 = variation,
				entity0 = pullTowardsPlayerEntity,
				position1 = new float3(amount, 0f, 0f)
			});
		}

		public void SetPlayerImmuneToDamage(Entity entity, bool immune)
		{
			rpcQueue.Enqueue(new Rpc
			{
				command = Command.SetPlayerImmuneToDamage,
				entity0 = entity,
				bool0 = immune
			});
		}

		public void SetPlayerPosition(Entity entity, Vector3 worldPosition)
		{
			debugRpcQueue.Enqueue(new DebugRpc
			{
				command = DebugCommand.SetPlayerPosition,
				entity0 = entity,
				position0 = worldPosition
			});
		}

		public void PlayMusicSheet(Entity entity, ObjectID sheet, InstrumentType instrumentType)
		{
			rpcQueue.Enqueue(new Rpc
			{
				command = Command.PlayMusicSheet,
				entity0 = entity,
				int0 = (int)sheet,
				int1 = (int)instrumentType
			});
		}

		public void StopPlayingMusicSheet(Entity entity)
		{
			rpcQueue.Enqueue(new Rpc
			{
				command = Command.PlayMusicSheet,
				entity0 = entity,
				int0 = 0,
				int1 = 0
			});
		}

		public void DebugDestroyEntity(Entity entity, Entity playerEntity, bool dontDrop = false)
		{
			debugRpcQueue.Enqueue(new DebugRpc
			{
				command = DebugCommand.Destroy,
				entity0 = entity,
				entity1 = playerEntity,
				bool0 = dontDrop
			});
		}

		public void DebugFillTile(TileType tileType, int tileset, int2 bottomLeft, int2 size)
		{
			debugRpcQueue.Enqueue(new DebugRpc
			{
				command = DebugCommand.FillTile,
				position0 = bottomLeft.ToFloat3(),
				position1 = size.ToFloat3(),
				int0 = (int)tileType,
				int1 = tileset
			});
		}

		public void DebugClearTile(int2 bottomLeft, int2 size)
		{
			debugRpcQueue.Enqueue(new DebugRpc
			{
				command = DebugCommand.ClearTile,
				position0 = bottomLeft.ToFloat3(),
				position1 = size.ToFloat3()
			});
		}

		public static void CreateTileDamage(Entity causedByEntity, DynamicBuffer<TileDamageBuffer> tileDamageBuffer, int2 worldPosition, int damage, in WorldInfoCD worldInfoCD, Entity pullAnyLootTowardsPlayerEntity = default(Entity), bool canDamageGround = false, bool pullAnyLootToPlayer = false, bool damagedByExplosion = false, bool dontPlayDamageTileEffect = true)
		{
			bool flag = damage == int.MaxValue;
			if (worldInfoCD.IsWorldModeEnabled(WorldMode.Creative) || !flag)
			{
				tileDamageBuffer.Add(new TileDamageBuffer
				{
					position = worldPosition,
					damage = damage,
					causedByEntity = causedByEntity,
					canHitGround = canDamageGround,
					canHitLowColliders = true,
					pullAnyLootToPlayer = pullAnyLootToPlayer,
					damagedByExplosion = damagedByExplosion,
					bypassMaxDamagePerHit = flag,
					skipWallAndRootsLootDropOnDestroy = flag,
					dontPlayDamageTileEffect = dontPlayDamageTileEffect
				});
			}
		}

		public void RemoveLoginImmunity(Entity entity)
		{
			rpcQueue.Enqueue(new Rpc
			{
				command = Command.RemoveLoginImmunity,
				entity0 = entity
			});
		}

		public void AddOrRefreshCondition(Entity entity, ConditionID id, int value, float duration)
		{
			rpcQueue.Enqueue(new Rpc
			{
				command = Command.AddOrRefreshCondition,
				int0 = (int)id,
				int1 = value,
				float0 = duration,
				entity0 = entity
			});
		}

		public static void SpawnProjectile(in PlayerAttackShared shared, in PlayerAttackLookups lookup, ObjectID objectID, float3 worldPosition, float3 direction, Entity owner, int damage, bool weaponIsReinforced, ref Unity.Mathematics.Random random, int level = 0, bool controlledByPlayer = true, Entity entityToFollow = default(Entity))
		{
			ConditionsTableCD conditionsTableCD = shared.conditionsTableCD;
			EntityUtility.SpawnProjectile(lookup.ghostOwnerLookup, lookup.behaviourTagsLookup, lookup.summarizeConiditionsLookup, lookup.factionLookup, shared.ecb, worldPosition, shared.databaseBank.databaseBankBlob, objectID, damage, 0f, direction, owner, conditionsTableCD, weaponIsReinforced, level, ref random, lookup.piercingProjectileLookup, controlledByPlayer, entityToFollow);
		}

		public static void SpawnProjectile(in AttackPlayerSystem.RegisterPlayerHitShared shared, in AttackPlayerSystem.RegisterPlayerHitLookup lookup, ObjectID objectID, float3 worldPosition, float3 direction, Entity owner, int damage, bool weaponIsReinforced, ref Unity.Mathematics.Random random, int level = 0, bool controlledByPlayer = true, Entity entityToFollow = default(Entity))
		{
			ConditionsTableCD conditionsTableCD = shared.conditionsTableCD;
			EntityUtility.SpawnProjectile(lookup.ghostOwnerLookup, lookup.behaviourTagsLookup, lookup.summarizeConiditionsLookup, lookup.factionLookup, shared.ecb, worldPosition, shared.databaseBank.databaseBankBlob, objectID, damage, 0f, direction, owner, conditionsTableCD, weaponIsReinforced, level, ref random, lookup.piercingProjectileLookup, controlledByPlayer, entityToFollow);
		}

		public static void SpawnExplosion(in AttackPlayerSystem.RegisterPlayerHitShared registerPlayerHitShared, in AttackPlayerSystem.RegisterPlayerHitLookup registerPlayerHitLookup, ObjectID objectID, float3 worldPosition, Entity owner, int damage, float radius, ref Unity.Mathematics.Random random, bool controlledByPlayer = true)
		{
			EntityUtility.SpawnExplosion(registerPlayerHitShared.ecb, worldPosition, registerPlayerHitShared.databaseBank.databaseBankBlob, objectID, damage, damage, owner, radius, registerPlayerHitShared.conditionsTableCD, ref random, registerPlayerHitLookup.factionLookup, registerPlayerHitLookup.behaviourTagsLookup, registerPlayerHitLookup.summarizeConiditionsLookup, registerPlayerHitLookup.summarizeConiditionsEffectsLookup);
		}

		public static void SpawnMortar(in AttackPlayerSystem.RegisterPlayerHitShared registerPlayerHitShared, in AttackPlayerSystem.RegisterPlayerHitLookup registerPlayerHitLookup, ObjectID objectID, float3 worldPosition, float3 targetPosition, Entity owner, int damage, int level, ref Unity.Mathematics.Random random, bool controlledByPlayer = true)
		{
			EntityUtility.SpawnMortarProjectile(registerPlayerHitShared.ecb, worldPosition, registerPlayerHitShared.databaseBank.databaseBankBlob, objectID, damage, targetPosition, owner, 0f, 0f, 0f, 0f, level, registerPlayerHitShared.conditionsTableCD, ref random, registerPlayerHitLookup.factionLookup, registerPlayerHitLookup.behaviourTagsLookup, registerPlayerHitLookup.summarizeConiditionsLookup, registerPlayerHitLookup.mortarProjectileLookup, registerPlayerHitLookup.mortarProjectileDamageEffectLookup);
		}

		public static void SpawnThunderBeam(in PlayerAttackShared playerAttackShared, in PlayerAttackLookups playerAttackLookups, float3 worldPosition, float3 direction, Entity owner, int damage, RefRW<RandomCD> random)
		{
			EntityUtility.SpawnThunderBeam(playerAttackLookups.birdBossLookup, playerAttackLookups.attackContinuouslyLookup, playerAttackLookups.factionLookup, playerAttackShared.ecb, worldPosition, playerAttackShared.databaseBank.databaseBankBlob, direction, owner, damage, random);
		}

		public void SetSkillTalentCondition(Entity entity, ConditionData conditionData)
		{
			rpcQueue.Enqueue(new Rpc
			{
				command = Command.SetSkillTalentCondition,
				int0 = (int)conditionData.conditionID,
				int1 = conditionData.value,
				entity0 = entity
			});
		}

		public void LowerTheGreatWall(Entity entity)
		{
			rpcQueue.Enqueue(new Rpc
			{
				command = Command.LowerTheGreatWall,
				entity0 = entity
			});
		}

		public void UnlockSouls(Entity entity)
		{
			rpcQueue.Enqueue(new Rpc
			{
				command = Command.UnlockSouls,
				entity0 = entity
			});
		}

		public void CollectSoul(Entity entity, SoulID soulID)
		{
			rpcQueue.Enqueue(new Rpc
			{
				command = Command.CollectSoul,
				int0 = (int)soulID,
				entity0 = entity
			});
		}

		public void MarkEnemyAsKilled(ObjectID objectID)
		{
			rpcQueue.Enqueue(new Rpc
			{
				command = Command.MarkEnemyAsKilled,
				int0 = (int)objectID
			});
		}

		public void CompleteQuest(Entity entity, QuestID questID)
		{
			rpcQueue.Enqueue(new Rpc
			{
				command = Command.CompleteQuest,
				int0 = (int)questID,
				entity0 = entity
			});
		}

		public void DebugToggleEnemyBehaviour()
		{
			debugRpcQueue.Enqueue(new DebugRpc
			{
				command = DebugCommand.ToggleEnemyBehaviour
			});
		}

		public void DebugSetMovementSpeed(Entity entity, float multiplier)
		{
			if (EntityUtility.TryGetComponentData<PlayerMovementCD>(entity, base.World, out var value))
			{
				value.movementSpeed = multiplier;
				EntityUtility.SetComponentData(entity, base.World, value);
				debugRpcQueue.Enqueue(new DebugRpc
				{
					command = DebugCommand.SetMovementSpeedMultiplier,
					entity0 = entity,
					position0 = new float3(multiplier, 0f, 0f)
				});
			}
		}

		public void DebugEnableSuperMan(Entity entity, float multiple)
		{
			debugRpcQueue.Enqueue(new DebugRpc
			{
				command = DebugCommand.EnableSuperMan,
				entity0 = entity,
				position0 = new float3(multiple, 0f, 0f)
			});
		}

		public void DebugDisableSuperMan(Entity entity)
		{
			debugRpcQueue.Enqueue(new DebugRpc
			{
				command = DebugCommand.DisableSuperman,
				entity0 = entity,
				position0 = new float3(0f, 0f, 0f)
			});
		}

		public void TriggerEnvironmentEvent(EnvironmentEventType eventType, bool bypassRequirements)
		{
			debugRpcQueue.Enqueue(new DebugRpc
			{
				command = DebugCommand.TriggerEnvironmentEvent,
				int0 = (int)eventType,
				bool0 = bypassRequirements
			});
		}

		public void ResetEnvironmentEventCooldowns()
		{
			debugRpcQueue.Enqueue(new DebugRpc
			{
				command = DebugCommand.ResetEnvironmentEventCooldowns
			});
		}

		public void SetEnvironmentEventsEnabled(bool value)
		{
			debugRpcQueue.Enqueue(new DebugRpc
			{
				command = DebugCommand.SetEnvironmentEventsEnabled,
				bool0 = value
			});
		}

		public void MapPing(Entity playerEntity, float3 worldPosition)
		{
			rpcQueue.Enqueue(new Rpc
			{
				command = Command.MapPing,
				entity0 = playerEntity,
				position0 = worldPosition
			});
		}

		public void ResetMerchantHasNewItems(Entity entity)
		{
			rpcQueue.Enqueue(new Rpc
			{
				command = Command.ResetMerchantHasNewItems,
				entity0 = entity
			});
		}

		public void UpdatePlayerCustomization(Entity entity, PlayerCustomization customization)
		{
			Entity entity2 = base.EntityManager.CreateEntity(updatePlayerCustomizationRpcArchetype);
			base.EntityManager.SetComponentData(entity2, new UpdatePlayerCustomizationRpc
			{
				entity = entity,
				playerCustomization = customization
			});
		}

		public void ActivateTerminal(Entity terminalEntity)
		{
			rpcQueue.Enqueue(new Rpc
			{
				command = Command.ActivateTerminal,
				entity0 = terminalEntity
			});
		}

		public void SetPlayerState(Entity entity, PlayerStateEnum playerState, bool locked = false)
		{
			rpcQueue.Enqueue(new Rpc
			{
				command = Command.SetPlayerState,
				entity0 = entity,
				int0 = (int)playerState,
				bool0 = locked
			});
		}

		public void AddSkillValue(Entity entity, SkillID skillID, int amount)
		{
			rpcQueue.Enqueue(new Rpc
			{
				command = Command.AddSkillValue,
				entity0 = entity,
				int0 = (int)skillID,
				int1 = amount
			});
		}

		public void SetSkillValue(Entity entity, SkillID skillID, int amount)
		{
			rpcQueue.Enqueue(new Rpc
			{
				command = Command.SetSkillValue,
				entity0 = entity,
				int0 = (int)skillID,
				int1 = amount
			});
		}

		public void SetSquashBugs(Entity entity, bool value)
		{
			rpcQueue.Enqueue(new Rpc
			{
				command = Command.SetSquashBugs,
				entity0 = entity,
				bool0 = value
			});
		}

		public void UnlockCurrentState(Entity entity)
		{
			rpcQueue.Enqueue(new Rpc
			{
				command = Command.UnlockCurrentState,
				entity0 = entity
			});
		}

		public void CreateItem(Entity entity, int freeSlot, ObjectID itemObject, int amount, Vector3 worldPosition, int variation = 0)
		{
			rpcQueue.Enqueue(new Rpc
			{
				command = Command.CreateItem,
				entity0 = entity,
				int0 = freeSlot,
				int1 = (int)itemObject,
				int2 = amount,
				position0 = worldPosition,
				int3 = variation
			});
		}

		public void SetGodMode(Entity entity, bool enabled)
		{
			rpcQueue.Enqueue(new Rpc
			{
				command = Command.SetGodMode,
				bool0 = enabled,
				entity0 = entity
			});
		}

		public void Unstuck(Entity entity)
		{
			rpcQueue.Enqueue(new Rpc
			{
				command = Command.Unstuck,
				entity0 = entity
			});
		}

		public void DebugSetUnlimitedMana(Entity entity, bool enabled)
		{
			debugRpcQueue.Enqueue(new DebugRpc
			{
				command = DebugCommand.SetUnlimitedPlayerMana,
				entity0 = entity,
				bool0 = enabled
			});
		}

		public void DebugSetAllItemsInInventoryToLevel(PlayerController player, int upgradeToLevel)
		{
			debugRpcQueue.Enqueue(new DebugRpc
			{
				command = DebugCommand.SetAllItemsInInventoryToLevel,
				entity0 = player.entity,
				int0 = upgradeToLevel
			});
		}

		public void DebugRepairAll(PlayerController playerController, bool reinforce)
		{
			debugRpcQueue.Enqueue(new DebugRpc
			{
				command = DebugCommand.RepairAll,
				entity0 = playerController.entity,
				bool0 = reinforce
			});
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ReceiveRpcCommandRequest>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<Rpc>();
			__query_1290591591_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<Rpc, ReceiveRpcCommandRequest>();
			__query_1290591591_1 = entityQueryBuilder2.Build(ref state);
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
		public ClientSystem()
		{
		}
	}
}
