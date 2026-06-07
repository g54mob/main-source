public class MPActionState : State<GameManager>
{
	private static readonly MPActionState instance;

	public static MPActionState Instance => instance;

	static MPActionState()
	{
		instance = new MPActionState();
	}

	private MPActionState()
	{
	}

	public override void Start(GameManager GAME)
	{
	}

	public override void Enter(GameManager GAME)
	{
	}

	public override void Execute(GameManager GAME)
	{
	}

	public override void Exit(GameManager GAME)
	{
	}
}
