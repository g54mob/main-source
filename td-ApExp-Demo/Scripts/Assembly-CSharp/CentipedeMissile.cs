using System;

public class CentipedeMissile : APCMissile
{
	[NonSerialized]
	public CentipedeArmamentSilo silo;

	protected override void HitDeath()
	{
		silo.OnMissileDeath(this);
		base.HitDeath();
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		silo.OnMissileDeath(this);
		base.OnDeath(info);
	}

	public override void EMP(float duration)
	{
	}
}
