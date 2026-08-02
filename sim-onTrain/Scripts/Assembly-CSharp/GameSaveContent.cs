using Michsky.UI.Heat;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameSaveContent : MonoBehaviour
{
	public TextMeshProUGUI saveTitle;

	public TextMeshProUGUI lastAccessTime;

	public HorizontalSelector lobbyModeSelector;

	public Button loadButton;

	public Button deleteButton;

	private string fileName;

	private GameSavesPanel parentPanel;

	private string gameKey;

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

	public void SetTitle(string saveName)
	{
		gameKey = saveName;
		saveTitle.SetText(saveName);
	}

	public void SetLastAccessTime(string timeText)
	{
		if (lastAccessTime != null)
		{
			lastAccessTime.SetText(timeText);
		}
	}

	public void SetupSaveContent(string saveName, string file, GameSavesPanel panel)
	{
		fileName = file;
		parentPanel = panel;
		SetTitle(saveName);
		string text = Singleton<ES3SaveManager>.Instance.GetSaveLastAccessTime(saveName);
		if (!string.IsNullOrEmpty(text) && text.Contains(" "))
		{
			text = text.Split(' ')[0];
		}
		SetLastAccessTime(text);
		if (lobbyModeSelector != null)
		{
			bool exists;
			int lobbyMode = Singleton<ES3SaveManager>.Instance.GetLobbyMode(saveName, out exists);
			lobbyModeSelector.defaultIndex = lobbyMode;
			lobbyModeSelector.index = lobbyMode;
			lobbyModeSelector.UpdateUI();
			lobbyModeSelector.onValueChanged.AddListener(delegate(int index)
			{
				Singleton<ES3SaveManager>.Instance.SaveLobbyMode(saveName, index);
			});
		}
		loadButton.onClick.AddListener(delegate
		{
			PlayClickSound();
			LoadGame();
		});
		deleteButton.onClick.AddListener(delegate
		{
			PlayClickSound();
			Object.FindObjectOfType<ConfirmPanel>().ShowPanel(DeleteSave);
		});
		AddHoverSound(loadButton);
		AddHoverSound(deleteButton);
	}

	public void LoadGame()
	{
		Singleton<ES3SaveManager>.Instance.SetSaveName(gameKey);
		Singleton<ES3SaveManager>.Instance.PreloadGameData();
		Singleton<ES3SaveManager>.Instance.UpdateLastAccessTime();
		Object.FindObjectOfType<MainMenuPanel>().StartGame(gameKey);
	}

	public void DeleteSave()
	{
		string saveName = fileName.Replace(".es3", "");
		Singleton<ES3SaveManager>.Instance.SetSaveName(saveName);
		Singleton<ES3SaveManager>.Instance.DeleteCurrentSave();
		parentPanel.RefreshContent();
	}
}
