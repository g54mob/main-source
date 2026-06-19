using UnityEngine;
using UnityEngine.UI;

public class RecipeButtonUI : MonoBehaviour
{
	[SerializeField]
	public Image _slotImage;

	[SerializeField]
	private Sprite _selectedSlotSprite;

	[SerializeField]
	public Image _itemIcon;

	[SerializeField]
	public Button _button;

	private RecipeSelectionUI _recipeSelectionUI;

	private Recipe _recipe;

	[SerializeField]
	private RecipeTooltipTrigger _tooltipTrigger;

	public void Initiate(RecipeSelectionUI recipeSelectionUI, Recipe recipe, bool selected)
	{
	}

	private void Select()
	{
	}
}
