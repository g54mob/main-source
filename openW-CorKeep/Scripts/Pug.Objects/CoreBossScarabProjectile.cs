using UnityEngine;

public class CoreBossScarabProjectile : Projectile
{
	private PoolableAudioSource audioLoop;

	public override void OnOccupied()
	{
		base.OnOccupied();
		audioLoop = AudioManager.SfxFollowTransform(SfxID.cosmicTriangleLoop, base.transform, 0.4f, 1f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: true, 2f);
		bool flag = currentHealth <= 0;
		directionTransform.gameObject.SetActive(!flag);
		if (!flag)
		{
			Vector3 vector = EntityMonoBehaviour.ToRenderFromWorld(spawnWorldPosition);
			Vector3 vector2 = EntityUtility.GetComponentData<ProjectileCD>(base.entity, base.world).GetDirection3() * 0.3f;
			Manager.effects.PlayPuff(PuffID.SmallEnergyExplosion, vector + directionTransform.localPosition + vector2);
		}
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		if ((bool)audioLoop)
		{
			audioLoop.FadeOutAndStop(0.5f);
			audioLoop = null;
		}
	}
}
