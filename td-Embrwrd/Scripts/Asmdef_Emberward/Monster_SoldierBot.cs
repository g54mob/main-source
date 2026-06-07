using System.Collections;
using UnityEngine;

public class Monster_SoldierBot : Monster_Basic
{
	public enum eMoveState
	{
		NONE = 0,
		HAS_CAPTAIN = 1,
		NO_CAPTAIN = 2
	}

	[SerializeField]
	private ParticleSystem particle_Shield;

	[SerializeField]
	private float damageReduction;

	private eMoveState moveState;

	private Monster_Basic captain;

	private float followDistance;

	private float detectInterval;

	private float detectTimer;

	public eMoveState MoveState => default(eMoveState);

	public void SetCaptain(Monster_Basic captain, float followDistance)
	{
	}

	public void SetFollowDistance(float followDistance)
	{
	}

	private void OnCaptainKilled(AMonsterBase monster)
	{
	}

	protected override void SpawnProc()
	{
	}

	protected override void HitProc(int damage, eDamageType damageType, bool doTriggerHitReaction, bool isFromTower)
	{
	}

	protected override void UpdateProc(float deltaTime)
	{
	}

	protected override IEnumerator DeathProc(int damage, bool isKilled, bool playAnimation = true)
	{
		return null;
	}

	protected override void DespawnProc()
	{
	}
}
