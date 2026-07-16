using UnityEngine;

[CreateAssetMenu(fileName = "DCFurnaceCoalConsum", menuName = "Upgrade/Mixed/DCFurnaceCoalConsum")]
public class UpgradeDCFurnaceCoalConsum : EnhancementUpgrade
{
	private ModuleDamageControl dc;

	private ModuleFurnace furnace;

	[SerializeField]
	private StatusEffectStats statusEffectFurnaceCoalConsum;

	private StatusEffect appliedSE;

	public override void ApplyUpgrade()
	{
		ModuleFurnace moduleByType = Train.Instance.GetModuleByType<ModuleFurnace>();
		if ((object)moduleByType != null)
		{
			furnace = moduleByType;
		}
		ModuleDamageControl moduleByType2 = Train.Instance.GetModuleByType<ModuleDamageControl>();
		if ((object)moduleByType2 != null)
		{
			dc = moduleByType2;
			dc.Started += StartBuff;
			dc.Ended += EndBuff;
			dc.FullyBroken += EndBuff;
		}
	}

	private void StartBuff()
	{
		SetBuffActive(isActive: true);
	}

	private void EndBuff()
	{
		SetBuffActive(isActive: false);
	}

	private void SetBuffActive(bool isActive)
	{
		if (isActive)
		{
			appliedSE = furnace.StatsSO.ApplyStatusEffect(statusEffectFurnaceCoalConsum);
		}
		else
		{
			furnace.StatsSO.RemoveStatusEffect(appliedSE);
		}
	}
}
