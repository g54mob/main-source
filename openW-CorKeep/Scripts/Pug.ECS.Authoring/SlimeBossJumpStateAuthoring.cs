using PugTilemap;
using UnityEngine;

[DisallowMultipleComponent]
public class SlimeBossJumpStateAuthoring : MonoBehaviour
{
	public float anticipationTime;

	public float enragedAnticipationTime;

	public float maxAirTime;

	public float enragedMaxAirTime;

	public float landTime;

	public float jumpMoveSpeed;

	public float enragedJumpMoveSpeed;

	public Tileset slimeTileset;

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
				damage = (int)((float)MeleeAttackStateAuthoring.LevelToDamage(num, damageMultiplier) * 1.55f);
			}
		}
	}
}
