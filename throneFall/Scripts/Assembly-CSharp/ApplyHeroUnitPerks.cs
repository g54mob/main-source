using UnityEngine;

public class ApplyHeroUnitPerks : MonoBehaviour
{
	private void Start()
	{
		Hp component = GetComponent<Hp>();
		if (PerkManager.instance.StrongerHeros)
		{
			component.maxHp *= PerkManager.instance.strongerHeros_healthMutli;
			component.DamageMultiplyer *= PerkManager.instance.strongerHeros_damageMulti;
			component.SetHpToMaxHp();
			AutoAttack[] componentsInChildren = GetComponentsInChildren<AutoAttack>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].DamageMultiplyer *= PerkManager.instance.strongerHeros_damageMulti;
			}
		}
	}
}
