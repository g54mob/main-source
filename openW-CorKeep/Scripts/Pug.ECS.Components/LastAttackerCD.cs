using Unity.Entities;

public struct LastAttackerCD : IComponentData, IQueryTypeParameter
{
	public const float CHASE_ATTEMPT_COOLDOWN = 5f;

	public const float LAST_ATTACKER_CHASE_DISTANCE_SQ = 400f;

	public Entity Value;

	public float timer;
}
