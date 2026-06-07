using System;
using UnityEngine.Events;

namespace UMA
{
	[Serializable]
	public class UMADataSlotEvent : UnityEvent<UMAData, SlotData>
	{
		public UMADataSlotEvent()
		{
		}

		public UMADataSlotEvent(UMADataSlotEvent source)
		{
		}
	}
}
