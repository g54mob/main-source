using JUTPSEditor.JUHeader;
using Mirror;
using UnityEngine;

namespace JUTPS.ItemSystem
{
	public class Item : NetworkBehaviour
	{
		[JUHeader("Item Setting")]
		public string ItemFilterTag = "General";

		public Sprite ItemIcon;

		public bool Unlocked;

		public int ItemQuantity;

		public int MaxItemQuantity = 1;

		public string ItemName;

		public int ItemSwitchID;

		public virtual void UseItem()
		{
			if (ItemQuantity > 0)
			{
				RemoveItem();
			}
		}

		public virtual void RemoveItem()
		{
			ItemQuantity--;
			ItemQuantity = Mathf.Clamp(ItemQuantity, 0, MaxItemQuantity);
			if (ItemQuantity == 0)
			{
				Unlocked = false;
			}
		}

		public virtual void AddItem()
		{
			ItemQuantity++;
			ItemQuantity = Mathf.Clamp(ItemQuantity, 0, MaxItemQuantity);
			if (ItemQuantity > 0)
			{
				Unlocked = true;
			}
		}

		public override bool Weaved()
		{
			return true;
		}
	}
}
