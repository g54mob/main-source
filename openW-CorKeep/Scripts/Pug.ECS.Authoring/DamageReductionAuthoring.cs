using Unity.Mathematics;
using UnityEngine;

public class DamageReductionAuthoring : MonoBehaviour
{
	[Header("If an AreaLevelAuthoring component exists then stats are calculated from that")]
	public bool calculateReductionFromLevel;

	public float reductionMultiplier = 1f;

	public int reduction;

	public int maxDamagePerHit;

	public int minDamagePerHit;

	public bool ignoreReductionWhenDamagedByDrill;

	[HideInInspector]
	public AreaLevelAuthoring level;

	private void OnValidate()
	{
		if (!Application.isPlaying)
		{
			if (level == null || level.gameObject != base.gameObject)
			{
				level = GetComponent<AreaLevelAuthoring>();
			}
			if (level != null && calculateReductionFromLevel)
			{
				int num = level.CalculateLevel();
				reduction = LevelToReduction(num);
			}
		}
	}

	public int LevelToReduction(int level)
	{
		float num = (float)level / 2f + 0.5f;
		return (int)math.round(5f * (-1f + num) * (-4f + 3f * num) * reductionMultiplier);
	}
}
