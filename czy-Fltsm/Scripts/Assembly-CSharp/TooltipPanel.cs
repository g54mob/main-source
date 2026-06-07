using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using PajamaLlama.Debugs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TooltipPanel : MonoBehaviour
{
	[SerializeField]
	[Tooltip("Gameobject for the tooltip.")]
	private GameObject _tooltipObject;

	public DrifterAttributeTooltipPanel AttributeEffectTooltip;

	[Space]
	[SerializeField]
	[Tooltip("Offset for the label compared to the mouse position.")]
	private Vector2 _offset = new Vector2(15f, 5f);

	[SerializeField]
	private TextMeshProUGUI _text;

	[SerializeField]
	[Tooltip("Prefab used to display items in the tooltip.")]
	private TooltipItemSlot _itemSlotPrefab;

	[SerializeField]
	[Tooltip("The parent transform for the displayed items.")]
	private RectTransform _itemSlotParent;

	[SerializeField]
	private TooltipBuilderProperties _tooltipBuilderProperties;

	[SerializeField]
	private TooltipButtonTooltip _errorTooltip;

	private Rect _bounds;

	private RectTransform _rectTransform;

	private RectTransform _parentRectTransform;

	private bool _initialized;

	private Vector2 _adjustedOffset;

	private List<TooltipItemSlot> _itemSlots;

	private bool _isItemTooltip;

	private ITooltipProvider _tooltipProvider;

	private Coroutine _delayCoroutine;

	private TooltipBuilder _tooltipBuilder;

	public static TooltipPanel Instance { get; private set; }

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Debugger.Warning("There is already a tooltip panel in this scene.", this);
		}
	}

	private void Update()
	{
		if (_tooltipProvider == null)
		{
			PositionTooltip(FlotsamInputManager.MousePosition);
		}
		else
		{
			PositionTooltip(_tooltipProvider.GetPosition());
		}
	}

	public static void ShowTooltip(ITooltipProvider tooltipProvider, bool delayed = true)
	{
		if (!(Instance == null))
		{
			Instance.ShowTooltip_Internal(tooltipProvider, delayed);
		}
	}

	public static void HideTooltip(ITooltipProvider tooltipProvider = null)
	{
		if (!(Instance == null))
		{
			Instance.HideTooltip_Internal(tooltipProvider);
		}
	}

	public static void DisplayErrorTooltip(object owner, Vector2 position, string error)
	{
		Instance._errorTooltip.Display(error, owner, position);
	}

	public static void DisplayErrorTooltip(object owner, Vector2 position, List<LocalizedString> errors)
	{
		if (!(Instance == null) && !errors.IsNullOrEmpty())
		{
			if (errors.Count == 1)
			{
				Instance._errorTooltip.Display(errors[0], owner, position);
			}
			else
			{
				Instance._errorTooltip.Display(errors, owner, position);
			}
		}
	}

	public static void CloseErrorTooltip(object owner)
	{
		if (!(Instance == null))
		{
			Instance._errorTooltip.Close(owner);
		}
	}

	public static string FormatTooltip(ITooltipProvider tooltipProvider)
	{
		if (tooltipProvider == null || Instance == null)
		{
			return null;
		}
		Instance.Initialize();
		Instance._tooltipBuilder.Clear();
		return tooltipProvider.GetTooltip(Instance._tooltipBuilder);
	}

	public static bool TryGetTooltipBuilder(out TooltipBuilder tooltipBuilder)
	{
		if (Instance == null)
		{
			tooltipBuilder = null;
			return false;
		}
		Instance.Initialize();
		tooltipBuilder = Instance._tooltipBuilder;
		return tooltipBuilder != null;
	}

	private void Initialize()
	{
		if (!_initialized)
		{
			_rectTransform = _tooltipObject.transform as RectTransform;
			_parentRectTransform = base.transform as RectTransform;
			_tooltipBuilder = new TooltipBuilder(_tooltipBuilderProperties);
			PositionTooltip(FlotsamInputManager.MousePosition);
			_initialized = true;
		}
	}

	private void ShowTooltip_Internal(ITooltipProvider tooltipProvider, bool delayed)
	{
		if (!_isItemTooltip && tooltipProvider != null)
		{
			if (_delayCoroutine != null)
			{
				StopCoroutine(_delayCoroutine);
				_delayCoroutine = null;
			}
			_tooltipProvider = tooltipProvider;
			if (delayed)
			{
				_delayCoroutine = StartCoroutine(ShowTooltipDelayedCoroutine(GameManager.Settings.UISettings.TooltipDelay));
			}
			else
			{
				DisplayTooltip(tooltipProvider);
			}
		}
	}

	private IEnumerator ShowTooltipDelayedCoroutine(float delay)
	{
		float timer = 0f;
		while (timer < delay)
		{
			timer += Time.unscaledDeltaTime;
			if (_tooltipProvider == null)
			{
				break;
			}
			yield return null;
		}
		if (_tooltipProvider != null)
		{
			DisplayTooltip(_tooltipProvider);
		}
		_delayCoroutine = null;
	}

	private void HideTooltip_Internal(ITooltipProvider tooltipProvider)
	{
		if (!_isItemTooltip && (tooltipProvider == null || _tooltipProvider == tooltipProvider))
		{
			if (_delayCoroutine != null)
			{
				StopCoroutine(_delayCoroutine);
			}
			_tooltipProvider = null;
			_delayCoroutine = null;
			_tooltipObject.SetActive(value: false);
		}
	}

	public void DisplayTooltip(ITooltipProvider tooltipProvider)
	{
		if (!_isItemTooltip)
		{
			Initialize();
			_tooltipBuilder.Clear();
			_text.text = tooltipProvider.GetTooltip(_tooltipBuilder);
			_text.color = tooltipProvider.GetColor(_tooltipBuilder);
			_text.gameObject.SetActive(value: true);
			_tooltipObject.SetActive(value: true);
			LayoutRebuilder.ForceRebuildLayoutImmediate(_rectTransform);
			PositionTooltip(tooltipProvider.GetPosition());
			LayoutRebuilder.ForceRebuildLayoutImmediate(_rectTransform);
		}
	}

	public void DisplayItemTooltip(InventoryAuditor inventoryAuditor = null, string preText = null)
	{
		if (_itemSlotPrefab == null)
		{
			return;
		}
		_isItemTooltip = true;
		if (inventoryAuditor == null || inventoryAuditor.TotalItemCount == 0)
		{
			_tooltipObject.SetActive(value: false);
			return;
		}
		Initialize();
		if (preText == null)
		{
			_text.gameObject.SetActive(value: false);
		}
		else
		{
			_text.gameObject.SetActive(value: true);
			_text.text = preText;
		}
		if (_itemSlots == null)
		{
			_itemSlots = new List<TooltipItemSlot>();
		}
		int i = 0;
		for (int j = 0; j < inventoryAuditor.CountedItems.Count; j++)
		{
			InventoryAuditor.CountedItem countedItem = inventoryAuditor.CountedItems[j];
			if (countedItem.UnreservedCount != 0)
			{
				TooltipItemSlot tooltipItemSlot;
				if (i < _itemSlots.Count)
				{
					tooltipItemSlot = _itemSlots[i];
				}
				else
				{
					tooltipItemSlot = Object.Instantiate(_itemSlotPrefab, _itemSlotParent);
					_itemSlots.Add(tooltipItemSlot);
				}
				tooltipItemSlot.Initialize(countedItem);
				i++;
			}
		}
		_itemSlots[i - 1].DeactivateDivider();
		for (; i < _itemSlots.Count; i++)
		{
			_itemSlots[i].gameObject.SetActive(value: false);
		}
		_tooltipObject.SetActive(value: true);
		LayoutRebuilder.ForceRebuildLayoutImmediate(_rectTransform);
		PositionTooltip(FlotsamInputManager.MousePosition);
	}

	public void HideItemTooltip()
	{
		_isItemTooltip = false;
		HideTooltip();
	}

	private void OrientateTooltip(Vector2 position)
	{
		Vector2 vector = ReturnRelativeMousePosition(position);
		Vector2 pivot = new Vector2(0f, 1f);
		_adjustedOffset = _offset;
		if (vector.x > 0f)
		{
			pivot.x = 1f;
			_adjustedOffset = new Vector2(0f - _adjustedOffset.x, _adjustedOffset.y);
		}
		if (vector.y < 0f)
		{
			pivot.y = 0f;
			_adjustedOffset = new Vector2(_adjustedOffset.x, _rectTransform.sizeDelta.y + _adjustedOffset.y);
		}
		_rectTransform.pivot = pivot;
		RectTransform component = _text.GetComponent<RectTransform>();
		if (pivot.y == 0f)
		{
			_rectTransform.localScale = FlotsamGame.SetY(_rectTransform.localScale, -1f);
			component.localScale = FlotsamGame.SetY(component.localScale, -1f);
		}
		else
		{
			_rectTransform.localScale = FlotsamGame.SetY(_rectTransform.localScale, 1f);
			component.localScale = FlotsamGame.SetY(component.localScale, 1f);
		}
	}

	private void PositionTooltip(Vector2 worldPosition)
	{
		if (_initialized)
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(_parentRectTransform, worldPosition, null, out var localPoint);
			Vector2 vector = localPoint + _offset;
			Rect rect = ReturnLocalPositionRect(_rectTransform, vector);
			UpdateBounds();
			if (rect.xMin < _bounds.xMin)
			{
				vector.x += _bounds.xMin - rect.xMin;
			}
			else if (_bounds.xMax < rect.xMax)
			{
				vector.x -= rect.xMax - _bounds.xMax;
			}
			if (rect.yMin < _bounds.yMin)
			{
				vector.y += _bounds.yMin - rect.yMin;
			}
			else if (_bounds.yMax < rect.yMax)
			{
				vector.y -= rect.yMax - _bounds.yMax;
			}
			_rectTransform.localPosition = vector;
		}
	}

	private Rect ReturnLocalPositionRect(RectTransform rectTransform, Vector2 position)
	{
		Vector2 sizeDelta = rectTransform.sizeDelta;
		Vector2 pivot = rectTransform.pivot;
		position.x -= sizeDelta.x * pivot.x;
		position.y -= sizeDelta.y * pivot.y;
		return new Rect(position, sizeDelta);
	}

	private void UpdateBounds()
	{
		if (!(_bounds.size == _parentRectTransform.sizeDelta))
		{
			Vector2 sizeDelta = _parentRectTransform.sizeDelta;
			_bounds = new Rect((0f - sizeDelta.x) / 2f, (0f - sizeDelta.y) / 2f, sizeDelta.x, sizeDelta.y);
		}
	}

	public void UpdateTextTooltip(string text)
	{
		if (_text != null)
		{
			_text.text = text;
		}
	}

	private Vector2 ReturnRelativeMousePosition(Vector2 mousePosition)
	{
		Vector2 one = Vector2.one;
		one.x = ((!(mousePosition.x < GameManager.UIManager.ScreenSize.x / 2f)) ? 1 : (-1));
		one.y = ((!(mousePosition.y < GameManager.UIManager.ScreenSize.y / 2f)) ? 1 : (-1));
		return one;
	}
}
