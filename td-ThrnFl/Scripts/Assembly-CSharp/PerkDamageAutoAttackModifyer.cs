using UnityEngine;

public class PerkDamageAutoAttackModifyer : MonoBehaviour
{
	[SerializeField]
	private Equippable perk;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float damageMultiplyer;

	private void Start()
	{
		if (PerkManager.instance.CurrentlyEquipped.Contains(perk))
		{
			AutoAttack[] componentsInChildren = GetComponentsInChildren<AutoAttack>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].DamageMultiplyer *= damageMultiplyer;
			}
		}
		Object.Destroy(this);
	}
}
