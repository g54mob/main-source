using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeGameHUDNotification : GameHUDNotification
{
	[SerializeField]
	private TextMeshProUGUI _titleText;

	[SerializeField]
	private Image _recipeImage;

	public void Set(Recipe recipe)
	{
	}
}
