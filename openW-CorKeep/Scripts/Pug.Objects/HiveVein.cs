using UnityEngine;

public class HiveVein : EntityMonoBehaviour
{
	protected override void OnDeath()
	{
		base.OnDeath();
		Transform variationsParticleSpawnLocation = GetVariationsParticleSpawnLocation();
		Manager.effects.PlayPuff(PuffID.BloodSpurt, variationsParticleSpawnLocation.position);
	}
}
