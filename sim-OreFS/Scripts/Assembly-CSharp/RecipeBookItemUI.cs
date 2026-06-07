using System;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RecipeBookItemUI : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
	[Header("UI Elements")]
	[SerializeField]
	private Image itemIcon;

	[SerializeField]
	private TextMeshProUGUI itemNameText;

	private T_ItemSO _itemSO;

	private bool _isSelected;

	private Action<T_ItemSO> _onClickCallback;

	private ComputerRecipeBookUI _recipeBookUI;

	public string ItemId => _itemSO?.GetItemID();

	public T_ItemSO ItemSO => _itemSO;

	public bool IsSelected => _isSelected;

	public void Initialize(T_ItemSO itemSO, bool isSelected, Action<T_ItemSO> onClick, ComputerRecipeBookUI recipeBookUI)
	{
		_itemSO = itemSO;
		_isSelected = isSelected;
		_onClickCallback = onClick;
		_recipeBookUI = recipeBookUI;
		UpdateUI();
	}

	public void SetSelected(bool selected)
	{
		_isSelected = selected;
	}

	public void UpdateUI()
	{
		if (!(_itemSO == null))
		{
			if (itemIcon != null)
			{
				itemIcon.sprite = _itemSO.Icon;
				itemIcon.gameObject.SetActive(_itemSO.Icon != null);
			}
			if (itemNameText != null)
			{
				string translation = LocalizationManager.GetTranslation(_itemSO.Name);
				itemNameText.text = ((!string.IsNullOrEmpty(translation)) ? translation : _itemSO.Name);
			}
		}
	}

	public void OnButtonClicked()
	{
		_onClickCallback?.Invoke(_itemSO);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (InputDetection.Instance != null && InputDetection.Instance.KeyboardEnabled)
		{
			ShowHoverPanel();
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		HideHoverPanel();
	}

	public void OnSelect(BaseEventData eventData)
	{
		if (InputDetection.Instance != null && InputDetection.Instance.GamepadEnabled)
		{
			ShowHoverPanel();
		}
	}

	public void OnDeselect(BaseEventData eventData)
	{
		HideHoverPanel();
	}

	private void ShowHoverPanel()
	{
		if (_recipeBookUI != null && _itemSO != null)
		{
			RectTransform component = GetComponent<RectTransform>();
			_recipeBookUI.ShowHoverPanel(_itemSO, component);
		}
	}

	private void HideHoverPanel()
	{
		if (_recipeBookUI != null)
		{
			_recipeBookUI.HideHoverPanel();
		}
	}
}
