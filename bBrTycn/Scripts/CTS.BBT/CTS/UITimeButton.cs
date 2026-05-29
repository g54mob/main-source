using System;
using CTS.BBT;
using CTS.Core;
using CTS.UI;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	[RequireComponent(typeof(Toggle))]
	public class UITimeButton : CTSBehaviour
	{
		[SerializeField]
		private ETimeModes _timeMode = ETimeModes.Normal;

		[SerializeField]
		[Inject(false)]
		private CTSToggle _button;

		private readonly LockToggle _timeControllerLock = new LockToggle();

		protected override void OnAwake()
		{
			base.OnAwake();
			_timeControllerLock.Add(_button);
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_button.onValueChanged.AddListener(OnButtonClick);
			TimeController.TimeModeChanged += OnTimeModeChanged;
			TimeController instance = MonoSingleton<TimeController>.Instance;
			instance.LockStateChanged = (Action<bool>)Delegate.Combine(instance.LockStateChanged, new Action<bool>(OnTimeControllerLocked));
			OnTimeModeChanged(MonoSingleton<TimeController>.Instance.TimeMode);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_button.onValueChanged.RemoveListener(OnButtonClick);
			TimeController.TimeModeChanged -= OnTimeModeChanged;
			if (MonoSingleton<TimeController>.InstanceExists())
			{
				TimeController instance = MonoSingleton<TimeController>.Instance;
				instance.LockStateChanged = (Action<bool>)Delegate.Remove(instance.LockStateChanged, new Action<bool>(OnTimeControllerLocked));
			}
		}

		private void OnTimeModeChanged(ETimeModes newTimeMode)
		{
			_button.isOn = _timeMode == newTimeMode;
		}

		private void OnTimeControllerLocked(bool isUnlocked)
		{
			_timeControllerLock.SetLock(!isUnlocked);
		}

		private void OnButtonClick(bool value)
		{
			if (value)
			{
				MonoSingleton<TimeController>.Instance.TimeMode = _timeMode;
			}
		}
	}
}
