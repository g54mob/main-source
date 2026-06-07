using System;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PickerUI : MonoBehaviour
{
	[Header("Panel")]
	public GameObject pickerPanel;

	[Header("Item Info")]
	public Image itemIcon;

	public TextMeshProUGUI itemNameText;

	[Header("Slider")]
	public Slider quantitySlider;

	public TextMeshProUGUI selectedQuantityText;

	[Header("Buttons")]
	public Button maxButton;

	public Button transferButton;

	public Button closeButton;

	[Header("State")]
	private T_ItemSO currentItem;

	private int maxQuantity;

	private Action<T_ItemSO, int> transferCallback;

	public Action<T_ItemSO, int> OnTransferRequested;

	private void Awake()
	{
		if (maxButton != null)
		{
			maxButton.onClick.AddListener(OnMaxButtonClicked);
		}
		if (transferButton != null)
		{
			transferButton.onClick.AddListener(OnTransferButtonClicked);
		}
		if (closeButton != null)
		{
			closeButton.onClick.AddListener(CloseUI);
		}
		if (quantitySlider != null)
		{
			quantitySlider.onValueChanged.AddListener(OnSliderValueChanged);
		}
		if (pickerPanel != null)
		{
			pickerPanel.SetActive(value: false);
		}
	}

	private void OnDestroy()
	{
		if (maxButton != null)
		{
			maxButton.onClick.RemoveListener(OnMaxButtonClicked);
		}
		if (transferButton != null)
		{
			transferButton.onClick.RemoveListener(OnTransferButtonClicked);
		}
		if (closeButton != null)
		{
			closeButton.onClick.RemoveListener(CloseUI);
		}
		if (quantitySlider != null)
		{
			quantitySlider.onValueChanged.RemoveListener(OnSliderValueChanged);
		}
	}

	public void OpenUI(T_ItemSO item, int availableCount, Action<T_ItemSO, int> onTransfer)
	{
		if (item == null || availableCount <= 0)
		{
			Debug.LogWarning("PickerUI: Geçersiz item veya miktar!");
			return;
		}
		if (onTransfer == null)
		{
			Debug.LogWarning("PickerUI: Transfer callback null!");
			return;
		}
		currentItem = item;
		int b = ((GameManager.Instance != null) ? GameManager.Instance.MaxItemsPerSack : availableCount);
		maxQuantity = Mathf.Min(availableCount, b);
		transferCallback = onTransfer;
		UpdateItemInfo();
		SetupSlider();
		if (pickerPanel != null)
		{
			pickerPanel.SetActive(value: true);
		}
	}

	public void CloseUI()
	{
		if (pickerPanel != null)
		{
			pickerPanel.SetActive(value: false);
		}
		currentItem = null;
		maxQuantity = 0;
		transferCallback = null;
	}

	public bool IsOpen()
	{
		if (pickerPanel != null)
		{
			return pickerPanel.activeSelf;
		}
		return false;
	}

	private void UpdateItemInfo()
	{
		if (!(currentItem == null))
		{
			if (itemIcon != null)
			{
				itemIcon.sprite = currentItem.Icon;
				itemIcon.enabled = currentItem.Icon != null;
			}
			if (itemNameText != null)
			{
				string translation = LocalizationManager.GetTranslation(currentItem.Name);
				itemNameText.text = ((!string.IsNullOrEmpty(translation)) ? translation : currentItem.Name);
			}
		}
	}

	private void SetupSlider()
	{
		if (!(quantitySlider == null))
		{
			quantitySlider.minValue = 1f;
			quantitySlider.maxValue = maxQuantity;
			quantitySlider.wholeNumbers = true;
			quantitySlider.value = maxQuantity;
			UpdateSelectedQuantityText((int)quantitySlider.value);
		}
	}

	private void UpdateSelectedQuantityText(int value)
	{
		if (selectedQuantityText != null)
		{
			selectedQuantityText.text = value.ToString();
		}
	}

	private void OnMaxButtonClicked()
	{
		if (quantitySlider != null)
		{
			quantitySlider.value = maxQuantity;
			UpdateSelectedQuantityText(maxQuantity);
		}
	}

	private void OnTransferButtonClicked()
	{
		if (currentItem == null)
		{
			Debug.LogWarning("PickerUI: Item null!");
			CloseUI();
			return;
		}
		if (transferCallback == null)
		{
			Debug.LogWarning("PickerUI: Transfer callback null!");
			CloseUI();
			return;
		}
		int num = ((quantitySlider != null) ? ((int)quantitySlider.value) : maxQuantity);
		if (num <= 0)
		{
			Debug.LogWarning("PickerUI: Geçersiz miktar!");
			return;
		}
		transferCallback(currentItem, num);
		OnTransferRequested?.Invoke(currentItem, num);
		CloseUI();
	}

	private void OnSliderValueChanged(float value)
	{
		UpdateSelectedQuantityText((int)value);
	}
}
