using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeBookIngredientUI : MonoBehaviour
{
	[Header("UI Elements")]
	[SerializeField]
	private Image itemIcon;

	[SerializeField]
	private TextMeshProUGUI itemNameText;

	[SerializeField]
	private TextMeshProUGUI itemCountText;

	public void Initialize(T_ItemSO item, int count)
	{
		if (!(item == null))
		{
			if (itemIcon != null)
			{
				itemIcon.sprite = item.Icon;
				itemIcon.gameObject.SetActive(item.Icon != null);
			}
			if (itemNameText != null)
			{
				string translation = LocalizationManager.GetTranslation(item.Name);
				itemNameText.text = ((!string.IsNullOrEmpty(translation)) ? translation : item.Name);
			}
			if (itemCountText != null)
			{
				itemCountText.text = $"x{count}";
			}
		}
	}
}
