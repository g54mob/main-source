using UnityEngine;
using UnityEngine.UI;

public class TopButtonsView : BaseGUIView
{
	public enum ToolsPanelEnum
	{
		Construction = 0,
		HingeEditor = 1,
		Properties = 2,
		JointEditor = 3,
		Logic = 4
	}

	public const string LevelEditorBackButtonEvent = "TopButtonsView.LevelEditorBackButtonEvent";

	public const string MainMenuButtonEvent = "TopButtonsView.MainMenuButtonEvent";

	public const string LoadButtonEvent = "TopButtonsView.LoadButtonEvent";

	public const string SaveButtonEvent = "TopButtonsView.SaveButtonEvent";

	public const string ManualButtonEvent = "TopButtonsView.ManualButtonEvent";

	public const string ConstructionToggleEvent = "TopButtonsView.ConstructionToggleEvent";

	public const string HingeEditorToggleEvent = "TopButtonsView.HingeEditorToggleEvent";

	public const string PropertiesToggleEvent = "TopButtonsView.PropertiesToggleEvent";

	public const string JointEditorToggleEvent = "TopButtonsView.JointEditorToggleEvent";

	public const string LogicEditorToggleEvent = "TopButtonsView.LogicEditorToggleEvent";

	public const string LevelCreationInfosToggleEvent = "TopButtonsView.LevelCreationInfosToggleEvent";

	public const string LevelStatisticsButtonEvent = "TopButtonsView.LevelStatisticsButtonEvent";

	public const string CameraButtonEvent = "TopButtonsView.CameraButtonEvent";

	public const string PlayButtonEvent = "TopButtonsView.PlayButtonEvent";

	public const string ClearButtonEvent = "TopButtonsView.ClearButtonEvent";

	public const string ResetButtonEvent = "TopButtonsView.ResetButtonEvent";

	public GameObject noKeysTextPrefab;

	[SerializeField]
	private GameObject restrictedBlockSlotPrefab;

	private Button levelEditorBackButton;

	private Button mainMenuButton;

	private Button loadButton;

	private Button saveButton;

	private Button manualButton;

	private Button playButton;

	private Button cameraButton;

	private Button levelStatisticsButton;

	private Toggle constructionToggle;

	private Toggle hingeEditorToggle;

	private Toggle propertiesToggle;

	private Toggle jointEditorToggle;

	private Toggle logicEditorToggle;

	private ToggleStylesApplier constructionToggleStylesApplier;

	private Toggle levelCreationInfosToggle;

	private ConstructionToolsView constructionToolsView;

	private GameObject hingeEditorToolsPanel;

	private GameObject propertiesToolsPanel;

	private GameObject jointEditorToolsPanel;

	private GameObject logicToolsPanel;

	public LevelCreationInfosView LevelCreationInfosView { get; private set; }

	public QuickKeysController QuickKeysController => constructionToolsView.QuickKeysController;

