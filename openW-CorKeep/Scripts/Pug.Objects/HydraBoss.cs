using System;
using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Mathematics;
using UnityEngine;

public class HydraBoss : EntityMonoBehaviour
{
	[Serializable]
	public struct HydraData
	{
		public ObjectID objectID;

		public HydraBossBodyController controller;

		public GameObject container;

		public LocalizedString name;
	}

	public Color enragedColor;

	public ParticleSystem explodeDirtParticles;

	public ParticleSystem explodeWaterParticles;

	public ParticleSystem explodeGhostParticles;

	public ParticleSystem baseDirtParticles;

	public GameObject baseWaterAffector;

	public ParticleSystem baseGhostParticles;

	public ParticleSystem burrowDirtParticles;

	public ParticleSystem burrowVoidParticles;

	public ParticleSystem scatterParticles;

	public ParticleSystem burrowWaterParticles;

	private readonly List<AudioManager.RunningSfxReference> _digAudioLoop = new List<AudioManager.RunningSfxReference>();

	private readonly List<AudioManager.RunningSfxReference> _voidDigAudioLoop = new List<AudioManager.RunningSfxReference>();

	private readonly List<AudioManager.RunningSfxReference> _digWaterAudioLoop = new List<AudioManager.RunningSfxReference>();

	private float _digAudioLoopDefaultVolume;

	private float _digWaterAudioLoopDefaultVolume;

	private readonly float sqDistanceToRender = 1600f;

	public ElectricBeamFX damagingBeam;

	public EnergyBeamFX defaultEnergyBeam;

	public EnergyBeamFX voidEnergyBeam;

	private EnergyBeamFX _energyBeam;

	public PugText nameText;

	private TileTypeColorLookupSystem m_colorLookupSystem;

	private float m_beamStartTime = -1f;

	private bool m_isVulnerable;

	private bool m_inWater;

	private bool m_inPit;

	private bool m_emerging;

	private float _voidPoolLerpTimer;

	public List<HydraData> hydraTypesData;

	private Dictionary<ObjectID, HydraData> _hydraTypesDataDict;

	private HydraData _activeHydra;

	public List<ParticleSystem> particlesToReduceOnLowQuality;

	private List<ParticleSystem.MinMaxCurve> particlesRateOverTimeDefaultValues;

	private List<ParticleSystem.MinMaxCurve> particlesRateOverDistanceDefaultValues;

	private const float particleReductionMultiplier = 0.1f;

	private float m_lastDamageTime;

	private bool wasShootingBeam;

	private float m_beamEndTime;

	protected override bool hideDirectlyOnDeath => false;

	private bool m_isGhost
	{
		get
		{
			if (EntityUtility.TryGetComponentData<HydraBossCD>(base.entity, base.world, out var value))
			{
				return value.isGhost;
			}
			return false;
		}
	}

	public HydraData GetActiveHydraData()
	{
		return _hydraTypesDataDict[base.objectData.objectID];
	}

	protected override int GetMaxProtectiveArmor()
	{
		return (int)math.round((float)GetMaxHealth() * 0.3f);
	}

	protected override void Awake()
	{
		base.Awake();
		_hydraTypesDataDict = new Dictionary<ObjectID, HydraData>();
		for (int i = 0; i < hydraTypesData.Count; i++)
		{
			_hydraTypesDataDict.Add(hydraTypesData[i].objectID, hydraTypesData[i]);
		}
		InitParticlesQuality();
	}

	public override void OnOccupied()
	{
		UpdateHydraToBeActive();
		_activeHydra = GetActiveHydraData();
		_activeHydra.controller.isVisible = false;
		_activeHydra.controller.EnableSegments();
		nameText.SetText(_activeHydra.name.mTerm);
		nameText.Render();
		wasShootingBeam = false;
		m_colorLookupSystem = base.world.GetExistingSystemManaged<TileTypeColorLookupSystem>();
		_digAudioLoopDefaultVolume = AudioManager.GetVolume(SfxTableID.hydraBossMovingBeneathGroundLoop, 0);
		_digWaterAudioLoopDefaultVolume = AudioManager.GetVolume(SfxTableID.hydraBossMovingBeneathWaterLoop, 0);
		StopLoopingDiggingSounds();
		UpdateParticlesQuality();
		if (EntityUtility.TryGetComponentData<HydraBossCD>(base.entity, base.world, out var value))
		{
			bool flag = IsCurrentHydraVoid() || value.isVoid;
			_energyBeam = (flag ? voidEnergyBeam : defaultEnergyBeam);
			voidEnergyBeam.gameObject.SetActive(flag);
			defaultEnergyBeam.gameObject.SetActive(!flag);
			m_emerging = true;
			burrowVoidParticles.gameObject.SetActive(IsCurrentHydraVoid());
			base.OnOccupied();
		}
	}

