public class BruteBrain : BaseEnemyBrain
{
	public override int WANDERYNESS
	{
		get
		{
			return 65;
		}
	}

	public override float WANDER_CHECK_PERIOD
	{
		get
		{
			return 10f;
		}
	}

	public override bool RotatesBeforeAttack
	{
		get
		{
			return true;
		}
	}

	public override bool RotatesBeforeNavigate
	{
		get
		{
			return true;
		}
	}

	public BruteBrain(BaseEnemy enemy)
		: base(enemy)
	{
	}
}
