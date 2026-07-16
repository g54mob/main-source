using UnityEngine;

[CreateAssetMenu(fileName = "FurnaceFastInefficient", menuName = "Upgrade/Furnace/FastInefficient")]
public class UpgradeFurnaceFastInefficient : EnhancementUpgrade
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
			appliedFurnaceUndeadSE = moduleByType.StatsSO.ApplyStatusEffect(furnaceUndeadSE);
			Train.Instance.SpeedChange(speedBoostPercent, isPercent: true);
		}
	}

	public override void OnRemove()
	{
		base.OnRemove();
		furnace.StatsSO.RemoveStatusEffect(appliedFurnaceUndeadSE);
	}
}