	private bool IsCurrentHydraVoid()
	{
		return _activeHydra.objectID == ObjectID.HydraBossVoid;
	}

	private void InitParticlesQuality()
	{
		particlesRateOverTimeDefaultValues = new List<ParticleSystem.MinMaxCurve>(particlesToReduceOnLowQuality.Count);
		particlesRateOverDistanceDefaultValues = new List<ParticleSystem.MinMaxCurve>(particlesToReduceOnLowQuality.Count);
		for (int i = 0; i < particlesToReduceOnLowQuality.Count; i++)
		{
			ParticleSystem.EmissionModule emission = particlesToReduceOnLowQuality[i].emission;
			particlesRateOverTimeDefaultValues.Add(emission.rateOverTime);
			particlesRateOverDistanceDefaultValues.Add(emission.rateOverDistance);
		}
	}

	private void UpdateParticlesQuality()
	{
		bool flag = Manager.prefs.particleQuality == 0;
		for (int i = 0; i < particlesToReduceOnLowQuality.Count; i++)
		{
			ParticleSystem.MinMaxCurve minMaxCurve = particlesRateOverTimeDefaultValues[i];
			ParticleSystem.MinMaxCurve rateOverTime = particlesToReduceOnLowQuality[i].emission.rateOverTime;
			if (rateOverTime.mode == ParticleSystemCurveMode.Constant)
			{
				float constant = minMaxCurve.constant;
				rateOverTime.constant = (flag ? (constant * 0.1f) : constant);
			}
			else if (rateOverTime.mode == ParticleSystemCurveMode.TwoConstants)
			{
				float constantMin = minMaxCurve.constantMin;
				rateOverTime.constantMin = (flag ? (constantMin * 0.1f) : constantMin);
				float constantMin2 = minMaxCurve.constantMin;
				rateOverTime.constantMax = (flag ? (constantMin2 * 0.1f) : constantMin2);
			}
			else
			{
				rateOverTime.curveMultiplier = (flag ? 0.1f : 1f);
			}
			minMaxCurve = particlesRateOverDistanceDefaultValues[i];
			ParticleSystem.MinMaxCurve rateOverDistance = particlesToReduceOnLowQuality[i].emission.rateOverDistance;
			if (rateOverDistance.mode == ParticleSystemCurveMode.Constant)
			{
				float constant2 = minMaxCurve.constant;
				rateOverDistance.constant = (flag ? (constant2 * 0.1f) : constant2);
			}
			else if (rateOverDistance.mode == ParticleSystemCurveMode.TwoConstants)
			{
				float constantMin3 = minMaxCurve.constantMin;
				rateOverDistance.constantMin = (flag ? (constantMin3 * 0.1f) : constantMin3);
				float constantMin4 = minMaxCurve.constantMin;
				rateOverDistance.constantMax = (flag ? (constantMin4 * 0.1f) : constantMin4);
			}
			else
			{
				rateOverDistance.curveMultiplier = (flag ? 0.1f : 1f);
			}
			ParticleSystem.EmissionModule emission = particlesToReduceOnLowQuality[i].emission;
			emission.rateOverTime = rateOverTime;
		}
	}

	public override void OnFree()
	{
		_activeHydra.controller.ResetVisibility();
		base.OnFree();
	}

