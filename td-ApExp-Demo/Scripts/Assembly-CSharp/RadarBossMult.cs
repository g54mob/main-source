using UnityEngine;

[CreateAssetMenu(fileName = "12BossMult", menuName = "Radar/12BossMult")]
public class RadarBossMult : EnhancementRadar
{
	[SerializeField]
	private float bossDmgMultInc = 0.1f;

	public override void OnApplied()
	{
		EnemyManager.Instance.BossDmgMult += bossDmgMultInc;
	}

	public override void OnRemoved()
	{
		EnemyManager.Instance.BossDmgMult -= bossDmgMultInc;
	}
}
