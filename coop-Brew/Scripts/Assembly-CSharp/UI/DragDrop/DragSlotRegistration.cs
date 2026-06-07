using System;
using InventorySystem;
using UnityEngine.UIElements;

namespace UI.DragDrop
{
	public class DragSlotRegistration
	{
		public string InventoryId;

		public int SlotIndex;

		public VisualElement SlotElement;

		public VisualElement IconElement;

		public Func<InventorySlot> GetSlotData;

		public Action<int, int> RequestSwap;

		public Action<int> OnClickFallback;

		public Func<Item, bool> CanAcceptItem;

		public Action<int, int> AcceptFromPlayer;

		public Action<int, int> SendToPlayer;
	}
}
