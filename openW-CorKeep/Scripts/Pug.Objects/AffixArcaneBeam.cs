using System.Collections.Generic;
using RayAttackState;
using UnityEngine;

public class AffixArcaneBeam : EntityMonoBehaviour, IRayAttackVisual
{
	public GameObject projectileSprite;

	public MagicBeamFX magicBeamFX;

	public ParticleSystem zapSystem;

	private List<AudioManager.RunningSfxReference> loopingSfx = new List<AudioManager.RunningSfxReference>();

	public override void OnOccupied()
	{
		base.OnOccupied();
		if (currentHealth > 0)
		{
			projectileSprite.SetActive(value: false);
		}
		AudioManager.Sfx(SfxTableID.magicBeamStartSfx, base.transform.position, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, null, forceStackable: false, 1f, 0f, 1f, 0.02f);
		AudioManager.Sfx(SfxTableID.magicBeamLoopSfx, base.transform.position, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, loopingSfx, forceStackable: false, 1f, 0f, 1f, 0.15f);
		magicBeamFX.isOn = false;
		EntityUtility.TryGetComponentData<SpawnTickCD>(base.entity, base.world, out var _);
		if (HasRecentlySpawned() && zapSystem != null)
		{
			AffixVisualUtilities.TryTriggerInitialZap(zapSystem, base.entity, base.world, AffixID.AffixArcaneBeam);
		}
	}

	public override void OnFree()
	{
		base.OnFree();
		if (loopingSfx != null)
		{
			foreach (AudioManager.RunningSfxReference item in loopingSfx)
			{
				item.FadeOutAndStop();
			}
			loopingSfx.Clear();
		}
		zapSystem.Stop();
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		AudioManager.Sfx(SfxTableID.magicBeamEndSfx, base.transform.position);
		if (loopingSfx != null)
		{
			foreach (AudioManager.RunningSfxReference item in loopingSfx)
			{
				item.FadeOutAndStop();
			}
			loopingSfx.Clear();
		}
		zapSystem.Stop();
	}

	public void DisableBeam()
	{
		magicBeamFX.isOn = false;
	}

	public void UpdateBeam(Vector3 fromWorldPos, Vector3 toWorldPos, bool isHittingSomething)
	{
		projectileSprite.SetActive(value: true);
		magicBeamFX.isOn = true;
		magicBeamFX.isConnected = isHittingSomething;
		magicBeamFX.originPointWorld = fromWorldPos;
		magicBeamFX.endPointWorld = toWorldPos;
		magicBeamFX.UpdatePosition();
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		AffixVisualUtilities.TryUpdateZap(zapSystem, base.entity, base.world, AffixID.AffixArcaneBeam);
	}
}
