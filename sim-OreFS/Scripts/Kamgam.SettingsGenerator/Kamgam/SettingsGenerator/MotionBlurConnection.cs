using UnityEngine.Rendering.Universal;

namespace Kamgam.SettingsGenerator
{
	public class MotionBlurConnection : Connection<bool>
	{
		protected MotionBlur _blur;

		public MotionBlurConnection()
		{
			if (!(SettingsVolume.Instance == null))
			{
				_blur = SettingsVolume.Instance.GetOrAddComponent<MotionBlur>();
				_blur.Override(_blur, 1f);
				_blur.active = false;
				_blur.quality.overrideState = true;
				_blur.quality.value = MotionBlurQuality.Low;
				_blur.intensity.overrideState = true;
				_blur.intensity.value = 0f;
			}
		}

		public override bool Get()
		{
			if (_blur == null)
			{
				return true;
			}
			return !_blur.active;
		}

		public override void Set(bool enable)
		{
			if (!(_blur == null))
			{
				_blur.active = !enable;
				NotifyListenersIfChanged(enable);
			}
		}
	}
}
