using System.Collections;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ComputerHoverPanel : MonoBehaviour
{
	[Header("UI Elements")]
	[SerializeField]
	private TextMeshProUGUI nameText;

	[SerializeField]
	private TextMeshProUGUI descriptionText;

	[SerializeField]
	private TextMeshProUGUI priceText;

	[SerializeField]
	private TextMeshProUGUI upgradeRequirementText;

	[SerializeField]
	private GameObject upgradeRequirementObj;

	[Header("Position Settings")]
	[SerializeField]
	private Vector2 offset = new Vector2(20f, -20f);

	[SerializeField]
	private float viewportPadding = 10f;

	[Header("References")]
	[SerializeField]
	private Canvas parentCanvas;

	private RectTransform _rectTransform;

	private RectTransform _canvasRectTransform;

	private bool _isVisible;

	private RectTransform _currentTargetRect;

	private void Awake()
	{
		_rectTransform = GetComponent<RectTransform>();
		if (parentCanvas != null)
		{
			_canvasRectTransform = parentCanvas.GetComponent<RectTransform>();
		}
	}

	private void Start()
	{
		base.gameObject.SetActive(value: false);
	}

	private void Update()
	{
		if (_isVisible)
		{
			if (InputDetection.Instance != null && InputDetection.Instance.KeyboardEnabled)
			{
				UpdatePositionForMouse();
			}
			else if (_currentTargetRect != null)
			{
				UpdatePositionForGamepad();
			}
		}
	}

	public void Show(T_BuildingItemSO itemSO, RectTransform targetRect = null)
	{
		if (!(itemSO == null))
		{
			string translation = LocalizationManager.GetTranslation(itemSO.Name);
			string translation2 = LocalizationManager.GetTranslation(itemSO.Description);
			bool flag = itemSO.requiredUpgrade != UpgradeType.None;
			string upgradeReqText = null;
			if (flag)
			{
				UpgradeGroupSO upgradeGroupSO = UpgradeManager.Instance?.GetGroupSO(itemSO.requiredUpgrade);
				string arg = ((upgradeGroupSO != null) ? upgradeGroupSO.UpgradeName : itemSO.requiredUpgrade.ToString());
				upgradeReqText = $"{arg} #{itemSO.requiredUpgradeLevel}";
			}
			ShowInternal(string.IsNullOrEmpty(translation) ? itemSO.Name : translation, string.IsNullOrEmpty(translation2) ? itemSO.Description : translation2, itemSO.Price, flag, upgradeReqText, targetRect);
		}
	}

	public void Show(T_ItemSO itemSO, RectTransform targetRect = null)
	{
		if (!(itemSO == null))
		{
			string translation = LocalizationManager.GetTranslation(itemSO.Name);
			string translation2 = LocalizationManager.GetTranslation(itemSO.Description);
			ShowInternal(string.IsNullOrEmpty(translation) ? itemSO.Name : translation, string.IsNullOrEmpty(translation2) ? itemSO.Description : translation2, itemSO.Price, showUpgradeReq: false, null, targetRect, approximatePrice: true);
		}
	}

	public void Hide()
	{
		_isVisible = false;
		_currentTargetRect = null;
		base.gameObject.SetActive(value: false);
	}

	private void ShowInternal(string name, string description, int price, bool showUpgradeReq, string upgradeReqText, RectTransform targetRect, bool approximatePrice = false)
	{
		if (nameText != null)
		{
			nameText.text = name;
		}
		if (descriptionText != null)
		{
			descriptionText.text = description;
		}
		if (priceText != null)
		{
			priceText.text = (approximatePrice ? $"≈{price}" : price.ToString());
		}
		if (upgradeRequirementObj != null)
		{
			upgradeRequirementObj.SetActive(showUpgradeReq);
		}
		if (upgradeRequirementText != null && showUpgradeReq)
		{
			upgradeRequirementText.text = upgradeReqText;
		}
		_currentTargetRect = targetRect;
		_isVisible = true;
		base.gameObject.SetActive(value: true);
		StartCoroutine(UpdatePositionNextFrame());
	}

	private IEnumerator UpdatePositionNextFrame()
	{
		yield return null;
		if (_isVisible)
		{
			if (InputDetection.Instance != null && InputDetection.Instance.KeyboardEnabled)
			{
				UpdatePositionForMouse();
			}
			else if (_currentTargetRect != null)
			{
				UpdatePositionForGamepad();
			}
		}
	}

	private void UpdatePositionForMouse()
	{
		if (!(parentCanvas == null) && !(_canvasRectTransform == null) && !(_rectTransform == null) && Mouse.current != null)
		{
			Vector2 screenPoint = Mouse.current.position.ReadValue();
			RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasRectTransform, screenPoint, (parentCanvas.renderMode == RenderMode.ScreenSpaceOverlay) ? null : parentCanvas.worldCamera, out var localPoint);
			Vector2 position = localPoint + offset;
			position = ClampToViewport(position);
			_rectTransform.anchoredPosition = position;
		}
	}

	private void UpdatePositionForGamepad()
	{
		if (!(_currentTargetRect == null) && !(parentCanvas == null) && !(_canvasRectTransform == null) && !(_rectTransform == null))
		{
			Vector3[] array = new Vector3[4];
			_currentTargetRect.GetWorldCorners(array);
			Vector3 vector = (array[0] + array[3]) / 2f;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(screenPoint: (parentCanvas.renderMode != RenderMode.ScreenSpaceOverlay) ? RectTransformUtility.WorldToScreenPoint(parentCanvas.worldCamera, vector) : ((Vector2)vector), rect: _canvasRectTransform, cam: (parentCanvas.renderMode == RenderMode.ScreenSpaceOverlay) ? null : parentCanvas.worldCamera, localPoint: out var localPoint);
			Vector2 position = localPoint + new Vector2(0f, offset.y);
			position = ClampToViewport(position);
			_rectTransform.anchoredPosition = position;
		}
	}

	private Vector2 ClampToViewport(Vector2 position)
	{
		if (_canvasRectTransform == null || _rectTransform == null)
		{
			return position;
		}
		Vector2 size = _canvasRectTransform.rect.size;
		Vector2 size2 = _rectTransform.rect.size;
		if (size2.x <= 0f || size2.y <= 0f)
		{
			return position;
		}
		Vector2 vector = new Vector2(size2.x * _rectTransform.pivot.x, size2.y * _rectTransform.pivot.y);
		Vector2 vector2 = new Vector2(size.x * _canvasRectTransform.pivot.x, size.y * _canvasRectTransform.pivot.y);
		float min = 0f - vector2.x + vector.x + viewportPadding;
		float max = vector2.x - (size2.x - vector.x) - viewportPadding;
		float min2 = 0f - vector2.y + vector.y + viewportPadding;
		float max2 = vector2.y - (size2.y - vector.y) - viewportPadding;
		position.x = Mathf.Clamp(position.x, min, max);
		position.y = Mathf.Clamp(position.y, min2, max2);
		return position;
	}
}
