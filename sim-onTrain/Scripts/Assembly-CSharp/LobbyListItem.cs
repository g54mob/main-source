using Michsky.UI.Heat;
using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LobbyListItem : MonoBehaviour
{
	public CSteamID lobbyID;

	public string lobbyName;

	public TextMeshProUGUI lobbyNameText;

	public Button joinButton;

	public GameObject isFullObject;

	private void Start()
	{
		joinButton.onClick.AddListener(delegate
		{
			PlayClickSound();
			JoinLobby();
		});
		AddHoverSound(joinButton);
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

	public void SetLobby()
	{
		lobbyNameText.text = lobbyName;
		int numLobbyMembers = SteamMatchmaking.GetNumLobbyMembers(lobbyID);
		int lobbyMemberLimit = SteamMatchmaking.GetLobbyMemberLimit(lobbyID);
		bool flag = lobbyMemberLimit > 0 && numLobbyMembers >= lobbyMemberLimit;
		joinButton.gameObject.SetActive(!flag);
		if (isFullObject != null)
		{
			isFullObject.SetActive(flag);
		}
	}

	public void JoinLobby()
	{
		CSteamID cSteamID = lobbyID;
		Debug.Log("Joining lobby: " + cSteamID.ToString());
		MainMenuPanel mainMenu = Object.FindObjectOfType<MainMenuPanel>();
		if (mainMenu != null && !mainMenu.HasSelectedCharacter())
		{
			CSteamID savedID = lobbyID;
			mainMenu.RequestCharacterSelectionForJoin(delegate
			{
				mainMenu.StartLoadingForJoin();
				Singleton<SteamLobby>.Instance.JoinLobby(savedID);
			});
		}
		else
		{
			if (mainMenu != null)
			{
				mainMenu.StartLoadingForJoin();
			}
			Singleton<SteamLobby>.Instance.JoinLobby(lobbyID);
		}
	}
}
