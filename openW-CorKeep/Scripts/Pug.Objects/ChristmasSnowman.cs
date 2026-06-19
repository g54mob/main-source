using UnityEngine;

public class ChristmasSnowman : EntityMonoBehaviour
{
	public Transform particleSpawnLocation;

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.SmallWhitePuff, particleSpawnLocation.position, 15);
	}
}
