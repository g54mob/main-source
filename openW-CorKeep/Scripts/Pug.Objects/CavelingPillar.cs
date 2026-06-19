using UnityEngine;

public class CavelingPillar : EntityMonoBehaviour
{
	public Transform particleSpawnLocation;

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.PotDebris, particleSpawnLocation.position);
		Manager.effects.PlayPuff(PuffID.StoneBlockDebris, particleSpawnLocation.position, 15);
		Manager.effects.PlayPuff(PuffID.StoneBlockDust, particleSpawnLocation.position, 6);
	}
}
