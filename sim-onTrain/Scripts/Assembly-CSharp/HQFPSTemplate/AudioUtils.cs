using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HQFPSTemplate
{
	public class AudioUtils : Singleton<AudioUtils>
	{
		private readonly Dictionary<AudioSource, Coroutine> m_LevelSetters = new Dictionary<AudioSource, Coroutine>();

		[SerializeField]
		private AudioSource m_2DAudioSource;

		public void Play2D(AudioClip clip, float volume)
		{
			if ((bool)m_2DAudioSource)
			{
				m_2DAudioSource.PlayOneShot(clip, volume);
			}
		}

		public static AudioSource CreateAudioSource(string name, Transform parent, Vector3 localPosition, bool is2D = false, float startVolume = 1f, float minDistance = 1f)
		{
			GameObject obj = new GameObject(name, typeof(AudioSource));
			obj.transform.parent = parent;
			obj.transform.localPosition = localPosition;
			AudioSource component = obj.GetComponent<AudioSource>();
			component.volume = startVolume;
			component.spatialBlend = (is2D ? 0f : 1f);
			component.minDistance = minDistance;
			return component;
		}

		public void LerpVolumeOverTime(AudioSource audioSource, float targetVolume, float speed)
		{
			if (m_LevelSetters.ContainsKey(audioSource))
			{
				if (m_LevelSetters[audioSource] != null)
				{
					StopCoroutine(m_LevelSetters[audioSource]);
				}
				m_LevelSetters[audioSource] = StartCoroutine(C_LerpVolumeOverTime(audioSource, targetVolume, speed));
			}
			else
			{
				m_LevelSetters.Add(audioSource, StartCoroutine(C_LerpVolumeOverTime(audioSource, targetVolume, speed)));
			}
		}

		private IEnumerator C_LerpVolumeOverTime(AudioSource audioSource, float volume, float speed)
		{
			while (audioSource != null && Mathf.Abs(audioSource.volume - volume) > 0.01f)
			{
				audioSource.volume = Mathf.MoveTowards(audioSource.volume, volume, Time.deltaTime * speed);
				yield return null;
			}
			if (audioSource.volume == 0f)
			{
				audioSource.Stop();
			}
			m_LevelSetters.Remove(audioSource);
		}
	}
}
