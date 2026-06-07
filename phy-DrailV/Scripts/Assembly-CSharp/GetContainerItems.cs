using System;
using System.Collections.Generic;
using Bolt;
using DV.InventorySystem;
using Ludiq;
using UnityEngine;

[UnitTitle("Get Container Items")]
[UnitSubtitle("All items from a container, in tightly packed array")]
[UnitCategory("Items")]
[TypeIcon(typeof(BoxCollider))]
public class GetContainerItems : Unit
{
	[DoNotSerialize]
	public ValueInput containerReference;

	[DoNotSerialize]
	public ValueOutput outputValue;

	protected override void Definition()
	{
		containerReference = ValueInput<GameObject>("Container", null);
		outputValue = ValueOutput("Output", delegate(Flow flow)
		{
			GameObject value = flow.GetValue<GameObject>(containerReference);
			if (value == null)
			{
				Debug.LogError("Container object reference is null in GetContainerItems");
				return Array.Empty<GameObject>();
			}
			AItemContainer aItemContainer = value?.GetComponent<AItemContainer>();
			if (aItemContainer == null)
			{
				Debug.LogError("Container object reference is not a valid AItemContainer in GetContainerItems");
				return Array.Empty<GameObject>();
			}
			List<GameObject> list = new List<GameObject>();
			GameObject[] itemsArray = aItemContainer.GetItemsArray(includingDropped: false);
			foreach (GameObject gameObject in itemsArray)
			{
				if ((bool)gameObject)
				{
					list.Add(gameObject);
				}
			}
			return list.ToArray();
		});
	}
}
