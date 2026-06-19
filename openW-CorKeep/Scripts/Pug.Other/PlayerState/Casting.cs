#define PUG_RGB_ENABLED
using Inventory;
using Pug.UnityExtensions;
using PugScan;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;

namespace PlayerState
{
	public static class Casting
	{
		private const float CAST_BAR_PUSH_BACK_STRENGTH = 3f;

		public static void EnterState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateShared changePlayerStateShared, ChangePlayerStateLookup changePlayerStateLookup)
		{
			ref CastingStateCD valueRW = ref changePlayerStateAspect.castingStateCD.ValueRW;
			valueRW.previousHealth = changePlayerStateAspect.healthCD.ValueRO.health;
			valueRW.previousMaxHealth = changePlayerStateAspect.healthCD.ValueRO.GetMaxHealthWithConditions(changePlayerStateAspect.summarizedConditionEffectsBuffer);
			valueRW.itemIsInProcessOfBeingUsed = false;
			valueRW.objectData = changePlayerStateAspect.equippedObjectCD.ValueRO.containedObject.objectData;
			valueRW.inventoryIndexOnCast = changePlayerStateAspect.equippedObjectCD.ValueRO.equippedSlotIndex;
			valueRW.exitStateDelayTimer.ClearStart();
			EquippedObjectCD valueRO = changePlayerStateAspect.equippedObjectCD.ValueRO;
			Entity equipmentPrefab = valueRO.equipmentPrefab;
			if (equipmentPrefab == Entity.Null)
			{
				changePlayerStateAspect.playerStateCD.ValueRW.SetNextState(PlayerStateEnum.Walk);
				return;
			}
			float seconds = 1f;
			if (changePlayerStateLookup.castItemLookup.TryGetComponent(equipmentPrefab, out var componentData))
			{
				seconds = componentData.castTime;
				valueRW.castCompleteEffect = componentData.castCompleteEffect;
			}
			changePlayerStateAspect.castingStateCD.ValueRW.castTimer.Start(changePlayerStateShared.currentTick, seconds, changePlayerStateShared.tickRate);
			StartCastingItem(equipmentPrefab, valueRO.containedObject.objectID, changePlayerStateAspect.animationBuffer, ref changePlayerStateAspect.animationBufferPointer.ValueRW, changePlayerStateLookup, changePlayerStateShared.currentTick);
		}

		private static void StartCastingItem(Entity equippedObjectPrefab, ObjectID objectID, DynamicBuffer<AnimationBuffer> animationBuffer, ref AnimationBufferPointer animationBufferPointer, ChangePlayerStateLookup changePlayerStateLookup, NetworkTick currentTick)
		{
			if (changePlayerStateLookup.parchmentRecipeLookup.HasComponent(equippedObjectPrefab))
			{
				PlayerController.PlayAnimationTrigger(-1518581387, currentTick, animationBuffer, ref animationBufferPointer);
				return;
			}
			if (changePlayerStateLookup.scannerLookup.HasComponent(equippedObjectPrefab))
			{
				PlayerController.PlayAnimationTrigger(-1518581387, currentTick, animationBuffer, ref animationBufferPointer);
				return;
			}
			switch (objectID)
			{
			case ObjectID.RecallIdol:
				PlayerController.PlayAnimationTrigger(-1518581387, currentTick, animationBuffer, ref animationBufferPointer);
				break;
			case ObjectID.Leash:
			case ObjectID.CattleCage:
				PlayerController.PlayAnimationTrigger(-34540245, currentTick, animationBuffer, ref animationBufferPointer);
				break;
			}
		}

