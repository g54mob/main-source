using UnityEngine;

[CreateAssetMenu(fileName = "7EnemyHealthbars", menuName = "Radar/7EnemyHealthbars")]
public class RadarEnemyHealthbars : EnhancementRadar
{
	public override void OnApplied()
	{
		UIManager.Instance.EnemyHealthbarsDisplay.ActivateHealthBars();
	}

	public override void OnRemoved()
	{
		UIManager.Instance.EnemyHealthbarsDisplay.DeactivateHealthBars();
	}
}
