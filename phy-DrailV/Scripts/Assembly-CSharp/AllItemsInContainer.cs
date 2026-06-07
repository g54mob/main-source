using System.Collections.Generic;
using Bolt;
using DV.CabControls;
using DV.Game.Tutorial;
using DV.Game.Tutorial.ItemTracker;
using DV.InventorySystem;
using Ludiq;
using UnityEngine;

[UnitCategory("Items")]
[UnitSubtitle("Wait for all of the items to be in a given container")]
[UnitTitle("All Items In Container")]
[TypeIcon(typeof(BoxCollider))]
public class AllItemsInContainer : GenericWaitForCondition
{
	private class Context
	{
		public ItemTracker.TargetZoneType ZoneType;

		public bool PassIfZoneFull;

		public AItemContainer Container;

		public ItemBase ContainerItem;

		public ItemBase[] Items;

		public ItemBase LastItem;

		public bool LastInInventory;

		public bool Inverted;

		public bool PlayerBoundContainer;

		public bool ShowControlHints;

		public List<ItemBase> InInventory = new List<ItemBase>();

		public List<ItemBase> InContainer = new List<ItemBase>();

		public List<ItemBase> OutsideInventory = new List<ItemBase>();

		public string Message;

		public string PickUpContainerMessage;

		public GameObject CurrentTarget;

		public ItemPointer ItemPointer;

		public bool CollectContainerMode;
	}

	[DoNotSerialize]
	public ValueInput containerReference;

	[DoNotSerialize]
	public ValueInput targetZoneValue;

	[DoNotSerialize]
	public ValueInput passIfZoneFull;

	[DoNotSerialize]
	public ValueInput[] itemsReference;

	[DoNotSerialize]
	public ValueInput itemsArrayRefererence;

	[DoNotSerialize]
	public ValueInput playerHoldsContainer;

	[DoNotSerialize]
	public ValueInput invertedMode;

	[LocalizedValue]
	[DoNotSerialize]
	public ValueInput messageValue;

	[LocalizedValue]
	[DoNotSerialize]
	public ValueInput messagePickUpContainer;

	[DoNotSerialize]
	public ValueInput showControlHints;

	[UnitHeaderInspectable("Array mode")]
	[Inspectable]
	public bool ArrayMode { get; set; }

	[Inspectable]
	[UnitHeaderInspectable("Count")]
	public int Count { get; set; } = 1;

	protected override void InternalDefinition()
	{
		containerReference = ValueInput<GameObject>("Container", null);
		targetZoneValue = ValueInput("Target zone", ItemTracker.TargetZoneType.Container);
		passIfZoneFull = ValueInput("Pass if zone full", @default: true);
		playerHoldsContainer = ValueInput("Player-bound", @default: true);
		invertedMode = ValueInput("Inverted", @default: false);
		if (ArrayMode)
		{
			itemsArrayRefererence = ValueInput<GameObject[]>("Items", null);
		}
		else
		{
			int num = Mathf.Clamp(Count, 1, 16);
			itemsReference = new ValueInput[num];
			for (int i = 0; i < num; i++)
			{
				itemsReference[i] = ValueInput<GameObject>("Item " + (i + 1), null);
			}
		}
		messageValue = ValueInput("Message", string.Empty);
		messagePickUpContainer = ValueInput("Pick Up Cont. msg", string.Empty);
		showControlHints = ValueInput("Control Hints", @default: true);
	}

	public override object PrepareContext(Flow flow)
	{
		base.PrepareContext(flow);
		GameObject[] array = (ArrayMode ? flow.GetValue<GameObject[]>(itemsArrayRefererence) : null);
		int num = ((!ArrayMode) ? Count : ((array != null) ? array.Length : 0));
		Context context = new Context();
		context.Container = flow.GetValue<GameObject>(containerReference)?.GetComponent<AItemContainer>();
		context.ZoneType = flow.GetValue<ItemTracker.TargetZoneType>(targetZoneValue);
		context.PassIfZoneFull = flow.GetValue<bool>(passIfZoneFull);
		context.ContainerItem = context.Container?.GetComponent<ItemBase>();
		context.PlayerBoundContainer = flow.GetValue<bool>(playerHoldsContainer);
		context.Items = new ItemBase[num];
		context.Inverted = flow.GetValue<bool>(invertedMode);
		context.ShowControlHints = flow.GetValue<bool>(showControlHints);
		for (int i = 0; i < num; i++)
		{
			GameObject obj = (ArrayMode ? array[i] : flow.GetValue<GameObject>(itemsReference[i]));
			context.Items[i] = obj?.GetComponent<ItemBase>();
			if ((bool)context.Items[i] && context.LastItem == null)
			{
				context.LastItem = context.Items[i];
			}
			if ((bool)context.Items[i] && context.Items[i].IsBoundToPlayer())
			{
				context.InInventory.Add(context.Items[i]);
			}
		}
		context.Message = flow.GetValue<string>(messageValue);
		context.PickUpContainerMessage = flow.GetValue<string>(messagePickUpContainer);
		return context;
	}

	public override bool EarlyOutCheck(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		if (context2.Container == null && context2.ZoneType == ItemTracker.TargetZoneType.Container)
		{
			Debug.LogError("Container is not assigned, or the assigned object is not an AItemContainer, skipping.");
			return true;
		}
		return base.EarlyOutCheck(flow, context, silent: true);
	}

	public override void Deinitialize(Flow flow, object context, bool silent = false)
	{
		base.Deinitialize(flow, context, silent);
		Context context2 = (Context)context;
		if (context2.ItemPointer != null)
		{
			context2.ItemPointer.Dispose();
			context2.ItemPointer = null;
		}
	}

	private void UpdateState(Flow flow, Context c, bool silent)
	{
		if (silent)
		{
			return;
		}
		if (c.ZoneType == ItemTracker.TargetZoneType.Container)
		{
			if (!c.PlayerBoundContainer || c.ContainerItem.IsBoundToPlayer())
			{
				if (c.ItemPointer == null || c.CollectContainerMode)
				{
					if (c.ItemPointer != null)
					{
						c.ItemPointer.Dispose();
					}
					c.ItemPointer = new ItemPointer(c.Items, c.Container, c.ZoneType, c.Message, localizeMessage: true, c.ShowControlHints);
					c.CollectContainerMode = false;
				}
			}
			else if (c.ItemPointer == null || !c.CollectContainerMode)
			{
				if (c.ItemPointer != null)
				{
					c.ItemPointer.Dispose();
				}
				c.ItemPointer = new ItemPointer(c.ContainerItem, null, ItemTracker.TargetZoneType.None, c.PickUpContainerMessage, localizeMessage: true, c.ShowControlHints);
				c.CollectContainerMode = true;
			}
		}
		else if (c.ItemPointer == null)
		{
			c.ItemPointer = new ItemPointer(c.Items, null, c.ZoneType, c.Message, localizeMessage: true, c.ShowControlHints);
		}
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		UpdateState(flow, context2, silent);
		if (context2.ZoneType == ItemTracker.TargetZoneType.Container && context2.PlayerBoundContainer && !context2.ContainerItem.IsBoundToPlayer())
		{
			return context2.Inverted;
		}
		ItemBase[] items = context2.Items;
		foreach (ItemBase itemBase in items)
		{
			if ((bool)itemBase && !ItemTracker.IsItemInZone(itemBase, context2.ZoneType, context2.Container) && (!context2.PassIfZoneFull || ItemTracker.FindFreeSlotInZone(context2.ZoneType, out var _, context2.Container)))
			{
				return context2.Inverted;
			}
		}
		return !context2.Inverted;
	}
}
