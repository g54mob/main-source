using UnityEngine;

public class MoldWell : EntityMonoBehaviour
{
	public Transform particleSpawnLocation;

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.PotDebris, particleSpawnLocation.position, 15);
		Manager.effects.PlayPuff(PuffID.StoneBlockDebris, particleSpawnLocation.position, 30);
		Manager.effects.PlayPuff(PuffID.StoneBlockDust, particleSpawnLocation.position);
		Manager.effects.PlayPuff(PuffID.SmallWaterSplash, particleSpawnLocation.position, 30);
		Manager.effects.PlayPuff(PuffID.SmallWhitePuff, particleSpawnLocation.position, 15);
		Manager.effects.PlayPuff(PuffID.SlimeExplosion, particleSpawnLocation.position, 5);
	}
}
