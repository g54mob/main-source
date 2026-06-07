using UnityEngine;

public class Bullet_Fireball : ASingleTargetProjectile
{
	[SerializeField]
	protected GameObject node_Model_Frost;

	[SerializeField]
	protected ParticleSystem particle_Explosion_Frost;

	[SerializeField]
	protected float speed;

	[SerializeField]
	protected int maxBounceCountSetting;

	[SerializeField]
	protected float bounceMaxRangeSetting;

	[SerializeField]
	protected float maxFlightHeightSetting;

	[SerializeField]
	protected float decreaseFlightHeightRange;

	[SerializeField]
	protected float explodeRange;

	protected float totalFlyTime;

	protected float flyTimer;

	protected Vector3 startPosition;

	protected int damage;

	protected int bounceCount;

	protected float flyHeight;

	protected int maxBounceCount;

	protected float maxBounceRange;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	protected virtual void LandedProc()
	{
	}

	public void Setup(int damage)
	{
	}

	public void OverrideMaxBounceCount(int count)
	{
	}

	public void OverrideCurrentBounceCount(int count)
	{
	}

	public void OverrideMaxBounceRange(float range)
	{
	}

	public void OverrideMaxFlightHeight(float height)
	{
	}

	protected override void SpawnProc()
	{
	}

	protected void CalculateFlyHeight()
	{
	}

	protected override void DespawnProc()
	{
	}

	protected override void DestroyProc()
	{
	}
}
