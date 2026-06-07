using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public static SoundManager Instance;

	[SerializeField]
	private List<LayerSFXData> layerSFXList = new List<LayerSFXData>();

	[SerializeField]
	private List<GameObject> audioSources = new List<GameObject>();

	private AudioSource[] _cachedAudioSources;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			if (audioSources == null)
			{
				return;
			}
			_cachedAudioSources = new AudioSource[audioSources.Count];
			for (int i = 0; i < audioSources.Count; i++)
			{
				if (audioSources[i] != null)
				{
					_cachedAudioSources[i] = audioSources[i].GetComponent<AudioSource>();
				}
			}
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}

	public void PlaySFXAtPosition(LayerSFX layerSFX, Vector3 position)
	{
		if (layerSFX == LayerSFX.None)
		{
			return;
		}
		LayerSFXData layerSFXData = null;
		foreach (LayerSFXData layerSFX2 in layerSFXList)
		{
			if (layerSFX2.layerSFX == layerSFX)
			{
				layerSFXData = layerSFX2;
				break;
			}
		}
		if (layerSFXData == null || layerSFXData.audioClips == null || layerSFXData.audioClips.Count == 0)
		{
			return;
		}
		int index = Random.Range(0, layerSFXData.audioClips.Count);
		AudioClip audioClip = layerSFXData.audioClips[index];
		if (audioClip == null || _cachedAudioSources == null || _cachedAudioSources.Length == 0)
		{
			return;
		}
		int num = _cachedAudioSources.Length;
		int num2 = Random.Range(0, num);
		for (int i = 0; i < num; i++)
		{
			int num3 = (num2 + i) % num;
			AudioSource audioSource = _cachedAudioSources[num3];
			if (!(audioSource == null))
			{
				GameObject gameObject = audioSources[num3];
				if (!(gameObject == null) && (!gameObject.activeSelf || !audioSource.isPlaying))
				{
					gameObject.transform.position = position;
					gameObject.SetActive(value: true);
					audioSource.volume = layerSFXData.volume;
					audioSource.clip = audioClip;
					audioSource.Play();
					StartCoroutine(DeactivateAfterPlay(audioSource, gameObject));
					break;
				}
			}
		}
	}

	private IEnumerator DeactivateAfterPlay(AudioSource audioSource, GameObject audioSourceObj)
	{
		if (audioSource.clip != null)
		{
			yield return new WaitForSeconds(audioSource.clip.length);
		}
		else
		{
			while (audioSource.isPlaying)
			{
				yield return null;
			}
		}
		if (audioSourceObj != null)
		{
			audioSourceObj.SetActive(value: false);
		}
	}
}
