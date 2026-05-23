using UnityEngine;

[CreateAssetMenu(fileName = "Slow Effect", menuName = "SimpleSiege/Blood Wand Active")]
public class BloodWandActiveAttEffect : AdditionalWeaponEffectScript
{
	[BalancingParameter(BalancingParameter.EType.Percentage)]
	public float healthToDamageRate = 1f;

	[BalancingParameter(BalancingParameter.EType.Percentage)]
	public float playerMinHp = 0.1f;

	[BalancingParameter(BalancingParameter.EType.Default)]
	public float playerSlow = 3f;

	public override void Effect(Hp _hpHit, TaggedObject _attacked, TaggedObject _attacker, Weapon _weapon, float _damageMultiplyer, bool targetKilled, float _damageAmount)
	{
		PlayerMovement.instance.Slow(playerSlow);
		float num = healthToDamageRate;
		Hp hp = PlayerMovement.instance.Hp;
		float a = _hpHit.HpValue / num;
		float b = hp.HpValue - hp.maxHp * playerMinHp;
		float num2 = Mathf.Min(a, b);
		if (!(num2 <= 0f))
		{
			hp.TakeDamage(Mathf.Max(num2, hp.maxHp * 0.05f));
			_hpHit.TakeDamage(num2 * num + 1f);
		}
	}
}
