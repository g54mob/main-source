using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AmbienceMusicData
{
	[Tooltip("Müzik listesi")]
	public List<AmbienceSoundClip> musicClips = new List<AmbienceSoundClip>();

	[Tooltip("Müzikler arası sessiz bekleme süresi (min-max saniye)")]
	[SerializeField]
	private Vector2 m_NonMusicTimer = new Vector2(5f, 15f);

	[Tooltip("Fade in/out süresi (saniye)")]
	[SerializeField]
	private float m_FadeDuration = 1f;

	[Tooltip("Hep aynı müziği çal")]
	public bool playSameMusic;

	private int lastPlayedIndex = -1;

	public Vector2 NonMusicTimer => m_NonMusicTimer;

	public float FadeDuration => m_FadeDuration;

	public float GetRandomNonMusicTime()
	{
		return UnityEngine.Random.Range(m_NonMusicTimer.x, m_NonMusicTimer.y);
	}

	public AmbienceSoundClip GetRandomMusicClip()
	{
		if (musicClips == null || musicClips.Count == 0)
		{
			return null;
		}
		if (musicClips.Count == 1 || playSameMusic)
		{
			lastPlayedIndex = 0;
			return musicClips[0];
		}
		int num;
		do
		{
			num = UnityEngine.Random.Range(0, musicClips.Count);
		}
		while (num == lastPlayedIndex && musicClips.Count > 1);
		lastPlayedIndex = num;
		return musicClips[num];
	}

	public bool HasMusic()
	{
		if (musicClips != null)
		{
			return musicClips.Count > 0;
		}
		return false;
	}
}
