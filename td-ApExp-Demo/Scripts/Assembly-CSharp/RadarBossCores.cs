using UnityEngine;

[CreateAssetMenu(fileName = "10BossCores", menuName = "Radar/10BossCores")]
public class RadarBossCores : EnhancementRadar
{
	[SerializeField]
	private float bossCoreAdd = 1f;

	public override void OnApplied()
	{
		ResourceManager.Instance.baseBossDroppedCoresAmount += bossCoreAdd;
	}

	public override void OnRemoved()
	{
		ResourceManager.Instance.baseBossDroppedCoresAmount -= bossCoreAdd;
	}
}
