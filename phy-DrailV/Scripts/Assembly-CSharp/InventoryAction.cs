using System.Collections;
using Bolt;
using DV;
using DV.Game.Tutorial;
using DV.Game.Tutorial.ItemTracker;
using DV.InventorySystem;
using DV.UI;
using DV.Utils;
using Ludiq;
using UnityEngine;

[UnitSubtitle("Wait for player to perform an inventory action")]
[UnitCategory("Interaction")]
[TypeIcon(typeof(CharacterController))]
[UnitTitle("Inventory action")]
public class InventoryAction : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput inTrigger;

	[DoNotSerialize]
	public ValueInput targetItem;

	[DoNotSerialize]
	public ValueInput actionType;

	[DoNotSerialize]
	[LocalizedValue]
	public ValueInput floatieMessage;

	[DoNotSerialize]
	[LocalizedValue]
	public ValueInput openInventoryMessage;

	[UnitHeaderInspectable("Require open inventory")]
	[Inspectable]
	public bool RequireInventory { get; set; }

	protected override void Definition()
	{
		inTrigger = ControlOutput("Performed");
		targetItem = ValueInput<GameObject>("Item", null);
		actionType = ValueInput("Action", InventoryActionType.Drop);
		floatieMessage = ValueInput<string>("Message", null);
		if (RequireInventory)
		{
			openInventoryMessage = ValueInput<string>("Inventory", null);
		}
		inputTrigger = ControlInputCoroutine("Input", Routine);
	}

	private IEnumerator Routine(Flow flow)
	{
		string inventoryMsg = string.Empty;
		if (RequireInventory)
		{
			inventoryMsg = flow.GetValue<string>(openInventoryMessage);
			yield return BoltTutorialUtils.WaitForPanelState(CanvasController.ElementType.Inventory, targetState: true, inventoryMsg);
		}
		string message = flow.GetValue<string>(floatieMessage);
		GameObject item = flow.GetValue<GameObject>(targetItem);
		ItemPointer pointer = new ItemPointer(item, null, ItemTracker.TargetZoneType.None, message);
		InventoryActionType action = flow.GetValue<InventoryActionType>(actionType);
		SingletonBehaviour<Inventory>.Instance.InventoryStatusChanged += OnInventoryAction;
		bool actionDone = false;
		while (!actionDone)
		{
			if (RequireInventory && !SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.Inventory))
			{
				if (pointer != null)
				{
					pointer.Dispose();
					pointer = null;
				}
				yield return BoltTutorialUtils.WaitForPanelState(CanvasController.ElementType.Inventory, targetState: true, inventoryMsg);
				if (!string.IsNullOrEmpty(message))
				{
					pointer = new ItemPointer(item, null, ItemTracker.TargetZoneType.None, message);
				}
			}
			yield return null;
		}
		SingletonBehaviour<Inventory>.Instance.InventoryStatusChanged -= OnInventoryAction;
		pointer?.Dispose();
		yield return inTrigger;
		void OnInventoryAction(InventorySlotState primarySlotState, InventoryActionType primaryActionType, InventorySlotState secondarySlotState, InventoryActionType secondaryActionType)
		{
			bool flag = false;
			flag = !item || primarySlotState.item == item;
			if (flag && primaryActionType.HasAnyIntFlag(action))
			{
				actionDone = true;
			}
		}
	}
}
