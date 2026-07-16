using UnityEngine;

[CreateAssetMenu(fileName = "16StartingScrap", menuName = "Radar/16StartingScrap")]
public class RadarStartingScrap : EnhancementRadar
{
	[SerializeField]
	private float startingScrapIncrease;

	public override void OnApplied()
	{
		ResourceManager.Instance.Scrap.AddValue(startingScrapIncrease);
	}

	public override void OnRemoved()
	{
		ResourceManager.Instance.Scrap.TrySpend(startingScrapIncrease);
	}
}
