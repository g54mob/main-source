using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Aggro.Core;
using Aggro.Core.Networking;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour, IInputController
{
	public GameObject startingSelected;

	public TextMeshProUGUI versionText;

	[Header("Development")]
	public GameObject devContainer;

	public Button devPlatformHostButton;

	public TMP_InputField devJoinInputField;

	public TextMeshProUGUI devGlobalIpText;

	public TextMeshProUGUI devLocalIpText;

	private EntityWorld _world;

	private GameObject _prevSelectedObject;

	private static bool _checkedPendingInvite;

	public Button hostGameButton;

	public Button joinGameButton;

	public Button[] releaseButtons;

	private void Start()
	{
		StartCoroutine(StartCo());
	}

	private IEnumerator StartCo()
	{
		AggroInputManager.Disable();
		GameUtil.isUnloadingScene = false;
		devContainer.SetActive(Debug.isDebugBuild);
		yield return GameUtil.InitializeGameCo();
		if (!_checkedPendingInvite)
		{
			_checkedPendingInvite = true;
			if (Platform.HasPendingInvite())
			{
				Task<PlatformGameJoin> task = Platform.AcceptPendingInvite();
				yield return new WaitForTask(task);
				GameUtil.JoinLobby(task.Result);
				yield break;
			}
		}
		if (Debug.isDebugBuild)
		{
			try
			{
				IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
				string text = "";
				foreach (IPAddress iPAddress in addressList)
				{
					if (!iPAddress.IsIPv6LinkLocal && iPAddress.AddressFamily == AddressFamily.InterNetwork)
					{
						text += $"{iPAddress}\n";
					}
				}
				devLocalIpText.text = text;
				devPlatformHostButton.interactable = false;
			}
			catch (SocketException)
			{
				Debug.LogWarning($"[{Time.frameCount}] [Title] [StartCo] Failed to get IP address at startup of Title scene. This error is going to be ignored.");
			}
		}
		versionText.text = GameUtil.gameVersionFull;
		_world = new EntityWorld("Title World", EntityWorldFlags.GameObjectWorld, Allocator.Persistent);
		EntityWorldUtil.CreateSystemsForWorld(_world);
		NetworkUtil.FindSetNetworkManagers();
		_world.ProcessExistingEntities(runStartRunning: false);
		_world.RunStartRunningMessages();
		devPlatformHostButton.interactable = Platform.HasPlatformJoin();
		AudioManager.PlayLobbyTitleMusic();
		joinGameButton.interactable = Platform.HasPlatformJoin() && Platform.IsOnline();
		hostGameButton.interactable = Platform.HasPlatformInvite() && Platform.IsOnline();
		List<Button> list = new List<Button>();
		Button[] array = releaseButtons;
		foreach (Button button in array)
		{
			if (button.interactable)
			{
				list.Add(button);
			}
		}
		for (int k = 0; k < list.Count; k++)
		{
			UIUtil.SetNavigation(list[k], null, (k == 0) ? null : list[k - 1], null, (k == list.Count - 1) ? null : list[k + 1]);
		}
		yield return FadeManager.FadeOutCo();
		AggroInputManager.Enable();
		AggroInputManager.EnableUIModule();
		AggroInputManager.PushController(this);
		if (GameUtil.gameError != GameError.None)
		{
			PlayerMessageManager.QueueErrorMessage(GameUtil.gameError);
			Debug.LogError(GameUtil.gameError);
			GameUtil.gameError = GameError.None;
		}
		if (Debug.isDebugBuild)
		{
			Task<string> ipTask = AggroUtil.GetGlobalIp();
			yield return new WaitForTask(ipTask);
			devGlobalIpText.text = ipTask.Result;
		}
		while (!Platform.hasPendingJoin)
		{
			yield return null;
		}
		PlatformGameJoin invite = Platform.GetAndConsumeJoin();
		AggroInputManager.Disable();
		AggroInputManager.DisableUIModule();
		yield return FadeManager.FadeInCo();
		GameUtil.JoinLobby(invite);
	}

	private void Update()
	{
		AggroInputManager.Update();
		if (_world != null)
		{
			_world.GetOrCreateSystem<PresentationUpdateSystemGroup>().Update();
			PlayerMessageManager.ProcessQueuedMessages();
		}
	}

	private void LateUpdate()
	{
		if (_world != null)
		{
			_world.GetOrCreateSystem<PresentationLateUpdateSystemGroup>().Update();
		}
	}

	private void OnDestroy()
	{
		if (_world != null)
		{
			_world.Dispose();
			_world = null;
		}
	}

	public void OnSinglePlayer()
	{
		StopAllCoroutines();
		StartCoroutine(SinglePlayerCo());
	}

	public void OnGameHost()
	{
		StopAllCoroutines();
		StartCoroutine(HostCo(Platform.HasPlatformJoin()));
	}

	public async void OnGameJoin()
	{
		Platform.JoinListError joinListError = await Platform.OpenJoinList();
		if (joinListError != Platform.JoinListError.None)
		{
			PlayerMessageManager.QueueErrorMessage(joinListError);
		}
	}

	public void OnDevHost()
	{
		StopAllCoroutines();
		StartCoroutine(HostCo(isPlatformHost: false));
	}

	public void OnDevPlatformHost()
	{
		StopAllCoroutines();
		StartCoroutine(HostCo(isPlatformHost: true));
	}

	public void OnDevJoin()
	{
		StopAllCoroutines();
		StartCoroutine(DevJoinCo());
	}

	public void OnTutorial()
	{
		StopAllCoroutines();
		StartCoroutine(TutorialCo());
	}

	public void OnQuitGame()
	{
		Application.Quit();
	}

	private IEnumerator SinglePlayerCo()
	{
		AggroInputManager.Disable();
		AggroInputManager.DisableUIModule();
		yield return FadeManager.FadeInCo();
		GameSettings.Set(new GameSettings
		{
			loadType = GameLoadType.Lobby,
			networkType = NetworkType.SinglePlayer
		});
		GameUtil.isUnloadingScene = true;
		SceneManager.LoadSceneAsync("scene-game");
	}

	private IEnumerator HostCo(bool isPlatformHost)
	{
		AggroInputManager.Disable();
		AggroInputManager.DisableUIModule();
		yield return FadeManager.FadeInCo();
		GameSettings.Set(new GameSettings
		{
			loadType = GameLoadType.Lobby,
			networkType = (isPlatformHost ? NetworkType.HostPlatform : NetworkType.Host),
			port = 7777,
			allowFriends = (AggroSettings.GetIndex("game-lobbyallowfriends") != 0)
		});
		GameUtil.isUnloadingScene = true;
		SceneManager.LoadSceneAsync("scene-game");
	}

	private IEnumerator DevJoinCo()
	{
		AggroInputManager.Disable();
		AggroInputManager.DisableUIModule();
		yield return FadeManager.FadeInCo();
		GameSettings.Set(new GameSettings
		{
			loadType = GameLoadType.Lobby,
			networkType = NetworkType.Join,
			address = devJoinInputField.text,
			port = 7777
		});
		GameUtil.isUnloadingScene = true;
		SceneManager.LoadSceneAsync("scene-game");
	}

	private IEnumerator TutorialCo()
	{
		AggroInputManager.Disable();
		AggroInputManager.DisableUIModule();
		yield return FadeManager.FadeInCo();
		GameSettings.Set(new GameSettings
		{
			loadType = GameLoadType.Tutorial,
			networkType = NetworkType.SinglePlayer
		});
		GameUtil.isUnloadingScene = true;
		SceneManager.LoadSceneAsync("scene-game");
	}

	public void OnInputControlGained()
	{
		AggroInputManager.EnableUIModule();
		if (AggroInputManager.mode == InputMode.Gamepad)
		{
			if (_prevSelectedObject != null)
			{
				EventSystem.current.SetSelectedGameObject(_prevSelectedObject);
				_prevSelectedObject = null;
			}
			else
			{
				EventSystem.current.SetSelectedGameObject(startingSelected);
			}
		}
	}

	public void OnInputControlLost()
	{
		_prevSelectedObject = EventSystem.current.currentSelectedGameObject;
		AggroInputManager.DisableUIModule();
	}
}
