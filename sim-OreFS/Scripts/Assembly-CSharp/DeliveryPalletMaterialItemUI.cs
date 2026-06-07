using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryPalletMaterialItemUI : MonoBehaviour
{
	[SerializeField]
	private Image itemIcon;

	[SerializeField]
	private TextMeshProUGUI itemNameText;

	[SerializeField]
	private TextMeshProUGUI itemCountText;

	private T_ItemSO itemSO;

	public void Initialize(T_ItemSO item, int count, int maxCount)
	{
		itemSO = item;
		if (itemIcon != null)
		{
			itemIcon.sprite = item.Icon;
			itemIcon.enabled = item.Icon != null;
		}
		if (itemNameText != null)
		{
			string translation = LocalizationManager.GetTranslation(item.Name);
			itemNameText.text = (string.IsNullOrEmpty(translation) ? item.Name : translation);
		}
		UpdateCount(count, maxCount);
	}

	public void UpdateCount(int count, int maxCount)
	{
		if (itemCountText != null)
		{
			itemCountText.text = $"{count}/{maxCount}";
		}
	}
}
