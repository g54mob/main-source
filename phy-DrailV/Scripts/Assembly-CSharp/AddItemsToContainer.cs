using Bolt;
using DV.InventorySystem;
using Ludiq;
using UnityEngine;

[UnitCategory("Items")]
[TypeIcon(typeof(BoxCollider))]
[UnitTitle("Add Items To Container")]
[UnitSubtitle("Adds all of the items to a given container item")]
public class AddItemsToContainer : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput doneTrigger;

	[DoNotSerialize]
	public ValueInput containerReference;

	[DoNotSerialize]
	public ValueInput[] itemsToAddReference;

	[Inspectable]
	[UnitHeaderInspectable("Count")]
	public int Count { get; set; } = 1;

	protected override void Definition()
	{
		doneTrigger = ControlOutput("Done");
		containerReference = ValueInput<GameObject>("Container", null);
		int num = Mathf.Clamp(Count, 1, 20);
		itemsToAddReference = new ValueInput[num];
		for (int i = 0; i < num; i++)
		{
			itemsToAddReference[i] = ValueInput<GameObject>("Item " + (i + 1), null);
		}
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			AItemContainer aItemContainer = flow.GetValue<GameObject>(containerReference)?.GetComponent<AItemContainer>();
			if (!aItemContainer)
			{
				Debug.LogError("Container is not assigned, or the assigned object is not an AItemContainer, skipping.");
				return doneTrigger;
			}
			for (int j = 0; j < Count; j++)
			{
				GameObject value = flow.GetValue<GameObject>(itemsToAddReference[j]);
				if ((bool)value)
				{
					aItemContainer.AddItem(value, j);
				}
			}
			return doneTrigger;
		});
	}
}
