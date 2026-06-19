using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Table : Chest
{
	[Serializable]
	public class TableItemsList
	{
		public List<TableItem> tableItems;
	}

	public bool showSmallIcons;

	public List<TableItemsList> tableItemsLists;

	private static readonly int Emissive = Shader.PropertyToID("_Emissive");

	protected override void Awake()
	{
		base.Awake();
		foreach (TableItemsList tableItemsList in tableItemsLists)
		{
			foreach (TableItem tableItem in tableItemsList.tableItems)
			{
				if (tableItem.itemOverlaySR != null)
				{
					tableItem.itemOverlaySR.gameObject.SetActive(value: false);
				}
				if (tableItem.itemUnderlaySR != null)
				{
					tableItem.itemUnderlaySR.gameObject.SetActive(value: false);
				}
			}
		}
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		ResetTableItems();
		UpdateVisuals();
	}

	protected override void OnHide()
	{
		foreach (TableItemsList tableItemsList in tableItemsLists)
		{
			List<TableItem> tableItems = tableItemsList.tableItems;
			for (int i = 0; i < tableItems.Count; i++)
			{
				if (tableItems[i].hasObjectLight)
				{
					tableItems[i].objectLight.gameObject.SetActive(value: false);
				}
			}
		}
		base.OnHide();
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (!base.isHidden)
		{
			UpdateVisuals();
		}
	}

	protected virtual void UpdateVisuals()
	{
		foreach (TableItemsList tableItemsList in tableItemsLists)
		{
			List<TableItem> tableItems = tableItemsList.tableItems;
			for (int i = 0; i < Mathf.Min(tableItems.Count, base.inventoryHandler.size); i++)
			{
				TableItem tableItem = tableItems[i];
				ContainedObjectsBuffer containedObjectData = base.inventoryHandler.GetContainedObjectData(i);
				if (containedObjectData.objectID == tableItem.currentItemIDShowing)
				{
					continue;
				}
				if (containedObjectData.objectID == ObjectID.None)
				{
					if (tableItem.itemSR != null)
					{
						SetItemSprite(tableItem, null, default(ContainedObjectsBuffer), i);
					}
					if (tableItem.legendaryBeam != null)
					{
						tableItem.legendaryBeam.SetActive(value: false);
					}
					if (tableItems[i].spriteSheetSkin != null)
					{
						SetItemSpriteSheetSkin(tableItems[i].spriteSheetSkin, null, i);
					}
				}
				else
				{
					ObjectInfo objectInfo = PugDatabase.GetObjectInfo(containedObjectData.objectID, containedObjectData.variation);
					if (objectInfo != null)
					{
						if (tableItem.itemSR != null)
						{
							SetItemSprite(tableItem, objectInfo, containedObjectData, i);
						}
						if (tableItems[i].spriteSheetSkin != null)
						{
							SetItemSpriteSheetSkin(tableItems[i].spriteSheetSkin, objectInfo, i);
						}
						if (tableItem.colorReplacer != null)
						{
							tableItem.colorReplacer.UpdateColorReplacerFromObjectData(containedObjectData);
						}
						if (tableItem.legendaryBeam != null)
						{
							tableItems[i].legendaryBeam.SetActive(objectInfo.rarity == Rarity.Legendary);
						}
					}
				}
				tableItem.currentItemIDShowing = containedObjectData.objectID;
			}
		}
		UpdateGlowingObjects();
	}

	protected virtual void SetItemSprite(TableItem tableItem, ObjectInfo itemInfo, ContainedObjectsBuffer containedObject, int slotIndex)
	{
		if (!tableItem.dontChangeSprite)
		{
			Sprite iconOverride = Manager.ui.itemOverridesTable.GetIconOverride(containedObject.objectData, showSmallIcons);
			tableItem.itemSR.sprite = ((iconOverride != null) ? iconOverride : ((itemInfo == null) ? null : (showSmallIcons ? itemInfo.smallIcon : itemInfo.icon)));
			Manager.ui.ApplyAnyIconGradientMap(containedObject, tableItem.itemSR);
			bool active = Manager.ui.ShouldShowCageOverlay(containedObject);
			if (tableItem.itemOverlaySR != null)
			{
				tableItem.itemOverlaySR.gameObject.SetActive(active);
			}
			if (tableItem.itemUnderlaySR != null)
			{
				tableItem.itemUnderlaySR.gameObject.SetActive(active);
			}
		}
	}

	protected virtual void SetItemSpriteSheetSkin(SpriteSheetSkin spriteSheetSkin, ObjectInfo itemInfo, int slotIndex)
	{
	}

	private void UpdateGlowingObjects()
	{
		foreach (TableItemsList tableItemsList in tableItemsLists)
		{
			List<TableItem> tableItems = tableItemsList.tableItems;
			for (int i = 0; i < Mathf.Min(tableItems.Count, base.inventoryHandler.size); i++)
			{
				UpdateGlowingObject(tableItems[i], i);
			}
		}
	}

	protected void UpdateGlowingObject(TableItem tableItem, int index)
	{
		if (!tableItem.hasObjectLight)
		{
			return;
		}
		ObjectDataCD objectDataCD = base.inventoryHandler.GetObjectData(index);
		ConditionID conditionID = ConditionID.None;
		if (objectDataCD.objectID != ObjectID.None)
		{
			if (PugDatabase.HasComponent<TableItemLightSourceCD>(objectDataCD))
			{
				SimpleConditionData condition = PugDatabase.GetComponent<TableItemLightSourceCD>(objectDataCD).Condition;
				ConditionID conditionID2 = condition.conditionID;
				if (conditionID2 == ConditionID.BlueGlow || conditionID2 == ConditionID.OrangeGlow || conditionID2 == ConditionID.PinkGlow || conditionID2 == ConditionID.GreenGlow || conditionID2 == ConditionID.VoidGlow)
				{
					tableItem.objectLight.lightToOptimize.range = condition.value;
					tableItem.objectLight.lightToOptimize.color = Manager.effects.GetGlowColor(condition.conditionID);
					conditionID = condition.conditionID;
				}
			}
			else if (PugDatabase.HasComponent<ActAsLightSourceWhenHeldInHandCD>(objectDataCD))
			{
				ActAsLightSourceWhenHeldInHandCD component = PugDatabase.GetComponent<ActAsLightSourceWhenHeldInHandCD>(objectDataCD);
				tableItem.objectLight.lightToOptimize.range = component.range;
				tableItem.objectLight.lightToOptimize.color = component.color;
				conditionID = ConditionID.OrangeGlow;
			}
		}
		if (conditionID != tableItem.currentGlowCondition)
		{
			if (conditionID != ConditionID.None)
			{
				tableItem.objectLight.gameObject.SetActive(value: true);
				SetEmissiveness(tableItem, Color.white * 0.7f);
			}
			else
			{
				tableItem.objectLight.gameObject.SetActive(value: false);
				SetEmissiveness(tableItem, Color.black);
			}
			tableItem.currentGlowCondition = conditionID;
		}
	}

	private void SetEmissiveness(TableItem tableItem, Color color)
	{
		if (tableItem.itemSR != null && tableItem.itemSR.material != null)
		{
			tableItem.itemSR.material.SetColor(Emissive, color);
		}
	}

	private void ResetTableItems()
	{
		foreach (TableItemsList tableItemsList in tableItemsLists)
		{
			List<TableItem> tableItems = tableItemsList.tableItems;
			for (int i = 0; i < tableItems.Count; i++)
			{
				ResetTableItem(tableItems[i], i);
			}
		}
	}

	protected void ResetTableItem(TableItem tableItem, int index)
	{
		SetEmissiveness(tableItem, Color.black);
		if (tableItem.itemSR != null)
		{
			SetItemSprite(tableItem, null, default(ContainedObjectsBuffer), index);
		}
		if (tableItem.spriteSheetSkin != null)
		{
			SetItemSpriteSheetSkin(tableItem.spriteSheetSkin, null, index);
		}
		if (tableItem.legendaryBeam != null)
		{
			tableItem.legendaryBeam.SetActive(value: false);
		}
		tableItem.currentItemIDShowing = ObjectID.None;
		tableItem.currentGlowCondition = ConditionID.None;
		if (tableItem.hasObjectLight)
		{
			tableItem.objectLight.gameObject.SetActive(value: false);
		}
	}

	protected void SetItemSpriteSheetSkinForEquipment(SpriteSheetSkin spriteSheetSkin, ObjectInfo itemInfo, int slotIndex, PlayerCustomizationTableDataBlock customizationTable)
	{
		if (itemInfo != null)
		{
			ObjectDataCD objectDataCD = new ObjectDataCD
			{
				objectID = itemInfo.objectID,
				variation = itemInfo.variation
			};
			if (PugDatabase.HasComponent<EquipmentSkinCD>(objectDataCD))
			{
				GetTextures(slotIndex, PugDatabase.GetComponent<EquipmentSkinCD>(objectDataCD).skin, out var texture, out var emissiveTexture);
				spriteSheetSkin.LoadAndSetSkinAsync(texture, emissiveTexture, runSynchronously: false, delegate
				{
					spriteSheetSkin.sr.enabled = true;
				});
			}
			else
			{
				spriteSheetSkin.sr.enabled = false;
			}
		}
		else
		{
			spriteSheetSkin.sr.enabled = false;
		}
	}

	private static void GetTextures(int slotIndex, DataBlockAddress address, out AssetReferenceTexture2D texture, out AssetReferenceTexture2D emissiveTexture)
	{
		texture = null;
		emissiveTexture = null;
		switch (slotIndex)
		{
		case 0:
		{
			HelmSkinDataBlock dataBlock3 = ScriptableData.GetDataBlock<HelmSkinDataBlock>(address);
			texture = ((dataBlock3 != null) ? dataBlock3.helmTexture : null);
			emissiveTexture = ((dataBlock3 != null) ? dataBlock3.emissiveHelmTexture : null);
			break;
		}
		case 1:
		{
			BreastArmorSkinDataBlock dataBlock2 = ScriptableData.GetDataBlock<BreastArmorSkinDataBlock>(address);
			texture = ((dataBlock2 != null) ? dataBlock2.breastTexture : null);
			emissiveTexture = ((dataBlock2 != null) ? dataBlock2.emissiveBreastTexture : null);
			break;
		}
		default:
		{
			PantsArmorSkinDataBlock dataBlock = ScriptableData.GetDataBlock<PantsArmorSkinDataBlock>(address);
			texture = ((dataBlock != null) ? dataBlock.pantsTexture : null);
			emissiveTexture = ((dataBlock != null) ? dataBlock.emissivePantsTexture : null);
			break;
		}
		}
	}
}
