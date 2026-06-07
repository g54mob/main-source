using Bolt;
using DV.CabControls;
using DV.Game.Tutorial;
using DV.Game.Tutorial.ItemTracker;
using DV.InventorySystem;
using DV.Utils;
using Ludiq;
using UnityEngine;

[UnitTitle("Drop Item")]
[UnitSubtitle("Wait for player to drop a specified item")]
[UnitCategory("Interaction")]
[TypeIcon(typeof(SphereCollider))]
public class ItemDropUnit : GenericWaitForCondition
{
	private class Context
	{
		public GameObject ItemObject;

		public InventoryItemSpec TargetSpec;

		public ItemBase ItemBase;

		public bool OkIfDropped;

		public bool WasInInventoryOrGrabbed;

		public string Message;

		public ItemPointer Pointer;

		public GameObject DropHint;

		public bool ControlHints;
	}

	[DoNotSerialize]
	public ValueInput targetItem;

	[DoNotSerialize]
	public ValueInput okIfDropped;

	[DoNotSerialize]
	public ValueInput dropHint;

	[LocalizedValue]
	[DoNotSerialize]
	public ValueInput messageValue;

	[DoNotSerialize]
	public ValueInput showControlHints;

	protected override string DoneFieldName => "Dropped";

	protected override void InternalDefinition()
	{
		targetItem = ValueInput<GameObject>("Item", null);
		okIfDropped = ValueInput("OK if dropped", @default: true);
		dropHint = ValueInput<GameObject>("Drop Hint", null);
		messageValue = ValueInput("Message", string.Empty);
		showControlHints = ValueInput("Control Hints", @default: true);
	}

	public override object PrepareContext(Flow flow)
	{
		Context obj = new Context
		{
			ItemObject = flow.GetValue<GameObject>(targetItem),
			TargetSpec = flow.GetValue<GameObject>(targetItem).GetComponentInChildren<InventoryItemSpec>()
		};
		obj.ItemBase = obj.ItemObject.GetComponent<ItemBase>();
		obj.OkIfDropped = flow.GetValue<bool>(okIfDropped);
		obj.WasInInventoryOrGrabbed = false;
		obj.Message = flow.GetValue<string>(messageValue);
		obj.DropHint = flow.GetValue<GameObject>(dropHint);
		obj.ControlHints = flow.GetValue<bool>(showControlHints);
		return obj;
	}

	public override void Initialize(Flow flow, object context, bool silent = false)
	{
		base.Initialize(flow, context, silent);
		Context context2 = (Context)context;
		if (!silent)
		{
			context2.Pointer = new ItemPointer(context2.ItemBase, null, ItemTracker.TargetZoneType.World, context2.Message, localizeMessage: true, worldHint: context2.DropHint?.transform, showHints: context2.ControlHints);
		}
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
		bool flag = SingletonBehaviour<Inventory>.Instance.Contains(context2.ItemObject, includeDropped: false);
		bool flag2 = context2.ItemBase.IsGrabbed();
		if (flag || flag2)
		{
			context2.WasInInventoryOrGrabbed = true;
		}
		if ((context2.WasInInventoryOrGrabbed || context2.OkIfDropped) && !flag)
		{
			return !flag2;
		}
		return false;
	}
}
