using Mirror;
using Mirror.Examples.CharacterSelection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomNetworkManager : NetworkManagerCharacterSelection
{
	public static string nick;

	public static string loadedGameKey;

	public static bool isManualDisconnect;

	private string savedOfflineScene;

	public override void OnServerConnect(NetworkConnectionToClient conn)
	{
		base.OnServerConnect(conn);
		if (Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
			UIPausePanelController uIPausePanelController = Object.FindObjectOfType<UIPausePanelController>(includeInactive: true);
			if (uIPausePanelController != null && uIPausePanelController.isPanelOpen)
			{
				uIPausePanelController.ChangePanelActive();
			}
		}
	}

	public override void OnServerDisconnect(NetworkConnectionToClient conn)
	{
		if (InventorySaver.Instance != null)
		{
			InventorySaver.Instance.OnPlayerDisconnected(conn);
		}
		base.OnServerDisconnect(conn);
	}

	public override void OnServerSceneChanged(string sceneName)
	{
		base.OnServerSceneChanged(sceneName);
		if (Singleton<SteamLobby>.Instance != null)
		{
			Singleton<SteamLobby>.Instance.MakeLobbyPublic();
		}
	}

	public override void OnStopHost()
	{
		base.OnStopHost();
		if (Singleton<SteamLobby>.Instance != null)
		{
			Singleton<SteamLobby>.Instance.LeaveLobby();
		}
	}

	public override void OnStopClient()
	{
		base.OnStopClient();
		if (Singleton<SteamLobby>.Instance != null)
		{
			Singleton<SteamLobby>.Instance.LeaveLobby();
		}
	}

	public override void OnClientDisconnect()
	{
		if (!isManualDisconnect && !NetworkServer.active)
		{
			savedOfflineScene = offlineScene;
			offlineScene = "";
			DisconnectOverlay disconnectOverlay = Object.FindObjectOfType<DisconnectOverlay>(includeInactive: true);
			if (disconnectOverlay != null)
			{
				disconnectOverlay.Show(delegate
				{
					offlineScene = savedOfflineScene;
					SceneManager.LoadScene(0);
				});
			}
			else
			{
				offlineScene = savedOfflineScene;
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;
				SceneManager.LoadScene(0);
			}
		}
		isManualDisconnect = false;
	}

	public override void OnClientConnect()
	{
		base.OnClientConnect();
		MainMenuPanel mainMenuPanel = Object.FindObjectOfType<MainMenuPanel>();
		if (mainMenuPanel != null)
		{
			mainMenuPanel.StartLoadingForJoin();
			Debug.Log("Client bağlandı, loading ekranı gösteriliyor (NetworkManagerHUD veya MainMenuPanel)");
		}
	}
}
