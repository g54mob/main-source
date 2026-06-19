using System.Collections.Generic;
using Unity.NetCode;
using UnityEngine;

public class VoidOrbGunProjectile : Projectile
{
	private readonly List<AudioManager.RunningSfxReference> _audioLoop = new List<AudioManager.RunningSfxReference>();

	public Transform scalingTransform;

	public override void OnOccupied()
	{
		base.OnOccupied();
		Manager.effects.PlayPuff(PuffID.WhiteSmoke, base.transform.position, 8);
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (base.entityExist)
		{
			float fraction;
			NetworkTick currentTickOnClient = EntityUtility.GetCurrentTickOnClient(base.entity, base.world, out fraction);
			int simulationTickRate = PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate;
			float num = Mathf.Clamp01(0.1f + EntityUtility.GetComponentData<DestroyTimerCD>(base.entity, base.world).timer.GetElapsedSeconds(currentTickOnClient, fraction, (uint)simulationTickRate));
			scalingTransform.localScale = Vector3.one * num;
		}
	}

	protected override void OnShow()
	{
		AudioManager.SfxFollowTransform(SfxTableID.voidOrbGunProjectileLoop, base.transform, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, _audioLoop);
		base.OnShow();
	}

	protected override void OnHide()
	{
		base.OnHide();
		StopAudioLoop();
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
