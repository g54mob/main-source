using System;
using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using Pug.Sprite;
using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Serialization;

public class CoreBoss : EntityMonoBehaviour
{
	[Serializable]
	public class AvailableEffects
	{
		[FormerlySerializedAs("activeTarget")]
		public PlayerController activeSource;

		public ParticlesTargeting effect;
	}

	private const float SQR_DISTANCE_TO_STEAL_SOULS = 400f;

	public Unity.Mathematics.Random rng;

	public Transform spriteParent;

	public float floatHeight;

	public float floatBobHeight;

	public float floatBobSpeed;

	public ParticleSystem teleportEffects;

	public SpriteObject bodySprite;

	public SpriteObject headSprite;

	public SpriteObject leftArmSprite;

	public SpriteObject rightArmSprite;

	public SpriteObject legsSprite;

	public SpriteObject shadowSprite;

	public DataBlockRef<SpriteAssetSkin> bodySpriteSkinRef;

	public DataBlockRef<SpriteAssetSkin> headSpriteSkinRef;

	public DataBlockRef<SpriteAssetSkin> armSpriteSkinRef;

	public DataBlockRef<SpriteAssetSkin> legsSpriteSkinRef;

	public SpriteObjectAnimationEventEffects leftArmEventEffects;

	public SpriteObjectAnimationEventEffects rightArmEventEffects;

	private List<SpriteObject> allSpriteObjects = new List<SpriteObject>();

	public Animator backRuneAnimator;

	public GameObject backEffects;

	public Transform deathEffectsPosition;

	public ParticleSystem vulnerableParticles;

	public ParticleSystem runeParticles;

	public ParticleSystem explosionAnticipationParticles;

	public ParticleSystem explosionParticles;

	public VoidZoneFX voidZoneFX;

	public Transform orbParticlesTarget;

	public List<ParticlesTargeting> orbTrailParticles;

	public ParticleSystem bossParticles;

	public AnimationCurve fallingAnimationCurve;

	public float fallingAnimationTime;

	public AnimationCurve risingAnimationCurve;

	public float risingAnimationTime;

	public float introRisingAnimationTime;

	public GameObject poweredUpParticles;

	public PugText speechText;

	public List<PugText> speechTextOutlines;

	public List<PugTextEffectEnunciateSyllables> syllables;

	public List<LocalizedString> speechStrings;

	public List<LocalizedString> phaseSpeechStrings;

	public List<LocalizedString> outroSpeechStrings;

	public PugText nameText;

	public LocalizedString phase1Name;

	public LocalizedString phase2Name;

	private bool _isFalling;

	private float _fallingT;

	private float _startVulnerableFloatHeight;

	private float _risingT;

	private float _startRisingFloatHeight;

	private float _currentFloatHeight;

	private bool _initialized;

	private List<PlayerController> playersCurrentlyStealingSoulsFrom = new List<PlayerController>();

	public List<AvailableEffects> empowerBossEffects;

	public Transform stealingSoulsTarget;

	public Flashable CustomFlash;

	public AnimationCurve FlashCurve;

	public AnimationCurve FlashCurveLong;

	public AnimationCurve FlashCurveDeath;

	public AnimationCurve FlashCurveIntro;

	public Color QuickFlashColor;

	private float _voidZoneProgress;

	public float voidZoneFadeDuration = 2f;

	private float _previousSafeZonesRadius;

	private bool _fadingOut;

	private bool _resetting;

	private float _fadeValue = 1f;

	private readonly int m_crack1Event = SpriteAsset.StringToHash("crack1");

	private readonly int m_crack2Event = SpriteAsset.StringToHash("crack2");

	private readonly int m_crack3Event = SpriteAsset.StringToHash("crack3");

	private readonly int m_hitGroundEvent = SpriteAsset.StringToHash("hitGround");

	private readonly int m_unleashEvent = SpriteAsset.StringToHash("unleash");

