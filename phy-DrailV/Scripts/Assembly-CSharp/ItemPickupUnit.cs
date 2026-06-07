using Bolt;
using DV.CabControls;
using DV.Game.Tutorial;
using DV.Game.Tutorial.ItemTracker;
using DV.Utils;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(SphereCollider))]
[UnitSubtitle("Wait for player to grab a specified item")]
[UnitCategory("Interaction")]
[UnitTitle("Grab Item")]
public class ItemPickupUnit : GenericWaitForCondition
{
	private class Context
	{
		public ItemBase Item;

		public ItemPointer Pointer;

		public string Message;

		public bool AcceptInInventory;

		public bool Invert;
	}

	[DoNotSerialize]
	public ValueInput targetItem;

	[DoNotSerialize]
	public ValueInput acceptInInventory;

	[DoNotSerialize]
	public ValueInput invertedValue;

	[DoNotSerialize]
	[LocalizedValue]
	public ValueInput nonVRMessageValue;

	[DoNotSerialize]
	[LocalizedValue]
	public ValueInput VRMessageValue;

	[Inspectable]
	[UnitHeaderInspectable("NonVR/VR")]
	public bool SeparateMessages { get; set; }

	protected override string DoneFieldName => "Grabbed";

	protected override void InternalDefinition()
	{
		targetItem = ValueInput<GameObject>("Item", null);
		acceptInInventory = ValueInput("OK in inventory", @default: false);
		invertedValue = ValueInput("Invert condition", @default: false);
		if (SeparateMessages)
		{
			nonVRMessageValue = ValueInput<string>("Non-VR msg", null);
			VRMessageValue = ValueInput<string>("VR msg", null);
		}
		else
		{
			nonVRMessageValue = ValueInput<string>("Message", null);
		}
		Requirement(targetItem, inputTrigger);
	}

	public override object PrepareContext(Flow flow)
	{
		Context context = new Context();
		context.Item = flow.GetValue<GameObject>(targetItem).GetComponentInChildren<ItemBase>();
		context.AcceptInInventory = flow.GetValue<bool>(acceptInInventory);
		context.Invert = flow.GetValue<bool>(invertedValue);
		if (SeparateMessages)
		{
			context.Message = flow.GetValue<string>(VRManager.IsVREnabled() ? VRMessageValue : nonVRMessageValue);
		}
		else
		{
			context.Message = flow.GetValue<string>(nonVRMessageValue);
		}
		context.Pointer = null;
		return context;
	}

	public override void Initialize(Flow flow, object context, bool silent = false)
	{
		base.Initialize(flow, context, silent);
		Context context2 = (Context)context;
		if (!silent)
		{
			context2.Pointer = new ItemPointer(context2.Item, null, (!context2.AcceptInInventory) ? ItemTracker.TargetZoneType.Hands : ItemTracker.TargetZoneType.None, context2.Message);
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

	public override bool EarlyOutCheck(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		bool flag = context2.Item.IsBoundToPlayer(includeInStashedContainer: true);
		if (context2.AcceptInInventory && flag)
		{
			return !context2.Invert;
		}
		return base.EarlyOutCheck(flow, context, silent);
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		if (context2.AcceptInInventory && context2.Item.IsBoundToPlayer())
		{
			return !context2.Invert;
		}
		bool flag = SingletonBehaviour<TutorialHelper>.Instance.GrabbedItemLeftHand == context2.Item || SingletonBehaviour<TutorialHelper>.Instance.GrabbedItemRightHand == context2.Item;
		if (!context2.Invert)
		{
			return flag;
		}
		return !flag;
	}
}
