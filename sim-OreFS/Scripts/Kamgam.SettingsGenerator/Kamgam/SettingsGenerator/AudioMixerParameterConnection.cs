using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Audio;

namespace Kamgam.SettingsGenerator
{
	public class AudioMixerParameterConnection : Connection<float>
	{
		public AudioMixer Mixer;

		public string ExposedParameterName;

		public bool UseExtendedRange;

		protected bool _scheduledDelayedSet;

		public AudioMixerParameterConnection(AudioMixer mixer, string exposedParameterName)
		{
			Mixer = mixer;
			ExposedParameterName = exposedParameterName;
		}

		public override float Get()
		{
			if (Mixer.GetFloat(ExposedParameterName, out var value))
			{
				float b = (UseExtendedRange ? 20f : 0f);
				float num = (UseExtendedRange ? 120f : 100f) / 2f;
				if (value > -16f)
				{
					return Mathf.InverseLerp(-16f, b, value) * num + num;
				}
				return Mathf.InverseLerp(-80f, -16f, value) * num;
			}
			return 0f;
		}

		public override void Set(float value)
		{
			float b = (UseExtendedRange ? 20f : 0f);
			float num = (UseExtendedRange ? 120f : 100f) / 2f;
			float value2 = ((!(value > num)) ? Mathf.Lerp(-80f, -16f, value / num) : Mathf.Lerp(-16f, b, (value - num) / num));
			Mixer.SetFloat(ExposedParameterName, value2);
			if (Time.frameCount < 1 && !_scheduledDelayedSet)
			{
				_scheduledDelayedSet = true;
				setOneFrameLater(value);
			}
		}

		protected async void setOneFrameLater(float value)
		{
			float b = (UseExtendedRange ? 20f : 0f);
			float num = (UseExtendedRange ? 120f : 100f) / 2f;
			float audioMixerValue = ((!(value > num)) ? Mathf.Lerp(-80f, -16f, value / num) : Mathf.Lerp(-16f, b, (value - num) / num));
			await Task.Delay(10);
			Mixer.SetFloat(ExposedParameterName, audioMixerValue);
			_scheduledDelayedSet = false;
		}
	}
}