	private readonly int m_powerUpEvent = SpriteAsset.StringToHash("powerUp");

	private readonly int m_soulPowerupEvent = SpriteAsset.StringToHash("soulPowerup");

	private readonly int m_DieEvent = SpriteAsset.StringToHash("die");

	public SpriteAssetSkin bodySpriteSkin => bodySpriteSkinRef.Get();

	public SpriteAssetSkin headSpriteSkin => headSpriteSkinRef.Get();

	public SpriteAssetSkin armSpriteSkin => armSpriteSkinRef.Get();

	public SpriteAssetSkin legsSpriteSkin => legsSpriteSkinRef.Get();

	protected override bool hideDirectlyOnDeath => false;

	protected override void Awake()
	{
		base.Awake();
		headSprite.onAnimationEvent += HandleAnimationEvent;
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		allSpriteObjects.Clear();
		allSpriteObjects.Add(bodySprite);
		allSpriteObjects.Add(headSprite);
		allSpriteObjects.Add(leftArmSprite);
		allSpriteObjects.Add(rightArmSprite);
		allSpriteObjects.Add(legsSprite);
		rng = PugRandom.GetRng();
		spriteParent.transform.localPosition = new Vector3(0f, 0f, 0f);
		_initialized = false;
		for (int i = 0; i < empowerBossEffects.Count; i++)
		{
			empowerBossEffects[i].activeSource = null;
			empowerBossEffects[i].effect.p.Stop();
		}
		voidZoneFX.radius = 0f;
		spriteParent.gameObject.SetActive(value: true);
		shadow.gameObject.SetActive(value: true);
		nameText.SetText(phase1Name.mTerm);
		if (EntityUtility.TryGetComponentData<HealthCD>(base.entity, base.world, out var value) && value.health > 0)
		{
			FadeOutSpeechText();
			ResetSpeechText();
		}
	}

	protected override void OnHide()
	{
		StopAllCoroutines();
		base.OnHide();
	}

	protected override int GetMaxProtectiveArmor()
	{
		return (int)math.round((float)GetMaxHealth() * 0.3f);
	}

	protected override void OnTakeDamage()
	{
		base.OnTakeDamage();
		flashable.FlashLinearNoCurve(Color.red);
	}

