using Inventory;
using PlayerEquipment;
using PlayerState;
using Pug.Properties;
using Unity.Collections;
using Unity.Entities;
using Unity.Physics;

public class CastingItemSlot : EquipmentSlot
{
	private const float CAST_COOLDOWN = 0.25f;

	protected override EquipmentSlotType slotType => EquipmentSlotType.CastingSlot;

	public static bool UpdateEquipment(bool interactHeld, bool secondInteractHeld, in ClientInput clientInput, in EquipmentUpdateAspect equipmentUpdateAspect, in EquipmentUpdateSharedData equipmentUpdateSharedData, in LookupEquipmentUpdateData equipmentUpdateLookupData, bool hasItemInMouse)
	{
		if (!secondInteractHeld)
		{
			return false;
		}
		if (hasItemInMouse)
		{
			return false;
		}
		CastItem(in clientInput, in equipmentUpdateAspect, in equipmentUpdateSharedData, in equipmentUpdateLookupData);
		return true;
	}

	private static void CastItem(in ClientInput clientInput, in EquipmentUpdateAspect equipmentUpdateAspect, in EquipmentUpdateSharedData equipmentUpdateSharedData, in LookupEquipmentUpdateData equipmentUpdateLookupData)
	{
		if (equipmentUpdateAspect.playerStateCD.ValueRO.HasAnyState(PlayerStateEnum.Casting))
		{
			return;
		}
		bool flag = true;
		if (equipmentUpdateLookupData.parchementRecipeLookup.TryGetComponent(equipmentUpdateAspect.equippedObjectCD.ValueRO.equipmentPrefab, out var componentData))
		{
			if (!HasRequiredMaterials(componentData, equipmentUpdateAspect.equippedObjectCD.ValueRO.containedObject.objectData, equipmentUpdateAspect, equipmentUpdateSharedData, equipmentUpdateLookupData))
			{
				DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = equipmentUpdateAspect.ghostEffectEventBuffer;
				ref GhostEffectEventBufferPointerCD valueRW = ref equipmentUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW;
				GhostEffectEventBuffer item = new GhostEffectEventBuffer
				{
					Tick = equipmentUpdateSharedData.currentTick,
					value = new EffectEventCD
					{
						entity = equipmentUpdateAspect.entity,
						localOnlyEffect = 1,
						effectID = EffectID.Emote,
						value1 = 18
					}
				};
				ghostEffectEventBuffer.AddToRingBuffer(ref valueRW, in item);
				flag = false;
			}
			else if (componentData.requiresNearbyObject != ObjectID.None)
			{
				PhysicsWorld physicsWorld = equipmentUpdateSharedData.physicsWorld;
				equipmentUpdateSharedData.physicsWorldHistory.GetCollisionWorldFromTick(equipmentUpdateSharedData.currentTick, 1u, ref physicsWorld, out var collWorld);
				if (!PlayerController.IsAtRequiredObject(componentData.requiresNearbyObject, in equipmentUpdateLookupData.localTransformLookup.GetRefRO(equipmentUpdateAspect.entity).ValueRO, in collWorld, equipmentUpdateLookupData.objectDataLookup))
				{
					if (componentData.requiresNearbyObject == ObjectID.AncientForge)
					{
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer2 = equipmentUpdateAspect.ghostEffectEventBuffer;
						ref GhostEffectEventBufferPointerCD valueRW2 = ref equipmentUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW;
						GhostEffectEventBuffer item = new GhostEffectEventBuffer
						{
							Tick = equipmentUpdateSharedData.currentTick,
							value = new EffectEventCD
							{
								entity = equipmentUpdateAspect.entity,
								localOnlyEffect = 1,
								effectID = EffectID.Emote,
								value1 = 22
							}
						};
						ghostEffectEventBuffer2.AddToRingBuffer(ref valueRW2, in item);
					}
					flag = false;
				}
			}
		}
		if (flag)
		{
			ObjectPropertiesCD componentData2;
			bool flag2 = equipmentUpdateLookupData.objectPropertiesLookup.TryGetComponent(equipmentUpdateAspect.equippedObjectCD.ValueRO.equipmentPrefab, out componentData2) && componentData2.Has(-1643145590);
			equipmentUpdateAspect.equipmentSlotCD.ValueRW.secondInteractBlockedUntilRelease = !flag2;
			equipmentUpdateAspect.playerStateCD.ValueRW.SetNextState(PlayerStateEnum.Casting);
			EquipmentSlot.StartCooldownForItem(in equipmentUpdateAspect.equippedObjectCD.ValueRO, ref equipmentUpdateAspect.playerAttackCooldownCD.ValueRW, equipmentUpdateAspect.syncedSharedCooldownTimers, equipmentUpdateSharedData.currentTick, equipmentUpdateSharedData.tickRate, in equipmentUpdateSharedData.databaseBank, equipmentUpdateLookupData.cooldownLookup, 0.25f);
		}
	}

	private static bool HasRequiredMaterials(ParchmentRecipeCD recipe, ObjectDataCD objectData, EquipmentUpdateAspect equipmentUpdateAspect, EquipmentUpdateSharedData equipmentUpdateSharedData, LookupEquipmentUpdateData equipmentUpdateLookupData)
	{
		ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(recipe.objectToCraft.objectID, equipmentUpdateSharedData.databaseBank.databaseBankBlob);
		Entity value = equipmentUpdateAspect.entity;
		using NativeList<Entity> inventoryEntities = new NativeList<Entity>(Allocator.Temp);
		inventoryEntities.Add(in value);
		ref PugDatabase.EntityObjectInfo entityObjectInfo2 = ref PugDatabase.GetEntityObjectInfo(entityObjectInfo.objectID, equipmentUpdateSharedData.databaseBank.databaseBankBlob);
		NativeList<ObjectWithAmount> requiredObjectsToCraft = new NativeList<ObjectWithAmount>(entityObjectInfo2.requiredObjectsToCraft.Length, Allocator.Temp);
		for (int i = 0; i < entityObjectInfo2.requiredObjectsToCraft.Length; i++)
		{
			requiredObjectsToCraft.Add(new ObjectWithAmount
			{
				objectID = entityObjectInfo2.requiredObjectsToCraft[i].objectID,
				amount = entityObjectInfo2.requiredObjectsToCraft[i].amount
			});
		}
		return InventoryUtility.HasMaterialsInCraftingInventoryToCraftRecipe(equipmentUpdateLookupData.containedObjectsBufferLookup, equipmentUpdateLookupData.inventoryBufferLookup, equipmentUpdateSharedData.databaseBank, equipmentUpdateLookupData.anvilLookup, equipmentUpdateLookupData.objectDataLookup, equipmentUpdateLookupData.summarizedConditionsBufferLookup, value, value, inventoryEntities, requiredObjectsToCraft);
	}
}
