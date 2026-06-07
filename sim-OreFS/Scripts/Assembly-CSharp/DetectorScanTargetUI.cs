using System;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DetectorScanTargetUI : MonoBehaviour
{
	[Header("References")]
	[SerializeField]
	private Image iconImage;

	[SerializeField]
	private TextMeshProUGUI nameText;

	[SerializeField]
	private Button selectButton;

	private T_ItemSO itemSO;

	private Action<T_ItemSO> onSelectCallback;

	public void Initialize(T_ItemSO item, Action<T_ItemSO> onSelect)
	{
		itemSO = item;
		onSelectCallback = onSelect;
		if (iconImage != null && item != null)
		{
			iconImage.sprite = item.Icon;
			iconImage.enabled = item.Icon != null;
		}
		if (nameText != null && item != null)
		{
			string translation = LocalizationManager.GetTranslation(item.Name);
			nameText.text = ((!string.IsNullOrEmpty(translation)) ? translation : item.Name);
		}
		if (selectButton != null)
		{
			selectButton.onClick.RemoveAllListeners();
			selectButton.onClick.AddListener(OnButtonClicked);
		}
	}

	private void OnButtonClicked()
	{
		onSelectCallback?.Invoke(itemSO);
	}

	public T_ItemSO GetItemSO()
	{
		return itemSO;
	}
}
