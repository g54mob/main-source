using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioKit : MonoBehaviour
{
	[Serializable]
	public class Effect
	{
		public string id;

		public float volume;

		public bool background;

		public ShuffleAudioClips clips;

		[NonSerialized]
		public AudioSource playedAudioSource;

		public bool playedRecently
		{
			get
			{
				return playedAudioSource != null && playedAudioSource.isPlaying && playedAudioSource.time < 0.05f;
			}
		}
	}

	public int numSources;

	public List<Effect> effects;

	private List<AudioSource> audioSources;

	private int muteUntilFrame;

	private bool mutingForOneFrame
	{
		get
		{
			return Time.frameCount <= muteUntilFrame;
		}
	}

	public void MuteForOneFrame()
	{
		muteUntilFrame = Time.frameCount + 1;
	}

	public void UnMute()
	{
		muteUntilFrame = 0;
	}

	private void Awake()
	{
		Init();
	}

	private void OnDisable()
	{
		foreach (AudioSource audioSource in audioSources)
		{
			audioSource.Stop();
			audioSource.clip = null;
		}
	}

	private void Init()
	{
		if (audioSources == null || audioSources.Count <= 0)
		{
			audioSources = new List<AudioSource>();
			for (int i = 0; i < numSources; i++)
			{
				audioSources.Add(base.gameObject.AddComponent<AudioSource>());
			}
		}
	}

	public AudioSource Play(string effectId)
	{
		if (mutingForOneFrame)
		{
			return null;
		}
		Init();
		Effect effect = GetEffect(effectId);
		if (effect == null)
		{
			return null;
		}
		if (effect.playedRecently)
		{
			return null;
		}
		if (effect.background)
		{
			foreach (Effect effect2 in effects)
			{
				if (!effect2.background && effect2.playedRecently)
				{
					return null;
				}
			}
		}
		else
		{
			foreach (Effect effect3 in effects)
			{
				if (effect3.background && effect3.playedRecently)
				{
					effect3.playedAudioSource.Stop();
				}
			}
		}
		AudioSource audioSource = null;
		foreach (AudioSource audioSource2 in audioSources)
		{
			if (!audioSource2.isPlaying)
			{
				return Play(audioSource2, effect);
			}
			if (audioSource == null || audioSource2.time > audioSource.time)
			{
				audioSource = audioSource2;
			}
		}
		return Play(audioSource, effect);
	}

	public bool Abort(string effectId)
	{
		Effect effect = GetEffect(effectId);
		if (effect != null && effect.playedAudioSource != null && effect.playedAudioSource.isPlaying)
		{
			effect.playedAudioSource.Stop();
			return true;
		}
		return false;
	}

	public AudioOneShot PlayUsingOneShot(string effectId)
	{
		Init();
		Effect effect = GetEffect(effectId);
		if (effect == null)
		{
			return null;
		}
		return AudioOneShot.Play(effect.clips.next, false, effect.volume);
	}

	public AudioClip GetNextAudioClip(string effectId)
	{
		Effect effect = GetEffect(effectId);
		if (effect != null)
		{
			return effect.clips.next;
		}
		return null;
	}

	private AudioSource Play(AudioSource audioSource, Effect effect)
	{
		foreach (Effect effect2 in effects)
		{
			if (effect2.playedAudioSource == audioSource)
			{
				effect2.playedAudioSource = null;
			}
		}
		audioSource.clip = effect.clips.next;
		audioSource.volume = effect.volume;
		audioSource.panStereo = 0f;
		audioSource.Play();
		effect.playedAudioSource = audioSource;
		return audioSource;
	}

	private Effect GetEffect(string effectId)
	{
		foreach (Effect effect in effects)
		{
			if (effectId == effect.id)
			{
				return effect;
			}
		}
		return null;
	}
}