	private void SetArmCastAttackSFX(int sfxTableID)
	{
		if (leftArmEventEffects.effects[1].eventName != "castAttack")
		{
			Debug.LogError("Invalid eventName for index 1 in leftArmEventEffects, should be castAttack unless changed.");
			return;
		}
		if (rightArmEventEffects.effects[1].eventName != "castAttack")
		{
			Debug.LogError("Invalid eventName for index 1 in rightArmEventEffects, should be castAttack unless changed.");
			return;
		}
		leftArmEventEffects.effects[1].sound.value = sfxTableID;
		rightArmEventEffects.effects[1].sound.value = sfxTableID;
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (!base.entityExist)
		{
			return;
		}
		CoreBossCD componentData = EntityUtility.GetComponentData<CoreBossCD>(base.entity, base.world);
		poweredUpParticles.SetActive(componentData.hasObtainedSouls);
		if (!_initialized)
		{
			if (!componentData.hasObtainedSouls)
			{
				optionalHealthBar.gameObject.SetActive(value: false);
				int weakenedLoopAnimHash = Animator.StringToHash("weakenedLoop");
				allSpriteObjects.ForEach(delegate(SpriteObject so)
				{
					if (so.skinRef != null)
					{
						so.skinRef = null;
						so.ApplyVisualChange();
					}
					if (so.currentAnimationHash != weakenedLoopAnimHash && so.HasAnimation(weakenedLoopAnimHash))
					{
						so.PlayAnimation(weakenedLoopAnimHash);
					}
				});
				foreach (PlayerController allPlayer in Manager.main.allPlayers)
				{
					TryPlaySoulEffectStealFromPlayer(allPlayer);
				}
				StartCoroutine(IntroLines_Coroutine());
				CustomFlash.Flash(FlashCurveIntro, Color.white, 15f);
			}
			else if (!_initialized)
			{
				allSpriteObjects.ForEach(delegate(SpriteObject so)
				{
					if (so.currentAnimationHash != -601574123 && so.HasAnimation(-601574123))
					{
						so.PlayAnimation(-601574123);
					}
				});
			}
			_initialized = true;
		}
		UpdateSpeechText();
		UpdateParticlesTargets();
		StateInfoCD componentData2 = EntityUtility.GetComponentData<StateInfoCD>(base.entity, base.world);
		if (componentData2.HasState(StateID.RangeAttack))
		{
			if (EntityUtility.GetComponentData<RangeAttackStateCD>(base.entity, base.world).projectileID == ObjectID.CoreBossWhirlwindProjectile)
			{
				SetArmCastAttackSFX(SfxTableID.coreBossCastAttackOmorothWhirlwinds);
			}
			else
			{
				SetArmCastAttackSFX(SfxTableID.coreBossCastAttackRaAkaarTriangles);
			}
		}
		else if (componentData2.HasState(StateID.CoreBossSpawnBeams))
		{
			SetArmCastAttackSFX(SfxTableID.coreBossCastAttackAzeosBeams);
		}
		bool isInVulnerableState = EntityUtility.GetComponentData<VulnerableStateCD>(base.entity, base.world).isInVulnerableState;
		if (EntityUtility.IsComponentEnabled<EntityDestroyedCD>(base.entity, base.world) || isInVulnerableState)
		{
			if (!_isFalling)
			{
				AudioManager.Sfx(SfxTableID.coreBossFallToGroundPowerDown, base.transform.position);
				_isFalling = true;
				ToggleBackRune(enabled: false);
				QuickFlash();
			}
			_risingT = 0f;
			if (_fallingT == 0f)
			{
				_startVulnerableFloatHeight = _currentFloatHeight;
			}
			_fallingT += Time.deltaTime * (1f / fallingAnimationTime);
			_currentFloatHeight = _startVulnerableFloatHeight * (1f - fallingAnimationCurve.Evaluate(math.min(1f, _fallingT)));
		}
		else
		{
			if (_isFalling)
			{
				_isFalling = false;
			}
			_fallingT = 0f;
			if (_risingT == 0f)
			{
				_startRisingFloatHeight = _currentFloatHeight;
			}
			float num = risingAnimationTime;
			if (!componentData.hasObtainedSouls)
			{
				num = introRisingAnimationTime;
			}
			_risingT += Time.deltaTime * (1f / num);
			_currentFloatHeight = _startRisingFloatHeight + (floatHeight - _startRisingFloatHeight) * risingAnimationCurve.Evaluate(math.min(1f, _risingT));
		}
		float num2 = _currentFloatHeight / floatHeight;
		float num3 = math.sin(Time.time * floatBobSpeed) * floatBobHeight * num2;
		spriteParent.transform.localPosition = new Vector3(0f, _currentFloatHeight + num3 + floatBobHeight, 0f - floatBobHeight);
		if (!componentData.hasObtainedSouls)
		{
			return;
		}
		float distance = EntityUtility.GetComponentData<AuraDistanceOverrideCD>(base.entity, base.world).distance;
		if (EntityUtility.GetConditionValue(ConditionID.AuraApplyVoidDamagePercentageOverTime, base.entity, base.world) < 0)
		{
			voidZoneFX.radius = distance;
			_voidZoneProgress += Time.deltaTime / voidZoneFadeDuration;
			_voidZoneProgress = Mathf.Clamp01(_voidZoneProgress);
			voidZoneFX.alpha = _voidZoneProgress;
		}
		else
		{
			_voidZoneProgress -= Time.deltaTime / voidZoneFadeDuration;
			_voidZoneProgress = Mathf.Clamp01(_voidZoneProgress);
			voidZoneFX.alpha = _voidZoneProgress;
			voidZoneFX.radius = math.max(0f, voidZoneFX.radius - Time.deltaTime * 20f);
		}
		NativeArray<CoreBossVoidImmuneZoneBuffer> nativeArray = EntityUtility.GetBuffer<CoreBossVoidImmuneZoneBuffer>(base.entity, base.world).ToNativeArray(Allocator.Temp);
		for (int num4 = 0; num4 < nativeArray.Length; num4++)
		{
			ObjectDataCD value;
			bool flag = EntityUtility.TryGetComponentData<ObjectDataCD>(nativeArray[num4].zone, base.world, out value);
			LocalTransform value2;
			bool flag2 = EntityUtility.TryGetComponentData<LocalTransform>(nativeArray[num4].zone, base.world, out value2);
			AuraDistanceOverrideCD value3;
			bool flag3 = EntityUtility.TryGetComponentData<AuraDistanceOverrideCD>(nativeArray[num4].zone, base.world, out value3);
			voidZoneFX.safeZones[num4].enabled = flag && flag2 && flag3 && value.objectID == ObjectID.CoreBossVoidImmuneZone;
			if (voidZoneFX.safeZones[num4].enabled)
			{
				voidZoneFX.safeZones[num4].position = EntityMonoBehaviour.ToRenderFromWorld(value2.Position);
				if (value3.distance <= _previousSafeZonesRadius)
				{
					voidZoneFX.safeZones[num4].radius = Mathf.Lerp(_previousSafeZonesRadius, value3.distance, Time.deltaTime * 0.25f);
					_previousSafeZonesRadius = voidZoneFX.safeZones[num4].radius;
				}
				else
				{
					voidZoneFX.safeZones[num4].radius = value3.distance;
					_previousSafeZonesRadius = value3.distance;
				}
			}
		}
		if (EntityUtility.HasComponentData<PhaseTransitionStateCD>(base.entity, base.world))
		{
			PhaseTransitionStateCD componentData3 = EntityUtility.GetComponentData<PhaseTransitionStateCD>(base.entity, base.world);
			bool num5 = componentData3.currentSyncedPhase == componentData3.GetCurrentPhase((float)currentHealth / (float)GetMaxHealth());
			bool active = num5 && !componentData3.isInvulnerable;
			optionalHealthBar.gameObject.SetActive(active);
			bool flag4 = num5 && componentData3.currentSyncedPhase == 1 && headSprite.currentAnimationHash != -33986332;
			ApplySkin(bodySprite, flag4, bodySpriteSkin);
			ApplySkin(headSprite, flag4, headSpriteSkin);
			ApplySkin(leftArmSprite, flag4, armSpriteSkin);
			ApplySkin(rightArmSprite, flag4, armSpriteSkin);
			ApplySkin(legsSprite, flag4, legsSpriteSkin);
			ApplySkin(shadowSprite, flag4, legsSpriteSkin);
			nameText.SetText(flag4 ? phase2Name.mTerm : phase1Name.mTerm);
		}
		nativeArray.Dispose();
		UpdateOrbParticles();
	}

