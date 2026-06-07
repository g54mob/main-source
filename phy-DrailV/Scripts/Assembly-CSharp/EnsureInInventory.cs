using System.Collections.Generic;
using Bolt;
using DV;
using DV.CabControls;
using DV.Customization.Gadgets;
using DV.InventorySystem;
using DV.Utils;
using Ludiq;
using UnityEngine;

[UnitSubtitle("Make sure player has an item, either by teleporting or spawning if needed")]
[UnitTitle("Ensure Player Has")]
[UnitCategory("Items")]
[TypeIcon(typeof(BoxCollider))]
public class EnsureInInventory : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput doneTrigger;

	[DoNotSerialize]
	public ValueInput prefabName;

	[DoNotSerialize]
	public ValueInput[] existingInstance;

	[DoNotSerialize]
	public ValueInput returnEntireContainer;

	[DoNotSerialize]
	public ValueInput allowSpawning;

	[DoNotSerialize]
	public ValueOutput itemOutput;

	[UnitHeaderInspectable("Existing Count")]
	[Inspectable]
	public int ExistingCount { get; set; } = 1;

	protected override void Definition()
	{
		doneTrigger = ControlOutput("Done");
		prefabName = ValueInput("Name", "");
		int num = Mathf.Clamp(ExistingCount, 1, 16);
		existingInstance = new ValueInput[num];
		for (int i = 0; i < num; i++)
		{
			if (i >= 1)
			{
				existingInstance[i] = ValueInput<GameObject>("Existing " + (i + 1), null);
			}
			else
			{
				existingInstance[i] = ValueInput<GameObject>("Existing", null);
			}
		}
		returnEntireContainer = ValueInput("Entire container", @default: true);
		allowSpawning = ValueInput("Allow spawning", @default: true);
		itemOutput = ValueOutput<GameObject>("Item", null);
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			bool value = flow.GetValue<bool>(returnEntireContainer);
			bool value2 = flow.GetValue<bool>(allowSpawning);
			string value3 = flow.GetValue<string>(prefabName);
			List<GameObject> itemsByPrefabName = GetItemFromInventory.GetItemsByPrefabName(value3, includeDropped: true, includeContainers: true);
			List<GameObject> list = new List<GameObject>();
			for (int j = 0; j < ExistingCount; j++)
			{
				GameObject value4 = flow.GetValue<GameObject>(existingInstance[j]);
				if (value4 != null)
				{
					GadgetItem component = value4.GetComponent<GadgetItem>();
					if (!component || component.Gadget.Custom == null)
					{
						list.Add(value4);
					}
				}
			}
			foreach (GameObject item in itemsByPrefabName)
			{
				GadgetItem component2 = item.GetComponent<GadgetItem>();
				if (!component2 || !(component2.Gadget.Custom != null))
				{
					if (GetItemFromInventory.GetItemByPrefabName(value3, includeDropped: false, includeContainers: true) == null)
					{
						bool flag = false;
						for (int k = 0; k < SingletonBehaviour<Inventory>.Instance.HandCapacity; k++)
						{
							if (!SingletonBehaviour<Inventory>.Instance.GetSlotDroppedState(k))
							{
								GameObject equippedItemAtSlot = SingletonBehaviour<Inventory>.Instance.GetEquippedItemAtSlot(k);
								InventoryItemSpec inventoryItemSpec = (equippedItemAtSlot ? equippedItemAtSlot.GetComponent<InventoryItemSpec>() : null);
								if (list.Contains(equippedItemAtSlot) || ((bool)inventoryItemSpec && inventoryItemSpec.ItemPrefabName == value3))
								{
									flag = true;
									break;
								}
							}
						}
						if (!flag)
						{
							item.SetActive(value: true);
							int num2 = SingletonBehaviour<Inventory>.Instance.IndexOf(item);
							Debug.Log("FORCE BACK TO INVENTORY OF " + item.name + " @ " + num2);
							SingletonBehaviour<Inventory>.Instance.AddItemToInventory(item, num2);
						}
					}
					flow.SetValue(itemOutput, item);
					return doneTrigger;
				}
			}
			if (list.Count == 0 && value2)
			{
				foreach (InventoryItemSpec item2 in Globals.G.Items.items)
				{
					if (string.Compare(item2.ItemPrefabName, value3, ignoreCase: true) == 0)
					{
						GameObject gameObject = Object.Instantiate(item2.gameObject);
						gameObject.name = item2.ItemPrefabName;
						list.Add(gameObject);
						PageBook componentInChildren = gameObject.GetComponentInChildren<PageBook>();
						if (componentInChildren != null)
						{
							componentInChildren.ForceStart();
							componentInChildren.generateOnStart = false;
						}
					}
				}
			}
			if (list.Count > 0)
			{
				foreach (GameObject item3 in list)
				{
					ItemBase component3 = item3.GetComponent<ItemBase>();
					if (value && (bool)component3 && component3.InContainer != null)
					{
						ItemBase component4 = component3.InContainer.GetComponent<ItemBase>();
						if ((bool)component4 && !component4.IsBoundToPlayer())
						{
							SingletonBehaviour<Inventory>.Instance.AddItemToInventory(item3);
						}
					}
					else
					{
						if (!item3.activeSelf)
						{
							item3.SetActive(value: true);
						}
						SingletonBehaviour<Inventory>.Instance.AddItemToInventory(item3);
					}
				}
			}
			else
			{
				Debug.LogError("ERROR! Item named '" + value3 + "' couldn't be found or spawned, is the name correct?");
			}
			flow.SetValue(itemOutput, (list.Count > 0) ? list[0] : null);
			return doneTrigger;
		});
	}
}
