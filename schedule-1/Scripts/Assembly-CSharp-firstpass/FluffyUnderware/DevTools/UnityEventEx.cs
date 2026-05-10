using System;
using System.Reflection;
using UnityEngine.Events;

namespace FluffyUnderware.DevTools
{
	[Serializable]
	public class UnityEventEx<T0> : UnityEvent<T0>
	{
		private object mCallerList;

		private MethodInfo mCallsCount;

		private int mCount;

		public void AddListenerOnce(UnityAction<T0> call)
		{
		}

		public bool HasListeners()
		{
			return false;
		}

		public void CheckForListeners()
		{
		}
	}
}
