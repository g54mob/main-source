using UnityEngine;

[CreateAssetMenu(fileName = "Slow Effect", menuName = "SimpleSiege/Blood Wand Passive")]
public class BloodWandPassiveAttEffect : AdditionalWeaponEffectScript
{
	public static Hp lastHit = null;

	public static float dmgMulti = 1f;

	private float lastHitTiming;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float dmgIncreasePerSecond = 1.05f;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float maxDmgMulti = 10f;

	public override void Effect(Hp _hpHit, TaggedObject _attacked, TaggedObject _attacker, Weapon _weapon, float _damageMultiplyer, bool targetKilled, float _damageAmount)
	{
		if (_hpHit == lastHit)
		{
			float p = Mathf.Clamp(Time.time - lastHitTiming, 0f, 0.22f);
			lastHitTiming = Time.time;
			dmgMulti *= Mathf.Pow(dmgIncreasePerSecond, p);
			dmgMulti = Mathf.Clamp(dmgMulti, 1f, maxDmgMulti);
			_hpHit.TakeDamage(_damageAmount * _damageMultiplyer * (dmgMulti - 1f));
		}
		else
		{
			lastHit = _hpHit;
			dmgMulti = 1f;
			lastHitTiming = Time.time;
		}
	}
}