	private static void ApplySkin(SpriteObject spriteObject, bool isSecondPhase, SpriteAssetSkin skin)
	{
		SpriteAssetSkin spriteAssetSkin = (isSecondPhase ? skin : null);
		if (!(spriteObject.skinRef == spriteAssetSkin))
		{
			spriteObject.skinRef = spriteAssetSkin;
			spriteObject.ApplyVisualChange();
		}
	}

	private void TryPlaySoulEffectStealFromPlayer(PlayerController player)
	{
		if (player == null || player.entity == Entity.Null || player.currentHealth <= 0 || playersCurrentlyStealingSoulsFrom.Contains(player) || !EntityUtility.HasCollectedAllSouls(player.entity, player.world) || !((player.transform.position - base.transform.position).sqrMagnitude < 400f))
		{
			return;
		}
		playersCurrentlyStealingSoulsFrom.Add(player);
		int num = -1;
		for (int i = 0; i < empowerBossEffects.Count; i++)
		{
			if (empowerBossEffects[i].activeSource == null)
			{
				num = i;
				empowerBossEffects[i].activeSource = player;
				break;
			}
		}
		if (num != -1)
		{
			StartCoroutine(SoulEffect_Coroutine(player, num));
		}
	}

	private IEnumerator SoulEffect_Coroutine(PlayerController player, int effectIndex)
	{
		yield return new WaitForSeconds(5f);
		empowerBossEffects[effectIndex].effect.p.Play(withChildren: true);
		AudioManager.SfxFollowTransform(SfxID.powerUp, base.transform, 0.8f, 0.85f);
		if (player == null)
		{
			empowerBossEffects[effectIndex].effect.p.Stop(withChildren: true);
			empowerBossEffects[effectIndex].activeSource = null;
			playersCurrentlyStealingSoulsFrom.Remove(player);
			yield break;
		}
		player.flashableComponent.FlashLinearNoCurve(5f);
		yield return new WaitForSeconds(3f);
		empowerBossEffects[effectIndex].effect.p.Stop(withChildren: true);
		if (player == null)
		{
			empowerBossEffects[effectIndex].activeSource = null;
			playersCurrentlyStealingSoulsFrom.Remove(player);
		}
		else
		{
			yield return new WaitForSeconds(3f);
			playersCurrentlyStealingSoulsFrom.Remove(player);
			empowerBossEffects[effectIndex].activeSource = null;
		}
	}

