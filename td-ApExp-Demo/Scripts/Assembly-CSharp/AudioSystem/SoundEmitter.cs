using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AudioSystem
{
	[RequireComponent(typeof(AudioSource))]
	public class SoundEmitter : MonoBehaviour
	{
		[NonSerialized]
		public bool stopIfSourceIsDestroyed;

		private AudioSource audioSource;

		private Coroutine playingCoroutine;

		private bool randomPitch;

		private float minPitchDown;

		private float maxPitchUp;

		private GameObject source;

		private Transform targetPosition;

		private bool matchVolumeWithTrainSpeed;

		private float previousVolume = -5f;

		private Coroutine currentMuteCoroutine;

		private bool coroutineMute;

		public SoundData Data { get; private set; }

		public LinkedListNode<SoundEmitter> Node { get; set; }

		public FrequentSoundTypes FrequentSoundType { get; private set; }

		private void Awake()
		{
			audioSource = base.gameObject.GetOrAdd<AudioSource>();
		}

		private void Update()
		{
			if (stopIfSourceIsDestroyed && source == null)
			{
				Stop();
			}
			if ((bool)targetPosition)
			{
				base.transform.position = targetPosition.position;
			}
			if (matchVolumeWithTrainSpeed)
			{
				if (previousVolume == -5f)
				{
					previousVolume = audioSource.volume;
				}
				audioSource.volume = previousVolume * Train.Instance.TrainSpeedNormalized;
			}
			else
			{
				previousVolume = -5f;
			}
		}

		public void Initialize(SoundData data)
		{
			if (data != null && data.clips.Count != 0)
			{
				Data = data;
				FrequentSoundType = data.frequentSoundType;
				if (data.clips.Count > 1)
				{
					audioSource.clip = data.clips[UnityEngine.Random.Range(0, data.clips.Count)];
				}
				else
				{
					audioSource.clip = data.clips[0];
				}
				audioSource.outputAudioMixerGroup = data.mixerGroup;
				audioSource.loop = data.loop;
				audioSource.mute = data.mute;
				audioSource.volume = data.volume;
				audioSource.pitch = data.pitch;
				randomPitch = data.randomPitch;
				minPitchDown = data.minPitchDown;
				maxPitchUp = data.maxPitchUp;
				targetPosition = data.withPosition;
				if ((bool)data.withPosition)
				{
					base.transform.position = data.withPosition.position;
				}
				source = data.stopWhenSourceIsDestroyed;
				if (source != null)
				{
					stopIfSourceIsDestroyed = true;
				}
				else
				{
					stopIfSourceIsDestroyed = false;
				}
			}
		}

		public void Play(float targetPitch = 0f, bool matchVolumeWithTrainSpeed = false)
		{
			if (playingCoroutine != null)
			{
				StopCoroutine(playingCoroutine);
			}
			if (targetPitch != 0f)
			{
				audioSource.pitch = targetPitch;
			}
			else
			{
				audioSource.pitch += UnityEngine.Random.Range(minPitchDown, maxPitchUp);
			}
			this.matchVolumeWithTrainSpeed = matchVolumeWithTrainSpeed;
			audioSource.Play();
			playingCoroutine = StartCoroutine(WaitForSoundToEnd());
		}

		private IEnumerator WaitForSoundToEnd()
		{
			yield return new WaitWhile(() => audioSource.isPlaying);
			Stop();
		}

		public void Stop()
		{
			if (playingCoroutine != null)
			{
				StopCoroutine(playingCoroutine);
				playingCoroutine = null;
			}
			audioSource.Stop();
			PersistentSingleton<SoundEmitterManager>.Instance.ReturnToPool(this);
		}

		public void SetVolume(float volume)
		{
			if (audioSource.volume != volume)
			{
				audioSource.volume = volume;
			}
		}

		public void MuteAudio(bool mute)
		{
			if (coroutineMute != mute)
			{
				if (currentMuteCoroutine != null)
				{
					StopCoroutine(currentMuteCoroutine);
					currentMuteCoroutine = null;
				}
				coroutineMute = mute;
				if (base.gameObject != null && this != null)
				{
					currentMuteCoroutine = StartCoroutine(LerpMute(mute));
				}
			}
		}

		private IEnumerator LerpMute(bool mute)
		{
			if (mute)
			{
				while (audioSource.volume > 0f)
				{
					yield return new WaitForSecondsRealtime(0.05f);
					audioSource.volume -= 0.01f;
				}
			}
			else
			{
				while (audioSource.volume < 1f)
				{
					yield return new WaitForSecondsRealtime(0.05f);
					audioSource.volume += 0.01f;
				}
			}
		}
	}
}
