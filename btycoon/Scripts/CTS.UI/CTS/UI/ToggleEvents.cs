using CTS.Core;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CTS.UI
{
	[RequireComponent(typeof(Toggle))]
	public class ToggleEvents : CTSBehaviour
	{
		[SerializeField]
		private UnityEvent<bool> ToggledOn;

		[SerializeField]
		private UnityEvent<bool> ToggledOff;

		[Inject(false)]
		private Toggle _toggle;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_toggle.onValueChanged.AddListener(OnValueChanged);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_toggle.onValueChanged.RemoveListener(OnValueChanged);
		}

		private void OnValueChanged(bool value)
		{
			if (value)
			{
				ToggledOn.Invoke(arg0: true);
			}
			else
			{
				ToggledOff.Invoke(arg0: false);
			}
		}
	}
}