	private void UpdateParticlesTargets()
	{
		foreach (AvailableEffects empowerBossEffect in empowerBossEffects)
		{
			if (empowerBossEffect.activeSource != null)
			{
				empowerBossEffect.effect.transform.position = empowerBossEffect.activeSource.center;
				empowerBossEffect.effect.Target.position = stealingSoulsTarget.position;
			}
		}
	}

	private IEnumerator IntroLines_Coroutine()
	{
		yield return new WaitForSeconds(14f);
		for (int i = 0; i < speechStrings.Count; i++)
		{
			string text = speechStrings[i].ToString();
			PlayLine(speechStrings[i]);
			yield return new WaitForSeconds((float)text.Length * 0.1f + 1f);
		}
		FadeOutSpeechText();
	}

	private IEnumerator PhaseLines_Coroutine()
	{
		yield return new WaitForSeconds(8f);
		for (int i = 0; i < phaseSpeechStrings.Count; i++)
		{
			string text = phaseSpeechStrings[i].ToString();
			PlayLine(phaseSpeechStrings[i]);
			yield return new WaitForSeconds((float)text.Length * 0.1f + 1f);
		}
		FadeOutSpeechText();
	}

	private IEnumerator OutroLines_Coroutine()
	{
		float seconds = 4f;
		yield return new WaitForSeconds(seconds);
		for (int i = 0; i < outroSpeechStrings.Count; i++)
		{
			string text = outroSpeechStrings[i].ToString();
			PlayLine(outroSpeechStrings[i]);
			yield return new WaitForSeconds((float)text.Length * 0.1f + 1f);
		}
		FadeOutSpeechText();
		seconds = 5f;
		Vector3 position = deathEffectsPosition.position;
		explosionAnticipationParticles.Play();
		AudioManager.Sfx(SfxTableID.coreBossDeathAnticipation, position);
		CustomFlash.Flash(FlashCurveDeath, Color.white, seconds);
		yield return new WaitForSeconds(seconds);
		position = deathEffectsPosition.position;
		explosionParticles.Play();
		Manager.effects.PlayPuff(PuffID.AncientEnergyRing, position, 8);
		AudioManager.Sfx(SfxTableID.coreBossDeathExplosion, position);
		Manager.camera.ShakeCameraNow(1.5f, 2.5f, 2.5f);
		spriteParent.gameObject.SetActive(value: false);
		shadow.gameObject.SetActive(value: false);
	}

