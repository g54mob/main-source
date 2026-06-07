using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelStatisticsView : BaseGUIView
{
	public enum PanelType
	{
		Creations = 0,
		OnlyText = 1,
		NotCompleted = 2
	}

	public enum StarFilter
	{
		Both = 0,
		Gold = 1,
		Silver = 2,
		None = 3
	}

	public const string StarFilterChangedEvent = "LevelStatisticsView.StarFilterChangedEvent";

	public const string LoadButtonEvent = "LevelStatisticsView.LoadButtonEvent";

	public const string CloseButtonEvent = "LevelStatisticsView.CloseButtonEvent";

	private Toggle recordsTab;

	private Toggle leaderboardsTab;

	private TextMeshProUGUI groupText;

	private TextMeshProUGUI nameText;

	private TextMeshProUGUI completedText;

	private TextMeshProUGUI starsText;

	private GameObject creationsRecordsPanel;

	private GameObject notCompletedPanel;

	private GameObject onlyTextPanel;

	private GameObject starRowObject;

	private Toggle zeroStarToggle;

	private Toggle oneStarToggle;

	private Toggle twoStarToggle;

	private Toggle threeStarToggle;

	private LevelStatisticsSlot timeSlot;

	private LevelStatisticsSlot blocksSlot;

	private LevelStatisticsSlot costSlot;

	private LevelStatisticsSlot weightSlot;

	private TextMeshProUGUI timeOnlyText;

	private TextMeshProUGUI blocksOnlyText;

	private TextMeshProUGUI costOnlyText;

	private TextMeshProUGUI weightOnlyText;

	private Button closeButton;

	private GameObject mouseOverCreationFolder;

	private Quaternion blockReferenceRotation;

	private bool isRotating;

	private LeaderboardsPanelView leaderboardsPanelView;

	private LeaderboardsPanelController leaderboardsPanelController;

	public override void Initialize()
	{
		recordsTab = mainPanel.transform.FindComponent<Toggle>("RecordsTab", isRecursively: true);
		leaderboardsTab = mainPanel.transform.FindComponent<Toggle>("LeaderboardsTab", isRecursively: true);
		groupText = mainPanel.transform.FindComponent<TextMeshProUGUI>("GroupText", isRecursively: true);
		nameText = mainPanel.transform.FindComponent<TextMeshProUGUI>("NameText", isRecursively: true);
		completedText = mainPanel.transform.FindComponent<TextMeshProUGUI>("CompletedText", isRecursively: true);
		starsText = mainPanel.transform.FindComponent<TextMeshProUGUI>("StarsText", isRecursively: true);
		creationsRecordsPanel = mainPanel.transform.FindChildRecursively("CreationsRecordsPanel").gameObject;
		notCompletedPanel = mainPanel.transform.FindChildRecursively("NotCompletedPanel").gameObject;
		onlyTextPanel = mainPanel.transform.FindChildRecursively("OnlyTextPanel").gameObject;
		starRowObject = mainPanel.transform.FindChildRecursively("StarRow").gameObject;
		zeroStarToggle = starRowObject.transform.FindComponent<Toggle>("ZeroStarToggle", isRecursively: true);
		oneStarToggle = starRowObject.transform.FindComponent<Toggle>("OneStarToggle", isRecursively: true);
		twoStarToggle = starRowObject.transform.FindComponent<Toggle>("TwoStarToggle", isRecursively: true);
		threeStarToggle = starRowObject.transform.FindComponent<Toggle>("ThreeStarToggle", isRecursively: true);
		timeSlot = mainPanel.transform.FindComponent<LevelStatisticsSlot>("TimeSlot", isRecursively: true);
		blocksSlot = mainPanel.transform.FindComponent<LevelStatisticsSlot>("BlocksSlot", isRecursively: true);
		costSlot = mainPanel.transform.FindComponent<LevelStatisticsSlot>("CostSlot", isRecursively: true);
		weightSlot = mainPanel.transform.FindComponent<LevelStatisticsSlot>("WeightSlot", isRecursively: true);
		timeOnlyText = mainPanel.transform.FindComponent<TextMeshProUGUI>("TimeOnlyText", isRecursively: true);
		blocksOnlyText = mainPanel.transform.FindComponent<TextMeshProUGUI>("BlocksOnlyText", isRecursively: true);
		costOnlyText = mainPanel.transform.FindComponent<TextMeshProUGUI>("CostOnlyText", isRecursively: true);
		weightOnlyText = mainPanel.transform.FindComponent<TextMeshProUGUI>("WeightOnlyText", isRecursively: true);
		closeButton = mainPanel.transform.FindComponent<Button>("CloseButton", isRecursively: true);
		recordsTab.onValueChanged.AddListener(RecordsTabChangedHandler);
		leaderboardsTab.onValueChanged.AddListener(LeaderboardsTabChangedHandler);
		zeroStarToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("LevelStatisticsView.StarFilterChangedEvent", StarFilter.None);
			}
		});
		oneStarToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("LevelStatisticsView.StarFilterChangedEvent", StarFilter.Silver);
			}
		});
		twoStarToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("LevelStatisticsView.StarFilterChangedEvent", StarFilter.Gold);
			}
		});
		threeStarToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("LevelStatisticsView.StarFilterChangedEvent", StarFilter.Both);
			}
		});
		timeSlot.OnLoadButtonEvent += delegate(CreationModel creationModel)
		{
			NotifyChange("LevelStatisticsView.LoadButtonEvent", creationModel);
		};
		timeSlot.OnMouseOverEvent += CreationRotationHandler;
		blocksSlot.OnLoadButtonEvent += delegate(CreationModel creationModel)
		{
			NotifyChange("LevelStatisticsView.LoadButtonEvent", creationModel);
		};
		blocksSlot.OnMouseOverEvent += CreationRotationHandler;
		costSlot.OnLoadButtonEvent += delegate(CreationModel creationModel)
		{
			NotifyChange("LevelStatisticsView.LoadButtonEvent", creationModel);
		};
		costSlot.OnMouseOverEvent += CreationRotationHandler;
		weightSlot.OnLoadButtonEvent += delegate(CreationModel creationModel)
		{
			NotifyChange("LevelStatisticsView.LoadButtonEvent", creationModel);
		};
		weightSlot.OnMouseOverEvent += CreationRotationHandler;
		closeButton.onClick.AddListener(delegate
		{
			NotifyChange("LevelStatisticsView.CloseButtonEvent");
		});
		leaderboardsPanelView = new LeaderboardsPanelView(this);
		leaderboardsPanelController = new LeaderboardsPanelController(leaderboardsPanelView, null);
	}

	private void RecordsTabChangedHandler(bool isOn)
	{
		if (isOn)
		{
			timeSlot.SetCreationVisibility(isVisible: true);
			blocksSlot.SetCreationVisibility(isVisible: true);
			costSlot.SetCreationVisibility(isVisible: true);
			weightSlot.SetCreationVisibility(isVisible: true);
		}
	}

	private void LeaderboardsTabChangedHandler(bool isOn)
	{
		if (isOn)
		{
			timeSlot.SetCreationVisibility(isVisible: false);
			blocksSlot.SetCreationVisibility(isVisible: false);
			costSlot.SetCreationVisibility(isVisible: false);
			weightSlot.SetCreationVisibility(isVisible: false);
			leaderboardsPanelController.SetModel(GameManager.Instance.LevelController.model);
		}
	}

	public override void SetVisibility(bool isVisible)
	{
		base.SetVisibility(isVisible);
		timeSlot.SetCreationVisibility(isVisible);
		blocksSlot.SetCreationVisibility(isVisible);
		costSlot.SetCreationVisibility(isVisible);
		weightSlot.SetCreationVisibility(isVisible);
	}

	public void SetLevelInfosValues(string groupName, string levelName, bool isLevelCompleted)
	{
		groupText.SetText(groupName);
		nameText.SetText(levelName);
		completedText.SetText(isLevelCompleted ? "<#F7EC3DFF>\uf046" : "<#787878FF>\uf096");
	}

	public void SetPanelType(PanelType panelType)
	{
		creationsRecordsPanel.SetActive(value: false);
		notCompletedPanel.SetActive(value: false);
		onlyTextPanel.SetActive(value: false);
		switch (panelType)
		{
		case PanelType.Creations:
			creationsRecordsPanel.SetActive(value: true);
			break;
		case PanelType.OnlyText:
			onlyTextPanel.SetActive(value: true);
			break;
		case PanelType.NotCompleted:
			notCompletedPanel.SetActive(value: true);
			break;
		default:
			creationsRecordsPanel.SetActive(value: true);
			break;
		}
	}

	public void SetTimeSlotInfos(string timeText, CreationModel creationModel)
	{
		timeSlot.SetSlotText("\uf017  " + timeText);
		timeSlot.SetCreationModel(creationModel);
	}

	public void SetBlocksSlotInfos(string blocksText, CreationModel creationModel)
	{
		blocksSlot.SetSlotText("\uf1b3  " + blocksText);
		blocksSlot.SetCreationModel(creationModel);
	}

	public void SetCostSlotInfos(string costText, CreationModel creationModel)
	{
		costSlot.SetSlotText("\uf0eb  " + costText);
		costSlot.SetCreationModel(creationModel);
	}

	public void SetWeightSlotInfos(string weightText, CreationModel creationModel)
	{
		weightSlot.SetSlotText("\ue908  " + weightText);
		weightSlot.SetCreationModel(creationModel);
	}

	public void SetOnlyTextInfos(string timeText, string blocksText, string costText, string weightText)
	{
		timeOnlyText.SetText(timeText);
		blocksOnlyText.SetText(blocksText);
		costOnlyText.SetText(costText);
		weightOnlyText.SetText(weightText);
	}

	public void SetRecordsTabOn()
	{
		recordsTab.isOn = true;
	}

	public void SetLeaderboardsTabVisibility(bool isVisible)
	{
		leaderboardsTab.gameObject.SetActive(isVisible);
	}

	public void SetStarRowVisibility(bool isVisible)
	{
		starRowObject.SetActive(isVisible);
		if (isVisible)
		{
			zeroStarToggle.SetIsOnWithoutNotify(value: true);
		}
	}

	public void SetStarRowInterativity(bool isAllBoth, bool isAllGold, bool isAllSilver)
	{
		threeStarToggle.interactable = isAllBoth;
		twoStarToggle.interactable = isAllGold;
		oneStarToggle.interactable = isAllSilver;
		zeroStarToggle.interactable = true;
	}

	public void SetCollectablesInfos(bool isThereCollectables, LevelStatus levelStatus)
	{
		starsText.gameObject.SetActive(isThereCollectables);
		if (isThereCollectables)
		{
			if (levelStatus != null)
			{
				var (text, text2) = Util.GetLevelStarsDefaultIcons(levelStatus.AllBothCollectables, levelStatus.AllGoldCollectables, levelStatus.AllSilverCollectables);
				starsText.SetText(text + text2);
			}
			else
			{
				var (text3, text4) = Util.GetLevelStarsDefaultIcons(isAllBoth: false, isAllGold: false, isAllSilver: false);
				starsText.SetText(text3 + text4);
			}
		}
	}

	private void CreationRotationHandler(GameObject creationFolder, Quaternion blockReferenceRotation, bool shouldRotate)
	{
		if (!shouldRotate)
		{
			creationFolder.transform.DOLocalRotate(blockReferenceRotation.eulerAngles, 0.5f, RotateMode.FastBeyond360);
			creationFolder.transform.DOScale(1f, 0.5f);
		}
		else
		{
			creationFolder.transform.DOScale(1.3f, 0.5f);
		}
		mouseOverCreationFolder = creationFolder;
		this.blockReferenceRotation = blockReferenceRotation;
		isRotating = shouldRotate;
	}

	private void Update()
	{
		if (isRotating && mouseOverCreationFolder != null)
		{
			if (mainPanel.activeSelf)
			{
				mouseOverCreationFolder.transform.Rotate(Vector3.up, Time.deltaTime * 100f, Space.World);
				return;
			}
			mouseOverCreationFolder.transform.localRotation = blockReferenceRotation;
			mouseOverCreationFolder.transform.localScale = Vector3.one;
			isRotating = false;
		}
	}
}
