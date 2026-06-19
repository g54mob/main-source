using System;

public class DamageableCreature : ClickHitDummy
{
	public static Action<DamageableCreature> GlobalAnnounceFinishingHit;

	public override void OnFinishingHit()
	{
	}
}
