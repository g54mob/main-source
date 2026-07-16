using UnityEngine;

public class SfxHelper : MonoBehaviour
{
	[SerializeField]
	private AudioSource audioSource;

	public void PlaySoundEffect(AudioClip clip, float volume, float pitch)
	{
		audioSource.clip = clip;
		audioSource.volume = volume;
		audioSource.pitch = pitch;
		audioSource.Play();
	}
}