		public static void UpdateState(StateUpdateAspect stateUpdateAspect, SharedStateUpdateData sharedStateUpdateData, LookupStateUpdateData lookupStateUpdateData)
		{
			ref CastingStateCD valueRW = ref stateUpdateAspect.castingStateCD.ValueRW;
			if (valueRW.itemIsInProcessOfBeingUsed)
			{
				if (valueRW.exitStateDelayTimer.isRunning && valueRW.exitStateDelayTimer.IsTimerElapsed(sharedStateUpdateData.currentTick))
				{
					stateUpdateAspect.playerStateCD.ValueRW.SetNextState(PlayerStateEnum.Walk);
				}
				return;
			}
			int health = stateUpdateAspect.healthCD.ValueRO.health;
			int maxHealthWithConditions = stateUpdateAspect.healthCD.ValueRO.GetMaxHealthWithConditions(lookupStateUpdateData.summarizedConditionEffectsLookup[stateUpdateAspect.entity]);
			if (valueRW.previousHealth > health && valueRW.previousMaxHealth == maxHealthWithConditions)
			{
				uint x = (uint)math.round((float)(valueRW.previousHealth - health) / (float)valueRW.previousMaxHealth * 3f / (float)sharedStateUpdateData.tickRate);
				uint elapsedTicks = (uint)valueRW.castTimer.GetElapsedTicks(sharedStateUpdateData.currentTick);
				valueRW.castTimer.startTick.Add(math.min(x, elapsedTicks));
			}
			valueRW.previousHealth = health;
			valueRW.previousMaxHealth = maxHealthWithConditions;
			if (valueRW.castTimer.IsTimerElapsed(sharedStateUpdateData.currentTick))
			{
				FinishCastingItem(stateUpdateAspect, sharedStateUpdateData, lookupStateUpdateData);
			}
			else if (math.length(stateUpdateAspect.playerMovementCD.ValueRO.targetMovementVelocity) > 0.1f || !stateUpdateAspect.equippedObjectCD.ValueRO.containedObject.objectData.Equals(valueRW.objectData) || stateUpdateAspect.equippedObjectCD.ValueRO.equippedSlotIndex != valueRW.inventoryIndexOnCast)
			{
				stateUpdateAspect.playerStateCD.ValueRW.SetNextState(PlayerStateEnum.Walk);
			}
		}