	private bool IsTileWaterButNotLava(SinglePugMap.TileLayerLookup lookup, int2 worldPosition)
	{
		bool result = lookup.HasTile(worldPosition, TileType.water);
		if (lookup.TryGetTileInfo(worldPosition, TileType.water, out var tileInfo) && tileInfo.tileset == 3)
		{
			result = false;
		}
		return result;
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (!base.entityExist)
		{
			return;
		}
		PlayerController player = Manager.main.player;
		if (player == null)
		{
			return;
		}
		_activeHydra.controller.isVisible = (lastAnim != -414722770 || !m_isGhost) && lastAnim != -696149821 && lastAnim != 296338006;
		HydraBossBodyController controller = _activeHydra.controller;
		if (!EntityUtility.TryGetComponentData<HydraBossCD>(base.entity, base.world, out var value))
		{
			return;
		}
		SinglePugMap.TileLayerLookup tileLayerLookup = Manager.multiMap.GetTileLayerLookup();
		int2 worldPosition = base.WorldPosition.RoundToInt2();
		m_inWater = IsTileWaterButNotLava(tileLayerLookup, worldPosition);
		m_inPit = tileLayerLookup.HasTile(worldPosition, TileType.pit);
		controller.inWater = m_inWater;
		controller.inPit = m_inPit;
		ParticleSystem.EmissionModule emission = burrowDirtParticles.emission;
		ParticleSystem.EmissionModule emission2 = burrowVoidParticles.emission;
		ParticleSystem.EmissionModule emission3 = scatterParticles.emission;
		ParticleSystem.EmissionModule emission4 = burrowWaterParticles.emission;
		bool flag = Manager.prefs.particleQuality == 0;
		if (math.distancesq(player.RenderPosition, base.RenderPosition) > sqDistanceToRender)
		{
			StopLoopingDiggingSounds();
			emission.rateOverDistance = 0f;
			emission3.rateOverDistance = 0f;
			damagingBeam.isOn = false;
			_energyBeam.enabled = false;
			optionalHealthBar.gameObject.SetActive(value: false);
			emission2.rateOverDistance = 0f;
			return;
		}
		emission.rateOverDistance = 0f;
		emission2.rateOverDistance = 0f;
		emission3.rateOverDistance = 0f;
		emission4.rateOverDistance = 0f;
		if (!m_inPit && currentHealth > 0)
		{
			if (m_inWater)
			{
				emission4.rateOverDistance = (flag ? 20 : 50);
			}
			else
			{
				emission.rateOverDistance = 20f;
				if (flag)
				{
					emission.rateOverDistance = 10f;
				}
				emission3.rateOverDistance = (flag ? 1 : 2);
				if (IsCurrentHydraVoid())
				{
					emission2.rateOverDistance = 3f;
				}
			}
		}
		controller.isGhost = value.isGhost;
		controller.isVoid = IsCurrentHydraVoid() || value.isVoid;
		float3 pointToLookAt = value.pointToLookAt;
		if (math.any(pointToLookAt != float3.zero))
		{
			_activeHydra.controller.transform.LookAt(EntityMonoBehaviour.ToRenderFromWorld(pointToLookAt), Vector3.up);
		}
		UpdateDamagingBeam(value);
		UpdateConditionEffects();
		optionalHealthBar.gameObject.SetActive(controller.isVisible && !value.isGhost);
		if (!controller.isVisible && currentHealth > 0)
		{
			if (_digAudioLoop.Count == 0)
			{
				AudioManager.SfxFollowTransform(SfxTableID.hydraBossMovingBeneathGroundLoop, base.transform, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, _digAudioLoop);
				if (IsCurrentHydraVoid())
				{
					AudioManager.SfxFollowTransform(SfxTableID.voidHydraMovingBeneathGroundLoopSfx, base.transform, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, _voidDigAudioLoop);
				}
			}
			if (_digWaterAudioLoop.Count == 0)
			{
				AudioManager.SfxFollowTransform(SfxTableID.hydraBossMovingBeneathWaterLoop, base.transform, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, _digWaterAudioLoop);
			}
			UpdateDiggingVolumes();
		}
		else
		{
			StopLoopingDiggingSounds();
		}
		m_isVulnerable = EntityUtility.GetConditionEffectValue(ConditionEffect.ProtectiveArmor, base.entity, base.world) <= 0;
		controller.lastDamageTime = m_lastDamageTime;
		Color flashColor = (m_isVulnerable ? Color.red : Color.yellow);
		flashColor.a = (flashable.enabled ? (flashable.flashEffect.currentFlashAmount * 0.25f) : 0f);
		controller.flashColor = flashColor;
		controller.pulseAmplitude = (m_isVulnerable ? 0f : 0.1f);
		if (IsCurrentHydraVoid())
		{
			UpdateVoidPoolEffect();
		}
	}

	private void UpdateVoidPoolEffect()
	{
		_voidPoolLerpTimer += Time.deltaTime;
		float num = 1.2f;
		float t = Mathf.PingPong(_voidPoolLerpTimer, num) / num;
		float num2 = Mathf.Lerp(0.7f, 1f, t);
		burrowVoidParticles.transform.localScale = new Vector3(num2, num2, num2);
	}

