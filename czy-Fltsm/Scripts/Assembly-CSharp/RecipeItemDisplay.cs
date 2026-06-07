using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class RecipeItemDisplay : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[Header("Components")]
	[Tooltip("Background image component of the item display.")]
	[SerializeField]
	private Image _backgroundImage;

	[Tooltip("Item image component of the item display.")]
	[SerializeField]
	private Image _itemImage;

	[SerializeField]
	[Tooltip("Should a potential icon override in the ProductionRecipeProperties be ignored?")]
	private bool _ignoreItemIconOverride;

	[SerializeField]
	[Tooltip("Amount text component of this item display.")]
	private TextMeshProUGUI _amountText;

	[SerializeField]
	[Tooltip("Name text component of this item display.")]
	private TextMeshProUGUI _nameText;

	[SerializeField]
	[Tooltip("Slider for the progress of this recipe.")]
	private Slider _progressSlider;

	[SerializeField]
	private Toggle _toggle;

	[Header("Events")]
	[Tooltip("Unity event called when the display is left clicked.")]
	public UnityEvent OnLeftClickEvent;

	[Tooltip("Unity event called when the display is right clicked.")]
	public UnityEvent OnRightClickEvent;

	[Header("Colors")]
	[SerializeField]
	[Tooltip("Color for valid requirements.")]
	private Color _validTextColor = new Color(0.196f, 0.196f, 0.196f);

	[SerializeField]
	[Tooltip("Color for invalid requirements.")]
	private Color _invalidTextColor = new Color(0.945f, 0.404f, 0.333f);

	private ItemTooltip _tooltip;

	public Producer.Recipe Recipe { get; private set; }

	public ItemProperties ItemProperties { get; private set; }

	public Toggle Toggle => _toggle;

	public bool ItemDisabled { get; private set; }

	private void Awake()
	{
		_tooltip = GetComponent<ItemTooltip>();
		if (_tooltip == null)
		{
			_tooltip = base.gameObject.AddComponent<ItemTooltip>();
		}
	}

	public void Initialize(Producer.Recipe recipe, ItemProperties itemProperties, bool itemDisabled = false, string amount = "")
	{
		if (_tooltip == null)
		{
			Awake();
		}
		Recipe = recipe;
		ItemProperties = itemProperties;
		ItemDisabled = itemDisabled;
		if (_amountText != null)
		{
			_amountText.text = amount;
			_amountText.color = (itemDisabled ? _invalidTextColor : _validTextColor);
		}
		if (itemProperties == null)
		{
			_itemImage.sprite = null;
			_itemImage.gameObject.SetActive(value: false);
			_backgroundImage.color = Color.white;
			_tooltip.IsEnabled = false;
			return;
		}
		_tooltip.IsEnabled = true;
		_tooltip.Initialize(itemProperties);
		if (!_itemImage.IsActive())
		{
			_itemImage.gameObject.SetActive(value: true);
		}
		if (_itemImage != null)
		{
			_itemImage.sprite = (_ignoreItemIconOverride ? itemProperties.InventorySprite : recipe.GetIcon(itemProperties));
		}
		if (_backgroundImage != null)
		{
			if (itemDisabled)
			{
				_backgroundImage.color = GameManager.Settings.ItemSettings.DisabledColor;
			}
			else
			{
				_backgroundImage.color = itemProperties.ItemType.Color;
			}
		}
		if (_nameText != null)
		{
			_nameText.text = itemProperties.LocalizedName;
			_nameText.color = (itemDisabled ? _invalidTextColor : _validTextColor);
		}
	}

	public void Initialize(QueuedRecipe queuedRecipe, ItemProperties itemProperties)
	{
		Initialize(queuedRecipe.Recipe, itemProperties);
		SetProgress(queuedRecipe.NormalizedProgress);
	}

	public void Initialize()
	{
		Initialize(null, null, itemDisabled: false, string.Empty);
	}

	public void Initialize(Sprite icon, Color color, LocalizedString tooltipText)
	{
		if (_tooltip == null)
		{
			_tooltip = GetComponent<ItemTooltip>();
			if (_tooltip == null)
			{
				_tooltip = base.gameObject.AddComponent<ItemTooltip>();
			}
		}
		Recipe = null;
		ItemProperties = null;
		_itemImage.sprite = icon;
		_tooltip.IsEnabled = true;
		_tooltip.Initialize(tooltipText);
		SetProgress(0f);
		if (_backgroundImage != null)
		{
			_backgroundImage.color = color;
		}
	}

	public void OnPointerClick(PointerEventData pointerEventData)
	{
		if (pointerEventData.button == PointerEventData.InputButton.Left)
		{
			OnLeftClickEvent.Invoke();
		}
		if (pointerEventData.button == PointerEventData.InputButton.Right)
		{
			OnRightClickEvent.Invoke();
		}
	}

	private void OnDisable()
	{
		_toggle?.onValueChanged.RemoveAllListeners();
	}

	private void OnDestroy()
	{
		OnLeftClickEvent.RemoveAllListeners();
		OnRightClickEvent.RemoveAllListeners();
	}

	public void SetToggleGroup(ToggleGroup toggleGroup)
	{
		_toggle.group = toggleGroup;
	}

	public void SetAmount(int amount)
	{
		_amountText.text = amount.ToString();
	}

	public void SetProgress(float progress)
	{
		if (_progressSlider != null)
		{
			_progressSlider.minValue = 0f;
			_progressSlider.maxValue = 1f;
			_progressSlider.value = progress;
		}
	}

	public void ActivateItem(bool activated)
	{
		if (_amountText != null)
		{
			_amountText.color = (activated ? _validTextColor : _invalidTextColor);
		}
		if (_nameText != null)
		{
			_nameText.color = (activated ? _validTextColor : _invalidTextColor);
		}
		if (_backgroundImage != null && ItemProperties != null)
		{
			_backgroundImage.color = (activated ? ItemProperties.ItemType.Color : GameManager.Settings.ItemSettings.DisabledColor);
		}
	}
}
