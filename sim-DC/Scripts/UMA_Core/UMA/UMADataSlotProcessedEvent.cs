using System;
using UnityEngine.Events;

namespace UMA
{
	[Serializable]
	public class UMADataSlotProcessedEvent : UnityEvent<UMAData, SlotData>
	{
		public UMADataSlotProcessedEvent()
		{
		}

		public UMADataSlotProcessedEvent(UMADataSlotProcessedEvent source)
		{
		}
	}
}
