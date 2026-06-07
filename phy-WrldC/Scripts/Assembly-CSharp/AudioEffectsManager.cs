using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UltimateReplay;
using UnityEngine;

public class AudioEffectsManager : MonoBehaviour
{
	private class AudioSourceInUse
	{
		public AudioSource AudioSource { get; set; }

		public bool WasAudioPlaying { get; set; }
	}

	private struct PlayedAudioClip
	{
		public AudioClip AudioClip { get; }

		public float Timestamp { get; }

		public PlayedAudioClip(AudioClip audioClip, float timestamp)
		{
			AudioClip = audioClip;
			Timestamp = timestamp;
		}
	}

	[SerializeField]
	private GameObject audioSourcePrefab;

	[SerializeField]
	private int poolSize = 20;

	[SerializeField]
	private int audiosPlayedHistorySize = 32;

	private List<AudioSource> audioSourcePool;

	private List<AudioSourceInUse> audioSourcesInUse;

	private Queue<PlayedAudioClip> audiosPlayedHistory;

	private bool shouldReplayAudios;

	public static AudioEffectsManager Instance => Singleton<AudioEffectsManager>.Instance;

	public static bool Exist => Singleton<AudioEffectsManager>.Exist;

	public bool IsAudioSourcesInPause { get; private set; }

	private void Awake()
	{
		audioSourcePool = new List<AudioSource>();
		audioSourcesInUse = new List<AudioSourceInUse>();
		audiosPlayedHistory = new Queue<PlayedAudioClip>();
		IsAudioSourcesInPause = false;
		shouldReplayAudios = true;
	}

	public IEnumerator PopulateAudioSourcePool()
	{
		if (audioSourcePool.Count <= 0)
		{
			for (int i = 0; i < poolSize; i++)
			{
				AddNewAudioSourceInPool();
			}
			yield return new WaitForEndOfFrame();
		}
	}

	private AudioSource AddNewAudioSourceInPool()
	{
		GameObject obj = Object.Instantiate(audioSourcePrefab, base.transform);
		obj.AddComponent<CustomAudioReplay>();
		obj.AddComponent<ReplayObject>().RebuildComponentList();
		AudioSource component = obj.GetComponent<AudioSource>();
		audioSourcePool.Add(component);
		return component;
	}

	public void SetAudioReplayStatus(bool shouldRemoveFromReplay)
	{
		if ((shouldReplayAudios && !shouldRemoveFromReplay) || (!shouldReplayAudios && shouldRemoveFromReplay))
		{
			return;
		}
		foreach (AudioSource item in audioSourcePool)
		{
			InternalAddOrRemoveAudioReplay(item);
		}
		foreach (AudioSourceInUse item2 in audioSourcesInUse)
		{
			InternalAddOrRemoveAudioReplay(item2.AudioSource);
		}
		shouldReplayAudios = !shouldRemoveFromReplay;
		void InternalAddOrRemoveAudioReplay(AudioSource audioSource)
		{
			if (shouldRemoveFromReplay)
			{
				CustomAudioReplay component = audioSource.gameObject.GetComponent<CustomAudioReplay>();
				if (component != null)
				{
					Object.Destroy(component);
				}
				ReplayObject component2 = audioSource.gameObject.GetComponent<ReplayObject>();
				if (component2 != null)
				{
					Object.Destroy(component2);
				}
			}
			else
			{
				audioSource.gameObject.AddComponent<CustomAudioReplay>();
				audioSource.gameObject.AddComponent<ReplayObject>().RebuildComponentList();
			}
		}
	}

	public AudioSource RequestAudioSource()
	{
		AudioSource audioSource = audioSourcePool.FirstOrDefault((AudioSource audioSource2) => !audioSource2.isPlaying);
		if (audioSource == null)
		{
			audioSource = AddNewAudioSourceInPool();
		}
		audioSourcePool.Remove(audioSource);
		audioSourcesInUse.Add(new AudioSourceInUse
		{
			AudioSource = audioSource
		});
		return audioSource;
	}

