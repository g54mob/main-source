using UnityEngine;

public class ArrestAudio : SoundEffectPlayer
{
	[SerializeField]
	private AudioClip stamp;

	[SerializeField]
	private AudioClip warrant;

	public void PlayStamp()
	{
		audioPlayer.PlayOneShot(stamp);
	}

	public void PlayWarrant()
	{
		audioPlayer.PlayOneShot(warrant);
	}
}
