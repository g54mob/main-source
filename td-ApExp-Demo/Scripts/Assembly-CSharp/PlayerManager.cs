using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
	[SerializeField]
	private GameObject playerPrefab;

	[SerializeField]
	private int maxPlayers = 2;

	[SerializeField]
	private PlayerInputManager playerInputManager;

	public List<Color> PlayerColors = new List<Color>
	{
		Color.red,
		Color.blue
	};

	public static PlayerManager Instance { get; private set; }

	public List<PlayerController> Players { get; private set; }

	public bool IsCoop
	{
		get
		{
			if (Players != null)
			{
				return Players.Count > 1;
			}
			return false;
		}
	}

	public event Action<PlayerController> OnCoopStarted;

	public event Action<PlayerController> OnCoopEnded;

	public event Action OnColorsChanged;

	private void Awake()
	{
		Instance = this;
		if (Players == null)
		{
			Players = new List<PlayerController>();
		}
		playerInputManager.onPlayerJoined += OnPlayerJoined;
	}

	private void Start()
	{
		StartCoroutine(SetColorsAtSaveInitialized());
		IEnumerator SetColorsAtSaveInitialized()
		{
			yield return new WaitUntil(() => SaveManager.Instance.IsInitialized);
			SetPlayerColors(SaveManager.Instance.GetP1Color(), SaveManager.Instance.GetP2Color());
		}
	}

	private void OnPlayerJoined(PlayerInput input)
	{
		if (Players == null || Players.Count == 0)
		{
			Players = new List<PlayerController>();
		}
		if (Players.Count <= 0)
		{
			PlayerController component = input.GetComponent<PlayerController>();
			Players.Add(component);
			if (Players.Count > 1)
			{
				SetPlayerColors(SaveManager.Instance.GetP1Color(), SaveManager.Instance.GetP2Color());
			}
		}
	}

	private void OnDestroy()
	{
		playerInputManager.onPlayerJoined -= OnPlayerJoined;
		Players.Clear();
	}

	public bool CanAddNewPlayer()
	{
		if (Players == null || Players.Count == 0)
		{
			return true;
		}
		if (Players.Count >= maxPlayers)
		{
			Debug.LogWarning("Cannot add more players, maximum reached.");
			return false;
		}
		InputDevice[] array = InputSystem.devices.Where((InputDevice d) => d is Gamepad).ToArray();
		if (Players != null && array.Length < Players.Count)
		{
			Debug.LogWarning("Trying to add player without available controller.");
			return false;
		}
		if (!(LevelManager.Instance.sm.CurrentState is LevelStateStation) && !(LevelManager.Instance.sm.CurrentState is LevelStateFadeIn))
		{
			Debug.LogWarning("Cannot add player outside the station.");
			return false;
		}
		return true;
	}

	public bool TryLoadCoop(ControllerType c1, ControllerType c2)
	{
		InputDevice inputDevice = InputSystem.devices.FirstOrDefault((InputDevice d) => d.name.Contains(StringControllerConverter.GetName(c1)));
		InputDevice inputDevice2 = InputSystem.devices.FirstOrDefault((InputDevice d) => d.name.Contains(StringControllerConverter.GetName(c2)));
		List<InputDevice> list = InputSystem.devices.Where((InputDevice d) => d is Gamepad || d is Keyboard).ToList();
		_ = new InputDevice[2];
		if (inputDevice == null && (inputDevice = list.FirstOrDefault((InputDevice d) => d is Keyboard)) == null && (inputDevice = InputSystem.devices.FirstOrDefault((InputDevice d) => d is Gamepad)) == null)
		{
			return false;
		}
		list.Remove(inputDevice);
		ControllerType controller = StringControllerConverter.GetController(inputDevice.name);
		if (inputDevice2 == null)
		{
			if (controller != ControllerType.KeyboardMouse)
			{
				inputDevice2 = list.FirstOrDefault((InputDevice d) => d is Keyboard || d is Mouse);
				if ((inputDevice2 = list.FirstOrDefault((InputDevice d) => d is Keyboard || d is Mouse)) == null)
				{
					return false;
				}
			}
			else if ((inputDevice2 = list.FirstOrDefault((InputDevice d) => d is Gamepad)) == null)
			{
				return false;
			}
		}
		TryStartCoop(inputDevice, inputDevice2);
		return true;
	}

	public void TryStartCoop(params InputDevice[] devices)
	{
		if (!CanAddNewPlayer())
		{
			Debug.LogWarning("Cannot add new player at this time.");
			return;
		}
		try
		{
			AddNewPlayerController();
			SetPlayerControls(devices);
			SetPlayerColors(SaveManager.Instance.GetP1Color(), SaveManager.Instance.GetP2Color());
			RefreshPlayerInteractors();
		}
		catch (Exception ex)
		{
			Debug.LogError("Failed to add new player: " + ex.Message);
		}
	}

	public void AddNewPlayerController()
	{
		if (Train.Instance == null)
		{
			Debug.LogError("Train instance is null. Cannot add player without a train reference.");
			return;
		}
		int num = 0;
		if (Players == null)
		{
			Players = new List<PlayerController>();
		}
		num = Players.Count;
		GameObject obj = UnityEngine.Object.Instantiate(playerPrefab, Train.Instance.GetPlayerSpawnPoint(num), Quaternion.identity);
		obj.name = $"P{Players.Count + 1}";
		PlayerController component = obj.GetComponent<PlayerController>();
		component.SetUpForNewSpawn();
		component.interactor.RefreshInteractablesArray();
		Players.Add(component);
		this.OnCoopStarted?.Invoke(component);
	}

	private void ClearInputDevices()
	{
		foreach (PlayerController player in Players)
		{
			player.GetComponent<PlayerInput>().user.UnpairDevices();
		}
	}

	private void SetPlayerControls(params InputDevice[] devices)
	{
		ClearInputDevices();
		for (int i = 0; i < Players.Count; i++)
		{
			PlayerController playerController = Players[i];
			if (StringControllerConverter.GetController(devices[i].name) == ControllerType.KeyboardMouse)
			{
				playerController.InputHandler.AssignKeyboardAndMouse();
				continue;
			}
			Gamepad gamepad = devices[i] as Gamepad;
			playerController.InputHandler.AssignGamepad(gamepad);
		}
	}

	public void TryEndCoop()
	{
		if (Players != null && Players.Count > 1)
		{
			List<PlayerController> players = Players;
			RemovePlayerController(players[players.Count - 1]);
		}
	}

	public void RemovePlayerController(PlayerController playerController)
	{
		if (Players.Contains(playerController))
		{
			Players.Remove(playerController);
			this.OnCoopEnded?.Invoke(playerController);
			UnityEngine.Object.Destroy(playerController.gameObject);
		}
	}

	public PlayerController IsTooltipTaken(PlayerController playerController)
	{
		if (playerController == null)
		{
			return null;
		}
		PlayerController playerController2 = GetOtherPlayerControllers(playerController).FirstOrDefault((PlayerController other) => other.interactor.ActiveInteractable == playerController.interactor.ActiveInteractable);
		if ((object)playerController2 != null)
		{
			return playerController2;
		}
		return null;
	}

	private PlayerController[] GetOtherPlayerControllers(PlayerController playerController)
	{
		List<PlayerController> list = new List<PlayerController>();
		foreach (PlayerController player in Players)
		{
			if (player != playerController)
			{
				list.Add(player);
			}
		}
		return list.ToArray();
	}

	public List<Interactable> GetAllPlayersActiveInteractables()
	{
		List<Interactable> list = new List<Interactable>();
		foreach (PlayerController player in Players)
		{
			if (player.interactor.ActiveInteractable != null)
			{
				list.Add(player.interactor.ActiveInteractable);
			}
		}
		return list;
	}

	internal PlayerController GetOtherPlayer(PlayerController thisPc)
	{
		return GetOtherPlayerControllers(thisPc).FirstOrDefault();
	}

	internal Color GetPlayerColor(int playerIndex)
	{
		if (playerIndex < 0 || playerIndex >= PlayerColors.Count)
		{
			return Color.white;
		}
		return PlayerColors[playerIndex];
	}

	internal void SetPlayerColors(Color p1Color, Color p2Color)
	{
		PlayerColors[0] = p1Color;
		PlayerColors[1] = p2Color;
		this.OnColorsChanged?.Invoke();
	}

	internal void RefreshPlayerInteractors()
	{
		foreach (PlayerController player in Players)
		{
			player.interactor.RefreshInteractablesArray();
		}
	}

	internal void SetPlayerInteractablesForTrain()
	{
		foreach (PlayerController player in Players)
		{
			player.interactor.SetWhitelist(Train.Instance.GetModuleInteractables());
		}
	}

	internal void ResolvePlayerInteractorConflict()
	{
		if (Players != null && Players.Count >= 2 && Players[0].interactor.ActiveInteractable != null && Players[1].interactor.ActiveInteractable != null && Players[0].interactor.ActiveInteractable == Players[1].interactor.ActiveInteractable)
		{
			float num = Vector2.Distance(Players[0].transform.position, Players[0].interactor.ActiveInteractable.transform.position);
			float num2 = Vector2.Distance(Players[1].transform.position, Players[1].interactor.ActiveInteractable.transform.position);
			if (num < num2)
			{
				Players[1].StopInteracting();
			}
			else
			{
				Players[0].StopInteracting();
			}
		}
	}
}
