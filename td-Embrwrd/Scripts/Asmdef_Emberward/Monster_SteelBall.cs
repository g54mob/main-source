using UnityEngine;

public class Monster_SteelBall : Monster_Basic
{
	private enum eMoveState
	{
		STAY = 0,
		ROLLING = 1,
		HIT_WALL = 2
	}

	[SerializeField]
	private float maxSpeedMultiplier;

	[SerializeField]
	private float selfStunTimeOnHitWall;

	[SerializeField]
	private float rollingDistanceThresholdForStun;

	[SerializeField]
	private float speedModifierIncreasePerSecond;

	[SerializeField]
	private ParticleSystem particle_HitWall;

	[SerializeField]
	private ParticleSystem particle_SpeedSpark;

	[SerializeField]
	private eMoveState moveState;

	[SerializeField]
	private float curSpeedModifier;

	[SerializeField]
	private float rollingDistance;

	private Vector3 curDirection;

	private Vector3 prevPosition;

	private bool isHardModeActive;

	private float finalMaxSpeedMultiplier;

	protected override void SpawnProc()
	{
	}

	protected override void StunProc(float duration, bool isFromPlayer)
	{
	}

	protected override void UpdateProc(float deltaTime)
	{
	}

	private void HitWall()
	{
	}

	public void RemoveRunSpeed()
	{
	}
}
