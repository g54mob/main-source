using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DV.Items.Brick
{
	public class BrickAudio : MonoBehaviour
	{
		private const float MIN_SOUND_DISTANCE = 0.1f;

		private const float MAX_SOUND_DISTANCE = 50f;

		private AudioSource musicSource;

		private Coroutine currentMusicCoroutine;

		private Dictionary<AudioSource, Coroutine> activeSoundEffects = new Dictionary<AudioSource, Coroutine>();

		private void Awake()
		{
			musicSource = NAudio.CreateSource(base.transform, null, 1f, 1f, loop: true, playAtStart: false, 0.1f, 50f).source;
		}

		private void OnDisable()
		{
			StopAllSounds();
		}

		public void PlayMusic(AudioClip clip, bool loop, float startDelay = 0f)
		{
			if (!(clip == null))
			{
				if (currentMusicCoroutine != null)
				{
					StopCoroutine(currentMusicCoroutine);
				}
				currentMusicCoroutine = StartCoroutine(PlayMusic(clip, startDelay, loop));
			}
		}

		public void StopMusic()
		{
			musicSource.Stop();
			if (currentMusicCoroutine != null)
			{
				StopCoroutine(currentMusicCoroutine);
				currentMusicCoroutine = null;
			}
		}

		public void PauseAudio()
		{
			if (musicSource.clip != null)
			{
				musicSource.Pause();
			}
			foreach (AudioSource key in activeSoundEffects.Keys)
			{
				if (key != null)
				{
					key.Pause();
				}
			}
		}

		public void ResumeAudio()
		{
			if (musicSource.clip != null)
			{
				musicSource.UnPause();
			}
			foreach (AudioSource key in activeSoundEffects.Keys)
			{
				if (key != null)
				{
					key.UnPause();
				}
			}
		}

		public void StopAllSounds()
		{
			if (currentMusicCoroutine != null)
			{
				StopCoroutine(currentMusicCoroutine);
			}
			currentMusicCoroutine = null;
			if (musicSource != null && musicSource.clip != null)
			{
				musicSource.Stop();
			}
			foreach (KeyValuePair<AudioSource, Coroutine> activeSoundEffect in activeSoundEffects)
			{
				if (activeSoundEffect.Key != null && activeSoundEffect.Key.isPlaying)
				{
					activeSoundEffect.Key.Stop();
				}
				if (activeSoundEffect.Value != null)
				{
					StopCoroutine(activeSoundEffect.Value);
				}
			}
			activeSoundEffects.Clear();
		}

		private IEnumerator PlayMusic(AudioClip musicClip, float startDelay, bool loop)
		{
			if (startDelay > 0f)
			{
				yield return WaitFor.Seconds(startDelay);
			}
			musicSource.clip = musicClip;
			musicSource.loop = loop;
			musicSource.Play();
			currentMusicCoroutine = null;
		}

		public void PlayClip(AudioClip clip)
		{
			if (!(clip == null))
			{
				AudioSource source = clip.Play(base.transform.position, 1f, 1f, 0f, 0.1f, 50f, default(AudioSourceCurves), null, base.transform).source;
				Coroutine value = StartCoroutine(UpdateActiveSoundEffectsAfterPlayed(source));
				activeSoundEffects.Add(source, value);
			}
		}

		private IEnumerator UpdateActiveSoundEffectsAfterPlayed(AudioSource source)
		{
			if (!(source == null) && !(source.clip == null))
			{
				yield return WaitFor.Seconds(source.clip.length);
				if (activeSoundEffects.ContainsKey(source))
				{
					activeSoundEffects.Remove(source);
				}
			}
		}
	}
}
