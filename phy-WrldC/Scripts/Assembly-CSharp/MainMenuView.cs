using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : BaseGUIView
{
	private enum PanelName
	{
		Root = 0,
		CampaignLoadLevel = 1,
		SandboxLoadLevel = 2,
		AttackerLoadLevel = 3,
		DefenderLoadLevel = 4,
		NewLevel = 5,
		Tutorial = 6,
		Options = 7,
		Credits = 8
	}

	public const string LoadCampaignLevelEvent = "MainMenuView.LoadCampaignLevelEvent";

	public const string LoadSandboxLevelEvent = "MainMenuView.LoadSandboxLevelEvent";

	public const string LoadAttackerLevelEvent = "MainMenuView.LoadAttackerLevelEvent";

	public const string LoadDefenderLevelEvent = "MainMenuView.LoadDefenderLevelEvent";

	public const string LoadTutorialLevelEvent = "MainMenuView.LoadTutorialLevelEvent";

	public const string OpenGroupCampaignWindowEvent = "MainMenuView.OpenGroupCampaignWindowEvent";

	public const string OpenOptionsWindowEvent = "MainMenuView.OpenOptionsWindowEvent";

	public const string OpenUserLoadLevelWindowEvent = "MainMenuView.OpenUserLoadLevelWindowEvent";

	public const string LoadLevelEditorEvent = "MainMenuView.LoadLevelEditorEvent";

	public const string BestPlayersWindowEvent = "MainMenuView.BestPlayersWindowEvent";

	public const string OpenWorshopTrendsWindowEvent = "MainMenuView.OpenWorshopTrendsWindowEvent";

	public const string ExitGameEvent = "MainMenuView.ExitGameEvent";

	public GameObject emptyLevelTextPrefab;

	public GameObject levelLoadSlotPrefab;

	public GameObject levelTemplateSlotPrefab;

	[SerializeField]
	private TextMeshProUGUI versionText;

	[SerializeField]
	private TextMeshProUGUI runtimeDebugText;

	[SerializeField]
	private int levelSlotsPerColumn;

	[SerializeField]
	private GameObject blurredBackgroundObject;

	[SerializeField]
	private Button workshopTrendsButton;

	private RootMenuView rootMenuView;

	private MediaMenuView mediaMenuView;

	private CampaignLevelLoadView campaignLevelLoadView;

	private SandboxLevelLoadView sandboxLevelLoadView;

	private TutorialLevelLoadView tutorialLevelLoadView;

	private AttackerLevelLoadView attackerLevelLoadView;

	private DefenderLevelLoadView defenderLevelLoadView;

	private NewLevelView newLevelView;

	private CreditsView creditsView;

	private WorkshopTrendsView workshopTrendsView;

	private CampaignLevelLoadController campaignLevelLoadController;

	private SandboxLevelLoadController sandboxLevelLoadController;

	private TutorialLevelLoadController tutorialLevelLoadController;

	private AttackerLevelLoadController attackerLevelLoadController;

	private DefenderLevelLoadController defenderLevelLoadController;

	private NewLevelController newLevelController;

	private CreditsController creditsController;

	private WorkshopTrendsController workshopTrendsController;

	public int LevelSlotsPerColumn => levelSlotsPerColumn;

	public override void Initialize()
	{
		rootMenuView = new RootMenuView(this);
		mediaMenuView = new MediaMenuView(this);
		campaignLevelLoadView = new CampaignLevelLoadView(this);
		sandboxLevelLoadView = new SandboxLevelLoadView(this);
		tutorialLevelLoadView = new TutorialLevelLoadView(this);
		attackerLevelLoadView = new AttackerLevelLoadView(this);
		defenderLevelLoadView = new DefenderLevelLoadView(this);
		newLevelView = new NewLevelView(this);
		creditsView = new CreditsView(this);
		workshopTrendsView = new WorkshopTrendsView(this);
		campaignLevelLoadController = new CampaignLevelLoadController(this, campaignLevelLoadView, GameManager.Instance.CampaignStructureModel);
		sandboxLevelLoadController = new SandboxLevelLoadController(this, sandboxLevelLoadView, GameManager.Instance.SandboxCampaignModel);
		tutorialLevelLoadController = new TutorialLevelLoadController(this, tutorialLevelLoadView, GameManager.Instance.TutorialCampaignModel);
		attackerLevelLoadController = new AttackerLevelLoadController(this, attackerLevelLoadView, GameManager.Instance.DefenderLevelModelCollection);
		defenderLevelLoadController = new DefenderLevelLoadController(this, defenderLevelLoadView, GameManager.Instance.DefenderLevelModelCollection);
		newLevelController = new NewLevelController(this, newLevelView, GameManager.Instance.TemplateLevelModelCollection);
		creditsController = new CreditsController(this, creditsView);
		workshopTrendsController = new WorkshopTrendsController(workshopTrendsView, GameManager.Instance.WorkshopTrendsModel);
		workshopTrendsButton.onClick.AddListener(delegate
		{
			NotifyChange("MainMenuView.OpenWorshopTrendsWindowEvent");
		});
		SetVisibility(isVisible: false);
	}

	public void GoToTutorial()
	{
		SetCurrentPanelVisibility(PanelName.Tutorial);
	}

	public void GoToCampaign()
	{
		SetCurrentPanelVisibility(PanelName.CampaignLoadLevel);
	}

	public void GoToSandbox()
	{
		SetCurrentPanelVisibility(PanelName.SandboxLoadLevel);
	}

	public void GoToGroupCampign()
	{
		NotifyChange("MainMenuView.OpenGroupCampaignWindowEvent");
	}

	public void GoToOptions()
	{
		NotifyChange("MainMenuView.OpenOptionsWindowEvent");
	}

	public void GoToUserLoadLevel()
	{
		NotifyChange("MainMenuView.OpenUserLoadLevelWindowEvent");
	}

	public void GoToLevelEditor()
	{
		NotifyChange("MainMenuView.LoadLevelEditorEvent");
	}

	public void GoToBestPlayers()
	{
		NotifyChange("MainMenuView.BestPlayersWindowEvent");
	}

	public void GoToCredits()
	{
		SetCurrentPanelVisibility(PanelName.Credits);
	}

	public void GoBackToRootMenu()
	{
		SetCurrentPanelVisibility(PanelName.Root);
	}

	public void GoToNewLevel()
	{
		SetCurrentPanelVisibility(PanelName.NewLevel);
	}

	public void LoadCampaignLevel(LevelModel levelModel)
	{
		NotifyChange("MainMenuView.LoadCampaignLevelEvent", levelModel);
	}

	public void LoadSandboxLevel(LevelModel levelModel)
	{
		NotifyChange("MainMenuView.LoadSandboxLevelEvent", levelModel);
	}

	public void LoadTutorialLevel(LevelModel levelModel)
	{
		NotifyChange("MainMenuView.LoadTutorialLevelEvent", levelModel);
	}

	public void LoadAttackerLevel(LevelModel levelModel)
	{
		NotifyChange("MainMenuView.LoadAttackerLevelEvent", levelModel);
	}

	public void LoadDefenderLevel(LevelModel levelModel)
	{
		NotifyChange("MainMenuView.LoadDefenderLevelEvent", levelModel);
	}

	public void ExitGame()
	{
		NotifyChange("MainMenuView.ExitGameEvent");
	}

	public void SetWorkshopTrendsVisibility(bool isPanelVisible, bool isButtonVisible)
	{
		workshopTrendsView.SetVisibility(isPanelVisible);
		workshopTrendsButton.gameObject.SetActive(isButtonVisible);
	}

	public override void SetVisibility(bool isVisible)
	{
		base.SetVisibility(isVisible);
		SetCurrentPanelVisibility(PanelName.Root);
	}

	private void SetCurrentPanelVisibility(PanelName panelName)
	{
		attackerLevelLoadView.SetVisibility(isVisible: false);
		campaignLevelLoadView.SetVisibility(isVisible: false);
		sandboxLevelLoadView.SetVisibility(isVisible: false);
		tutorialLevelLoadView.SetVisibility(isVisible: false);
		defenderLevelLoadView.SetVisibility(isVisible: false);
		newLevelView.SetVisibility(isVisible: false);
		creditsView.SetVisibility(isVisible: false);
		switch (panelName)
		{
		case PanelName.Root:
			rootMenuView.SetVisibility(isVisible: true);
			mediaMenuView.SetVisibility(isVisible: true);
			blurredBackgroundObject.SetActive(value: false);
			break;
		case PanelName.CampaignLoadLevel:
			campaignLevelLoadView.SetVisibility(isVisible: true);
			break;
		case PanelName.SandboxLoadLevel:
			sandboxLevelLoadView.SetVisibility(isVisible: true);
			blurredBackgroundObject.SetActive(value: true);
			break;
		case PanelName.Tutorial:
			tutorialLevelLoadView.SetVisibility(isVisible: true);
			blurredBackgroundObject.SetActive(value: true);
			break;
		case PanelName.AttackerLoadLevel:
			attackerLevelLoadView.SetVisibility(isVisible: true);
			break;
		case PanelName.DefenderLoadLevel:
			defenderLevelLoadView.SetVisibility(isVisible: true);
			break;
		case PanelName.NewLevel:
			newLevelView.SetVisibility(isVisible: true);
			break;
		case PanelName.Credits:
			creditsView.SetVisibility(isVisible: true);
			blurredBackgroundObject.SetActive(value: true);
			break;
		default:
			rootMenuView.SetVisibility(isVisible: true);
			mediaMenuView.SetVisibility(isVisible: true);
			blurredBackgroundObject.SetActive(value: false);
			break;
		}
	}

	public void SetUserLevelButtonInteractivity(bool isInteractive)
	{
		rootMenuView.SetUserLevelButtonInteractivity(isInteractive);
	}

	public void SetBestPlayersButtonVisibility(bool isVisible)
	{
		rootMenuView.SetBestPlayersButtonVisibility(isVisible);
	}

	public void SetGameVersion(string version)
	{
		versionText.SetText(version);
	}

	public void SetRuntimeDebugText(string text)
	{
		runtimeDebugText.SetText(text);
	}
}
