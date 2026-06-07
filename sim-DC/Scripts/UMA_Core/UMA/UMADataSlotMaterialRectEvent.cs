using System;
using UnityEngine;
using UnityEngine.Events;

namespace UMA
{
	[Serializable]
	public class UMADataSlotMaterialRectEvent : UnityEvent<UMAData, SlotData, Material, Rect>
	{
		public UMADataSlotMaterialRectEvent()
		{
		}

		public UMADataSlotMaterialRectEvent(UMADataSlotMaterialRectEvent source)
		{
		}
	}
}
