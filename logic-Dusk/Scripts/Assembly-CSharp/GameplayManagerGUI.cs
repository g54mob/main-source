using System.Collections.Generic;
using UnityEngine;

public class GameplayManagerGUI : MonoBehaviour
{
	private const float SHIP_SWAP_WIDTH = 350f;

	private const float SHIP_SWAP_HEIGHT = 175f;

	public static GameplayManagerGUI Instance;

	private GUIStyle commandeerSlotStyle;

	private GUIStyle cheatStyle;

	private Rect commandeerRect = new Rect(0f, 0f, 0f, 0f);

	private Rect commandeerTitleCurrentRect = new Rect(0f, 0f, 0f, 0f);

	private Rect commandeerTitleThisRect = new Rect(0f, 0f, 0f, 0f);

	private Rect commandeerSlotRect = new Rect(0f, 0f, 0f, 0f);

	private Rect commandeerAcceptButtonRect = new Rect(0f, 0f, 0f, 0f);

	private Rect commandeerCancelButtonRect = new Rect(0f, 0f, 0f, 0f);

	public GameOverWindow _gameOverWindow { get; set; }

	public StoreWindow _storeWindow { get; set; }

	public InventoryWindow _inventoryWindow { get; set; }

	public DroneSummaryWindow _droneSummaryWindowForInstall { get; set; }

	public DroneInstallUpgradesWindow _droneInstallUpgradesWindow { get; set; }

	public bool _blankedOutScreen { get; set; }

	public string guiPropulsionFuelCollected { get; set; }

	public string guiJumpFuelCollected { get; set; }

	public string guiRationsCollected { get; set; }

	public string guiRationsNeeded { get; set; }

	public string guiMissionHours { get; set; }

	public string guiMissionMinutes { get; set; }

	public string guiMissionSeconds { get; set; }

	private List<BaseShipUpgrade> commandeerShipSlots { get; set; }

