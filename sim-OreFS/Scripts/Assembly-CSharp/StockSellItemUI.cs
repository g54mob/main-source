using System;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StockSellItemUI : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
	[Header("UI Elements")]
	[Tooltip("Item ikonu")]
	[SerializeField]
	private Image itemIcon;

	[Tooltip("Stok miktarı")]
	[SerializeField]
	private TextMeshProUGUI stockCountText;

	[Tooltip("Item ismi")]
	[SerializeField]
	private TextMeshProUGUI itemNameText;

	private T_ItemSO _itemSO;

	private int _stockCount;

	private bool _isSelected;

	private Action<T_ItemSO> _onClickCallback;

	private ComputerStockSellUI _stockSellUI;

	public string ItemId => _itemSO?.GetItemID();

	public T_ItemSO ItemSO => _itemSO;

	public int StockCount => _stockCount;

	public bool IsSelected => _isSelected;

	public void Initialize(T_ItemSO itemSO, int stockCount, bool isSelected, Action<T_ItemSO> onClick, ComputerStockSellUI stockSellUI = null)
	{
		_itemSO = itemSO;
		_stockCount = stockCount;
		_isSelected = isSelected;
		_onClickCallback = onClick;
		_stockSellUI = stockSellUI;
		UpdateUI();
	}

	public void UpdateStockCount(int newCount)
	{
		_stockCount = newCount;
		if (stockCountText != null)
		{
			stockCountText.text = $"x{_stockCount}";
		}
		ApplyStockAlpha();
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
			if (stockCountText != null)
			{
				stockCountText.text = $"x{_stockCount}";
			}
			if (itemNameText != null)
			{
				string translation = LocalizationManager.GetTranslation(_itemSO.Name);
				itemNameText.text = ((!string.IsNullOrEmpty(translation)) ? translation : _itemSO.Name);
			}
			ApplyStockAlpha();
		}
	}

	private void ApplyStockAlpha()
	{
		float a = ((_stockCount <= 0) ? 0.5f : 1f);
		if (itemIcon != null)
		{
			Color color = itemIcon.color;
			color.a = a;
			itemIcon.color = color;
		}
		if (stockCountText != null)
		{
			Color color2 = stockCountText.color;
			color2.a = a;
			stockCountText.color = color2;
			stockCountText.fontSizeMax = ((_stockCount <= 0) ? 20f : 25f);
		}
		if (itemNameText != null)
		{
			Color color3 = itemNameText.color;
			color3.a = a;
			itemNameText.color = color3;
		}
	}

	public void OnButtonClicked()
	{
		if (GameManager.Instance != null && GameManager.Instance.dayNightManager.IsNighttime)
		{
			Debug.LogWarning("[ComputerContractManager] Gece Negotiation başlatılamaz!");
			if (NotificationManager.Instance != null)
			{
				NotificationManager.Instance.ShowNotification(LocalizationManager.GetTranslation("Too Late For This Action"), isComputer: true);
			}
		}
		else if (!(TutorialManager.Instance != null) || !TutorialManager.Instance.IsTutorialRunning || _stockCount >= 5)
		{
			_onClickCallback?.Invoke(_itemSO);
		}
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
		if (_stockSellUI != null && _itemSO != null)
		{
			RectTransform component = GetComponent<RectTransform>();
			_stockSellUI.ShowHoverPanel(_itemSO, component);
		}
	}

	private void HideHoverPanel()
	{
		if (_stockSellUI != null)
		{
			_stockSellUI.HideHoverPanel();
		}
	}
}
