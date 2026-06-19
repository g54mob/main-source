using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	[DefaultExecutionOrder(-100)]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(AudioSource))]
	public class AudioManager : MonoBehaviour
	{
		public static AudioManager instance;

		public UIManager UIManagerAsset;

		public AudioSource audioSource;

		[SerializeField]
		private AudioMixer mixer;

		[SerializeField]
		private SliderManager masterSlider;

		[SerializeField]
		private Image taskbarIndicator;

		[SerializeField]
		private Image mixerIndicator;

		public Sprite volumeMuted;

		public Sprite volumeLow;

		public Sprite volumeHigh;

		private float muteValue = 0.0001f;

		private float preMute = 1f;

		private bool isMuted;

		private DreamOSDataManager.DataCategory dataCat = DreamOSDataManager.DataCategory.System;

		private void Awake()
		{
			instance = this;
			if (audioSource == null)
			{
				base.gameObject.GetComponent<AudioSource>();
			}
			if (!(mixer == null) && !(masterSlider == null))
			{
				if (!DreamOSDataManager.ContainsJsonKey(dataCat, masterSlider.saveKey))
				{
					DreamOSDataManager.WriteFloatData(dataCat, masterSlider.saveKey, masterSlider.mainSlider.value);
				}
				mixer.SetFloat("Master", Mathf.Log10(DreamOSDataManager.ReadFloatData(dataCat, masterSlider.saveKey)) * 20f);
				masterSlider.mainSlider.onValueChanged.AddListener(SetMasterVolume);
				masterSlider.mainSlider.onValueChanged.Invoke(masterSlider.mainSlider.value);
			}
		}

		private void Update()
		{
			if (UIManagerAsset.enableKeystrokes && Time.timeScale != 0f)
			{
				if (Mouse.current.leftButton.wasPressedThisFrame || Mouse.current.rightButton.wasPressedThisFrame)
				{
					PlayMouseStroke();
				}
				else if (Keyboard.current.anyKey.wasPressedThisFrame)
				{
					PlayKeyboardStroke();
				}
			}
		}

		public void PlayKeyboardStroke()
		{
			if (UIManagerAsset.enableKeyboardKeystroke)
			{
				audioSource.PlayOneShot(UIManagerAsset.keyboardStrokes[Random.Range(0, UIManagerAsset.keyboardStrokes.Count)]);
			}
		}

		public void PlayMouseStroke()
		{
			if (UIManagerAsset.enableMouseKeystroke)
			{
				audioSource.PlayOneShot(UIManagerAsset.mouseStrokes[Random.Range(0, UIManagerAsset.mouseStrokes.Count)]);
			}
		}

		public void EnableStrokes(bool value)
		{
			if (value)
			{
				UIManagerAsset.enableKeystrokes = true;
			}
			else
			{
				UIManagerAsset.enableKeystrokes = false;
			}
		}

		public void SetMasterVolume(float volume)
		{
			if (mixer == null || masterSlider == null)
			{
				return;
			}
			mixer.SetFloat("Master", Mathf.Log10(volume) * 20f);
			if (taskbarIndicator != null)
			{
				if (masterSlider.mainSlider.value <= muteValue)
				{
					taskbarIndicator.sprite = volumeMuted;
				}
				else if (masterSlider.mainSlider.value > 0.5f)
				{
					taskbarIndicator.sprite = volumeHigh;
				}
				else if (masterSlider.mainSlider.value < 0.5f)
				{
					taskbarIndicator.sprite = volumeLow;
				}
			}
			if (mixerIndicator != null)
			{
				if (masterSlider.mainSlider.value <= muteValue)
				{
					mixerIndicator.sprite = volumeMuted;
				}
				else if (masterSlider.mainSlider.value > 0.5f)
				{
					mixerIndicator.sprite = volumeHigh;
				}
				else if (masterSlider.mainSlider.value < 0.5f)
				{
					mixerIndicator.sprite = volumeLow;
				}
			}
			if (masterSlider.mainSlider.value > muteValue)
			{
				isMuted = false;
			}
			else
			{
				isMuted = true;
			}
		}

		public void Mute()
		{
			if (isMuted)
			{
				masterSlider.mainSlider.value = preMute;
			}
			else
			{
				preMute = masterSlider.mainSlider.value;
				masterSlider.mainSlider.value = muteValue;
			}
			SetMasterVolume(masterSlider.mainSlider.value);
		}
	}
}
