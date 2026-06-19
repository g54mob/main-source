using System;
using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using Pug.Sprite;
using Pug.UnityExtensions;
using PugScan;
using Unity.Collections;
using Unity.Transforms;
using UnityEngine;

public class GiantCicadaBoss : EntityMonoBehaviour
{
	[Serializable]
	public enum GiantCicadaAnimationAttacks
	{
		None = 0,
		ArmSlamLeftFar = 1,
		ArmSlamLeft = 2,
		ArmSlamMiddleClose = 3,
		ArmSlamRight = 4,
		ArmSlamRightFar = 5,
		ArmSlamMiddleFar = 6
	}

	[Serializable]
	public struct GiantCicadaMeleeAttacksList
	{
		public GiantCicadaAnimationAttacks attack;

		public Vector3 position;

		public float animationDuration;

		public float timeUntilImpact;

		public float radius;
	}

	[Header("Hit Effects")]
	public ParticleSystem sandExplosionParticles;

	public ParticleSystem hitPointAniticipationParticles;

	public ParticleSystem clawReleaseFx;

	[Header("Death")]
	public SpriteObject parasiteSpriteObject;

	private readonly List<AudioManager.RunningSfxReference> _parasiteAudioLoop = new List<AudioManager.RunningSfxReference>();

	[Header("Dialogue")]
	public List<PugTextEffectEnunciateSyllables> syllables;

	public List<LocalizedString> outroSpeechStrings;

	public PugText speechText;

	public List<PugText> speechTextOutlines;

	[Header("Other")]
	public Transform animBase;

	public Transform particlePos;

	public List<MeshRenderer> meshesToEnrage;

	public VoidZoneFX voidZoneFX;

	public ParticleSystem spawnParticles;

	public Transform headRotator;

	public float headRotationSpeed = 1.5f;

	public float maxHeadRotation = 20f;

	private bool _hasFullySpawned;

	private int _syncedStage = -1;

	private bool _showParasiteSprite;

	private int _weakpointEnabled;

	private bool _headTrackPlayers = true;

	private GiantCicadaAnimationAttacks _currentAnimationAttack;

	private Quaternion _targetRotation;

	private bool _voidZoneTrigger;

	[SerializeField]
	private MeshRenderer m_HeadRenderer;

	private static int _tintColor = Shader.PropertyToID("_TintColor");

	private bool _fadingOut;

	private float _fadeValue = 1f;

	private bool _resetting;

	private const float BaseAnimationSpeed = 1f;

	public float voidZoneFadeDuration = 3f;

	private float _voidZoneProgress;

	private float _previousSafeZonesRadius;

	[Header("For visually displaying attack positions, system needs to be manually updated")]
	public List<GiantCicadaMeleeAttacksList> attackAnimations;

	public AnimationCurve deadFlashCurve;

	public Flashable leftArmFlashable;

	public Flashable rightArmFlashable;

	public Flashable bodyFlashable;

	public Flashable headFlashable;

	protected override bool hideDirectlyOnDeath => false;

	protected override void Awake()
	{
		base.Awake();
		_showParasiteSprite = false;
		_weakpointEnabled = 0;
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		parasiteSpriteObject.PlayAnimation(-2007111235, forceResetTime: false, skipTransition: true);
		animBase.localPosition = new Vector3(0f, -20f, 0f);
		voidZoneFX.radius = 0f;
		_syncedStage = -1;
		if (EntityUtility.TryGetComponentData<HealthCD>(base.entity, base.world, out var value) && value.health > 0)
		{
			FadeOutSpeechText();
			ResetSpeechText();
		}
	}