	public void RecycleAudioSource(AudioSource audioSource)
	{
		if (audioSourcePool.Contains(audioSource))
		{
			return;
		}
		audioSource.Stop();
		audioSource.pitch = 1f;
		audioSource.loop = false;
		audioSourcePool.Add(audioSource);
		AudioSourceInUse audioSourceInUse = null;
		for (int i = 0; i < audioSourcesInUse.Count; i++)
		{
			if (audioSourcesInUse[i].AudioSource == audioSource)
			{
				audioSourceInUse = audioSourcesInUse[i];
				break;
			}
		}
		if (audioSourceInUse != null)
		{
			audioSourcesInUse.Remove(audioSourceInUse);
		}
	}

	public void PauseAudioSourcesInUse()
	{
		for (int i = 0; i < audioSourcesInUse.Count; i++)
		{
			audioSourcesInUse[i].WasAudioPlaying = audioSourcesInUse[i].AudioSource.isPlaying;
			if (audioSourcesInUse[i].WasAudioPlaying)
			{
				audioSourcesInUse[i].AudioSource.Stop();
			}
		}
		IsAudioSourcesInPause = true;
	}

	public void UnPauseAudioSourcesInUse()
	{
		for (int i = 0; i < audioSourcesInUse.Count; i++)
		{
			if (audioSourcesInUse[i].WasAudioPlaying)
			{
				audioSourcesInUse[i].AudioSource.Play();
			}
		}
		IsAudioSourcesInPause = false;
	}

	public void PlayOnceEffect(AudioEffectData audioEffectData, Vector3 worldPosition)
	{
		if (ShouldPlayClip(audioEffectData))
		{
			if (audioEffectData.LoudnessIntensity == AudioEffectData.Loudness.VeryHigh)
			{
				float num = Vector3.Distance(GameManager.Instance.CameraManager.OrbitCamera.WorldPosition, worldPosition);
				float attenuationRate = 1f - num / 50f;
				MusicManager.Instance.MusicAttenuation(0.5f, 0.2f, attenuationRate);
			}
			AudioSource audioSource = audioSourcePool.FirstOrDefault((AudioSource audioSource2) => !audioSource2.isPlaying);
			if (audioSource == null)
			{
				audioSource = AddNewAudioSourceInPool();
			}
			audioSource.clip = audioEffectData.AudioClip;
			audioSource.volume = audioEffectData.Volume;
			audioSource.pitch = audioEffectData.Pitch;
			audioSource.priority = audioEffectData.Priority;
			audioSource.gameObject.transform.position = worldPosition;
			audioSource.Play();
			audiosPlayedHistory.Enqueue(new PlayedAudioClip(audioEffectData.AudioClip, Time.time));
			if (audiosPlayedHistory.Count > audiosPlayedHistorySize)
			{
				audiosPlayedHistory.Dequeue();
			}
		}
	}

	private bool ShouldPlayClip(AudioEffectData audioEffectData)
	{
		float num = ClosestTimeClipLastPlayed(audioEffectData);
		switch (audioEffectData.LoudnessIntensity)
		{
		case AudioEffectData.Loudness.VeryLow:
			return num > 0.3f;
		case AudioEffectData.Loudness.Low:
			return num > 0.15f;
		case AudioEffectData.Loudness.Medium:
			return num > 0.1f;
		default:
			return true;
		}
	}

	private bool IsSameClipPlaying(AudioEffectData audioEffectData, float maxLastPlayedDelay)
	{
		foreach (PlayedAudioClip item in audiosPlayedHistory)
		{
			if (!(audioEffectData.AudioClip != item.AudioClip) && Time.time - item.Timestamp <= maxLastPlayedDelay)
			{
				return true;
			}
		}
		return false;
	}

	private float ClosestTimeClipLastPlayed(AudioEffectData audioEffectData)
	{
		float num = float.PositiveInfinity;
		foreach (PlayedAudioClip item in audiosPlayedHistory)
		{
			if (!(audioEffectData.AudioClip != item.AudioClip))
			{
				num = Mathf.Min(Time.time - item.Timestamp, num);
			}
		}
		return num;
	}
}
