using DV.CabControls;
using DV.Game.Tutorial.ItemTracker;
using DV.InventorySystem;
using DV.Utils;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class EquipAnyItemStep : AQuickTutorialStep
	{
		private string[] prefabNames;

		private ItemBase[] availableItems;

		private ItemPointer pointer;

		public EquipAnyItemStep(string[] prefabNames, string message, bool shouldRecheck = true)
			: base(message, null, Vector3.zero, shouldRecheck)
		{
			this.prefabNames = prefabNames;
		}

		protected override void InternalMakeCurrent()
		{
			base.InternalMakeCurrent();
			availableItems = SingletonBehaviour<Inventory>.Instance.GetAllItemsByPrefabNames(prefabNames);
		}

		public override void ShowVisual()
		{
			if (pointer != null)
			{
				pointer.Dispose();
			}
			pointer = new ItemPointer(availableItems, null, ItemTracker.TargetZoneType.Hands, Message.GetMessage(GetVerb()), localizeMessage: false);
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
			if (spec == null)
			{
				return false;
			}
			string[] array = prefabNames;
			foreach (string text in array)
			{
				if (spec.ItemPrefabName == text)
				{
					return true;
				}
			}
			return false;
		}

		protected override bool InternalCheck()
		{
			if (!CheckSpec(SingletonBehaviour<TutorialHelper>.Instance.GrabbedInventoryItemLeftHand))
			{
				return CheckSpec(SingletonBehaviour<TutorialHelper>.Instance.GrabbedInventoryItemRightHand);
			}
			return true;
		}
	}
}
