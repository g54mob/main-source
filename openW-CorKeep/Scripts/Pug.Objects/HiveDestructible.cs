using UnityEngine;

public class HiveDestructible : EntityMonoBehaviour
{
	protected override void OnDeath()
	{
		base.OnDeath();
		Transform variationsParticleSpawnLocation = GetVariationsParticleSpawnLocation();
		int num = base.objectData.variation;
		if (num == 0)
		{
			Manager.effects.PlayPuff(PuffID.BloodSpurt, variationsParticleSpawnLocation.position, 30);
			Manager.effects.PlayTempSprite(SpriteTempEffectID.BloodImpact, base.transform.position + new Vector3(0f, 0.0625f, 0f), 0.5f);
		}
		if (num == 1)
		{
			Manager.effects.PlayPuff(PuffID.BloodSpurt, variationsParticleSpawnLocation.position, 50);
			Manager.effects.PlayTempSprite(SpriteTempEffectID.BloodImpact, base.transform.position + new Vector3(0.45f, 0.0625f, 0f));
		}
	}
}
