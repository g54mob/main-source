using CTS.Core.Utilities;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class DecorationSlots : MonoBehaviour
	{
		[SerializeField]
		private ItemSlot[] _itemSlots;

		public bool HasItemSlots => _itemSlots.Length != 0;

		public bool TryGetClosestSlot(Vector3 p_pos, out ItemSlot p_slot)
		{
			p_slot = null;
			if (!HasItemSlots)
			{
				return false;
			}
			float num = float.MaxValue;
			ItemSlot[] itemSlots = _itemSlots;
			foreach (ItemSlot itemSlot in itemSlots)
			{
				if (!itemSlot.InUse)
				{
					float sqrMagnitude = (itemSlot.transform.position - p_pos).ToHorizontal2D().sqrMagnitude;
					if (sqrMagnitude < num)
					{
						num = sqrMagnitude;
						p_slot = itemSlot;
					}
				}
			}
			return p_slot;
		}

		[Button(null, EButtonEnableMode.Always)]
		private void FindItemSlots()
		{
			_itemSlots = GetComponentsInChildren<ItemSlot>();
		}
	}
}
