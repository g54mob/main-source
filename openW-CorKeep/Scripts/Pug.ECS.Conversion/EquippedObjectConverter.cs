using System.Collections.Generic;
using PlayerEquipment;
using Pug.Conversion;
using PugTilemap;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

public class EquippedObjectConverter : SingleAuthoringComponentConverter<EquippedObjectAuthoring>
{
	protected override void Convert(EquippedObjectAuthoring authoring)
	{
		_ = PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate;
		AddComponentData(new EquippedObjectCD
		{
			equippedSlotIndex = authoring.equippedSlotIndex
		});
		EnsureHasComponent<EquippedObjectVisualCD>();
		AddComponentData(EquipmentSlotCD.GetDefaultValues(secondInteractBlockedUntilRelease: false));
		EnsureHasComponent<EquipmentSlotVisualCD>();
		BlobAssetReference<EquipmentData> blobAsset = BuildEquipmentDataBlobAsset(authoring.equipmentSlots);
		base.BlobAssetStore.TryAdd(ref blobAsset);
		PlacementHandlerDigging hoePlacementHandler = GetHoePlacementHandler(authoring.equipmentSlots);
		BlobAssetReference<BlobArray<Tileset>> blobAsset2 = CreateTilesetArrayBlobAsset(hoePlacementHandler.hoeableGroundTilesets);
		base.BlobAssetStore.TryAdd(ref blobAsset2);
		PlacementHandlerDigging shovelPlacementHandler = GetShovelPlacementHandler(authoring.equipmentSlots);
		BlobAssetReference<BlobArray<Tileset>> blobAsset3 = CreateTilesetArrayBlobAsset(shovelPlacementHandler.nonDiggableGroundTilesets);
		base.BlobAssetStore.TryAdd(ref blobAsset3);
		PlacementHandlerSeeder seederPlacementHandler = GetSeederPlacementHandler(authoring.equipmentSlots);
		BlobAssetReference<BlobArray<Tileset>> blobAsset4 = CreateTilesetArrayBlobAsset(seederPlacementHandler.seedableGroundTilesets);
		base.BlobAssetStore.TryAdd(ref blobAsset4);
		AddComponentData(new EquipmentSlotConstantCD
		{
			equipmentData = blobAsset,
			hoeableGroundTilesets = blobAsset2,
			nonDiggableGroundTilesets = blobAsset3,
			seedableGroundTilesets = blobAsset4
		});
	}

	private BlobAssetReference<EquipmentData> BuildEquipmentDataBlobAsset(List<EquippedObjectAuthoring.EquipmentSlotData> equipmentSlotsAuthored)
	{
		using BlobBuilder blobBuilder = new BlobBuilder(Allocator.Temp);
		BlobBuilderArray<EquipmentInfo> blobBuilderArray = blobBuilder.Allocate(ref blobBuilder.ConstructRoot<EquipmentData>().equipmentInfo, equipmentSlotsAuthored.Count);
		for (int i = 0; i < equipmentSlotsAuthored.Count; i++)
		{
			EquipmentSlotType equipmentSlotType = equipmentSlotsAuthored[i].equipmentSlotType;
			if (HasEquipmentSlotClassWithData(equipmentSlotType))
			{
				EquipmentSlot equipmentSlot = equipmentSlotsAuthored[i].equipmentSlot as EquipmentSlot;
				if (equipmentSlot == null)
				{
					Debug.LogError($"Equipment slot {equipmentSlotType} is not of type EquipmentSlot. Please ensure it is set correctly.");
					continue;
				}
				blobBuilderArray[i].windupMoveSpeedMultiplier = equipmentSlot.windupMoveSpeedMultiplier;
				blobBuilderArray[i].collidesWith = equipmentSlot.collidesWith;
			}
		}
		return blobBuilder.CreateBlobAssetReference<EquipmentData>(Allocator.Persistent);
	}

	private bool HasEquipmentSlotClassWithData(EquipmentSlotType slot)
	{
		return slot != EquipmentSlotType.Shield;
	}

	private PlacementHandlerDigging GetHoePlacementHandler(List<EquippedObjectAuthoring.EquipmentSlotData> slots)
	{
		foreach (EquippedObjectAuthoring.EquipmentSlotData slot in slots)
		{
			if (slot.equipmentSlot is HoeSlot hoeSlot)
			{
				return hoeSlot.placementHandler;
			}
		}
		return null;
	}

	private PlacementHandlerDigging GetShovelPlacementHandler(List<EquippedObjectAuthoring.EquipmentSlotData> slots)
	{
		foreach (EquippedObjectAuthoring.EquipmentSlotData slot in slots)
		{
			if (slot.equipmentSlot is ShovelSlot shovelSlot)
			{
				return shovelSlot.placementHandler;
			}
		}
		return null;
	}

	private PlacementHandlerSeeder GetSeederPlacementHandler(List<EquippedObjectAuthoring.EquipmentSlotData> slots)
	{
		foreach (EquippedObjectAuthoring.EquipmentSlotData slot in slots)
		{
			if (slot.equipmentSlot is SeederSlot seederSlot)
			{
				return seederSlot.placementHandler;
			}
		}
		return null;
	}

	private BlobAssetReference<BlobArray<Tileset>> CreateTilesetArrayBlobAsset(List<Tileset> tileset)
	{
		using BlobBuilder blobBuilder = new BlobBuilder(Allocator.Temp, tileset.Count * 4 * 2);
		BlobBuilderArray<Tileset> blobBuilderArray = blobBuilder.Allocate(ref blobBuilder.ConstructRoot<BlobArray<Tileset>>(), tileset.Count);
		for (int i = 0; i < tileset.Count; i++)
		{
			blobBuilderArray[i] = tileset[i];
		}
		return blobBuilder.CreateBlobAssetReference<BlobArray<Tileset>>(Allocator.Persistent);
	}
}
