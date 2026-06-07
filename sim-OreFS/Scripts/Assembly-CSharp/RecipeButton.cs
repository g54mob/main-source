using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeButton : MonoBehaviour
{
	[Header("UI Elements")]
	[SerializeField]
	private Image iconImage;

	[SerializeField]
	private TextMeshProUGUI nameText;

	[SerializeField]
	private GameObject activeObject;

	private T_ItemSO recipe;

	private int recipeIndex;

	private RecipeListUI parentUI;

	private MachineUI machineUI;

	public void Initialize(T_ItemSO recipeSO, int index, RecipeListUI parent, MachineUI ui)
	{
		recipe = recipeSO;
		recipeIndex = index;
		parentUI = parent;
		machineUI = ui;
		if (iconImage == null)
		{
			iconImage = base.transform.Find("Icon")?.GetComponent<Image>();
		}
		if (nameText == null)
		{
			nameText = GetComponentInChildren<TextMeshProUGUI>();
		}
		UpdateUI();
	}

	private void UpdateUI()
	{
		if (recipe == null)
		{
			return;
		}
		if (iconImage != null && recipe.Icon != null)
		{
			iconImage.sprite = recipe.Icon;
			iconImage.enabled = true;
		}
		else if (iconImage != null)
		{
			iconImage.enabled = false;
		}
		if (nameText != null)
		{
			string translation = LocalizationManager.GetTranslation(recipe.Name);
			if (string.IsNullOrEmpty(translation))
			{
				translation = recipe.Name;
			}
			nameText.text = translation;
		}
	}

	public void SetSelected(bool selected)
	{
		activeObject.SetActive(selected);
	}

	public void OnClicked()
	{
		if (parentUI != null)
		{
			parentUI.OnRecipeSelected(recipeIndex);
		}
	}

	public void OnHover()
	{
		if (machineUI != null)
		{
			machineUI.OnRecipeHoverEnter(recipeIndex);
		}
	}

	public void OnDrop()
	{
		if (machineUI != null)
		{
			machineUI.OnRecipeHoverExit();
		}
	}
}
