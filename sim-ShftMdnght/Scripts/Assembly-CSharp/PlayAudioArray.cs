using UnityEngine;

public class PlayAudioArray : MonoBehaviour
{
	public float maxPitch;

	public float minPitch;

	public AudioSource[] audios;

	private int index;

	public void PlayAudio()
	{
		audios[index].pitch = Random.Range(minPitch, maxPitch);
		audios[index].Play();
		index++;
		if (index >= audios.Length)
		{
			index = 0;
		}
	}
}
