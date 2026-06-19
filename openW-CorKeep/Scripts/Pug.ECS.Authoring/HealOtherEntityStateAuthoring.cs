using Unity.Mathematics;
using UnityEngine;

[DisallowMultipleComponent]
public class HealOtherEntityStateAuthoring : MonoBehaviour
{
	public float maxReachDistance;

	public float anticipationDuration;

	public float healDuration;

	public bool skipVisibilityCheck;

	public int keepHealingUntilTakingDamageXTimes;

	[Header("If an AreaLevelAuthoring component exists then stats are calculated from that")]
	public bool donCalculateHealingFromLevel;

	public bool healPercentageOfHp;

	public int healPerSecond;

	public float healMultiplier = 1f;

	public float minCooldown;

	public float maxCooldown;

	public static int LevelToHealing(int level, float multiplier)
	{
		return math.max(1, (int)math.round((100f + 50f * math.pow(level - 1, 1.2f) * 0.3f) * multiplier));
	}
}
