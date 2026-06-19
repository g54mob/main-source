using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	public class AudioMessage : MonoBehaviour
	{
		[Header("Resources")]
		[SerializeField]
		private Button playButton;

		[SerializeField]
		private Button stopButton;

		[SerializeField]
		private Slider durationSlider;

		[SerializeField]
		private Image durationBackground;

		[SerializeField]
		private Image durationForeground;

		public TextMeshProUGUI timeText;

		[Header("Settings")]
		[SerializeField]
		private bool rememberPosition = true;

		[SerializeField]
		private List<Sprite> durationRandomizer = new List<Sprite>();

		[HideInInspector]
		public AudioSource aSource;

		[HideInInspector]
		public AudioClip aClip;

		private void Start()
		{
			base.enabled = false;
			playButton.gameObject.SetActive(value: true);
			stopButton.gameObject.SetActive(value: false);
			durationBackground.sprite = durationRandomizer[Random.Range(0, durationRandomizer.Count)];
			durationForeground.sprite = durationBackground.sprite;
			durationSlider.value = 0f;
		}

		private void Update()
		{
			if (aSource.clip.name != aClip.name)
			{
				base.enabled = false;
				durationSlider.value = 0f;
				playButton.gameObject.SetActive(value: true);
				stopButton.gameObject.SetActive(value: false);
				return;
			}
			durationSlider.value = aSource.time;
			if (durationSlider.value >= aClip.length)
			{
				StopAudio();
				durationSlider.value = 0f;
			}
		}

		public void PlayAudio()
		{
			base.enabled = true;
			durationSlider.maxValue = aClip.length;
			aSource.clip = aClip;
			if (rememberPosition && durationSlider.value < aClip.length)
			{
				aSource.time = Mathf.Min(durationSlider.value, aSource.clip.length - 0.01f);
			}
			aSource.Play();
			playButton.gameObject.SetActive(value: false);
			stopButton.gameObject.SetActive(value: true);
		}

		public void StopAudio()
		{
			base.enabled = false;
			playButton.gameObject.SetActive(value: true);
			stopButton.gameObject.SetActive(value: false);
			if (rememberPosition)
			{
				aSource.Pause();
				return;
			}
			durationSlider.value = 0f;
			aSource.Stop();
		}
	}
}
