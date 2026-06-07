using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace UMA
{
	[Serializable]
	public class UMASlotsEvent : UnityEvent<List<SlotData>>
	{
		public UMASlotsEvent()
		{
		}

		public UMASlotsEvent(UMASlotsEvent source)
		{
		}

		public void AddAction(Action<List<SlotData>> action)
		{
		}

		public void RemoveAction(Action<List<SlotData>> action)
		{
		}
	}
}
