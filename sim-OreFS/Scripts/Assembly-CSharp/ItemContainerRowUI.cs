using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemContainerRowUI : MonoBehaviour
{
	[SerializeField]
	private Image itemIcon;

	[SerializeField]
	private TextMeshProUGUI itemNameText;

	[SerializeField]
	private TextMeshProUGUI itemCountText;

	private string itemId;

	public string ItemId => itemId;

	public void Initialize(T_ItemSO itemSO, int count)
	{
		if (!(itemSO == null))
		{
			itemId = itemSO.GetItemID();
			if (itemIcon != null)
			{
				itemIcon.sprite = itemSO.Icon;
				itemIcon.enabled = itemSO.Icon != null;
			}
			if (itemNameText != null)
			{
				string translation = LocalizationManager.GetTranslation(itemSO.Name);
				itemNameText.text = (string.IsNullOrEmpty(translation) ? itemSO.Name : translation);
			}
			UpdateCount(count);
		}
	}

	public void UpdateCount(int count)
	{
		if (itemCountText != null)
		{
			itemCountText.text = count.ToString();
		}
	}
}
