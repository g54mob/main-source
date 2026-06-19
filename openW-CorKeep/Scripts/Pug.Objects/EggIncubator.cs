using Pug.Sprite;
using Pug.UnityExtensions;
using PugTilemap;
using UnityEngine;

public class EggIncubator : CraftingBuilding
{
	public SpriteObject eggSpriteObject;

	private static readonly int StrengthMul = Shader.PropertyToID("_strengthMul");

	protected override void OnShow()
	{
		Manager.multiMap.SetHiddenTile(base.WorldPosition.RoundToInt2(), 4, TileType.circuitPlate, 0);
		base.OnShow();
	}

	protected override void OnHide()
	{
		Manager.multiMap.ClearHiddenTileOfType(base.WorldPosition.RoundToInt2(), TileType.circuitPlate);
		base.OnHide();
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		ObjectID objectID = ObjectID.None;
		if (craftingHandler.outputInventoryHandler.HasObject(0))
		{
			objectID = craftingHandler.outputInventoryHandler.GetObjectData(0).objectID;
		}
		else if (craftingHandler.inventoryHandler.HasObject(0))
		{
			objectID = craftingHandler.inventoryHandler.GetObjectData(0).objectID;
		}
		DataBlockRef<SpriteAssetSkin> dataBlockRef = null;
		if (objectID != ObjectID.None)
		{
			dataBlockRef = PugDatabase.GetObjectInfo(objectID)?.iconSkinAsset;
		}
		if (dataBlockRef != eggSpriteObject.skinRef || (dataBlockRef == null && eggSpriteObject.gameObject.activeSelf) || (dataBlockRef != null && !eggSpriteObject.gameObject.activeSelf))
		{
			if (dataBlockRef == null)
			{
				eggSpriteObject.gameObject.SetActive(value: false);
				return;
			}
			eggSpriteObject.gameObject.SetActive(value: true);
			eggSpriteObject.skinRef = dataBlockRef;
			eggSpriteObject.ApplyVisualChange();
		}
	}
}
