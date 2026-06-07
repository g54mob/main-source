using System;
using System.Collections;
using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomNetworkManager : NetworkManager
{
	public GameObject playerGameplayPrefab;

	public GameObject lostConnectionWarning;

	private bool _returningToMenu;

	public new static CustomNetworkManager singleton => (CustomNetworkManager)NetworkManager.singleton;

	public override void Awake()
	{
		base.Awake();
	}

	public override void OnValidate()
	{
		base.OnValidate();
	}

	public override void Start()
	{
		base.Start();
	}

	public override void LateUpdate()
	{
		base.LateUpdate();
	}

	public override void OnDestroy()
	{
		base.OnDestroy();
	}

	public override void ConfigureHeadlessFrameRate()
	{
		base.ConfigureHeadlessFrameRate();
	}

	public override void OnApplicationQuit()
	{
		base.OnApplicationQuit();
	}

	public override void ServerChangeScene(string newSceneName)
	{
		if (newSceneName == "Game")
		{
			playerPrefab = playerGameplayPrefab;
			onlineScene = newSceneName;
		}
		base.ServerChangeScene(newSceneName);
	}

	public override void OnServerChangeScene(string newSceneName)
	{
	}

	public override void OnServerSceneChanged(string sceneName)
	{
	}

	public override void OnClientChangeScene(string newSceneName, SceneOperation sceneOperation, bool customHandling)
	{
	}

	public override void OnClientSceneChanged()
	{
		base.OnClientSceneChanged();
	}

	public override void OnServerConnect(NetworkConnectionToClient conn)
	{
	}

	public override void OnServerReady(NetworkConnectionToClient conn)
	{
		base.OnServerReady(conn);
	}

	public override void OnServerDisconnect(NetworkConnectionToClient conn)
	{
		if ((bool)StoreManager.Instance)
		{
			StoreManager.Instance.Invoke("LoadAllPlayerMans", 3f);
		}
		base.OnServerDisconnect(conn);
	}

	public override void OnServerError(NetworkConnectionToClient conn, TransportError transportError, string message)
	{
	}

	public override void OnServerTransportException(NetworkConnectionToClient conn, Exception exception)
	{
	}

	public override void OnClientConnect()
	{
		base.OnClientConnect();
	}

	public override void OnClientDisconnect()
	{
		base.OnClientDisconnect();
		ReturnClientToMainMenu("Disconnected from host");
	}

	public void ReturnClientToMainMenu(string why)
	{
		if (!_returningToMenu)
		{
			_returningToMenu = true;
			UnityEngine.Object.Instantiate(lostConnectionWarning, Vector3.zero, Quaternion.identity);
			Debug.LogWarning("Returning to main menu. Reason: " + why);
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			if (NetworkServer.active && NetworkClient.isConnected)
			{
				StopHost();
			}
			else
			{
				StopClient();
			}
			StartCoroutine(DestroyNetworkManagerAndLoadMenu());
		}
	}

	private IEnumerator DestroyNetworkManagerAndLoadMenu()
	{
		yield return null;
		SceneManager.MoveGameObjectToScene(base.gameObject, SceneManager.GetActiveScene());
		GoBackToMenuManager.Instance.GoBackToMenu();
		UnityEngine.Object.Destroy(base.gameObject);
		yield return null;
	}

	public override void OnClientNotReady()
	{
	}

	public override void OnClientError(TransportError transportError, string message)
	{
		base.OnClientError(transportError, message);
		ReturnClientToMainMenu($"Network error: {transportError} ({message})");
	}

	public override void OnClientTransportException(Exception exception)
	{
	}

	public override void OnStartHost()
	{
	}

	public override void OnStartServer()
	{
	}

	public override void OnStartClient()
	{
	}

	public override void OnStopHost()
	{
	}

	public override void OnStopServer()
	{
	}

	public override void OnStopClient()
	{
	}
}
