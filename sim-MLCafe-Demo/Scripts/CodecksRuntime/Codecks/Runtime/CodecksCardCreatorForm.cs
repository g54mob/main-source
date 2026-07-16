using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Codecks.Runtime
{
	public class CodecksCardCreatorForm : MonoBehaviour
	{
		public CodecksCardCreator cardCreator;

		[SerializeField]
		private UnityEvent OnHideForm = new UnityEvent();

		[Header("UI References")]
		public TMP_Dropdown categoryDropdown;

		public TMP_InputField textArea;

		public TMP_InputField emailInput;

		public TMP_Text statusText;

		public Button sendButton;

		[Header("Texts")]
		public string statusShortText;

		public string statusSending;

		public string statusSent;

		public string statusError;

		private byte[] queuedScreenshot;

		public void AssignStatusLocalization(List<string> states)
		{
			statusShortText = states[0];
			statusSending = states[1];
			statusSent = states[2];
			statusError = states[3];
		}

		public void ShowCodecksForm()
		{
			cardCreator.StartCoroutine(ShowCodecksFormCoroutine());
		}

		private IEnumerator ShowCodecksFormCoroutine()
		{
			yield return new WaitForEndOfFrame();
			Texture2D texture2D = ScreenCapture.CaptureScreenshotAsTexture();
			queuedScreenshot = texture2D.EncodeToJPG();
			Object.Destroy(texture2D);
			textArea.text = "";
			sendButton.interactable = true;
			base.gameObject.SetActive(value: true);
		}

		public void HideCodecksForm()
		{
			queuedScreenshot = null;
			base.gameObject.SetActive(value: false);
			statusText.text = "";
		}

		private IEnumerator HideCodecksFormWithDelayCoroutine()
		{
			yield return new WaitForSeconds(1f);
			OnHideForm.Invoke();
		}

		public void OnButtonSend()
		{
			if (textArea.text.Length < 10)
			{
				statusText.text = statusShortText;
				return;
			}
			string text = textArea.text + "\n\n";
			text += GetMetaText();
			Dictionary<string, (byte[], CodecksCardCreator.CodecksFileType)> dictionary = new Dictionary<string, (byte[], CodecksCardCreator.CodecksFileType)>();
			dictionary["screenshot.jpg"] = (queuedScreenshot, CodecksCardCreator.CodecksFileType.JPG);
			statusText.text = statusSending;
			sendButton.interactable = false;
			cardCreator.CreateNewCard(text, dictionary, (CodecksCardCreator.CodecksSeverity)categoryDropdown.value, emailInput.text, delegate(bool success, string result)
			{
				if (success)
				{
					statusText.text = statusSent;
					sendButton.interactable = false;
					StartCoroutine(HideCodecksFormWithDelayCoroutine());
				}
				else
				{
					sendButton.interactable = true;
					statusText.text = statusError;
				}
			});
		}

		public void OnButtonCancel()
		{
			HideCodecksForm();
		}

		private static string GetMetaText()
		{
			string text = "Full Game";
			text = "Demo";
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("```");
			stringBuilder.AppendLine("App Type: " + text);
			stringBuilder.AppendLine("Platform: " + Application.platform);
			stringBuilder.AppendLine("App Version: " + Application.version);
			stringBuilder.AppendLine("```");
			return stringBuilder.ToString();
		}
	}
}
