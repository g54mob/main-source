using UnityEngine;

public class BossLarvaAuthoring : MonoBehaviour
{
	public WorldGenerationTypeDependentValue<int> roamDistance;

	public WorldGenerationTypeDependentValue<int> roamDeviation;

	[Header("If an AreaLevelAuthoring component exists then stats are calculated from that")]
	public int damage;

	public float damageMultiplier = 1f;

	public GameObject segmentPrefabSmall;

	public GameObject segmentPrefabMedium;

	public GameObject segmentPrefabLarge;

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
			if (level != null)
			{
				int num = level.CalculateLevel();
				damage = MeleeAttackStateAuthoring.LevelToDamage(num, damageMultiplier);
			}
		}
	}
}
