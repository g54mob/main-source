using System.Collections.Generic;
using PugTilemap;
using Unity.Entities;
using UnityEngine;

public class CraftingUIBase : UIelement
{
	public GameObject root;

	public ItemSlotsUIContainer inventoryUI;

	public RecipesUI recipeUI;

	public OutputUI outputUI;

	public SmallTitleUIBackground title;

	public SpriteRenderer arrow;

	public bool dontUseThemeForInventorySlots;

	public SpriteRenderer background;

	public SpriteRenderer categoryBackground;

	[HideInInspector]
	public int windowIndex;

	public override bool isShowing => root.activeInHierarchy;

	protected CraftingHandler activeCraftingHandler => Manager.main.player?.activeCraftingHandler;

	protected override void LateUpdate()
	{
		root.transform.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
		base.LateUpdate();
	}

	public virtual void ShowCraftingUI()
	{
		ClearRecipeHighlights();
		root.SetActive(value: true);
		UIManager.CraftingUIThemeType craftingUIThemeType = UIManager.CraftingUIThemeType.Wood;
		CraftingBuilding craftingBuilding = GetCraftingBuilding();
		if (craftingBuilding != null && craftingBuilding.entityExist)
		{
			craftingUIThemeType = craftingBuilding.GetCraftingUISettings().craftingUIBackgroundVariation;
		}
		UIManager.CraftingUITheme craftingUITheme = Manager.ui.GetCraftingUITheme(craftingUIThemeType);
		background.sprite = craftingUITheme.background;
		if (categoryBackground != null)
		{
			categoryBackground.sprite = craftingUITheme.categoryBackground;
		}
		if (outputUI != null)
		{
			foreach (SlotUIBase itemSlot in outputUI.itemSlots)
			{
				itemSlot.background.sprite = craftingUITheme.outputSlotBackground;
				itemSlot.hoverBorder.sprite = craftingUITheme.slotHoverSprite;
				itemSlot.activeBorder.sprite = craftingUITheme.slotSelectSprite;
			}
		}
		if (inventoryUI != null)
		{
			foreach (SlotUIBase itemSlot2 in inventoryUI.itemSlots)
			{
				if (dontUseThemeForInventorySlots)
				{
					continue;
				}
				itemSlot2.background.sprite = craftingUITheme.inventorySlotBackground;
				if (itemSlot2.tiledDecorationBackground != null)
				{
					itemSlot2.tiledDecorationBackground.gameObject.SetActive(craftingUITheme.inventorySlotTiledDecorationBackground != null);
					Vector2 size = itemSlot2.tiledDecorationBackground.size;
					itemSlot2.tiledDecorationBackground.sprite = craftingUITheme.inventorySlotTiledDecorationBackground;
					itemSlot2.tiledDecorationBackground.size = size;
				}
				if (itemSlot2.darkBackground != null)
				{
					itemSlot2.darkBackground.color = craftingUITheme.backgroundColor;
					InventorySlotUI inventorySlotUI = itemSlot2 as InventorySlotUI;
					if (inventorySlotUI != null)
					{
						inventorySlotUI.darkBackgroundDefaultAlpha = craftingUITheme.backgroundColor.a;
					}
				}
				itemSlot2.hoverBorder.sprite = craftingUITheme.slotHoverSprite;
				itemSlot2.activeBorder.sprite = craftingUITheme.slotSelectSprite;
			}
		}
		if (recipeUI != null)
		{
			foreach (SlotUIBase itemSlot3 in recipeUI.itemSlots)
			{
				itemSlot3.background.sprite = craftingUITheme.inventorySlotBackground;
				if (itemSlot3.tiledDecorationBackground != null)
				{
					itemSlot3.tiledDecorationBackground.gameObject.SetActive(craftingUITheme.inventorySlotTiledDecorationBackground != null);
					Vector2 size2 = itemSlot3.tiledDecorationBackground.size;
					itemSlot3.tiledDecorationBackground.sprite = craftingUITheme.inventorySlotTiledDecorationBackground;
					itemSlot3.tiledDecorationBackground.size = size2;
				}
				if (itemSlot3.darkBackground != null)
				{
					itemSlot3.darkBackground.color = craftingUITheme.backgroundColor;
				}
				itemSlot3.hoverBorder.sprite = craftingUITheme.slotHoverSprite;
				itemSlot3.activeBorder.sprite = craftingUITheme.slotSelectSprite;
			}
		}
		if (arrow != null)
		{
			arrow.sprite = craftingUITheme.arrowSprite;
		}
		if (title != null)
		{
			title.UpdateThemeTextAndBackground(craftingUITheme, windowIndex);
		}
	}

	public virtual void HighlightRecipe(ObjectID recipe)
	{
		if (recipeUI != null)
		{
			recipeUI.HighlightRecipe(recipe);
		}
	}

	public virtual void ClearRecipeHighlights()
	{
		if (recipeUI != null)
		{
			recipeUI.ClearRecipeHighlights();
		}
	}

	public static CraftingBuilding GetCraftingBuilding()
	{
		InteractableObject currentInteractableObject = Manager.main.player.GetCurrentInteractableObject();
		if (currentInteractableObject != null && Manager.main.player.activeCraftingHandler != Manager.main.player.playerCraftingHandler)
		{
			return currentInteractableObject.transform.parent.GetComponent<CraftingBuilding>();
		}
		return null;
	}

	public virtual void HideCraftingUI()
	{
		root.SetActive(value: false);
	}

	public virtual void UpdateAllCraftingUI(bool autoFillMaterials = false)
	{
	}

