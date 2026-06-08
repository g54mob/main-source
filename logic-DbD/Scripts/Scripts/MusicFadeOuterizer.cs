using System.Collections;
using UnityEngine;

public class MusicFadeOuterizer : MonoBehaviour
{
	[SerializeField]
	private AudioSource audioSource;

	private float? previousVolume;

	public void FadeOut()
	{
		if (!audioSource.isPlaying)
		{
			previousVolume = null;
			return;
		}
		previousVolume = audioSource.volume;
		StartCoroutine(FadeOutRoutine());
	}

	public void FadeIn()
	{
		if (previousVolume.HasValue)
		{
			StartCoroutine(FadeInRoutine());
		}
	}

	private IEnumerator FadeOutRoutine()
	{
		while (audioSource.volume > 0f)
		{
			yield return new WaitForSeconds(0.1f);
			audioSource.volume -= 0.01f;
		}
	}

	private IEnumerator FadeInRoutine()
	{
		while (audioSource.volume < previousVolume)
		{
			yield return new WaitForSeconds(0.1f);
			audioSource.volume += 0.01f;
		}
	}
}
