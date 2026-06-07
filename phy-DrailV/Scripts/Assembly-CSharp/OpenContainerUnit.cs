using Bolt;
using DV.CabControls;
using DV.Game.Tutorial;
using DV.Game.Tutorial.ItemTracker;
using DV.InventorySystem;
using DV.UI;
using DV.Utils;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(BoxCollider))]
[UnitTitle("Open Container")]
[UnitCategory("Interaction")]
[UnitSubtitle("Open the inventory and/or a given container")]
public class OpenContainerUnit : GenericWaitForCondition
{
	private class Context
	{
		public string InventoryMessage;

		public string ContainerMessage;

		public AItemContainer TargetContainer;

		public ItemBase ContainerItem;

		public bool LastInventoryState;

		public ItemPointer Pointer;
	}

	[DoNotSerialize]
	public ValueInput targetContainer;

	[LocalizedValue]
	[DoNotSerialize]
	public ValueInput inventoryMessage;

	[DoNotSerialize]
	[LocalizedValue]
	public ValueInput containerMessage;

	protected override void InternalDefinition()
	{
		targetContainer = ValueInput<GameObject>("Container");
		inventoryMessage = ValueInput<string>("Inventory Msg", null);
		containerMessage = ValueInput<string>("Container Msg", null);
	}

	public override object PrepareContext(Flow flow)
	{
		Context context = new Context();
		context.ContainerMessage = flow.GetValue<string>(containerMessage);
		context.InventoryMessage = flow.GetValue<string>(inventoryMessage);
		context.TargetContainer = flow.GetValue<GameObject>(targetContainer)?.GetComponent<AItemContainer>();
		context.ContainerItem = (context.TargetContainer ? context.TargetContainer.GetComponent<ItemBase>() : null);
		context.LastInventoryState = SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.Inventory);
		return context;
	}

	public override bool EarlyOutCheck(Flow flow, object context, bool silent = false)
	{
		return SingletonBehaviour<Inventory>.Instance.ItemContainerRegistry.ActiveContainer == ((Context)context).TargetContainer;
	}

	public override void Deinitialize(Flow flow, object context, bool silent = false)
	{
		base.Deinitialize(flow, context, silent);
		Context context2 = (Context)context;
		if (context2.Pointer != null)
		{
			context2.Pointer.Dispose();
		}
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		if (!SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.Inventory))
		{
			if (context2.LastInventoryState || context2.Pointer == null)
			{
				context2.LastInventoryState = false;
				if (context2.Pointer != null)
				{
					context2.Pointer.Dispose();
				}
				if (!silent)
				{
					context2.Pointer = new ItemPointer(context2.ContainerItem, null, ItemTracker.TargetZoneType.None, context2.InventoryMessage);
				}
			}
		}
		else
		{
			if (!context2.LastInventoryState || context2.Pointer == null)
			{
				context2.LastInventoryState = true;
				if (context2.Pointer != null)
				{
					context2.Pointer.Dispose();
				}
				if (!silent)
				{
					context2.Pointer = new ItemPointer(context2.ContainerItem, null, ItemTracker.TargetZoneType.None, context2.ContainerMessage);
				}
			}
			if (SingletonBehaviour<Inventory>.Instance.ItemContainerRegistry.ActiveContainer == context2.TargetContainer)
			{
				return true;
			}
		}
		return false;
	}
}
