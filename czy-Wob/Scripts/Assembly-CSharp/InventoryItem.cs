using I2.Loc;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItem", menuName = "InventoryItem", order = 1)]
public class InventoryItem : ScriptableObject
{
	public bool startUnlocked = true;

	public bool placeableObjectOverride;

	public ItemType type;

	public ItemSet setType;

	public ItemRarity rarity = ItemRarity.COMMON;

	public string itemName;

	public bool canSpawnThroughCheats = true;

	public LocalizedString itemNameLocalized;

	public LocalizedString itemDescriptionLocalized;

	public GameObject itemPrefab;

	public Sprite icon;

	public bool updateObjectRotationForIcon = true;
}
