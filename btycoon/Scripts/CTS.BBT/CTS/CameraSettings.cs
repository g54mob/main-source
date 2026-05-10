using CTS.Core;
using CTS.ScriptableSettings;
using UnityEngine;

namespace CTS
{
	public class CameraSettings : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private CameraRotation _cameraRotation;

		[SerializeField]
		[Inject(false)]
		private CameraMovements _cameraMovements;

		[SerializeField]
		private SettingObject<float> _rotationSetting;

		[SerializeField]
		private SettingObject<float> _speedSetting;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_rotationSetting.ValueChanged += OnRotationChanged;
			OnRotationChanged(_rotationSetting.GetValue());
			_speedSetting.ValueChanged += OnSpeedChanged;
			OnSpeedChanged(_speedSetting.GetValue());
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_rotationSetting.ValueChanged -= OnRotationChanged;
			_speedSetting.ValueChanged -= OnSpeedChanged;
		}

		private void OnRotationChanged(float obj)
		{
			_cameraRotation.SetSpeedModifier(obj);
		}

		private void OnSpeedChanged(float obj)
		{
			_cameraMovements.SetSpeedModifier(obj);
		}
	}
}
