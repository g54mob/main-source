using UnityEngine;

public class ValentineCandles : EntityMonoBehaviour
{
	public Transform particleSpawnLocation;

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.DirtBlockDust, base.transform.position, 5);
		Manager.effects.PlayPuff(PuffID.FireFloaters, particleSpawnLocation.position, 8);
		Manager.effects.PlayPuff(PuffID.SmallWhitePuff, particleSpawnLocation.position);
	}
}
