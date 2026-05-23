using UnityEngine;

[CreateAssetMenu(fileName = "Slow Effect", menuName = "SimpleSiege/Slow Effect")]
public class SlowEffect : AdditionalWeaponEffectScript
{
	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Percentage)]
	private float slowDuration = 2f;

	public override void Effect(Hp _hpHit, TaggedObject _attacked, TaggedObject _attacker, Weapon _weapon, float _damageMultiplyer, bool targetKilled, float _damageAmount)
	{
		if ((bool)_hpHit.PathfindMovement)
		{
			_hpHit.PathfindMovement.Slow(slowDuration);
		}
	}
}
