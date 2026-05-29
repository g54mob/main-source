using System;

namespace CTS.Core
{
	public class ObjectStateEvent : CTSBehaviour
	{
		public event Action Enabled;

		public event Action Disabled;

		public event Action<bool> ActiveStateChanged;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			this.Enabled?.Invoke();
			this.ActiveStateChanged?.Invoke(obj: true);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			this.Disabled?.Invoke();
			this.ActiveStateChanged?.Invoke(obj: false);
		}
	}
}
