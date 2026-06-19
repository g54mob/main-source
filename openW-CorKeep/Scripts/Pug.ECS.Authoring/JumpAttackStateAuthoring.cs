using UnityEngine;

public class JumpAttackStateAuthoring : MonoBehaviour
{
	[Header("If an AreaLevelAuthoring component exists then stats are calculated from that")]
	public float anticipationTime;

	public float airTime;

	public int jumpDamage;

	public float jumpDamageMultiplier = 1f;

	public float jumpMoveSpeed;

	public bool canOnlyAttackEnemiesAndPlayer;

	public float minCooldown = 1f;

	public float maxCooldown = 1f;

	[Header("This is currently distance squared. TODO: fix this and change prefab values accordingly.")]
	public float distanceToAttack = 3f;

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
				jumpDamage = MeleeAttackStateAuthoring.LevelToDamage(num, jumpDamageMultiplier);
			}
		}
	}
}
