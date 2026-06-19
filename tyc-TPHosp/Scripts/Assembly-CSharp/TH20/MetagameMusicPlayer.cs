using UnityEngine;

namespace TH20
{
	public class MetagameMusicPlayer : MonoBehaviour
	{
		[SerializeField]
		private AudioClip[] _tracks;

		[SerializeField]
		private AudioSource _audioSource;

		private int _currentTrackIndex;

		private float _pausedTime;

		private void Start()
		{
		}

		private void OnEnable()
		{
			_currentTrackIndex = RandomUtils.GlobalRandomInstance.Next(0, _tracks.Length);
			_audioSource.clip = _tracks[_currentTrackIndex];
			if (_audioSource.clip != null)
			{
				_audioSource.Play();
				_audioSource.time = Mathf.Min(_audioSource.clip.length, _pausedTime);
			}
			else
			{
				SetNextTrack();
			}
		}

		private void OnDisable()
		{
			if (_audioSource.clip != null)
			{
				_pausedTime = _audioSource.time;
			}
		}

		private void Update()
		{
			if (_audioSource.clip == null || !_audioSource.isPlaying)
			{
				SetNextTrack();
			}
		}

		private void SetNextTrack()
		{
			_currentTrackIndex = (_currentTrackIndex + 1) % _tracks.Length;
			_audioSource.clip = _tracks[_currentTrackIndex];
			_audioSource.time = 0f;
			_audioSource.priority = 0;
			_audioSource.Play();
		}
	}
}
