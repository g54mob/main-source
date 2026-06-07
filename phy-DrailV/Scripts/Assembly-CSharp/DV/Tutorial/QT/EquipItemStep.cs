using System.Linq;
using DV.CabControls;
using DV.Game.Tutorial.ItemTracker;
using DV.Utils;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class EquipItemStep : AQuickTutorialStep
	{
		public delegate InventoryItemSpec ItemProvider();

		public delegate bool AdditionalCheck(InventoryItemSpec spec);

		private readonly string[] prefabNames;

		private InventoryItemSpec specificItem;

		private readonly ItemProvider provider;

		private readonly AdditionalCheck check;

		private readonly ItemBase[] availableItems;

		private ItemPointer pointer;

		public InventoryItemSpec EquippedItem { get; private set; }

		public EquipItemStep(string prefabName, ItemBase[] availableItems, string message, AdditionalCheck check = null, bool shouldRecheck = true)
			: base(message, null, Vector3.zero, shouldRecheck)
		{
			prefabNames = new string[1] { prefabName };
			this.check = check;
			this.availableItems = availableItems;
		}

		public EquipItemStep(string[] prefabNames, ItemBase[] availableItems, string message, AdditionalCheck check = null, bool shouldRecheck = true)
			: base(message, null, Vector3.zero, shouldRecheck)
		{
			this.prefabNames = prefabNames;
			this.check = check;
			this.availableItems = availableItems;
		}

		public EquipItemStep(InventoryItemSpec specificItem, string message, AdditionalCheck check = null, Vector3 offset = default(Vector3), bool shouldRecheck = true)
			: base(message, specificItem.transform, offset, shouldRecheck)
		{
			this.specificItem = specificItem;
			this.check = check;
			availableItems = new ItemBase[1] { this.specificItem.GetComponent<ItemBase>() };
		}

		public EquipItemStep(ItemProvider provider, string message, AdditionalCheck check = null, Vector3 offset = default(Vector3), bool shouldRecheck = true)
			: base(message, null, offset, shouldRecheck)
		{
			this.provider = provider;
			this.check = check;
			availableItems = new ItemBase[1];
		}

		protected override void InternalMakeCurrent()
		{
			if (provider != null)
			{
				specificItem = provider();
				availableItems[0] = specificItem.GetComponent<ItemBase>();
				AttentionPoint = specificItem.transform;
			}
			base.InternalMakeCurrent();
			EquippedItem = null;
		}

		public override void ShowVisual()
		{
			string message = Message.GetMessage(GetVerb());
			pointer = new ItemPointer(availableItems, null, ItemTracker.TargetZoneType.Hands, message, localizeMessage: false);
		}

		protected override void HideVisual()
		{
			if (pointer != null)
			{
				pointer.Dispose();
				pointer = null;
			}
		}

		private bool CheckSpec(InventoryItemSpec spec)
		{
			if (specificItem != null)
			{
				return spec == specificItem;
			}
			if (spec != null && prefabNames.Contains(spec.ItemPrefabName))
			{
				return check?.Invoke(spec) ?? true;
			}
			return false;
		}

		protected override bool InternalCheck()
		{
			if (EquippedItem == null)
			{
				if (CheckSpec(SingletonBehaviour<TutorialHelper>.Instance.GrabbedInventoryItemLeftHand))
				{
					EquippedItem = SingletonBehaviour<TutorialHelper>.Instance.GrabbedInventoryItemLeftHand;
					return true;
				}
				if (CheckSpec(SingletonBehaviour<TutorialHelper>.Instance.GrabbedInventoryItemRightHand))
				{
					EquippedItem = SingletonBehaviour<TutorialHelper>.Instance.GrabbedInventoryItemRightHand;
					return true;
				}
				return false;
			}
			return true;
		}
	}
}
