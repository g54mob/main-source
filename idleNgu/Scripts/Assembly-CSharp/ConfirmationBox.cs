using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ConfirmationBox : MonoBehaviour
{
	public Text messageText;

	public GameObject messageBox;

	public Button yesButton;

	public Button noButton;

	public void displayBox(string message, UnityAction yesEvent, UnityAction noEvent)
	{
		messageBox.transform.localPosition = new Vector3(0f, 0f);
		messageBox.transform.SetAsLastSibling();
		messageBox.GetComponent<CanvasRenderer>().SetAlpha(1f);
		yesButton.GetComponentInChildren<Text>().text = "Yeah";
		yesButton.onClick.RemoveAllListeners();
		yesButton.onClick.AddListener(closeBox);
		yesButton.onClick.AddListener(yesEvent);
		noButton.GetComponentInChildren<Text>().text = "Nah";
		noButton.onClick.RemoveAllListeners();
		noButton.onClick.AddListener(closeBox);
		noButton.onClick.AddListener(noEvent);
		messageText.text = message;
	}

	public void displayBox(string message, string yesText, string noText, UnityAction yesEvent, UnityAction noEvent)
	{
		messageBox.transform.localPosition = new Vector3(0f, 0f);
		messageBox.transform.SetAsLastSibling();
		messageBox.GetComponent<CanvasRenderer>().SetAlpha(1f);
		yesButton.GetComponentInChildren<Text>().text = yesText;
		yesButton.onClick.RemoveAllListeners();
		yesButton.onClick.AddListener(closeBox);
		yesButton.onClick.AddListener(yesEvent);
		noButton.GetComponentInChildren<Text>().text = noText;
		noButton.onClick.RemoveAllListeners();
		noButton.onClick.AddListener(closeBox);
		noButton.onClick.AddListener(noEvent);
		messageText.text = message;
	}

	public void closeBox()
	{
		messageBox.transform.localPosition = new Vector3(-2000f, -2000f);
		messageBox.GetComponent<CanvasRenderer>().SetAlpha(0f);
	}
}
