using System;
using UnityEngine.Events;

namespace UMA
{
	[Serializable]
	public class UMAExpressionEvent : UnityEvent<UMAData, string, float>
	{
		public UMAExpressionEvent()
		{
		}

		public UMAExpressionEvent(UMAExpressionEvent source)
		{
		}
	}
}
