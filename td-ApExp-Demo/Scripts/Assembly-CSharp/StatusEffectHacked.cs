using UnityEngine;

[CreateAssetMenu(fileName = "StatusEffectHacked", menuName = "Status Effects/Hacked")]
public class StatusEffectHacked : StatusEffect
{
	public override void Apply(Unit unit)
	{
		base.Apply(unit);
		unit.Hack(isHacked: true);
	}

	public override void Expire()
	{
		base.Expire();
		unit.Hack(isHacked: false);
	}
}
