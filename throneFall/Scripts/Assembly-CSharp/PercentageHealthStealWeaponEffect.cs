using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "SimpleSiege/Percentage Healthsteal Effect")]
public class PercentageHealthStealWeaponEffect : AdditionalWeaponEffectScript
{
	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Percentage)]
	private float regenPercentage = 0.5f;

	public override void Effect(Hp _hpHit, TaggedObject _attacked, TaggedObject _attacker, Weapon _weapon, float _damageMultiplyer, bool targetKilled, float _damageAmount)
	{
		_attacker.Hp.Heal(_damageAmount * regenPercentage);
	}
}
