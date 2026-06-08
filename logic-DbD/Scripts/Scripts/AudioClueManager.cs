public class AudioClueManager : AudioTranscriptManager
{
	public void OnEnable()
	{
		iconSwitcher.PauseSprite();
		audioSource.Play();
		StartCoroutine(StartAudio());
	}

	public override string GetTranscriptTitleName()
	{
		return audioSource.clip.name + " Transcript";
	}

	public override void LaunchTranscript()
	{
		if (!taskbarManager.IsMaximumTaskbarButtons(transcriptPopup))
		{
			base.LaunchTranscript();
			taskbarManager.AddTaskbar(transcriptPopup, transcriptTaskbarSprite, "Transcript");
		}
	}
}
