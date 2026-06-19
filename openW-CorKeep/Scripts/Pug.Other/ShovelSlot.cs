using PlayerEquipment;
using PlayerState;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

public class ShovelSlot : EquipmentSlot
{
	public enum ShovelAction
	{
		DIG_HOLE = 0,
		DIG_UP_ENTITY = 1,
		DIG_UP_TILE = 2
	}

	private const float DIG_COOLDOWN = 0.4f;

	public PlacementHandlerDigging placementHandler;

	protected override EquipmentSlotType slotType => EquipmentSlotType.ShovelSlot;

	public static bool UpdateEquipment(bool interactHeld, bool secondInteractHeld, in ClientInput clientInput, in EquipmentUpdateAspect equipmentUpdateAspect, in EquipmentUpdateSharedData equipmentUpdateSharedData, in LookupEquipmentUpdateData equipmentUpdateLookupData, bool hasItemInMouse)
	{
		if (clientInput.IsButtonStateSet(CommandInputButtonStateNames.Rotate_Pressed))
		{
			EquipmentSlot.ChangeSize(in equipmentUpdateAspect, equipmentUpdateSharedData.databaseBank);
		}
		NativeList<PlacementHandler.EntityAndInfoFromPlacement> diggableEntityAndInfos = new NativeList<PlacementHandler.EntityAndInfoFromPlacement>(Allocator.Temp);
		PlacementHandler.UpdatePlaceablePosition(equipmentUpdateAspect.equippedObjectCD.ValueRO.equipmentPrefab, ref diggableEntityAndInfos, in equipmentUpdateAspect, in equipmentUpdateSharedData, in equipmentUpdateLookupData);
		if (equipmentUpdateAspect.equippedObjectCD.ValueRO.isBroken || !secondInteractHeld)
		{
			diggableEntityAndInfos.Dispose();
			return false;
		}
		if (hasItemInMouse)
		{
			return false;
		}
		Dig(ref diggableEntityAndInfos, in equipmentUpdateAspect, equipmentUpdateSharedData, equipmentUpdateLookupData);
		diggableEntityAndInfos.Dispose();
		return true;
	}