		private static void FinishCastingItem(StateUpdateAspect stateUpdateAspect, SharedStateUpdateData sharedStateUpdateData, LookupStateUpdateData lookupStateUpdateData)
		{
			stateUpdateAspect.castingStateCD.ValueRW.itemIsInProcessOfBeingUsed = true;
			ObjectID objectID = stateUpdateAspect.equippedObjectCD.ValueRO.containedObject.objectData.objectID;
			Entity equipmentPrefab = stateUpdateAspect.equippedObjectCD.ValueRO.equipmentPrefab;
			if (stateUpdateAspect.castingStateCD.ValueRO.castCompleteEffect != EffectID.None)
			{
				DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = stateUpdateAspect.ghostEffectEventBuffer;
				ref GhostEffectEventBufferPointerCD valueRW = ref stateUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW;
				GhostEffectEventBuffer item = new GhostEffectEventBuffer
				{
					Tick = sharedStateUpdateData.currentTick,
					value = new EffectEventCD
					{
						position1 = lookupStateUpdateData.localTransformLookup[stateUpdateAspect.entity].Position,
						effectID = stateUpdateAspect.castingStateCD.ValueRO.castCompleteEffect
					}
				};
				ghostEffectEventBuffer.AddToRingBuffer(ref valueRW, in item);
			}
			if (lookupStateUpdateData.parchmentRecipeLookup.TryGetComponent(equipmentPrefab, out var componentData))
			{
				CraftParchmentRecipe(equipmentPrefab, componentData, stateUpdateAspect, lookupStateUpdateData, sharedStateUpdateData);
				stateUpdateAspect.playerStateCD.ValueRW.SetNextState(PlayerStateEnum.Walk);
				return;
			}
			if (lookupStateUpdateData.scannerLookup.TryGetComponent(equipmentPrefab, out var componentData2))
			{
				if (componentData2.summonInsteadOfScan)
				{
					SummonEntity(componentData2, stateUpdateAspect, sharedStateUpdateData, lookupStateUpdateData);
				}
				else
				{
					Scan(componentData2, stateUpdateAspect, sharedStateUpdateData, lookupStateUpdateData);
				}
				stateUpdateAspect.playerStateCD.ValueRW.SetNextState(PlayerStateEnum.Walk);
				return;
			}
			if (lookupStateUpdateData.spawnsItemsOnUseLookup.TryGetComponent(equipmentPrefab, out var componentData3))
			{
				OpenItemAndSpawnLoot(componentData3, stateUpdateAspect, sharedStateUpdateData, lookupStateUpdateData);
				stateUpdateAspect.playerStateCD.ValueRW.SetNextState(PlayerStateEnum.Walk);
				return;
			}
			switch (objectID)
			{
			case ObjectID.RecallIdol:
			{
				stateUpdateAspect.teleportingStateCD.ValueRW.targetPosition = PlayerControllerBurstableStatics.PLAYER_SPAWN_POSITION;
				stateUpdateAspect.playerStateCD.ValueRW.SetNextState(PlayerStateEnum.Teleporting, nextStateLocked: true);
				float3 position = lookupStateUpdateData.localTransformLookup.GetRefRO(stateUpdateAspect.entity).ValueRO.Position;
				lookupStateUpdateData.inventoryChangeBuffer[sharedStateUpdateData.inventoryChangeBufferEntity].Add(new InventoryChangeBuffer
				{
					inventoryChangeData = Create.ConsumeEntityAt(stateUpdateAspect.entity, stateUpdateAspect.equippedObjectCD.ValueRO.equippedSlotIndex, 1, destroy: true, lookupStateUpdateData.godModeLookup.IsComponentEnabled(stateUpdateAspect.entity), position, stateUpdateAspect.equippedObjectCD.ValueRO.containedObject.variation),
					playerEntity = stateUpdateAspect.entity
				});
				break;
			}
			case ObjectID.Leash:
				if (ThrowLeash(stateUpdateAspect, sharedStateUpdateData, lookupStateUpdateData))
				{
					stateUpdateAspect.castingStateCD.ValueRW.exitStateDelayTimer.Start(sharedStateUpdateData.currentTick, 0.2f, sharedStateUpdateData.tickRate);
				}
				else
				{
					stateUpdateAspect.playerStateCD.ValueRW.SetNextState(PlayerStateEnum.Walk);
				}
				break;
			case ObjectID.CattleCage:
				if (CageCattle(stateUpdateAspect, sharedStateUpdateData, lookupStateUpdateData))
				{
					stateUpdateAspect.castingStateCD.ValueRW.exitStateDelayTimer.Start(sharedStateUpdateData.currentTick, 0.2f, sharedStateUpdateData.tickRate);
				}
				else
				{
					stateUpdateAspect.playerStateCD.ValueRW.SetNextState(PlayerStateEnum.Walk);
				}
				break;
			default:
				Debug.LogError($"You have not implemented what {objectID} should do when it has been casted.");
				break;
			}
		}

