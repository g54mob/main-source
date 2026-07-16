using UnityEngine;

[CreateAssetMenu(fileName = "13StartingAmmo", menuName = "Radar/13StartingAmmo")]
public class RadarStartingAmmo : EnhancementRadar
{
	[SerializeField]
	private float startingAmmoIncrease = 200f;

	public override void OnApplied()
	{
		ResourceManager.Instance.Ammo.AddValue(startingAmmoIncrease);
	}

	public override void OnRemoved()
	{
		ResourceManager.Instance.Ammo.TrySpend(startingAmmoIncrease);
	}
}
