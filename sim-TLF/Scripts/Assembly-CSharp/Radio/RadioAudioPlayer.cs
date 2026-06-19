using System;
using UnityEngine;

namespace Radio
{
	public class RadioAudioPlayer : MonoBehaviour
	{
		[Header("Static noise")]
		[SerializeField]
		private AudioClip _staticSoundFileObect;

		[SerializeField]
		private AudioSource _musicSource;

		[SerializeField]
		private AudioSource _staticAudioSource;

		private RadioTrack _currentTrack;

		public AudioSource MusicSource => _musicSource;

		public AudioSource StaticSource => _staticAudioSource;

		private void Update()
		{
			_musicSource.pitch = Time.timeScale;
			_staticAudioSource.pitch = Time.timeScale;
		}

		public void PlayTrack(RadioTrack track)
		{
			StopTrack();
			if (track == null || track.musicFileObject == null)
			{
				return;
			}
			try
			{
				_currentTrack = track;
				_musicSource.PlayOneShot(track.musicFileObject);
			}
			catch (Exception ex)
			{
				Debug.LogWarning($"[RadioAudioPlayer] PlayMusic failed for '{track.musicFileObject}': {ex.Message}");
			}
		}

		public void StopTrack()
		{
			try
			{
				_musicSource.Stop();
			}
			catch
			{
			}
		}

		public void PlayStatic()
		{
			if (_staticSoundFileObect == null)
			{
				return;
			}
			StopStatic();
			try
			{
				_staticAudioSource.clip = _staticSoundFileObect;
				_staticAudioSource.Play();
				_staticAudioSource.loop = true;
			}
			catch (Exception ex)
			{
				Debug.LogWarning("[RadioAudioPlayer] Static sound failed: " + ex.Message);
			}
		}

		public void StopStatic()
		{
			try
			{
				_staticAudioSource.Stop();
			}
			catch
			{
			}
		}

		private void OnDisable()
		{
			StopTrack();
			StopStatic();
		}
	}
}
