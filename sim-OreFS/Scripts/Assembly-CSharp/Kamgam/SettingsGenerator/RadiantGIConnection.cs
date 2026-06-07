using RadiantGI.Universal;

namespace Kamgam.SettingsGenerator
{
	public class RadiantGIConnection : Connection<bool>
	{
		private bool _enabled = true;

		private static bool _currentValue = true;

		private RadiantGlobalIllumination _radiantGI;

		private float _cachedIntensity = 1f;

		public static bool CurrentValue => _currentValue;

		public RadiantGIConnection()
		{
			if (!(SettingsVolume.Instance == null))
			{
				_radiantGI = SettingsVolume.Instance.GetOrAddComponent<RadiantGlobalIllumination>();
				_radiantGI.Override(_radiantGI, 1f);
				_radiantGI.active = false;
				_radiantGI.indirectIntensity.overrideState = true;
				_radiantGI.indirectIntensity.value = 0f;
				RadiantGlobalIllumination radiantGlobalIllumination = SettingsVolume.Instance.FindDefaultVolumeComponent<RadiantGlobalIllumination>(useStackAsFallback: true);
				if (radiantGlobalIllumination != null)
				{
					_cachedIntensity = radiantGlobalIllumination.indirectIntensity.value;
				}
			}
		}

		public override bool GetDefault()
		{
			RadiantGlobalIllumination radiantGlobalIllumination = SettingsVolume.Instance.FindDefaultVolumeComponent<RadiantGlobalIllumination>(useStackAsFallback: true);
			if (radiantGlobalIllumination != null)
			{
				return radiantGlobalIllumination.indirectIntensity.value > 0f;
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
			if (!(_radiantGI == null))
			{
				_radiantGI.active = !enable;
				NotifyListenersIfChanged(enable);
			}
		}
	}
}
