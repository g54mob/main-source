using Services.Time;
using UnityEngine;
using Zenject;

namespace Audio
{
	[RequireComponent(typeof(AudioSource))]
	public class DayTimeAudioAdapter : MonoBehaviour
	{
		[SerializeField]
		private AnimationCurve _volume;

		[SerializeField]
		private float _maxVolume;

		private AudioSource _audioSource;

		[Inject]
		private ITimeService _timeService;

		private void Awake()
		{
			_audioSource = GetComponent<AudioSource>();
		}

		private void Update()
		{
			_audioSource.volume = Mathf.Clamp(_volume.Evaluate(_timeService.CurrentTime / 24f), 0f, _maxVolume);
		}
	}
}
