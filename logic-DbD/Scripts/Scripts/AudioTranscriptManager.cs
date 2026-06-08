using System;
using System.Collections;
using UnityEngine;

public class AudioTranscriptManager : AudioManager
{
	[SerializeField]
	protected GameObject transcriptPrefab;

	[SerializeField]
	protected Toolbar toolbar;

	[SerializeField]
	protected Sprite transcriptTaskbarSprite;

	protected ClosePanelAudio audioPlayer;

	protected GameObject transcriptPopup;

	protected string transcript;

	protected Canvas canvas;

	protected bool isPaused;

	protected TaskbarManager taskbarManager;

	protected virtual void Awake()
	{
		canvas = UIUtils.FindCanvasFromChild(base.transform);
		audioPlayer = SoundEffectUtils.GetOpenClosePanelPlayer();
		taskbarManager = GameObject.Find("Canvas/Icon Container").GetComponent<TaskbarManager>();
		transcriptPopup = null;
		toolbar.AddCloseFunction(base.ResetAudio);
		float? volume = PlayerPrefsManager.GetVolume(PlayerPrefsManager.MESSAGE_VOLUME);
		SetVolume(volume.HasValue ? volume.Value : volumeSlider.value);
	}

	public override void SetVolume(float sliderValue)
	{
		PlayerPrefs.SetFloat(PlayerPrefsManager.MESSAGE_VOLUME, sliderValue);
		audioSource.volume = sliderValue;
		volumeSlider.value = sliderValue;
	}

	public void SetAudioClip(AudioClip clip)
	{
		audioSource.clip = clip;
		SetMaxProgress();
	}

	public void SetTranscript(string transcript)
	{
		this.transcript = transcript;
	}

	public void SetMessage(Message message)
	{
		SetAudioClip(message.message);
		SetTranscript(message.transcriptText);
	}

	public virtual void LaunchTranscript()
	{
		audioPlayer.PlayOpen();
		if (!transcriptPopup)
		{
			string transcriptTitleName = GetTranscriptTitleName();
			transcriptPopup = UIUtils.LaunchTextPopup(transcriptPrefab, canvas, transcriptTitleName, transcript);
		}
		else if (transcriptPopup.GetComponent<Transcript>().GetTranscript() != transcript)
		{
			UIUtils.SetTextPopup(transcriptPopup, transcript);
			UIUtils.SetTitlePopup(transcriptPopup, GetTranscriptTitleName());
		}
		PanelManager.OpenWindow(transcriptPopup);
	}

	public override void PlayAudio()
	{
		Debug.Log($"{audioSource.clip.length}");
		isPaused = audioSource.isPlaying;
		if (audioSource.isPlaying)
		{
			Debug.Log("Stop");
			iconSwitcher.PlaySprite();
			audioSource.Pause();
		}
		else
		{
			Debug.Log("Play");
			iconSwitcher.PauseSprite();
			audioSource.Play();
			StartCoroutine(StartAudio());
		}
	}

	protected virtual IEnumerator StartAudio()
	{
		while (audioSource.isPlaying)
		{
			yield return new WaitForSeconds(AUDIO_WAIT_TIME);
			progressSlider.value = audioSource.time;
			yield return null;
		}
		if (!isPaused)
		{
			ResetAudio();
		}
	}

	public virtual string GetTranscriptTitleName()
	{
		throw new Exception("GetTranscriptTitleName function cannot be called without overriding");
	}
}
