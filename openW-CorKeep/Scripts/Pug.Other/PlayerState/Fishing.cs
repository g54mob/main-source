using Inventory;
using PlayerCommand;
using Pug.UnityExtensions;
using PugTilemap;
using QFSW.QC;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine.Scripting;

namespace PlayerState
{
	public static class Fishing
	{
		public class GuaranteeLegendaryFishKey
		{
		}

		public struct PullUpData
		{
			public Entity entity;

			public RefRW<FishingStateCD> fishingStateCD;

			public RefRW<GhostEffectEventBufferPointerCD> ghostEffectEventBufferPointerCD;

			public RefRW<PlayerAimPositionCD> playerAimPositionCD;

			public DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer;

			public DynamicBuffer<AnimationBuffer> animationBuffer;

			public RefRW<AnimationBufferPointer> animationBufferPointerCD;

			public NetworkTick currentTick;

			public RefRW<FishingMiniGameStateCD> fishingMiniGameStateCD;

			public RefRO<ClientInput> clientInput;
		}

		private const float FISH_BITING_MIN_TIME = 3f;

		private const float FISH_BITING_MAX_TIME = 4f;

		private const float IDLE_MIN_TIME = 7f;

		private const float IDLE_MAX_TIME = 16f;

		private const float SHOAL_IDLE_MIN_TIME = 3f;

		private const float SHOAL_IDLE_MAX_TIME = 5f;

		private const float MIN_THROW_DISTANCE = 0.7f;

		private const float MAX_THROW_DISTANCE = 3f;

		private const float TARGET_SINK_HEIGHT = -0.2f;

		public static readonly SharedStatic<bool> guaranteeLegendaryFish = SharedStatic<bool>.GetOrCreateUnsafe(0u, 7432750675664871164L, 0L);

