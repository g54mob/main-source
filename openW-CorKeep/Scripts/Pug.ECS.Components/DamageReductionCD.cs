using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct DamageReductionCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public int reduction;

	[GhostField]
	public int maxDamagePerHit;

	public int minDamagePerHit;

	public bool ignoreReductionWhenDamagedByDrill;

	public int GetDamageDealt(int damage, bool bypassDamageReduction, bool bypassMaxDamagePerHit, bool isDamagedByDrill)
	{
		int num = ((!bypassDamageReduction && (!isDamagedByDrill || !ignoreReductionWhenDamagedByDrill)) ? reduction : 0);
		return math.max(minDamagePerHit, math.min(damage - num, (maxDamagePerHit > 0 && !bypassMaxDamagePerHit) ? maxDamagePerHit : int.MaxValue));
	}
}
