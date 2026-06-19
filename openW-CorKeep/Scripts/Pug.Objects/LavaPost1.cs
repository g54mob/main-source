using UnityEngine;

public class LavaPost1 : EntityMonoBehaviour
{
	public Transform particleSpawnLocation;

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.PotDebris, particleSpawnLocation.position);
		Manager.effects.PlayPuff(PuffID.BlackWoodDebris, particleSpawnLocation.position);
		Manager.effects.PlayPuff(PuffID.StoneBlockDebris, particleSpawnLocation.position, 15);
		Manager.effects.PlayPuff(PuffID.StoneBlockDust, particleSpawnLocation.position, 6);
		Manager.effects.PlayPuff(PuffID.BlackDebris, particleSpawnLocation.position, 15);
	}
}
