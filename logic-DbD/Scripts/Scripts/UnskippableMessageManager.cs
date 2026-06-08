using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class UnskippableMessageManager : AudioTranscriptManager
{
	[SerializeField]
	private TextMeshProUGUI messageTitle;

	protected override void Start()
	{
		base.Start();
		SetMaxProgress();
	}

	public void SetDisplayMessage(Message message)
	{
		messageTitle.text = message.title;
		SetMessage(message);
	}

	public override string GetTranscriptTitleName()
	{
		return "Transcript";
	}

	public override void LaunchTranscript()
	{
		base.LaunchTranscript();
		Transform minimize = transcriptPopup.GetComponentInChildren<Toolbar>().GetMinimize();
		Debug.Log(minimize);
		minimize.gameObject.SetActive(value: false);
	}

	protected IEnumerator StartAudio(Action afterCallAction)
	{
		while (audioSource.isPlaying)
		{
			yield return new WaitForSeconds(AUDIO_WAIT_TIME);
			progressSlider.value = audioSource.time;
			yield return null;
		}
		afterCallAction();
		base.transform.parent.GetComponent<Panel>().ClosePanel();
	}

	public void PlayAudio(Action afterCallAction)
	{
		Debug.Log("Play");
		audioSource.Play();
		StartCoroutine(StartAudio(afterCallAction));
	}
}
