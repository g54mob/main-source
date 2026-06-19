using UnityEngine;

public class LarvaSkewer : EntityMonoBehaviour
{
	public Transform particleSpawnLocation;

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.SlimeExplosion, particleSpawnLocation.position, 30);
	}
}
