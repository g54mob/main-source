using DG.Tweening;
using TMPro;
using UnityEngine;

public class ScreenNoteManager : MonoBehaviour
{
	public delegate void NoteEnd();

	public NoteEnd NoteEndCallback;

	[SerializeField]
	private TMP_Text mainText;

	[SerializeField]
	private GameObject continueButton;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void ShowNote(string storyText)
	{
		base.gameObject.SetActive(value: true);
		continueButton.SetActive(value: true);
		mainText.text = storyText;
	}

	public void CloseNote()
	{
		NoteEndCallback();
		base.gameObject.SetActive(value: false);
	}

	public void ShowNoteNotification(string notificationText, int duration)
	{
		continueButton.SetActive(value: false);
		base.gameObject.SetActive(value: true);
		mainText.SetText(string.Empty);
		mainText.text = notificationText;
		base.gameObject.GetComponent<CanvasGroup>().alpha = 0f;
		base.gameObject.GetComponent<CanvasGroup>().DOFade(1f, 0.15f);
		Invoke("DisableNote", duration);
	}

	public void DisableNote()
	{
		base.gameObject.GetComponent<CanvasGroup>().DOFade(0f, 0.5f).OnComplete(delegate
		{
			base.gameObject.GetComponent<CanvasGroup>().alpha = 1f;
			base.gameObject.SetActive(value: false);
		});
	}
}
