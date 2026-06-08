using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
	[NonSerialized]
	public string title;

	[NonSerialized]
	public AudioClip message;

	[NonSerialized]
	public string transcriptText;

	private void Start()
	{
		GetComponentInChildren<TextMeshProUGUI>().text = title;
		Button messageButton = GetComponent<Button>();
		messageButton.onClick.AddListener(delegate
		{
			MessageContainerController componentInParent = GetComponentInParent<MessageContainerController>();
			componentInParent.SetMessage(this);
			componentInParent.PlayMessageClickEffect();
			messageButton.interactable = false;
		});
	}

	public void SetMessage(Message message)
	{
		title = message.title;
		this.message = message.message;
		transcriptText = message.transcriptText;
	}
}