	public GUIStyle hudTextStyle { get; private set; }

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		cheatStyle = new GUIStyle();
		cheatStyle.normal.textColor = Color.red;
		hudTextStyle = new GUIStyle();
		hudTextStyle.normal.textColor = Color.yellow;
	}

	private void OnGUI()
	{
		if (GlobalSettings.GameStateIsLoaded && !LogUI.Instance.IsShowing && GlobalSettings.cheatMode)
		{
			DrawCheatItems();
		}
	}

	private void DrawShipSwapWindow2(int id)
	{
		DungeonInfo myShip = GlobalSettings.GameState.ThePlayer.MyShip;
		DungeonInfo currentDockedDungeon = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon;
		GUI.Label(commandeerTitleCurrentRect, string.Format("Your current ship has {0} slots", myShip.ShipUpgradeSlots));
		GUI.Label(commandeerTitleThisRect, string.Format("========== This Derelict ==========", currentDockedDungeon.ShipUpgradeSlots));
		int num = 0;
		foreach (BaseShipUpgrade commandeerShipSlot in commandeerShipSlots)
		{
			num++;
			commandeerSlotRect.x = 10f;
			GUI.Label(commandeerSlotRect, string.Format(" Slot: {0}", num), commandeerSlotStyle);
			commandeerSlotRect.x = commandeerSlotRect.width + 20f;
			GUI.Label(commandeerSlotRect, string.Format(" {0}", commandeerShipSlot.Name), commandeerSlotStyle);
			commandeerSlotRect.y += 25f;
		}
		if (num < currentDockedDungeon.ShipUpgradeSlots)
		{
			for (int i = num + 1; i <= currentDockedDungeon.ShipUpgradeSlots; i++)
			{
				commandeerSlotRect.x = 10f;
				GUI.Label(commandeerSlotRect, string.Format(" Slot: {0}", i), commandeerSlotStyle);
				commandeerSlotRect.x = commandeerSlotRect.width + 20f;
				GUI.Label(commandeerSlotRect, " [ empty ]", commandeerSlotStyle);
				commandeerSlotRect.y += 25f;
			}
		}
		if (GUI.Button(commandeerAcceptButtonRect, "C[o]mmandeer") || Event.current.keyCode == KeyCode.O)
		{
			GameplayManager.Instance.WindowState = GameWindowStates.None;
			DungeonManager.Instance.CommandeerCurrentDerelict();
			DungeonManager.Instance.DisableAllInputForAMoment();
			ConsoleWindow3.SendConsoleResponse("Commandeering...", ConsoleMessageType.Info);
		}
		else if (GUI.Button(commandeerCancelButtonRect, "[C]ancel") || Event.current.keyCode == KeyCode.C)
		{
			GameplayManager.Instance.WindowState = GameWindowStates.None;
			DungeonManager.Instance.DisableAllInputForAMoment();
			ConsoleWindow3.SendConsoleResponse("Commandeering canceled", ConsoleMessageType.Info);
		}
	}

	private void DrawCheatItems()
	{
		GUI.Label(new Rect(1f, 1f, 100f, 20f), "Cheat Mode!!!", cheatStyle);
		DisplayAndProcessMenuButtons();
		switch (GameplayManager.Instance.WindowState)
		{
		case GameWindowStates.ShowStore:
			_storeWindow.ShowWindow();
			_inventoryWindow.ShowWindow();
			_droneSummaryWindowForInstall.ShowWindow(DroneManager.Instance.IDronesList);
			break;
		case GameWindowStates.ShowDroneInstallUpgrades:
			_droneInstallUpgradesWindow.ShowWindow(DroneManager.Instance.IDronesList);
			_inventoryWindow.ShowWindow();
			_droneSummaryWindowForInstall.ShowWindow(DroneManager.Instance.IDronesList);
			break;
		}
		GUI.Label(new Rect(1f, Screen.height - 80, 100f, 20f), guiPropulsionFuelCollected, hudTextStyle);
		GUI.Label(new Rect(1f, Screen.height - 65, 100f, 20f), guiJumpFuelCollected, hudTextStyle);
		GUI.Label(new Rect(1f, Screen.height - 50, 100f, 20f), guiRationsCollected, hudTextStyle);
		GUI.Label(new Rect(1f, Screen.height - 35, 100f, 20f), guiRationsNeeded, hudTextStyle);
		if (GlobalSettings.MissionStarted)
		{
			GUI.Label(new Rect(1f, Screen.height - 20, 100f, 20f), "Mission Time: " + guiMissionHours + ":" + guiMissionMinutes + ":" + guiMissionSeconds, hudTextStyle);
		}
		else
		{
			GUI.Label(new Rect(1f, Screen.height - 20, 100f, 20f), "Open door leaving docking ship to start mission", hudTextStyle);
		}
	}

	private void DisplayAndProcessMenuButtons()
	{
		int num = 100;
		Rect position = new Rect(1f, num, 50f, 30f);
		if (GUI.Button(position, "Install"))
		{
			ToggleItemInstallMode();
		}
		num += 30;
		position = new Rect(1f, num, 50f, 30f);
		if (GUI.Button(position, "Store"))
		{
			ToggleStoreMode();
		}
	}

	public void ToggleStoreMode()
	{
		if (GameplayManager.Instance.WindowState != GameWindowStates.ShowStore)
		{
			DroneManager.Instance.ShowDroneWindow = false;
			GameplayManager.Instance.WindowState = GameWindowStates.ShowStore;
		}
		else
		{
			DroneManager.Instance.ShowDroneWindow = true;
			GameplayManager.Instance.WindowState = GameWindowStates.None;
		}
	}

	public void ToggleItemInstallMode()
	{
		if (GameplayManager.Instance.WindowState != GameWindowStates.ShowDroneInstallUpgrades)
		{
			DroneManager.Instance.ShowDroneWindow = false;
			_inventoryWindow.InventoryMode = InventoryModeEnum.ItemInstallMode;
			_droneInstallUpgradesWindow.UpdateDroneList(DroneManager.Instance.IDronesList);
			GameplayManager.Instance.WindowState = GameWindowStates.ShowDroneInstallUpgrades;
		}
		else
		{
			DroneManager.Instance.ShowDroneWindow = true;
			GameplayManager.Instance.WindowState = GameWindowStates.None;
		}
	}

	public void Enable()
	{
		base.enabled = true;
	}

	public void Disable()
	{
		if (!GlobalSettings.GameIsOver && !GlobalSettings.cheatMode)
		{
			base.enabled = false;
		}
	}
}
