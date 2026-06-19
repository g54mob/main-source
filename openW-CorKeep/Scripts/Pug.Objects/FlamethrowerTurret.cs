using System.Collections.Generic;
using Pug.Automation;
using Pug.UnityExtensions;
using RayAttackState;
using UnityEngine;

public class FlamethrowerTurret : Turret, IRayAttackVisual
{
	public FlamethrowerFX flamethrowerFX;

	public ParticleEffectSpawner sparksFX;

	private TimerSimple flamethrowerStartSoundTimer = new TimerSimple(0.08f);

	private List<AudioManager.RunningSfxReference> beamSoundAudioSources = new List<AudioManager.RunningSfxReference>();

	private bool _islooping;

	public override void OnOccupied()
	{
		base.OnOccupied();
		flamethrowerFX.isOn = false;
	}

	protected override void OnHide()
	{
		base.OnHide();
		DisableBeam();
	}

	public void DisableBeam()
	{
		flamethrowerFX.isOn = false;
		if (beamSoundAudioSources.Count <= 0)
		{
			return;
		}
		AudioManager.SfxFollowTransform(SfxTableID.flamethrowerEndSfx, base.transform);
		foreach (AudioManager.RunningSfxReference beamSoundAudioSource in beamSoundAudioSources)
		{
			beamSoundAudioSource.FadeOutAndStop(0.12f);
		}
		beamSoundAudioSources.Clear();
		flamethrowerStartSoundTimer.Stop();
		_islooping = false;
	}

	public void UpdateBeam(Vector3 fromWorldPos, Vector3 toWorldPos, bool isHittingSomething)
	{
		if (!_islooping)
		{
			if (!flamethrowerStartSoundTimer.isRunning)
			{
				AudioManager.SfxFollowTransform(SfxTableID.flamethrowerStartSfx, base.transform, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, beamSoundAudioSources);
				flamethrowerStartSoundTimer.Start();
			}
			else if (flamethrowerStartSoundTimer.isRunning && flamethrowerStartSoundTimer.isTimerElapsed)
			{
				_islooping = true;
				AudioManager.SfxFollowTransform(SfxTableID.flamethrowerLoopSfx, base.transform, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, beamSoundAudioSources, 1f, 0f, 1f, 0.15f);
			}
		}
		flamethrowerFX.isOn = true;
		flamethrowerFX.isConnected = isHittingSomething;
		flamethrowerFX.originPointWorld = fromWorldPos;
		flamethrowerFX.endPointWorld = toWorldPos;
		flamethrowerFX.UpdatePosition();
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (EntityUtility.TryGetComponentData<ElectricityCD>(base.entity, base.world, out var value) && !value.hasEnoughElectricityToPowerStuff)
		{
			spriteObjects[0].PlayAnimation(-1949102368);
			sparksFX.enabled = false;
		}
		else
		{
			spriteObjects[0].PlayAnimation(1260321794);
			sparksFX.enabled = true;
		}
	}
}
