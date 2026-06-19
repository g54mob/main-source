using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class SimpleCraftingUIContainer : CraftingUIBase
{
	public const int MAX_RECIPES_PER_UI = 6;

	public const float WINDOW_SPACING = 5f;

	public List<SimpleCraftingUI> simpleCraftingUIs;

	public int amountOfWindowsShowing { get; private set; }

	private void Awake()
	{
		foreach (SimpleCraftingUI simpleCraftingUI in simpleCraftingUIs)
		{
			simpleCraftingUI.Init();
		}
		root.SetActive(value: false);
	}

	public void UpdatePosition(bool isShowingCharacterWindow)
	{
		if (isShowingCharacterWindow)
		{
			root.transform.localPosition = new Vector3(-4.625f, 0f, 0f);
		}
		else
		{
			root.transform.localPosition = Vector3.zero;
		}
	}

	public override void ShowCraftingUI()
	{
		root.SetActive(value: true);
		DynamicBuffer<CanCraftObjectsBuffer> recipes = base.activeCraftingHandler.GetRecipes();
		CraftingBuilding.CraftingCategoryWindowInfo craftingCategoryWindowInfo = Manager.ui.GetCraftingCategoryWindowInfo();
		int num = 0;
		int num2 = recipes.Length;
		if (craftingCategoryWindowInfo != null)
		{
			num = craftingCategoryWindowInfo.startSlotIndex;
			num2 = craftingCategoryWindowInfo.endSlotIndex + 1;
		}
		amountOfWindowsShowing = 0;
		int num3 = num;
		int num4 = 0;
		while (num3 < num2)
		{
			if (AnyAvailableRecipeInRange(recipes, num3, num3 + 6))
			{
				if (amountOfWindowsShowing >= simpleCraftingUIs.Count)
				{
					Debug.LogError($"Not enough SimpleCraftingUIs in SimpleCraftingUIContainer to show all recipes. Needed at least {amountOfWindowsShowing + 1}, but only have {simpleCraftingUIs.Count}.", this);
				}
				else
				{
					simpleCraftingUIs[amountOfWindowsShowing].windowIndex = num4;
					simpleCraftingUIs[amountOfWindowsShowing].ShowCraftingUI();
					amountOfWindowsShowing++;
				}
			}
			num3 += 6;
			num4++;
		}
		for (int i = amountOfWindowsShowing; i < simpleCraftingUIs.Count; i++)
		{
			simpleCraftingUIs[i].HideCraftingUI();
		}
		float num5 = (float)(amountOfWindowsShowing - 1) * -2.5f;
		for (int j = 0; j < amountOfWindowsShowing; j++)
		{
			Vector3 localPosition = simpleCraftingUIs[j].transform.localPosition;
			simpleCraftingUIs[j].transform.localPosition = new Vector3(num5, localPosition.y, localPosition.z);
			num5 += 5f;
		}
	}

	private static bool AnyAvailableRecipeInRange(DynamicBuffer<CanCraftObjectsBuffer> canCraftBuffer, int startIndex, int endIndex)
	{
		endIndex = Mathf.Min(endIndex, canCraftBuffer.Length);
		for (int i = startIndex; i < endIndex; i++)
		{
			if (canCraftBuffer[i].objectID != ObjectID.None)
			{
				return true;
			}
		}
		return false;
	}

	public override void HideCraftingUI()
	{
		foreach (SimpleCraftingUI simpleCraftingUI in simpleCraftingUIs)
		{
			simpleCraftingUI.HideCraftingUI();
		}
		base.HideCraftingUI();
	}

	public override void HighlightRecipe(ObjectID recipe)
	{
		foreach (SimpleCraftingUI simpleCraftingUI in simpleCraftingUIs)
		{
			simpleCraftingUI.HighlightRecipe(recipe);
		}
	}

	public override void ClearRecipeHighlights()
	{
		foreach (SimpleCraftingUI simpleCraftingUI in simpleCraftingUIs)
		{
			simpleCraftingUI.ClearRecipeHighlights();
		}
	}

	public override void UpdateAllCraftingUI(bool autoFillMaterials = false)
	{
		foreach (SimpleCraftingUI simpleCraftingUI in simpleCraftingUIs)
		{
			if (simpleCraftingUI.isShowing)
			{
				simpleCraftingUI.UpdateAllCraftingUI(autoFillMaterials);
			}
		}
	}

	public override UIelement GetClosestUIElement(Vector3 worldPosition)
	{
		UIelement result = null;
		float num = float.MaxValue;
		foreach (SimpleCraftingUI simpleCraftingUI in simpleCraftingUIs)
		{
			if (!simpleCraftingUI.isShowing)
			{
				continue;
			}
			UIelement closestUIElement = simpleCraftingUI.GetClosestUIElement(worldPosition);
			if (closestUIElement != null)
			{
				float magnitude = (worldPosition - closestUIElement.transform.position).magnitude;
				if (magnitude < num)
				{
					num = magnitude;
					result = closestUIElement;
				}
			}
		}
		return result;
	}
}
