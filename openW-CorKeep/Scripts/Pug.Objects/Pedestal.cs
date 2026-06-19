using System;
using System.Collections.Generic;
using System.Linq;
using Pug.Sprite;

public class Pedestal : Table
{
	[Serializable]
	public class GameObjectVariation
	{
		public ObjectID objectID;

		public string versionHash;
	}

	public List<GameObjectVariation> variations;

	public SpriteObject spriteObjectPedestal;

	public DataBlockRef<PlayerCustomizationTableDataBlock> customizationTable;

	public TableItem optionalHelmItem;

	public override void OnOccupied()
	{
		base.OnOccupied();
		foreach (GameObjectVariation item in variations.Where((GameObjectVariation var) => var.objectID == base.objectData.objectID))
		{
			if (item.versionHash.Length > 0)
			{
				spriteObjectPedestal.SetVariant(SpriteAsset.StringToHash(item.versionHash));
			}
			else
			{
				spriteObjectPedestal.SetVariant(0);
			}
		}
	}

	protected override void SetItemSpriteSheetSkin(SpriteSheetSkin spriteSheetSkin, ObjectInfo itemInfo, int slotIndex)
	{
		PlayerCustomizationTableDataBlock playerCustomizationTableDataBlock = customizationTable.Get();
		if (IsHelmSlot(slotIndex))
		{
			optionalHelmItem.gameObject.SetActive(itemInfo != null);
			tableItemsLists[0].tableItems[0].gameObject.SetActive(value: false);
			if (ItemShouldShowHelm(itemInfo, slotIndex))
			{
				optionalHelmItem.gameObject.SetActive(itemInfo.objectID != ObjectID.None);
				SetItemSpriteSheetSkinForEquipment(optionalHelmItem.spriteSheetSkin, itemInfo, slotIndex, playerCustomizationTableDataBlock);
			}
		}
		else
		{
			if (optionalHelmItem != null)
			{
				optionalHelmItem.gameObject.SetActive(value: false);
			}
			tableItemsLists[0].tableItems[0].gameObject.SetActive(value: true);
			UpdateGlowingObject(tableItemsLists[0].tableItems[0], 0);
			base.SetItemSpriteSheetSkin(spriteSheetSkin, itemInfo, slotIndex);
		}
	}

	protected override void SetItemSprite(TableItem tableItem, ObjectInfo itemInfo, ContainedObjectsBuffer containedObject, int slotIndex)
	{
		if (!IsHelmSlot(slotIndex))
		{
			base.SetItemSprite(tableItem, itemInfo, containedObject, slotIndex);
		}
	}

	private bool ItemShouldShowHelm(ObjectInfo itemInfo, int slotIndex)
	{
		if (itemInfo != null)
		{
			return IsHelmSlot(slotIndex);
		}
		return false;
	}

	private bool IsHelmSlot(int slotIndex)
	{
		if (slotIndex == 0 && (base.objectData.objectID == ObjectID.SkeletonPedestal || base.objectData.objectID == ObjectID.SkeletonPedestal2))
		{
			return optionalHelmItem != null;
		}
		return false;
	}
}
