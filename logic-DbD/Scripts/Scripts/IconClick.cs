using UnityEngine;

public class IconClick : SoundEffectPlayer
{
	[SerializeField]
	private AudioClip click1;

	[SerializeField]
	private AudioClip click2;

	public void PlaySingleClick(float pitch)
	{
		audioPlayer.pitch = pitch;
		audioPlayer.PlayOneShot(click1);
	}

	public void PlayDoubleClick(float pitch)
	{
		audioPlayer.pitch = pitch;
		audioPlayer.PlayOneShot(click2);
	}
}
