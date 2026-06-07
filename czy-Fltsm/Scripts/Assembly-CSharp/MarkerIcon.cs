using UnityEngine;
using UnityEngine.UI;

public class MarkerIcon : MonoBehaviour
{
	public Image Icon;

	public Image Background;

	public ItemProperties ItemProperties { get; private set; }

	public void Initialize(ItemProperties itemProperties)
	{
		ItemProperties = itemProperties;
		Icon.sprite = ItemProperties.InventorySprite;
		Background.color = itemProperties.ItemType.Color;
	}
}
