#define PUG_ACHIEVEMENTS
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class CookBookUI : ItemSlotsUIContainer, IScrollable
{
	public CookBookIngredientTypeFilterUI cookBookIngredientTypeFilterUI;

	public CookBookIngredientFilterUI cookBookIngredientFilterUI;

	private List<DiscoveredObjectData> allDiscoveredRecipes = new List<DiscoveredObjectData>();

	private List<UIelement> activeRecipeSlots = new List<UIelement>();

	public GameObject root;

	public GameObject infoContainer;

	public GameObject cookBookContainer;

	public PugText recipesText;

	private int prevDiscoveredCookedFoods;

	private const string recipes = "Recipes";

	protected const string rare = "Rare";

	protected const string epic = "Epic";

	protected CraftingHandler activeCraftingHandler => Manager.main.player?.activeCraftingHandler;

	public override bool isShowing => root.activeInHierarchy;

	public override int MAX_ROWS => 50;

	public override int MAX_COLUMNS => 5;

	protected override void LateUpdate()
	{
		if (isShowing)
		{
			int count = Manager.saves.GetDiscoveredCookedFoods().Count;
			if (prevDiscoveredCookedFoods != count)
			{
				UpdateDiscoveredRecipes();
				UpdateFilter();
			}
			recipesText.formatFields = new string[1] { allDiscoveredRecipes.Count.ToString() };
			recipesText.Render("Recipes");
			if (activeCraftingHandler != null)
			{
				List<Entity> nearbyChests = activeCraftingHandler.GetNearbyChests();
				foreach (UIelement activeRecipeSlot in activeRecipeSlots)
				{
					((CookBookRecipe)activeRecipeSlot).UpdateAvailability(nearbyChests);
					((CookBookRecipe)activeRecipeSlot).UpdateSlot();
				}
			}
		}
		base.LateUpdate();
	}

	public void UpdateFilter()
	{
		activeRecipeSlots.Clear();
		IngredientType currentIngredientTypeFilter = cookBookIngredientTypeFilterUI.currentIngredientTypeFilter;
		ObjectID currentIngredientFilter = cookBookIngredientFilterUI.currentIngredientFilter;
		int num = 0;
		for (int i = 0; i < allDiscoveredRecipes.Count; i++)
		{
			bool flag = true;
			if (currentIngredientFilter != ObjectID.None)
			{
				ObjectID primaryIngredientFromVariation = CookedFoodCD.GetPrimaryIngredientFromVariation(allDiscoveredRecipes[i].variation);
				ObjectID secondaryIngredientFromVariation = CookedFoodCD.GetSecondaryIngredientFromVariation(allDiscoveredRecipes[i].variation);
				flag = currentIngredientFilter == primaryIngredientFromVariation || currentIngredientFilter == secondaryIngredientFromVariation;
			}
			else if (currentIngredientTypeFilter != IngredientType.None)
			{
				ObjectID primaryIngredientFromVariation2 = CookedFoodCD.GetPrimaryIngredientFromVariation(allDiscoveredRecipes[i].variation);
				ObjectID secondaryIngredientFromVariation2 = CookedFoodCD.GetSecondaryIngredientFromVariation(allDiscoveredRecipes[i].variation);
				flag = (PugDatabase.HasComponent<CookingIngredientCD>(primaryIngredientFromVariation2) && PugDatabase.GetComponent<CookingIngredientCD>(primaryIngredientFromVariation2).ingredientType == currentIngredientTypeFilter) || (PugDatabase.HasComponent<CookingIngredientCD>(secondaryIngredientFromVariation2) && PugDatabase.GetComponent<CookingIngredientCD>(secondaryIngredientFromVariation2).ingredientType == currentIngredientTypeFilter);
			}
			if (flag)
			{
				CookBookRecipe cookBookRecipe = itemSlots[num] as CookBookRecipe;
				if (cookBookRecipe.containedObject.objectID != allDiscoveredRecipes[i].objectID || cookBookRecipe.containedObject.variation != allDiscoveredRecipes[i].variation)
				{
					cookBookRecipe.SetObjectData(new ContainedObjectsBuffer
					{
						objectData = new ObjectDataCD
						{
							objectID = allDiscoveredRecipes[i].objectID,
							variation = allDiscoveredRecipes[i].variation
						}
					}, this);
				}
				cookBookRecipe.gameObject.SetActive(value: true);
				activeRecipeSlots.Add(cookBookRecipe);
				num++;
				if (num >= itemSlots.Count)
				{
					break;
				}
			}
		}
		for (int j = num; j < itemSlots.Count; j++)
		{
			itemSlots[j].gameObject.SetActive(value: false);
		}
		UpdateSlotsPositioning();
	}

	private void UpdateDiscoveredRecipes()
	{
		allDiscoveredRecipes.Clear();
		List<DiscoveredObjectData> discoveredCookedFoods = Manager.saves.GetDiscoveredCookedFoods();
		HashSet<string> hashSet = new HashSet<string>();
		for (int i = 0; i < discoveredCookedFoods.Count; i++)
		{
			string text = discoveredCookedFoods[i].objectID.ToString();
			if (text.EndsWith("Epic"))
			{
				continue;
			}
			ObjectID primaryIngredientFromVariation = CookedFoodCD.GetPrimaryIngredientFromVariation(discoveredCookedFoods[i].variation);
			ObjectID secondaryIngredientFromVariation = CookedFoodCD.GetSecondaryIngredientFromVariation(discoveredCookedFoods[i].variation);
			if (CookedFoodCD.IsIngredientObsolete(primaryIngredientFromVariation) || CookedFoodCD.IsIngredientObsolete(secondaryIngredientFromVariation))
			{
				continue;
			}
			string text2 = primaryIngredientFromVariation.ToString();
			string text3 = secondaryIngredientFromVariation.ToString();
			ObjectInfo objectInfo = PugDatabase.GetObjectInfo(primaryIngredientFromVariation);
			ObjectInfo objectInfo2 = PugDatabase.GetObjectInfo(secondaryIngredientFromVariation);
			if (objectInfo != null && objectInfo2 != null && ((!text2.EndsWith("Rare") && !text3.EndsWith("Rare")) || text.EndsWith("Rare")) && (text2.EndsWith("Rare") || text3.EndsWith("Rare") || objectInfo.rarity == Rarity.Legendary || objectInfo2.rarity == Rarity.Legendary || !text.EndsWith("Rare")))
			{
				string item = text + text2 + text3;
				if (!hashSet.Contains(item))
				{
					hashSet.Add(item);
					allDiscoveredRecipes.Add(discoveredCookedFoods[i]);
				}
			}
		}
		prevDiscoveredCookedFoods = discoveredCookedFoods.Count;
		allDiscoveredRecipes.Sort((DiscoveredObjectData a, DiscoveredObjectData b) => string.Compare(a.objectID.ToString(), b.objectID.ToString()));
		if (allDiscoveredRecipes.Count == 0)
		{
			infoContainer.SetActive(value: true);
			cookBookContainer.SetActive(value: false);
			return;
		}
		infoContainer.SetActive(value: false);
		cookBookContainer.SetActive(value: true);
		if (allDiscoveredRecipes.Count >= 100)
		{
			Manager.achievements.TriggerAchievement(AchievementID.Discover100CookBookRecipes);
		}
	}

	public override void ShowContainerUI()
	{
		root.SetActive(value: true);
		UpdateDiscoveredRecipes();
		UpdateFilter();
		base.ShowContainerUI();
		cookBookIngredientTypeFilterUI.ShowContainerUI();
		cookBookIngredientFilterUI.ShowContainerUI();
	}

	public override void HideContainerUI()
	{
		root.SetActive(value: false);
		base.HideContainerUI();
	}

	private void UpdateSlotsPositioning()
	{
		int num = Mathf.Min(activeRecipeSlots.Count - startSlotIndex, base.MAX_SLOTS);
		float sideStartPosition = GetSideStartPosition(MAX_COLUMNS);
		float num2 = 0f;
		for (int i = 0; i < num; i++)
		{
			int num3 = i % MAX_COLUMNS;
			int num4 = i / MAX_COLUMNS;
			CookBookRecipe obj = activeRecipeSlots[i] as CookBookRecipe;
			obj.visibleSlotIndex = i;
			obj.transform.localPosition = new Vector3(sideStartPosition + (float)num3 * spread, num2 - (float)num4 * spread, 0f);
		}
	}

	private float GetSideStartPosition(int size)
	{
		return (0f - (float)(size - 1) / 2f) * spread;
	}

	public void UpdateContainingElements(float scroll)
	{
	}

	public bool IsBottomElementSelected()
	{
		if (Manager.ui.currentSelectedUIElement == null)
		{
			return false;
		}
		int num = math.max(0, activeRecipeSlots.Count - 1) / MAX_COLUMNS * MAX_COLUMNS;
		for (int i = num; i < activeRecipeSlots.Count; i++)
		{
			if (i >= num && activeRecipeSlots[i] == Manager.ui.currentSelectedUIElement)
			{
				return true;
			}
		}
		return false;
	}

	public bool IsTopElementSelected()
	{
		if (Manager.ui.currentSelectedUIElement == null)
		{
			return false;
		}
		int num = math.min(MAX_COLUMNS, activeRecipeSlots.Count);
		for (int i = 0; i < num; i++)
		{
			if (activeRecipeSlots[i] == Manager.ui.currentSelectedUIElement)
			{
				return true;
			}
		}
		return false;
	}

	public float GetCurrentWindowHeight()
	{
		if (activeRecipeSlots.Count > 0)
		{
			return activeRecipeSlots[0].transform.localPosition.y - activeRecipeSlots[activeRecipeSlots.Count - 1].transform.localPosition.y + 1.375f;
		}
		return 0f;
	}

	public UIScrollWindow GetScrollWindow()
	{
		return scrollWindow;
	}
}
