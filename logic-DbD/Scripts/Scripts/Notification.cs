using UnityEngine;
using UnityEngine.UI;

public class Notification : SoundEffectPlayer
{
	[SerializeField]
	private AudioClip errorAudio;

	[SerializeField]
	private AudioClip warningAudio;

	[SerializeField]
	private AudioClip loginAudio;

	[SerializeField]
	private AudioClip renameAudio;

	[SerializeField]
	private AudioClip renameSuccessAudio;

	[SerializeField]
	private AudioClip emptyResults;

	[SerializeField]
	private AudioClip loadClue;

	[SerializeField]
	private AudioClip toggleOn;

	[SerializeField]
	private AudioClip toggleOff;

	public void PlayError()
	{
		audioPlayer.PlayOneShot(errorAudio);
	}

	public void PlayWarning()
	{
		audioPlayer.PlayOneShot(warningAudio);
	}

	public void PlayLogin()
	{
		audioPlayer.PlayOneShot(loginAudio);
	}

	public void PlayRename()
	{
		audioPlayer.PlayOneShot(renameAudio);
	}

	public void PlayRenameSuccess()
	{
		audioPlayer.PlayOneShot(renameSuccessAudio);
	}

	public void PlayEmptyResults()
	{
		audioPlayer.PlayOneShot(emptyResults);
	}

	public void PlayLoadClue()
	{
		audioPlayer.PlayOneShot(loadClue);
	}

	public void PlayToggle(bool toggleValue)
	{
		audioPlayer.PlayOneShot(toggleValue ? toggleOn : toggleOff);
	}

	public void AddToggleListener(Toggle toggle)
	{
		toggle.onValueChanged.AddListener(PlayToggle);
	}
}
