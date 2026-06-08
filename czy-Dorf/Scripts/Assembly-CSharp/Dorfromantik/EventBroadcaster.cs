using System;
using System.Collections.Generic;

namespace Dorfromantik
{
	public class EventBroadcaster<T>
	{
		private const int ArrayCapacity = 5000;

		private List<Action<T>[]> subscribedActions = new List<Action<T>[]> { new Action<T>[5000] };

		private int currentSubscriberArrayIndex;

		private int currentSubscriberListIndex;

		public int ListenerCount => currentSubscriberListIndex * 5000 + currentSubscriberArrayIndex;

		public void BroadcastToAllListeners(T parameter)
		{
			for (int i = 0; i < subscribedActions.Count; i++)
			{
				for (int j = 0; j < LastArrayIndex(i); j++)
				{
					subscribedActions[i][j]?.Invoke(parameter);
				}
			}
		}

		private int LastArrayIndex(int arrayIndexInList)
		{
			if (arrayIndexInList == subscribedActions.Count - 1)
			{
				return currentSubscriberArrayIndex;
			}
			return 5000;
		}
	}
}
