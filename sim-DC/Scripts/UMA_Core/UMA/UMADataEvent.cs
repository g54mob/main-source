using System;
using UnityEngine.Events;

namespace UMA
{
	[Serializable]
	public class UMADataEvent : UnityEvent<UMAData>
	{
		public UMADataEvent()
		{
		}

		public UMADataEvent(UMADataEvent source)
		{
		}

		public void AddAction(Action<UMAData> action)
		{
		}

		public void RemoveAction(Action<UMAData> action)
		{
		}
	}
}
