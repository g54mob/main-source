using System.Collections;
using Bolt;
using DV;
using DV.Common;
using DV.Game.Tutorial;
using DV.InventorySystem;
using DV.UI;
using DV.UI.Inventory;
using DV.Utils;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(CharacterController))]
[UnitSubtitle("Succeeds if player uses magic get button")]
[UnitCategory("Interaction")]
[UnitTitle("Inventory Item Magic Get Pressed")]
public class InventoryItemMagicGetPressedUnit : Unit
{
	[DoNotSerialize]
	public ControlOutput outputSuccess;

	[DoNotSerialize]
	public ControlOutput outputFail;

	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ValueInput targetItem;

	[LocalizedValue]
	[DoNotSerialize]
	public ValueInput floatieMessage;

	protected override void Definition()
	{
		outputSuccess = ControlOutput("Output Success");
		outputFail = ControlOutput("Output Fail");
		targetItem = ValueInput<GameObject>("Item", null);
		inputTrigger = ControlInputCoroutine("Input", Routine);
		floatieMessage = ValueInput<string>("Message", null);
	}

	private IEnumerator Routine(Flow flow)
	{
		GameObject item = flow.GetValue<GameObject>(targetItem);
		SingletonBehaviour<Inventory>.Instance.InventoryStatusChanged += OnInventoryAction;
		bool? succeed = null;
		bool shownFloatie = false;
		int num = SingletonBehaviour<Inventory>.Instance.FindReservedSlotForDroppedItem(item);
		if (num < 0)
		{
			SingletonBehaviour<Inventory>.Instance.InventoryStatusChanged -= OnInventoryAction;
			yield return outputFail;
			yield break;
		}
		InventoryUIController componentInChildren = SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.mainCanvas.GetComponentInChildren<InventoryUIController>(includeInactive: true);
		InventorySectionController inventorySectionController = (InventoryUtils.IsValidHotbarIndex(num) ? componentInChildren.hotbarController : (InventoryUtils.IsValidInventoryIndex(num) ? componentInChildren.backpackController : componentInChildren.handController));
		IInventoryItemSpec component = item.GetComponent<IInventoryItemSpec>();
		InventoryUIInteractionObserver component2 = inventorySectionController.GetComponent<InventoryUIInteractionObserver>();
		GameObject gameObject = null;
		for (int i = 0; i < inventorySectionController.gridView.Model.Count; i++)
		{
			InventorySlotDisplayData inventorySlotDisplayData = inventorySectionController.gridView.Model[i];
			if (inventorySlotDisplayData.IsGhost && inventorySlotDisplayData.Spec == component)
			{
				gameObject = component2.slotObservers[i].element.getButton.gameObject;
				break;
			}
		}
		string value = flow.GetValue<string>(floatieMessage);
		if (!string.IsNullOrEmpty(value))
		{
			SingletonBehaviour<TutorialHelper>.Instance.ShowTutorialFloatie(value, (gameObject != null) ? gameObject.transform : null, default(Vector3), localize: true, targetIsUI: true);
			shownFloatie = true;
		}
		while (!succeed.HasValue)
		{
			if (!SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.Inventory))
			{
				if (shownFloatie)
				{
					SingletonBehaviour<TutorialHelper>.Instance.HideTutorialFloatie();
				}
				yield return outputFail;
				yield break;
			}
			yield return null;
		}
		SingletonBehaviour<Inventory>.Instance.InventoryStatusChanged -= OnInventoryAction;
		if (shownFloatie)
		{
			SingletonBehaviour<TutorialHelper>.Instance.HideTutorialFloatie();
		}
		if (succeed.Value)
		{
			yield return outputSuccess;
		}
		else
		{
			yield return outputFail;
		}
		void OnInventoryAction(InventorySlotState primarySlotState, InventoryActionType primaryActionType, InventorySlotState secondarySlotState, InventoryActionType secondaryActionType)
		{
			bool flag = false;
			flag = !item || primarySlotState.item == item;
			if (flag && primaryActionType.HasAnyIntFlag(InventoryActionType.Equip))
			{
				succeed = false;
			}
			else if (flag && primaryActionType.HasAnyIntFlag(InventoryActionType.Add))
			{
				succeed = true;
			}
		}
	}
}
