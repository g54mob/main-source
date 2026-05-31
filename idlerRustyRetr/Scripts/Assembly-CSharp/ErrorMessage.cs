using TMPro;
using UnityEngine;

public class ErrorMessage : MonoBehaviour
{
	public static ErrorMessage ins;

	[SerializeField]
	private TMP_Text bodyText;

	[SerializeField]
	private GameObject errorBox;

	private void Awake()
	{
		ins = this;
	}

	public void ShowMessage(string msg)
	{
		TMP_Text tMP_Text = bodyText;
		tMP_Text.text = tMP_Text.text + msg + "<br>";
		errorBox.SetActive(value: true);
	}

	public void CloseErrorMessage()
	{
		bodyText.text = "";
		errorBox.SetActive(value: false);
	}
}
