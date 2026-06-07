using System;
using System.Collections;
using System.Threading.Tasks;
using Extensions;
using Mirror;
using UnityEngine;

public class QuitGameComponent : MonoBehaviour
{
	public void QuitGame()
	{
		PreQuitCleanup();
		ForceExitFallback();
		Application.Quit();
	}

	public void QuitGameWithConfirmation()
	{
		if (MonoSingleton<ConfirmationDialogManager>.Instance != null)
		{
			MonoSingleton<ConfirmationDialogManager>.Instance.ShowConfirmation("Are you sure you want to quit?", delegate
			{
				StartCoroutine(QuitGameCoroutine());
			}, delegate
			{
				Debug.Log("[QuitGameComponent] User cancelled quitting game.");
			}, "Yes, quit", "No, stay");
		}
		else
		{
			Debug.LogWarning("[QuitGameComponent] ConfirmationDialogManager not found. Quitting without confirmation.");
			QuitGame();
		}
	}

	private IEnumerator QuitGameCoroutine()
	{
		MonoSingleton<SceneTransitioner>.Instance.SetLoadingScreen(isEnabled: true, 0.5f, loadingScreen: false);
		yield return new WaitForSeconds(1f);
		QuitGame();
	}

	private void PreQuitCleanup()
	{
		if (NetworkManager.singleton != null)
		{
			if (NetworkServer.active && NetworkClient.isConnected)
			{
				NetworkManager.singleton.StopHost();
			}
			else if (NetworkClient.isConnected || NetworkClient.active)
			{
				NetworkManager.singleton.StopClient();
			}
			else if (NetworkServer.active)
			{
				NetworkManager.singleton.StopServer();
			}
		}
		MonoSingleton<LobbyManager>.Instance?.LeaveLobby();
		MonoSingleton<SteamRichPresenceManager>.Instance?.ClearRichPresence();
		MonoSingleton<DiscordRichPresenceManager>.Instance?.DisconnectDiscord();
		MonoSingleton<WebSocketManager>.Instance?.ShutdownForQuit();
	}

	private void ForceExitFallback()
	{
		Task.Run(async delegate
		{
			await Task.Delay(3000);
			Environment.Exit(0);
		});
	}
}
