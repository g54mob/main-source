using System;
using UnityEngine;

namespace HQFPSTemplate
{
	[Serializable]
	public class SoundPlayer : ICloneable
	{
		[SerializeField]
		[Reorderable]
		private AudioClipList m_Clips;

		[Space(5f)]
		[SerializeField]
		[SimpleMinMax(0f, 1f)]
		private Vector2 m_VolumeRange = new Vector2(0.5f, 0.75f);

		[SerializeField]
		[SimpleMinMax(0.5f, 1.5f)]
		private Vector2 m_PitchRange = new Vector2(0.9f, 1.1f);

		[SerializeField]
		[Range(0f, 1f)]
		private float m_VolumeMultiplier = 1f;

		private int m_LastClipPlayed = -1;

		public int ClipCount => m_Clips.Count;

		public object Clone()
		{
			return MemberwiseClone();
		}

		public void Play(AudioSource audioSource, float volume = 1f)
		{
			Play(ItemSelection.Method.RandomExcludeLast, audioSource, volume);
		}

		public void Play(ItemSelection.Method selectionMethod, AudioSource audioSource, float volume = 1f)
		{
			if ((bool)audioSource && m_Clips.Count != 0)
			{
				if (m_LastClipPlayed >= m_Clips.Count || m_LastClipPlayed <= -1)
				{
					m_LastClipPlayed = m_Clips.Count - 1;
				}
				AudioClip clip = m_Clips.List.Select(ref m_LastClipPlayed, selectionMethod);
				float volumeScale = GetVolume() * volume;
				audioSource.pitch = UnityEngine.Random.Range(m_PitchRange.x, m_PitchRange.y);
				audioSource.PlayOneShot(clip, volumeScale);
			}
		}

		public void PlayAtPosition(ItemSelection.Method selectionMethod, Vector3 position, float volume = 1f)
		{
			if (m_Clips.Count != 0)
			{
				AudioSource.PlayClipAtPoint(m_Clips.List.Select(ref m_LastClipPlayed, selectionMethod), position, GetVolume() * volume);
			}
		}

		public void Play2D(ItemSelection.Method selectionMethod = ItemSelection.Method.RandomExcludeLast, float volume = 1f)
		{
			if (m_Clips.Count != 0)
			{
				AudioClip clip = m_Clips.List.Select(ref m_LastClipPlayed, selectionMethod);
				Singleton<AudioUtils>.Instance.Play2D(clip, GetVolume() * volume);
			}
		}

		private float GetVolume()
		{
			return UnityEngine.Random.Range(m_VolumeRange.x, m_VolumeRange.y) * m_VolumeMultiplier;
		}
	}
}
