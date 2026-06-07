using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemSpawnIcon : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public class ItemSpawnEvent : UnityEvent<ItemProperties>
	{
	}

	[SerializeField]
	private Image _backgroundImage;

	[SerializeField]
	private Image _itemImage;

	private ItemProperties _properties;

	public ItemSpawnEvent SpawnEvent { get; private set; }

	public void Initialize(ItemProperties properties)
	{
		_properties = properties;
		SpawnEvent = new ItemSpawnEvent();
		_backgroundImage.color = properties.ItemType.Color;
		_itemImage.sprite = properties.InventorySprite;
	}

	public void OnPointerClick(PointerEventData pointerEventData)
	{
		SpawnEvent.Invoke(_properties);
	}
}
