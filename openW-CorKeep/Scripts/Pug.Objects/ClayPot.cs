using UnityEngine;

public class ClayPot : EntityMonoBehaviour
{
	public Transform particleSpawnLocation;

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.BrownPotDebris, particleSpawnLocation.position, 20);
		Manager.effects.PlayPuff(PuffID.ClayBlockDebrisBox, particleSpawnLocation.position);
		Manager.effects.PlayPuff(PuffID.ClayBlockDust, particleSpawnLocation.position, 6);
	}
}
