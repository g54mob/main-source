using UnityEngine;

public class CavelingThrone : SittableObject
{
	public Transform particleSpawnLocation;

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.PotDebris, particleSpawnLocation.position, 15);
		Manager.effects.PlayPuff(PuffID.StoneBlockDebris, particleSpawnLocation.position, 30);
		Manager.effects.PlayPuff(PuffID.StoneBlockDust, particleSpawnLocation.position);
	}
}
