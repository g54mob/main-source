using UnityEngine;

public class AudioSwitcher : SoundEffectPlayer
{
	[SerializeField]
	private AudioClip turn1;

	[SerializeField]
	private AudioClip turn2;

	public void PlayEffect()
	{
		if (audioPlayer.clip == turn1)
		{
			audioPlayer.clip = turn2;
		}
		else
		{
			audioPlayer.clip = turn1;
		}
		audioPlayer.Play();
	}
}
