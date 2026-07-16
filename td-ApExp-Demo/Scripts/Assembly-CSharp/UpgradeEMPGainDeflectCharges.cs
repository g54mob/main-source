using UnityEngine;

[CreateAssetMenu(fileName = "EMPGainDeflectCharges", menuName = "Upgrade/EMP/GainDeflectCharges")]
public class UpgradeEMPGainDeflectCharges : EnhancementUpgrade
{
	private ModuleDeflect deflect;

	private ModuleEMP emp;

	public override void ApplyUpgrade()
	{
		deflect = Train.Instance.GetModuleByType<ModuleDeflect>();
		emp = Train.Instance.GetModuleByType<ModuleEMP>();
		emp.OnInteractStartEvent += GainDeflectCharges;
	}

	private void GainDeflectCharges()
	{
		deflect.deflectCharges = Mathf.CeilToInt(deflect.GetUpgradedStatValueByStatType(StatTypes.capacity));
	}
}
