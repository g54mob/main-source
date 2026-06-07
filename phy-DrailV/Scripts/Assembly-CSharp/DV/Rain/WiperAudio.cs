using System;
using DV.Damage;
using DV.Utils;
using DV.VFX;
using DV.WeatherSystem;
using UnityEngine;

namespace DV.Rain
{
	public class WiperAudio : MonoBehaviour
	{
		private const float WET_WIPER_SOUND = 0.25f;

		private const float DRY_WIPER_SOUND = 0.05f;

		private const float ROOF_WIPER_AUDIO_TIME = 5f;

		private const float VOLUME_THRESHOLD = 0.01f;

		public WiperController wiperController;

		public WiperDriver driver;

		public float[] pitchMultiplierValues;

		public AnimationCurve slideVolumeCurve;

		public AudioClip wetClip;

		public AudioClip dryClip;

		public AudioClip motorClip;

		public AnimationCurve leftMove;

		public AnimationCurve rightMove;

		public AudioSource slideAudioSource;

		public AudioSource motorAudioSource;

		public float slideVolume;

		public AudioSource endAudio;

		public AudioClip endClip;

		public float endVolume;

		public float endPitchLeft;

		public float endPitchRight;

		private WindowsBreakingController windowsBreakingController;

		private CeilingDetection ceilingDetection;

		private float roofTimer;

		private void OnValidate()
		{
			if (pitchMultiplierValues == null)
			{
				return;
			}
			if (wiperController != null && pitchMultiplierValues.Length != wiperController.speeds.Length)
			{
				Array.Resize(ref pitchMultiplierValues, wiperController.speeds.Length);
			}
			for (int i = 1; i < pitchMultiplierValues.Length; i++)
			{
				if (pitchMultiplierValues[i] == 0f)
				{
					pitchMultiplierValues[i] = 1f;
				}
			}
		}

		private void Start()
		{
			motorAudioSource.clip = motorClip;
			windowsBreakingController = TrainCar.Resolve(base.transform.parent).GetComponent<WindowsBreakingController>();
			driver.wiper.OnReleaseDroplets += OnDropletsReleased;
			ceilingDetection = SingletonBehaviour<CeilingDetection>.Instance;
		}

		private void Update()
		{
			bool num = wiperController.usedSpeedIndex > 0;
			float num2 = pitchMultiplierValues[wiperController.usedSpeedIndex];
			float num3 = (driver.direction ? leftMove.Evaluate(driver.currentPos) : rightMove.Evaluate(driver.currentPos));
			float num4 = (SingletonBehaviour<WeatherDriver>.Instance ? ((float)SingletonBehaviour<WeatherDriver>.Instance.WetnessValue) : 0f);
			bool flag = false;
			if ((bool)ceilingDetection)
			{
				CeilingDetection.WorldPositionedArray worldPositionedArray = ceilingDetection.worldPositionedArray;
				int index = worldPositionedArray.GetIndex(base.transform.position);
				if (index >= 0 && ceilingDetection.copiedResults[index].point.y > base.transform.position.y + 3f)
				{
					flag = true;
				}
			}
			roofTimer = (flag ? Mathf.Max(roofTimer - Time.deltaTime, 0f) : 5f);
			num4 *= 0.25f + roofTimer * 0.75f / 5f;
			AudioClip audioClip = ((!(num4 <= 0.25f)) ? null : ((!(num4 < 0.05f)) ? wetClip : dryClip));
			if (slideAudioSource.clip != audioClip)
			{
				slideAudioSource.Stop();
				slideAudioSource.clip = audioClip;
				if ((bool)audioClip)
				{
					slideAudioSource.Play();
				}
			}
			float num5 = ((!windowsBreakingController || !windowsBreakingController.windowsBroken) ? 1 : 0);
			float num6 = slideVolumeCurve.Evaluate(driver.currentPos);
			slideAudioSource.pitch = num3 * num2;
			slideAudioSource.volume = slideVolume * num6 * num5;
			bool flag2 = num && slideAudioSource.volume > 0.01f;
			if (slideAudioSource.isPlaying != flag2)
			{
				if (flag2)
				{
					if ((bool)audioClip)
					{
						slideAudioSource.Play();
					}
				}
				else
				{
					slideAudioSource.Stop();
				}
			}
			motorAudioSource.pitch = num3 * num2;
			motorAudioSource.volume = slideVolume * num6;
			bool flag3 = num && motorAudioSource.volume > 0.01f;
			if (motorAudioSource.isPlaying != flag3)
			{
				if (flag3)
				{
					motorAudioSource.Play();
				}
				else
				{
					motorAudioSource.Stop();
				}
			}
		}

		private void OnDestroy()
		{
			driver.wiper.OnReleaseDroplets -= OnDropletsReleased;
		}

		private void OnDropletsReleased(Wiper wiper)
		{
			endAudio.clip = endClip;
			endAudio.pitch = (driver.direction ? endPitchLeft : endPitchRight);
			endAudio.volume = endVolume;
			endAudio.Play();
		}
	}
}
