using UnityEngine;

public class CavelingShortWall : EntityMonoBehaviour
{
	public Transform particleSpawnLocation;

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.PotDebris, particleSpawnLocation.position, 3);
		Manager.effects.PlayPuff(PuffID.StoneBlockDebris, particleSpawnLocation.position);
		Manager.effects.PlayPuff(PuffID.StoneBlockDust, particleSpawnLocation.position, 4);
	}
}
