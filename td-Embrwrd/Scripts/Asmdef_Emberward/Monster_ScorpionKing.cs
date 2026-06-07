using UnityEngine;

public class Monster_ScorpionKing : Monster_Basic
{
	[SerializeField]
	private float healthThreshold;

	[SerializeField]
	private float damageReduction;

	[SerializeField]
	private float speedModifier;

	[SerializeField]
	private ParticleSystem particle_ShieldBreak;

	[SerializeField]
	private ParticleSystem particle_ShieldIcon;

	[SerializeField]
	private Material mat_WithoutShield_Normal;

	[SerializeField]
	private Material mat_WithoutShield_Corrupted;

	private bool isSpeedUp;

	private bool isHardModeActive;

	protected override void SpawnProc()
	{
	}

	protected override void UpdateProc(float deltaTime)
	{
	}

	protected override void HitProc(int damage, eDamageType damageType, bool doTriggerHitReaction, bool fromTower)
	{
	}
}