	private void UpdateHydraToBeActive()
	{
		ObjectID objectID = base.objectData.objectID;
		for (int i = 0; i < hydraTypesData.Count; i++)
		{
			hydraTypesData[i].container.SetActive(hydraTypesData[i].objectID == objectID);
		}
	}

	protected override void OnTakeDamage()
	{
		base.OnTakeDamage();
		if (m_isVulnerable)
		{
			m_lastDamageTime = Time.time;
		}
		if (_activeHydra.objectID == ObjectID.HydraBossVoid)
		{
			soundOptions.takeDamageSfx.value = SfxTableID.voidHydraTakeDamageSfx;
		}
		else
		{
			soundOptions.takeDamageSfx.value = SfxTableID.hydraBossTakeDamage;
		}
	}

	private void UpdateDamagingBeam(HydraBossCD hydraBossCD)
	{
		HydraBossBodyController controller = GetActiveHydraData().controller;
		if (hydraBossCD.isShootingBeam)
		{
			SinglePugMap.TileLayerLookup tileLayerLookup = Manager.multiMap.GetTileLayerLookup();
			if (m_beamStartTime < 0f)
			{
				m_beamStartTime = Time.time;
			}
			_energyBeam.enabled = Time.time > m_beamStartTime + 0.5f;
			int2 worldPosition = _energyBeam.endPointWorld.RoundToInt2();
			bool flag = tileLayerLookup.HasTile(worldPosition, TileType.pit);
			_energyBeam.isCharging = flag || Time.time < m_beamStartTime + 2.1f;
			_energyBeam.isImpactingWater = IsTileWaterButNotLava(tileLayerLookup, worldPosition);
			controller.lookAtWeight = Mathf.Clamp01(Time.time - m_beamStartTime);
			controller.lookAtPointWorld = _energyBeam.endPointWorld;
			wasShootingBeam = true;
			m_beamEndTime = Time.time;
		}
		else
		{
			float num = Time.time - m_beamEndTime;
			_energyBeam.isCharging = true;
			controller.lookAtWeight = 0f;
			_energyBeam.enabled = num < 0.4f;
			m_beamStartTime = -1f;
			if (wasShootingBeam)
			{
				wasShootingBeam = false;
				HandleAnimationTrigger(-1225563461);
			}
			controller.StopAnyBeamLoop();
		}
		if (_energyBeam.enabled)
		{
			_energyBeam.originPointWorld = controller.controlPoints[controller.controlPoints.Count - 1].position.ToWorld();
			_energyBeam.endPointWorld = hydraBossCD.beamTargetPoint;
			_energyBeam.originPointWorld += (_energyBeam.endPointWorld - _energyBeam.originPointWorld).normalized;
		}
		_energyBeam.UpdateBeam();
	}

	private void UpdateConditionEffects()
	{
		Transform transform = GetActiveHydraData().controller.head.conditionEffectReferencePoint.transform;
		conditionEffectsHandler.transform.rotation = transform.rotation;
		conditionEffectsHandler.transform.position = transform.position;
		bool active = transform.position.y > 2f;
		conditionEffectsHandler.gameObject.SetActive(active);
	}

	protected override void TakeDamageEffect(Vector3 offset)
	{
	}

	protected override void HandleInitialAnimationTrigger(int animID)
	{
		base.HandleInitialAnimationTrigger(animID);
		HandleTrigger(animID);
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		HandleTrigger(animID);
	}

	protected override bool ShouldPlayAnimTrigger(int animID)
	{
		if (lastAnim == -414722770 || (lastAnim == 1819704882 && animID == -601574123) || (lastAnim == 425101933 && animID != -2008574808 && animID != -414722770))
		{
			return false;
		}
		return base.ShouldPlayAnimTrigger(animID);
	}

