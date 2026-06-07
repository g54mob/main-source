using DV.CabControls;
using DV.Game.Tutorial.ItemTracker;
using DV.InventorySystem;
using DV.Utils;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class DropItemStep : AQuickTutorialStep
	{
		public delegate GameObject ItemProvider();

		private readonly ItemProvider provider;

		private GameObject item;

		private ItemBase itemBase;

		private ItemPointer pointer;

		public DropItemStep(GameObject item, AQuickTutorialMessage message, Transform attentionPoint = null, Vector3 attentionOffset = default(Vector3), bool shouldRecheck = true)
			: base(message, attentionPoint, attentionOffset, shouldRecheck)
		{
			this.item = item;
			itemBase = item.GetComponent<ItemBase>();
		}

		public DropItemStep(ItemProvider provider, AQuickTutorialMessage message, Transform attentionPoint = null, Vector3 attentionOffset = default(Vector3), bool shouldRecheck = true)
			: base(message, attentionPoint, attentionOffset, shouldRecheck)
		{
			this.provider = provider;
		}

		protected override void InternalMakeCurrent()
		{
			if (provider != null)
			{
				item = provider();
				itemBase = item.GetComponent<ItemBase>();
			}
			base.InternalMakeCurrent();
		}

		public override void ShowVisual()
		{
			string message = Message.GetMessage(GetVerb());
			pointer = new ItemPointer(item, null, ItemTracker.TargetZoneType.None, message, localizeMessage: false);
		}

		protected override void HideVisual()
		{
			if (pointer != null)
			{
				pointer.Dispose();
				pointer = null;
			}
		}

		protected override bool InternalCheck()
		{
			bool num = SingletonBehaviour<Inventory>.Instance.Contains(item, includeDropped: false);
			bool flag = itemBase.IsGrabbed();
			if (!num)
			{
				return !flag;
			}
			return false;
		}
	}
}