	private void UpdateSpeechText()
	{
		if (!_fadingOut)
		{
			return;
		}
		for (int i = 0; i < speechText.glyphs.Count; i++)
		{
			speechText.glyphs[i].SetAlpha(_fadeValue);
		}
		foreach (PugText speechTextOutline in speechTextOutlines)
		{
			for (int j = 0; j < speechTextOutline.glyphs.Count; j++)
			{
				speechTextOutline.glyphs[j].SetAlpha(_fadeValue);
			}
		}
		if (_fadeValue <= 0f)
		{
			_fadeValue = 1f;
			_fadingOut = false;
			if (_resetting)
			{
				ResetSpeechText();
			}
		}
		_fadeValue = Mathf.Clamp01(_fadeValue - Time.deltaTime * 2f);
	}

	private void ResetSpeechText()
	{
		speechText.Render("", rewindEffectAnims: true);
		foreach (PugText speechTextOutline in speechTextOutlines)
		{
			speechTextOutline.Render("");
		}
	}

	private void PlayLine(LocalizedString line)
	{
		speechText.Render(line.mTerm, rewindEffectAnims: true);
		foreach (PugText speechTextOutline in speechTextOutlines)
		{
			speechTextOutline.Render(line.mTerm, rewindEffectAnims: true);
		}
	}

	private void FadeOutSpeechText(bool reset = true)
	{
		_fadingOut = true;
		_resetting = reset;
		foreach (PugTextEffectEnunciateSyllables syllable in syllables)
		{
			syllable.StopPlaying();
		}
	}

	private void UpdateOrbParticles()
	{
		if (!EntityUtility.TryGetBuffer(base.entity, base.world, out DynamicBuffer<CoreBossOrbsBuffer> value))
		{
			return;
		}
		bool flag = false;
		for (int i = 0; i < value.Length; i++)
		{
			EntityMonoBehaviour entityMono = Manager.memory.GetEntityMono(value[i].orb);
			if (entityMono != null)
			{
				orbTrailParticles[i].transform.position = entityMono.transform.position + new Vector3(0f, 0.5f, 0f);
				orbTrailParticles[i].Target = orbParticlesTarget;
				bool flag2 = entityMono.currentHealth > 0;
				if (!orbTrailParticles[i].p.isPlaying && flag2)
				{
					orbTrailParticles[i].p.Play(withChildren: true);
				}
				else if (orbTrailParticles[i].p.isPlaying && !flag2)
				{
					orbTrailParticles[i].p.Stop(withChildren: true);
				}
				flag = flag || flag2;
			}
		}
		if (!bossParticles.isPlaying && flag)
		{
			bossParticles.Play(withChildren: true);
		}
		else if (bossParticles.isPlaying && !flag)
		{
			bossParticles.Stop(withChildren: true);
		}
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (!base.entityExist)
		{
			return;
		}
		if (!EntityUtility.GetComponentData<CoreBossCD>(base.entity, base.world).hasObtainedSouls)
		{
			if (animID == Animator.StringToHash("soulPowerup"))
			{
				allSpriteObjects.ForEach(delegate(SpriteObject so)
				{
					if (so.HasAnimation(animID))
					{
						so.PlayAnimation(animID);
					}
				});
			}
			if (animID == Animator.StringToHash("coreBossSpawnOrbs"))
			{
				leftArmSprite.PlayAnimation(1494526215);
				rightArmSprite.PlayAnimation(1494526215);
			}
			return;
		}
		if (animID == -601574123 || animID == 425101933 || animID == -2008574808 || animID == -33986332 || animID == -414722770)
		{
			if (animID == -414722770)
			{
				StopAllCoroutines();
				StartCoroutine(OutroLines_Coroutine());
			}
			allSpriteObjects.ForEach(delegate(SpriteObject so)
			{
				if (so.HasAnimation(animID))
				{
					so.PlayAnimation(animID);
				}
			});
		}
		else if (animID == -1498481396)
		{
			allSpriteObjects.ForEach(delegate(SpriteObject so)
			{
				if (so.HasAnimation(-78586100))
				{
					so.PlayAnimation(-78586100);
				}
			});
		}
		if (animID == -1014102059 || animID == 1494526215)
		{
			(rng.NextBool() ? leftArmSprite : rightArmSprite).PlayAnimation(1494526215);
		}
		if (animID == -621508332)
		{
			leftArmSprite.PlayAnimation(-621508332);
			rightArmSprite.PlayAnimation(-621508332);
		}
	}

