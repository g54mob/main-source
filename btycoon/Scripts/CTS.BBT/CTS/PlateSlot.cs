using CTS.BBT;
using UnityEngine;

namespace CTS
{
	public sealed class PlateSlot : ItemSlot
	{
		public OrderPlate Plate { get; private set; }

		public void SetPlate(OrderPlate plate)
		{
			Plate = plate;
		}

		protected override void OnSetUnused()
		{
			if ((bool)base.InSlot)
			{
				base.InSlot.GetComponentInChildren<Collider>(includeInactive: true).enabled = true;
			}
			base.OnSetUnused();
		}

		protected override void OnSetUsed(Item item)
		{
			base.OnSetUsed(item);
			if ((bool)base.InSlot)
			{
				base.InSlot.GetComponentInChildren<Collider>(includeInactive: true).enabled = false;
			}
		}
	}
}
