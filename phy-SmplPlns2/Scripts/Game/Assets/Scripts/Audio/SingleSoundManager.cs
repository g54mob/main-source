using System;
using System.Collections.Generic;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Cameras;
using UnityEngine;
using UnityEngine.Audio;

namespace Assets.Scripts.Audio
{
	public class SingleSoundManager : MonoBehaviour
	{
		private struct SoundSource
		{
			public Vector3 Position { get; set; }

			public float Volume { get; set; }

			public float Pitch { get; set; }
		}

		private AudioSource _audioSource;

		private List<SoundSource> _sources = new List<SoundSource>();

		private float _totalVolume;

		public float MaxVolume { get; set; }

		public bool IsRemote { get; set; }

		public static SingleSoundManager Create(string sound, Transform parent, float maxVolume, AudioMixerGroup mixerGroup, bool isRemote = false, bool isFaded = true, float minDist = -1f, float maxDist = -1f)
		{
			GameObject obj = new GameObject("SingleSoundManager - " + sound);
			SingleSoundManager singleSoundManager = obj.AddComponent<SingleSoundManager>();
			singleSoundManager.SetSound(sound, mixerGroup, isFaded);
			singleSoundManager.MaxVolume = maxVolume;
			singleSoundManager.IsRemote = isRemote;
			obj.transform.parent = parent;
			if (minDist > 0f)
			{
				singleSoundManager._audioSource.minDistance = minDist;
			}
			if (maxDist > 0f)
			{
				singleSoundManager._audioSource.maxDistance = maxDist;
			}
			return singleSoundManager;
		}

		public void AddSound(Vector3 position, float volume, float pitch = 1f)
		{
			SoundSource item = new SoundSource
			{
				Position = position,
				Volume = volume,
				Pitch = pitch
			};
			_sources.Add(item);
			_totalVolume += volume;
		}

		public void NewFrame()
		{
			_totalVolume = 0f;
			_sources.Clear();
		}

		protected virtual void Update()
		{
			if (_totalVolume > 0f)
			{
				Vector3 vector = default(Vector3);
				float num = 0f;
				foreach (SoundSource source in _sources)
				{
					vector += source.Position * source.Volume;
					num += source.Pitch * source.Volume;
				}
				base.transform.position = vector / _totalVolume;
				num /= _totalVolume;
				if (!_audioSource.isPlaying)
				{
					_audioSource.Play();
				}
				_audioSource.pitch = num;
				_audioSource.volume = Mathf.Clamp(_totalVolume, 0f, MaxVolume);
			}
			else
			{
				_audioSource.volume = 0f;
			}
		}

		protected void OnDestroy()
		{
			if (FlightSceneScript.Instance?.CameraScript != null)
			{
				FlightSceneScript.Instance.CameraScript.DopplerFixChanged -= SetDoppler;
			}
		}

		private void SetDoppler(object o, EventArgs e)
		{
			bool flag = false;
			_audioSource.dopplerLevel = ((flag || !(e as CameraManagerScript.DopplerFixChangedEventArgs).Enabled) ? 0.5f : 0f);
		}

		private void SetSound(string sound, AudioMixerGroup mixerGroup, bool isFaded)
		{
			_audioSource = base.gameObject.GetComponent<AudioSource>();
			if (_audioSource == null)
			{
				_audioSource = base.gameObject.AddComponent<AudioSource>();
				if (isFaded)
				{
					base.gameObject.AddComponent<LPFbyDistance>().Filter = base.gameObject.AddComponent<AudioLowPassFilter>();
				}
			}
			AudioStore.SetupAudioSource(_audioSource, AudioStore.GroundWheelSounds, Resources.Load(sound) as AudioClip);
			FlightSceneScript.Instance.CameraScript.DopplerFixChanged += SetDoppler;
			_audioSource.outputAudioMixerGroup = mixerGroup;
		}
	}
}
