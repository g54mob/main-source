using System.Collections;
using TMPro;
using UnityEngine;

public class AudioMessageManager : AudioTranscriptManager
{
	[SerializeField]
	private MessageSpawner messages;

	[SerializeField]
	private TextMeshProUGUI messageTitle;

	[SerializeField]
	private TutorialSpawner tutorialSpawner;

	[SerializeField]
	private MusicManager musicController;

	[SerializeField]
	private CallPopupCreator callPopup;

	protected override void Start()
	{
		base.Start();
		SetMaxProgress();
	}

	private void OnEnable()
	{
		callPopup.ClosePopup();
	}

	public void UpdateMessages(int currLevel, bool isCorrectArrest)
	{
		messages.AddLevelStartMessage(currLevel, isCorrectArrest);
		SetMaxProgress();
	}

	public void UpdateMessages(int currLevel, MessageSpawner.MessageCodes messageNumber)
	{
		messages.AddLevelStartMessage(currLevel, messageNumber);
		SetMaxProgress();
	}

	public void SetDisplayMessage(Message message)
	{
		if (audioSource.isPlaying)
		{
			ResetAudio();
		}
		messageTitle.text = message.title;
		SetMessage(message);
	}

	public override void LaunchTranscript()
	{
		if (!(transcriptTaskbarSprite != null) || !taskbarManager.IsMaximumTaskbarButtons(transcriptPopup))
		{
			base.LaunchTranscript();
			Save.SetIntroPlayed();
			if (transcriptTaskbarSprite != null)
			{
				taskbarManager.AddTaskbar(transcriptPopup, transcriptTaskbarSprite, "Transcript");
			}
		}
	}

	public override string GetTranscriptTitleName()
	{
		return messageTitle.text;
	}

	protected override IEnumerator StartAudio()
	{
		while (audioSource.isPlaying)
		{
			yield return new WaitForSeconds(AUDIO_WAIT_TIME);
			progressSlider.value = audioSource.time;
			yield return null;
		}
		if (!isPaused)
		{
			tutorialSpawner.SpawnAssistant();
			ResetAudio();
		}
	}

	public override void PlayAudio()
	{
		Debug.Log($"{audioSource.clip.length}");
		isPaused = audioSource.isPlaying;
		if (audioSource.isPlaying)
		{
			tutorialSpawner.SpawnAssistant();
			Debug.Log("Stop");
			iconSwitcher.PlaySprite();
			audioSource.Pause();
			return;
		}
		if (messageTitle.text == MessageSpawner.MESSAGE_NAMES[0])
		{
			musicController.SetVolume();
			musicController.SetSong("MusicByPedro - Noire #1");
			musicController.PlayAudio();
		}
		Debug.Log("Play");
		iconSwitcher.PauseSprite();
		audioSource.Play();
		StartCoroutine(StartAudio());
		Save.SetIntroPlayed();
	}
}
