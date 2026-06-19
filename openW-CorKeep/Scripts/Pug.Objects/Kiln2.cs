using UnityEngine;

public class Kiln2 : EntityMonoBehaviour
{
	public Transform particleSpawnLocation;

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.ClayBlockDebrisBox, particleSpawnLocation.position, 18);
		Manager.effects.PlayPuff(PuffID.ClayBlockDust, particleSpawnLocation.position, 6);
	}
}
