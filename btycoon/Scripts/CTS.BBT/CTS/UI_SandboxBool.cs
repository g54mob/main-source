using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public abstract class UI_SandboxBool<TObject> : UI_SandboxSetting<TObject, bool> where TObject : ScriptableObject
	{
		[SerializeField]
		[Inject(false)]
		private CTSToggle _toggle;

		[SerializeField]
		private bool _defaultValue;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_toggle.onValueChanged.AddListener(OnToggleValueChanged);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_toggle.onValueChanged.RemoveListener(OnToggleValueChanged);
		}

		public override void ResetValue()
		{
			_toggle.isOn = _defaultValue;
		}

		private void OnToggleValueChanged(bool isOn)
		{
			TObject obj = GetObject();
			if (GetValue(obj) != isOn)
			{
				SetValue(obj, isOn);
				bool value = GetValue(obj);
				if (value != isOn)
				{
					_toggle.isOn = value;
				}
			}
		}
	}
}
