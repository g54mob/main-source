using System;
using UnityEngine;

namespace CTS.Utilities
{
	public class ActivationEvents : MonoBehaviour
	{
		public event Action Enabled;

		public event Action Disabled;

		public event Action<bool> ActiveStatusChanged;

		private void OnEnable()
		{
			this.Enabled?.Invoke();
			this.ActiveStatusChanged?.Invoke(obj: true);
		}

		private void OnDisable()
		{
			this.Disabled?.Invoke();
			this.ActiveStatusChanged?.Invoke(obj: false);
		}
	}
}
