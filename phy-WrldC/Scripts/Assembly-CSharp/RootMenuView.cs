using UnityEngine.UI;

public class RootMenuView : BaseGUIPanelView
{
	private Button tutorialButton;

	private Button campaignButton;

	private Button groupCampaignButton;

	private Button sandboxButton;

	private Button optionsButton;

	private Button userLevelButton;

	private Button levelEditorButton;

	private Button bestPlayersButton;

	private Button creditsButton;

	private Button exitButton;

	public RootMenuView(MainMenuView mainMenuView)
	{
		base.MainPanel = mainMenuView.mainPanel.transform.Find("RootMenuPanel").gameObject;
		tutorialButton = base.MainPanel.transform.FindComponent<Button>("TutorialButton", isRecursively: true);
		campaignButton = base.MainPanel.transform.FindComponent<Button>("CampaignButton", isRecursively: true);
		groupCampaignButton = base.MainPanel.transform.FindComponent<Button>("GroupCampaignButton", isRecursively: true);
		sandboxButton = base.MainPanel.transform.FindComponent<Button>("SandboxButton", isRecursively: true);
		optionsButton = base.MainPanel.transform.FindComponent<Button>("OptionsButton", isRecursively: true);
		userLevelButton = base.MainPanel.transform.FindComponent<Button>("UserLevelButton", isRecursively: true);
		levelEditorButton = base.MainPanel.transform.FindComponent<Button>("LevelEditorButton", isRecursively: true);
		bestPlayersButton = base.MainPanel.transform.FindComponent<Button>("BestPlayersButton", isRecursively: true);
		creditsButton = base.MainPanel.transform.FindComponent<Button>("CreditsButton", isRecursively: true);
		exitButton = base.MainPanel.transform.FindComponent<Button>("ExitButton", isRecursively: true);
		tutorialButton.onClick.AddListener(mainMenuView.GoToTutorial);
		sandboxButton.onClick.AddListener(mainMenuView.GoToSandbox);
		campaignButton.onClick.AddListener(mainMenuView.GoToCampaign);
		groupCampaignButton.onClick.AddListener(mainMenuView.GoToGroupCampign);
		optionsButton.onClick.AddListener(mainMenuView.GoToOptions);
		userLevelButton.onClick.AddListener(mainMenuView.GoToUserLoadLevel);
		levelEditorButton.onClick.AddListener(mainMenuView.GoToLevelEditor);
		bestPlayersButton.onClick.AddListener(mainMenuView.GoToBestPlayers);
		creditsButton.onClick.AddListener(mainMenuView.GoToCredits);
		exitButton.onClick.AddListener(mainMenuView.ExitGame);
	}

	public void SetUserLevelButtonInteractivity(bool isInteractive)
	{
		if (userLevelButton.interactable != isInteractive)
		{
			userLevelButton.interactable = isInteractive;
		}
	}

	public void SetBestPlayersButtonVisibility(bool isVisible)
	{
		bestPlayersButton.gameObject.SetActive(isVisible);
	}
}
