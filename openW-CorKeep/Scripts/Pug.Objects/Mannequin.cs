using Pug.UnityExtensions;
using Unity.Mathematics;
using UnityEngine;

public class Mannequin : Table
{
	public DataBlockRef<PlayerCustomizationTableDataBlock> customizationTable;

	[Tooltip("If set, the right-facing variation is reused and reflected for the left-facing variation.")]
	public bool reflectSides = true;

	public Sprite downSprite;

	public Sprite sideSprite;

	public Sprite upSprite;

	public override void OnOccupied()
	{
		base.OnOccupied();
		if (!EntityUtility.HasComponentData<DirectionCD>(base.entity, base.world))
		{
			Debug.LogError($"{base.name} has {typeof(SpriteVariationFromEntityDirection)}, but the entity has no {typeof(DirectionCD)}.");
		}
		else
		{
			SetDirection(EntityUtility.GetComponentData<DirectionCD>(base.entity, base.world).direction.RoundToInt2());
		}
	}

	public void SetDirection(int2 direction)
	{
		int variationFromDirection = DirectionBasedOnVariationCD.GetVariationFromDirection(direction);
		for (int i = 0; i < tableItemsLists[0].tableItems.Count; i++)
		{
			SpriteRenderer component = tableItemsLists[0].tableItems[i].GetComponent<SpriteRenderer>();
			component.sprite = variationFromDirection switch
			{
				0 => upSprite, 
				1 => sideSprite, 
				3 => sideSprite, 
				_ => downSprite, 
			};
			if (reflectSides)
			{
				tableItemsLists[0].tableItems[i].transform.localScale = new Vector3((variationFromDirection != 3) ? 1 : (-1), 1f, 1f);
			}
		}
	}

	protected override void SetItemSpriteSheetSkin(SpriteSheetSkin spriteSheetSkin, ObjectInfo itemInfo, int slotIndex)
	{
		PlayerCustomizationTableDataBlock playerCustomizationTableDataBlock = customizationTable.Get();
		SetItemSpriteSheetSkinForEquipment(spriteSheetSkin, itemInfo, slotIndex, playerCustomizationTableDataBlock);
	}

	protected override void SetItemSprite(TableItem tableItem, ObjectInfo itemInfo, ContainedObjectsBuffer containedObject, int slotIndex)
	{
	}
}