	private void HandleAnimationEvent(int hash)
	{
		if (m_hitGroundEvent == hash)
		{
			vulnerableParticles.Play();
			Manager.camera.ShakeCameraNow(0.3f);
		}
		else if (m_crack1Event == hash || m_crack2Event == hash || m_crack3Event == hash)
		{
			Manager.camera.ShakeCameraNow(0.3f, 1.5f);
			QuickFlash();
		}
		else if (m_unleashEvent == hash)
		{
			StopAllCoroutines();
			StartCoroutine(PhaseLines_Coroutine());
			Manager.camera.ShakeCameraNow(0.8f, 1.5f, 1.5f);
			LongFlash();
			StartCoroutine(DeferredActivateBackRune());
		}
		else if (m_powerUpEvent == hash)
		{
			ToggleBackRune(enabled: true);
		}
		else if (m_soulPowerupEvent != hash && m_DieEvent == hash)
		{
			Manager.camera.ShakeCameraNow(0.8f, 1.5f, 1.5f);
			LongFlash();
		}
	}

	private void ToggleBackRune(bool enabled)
	{
		if (enabled)
		{
			runeParticles.Play();
			backRuneAnimator.ResetTrigger("shrink");
			backRuneAnimator.SetTrigger("grow");
		}
		else
		{
			backRuneAnimator.ResetTrigger("grow");
			backRuneAnimator.SetTrigger("shrink");
		}
	}

	private IEnumerator DeferredActivateBackRune()
	{
		yield return Yielders.WaitForEndOfFrame();
		if (backEffects != null)
		{
			backEffects.SetActive(value: true);
		}
		ToggleBackRune(enabled: true);
	}

	private void QuickFlash()
	{
		CustomFlash.Flash(FlashCurve, QuickFlashColor, 0.65f);
	}

	private void LongFlash()
	{
		CustomFlash.Flash(FlashCurveLong, Color.white, 4f);
	}

	public override void Spawn(Entity entity, EntityManager entityManager)
	{
		Manager.memory.ReserveObjects(ObjectID.CoreBossWhirlwindProjectile, 15);
		Manager.memory.ReserveObjects(ObjectID.CoreBossScarabProjectile, 3);
		Manager.memory.ReserveObjects(ObjectID.CoreBossBeam, 40);
		Manager.memory.ReserveObjects(ObjectID.CoreBossElectricProjectile, 40);
		base.Spawn(entity, entityManager);
	}

	public override void Despawn(Entity entity, EntityManager entityManager)
	{
		Manager.memory.UnreserveObjects(ObjectID.CoreBossWhirlwindProjectile);
		Manager.memory.UnreserveObjects(ObjectID.CoreBossScarabProjectile);
		Manager.memory.UnreserveObjects(ObjectID.CoreBossBeam);
		Manager.memory.UnreserveObjects(ObjectID.CoreBossElectricProjectile);
		base.Despawn(entity, entityManager);
	}
}