		private static void CraftParchmentRecipe(Entity equippedObjectPrefab, ParchmentRecipeCD parchmentRecipeCD, StateUpdateAspect stateUpdateAspect, LookupStateUpdateData lookupStateUpdateData, SharedStateUpdateData sharedStateUpdateData)
		{
			ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(parchmentRecipeCD.objectToCraft.objectID, sharedStateUpdateData.pugDatabaseBank.databaseBankBlob);
			Entity value = stateUpdateAspect.entity;
			using NativeList<Entity> inventoryEntities = new NativeList<Entity>(Allocator.Temp);
			inventoryEntities.Add(in value);
			ref PugDatabase.EntityObjectInfo entityObjectInfo2 = ref PugDatabase.GetEntityObjectInfo(entityObjectInfo.objectID, sharedStateUpdateData.pugDatabaseBank.databaseBankBlob);
			NativeList<ObjectWithAmount> requiredObjectsToCraft = new NativeList<ObjectWithAmount>(entityObjectInfo2.requiredObjectsToCraft.Length, Allocator.Temp);
			for (int i = 0; i < entityObjectInfo2.requiredObjectsToCraft.Length; i++)
			{
				requiredObjectsToCraft.Add(new ObjectWithAmount
				{
					objectID = entityObjectInfo2.requiredObjectsToCraft[i].objectID,
					amount = entityObjectInfo2.requiredObjectsToCraft[i].amount
				});
			}
			if (InventoryUtility.HasMaterialsInCraftingInventoryToCraftRecipe(lookupStateUpdateData.containedObjectsBufferLookup, lookupStateUpdateData.inventoryBufferLookup, sharedStateUpdateData.pugDatabaseBank, lookupStateUpdateData.anvilLookup, lookupStateUpdateData.objectDataLookup, lookupStateUpdateData.summarizedConditionsLookup, value, value, inventoryEntities, requiredObjectsToCraft))
			{
				float3 position = lookupStateUpdateData.localTransformLookup.GetRefRO(stateUpdateAspect.entity).ValueRO.Position;
				if (entityObjectInfo.rarity == Rarity.Legendary)
				{
					DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = stateUpdateAspect.ghostEffectEventBuffer;
					ref GhostEffectEventBufferPointerCD valueRW = ref stateUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW;
					GhostEffectEventBuffer item = new GhostEffectEventBuffer
					{
						Tick = sharedStateUpdateData.currentTick,
						value = EffectEventExtensions.CreateSingleAudioFollowSFX(localOnlyEffect: true, SfxID.spoonget, stateUpdateAspect.entity, 0.4f, 0.9f, 30f)
					};
					ghostEffectEventBuffer.AddToRingBuffer(ref valueRW, in item);
				}
				stateUpdateAspect.ghostEffectEventBuffer.AddToRingBuffer(ref stateUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW, new GhostEffectEventBuffer
				{
					Tick = sharedStateUpdateData.currentTick,
					value = new EffectEventCD
					{
						entity = stateUpdateAspect.entity,
						position1 = position,
						effectID = EffectID.TeleportExplosion
					}
				});
				lookupStateUpdateData.craftBuffer[sharedStateUpdateData.craftBufferEntity].Add(new CraftBuffer
				{
					craftActionData = Create.CraftParchmentRecipe(stateUpdateAspect.entity, stateUpdateAspect.equippedObjectCD.ValueRO.containedObject.objectID, stateUpdateAspect.equippedObjectCD.ValueRO.containedObject.variation, stateUpdateAspect.equippedObjectCD.ValueRO.equippedSlotIndex)
				});
			}
		}

		private static void Scan(ScannerCD scannerCD, StateUpdateAspect stateUpdateAspect, SharedStateUpdateData sharedStateUpdateData, LookupStateUpdateData lookupStateUpdateData)
		{
			DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = stateUpdateAspect.ghostEffectEventBuffer;
			ref GhostEffectEventBufferPointerCD valueRW = ref stateUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW;
			GhostEffectEventBuffer item = new GhostEffectEventBuffer
			{
				Tick = sharedStateUpdateData.currentTick,
				value = new EffectEventCD
				{
					position1 = lookupStateUpdateData.localTransformLookup[stateUpdateAspect.entity].Position,
					effectID = EffectID.ScanEffect
				}
			};
			ghostEffectEventBuffer.AddToRingBuffer(ref valueRW, in item);
			ObjectID objectToScan = scannerCD.objectToScan;
			if (objectToScan != ObjectID.None && sharedStateUpdateData.isServer)
			{
				float3 position = lookupStateUpdateData.localTransformLookup.GetRefRO(stateUpdateAspect.entity).ValueRO.Position;
				Entity e = sharedStateUpdateData.ecb.CreateEntity();
				sharedStateUpdateData.ecb.AddComponent(e, new ScanRequestCD
				{
					objectToScan = new ObjectDataCD
					{
						objectID = objectToScan
					},
					inventory = stateUpdateAspect.entity,
					inventorySlot = stateUpdateAspect.equippedObjectCD.ValueRO.equippedSlotIndex,
					consumeItemFromInventory = true,
					sendResponse = true,
					sourceConnectionEntity = stateUpdateAspect.playerGhost.ValueRO.connection,
					typeOfRequest = PugScanType.Scan,
					position = position
				});
			}
		}