	public virtual void ActivateRecipeSlot(int visibleSlotIndex, bool mod1, bool mod2)
	{
		PlayerController player = Manager.main.player;
		if (player == null)
		{
			return;
		}
		InventoryHandler mouseInventoryHandler = Manager.main.player.mouseInventoryHandler;
		List<Entity> nearbyChests = activeCraftingHandler.GetNearbyChests();
		if (Manager.ui.craftingMaterialsAreNotRequired || activeCraftingHandler.HasMaterialsInCraftingInventoryToCraftRecipe(visibleSlotIndex, checkPlayerInventoryToo: true, nearbyChests))
		{
			CraftingHandler.RecipeInfo recipeInfo = activeCraftingHandler.GetRecipeInfo(visibleSlotIndex);
			ContainedObjectsBuffer containedObject = new ContainedObjectsBuffer
			{
				objectData = new ObjectDataCD
				{
					objectID = recipeInfo.objectID,
					amount = recipeInfo.amount
				}
			};
			if (!mouseInventoryHandler.HasRoomForObject(player, containedObject))
			{
				if (!player.playerInventoryHandler.HasRoomForObject(player, mouseInventoryHandler.GetContainedObjectData(0)))
				{
					return;
				}
				mouseInventoryHandler.MoveAllToOrDrop(player, 0, player.playerInventoryHandler, player.transform.position);
			}
			int num = 1;
			ObjectInfo objectInfo = PugDatabase.GetObjectInfo(containedObject.objectID);
			if (mod1 && objectInfo.isStackable)
			{
				for (int num2 = 10; num2 >= 2; num2--)
				{
					if (activeCraftingHandler.HasMaterialsInCraftingInventoryToCraftRecipe(visibleSlotIndex, checkPlayerInventoryToo: true, nearbyChests, num2))
					{
						num = num2;
						break;
					}
				}
			}
			int amount = num;
			int num3 = (containedObject.amount - 1) * num;
			ObjectID objectID = containedObject.objectID;
			DynamicBuffer<SummarizedConditionsBuffer> conditionValues = EntityUtility.GetConditionValues(player.entity, player.world);
			float num4 = (float)conditionValues[119].value / 100f;
			if (num4 > 0f && PugDatabase.HasComponent<TileCD>(containedObject.objectID))
			{
				TileCD component = PugDatabase.GetComponent<TileCD>(containedObject.objectID);
				if (component.tileType == TileType.wall || component.tileType == TileType.floor || component.tileType == TileType.fence || component.tileType == TileType.bridge || component.tileType == TileType.litFloor || component.tileType == TileType.thinWall || (component.tileType == TileType.ground && component.tileset == 31))
				{
					int num5 = 0;
					for (int i = 0; i < num; i++)
					{
						if (Random.value < num4)
						{
							num5++;
						}
					}
					num3 += num5;
					if (objectInfo != null && num5 > 0)
					{
						string[] formatFields = new string[2]
						{
							num5.ToString(),
							PlayerController.GetObjectName(containedObject, localize: true).text
						};
						Manager.ui.chatWindow.AddInfoText(formatFields, objectInfo.rarity, ChatWindow.MessageTextType.AdditionalItemGained);
					}
				}
			}
			float num6 = (float)conditionValues[120].value / 100f;
			if (num6 > 0f && EntityUtility.HasComponentData<ObjectDataCD>(player.activeCraftingHandler.craftingEntity, player.world))
			{
				ObjectID objectID2 = EntityUtility.GetComponentData<ObjectDataCD>(player.activeCraftingHandler.craftingEntity, player.world).objectID;
				if (objectID2 == ObjectID.AlchemyTable || objectID2 == ObjectID.DistilleryTable || objectID2 == ObjectID.LaboratoryWorkbench)
				{
					int num7 = 0;
					for (int j = 0; j < num; j++)
					{
						if (Random.value < num6)
						{
							num7++;
						}
					}
					num3 += num7;
					if (objectInfo != null && num7 > 0)
					{
						string[] formatFields2 = new string[2]
						{
							num7.ToString(),
							PlayerController.GetObjectName(containedObject, localize: true).text
						};
						Manager.ui.chatWindow.AddInfoText(formatFields2, objectInfo.rarity, ChatWindow.MessageTextType.AdditionalItemGained);
					}
				}
			}
			float num8 = (float)conditionValues[122].value / 100f;
			for (int k = 0; k < num; k++)
			{
				if (Random.value < num8 && PugDatabase.HasComponent<JewelryCanBePolishedCD>(containedObject.objectID))
				{
					objectID = PugDatabase.GetComponent<JewelryCanBePolishedCD>(containedObject.objectID).polishedVersion;
					ObjectInfo objectInfo2 = PugDatabase.GetObjectInfo(objectID);
					if (objectInfo2 != null)
					{
						string[] formatFields3 = new string[1] { PlayerController.GetObjectName(new ContainedObjectsBuffer
						{
							objectData = new ObjectDataCD
							{
								objectID = objectID
							}
						}, localize: true).text };
						Manager.ui.chatWindow.AddInfoText(formatFields3, objectInfo2.rarity, ChatWindow.MessageTextType.GainedItem);
					}
				}
			}
			int value = conditionValues[121].value;
			if (value > 0 && (containedObject.objectID == ObjectID.ConveyorBelt || containedObject.objectID == ObjectID.Rail || containedObject.objectID == ObjectID.ElectricalWire))
			{
				num3 += value * num;
			}
			mouseInventoryHandler.CraftItem(player, objectID, amount, num3);
			AudioManager.SfxUI(SfxID.uiPickup, 1.1f, reuse: true, 1f, 0.2f);
		}
		UpdateAllCraftingUI();
	}

	public virtual UIelement GetClosestUIElementExceptRecipes(Vector3 worldPosition)
	{
		return null;
	}
}
