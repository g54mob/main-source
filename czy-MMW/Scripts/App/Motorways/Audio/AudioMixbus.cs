using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Motorways.Audio
{
	public class AudioMixbus
	{
		public enum FilterType
		{
			Lowpass = 0,
			Highpass = 1
		}

		private AudioMixer _audioMixer;

		public AudioMixer Mixer => _audioMixer;

		public float Pitch
		{
			get
			{
				_audioMixer.GetFloat("Pitch", out var value);
				return value;
			}
			set
			{
				_audioMixer.SetFloat("Pitch", value);
				_audioMixer.SetFloat("Volume", PitchToVolumeCompensation(value));
			}
		}

		public float Volume
		{
			get
			{
				_audioMixer.GetFloat("MasterVolume", out var value);
				return value;
			}
			set
			{
				InterpolateVolume(value, 2f);
			}
		}

		public float EchoDelay
		{
			get
			{
				_audioMixer.GetFloat("EchoDelay", out var value);
				return value;
			}
			set
			{
				InterpolateEchoDelay(value, 0.5f);
			}
		}

		public float EchoWet
		{
			get
			{
				_audioMixer.GetFloat("EchoWet", out var value);
				return value;
			}
			set
			{
				InterpolateEchoWet(value, 4f);
			}
		}

		public float EchoDecay
		{
			get
			{
				_audioMixer.GetFloat("EchoDecay", out var value);
				return value;
			}
			set
			{
				InterpolateEchoDecay(value, 0.5f);
			}
		}

		public AudioMixbus()
		{
			_audioMixer = Resources.Load("Audio/Master") as AudioMixer;
		}

		public void InterpolateWetLevel(FilterType filterType, float targetWetLevel, float duration)
		{
			string param = ((filterType == FilterType.Highpass) ? "High" : "Low") + "passWet";
			float num = Mathf.Max(-79.99f, Mathf.Lerp(-80f, 0f, targetWetLevel));
			_audioMixer.GetFloat(param, out var value);
			int pow = ((value > num) ? 3 : (-3));
			Twerp.StartCoroutine(Twerp.InterpolateFloat(delegate(float x)
			{
				_audioMixer.SetFloat(param, x);
			}, value, num, duration, pow));
		}

		public void InterpolateCutoffFreq(FilterType filterType, float targetFreq, float duration)
		{
			string param = ((filterType == FilterType.Highpass) ? "High" : "Low") + "passCutoff";
			_audioMixer.GetFloat(param, out var value);
			int pow = ((value > targetFreq) ? (-3) : 3);
			Twerp.StartCoroutine(Twerp.InterpolateFloat(delegate(float x)
			{
				_audioMixer.SetFloat(param, x);
			}, value, targetFreq, duration, pow));
		}

		public void BoingPitchInPlace(float duration, float freq, float amp, float phase = 0f)
		{
			Action<bool> callback = delegate(bool b)
			{
				if (b)
				{
					_audioMixer.SetFloat("Pitch", Settings.PITCH_ANCHOR);
				}
			};
			Twerp.StartCoroutine(Twerp.InterpolateFloatBoingInPlace(delegate(float x)
			{
				_audioMixer.SetFloat("Pitch", x);
			}, Settings.PITCH_ANCHOR, duration, freq, amp, phase, callback));
		}

		public void InterpolatePitch(float targetPitch, float duration, int pow = 1, Twerp.CurveType curve = Twerp.CurveType.None)
		{
			float pitch = Pitch;
			Twerp.StartCoroutine(Twerp.InterpolateFloat(delegate(float x)
			{
				_audioMixer.SetFloat("Pitch", x);
			}, pitch, targetPitch, duration, pow, curve));
			float num = PitchToVolumeCompensation(pitch);
			float to = PitchToVolumeCompensation(targetPitch);
			Twerp.StartCoroutine(Twerp.InterpolateFloat(delegate(float x)
			{
				_audioMixer.SetFloat("Volume", x);
			}, num, to, duration, pow, curve));
		}

		public void InterpolateVolume(float targetVolume, float duration)
		{
			float volume = Volume;
			Twerp.StartCoroutine(Twerp.InterpolateFloat(delegate(float x)
			{
				_audioMixer.SetFloat("MasterVolume", x);
			}, volume, targetVolume, duration));
		}

		public void InterpolateEchoDelay(float targetDelay, float duration, int pow = 1, Twerp.CurveType curve = Twerp.CurveType.None)
		{
			float echoDelay = EchoDelay;
			Twerp.StartCoroutine(Twerp.InterpolateFloat(delegate(float x)
			{
				_audioMixer.SetFloat("EchoDelay", x);
			}, echoDelay, targetDelay, duration, pow, curve));
		}

		public void InterpolateEchoDecay(float targetDecay, float duration, int pow = 1, Twerp.CurveType curve = Twerp.CurveType.None)
		{
			float echoDecay = EchoDecay;
			Twerp.StartCoroutine(Twerp.InterpolateFloat(delegate(float x)
			{
				_audioMixer.SetFloat("EchoDecay", x);
			}, echoDecay, targetDecay, duration, pow, curve));
		}

		public void InterpolateEchoWet(float targetWet, float duration, int pow = 1, Twerp.CurveType curve = Twerp.CurveType.None)
		{
			float echoWet = EchoWet;
			Twerp.StartCoroutine(Twerp.InterpolateFloat(delegate(float x)
			{
				_audioMixer.SetFloat("EchoWet", x);
			}, echoWet, targetWet, duration, pow, curve));
		}

		private static float PitchToVolumeCompensation(float pitch)
		{
			return Maf.Map(pitch, 1f, 2f, 0f, Settings.PITCH_MIXBUS_ATTENUATION);
		}
	}
}
