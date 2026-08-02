using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Suntail
{
	public class SuntailStartDemo : MonoBehaviour
	{
		[SerializeField]
		private AudioMixer _audioMixer;

		[SerializeField]
		private Image blackScreenImage;

		[SerializeField]
		private Text blackScreenText1;

		[SerializeField]
		private Text blackScreenText2;

		[SerializeField]
		private Text hintText;

		[SerializeField]
		private float blackScreenDuration = 4f;

		[SerializeField]
		private float hintDuration = 14f;

		[SerializeField]
		private float fadingDuration = 3f;

		private bool screenTimerIsActive = true;

		private bool hintTimerIsActive = true;

		private void Start()
		{
			blackScreenImage.gameObject.SetActive(value: true);
			blackScreenText1.gameObject.SetActive(value: true);
			blackScreenText2.gameObject.SetActive(value: true);
			hintText.gameObject.SetActive(value: true);
			_audioMixer.SetFloat("soundsVolume", -80f);
		}

		private void Update()
		{
			if (screenTimerIsActive)
			{
				blackScreenDuration -= Time.deltaTime;
				if (blackScreenDuration < 0f)
				{
					screenTimerIsActive = false;
					blackScreenImage.CrossFadeAlpha(0f, fadingDuration, ignoreTimeScale: false);
					blackScreenText1.CrossFadeAlpha(0f, fadingDuration, ignoreTimeScale: false);
					blackScreenText2.CrossFadeAlpha(0f, fadingDuration, ignoreTimeScale: false);
					StartCoroutine(StartAudioFade(_audioMixer, "soundsVolume", fadingDuration, 1f));
				}
			}
			if (hintTimerIsActive)
			{
				hintDuration -= Time.deltaTime;
				if (hintDuration < 0f)
				{
					hintTimerIsActive = false;
					hintText.CrossFadeAlpha(0f, fadingDuration, ignoreTimeScale: false);
				}
			}
		}

		public static IEnumerator StartAudioFade(AudioMixer audioMixer, string exposedParam, float duration, float targetVolume)
		{
			float currentTime = 0f;
			audioMixer.GetFloat(exposedParam, out var currentVol);
			currentVol = Mathf.Pow(10f, currentVol / 20f);
			float targetValue = Mathf.Clamp(targetVolume, 0.0001f, 1f);
			while (currentTime < duration)
			{
				currentTime += Time.deltaTime;
				float f = Mathf.Lerp(currentVol, targetValue, currentTime / duration);
				audioMixer.SetFloat(exposedParam, Mathf.Log10(f) * 20f);
				yield return null;
			}
		}
	}
}
