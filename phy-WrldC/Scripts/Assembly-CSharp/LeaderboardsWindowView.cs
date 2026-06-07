using TMPro;
using UnityEngine.UI;

public class LeaderboardsWindowView : BaseGUIView
{
	public const string CloseButtonEvent = "LeaderboardsView.CloseButtonEvent";

	private TextMeshProUGUI groupText;

	private TextMeshProUGUI nameText;

	private Button closeButton;

	private LeaderboardsPanelView leaderboardsPanelView;

	private LeaderboardsPanelController leaderboardsPanelController;

	public override void Initialize()
	{
		groupText = mainPanel.transform.FindComponent<TextMeshProUGUI>("GroupText", isRecursively: true);
		nameText = mainPanel.transform.FindComponent<TextMeshProUGUI>("NameText", isRecursively: true);
		closeButton = mainPanel.transform.FindComponent<Button>("CloseButton", isRecursively: true);
		closeButton.onClick.AddListener(delegate
		{
			NotifyChange("LeaderboardsView.CloseButtonEvent");
		});
		leaderboardsPanelView = new LeaderboardsPanelView(this);
		leaderboardsPanelController = new LeaderboardsPanelController(leaderboardsPanelView, null);
	}

	public void SetLeaderboardsPanelLevelModel(LevelModel levelModel)
	{
		leaderboardsPanelController.SetModel(levelModel);
	}

	public void SetLevelInfosValues(string groupName, string levelName)
	{
		groupText.SetText(groupName);
		nameText.SetText(levelName);
	}
}