		[Preserve]
		[Command("guaranteeLegendaryFish", "Guarantees the catching of legendary fish if the water/lava has one.", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
		public static void GuaranteeLegendaryFish(bool value)
		{
			guaranteeLegendaryFish.Data = value;
		}

		public static void EnterState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateShared changePlayerStateShared, ChangePlayerStateLookup changePlayerStateLookup)
		{
			changePlayerStateAspect.playerRoutineCD.ValueRW.activeRoutine = PlayerRoutines.Inactive;
			StartFishing(changePlayerStateAspect.entity, ref changePlayerStateAspect.fishingStateCD.ValueRW, ref changePlayerStateAspect.fishingMiniGameStateCD.ValueRW, ref changePlayerStateAspect.playerOrientationCD.ValueRW, in changePlayerStateAspect.equipmentCD.ValueRO, changePlayerStateAspect.animationBuffer, ref changePlayerStateAspect.animationBufferPointer.ValueRW, in changePlayerStateAspect.clientInput.ValueRO, changePlayerStateAspect.containedObjectsBuffer, changePlayerStateLookup.offHandLookup, changePlayerStateShared.currentTick, changePlayerStateShared.databaseBankCD);
		}

		private static void StartFishing(Entity entity, ref FishingStateCD fishingStateCD, ref FishingMiniGameStateCD fishingMiniGameStateCD, ref PlayerOrientationCD playerOrientationCD, in EquipmentCD equipmentCD, DynamicBuffer<AnimationBuffer> animationBuffer, ref AnimationBufferPointer animationBufferPointer, in ClientInput clientInput, DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer, ComponentLookup<OffHandCD> offHandLookup, NetworkTick currentTick, PugDatabase.DatabaseBankCD databaseBankCD)
		{
			playerOrientationCD.reorientationBlocked = true;
			PlayerController.PlayAnimationTrigger(1673686245, currentTick, animationBuffer, ref animationBufferPointer);
			fishingStateCD.castTimer.Start(currentTick);
			fishingStateCD.allowedToLeaveStateTimer.Start(currentTick);
			fishingStateCD.throwTimer.Stop(currentTick);
			fishingStateCD.pullUpTimer.Stop(currentTick);
			fishingStateCD.fishBiteTimer.Stop(currentTick);
			fishingStateCD.queueThrowAgain = false;
			fishingStateCD.isSuccessfullyFishing = false;
			fishingStateCD.fishShoalEntity = Entity.Null;
			fishingStateCD.octopusBossEntity = Entity.Null;
			fishingStateCD.octopusBossSpawnLocationEntity = Entity.Null;
			fishingStateCD.fishOnTheHook = false;
			fishingStateCD.fishIsNibbling = false;
			fishingStateCD.fishingLootToSpawn = ObjectID.None;
			fishingStateCD.useFishingMiniGame = clientInput.useFishingMiniGame;
			TryGetBaitObjectID(entity, in equipmentCD, containedObjectsBuffer, offHandLookup, databaseBankCD, out var baitObjectID);
			fishingStateCD.startingBaitObjectID = baitObjectID;
			if (fishingStateCD.useFishingMiniGame)
			{
				FishingMiniGame.StartFishing(ref fishingMiniGameStateCD);
			}
		}

		public static void BeginPullUp(in PullUpData pullUpData)
		{
			FishingStateCD valueRO = pullUpData.fishingStateCD.ValueRO;
			if (valueRO.fishingLootToSpawn != ObjectID.None || valueRO.spawnOctopusBoss)
			{
				if (valueRO.fishOnTheHook && valueRO.useFishingMiniGame)
				{
					FishingMiniGame.BeginPullUp(pullUpData.entity, ref pullUpData.fishingMiniGameStateCD.ValueRW, pullUpData.currentTick, pullUpData.ghostEffectEventBuffer, ref pullUpData.ghostEffectEventBufferPointerCD.ValueRW);
				}
				else
				{
					PullUp(in pullUpData, failedThrow: false);
				}
			}
		}

		public static void PullUp(in PullUpData pullUpData, bool failedThrow)
		{
			ref FishingStateCD valueRW = ref pullUpData.fishingStateCD.ValueRW;
			DynamicBuffer<AnimationBuffer> animationBuffer = pullUpData.animationBuffer;
			ref AnimationBufferPointer valueRW2 = ref pullUpData.animationBufferPointerCD.ValueRW;
			GhostEffectEventBufferPointerCD pointer = pullUpData.ghostEffectEventBufferPointerCD.ValueRW;
			DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = pullUpData.ghostEffectEventBuffer;
			NetworkTick currentTick = pullUpData.currentTick;
			valueRW.pullUpTimer.Start(currentTick);
			if (failedThrow)
			{
				pullUpData.fishingMiniGameStateCD.ValueRW.isInFishingMiniGame = false;
				PlayerController.PlayAnimationTrigger(-1704462721, currentTick, animationBuffer, ref valueRW2);
			}
			else
			{
				PlayerController.PlayAnimationTrigger(1763897515, currentTick, animationBuffer, ref valueRW2);
				if ((valueRW.isSuccessfullyFishing && valueRW.fishingLootToSpawn != ObjectID.None) || valueRW.spawnOctopusBoss)
				{
					GhostEffectEventBuffer item = new GhostEffectEventBuffer
					{
						Tick = currentTick,
						value = new EffectEventCD
						{
							effectID = EffectID.WaterSplash,
							position1 = valueRW.targetSinkWorldPosition
						}
					};
					ghostEffectEventBuffer.AddToRingBuffer(ref pointer, in item);
				}
			}
			pullUpData.playerAimPositionCD.ValueRW = new PlayerAimPositionCD
			{
				position = valueRW.targetSinkWorldPosition
			};
		}

		public static void UpdateState(StateUpdateAspect stateUpdateAspect, SharedStateUpdateData sharedStateUpdateData, LookupStateUpdateData lookupStateUpdateData)
		{
			ref FishingStateCD valueRW = ref stateUpdateAspect.fishingStateCD.ValueRW;
			ref FishingMiniGameStateCD valueRW2 = ref stateUpdateAspect.fishingMiniGameStateCD.ValueRW;
			NetworkTick currentTick = sharedStateUpdateData.currentTick;
			uint tickRate = sharedStateUpdateData.tickRate;
			bool useFishingMiniGame = valueRW.useFishingMiniGame;
			if (FishingMiniGame.WaitForBeginMiniGame(ref stateUpdateAspect.fishingMiniGameStateCD.ValueRW, in sharedStateUpdateData))
			{
				return;
			}
			DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer = lookupStateUpdateData.containedObjectsBufferLookup[stateUpdateAspect.entity];
			TryGetBaitObjectID(stateUpdateAspect.entity, in stateUpdateAspect.equipmentCD.ValueRO, containedObjectsBuffer, lookupStateUpdateData.offHandLookup, sharedStateUpdateData.pugDatabaseBank, out var baitObjectID);
			if (valueRW.startingBaitObjectID != baitObjectID)
			{
				OnExitFishing(ref stateUpdateAspect.playerStateCD.ValueRW, ref stateUpdateAspect.playerOrientationCD.ValueRW, ref valueRW, sharedStateUpdateData.currentTick, wasExitingState: false);
			}
			if (valueRW.pullUpTimer.isRunning)
			{
				if (!valueRW.pullUpTimer.IsTimerElapsed(currentTick))
				{
					return;
				}
				valueRW.pullUpTimer.Stop(currentTick);
				if (valueRW.fishingLootToSpawn != ObjectID.None || valueRW.spawnOctopusBoss)
				{
					if (baitObjectID != ObjectID.None && ShouldConsumeBait(baitObjectID, in valueRW, stateUpdateAspect, lookupStateUpdateData))
					{
						ConsumeBait(baitObjectID, in stateUpdateAspect, sharedStateUpdateData, lookupStateUpdateData);
					}
					else if (!valueRW.isFishingAtOctopusBoss)
					{
						CreateFishingLoot(stateUpdateAspect.entity, ref valueRW, valueRW.fishShoalEntity, valueRW.fishOnTheHook, valueRW.fishingLootToSpawn, sharedStateUpdateData.isServer, sharedStateUpdateData.isFirstTimeFullyPredictingTick, in stateUpdateAspect.playerGhost.ValueRO, lookupStateUpdateData.objectDataLookup, lookupStateUpdateData.randomLookup, lookupStateUpdateData.localTransformLookup, lookupStateUpdateData.summarizedConditionsLookup, sharedStateUpdateData.ecb, lookupStateUpdateData.delayedFishingLootLookup);
					}
				}
				if (valueRW.queueThrowAgain)
				{
					StartFishing(stateUpdateAspect.entity, ref stateUpdateAspect.fishingStateCD.ValueRW, ref stateUpdateAspect.fishingMiniGameStateCD.ValueRW, ref stateUpdateAspect.playerOrientationCD.ValueRW, in stateUpdateAspect.equipmentCD.ValueRO, stateUpdateAspect.animationBuffer, ref stateUpdateAspect.animationBufferPointer.ValueRW, in stateUpdateAspect.clientInput.ValueRO, containedObjectsBuffer, lookupStateUpdateData.offHandLookup, sharedStateUpdateData.currentTick, sharedStateUpdateData.pugDatabaseBank);
				}
				else
				{
					OnExitFishing(ref stateUpdateAspect.playerStateCD.ValueRW, ref stateUpdateAspect.playerOrientationCD.ValueRW, ref valueRW, sharedStateUpdateData.currentTick, wasExitingState: false);
				}
				return;
			}
			ObjectID objectID = stateUpdateAspect.equippedObjectCD.ValueRO.containedObject.objectID;
			bool flag = objectID == ObjectID.GalaxiteFishingRod || objectID == ObjectID.SolariteFishingRod;
			PullUpData pullUpData = new PullUpData
			{
				entity = stateUpdateAspect.entity,
				fishingStateCD = stateUpdateAspect.fishingStateCD,
				animationBuffer = stateUpdateAspect.animationBuffer,
				animationBufferPointerCD = stateUpdateAspect.animationBufferPointer,
				ghostEffectEventBufferPointerCD = stateUpdateAspect.ghostEffectEventBufferPointerCD,
				playerAimPositionCD = stateUpdateAspect.playerAimPositionCD,
				ghostEffectEventBuffer = stateUpdateAspect.ghostEffectEventBuffer,
				currentTick = sharedStateUpdateData.currentTick,
				fishingMiniGameStateCD = stateUpdateAspect.fishingMiniGameStateCD,
				clientInput = stateUpdateAspect.clientInput
			};
			if (valueRW.castTimer.isRunning && (valueRW.castTimer.IsTimerElapsed(currentTick) || (!stateUpdateAspect.clientInput.ValueRO.IsButtonStateSet(CommandInputButtonStateNames.SecondInteract_HeldDown) && valueRW.castTimer.GetElapsedSeconds(currentTick, tickRate) > 0.1f)))
			{
				ThrowFishingRod(stateUpdateAspect, sharedStateUpdateData, lookupStateUpdateData, flag);
			}
			LocalTransform localTransform = lookupStateUpdateData.localTransformLookup[stateUpdateAspect.entity];
			if (valueRW.throwTimer.isRunning)
			{
				if (WallIsBetweenPlayerAndSink(in localTransform, in valueRW, in sharedStateUpdateData.tileAccessor))
				{
					PullUp(in pullUpData, failedThrow: true);
					return;
				}
				if (valueRW.throwTimer.IsTimerElapsed(currentTick))
				{
					valueRW.throwTimer.Stop(currentTick);
					float3 targetSinkWorldPosition = valueRW.targetSinkWorldPosition;
					int2 worldPosition = targetSinkWorldPosition.RoundToInt2();
					TileCD top = sharedStateUpdateData.tileAccessor.GetTop(worldPosition);
					if (top.tileType != TileType.water || !(top.tileset != 3 || flag))
					{
						PullUp(in pullUpData, failedThrow: true);
						return;
					}
					stateUpdateAspect.ghostEffectEventBuffer.AddToRingBuffer(ref stateUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW, new GhostEffectEventBuffer
					{
						Tick = currentTick,
						value = new EffectEventCD
						{
							effectID = EffectID.SmallWaterSplash,
							position1 = targetSinkWorldPosition
						}
					});
					PlayerController.PlayAnimationTrigger(1975517117, currentTick, stateUpdateAspect.animationBuffer, ref stateUpdateAspect.animationBufferPointer.ValueRW);
					valueRW.allowedToLeaveStateTimer.Start(currentTick);
					valueRW.isSuccessfullyFishing = true;
				}
			}
			bool flag2 = PugDatabase.GetEntityObjectInfo(stateUpdateAspect.equippedObjectCD.ValueRO.containedObject.objectID, sharedStateUpdateData.pugDatabaseBank.databaseBankBlob).objectType != ObjectType.FishingRod;
			if (valueRW.allowedToLeaveStateTimer.isRunning && valueRW.allowedToLeaveStateTimer.IsTimerElapsed(currentTick))
			{
				bool flag3 = stateUpdateAspect.playerStateCD.ValueRO.HasAnyState(PlayerStateEnum.MinecartRiding) && math.lengthsq(stateUpdateAspect.minecartRidingStateCD.ValueRO.activeVelocity) > 0.3f;
				if (math.length(stateUpdateAspect.playerMovementCD.ValueRO.targetMovementVelocity) > 0.1f || flag3 || flag2)
				{
					OnExitFishing(ref stateUpdateAspect.playerStateCD.ValueRW, ref stateUpdateAspect.playerOrientationCD.ValueRW, ref valueRW, sharedStateUpdateData.currentTick, wasExitingState: false);
					return;
				}
				if (!valueRW.IsCasting(currentTick) && math.distance(valueRW.targetSinkWorldPosition, localTransform.Position) > 6f)
				{
					OnExitFishing(ref stateUpdateAspect.playerStateCD.ValueRW, ref stateUpdateAspect.playerOrientationCD.ValueRW, ref valueRW, sharedStateUpdateData.currentTick, wasExitingState: false);
					return;
				}
				if (valueRW.isSuccessfullyFishing)
				{
					bool flag4 = useFishingMiniGame && valueRW2.isInFishingMiniGame;
					if (!valueRW.fishIsNibbling && !flag4 && stateUpdateAspect.clientInput.ValueRO.IsButtonStateSet(CommandInputButtonStateNames.SecondInteract_HeldDown))
					{
						PullUp(in pullUpData, failedThrow: false);
						return;
					}
					TileCD top2 = sharedStateUpdateData.tileAccessor.GetTop(valueRW.targetSinkWorldPosition.RoundToInt2());
					if (top2.tileType != TileType.water || (top2.tileset == 3 && !flag) || WallIsBetweenPlayerAndSink(in localTransform, in valueRW, in sharedStateUpdateData.tileAccessor))
					{
						valueRW.fishingLootToSpawn = ObjectID.None;
						PullUp(in pullUpData, failedThrow: true);
						return;
					}
				}
			}
			if (useFishingMiniGame && valueRW2.isInFishingMiniGame)
			{
				if (valueRW.isSuccessfullyFishing)
				{
					valueRW.fishIsNibbling = false;
				}
			}
			else
			{
				UpdateFishOnTheHook(stateUpdateAspect, sharedStateUpdateData, lookupStateUpdateData);
			}
			if (useFishingMiniGame)
			{
				if (valueRW2.isInFishingMiniGame)
				{
					FishingMiniGame.UpdateMiniGame(in stateUpdateAspect, in sharedStateUpdateData, in lookupStateUpdateData, pullUpData);
				}
				else
				{
					valueRW2.fishPosition = (float)(-EntityUtility.GetConditionValue(ConditionID.FishStartsCloserToBeReeledIn, stateUpdateAspect.entity, lookupStateUpdateData.summarizedConditionsLookup)) * 2f / 100f;
				}
			}
		}

		private static bool TryGetBaitObjectID(Entity entity, in EquipmentCD equipmentCD, DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer, ComponentLookup<OffHandCD> offHandLookup, PugDatabase.DatabaseBankCD databaseBankCD, out ObjectID baitObjectID)
		{
			ContainedObjectsBuffer containedObjectsBuffer2 = containedObjectsBuffer[equipmentCD.offHandIndex];
			Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(containedObjectsBuffer2.objectID, databaseBankCD.databaseBankBlob, containedObjectsBuffer2.variation);
			if (!offHandLookup.TryGetComponent(primaryPrefabEntity, out var componentData) || componentData.mechanic != OffHandMechanic.Bait)
			{
				baitObjectID = ObjectID.None;
				return false;
			}
			baitObjectID = containedObjectsBuffer2.objectID;
			return true;
		}

		private static bool ShouldConsumeBait(ObjectID baitObjectID, in FishingStateCD fishingStateCD, StateUpdateAspect stateUpdateAspect, LookupStateUpdateData lookupStateUpdateData)
		{
			bool result = true;
			float num = (float)EntityUtility.GetConditionValue(ConditionID.ChanceToPreserveBait, stateUpdateAspect.entity, lookupStateUpdateData.summarizedConditionsLookup) / 100f;
			ref RandomCD valueRW = ref lookupStateUpdateData.randomLookup.GetRefRW(stateUpdateAspect.entity).ValueRW;
			if (baitObjectID == ObjectID.BaitOctopusBoss)
			{
				result = fishingStateCD.spawnOctopusBoss;
			}
			else if (valueRW.Value.NextFloat() < num)
			{
				result = false;
			}
			return result;
		}

		private static void ConsumeBait(ObjectID baitObjectID, in StateUpdateAspect stateUpdateAspect, SharedStateUpdateData sharedStateUpdateData, LookupStateUpdateData lookupStateUpdateData)
		{
			ref FishingStateCD valueRW = ref stateUpdateAspect.fishingStateCD.ValueRW;
			int offHandIndex = stateUpdateAspect.equipmentCD.ValueRO.offHandIndex;
			DynamicBuffer<InventoryChangeBuffer> dynamicBuffer = lookupStateUpdateData.inventoryChangeBuffer[sharedStateUpdateData.inventoryChangeBufferEntity];
			InventoryChangeBuffer elem = default(InventoryChangeBuffer);
			elem.inventoryChangeData = Create.ConsumeEntityAt(stateUpdateAspect.entity, offHandIndex, 1, destroy: true, dontConsume: false, default(float3), -1, default(float3), baitObjectID);
			elem.playerEntity = stateUpdateAspect.entity;
			dynamicBuffer.Add(elem);
			lookupStateUpdateData.waitingForConsumedBaitResultLookup.GetRefRW(stateUpdateAspect.entity).ValueRW = new WaitingForConsumedBaitResultCD
			{
				resultIndex = dynamicBuffer.Length - 1,
				isFishingAtOctopusBoss = valueRW.isFishingAtOctopusBoss,
				octopusBossEntity = valueRW.octopusBossEntity,
				octopusBossSpawnLocationEntity = valueRW.octopusBossSpawnLocationEntity,
				spawnOctopusBoss = valueRW.spawnOctopusBoss,
				fishShoalEntity = valueRW.fishShoalEntity,
				fishOnTheHook = valueRW.fishOnTheHook,
				fishingLootToSpawn = valueRW.fishingLootToSpawn
			};
			lookupStateUpdateData.waitingForConsumedBaitResultLookup.SetComponentEnabled(stateUpdateAspect.entity, value: true);
		}

		public static void CreateFishingLoot(Entity entity, ref FishingStateCD fishingStateCD, Entity fishShoalEntity, bool fishOnTheHook, ObjectID fishingLootToSpawn, bool isServer, bool isFirstTimeFullyPredictingTick, in PlayerGhost playerGhost, ComponentLookup<ObjectDataCD> objectDataLookup, ComponentLookup<RandomCD> randomLookup, ComponentLookup<LocalTransform> localTransformLookup, BufferLookup<SummarizedConditionsBuffer> summarizedConditionsLookup, EntityCommandBuffer ecb, ComponentLookup<DelayedFishLootCD> delayedFishLootLookup)
		{
			CatchFishFromShoal(fishShoalEntity, ecb, objectDataLookup, randomLookup, isServer);
			int num = 1;
			if (fishOnTheHook)
			{
				float num2 = (float)EntityUtility.GetConditionValue(ConditionID.ChanceToGetDoubleFish, entity, summarizedConditionsLookup) / 100f;
				if (randomLookup.GetRefRW(entity).ValueRW.Value.NextFloat() < num2)
				{
					num = 2;
				}
			}
			float3 position = localTransformLookup.GetRefRO(entity).ValueRO.Position;
			delayedFishLootLookup.SetComponentEnabled(entity, value: true);
			delayedFishLootLookup.GetRefRW(entity).ValueRW = new DelayedFishLootCD
			{
				dropPosition = position,
				amount = num,
				fishingLootToSpawn = fishingLootToSpawn
			};
			if (isServer && fishingStateCD.fishingLootToSpawn == ObjectID.StarlightNautilus)
			{
				Entity e = ecb.CreateEntity();
				ecb.AddComponent(e, new SendRpcCommandRequest
				{
					TargetConnection = playerGhost.connection
				});
				ecb.AddComponent(e, new Rpc
				{
					command = Command.AchievementUnlocked,
					int0 = 26
				});
			}
			if (isFirstTimeFullyPredictingTick)
			{
				fishingStateCD.displayCaughtFishingLoot = num;
				fishingStateCD.displayFishingLootToSpawn = fishingLootToSpawn;
				fishingStateCD.caughtFishCounter++;
			}
			PlayerController.AddSkill(entity, SkillID.Fishing, 1, ecb, isServer);
		}

		public static void CatchFishFromShoal(Entity fishShoalEntity, EntityCommandBuffer ecb, ComponentLookup<ObjectDataCD> objectDataLookup, ComponentLookup<RandomCD> randomLookup, bool isServer)
		{
			if (isServer && objectDataLookup.HasComponent(fishShoalEntity))
			{
				ref ObjectDataCD valueRW = ref objectDataLookup.GetRefRW(fishShoalEntity).ValueRW;
				ref RandomCD valueRW2 = ref randomLookup.GetRefRW(fishShoalEntity).ValueRW;
				valueRW.amount++;
				if ((valueRW.amount >= 3 && valueRW2.Value.NextFloat() < 0.5f) || valueRW.amount >= 6)
				{
					ecb.DestroyEntity(fishShoalEntity);
				}
			}
		}

		public static void DisplayCaughtFishingLoot(in FishingStateCD fishingStateCD, int caughtAmount, PlayerController pc)
		{
			AudioManager.Sfx(SfxID.twitch, pc.transform.position, 0.2f, 0.7f, 0.1f, reuse: true);
			ObjectInfo objectInfo = PugDatabase.GetObjectInfo(fishingStateCD.displayFishingLootToSpawn);
			if (objectInfo != null)
			{
				Rarity rarity = objectInfo.rarity;
				if (Manager.saves.HasDiscoveredObject(fishingStateCD.displayFishingLootToSpawn))
				{
					string[] formatFields = new string[1] { PlayerController.GetObjectName(new ContainedObjectsBuffer
					{
						objectData = new ObjectDataCD
						{
							objectID = fishingStateCD.displayFishingLootToSpawn
						}
					}, localize: true).text };
					Manager.ui.chatWindow.AddInfoText(formatFields, rarity, ChatWindow.MessageTextType.CaughtItem);
				}
				if (caughtAmount > 1)
				{
					string[] formatFields2 = new string[2]
					{
						"1",
						PlayerController.GetObjectName(new ContainedObjectsBuffer
						{
							objectData = new ObjectDataCD
							{
								objectID = fishingStateCD.displayFishingLootToSpawn
							}
						}, localize: true).text
					};
					Manager.ui.chatWindow.AddInfoText(formatFields2, rarity, ChatWindow.MessageTextType.AdditionalItemGained);
				}
			}
		}

		private static void ThrowFishingRod(StateUpdateAspect stateUpdateAspect, SharedStateUpdateData sharedStateUpdateData, LookupStateUpdateData lookupStateUpdateData, bool isHoldingLavaRod)
		{
			ref FishingStateCD valueRW = ref stateUpdateAspect.fishingStateCD.ValueRW;
			DynamicBuffer<AnimationBuffer> animationBuffer = stateUpdateAspect.animationBuffer;
			ref AnimationBufferPointer valueRW2 = ref stateUpdateAspect.animationBufferPointer.ValueRW;
			NetworkTick currentTick = sharedStateUpdateData.currentTick;
			valueRW.castTimer.Stop(currentTick);
			float num = 1f + (float)EntityUtility.GetConditionValue(ConditionID.IncreasedRodRange, stateUpdateAspect.entity, lookupStateUpdateData.summarizedConditionsLookup) / 100f;
			float num2 = math.lerp(0.7f, 3f * num, valueRW.castTimer.GetElapsedRatio(currentTick));
			float3 float5 = lookupStateUpdateData.localTransformLookup[stateUpdateAspect.entity].Position + stateUpdateAspect.animationOrientationCD.ValueRO.facingDirection.f3 * num2;
			TileCD top = sharedStateUpdateData.tileAccessor.GetTop(float5.RoundToInt2());
			if (top.tileType == TileType.water && (top.tileset != 3 || isHoldingLavaRod))
			{
				float5.y = -0.2f;
			}
			stateUpdateAspect.playerAimPositionCD.ValueRW = new PlayerAimPositionCD
			{
				position = float5
			};
			valueRW.throwTimer.Start(currentTick);
			valueRW.allowedToLeaveStateTimer.Start(currentTick);
			PlayerController.PlayAnimationTrigger(577303787, currentTick, animationBuffer, ref valueRW2);
			valueRW.targetSinkWorldPosition = float5;
		}

		private static bool WallIsBetweenPlayerAndSink(in LocalTransform localTransform, in FishingStateCD fishingStateCD, in TileAccessor tileAccessor)
		{
			int2 int5 = localTransform.Position.RoundToInt2();
			int2 int6 = fishingStateCD.targetSinkWorldPosition.RoundToInt2() - int5;
			while (int6.x != 0 || int6.y != 0)
			{
				TileType tileType = tileAccessor.GetTop(int5 + int6).tileType;
				if (tileType == TileType.wall || tileType == TileType.thinWall || tileType.IsContainedResource())
				{
					return true;
				}
				if (int6.x > 0)
				{
					int6.x--;
				}
				if (int6.x < 0)
				{
					int6.x++;
				}
				if (int6.y > 0)
				{
					int6.y--;
				}
				if (int6.y < 0)
				{
					int6.y++;
				}
			}
			return false;
		}

		private static void UpdateFishOnTheHook(StateUpdateAspect stateUpdateAspect, SharedStateUpdateData sharedStateUpdateData, LookupStateUpdateData lookupStateUpdateData)
		{
			ref FishingStateCD valueRW = ref stateUpdateAspect.fishingStateCD.ValueRW;
			NetworkTick currentTick = sharedStateUpdateData.currentTick;
			uint tickRate = sharedStateUpdateData.tickRate;
			if (!valueRW.isSuccessfullyFishing || (valueRW.fishBiteTimer.isRunning && !valueRW.fishBiteTimer.IsTimerElapsed(sharedStateUpdateData.currentTick)))
			{
				return;
			}
			ref RandomCD valueRW2 = ref lookupStateUpdateData.randomLookup.GetRefRW(stateUpdateAspect.entity).ValueRW;
			if (valueRW.fishIsNibbling || !valueRW.fishBiteTimer.isRunning)
			{
				float num = 7f;
				float num2 = 16f;
				CollisionWorld collisionWorld = sharedStateUpdateData.physicsWorld.CollisionWorld;
				float3 targetSinkWorldPosition = valueRW.targetSinkWorldPosition;
				NativeList<RaycastHit> allHits = new NativeList<RaycastHit>(Allocator.Temp);
				RaycastInput input = new RaycastInput
				{
					Start = targetSinkWorldPosition + new float3(0f, 1f, 0f),
					End = targetSinkWorldPosition + new float3(0f, -1f, 0f),
					Filter = new CollisionFilter
					{
						BelongsTo = 2u,
						CollidesWith = 8192u
					}
				};
				bool flag = lookupStateUpdateData.containedObjectsBufferLookup[stateUpdateAspect.entity][stateUpdateAspect.equipmentCD.ValueRO.offHandIndex].objectID == ObjectID.BaitOctopusBoss;
				if (collisionWorld.CastRay(input, ref allHits))
				{
					for (int i = 0; i < allHits.Length; i++)
					{
						RaycastHit raycastHit = allHits[i];
						if (!lookupStateUpdateData.objectDataLookup.TryGetComponent(raycastHit.Entity, out var componentData))
						{
							continue;
						}
						switch (componentData.objectID)
						{
						case ObjectID.FishShoal:
							valueRW.fishShoalEntity = raycastHit.Entity;
							continue;
						case ObjectID.OctopusBossTeleportLocation:
							break;
						default:
							continue;
						}
						if (flag)
						{
							NativeList<Entity> octopusBosses = sharedStateUpdateData.octopusBosses;
							if (octopusBosses.Length > 0 && !lookupStateUpdateData.octopusBossLookup[octopusBosses[0]].isFighting)
							{
								valueRW.octopusBossSpawnLocationEntity = raycastHit.Entity;
								valueRW.octopusBossEntity = octopusBosses[0];
							}
							if (valueRW.isFishingAtOctopusBoss)
							{
								break;
							}
						}
					}
				}
				allHits.Dispose();
				if (valueRW.isFishingInShoal || valueRW.isFishingAtOctopusBoss)
				{
					num = 3f;
					num2 = 5f;
				}
				int2 worldPosition = valueRW.targetSinkWorldPosition.RoundToInt2();
				Tileset tileset = (Tileset)sharedStateUpdateData.tileAccessor.GetTop(worldPosition).tileset;
				Biome biome = stateUpdateAspect.currentBiomeCD.ValueRO.biome;
				sharedStateUpdateData.fishingTableCD.GetFishingStats(tileset, biome, out var _, out var skillNeeded);
				int conditionEffectValue = EntityUtility.GetConditionEffectValue(ConditionEffect.Fishing, stateUpdateAspect.entity, lookupStateUpdateData.summarizedConditionEffectsLookup);
				float num3 = math.clamp(math.lerp(1f, 0.5f, (float)(conditionEffectValue - skillNeeded) / (float)skillNeeded), 0.5f, 1f);
				float num4 = 1f - (float)EntityUtility.GetConditionValue(ConditionID.FishBitesFaster, stateUpdateAspect.entity, lookupStateUpdateData.summarizedConditionsLookup) / 100f;
				num *= num4 * num3;
				num2 *= num4 * num3;
				valueRW.fishBiteTimer.Start(currentTick, valueRW2.Value.NextFloat(num, num2), tickRate);
				valueRW.fishIsNibbling = false;
				valueRW.fishingLootToSpawn = ObjectID.None;
				return;
			}
			if (sharedStateUpdateData.isFirstTimeFullyPredictingTick)
			{
				valueRW.playFishOnHookLocalSound = true;
			}
			int2 worldPosition2 = valueRW.targetSinkWorldPosition.RoundToInt2();
			Tileset tileset2 = (Tileset)sharedStateUpdateData.tileAccessor.GetTop(worldPosition2).tileset;
			Biome biome2 = stateUpdateAspect.currentBiomeCD.ValueRO.biome;
			sharedStateUpdateData.fishingTableCD.GetFishingStats(tileset2, biome2, out var fishingInfo2, out var skillNeeded2);
			if (EntityUtility.GetConditionEffectValue(ConditionEffect.Fishing, stateUpdateAspect.entity, lookupStateUpdateData.summarizedConditionEffectsLookup) >= skillNeeded2)
			{
				DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = stateUpdateAspect.ghostEffectEventBuffer;
				ref GhostEffectEventBufferPointerCD valueRW3 = ref stateUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW;
				GhostEffectEventBuffer item = new GhostEffectEventBuffer
				{
					Tick = sharedStateUpdateData.currentTick,
					value = new EffectEventCD
					{
						localOnlyEffect = 1,
						effectID = EffectID.EmoteIcon,
						entity = stateUpdateAspect.entity,
						value1 = 0,
						value2 = 0
					}
				};
				ghostEffectEventBuffer.AddToRingBuffer(ref valueRW3, in item);
				float num5 = (float)EntityUtility.GetConditionValue(ConditionID.IncreasedChanceToGetFish, stateUpdateAspect.entity, lookupStateUpdateData.summarizedConditionsLookup) / 100f;
				num5 -= (float)EntityUtility.GetConditionValue(ConditionID.IncreasedChanceToGetFishLoot, stateUpdateAspect.entity, lookupStateUpdateData.summarizedConditionsLookup) / 100f;
				valueRW.fishOnTheHook = (!valueRW.isFishingAtOctopusBoss && valueRW2.Value.NextFloat() < num5 + 0.4f) || valueRW.isFishingInShoal;
				LootTableID lootTableID = (valueRW.fishOnTheHook ? fishingInfo2.fishLootTableID : fishingInfo2.lootTableID);
				if (!valueRW.isFishingAtOctopusBoss)
				{
					Rarity minimumRarity = Rarity.Poor;
					if (valueRW.fishOnTheHook)
					{
						if (guaranteeLegendaryFish.Data)
						{
							minimumRarity = Rarity.Legendary;
						}
						else
						{
							float num6 = (float)EntityUtility.GetConditionValue(ConditionID.IncreasedChanceForHigherRarityFish, stateUpdateAspect.entity, lookupStateUpdateData.summarizedConditionsLookup) / 100f;
							if (valueRW2.Value.NextFloat() < num6)
							{
								minimumRarity = Rarity.Uncommon;
							}
						}
					}
					using NativeList<PugDatabase.EntityLootData> nativeList = PugDatabase.GetRandomLoot(lootTableID, ref valueRW2.Value, sharedStateUpdateData.lootTableBank.Value, sharedStateUpdateData.pugDatabaseBank.databaseBankBlob, stateUpdateAspect.currentBiomeCD.ValueRO.biome, 1f, minimumRarity);
					if (nativeList.Length > 0)
					{
						valueRW.fishingLootToSpawn = nativeList[0].objectID;
					}
				}
				if (valueRW.useFishingMiniGame)
				{
					ref FishingMiniGameStateCD valueRW4 = ref stateUpdateAspect.fishingMiniGameStateCD.ValueRW;
					if (valueRW.fishOnTheHook)
					{
						ref FishingStruggleInfoData fishStruggleInfo = ref sharedStateUpdateData.fishingTableCD.GetFishStruggleInfo(valueRW.fishingLootToSpawn);
						valueRW4.fishStruggleIndex = valueRW2.Value.NextInt(0, fishStruggleInfo.struggleData.Length);
						Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(valueRW.fishingLootToSpawn, sharedStateUpdateData.pugDatabaseBank.databaseBankBlob);
						if (lookupStateUpdateData.levelLookup.TryGetComponent(primaryPrefabEntity, out var componentData2))
						{
							valueRW4.fishLevel = componentData2.level;
						}
						else
						{
							valueRW4.fishLevel = 1;
						}
					}
				}
				valueRW.fishBiteTimer.Start(currentTick, valueRW2.Value.NextFloat(3f, 4f), tickRate);
				valueRW.fishIsNibbling = true;
			}
			else
			{
				DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer2 = stateUpdateAspect.ghostEffectEventBuffer;
				ref GhostEffectEventBufferPointerCD valueRW5 = ref stateUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW;
				GhostEffectEventBuffer item = new GhostEffectEventBuffer
				{
					Tick = sharedStateUpdateData.currentTick,
					value = new EffectEventCD
					{
						entity = stateUpdateAspect.entity,
						localOnlyEffect = 1,
						effectID = EffectID.Emote,
						value1 = 14
					}
				};
				ghostEffectEventBuffer2.AddToRingBuffer(ref valueRW5, in item);
				valueRW.fishBiteTimer.Start(currentTick, valueRW2.Value.NextFloat(7f, 16f), tickRate);
				valueRW.fishIsNibbling = false;
			}
		}

		public static void OnExitFishing(ref PlayerStateCD playerStateCD, ref PlayerOrientationCD playerOrientationCD, ref FishingStateCD fishingStateCD, NetworkTick currentTick, bool wasExitingState)
		{
			fishingStateCD.fishIsNibbling = false;
			playerStateCD.PopState(PlayerStateEnum.Fishing);
			fishingStateCD.pullUpTimer.Stop(currentTick);
		}

		public static void ExitState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateShared changePlayerStateShared)
		{
			changePlayerStateAspect.playerOrientationCD.ValueRW.reorientationBlocked = false;
			PlayerStateCommon.ExitPoppedState(changePlayerStateAspect, changePlayerStateShared);
		}

		public static void EnterStatePresentation(PlayerController playerController, ChangePlayerStatePresentationAspect changePlayerStatePresentationAspect)
		{
			if (playerController.isLocal && changePlayerStatePresentationAspect.fishingState.ValueRO.useFishingMiniGame)
			{
				playerController.StartFishingMiniGameSounds();
			}
		}

		public static void ExitStatePresentation(PlayerController playerController)
		{
			if (playerController.isLocal)
			{
				playerController.StopFishingMiniGameSounds();
			}
		}

		public static void UpdateStatePresentation(StatePresentationUpdateAspect stateUpdateAspect, PlayerController playerController)
		{
			if (playerController.isLocal)
			{
				playerController.UpdateFishingMiniGameSounds(in stateUpdateAspect.fishingMiniGameStateCD.ValueRO);
			}
		}
	}
}
