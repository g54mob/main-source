using System.Collections.Generic;
using Bolt;
using DV.InventorySystem;
using DV.Utils;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(BoxCollider))]
[UnitCategory("Items")]
[UnitSubtitle("All items from hotbar, in tightly packed array")]
[UnitTitle("Get Hotbar Items")]
public class GetHotbarItems : Unit
{
	[DoNotSerialize]
	public ValueOutput outputValue;

	protected override void Definition()
	{
		outputValue = ValueOutput("Output", delegate
		{
			GameObject[] itemsArray = SingletonBehaviour<Inventory>.Instance.GetItemsArray(includingDropped: false);
			List<GameObject> list = new List<GameObject>();
			for (int i = 0; i <= 11; i++)
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