	protected override bool AnimationHasHigherOrSamePrioAsTakeDamage(int animID)
	{
		if (animID != 1203776827 && animID != 573175182)
		{
			return base.AnimationHasHigherOrSamePrioAsTakeDamage(animID);
		}
		return true;
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == -414722770)
		{
			_headTrackPlayers = false;
			StopCoroutine(StartAndStopHeadTracking_Coroutine(0f, 0f));
			StopAllCoroutines();
			StartCoroutine(OutroLines_Coroutine());
		}
		SetCurrentAttackID(animID);
		if (animID == 573175182 || animID == -33986332)
		{
			_headTrackPlayers = false;
			StopCoroutine(StartAndStopHeadTracking_Coroutine(0f, 0f));
			hitPointAniticipationParticles.Stop();
			animator.SetTrigger("scream");
		}
		if (animID == 80170468)
		{
			animator.SetTrigger("block");
		}
	}

	protected override void TakeDamageEffect(Vector3 offset)
	{
	}

	protected override void OnTakeDamage()
	{
		base.OnTakeDamage();
		flashable.FlashLinearNoCurve(Color.red);
	}

	private IEnumerator OutroLines_Coroutine()
	{
		yield return new WaitForSeconds(11.5f);
		AE_ParasiteShow();
		float seconds = 3f;
		yield return new WaitForSeconds(seconds);
		for (int i = 0; i < outroSpeechStrings.Count; i++)
		{
			string text = outroSpeechStrings[i].ToString();
			PlayLine(outroSpeechStrings[i]);
			yield return new WaitForSeconds((float)text.Length * 0.1f + 2f);
		}
		FadeOutSpeechText();
		seconds = 1f;
		yield return new WaitForSeconds(seconds);
		parasiteSpriteObject.PlayAnimation(-2007111235);
		AudioManager.Sfx(SfxTableID.giantCicadaDeathParasiteExit, base.transform.position);
		_parasiteAudioLoop.ForEach(delegate(AudioManager.RunningSfxReference audioSource)
		{
			audioSource.FadeOutAndStop(2f);
		});
		_parasiteAudioLoop.Clear();
		seconds = 0.5f;
		yield return new WaitForSeconds(seconds);
		animator.SetTrigger("headExplode");
		ResetSpeechText();
	}

	private void PlayLine(string line)
	{
		speechText.Render(line, rewindEffectAnims: true);
		foreach (PugText speechTextOutline in speechTextOutlines)
		{
			speechTextOutline.Render(line, rewindEffectAnims: true);
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

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		HealthCD componentData = EntityUtility.GetComponentData<HealthCD>(base.entity, base.world);
		EnemyStagesStateCD value;
		bool hasEnemyStages = EntityUtility.TryGetComponentData<EnemyStagesStateCD>(base.entity, base.world, out value);
		GiantCicadaBossCD value2;
		bool hasCicadaBoss = EntityUtility.TryGetComponentData<GiantCicadaBossCD>(base.entity, base.world, out value2);
		UpdateAnimationSpeed(componentData, hasEnemyStages, value);
		UpdateHealthBarColor(hasCicadaBoss, value2);
		HandleEnrageAppearance(value);
		float distance = EntityUtility.GetComponentData<AuraDistanceOverrideCD>(base.entity, base.world).distance;
		if (EntityUtility.GetConditionValue(ConditionID.AuraApplyVoidDamagePercentageOverTime, base.entity, base.world) < 0)
		{
			if (!_voidZoneTrigger)
			{
				_voidZoneTrigger = true;
				AudioManager.Sfx(SfxTableID.giantCicadaVoidAttackSpawn, base.transform.position);
			}
			_voidZoneProgress += Time.deltaTime / voidZoneFadeDuration;
			_voidZoneProgress = Mathf.Clamp01(_voidZoneProgress);
			voidZoneFX.alpha = _voidZoneProgress;
			voidZoneFX.radius = distance;
		}
		else
		{
			if (_voidZoneTrigger)
			{
				_voidZoneTrigger = false;
				AudioManager.Sfx(SfxTableID.coreBossVoidAttackSpawn, base.transform.position);
			}
			_voidZoneProgress -= Time.deltaTime / voidZoneFadeDuration;
			_voidZoneProgress = Mathf.Clamp01(_voidZoneProgress);
			voidZoneFX.alpha = _voidZoneProgress;
			voidZoneFX.radius = Mathf.Max(0f, voidZoneFX.radius - Time.deltaTime * 20f);
		}
		for (int i = 0; i < voidZoneFX.safeZones.Count; i++)
		{
			if (voidZoneFX.safeZones[i].enabled)
			{
				voidZoneFX.safeZones[i].enabled = false;
				voidZoneFX.safeZones[i].radius = 0f;
			}
		}
		NativeArray<CoreBossVoidImmuneZoneBuffer> nativeArray = EntityUtility.GetBuffer<CoreBossVoidImmuneZoneBuffer>(base.entity, base.world).ToNativeArray(Allocator.Temp);
		for (int j = 0; j < nativeArray.Length && j < voidZoneFX.safeZones.Count; j++)
		{
			ObjectDataCD value3;
			bool flag = EntityUtility.TryGetComponentData<ObjectDataCD>(nativeArray[j].zone, base.world, out value3);
			LocalTransform value4;
			bool flag2 = EntityUtility.TryGetComponentData<LocalTransform>(nativeArray[j].zone, base.world, out value4);
			AuraDistanceOverrideCD value5;
			bool flag3 = EntityUtility.TryGetComponentData<AuraDistanceOverrideCD>(nativeArray[j].zone, base.world, out value5);
			voidZoneFX.safeZones[j].enabled = flag && flag2 && flag3 && value3.objectID == ObjectID.CoreBossVoidImmuneZone;
			if (voidZoneFX.safeZones[j].enabled)
			{
				voidZoneFX.safeZones[j].position = EntityMonoBehaviour.ToRenderFromWorld(value4.Position);
				if (value5.distance <= _previousSafeZonesRadius)
				{
					voidZoneFX.safeZones[j].radius = Mathf.Lerp(_previousSafeZonesRadius, value5.distance, Time.deltaTime * 0.25f);
					_previousSafeZonesRadius = voidZoneFX.safeZones[j].radius;
				}
				else
				{
					voidZoneFX.safeZones[j].radius = value5.distance;
					_previousSafeZonesRadius = value5.distance;
				}
			}
		}
		animator.SetInteger("weakpointGlow", _weakpointEnabled);
		if (_headTrackPlayers && value.currentStage > 0)
		{
			List<PlayerController> allPlayers = Manager.main.allPlayers;
			if (allPlayers == null || allPlayers.Count == 0)
			{
				return;
			}
			PlayerController playerController = null;
			float num = float.MaxValue;
			Vector3 vector = Vector3.zero;
			foreach (PlayerController item in allPlayers)
			{
				if (!(item == null))
				{
					Vector3 position = item.transform.position;
					float magnitude = (position.XZ() - base.transform.position.XZ()).magnitude;
					if (magnitude < num)
					{
						playerController = item;
						num = magnitude;
						vector = position;
					}
				}
			}
			if (playerController != null)
			{
				Vector3 normalized = (vector - headRotator.position).normalized;
				normalized.y = 0f;
				if (Mathf.Abs(Vector3.SignedAngle(parasiteSpriteObject.transform.forward, -normalized, Vector3.up)) < maxHeadRotation && vector.y < headRotator.position.y)
				{
					_targetRotation = Quaternion.LookRotation(-normalized);
				}
			}
		}
		else
		{
			_targetRotation = Quaternion.Euler(0f, 0f, 0f);
		}
		headRotator.localRotation = Quaternion.Lerp(headRotator.localRotation, _targetRotation, Time.deltaTime * headRotationSpeed);
	}

	private void UpdateAnimationSpeed(HealthCD healthCD, bool hasEnemyStages, EnemyStagesStateCD enemyStagesStateCD)
	{
		if ((float)healthCD.health > 0f && _currentAnimationAttack != GiantCicadaAnimationAttacks.None)
		{
			if (hasEnemyStages)
			{
				animator.speed = 1f / enemyStagesStateCD.GetMultiplierDecreasingAsHealthDecreases();
			}
		}
		else
		{
			animator.speed = 1f;
		}
	}

	private void UpdateHealthBarColor(bool hasCicadaBoss, GiantCicadaBossCD giantCicadaCD)
	{
		if (!hasCicadaBoss)
		{
			return;
		}
		if (giantCicadaCD.internalState == GiantCicadaBossInternalState.Immune)
		{
			if (_hasFullySpawned)
			{
				optionalHealthBar.healthColor = optionalHealthBar.immuneColor;
			}
			else
			{
				optionalHealthBar.gameObject.SetActive(value: false);
			}
		}
		else
		{
			optionalHealthBar.gameObject.SetActive(value: true);
			optionalHealthBar.showHealthBarAtFullHealth = true;
			optionalHealthBar.healthColor = new Color(1f, 0.239f, 0.239f);
		}
	}

	private void HandleEnrageAppearance(EnemyStagesStateCD enemyStagesStateCD)
	{
		if (_syncedStage == enemyStagesStateCD.currentStage)
		{
			return;
		}
		_syncedStage = enemyStagesStateCD.currentStage;
		MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
		int currentStage = enemyStagesStateCD.currentStage;
		if (currentStage <= 2)
		{
			switch (currentStage)
			{
			case 2:
				SetMesheTintColor(propertyBlock, new Color(1f, 0.8f, 0.8f, 1f));
				break;
			case 1:
				SetMesheTintColor(propertyBlock, new Color(1f, 0.7f, 0.7f, 1f));
				break;
			case 0:
				SetMesheTintColor(propertyBlock, new Color(1f, 0.6f, 0.6f, 1f));
				break;
			}
		}
		else
		{
			SetMesheTintColor(propertyBlock, Color.white);
		}
	}

	private void SetMesheTintColor(MaterialPropertyBlock propertyBlock, Color flashColor)
	{
		propertyBlock.SetColor(_tintColor, flashColor);
		foreach (MeshRenderer item in meshesToEnrage)
		{
			item.SetPropertyBlock(propertyBlock);
		}
	}

	private void ResetSpeechText()
	{
		speechText.Render("", rewindEffectAnims: true);
		foreach (PugText speechTextOutline in speechTextOutlines)
		{
			speechTextOutline.Render("");
		}
	}

	private void SetCurrentAttackID(int animID)
	{
		_currentAnimationAttack = GiantCicadaAnimationAttacks.None;
		if (animID == -1878077465)
		{
			_hasFullySpawned = false;
		}
		if (animID != -1878077465 && animID != -601574123)
		{
			_hasFullySpawned = true;
		}
		switch (animID)
		{
		case -55886041:
			_currentAnimationAttack = GiantCicadaAnimationAttacks.ArmSlamLeftFar;
			break;
		case -290922184:
			_currentAnimationAttack = GiantCicadaAnimationAttacks.ArmSlamLeft;
			break;
		case 1203776827:
			_currentAnimationAttack = GiantCicadaAnimationAttacks.ArmSlamMiddleClose;
			break;
		case -550114330:
			_currentAnimationAttack = GiantCicadaAnimationAttacks.ArmSlamRight;
			break;
		case 267198559:
			_currentAnimationAttack = GiantCicadaAnimationAttacks.ArmSlamRightFar;
			break;
		case -624168705:
			_currentAnimationAttack = GiantCicadaAnimationAttacks.ArmSlamMiddleFar;
			break;
		}
		attackAnimations.ForEach(delegate(GiantCicadaMeleeAttacksList attack)
		{
			if (attack.attack == _currentAnimationAttack)
			{
				hitPointAniticipationParticles.transform.localPosition = attack.position;
				hitPointAniticipationParticles.Play(withChildren: true);
				StartCoroutine(StartAndStopHeadTracking_Coroutine(0.6f, attack.timeUntilImpact * 0.8f));
			}
		});
	}

	private IEnumerator StartAndStopHeadTracking_Coroutine(float stopDelay, float startDelay)
	{
		yield return new WaitForSeconds(stopDelay);
		_headTrackPlayers = false;
		yield return new WaitForSeconds(startDelay);
		_headTrackPlayers = true;
	}

	protected override void OnDeath()
	{
		if (Manager.ui.mapUI.IsShowingShrineMarker(ObjectID.PassageBossStatue))
		{
			Manager.ui.chatWindow.AddInfoText(ChatWindow.MessageTextType.TalkToTheCore);
			base.world.GetExistingSystemManaged<PugScanClientSystem>().Scan(new ScanRequestCD
			{
				objectToScan = new ObjectDataCD
				{
					objectID = ObjectID.PassageBossStatue
				},
				sendResponse = false,
				typeOfRequest = PugScanType.HideMarker
			});
		}
		hitPointAniticipationParticles.Stop();
		animator.speed = 1f;
		MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
		SetMesheTintColor(propertyBlock, Color.white);
		_headTrackPlayers = false;
		_showParasiteSprite = true;
		parasiteSpriteObject.gameObject.SetActive(_showParasiteSprite);
		Manager.camera.ShakeCameraNow(1.5f, 2.5f, 2.5f, null, null, 0, 20f);
		optionalHealthBar.gameObject.SetActive(value: false);
		optionalHealthBar.showHealthBarAtFullHealth = false;
	}

	public void AE_FlashAttack(int attackIndex)
	{
		switch (attackIndex)
		{
		case 0:
			leftArmFlashable.FlashLinearNoCurve(Color.white);
			break;
		case 1:
			leftArmFlashable.FlashLinearNoCurve(Color.white);
			rightArmFlashable.FlashLinearNoCurve(Color.white);
			break;
		case 2:
			rightArmFlashable.FlashLinearNoCurve(Color.white);
			break;
		}
		float pitchMultiplier = 2f - (float)_syncedStage * 0.25f;
		AudioManager.Sfx(SfxTableID.giantCicadaArmSlamAnticipation, base.transform.position, 1f, pitchMultiplier);
	}

	public void AE_FlashLeftArm()
	{
		leftArmFlashable.Flash(deadFlashCurve, Color.white, 0.5f);
	}

	public void AE_FlashRightArm()
	{
		rightArmFlashable.Flash(deadFlashCurve, Color.white, 0.5f);
	}

	public void AE_FlashBody()
	{
		bodyFlashable.Flash(deadFlashCurve, Color.white, 0.5f);
	}

	public void AE_FlashHead()
	{
		headFlashable.Flash(deadFlashCurve, Color.white, 1.2f);
	}

	public void AE_WeakPointExplode()
	{
		Vector3 position = particleOptions.particleSpawnLocations[4].position;
		Manager.effects.PlayPuff(PuffID.GiantCicadaBossDeathBulb, position, 1);
		AudioManager.Sfx(SfxTableID.giantCicadaDeathWeakSpotExplosion, particlePos.position);
	}

	public void AE_LeftArmExplode()
	{
		Vector3 position = particleOptions.particleSpawnLocations[0].position;
		Manager.effects.PlayPuff(PuffID.GiantCicadaBossDeathArm, position, 1);
		AudioManager.Sfx(SfxTableID.giantCicadaDeathArmExplosion, particlePos.position);
	}

	public void AE_RightArmExplode()
	{
		Vector3 position = particleOptions.particleSpawnLocations[1].position;
		Manager.effects.PlayPuff(PuffID.GiantCicadaBossDeathArm, position, 1);
		AudioManager.Sfx(SfxTableID.giantCicadaDeathArmExplosion, particlePos.position);
	}

	public void AE_BodyExplode()
	{
		Vector3 position = particleOptions.particleSpawnLocations[2].position;
		Manager.effects.PlayPuff(PuffID.GiantCicadaBossDeathBody, position, 1);
		AudioManager.Sfx(SfxTableID.giantCicadaDeathBodyExplosion, particlePos.position);
	}

	public void AE_HeadLand()
	{
		Vector3 position = particleOptions.particleSpawnLocations[2].position;
		Manager.effects.PlayPuff(PuffID.DirtImpact, position, 1);
		AudioManager.Sfx(SfxTableID.giantCicadaDeathExplosion, particlePos.position);
	}

	public void AE_HeadExplode()
	{
		Vector3 position = particleOptions.particleSpawnLocations[3].position;
		Manager.effects.PlayPuff(PuffID.GiantCicadaBossDeathHead, position, 1);
		AudioManager.Sfx(SfxTableID.giantCicadaDeathExplosion, particlePos.position);
	}

	public void AE_SetArmShakeRight(int shake)
	{
		animator.SetInteger("armShakeRight", shake);
	}

	public void AE_SetArmShakeLeft(int shake)
	{
		animator.SetInteger("armShakeLeft", shake);
	}

	public void AE_ParasiteShow()
	{
		AudioManager.Sfx(SfxTableID.giantCicadaDeathParasiteAppear, base.transform.position);
		AudioManager.SfxFollowTransform(SfxTableID.giantCicadaDeathParasiteLoop, base.transform, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, _parasiteAudioLoop);
		parasiteSpriteObject.PlayAnimation(-601574123);
	}

	public void AE_ParasiteHide()
	{
		parasiteSpriteObject.PlayAnimation(-2007111235);
	}

	public void AE_SetCameraShake(float time)
	{
		Manager.camera.ShakeCameraNow(time, 0.5f, 2.5f, null, null, 0, 5f);
	}

	public void AE_SpawnFXPlay()
	{
		spawnParticles.Play();
		AudioManager.Sfx(SfxTableID.giantCicadaEmerge, base.transform.position);
	}

	public void AE_SpawnFXStop()
	{
		_hasFullySpawned = true;
		spawnParticles.Stop();
		AudioManager.Sfx(SfxTableID.giantCicadaScream, base.transform.position);
	}

	public void AE_SetWeakpointGlow(int enabled)
	{
		_weakpointEnabled = enabled;
	}

	public void AE_PlaySFXScream()
	{
		hitPointAniticipationParticles.Stop();
		AudioManager.Sfx(SfxTableID.giantCicadaScream, base.transform.position);
		Manager.camera.ShakeCameraNow(3.5f, 2.4f, 2.4f, null, null, 1, 15f);
	}

	public void AE_PlaySFXScreamDeath()
	{
		hitPointAniticipationParticles.Stop();
		AudioManager.Sfx(SfxTableID.giantCicadaDeathScream, base.transform.position);
		Manager.camera.ShakeCameraNow(3.5f, 2.4f, 2.4f, null, null, 1, 15f);
	}

	public void AE_PlaySFXArmSlam()
	{
		hitPointAniticipationParticles.Stop();
		attackAnimations.ForEach(delegate(GiantCicadaMeleeAttacksList attack)
		{
			if (attack.attack == _currentAnimationAttack)
			{
				Manager.camera.ShakeCameraNow(0.3f, 3.5f, 3.5f);
				AudioManager.Sfx(SfxTableID.giantCicadaArmSlam, base.transform.position + attack.position);
				sandExplosionParticles.transform.localPosition = attack.position;
				sandExplosionParticles.Play(withChildren: true);
			}
		});
	}

	public void AE_PlaySFXArmFlex()
	{
		AudioManager.Sfx(SfxTableID.giantCicadaArmFlex, base.transform.position);
	}

	public void AE_PlaySFXActivate()
	{
		AudioManager.Sfx(SfxTableID.giantCicadaActivate, base.transform.position);
	}

	public void AE_PlaySFXHeartbeat()
	{
		AudioManager.Sfx(SfxTableID.giantCicadaHeartbeat, base.transform.position);
	}

	public void AE_PlaySFXDeathAnticipation()
	{
		AudioManager.Sfx(SfxTableID.bossDeathAnticipation, base.transform.position);
	}

	public void AE_ClawReleaseFx()
	{
		attackAnimations.ForEach(delegate(GiantCicadaMeleeAttacksList attack)
		{
			if (attack.attack == _currentAnimationAttack)
			{
				AudioManager.Sfx(SfxTableID.sandDestroy, base.transform.position + attack.position);
				clawReleaseFx.transform.localPosition = attack.position;
				clawReleaseFx.Play(withChildren: true);
			}
		});
	}
}
