using UnityEngine;

public class MoldVein : EntityMonoBehaviour
{
	protected override void OnDeath()
	{
		base.OnDeath();
		Transform variationsParticleSpawnLocation = GetVariationsParticleSpawnLocation();
		Manager.effects.PlayPuff(PuffID.SmallWhitePuff, variationsParticleSpawnLocation.position);
	}
}
