using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LETopButtonsView : BaseGUIView
{
	public const string MainMenuButtonEvent = "LETopButtonsView.MainMenuButtonEvent";

	public const string LoadButtonEvent = "LETopButtonsView.LoadButtonEvent";

	public const string SaveButtonEvent = "LETopButtonsView.SaveButtonEvent";

	public const string ManualButtonEvent = "LETopButtonsView.ManualButtonEvent";

	public const string TestLevelButtonEvent = "LETopButtonsView.TestLevelButtonEvent";

	public const string LevelInfosCloseButtonEvent = "LETopButtonsView.LevelInfosCloseButtonEvent";

	public const string LevelInfosToggleEvent = "LETopButtonsView.LevelInfosToggleEvent";

	public const string ManualIndicatorCloseButtonEvent = "LETopButtonsView.ManualIndicatorCloseButtonEvent";

	private Button mainMenuButton;

	private Button saveButton;

	private Button loadButton;

	private Button manualButton;

	private Button testLevelButton;

	private Toggle levelInfosToggle;

	private GameObject levelInfosWindow;

	private GameObject manualIndicatorPanel;

	private Button levelInfosCloseButton;

	private Button manualIndicatorCloseButton;

	private TextMeshProUGUI nameText;

	private TextMeshProUGUI descriptionText;

	public override void Initialize()
	{
		mainMenuButton = mainPanel.transform.FindComponent<Button>("MainMenuButton", isRecursively: true);
		loadButton = mainPanel.transform.FindComponent<Button>("LoadButton", isRecursively: true);
		saveButton = mainPanel.transform.FindComponent<Button>("SaveButton", isRecursively: true);
		manualButton = mainPanel.transform.FindComponent<Button>("ManualButton", isRecursively: true);
		testLevelButton = mainPanel.transform.FindComponent<Button>("TestLevelButton", isRecursively: true);
		levelInfosToggle = mainPanel.transform.FindComponent<Toggle>("LevelInfosToggle", isRecursively: true);
		levelInfosWindow = mainPanel.transform.FindChildRecursively("LevelInfosWindow").gameObject;
		manualIndicatorPanel = mainPanel.transform.FindChildRecursively("ManualIndicatorPanel").gameObject;
		levelInfosCloseButton = mainPanel.transform.FindComponent<Button>("LevelInfosCloseButton", isRecursively: true);
		manualIndicatorCloseButton = mainPanel.transform.FindComponent<Button>("ManualIndicatorCloseButton", isRecursively: true);
		nameText = mainPanel.transform.FindComponent<TextMeshProUGUI>("NameText", isRecursively: true);
		descriptionText = mainPanel.transform.FindComponent<TextMeshProUGUI>("DescriptionText", isRecursively: true);
		mainMenuButton.onClick.AddListener(delegate
		{
			NotifyChange("LETopButtonsView.MainMenuButtonEvent");
		});
		loadButton.onClick.AddListener(delegate
		{
			NotifyChange("LETopButtonsView.LoadButtonEvent");
		});
		saveButton.onClick.AddListener(delegate
		{
			NotifyChange("LETopButtonsView.SaveButtonEvent");
		});
		manualButton.onClick.AddListener(delegate
		{
			NotifyChange("LETopButtonsView.ManualButtonEvent");
		});
		testLevelButton.onClick.AddListener(delegate
		{
			NotifyChange("LETopButtonsView.TestLevelButtonEvent");
		});
		levelInfosCloseButton.onClick.AddListener(delegate
		{
			NotifyChange("LETopButtonsView.LevelInfosCloseButtonEvent");
		});
		levelInfosToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			NotifyChange("LETopButtonsView.LevelInfosToggleEvent", isOn);
		});
		manualIndicatorCloseButton.onClick.AddListener(delegate
		{
			NotifyChange("LETopButtonsView.ManualIndicatorCloseButtonEvent");
		});
		Util.AddMouseOverUIEvents(mainPanel, base.OnMouseOverUIHandler);
	}

	public void SetLoadButtonInteractivity(bool isInteractive)
	{
		if (loadButton.interactable != isInteractive)
		{
			loadButton.interactable = isInteractive;
		}
	}

	public void SetLevelInfosWindowVisibility(bool isVisible)
	{
		if (levelInfosWindow.activeSelf != isVisible)
		{
			levelInfosWindow.SetActive(isVisible);
		}
	}

	public void SetManualIndicatorPanelVisibility(bool isVisible)
	{
		if (manualIndicatorPanel.activeSelf != isVisible)
		{
			manualIndicatorPanel.SetActive(isVisible);
		}
	}

	public void SetLevelInfos(LevelModel levelModel)
	{
		nameText.SetText(levelModel.Name);
		descriptionText.SetText(levelModel.Description);
	}

	public void SetLevelInfosToggleValue(bool isSelected)
	{
		if (levelInfosToggle.isOn != isSelected)
		{
			levelInfosToggle.SetValue(isSelected);
		}
	}
}