		private static void OpenItemAndSpawnLoot(SpawnsItemsOnUseCD spawnsItemsOnUseCD, StateUpdateAspect stateUpdateAspect, SharedStateUpdateData sharedStateUpdateData, LookupStateUpdateData lookupStateUpdateData)
		{
			ObjectDataCD objectData = stateUpdateAspect.equippedObjectCD.ValueRO.containedObject.objectData;
			if (PlayerController.CanConsumeEntityInSlot(stateUpdateAspect.equippedObjectCD.ValueRO.equipmentPrefab, objectData, 1, lookupStateUpdateData.cattleLookup))
			{
				float3 position = lookupStateUpdateData.localTransformLookup.GetRefRO(stateUpdateAspect.entity).ValueRO.Position;
				DynamicBuffer<InventoryChangeBuffer> dynamicBuffer = lookupStateUpdateData.inventoryChangeBuffer[sharedStateUpdateData.inventoryChangeBufferEntity];
				dynamicBuffer.Add(new InventoryChangeBuffer
				{
					inventoryChangeData = Create.ConsumeEntityAt(stateUpdateAspect.entity, stateUpdateAspect.equippedObjectCD.ValueRO.equippedSlotIndex, 1, destroy: true, lookupStateUpdateData.godModeLookup.IsComponentEnabled(stateUpdateAspect.entity), position, 0),
					playerEntity = stateUpdateAspect.entity
				});
				lookupStateUpdateData.waitingForCastingOpenItemResultLookup.GetRefRW(stateUpdateAspect.entity).ValueRW.resultIndex = dynamicBuffer.Length - 1;
				lookupStateUpdateData.waitingForCastingOpenItemResultLookup.SetComponentEnabled(stateUpdateAspect.entity, value: true);
				EffectID spawnEffects = spawnsItemsOnUseCD.spawnEffects;
				DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = stateUpdateAspect.ghostEffectEventBuffer;
				ref GhostEffectEventBufferPointerCD valueRW = ref stateUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW;
				GhostEffectEventBuffer item = new GhostEffectEventBuffer
				{
					Tick = sharedStateUpdateData.currentTick,
					value = new EffectEventCD
					{
						entity = stateUpdateAspect.entity,
						position1 = position,
						effectID = spawnEffects
					}
				};
				ghostEffectEventBuffer.AddToRingBuffer(ref valueRW, in item);
			}
		}

		private static void SummonEntity(ScannerCD scannerCD, StateUpdateAspect stateUpdateAspect, SharedStateUpdateData sharedStateUpdateData, LookupStateUpdateData lookupStateUpdateData)
		{
			ObjectID objectToScan = scannerCD.objectToScan;
			if (objectToScan != ObjectID.None && sharedStateUpdateData.isServer)
			{
				if (scannerCD.onlyInBiome != Biome.None && stateUpdateAspect.currentBiomeCD.ValueRO.biome != scannerCD.onlyInBiome)
				{
					DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = stateUpdateAspect.ghostEffectEventBuffer;
					ref GhostEffectEventBufferPointerCD valueRW = ref stateUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW;
					GhostEffectEventBuffer item = new GhostEffectEventBuffer
					{
						Tick = sharedStateUpdateData.currentTick,
						value = new EffectEventCD
						{
							entity = stateUpdateAspect.entity,
							localOnlyEffect = 1,
							effectID = EffectID.Emote,
							value1 = 2
						}
					};
					ghostEffectEventBuffer.AddToRingBuffer(ref valueRW, in item);
					Debug.Log("WRONG BIOME, dont do effect");
				}
				else
				{
					Entity e = sharedStateUpdateData.ecb.CreateEntity();
					sharedStateUpdateData.ecb.AddComponent(e, new ScanRequestCD
					{
						objectToScan = new ObjectDataCD
						{
							objectID = objectToScan
						},
						inventory = stateUpdateAspect.entity,
						inventorySlot = stateUpdateAspect.equippedObjectCD.ValueRO.equippedSlotIndex,
						consumeItemFromInventory = true,
						sendResponse = true,
						sourceConnectionEntity = stateUpdateAspect.playerGhost.ValueRO.connection,
						typeOfRequest = PugScanType.Summon,
						position = lookupStateUpdateData.localTransformLookup.GetRefRO(stateUpdateAspect.entity).ValueRO.Position
					});
				}
			}
		}

