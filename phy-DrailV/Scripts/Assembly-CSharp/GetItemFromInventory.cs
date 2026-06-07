using System.Collections.Generic;
using System.Linq;
using Bolt;
using DV.InventorySystem;
using DV.Utils;
using Ludiq;
using UnityEngine;

[UnitTitle("Get Inventory Item")]
[UnitSubtitle("Get an item from player's inventory")]
[UnitCategory("Items")]
[TypeIcon(typeof(BoxCollider))]
public class GetItemFromInventory : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput outputTrigger;

	[DoNotSerialize]
	public ValueInput prefabName;

	[DoNotSerialize]
	public ValueInput allowDropped;

	[DoNotSerialize]
	public ValueInput allowContainers;

	[DoNotSerialize]
	public ValueOutput foundItem;

	protected override void Definition()
	{
		outputTrigger = ControlOutput("Got it");
		prefabName = ValueInput("Name", "");
		allowDropped = ValueInput("Allow dropped", @default: true);
		allowContainers = ValueInput("Allow containers", @default: true);
		foundItem = ValueOutput<GameObject>("Item", null);
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			flow.SetValue(foundItem, GetItemByPrefabName(flow.GetValue<string>(prefabName), flow.GetValue<bool>(allowDropped), flow.GetValue<bool>(allowContainers)));
			return outputTrigger;
		});
	}

	public static List<GameObject> GetItemsByPrefabName(string prefabName, bool includeDropped, bool includeContainers)
	{
		GameObject[] itemsArray = SingletonBehaviour<Inventory>.Instance.GetItemsArray(includeDropped);
		List<GameObject> list = new List<GameObject>();
		GameObject[] array = itemsArray;
		foreach (GameObject gameObject in array)
		{
			if (!gameObject)
			{
				continue;
			}
			InventoryItemSpec component = gameObject.GetComponent<InventoryItemSpec>();
			if ((bool)component && component.ItemPrefabName == prefabName)
			{
				list.Add(gameObject);
			}
			if (!includeContainers)
			{
				continue;
			}
			AItemContainer component2 = gameObject.GetComponent<AItemContainer>();
			if ((bool)component2)
			{
				component2.FindAll(delegate(GameObject containerItem)
				{
					InventoryItemSpec component3 = containerItem.GetComponent<InventoryItemSpec>();
					return component3 != null && component3.ItemPrefabName == prefabName;
				}, recursive: true, includeDropped, list);
			}
		}
		return list;
	}

	public static GameObject GetItemByPrefabName(string prefabName, bool includeDropped, bool includeContainers)
	{
		return GetItemsByPrefabName(prefabName, includeDropped, includeContainers).FirstOrDefault();
	}
}
