using UnityEngine;

public class CavelingChair : SittableObject
{
	public Transform particleSpawnLocation;

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.PotDebris, particleSpawnLocation.position, 5);
		Manager.effects.PlayPuff(PuffID.StoneBlockDebris, particleSpawnLocation.position, 12);
		Manager.effects.PlayPuff(PuffID.StoneBlockDust, particleSpawnLocation.position, 6);
	}
}