	private void HandleTrigger(int animID)
	{
		if (!ShouldPlayAnimTrigger(animID))
		{
			return;
		}
		HydraData activeHydraData = GetActiveHydraData();
		if (animID == -696149821)
		{
			if (m_inWater)
			{
				AudioManager.Sfx(SfxTableID.hydraBossSubmergeIntoWater, base.transform.position);
				explodeWaterParticles.Play(withChildren: true);
			}
			else
			{
				AudioManager.Sfx(SfxTableID.hydraBossSubmergeIntoGround, base.transform.position);
				explodeDirtParticles.Play(withChildren: true);
			}
			baseWaterAffector.SetActive(value: false);
			baseDirtParticles.Stop();
			baseGhostParticles.Stop();
			WaterSim.AddImpulse(base.transform.position, 1f, 20f);
			m_emerging = false;
			_voidPoolLerpTimer = 0f;
		}
		else if (animID == -1664757979)
		{
			PlayEmergeEffects();
			m_emerging = true;
			_voidPoolLerpTimer = 0f;
		}
		else if (animID == -414722770 && m_isGhost)
		{
			baseWaterAffector.SetActive(value: false);
			baseDirtParticles.Stop();
			baseGhostParticles.Stop();
		}
		else
		{
			activeHydraData.controller.SetTrigger(animID);
		}
		if (animID == 1819704882)
		{
			PlayEmergeEffects();
			m_emerging = true;
		}
		if (animID == -1014102059)
		{
			AudioManager.Sfx(SfxID.MagicBuildup, base.transform.position, 0.5f, 1.2f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 20f);
		}
	}

	private void PlayEmergeEffects()
	{
		if (m_isGhost)
		{
			AudioManager.Sfx(SfxTableID.hydraBossEmergeGhost, base.transform.position);
			explodeGhostParticles.Play(withChildren: true);
			baseGhostParticles.Play();
			baseWaterAffector.SetActive(value: false);
		}
		else if (IsCurrentHydraVoid())
		{
			AudioManager.Sfx(SfxTableID.voidHydraEmergeSfx, base.transform.position);
		}
		else if (m_inPit)
		{
			AudioManager.Sfx(SfxTableID.hydraBossEmergeFromGround, base.transform.position);
		}
		else if (m_inWater)
		{
			AudioManager.Sfx(SfxTableID.hydraBossEmergeFromWater, base.transform.position);
			explodeWaterParticles.Play(withChildren: true);
			baseWaterAffector.SetActive(value: true);
			WaterSim.AddImpulse(base.transform.position, 1f, 20f);
		}
		else
		{
			AudioManager.Sfx(SfxTableID.hydraBossEmergeFromGround, base.transform.position);
			explodeDirtParticles.Play(withChildren: true);
			baseDirtParticles.Play();
		}
	}

	private void UpdateDiggingVolumes()
	{
		float volume = (m_inWater ? 0f : _digAudioLoopDefaultVolume);
		float volume2 = (m_inWater ? _digWaterAudioLoopDefaultVolume : 0f);
		foreach (AudioManager.RunningSfxReference item in _digAudioLoop)
		{
			item.SetVolume(volume);
		}
		foreach (AudioManager.RunningSfxReference item2 in _digWaterAudioLoop)
		{
			item2.SetVolume(volume2);
		}
	}

	private void StopLoopingDiggingSounds()
	{
		foreach (AudioManager.RunningSfxReference item in _digAudioLoop)
		{
			item.FadeOutAndStop(0.25f);
		}
		_digAudioLoop.Clear();
		foreach (AudioManager.RunningSfxReference item2 in _voidDigAudioLoop)
		{
			item2.FadeOutAndStop(0.25f);
		}
		_voidDigAudioLoop.Clear();
		foreach (AudioManager.RunningSfxReference item3 in _digWaterAudioLoop)
		{
			item3.FadeOutAndStop(0.25f);
		}
		_digWaterAudioLoop.Clear();
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		StopLoopingDiggingSounds();
		GetActiveHydraData().controller.isVisible = true;
		if (!m_isGhost)
		{
			StartCoroutine(PlayDeathExplosions());
		}
		if (_activeHydra.objectID == ObjectID.HydraBossVoid)
		{
			soundOptions.takeDamageSfx.value = SfxTableID.voidHydraDeathSfx;
		}
		else
		{
			soundOptions.takeDamageSfx.value = SfxTableID.hydraBossDeath;
		}
	}

	public IEnumerator PlayDeathExplosions()
	{
		PuffID burstId = base.objectData.objectID switch
		{
			ObjectID.HydraBossSea => PuffID.HydraDeathIce, 
			ObjectID.HydraBossDesert => PuffID.HydraDeathLava, 
			ObjectID.HydraBossVoid => PuffID.HydraDeathVoid, 
			_ => PuffID.HydraDeathNature, 
		};
		yield return new WaitForSeconds(5f);
		GetActiveHydraData().controller.PlayDeathExplosions(burstId);
		baseDirtParticles.Stop();
		baseGhostParticles.Stop();
	}
}