		private static bool ThrowLeash(StateUpdateAspect stateUpdateAspect, SharedStateUpdateData sharedStateUpdateData, LookupStateUpdateData lookupStateUpdateData)
		{
			Entity leashedEntity = stateUpdateAspect.leashingCD.ValueRO.leashedEntity;
			if (leashedEntity != Entity.Null)
			{
				if (lookupStateUpdateData.simulateLookup.HasComponent(leashedEntity) && lookupStateUpdateData.simulateLookup.IsComponentEnabled(leashedEntity))
				{
					EntityUtility.ReleaseLeashOnEntity(stateUpdateAspect.entity, leashedEntity, lookupStateUpdateData.leashedLookup);
				}
				return false;
			}
			NativeList<ColliderCastHit> outHits = new NativeList<ColliderCastHit>(Allocator.Temp);
			float num = 1f;
			float3 position = lookupStateUpdateData.localTransformLookup.GetRefRO(stateUpdateAspect.entity).ValueRO.Position;
			float3 float5 = stateUpdateAspect.clientInput.ValueRO.targetingDirection.ToFloat3();
			float3 origin = position + 0.5f * new float3(0f, 1f, 0f) + float5 * num;
			float closestDistanceSq = float.MaxValue;
			Entity entity = Entity.Null;
			float3 pointToCheckDistanceFrom = position + float5 * (num / 2f);
			Entity currentClosestInteractable = stateUpdateAspect.interactorCD.ValueRO.currentClosestInteractable;
			if (currentClosestInteractable != Entity.Null && IsValidEntityToLeash(currentClosestInteractable, pointToCheckDistanceFrom, closestDistanceSq, out var distanceSq, lookupStateUpdateData))
			{
				closestDistanceSq = distanceSq;
				entity = currentClosestInteractable;
			}
			NetworkTick currentTick = sharedStateUpdateData.currentTick;
			currentTick.Decrement();
			sharedStateUpdateData.physicsWorldHistory.GetCollisionWorldFromTick(currentTick, stateUpdateAspect.commandDataInterpolationDelay.ValueRO.Delay, ref sharedStateUpdateData.physicsWorld, out var collWorld);
			if (entity == Entity.Null && collWorld.SphereCastAll(origin, num, float3.zero, 0f, ref outHits, new CollisionFilter
			{
				BelongsTo = uint.MaxValue,
				CollidesWith = 556618u
			}))
			{
				for (int i = 0; i < outHits.Length; i++)
				{
					Entity entity2 = outHits[i].Entity;
					if (IsValidEntityToLeash(entity2, pointToCheckDistanceFrom, closestDistanceSq, out distanceSq, lookupStateUpdateData))
					{
						closestDistanceSq = distanceSq;
						entity = entity2;
					}
				}
			}
			if (entity != Entity.Null && lookupStateUpdateData.simulateLookup.HasComponent(entity) && lookupStateUpdateData.simulateLookup.IsComponentEnabled(entity))
			{
				EntityUtility.PutLeashOnEntity(stateUpdateAspect.entity, entity, stateUpdateAspect.equippedObjectCD.ValueRO.equippedSlotIndex, lookupStateUpdateData.leashedLookup);
			}
			outHits.Dispose();
			return true;
		}

