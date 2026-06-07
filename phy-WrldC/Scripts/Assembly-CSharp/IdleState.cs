public class IdleState : State<GameManager>
{
	private static readonly IdleState instance;

	public static IdleState Instance => instance;

	static IdleState()
	{
		instance = new IdleState();
	}

	private IdleState()
	{
	}

	public override void Start(GameManager entity)
	{
	}

	public override void Enter(GameManager entity)
	{
	}

	public override void Execute(GameManager entity)
	{
	}

	public override void Exit(GameManager entity)
	{
	}
}
