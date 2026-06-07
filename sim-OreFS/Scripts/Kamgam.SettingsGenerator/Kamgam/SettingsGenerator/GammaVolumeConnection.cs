using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Kamgam.SettingsGenerator
{
	public class GammaVolumeConnection : Connection<float>
	{
		protected LiftGammaGain _effect;

		public Vector4 _defaultValue = new Vector4(1f, 1f, 1f, 0f);

		public GammaVolumeConnection()
		{
			if (!(SettingsVolume.Instance == null))
			{
				_effect = SettingsVolume.Instance.GetOrAddComponent<LiftGammaGain>();
				_effect.Override(_effect, 1f);
				_effect.active = false;
				UpdateDefaultValue();
			}
		}

		public void UpdateDefaultValue()
		{
			LiftGammaGain liftGammaGain = SettingsVolume.Instance.FindDefaultVolumeComponent<LiftGammaGain>();
			if (liftGammaGain != null)
			{
				_defaultValue = liftGammaGain.gamma.value;
			}
		}

		public override float Get()
		{
			if (_effect == null || !_effect.active)
			{
				return 0f;
			}
			if (_effect.gamma.overrideState)
			{
				return _effect.gamma.value.w;
			}
			return 0f;
		}

		public override void Set(float gamma)
		{
			if (!(_effect == null))
			{
				_effect.active = true;
				Vector4 defaultValue = _defaultValue;
				defaultValue.w = gamma;
				_effect.gamma.Override(defaultValue);
				NotifyListenersIfChanged(gamma);
			}
		}
	}
}
