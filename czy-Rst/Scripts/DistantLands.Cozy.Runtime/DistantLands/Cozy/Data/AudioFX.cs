using System;
using UnityEngine;
using UnityEngine.Audio;

namespace DistantLands.Cozy.Data
{
	[Serializable]
	[CreateAssetMenu(menuName = "Distant Lands/Cozy/FX/Audio FX", order = 361)]
	public class AudioFX : FXProfile
	{
		public AudioClip clip;

		[Tooltip("The audio mixer group that the COZY weather audio FX will use.")]
		public AudioMixerGroup audioMixer;

		private AudioSource runtimeRef;

		public float maximumVolume = 1f;

		public override void PlayEffect(float weight)
		{
			if (!runtimeRef && !InitializeEffect(weatherSphere))
			{
				return;
			}
			if (weight == 0f)
			{
				runtimeRef.volume = 0f;
				runtimeRef.Stop();
				return;
			}
			if (!runtimeRef.isPlaying && runtimeRef.isActiveAndEnabled)
			{
				runtimeRef.Play();
			}
			runtimeRef.volume = maximumVolume * transitionTimeModifier.Evaluate(weight);
		}

		public override bool InitializeEffect(CozyWeather weather)
		{
			if (!Application.isPlaying)
			{
				return false;
			}
			base.InitializeEffect(weather);
			if (runtimeRef == null)
			{
				runtimeRef = weather.GetFXRuntimeRef<AudioSource>(base.name);
				if ((bool)runtimeRef)
				{
					return true;
				}
				runtimeRef = new GameObject().AddComponent<AudioSource>();
				runtimeRef.gameObject.name = base.name;
				runtimeRef.transform.parent = weather.audioFXParent;
				runtimeRef.transform.localPosition = Vector3.zero;
				runtimeRef.transform.localRotation = Quaternion.identity;
				runtimeRef.clip = clip;
				runtimeRef.outputAudioMixerGroup = audioMixer;
				runtimeRef.playOnAwake = false;
				runtimeRef.volume = 0f;
				runtimeRef.loop = true;
			}
			return true;
		}
	}
}
