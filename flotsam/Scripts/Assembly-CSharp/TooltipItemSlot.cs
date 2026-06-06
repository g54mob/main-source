using UnityEngine;
using UnityEngine.UI;

public class TooltipItemSlot : MonoBehaviour
{
	[SerializeField]
	[Tooltip("Image component of the item slot.")]
	private Image _icon;

	[SerializeField]
	[Tooltip("Counter text component of the item slot.")]
	private Text _counter;

	[SerializeField]
	[Tooltip("Divider prefab for the object that is spawned between the different items.")]
	private GameObject _dividerPrefab;

	private GameObject _divider;

	public void Initialize(InventoryAuditor.CountedItem countedItem)
	{
		_icon.sprite = countedItem.ItemProperties.InventorySprite;
		_counter.text = countedItem.UnreservedCount.ToString();
		if (_divider == null)
		{
			_divider = Object.Instantiate(_dividerPrefab, base.transform.parent);
		}
		_divider.gameObject.SetActive(value: true);
		base.gameObject.SetActive(value: true);
	}

	private void OnDisable()
	{
		if (_divider != null)
		{
			_divider.SetActive(value: false);
		}
		base.gameObject.SetActive(value: false);
	}

	public void DeactivateDivider()
	{
		if (!(_divider == null))
		{
			_divider.SetActive(value: false);
		}
	}
}
