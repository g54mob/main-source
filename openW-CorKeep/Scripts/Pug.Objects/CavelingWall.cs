using UnityEngine;

public class CavelingWall : EntityMonoBehaviour
{
	public Transform particleSpawnLocation;

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.PotDebris, particleSpawnLocation.position);
		Manager.effects.PlayPuff(PuffID.StoneBlockDebris, particleSpawnLocation.position, 30);
		Manager.effects.PlayPuff(PuffID.StoneBlockDust, particleSpawnLocation.position);
	}
}
