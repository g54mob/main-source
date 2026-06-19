using System.Collections.Generic;
using Inventory;
using Unity.Entities;
using UnityEngine;

public class ProcessResourcesCraftingUI : CraftingUIBase
{
	public SpriteRenderer electricityIcon;

	public Color electricityColorOn;

	public Color electricityColorOff;

	public Vector3 arrowDefaultPos;

	public GameObject container;

	public float electricityColorOffPulseSpeed = 3.5f;

	public float electricityColorOffPulseIntensity = 0.9f;

	public float baselineColumnsBeforeExtraWidth = 3f;

	private float _defaultBackgroundWidth;

	private void Awake()
	{
		inventoryUI.Init();
		recipeUI.Init();
		root.SetActive(value: false);
		arrowDefaultPos = arrow.transform.localPosition;
		_defaultBackgroundWidth = background.size.x;
	}

	public override void ShowCraftingUI()
	{
		base.ShowCraftingUI();
		inventoryUI.ShowContainerUI();
		CraftingBuilding craftingBuilding = CraftingUIBase.GetCraftingBuilding();
		int num;
		if (craftingBuilding != null)
		{
			num = (craftingBuilding.hideRecipes ? 1 : 0);
			if (num != 0)
			{
				recipeUI.HideContainerUI();
				goto IL_0044;
			}
		}
		else
		{
			num = 0;
		}
		recipeUI.ShowContainerUI();
		goto IL_0044;
		IL_0044:
		if (num != 0)
		{
			container.transform.localPosition = new Vector3(0f, 0.625f, 0f);
		}
		else
		{
			container.transform.localPosition = Vector3.zero;
		}
		if (craftingBuilding.HasOutputSlot())
		{
			outputUI.ShowContainerUI();
		}
		else
		{
			outputUI.HideContainerUI();
		}
		if (num != 0)
		{
			background.size = new Vector2(_defaultBackgroundWidth, background.size.y);
		}
		else
		{
			float num2 = Mathf.Max(0f, (float)recipeUI.visibleColumns - baselineColumnsBeforeExtraWidth);
			background.size = new Vector2(_defaultBackgroundWidth + num2 * recipeUI.spread, background.size.y);
		}
		UpdateAllCraftingUI();
	}

	private void Update()
	{
		if (root.activeInHierarchy)
		{
			UpdateAllCraftingUI();
		}
	}

	public override void ActivateRecipeSlot(int visibleSlotIndex, bool mod1, bool mod2)
	{
		PlayerController player = Manager.main.player;
		if (base.activeCraftingHandler != null && !(player == null))
		{
			CraftingHandler.RecipeInfo recipeInfo = base.activeCraftingHandler.GetRecipeInfo(visibleSlotIndex);
			List<Entity> nearbyChests = base.activeCraftingHandler.GetNearbyChests();
			if (recipeInfo.requiredObjectsToCraft.Count == 1 && base.activeCraftingHandler.HasMaterialsInCraftingInventoryToCraftRecipe(recipeInfo, checkPlayerInventoryToo: true, nearbyChests, useRequiredObjectsSetInRecipeInfo: true))
			{
				player.QueueInputAction(new UIInputActionData
				{
					action = UIInputAction.Craft,
					craftActionData = Create.ActivateRecipeSlot(base.activeCraftingHandler.craftingEntity, player.entity, 1, mod1, visibleSlotIndex)
				});
			}
		}
	}

	public override void UpdateAllCraftingUI(bool autoFillMaterials = false)
	{
		for (int i = 0; i < inventoryUI.totalVisibleSlots; i++)
		{
			inventoryUI.OnSlotUpdated(i);
		}
		for (int j = 0; j < recipeUI.totalVisibleSlots; j++)
		{
			recipeUI.OnSlotUpdated(j);
		}
		for (int k = 0; k < outputUI.totalVisibleSlots; k++)
		{
			outputUI.OnSlotUpdated(k);
		}
		if (base.activeCraftingHandler != null && base.activeCraftingHandler.RequiresElectricity())
		{
			electricityIcon.gameObject.SetActive(value: true);
			arrow.transform.localPosition = arrowDefaultPos - new Vector3(0f, 0.3125f, 0f);
			if (base.activeCraftingHandler.HasElectricity())
			{
				electricityIcon.color = electricityColorOn;
				return;
			}
			float t = (Mathf.Sin(Time.time * electricityColorOffPulseSpeed) * 0.5f + 0.5f) * electricityColorOffPulseIntensity;
			Color color = Color.Lerp(electricityColorOff, electricityColorOn, t);
			electricityIcon.color = color;
		}
		else
		{
			electricityIcon.gameObject.SetActive(value: false);
			arrow.transform.localPosition = arrowDefaultPos;
		}
	}

	public override UIelement GetClosestUIElement(Vector3 worldPosition)
	{
		List<UIelement> list = new List<UIelement>();
		UIelement closestUIElement = inventoryUI.GetClosestUIElement(worldPosition);
		list.Add(closestUIElement);
		UIelement closestUIElement2 = recipeUI.GetClosestUIElement(worldPosition);
		if (closestUIElement2 != null)
		{
			list.Add(closestUIElement2);
		}
		list.Add(outputUI.GetClosestUIElement(worldPosition));
		UIelement result = null;
		float num = 2.1474836E+09f;
		foreach (UIelement item in list)
		{
			float sqrMagnitude = (worldPosition - item.transform.position).sqrMagnitude;
			if (sqrMagnitude < num)
			{
				num = sqrMagnitude;
				result = item;
			}
		}
		return result;
	}

	public override UIelement GetClosestUIElementExceptRecipes(Vector3 worldPosition)
	{
		List<UIelement> list = new List<UIelement>();
		UIelement closestUIElement = inventoryUI.GetClosestUIElement(worldPosition);
		list.Add(closestUIElement);
		recipeUI.GetClosestUIElement(worldPosition);
		list.Add(outputUI);
		UIelement result = null;
		float num = 2.1474836E+09f;
		foreach (UIelement item in list)
		{
			float sqrMagnitude = (worldPosition - item.transform.position).sqrMagnitude;
			if (sqrMagnitude < num)
			{
				num = sqrMagnitude;
				result = item;
			}
		}
		return result;
	}
}
