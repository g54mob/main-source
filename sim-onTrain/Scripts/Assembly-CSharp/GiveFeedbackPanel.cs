using System;
using System.Collections;
using System.Text;
using Michsky.UI.Heat;
using Mirror;
using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GiveFeedbackPanel : UIPanelBase
{
	[Serializable]
	private class DiscordWebhookMessage
	{
		public string content;
	}

	[Header("UI Elements")]
	public TMP_InputField feedbackInputField;

	public Button submitButton;

	public Button closeButton;

	public TextMeshProUGUI statusText;

	[Header("Discord Webhook")]
	public string webhookUrl = "";

	private MainMenuPanel mainMenuPanel;

	private UIPausePanelController pausePanelController;

	private bool isSending;

	private bool openedFromPausePanel;

	private void Start()
	{
		mainMenuPanel = UnityEngine.Object.FindObjectOfType<MainMenuPanel>();
		pausePanelController = UnityEngine.Object.FindObjectOfType<UIPausePanelController>(includeInactive: true);
		submitButton.onClick.AddListener(delegate
		{
			PlayClickSound();
			SubmitFeedback();
		});
		closeButton.onClick.AddListener(delegate
		{
			PlayClickSound();
			ClosePanel();
		});
		AddHoverSound(submitButton);
		AddHoverSound(closeButton);
		if (statusText != null)
		{
			statusText.gameObject.SetActive(value: false);
		}
		UpdateSubmitButtonState();
		feedbackInputField.onValueChanged.AddListener(delegate
		{
			UpdateSubmitButtonState();
		});
	}

	private void PlayClickSound()
	{
		if (UIManagerAudio.instance != null && UIManagerAudio.instance.UIManagerAsset != null)
		{
			UIManagerAudio.instance.audioSource.PlayOneShot(UIManagerAudio.instance.UIManagerAsset.clickSound);
		}
	}

	private void PlayHoverSound()
	{
		if (UIManagerAudio.instance != null && UIManagerAudio.instance.UIManagerAsset != null)
		{
			UIManagerAudio.instance.audioSource.PlayOneShot(UIManagerAudio.instance.UIManagerAsset.hoverSound);
		}
	}

	private void AddHoverSound(Button button)
	{
		EventTrigger eventTrigger = button.gameObject.GetComponent<EventTrigger>();
		if (eventTrigger == null)
		{
			eventTrigger = button.gameObject.AddComponent<EventTrigger>();
		}
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.PointerEnter;
		entry.callback.AddListener(delegate
		{
			PlayHoverSound();
		});
		eventTrigger.triggers.Add(entry);
	}

	private void Update()
	{
		if (isPanelOpen && Input.GetKeyDown(Singleton<UserPrefencesManager>.Instance.keyData.ExitKey))
		{
			ClosePanel();
		}
	}

	private void UpdateSubmitButtonState()
	{
		bool flag = !string.IsNullOrWhiteSpace(feedbackInputField.text);
		submitButton.interactable = flag && !isSending;
	}

	public void SubmitFeedback()
	{
		if (!isSending)
		{
			string text = feedbackInputField.text?.Trim();
			if (string.IsNullOrEmpty(text))
			{
				ShowStatus("Please enter your feedback.", Color.yellow);
			}
			else if (string.IsNullOrEmpty(webhookUrl))
			{
				ShowStatus("Webhook URL not configured.", Color.red);
			}
			else
			{
				StartCoroutine(SendFeedbackToDiscord(text));
			}
		}
	}

	private IEnumerator SendFeedbackToDiscord(string feedback)
	{
		isSending = true;
		UpdateSubmitButtonState();
		ShowStatus("Sending...", Color.white);
		string text = "Anonymous";
		string text2 = "Unknown";
		if (SteamManager.Initialized)
		{
			try
			{
				text = SteamFriends.GetPersonaName();
				text2 = SteamUser.GetSteamID().m_SteamID.ToString();
			}
			catch
			{
			}
		}
		string gameModeNote = GetGameModeNote();
		string playtimeNote = GetPlaytimeNote();
		DiscordWebhookMessage discordWebhookMessage = new DiscordWebhookMessage();
		discordWebhookMessage.content = "**Feedback from " + text + "** (ID: " + text2 + ")\n" + feedback + "\n\n_" + gameModeNote + "_\n_" + playtimeNote + "_";
		string s = JsonUtility.ToJson(discordWebhookMessage);
		using (UnityWebRequest request = new UnityWebRequest(webhookUrl, "POST"))
		{
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			request.uploadHandler = new UploadHandlerRaw(bytes);
			request.downloadHandler = new DownloadHandlerBuffer();
			request.SetRequestHeader("Content-Type", "application/json");
			yield return request.SendWebRequest();
			if (request.result == UnityWebRequest.Result.Success)
			{
				ShowStatus("Thank you for your feedback!", Color.green);
				feedbackInputField.text = "";
				yield return new WaitForSecondsRealtime(1.5f);
				ClosePanel();
			}
			else
			{
				ShowStatus("Failed to send. Please try again.", Color.red);
				Debug.LogError("Discord webhook error: " + request.error);
			}
		}
		isSending = false;
		UpdateSubmitButtonState();
	}

	private string GetGameModeNote()
	{
		int count = ZombieController.AllRegisteredPlayers.Count;
		if (NetworkServer.active)
		{
			count = Mathf.Max(count, NetworkServer.connections.Count);
			string arg = ((count > 1) ? "Multiplayer (Host)" : "Single Player");
			return $"Game Mode: {arg} | Players: {count}";
		}
		if (NetworkClient.active)
		{
			return $"Game Mode: Multiplayer (Client) | Players: {Mathf.Max(count, 2)}";
		}
		return "Game Mode: Main Menu (not in game)";
	}

	private string GetPlaytimeNote()
	{
		string text = (string.IsNullOrEmpty(CustomNetworkManager.loadedGameKey) ? "DefaultGame" : CustomNetworkManager.loadedGameKey);
		TestTimerPanel testTimerPanel = UnityEngine.Object.FindObjectOfType<TestTimerPanel>(includeInactive: true);
		float num = ((!(testTimerPanel != null)) ? PlayerPrefs.GetFloat(text + "_TotalGameTime", 0f) : testTimerPanel.totalGameTime);
		int num2 = Mathf.FloorToInt(num / 60f);
		return $"Save: {text} | Playtime: {num2} min";
	}

	private void ShowStatus(string message, Color color)
	{
		if (statusText != null)
		{
			statusText.text = message;
			statusText.color = color;
			statusText.gameObject.SetActive(value: true);
		}
	}

	public void ShowPanel(bool fromPausePanel = false)
	{
		openedFromPausePanel = fromPausePanel;
		base.ShowPanel();
	}

	public void ClosePanel()
	{
		if (statusText != null)
		{
			statusText.gameObject.SetActive(value: false);
		}
		HidePanelWithFade(0.2f, delegate
		{
			if (openedFromPausePanel && pausePanelController != null)
			{
				pausePanelController.ShowPanel();
			}
			else if (mainMenuPanel != null)
			{
				mainMenuPanel.ShowMainMenuCanvas();
			}
		});
	}
}
