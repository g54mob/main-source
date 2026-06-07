using System.Collections;
using Bolt;
using DV.Game.Tutorial;
using DV.Game.Tutorial.ItemTracker;
using DV.InventorySystem;
using DV.UI;
using DV.Utils;
using Ludiq;
using UnityEngine;

[UnitTitle("Item in inventory")]
[UnitCategory("Interaction")]
[TypeIcon(typeof(CharacterController))]
[UnitSubtitle("Wait for an item to appear in player's inventory")]
public class ItemInInventoryUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput inTrigger;

	[DoNotSerialize]
	public ValueInput targetItem;

	[DoNotSerialize]
	public ValueInput okEquippedValue;

	[LocalizedValue]
	[DoNotSerialize]
	public ValueInput floatieMessage;

	[DoNotSerialize]
	public ValueInput openInventoryMessage;

	private bool shownFloatie;

	[UnitHeaderInspectable("Require open inventory")]
	[Inspectable]
	public bool RequireInventory { get; set; }

	protected virtual bool DesiredState => true;

	protected virtual string OutName => "In";

	protected override void Definition()
	{
		inTrigger = ControlOutput(OutName);
		targetItem = ValueInput<GameObject>("Item", null);
		okEquippedValue = ValueInput("Equipped OK", @default: true);
		floatieMessage = ValueInput<string>("Message", null);
		if (RequireInventory)
		{
			openInventoryMessage = ValueInput<string>("Inventory", null);
		}
		inputTrigger = ControlInputCoroutine("Input", Routine);
		Requirement(targetItem, inputTrigger);
	}

	private IEnumerator Routine(Flow flow)
	{
		GameObject obj = flow.GetValue<GameObject>(targetItem);
		bool okEquipped = flow.GetValue<bool>(okEquippedValue);
		shownFloatie = false;
		bool num = SingletonBehaviour<Inventory>.Instance.Contains(obj, includeDropped: false);
		bool flag = SingletonBehaviour<Inventory>.Instance.GetEquipSlotForItem(obj) >= 0;
		if ((num || (okEquipped && flag)) == DesiredState)
		{
			yield return inTrigger;
			yield break;
		}
		if (RequireInventory && !SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.Inventory))
		{
			yield return BoltTutorialUtils.WaitForPanelState(CanvasController.ElementType.Inventory, targetState: true, flow.GetValue<string>(openInventoryMessage));
		}
		string message = flow.GetValue<string>(floatieMessage);
		ItemPointer pointer = null;
		if (!DesiredState)
		{
			pointer = new ItemPointer(obj, null, ItemTracker.TargetZoneType.World, message);
		}
		else if (!string.IsNullOrEmpty(message))
		{
			SingletonBehaviour<TutorialHelper>.Instance.ShowTutorialFloatie(message, null);
			shownFloatie = true;
		}
		else if (shownFloatie)
		{
			SingletonBehaviour<TutorialHelper>.Instance.HideTutorialFloatie();
			shownFloatie = false;
		}
		while (true)
		{
			if (RequireInventory && !SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.Inventory))
			{
				yield return BoltTutorialUtils.WaitForPanelState(CanvasController.ElementType.Inventory, targetState: true, flow.GetValue<string>(openInventoryMessage));
				if (!string.IsNullOrEmpty(message) && pointer == null)
				{
					SingletonBehaviour<TutorialHelper>.Instance.ShowTutorialFloatie(message, null);
					shownFloatie = true;
				}
			}
			else
			{
				bool num2 = SingletonBehaviour<Inventory>.Instance.Contains(obj, includeDropped: false);
				flag = SingletonBehaviour<Inventory>.Instance.GetEquipSlotForItem(obj) >= 0;
				if ((num2 || (okEquipped && flag)) == DesiredState)
				{
					break;
				}
			}
			yield return null;
		}
		if (shownFloatie)
		{
			SingletonBehaviour<TutorialHelper>.Instance.HideTutorialFloatie();
		}
		pointer?.Dispose();
		yield return inTrigger;
	}
}
