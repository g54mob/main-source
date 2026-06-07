using System.Collections.Generic;
using Bolt;
using DV.InventorySystem;
using DV.Utils;
using Ludiq;
using UnityEngine;

[UnitTitle("Nuke Items")]
[TypeIcon(typeof(SphereCollider))]
[UnitCategory("Interaction")]
[UnitSubtitle("Destroy specified items")]
public class NukeItemsUnit : Unit
{
	private const int MAX_ITEMS = 16;

	[DoNotSerialize]
	public ValueInput[] targetItem;

	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput doneTrigger;

	[Inspectable]
	[UnitHeaderInspectable("Count")]
	public int Count { get; set; } = 1;

	protected override void Definition()
	{
		doneTrigger = ControlOutput("Done");
		int count = Mathf.Clamp(Count, 1, 16);
		targetItem = new ValueInput[count];
		for (int i = 0; i < count; i++)
		{
			targetItem[i] = ValueInput<GameObject>($"Item {i + 1}", null);
		}
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			List<GameObject> list = new List<GameObject>();
			for (int j = 0; j < count; j++)
			{
				GameObject value = flow.GetValue<GameObject>(targetItem[j]);
				if (value != null)
				{
					if (SingletonBehaviour<Inventory>.Instance.Contains(value, includeDropped: false))
					{
						SingletonBehaviour<Inventory>.Instance.DropItemFromHandsOrInventory(value);
					}
					list.Add(value);
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
		for (int num = 0; num < count; num++)
		{
			Requirement(targetItem[num], inputTrigger);
		}
	}
}
