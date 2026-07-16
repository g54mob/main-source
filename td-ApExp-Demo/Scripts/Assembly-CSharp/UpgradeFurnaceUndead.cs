using UnityEngine;

[CreateAssetMenu(fileName = "FurnaceUndead", menuName = "Upgrade/Furnace/Undead")]
public class UpgradeFurnaceUndead : EnhancementUpgrade
{
	[SerializeField]
	private float speedBoostPercent;

	[SerializeField]
	private StatusEffect furnaceUndeadSE;

	private StatusEffect appliedFurnaceUndeadSE;

	private ModuleFurnace furnace;

	public override void ApplyUpgrade()
	{
		ModuleFurnace moduleByType = Train.Instance.GetModuleByType<ModuleFurnace>();
		if ((object)moduleByType != null)
		{
			furnace = moduleByType;
			moduleByType.HealthComponent.OnDeath += delegate
			{
				OnFurnaceDeath();
			};
			moduleByType.HealthComponent.OnRes += delegate
			{
				OnFurnaceRes();
			};
			moduleByType.continueDuringDeath = true;
		}
	}

	private void OnFurnaceDeath()
	{
		appliedFurnaceUndeadSE = furnace.StatsSO.ApplyStatusEffect(furnaceUndeadSE);
		Train.Instance.SpeedChange(speedBoostPercent, isPercent: true);
	}

	private void OnFurnaceRes()
	{
		furnace.StatsSO.RemoveStatusEffect(appliedFurnaceUndeadSE);
		Train.Instance.SpeedChange(0f - speedBoostPercent, isPercent: true);
	}
}
