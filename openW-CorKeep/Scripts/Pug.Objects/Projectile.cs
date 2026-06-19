using System;
using System.Collections.Generic;
using Unity.Entities;
using Unity.NetCode;
using Unity.Transforms;
using UnityEngine;

public class Projectile : EntityMonoBehaviour
{
	[Serializable]
	public class ProjectileParticleSetting
	{
		public ParticleSystem particleSystem;

		public ParticleQualityAction particleQualityAction;

		[NonSerialized]
		public ParticleSystem.MinMaxCurve particleMinMaxCurve;
	}

	public enum ParticleQualityAction
	{
		DisableParticlesOnLowQuality = 0,
		ReduceParticlesOnLowQuality = 1
	}

	protected Vector3 spawnWorldPosition;

	protected bool hasExploded;

	public Transform SRPivot;

	public Transform directionTransform;

	public bool shouldUpdateDirection;

	public List<ProjectileParticleSetting> projectileParticleSettings;

	private const float particleReductionMultiplier = 0.3f;

	protected override bool skipConditionEffectsHandler => true;

	protected override void Awake()
	{
		base.Awake();
		InitParticlesQuality();
	}

	public override void OnOccupied()
	{
		UpdateParticlesQuality();
		hasExploded = EntityUtility.IsComponentEnabled<EntityDestroyedCD>(base.entity, base.world);
		bool flag = EntityUtility.HasComponentData<PredictedGhost>(base.entity, base.world);
		bool flag2 = EntityUtility.IsNewlyCreatedObject(base.entity, base.world, !flag);
		if (hasExploded && flag2)
		{
			hasExploded = false;
		}
		base.OnOccupied();
		if (flag)
		{
			spawnWorldPosition = EntityUtility.GetComponentData<LocalTransform>(base.entity, base.world).Position;
		}
		else
		{
			ProjectileCD componentData = EntityUtility.GetComponentData<ProjectileCD>(base.entity, base.world);
			float speed = EntityUtility.GetComponentData<MovementSpeedCD>(base.entity, base.world).speed;
			NetworkTick spawnTick = EntityUtility.GetComponentData<GhostInstance>(base.entity, base.world).spawnTick;
			using EntityQuery entityQuery = base.world.EntityManager.CreateEntityQuery(typeof(NetworkTime));
			int num = entityQuery.GetSingleton<NetworkTime>().InterpolationTick.TicksSince(spawnTick);
			spawnWorldPosition = base.WorldPosition - (Vector3)(componentData.GetDirection3() * speed * ((float)num / (float)PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate));
		}
		if (!hasExploded && flag2 && EntityUtility.TryGetComponentData<CustomAttackSoundCD>(base.entity, base.world, out var value) && value.attackSoundId != 0)
		{
			AudioManager.Sfx(value.attackSoundId, base.RenderPosition, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: true);
		}
	}

	private void InitParticlesQuality()
	{
		for (int i = 0; i < projectileParticleSettings.Count; i++)
		{
			ProjectileParticleSetting projectileParticleSetting = projectileParticleSettings[i];
			if (projectileParticleSetting.particleQualityAction == ParticleQualityAction.ReduceParticlesOnLowQuality)
			{
				ParticleSystem.EmissionModule emission = projectileParticleSetting.particleSystem.emission;
				projectileParticleSettings[i].particleMinMaxCurve = emission.rateOverTime;
			}
		}
	}

	private void UpdateParticlesQuality()
	{
		bool flag = Manager.prefs.particleQuality == 0;
		for (int i = 0; i < projectileParticleSettings.Count; i++)
		{
			ProjectileParticleSetting projectileParticleSetting = projectileParticleSettings[i];
			if (projectileParticleSetting.particleQualityAction == ParticleQualityAction.DisableParticlesOnLowQuality)
			{
				projectileParticleSetting.particleSystem.gameObject.SetActive(!flag);
			}
			else if (projectileParticleSetting.particleQualityAction == ParticleQualityAction.ReduceParticlesOnLowQuality)
			{
				ParticleSystem.MinMaxCurve rateOverTime = projectileParticleSetting.particleSystem.emission.rateOverTime;
				if (rateOverTime.mode == ParticleSystemCurveMode.Constant)
				{
					float constant = projectileParticleSetting.particleMinMaxCurve.constant;
					rateOverTime.constant = (flag ? (constant * 0.3f) : constant);
				}
				else if (rateOverTime.mode == ParticleSystemCurveMode.TwoConstants)
				{
					float constantMin = projectileParticleSetting.particleMinMaxCurve.constantMin;
					rateOverTime.constantMin = (flag ? (constantMin * 0.3f) : constantMin);
					float constantMin2 = projectileParticleSetting.particleMinMaxCurve.constantMin;
					rateOverTime.constantMax = (flag ? (constantMin2 * 0.3f) : constantMin2);
				}
				else
				{
					rateOverTime.curveMultiplier = (flag ? 0.3f : 1f);
				}
				ParticleSystem.EmissionModule emission = projectileParticleSetting.particleSystem.emission;
				emission.rateOverTime = rateOverTime;
			}
		}
	}

	protected override void OnShow()
	{
		if (hasExploded)
		{
			if (XScaler != null)
			{
				XScaler.gameObject.SetActive(value: false);
			}
			if (shadow != null)
			{
				shadow.SetActive(value: false);
			}
		}
		else
		{
			if (XScaler != null)
			{
				XScaler.gameObject.SetActive(value: true);
			}
			if (shadow != null)
			{
				shadow.SetActive(value: true);
			}
		}
		base.OnShow();
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (shouldUpdateDirection)
		{
			UpdateProjectileOrientation();
		}
	}

	protected override void OnDeath()
	{
		if (!hasExploded)
		{
			if (EntityUtility.TryGetComponentData<CustomAttackSoundCD>(base.entity, base.world, out var value) && value.impactSoundId != 0)
			{
				AudioManager.Sfx(value.impactSoundId, base.RenderPosition, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: true);
			}
			base.OnDeath();
			hasExploded = true;
		}
	}

	private void UpdateProjectileOrientation()
	{
		if (hasAnimator)
		{
			SetOrientation(EntityUtility.GetComponentData<ProjectileCD>(base.entity, base.world).GetDirection3());
			return;
		}
		Vector3 vector = EntityUtility.GetComponentData<ProjectileCD>(base.entity, base.world).GetDirection3();
		directionTransform.LookAt(directionTransform.position + vector, Vector3.up);
	}
}
