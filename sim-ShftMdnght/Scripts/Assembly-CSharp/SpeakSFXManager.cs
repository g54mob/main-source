using UnityEngine;

public class SpeakSFXManager : MonoBehaviour
{
	public AudioSource[] audios;

	public float maxPitch;

	public float minPitch;

	public void PlaySFX()
	{
		AudioSource[] array = audios;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Stop();
		}
		int num = Random.Range(0, audios.Length - 1);
		audios[num].pitch = Random.Range(minPitch, maxPitch);
		audios[num].Play();
	}
}
