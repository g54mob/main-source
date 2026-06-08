using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BoardingConfigUi : MonoBehaviour
{
	public delegate void ShipBoardedDelegate();

	private const int TOTAL_DRONE_SLOTS = 7;

	private const int MAX_DEPLOYED_DRONES = 4;

	private const int INVENTORY_ROW_COUNT = 8;

	private const int INVENTORY_COLUMN_COUNT = 3;

	private const int MAX_INVENTORY_SLOTS = 24;

	public static BoardingConfigUi Instance;

	public ShipBoardedDelegate shipBoarded;

	public UIBreakStatsItem breakStats;

	public Image quarantineImage;

	public Color boardingKeyColor = Color.blue;

	public Color boardingTextColor = Color.white;

	public Color selectedKeyHintColor = Color.blue;

	public Color selectedKeySpaceHintColor = Color.white;

	public Color selectedDetailColor = Color.cyan;

	public Color selectedShipOutlineColor = Color.cyan;

	public Color selectedTitleColor = Color.cyan;

	public Color selectedBorderColor = Color.blue;

	public Color selectedDroneBorderColor = Color.blue;

	public Color selectedDroneNumberColor = Color.cyan;

	public Color selectedDroneNameColor = Color.green;

	public Color selectedDroneHPColor = Color.white;

	public Color selectedBoardTitleColor = Color.white;

	public Color selectedBoardingTextColor = Color.green;

	public Color highlightedUpgradeColor = Color.white;

	public Color enabledBoardingArrowColor = Color.white;

	public Color DisabledDrone = Color.yellow;

	public Color DisabledHighlightedDrone = Color.yellow;

	public Color unSelectedDetailColor = Color.gray;

	public Color unSelectedShipOutlineColor = Color.gray;

	public Color unSelectedDroneNumberColor = Color.gray;

	public Color unSelectedDroneNameColor = Color.gray;

	public Color unSelectedDroneHPColor = Color.white;

	public Color unSelectedTitleColor = Color.gray;

	public Color unSelectedBorderColor = Color.gray;

	public Color unSelectedBoardTitleColor = Color.gray;

	public Color unSelectedBoardingTextColor = Color.gray;

	public Color notHighlightedUpgradeColor = Color.gray;

	public Color disabledBoardingArrowColor = Color.gray;

	public Material drone1Mat;

	public Material drone2Mat;

	public Material drone3Mat;

	public Material drone4Mat;

	public Material drone5Mat;

	public Material drone6Mat;

	private bool _initialized;

	private int _currentDroneSlot;

	private int _currentRowInventory;

	private int _currentColInventory;

	private bool boardShipHasFocus;

	private bool _upperSectionHasFocus;

	private bool _droneHighlightedForMove;

	private bool _cursorIsAtInventory;

	private bool _aboutToBoard;

	private BoardingConfigDronePanel[] _droneSlots = new BoardingConfigDronePanel[7];

	private BoardingConfigSelectedDrone _selectedDrone;

	private BoardingConfigInventorySlot[,] _inventory = new BoardingConfigInventorySlot[8, 3];

	private GameObject cursorObject;

	private GameObject playerShipWindow;

	private GameObject arrowToShipWindow;

	private Text _boardingText;

	private Text topMiddleHintText;

	private Text topMiddleHintTextBottomPanel;

	private Text topRightHintTextUpperPanel;

	private Text bottomLeftHintTextUpperPanel;

	private Text bottomMiddleHintTextUpperPanel;

	private Text bottomMiddleHintTextLowerPanel;

	private Text topRightHintTextLowerPanel;

	private Text activeDroneTitleText;

	private Text activeDroneNameText;

	private Text activeDroneNumberText;

	private Text activeDroneLoadoutTitleText;

	private Text activeDroneInventoryTitleText;

	private Text hintText;

	private Text shipInfoText;

	private Text[] _miniIndicatorDroneNumbers = new Text[4];

	private Image _hintsUpperDroneSelect;

	private Image _hintsUpperDroneSwap;

	private Image _hintsLowerUpgradeSwap;

	private Image panelShipInfo;

	private Image panelCTA;

	private Image panelCautionStripes;

	private Image panelCautionStripeBorder;

	private RawImage shipImage;

	private Image borderActiveTitleSmall;

	private Image borderActiveTitleLarge;

	private Image activeBorderLayoutTitleSmall;

	private Image activeBorderInventoryTitleSmall;

	private Image activeBorderPanelLoadout;

	private Image activeDividerLine;

	private Image activeDividerImage;

	private Image activeDroneImage;

	private Image hintBorder;

	private Image _miniIndicatorBorder;

	private Image _arrowToShip;

	private Image _connectorLine1;

	private Image _connectorLine2;

	private bool _needsInitialData = true;

	private bool isCursorOnBoarding = true;

	public bool IsVisible
	{
		get
		{
			return base.gameObject.activeInHierarchy;
		}
		set
		{
			base.gameObject.SetActive(value);
		}
	}

	public bool ReadyToBoard { get; private set; }

	public HelpManualMenuHelper helper { get; private set; }

	private void Awake()
	{
		Instance = this;
		if (!_initialized)
		{
			Initialize();
		}
		if (breakStats != null)
		{
			breakStats.gameObject.SetActive(false);
		}
		if (quarantineImage != null)
		{
			quarantineImage.gameObject.SetActive(false);
		}
	}

	private void OnDestroy()
	{
		quarantineImage = null;
		drone1Mat = null;
		drone2Mat = null;
		drone3Mat = null;
		drone4Mat = null;
		drone5Mat = null;
		drone6Mat = null;
		cursorObject = null;
		playerShipWindow = null;
		arrowToShipWindow = null;
		_boardingText = null;
		topMiddleHintText = null;
		topMiddleHintTextBottomPanel = null;
		topRightHintTextUpperPanel = null;
		bottomLeftHintTextUpperPanel = null;
		bottomMiddleHintTextUpperPanel = null;
		bottomMiddleHintTextLowerPanel = null;
		activeDroneTitleText = null;
		activeDroneNameText = null;
		activeDroneNumberText = null;
		activeDroneLoadoutTitleText = null;
		activeDroneInventoryTitleText = null;
		hintText = null;
		shipInfoText = null;
		if (_miniIndicatorDroneNumbers != null)
		{
			int num = _miniIndicatorDroneNumbers.Length;
			for (int i = 0; i < num; i++)
			{
				_miniIndicatorDroneNumbers[i] = null;
			}
			_miniIndicatorDroneNumbers = null;
		}
		_hintsUpperDroneSelect = null;
		_hintsUpperDroneSwap = null;
		_hintsLowerUpgradeSwap = null;
		panelShipInfo = null;
		panelCTA = null;
		panelCautionStripes = null;
		panelCautionStripeBorder = null;
		shipImage = null;
		borderActiveTitleSmall = null;
		borderActiveTitleLarge = null;
		activeBorderLayoutTitleSmall = null;
		activeBorderInventoryTitleSmall = null;
		activeBorderPanelLoadout = null;
		activeDividerLine = null;
		activeDividerImage = null;
		activeDroneImage = null;
		hintBorder = null;
		_miniIndicatorBorder = null;
		_arrowToShip = null;
		_connectorLine1 = null;
		_connectorLine2 = null;
	}

	private void Initialize()
	{
		if (_initialized)
		{
			return;
		}
		CommandHelper.Initialize();
		helper = new HelpManualMenuHelper();
		helper.BuildMenus(true);
		bool flag = false;
		Transform transform = base.transform.FindChild("PanelUpperSection");
		if (transform != null)
		{
			Transform transform2 = transform.FindChild("PanelActive");
			if (transform2 != null)
			{
				Transform transform3 = transform2.FindChild("PanelCautionStripes");
				Transform transform4;
				if (transform3 != null)
				{
					panelCautionStripes = transform3.gameObject.GetComponent<Image>();
					flag = true;
					for (int i = 0; i < 4; i++)
					{
						string text = (i + 1).ToString("00");
						transform4 = transform3.FindChild("Drone" + text + "Slot");
						if (transform4 != null)
						{
							_droneSlots[i] = transform4.gameObject.GetComponent<BoardingConfigDronePanel>();
							_droneSlots[i].droneSlotImage = transform4.gameObject.GetComponent<Image>();
						}
						else
						{
							flag = false;
						}
					}
					transform4 = transform3.FindChild("ImageBorder");
					panelCautionStripeBorder = transform4.gameObject.GetComponent<Image>();
				}
				transform4 = transform2.FindChild("ImageTopLines");
				if (transform4 != null)
				{
					borderActiveTitleLarge = transform4.gameObject.GetComponent<Image>();
				}
				Transform transform5 = transform2.FindChild("PanelActiveTitle");
				if (transform5 != null)
				{
					transform4 = transform5.FindChild("ImageBorder");
					if (transform4 != null)
					{
						borderActiveTitleSmall = transform4.gameObject.GetComponent<Image>();
					}
					transform4 = transform5.FindChild("Text");
					if (transform4 != null)
					{
						activeDroneTitleText = transform4.gameObject.GetComponent<Text>();
					}
				}
			}
			for (int j = 4; j < 7; j++)
			{
				string text2 = (j + 1).ToString("00");
				Transform transform4 = transform.FindChild("Drone" + text2 + "Slot");
				if (transform4 != null)
				{
					_droneSlots[j] = transform4.gameObject.GetComponent<BoardingConfigDronePanel>();
				}
				if (_droneSlots[j] == null)
				{
					flag = false;
				}
			}
			Transform transform6 = transform.FindChild("ArrowToShip");
			if (transform6 != null)
			{
				arrowToShipWindow = transform6.gameObject;
				Transform transform4 = transform6.FindChild("triangleToBoardingMsg");
				if (transform4 != null)
				{
					_arrowToShip = transform4.gameObject.GetComponent<Image>();
				}
				transform4 = transform6.FindChild("connectorLine1");
				if (transform4 != null)
				{
					_connectorLine1 = transform4.gameObject.GetComponent<Image>();
				}
				transform4 = transform6.FindChild("connectorLine2");
				if (transform4 != null)
				{
					_connectorLine2 = transform4.gameObject.GetComponent<Image>();
				}
			}
		}
		bool flag2 = false;
		Transform transform7 = base.transform.FindChild("PanelLowerLeft");
		if (transform7 != null)
		{
			Transform transform8 = transform7.FindChild("PanelLoadout");
			if (transform8 != null)
			{
				activeBorderPanelLoadout = transform8.gameObject.GetComponent<Image>();
				Transform transform9 = transform8.FindChild("DronesPanel");
				if (transform9 != null)
				{
					_selectedDrone = transform9.gameObject.GetComponent<BoardingConfigSelectedDrone>();
					Transform transform4 = transform9.FindChild("droneName");
					if (transform4 != null)
					{
						activeDroneNameText = transform4.gameObject.GetComponent<Text>();
					}
					transform4 = transform9.FindChild("droneNumberFrame");
					if (transform4 != null)
					{
						transform4 = transform4.FindChild("droneNumber");
						if (transform4 != null)
						{
							activeDroneNumberText = transform4.gameObject.GetComponent<Text>();
						}
					}
					transform4 = transform9.FindChild("Image");
					if (transform4 != null)
					{
						activeDroneImage = transform4.gameObject.GetComponent<Image>();
					}
				}
				Transform transform10 = transform8.FindChild("Inventory");
				if (transform10 != null)
				{
					flag2 = true;
					Transform transform11 = transform10.FindChild("InventoryPanel");
					Transform transform4;
					if (transform11 != null)
					{
						int num = 1;
						char c = 'a';
						for (int k = 0; k < 3; k++)
						{
							for (int l = 0; l < 8; l++)
							{
								transform4 = transform11.FindChild("inventorySlot" + num++);
								if (transform4 != null)
								{
									_inventory[l, k] = transform4.gameObject.GetComponent<BoardingConfigInventorySlot>();
								}
								if (_inventory[l, k] == null)
								{
									flag2 = false;
								}
								else
								{
									_inventory[l, k].address.text = c + ".";
								}
								c = (char)(c + 1);
							}
						}
					}
					transform4 = transform10.FindChild("MiddleDivider");
					if (transform4 != null)
					{
						activeDividerLine = transform4.gameObject.GetComponent<Image>();
					}
					transform4 = transform10.FindChild("Image");
					if (transform4 != null)
					{
						activeDividerImage = transform4.gameObject.GetComponent<Image>();
					}
					Transform transform12 = transform10.FindChild("PanelTitle");
					if (transform12 != null)
					{
						transform4 = transform12.FindChild("Text");
						if (transform4 != null)
						{
							activeDroneInventoryTitleText = transform4.gameObject.GetComponent<Text>();
						}
						transform4 = transform12.FindChild("ImageBorder");
						if (transform4 != null)
						{
							activeBorderInventoryTitleSmall = transform4.gameObject.GetComponent<Image>();
						}
					}
				}
			}
			Transform transform13 = transform7.FindChild("PanelLoadoutTitle");
			if (transform13 != null)
			{
				Transform transform4 = transform13.FindChild("Text");
				if (transform4 != null)
				{
					activeDroneLoadoutTitleText = transform4.gameObject.GetComponent<Text>();
				}
				transform4 = transform13.FindChild("ImageBorder");
				if (transform4 != null)
				{
					activeBorderLayoutTitleSmall = transform4.gameObject.GetComponent<Image>();
				}
			}
			Transform transform14 = transform7.FindChild("PanelCommandHints");
			if (transform14 != null)
			{
				Transform transform15 = transform14.FindChild("UpperDroneSelect");
				if (transform15 != null)
				{
					_hintsUpperDroneSelect = transform15.gameObject.GetComponent<Image>();
					Transform transform4 = transform15.FindChild("topMiddle");
					if (transform4 != null)
					{
						topMiddleHintText = transform4.gameObject.GetComponent<Text>();
					}
					transform4 = transform15.FindChild("topRight");
					if (transform4 != null)
					{
						topRightHintTextUpperPanel = transform4.gameObject.GetComponent<Text>();
					}
					transform4 = transform15.FindChild("bottomMiddle");
					if (transform4 != null)
					{
						bottomMiddleHintTextUpperPanel = transform4.gameObject.GetComponent<Text>();
						bottomMiddleHintTextUpperPanel.enabled = true;
						bottomMiddleHintTextUpperPanel.text = "[CTRL + R] = RENAME DRONE";
					}
					transform4 = transform15.FindChild("bottomLeft");
					if (transform4 != null)
					{
						bottomLeftHintTextUpperPanel = transform4.gameObject.GetComponent<Text>();
						bottomLeftHintTextUpperPanel.enabled = true;
					}
					transform15.gameObject.SetActive(true);
					Text[] componentsInChildren = transform15.GetComponentsInChildren<Text>();
					Text[] array = componentsInChildren;
					foreach (Text text3 in array)
					{
						if (text3 != null)
						{
							text3.color = selectedKeyHintColor;
						}
					}
					bottomMiddleHintTextUpperPanel.color = selectedKeySpaceHintColor;
					bottomMiddleHintTextUpperPanel.enabled = false;
				}
				Transform transform16 = transform14.FindChild("UpperDroneSwap");
				if (transform16 != null)
				{
					_hintsUpperDroneSwap = transform16.gameObject.GetComponent<Image>();
					Transform transform4 = transform16.FindChild("topMiddle");
					if (transform4 != null)
					{
						topMiddleHintTextBottomPanel = transform4.gameObject.GetComponent<Text>();
						topMiddleHintTextBottomPanel.enabled = true;
						topMiddleHintTextBottomPanel.text = "[!CTRL] = EXIT SWAP MODE";
					}
					transform15.gameObject.SetActive(true);
					Text[] componentsInChildren2 = transform15.GetComponentsInChildren<Text>();
					Text[] array2 = componentsInChildren2;
					foreach (Text text4 in array2)
					{
						if (text4 != null)
						{
							text4.color = selectedKeyHintColor;
						}
					}
				}
				Transform transform17 = transform14.FindChild("LowerUpgradeSwap");
				if (transform17 != null)
				{
					_hintsLowerUpgradeSwap = transform17.gameObject.GetComponent<Image>();
					transform17.gameObject.SetActive(true);
					Text[] componentsInChildren3 = transform17.GetComponentsInChildren<Text>();
					Text[] array3 = componentsInChildren3;
					foreach (Text text5 in array3)
					{
						if (text5 != null)
						{
							text5.color = selectedKeyHintColor;
						}
					}
					Transform transform4 = transform17.FindChild("bottomMiddle");
					if (transform4 != null)
					{
						bottomMiddleHintTextLowerPanel = transform4.gameObject.GetComponent<Text>();
						bottomMiddleHintTextLowerPanel.enabled = false;
						bottomMiddleHintTextLowerPanel.color = selectedKeySpaceHintColor;
						bottomMiddleHintTextLowerPanel.text = "[CTRL + R] = RENAME DRONE";
					}
					transform4 = transform17.FindChild("topRight");
					if (transform4 != null)
					{
						topRightHintTextLowerPanel = transform4.gameObject.GetComponent<Text>();
					}
				}
				Transform transform18 = transform14.FindChild("UpgradeHintPanel");
				if (transform18 != null)
				{
					hintBorder = transform18.gameObject.GetComponent<Image>();
					Transform transform4 = transform18.FindChild("hintText");
					if (transform4 != null)
					{
						hintText = transform4.gameObject.GetComponent<Text>();
					}
				}
				_hintsUpperDroneSwap.color = selectedBorderColor;
				_hintsUpperDroneSelect.color = selectedBorderColor;
				_hintsLowerUpgradeSwap.color = selectedBorderColor;
			}
		}
		Transform transform19 = base.transform.FindChild("PanelPlayerShip");
		if (transform19 != null)
		{
			playerShipWindow = transform19.gameObject;
			Transform transform4 = transform19.FindChild("PanelCTA");
			if (transform4 != null)
			{
				panelCTA = transform4.gameObject.GetComponent<Image>();
				transform4 = transform4.FindChild("BoardingText");
				if (transform4 != null)
				{
					_boardingText = transform4.gameObject.GetComponent<Text>();
					Color32 color = boardingKeyColor;
					string text6 = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
					_boardingText.text = "PRESS [<color=" + text6 + ">ENTER</color>] TO BOARD DERELICT";
				}
			}
			transform4 = transform19.FindChild("PanelShipInfo");
			if (transform4 != null)
			{
				panelShipInfo = transform4.gameObject.GetComponent<Image>();
			}
			transform4 = transform19.FindChild("focusSelector");
			if (transform4 != null)
			{
				cursorObject = transform4.gameObject;
				cursorObject.GetComponent<Image>().color = selectedDroneBorderColor;
			}
			transform4 = transform19.FindChild("ShipImage");
			if (transform4 != null)
			{
				shipImage = transform4.GetComponent<RawImage>();
			}
			transform4 = transform19.FindChild("ShipInfo");
			if (transform4 != null)
			{
				shipInfoText = transform4.GetComponent<Text>();
			}
			Transform transform20 = transform19.FindChild("PanelWithStripes");
			if (transform20 != null)
			{
				transform4 = transform20.FindChild("BorderImage");
				if (transform4 != null)
				{
					_miniIndicatorBorder = transform4.gameObject.GetComponent<Image>();
				}
				for (int num3 = 0; num3 < 4; num3++)
				{
					transform4 = transform20.FindChild("droneNumberFrame" + (num3 + 1));
					if (transform4 != null)
					{
						transform4 = transform4.FindChild("droneNumber");
						if (transform4 != null)
						{
							_miniIndicatorDroneNumbers[num3] = transform4.gameObject.GetComponent<Text>();
						}
					}
				}
			}
		}
		if (flag && transform != null)
		{
			for (int num4 = 0; num4 < 7; num4++)
			{
				Image leftArrow = null;
				Image rightArrow = null;
				Transform transform4 = transform.FindChild("leftArrowDrone" + (num4 + 1));
				if (transform4 != null)
				{
					leftArrow = transform4.gameObject.GetComponent<Image>();
				}
				transform4 = transform.FindChild("rightArrowDrone" + (num4 + 1));
				if (transform4 != null)
				{
					rightArrow = transform4.gameObject.GetComponent<Image>();
				}
				_droneSlots[num4].SetLeftRightArrows(leftArrow, rightArrow);
			}
		}
		if (!flag || _selectedDrone == null || !flag2 || _boardingText == null || _hintsUpperDroneSelect == null || _hintsUpperDroneSwap == null || _hintsLowerUpgradeSwap == null || _miniIndicatorDroneNumbers[0] == null || _miniIndicatorDroneNumbers[1] == null || _miniIndicatorDroneNumbers[2] == null || _miniIndicatorDroneNumbers[3] == null || _arrowToShip == null || _connectorLine1 == null || _connectorLine2 == null || _miniIndicatorBorder == null)
		{
			Debug.LogError("BoardingConfigUi did not resolve all fields properly");
		}
		else
		{
			_selectedDrone.IsVisible = false;
		}
		_initialized = true;
	}

	public void SetLatestData()
	{
		SetLatestData(false);
	}

	public void SetLatestData(bool aboutToBoard)
	{
		_needsInitialData = false;
		_aboutToBoard = aboutToBoard;
		if (aboutToBoard)
		{
			_boardingText.gameObject.SetActive(true);
			_boardingText.enabled = true;
			playerShipWindow.SetActive(true);
			arrowToShipWindow.SetActive(true);
			string empty = string.Empty;
			empty = ((GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Value == null) ? GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.imageFileName : GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Value.imageFileName);
			if (!string.IsNullOrEmpty(empty))
			{
				Texture2D texture2D = ResourceManager.LoadAsset<Texture2D>("UI/shipProfiles/" + empty);
				if (texture2D != null)
				{
					shipImage.texture = texture2D;
				}
			}
			if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.IsQuarentined)
			{
				quarantineImage.gameObject.SetActive(true);
			}
			else
			{
				quarantineImage.gameObject.SetActive(false);
			}
		}
		else
		{
			_boardingText.gameObject.SetActive(false);
			playerShipWindow.SetActive(false);
			arrowToShipWindow.SetActive(false);
		}
		_hintsUpperDroneSelect.gameObject.SetActive(true);
		_hintsUpperDroneSwap.gameObject.SetActive(false);
		_hintsLowerUpgradeSwap.gameObject.SetActive(false);
		for (int i = 0; i < 4; i++)
		{
			_miniIndicatorDroneNumbers[i].color = unSelectedDroneNumberColor;
		}
		for (int j = 0; j < 7; j++)
		{
			_droneSlots[j].IsVisible = false;
			_droneSlots[j].SetCursorHere(false);
			_droneSlots[j].SetHighlighted(false);
			_droneSlots[j].ShowLeftRightArrows(false);
			_droneSlots[j].SetDownArrow(false);
			_droneSlots[j].SetDrone(null);
		}
		_selectedDrone.IsVisible = false;
		foreach (IDrone drone in GlobalSettings.GameState.ThePlayer.Drones)
		{
			if (drone != null && drone.DroneNumber <= 7 && drone.DroneNumber > 0)
			{
				_droneSlots[drone.DroneNumber - 1].SetDrone(drone);
				if (drone.DroneNumber <= 4)
				{
					_miniIndicatorDroneNumbers[drone.DroneNumber - 1].color = selectedDroneNumberColor;
				}
			}
		}
		if (aboutToBoard)
		{
			cursorObject.SetActive(true);
			isCursorOnBoarding = true;
			_currentDroneSlot = -1;
			SetFocusOnShipPanel();
			boardShipHasFocus = true;
			if (bottomMiddleHintTextLowerPanel != null)
			{
				bottomMiddleHintTextLowerPanel.enabled = true;
			}
		}
		else
		{
			cursorObject.SetActive(false);
			isCursorOnBoarding = false;
			_droneSlots[0].SetCursorHere(true);
			_droneSlots[0].SetDownArrow(true);
			_currentDroneSlot = 0;
			SetFocusOnUpperPanel();
			topMiddleHintText.text = "[CTRL + Left/Right] = SWAP DRONES";
			_upperSectionHasFocus = true;
			if (breakStats != null)
			{
				Instance.breakStats.gameObject.SetActive(false);
			}
			if (bottomMiddleHintTextLowerPanel != null)
			{
				bottomMiddleHintTextLowerPanel.enabled = true;
			}
		}
		if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon != null)
		{
			shipInfoText.enabled = true;
			shipInfoText.text = string.Empty;
			DungeonInfo currentDockedDungeon = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon;
			if (currentDockedDungeon.DungeonType == DungeonTypeEnum.Derelict)
			{
				Text text = shipInfoText;
				text.text = text.text + "Ship Class: " + currentDockedDungeon.DisplayName;
			}
			if (currentDockedDungeon.DungeonType == DungeonTypeEnum.Station)
			{
				Text text2 = shipInfoText;
				text2.text = text2.text + "Station Class: " + currentDockedDungeon.DisplayName;
			}
			else if (currentDockedDungeon.DungeonType == DungeonTypeEnum.Outpost)
			{
				Text text3 = shipInfoText;
				text3.text = text3.text + "Type: " + currentDockedDungeon.DisplayName;
			}
			else if (currentDockedDungeon.DungeonType == DungeonTypeEnum.Stargate && currentDockedDungeon.HaveVisited)
			{
				shipInfoText.text += string.Format("Destination: {0}", currentDockedDungeon.Parent.IsChildGate ? currentDockedDungeon.Parent.StargateConnection.parentNode.name : currentDockedDungeon.Parent.StargateConnection.childNode.name);
			}
			if (!string.IsNullOrEmpty(shipInfoText.text))
			{
				shipInfoText.text += "\r\n";
			}
			shipInfoText.text += string.Format("Age: {0} ({1})", currentDockedDungeon.Age, currentDockedDungeon.AgeText);
			if (currentDockedDungeon.DungeonType != DungeonTypeEnum.AutoTrade && currentDockedDungeon.DungeonType != DungeonTypeEnum.Stargate)
			{
				Text text4 = shipInfoText;
				text4.text = text4.text + "\r\nInfestation Types: " + currentDockedDungeon.InfestationTypeCount;
			}
			shipInfoText.text += string.Format("\r\nHull Integrity: {0}", currentDockedDungeon.HullIntegrity);
			if (currentDockedDungeon.DungeonType == DungeonTypeEnum.Derelict && !currentDockedDungeon.Definition.Key.suppressCommandeer)
			{
				shipInfoText.text += string.Format("\r\nScrap Capacity: {0}", currentDockedDungeon.ScrapMax);
			}
		}
		else
		{
			shipInfoText.enabled = false;
		}
		_droneHighlightedForMove = false;
		RefreshInventoryItems();
		_currentRowInventory = 0;
		_currentColInventory = 0;
		_cursorIsAtInventory = false;
	}

	private void RefreshInventoryItems()
	{
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 8; j++)
			{
				_inventory[j, i].SetInventoryItem(null);
				_inventory[j, i].SetCursorHere(false);
			}
		}
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		if (GlobalSettings.GameState.ThePlayer.Inventory.ItemsCopy == null)
		{
			return;
		}
		foreach (IInventoryItem item in GlobalSettings.GameState.ThePlayer.Inventory.ItemsCopy)
		{
			if (item.InventoryType != InventoryTypeEnum.DroneUpgrade)
			{
				continue;
			}
			_inventory[num2, num3].SetInventoryItem(item);
			if (++num >= 24)
			{
				Debug.LogWarning("Too many inventory items to display in UI");
				break;
			}
			if (++num2 >= 8)
			{
				num2 = 0;
				if (++num3 >= 3)
				{
					Debug.LogWarning("Too many inventory items to display in UI (2)");
					break;
				}
			}
		}
	}

	private void Update()
	{
		if (DialogUI.Instance.IsShowing)
		{
			return;
		}
		if (_needsInitialData)
		{
			_needsInitialData = false;
			SetLatestData();
		}
		if (Input.GetKeyDown(KeyCode.Escape) && (boardShipHasFocus || (!_aboutToBoard && _upperSectionHasFocus)))
		{
			IsVisible = false;
			SystemOverlayUI.Instance.IsVisible = true;
			SystemOverlayUI.Instance.RefreshDroneInfo();
			GameAudio.Play2DSFX(GameAudio.SoundEnum.UIExitMenu);
			return;
		}
		if (boardShipHasFocus)
		{
			ProcessKeyPressesForBoardSection();
		}
		bool flag = true;
		if (_selectedDrone != null && ((CommonMethods.ControlKeyIsBeingPressed() && Input.GetKeyDown(KeyCode.R)) || Input.GetKeyDown(KeyCode.F2)) && _currentDroneSlot >= 0 && _droneSlots[_currentDroneSlot].ThisDrone != null)
		{
			DialogUI.Instance.ShowDialog("Drone Rename", "Enter new name...", ModalWindowType.OKCancelInput, delegate(ModalWindowResult result, string inputString)
			{
				if (result == ModalWindowResult.OK)
				{
					((NonVisualDrone)_droneSlots[_currentDroneSlot].ThisDrone).DroneName = inputString;
					_droneSlots[_currentDroneSlot].dronePanel.droneName.text = _droneSlots[_currentDroneSlot].ThisDrone.DroneName;
				}
			}, 0, _droneSlots[_currentDroneSlot].dronePanel.droneName.text);
			flag = false;
		}
		if (flag)
		{
			if (_upperSectionHasFocus)
			{
				ProcessKeyPressesForUpperSection();
			}
			else if (!boardShipHasFocus)
			{
				ProcessKeyPressesForLowerSection();
			}
		}
	}

	private void ProcessKeyPressesForBoardSection()
	{
		if (Input.GetButtonDown("Left"))
		{
			isCursorOnBoarding = false;
			cursorObject.SetActive(false);
			GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectHigh);
			topMiddleHintText.text = "[CTRL + Left/Right] = SWAP DRONES";
			_currentDroneSlot = 6;
			_droneSlots[_currentDroneSlot].SetCursorHere(true);
			if (_droneSlots[_currentDroneSlot].ThisDrone != null)
			{
				_droneSlots[_currentDroneSlot].SetDownArrow(true);
			}
			Input.ResetInputAxes();
			SetFocusOnUpperPanel();
		}
		else if (Input.GetButtonDown("Right"))
		{
			isCursorOnBoarding = false;
			GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectHigh);
			cursorObject.SetActive(false);
			topMiddleHintText.text = "[CTRL + Left/Right] = SWAP DRONES";
			_currentDroneSlot = 0;
			_droneSlots[_currentDroneSlot].SetCursorHere(true);
			if (_droneSlots[_currentDroneSlot].ThisDrone != null)
			{
				_droneSlots[_currentDroneSlot].SetDownArrow(true);
			}
			Input.ResetInputAxes();
			SetFocusOnUpperPanel();
		}
		else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			BoardShip();
			Input.ResetInputAxes();
		}
	}

	private void ConfirmBoardShip(ModalWindowResult result, string input)
	{
		if (result == ModalWindowResult.Yes)
		{
			BoardShip(true);
		}
	}

	private void BoardShip()
	{
		BoardShip(false);
	}

	private void BoardShip(bool force)
	{
		if (!GlobalSettings.GameState.ThePlayer.Drones.Any((IDrone x) => !x.IsDead && x.DroneNumber <= 4 && x.CurrentHitPoints > 0f))
		{
			DialogUI.Instance.ShowDialog("No Active Drones in Boarding Fleet", "At least 1 non-disabled drone required in the \"Boarding Drones\" section to board. Use modifications menu to repair disabled drones or use active reserve drones.");
			return;
		}
		if (!force && GlobalSettings.GameState.ThePlayer.Drones.Any((IDrone x) => x.DroneNumber <= 4 && x.CurrentHitPoints == 0f) && !GameSaveFile.Get("MSG_SUP_DISDRONEWARN", false))
		{
			DialogUI.Instance.ShowDialog("Deploy With Disabled Drone?", "Are you sure you want to board the ship with a disabled drone? (use Modifications menu to repair drones)", ModalWindowType.YesNo, ConfirmBoardShip, 1);
			return;
		}
		if (!GameSaveFile.Get("WS_LOAD_NOTFULL", false))
		{
			bool flag = false;
			int num = 0;
			int num2 = 0;
			for (int num3 = 0; num3 < 7; num3++)
			{
				if (num3 < 4 && _droneSlots[num3].ThisDrone != null)
				{
					num++;
				}
				if (_droneSlots[num3].ThisDrone != null)
				{
					num2++;
				}
			}
			if (num < num2 && !GameSaveFile.Get("HNT_DISABLE", false))
			{
				DialogUI.Instance.ShowDialog("Are You Sure?", "You are leaving a drone behind.\r\n\r\nWas this intentional?\r\n\r\nThis warning won't show again.", ModalWindowType.YesNo, delegate(ModalWindowResult result, string inputString)
				{
					if (result == ModalWindowResult.Yes)
					{
						ReadyToBoard = true;
						GalaxyMapManager.Instance.DestroyObjectsBeforeBoard();
						SystemOverlayUI.Instance.IsVisible = true;
						SystemOverlayUI.Instance.RefreshDroneInfo();
						IsVisible = false;
					}
				});
				flag = true;
			}
			for (int num4 = 0; num4 < 8; num4++)
			{
				for (int num5 = 0; num5 < 3; num5++)
				{
					if (_inventory[num4, num5].InventoryItem == null || GameSaveFile.Get("HNT_DISABLE", false))
					{
						continue;
					}
					DialogUI.Instance.ShowDialog("Are You Sure?", "You are leaving some critical drone upgrades behind.\r\n\r\nWould you like to continue without them?\r\n\r\n(This warning won't show again)", ModalWindowType.YesNo, delegate(ModalWindowResult result, string inputString)
					{
						if (result == ModalWindowResult.Yes)
						{
							ReadyToBoard = true;
							GalaxyMapManager.Instance.DestroyObjectsBeforeBoard();
							SystemOverlayUI.Instance.IsVisible = true;
							SystemOverlayUI.Instance.RefreshDroneInfo();
							IsVisible = false;
						}
					}, 1);
					flag = true;
				}
			}
			GameSaveFile.Save("WS_LOAD_NOTFULL", true);
			if (flag)
			{
				return;
			}
		}
		ReadyToBoard = true;
		GalaxyMapManager.Instance.DestroyObjectsBeforeBoard();
		SystemOverlayUI.Instance.RefreshDroneInfo();
		IsVisible = false;
		if (shipBoarded != null)
		{
			shipBoarded();
		}
	}

	private void ProcessKeyPressesForUpperSection()
	{
		if (!_droneHighlightedForMove)
		{
			int zeroBasedIndex;
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				SetFocusOnShipPanel();
				Input.ResetInputAxes();
			}
			else if (_aboutToBoard && Input.GetKeyDown(KeyCode.Space))
			{
				BoardShip();
			}
			else if (Input.GetButtonDown("Left"))
			{
				if (_currentDroneSlot < 0)
				{
					_currentDroneSlot = 0;
				}
				_droneSlots[_currentDroneSlot].SetCursorHere(false);
				_droneSlots[_currentDroneSlot].SetDownArrow(false);
				if (_currentDroneSlot == 0)
				{
					if (_aboutToBoard)
					{
						SetFocusOnShipPanel();
					}
					else
					{
						_currentDroneSlot = 6;
						_droneSlots[_currentDroneSlot].SetCursorHere(true);
						if (_droneSlots[_currentDroneSlot].ThisDrone != null)
						{
							_droneSlots[_currentDroneSlot].SetDownArrow(true);
						}
						SetFocusOnUpperPanel();
					}
				}
				else
				{
					_currentDroneSlot--;
					_droneSlots[_currentDroneSlot].SetCursorHere(true);
					if (_droneSlots[_currentDroneSlot].ThisDrone != null)
					{
						_droneSlots[_currentDroneSlot].SetDownArrow(true);
					}
					SetFocusOnUpperPanel();
				}
				GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectHigh);
			}
			else if (Input.GetButtonDown("Right"))
			{
				if (_currentDroneSlot < 0)
				{
					return;
				}
				_droneSlots[_currentDroneSlot].SetCursorHere(false);
				_droneSlots[_currentDroneSlot].SetDownArrow(false);
				if (_currentDroneSlot == 6)
				{
					if (_aboutToBoard)
					{
						SetFocusOnShipPanel();
					}
					else
					{
						_currentDroneSlot = 0;
						_droneSlots[_currentDroneSlot].SetCursorHere(true);
						if (_droneSlots[_currentDroneSlot].ThisDrone != null)
						{
							_droneSlots[_currentDroneSlot].SetDownArrow(true);
						}
						SetFocusOnUpperPanel();
					}
				}
				else
				{
					_currentDroneSlot++;
					_droneSlots[_currentDroneSlot].SetCursorHere(true);
					if (_droneSlots[_currentDroneSlot].ThisDrone != null)
					{
						_droneSlots[_currentDroneSlot].SetDownArrow(true);
					}
					SetFocusOnUpperPanel();
				}
				GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectHigh);
			}
			else if (!isCursorOnBoarding && (Input.GetButtonDown("Down") || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
			{
				if (_droneSlots[_currentDroneSlot].ThisDrone != null)
				{
					_upperSectionHasFocus = false;
					_cursorIsAtInventory = false;
					GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectLow);
					_selectedDrone.SetDrone(_droneSlots[_currentDroneSlot].ThisDrone);
					_selectedDrone.ShowCursor(true);
					_droneSlots[_currentDroneSlot].SetDownArrow(false);
					topRightHintTextLowerPanel.text = "[1-" + _droneSlots[_currentDroneSlot].ThisDrone.NumberOfUpgradeSlots + "] = QUICK SWAP";
					_currentRowInventory = 0;
					_currentColInventory = 0;
					_hintsUpperDroneSelect.gameObject.SetActive(false);
					_hintsUpperDroneSwap.gameObject.SetActive(false);
					_hintsLowerUpgradeSwap.gameObject.SetActive(true);
					SetFocusOnLowerPanel();
				}
				else
				{
					CommonAudioHelper.Instance.PlayErrorSound();
				}
			}
			else if (CheckForKeyPressForNumericIndexSelect(out zeroBasedIndex))
			{
				if (_currentDroneSlot != zeroBasedIndex && zeroBasedIndex >= 0 && zeroBasedIndex < 7)
				{
					if (_currentDroneSlot != -1)
					{
						_droneSlots[_currentDroneSlot].SetCursorHere(false);
						_droneSlots[_currentDroneSlot].SetDownArrow(false);
					}
					_currentDroneSlot = zeroBasedIndex;
					_droneSlots[_currentDroneSlot].SetCursorHere(true);
					if (_droneSlots[_currentDroneSlot].ThisDrone != null)
					{
						_droneSlots[_currentDroneSlot].SetDownArrow(true);
					}
				}
			}
			else if (CommonMethods.ControlKeyIsDown() && !isCursorOnBoarding)
			{
				_droneHighlightedForMove = true;
				_droneSlots[_currentDroneSlot].SetHighlighted(true);
				_droneSlots[_currentDroneSlot].ShowLeftRightArrows(true);
				_droneSlots[_currentDroneSlot].SetDownArrow(false);
				_hintsUpperDroneSelect.gameObject.SetActive(false);
				_hintsUpperDroneSwap.gameObject.SetActive(true);
				_hintsLowerUpgradeSwap.gameObject.SetActive(false);
			}
		}
		else if (Input.GetButtonDown("Left"))
		{
			int num = ((_currentDroneSlot != 0) ? (_currentDroneSlot - 1) : 6);
			SwapDroneSlots(_currentDroneSlot, num);
			_droneSlots[_currentDroneSlot].SetHighlighted(false);
			_droneSlots[num].SetHighlighted(true);
			_droneSlots[_currentDroneSlot].ShowLeftRightArrows(false);
			_droneSlots[num].ShowLeftRightArrows(true);
			_droneSlots[_currentDroneSlot].SetCursorHere(false);
			_droneSlots[num].SetCursorHere(true);
			_currentDroneSlot = num;
			GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectHigh);
		}
		else if (Input.GetButtonDown("Right"))
		{
			int num2 = ((_currentDroneSlot != 6) ? (_currentDroneSlot + 1) : 0);
			SwapDroneSlots(_currentDroneSlot, num2);
			_droneSlots[_currentDroneSlot].SetHighlighted(false);
			_droneSlots[num2].SetHighlighted(true);
			_droneSlots[_currentDroneSlot].ShowLeftRightArrows(false);
			_droneSlots[num2].ShowLeftRightArrows(true);
			_droneSlots[_currentDroneSlot].SetCursorHere(false);
			_droneSlots[num2].SetCursorHere(true);
			_currentDroneSlot = num2;
			GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectHigh);
		}
		else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			_droneHighlightedForMove = false;
			_droneSlots[_currentDroneSlot].SetCursorHere(true);
			_droneSlots[_currentDroneSlot].SetHighlighted(false);
			_droneSlots[_currentDroneSlot].ShowLeftRightArrows(false);
			if (_droneSlots[_currentDroneSlot].ThisDrone != null)
			{
				_droneSlots[_currentDroneSlot].SetDownArrow(true);
			}
			_hintsUpperDroneSelect.gameObject.SetActive(true);
			_hintsUpperDroneSwap.gameObject.SetActive(false);
			_hintsLowerUpgradeSwap.gameObject.SetActive(false);
		}
		else if (!CommonMethods.ControlKeyIsBeingPressed())
		{
			_droneHighlightedForMove = false;
			_droneSlots[_currentDroneSlot].SetCursorHere(true);
			_droneSlots[_currentDroneSlot].SetHighlighted(false);
			_droneSlots[_currentDroneSlot].ShowLeftRightArrows(false);
			if (_droneSlots[_currentDroneSlot].ThisDrone != null)
			{
				_droneSlots[_currentDroneSlot].SetDownArrow(true);
			}
			_hintsUpperDroneSelect.gameObject.SetActive(true);
			_hintsUpperDroneSwap.gameObject.SetActive(false);
			_hintsLowerUpgradeSwap.gameObject.SetActive(false);
		}
	}

	private bool CheckForKeyPressForNumericIndexSelect(out int zeroBasedIndex)
	{
		bool result = false;
		zeroBasedIndex = -1;
		if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
		{
			result = true;
			zeroBasedIndex = 0;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
		{
			result = true;
			zeroBasedIndex = 1;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
		{
			result = true;
			zeroBasedIndex = 2;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
		{
			result = true;
			zeroBasedIndex = 3;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
		{
			result = true;
			zeroBasedIndex = 4;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
		{
			result = true;
			zeroBasedIndex = 5;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7))
		{
			result = true;
			zeroBasedIndex = 6;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8))
		{
			result = true;
			zeroBasedIndex = 6;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9))
		{
			result = true;
			zeroBasedIndex = 6;
		}
		return result;
	}

	private bool ProcessAlphaShortcutKeysInventory(out int newRow, out int newCol)
	{
		bool result = false;
		newRow = _currentRowInventory;
		newCol = _currentColInventory;
		if (Input.GetKeyDown(KeyCode.A))
		{
			newRow = 0;
			newCol = 0;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.B))
		{
			newRow = 1;
			newCol = 0;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.C))
		{
			newRow = 2;
			newCol = 0;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.D))
		{
			newRow = 3;
			newCol = 0;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.E))
		{
			newRow = 4;
			newCol = 0;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.F))
		{
			newRow = 5;
			newCol = 0;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.G))
		{
			newRow = 6;
			newCol = 0;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.H))
		{
			newRow = 7;
			newCol = 0;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.I))
		{
			newRow = 0;
			newCol = 1;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.J))
		{
			newRow = 1;
			newCol = 1;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.K))
		{
			newRow = 2;
			newCol = 1;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.L))
		{
			newRow = 3;
			newCol = 1;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.M))
		{
			newRow = 4;
			newCol = 1;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.N))
		{
			newRow = 5;
			newCol = 1;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.O))
		{
			newRow = 6;
			newCol = 1;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.P))
		{
			newRow = 7;
			newCol = 1;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.Q))
		{
			newRow = 0;
			newCol = 2;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.R))
		{
			newRow = 1;
			newCol = 2;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.S))
		{
			newRow = 2;
			newCol = 2;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.T))
		{
			newRow = 3;
			newCol = 2;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.U))
		{
			newRow = 4;
			newCol = 2;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.V))
		{
			newRow = 5;
			newCol = 2;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.W))
		{
			newRow = 6;
			newCol = 2;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.X))
		{
			newRow = 7;
			newCol = 2;
			result = true;
		}
		return result;
	}

	private void SwapDroneSlots(int slot1, int slot2)
	{
		IDrone thisDrone = _droneSlots[slot1].ThisDrone;
		IDrone thisDrone2 = _droneSlots[slot2].ThisDrone;
		if (slot1 < 4)
		{
			_miniIndicatorDroneNumbers[slot1].color = unSelectedDroneNumberColor;
		}
		if (slot2 < 4)
		{
			_miniIndicatorDroneNumbers[slot2].color = unSelectedDroneNumberColor;
		}
		_droneSlots[slot1].SetDrone(thisDrone2);
		_droneSlots[slot2].SetDrone(thisDrone);
		if (thisDrone != null)
		{
			thisDrone.DroneNumber = slot2 + 1;
			if (slot2 < 4)
			{
				_miniIndicatorDroneNumbers[slot2].color = selectedDroneNumberColor;
			}
		}
		if (thisDrone2 != null)
		{
			thisDrone2.DroneNumber = slot1 + 1;
			if (slot1 < 4)
			{
				_miniIndicatorDroneNumbers[slot1].color = selectedDroneNumberColor;
			}
		}
	}

	private void ProcessKeyPressesForLowerSection()
	{
		if (_aboutToBoard && Input.GetKeyDown(KeyCode.Space))
		{
			BoardShip();
			return;
		}
		if (((!_cursorIsAtInventory && _selectedDrone.CurrentSlotIndex == 0) || (_cursorIsAtInventory && _currentRowInventory == 0)) && Input.GetButtonDown("Up"))
		{
			_upperSectionHasFocus = true;
			GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectHigh);
			if (breakStats != null)
			{
				Instance.breakStats.gameObject.SetActive(false);
			}
			_selectedDrone.SetDrone(null);
			_droneSlots[_currentDroneSlot].SetHighlighted(false);
			_droneSlots[_currentDroneSlot].SetCursorHere(true);
			if (_droneSlots[_currentDroneSlot].ThisDrone != null)
			{
				_droneSlots[_currentDroneSlot].SetDownArrow(true);
			}
			CurInvSlot().SetCursorHere(false);
			_currentRowInventory = 0;
			_currentColInventory = 0;
			_hintsUpperDroneSelect.gameObject.SetActive(true);
			_hintsUpperDroneSwap.gameObject.SetActive(false);
			_hintsLowerUpgradeSwap.gameObject.SetActive(false);
			SetFocusOnUpperPanel();
			return;
		}
		if (Input.GetKeyUp(KeyCode.Escape))
		{
			_upperSectionHasFocus = true;
			if (breakStats != null)
			{
				Instance.breakStats.gameObject.SetActive(false);
			}
			_selectedDrone.SetDrone(null);
			if (_currentDroneSlot >= 0)
			{
				_droneSlots[_currentDroneSlot].SetHighlighted(false);
				_droneSlots[_currentDroneSlot].SetCursorHere(true);
				if (_droneSlots[_currentDroneSlot].ThisDrone != null)
				{
					_droneSlots[_currentDroneSlot].SetDownArrow(true);
				}
			}
			CurInvSlot().SetCursorHere(false);
			_currentRowInventory = 0;
			_currentColInventory = 0;
			_hintsUpperDroneSelect.gameObject.SetActive(true);
			_hintsUpperDroneSwap.gameObject.SetActive(false);
			_hintsLowerUpgradeSwap.gameObject.SetActive(false);
			SetFocusOnUpperPanel();
			GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectHigh);
			return;
		}
		if (!_cursorIsAtInventory)
		{
			if (Input.GetButtonDown("Right"))
			{
				_cursorIsAtInventory = true;
				_selectedDrone.ShowCursor(false);
				_currentRowInventory = 0;
				_currentColInventory = 0;
				BoardingConfigInventorySlot boardingConfigInventorySlot = null;
				for (int i = 0; i < 3; i++)
				{
					for (int j = 0; j < 8; j++)
					{
						if (_inventory[j, i].InventoryItem != null)
						{
							_currentRowInventory = j;
							_currentColInventory = i;
							boardingConfigInventorySlot = _inventory[j, i];
							break;
						}
					}
					if (boardingConfigInventorySlot != null)
					{
						break;
					}
				}
				if (boardingConfigInventorySlot == null)
				{
					boardingConfigInventorySlot = _inventory[0, 0];
				}
				if (boardingConfigInventorySlot != null)
				{
					boardingConfigInventorySlot.SetCursorHere(true);
					GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectLow);
				}
			}
			else if (Input.GetButtonDown("Up"))
			{
				_selectedDrone.ArrowUp();
			}
			else if (Input.GetButtonDown("Down"))
			{
				_selectedDrone.ArrowDown();
			}
			else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
			{
				if (_selectedDrone.SelectedUpgrade != null)
				{
					RemoveCurrentUpgradeAndMoveToInventory();
				}
				else
				{
					CommonAudioHelper.Instance.PlayErrorSound();
				}
			}
			else if (Input.GetButtonDown("Left") && _aboutToBoard)
			{
				_selectedDrone.ArrowUp(true);
				_selectedDrone.SetDrone(null);
				SetFocusOnShipPanel();
				GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectLow);
			}
		}
		else if (Input.GetButtonDown("Left") && _currentColInventory == 0)
		{
			_cursorIsAtInventory = false;
			_selectedDrone.SetCursorAtSlot(_selectedDrone.CurrentSlotIndex);
			CurInvSlot().SetCursorHere(false);
			_currentRowInventory = 0;
			_currentColInventory = 0;
			GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectLow);
		}
		else if (Input.GetButtonDown("Left"))
		{
			CurInvSlot().SetCursorHere(false);
			_currentColInventory--;
			CurInvSlot().SetCursorHere(true);
			GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectLow);
		}
		else if (Input.GetButtonDown("Right"))
		{
			if (_currentColInventory < 2 && InvSlot(_currentRowInventory, _currentColInventory + 1) != null)
			{
				CurInvSlot().SetCursorHere(false);
				_currentColInventory++;
				CurInvSlot().SetCursorHere(true);
				GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectLow);
			}
		}
		else if (Input.GetButtonDown("Up"))
		{
			CurInvSlot().SetCursorHere(false);
			_currentRowInventory--;
			CurInvSlot().SetCursorHere(true);
			GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectLow);
		}
		else if (Input.GetButtonDown("Down"))
		{
			if (_currentColInventory < 7 && InvSlot(_currentRowInventory + 1, _currentColInventory) != null)
			{
				CurInvSlot().SetCursorHere(false);
				_currentRowInventory++;
				CurInvSlot().SetCursorHere(true);
			}
			GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectLow);
		}
		else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			if (_selectedDrone.ThisDrone.NumberOfUpgradesInstalled() < _selectedDrone.ThisDrone.NumberOfUpgradeSlots)
			{
				RemoveCurrentItemFromInventoryAndInstall();
			}
			else
			{
				CommonAudioHelper.Instance.PlayErrorSound();
			}
		}
		int newRow;
		int newCol;
		int zeroBasedIndex;
		if (ProcessAlphaShortcutKeysInventory(out newRow, out newCol))
		{
			if (newRow >= 0 && newRow < 8 && newCol >= 0 && newCol < 3)
			{
				if (!_cursorIsAtInventory)
				{
					_selectedDrone.ShowCursor(false);
					_cursorIsAtInventory = true;
				}
				else
				{
					CurInvSlot().SetCursorHere(false);
				}
				_currentRowInventory = newRow;
				_currentColInventory = newCol;
				CurInvSlot().SetCursorHere(true);
				if (_selectedDrone.ThisDrone.NumberOfUpgradesInstalled() < _selectedDrone.ThisDrone.NumberOfUpgradeSlots)
				{
					RemoveCurrentItemFromInventoryAndInstall();
				}
				else
				{
					CommonAudioHelper.Instance.PlayErrorSound();
				}
			}
		}
		else if (CheckForKeyPressForNumericIndexSelect(out zeroBasedIndex) && zeroBasedIndex >= 0 && (_selectedDrone.ThisDrone == null || zeroBasedIndex < _selectedDrone.ThisDrone.NumberOfUpgradeSlots))
		{
			if (_cursorIsAtInventory)
			{
				_cursorIsAtInventory = false;
				_selectedDrone.ShowCursor(true);
				CurInvSlot().SetCursorHere(false);
				_currentRowInventory = 0;
				_currentColInventory = 0;
			}
			_selectedDrone.SetCursorAtSlot(zeroBasedIndex);
			if (_selectedDrone.SelectedUpgrade != null)
			{
				RemoveCurrentUpgradeAndMoveToInventory();
			}
			else
			{
				CommonAudioHelper.Instance.PlayErrorSound();
			}
		}
	}

	private void RemoveCurrentItemFromInventoryAndInstall()
	{
		IInventoryItem inventoryItem = CurInvSlot().InventoryItem;
		if (inventoryItem != null)
		{
			GlobalSettings.GameState.ThePlayer.RemoveFromInventory(inventoryItem);
			_selectedDrone.InstallUpgradeAnySlot((BaseDroneUpgrade)inventoryItem);
			_droneSlots[_currentDroneSlot].SetDrone(_droneSlots[_currentDroneSlot].ThisDrone);
			_selectedDrone.SetDrone(_selectedDrone.ThisDrone);
			RefreshInventoryItems();
			GameAudio.Play2DSFX(GameAudio.SoundEnum.UIEquip);
			if (CurInvSlot().InventoryItem == null)
			{
				bool flag = false;
				for (int num = 2; num >= 0; num--)
				{
					for (int num2 = 7; num2 >= 0; num2--)
					{
						if (InvSlot(num2, num).InventoryItem != null)
						{
							flag = true;
							CurInvSlot().SetCursorHere(false);
							_currentRowInventory = num2;
							_currentColInventory = num;
							CurInvSlot().SetCursorHere(true);
							_selectedDrone.ShowCursor(false);
							break;
						}
					}
					if (flag)
					{
						break;
					}
				}
				if (!flag)
				{
					_cursorIsAtInventory = false;
					_selectedDrone.ShowCursor(true);
					CurInvSlot().SetCursorHere(false);
					_currentRowInventory = 0;
					_currentColInventory = 0;
				}
			}
			else
			{
				CurInvSlot().SetCursorHere(true);
				_selectedDrone.ShowCursor(false);
			}
		}
		else
		{
			CommonAudioHelper.Instance.PlayErrorSound();
		}
	}

	private void RemoveCurrentUpgradeAndMoveToInventory()
	{
		BoardingConfigInventorySlot boardingConfigInventorySlot = null;
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 8; j++)
			{
				if (_inventory[j, i].InventoryItem == null)
				{
					boardingConfigInventorySlot = _inventory[j, i];
					break;
				}
			}
			if (boardingConfigInventorySlot != null)
			{
				break;
			}
		}
		if (boardingConfigInventorySlot != null && GlobalSettings.GameState.ThePlayer.AddToInventory(_selectedDrone.SelectedUpgrade))
		{
			boardingConfigInventorySlot.SetInventoryItem(_selectedDrone.SelectedUpgrade);
			_selectedDrone.RemoveSelectedUpgrade();
			_droneSlots[_currentDroneSlot].SetDrone(_droneSlots[_currentDroneSlot].ThisDrone);
			GameAudio.Play2DSFX(GameAudio.SoundEnum.UIUnEquip);
		}
		ClearHintText();
	}

	private BoardingConfigInventorySlot CurInvSlot()
	{
		return InvSlot(_currentRowInventory, _currentColInventory);
	}

	private BoardingConfigInventorySlot InvSlot(int row, int col)
	{
		if (row < 0 || row >= 8 || col < 0 || col >= 3)
		{
			return null;
		}
		return _inventory[row, col];
	}

	private void SetFocusOnShipPanel()
	{
		LoseFocusOnUpperPanel();
		LoseFocusOnLowerPanel();
		_hintsUpperDroneSelect.gameObject.SetActive(true);
		boardShipHasFocus = true;
		isCursorOnBoarding = true;
		bottomMiddleHintTextUpperPanel.enabled = false;
		bottomLeftHintTextUpperPanel.enabled = false;
		topRightHintTextUpperPanel.enabled = false;
		_currentDroneSlot = -1;
		isCursorOnBoarding = true;
		cursorObject.SetActive(true);
		_boardingText.enabled = true;
		topMiddleHintText.text = "[ENTER] = BOARD SHIP";
		panelCTA.color = selectedBorderColor;
		panelShipInfo.color = selectedBorderColor;
		shipImage.color = selectedShipOutlineColor;
		shipInfoText.color = selectedBoardingTextColor;
		Color32 color = boardingTextColor;
		Color32 color2 = boardingKeyColor;
		string text = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
		string text2 = color2.r.ToString("X2") + color2.g.ToString("X2") + color2.b.ToString("X2");
		_boardingText.text = "<color=#" + text + ">PRESS [</color><color=#" + text2 + ">ENTER</color><color=#" + text + ">] TO BOARD DERELICT</color>";
	}

	private void LoseFocusOnShipPanel()
	{
		boardShipHasFocus = false;
		isCursorOnBoarding = false;
		panelCTA.color = unSelectedBorderColor;
		panelShipInfo.color = unSelectedBorderColor;
		shipImage.color = unSelectedShipOutlineColor;
		shipInfoText.color = unSelectedBoardingTextColor;
		Color32 color = boardingTextColor;
		Color32 color2 = boardingKeyColor;
		string text = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
		string text2 = color2.r.ToString("X2") + color2.g.ToString("X2") + color2.b.ToString("X2");
		_boardingText.text = "<color=#" + text + ">PRESS [</color><color=#" + text2 + ">SPACE</color><color=#" + text + ">] TO BOARD DERELICT</color>";
	}

	private void SetFocusOnUpperPanel()
	{
		SetFocusOnUpperPanel(false);
	}

	private void SetFocusOnUpperPanel(bool currentOnly)
	{
		LoseFocusOnShipPanel();
		LoseFocusOnLowerPanel();
		_hintsUpperDroneSelect.gameObject.SetActive(true);
		_upperSectionHasFocus = true;
		if (breakStats != null)
		{
			Instance.breakStats.gameObject.SetActive(false);
		}
		bottomMiddleHintTextUpperPanel.enabled = true;
		bottomMiddleHintTextUpperPanel.color = selectedKeySpaceHintColor;
		bottomLeftHintTextUpperPanel.enabled = true;
		topRightHintTextUpperPanel.enabled = true;
		panelCautionStripes.color = selectedBorderColor;
		panelCautionStripeBorder.color = selectedBorderColor;
		borderActiveTitleLarge.color = selectedBorderColor;
		borderActiveTitleSmall.color = selectedBorderColor;
		_arrowToShip.color = enabledBoardingArrowColor;
		_connectorLine1.color = enabledBoardingArrowColor;
		_connectorLine2.color = enabledBoardingArrowColor;
		_miniIndicatorBorder.color = enabledBoardingArrowColor;
		activeDroneTitleText.color = selectedTitleColor;
		int num = _droneSlots.Length;
		for (int i = 0; i < num; i++)
		{
			if (currentOnly && i != _currentDroneSlot)
			{
				continue;
			}
			if (_droneSlots[i].droneSlotImage != null)
			{
				if (i != _currentDroneSlot)
				{
					if (i < 4)
					{
						_droneSlots[i].borderImage.color = selectedBorderColor;
					}
				}
				else
				{
					_droneSlots[i].borderImage.color = selectedDroneBorderColor;
				}
				if (_droneSlots[i].dronePanel.droneNumber != null)
				{
					_droneSlots[i].dronePanel.droneNumber.color = selectedDroneNumberColor;
				}
			}
			_droneSlots[i].dronePanel.droneName.color = selectedDroneNameColor;
			_droneSlots[i].dronePanel.droneHP.color = selectedDroneHPColor;
		}
	}

	private void LoseFocusOnUpperPanel()
	{
		LoseFocusOnUpperPanel(false);
	}

	private void LoseFocusOnUpperPanel(bool excludeCurrent)
	{
		_upperSectionHasFocus = false;
		panelCautionStripes.color = unSelectedBorderColor;
		panelCautionStripeBorder.color = unSelectedBorderColor;
		borderActiveTitleLarge.color = unSelectedBorderColor;
		borderActiveTitleSmall.color = unSelectedBorderColor;
		_arrowToShip.color = disabledBoardingArrowColor;
		_connectorLine1.color = disabledBoardingArrowColor;
		_connectorLine2.color = disabledBoardingArrowColor;
		_miniIndicatorBorder.color = disabledBoardingArrowColor;
		activeDroneTitleText.color = unSelectedTitleColor;
		int num = _droneSlots.Length;
		for (int i = 0; i < num; i++)
		{
			if (!excludeCurrent || i != _currentDroneSlot)
			{
				if (i < 4 && _droneSlots[i].borderImage != null)
				{
					_droneSlots[i].borderImage.color = unSelectedBorderColor;
				}
				_droneSlots[i].dronePanel.droneName.color = unSelectedDroneNameColor;
				_droneSlots[i].dronePanel.droneHP.color = unSelectedDroneHPColor;
				if (_droneSlots[i].dronePanel.droneNumber != null)
				{
					_droneSlots[i].dronePanel.droneNumber.color = unSelectedDroneNumberColor;
				}
			}
		}
		if (_currentDroneSlot >= 0)
		{
			_droneSlots[_currentDroneSlot].SetCursorHere(false);
			_droneSlots[_currentDroneSlot].SetDownArrow(false);
		}
	}

	private void SetFocusOnLowerPanel()
	{
		LoseFocusOnUpperPanel(true);
		activeDroneInventoryTitleText.color = selectedTitleColor;
		activeDroneLoadoutTitleText.color = selectedTitleColor;
		activeDroneNameText.color = selectedDroneNameColor;
		activeDroneNumberText.color = selectedDroneNumberColor;
		activeDroneImage.material = _droneSlots[_currentDroneSlot].dronePanel.droneImage.material;
		activeBorderInventoryTitleSmall.color = selectedBorderColor;
		activeBorderLayoutTitleSmall.color = selectedBorderColor;
		activeBorderPanelLoadout.color = selectedBorderColor;
		activeDividerLine.color = selectedBorderColor;
		activeDividerImage.color = selectedBorderColor;
		hintBorder.enabled = true;
		hintBorder.color = selectedBorderColor;
	}

	private void LoseFocusOnLowerPanel()
	{
		_hintsLowerUpgradeSwap.gameObject.SetActive(false);
		activeDroneInventoryTitleText.color = unSelectedTitleColor;
		activeDroneLoadoutTitleText.color = unSelectedTitleColor;
		activeDroneNameText.color = unSelectedDroneNameColor;
		activeDroneNumberText.color = unSelectedDroneNumberColor;
		activeBorderInventoryTitleSmall.color = unSelectedBorderColor;
		activeBorderLayoutTitleSmall.color = unSelectedBorderColor;
		activeBorderPanelLoadout.color = unSelectedBorderColor;
		activeDividerLine.color = unSelectedBorderColor;
		activeDividerImage.color = unSelectedBorderColor;
		hintBorder.enabled = false;
		hintText.enabled = false;
		hintBorder.color = unSelectedBorderColor;
	}

	public void SetHintText(string text)
	{
		hintText.enabled = true;
		hintText.text = text;
	}

	public void ClearHintText()
	{
		hintText.enabled = false;
	}
}
