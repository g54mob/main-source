using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "SimpleSiege/Godly Curse Effect")]
public class GodlyCurseEffect : AdditionalWeaponEffectScript
{
	public override void Effect(Hp _hpHit, TaggedObject _attacked, TaggedObject _attacker, Weapon _weapon, float _damageMultiplyer, bool targetKilled, float _damageAmount)
	{
		if (PlayerUpgradeManager.instance.godlyCurse && _damageAmount > 0f)
		{
			UpgradeGodlyCurse.instance.Damage(_hpHit);
		}
	}
}
