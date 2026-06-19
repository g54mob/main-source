using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ModIO.Implementation
{
	public class ExampleSettingsPanel : MonoBehaviour
	{
		[SerializeField]
		private TMP_InputField gameIdInputField;

		[SerializeField]
		private TMP_InputField apiKeyInputField;

		[SerializeField]
		private TMP_InputField initUserInputField;

		[SerializeField]
		private TextMeshProUGUI currentServerUrlText;

		[SerializeField]
		private TextMeshProUGUI currentGameIdText;

		[SerializeField]
		private Button[] buttons;

		private string urlToUse;

		public void ActivatePanel(bool isActive)
		{
			SetServerUrl(Settings.server.serverURL);
			currentServerUrlText.text = "Server Url: " + Settings.server.serverURL;
			currentGameIdText.text = $"Game Id: {Settings.server.gameId}";
			base.gameObject.SetActive(isActive);
			LayoutRebuilder.ForceRebuildLayoutImmediate(base.transform as RectTransform);
			LayoutRebuilder.ForceRebuildLayoutImmediate(base.transform as RectTransform);
		}

		public void SetProductionUrl()
		{
			urlToUse = $"https://g-{Settings.server.gameId}.modapi.io/v1";
			currentServerUrlText.text = "Server Url: " + urlToUse;
		}

		public void SetTestUrl()
		{
			urlToUse = "https://api.test.mod.io/v1";
			currentServerUrlText.text = "Server Url: " + urlToUse;
		}

		public void SetServerUrl(string url)
		{
			urlToUse = url;
			currentServerUrlText.text = "Server Url: " + urlToUse;
		}

		public async void SaveSettings()
		{
			try
			{
				Button[] array = buttons;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].enabled = false;
				}
				if (ModIOUnity.IsInitialized())
				{
					await ModIOUnityAsync.Shutdown();
				}
				ServerSettings serverSettings = new ServerSettings(Settings.server);
				BuildSettings buildSettings = new BuildSettings();
				if (gameIdInputField.text != string.Empty && uint.TryParse(gameIdInputField.text, out var result))
				{
					serverSettings.gameId = result;
				}
				if (apiKeyInputField.text != string.Empty)
				{
					serverSettings.gameKey = apiKeyInputField.text;
				}
				serverSettings.serverURL = urlToUse;
				ModIOUnity.InitializeForUser(string.IsNullOrWhiteSpace(initUserInputField.text) ? "User" : initUserInputField.text, serverSettings, buildSettings);
				currentServerUrlText.text = "Server Url: " + urlToUse;
				currentGameIdText.text = $"Game Id: {Settings.server.gameId}";
			}
			catch (Exception message)
			{
				Debug.LogWarning(message);
			}
			finally
			{
				Button[] array = buttons;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].enabled = true;
				}
			}
		}

		public void Close()
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
