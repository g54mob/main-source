using System;
using Bolt;
using DV;
using DV.CabControls;
using DV.Game.Tutorial;
using DV.Game.Tutorial.ItemTracker;
using DV.InventorySystem;
using DV.Utils;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(BoxCollider))]
[UnitSubtitle("Grab the comms radio and set it to a specific mode")]
[UnitCategory("Interaction")]
[UnitTitle("Comms Radio mode")]
public class CommsRadioModeUnit : GenericWaitForCondition
{
	private enum Phase
	{
		P0_Start = 0,
		P1_WaitForComms = 1,
		P2_WaitForMode = 2
	}

	private class Context
	{
		public ItemBase CommsInventoryItem;

		public CommsRadioController Comms;

		public CommsRadioModesEnum TargetMode;

		public Type ModeType;

		public string ItemMessage;

		public string ModeMessage;

		public ItemPointer Pointer;

		public Phase Phase;
	}

	[DoNotSerialize]
	[LocalizedValue]
	public ValueInput itemMessageValue;

	[DoNotSerialize]
	[LocalizedValue]
	public ValueInput modeMessageValue;

	[DoNotSerialize]
	public ValueInput targetModeValue;

	protected override void InternalDefinition()
	{
		itemMessageValue = ValueInput("Take Radio Msg", string.Empty);
		modeMessageValue = ValueInput("Set Mode Msg", string.Empty);
		targetModeValue = ValueInput("Mode", CommsRadioModesEnum.JunctionRemoteLogic);
	}

	private CommsRadioController GetComms(InventoryItemSpec spec)
	{
		if (spec == null)
		{
			return null;
		}
		return spec.GetComponentInChildren<CommsRadioController>();
	}

	public override object PrepareContext(Flow flow)
	{
		Context obj = new Context
		{
			ItemMessage = flow.GetValue<string>(itemMessageValue),
			ModeMessage = flow.GetValue<string>(modeMessageValue),
			TargetMode = flow.GetValue<CommsRadioModesEnum>(targetModeValue)
		};
		obj.ModeType = obj.TargetMode.ToType();
		obj.CommsInventoryItem = SingletonBehaviour<Inventory>.Instance.GetFirstItemByPrefabName("CommsRadio");
		return obj;
	}

	public override bool EarlyOutCheck(Flow flow, object context, bool silent = false)
	{
		if (GetComms(SingletonBehaviour<TutorialHelper>.Instance.GrabbedInventoryItemLeftHand) != null)
		{
			return true;
		}
		if (GetComms(SingletonBehaviour<TutorialHelper>.Instance.GrabbedInventoryItemRightHand) != null)
		{
			return true;
		}
		return false;
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		if (context2.Phase <= Phase.P1_WaitForComms)
		{
			if (context2.Comms == null)
			{
				context2.Comms = GetComms(SingletonBehaviour<TutorialHelper>.Instance.GrabbedInventoryItemLeftHand);
				if (context2.Comms == null)
				{
					context2.Comms = GetComms(SingletonBehaviour<TutorialHelper>.Instance.GrabbedInventoryItemRightHand);
				}
			}
			if ((bool)context2.Comms)
			{
				if (!silent)
				{
					if (context2.Pointer != null)
					{
						context2.Pointer.Dispose();
						context2.Pointer = null;
					}
					if (!string.IsNullOrEmpty(context2.ModeMessage))
					{
						SingletonBehaviour<TutorialHelper>.Instance.ShowTutorialFloatie(context2.ModeMessage, null);
					}
					else
					{
						SingletonBehaviour<TutorialHelper>.Instance.HideTutorialFloatie();
					}
				}
				context2.Phase = Phase.P2_WaitForMode;
			}
			else if (context2.Phase == Phase.P0_Start)
			{
				if (!silent && !string.IsNullOrEmpty(context2.ItemMessage))
				{
					if (context2.Pointer != null)
					{
						context2.Pointer.Dispose();
					}
					context2.Pointer = new ItemPointer(context2.CommsInventoryItem, null, ItemTracker.TargetZoneType.Hands, context2.ItemMessage);
				}
				context2.Phase = Phase.P1_WaitForComms;
			}
		}
		if (context2.Phase == Phase.P2_WaitForMode)
		{
			if (context2.Pointer != null)
			{
				context2.Pointer.Dispose();
				context2.Pointer = null;
			}
			if (context2.Comms.CurrentActiveMode != null && context2.Comms.CurrentActiveMode.GetType() == context2.ModeType)
			{
				return true;
			}
		}
		return false;
	}

	public override void Deinitialize(Flow flow, object context, bool silent = false)
	{
		base.Deinitialize(flow, context, silent);
		Context context2 = (Context)context;
		if (!silent)
		{
			if (context2.Phase == Phase.P1_WaitForComms && !string.IsNullOrEmpty(context2.ItemMessage))
			{
				SingletonBehaviour<TutorialHelper>.Instance.HideTutorialFloatie();
			}
			else if (context2.Phase == Phase.P2_WaitForMode && !string.IsNullOrEmpty(context2.ModeMessage))
			{
				SingletonBehaviour<TutorialHelper>.Instance.HideTutorialFloatie();
			}
		}
		if (context2.Pointer != null)
		{
			context2.Pointer.Dispose();
			context2.Pointer = null;
		}
	}
}
