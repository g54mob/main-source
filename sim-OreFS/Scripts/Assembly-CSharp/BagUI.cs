using System;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BagUI : MonoBehaviour
{
	[Header("Panel")]
	public GameObject bagPanel;

	public GameObject bagButton;

	[Header("Info")]
	public Slider bagFillSlider;

	public TextMeshProUGUI bagFillAmountText;

	public Image bagFillImage;

	public TextMeshProUGUI bagCapacityText;

	[Header("Content")]
	public Transform bagScrollContent;

	public GameObject bagItemEntryPrefab;

	[Header("Filter")]
	[SerializeField]
	private TextMeshProUGUI filterButtonText;

	[Header("Input Actions")]
	[SerializeField]
	private InputActionReference leftAction;

	[SerializeField]
	private InputActionReference rightAction;

	private int currentFilterIndex = -1;

	private static readonly int filterTypeCount = Enum.GetValues(typeof(FilterType)).Length;

	public void OnFilterButtonClicked()
	{
		currentFilterIndex++;
		if (currentFilterIndex >= filterTypeCount)
		{
			currentFilterIndex = -1;
		}
		UpdateFilterButtonText();
		ApplyFilter();
	}

	private void UpdateFilterButtonText()
	{
		if (!(filterButtonText == null))
		{
			if (currentFilterIndex == -1)
			{
				string translation = LocalizationManager.GetTranslation("FilterType_All");
				filterButtonText.text = ((!string.IsNullOrEmpty(translation)) ? translation : "NL- All");
			}
			else
			{
				FilterType filterType = (FilterType)currentFilterIndex;
				string translation2 = LocalizationManager.GetTranslation("FilterType_" + filterType);
				filterButtonText.text = ((!string.IsNullOrEmpty(translation2)) ? translation2 : ("NL- " + filterType));
			}
		}
	}

	public void ApplyFilter()
	{
		if (bagScrollContent == null)
		{
			return;
		}
		foreach (Transform item2 in bagScrollContent)
		{
			BagItemUI component = item2.GetComponent<BagItemUI>();
			if (component == null)
			{
				continue;
			}
			if (currentFilterIndex == -1)
			{
				item2.gameObject.SetActive(value: true);
				continue;
			}
			FilterType item = (FilterType)currentFilterIndex;
			T_ItemSO itemSO = component.GetItemSO();
			if (itemSO != null && itemSO.FilterTypes != null)
			{
				item2.gameObject.SetActive(itemSO.FilterTypes.Contains(item));
			}
			else
			{
				item2.gameObject.SetActive(value: false);
			}
		}
	}

	public void ResetFilter()
	{
		currentFilterIndex = -1;
		UpdateFilterButtonText();
		ApplyFilter();
	}

	public void EnableInputActions()
	{
		if (leftAction != null && leftAction.action != null)
		{
			leftAction.action.Enable();
		}
		if (rightAction != null && rightAction.action != null)
		{
			rightAction.action.Enable();
		}
	}

	public void DisableInputActions()
	{
		if (leftAction != null && leftAction.action != null)
		{
			leftAction.action.Disable();
		}
		if (rightAction != null && rightAction.action != null)
		{
			rightAction.action.Disable();
		}
	}

	public void UpdateFillInfo(int currentCount, int maxCapacity)
	{
		if (maxCapacity < 0)
		{
			maxCapacity = 0;
		}
		if (currentCount < 0)
		{
			currentCount = 0;
		}
		float num = ((maxCapacity > 0) ? Mathf.Clamp01((float)currentCount / (float)maxCapacity) : 0f);
		float f = num * 100f;
		if (bagFillSlider != null)
		{
			bagFillSlider.minValue = 0f;
			bagFillSlider.maxValue = maxCapacity;
			bagFillSlider.value = currentCount;
		}
		if (bagFillAmountText != null)
		{
			bagFillAmountText.text = $"{Mathf.RoundToInt(f)}<size=50%>%</size>";
		}
		if (bagFillImage != null)
		{
			bagFillImage.fillAmount = num;
		}
		if (bagCapacityText != null)
		{
			bagCapacityText.text = $"{currentCount}/{maxCapacity}";
		}
	}
}
