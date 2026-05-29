using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ThreeChoiceBox : MonoBehaviour
{
	public Text messageText;

	public GameObject messageBox;

	public Button yesButton;

	public Button noButton;

	public Button cancelButton;

	public void displayBox(string message, UnityAction yesEvent, UnityAction noEvent, UnityAction cancelEvent)
	{
		messageBox.transform.localPosition = new Vector3(0f, 0f);
		messageBox.transform.SetAsLastSibling();
		messageBox.GetComponent<CanvasRenderer>().SetAlpha(1f);
		yesButton.onClick.RemoveAllListeners();
		yesButton.onClick.AddListener(yesEvent);
		yesButton.onClick.AddListener(closeBox);
		noButton.onClick.RemoveAllListeners();
		noButton.onClick.AddListener(noEvent);
		noButton.onClick.AddListener(closeBox);
		cancelButton.onClick.RemoveAllListeners();
		cancelButton.onClick.AddListener(cancelEvent);
		cancelButton.onClick.AddListener(closeBox);
		messageText.text = message;
	}

	public void displayBox(string message, UnityAction yesEvent, UnityAction noEvent, UnityAction cancelEvent, string action1String, string action2String)
	{
		messageBox.transform.localPosition = new Vector3(0f, 0f);
		messageBox.transform.SetAsLastSibling();
		messageBox.GetComponent<CanvasRenderer>().SetAlpha(1f);
		yesButton.onClick.RemoveAllListeners();
		yesButton.onClick.AddListener(yesEvent);
		yesButton.onClick.AddListener(closeBox);
		noButton.onClick.RemoveAllListeners();
		noButton.onClick.AddListener(noEvent);
		noButton.onClick.AddListener(closeBox);
		cancelButton.onClick.RemoveAllListeners();
		cancelButton.onClick.AddListener(cancelEvent);
		cancelButton.onClick.AddListener(closeBox);
		messageText.text = message;
		yesButton.GetComponentInChildren<Text>().text = action1String;
		noButton.GetComponentInChildren<Text>().text = action2String;
	}

	private void closeBox()
	{
		messageBox.transform.localPosition = new Vector3(-2000f, -2000f);
		messageBox.GetComponent<CanvasRenderer>().SetAlpha(0f);
	}
}
