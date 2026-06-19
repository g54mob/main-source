using UnityEngine;

public class LarvaskinRugRed : EntityMonoBehaviour
{
	public Transform particleSpawnLocation;

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.SlimeExplosion, particleSpawnLocation.position, 30);
	}
}
