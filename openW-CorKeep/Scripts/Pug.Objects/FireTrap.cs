using System.Collections.Generic;
using Pug.Sprite;
using Pug.UnityExtensions;
using Unity.NetCode;
using UnityEngine;

public class FireTrap : EntityMonoBehaviour
{
	[Header("FireTrap Properties------------------------")]
	public SFXTableIDField burnSoundID;

	public bool playSoundOnGamepad;

	public float deathFadeoutTime = 0.5f;

	private List<AudioManager.RunningSfxReference> _burnSound = new List<AudioManager.RunningSfxReference>();

	private Vector3 _baseLightScale;

	private Vector3 _lightScale;

	private bool _hasPlayedDeathSequence;

	private TimerSimple _lightFadeoutTimer;

	protected override bool skipConditionEffectsHandler => true;

	protected override bool hideDirectlyOnDeath => false;

	protected override void Awake()
	{
		_baseLightScale = indirectLightEmitters[0].transform.localScale;
		_lightFadeoutTimer = new TimerSimple(deathFadeoutTime);
		base.Awake();
	}

	protected override void OnDeath()
	{
		PlayDeathSequence();
	}

	protected override void OnTakeDamage()
	{
	}

	protected override void OnHide()
	{
		base.OnHide();
		PlayDeathSequence();
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		_hasPlayedDeathSequence = false;
		foreach (SpriteObject spriteObject in spriteObjects)
		{
			spriteObject.PlayAnimation(-1878077465);
		}
		_lightScale = _baseLightScale;
		indirectLightEmitters[0].SetActive(value: true);
		indirectLightEmitters[0].transform.localScale = _lightScale;
		_lightFadeoutTimer.Stop();
		AudioManager.Sfx(burnSoundID.value, base.transform.position, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playSoundOnGamepad, _burnSound);
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (_lightFadeoutTimer.isRunning)
		{
			float invElapsedRatio = _lightFadeoutTimer.invElapsedRatio;
			_lightScale = new Vector3(_baseLightScale.x * invElapsedRatio, _baseLightScale.y * invElapsedRatio, 1f);
			indirectLightEmitters[0].transform.localScale = _lightScale;
			if (_lightFadeoutTimer.isTimerElapsed)
			{
				indirectLightEmitters[0].SetActive(value: false);
			}
		}
		if (!_hasPlayedDeathSequence)
		{
			float fraction;
			NetworkTick currentTick = EntityUtility.GetCurrentTickOnClient(base.entity, base.world, out fraction);
			float num = -2f;
			int simulationTickRate = PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate;
			if (EntityUtility.HasComponentData<DestroyTimerCD>(base.entity, base.world))
			{
				num = EntityUtility.GetComponentData<DestroyTimerCD>(base.entity, base.world).timer.GetRemainingSeconds(in currentTick, (uint)simulationTickRate);
			}
			if (num > -1f && num < deathFadeoutTime)
			{
				PlayDeathSequence();
			}
		}
	}

	private void PlayDeathSequence()
	{
		if (_hasPlayedDeathSequence)
		{
			return;
		}
		_lightFadeoutTimer.Start();
		_hasPlayedDeathSequence = true;
		if (_burnSound != null)
		{
			foreach (AudioManager.RunningSfxReference item in _burnSound)
			{
				item.FadeOutAndStop(0.5f);
			}
			_burnSound.Clear();
		}
		foreach (SpriteObject spriteObject in spriteObjects)
		{
			spriteObject.PlayAnimation(-414722770);
		}
	}
}
