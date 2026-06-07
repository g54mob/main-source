public class Bomber : FlyingUnitManager
{
	private int coolDown;

	private bool weaponsEnabled;

	private ParticleTrailManager trail0;

	private ParticleTrailManager trail1;

	public float FIRE_COST => 0f;

	private int COOL_DOWN => 0;

	protected override bool CanFireWeapons()
	{
		return false;
	}

	protected override void EnableWeapons(bool enabled)
	{
	}

	protected override bool AreWeaponsEnabled()
	{
		return false;
	}

	public override void Awake()
	{
	}

	public void CreateMVerseUnit()
	{
	}

	public override void Update()
	{
	}

	public override void GameUpdate()
	{
	}

	private void Fire(float targetX, float targetY)
	{
	}

	private bool CreeperUnderCrossHairs(float targetX, float targetY)
	{
		return false;
	}

	private bool CellContainsEnemy(int gsx, int gsy)
	{
		return false;
	}

	public override void DestroyUnit(bool suppressEffects)
	{
	}
}
