using UnityEngine;

public class PerkCooldownModifyer : MonoBehaviour
{
	public Equippable requiredPerk;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float hpCooldownMultiplyer;

	public AutoAttack autoAttack;

	private void Start()
	{
		if (PerkManager.IsEquipped(requiredPerk))
		{
			autoAttack.cooldownDuration *= hpCooldownMultiplyer;
			autoAttack.recheckTargetInterval *= hpCooldownMultiplyer;
		}
		Object.Destroy(this);
	}
}
