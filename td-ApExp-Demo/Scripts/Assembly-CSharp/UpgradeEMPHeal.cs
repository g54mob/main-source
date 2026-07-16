using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "EMPHeal", menuName = "Upgrade/Mixed/EMPHeal")]
public class UpgradeEMPHeal : EnhancementUpgrade
{
	[SerializeField]
	private float repairAmount = 1f;

	private ModuleEMP emp;

	public override void ApplyUpgrade()
	{
		emp = Train.Instance.GetModuleByType<ModuleEMP>();
		EnemyManager.Instance.EnemyEMPd += OnEnemyEMPd;
	}

	private void OnEnemyEMPd(EnemyBase enemy)
	{
		Module[] array = Train.Instance.Modules.Where((Module m) => m).ToArray();
		for (int num = 0; num < array.Length; num++)
		{
			Health healthComponent = array[num].HealthComponent;
			healthComponent.ChangeHealthWithInfo(new HealthChangeInfo(emp, healthComponent, repairAmount, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.Healing));
		}
	}
}
