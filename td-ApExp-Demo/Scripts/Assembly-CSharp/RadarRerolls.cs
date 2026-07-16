using UnityEngine;

[CreateAssetMenu(fileName = "15Rerolls", menuName = "Radar/15Rerolls")]
public class RadarRerolls : EnhancementRadar
{
	[SerializeField]
	private int rerollsToAdd = 3;

	public override void OnApplied()
	{
		ResourceManager.Instance.Rerolls.AddValue(rerollsToAdd);
	}

	public override void OnRemoved()
	{
		ResourceManager.Instance.Rerolls.TrySpend(rerollsToAdd);
	}
}