	private static void Dig(ref NativeList<PlacementHandler.EntityAndInfoFromPlacement> diggableEntityAndInfos, in EquipmentUpdateAspect equipmentUpdateAspect, EquipmentUpdateSharedData equipmentUpdateSharedData, LookupEquipmentUpdateData equipmentUpdateLookupData)
	{
		ref PlacementCD valueRW = ref equipmentUpdateAspect.placementCD.ValueRW;
		if (!valueRW.canPlaceObject || diggableEntityAndInfos.Length <= 0)
		{
			return;
		}
		float cooldown = (equipmentUpdateLookupData.godModeLookup.IsComponentEnabled(equipmentUpdateAspect.entity) ? 0.15f : 0.4f);
		EquipmentSlot.StartCooldownForItem(in equipmentUpdateAspect, equipmentUpdateSharedData, equipmentUpdateLookupData, cooldown);
		ObjectDataCD objectDataCD = equipmentUpdateAspect.equippedObjectCD.ValueRO.containedObject.objectData;
		ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(objectDataCD.objectID, equipmentUpdateSharedData.databaseBank.databaseBankBlob, objectDataCD.variation);
		equipmentUpdateAspect.digStateCD.ValueRW.positionToPlaceAt = valueRW.bestPositionToPlaceAt;
		equipmentUpdateAspect.flattenStateCD.ValueRW.positionToPlaceAt = valueRW.bestPositionToPlaceAt;
		equipmentUpdateAspect.playerStateCD.ValueRW.PushState(PlayerStateEnum.Dig);
		ShovelAction shovelAction = ShovelAction.DIG_HOLE;
		foreach (PlacementHandler.EntityAndInfoFromPlacement diggableEntityAndInfo in diggableEntityAndInfos)
		{
			if (diggableEntityAndInfo.entity != Entity.Null && !equipmentUpdateLookupData.tileLookup.HasComponent(diggableEntityAndInfo.entity))
			{
				shovelAction = ShovelAction.DIG_UP_ENTITY;
				break;
			}
			TileType tileType = diggableEntityAndInfo.tileType;
			if (tileType != TileType.ground && tileType != TileType.dugUpGround && tileType != TileType.wateredGround)
			{
				shovelAction = ShovelAction.DIG_UP_TILE;
			}
		}
		TileAccessor tileAccessor = equipmentUpdateSharedData.tileAccessor;
		bool flag = false;
		foreach (PlacementHandler.EntityAndInfoFromPlacement diggableEntityAndInfo2 in diggableEntityAndInfos)
		{
			int2 int5 = diggableEntityAndInfo2.pos.ToInt2();
			Entity entity = diggableEntityAndInfo2.entity;
			if (tileAccessor.HasType(int5, TileType.immune))
			{
				continue;
			}
			switch (shovelAction)
			{
			case ShovelAction.DIG_UP_ENTITY:
				if (entity != Entity.Null)
				{
					if (equipmentUpdateLookupData.destructibleLookup.HasComponent(entity))
					{
						EntityUtility.DropDestructible(entity, equipmentUpdateAspect.entity, equipmentUpdateLookupData, equipmentUpdateSharedData);
						flag = true;
						break;
					}
					PlayerController.OnHarvest(equipmentUpdateAspect.entity, ref equipmentUpdateAspect.hungerCD.ValueRW, in equipmentUpdateAspect.playerStateCD.ValueRO, equipmentUpdateSharedData.ecb, equipmentUpdateSharedData.isServer, entity, wasInstantlyDestroyed: true, equipmentUpdateLookupData.plantLookup, equipmentUpdateLookupData.growingLookup, equipmentUpdateLookupData.objectDataLookup, equipmentUpdateLookupData.healthLookup, equipmentUpdateLookupData.summarizedConditionsBufferLookup, equipmentUpdateSharedData.achievementArchetype, equipmentUpdateLookupData.objectPropertiesLookup);
					Random rng = new Random(equipmentUpdateAspect.randomCD.ValueRO.Value.NextUInt());
					EntityUtility.Destroy(entity, dontDrop: false, equipmentUpdateAspect.entity, equipmentUpdateLookupData.healthLookup, equipmentUpdateLookupData.entityDestroyedLookup, equipmentUpdateLookupData.dontDropSelfLookup, equipmentUpdateLookupData.dontDropLootLookup, equipmentUpdateLookupData.killedByPlayerLookup, equipmentUpdateLookupData.plantLookup, equipmentUpdateLookupData.summarizedConditionEffectsBufferLookup, ref rng, equipmentUpdateLookupData.moveToPredictedByEntityDestroyedLookup, equipmentUpdateSharedData.currentTick);
					flag = true;
				}
				break;
			case ShovelAction.DIG_UP_TILE:
			{
				TileType tileType = diggableEntityAndInfo2.tileType;
				if (tileType != TileType.ground && tileType != TileType.dugUpGround && tileType != TileType.wateredGround)
				{
					DynamicBuffer<TileUpdateBuffer> tileUpdateBuffer = equipmentUpdateLookupData.tileUpdateBufferLookup[equipmentUpdateSharedData.tileUpdateBufferEntity];
					PlayerController.DigUpTile(diggableEntityAndInfo2.tileType, diggableEntityAndInfo2.tileset, int5.ToInt3(), equipmentUpdateAspect.entity, tileUpdateBuffer, equipmentUpdateSharedData.tileAccessor, equipmentUpdateSharedData.databaseBank, equipmentUpdateSharedData.ecb, equipmentUpdateSharedData.tileWithTilesetToObjectDataMapCD, equipmentUpdateLookupData.tileLookup, equipmentUpdateSharedData.isFirstTimeFullyPredictingTick);
					flag = true;
				}
				break;
			}
			case ShovelAction.DIG_HOLE:
			{
				TileType tileType = diggableEntityAndInfo2.tileType;
				if (tileType == TileType.ground || tileType == TileType.dugUpGround || tileType == TileType.wateredGround)
				{
					if (!equipmentUpdateLookupData.godModeLookup.IsComponentEnabled(equipmentUpdateAspect.entity) && (diggableEntityAndInfo2.tileset == 72 || diggableEntityAndInfo2.tileset == 2))
					{
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = equipmentUpdateAspect.ghostEffectEventBuffer;
						ref GhostEffectEventBufferPointerCD valueRW2 = ref equipmentUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW;
						GhostEffectEventBuffer item = new GhostEffectEventBuffer
						{
							Tick = equipmentUpdateSharedData.currentTick,
							value = new EffectEventCD
							{
								effectID = EffectID.FailedHitWithSparks,
								position1 = int5.ToFloat3() + new float3(0f, 1f, 0f) * 0.1f
							}
						};
						ghostEffectEventBuffer.AddToRingBuffer(ref valueRW2, in item);
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer2 = equipmentUpdateAspect.ghostEffectEventBuffer;
						ref GhostEffectEventBufferPointerCD valueRW3 = ref equipmentUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW;
						item = new GhostEffectEventBuffer
						{
							Tick = equipmentUpdateSharedData.currentTick,
							value = new EffectEventCD
							{
								entity = equipmentUpdateAspect.entity,
								localOnlyEffect = 1,
								effectID = EffectID.Emote,
								value1 = 27
							}
						};
						ghostEffectEventBuffer2.AddToRingBuffer(ref valueRW3, in item);
						continue;
					}
					equipmentUpdateAspect.dealDamageToEntityBuffer.Add(new DealDamageToEntityBuffer
					{
						attackType = DealDamageToEntityBuffer.AttackType.Shovel,
						hitPosition = int5.ToFloat3()
					});
					flag = true;
				}
				break;
			}
			}
			if (flag)
			{
				PlayDigEffects(int5.ToFloat3() + new float3(0f, 1f, 0f) * 0.1f, equipmentUpdateAspect, equipmentUpdateSharedData);
			}
			float num = entityObjectInfo.prefabTileSize.x;
			float num2 = entityObjectInfo.prefabTileSize.y;
			float num3 = 0.5f;
			float num4 = -0.5f;
			float3 float5 = new float3(num / 2f + num4, 0f, num2 / 2f + num4);
			float3 size = new float3(num + num3, 1f, num2 + num3);
			equipmentUpdateAspect.critterDamageFromPlacingCD.ValueRW = new CritterDamageFromPlacingCD
			{
				triggered = true,
				pos = int5.ToFloat3() - float5,
				size = size,
				canDamageFlyingCritter = false,
				killEvenIfSquashBugsIsOff = true
			};
		}
		if (flag)
		{
			equipmentUpdateLookupData.reduceDurabilityOfEquippedTagLookup.SetComponentEnabled(equipmentUpdateAspect.entity, value: true);
			equipmentUpdateLookupData.reduceDurabilityOfEquippedTagLookup.GetRefRW(equipmentUpdateAspect.entity).ValueRW.triggerCounter++;
		}
	}

	private static void PlayDigEffects(float3 position, EquipmentUpdateAspect equipmentUpdateAspect, EquipmentUpdateSharedData equipmentUpdateSharedData)
	{
		DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = equipmentUpdateAspect.ghostEffectEventBuffer;
		ref GhostEffectEventBufferPointerCD valueRW = ref equipmentUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW;
		GhostEffectEventBuffer item = new GhostEffectEventBuffer
		{
			Tick = equipmentUpdateSharedData.currentTick,
			value = new EffectEventCD
			{
				effectID = EffectID.DigGround,
				position1 = position
			}
		};
		ghostEffectEventBuffer.AddToRingBuffer(ref valueRW, in item);
	}

	public override void OnFree()
	{
		placementHandler.Disable();
		base.OnFree();
	}

	public override void OnEquip(PlayerController player)
	{
		base.OnEquip(player);
		placementHandler.Enable();
	}

	public override void OnUnequip(PlayerController player)
	{
		placementHandler.Disable();
		base.OnUnequip(player);
	}

	public override void OnPickUp(PlayerController player, bool fireSceneEvent)
	{
		base.OnPickUp(player, fireSceneEvent);
		placementHandler.Disable();
	}
}
