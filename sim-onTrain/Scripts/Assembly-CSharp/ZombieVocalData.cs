using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ZombieVocalData
{
	[Tooltip("Ses listesi")]
	public List<ZombieSoundClip> sounds;

	[Tooltip("Sesler arası bekleme süresi (min-max saniye)")]
	public Vector2 intervalRange = new Vector2(5f, 15f);

	public float GetRandomInterval()
	{
		return UnityEngine.Random.Range(intervalRange.x, intervalRange.y);
	}

	public ZombieSoundClip GetRandomSound()
	{
		if (sounds == null || sounds.Count == 0)
		{
			return null;
		}
		return sounds[UnityEngine.Random.Range(0, sounds.Count)];
	}

	public bool HasSounds()
	{
		if (sounds != null)
		{
			return sounds.Count > 0;
		}
		return false;
	}
}
