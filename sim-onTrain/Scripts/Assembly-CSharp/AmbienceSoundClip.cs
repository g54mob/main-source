using System;
using UnityEngine;

[Serializable]
public class AmbienceSoundClip
{
	public AudioClip clip;

	[Tooltip("Ses seviyesi (0-1)")]
	[Range(0f, 1f)]
	public float volume = 0.5f;

	[Tooltip("Bu sesin çalma süresi (min-max saniye)")]
	public Vector2 playTimeRange = new Vector2(30f, 60f);

	public float GetRandomPlayTime()
	{
		return UnityEngine.Random.Range(playTimeRange.x, playTimeRange.y);
	}
}
