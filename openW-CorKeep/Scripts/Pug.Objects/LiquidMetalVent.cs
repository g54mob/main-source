using UnityEngine;

public class LiquidMetalVent : EntityMonoBehaviour
{
	public Transform particleSpawnLocation;

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.PotDebris, particleSpawnLocation.position);
		Manager.effects.PlayPuff(PuffID.LiquidMetalVentBreak, particleSpawnLocation.position, 15);
		Manager.effects.PlayPuff(PuffID.SmallWhitePuff, particleSpawnLocation.position, 15);
	}
}
