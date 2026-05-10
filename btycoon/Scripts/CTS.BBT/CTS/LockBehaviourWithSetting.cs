using CTS.Core;
using CTS.ScriptableSettings;
using UnityEngine;

namespace CTS
{
	public class LockBehaviourWithSetting : CTSBehaviour
	{
		[SerializeField]
		private SettingObject<bool> _boolSetting;

		[SerializeField]
		private MonoBehaviour _behaviour;

		[SerializeField]
		private bool _invert;

		protected override void OnAwake()
		{
			base.OnAwake();
			OnSettingChanged(_boolSetting.GetValue());
			_boolSetting.ValueChanged += OnSettingChanged;
		}

		private void OnDestroy()
		{
			_boolSetting.ValueChanged -= OnSettingChanged;
		}

		private void OnSettingChanged(bool isOn)
		{
			if (_invert)
			{
				_behaviour.enabled = !isOn;
			}
			else
			{
				_behaviour.enabled = isOn;
			}
		}
	}
}
