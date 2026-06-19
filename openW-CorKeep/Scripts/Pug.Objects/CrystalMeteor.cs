using System.Collections.Generic;
using I2.Loc;
using Pug.Sprite;
using Unity.Entities;
using Unity.NetCode;
using UnityEngine;

public class CrystalMeteor : SummonArea
{
	public Transform spriteParent;

	public SpriteObject cracksSprite;

	public ParticleSystem CrackEffects;

	public ParticleSystem AwakenedEffects;

	public ParticleSystemRenderer BigSphereDissolveObject;

	public Transform destroyparticlePos;

	public float timeBeforeSpeech = 6f;

	public float timePerGlyph = 0.1f;

	public float delayBetweenSpeechStrings = 1f;

	public List<LocalizedString> introSpeechStrings;

	private readonly List<AudioManager.RunningSfxReference> _geigerSound = new List<AudioManager.RunningSfxReference>();

	private readonly List<AudioManager.RunningSfxReference> _activatedSound = new List<AudioManager.RunningSfxReference>();

	private CoreBossSpawnState _prevState;

	private bool _playedCracksAnimation;

	private readonly int m_crack1Event = SpriteAsset.StringToHash("crackfx1");

	private readonly int m_crack2Event = SpriteAsset.StringToHash("crackfx2");

	private readonly int m_crack3Event = SpriteAsset.StringToHash("crackfx3");

	protected override void Awake()
	{
		base.Awake();
		cracksSprite.onAnimationEvent += HandleAnimationEvent;
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		if (EntityUtility.TryGetComponentData<CoreBossSpawnCD>(base.entity, base.world, out var value))
		{
			if (value.state != CoreBossSpawnState.Hidden)
			{
				AudioManager.Sfx(SfxTableID.meteorGeiger, base.transform.position, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, _geigerSound);
			}
			_prevState = value.state;
			spriteParent.gameObject.SetActive(_prevState != CoreBossSpawnState.Hidden);
		}
		_playedCracksAnimation = false;
		cracksSprite.PlayAnimation(-601574123);
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (Manager.main.player == null || !base.entityExist || base.isHidden || !EntityUtility.TryGetComponentData<CoreBossSpawnCD>(base.entity, base.world, out var value))
		{
			return;
		}
		switch (value.state)
		{
		case CoreBossSpawnState.Activated:
			if (_activatedSound == null)
			{
				AudioManager.Sfx(SfxTableID.meteorHumming, base.transform.position, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, _activatedSound);
			}
			if ((bool)AwakenedEffects && !AwakenedEffects.isPlaying)
			{
				AwakenedEffects.Play();
			}
			break;
		case CoreBossSpawnState.Spawning:
			if (_prevState != value.state)
			{
				if ((bool)AwakenedEffects && AwakenedEffects.isPlaying)
				{
					AwakenedEffects.Stop();
				}
				PlayCracksAnimation();
				AudioManager.Sfx(SfxID.rockDebris1, base.transform.position);
				Manager.effects.PlayPuff(PuffID.MeteorDestroyWarmup, destroyparticlePos.transform.position, 1);
			}
			break;
		case CoreBossSpawnState.Hidden:
			if (_prevState != value.state)
			{
				AudioManager.Sfx(SfxTableID.meteorShatter, base.transform.position);
				spriteParent.gameObject.SetActive(value: false);
				ReleaseAudioLoops();
				Manager.effects.PlayPuff(PuffID.MeteorDestroy, destroyparticlePos.transform.position, 1, guaranteedToPlay: true);
				Manager.camera.ShakeCameraNow(2.8f, 0.5f, 0.5f);
			}
			break;
		}
		_prevState = value.state;
	}

	private void PlayCracksAnimation()
	{
		if (!_playedCracksAnimation)
		{
			_playedCracksAnimation = true;
			cracksSprite.PlayAnimation(-1569965903);
		}
	}

	protected override void OnHide()
	{
		ReleaseAudioLoops();
		base.OnHide();
	}

	private void ReleaseAudioLoops()
	{
		foreach (AudioManager.RunningSfxReference item in _geigerSound)
		{
			item.FadeOutAndStop();
		}
		_geigerSound.Clear();
		foreach (AudioManager.RunningSfxReference item2 in _activatedSound)
		{
			item2.FadeOutAndStop();
		}
		_activatedSound.Clear();
	}

	public void OnUse()
	{
		if (!EntityUtility.TryGetComponentData<CoreBossSpawnCD>(base.entity, base.world, out var value) || value.state != CoreBossSpawnState.Activated)
		{
			return;
		}
		PlayCracksAnimation();
		Entity entity = base.world.EntityManager.CreateEntity(typeof(BreakCrystalMeteorRPC), typeof(SendRpcCommandRequest));
		float num = timeBeforeSpeech;
		foreach (LocalizedString introSpeechString in introSpeechStrings)
		{
			num += (float)introSpeechString.ToString().Length * timePerGlyph + delayBetweenSpeechStrings;
		}
		base.world.EntityManager.SetComponentData(entity, new BreakCrystalMeteorRPC
		{
			entity = base.entity,
			introTimeDuration = num
		});
	}

	private void HandleAnimationEvent(int hash)
	{
		if (m_crack1Event == hash)
		{
			CrackEffects.Play();
			Manager.camera.ShakeCameraNow(0.3f);
		}
		else if (m_crack2Event == hash)
		{
			CrackEffects.Play();
			Manager.camera.ShakeCameraNow(0.3f, 1.5f);
		}
		else if (m_crack3Event == hash)
		{
			CrackEffects.Play();
			Manager.camera.ShakeCameraNow(0.4f, 1.5f, 1.5f);
			PlayBrightFlashEffect(2f);
		}
	}
}
