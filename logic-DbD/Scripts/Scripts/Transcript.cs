using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Transcript : Panel
{
	[SerializeField]
	protected TextMeshProUGUI message;

	[SerializeField]
	protected Image success;

	[SerializeField]
	protected Image warning;

	[SerializeField]
	protected Image error;

	[SerializeField]
	protected Image checkmark;

	protected int VERTICAL_MARGIN = 160;

	protected int LINE_SIZE = 30;

	protected int HORIZONTAL_MARGIN = 200;

	protected int lines;

	public virtual void Resize()
	{
		lines = message.text.Split('\n').Length;
		RectTransform component = GetComponent<RectTransform>();
		component.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, lines * LINE_SIZE + VERTICAL_MARGIN);
		component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, message.preferredWidth + (float)HORIZONTAL_MARGIN);
	}

	public void SetIcon(NotificationHandler.Icon icon)
	{
		error.gameObject.SetActive(icon == NotificationHandler.Icon.ERROR);
		warning.gameObject.SetActive(icon == NotificationHandler.Icon.WARNING);
		success.gameObject.SetActive(icon == NotificationHandler.Icon.DOWNLOAD_SUCCESS);
		checkmark.gameObject.SetActive(icon == NotificationHandler.Icon.GENERIC_SUCCESS);
	}

	public void SetTranscript(string transcript)
	{
		message.text = transcript;
		Debug.Log("transcript=" + transcript);
		lines = message.text.Split('\n').Length;
	}

	public string GetTranscript()
	{
		return message.text;
	}

	protected override IEnumerator OnPanelClose(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		if (!isOpen)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
