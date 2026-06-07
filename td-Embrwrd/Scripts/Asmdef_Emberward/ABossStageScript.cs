public abstract class ABossStageScript : AStageScript
{
	private AMonsterBase monster;

	protected virtual void Awake()
	{
	}

	public bool IsBossDead()
	{
		return false;
	}
}
