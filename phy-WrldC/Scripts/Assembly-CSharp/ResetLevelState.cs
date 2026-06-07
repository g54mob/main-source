public class ResetLevelState : State<GameManager>
{
	public static ResetLevelState Instance { get; }

	static ResetLevelState()
	{
		Instance = new ResetLevelState();
	}

	private ResetLevelState()
	{
	}

	public override void Start(GameManager gameManager)
	{
	}

	public override void Enter(GameManager gameManager)
	{
		gameManager.VisualEffectsManager.DestroyAllEffects();
	}

	public override void Execute(GameManager gameManager)
	{
		if (gameManager.MainCreationsManager.IsCreationsLoaded)
		{
			gameManager.ChangeState(ActionState.Instance);
		}
	}

	public override void Exit(GameManager gameManager)
	{
	}
}
