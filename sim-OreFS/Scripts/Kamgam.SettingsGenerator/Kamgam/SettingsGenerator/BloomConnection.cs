using UnityEngine.Rendering.Universal;

namespace Kamgam.SettingsGenerator
{
	public class BloomConnection : Connection<bool>
	{
		protected Bloom _bloom;

		public BloomConnection()
		{
			if (!(SettingsVolume.Instance == null))
			{
				_bloom = SettingsVolume.Instance.GetOrAddComponent<Bloom>();
				_bloom.Override(_bloom, 1f);
				_bloom.active = false;
				_bloom.intensity.overrideState = true;
				_bloom.intensity.value = 0f;
			}
		}

		public override bool GetDefault()
		{
			Bloom bloom = SettingsVolume.Instance.FindDefaultVolumeComponent<Bloom>(useStackAsFallback: true);
			if ((bool)bloom)
			{
				return bloom.active;
			}
			return false;
		}

		public override bool Get()
		{
			if (_bloom == null)
			{
				return true;
			}
			return !_bloom.active;
		}

		public override void Set(bool enable)
		{
			if (!(_bloom == null))
			{
				_bloom.active = !enable;
				NotifyListenersIfChanged(enable);
			}
		}
	}
}
