using UnityEngine;

public class Bullet_Missile : Bullet_HomingMissile
{
	[SerializeField]
	private GameObject missile_Normal;

	[SerializeField]
	private GameObject missile_Fire;

	[SerializeField]
	private GameObject missile_Frost;

	[SerializeField]
	private ParticleSystem particle_Explosion_Normal;

	[SerializeField]
	private ParticleSystem particle_Explosion_Fire;

	[SerializeField]
	private ParticleSystem particle_Explosion_Frost;

	private int effectDamage;

	private float effectRange;

	private eDamageType upgradeEffectType;

	public void SetMissileType(eDamageType damageType, eDamageType upgradeEffectType, int effectDamage, float effectRange)
	{
	}

	protected override void Explode()
	{
	}
}
