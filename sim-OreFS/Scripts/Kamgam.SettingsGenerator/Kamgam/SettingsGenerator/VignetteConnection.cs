using UnityEngine.Rendering.Universal;

namespace Kamgam.SettingsGenerator
{
	public class VignetteConnection : Connection<bool>
	{
		protected Vignette _vignette;

		public VignetteConnection()
		{
			if (!(SettingsVolume.Instance == null))
			{
				_vignette = SettingsVolume.Instance.GetOrAddComponent<Vignette>();
				_vignette.Override(_vignette, 1f);
				_vignette.active = false;
				_vignette.intensity.overrideState = true;
				_vignette.intensity.value = 0f;
			}
		}

		public override bool Get()
		{
			if (_vignette == null)
			{
				return true;
			}
			return !_vignette.active;
		}

		public override void Set(bool enable)
		{
			if (!(_vignette == null))
			{
				_vignette.active = !enable;
				NotifyListenersIfChanged(enable);
			}
		}
	}
}
