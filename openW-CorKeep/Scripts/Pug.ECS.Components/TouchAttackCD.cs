using Unity.Entities;
using Unity.NetCode;

public struct TouchAttackCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public NetworkTick lastAttackTick;

	public int damage;

	public float pushback;

	public float hitRadius;

	public float cooldown;

	public int triggerAnimation;

	public bool ignoreDamageReduction;
}
