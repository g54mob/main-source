using DV.Utils;
using UnityEngine;

namespace DV.ModularAudioCar
{
	public class TrainDerailAudioModule : CarAudioModule
	{
		private TrainCar car;

		private bool doDerailAudio = true;

		public override bool ExternalUpdate => false;

		public override void Initialize(TrainCar trainCar)
		{
			doDerailAudio = true;
			car = trainCar;
			car.OnDerailed += PlayDerailAudio;
			car.SuppressDerailSound += OnDerailSoundSuppressed;
		}

		public override void Deinitialize()
		{
			car.OnDerailed -= PlayDerailAudio;
			car.SuppressDerailSound -= OnDerailSoundSuppressed;
			car = null;
		}

		private void OnDerailSoundSuppressed()
		{
			doDerailAudio = false;
		}

		private void PlayDerailAudio(TrainCar _)
		{
			if (doDerailAudio)
			{
				if (!SingletonBehaviour<AudioManager>.Instance)
				{
					Debug.LogWarning("TrainDerailAudio couldn't find an AudioManager instance, will do nothing", this);
				}
				else
				{
					SingletonBehaviour<AudioManager>.Instance.derailHitClip.Play(base.transform.position, 1f, 1f, 0f, 1f, 2000f, default(AudioSourceCurves), SingletonBehaviour<AudioManager>.Instance.derailGroup);
				}
			}
		}
	}
}
