using System.Collections.Generic;
using Bolt;
using DV.InventorySystem;
using DV.Utils;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(SphereCollider))]
[UnitSubtitle("Destroy all inventory items, use with caution")]
[UnitCategory("Interaction")]
[UnitTitle("Nuke Inventory")]
public class NukeInventoryUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ValueInput includeDroppedValue;

	[DoNotSerialize]
	public ControlOutput doneTrigger;

	protected override void Definition()
	{
		doneTrigger = ControlOutput("Done");
		includeDroppedValue = ValueInput("Include Dropped", @default: true);
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			bool value = flow.GetValue<bool>(includeDroppedValue);
			GameObject[] itemsArray = SingletonBehaviour<Inventory>.Instance.GetItemsArray(value);
			List<GameObject> list = new List<GameObject>();
			for (int i = 0; i < itemsArray.Length; i++)
			{
				if (itemsArray[i] != null)
				{
					if (SingletonBehaviour<Inventory>.Instance.Contains(itemsArray[i], includeDropped: false))
					{
						SingletonBehaviour<Inventory>.Instance.DropItemFromHandsOrInventory(itemsArray[i]);
					}
					list.Add(itemsArray[i]);
				}
			}
			foreach (GameObject item in list)
			{
				if (item != null)
				{
					Object.Destroy(item);
				}
			}
			return doneTrigger;
		});
	}
}
