using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "SimpleSiege/Cursed Blowpipe Effect")]
public class CurseEffect : AdditionalWeaponEffectScript
{
	[SerializeField]
	private Weapon weaponToDamageEverybody;

	public override void Effect(Hp _hpHit, TaggedObject _attacked, TaggedObject _attacker, Weapon _weapon, float _damageMultiplyer, bool targetKilled, float _damageAmount)
	{
		CurseBlastMA.instance.AddCursedHp(_hpHit, weaponToDamageEverybody, _attacked, _damageMultiplyer);
	}
}
