using UnityEngine;

[CreateAssetMenu(fileName = "Researchable", menuName = "Researchable", order = 1)]
public class Researchable : ScriptableObject
{
	public bool startUnlocked;

	public bool canBeUnlockedThroughCheats = true;

	public ItemSet associatedSetType;

	public InventoryItem inventoryItemUnlock;

	public RoomCustomizationObject roomCustomizationObjectUnlock;
}
