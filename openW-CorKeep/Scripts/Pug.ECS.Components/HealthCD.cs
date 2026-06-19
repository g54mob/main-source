using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct HealthCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public int health;

	[GhostField]
	public int maxHealth;

	public float Normalized => (float)health / (float)maxHealth;

	public bool HasFullHealth => health >= maxHealth;

	public bool HasFullHealthIncludingConditions(DynamicBuffer<SummarizedConditionEffectsBuffer> conditionEffectsBuffer)
	{
		return health >= GetMaxHealthWithConditions(conditionEffectsBuffer);
	}

	public readonly int GetMaxHealthWithConditions(DynamicBuffer<SummarizedConditionEffectsBuffer> conditionEffectsBuffer)
	{
		int num = maxHealth;
		num += conditionEffectsBuffer[5].value;
		num += conditionEffectsBuffer[68].value;
		float num2 = math.max(1f + (float)conditionEffectsBuffer[34].value / 100f, 0f);
		return (int)math.round(math.max(1f, num2 * (float)num));
	}
}
