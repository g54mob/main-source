using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "SimpleSiege/Healthsteal Effect")]
public class HealthStealWeaponEffect : AdditionalWeaponEffectScript
{
	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Percentage)]
	private float regenTargetHp = 2f;

	public override void Effect(Hp _hpHit, TaggedObject _attacked, TaggedObject _attacker, Weapon _weapon, float _damageMultiplyer, bool targetKilled, float _damageAmount)
	{
		_attacker.Hp.Heal(regenTargetHp);
	}
}
