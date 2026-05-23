using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "SimpleSiege/Heal on Kill Effect")]
public class HealOnKillWeaponEffect : AdditionalWeaponEffectScript
{
	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private float healOnKill = 10f;

	[SerializeField]
	private bool applyPlayerSelfHealMulti;

	public override void Effect(Hp _hpHit, TaggedObject _attacked, TaggedObject _attacker, Weapon _weapon, float _damageMultiplyer, bool targetKilled, float _damageAmount)
	{
		if (targetKilled)
		{
			if (applyPlayerSelfHealMulti)
			{
				_attacker.Hp.Heal(healOnKill * PlayerUpgradeManager.instance.PlayerHealthRegenerationMultiplyer);
			}
			else
			{
				_attacker.Hp.Heal(healOnKill);
			}
		}
	}
}