		private static bool IsValidEntityToLeash(Entity entity, float3 pointToCheckDistanceFrom, float closestDistanceSq, out float distanceSq, LookupStateUpdateData lookupStateUpdateData)
		{
			distanceSq = float.MaxValue;
			if (!lookupStateUpdateData.leashedLookup.TryGetComponent(entity, out var componentData) || componentData.leashedToEntity != Entity.Null || !lookupStateUpdateData.localTransformLookup.TryGetComponent(entity, out var componentData2))
			{
				return false;
			}
			distanceSq = math.distancesq(pointToCheckDistanceFrom, componentData2.Position);
			return distanceSq < closestDistanceSq;
		}

		private static bool CageCattle(StateUpdateAspect stateUpdateAspect, SharedStateUpdateData sharedStateUpdateData, LookupStateUpdateData lookupStateUpdateData)
		{
			if (stateUpdateAspect.equippedObjectCD.ValueRO.containedObject.objectData.objectID != ObjectID.CattleCage)
			{
				return false;
			}
			NativeList<ColliderCastHit> outHits = new NativeList<ColliderCastHit>(Allocator.Temp);
			float num = 1f;
			float3 position = lookupStateUpdateData.localTransformLookup.GetRefRO(stateUpdateAspect.entity).ValueRO.Position;
			float3 float5 = stateUpdateAspect.clientInput.ValueRO.targetingDirection.ToFloat3();
			float3 origin = position + 0.5f * new float3(0f, 1f, 0f) + float5 * num;
			float closestDistanceSq = float.MaxValue;
			Entity entity = Entity.Null;
			float3 pointToCheckDistanceFrom = position + float5 * (num / 2f);
			Entity currentClosestInteractable = stateUpdateAspect.interactorCD.ValueRO.currentClosestInteractable;
			if (currentClosestInteractable != Entity.Null && IsValidEntityToCage(currentClosestInteractable, pointToCheckDistanceFrom, closestDistanceSq, out var distanceSq, lookupStateUpdateData.cattleLookup, lookupStateUpdateData.localTransformLookup))
			{
				closestDistanceSq = distanceSq;
				entity = currentClosestInteractable;
			}
			if (entity == Entity.Null && sharedStateUpdateData.physicsWorld.CollisionWorld.SphereCastAll(origin, num, float3.zero, 0f, ref outHits, new CollisionFilter
			{
				BelongsTo = uint.MaxValue,
				CollidesWith = 556618u
			}))
			{
				for (int i = 0; i < outHits.Length; i++)
				{
					Entity entity2 = outHits[i].Entity;
					if (IsValidEntityToCage(entity2, pointToCheckDistanceFrom, closestDistanceSq, out distanceSq, lookupStateUpdateData.cattleLookup, lookupStateUpdateData.localTransformLookup))
					{
						closestDistanceSq = distanceSq;
						entity = entity2;
					}
				}
			}
			if (entity != Entity.Null && lookupStateUpdateData.localTransformLookup.TryGetComponent(entity, out var componentData) && lookupStateUpdateData.objectDataLookup.TryGetComponent(entity, out var componentData2) && lookupStateUpdateData.cattleLookup.TryGetComponent(entity, out var _))
			{
				float3 position2 = componentData.Position;
				if (sharedStateUpdateData.isServer)
				{
					ContainedObjectsBuffer containedObject = new ContainedObjectsBuffer
					{
						objectData = componentData2
					};
					EntityUtility.DropPetInCage(sharedStateUpdateData.ecb, containedObject, position2, sharedStateUpdateData.pugDatabaseBank, entity, lookupStateUpdateData.nameLookup, lookupStateUpdateData.mealsEatenLookup, lookupStateUpdateData.breedToggleLookup, in sharedStateUpdateData.InventoryAuxDataSystemData);
					sharedStateUpdateData.ecb.DestroyEntity(entity);
				}
				lookupStateUpdateData.inventoryChangeBuffer[sharedStateUpdateData.inventoryChangeBufferEntity].Add(new InventoryChangeBuffer
				{
					inventoryChangeData = Create.ConsumeEntityAt(stateUpdateAspect.entity, stateUpdateAspect.equippedObjectCD.ValueRO.equippedSlotIndex, 1, destroy: true, lookupStateUpdateData.godModeLookup.IsComponentEnabled(stateUpdateAspect.entity), position),
					playerEntity = stateUpdateAspect.entity
				});
				stateUpdateAspect.ghostEffectEventBuffer.AddToRingBuffer(ref stateUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW, new GhostEffectEventBuffer
				{
					Tick = sharedStateUpdateData.currentTick,
					value = new EffectEventCD
					{
						entity = stateUpdateAspect.entity,
						position1 = position2,
						effectID = EffectID.useCattleCage
					}
				});
			}
			outHits.Dispose();
			return true;
		}

