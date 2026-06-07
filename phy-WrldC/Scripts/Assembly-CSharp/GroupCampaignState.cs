public class GroupCampaignState : State<GameManager>
{
	private GroupCampaignController groupCampaignController;

	public static GroupCampaignState Instance { get; }

	static GroupCampaignState()
	{
		Instance = new GroupCampaignState();
	}

	private GroupCampaignState()
	{
	}

	public override void Start(GameManager gameManager)
	{
		groupCampaignController = GUIManager.Instance.GroupCampaignController;
		groupCampaignController.model.SelectNextLevel();
	}

	public override void Enter(GameManager gameManager)
	{
		groupCampaignController.view.SetVisibility(isVisible: true);
	}

	public override void Execute(GameManager gameManager)
	{
	}

	public override void Exit(GameManager gameManager)
	{
		groupCampaignController.view.SetVisibility(isVisible: false);
	}
}
