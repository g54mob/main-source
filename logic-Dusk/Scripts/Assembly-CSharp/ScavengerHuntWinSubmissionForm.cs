using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class ScavengerHuntWinSubmissionForm : MonoBehaviour
{
	private Rect windowRect = default(Rect);

	private Rect sendingWindowRect = default(Rect);

	private Rect infoLabelRect = default(Rect);

	private Rect emailLabelRect = default(Rect);

	private Rect emailRect = default(Rect);

	private Rect emailBackgroundRectOffset = default(Rect);

	private Rect nameLabelRect = default(Rect);

	private Rect nameRect = default(Rect);

	private Rect nameBackgroundRectOffset = default(Rect);

	private Rect commentLabelRect = default(Rect);

	private Rect idLabelRect = default(Rect);

	private UITextEditor comments;

	private string emailText = string.Empty;

	private string nameText = string.Empty;

	private bool emailSelected;

	private bool nameSelected;

	private bool firstFocus;

	private bool waitingToTestInput;

	private bool isPreparingToSend;

	private bool isDelaySend;

	private bool isReadyToSend;

	private bool isSending;

	private bool isDoneSending;

	private GUIStyle infoStyle;

	private GUIStyle textStyle;

	private GUIStyle inputStyle;

	private GUIStyle noteStyle;

	private GUIStyle sendingStyle;

	private float timerClearPreviousInput;

	private float timerDelaySend;

	private MailMessage message;

	private SmtpClient client;

	public MenuScreen CallingMenuScreen { get; set; }

	public bool TestForKeyboardRelease { get; set; }

	private void Start()
	{
		client = new SmtpClient("mail.misfitsattic.com");
		client.Port = 587;
		client.Credentials = new NetworkCredential("robot@misfitsattic.com", "roboRally");
		client.EnableSsl = true;
		ServicePointManager.ServerCertificateValidationCallback = (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) => true;
		infoStyle = new GUIStyle();
		infoStyle.fontSize = 14;
		infoStyle.normal.textColor = Color.white;
		infoStyle.wordWrap = true;
		textStyle = new GUIStyle();
		textStyle.fontSize = 12;
		textStyle.normal.textColor = Color.white;
		inputStyle = new GUIStyle();
		inputStyle.fontSize = 12;
		inputStyle.normal.textColor = Color.white;
		noteStyle = new GUIStyle();
		noteStyle.fontSize = 10;
		noteStyle.normal.textColor = Color.gray;
		noteStyle.alignment = TextAnchor.UpperLeft;
		sendingStyle = new GUIStyle();
		sendingStyle.fontSize = 20;
		sendingStyle.normal.textColor = Color.white;
		sendingStyle.alignment = TextAnchor.MiddleCenter;
		windowRect.width = 700f;
		windowRect.height = 400f;
		windowRect.x = (float)(Screen.width / 2) - windowRect.width / 2f;
		windowRect.y = (float)(Screen.height / 2) - windowRect.height / 2f;
		sendingWindowRect.width = 250f;
		sendingWindowRect.height = 50f;
		sendingWindowRect.x = (float)(Screen.width / 2) - sendingWindowRect.width / 2f;
		sendingWindowRect.y = (float)(Screen.height / 2) - sendingWindowRect.height / 2f;
		float num = 20f;
		float num2 = 30f;
		infoLabelRect.x = num;
		infoLabelRect.y = num2;
		infoLabelRect.width = windowRect.width - num * 2f;
		infoLabelRect.height = 40f;
		num2 += 65f;
		emailLabelRect.x = num;
		emailLabelRect.y = num2;
		emailLabelRect.width = windowRect.width - num * 2f;
		emailLabelRect.height = 20f;
		num2 += 20f;
		emailRect.x = num;
		emailRect.y = num2;
		emailRect.width = windowRect.width - num * 2f;
		emailRect.height = 20f;
		emailBackgroundRectOffset = emailRect;
		emailBackgroundRectOffset.x -= 2f;
		emailBackgroundRectOffset.y -= 4f;
		num2 += 25f;
		nameLabelRect.x = num;
		nameLabelRect.y = num2;
		nameLabelRect.width = windowRect.width - num * 2f;
		nameLabelRect.height = 20f;
		num2 += 20f;
		nameRect.x = num;
		nameRect.y = num2;
		nameRect.width = windowRect.width - num * 2f;
		nameRect.height = 20f;
		nameBackgroundRectOffset = nameRect;
		nameBackgroundRectOffset.x -= 2f;
		nameBackgroundRectOffset.y -= 4f;
		num2 += 25f;
		commentLabelRect.x = num;
		commentLabelRect.y = num2;
		commentLabelRect.width = windowRect.width - num * 2f;
		commentLabelRect.height = 20f;
		num2 += 5f;
		comments = new UITextEditor
		{
			InputArea = new Rect(num, num2, windowRect.width - num * 2f, windowRect.height - num2 - 45f),
			MaxCharacters = 500,
			ExcludedCharacters = new char[2] { '<', '>' },
			TextSize = 12
		};
		num2 += comments.InputArea.height;
		idLabelRect.x = num;
		idLabelRect.y = num2;
		idLabelRect.width = windowRect.width - num * 2f;
		idLabelRect.height = 20f;
	}

	private void Update()
	{
		if (waitingToTestInput)
		{
			timerClearPreviousInput += Time.deltaTime;
			if (timerClearPreviousInput > 0.5f)
			{
				waitingToTestInput = false;
			}
		}
		else if (isDelaySend)
		{
			timerDelaySend += Time.deltaTime;
			if (timerDelaySend > 0.5f)
			{
				isDelaySend = false;
			}
		}
	}

	private void OnGUI()
	{
		if (!isPreparingToSend && !isSending && !isReadyToSend)
		{
			windowRect = GUI.Window(34, windowRect, DrawWindow, "Scavenger Hunt Submission Form");
		}
		else
		{
			if (isDoneSending)
			{
				return;
			}
			GUI.Label(sendingWindowRect, "Sending...", sendingStyle);
			if (!isDelaySend)
			{
				if (isPreparingToSend)
				{
					PrepareEmail();
				}
				else if (isReadyToSend)
				{
					SendEmail();
				}
			}
		}
	}

	private void DrawWindow(int id)
	{
		if (isPreparingToSend || isSending)
		{
			return;
		}
		GUI.Label(infoLabelRect, "This form is available to you because you have completed our Alpha scavenger hunt!  We'd love to hear your thoughts of the game so far, as well as issues or things you'd like to see added in a future update...", infoStyle);
		GUI.Label(emailLabelRect, "Email Address *", textStyle);
		GUI.DrawTexture(emailBackgroundRectOffset, ResourceManager.SemiTransparantBackground50);
		GUI.SetNextControlName("Email");
		string text = GUI.TextArea(emailRect, emailText, textStyle);
		if (emailSelected)
		{
			text = text.Replace("\n", string.Empty);
			text = text.Replace("<", "*");
			text = text.Replace(">", "*");
			if (waitingToTestInput && emailText != text)
			{
				if (text.ToLower().EndsWith("s"))
				{
					text = text.Remove(text.Length - 1);
				}
				else if (!string.IsNullOrEmpty(text))
				{
					waitingToTestInput = false;
				}
			}
			emailText = text;
		}
		else if (!firstFocus && Event.current.keyCode == KeyCode.None)
		{
			firstFocus = true;
			waitingToTestInput = true;
			GUI.FocusControl("Email");
		}
		if (GUI.GetNameOfFocusedControl() == "Email")
		{
			if (!emailSelected)
			{
				TextEditor textEditor = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);
				emailSelected = true;
			}
		}
		else
		{
			emailSelected = false;
		}
		GUI.Label(nameLabelRect, "Name *", textStyle);
		GUI.DrawTexture(nameBackgroundRectOffset, ResourceManager.SemiTransparantBackground50);
		GUI.SetNextControlName("Name");
		text = GUI.TextArea(nameRect, nameText, textStyle);
		if (nameSelected)
		{
			text = text.Replace("\n", string.Empty);
			text = text.Replace("<", "*");
			text = text.Replace(">", "*");
			nameText = text;
		}
		if (GUI.GetNameOfFocusedControl() == "Name")
		{
			if (!nameSelected)
			{
				TextEditor textEditor2 = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);
				nameSelected = true;
				waitingToTestInput = false;
			}
		}
		else
		{
			nameSelected = false;
		}
		GUI.Label(commentLabelRect, "Comments (thoughts about the scavenger hunt, game in general, what you had for breakfast, etc)", textStyle);
		comments.Draw();
		if (waitingToTestInput && !string.IsNullOrEmpty(comments.Text))
		{
			waitingToTestInput = false;
		}
		GUI.Label(idLabelRect, string.Format("Your Device ID: {0}", SystemInfo.deviceUniqueIdentifier), noteStyle);
		bool flag = false;
		if (emailText.Length > 4 && emailText.Contains("@") && emailText.Contains(".") && emailText.IndexOf('@') == emailText.LastIndexOf('@') && emailText.IndexOf('.') == emailText.LastIndexOf('.') && !emailText.StartsWith("@") && !emailText.EndsWith(".") && emailText.IndexOf(".") > emailText.IndexOf("@") && nameText.Length > 1)
		{
			flag = true;
		}
		string text2 = "Send";
		string text3 = "Cancel";
		if (!waitingToTestInput)
		{
			if (Event.current.alt)
			{
				text2 = "[S]end";
				text3 = "[C]ancel";
				if (flag && Event.current.keyCode == KeyCode.S)
				{
					BeginSendButtonPressed();
					return;
				}
				if (Event.current.keyCode == KeyCode.C)
				{
					CancelButtonPressed();
					return;
				}
			}
			else if (Event.current.keyCode == KeyCode.Escape)
			{
				CancelButtonPressed();
				return;
			}
		}
		if (!flag)
		{
			GUI.enabled = false;
		}
		if (GUI.Button(new Rect(5f, windowRect.height - 30f, 100f, 25f), text2))
		{
			BeginSendButtonPressed();
		}
		if (!flag)
		{
			GUI.enabled = true;
		}
		if (GUI.Button(new Rect(windowRect.width - 105f, windowRect.height - 30f, 100f, 25f), text3))
		{
			CancelButtonPressed();
		}
	}

	private void BeginSendButtonPressed()
	{
		isPreparingToSend = true;
		isDoneSending = false;
		isReadyToSend = false;
		isSending = false;
		isDelaySend = true;
		timerDelaySend = 0f;
	}

	private void PrepareEmail()
	{
		isReadyToSend = true;
		isPreparingToSend = false;
		message = new MailMessage();
		message.From = new MailAddress(emailText);
		message.To.Add("robot@misfitsattic.com");
		message.Subject = "Scavenger Hunt Winner";
		message.Body = string.Format("Date: {0}\r\nName: {1}\r\nEmail: {2}\r\nInternal ID: {3}\r\n\r\nPlayer Comments:\r\n{4}", DateTime.Now, nameText, emailText, SystemInfo.deviceUniqueIdentifier, comments.Text);
	}

	private void SendEmail()
	{
		isSending = true;
		isReadyToSend = false;
		try
		{
			client.Send(message);
			isDoneSending = true;
			GameSaveFile.Save("SCAVENGER_SUBMIT", true);
			DialogUI.Instance.ShowDialog("Submission Sent", "Your information was successfully sent!", ModalWindowType.OK, delegate
			{
				CloseAndReturnToMenu();
			});
		}
		catch (Exception ex)
		{
			DialogUI.Instance.ShowDialog("Error Sending!", string.Format("There was an unexpected error while trying to send your information.\r\n\r\nPlease try again.  If you are unable to resolve this issue, please send us an email at duskers@misfitsattic.com\r\n\r\nError: {0}", ex.Message), ModalWindowType.OK, delegate
			{
				isSending = false;
				waitingToTestInput = true;
				timerClearPreviousInput = 0f;
			});
			isDoneSending = true;
		}
	}

	private void CancelButtonPressed()
	{
		if (emailText.Length > 0 || nameText.Length > 0 || comments.Text.Length > 0)
		{
			DialogUI.Instance.ShowDialog("Cancel Submission?", "You haven't yet sent us your information so that we can give you credit for the win.\r\n\r\nYou can still come back at a later point and try again.  Really return to the main menu?", ModalWindowType.YesNo, delegate(ModalWindowResult result, string inputString)
			{
				if (result == ModalWindowResult.Yes)
				{
					CloseAndReturnToMenu();
				}
			});
		}
		else
		{
			CloseAndReturnToMenu();
		}
	}

	private void CloseAndReturnToMenu()
	{
		if (CallingMenuScreen != null)
		{
			CallingMenuScreen.Enable();
			CallingMenuScreen.ReloadMenuItems();
		}
		UnityEngine.Object.Destroy(this);
	}
}