		private static bool IsValidEntityToCage(Entity entity, float3 pointToCheckDistanceFrom, float closestDistanceSq, out float distanceSq, ComponentLookup<CattleCD> cattleLookup, ComponentLookup<LocalTransform> localTransformLookup)
		{
			distanceSq = float.MaxValue;
			if (!cattleLookup.HasComponent(entity) || !localTransformLookup.TryGetComponent(entity, out var componentData))
			{
				return false;
			}
			distanceSq = math.distancesq(pointToCheckDistanceFrom, componentData.Position);
			return distanceSq < closestDistanceSq;
		}

		public static void ExitState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateLookup changePlayerStateLookup, ChangePlayerStateShared changePlayerStateShared)
		{
			StopCastingItem(changePlayerStateAspect, changePlayerStateLookup, changePlayerStateShared);
		}

		private static void StopCastingItem(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateLookup changePlayerStateLookup, ChangePlayerStateShared changePlayerStateShared)
		{
			Entity equipmentPrefab = changePlayerStateAspect.equippedObjectCD.ValueRO.equipmentPrefab;
			if (changePlayerStateLookup.parchmentRecipeLookup.HasComponent(equipmentPrefab))
			{
				PlayerController.PlayAnimationTrigger(-1065991089, changePlayerStateShared.currentTick, changePlayerStateAspect.animationBuffer, ref changePlayerStateAspect.animationBufferPointer.ValueRW);
			}
			else if (changePlayerStateLookup.scannerLookup.HasComponent(equipmentPrefab))
			{
				PlayerController.PlayAnimationTrigger(-1065991089, changePlayerStateShared.currentTick, changePlayerStateAspect.animationBuffer, ref changePlayerStateAspect.animationBufferPointer.ValueRW);
			}
			else if (changePlayerStateAspect.equippedObjectCD.ValueRO.containedObject.objectID == ObjectID.RecallIdol && changePlayerStateAspect.playerStateCD.ValueRO.nextState != PlayerStateEnum.Teleporting)
			{
				PlayerController.PlayAnimationTrigger(-1065991089, changePlayerStateShared.currentTick, changePlayerStateAspect.animationBuffer, ref changePlayerStateAspect.animationBufferPointer.ValueRW);
			}
		}

		public static void EnterStatePresentation(PlayerController playerController)
		{
			if (playerController.isLocal)
			{
				Manager.rgb.StartState(RGBManager.State.Casting);
			}
		}

		public static void ExitStatePresentation(PlayerController playerController, ChangePlayerStatePresentationAspect changePlayerStatePresentationAspect)
		{
			if (playerController.isLocal)
			{
				Manager.effects.SetScanEffectValues(0f, 0f, 5f, playerController.transform.position);
				Manager.rgb.EndState(RGBManager.State.Casting);
			}
		}
	}
}
