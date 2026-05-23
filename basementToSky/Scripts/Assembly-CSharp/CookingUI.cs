using System;
using System.Collections.Generic;
using RainbowArt.CleanFlatUI;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class CookingUI : MonoBehaviour
{
	private LocalizedString foodDescCompleteString = new LocalizedString("MyTable", "cookingui-completed");

	private LocalizedString foodDescString = new LocalizedString("MyTable", "cookingui-foodselected");

	private LocalizedString satietyString = new LocalizedString("MyTable", "Satiety");

	private LocalizedString knowledgeString = new LocalizedString("MyTable", "knowledge");

	private LocalizedString valueString = new LocalizedString("MyTable", "value");

	[SerializeField]
	private GameObject cookingUnlocked;

	[SerializeField]
	private Refriger refriger;

	public List<GameObject> oneStarRecipes;

	public List<GameObject> twoStarRecipes;

	public List<GameObject> threeStarRecipes;

	[SerializeField]
	private GameObject ingredientUIPrefab;

	[SerializeField]
	private Transform ingredientsParent;

	private List<GameObject> ingredients;

	private Food selectedFood;

	private GameObject selectedFoodGO;

	[SerializeField]
	private ProgressBarSpecialPattern panCookingGage;

	[SerializeField]
	private ProgressBarSpecialPattern boilCookingGage;

	[SerializeField]
	private GameObject[] UIs;

	[SerializeField]
	private GameObject menuSelectionUI;

	[SerializeField]
	private GameObject panCookingUI;

	[SerializeField]
	private GameObject stackCookingUI;

	[SerializeField]
	private GameObject boilCookingUI;

	[SerializeField]
	private GameObject completeUI;

	[SerializeField]
	private GameObject doneBtn;

	[SerializeField]
	private Image selectedFoodImage;

	[SerializeField]
	private TextMeshProUGUI selectedFoodDescription;

	[SerializeField]
	private Image completedFoodImage;

	[SerializeField]
	private TextMeshProUGUI completedFoodSescription;

	[SerializeField]
	private GameObject stars;

	[SerializeField]
	private GameObject filledStar;

	[SerializeField]
	private GameObject emptyStar;

	[SerializeField]
	private GameObject stackingIngredientIcon;

	private List<GameObject> stackingIngredientIcons;

	private List<GameObject> starsIcons;

	public Image[] ingredientImages;

	public TextMeshProUGUI[] ingredientsCount;

	private bool canCraft;

	private int index;

	private int starIndex = 1;

	public static event Action OnCannotCook;

	private void Start()
	{
		base.gameObject.SetActive(value: false);
		panCookingUI.SetActive(value: false);
		stackingIngredientIcons = new List<GameObject>();
		starsIcons = new List<GameObject>();
		ingredients = new List<GameObject>();
		GameManager.S.OnCookingTable += GameManager_OnCookingTable;
		GameManager.S.OnPanCookingStart += Gamemanager_OnPanCookingStart;
		GameManager.S.OnStackCookingStart += GameManager_OnStackCookingStart;
		GameManager.S.OnBoilCookingStart += GM_OnBoilCookingStart;
		GameManager.S.OnCookingCompleted += GameManager_OnCookingCompleted;
		GameManager.S.OnFoodStacked += GameManager_OnFoodStacked;
	}

	private void OnDestroy()
	{
		GameManager.S.OnCookingTable -= GameManager_OnCookingTable;
		GameManager.S.OnPanCookingStart -= Gamemanager_OnPanCookingStart;
		GameManager.S.OnStackCookingStart -= GameManager_OnStackCookingStart;
		GameManager.S.OnBoilCookingStart -= GM_OnBoilCookingStart;
		GameManager.S.OnCookingCompleted -= GameManager_OnCookingCompleted;
		GameManager.S.OnFoodStacked -= GameManager_OnFoodStacked;
	}

	private void GM_OnBoilCookingStart(object sender, EventArgs e)
	{
		OpenUI(boilCookingUI);
	}

	private void GameManager_OnFoodStacked(object sender, EventArgs e)
	{
		GameObject obj = stackingIngredientIcons[0];
		stackingIngredientIcons.RemoveAt(0);
		UnityEngine.Object.Destroy(obj);
	}

	private void GameManager_OnCookingCompleted(object sender, GameManager.OnCookingCompletedArg e)
	{
		OpenUI(completeUI);
		doneBtn.SetActive(value: false);
		for (int i = 0; i < e.stars; i++)
		{
			GameObject item = UnityEngine.Object.Instantiate(filledStar, stars.transform);
			starsIcons.Add(item);
		}
		for (int j = 0; j < e.maxStars - e.stars; j++)
		{
			GameObject item2 = UnityEngine.Object.Instantiate(emptyStar, stars.transform);
			starsIcons.Add(item2);
		}
		float num = 0f;
		int num2 = 0;
		int num3 = 0;
		if (e.stars == 3)
		{
			num = selectedFood.hungerGain;
			num2 = selectedFood.knowledgeGain;
			num3 = Mathf.FloorToInt(selectedFood.value * 0.3f);
		}
		else if (e.stars == 2)
		{
			num = selectedFood.hungerGain * 0.5f;
			num2 = selectedFood.knowledgeGain / 2;
			num3 = Mathf.FloorToInt(selectedFood.value * 0.2f);
		}
		else if (e.stars == 1)
		{
			num = 0f;
			num2 = 0;
			num3 = 0;
		}
		else
		{
			num -= Mathf.Floor(selectedFood.hungerGain / 2f);
			num2 -= (int)Mathf.Floor((float)selectedFood.knowledgeGain / 2f);
			num3 -= (int)Mathf.Floor(selectedFood.value / 2f);
		}
		if (GameManager.S.cookingPerkList[2])
		{
			num3 += Mathf.FloorToInt(selectedFood.value * 0.2f);
		}
		Food.Ingredient[] array = selectedFood.ingredients;
		for (int k = 0; k < array.Length; k++)
		{
			Food.Ingredient ingredient = array[k];
			int num4 = ingredient.number;
			int num5 = refriger.foods.Count - 1;
			while (num5 >= 0 && num4 > 0)
			{
				Food component = refriger.foods[num5].GetComponent<Food>();
				Food component2 = ingredient.food.GetComponent<Food>();
				if (component.itemName == component2.itemName)
				{
					component.GetComponentInParent<RefrigerSlot>().Comsume();
					num4--;
				}
				num5--;
			}
		}
		completedFoodImage.sprite = selectedFood.mainImage;
		UpdateCompleteFoodUI(selectedFood, num, num2, num3);
		GameManager.S.AddBounsOnFood(num, num2, num3);
	}

	public void UpdateCompleteFoodUI(Food food, float hungergainBonus, int knowledgeGainBonus, int valueBonus)
	{
		foodDescCompleteString.Arguments = new object[10]
		{
			food.itemNameTemp.GetLocalizedString(),
			satietyString.GetLocalizedString(),
			selectedFood.hungerGain + hungergainBonus,
			FormatBonusfloat(hungergainBonus),
			knowledgeString.GetLocalizedString(),
			selectedFood.knowledgeGain + knowledgeGainBonus,
			FormatBonusInt(knowledgeGainBonus),
			valueString.GetLocalizedString(),
			selectedFood.value + (float)valueBonus,
			FormatBonusInt(valueBonus)
		};
		completedFoodSescription.text = foodDescCompleteString.GetLocalizedString();
	}

	private string FormatBonusInt(int bonus)
	{
		if (bonus > 0)
		{
			return $" <color=green>(+{bonus})</color>";
		}
		if (bonus < 0)
		{
			return $" <color=red>({bonus})</color>";
		}
		return "";
	}

	private string FormatBonusfloat(float bonus)
	{
		if (bonus > 0f)
		{
			return $" <color=green>(+{bonus})</color>";
		}
		if (bonus < 0f)
		{
			return $" <color=red>({bonus})</color>";
		}
		return "";
	}

	private void GameManager_OnStackCookingStart(object sender, EventArgs e)
	{
		OpenUI(stackCookingUI);
		Food.Recipe[] recipe = selectedFood.recipe;
		for (int i = 0; i < recipe.Length; i++)
		{
			Food.Recipe recipe2 = recipe[i];
			if (recipe2.cookingMethod == CookingController.CookingMethod.Stack)
			{
				GameObject[] food = recipe2.food;
				foreach (GameObject gameObject in food)
				{
					GameObject gameObject2 = UnityEngine.Object.Instantiate(stackingIngredientIcon, stackCookingUI.transform);
					gameObject2.transform.GetChild(2).GetComponent<Image>().sprite = gameObject.GetComponent<Food>().mainImage;
					stackingIngredientIcons.Add(gameObject2);
				}
			}
		}
	}

	private void Gamemanager_OnPanCookingStart(object sender, EventArgs e)
	{
		OpenUI(panCookingUI);
	}

	private void GameManager_OnCookingTable(object sender, EventArgs e)
	{
		OnUI();
	}

	private void Update()
	{
	}

	public void OffUI()
	{
		base.gameObject.SetActive(value: false);
		foreach (GameObject stackingIngredientIcon in stackingIngredientIcons)
		{
			UnityEngine.Object.Destroy(stackingIngredientIcon);
		}
		stackingIngredientIcons.Clear();
		foreach (GameObject starsIcon in starsIcons)
		{
			UnityEngine.Object.Destroy(starsIcon);
		}
		starsIcons.Clear();
		selectedFoodGO = null;
	}

	public void OnUI()
	{
		starIndex = 1;
		index = 0;
		FoodSelected(index);
		base.gameObject.SetActive(value: true);
		OpenUI(menuSelectionUI);
		doneBtn.SetActive(value: true);
		cookingUnlocked.SetActive(value: false);
	}

	public void CookingDone()
	{
		GameManager.S.CookingDone();
		OffUI();
	}

	public void ChangeStarIndex(int star)
	{
		starIndex = star;
		cookingUnlocked.SetActive(value: false);
		switch (star)
		{
		case 2:
			if (!GameManager.S.cookingPerkList[1])
			{
				cookingUnlocked.SetActive(value: true);
			}
			break;
		case 3:
			if (!GameManager.S.cookingPerkList[3])
			{
				cookingUnlocked.SetActive(value: true);
			}
			break;
		}
		index = 0;
		FoodSelected(index);
	}

	public void FoodSelected(int index)
	{
		GameObject gameObject;
		int maxStars;
		if (starIndex == 1)
		{
			gameObject = oneStarRecipes[index];
			maxStars = 1;
		}
		else if (starIndex == 2)
		{
			gameObject = twoStarRecipes[index];
			maxStars = 2;
		}
		else
		{
			gameObject = threeStarRecipes[index];
			maxStars = 3;
		}
		Food food = (selectedFood = gameObject.GetComponent<Food>());
		selectedFoodImage.sprite = food.mainImage;
		UpdateSelectedFoodUI(food);
		int num = 0;
		if (ingredients.Count > 0)
		{
			foreach (GameObject ingredient2 in ingredients)
			{
				UnityEngine.Object.Destroy(ingredient2.gameObject);
			}
			ingredients.Clear();
		}
		canCraft = true;
		Food.Ingredient[] array = food.ingredients;
		for (int i = 0; i < array.Length; i++)
		{
			Food.Ingredient ingredient = array[i];
			Food component = ingredient.food.GetComponent<Food>();
			GameObject gameObject2 = UnityEngine.Object.Instantiate(ingredientUIPrefab, ingredientsParent);
			ingredients.Add(gameObject2);
			gameObject2.GetComponentInChildren<Tooltip>(includeInactive: true).description.text = component.itemNameTemp.GetLocalizedString();
			gameObject2.GetComponent<Image>().sprite = component.mainImage;
			TextMeshProUGUI componentInChildren = gameObject2.GetComponentInChildren<TextMeshProUGUI>();
			int num2 = CheckRefriger(component);
			componentInChildren.text = $"{num2}/{ingredient.number}";
			if (num2 < ingredient.number)
			{
				canCraft = false;
			}
			num++;
		}
		GameManager.S.MenuSelected(gameObject, maxStars);
	}

	public void UpdateSelectedFoodUI(Food food)
	{
		foodDescString.Arguments = new object[7]
		{
			food.itemNameTemp.GetLocalizedString(),
			satietyString.GetLocalizedString(),
			food.hungerGain,
			knowledgeString.GetLocalizedString(),
			food.knowledgeGain,
			valueString.GetLocalizedString(),
			food.value
		};
		selectedFoodDescription.text = foodDescString.GetLocalizedString();
	}

	public int CheckRefriger(Food food)
	{
		int num = 0;
		foreach (GameObject food2 in refriger.foods)
		{
			if (food.itemName == food2.GetComponent<Food>().itemName)
			{
				num++;
			}
		}
		return num;
	}

	public void NextFood()
	{
		if (starIndex == 1)
		{
			if (oneStarRecipes.Count - 1 == index)
			{
				index = 0;
			}
			else
			{
				index++;
			}
		}
		else if (starIndex == 2)
		{
			if (twoStarRecipes.Count - 1 == index)
			{
				index = 0;
			}
			else
			{
				index++;
			}
		}
		else if (threeStarRecipes.Count - 1 == index)
		{
			index = 0;
		}
		else
		{
			index++;
		}
		FoodSelected(index);
	}

	public void PrevFood()
	{
		if (starIndex == 1)
		{
			if (index == 0)
			{
				index = oneStarRecipes.Count - 1;
			}
			else
			{
				index--;
			}
		}
		else if (starIndex == 2)
		{
			if (index == 0)
			{
				index = twoStarRecipes.Count - 1;
			}
			else
			{
				index--;
			}
		}
		else if (index == 0)
		{
			index = threeStarRecipes.Count - 1;
		}
		else
		{
			index--;
		}
		FoodSelected(index);
	}

	public void StartCooking()
	{
		if (!canCraft)
		{
			CookingUI.OnCannotCook?.Invoke();
			AudioManager.S.PlaySFX(AudioManager.S.notEnoughMoney);
		}
		else
		{
			GameManager.S.CookingStart(selectedFood, panCookingGage, boilCookingGage);
		}
	}

	public void ToTheNextStep()
	{
		GameManager.S.ToTheNextStep();
	}

	private void OpenUI(GameObject currentUI)
	{
		GameObject[] uIs = UIs;
		foreach (GameObject gameObject in uIs)
		{
			if (gameObject != currentUI)
			{
				gameObject.SetActive(value: false);
			}
			else
			{
				gameObject.SetActive(value: true);
			}
		}
		doneBtn.SetActive(value: false);
	}
}
