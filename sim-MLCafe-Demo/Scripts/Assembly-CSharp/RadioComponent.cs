using UnityEngine;

public class RadioComponent : MonoBehaviour
{
	[SerializeField]
	private string[] musicKeys;

	[SerializeField]
	private string soundInteraction;

	[SerializeField]
	private ParticleSystem psNotes;

	private int musicIndex;

	private void Start()
	{
		SoundManager.OnChangeMusicEvent.AddListener(ShowVFX);
		SoundManager.OnStopMusicEvent.AddListener(HideVFX);
		if (SoundManager.IsPlayingMusic())
		{
			ShowVFX();
		}
	}

	public void OnToggleRadio()
	{
		if (SoundManager.IsPlayingMusic())
		{
			SoundManager.StopMusic();
		}
		else
		{
			SoundManager.ChangeMusic(musicKeys[musicIndex]);
		}
		SoundManager.PlaySoundOnce(soundInteraction);
	}

	public void OnChangeMusic()
	{
		musicIndex++;
		if (musicIndex >= musicKeys.Length)
		{
			musicIndex = 0;
		}
		SoundManager.ChangeMusic(musicKeys[musicIndex]);
		SoundManager.PlaySoundOnce(soundInteraction);
	}

	private void ShowVFX()
	{
		if (psNotes != null)
		{
			psNotes.Play();
		}
	}

	private void HideVFX()
	{
		if (psNotes != null)
		{
			psNotes.Stop();
		}
	}
}
