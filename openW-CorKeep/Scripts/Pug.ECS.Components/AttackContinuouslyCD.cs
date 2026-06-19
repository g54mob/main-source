using Unity.Entities;
using UnityEngine.Serialization;

public struct AttackContinuouslyCD : IComponentData, IQueryTypeParameter
{
	public int damage;

	public DamageEffectType damageEffectType;

	public float attackTime;

	public float cooldown;

	public float timer;

	public float breakTimer;

	public bool hasTriggeredIdleAnimationOnEnteringState;

	public bool isBreaking;

	[FormerlySerializedAs("disabled")]
	public bool disableDamage;
}
