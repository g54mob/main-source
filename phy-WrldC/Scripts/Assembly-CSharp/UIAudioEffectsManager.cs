using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAudioEffectsManager : MonoBehaviour
{
	[SerializeField]
	private GameObject audioSourcePrefab;

	[SerializeField]
	private int poolSize = 5;

	private List<AudioSource> audioSourcePool;

	public static UIAudioEffectsManager Instance => Singleton<UIAudioEffectsManager>.Instance;

	public static bool Exist => Singleton<UIAudioEffectsManager>.Exist;

	private void Awake()
	{
		audioSourcePool = new List<AudioSource>();
	}

	public IEnumerator PopulateAudioSourcePool()
	{
		if (audioSourcePool.Count <= 0)
		{
			for (int i = 0; i < poolSize; i++)
			{
				AudioSource component = Object.Instantiate(audioSourcePrefab, base.transform).GetComponent<AudioSource>();
				audioSourcePool.Add(component);
			}
			yield return new WaitForEndOfFrame();
		}
	}

	public void PlayAudio(AudioClip audioClip, float linearVolume = 1f)
	{
		for (int i = 0; i < audioSourcePool.Count; i++)
		{
			if (!audioSourcePool[i].isPlaying || i == audioSourcePool.Count - 1)
			{
				audioSourcePool[i].clip = audioClip;
				audioSourcePool[i].volume = linearVolume;
				audioSourcePool[i].Play();
				break;
			}
		}
	}
}
