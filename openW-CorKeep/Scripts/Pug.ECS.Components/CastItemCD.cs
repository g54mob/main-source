using Unity.Entities;

public struct CastItemCD : IComponentData, IQueryTypeParameter
{
	public float castTime;

	public CastItemUseType useType;

	public AchievementID achievement;

	public EffectID castCompleteEffect;
}
