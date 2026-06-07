using Bolt;
using DV.Game.Tutorial.ItemTracker;
using DV.InventorySystem;
using DV.Utils;
using Ludiq;
using UnityEngine;

[UnitTitle("Pick Up Items")]
[TypeIcon(typeof(SphereCollider))]
[UnitSubtitle("Wait for player to pick up all the items")]
[UnitCategory("Interaction")]
public class PickUpAllItemsUnit : GenericWaitForCondition
{
	private class Context
	{
		public GameObject[] Items;

		public InventoryItemSpec[] Specs;

		public bool AcceptInInventory;

		public bool Inverted;

		public bool AnyOne;

		public GameObject LastAnchor;

		public string Message;

		public ItemPointer Pointer;

		public bool CheckItem(int index, out bool inInventory, out bool inHands)
		{
			if (Items[index] == null)
			{
				inInventory = false;
				inHands = false;
				return true;
			}
			inInventory = SingletonBehaviour<Inventory>.Instance.Contains(Items[index], includeDropped: false);
			inHands = SingletonBehaviour<TutorialHelper>.Instance.GrabbedInventoryItemLeftHand == Specs[index] || SingletonBehaviour<TutorialHelper>.Instance.GrabbedInventoryItemRightHand == Specs[index];
			bool flag = inHands || (AcceptInInventory & inInventory);
			if (!Inverted)
			{
				return flag;
			}
			return !flag;
		}
	}

	private const int MAX_ITEMS = 16;

	[DoNotSerialize]
	public ValueInput[] targetItem;

	[DoNotSerialize]
	public ValueInput acceptInInventory;

	[DoNotSerialize]
	public ValueInput invertedValue;

	[DoNotSerialize]
	public ValueInput anyValue;

	[DoNotSerialize]
	public ValueInput messageValue;

	[UnitHeaderInspectable("Count")]
	[Inspectable]
	public int Count { get; set; } = 1;

	protected override string DoneFieldName => "Picked";

	protected override void InternalDefinition()
	{
		int num = Mathf.Clamp(Count, 1, 16);
		targetItem = new ValueInput[num];
		for (int i = 0; i < num; i++)
		{
			targetItem[i] = ValueInput<GameObject>($"Item {i + 1}");
		}
		messageValue = ValueInput("Message", string.Empty);
		acceptInInventory = ValueInput("OK in inventory", @default: false);
		invertedValue = ValueInput("Invert condition", @default: false);
		anyValue = ValueInput("One is enough", @default: false);
		for (int j = 0; j < num; j++)
		{
			Requirement(targetItem[j], inputTrigger);
		}
	}

	public override object PrepareContext(Flow flow)
	{
		Context context = new Context();
		context.Items = new GameObject[targetItem.Length];
		context.Specs = new InventoryItemSpec[targetItem.Length];
		for (int i = 0; i < targetItem.Length; i++)
		{
			context.Items[i] = flow.GetValue<GameObject>(targetItem[i]);
			if (context.Items[i] == null)
			{
				Debug.LogWarning(string.Format("There's a null item in the list of {0} at index {1}, possibly an issue.", "PickUpAllItemsUnit", i));
			}
			else
			{
				context.Specs[i] = context.Items[i].GetComponentInChildren<InventoryItemSpec>();
			}
		}
		context.AcceptInInventory = flow.GetValue<bool>(acceptInInventory);
		context.Inverted = flow.GetValue<bool>(invertedValue);
		context.AnyOne = flow.GetValue<bool>(anyValue);
		context.Message = flow.GetValue<string>(messageValue);
		return context;
	}

	public override void CleanupContext(Flow flow, object context)
	{
		base.CleanupContext(flow, context);
		Context context2 = (Context)context;
		if (context2.Pointer != null)
		{
			context2.Pointer.Dispose();
		}
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		for (int i = 0; i < context2.Items.Length; i++)
		{
			if (!context2.CheckItem(i, out var _, out var _))
			{
				if (!silent && context2.LastAnchor != context2.Items[i])
				{
					context2.LastAnchor = context2.Items[i];
					if (context2.Pointer != null)
					{
						context2.Pointer.Dispose();
					}
					context2.Pointer = new ItemPointer(context2.Items[i], null, ItemTracker.TargetZoneType.None, context2.Message);
				}
				if (!context2.AnyOne)
				{
					return false;
				}
			}
			else if (context2.AnyOne)
			{
				return true;
			}
		}
		return !context2.AnyOne;
	}
}
