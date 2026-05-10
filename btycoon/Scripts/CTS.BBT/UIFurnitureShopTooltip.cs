using CTS;
using CTS.BBT;
using CTS.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIFurnitureShopTooltip : MonoBehaviour
{
	[SerializeField]
	private Image _furnitureImage;

	[SerializeField]
	private TextMeshProUGUI _furnitureName;

	[SerializeField]
	private TextMeshProUGUI _furniturePrice;

	[SerializeField]
	private TextMeshProUGUI _furnitureDescription;

	[SerializeField]
	private CanvasGroupController _canvasGroupController;

	[SerializeField]
	private float _timeBeforeHide;

	private float _currentTime;

	private bool _isHovered;

	private bool _isShowable = true;

	private bool _isShown;

	private void OnEnable()
	{
		FurnitureShop.FurnitureShopStatusChanged += OnFurnitureShopStatusChanged;
		UIFurnitureButton.FurnitureButtonHovered += AssignFurniture;
		UIFurnitureButton.FurnitureButtonExited += OnFurnitureButtonExited;
		FurnitureController.FurniturePickedUp += OnFurniturePickedUp;
		FurnitureController.PlacingFurniture += OnPlacingFurniture;
	}

	private void OnFurnitureShopStatusChanged(bool p_shopIsOpen)
	{
		_isShowable = p_shopIsOpen;
		if (_isShown && !p_shopIsOpen)
		{
			Hide();
		}
	}

	private void OnFurniturePickedUp(FurnitureController obj)
	{
		_isShowable = false;
		Hide();
	}

	private void OnPlacingFurniture(FurnitureController obj)
	{
		_isShowable = true;
	}

	private void OnDisable()
	{
		FurnitureShop.FurnitureShopStatusChanged -= OnFurnitureShopStatusChanged;
		UIFurnitureButton.FurnitureButtonHovered -= AssignFurniture;
		UIFurnitureButton.FurnitureButtonExited -= OnFurnitureButtonExited;
		FurnitureController.FurniturePickedUp -= OnFurniturePickedUp;
		FurnitureController.PlacingFurniture -= OnPlacingFurniture;
	}

	private void AssignFurniture(FurnitureSO p_furnitureSO)
	{
		if (_isShowable)
		{
			if (p_furnitureSO.Icon != null)
			{
				_furnitureImage.sprite = p_furnitureSO.Icon;
				_furnitureImage.enabled = true;
			}
			else
			{
				_furnitureImage.enabled = false;
			}
			_furnitureName.text = p_furnitureSO.Name;
			_furniturePrice.text = $"{p_furnitureSO.PurchasePrice}$";
			_furnitureDescription.text = p_furnitureSO.Description;
			_currentTime = _timeBeforeHide;
			_isHovered = true;
			_isShown = true;
			if (_canvasGroupController.IsHidden)
			{
				_canvasGroupController.ShowCanvasGroup(show: true, 0.7f);
			}
		}
	}

	private void OnFurnitureButtonExited(FurnitureSO obj)
	{
		_isHovered = false;
	}

	private void OnFurnitureButtonClicked(Furniture obj)
	{
		Hide();
	}

	private void Hide()
	{
		_isHovered = false;
		_isShown = false;
		_canvasGroupController.ShowCanvasGroup(show: false, 0.7f);
	}

	private void Update()
	{
		if (!_isHovered && _isShown)
		{
			_currentTime = Mathf.MoveTowards(_currentTime, 0f, Time.deltaTime);
			if (_currentTime == 0f)
			{
				Hide();
			}
		}
	}
}
