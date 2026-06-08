using UnityEngine;

public class ClosePanelAudio : SoundEffectPlayer
{
	[SerializeField]
	private AudioClip closeAudio;

	[SerializeField]
	private AudioClip openAudio;

	[SerializeField]
	private AudioClip destroyAudio;

	[SerializeField]
	private AudioClip doorClose;

	[SerializeField]
	private AudioSwitcher gunshot;

	[SerializeField]
	private AudioSwitcher explosion;

	[SerializeField]
	private AudioClip minimize;

	[SerializeField]
	private AudioClip maximize;

	private static float DEFAULT_VOLUME = 0.25f;

	public void PlayClose()
	{
		audioPlayer.volume = DEFAULT_VOLUME;
		audioPlayer.PlayOneShot(closeAudio);
	}

	public void PlayOpen()
	{
		audioPlayer.volume = DEFAULT_VOLUME;
		audioPlayer.PlayOneShot(openAudio);
	}

	public void PlayDoorClose()
	{
		audioPlayer.volume = DEFAULT_VOLUME;
		audioPlayer.PlayOneShot(doorClose);
	}

	public void PlayDestroy()
	{
		audioPlayer.volume = DEFAULT_VOLUME;
		gunshot.PlayEffect();
	}

	public void PlayExplosion()
	{
		audioPlayer.volume = 0.5f;
		explosion.PlayEffect();
	}

	public void PlayMaximize()
	{
		audioPlayer.volume = DEFAULT_VOLUME;
		audioPlayer.PlayOneShot(maximize);
	}

	public void PlayMinimize()
	{
		audioPlayer.volume = DEFAULT_VOLUME;
		audioPlayer.PlayOneShot(minimize);
	}
}
