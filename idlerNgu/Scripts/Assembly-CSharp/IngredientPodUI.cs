using UnityEngine;
using UnityEngine.UI;

public class IngredientPodUI : MonoBehaviour
{
	public Character character;

	public GameObject pod;

	public int ingredientDataIndex;

	public Image sprite;

	public Text nameText;

	public Text ingredientUnitText;

	public void updatePod()
	{
		if (ingredientDataIndex < 0 || ingredientDataIndex >= character.cooking.ingredients.Count)
		{
			pod.SetActive(value: false);
			return;
		}
		if (!character.cooking.ingredients[ingredientDataIndex].unlocked)
		{
			pod.SetActive(value: false);
			return;
		}
		pod.SetActive(value: true);
		int propertyIndex = character.cooking.ingredients[ingredientDataIndex].propertyIndex;
		sprite.sprite = character.cookingController.ingredientProperties[propertyIndex].sprite;
		ingredientUnitText.text = character.cookingController.getIngredientAmount(ingredientDataIndex) + " " + character.cookingController.getIngredientUnitName(ingredientDataIndex);
		nameText.text = character.cookingController.ingredientProperties[propertyIndex].ingredientName;
	}

	public void onHover()
	{
		if (ingredientDataIndex >= 0 && ingredientDataIndex < character.cooking.ingredients.Count)
		{
			character.cookingController.showIngredientInfo(ingredientDataIndex);
		}
	}

	public void onExit()
	{
		character.tooltip.hideTooltip();
	}

	public void raiseIngredient()
	{
		character.cookingController.tryIngredientUp(ingredientDataIndex);
	}

	public void lowerIngredient()
	{
		character.cookingController.tryIngredientDown(ingredientDataIndex);
	}
}
