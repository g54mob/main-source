using UnityEngine;

public class ValentineRug : EntityMonoBehaviour
{
	public Transform particleSpawnLocation;

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.PinkLeafDebris, particleSpawnLocation.position, 12);
		Manager.effects.PlayPuff(PuffID.WhiteFur, particleSpawnLocation.position, 4);
	}
}
