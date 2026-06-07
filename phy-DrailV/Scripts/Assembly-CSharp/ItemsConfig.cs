using System.Collections.Generic;
using DV.Items;
using UnityEngine;

[CreateAssetMenu(menuName = "DV/Items config")]
public class ItemsConfig : ScriptableObject
{
	public string configName = "<NOT SET>";

	public int configVersion = -1;

	public List<InventoryItemSpec> items;

	[SerializeField]
	private List<StartingItems> startingItems;

	public StartingItems GetStartingItemsAsset(GameParams.StartingItemsType type)
	{
		return startingItems.Find((StartingItems s) => s.startingItemsType == type);
	}
}