	public override void Initialize()
	{
		levelEditorBackButton = mainPanel.transform.FindComponent<Button>("LevelEditorBackButton", isRecursively: true);
		mainMenuButton = mainPanel.transform.FindComponent<Button>("MainMenuButton", isRecursively: true);
		loadButton = mainPanel.transform.FindComponent<Button>("LoadButton", isRecursively: true);
		saveButton = mainPanel.transform.FindComponent<Button>("SaveButton", isRecursively: true);
		manualButton = mainPanel.transform.FindComponent<Button>("ManualButton", isRecursively: true);
		constructionToggle = mainPanel.transform.FindComponent<Toggle>("ConstructionToggle", isRecursively: true);
		hingeEditorToggle = mainPanel.transform.FindComponent<Toggle>("HingeEditorToggle", isRecursively: true);
		propertiesToggle = mainPanel.transform.FindComponent<Toggle>("PropertiesToggle", isRecursively: true);
		jointEditorToggle = mainPanel.transform.FindComponent<Toggle>("JointEditorToggle", isRecursively: true);
		logicEditorToggle = mainPanel.transform.FindComponent<Toggle>("LogicEditorToggle", isRecursively: true);
		constructionToggleStylesApplier = constructionToggle.gameObject.GetComponent<ToggleStylesApplier>();
		levelCreationInfosToggle = mainPanel.transform.FindComponent<Toggle>("LevelCreationInfosToggle", isRecursively: true);
		levelStatisticsButton = mainPanel.transform.FindComponent<Button>("LevelStatisticsButton", isRecursively: true);
		cameraButton = mainPanel.transform.FindComponent<Button>("CameraResetButton", isRecursively: true);
		playButton = mainPanel.transform.FindComponent<Button>("PlayButton", isRecursively: true);
		constructionToolsView = new ConstructionToolsView(this);
		new ConstructionToolsController(constructionToolsView, GameManager.Instance.ConstructionToolsModel);
		hingeEditorToolsPanel = mainPanel.transform.FindChildRecursively("HingeEditorToolsPanel").gameObject;
		propertiesToolsPanel = mainPanel.transform.FindChildRecursively("PropertiesToolsPanel").gameObject;
		jointEditorToolsPanel = mainPanel.transform.FindChildRecursively("JointEditorToolsPanel").gameObject;
		logicToolsPanel = mainPanel.transform.FindChildRecursively("LogicToolsPanel").gameObject;
		levelEditorBackButton.onClick.AddListener(delegate
		{
			NotifyChange("TopButtonsView.LevelEditorBackButtonEvent");
		});
		mainMenuButton.onClick.AddListener(delegate
		{
			NotifyChange("TopButtonsView.MainMenuButtonEvent");
		});
		loadButton.onClick.AddListener(delegate
		{
			NotifyChange("TopButtonsView.LoadButtonEvent");
		});
		saveButton.onClick.AddListener(delegate
		{
			NotifyChange("TopButtonsView.SaveButtonEvent");
		});
		manualButton.onClick.AddListener(delegate
		{
			NotifyChange("TopButtonsView.ManualButtonEvent");
		});
		constructionToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("TopButtonsView.ConstructionToggleEvent");
			}
		});
		hingeEditorToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("TopButtonsView.HingeEditorToggleEvent");
			}
		});
		propertiesToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("TopButtonsView.PropertiesToggleEvent");
			}
		});
		jointEditorToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("TopButtonsView.JointEditorToggleEvent");
			}
		});
		logicEditorToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NotifyChange("TopButtonsView.LogicEditorToggleEvent");
			}
		});
		levelCreationInfosToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			NotifyChange("TopButtonsView.LevelCreationInfosToggleEvent", isOn);
		});
		levelStatisticsButton.onClick.AddListener(delegate
		{
			NotifyChange("TopButtonsView.LevelStatisticsButtonEvent");
		});
		cameraButton.onClick.AddListener(delegate
		{
			NotifyChange("TopButtonsView.CameraButtonEvent");
		});
		playButton.onClick.AddListener(delegate
		{
			NotifyChange("TopButtonsView.PlayButtonEvent");
		});
		LevelCreationInfosView = new LevelCreationInfosView(this, restrictedBlockSlotPrefab);
		Util.AddMouseOverUIEvents(mainPanel, base.OnMouseOverUIHandler);
	}

	public void ShowToolsPanel(ToolsPanelEnum whichToolsPanelToShow)
	{
		switch (whichToolsPanelToShow)
		{
		case ToolsPanelEnum.Construction:
			constructionToolsView.SetVisibility(isVisible: true);
			hingeEditorToolsPanel.SetActive(value: false);
			propertiesToolsPanel.SetActive(value: false);
			jointEditorToolsPanel.SetActive(value: false);
			logicToolsPanel.SetActive(value: false);
			break;
		case ToolsPanelEnum.HingeEditor:
			hingeEditorToolsPanel.SetActive(value: true);
			constructionToolsView.SetVisibility(isVisible: false);
			propertiesToolsPanel.SetActive(value: false);
			jointEditorToolsPanel.SetActive(value: false);
			logicToolsPanel.SetActive(value: false);
			break;
		case ToolsPanelEnum.Properties:
			propertiesToolsPanel.SetActive(value: true);
			constructionToolsView.SetVisibility(isVisible: false);
			hingeEditorToolsPanel.SetActive(value: false);
			jointEditorToolsPanel.SetActive(value: false);
			logicToolsPanel.SetActive(value: false);
			break;
		case ToolsPanelEnum.JointEditor:
			jointEditorToolsPanel.SetActive(value: true);
			constructionToolsView.SetVisibility(isVisible: false);
			hingeEditorToolsPanel.SetActive(value: false);
			propertiesToolsPanel.SetActive(value: false);
			logicToolsPanel.SetActive(value: false);
			break;
		case ToolsPanelEnum.Logic:
			logicToolsPanel.SetActive(value: true);
			constructionToolsView.SetVisibility(isVisible: false);
			hingeEditorToolsPanel.SetActive(value: false);
			propertiesToolsPanel.SetActive(value: false);
			jointEditorToolsPanel.SetActive(value: false);
			break;
		}
	}

	public override void SetVisibility(bool isVisible)
	{
		base.SetVisibility(isVisible);
		if (isVisible)
		{
			if (GameManager.Instance.GameMode == GameManager.GameModeState.Attacker)
			{
				loadButton.gameObject.SetActive(value: true);
			}
			else if (GameManager.Instance.GameMode == GameManager.GameModeState.Defender)
			{
				loadButton.gameObject.SetActive(value: false);
			}
		}
	}

	public void SetConstructionToggleStatus(bool isSelected)
	{
		if (constructionToggle.isOn != isSelected)
		{
			constructionToggle.SetValue(isSelected);
		}
		if (constructionToggleStylesApplier != null)
		{
			constructionToggleStylesApplier.SetToggleStyles(isSelected);
		}
	}

	public void SetHingeEditorToggleStatus(bool isSelected)
	{
		if (hingeEditorToggle.isOn != isSelected)
		{
			hingeEditorToggle.SetValue(isSelected);
		}
	}

	public void SetPropertiesToggleStatus(bool isSelected)
	{
		if (propertiesToggle.isOn != isSelected)
		{
			propertiesToggle.SetValue(isSelected);
		}
	}

	public void SetJointEditorToggleStatus(bool isSelected)
	{
		if (jointEditorToggle.isOn != isSelected)
		{
			jointEditorToggle.SetValue(isSelected);
		}
	}

	public void SetLogicEditorToggleStatus(bool isSelected)
	{
		if (logicEditorToggle.isOn != isSelected)
		{
			logicEditorToggle.SetValue(isSelected);
		}
	}

	public void SetLevelCreationInfosToggleStatus(bool isSelected)
	{
		if (levelCreationInfosToggle.isOn != isSelected)
		{
			levelCreationInfosToggle.SetValue(isSelected);
		}
	}

	public void SetSaveButtonInteractivity(bool isInteractable)
	{
		if (saveButton.interactable != isInteractable)
		{
			saveButton.interactable = isInteractable;
		}
	}

	public void SetLevelEditorBackButtonVisibility(bool isVisible)
	{
		if (levelEditorBackButton.gameObject.activeSelf != isVisible)
		{
			levelEditorBackButton.gameObject.SetActive(isVisible);
		}
	}
}
