using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioKeyHolder : Singleton<AudioKeyHolder>
{
	[Header("Bank")]
	[SerializeField]
	private List<AudioItem> items = new List<AudioItem>();

	[Header("Defaults")]
	[SerializeField]
	private AudioMixerGroup defaultSfxGroup;

	private Dictionary<AudioKey, AudioItem> map;

	private void Awake()
	{
		BuildMap();
	}

	private void BuildMap()
	{
		map = new Dictionary<AudioKey, AudioItem>(items.Count);
		foreach (AudioItem item in items)
		{
			if (!(item == null) && !(item.clip == null))
			{
				map[item.key] = item;
			}
		}
	}

	public void PlayAt(AudioKey key, Vector3 position)
	{
		if (map.TryGetValue(key, out var value) && !(value.clip == null))
		{
			GameObject obj = new GameObject($"SFX_{key}");
			obj.transform.position = position;
			AudioSource audioSource = obj.AddComponent<AudioSource>();
			audioSource.clip = value.clip;
			audioSource.volume = value.volume;
			audioSource.pitch = value.pitch;
			audioSource.spatialBlend = (value.spatial ? value.spatialBlend : 0f);
			audioSource.minDistance = value.minDistance;
			audioSource.maxDistance = Mathf.Max(value.maxDistance, value.minDistance + 0.01f);
			AudioMixerGroup audioMixerGroup = ((value.mixerGroupOverride != null) ? value.mixerGroupOverride : defaultSfxGroup);
			if ((bool)audioMixerGroup)
			{
				audioSource.outputAudioMixerGroup = audioMixerGroup;
			}
			audioSource.Play();
			float t = value.clip.length / Mathf.Max(0.01f, value.pitch) + 0.1f;
			Object.Destroy(obj, t);
		}
	}

	public void Play2D(AudioKey key)
	{
		if (map.TryGetValue(key, out var value) && !(value.clip == null))
		{
			Singleton<AudioManager>.Instance?.PlaySFX(value.clip, value.volume);
		}
	}
}
