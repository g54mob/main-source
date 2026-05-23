using UnityEngine;

public class PerkDamageModifyerPlayerunitAuto : MonoBehaviour
{
	private void Start()
	{
		PerkManager instance = PerkManager.instance;
		if (instance.ArcherySkillsActive)
		{
			AutoAttack[] componentsInChildren = GetComponentsInChildren<AutoAttack>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].ProjectileSpeedMultiplyer *= instance.archerySkills_projectileSpeedMulti;
			}
		}
		if (instance.WarriorModeActive)
		{
			AutoAttack[] componentsInChildren = GetComponentsInChildren<AutoAttack>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].DamageMultiplyer *= instance.warriorModeAllyDmgMulti;
			}
			HotOilTower[] componentsInChildren2 = GetComponentsInChildren<HotOilTower>(includeInactive: true);
			for (int i = 0; i < componentsInChildren2.Length; i++)
			{
				componentsInChildren2[i].DamageMultiplyer *= instance.warriorModeAllyDmgMulti;
			}
			BarricadeDamage[] componentsInChildren3 = GetComponentsInChildren<BarricadeDamage>(includeInactive: true);
			for (int i = 0; i < componentsInChildren3.Length; i++)
			{
				componentsInChildren3[i].DamageMultiplyer *= instance.warriorModeAllyDmgMulti;
			}
		}
		if (instance.CommanderModeActive)
		{
			AutoAttack[] componentsInChildren = GetComponentsInChildren<AutoAttack>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].DamageMultiplyer *= instance.commanderModeAllyDmgMulti;
			}
			HotOilTower[] componentsInChildren2 = GetComponentsInChildren<HotOilTower>(includeInactive: true);
			for (int i = 0; i < componentsInChildren2.Length; i++)
			{
				componentsInChildren2[i].DamageMultiplyer *= instance.commanderModeAllyDmgMulti;
			}
			BarricadeDamage[] componentsInChildren3 = GetComponentsInChildren<BarricadeDamage>(includeInactive: true);
			for (int i = 0; i < componentsInChildren3.Length; i++)
			{
				componentsInChildren3[i].DamageMultiplyer *= instance.commanderModeAllyDmgMulti;
			}
		}
		Object.Destroy(this);
	}
}
