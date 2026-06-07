using System.Collections;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuSaveUI : MonoBehaviour
{
	[Header("Single Player")]
	[SerializeField]
	private Button singlePlayerContinueButton;

	[Header("Multiplayer")]
	[SerializeField]
	private Button multiplayerContinueButton;

	[Header("Debug")]
	[SerializeField]
	private bool debugLogs = true;

	private NewNetworkManager networkManager;

	private SteamLobbyManager lobbyManager;

	private void Start()
	{
		networkManager = Object.FindFirstObjectByType<NewNetworkManager>();
		lobbyManager = Object.FindFirstObjectByType<SteamLobbyManager>();
		RefreshContinueButtons();
		if (singlePlayerContinueButton != null)
		{
			singlePlayerContinueButton.onClick.AddListener(OnSinglePlayerContinueClicked);
		}
		if (multiplayerContinueButton != null)
		{
			multiplayerContinueButton.onClick.AddListener(OnMultiplayerContinueClicked);
		}
	}

	private void OnDestroy()
	{
		if (singlePlayerContinueButton != null)
		{
			singlePlayerContinueButton.onClick.RemoveListener(OnSinglePlayerContinueClicked);
		}
		if (multiplayerContinueButton != null)
		{
			multiplayerContinueButton.onClick.RemoveListener(OnMultiplayerContinueClicked);
		}
	}

	public void RefreshContinueButtons()
	{
		bool flag = false;
		if (Singleton<SaveLoadManager>.Instance != null)
		{
			flag = Singleton<SaveLoadManager>.Instance.HasSave();
		}
		if (singlePlayerContinueButton != null)
		{
			singlePlayerContinueButton.interactable = flag;
		}
		if (multiplayerContinueButton != null)
		{
			multiplayerContinueButton.interactable = flag;
		}
		if (debugLogs)
		{
			Debug.Log("[MainMenuSaveUI] Continue butonlari durumu: " + (flag ? "Aktif" : "Pasif"));
		}
	}

	private void OnSinglePlayerContinueClicked()
	{
		if (debugLogs)
		{
			Debug.Log("[MainMenuSaveUI] Single Player Continue butonuna tiklandi.");
		}
		StartCoroutine(LoadSinglePlayerCoroutine());
	}

	private IEnumerator LoadSinglePlayerCoroutine()
	{
		LoadingManagerUI.Show(LoadingType.Scene);
		yield return new WaitForSeconds(0.5f);
		SaveLoadGameManager.RequestLoadOnStart();
		NewNetworkManager newNetworkManager = ((networkManager != null) ? networkManager : Object.FindFirstObjectByType<NewNetworkManager>());
		if (newNetworkManager != null)
		{
			newNetworkManager.ClearLobbyCode();
			newNetworkManager.StartHostSafe();
			if (debugLogs)
			{
				Debug.Log("[MainMenuSaveUI] Single Player: Host baslatildi.");
			}
		}
	}

	private void OnMultiplayerContinueClicked()
	{
		if (debugLogs)
		{
			Debug.Log("[MainMenuSaveUI] Multiplayer Continue butonuna tiklandi.");
		}
		StartCoroutine(LoadMultiplayerCoroutine());
	}

	private IEnumerator LoadMultiplayerCoroutine()
	{
		LoadingManagerUI.Show(LoadingType.CreatingRoom);
		yield return new WaitForSeconds(0.5f);
		SaveLoadGameManager.RequestLoadOnStart();
		if (lobbyManager != null)
		{
			LoadingManagerUI.Hide(LoadingType.CreatingRoom);
			LoadingManagerUI.Show(LoadingType.Scene);
			lobbyManager.CreateLobbyAndStartHost(isPrivate: false);
			if (debugLogs)
			{
				Debug.Log("[MainMenuSaveUI] Multiplayer: Lobby olusturuldu ve host baslatildi.");
			}
		}
		else if (networkManager != null)
		{
			networkManager.StartHostSafe();
		}
	}

	[ContextMenu("Refresh Continue Buttons")]
	private void TestRefresh()
	{
		RefreshContinueButtons();
	}
}
