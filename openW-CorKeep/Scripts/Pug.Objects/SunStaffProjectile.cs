using System.Collections.Generic;
using UnityEngine;

public class SunStaffProjectile : Projectile
{
	public GameObject indirectLightObject;

	private readonly List<AudioManager.RunningSfxReference> _audioLoop = new List<AudioManager.RunningSfxReference>();

	public override void OnOccupied()
	{
		base.OnOccupied();
		if (currentHealth > 0)
		{
			EntityMonoBehaviour.ToRenderFromWorld(spawnWorldPosition);
			Vector3 vector = EntityUtility.GetComponentData<ProjectileCD>(base.entity, base.world).GetDirection3() * 0.3f;
			Manager.effects.PlayPuff(PuffID.SmallFireExplosion, particleOptions.particleSpawnLocations[0].position + vector);
			if ((bool)indirectLightObject)
			{
				indirectLightObject.gameObject.SetActive(value: true);
			}
		}
	}

	protected override void OnShow()
	{
		AudioManager.SfxFollowTransform(SfxTableID.sunStaffProjectileLoop, base.transform, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, _audioLoop);
		base.OnShow();
	}

	protected override void OnHide()
	{
		StopAudioLoop();
		base.OnHide();
	}

	private void StopAudioLoop()
	{
		foreach (AudioManager.RunningSfxReference item in _audioLoop)
		{
			item.Stop();
		}
		_audioLoop.Clear();
	}

	public override void OnFree()
	{
		base.OnFree();
		StopAudioLoop();
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == 16528305)
		{
			StopAudioLoop();
		}
	}
}
