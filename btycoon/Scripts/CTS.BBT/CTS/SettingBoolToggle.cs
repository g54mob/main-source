using System;
using CTS.Core;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class SettingBoolToggle : CTSBehaviour
	{
		[InjectScope(EGetScope.Children)]
		[SerializeField]
		[Inject(false)]
		private Toggle _toggle;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_toggle.onValueChanged.AddListener(OnToggleChanged);
		}

		private void OnToggleChanged(bool isOn)
		{
			throw new NotImplementedException();
		}
	}
}
