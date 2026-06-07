using System.Collections.Generic;
using ModApi.Audio;
using UnityEngine;
using UnityEngine.Audio;

namespace Assets.Scripts.Audio
{
	public class SingleSound : MonoBehaviour, ISingleSound
	{
		private class SoundSource
		{
			public Vector3 Position { get; set; }

			public float Volume { get; set; }
		}

		private AudioSource _audioSource;

		private List<SoundSource> _sources = new List<SoundSource>();

		private float _totalVolume;

		public float MaxVolume { get; set; }

		public static ISingleSound Create(string sound, Transform parent, float maxVolume, AudioMixerGroup mixerGroup = null)
		{
			SingleSound singleSound = new GameObject("SingleSound - " + sound).AddComponent<SingleSound>();
			singleSound.SetSound(sound, mixerGroup);
			singleSound.MaxVolume = maxVolume;
			return singleSound;
		}

		public void AddPosition(Vector3 position, float volume)
		{
			SoundSource soundSource = new SoundSource();
			soundSource.Position = position;
			soundSource.Volume = volume;
			_sources.Add(soundSource);
			_totalVolume += volume;
		}

		public void NewFrame()
		{
			_totalVolume = 0f;
			_sources.Clear();
		}

		private void SetSound(string sound, AudioMixerGroup mixerGroup)
		{
			_audioSource = base.gameObject.GetComponent<AudioSource>();
			if (_audioSource == null)
			{
				_audioSource = base.gameObject.AddComponent<AudioSource>();
			}
			_audioSource.volume = 0f;
			_audioSource.dopplerLevel = 0f;
			_audioSource.spatialBlend = 1f;
			_audioSource.minDistance = 50f;
			_audioSource.maxDistance = 1500f;
			_audioSource.outputAudioMixerGroup = mixerGroup;
			_audioSource.clip = Resources.Load(sound) as AudioClip;
			_audioSource.loop = true;
		}

		private void Update()
		{
			float b = 0f;
			if (_totalVolume > 0f)
			{
				Vector3 position = default(Vector3);
				foreach (SoundSource source in _sources)
				{
					position += source.Position * source.Volume / _totalVolume;
				}
				base.transform.position = position;
				b = Mathf.Clamp01(_totalVolume) * MaxVolume;
			}
			float num = Mathf.Lerp(_audioSource.volume, b, 7.5f * Mathf.Clamp(Time.deltaTime, 0f, 0.02f));
			if (num > 0.0001f)
			{
				if (!_audioSource.isPlaying)
				{
					_audioSource.Play();
				}
				_audioSource.volume = num;
			}
			else
			{
				_audioSource.volume = 0f;
			}
		}
	}
}
