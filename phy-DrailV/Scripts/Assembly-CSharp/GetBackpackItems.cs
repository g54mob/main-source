using System.Collections.Generic;
using Bolt;
using DV.InventorySystem;
using DV.Utils;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(BoxCollider))]
[UnitCategory("Items")]
[UnitSubtitle("All items from backpack, in tightly packed array")]
[UnitTitle("Get Backpack Items")]
public class GetBackpackItems : Unit
{
	[DoNotSerialize]
	public ValueOutput outputValue;

	protected override void Definition()
	{
		outputValue = ValueOutput("Output", delegate
		{
			GameObject[] itemsArray = SingletonBehaviour<Inventory>.Instance.GetItemsArray(includingDropped: false);
			List<GameObject> list = new List<GameObject>();
			for (int i = 12; i < 36; i++)
			{
				if ((bool)itemsArray[i])
				{
					list.Add(itemsArray[i]);
				}
			}
			return list.ToArray();
		});
	}
}
