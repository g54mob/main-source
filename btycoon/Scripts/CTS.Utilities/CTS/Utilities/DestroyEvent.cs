using System;
using CTS.Core;

namespace CTS.Utilities
{
	public class DestroyEvent : CTSBehaviour
	{
		public event Action Destroyed;

		private void OnDestroy()
		{
			this.Destroyed?.Invoke();
		}
	}
}
