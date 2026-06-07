namespace Kamgam.SettingsGenerator
{
	public class VolumetricFogConnection : Connection<bool>
	{
		private bool _enabled = true;

		private static bool _currentValue = true;

		private VolumetricFogVolumeComponent _volumetricFog;

		public static bool CurrentValue => _currentValue;

		public VolumetricFogConnection()
		{
			if (!(SettingsVolume.Instance == null))
			{
				_volumetricFog = SettingsVolume.Instance.GetOrAddComponent<VolumetricFogVolumeComponent>();
				_volumetricFog.Override(_volumetricFog, 1f);
				_volumetricFog.active = false;
				_volumetricFog.enabled.overrideState = true;
				_volumetricFog.enabled.value = false;
			}
		}

		public override bool GetDefault()
		{
			VolumetricFogVolumeComponent volumetricFogVolumeComponent = SettingsVolume.Instance.FindDefaultVolumeComponent<VolumetricFogVolumeComponent>(useStackAsFallback: true);
			if (volumetricFogVolumeComponent != null)
			{
				return volumetricFogVolumeComponent.enabled.value;
			}
			return true;
		}

		public override bool Get()
		{
			return _enabled;
		}

		public override void Set(bool enable)
		{
			_enabled = enable;
			_currentValue = enable;
			if (!(_volumetricFog == null))
			{
				_volumetricFog.active = !enable;
				NotifyListenersIfChanged(enable);
			}
		}
	}
}
