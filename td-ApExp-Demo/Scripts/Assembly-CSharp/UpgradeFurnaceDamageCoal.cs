using UnityEngine;

[CreateAssetMenu(fileName = "FurnaceDamageCoal", menuName = "Upgrade/Furnace/DamageCoal")]
public class UpgradeFurnaceDamageCoal : EnhancementUpgrade
{
	private ModuleFurnace furnace;

	[SerializeField]
	private float coalSecondsPerHit = 1f;

	public override void ApplyUpgrade()
	{
		ModuleFurnace moduleByType = Train.Instance.GetModuleByType<ModuleFurnace>();
		if ((object)moduleByType != null)
		{
			furnace = moduleByType;
			moduleByType.HealthComponent.OnHealthChanged += OnFurnaceHealthChange;
		}
	}

	private void OnFurnaceHealthChange(HealthChangeInfo info)
	{
		if (!(info.HealthChange >= 0f))
		{
			Train.Instance.CoalSeconds += coalSecondsPerHit;
		}
	}
}
