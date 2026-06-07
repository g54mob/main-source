using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildItemSlot : MonoBehaviour
{
	public enum SlotState
	{
		None = 0,
		CountingUp = 1,
		CountingDown = 2,
		All = 3,
		Checked = 4
	}

	[Header("Background")]
	[SerializeField]
	[Tooltip("The default background sprite.")]
	public Sprite _defaultBackground;

	[Header("References")]
	[SerializeField]
	[Tooltip("The image used for the background of the slot.")]
	protected Image _background;

	[SerializeField]
	[Tooltip("The text used for displaying the item count.")]
	protected TextMeshProUGUI _counter;

	[SerializeField]
	[Tooltip("The image used for the icon of the item.")]
	protected Image _icon;

	[Tooltip("Check-mark to display on complete resources.")]
	[SerializeField]
	private Image _checkmark;

	[SerializeField]
	private ItemTooltip _tooltip;

	private SlotState _slotState;

	public CountedItemProperty RequiredResources { get; private set; }

	public void UpdateSlot(int amount, CountedItemProperty requiredResources, SlotState slotState)
	{
		if (RequiredResources != requiredResources)
		{
			RequiredResources = requiredResources;
			_icon.sprite = RequiredResources.ItemProperties.InventorySprite;
			_tooltip.Initialize(RequiredResources.ItemProperties);
		}
		_slotState = slotState;
		switch (_slotState)
		{
		case SlotState.CountingUp:
			if (amount == RequiredResources.Amount)
			{
				ShowCheckmark();
			}
			else
			{
				ShowCounter(amount);
			}
			SetBackground(RequiredResources.ItemProperties, amount);
			break;
		case SlotState.CountingDown:
			ShowCounter(amount);
			SetBackground(RequiredResources.ItemProperties, amount);
			break;
		case SlotState.All:
			ShowCounter(RequiredResources.Amount);
			SetBackground(RequiredResources.ItemProperties, RequiredResources.Amount);
			break;
		case SlotState.Checked:
			ShowCheckmark();
			SetBackground(RequiredResources.ItemProperties, RequiredResources.Amount);
			break;
		}
		base.gameObject.SetActive(value: true);
	}

	private void SetBackground(ItemProperties itemProperties, int itemCount)
	{
		_background.sprite = _defaultBackground;
		_background.color = ((itemCount == RequiredResources.Amount) ? itemProperties.ItemType.Color : GameManager.Settings.ItemSettings.DisabledColor);
	}

	private void ShowCheckmark()
	{
		_counter.gameObject.SetActive(value: false);
		_checkmark.gameObject.SetActive(value: true);
	}

	private void ShowCounter(int itemCount)
	{
		_counter.text = $"{itemCount}/{RequiredResources.Amount}";
		_counter.gameObject.SetActive(value: true);
		_checkmark.gameObject.SetActive(value: false);
	}
}
