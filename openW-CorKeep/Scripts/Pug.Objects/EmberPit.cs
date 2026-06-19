using UnityEngine;

public class EmberPit : EntityMonoBehaviour
{
	public Transform particleSpawnLocation;

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.PotDebris, particleSpawnLocation.position);
		Manager.effects.PlayPuff(PuffID.StoneBlockDebris, particleSpawnLocation.position, 15);
		Manager.effects.PlayPuff(PuffID.StoneBlockDust, particleSpawnLocation.position, 6);
		Manager.effects.PlayPuff(PuffID.SmallBlackPuff, particleSpawnLocation.position, 15);
		Manager.effects.PlayPuff(PuffID.BlackDebris, particleSpawnLocation.position, 30);
	}
}
