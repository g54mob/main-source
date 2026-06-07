using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace UMA
{
	[Serializable]
	public class UMALabelsEvent : UnityEvent<List<string>>
	{
		public UMALabelsEvent()
		{
		}

		public UMALabelsEvent(UMALabelsEvent source)
		{
		}

		public void AddAction(Action<List<string>> action)
		{
		}

		public void RemoveAction(Action<List<string>> action)
		{
		}
	}
}
