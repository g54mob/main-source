using System.Collections.Generic;
using Inventory;
using Pug.UnityExtensions;
using PugMod;
using Unity.Entities;
using UnityEngine;

public class CookBookRecipe : SlotUIBase
{
	public ColorReplacer colorReplacer;

	public CookBookUI cookBookUI;

	private TimerSimple holdDownCraftTimer;

	private float timeBetweenCraftsWhenHolding;

	private int craftsDoneWhileHolding;

	private CraftingHandler.RecipeInfo recipeInfo;

	private const float TIME_BETWEEN_CRAFTS_SPEED1 = 0.35f;

	private const float TIME_BETWEEN_CRAFTS_SPEED2 = 0.05f;

	public ContainedObjectsBuffer containedObject { get; private set; }

	protected CraftingHandler activeCraftingHandler => Manager.main.player?.activeCraftingHandler;

	public override float localScrollPosition => base.transform.localPosition.y + base.transform.parent.localPosition.y;

	private bool showHoverWindow
	{
		get
		{
			if (cookBookUI != null)
			{
				return cookBookUI.scrollWindow.IsShowingPosition(localScrollPosition, background.size.y / 2f);
			}
			return false;
		}
	}

	public override bool isVisibleOnScreen
	{
		get
		{
			if (showHoverWindow)
			{
				return base.isVisibleOnScreen;
			}
			return false;
		}
	}

	public override UIScrollWindow uiScrollWindow
	{
		get
		{
			if (!(cookBookUI != null))
			{
				return null;
			}
			return cookBookUI.scrollWindow;
		}
	}

	public void SetObjectData(ContainedObjectsBuffer _containedObject, CookBookUI _cookBookUI)
	{
		containedObject = _containedObject;
		cookBookUI = _cookBookUI;
		ObjectInfo objectInfo;
		if (_containedObject.objectID == ObjectID.None)
		{
			SetEmptyIcon();
		}
		else if (!PugDatabase.TryGetObjectInfo(_containedObject.objectID, out objectInfo) || objectInfo.icon == null)
		{
			SetMissingIcon();
		}
		else
		{
			icon.sprite = objectInfo.icon;
			icon.transform.localPosition = objectInfo.iconOffset;
			colorReplacer.UpdateColorReplacerFromObjectData(containedObject);
			background.color = Manager.ui.GetSlotBorderRarityColor(objectInfo.rarity, useDefaultColorForCommon: false, Color.white);
		}
		ObjectID primaryIngredientFromVariation = CookedFoodCD.GetPrimaryIngredientFromVariation(containedObject.variation);
		ObjectID secondaryIngredientFromVariation = CookedFoodCD.GetSecondaryIngredientFromVariation(containedObject.variation);
		recipeInfo = new CraftingHandler.RecipeInfo(new ObjectInfo
		{
			objectID = containedObject.objectID,
			requiredObjectsToCraft = new List<CraftingObject>
			{
				new CraftingObject
				{
					amount = 1,
					objectID = primaryIngredientFromVariation
				},
				new CraftingObject
				{
					amount = 1,
					objectID = secondaryIngredientFromVariation
				}
			}
		}, 1);
	}

	public override void UpdateSlot()
	{
		if (base.leftClickIsHeldDown && cookBookUI.isShowing)
		{
			if (!holdDownCraftTimer.isRunning || holdDownCraftTimer.isTimerElapsed)
			{
				if (craftsDoneWhileHolding > 0)
				{
					timeBetweenCraftsWhenHolding = 0.05f;
				}
				holdDownCraftTimer.Start(timeBetweenCraftsWhenHolding);
				if (craftsDoneWhileHolding > 0)
				{
					LeftClick();
				}
				craftsDoneWhileHolding++;
			}
		}
		else
		{
			holdDownCraftTimer.Stop();
			timeBetweenCraftsWhenHolding = 0.35f;
			craftsDoneWhileHolding = 0;
		}
	}

	public void UpdateAvailability(List<Entity> nearbyChests)
	{
		if (isVisibleOnScreen)
		{
			if (activeCraftingHandler != null && activeCraftingHandler.HasMaterialsInCraftingInventoryToCraftRecipe(recipeInfo, checkPlayerInventoryToo: true, nearbyChests, useRequiredObjectsSetInRecipeInfo: true))
			{
				icon.color = Color.white;
			}
			else
			{
				icon.color = new Color(0.8f, 0.8f, 0.8f, 0.5f);
			}
		}
	}

	public override void OnSelected()
	{
		cookBookUI.GetScrollWindow().MoveScrollToIncludePosition(localScrollPosition, background.size.y / 2f);
		OnSelectSlot();
	}

	public override void OnDeselected(bool playEffect = true)
	{
		OnDeselectSlot();
	}

	public override void OnLeftClicked(bool mod1, bool mod2)
	{
		PlayerController player = Manager.main.player;
		if (activeCraftingHandler != null && !(player == null))
		{
			List<Entity> nearbyChests = activeCraftingHandler.GetNearbyChests();
			if (activeCraftingHandler.HasMaterialsInCraftingInventoryToCraftRecipe(recipeInfo, checkPlayerInventoryToo: true, nearbyChests, useRequiredObjectsSetInRecipeInfo: true))
			{
				Entity entity = player.entity;
				player.QueueInputAction(new UIInputActionData
				{
					action = UIInputAction.Craft,
					craftActionData = Create.SetupCookBookRecipe(activeCraftingHandler.outputInventoryHandler.inventoryEntity, entity, activeCraftingHandler.craftingEntity, mod1, containedObject.objectID, containedObject.variation)
				});
			}
		}
	}

	public override List<PugDatabase.MaterialInfo> GetRequiredMaterials(bool isRepairing, bool isReinforcing)
	{
		if (!showHoverWindow || activeCraftingHandler == null)
		{
			return null;
		}
		List<Entity> nearbyChests = activeCraftingHandler.GetNearbyChests();
		return activeCraftingHandler.GetCraftingMaterialInfosForRecipe(recipeInfo, nearbyChests, isRepairing: false, isReinforcing: false, isCookedFood: true);
	}

	public override TextAndFormatFields GetHoverTitle()
	{
		if (!showHoverWindow)
		{
			return null;
		}
		TextAndFormatFields objectName = PlayerController.GetObjectName(containedObject, localize: false);
		objectName.color = Manager.text.GetRarityColor(PugDatabase.GetObjectInfo(containedObject.objectID).rarity);
		return objectName;
	}

	public override List<TextAndFormatFields> GetHoverDescription()
	{
		if (!showHoverWindow)
		{
			return null;
		}
		if (!API.Authoring.ObjectProperties.TryGetPropertyString(containedObject.objectID, "name", out var value))
		{
			value = containedObject.objectID.ToString();
		}
		return new List<TextAndFormatFields>
		{
			new TextAndFormatFields
			{
				text = "Items/" + value + "Desc"
			}
		};
	}

	public override List<TextAndFormatFields> GetHoverStats(bool previewReinforced)
	{
		if (!showHoverWindow)
		{
			return null;
		}
		return GetHoverStats(new ContainedObjectsBuffer
		{
			objectData = containedObject.objectData
		}, previewReinforced, previewUpgraded: false);
	}

	public override bool MaterialsAreIngredients()
	{
		return true;
	}

	public override HoverWindowAlignment GetHoverWindowAlignment()
	{
		return HoverWindowAlignment.BOTTOM_RIGHT_OF_SCREEN;
	}

	public override HoverTitleIconType GetHoverTitleIconType()
	{
		return HoverTitleIconType.Edible;
	}
}
