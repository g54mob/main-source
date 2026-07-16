public class E7Wall : EnemyBase
{
	public bool isExpanded;

	private new void Awake()
	{
		base.Awake();
		sm = new StateMachine();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[4]
		{
			new BMoveState(sm, this),
			new E7Idle(sm, this, "Move", "Expanding"),
			new E7Expanding(sm, this),
			new BEMPState(sm, this)
		};
		stateMachine.BuildStateDictionary(newStates);
	}

	private new void Start()
	{
		base.Start();
		Target();
	}
}
