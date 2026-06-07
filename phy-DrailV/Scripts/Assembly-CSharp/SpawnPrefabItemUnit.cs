using Bolt;
using DV;
using DV.InventorySystem;
using DV.Utils;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(BoxCollider))]
[UnitCategory("Items")]
[UnitSubtitle("Spawn a prefabbed player item in the world, or in inventory if target null")]
[UnitTitle("Spawn Prefab Item")]
public class SpawnPrefabItemUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput spawnedTrigger;

	[DoNotSerialize]
	public ValueInput prefabName;

	[DoNotSerialize]
	public ValueInput quantityValue;

	[DoNotSerialize]
	public ValueInput targetAnchor;

	[DoNotSerialize]
	public ValueOutput spawnedItem;

	protected override void Definition()
	{
		spawnedTrigger = ControlOutput("Spawned");
		prefabName = ValueInput("Name", "");
		targetAnchor = ValueInput<GameObject>("Target", null);
		quantityValue = ValueInput("Quantity", 1.0);
		spawnedItem = ValueOutput<GameObject>("Item", null);
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			flow.stack.AsReference();
			string value = flow.GetValue<string>(prefabName);
			GameObject value2 = flow.GetValue<GameObject>(targetAnchor);
			Transform transform = (value2 ? value2.transform : null);
			GameObject gameObject = null;
			bool flag = false;
			foreach (InventoryItemSpec item in Globals.G.Items.items)
			{
				if (string.Compare(item.ItemPrefabName, value, ignoreCase: true) == 0)
				{
					gameObject = Object.Instantiate(item.gameObject);
					gameObject.name = item.ItemPrefabName;
					TutorialHelper.MakeItemEssential(gameObject, belongsToPlayer: true, immuneToDumpster: true);
					if ((bool)transform)
					{
						gameObject.transform.SetPositionAndRotation(transform.transform.position, transform.transform.rotation);
					}
					else
					{
						SingletonBehaviour<Inventory>.Instance.AddItemToInventory(gameObject);
					}
					PageBook componentInChildren = gameObject.GetComponentInChildren<PageBook>();
					if (componentInChildren != null)
					{
						componentInChildren.ForceStart();
						componentInChildren.generateOnStart = false;
					}
					IMoney component = gameObject.GetComponent<IMoney>();
					if (component != null)
					{
						component.Amount = flow.GetValue<double>(quantityValue);
					}
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				Debug.LogError("ERROR! Item prefab " + value + " not found, nothing is spawned!");
			}
			flow.SetValue(spawnedItem, gameObject);
			return spawnedTrigger;
		});
	}
}
