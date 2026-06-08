using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SystemOverlayUI : MonoBehaviour
{
	private const float RATIONS_COLOR_BLINK_TIME = 2f;

	public static SystemOverlayUI Instance;

	public Color DisabledButtonColor = Color.gray;

	public Color EnabledButtonColor = Color.blue;

	public Color DeselectedDroneNumberColor = Color.gray;

	public Color SelectedDroneNumberColor = Color.blue;

	public Color BlinkButtonColor = Color.blue;

	public Color PropertyNormalColor = Color.blue;

	public Color PropertyHighlightedColor = Color.yellow;

	public Color SelectedItemColor = Color.blue;

	public Color SelectedButtonColor = Color.blue;

	public Color MissingTransporterColor = GlobalSettings.Constants.ORANGE;

	public Color HasTransporterColor = Color.green;

	public Color InvalidShipTypeColor = GlobalSettings.Constants.ORANGE;

	public Color ValidShipTypeColor = Color.green;

	public Camera GUICamera;

	public Sprite derelictIcon;

	public Sprite stationIcon;

	public Sprite stargateIcon;

	public Sprite outpostIcon;

	public Sprite tradingIcon;

	public Image previewBG;

	public Image quarantineWarningImage;

	private bool initalized;

	private Text numberScrap;

	private Text fuelNumber;

	private Text fuelLabel;

	private Text jumpNumber;

	private Text jumpLabel;

	private Text titleGalaxy;

	private Text titleView;

	private Text titleCurrentShip;

	private Text titleUniverseName;

	private Text titleSysName;

	private Text titleShipName;

	private Text sysObjectsLabel;

	private Text sysObjectsValue;

	private Text sysVisitedLabel;

	private Text sysVisitedValue;

	private Text universeObjectsLabel;

	private Text universeObjectsValue;

	private Text universeVisitedLabel;

	private Text universeVisitedValue;

	private Text shipDistanceLabel;

	private Text shipDistanceValue;

	private Text shipClassLabel;

	private Text shipClassValue;

	private Text shipAgeLabel;

	private Text shipAgeValue;

	private Text shipInfectionTypeLabel;

	private Text shipInfectionTypeValue;

	private Text shipVisitedLabel;

	private Text shipVisitedValue;

	private Text shipScrapCapacityLabel;

	private Text shipScrapCapacityValue;

	private Text travelBoardButtonValue;

	private GameObject arrow;

	private GameObject emptyDataMsg;

	private GameObject openConstelationMsg;

	private Image buttonObjectives;

	private Image buttonObjectivesBorder;

	private Text buttonObjectivesLabel;

	private Image buttonNotes;

	private Image buttonNotesBorder;

	private Text buttonNotesLabel;

	private Image buttonUniverse;

	private Image buttonUniverseBorder;

	private Text buttonUniverseLabel;

	private Image buttonGalaxy;

	private Image buttonGalaxyBorder;

	private Text buttonGalaxyLabel;

	private Image buttonSystem;

	private Image buttonSystemBorder;

	private Text buttonSystemLabel;

	private Image buttonUpgrades;

	private Image buttonUpgradesBorder;

	private Text buttonUpgradesLabel;

	private Image buttonShipConfig;

	private Image buttonShipConfigBorder;

	private Text buttonShipConfigLabel;

	private Image buttonModifications;

	private Image buttonModificationsIcon;

	private Image buttonModificationsBorder;

	private Text buttonModificationsLabel;

	private Image buttonTravelBoard;

	private Image buttonTravelBoardBorder;

	private Image buttonClose;

	private Image[] shipUpgradeSlotArray;

	private Image[] shipUpgradeItemArray;

	private Image[] droneNumberBorderImageArray;

	private Text[] droneNumberTextImageArray;

	private Image systemIcon;

	private Image dockedIcon;

	private Transform panelTargetTrans;

	private Transform panelTargetSysTrans;

	private Transform panelTargetUniverseTrans;

	private Text outpostWarningMessage;

	private Text shipTypeMessage;

	private bool lastSysJumpStatus;

	private RawImage shipProfileImage;

	private ColorBlinkManager firstBlinkManager;

	private Color colorFirstBoardingButton = Color.white;

	private Color colorFirstReadyButton = Color.white;

	private ColorBlinkManager objectiveBlinkManager;

	private ColorBlinkManager logBlinkManager;

	private ColorBlinkManager modificationsBlinkManager;

	private ColorBlinkManager shipConfigBlinkManager;

	private bool isHighlightingFuel;

	private bool isHighlightingJump;

	private float _propulsionFuelChangedTimer;

	private float _jumpFuelChangedTimer;

	private Blur guiBlurEffect;

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

	private void Awake()
	{
		Instance = this;
		if (!initalized)
		{
			Initalized();
		}
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
		derelictIcon = null;
		stationIcon = null;
		stargateIcon = null;
		outpostIcon = null;
		tradingIcon = null;
		previewBG = null;
		quarantineWarningImage = null;
		numberScrap = null;
		fuelNumber = null;
		fuelLabel = null;
		jumpNumber = null;
		jumpLabel = null;
		titleView = null;
		titleCurrentShip = null;
		titleUniverseName = null;
		titleSysName = null;
		titleShipName = null;
		sysObjectsLabel = null;
		sysObjectsValue = null;
		sysVisitedLabel = null;
		sysVisitedValue = null;
		universeObjectsLabel = null;
		universeObjectsValue = null;
		universeVisitedLabel = null;
		universeVisitedValue = null;
		shipDistanceLabel = null;
		shipDistanceValue = null;
		shipClassLabel = null;
		shipClassValue = null;
		shipAgeLabel = null;
		shipAgeValue = null;
		shipInfectionTypeLabel = null;
		shipInfectionTypeValue = null;
		shipVisitedLabel = null;
		shipVisitedValue = null;
		shipScrapCapacityLabel = null;
		shipScrapCapacityValue = null;
		travelBoardButtonValue = null;
		arrow = null;
		emptyDataMsg = null;
		openConstelationMsg = null;
		buttonObjectives = null;
		buttonObjectivesBorder = null;
		buttonObjectivesLabel = null;
		buttonNotes = null;
		buttonNotesBorder = null;
		buttonNotesLabel = null;
		buttonUniverse = null;
		buttonUniverseBorder = null;
		buttonUniverseLabel = null;
		buttonGalaxy = null;
		buttonGalaxyBorder = null;
		buttonGalaxyLabel = null;
		buttonSystem = null;
		buttonSystemBorder = null;
		buttonSystemLabel = null;
		buttonUpgrades = null;
		buttonUpgradesBorder = null;
		buttonUpgradesLabel = null;
		buttonShipConfig = null;
		buttonShipConfigBorder = null;
		buttonShipConfigLabel = null;
		buttonModifications = null;
		buttonModificationsIcon = null;
		buttonModificationsBorder = null;
		buttonModificationsLabel = null;
		buttonTravelBoard = null;
		buttonTravelBoardBorder = null;
		buttonClose = null;
		if (shipUpgradeSlotArray != null)
		{
			int num = shipUpgradeSlotArray.Length;
			for (int i = 0; i < num; i++)
			{
				shipUpgradeSlotArray[i] = null;
			}
			shipUpgradeSlotArray = null;
		}
		if (shipUpgradeItemArray != null)
		{
			int num2 = shipUpgradeItemArray.Length;
			for (int j = 0; j < num2; j++)
			{
				shipUpgradeItemArray[j] = null;
			}
			shipUpgradeItemArray = null;
		}
		if (droneNumberBorderImageArray != null)
		{
			int num3 = droneNumberBorderImageArray.Length;
			for (int k = 0; k < num3; k++)
			{
				droneNumberBorderImageArray[k] = null;
			}
			droneNumberBorderImageArray = null;
		}
		if (droneNumberTextImageArray != null)
		{
			int num4 = droneNumberTextImageArray.Length;
			for (int l = 0; l < num4; l++)
			{
				droneNumberTextImageArray[l] = null;
			}
			droneNumberTextImageArray = null;
		}
		systemIcon = null;
		dockedIcon = null;
		panelTargetTrans = null;
		panelTargetSysTrans = null;
		panelTargetUniverseTrans = null;
		outpostWarningMessage = null;
		shipTypeMessage = null;
		shipProfileImage = null;
	}

	private void Initalized()
	{
		if (GUICamera != null)
		{
			guiBlurEffect = GUICamera.gameObject.GetComponent<Blur>();
			if (guiBlurEffect != null)
			{
				guiBlurEffect.enabled = false;
			}
		}
		if (previewBG != null)
		{
			previewBG.gameObject.SetActive(false);
			previewBG.enabled = true;
		}
		Transform transform = base.transform.FindChild("panelMap");
		if (transform != null)
		{
			Transform transform2 = transform.FindChild("PanelResources");
			Transform transform3 = transform.FindChild("PanelButtons");
			Transform transform4 = transform.FindChild("PanelSystemInfo");
			Transform transform5 = transform.FindChild("PanelEmpty");
			Transform transform6 = transform.FindChild("PanelOpenConstelationList");
			Transform transform7 = transform.FindChild("HintsPanel");
			if (transform2 != null)
			{
				Transform transform8 = transform2.FindChild("numberScrap");
				if (transform8 != null)
				{
					numberScrap = transform8.gameObject.GetComponent<Text>();
				}
				transform8 = transform2.FindChild("numberFuel");
				if (transform8 != null)
				{
					fuelNumber = transform8.gameObject.GetComponent<Text>();
				}
				transform8 = transform2.FindChild("TextFuel");
				if (transform8 != null)
				{
					fuelLabel = transform8.gameObject.GetComponent<Text>();
				}
				transform8 = transform2.FindChild("numberJumps");
				if (transform8 != null)
				{
					jumpNumber = transform8.gameObject.GetComponent<Text>();
				}
				transform8 = transform2.FindChild("TextJumps");
				if (transform8 != null)
				{
					jumpLabel = transform8.gameObject.GetComponent<Text>();
				}
			}
			if (transform3 != null)
			{
				Transform transform9 = null;
				Transform transform10 = transform3.FindChild("buttonObjectives");
				if (transform10 != null)
				{
					buttonObjectives = transform10.gameObject.GetComponent<Image>();
					transform9 = transform10.FindChild("border");
					if (transform9 != null)
					{
						buttonObjectivesBorder = transform9.gameObject.GetComponent<Image>();
					}
					transform9 = transform10.FindChild("Text");
					if (transform9 != null)
					{
						buttonObjectivesLabel = transform9.gameObject.GetComponent<Text>();
					}
					if (GlobalSettings.gameMode != GameModeEnum.Normal)
					{
						buttonObjectives.gameObject.SetActive(false);
						buttonObjectivesBorder.gameObject.SetActive(false);
						buttonObjectivesLabel.gameObject.SetActive(false);
					}
				}
			}
			if (transform4 != null)
			{
				Transform transform11 = transform4.FindChild("TextSystem");
				if (transform11 != null)
				{
					titleGalaxy = transform11.gameObject.GetComponent<Text>();
				}
				transform11 = transform4.FindChild("numberObjects");
			}
			if (transform5 != null)
			{
				emptyDataMsg = transform5.gameObject;
				emptyDataMsg.SetActive(false);
			}
			if (transform6 != null)
			{
				openConstelationMsg = transform6.gameObject;
				openConstelationMsg.SetActive(false);
			}
			if (transform7 != null)
			{
				HintManager.HintPanelGameObject = transform7.gameObject;
				HintManager.HintPanelGameObject.SetActive(false);
				if (HintManager.HintPanelGameObject != null)
				{
					HintManager.OnScreenPosition = HintManager.HintPanelGameObject.transform.position + new Vector3(-270f, 0f, 0f);
					HintManager.OffScreenPosition = new Vector3(HintManager.OnScreenPosition.x + 600f, HintManager.OnScreenPosition.y);
					Transform transform12 = HintManager.HintPanelGameObject.transform.Find("HintText");
					if (transform12 != null)
					{
						HintManager.HintText = transform12.gameObject.GetComponent<Text>();
					}
					transform12 = HintManager.HintPanelGameObject.transform.Find("BorderImage");
					if (transform12 != null)
					{
						HintManager.HintBorder = transform12.gameObject.GetComponent<Image>();
						HintManager.defaultRingColor = HintManager.HintBorder.color;
					}
				}
			}
		}
		Transform transform13 = base.transform.FindChild("PanelTopMask");
		if (transform13 != null)
		{
			Transform transform14 = transform13.FindChild("PanelTopBarLeft");
			Transform transform15 = transform13.FindChild("PanelTopBarRight");
			if (transform14 != null)
			{
				Transform transform16 = transform14.FindChild("PanelButtonHolder");
				Transform transform17 = transform14.FindChild("PanelCurrentLocation");
				if (transform16 != null)
				{
					Transform transform18 = transform16.FindChild("PanelButtons");
					if (transform18 != null)
					{
						Transform transform19 = transform18.FindChild("buttonUniverse");
						if (transform19 != null)
						{
							buttonUniverse = transform19.GetComponent<Image>();
							Transform transform20 = transform19.FindChild("border");
							if (transform20 != null)
							{
								buttonUniverseBorder = transform20.gameObject.GetComponent<Image>();
							}
							transform20 = transform19.FindChild("Text");
							if (transform20 != null)
							{
								buttonUniverseLabel = transform20.gameObject.GetComponent<Text>();
							}
						}
						transform19 = transform18.FindChild("buttonGalaxy");
						if (transform19 != null)
						{
							buttonGalaxy = transform19.GetComponent<Image>();
							Transform transform21 = transform19.FindChild("border");
							if (transform21 != null)
							{
								buttonGalaxyBorder = transform21.gameObject.GetComponent<Image>();
							}
							transform21 = transform19.FindChild("Text");
							if (transform21 != null)
							{
								buttonGalaxyLabel = transform21.gameObject.GetComponent<Text>();
							}
						}
						transform19 = transform18.FindChild("buttonSystem");
						if (transform19 != null)
						{
							buttonSystem = transform19.GetComponent<Image>();
							Transform transform22 = transform19.FindChild("border");
							if (transform22 != null)
							{
								buttonSystemBorder = transform22.gameObject.GetComponent<Image>();
							}
							transform22 = transform19.FindChild("Text");
							if (transform22 != null)
							{
								buttonSystemLabel = transform22.gameObject.GetComponent<Text>();
							}
						}
					}
				}
				if (transform17 != null)
				{
					Transform transform23 = transform17.FindChild("name");
					if (transform23 != null)
					{
						titleView = transform23.gameObject.GetComponent<Text>();
					}
				}
			}
			if (transform15 != null)
			{
				Transform transform24 = transform15.FindChild("buttonModifications");
				Transform transform25 = null;
				if (transform24 != null)
				{
					buttonModifications = transform24.GetComponent<Image>();
					transform25 = transform24.FindChild("icon");
					if (transform25 != null)
					{
						buttonModificationsIcon = transform25.GetComponent<Image>();
					}
					transform25 = transform24.FindChild("border");
					if (transform25 != null)
					{
						buttonModificationsBorder = transform25.GetComponent<Image>();
					}
					transform25 = transform24.FindChild("Text");
					if (transform25 != null)
					{
						buttonModificationsLabel = transform25.GetComponent<Text>();
					}
				}
				transform24 = transform15.FindChild("buttonShipconfig");
				if (transform24 != null)
				{
					buttonShipConfig = transform24.GetComponent<Image>();
					transform25 = transform24.FindChild("border");
					if (transform25 != null)
					{
						buttonShipConfigBorder = transform25.GetComponent<Image>();
					}
					transform25 = transform24.FindChild("Text");
					if (transform25 != null)
					{
						buttonShipConfigLabel = transform25.GetComponent<Text>();
					}
				}
				transform24 = transform15.FindChild("buttonUpgrades");
				if (transform24 != null)
				{
					buttonUpgrades = transform24.GetComponent<Image>();
					transform25 = transform24.FindChild("border");
					if (transform25 != null)
					{
						buttonUpgradesBorder = transform25.GetComponent<Image>();
					}
					transform25 = transform24.FindChild("Text");
					if (transform25 != null)
					{
						buttonUpgradesLabel = transform25.GetComponent<Text>();
					}
				}
			}
		}
		Transform transform26 = base.transform.FindChild("PanelRightMask");
		if (transform26 != null)
		{
			Transform transform27 = transform26.FindChild("PanelYourShip");
			panelTargetTrans = transform26.FindChild("PanelTargetInfo");
			panelTargetSysTrans = transform26.FindChild("PanelTargetSystemInfo");
			panelTargetUniverseTrans = transform26.FindChild("PanelTargetUniverseInfo");
			Transform transform28 = transform26.FindChild("PanelButtons");
			if (transform27 != null)
			{
				Transform transform29 = transform27.FindChild("TextName");
				if (transform29 != null)
				{
					titleCurrentShip = transform29.gameObject.GetComponent<Text>();
				}
				Transform transform30 = transform27.FindChild("PanelUpgradeSlots");
				if (transform30 != null)
				{
					shipUpgradeSlotArray = new Image[6];
					transform29 = transform30.FindChild("Image1");
					if (transform29 != null)
					{
						shipUpgradeSlotArray[0] = transform29.gameObject.GetComponent<Image>();
					}
					transform29 = transform30.FindChild("Image2");
					if (transform29 != null)
					{
						shipUpgradeSlotArray[1] = transform29.gameObject.GetComponent<Image>();
					}
					transform29 = transform30.FindChild("Image3");
					if (transform29 != null)
					{
						shipUpgradeSlotArray[2] = transform29.gameObject.GetComponent<Image>();
					}
					transform29 = transform30.FindChild("Image4");
					if (transform29 != null)
					{
						shipUpgradeSlotArray[3] = transform29.gameObject.GetComponent<Image>();
					}
					transform29 = transform30.FindChild("Image5");
					if (transform29 != null)
					{
						shipUpgradeSlotArray[4] = transform29.gameObject.GetComponent<Image>();
					}
					transform29 = transform30.FindChild("Image6");
					if (transform29 != null)
					{
						shipUpgradeSlotArray[5] = transform29.gameObject.GetComponent<Image>();
					}
				}
				Transform transform31 = transform27.FindChild("PanelUpgradeInstalled");
				if (transform31 != null)
				{
					shipUpgradeItemArray = new Image[6];
					transform29 = transform31.FindChild("Image1");
					if (transform29 != null)
					{
						shipUpgradeItemArray[0] = transform29.gameObject.GetComponent<Image>();
					}
					transform29 = transform31.FindChild("Image2");
					if (transform29 != null)
					{
						shipUpgradeItemArray[1] = transform29.gameObject.GetComponent<Image>();
					}
					transform29 = transform31.FindChild("Image3");
					if (transform29 != null)
					{
						shipUpgradeItemArray[2] = transform29.gameObject.GetComponent<Image>();
					}
					transform29 = transform31.FindChild("Image4");
					if (transform29 != null)
					{
						shipUpgradeItemArray[3] = transform29.gameObject.GetComponent<Image>();
					}
					transform29 = transform31.FindChild("Image5");
					if (transform29 != null)
					{
						shipUpgradeItemArray[4] = transform29.gameObject.GetComponent<Image>();
					}
					transform29 = transform31.FindChild("Image6");
					if (transform29 != null)
					{
						shipUpgradeItemArray[5] = transform29.gameObject.GetComponent<Image>();
					}
				}
				droneNumberBorderImageArray = new Image[7];
				droneNumberTextImageArray = new Text[7];
				Transform transform32 = transform27.FindChild("PanelWithStripes");
				if (transform32 != null)
				{
					Transform transform33 = transform32.FindChild("drones");
					if (transform33 != null)
					{
						Transform transform34 = transform33.FindChild("droneNumberFrame1");
						if (transform34 != null)
						{
							transform29 = transform34.FindChild("Image");
							if (transform29 != null)
							{
								droneNumberBorderImageArray[0] = transform29.gameObject.GetComponent<Image>();
							}
							transform29 = transform34.FindChild("droneNumber");
							if (transform29 != null)
							{
								droneNumberTextImageArray[0] = transform29.gameObject.GetComponent<Text>();
							}
						}
						transform34 = transform33.FindChild("droneNumberFrame2");
						if (transform34 != null)
						{
							transform29 = transform34.FindChild("Image");
							if (transform29 != null)
							{
								droneNumberBorderImageArray[1] = transform29.gameObject.GetComponent<Image>();
							}
							transform29 = transform34.FindChild("droneNumber");
							if (transform29 != null)
							{
								droneNumberTextImageArray[1] = transform29.gameObject.GetComponent<Text>();
							}
						}
						transform34 = transform33.FindChild("droneNumberFrame3");
						if (transform34 != null)
						{
							transform29 = transform34.FindChild("Image");
							if (transform29 != null)
							{
								droneNumberBorderImageArray[2] = transform29.gameObject.GetComponent<Image>();
							}
							transform29 = transform34.FindChild("droneNumber");
							if (transform29 != null)
							{
								droneNumberTextImageArray[2] = transform29.gameObject.GetComponent<Text>();
							}
						}
						transform34 = transform33.FindChild("droneNumberFrame4");
						if (transform34 != null)
						{
							transform29 = transform34.FindChild("Image");
							if (transform29 != null)
							{
								droneNumberBorderImageArray[3] = transform29.gameObject.GetComponent<Image>();
							}
							transform29 = transform34.FindChild("droneNumber");
							if (transform29 != null)
							{
								droneNumberTextImageArray[3] = transform29.gameObject.GetComponent<Text>();
							}
						}
					}
				}
				Transform transform35 = transform27.FindChild("drones");
				if (transform35 != null)
				{
					Transform transform36 = transform35.FindChild("droneNumberFrame1");
					if (transform36 != null)
					{
						transform29 = transform36.FindChild("Image");
						if (transform29 != null)
						{
							droneNumberBorderImageArray[4] = transform29.gameObject.GetComponent<Image>();
						}
						transform29 = transform36.FindChild("droneNumber");
						if (transform29 != null)
						{
							droneNumberTextImageArray[4] = transform29.gameObject.GetComponent<Text>();
						}
					}
					transform36 = transform35.FindChild("droneNumberFrame2");
					if (transform36 != null)
					{
						transform29 = transform36.FindChild("Image");
						if (transform29 != null)
						{
							droneNumberBorderImageArray[5] = transform29.gameObject.GetComponent<Image>();
						}
						transform29 = transform36.FindChild("droneNumber");
						if (transform29 != null)
						{
							droneNumberTextImageArray[5] = transform29.gameObject.GetComponent<Text>();
						}
					}
					transform36 = transform35.FindChild("droneNumberFrame3");
					if (transform36 != null)
					{
						transform29 = transform36.FindChild("Image");
						if (transform29 != null)
						{
							droneNumberBorderImageArray[6] = transform29.gameObject.GetComponent<Image>();
						}
						transform29 = transform36.FindChild("droneNumber");
						if (transform29 != null)
						{
							droneNumberTextImageArray[6] = transform29.gameObject.GetComponent<Text>();
						}
					}
				}
			}
			if (panelTargetTrans != null)
			{
				Transform transform37 = panelTargetTrans.FindChild("TextName");
				if (transform37 != null)
				{
					titleShipName = transform37.gameObject.GetComponent<Text>();
				}
				transform37 = panelTargetTrans.FindChild("selectedIcon");
				if (transform37 != null)
				{
					dockedIcon = transform37.gameObject.GetComponent<Image>();
				}
				Transform transform38 = panelTargetTrans.FindChild("infoTitlesPanel");
				Transform transform39 = panelTargetTrans.FindChild("infoTitlesValuesPanel");
				if (transform38 != null)
				{
					transform37 = transform38.FindChild("DistLabelText");
					if (transform37 != null)
					{
						shipDistanceLabel = transform37.gameObject.GetComponent<Text>();
					}
					transform37 = transform38.FindChild("ClassLabelText");
					if (transform37 != null)
					{
						shipClassLabel = transform37.gameObject.GetComponent<Text>();
					}
					transform37 = transform38.FindChild("AgeLabelText");
					if (transform37 != null)
					{
						shipAgeLabel = transform37.gameObject.GetComponent<Text>();
					}
					transform37 = transform38.FindChild("ITLabelText");
					if (transform37 != null)
					{
						shipInfectionTypeLabel = transform37.gameObject.GetComponent<Text>();
					}
					transform37 = transform38.FindChild("VisitedLabelText");
					if (transform37 != null)
					{
						shipVisitedLabel = transform37.gameObject.GetComponent<Text>();
					}
					transform37 = transform38.FindChild("ScrapCapacityLabelText");
					if (transform37 != null)
					{
						shipScrapCapacityLabel = transform37.gameObject.GetComponent<Text>();
					}
				}
				if (transform39 != null)
				{
					transform37 = transform39.FindChild("DistValueText");
					if (transform37 != null)
					{
						shipDistanceValue = transform37.gameObject.GetComponent<Text>();
					}
					transform37 = transform39.FindChild("ClassValueText");
					if (transform37 != null)
					{
						shipClassValue = transform37.gameObject.GetComponent<Text>();
					}
					transform37 = transform39.FindChild("AgeValueText");
					if (transform37 != null)
					{
						shipAgeValue = transform37.gameObject.GetComponent<Text>();
					}
					transform37 = transform39.FindChild("ITValueText");
					if (transform37 != null)
					{
						shipInfectionTypeValue = transform37.gameObject.GetComponent<Text>();
					}
					transform37 = transform39.FindChild("VisitedValueText");
					if (transform37 != null)
					{
						shipVisitedValue = transform37.gameObject.GetComponent<Text>();
					}
					transform37 = transform39.FindChild("ScrapCapacityValueText");
					if (transform37 != null)
					{
						shipScrapCapacityValue = transform37.gameObject.GetComponent<Text>();
					}
				}
				transform37 = panelTargetTrans.FindChild("OutpostWarningText");
				if (transform37 != null)
				{
					outpostWarningMessage = transform37.gameObject.GetComponent<Text>();
					outpostWarningMessage.enabled = false;
				}
				transform37 = panelTargetTrans.FindChild("ShipTypeWarningText");
				if (transform37 != null)
				{
					shipTypeMessage = transform37.gameObject.GetComponent<Text>();
					shipTypeMessage.enabled = false;
				}
				transform37 = panelTargetTrans.FindChild("shipProfile");
				if (transform37 != null)
				{
					shipProfileImage = transform37.GetComponent<RawImage>();
				}
			}
			if (panelTargetSysTrans != null)
			{
				Transform transform40 = panelTargetSysTrans.FindChild("TextName");
				if (transform40 != null)
				{
					titleSysName = transform40.gameObject.GetComponent<Text>();
				}
				transform40 = panelTargetSysTrans.FindChild("selectedIcon");
				if (transform40 != null)
				{
					systemIcon = transform40.gameObject.GetComponent<Image>();
				}
				Transform transform41 = panelTargetSysTrans.FindChild("infoTitlesPanel");
				Transform transform42 = panelTargetSysTrans.FindChild("infoTitlesValuesPanel");
				if (transform41 != null)
				{
					transform40 = transform41.FindChild("ObjectsLabelText");
					if (transform40 != null)
					{
						sysObjectsLabel = transform40.gameObject.GetComponent<Text>();
					}
					transform40 = transform41.FindChild("VisitedLabelText");
					if (transform40 != null)
					{
						sysVisitedLabel = transform40.gameObject.GetComponent<Text>();
					}
				}
				if (transform42 != null)
				{
					transform40 = transform42.FindChild("ObjectsValueText");
					if (transform40 != null)
					{
						sysObjectsValue = transform40.gameObject.GetComponent<Text>();
					}
					transform40 = transform42.FindChild("VisitedValueText");
					if (transform40 != null)
					{
						sysVisitedValue = transform40.gameObject.GetComponent<Text>();
					}
				}
			}
			if (panelTargetUniverseTrans != null)
			{
				Transform transform43 = panelTargetUniverseTrans.FindChild("TextName");
				if (transform43 != null)
				{
					titleUniverseName = transform43.gameObject.GetComponent<Text>();
				}
				Transform transform44 = panelTargetUniverseTrans.FindChild("infoTitlesValuesPanel");
				if (transform43 != null)
				{
					transform43 = transform44.FindChild("ObjectsValueText");
					if (transform43 != null)
					{
						universeObjectsValue = transform43.gameObject.GetComponent<Text>();
					}
					transform43 = transform44.FindChild("VisitedValueText");
					if (transform43 != null)
					{
						universeVisitedValue = transform43.gameObject.GetComponent<Text>();
					}
				}
			}
			if (transform28 != null)
			{
				Transform transform45 = transform28.FindChild("buttonTravelBoard");
				Transform transform46 = null;
				if (transform45 != null)
				{
					buttonTravelBoard = transform45.gameObject.GetComponent<Image>();
					transform46 = transform45.FindChild("border");
					if (transform46 != null)
					{
						buttonTravelBoardBorder = transform46.gameObject.GetComponent<Image>();
					}
					transform46 = transform45.FindChild("Text");
					if (transform46 != null)
					{
						travelBoardButtonValue = transform46.gameObject.GetComponent<Text>();
					}
				}
				transform45 = transform28.FindChild("buttonClose");
				if (transform45 != null)
				{
					buttonClose = transform45.gameObject.GetComponent<Image>();
					buttonClose.gameObject.SetActive(false);
				}
				transform46 = transform28.FindChild("arrow");
				if (transform46 != null)
				{
					arrow = transform46.gameObject;
				}
			}
		}
		if (quarantineWarningImage != null)
		{
			quarantineWarningImage.gameObject.SetActive(false);
		}
	}

	private void Update()
	{
		if (DialogUI.Instance.IsShowing || GlobalSettings.IsGamePaused || GalaxyMapManager.Instance.isHidingAll || GalaxyMapManager.Instance.showingFullScreenUi || Manual.IsVisible)
		{
			return;
		}
		HintManager.Update();
		if (firstBlinkManager != null && firstBlinkManager.IsActive)
		{
			Color color = firstBlinkManager.Update(Time.deltaTime);
			buttonTravelBoard.color = color;
		}
		if (objectiveBlinkManager != null && objectiveBlinkManager.IsActive)
		{
			Color color2 = objectiveBlinkManager.Update(Time.deltaTime);
			if (!objectiveBlinkManager.IsActive)
			{
				objectiveBlinkManager = null;
			}
			else
			{
				buttonObjectives.color = color2;
			}
		}
		if (logBlinkManager != null && logBlinkManager.IsActive)
		{
			Color color3 = logBlinkManager.Update(Time.deltaTime);
			if (!logBlinkManager.IsActive)
			{
				logBlinkManager = null;
			}
		}
		if (modificationsBlinkManager != null && modificationsBlinkManager.IsActive)
		{
			Color color4 = modificationsBlinkManager.Update(Time.deltaTime);
			if (!modificationsBlinkManager.IsActive)
			{
				modificationsBlinkManager = null;
			}
			else
			{
				buttonModifications.color = color4;
			}
		}
		if (shipConfigBlinkManager != null && shipConfigBlinkManager.IsActive)
		{
			Color color5 = shipConfigBlinkManager.Update(Time.deltaTime);
			if (!shipConfigBlinkManager.IsActive)
			{
				shipConfigBlinkManager = null;
			}
			else
			{
				buttonShipConfig.color = color5;
			}
		}
		if (isHighlightingFuel)
		{
			if (_propulsionFuelChangedTimer > 0f)
			{
				_propulsionFuelChangedTimer -= Time.deltaTime;
			}
			else
			{
				fuelNumber.color = PropertyNormalColor;
				fuelLabel.color = PropertyNormalColor;
				isHighlightingFuel = false;
			}
		}
		if (isHighlightingJump)
		{
			if (_jumpFuelChangedTimer > 0f)
			{
				_jumpFuelChangedTimer -= Time.deltaTime;
				return;
			}
			jumpNumber.color = PropertyNormalColor;
			jumpLabel.color = PropertyNormalColor;
			isHighlightingJump = false;
		}
	}

	public void EnableCameraBlur()
	{
		if (guiBlurEffect != null)
		{
			guiBlurEffect.enabled = true;
		}
	}

	public void DisableCameraBlur()
	{
		if (guiBlurEffect != null)
		{
			guiBlurEffect.enabled = false;
		}
	}

	public void BeginBlinkJumpFuelChange()
	{
		_jumpFuelChangedTimer = 2f;
		jumpNumber.color = PropertyHighlightedColor;
		jumpLabel.color = PropertyHighlightedColor;
		isHighlightingJump = true;
	}

	public void BeginBlinkPropulsionFuelChange()
	{
		_propulsionFuelChangedTimer = 2f;
		fuelNumber.color = PropertyHighlightedColor;
		fuelLabel.color = PropertyHighlightedColor;
		isHighlightingFuel = true;
	}

	public void EndBlinkBoardOrReadyButton()
	{
		if (firstBlinkManager != null && firstBlinkManager.IsActive)
		{
			if (!GameSaveFile.Get("FIRST_READY", false))
			{
				GameSaveFile.Save("FIRST_READY", true);
			}
			if (!GameSaveFile.Get("FIRST_BOARD", false))
			{
				GameSaveFile.Save("FIRST_BOARD", true);
			}
			buttonTravelBoard.color = Color.black;
			firstBlinkManager = null;
		}
	}

	public void BeginBlinkBoardButton()
	{
		firstBlinkManager = new ColorBlinkManager();
		firstBlinkManager.Start(Color.black, BlinkButtonColor, 0.35f, false);
	}

	public void BeginBlinkObjectiveButton()
	{
		objectiveBlinkManager = new ColorBlinkManager();
		objectiveBlinkManager.Start(Color.black, BlinkButtonColor, 0.35f, false);
	}

	public void EndBlinkObjectiveButton()
	{
		objectiveBlinkManager = null;
		buttonObjectives.color = Color.black;
	}

	public void BeginBlinkLogButton()
	{
		logBlinkManager = new ColorBlinkManager();
		logBlinkManager.Start(Color.black, BlinkButtonColor, 0.35f, false);
	}

	public void EndBlinkLogButton()
	{
		logBlinkManager = null;
	}

	public void BeginBlinkModificationButton()
	{
		modificationsBlinkManager = new ColorBlinkManager();
		modificationsBlinkManager.Start(Color.black, BlinkButtonColor, 0.35f, false);
	}

	public void EndBlinkModificationButton()
	{
		modificationsBlinkManager = null;
		buttonModifications.color = Color.black;
	}

	public void BeginBlinkShipConfigButton()
	{
		shipConfigBlinkManager = new ColorBlinkManager();
		shipConfigBlinkManager.Start(Color.black, BlinkButtonColor, 0.35f, false);
	}

	public void EndBlinkShipConfigButton()
	{
		shipConfigBlinkManager = null;
		buttonShipConfig.color = Color.black;
	}

	public void RefreshUniverseInfo()
	{
		if (UniverseMapManager.HasData)
		{
			emptyDataMsg.SetActive(false);
			if (UniverseMapManager.Instance.CurrentConstelation == null && !UniverseMapManager.Instance.isShowingConstellationSelectionPanel && UniverseMapManager.Instance.CountConstelation > 0)
			{
				openConstelationMsg.SetActive(true);
			}
			else
			{
				openConstelationMsg.SetActive(false);
			}
		}
		else
		{
			emptyDataMsg.SetActive(true);
			openConstelationMsg.SetActive(false);
		}
		titleGalaxy.enabled = false;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		foreach (StarSystemInfo starSystem in GlobalSettings.GameState.StarSystems)
		{
			if (starSystem.galaxyNode.IsScanned)
			{
				num3++;
			}
		}
		List<string> allGroups = GalaxySaveFile.GetAllGroups("SYS_", "VIEWED", true);
		universeObjectsValue.text = num3.ToString();
		universeVisitedValue.text = allGroups.Count.ToString();
	}

	public void RefreshUniverseNode(UniverseNode node)
	{
		titleGalaxy.enabled = false;
		titleUniverseName.text = node.name;
	}

	public void RefreshGalaxyInfo()
	{
	}

	public void RefreshSelectedSystem(StarSystemInfo system)
	{
		systemIcon.color = Color.white;
		if (GlobalSettings.GameState.ThePlayer.CurrentStarSystem != null)
		{
			titleGalaxy.text = GalaxyProcessor.universeMapManager.CurrentUniverseNode.name;
			titleSysName.text = system.Name;
		}
		if (!GalaxySaveFile.Get<bool>(system.GroupKey, "VISITED"))
		{
			if (system.galaxyNode.inRange)
			{
				systemIcon.color = system.galaxyNode.InRangeColor;
			}
			else
			{
				systemIcon.color = system.galaxyNode.TooFarRangeColor;
			}
		}
		else
		{
			systemIcon.color = system.galaxyNode.VisitedColor;
		}
	}

	public void RefreshSelectedDungeon(DungeonInfo dungeon)
	{
		RefreshSelectedDungeon(dungeon, GalaxyMapManager.Instance.GetNodeFromDungeonInfo(dungeon));
	}

	public void RefreshSelectedDungeon(DungeonInfo dungeon, DungeonNode node)
	{
		dockedIcon.color = Color.white;
		outpostWarningMessage.enabled = false;
		shipTypeMessage.enabled = false;
		quarantineWarningImage.gameObject.SetActive(false);
		if (!dungeon.HaveVisited)
		{
			if (node.inRange)
			{
				dockedIcon.color = node.InRangeColor;
			}
			else
			{
				dockedIcon.color = node.TooFarRangeColor;
			}
			if (dungeon.DungeonType == DungeonTypeEnum.Outpost)
			{
				outpostWarningMessage.enabled = true;
				outpostWarningMessage.text = "Outpost - Requires Transporter";
				if (GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy.FirstOrDefault((IInventoryItem x) => x != null && x is TransporterShipUpgrade) == null)
				{
					outpostWarningMessage.color = MissingTransporterColor;
				}
				else
				{
					outpostWarningMessage.color = HasTransporterColor;
				}
				if (dungeon.Definition.Key.allowedShipTypes != "all")
				{
					shipTypeMessage.enabled = true;
					if (!dungeon.Definition.Key.allowedShipTypes.Contains(GlobalSettings.GameState.ThePlayer.MyShip.Definition.Key.name.ToLower()))
					{
						shipTypeMessage.color = MissingTransporterColor;
					}
					else
					{
						shipTypeMessage.color = HasTransporterColor;
					}
					TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
					shipTypeMessage.text = string.Format("{0} clearance required", textInfo.ToTitleCase(dungeon.Definition.Key.allowedShipTypes));
				}
			}
			if (dungeon.IsQuarentined)
			{
				quarantineWarningImage.gameObject.SetActive(true);
			}
		}
		else
		{
			dockedIcon.color = node.VisitedColor;
		}
	}

	public void RefreshPlayerShipInfo()
	{
		titleCurrentShip.text = GlobalSettings.GameState.ThePlayer.MyShip.Name;
		Image[] array = shipUpgradeItemArray;
		foreach (Image image in array)
		{
			image.enabled = false;
		}
		Image[] array2 = shipUpgradeSlotArray;
		foreach (Image image2 in array2)
		{
			image2.enabled = false;
		}
		int inventoryCount = GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.InventoryCount;
		int num = 0;
		for (int k = 0; k < inventoryCount; k++)
		{
			if (GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy[k] != null && num < shipUpgradeItemArray.Length)
			{
				shipUpgradeItemArray[num++].enabled = true;
			}
		}
		inventoryCount = GlobalSettings.GameState.ThePlayer.MyShip.ShipUpgradeSlots;
		for (int l = 0; l < inventoryCount; l++)
		{
			shipUpgradeSlotArray[l].enabled = true;
		}
	}

	public void RefreshDroneInfo()
	{
		Text[] array = droneNumberTextImageArray;
		foreach (Text text in array)
		{
			text.color = DeselectedDroneNumberColor;
		}
		foreach (IDrone drone in GlobalSettings.GameState.ThePlayer.Drones)
		{
			if (drone.DroneNumber > 0 && drone.DroneNumber <= droneNumberTextImageArray.Length)
			{
				droneNumberTextImageArray[drone.DroneNumber - 1].color = SelectedDroneNumberColor;
			}
		}
	}

	public void SwitchToUniverseInTravelMode()
	{
		SwitchToUniverse();
		emptyDataMsg.SetActive(false);
		openConstelationMsg.SetActive(false);
		buttonTravelBoardBorder.gameObject.SetActive(true);
		travelBoardButtonValue.gameObject.SetActive(true);
		travelBoardButtonValue.text = "[T]ravel";
		buttonClose.gameObject.SetActive(true);
		buttonTravelBoardBorder.color = EnabledButtonColor;
		travelBoardButtonValue.color = EnabledButtonColor;
		SetStargateTravelAbility(false);
		if (firstBlinkManager != null)
		{
			buttonTravelBoard.color = Color.black;
			firstBlinkManager.Stop();
		}
	}

	public void SwitchToUniverse()
	{
		buttonUniverse.color = SelectedButtonColor;
		buttonGalaxy.color = Color.black;
		buttonSystem.color = Color.black;
		travelBoardButtonValue.text = "[V]iew";
		buttonClose.gameObject.SetActive(true);
		buttonTravelBoardBorder.color = DisabledButtonColor;
		travelBoardButtonValue.color = DisabledButtonColor;
		HideSideButtons();
		SetConstelationStatus(false);
		panelTargetUniverseTrans.gameObject.SetActive(true);
		panelTargetSysTrans.gameObject.SetActive(false);
		panelTargetTrans.gameObject.SetActive(false);
		buttonClose.gameObject.SetActive(false);
		if (firstBlinkManager != null)
		{
			buttonTravelBoard.color = Color.black;
			firstBlinkManager.Stop();
		}
		RefreshUniverseInfo();
		if (UniverseMapManager.Instance.IsReadOnlyGalaxy)
		{
			previewBG.gameObject.SetActive(true);
		}
		else
		{
			previewBG.gameObject.SetActive(false);
		}
	}

	public void SwitchToGalaxy()
	{
		buttonUniverse.color = Color.black;
		buttonGalaxy.color = SelectedButtonColor;
		buttonSystem.color = Color.black;
		if (!UniverseMapManager.Instance.IsReadOnlyGalaxy)
		{
			travelBoardButtonValue.text = "[J]ump";
			travelBoardButtonValue.color = DisabledButtonColor;
			buttonTravelBoardBorder.color = DisabledButtonColor;
		}
		else
		{
			travelBoardButtonValue.text = "[R]eturn";
			travelBoardButtonValue.color = EnabledButtonColor;
			buttonTravelBoardBorder.color = EnabledButtonColor;
		}
		if (!travelBoardButtonValue.gameObject.activeSelf)
		{
			travelBoardButtonValue.gameObject.SetActive(true);
			buttonTravelBoardBorder.gameObject.SetActive(true);
		}
		ShowSideButtons();
		if (panelTargetUniverseTrans.gameObject.activeSelf)
		{
			panelTargetUniverseTrans.gameObject.SetActive(false);
		}
		if (!panelTargetSysTrans.gameObject.activeSelf)
		{
			panelTargetSysTrans.gameObject.SetActive(true);
		}
		if (panelTargetTrans.gameObject.activeSelf)
		{
			panelTargetTrans.gameObject.SetActive(false);
		}
		if (!arrow.gameObject.activeSelf)
		{
			arrow.gameObject.SetActive(true);
		}
		if (buttonClose.gameObject.activeSelf)
		{
			buttonClose.gameObject.SetActive(false);
		}
		if (firstBlinkManager != null)
		{
			buttonTravelBoard.color = Color.black;
			firstBlinkManager.Stop();
		}
		if (emptyDataMsg.gameObject.activeSelf)
		{
			emptyDataMsg.SetActive(false);
		}
		if (openConstelationMsg.gameObject.activeSelf)
		{
			openConstelationMsg.SetActive(false);
		}
		if (UniverseMapManager.Instance.IsReadOnlyGalaxy)
		{
			if (!previewBG.gameObject.activeSelf)
			{
				previewBG.gameObject.SetActive(true);
			}
		}
		else if (previewBG.gameObject.activeSelf)
		{
			previewBG.gameObject.SetActive(false);
		}
	}

	public void SwitchToSystem(bool isViewOnly, bool isStargate)
	{
		lastSysJumpStatus = false;
		buttonUniverse.color = Color.black;
		buttonGalaxy.color = Color.black;
		buttonSystem.color = SelectedButtonColor;
		if (!isViewOnly)
		{
			if (!isStargate)
			{
				travelBoardButtonValue.text = "[B]oard";
			}
			else
			{
				travelBoardButtonValue.text = "[J]ump";
			}
			travelBoardButtonValue.color = EnabledButtonColor;
			buttonTravelBoardBorder.color = EnabledButtonColor;
			if (!travelBoardButtonValue.gameObject.activeSelf)
			{
				if (!travelBoardButtonValue.gameObject.activeSelf)
				{
					travelBoardButtonValue.gameObject.SetActive(true);
				}
				if (!buttonTravelBoardBorder.gameObject.activeSelf)
				{
					buttonTravelBoardBorder.gameObject.SetActive(true);
				}
			}
		}
		else if (!UniverseMapManager.Instance.IsReadOnlyGalaxy)
		{
			if (travelBoardButtonValue.gameObject.activeSelf)
			{
				travelBoardButtonValue.gameObject.SetActive(false);
			}
			if (buttonTravelBoardBorder.gameObject.activeSelf)
			{
				buttonTravelBoardBorder.gameObject.SetActive(false);
			}
		}
		else
		{
			travelBoardButtonValue.text = "[R]eturn";
			travelBoardButtonValue.color = EnabledButtonColor;
			buttonTravelBoardBorder.color = EnabledButtonColor;
			if (!travelBoardButtonValue.gameObject.activeSelf)
			{
				travelBoardButtonValue.gameObject.SetActive(true);
			}
			if (!buttonTravelBoardBorder.gameObject.activeSelf)
			{
				buttonTravelBoardBorder.gameObject.SetActive(true);
			}
		}
		ShowSideButtons();
		if (buttonNotes != null && buttonNotes.gameObject.activeSelf)
		{
			buttonNotes.gameObject.SetActive(false);
		}
		if (panelTargetUniverseTrans.gameObject.activeSelf)
		{
			panelTargetUniverseTrans.gameObject.SetActive(false);
		}
		if (panelTargetSysTrans.gameObject.activeSelf)
		{
			panelTargetSysTrans.gameObject.SetActive(false);
		}
		if (!panelTargetTrans.gameObject.activeSelf)
		{
			panelTargetTrans.gameObject.SetActive(true);
		}
		if (!arrow.gameObject.activeSelf)
		{
			arrow.gameObject.SetActive(true);
		}
		if (buttonClose.gameObject.activeSelf)
		{
			buttonClose.gameObject.SetActive(false);
		}
		if (firstBlinkManager != null && !GalaxyMapManager.Instance.isViewOnlyStarSystemView)
		{
			firstBlinkManager.Start(Color.black, BlinkButtonColor, 0.35f, false);
		}
		if (emptyDataMsg.activeSelf)
		{
			emptyDataMsg.SetActive(false);
		}
		if (openConstelationMsg.activeSelf)
		{
			openConstelationMsg.SetActive(false);
		}
		if (UniverseMapManager.Instance.IsReadOnlyGalaxy || isViewOnly)
		{
			if (!previewBG.gameObject.activeSelf)
			{
				previewBG.gameObject.SetActive(true);
			}
		}
		else if (previewBG.gameObject.activeSelf)
		{
			previewBG.gameObject.SetActive(false);
		}
	}

	public void SetConstelationStatus(bool hasConstelation)
	{
	}

	public void SetStargateTravelAbility(bool canTravel)
	{
		if (canTravel)
		{
			buttonTravelBoardBorder.color = EnabledButtonColor;
			travelBoardButtonValue.color = EnabledButtonColor;
		}
		else
		{
			buttonTravelBoardBorder.color = DisabledButtonColor;
			travelBoardButtonValue.color = DisabledButtonColor;
		}
	}

	public void SetCurrentSystemJumpAbility(bool canJump)
	{
		if (canJump || UniverseMapManager.Instance.IsReadOnlyGalaxy)
		{
			travelBoardButtonValue.color = EnabledButtonColor;
			buttonTravelBoardBorder.color = EnabledButtonColor;
		}
		else
		{
			travelBoardButtonValue.color = DisabledButtonColor;
			buttonTravelBoardBorder.color = DisabledButtonColor;
		}
		lastSysJumpStatus = canJump;
	}

	public void SetCurrentDungeonTravelAbility(bool canTravel)
	{
		if (canTravel)
		{
			travelBoardButtonValue.color = EnabledButtonColor;
			buttonTravelBoardBorder.color = EnabledButtonColor;
		}
		else
		{
			travelBoardButtonValue.color = DisabledButtonColor;
			buttonTravelBoardBorder.color = DisabledButtonColor;
		}
	}

	public void SetDungeonAsTravel()
	{
		if (!UniverseMapManager.Instance.IsReadOnlyGalaxy)
		{
			travelBoardButtonValue.text = "[T]ravel";
		}
		else
		{
			travelBoardButtonValue.text = "[R]eturn";
		}
	}

	public void SetDungeonAsBoard()
	{
		if (!UniverseMapManager.Instance.IsReadOnlyGalaxy)
		{
			travelBoardButtonValue.text = "[B]oard";
		}
		else
		{
			travelBoardButtonValue.text = "[R]eturn";
		}
	}

	public void SetStargateAsTravel()
	{
		if (!UniverseMapManager.Instance.IsReadOnlyGalaxy)
		{
			travelBoardButtonValue.text = "[J]ump";
		}
		else
		{
			travelBoardButtonValue.text = "[R]eturn";
		}
	}

	public void SetScrap(int scrap)
	{
		numberScrap.text = string.Format("{0}/{1}", scrap, GlobalSettings.GameState.ThePlayer.MyShip.ScrapMax);
	}

	public void SetFuelPropulsion(int fuelCharge, int fuelReserve)
	{
		fuelNumber.text = string.Format("{0}/{2} (+{1})", fuelCharge, fuelReserve, GlobalSettings.GameState.ThePlayer.MyShip.PFuelMax);
	}

	public void SetFuelJump(int fuel)
	{
		jumpNumber.text = fuel.ToString();
	}

	public void SetSystemProperties(StarSystemInfo system, bool isCurrentSystem)
	{
		RefreshSelectedSystem(system);
		titleGalaxy.enabled = true;
		if (isCurrentSystem)
		{
			titleView.text = system.Name;
		}
		int num = system.NumberOfDungeons + system.NumberOfOutposts + system.NumberOfStations + system.NumberOfTradingPosts;
		if (system.IsNursery && (GameSaveFile.Get("PLAYS", 0) <= 1 || !GameSaveFile.Get("NC", false)))
		{
			num = 4;
		}
		if (system.HasStargate)
		{
			num++;
		}
		sysObjectsValue.text = num.ToString();
		sysVisitedValue.text = system.VisitedCount.ToString();
	}

	public void SetDungeonProperties(DungeonInfo dungeon, DungeonNode node, int dist)
	{
		RefreshSelectedDungeon(dungeon, node);
		if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon != null)
		{
			titleGalaxy.enabled = true;
			titleGalaxy.text = GalaxyMapManager.Instance.SelectedStarSystem.Name;
		}
		DungeonTypeEnum dungeonType = dungeon.DungeonType;
		switch (dungeonType)
		{
		case DungeonTypeEnum.AutoTrade:
			dockedIcon.overrideSprite = tradingIcon;
			break;
		case DungeonTypeEnum.Derelict:
			dockedIcon.overrideSprite = derelictIcon;
			break;
		case DungeonTypeEnum.Station:
			dockedIcon.overrideSprite = stationIcon;
			break;
		case DungeonTypeEnum.Outpost:
			dockedIcon.overrideSprite = outpostIcon;
			break;
		case DungeonTypeEnum.Stargate:
			dockedIcon.overrideSprite = stargateIcon;
			break;
		}
		titleShipName.text = dungeon.Name;
		shipDistanceValue.text = dist.ToString();
		shipClassValue.text = dungeon.DisplayName;
		if (dungeonType != DungeonTypeEnum.Stargate)
		{
			shipAgeLabel.gameObject.SetActive(true);
			shipAgeValue.gameObject.SetActive(true);
			shipAgeValue.text = string.Format("{0} ({1})", dungeon.Age, dungeon.AgeText);
		}
		else
		{
			shipAgeLabel.gameObject.SetActive(false);
			shipAgeValue.gameObject.SetActive(false);
		}
		shipVisitedValue.text = dungeon.HaveVisited.ToString();
		shipScrapCapacityValue.text = dungeon.ScrapMax.ToString();
		if (dungeonType != DungeonTypeEnum.Stargate && dungeonType != DungeonTypeEnum.AutoTrade)
		{
			shipInfectionTypeLabel.gameObject.SetActive(true);
			shipInfectionTypeValue.gameObject.SetActive(true);
			shipInfectionTypeValue.text = dungeon.InfestationTypeCount;
			shipClassLabel.gameObject.SetActive(true);
			shipClassValue.gameObject.SetActive(true);
			if (dungeonType == DungeonTypeEnum.Derelict && !dungeon.Definition.Key.suppressCommandeer)
			{
				shipScrapCapacityLabel.gameObject.SetActive(true);
				shipScrapCapacityValue.gameObject.SetActive(true);
			}
			else
			{
				shipScrapCapacityLabel.gameObject.SetActive(false);
				shipScrapCapacityValue.gameObject.SetActive(false);
			}
		}
		else
		{
			shipInfectionTypeLabel.gameObject.SetActive(false);
			shipInfectionTypeValue.gameObject.SetActive(false);
			shipScrapCapacityLabel.gameObject.SetActive(false);
			shipScrapCapacityValue.gameObject.SetActive(false);
			if (dungeonType == DungeonTypeEnum.Stargate)
			{
				shipClassLabel.gameObject.SetActive(false);
				shipClassValue.gameObject.SetActive(false);
			}
			else
			{
				shipClassLabel.gameObject.SetActive(true);
				shipClassValue.gameObject.SetActive(true);
			}
		}
		if (dungeonType != DungeonTypeEnum.Stargate && dungeonType != DungeonTypeEnum.AutoTrade)
		{
			shipProfileImage.enabled = true;
			string empty = string.Empty;
			empty = ((dungeon.Definition.Value == null) ? dungeon.Definition.Key.imageFileName : dungeon.Definition.Value.imageFileName);
			if (!string.IsNullOrEmpty(empty))
			{
				Texture2D texture2D = ResourceManager.LoadAsset<Texture2D>("UI/shipProfiles/" + empty);
				if (texture2D != null)
				{
					shipProfileImage.texture = texture2D;
				}
			}
			return;
		}
		switch (dungeonType)
		{
		case DungeonTypeEnum.Stargate:
		{
			string text2 = "stargate";
			if (!string.IsNullOrEmpty(text2))
			{
				Texture2D texture2D3 = ResourceManager.LoadAsset<Texture2D>("UI/shipProfiles/" + text2);
				if (texture2D3 != null)
				{
					shipProfileImage.texture = texture2D3;
				}
			}
			break;
		}
		case DungeonTypeEnum.AutoTrade:
		{
			string text = "tradepost";
			if (!string.IsNullOrEmpty(text))
			{
				Texture2D texture2D2 = ResourceManager.LoadAsset<Texture2D>("UI/shipProfiles/" + text);
				if (texture2D2 != null)
				{
					shipProfileImage.texture = texture2D2;
				}
			}
			break;
		}
		default:
			shipProfileImage.enabled = false;
			break;
		}
	}

	public void SetNoteMode(bool isEditingNote)
	{
		if (isEditingNote)
		{
			DisableSideButtons();
			DisableTopButtons();
			DisableTravelButtons();
		}
		else
		{
			EnableSideButtons();
			EnableTopButtons();
			EnableTravelButtons();
		}
	}

	private void DisableSideButtons()
	{
		buttonObjectivesBorder.color = DisabledButtonColor;
		buttonObjectivesLabel.color = DisabledButtonColor;
		if (buttonNotes != null)
		{
			buttonNotesBorder.color = DisabledButtonColor;
			buttonNotesLabel.color = DisabledButtonColor;
		}
	}

	private void DisableTopButtons()
	{
		buttonUpgradesBorder.color = DisabledButtonColor;
		buttonUpgradesLabel.color = DisabledButtonColor;
		buttonModificationsBorder.color = DisabledButtonColor;
		buttonModificationsIcon.color = DisabledButtonColor;
		buttonModificationsLabel.color = DisabledButtonColor;
		buttonShipConfigBorder.color = DisabledButtonColor;
		buttonShipConfigLabel.color = DisabledButtonColor;
	}

	private void DisableTravelButtons()
	{
		buttonTravelBoardBorder.color = DisabledButtonColor;
		travelBoardButtonValue.color = DisabledButtonColor;
	}

	private void EnableSideButtons()
	{
		buttonObjectivesBorder.color = EnabledButtonColor;
		buttonObjectivesLabel.color = EnabledButtonColor;
		if (buttonNotes != null)
		{
			buttonNotesBorder.color = EnabledButtonColor;
			buttonNotesLabel.color = EnabledButtonColor;
		}
	}

	private void EnableTopButtons()
	{
		buttonUpgradesBorder.color = EnabledButtonColor;
		buttonUpgradesLabel.color = EnabledButtonColor;
		buttonModificationsBorder.color = EnabledButtonColor;
		buttonModificationsIcon.color = EnabledButtonColor;
		buttonModificationsLabel.color = EnabledButtonColor;
		buttonShipConfigBorder.color = EnabledButtonColor;
		buttonShipConfigLabel.color = EnabledButtonColor;
	}

	private void EnableTravelButtons()
	{
		if (lastSysJumpStatus)
		{
			buttonTravelBoardBorder.color = EnabledButtonColor;
			travelBoardButtonValue.color = EnabledButtonColor;
		}
	}

	private void HideSideButtons()
	{
		if (buttonNotes != null)
		{
			buttonNotes.gameObject.SetActive(false);
		}
	}

	private void ShowSideButtons()
	{
		if (GlobalSettings.gameMode == GameModeEnum.Normal && !buttonObjectives.gameObject.activeSelf)
		{
			buttonObjectives.gameObject.SetActive(true);
		}
		if (buttonNotes != null && !buttonNotes.gameObject.activeSelf)
		{
			buttonNotes.gameObject.SetActive(true);
		}
	}
}
