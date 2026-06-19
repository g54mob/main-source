using UnityEngine;

[DisallowMultipleComponent]
public class ScarabBossAuthoring : MonoBehaviour
{
	public float appearDuration;

	[Header("Charge state")]
	public float buryDuration;

	public float unearthDuration;

	public float minChargeCooldown;

	public float maxChargeCooldown;

	public int chargeDamage;

	public float chargeDamageMultiplier;

	[Header("Scarab spawning")]
	public float bombScarabSpawnAnticipationDuration;

	public float bombScarabSpawnDuration;

	public float bombScarabSpawnEndDuration;

	public float bombScarabSpawnMinCooldown;

	public float bombScarabSpawnMaxCooldown;

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
				chargeDamage = MeleeAttackStateAuthoring.LevelToDamage(num, chargeDamageMultiplier);
			}
		}
	}
}
