using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AmbienceEffectData
{
	[Tooltip("Efekt sesleri listesi")]
	public List<AmbienceSoundClip> effectClips = new List<AmbienceSoundClip>();

	[Tooltip("Efektler arası sessiz bekleme süresi (min-max saniye)")]
	[SerializeField]
	private Vector2 m_NonEffectTimer = new Vector2(10f, 25f);

	[Tooltip("Fade in/out süresi (saniye)")]
	[SerializeField]
	private float m_FadeDuration = 0.5f;

	public Vector2 NonEffectTimer => m_NonEffectTimer;

	public float FadeDuration => m_FadeDuration;

	public float GetRandomNonEffectTime()
	{
		return UnityEngine.Random.Range(m_NonEffectTimer.x, m_NonEffectTimer.y);
	}

	public AmbienceSoundClip GetRandomEffectClip()
	{
		if (effectClips == null || effectClips.Count == 0)
		{
			return null;
		}
		return effectClips[UnityEngine.Random.Range(0, effectClips.Count)];
	}

	public bool HasEffects()
	{
		if (effectClips != null)
		{
			return effectClips.Count > 0;
		}
		return false;
	}
}
