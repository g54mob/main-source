using UnityEngine;

[CreateAssetMenu(fileName = "23SlowMissiles", menuName = "Radar/23SlowMissiles")]
public class RadarSlowMissiles : EnhancementRadar
{
	[SerializeField]
	[Tooltip("This value is the reduction applied to the multiplier, e.g. a value of 0.25 here will equal a 25% speed reduction.")]
	private float missileSpeedMultReduction = 0.25f;

	public override void OnApplied()
	{
		EnemyManager.Instance.EnemyMissileSpeedMult -= missileSpeedMultReduction;
	}

	public override void OnRemoved()
	{
		EnemyManager.Instance.EnemyMissileSpeedMult += missileSpeedMultReduction;
	}
}
