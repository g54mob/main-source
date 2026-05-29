using CTS.Core;
using CTS.ScriptableSettings;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class LockButtonWithSetting : CTSBehaviour
	{
		[SerializeField]
		private SettingObject<bool> _boolSetting;

		[SerializeField]
		[Inject(false)]
		private ISelectable _selectable;

		[SerializeField]
		private bool _invert;

		private readonly LockToggle _lockToggle = new LockToggle();

		protected override void OnAwake()
		{
			base.OnAwake();
			_lockToggle.Add(_selectable);
			OnSettingChanged(_boolSetting.GetValue());
			_boolSetting.ValueChanged += OnSettingChanged;
		}

		private void OnDestroy()
		{
			_lockToggle.Unlock();
			_boolSetting.ValueChanged -= OnSettingChanged;
		}

		private void OnSettingChanged(bool isOn)
		{
			if (_invert)
			{
				_lockToggle.SetLock(isOn);
			}
			else
			{
				_lockToggle.SetLock(!isOn);
			}
		}
	}
}
