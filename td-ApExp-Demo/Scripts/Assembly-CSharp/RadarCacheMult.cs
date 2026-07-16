using UnityEngine;

[CreateAssetMenu(fileName = "9CacheMult", menuName = "Radar/9CacheMult")]
public class RadarCacheMult : EnhancementRadar
{
	[SerializeField]
	private float cacheMultIncrease = 0.1f;

	public override void OnApplied()
	{
		LootManager.Instance.CacheMult += cacheMultIncrease;
	}

	public override void OnRemoved()
	{
		LootManager.Instance.CacheMult -= cacheMultIncrease;
	}
}
