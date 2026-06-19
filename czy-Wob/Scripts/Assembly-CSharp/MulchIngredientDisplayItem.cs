using TMPro;
using UnityEngine;

public class MulchIngredientDisplayItem : MonoBehaviour
{
	public TextMeshProUGUI ingredientNameText;

	public TextMeshProUGUI ingredientAmountText;

	public void SetIngredientName(string nameText)
	{
		ingredientNameText.text = nameText;
	}

	public void SetAmountInfo(int amountOwned, int amountNeeded)
	{
		ingredientAmountText.text = amountOwned + "/" + amountNeeded;
	}
}
