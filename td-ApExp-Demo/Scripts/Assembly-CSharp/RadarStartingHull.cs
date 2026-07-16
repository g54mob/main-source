using UnityEngine;

[CreateAssetMenu(fileName = "21StartingHull", menuName = "Radar/21StartingHull")]
public class RadarStartingHull : EnhancementRadar, IEnhancementMaxHull
{
	[SerializeField]
	private float startingHullIncrease = 200f;

	public void ExecuteOnLoad()
	{
	}

	public override void OnApplied()
	{
		Train.Instance.HealthComponent.SetMaxHealth(Train.Instance.HealthComponent.HealthMax + startingHullIncrease);
	}

	public override void OnRemoved()
	{
		Train.Instance.HealthComponent.SetMaxHealth(Train.Instance.HealthComponent.HealthMax - startingHullIncrease);
	}
}
