using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EastupSoundData
{
	[Tooltip("Sesin enum değeri")]
	public GameAudios audioName;

	[Tooltip("Çalınacak ses dosyaları listesi")]
	public List<AudioClip> audioClips = new List<AudioClip>();

	[Tooltip("Ses yüksekliği aralığı (0-1)")]
	[SerializeField]
	private Vector2 m_VolumeRange = new Vector2(0.5f, 0.75f);

	[Tooltip("Pitch aralığı (0.5-1.5)")]
	[SerializeField]
	private Vector2 m_PitchRange = new Vector2(0.9f, 1.1f);

	[Tooltip("Ses yüksekliği çarpanı")]
	[Range(0f, 1f)]
	public float volumeMultiplier = 1f;

	[Header("Spatial Settings")]
	[Tooltip("Sesin tam duyulduğu minimum mesafe")]
	public float minDistance = 1f;

	[Tooltip("Sesin artık duyulmadığı maksimum mesafe")]
	public float maxDistance = 50f;

	[Header("Network")]
	[Tooltip("true = sadece local client'ta çalar, false = tüm clientlara network üzerinden gönderir")]
	public bool isLocalOnly;

	public Vector2 VolumeRange => m_VolumeRange;

	public Vector2 PitchRange => m_PitchRange;

	public AudioClip GetAudioClip()
	{
		if (audioClips == null || audioClips.Count == 0)
		{
			Debug.LogWarning($"AudioClips list is empty for {audioName}");
			return null;
		}
		int index = UnityEngine.Random.Range(0, audioClips.Count);
		return audioClips[index];
	}
}
