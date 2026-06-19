using UnityEngine;

public class CavelingToilet : SittableObject
{
	public Transform particleSpawnLocation;

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.PotDebris, particleSpawnLocation.position, 5);
		Manager.effects.PlayPuff(PuffID.StoneBlockDebris, particleSpawnLocation.position, 8);
		Manager.effects.PlayPuff(PuffID.DirtBlockDebrisBox, particleSpawnLocation.position, 20);
		Manager.effects.PlayPuff(PuffID.DirtBlockDust, particleSpawnLocation.position);
		Manager.effects.PlayPuff(PuffID.AcidPuff, particleSpawnLocation.position);
	}
}
