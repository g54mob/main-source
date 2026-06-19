using UnityEngine;

[DisallowMultipleComponent]
public class BeamAttackStateAuthoring : MonoBehaviour
{
	public float anticipationDuration;

	public float attackDuration;

	public float endDuration;

	public float spawnAtDistanceInfront;

	public float timeBetweenDamageTicks;

	public float minCooldown;

	public float maxCooldown;

	public float beamReachDistance;

	public float beamWidth;

	public int amountOfBeams = 1;

	public float angleBetweenBeams;

	[Header("If an AreaLevelAuthoring component exists then stats are calculated from that")]
	public int damage;

	public float damageMultiplier = 1f;

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
