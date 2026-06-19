using Unity.Entities;

public struct BehaviourTagsCD : IComponentData, IQueryTypeParameter
{
	public ulong wantsToAttackTagsBitMask;

	public ulong cantAttackTagsBitMask;

	public ulong eatsTagsBitMask;

	public static bool CantAttack(BehaviourTagsCD attackerBehaviourTags, ObjectCategoryTagsCD targetTags)
	{
		return ObjectCategoryTagsCD.HasAnyMatches(attackerBehaviourTags.cantAttackTagsBitMask, targetTags.tagsBitMask);
	}

	public static bool CantAttack(BehaviourTagsCD attackerBehaviourTags, ObjectCategoryTag targetTag)
	{
		return ObjectCategoryTagsCD.HasTag(attackerBehaviourTags.cantAttackTagsBitMask, targetTag);
	}

	public static bool WantsToAttack(BehaviourTagsCD attackerBehaviourTags, ObjectCategoryTagsCD targetTags)
	{
		return ObjectCategoryTagsCD.HasAnyMatches(attackerBehaviourTags.wantsToAttackTagsBitMask, targetTags.tagsBitMask);
	}

	public static bool WantsToAndCanAttack(BehaviourTagsCD attackerBehaviourTags, ObjectCategoryTagsCD targetTags)
	{
		if (WantsToAttack(attackerBehaviourTags, targetTags))
		{
			return !CantAttack(attackerBehaviourTags, targetTags);
		}
		return false;
	}

	public static bool Eats(BehaviourTagsCD eaterBehaviourTags, ObjectCategoryTagsCD targetTags)
	{
		return ObjectCategoryTagsCD.HasAnyMatches(eaterBehaviourTags.eatsTagsBitMask, targetTags.tagsBitMask);
	}
}
