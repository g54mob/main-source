using System;
using System.Collections;
using System.Collections.Generic;
using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class WallBoss : EntityMonoBehaviour
{
	private const float SHAKE_MAX_SPEED_FACTOR = 3f;

	[Header("WALL BOSS")]
	public Transform mainSegment;

	public Transform supportSegment;

	public ParticleSystem bodyParticles;

	public ParticleSystem deathParticles;

	public ParticleSystem rageParticles;

	public ParticleSystem smokeParticles;

	public WaterSimAffector waterAffector;

	public Transform[] animationBones;

	public Renderer[] fadeableRenderers;

	public AnimationCurve shakeIntensityCurve;

	[Header("Rolling")]
	public float rollRadius = 1f;

	[Min(0f)]
	public int rollFps = 12;

	[Header("Death Sequence")]
	public float deathInitialPause = 0.5f;

	public float deathWaitForHead = 3f;

	public float deathDeflateDuration = 5f;

	public float deathFadeDuration = 1f;

	private WallBossMovementState m_movementState;

	private float m_currentSpeed;

	private float m_baseSpeed;

	private float m_maxSpeed;

	private Vector3 m_velocity;

	private Vector3 m_prevPosition;

	private int m_prevAnimationFrame;

	private Vector3 m_startLocalPosition;

	private Quaternion m_currentRotation;

	private float[] m_timeOffsets;

	private ParticleSystem.EmissionModule m_bodyParticlesEmission;

	private float m_maxBodyParticlesRateOverTime;

	private int? m_segmentNumber;

	private bool m_isDead;

	private TimerSimple audioLoopUpdateTimer = new TimerSimple(0.15f);

	private TimerSimple screenShakeUpdateTimer = new TimerSimple(0.15f);

	private PoolableAudioSource _earthquakeAudioLoop;

	private List<Material> m_fadeableMaterials;

	private static readonly int _Alpha = Shader.PropertyToID("_Alpha");

	private ParticleSystem.EmissionModule m_rageParticleEmission;

	private ParticleSystem.EmissionModule m_smokeParticleEmission;

	protected override bool hideDirectlyOnDeath => false;

	protected override void Awake()
	{
		base.Awake();
		m_bodyParticlesEmission = bodyParticles.emission;
		m_maxBodyParticlesRateOverTime = m_bodyParticlesEmission.rateOverTime.constant;
		m_startLocalPosition = mainSegment.localPosition;
		m_currentRotation = UnityEngine.Random.rotation;
		supportSegment.localRotation = UnityEngine.Random.rotation;
		m_timeOffsets = new float[animationBones.Length];
		for (int i = 0; i < m_timeOffsets.Length; i++)
		{
			m_timeOffsets[i] = UnityEngine.Random.value;
		}
		m_fadeableMaterials = new List<Material>();
		for (int j = 0; j < fadeableRenderers.Length; j++)
		{
			Renderer renderer = fadeableRenderers[j];
			m_fadeableMaterials.Add(renderer.material);
		}
		m_rageParticleEmission = rageParticles.emission;
		m_smokeParticleEmission = smokeParticles.emission;
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		m_movementState = WallBossMovementState.Decelerating;
		m_currentSpeed = 0f;
		m_segmentNumber = null;
		audioLoopUpdateTimer.Start();
		_earthquakeAudioLoop = AudioManager.SfxFollowTransform(SfxID.EarthquakeLoop, base.transform, 1f, 1f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: true, 60f, 30f);
		m_isDead = false;
		if ((bool)deathParticles)
		{
			deathParticles.Stop();
		}
	}

	public override void OnFree()
	{
		base.OnFree();
		StopAudioLoopsAndTimers();
	}

	private void StopAudioLoopsAndTimers()
	{
		audioLoopUpdateTimer.Stop();
		if (_earthquakeAudioLoop != null)
		{
			_earthquakeAudioLoop.FadeOutAndStop();
			_earthquakeAudioLoop = null;
		}
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (EntityUtility.TryGetComponentData<WallBossCD>(base.entity, base.world, out var value))
		{
			if (value.isMainEntity)
			{
				XScaler.gameObject.SetActive(value: false);
				StopAudioLoopsAndTimers();
				if (EntityUtility.TryGetComponentData<WallBossCD>(base.entity, base.world, out var value2))
				{
					m_movementState = value2.movementState;
					m_baseSpeed = value2.baseSpeed;
					m_maxSpeed = value2.maxSpeed;
					m_currentSpeed = value2.currentSpeed;
				}
				UpdateScreenShake();
				return;
			}
			if (EntityUtility.TryGetComponentData<WallBossCD>(value.mainEntity, base.world, out var value3))
			{
				m_movementState = value3.movementState;
				m_baseSpeed = value3.baseSpeed;
				m_maxSpeed = value3.maxSpeed;
				m_currentSpeed = value3.currentSpeed;
			}
			m_segmentNumber = value.segmentNumber;
		}
		base.transform.rotation = CalculateClockwiseAngleFromDirection(EntityMonoBehaviour.ToWorldFromRender(base.transform.position));
		UpdateEarthquakeAudio(value);
		UpdateRotations();
		if (!m_isDead)
		{
			UpdatePositions(value);
			SetRenderersAlpha(1f);
		}
		float num = 0f;
		if (!m_isDead)
		{
			float num2 = (m_currentSpeed - m_baseSpeed) / (m_maxSpeed - m_baseSpeed);
			float num3 = 4f;
			num = Mathf.Clamp01(Mathf.Floor(num2 * num3) / (num3 - 1f));
		}
		bool flag = Manager.prefs.particleQuality != 0;
		if (rageParticles.gameObject.activeSelf != flag)
		{
			rageParticles.gameObject.SetActive(flag);
		}
		if (smokeParticles.gameObject.activeSelf != flag)
		{
			smokeParticles.gameObject.SetActive(flag);
		}
		if (bodyParticles.gameObject.activeSelf != flag)
		{
			bodyParticles.gameObject.SetActive(flag);
		}
		if (flag)
		{
			m_rageParticleEmission.rateOverTime = 50f * num;
			m_smokeParticleEmission.rateOverTime = 40f;
			m_bodyParticlesEmission.rateOverTime = math.min(m_maxBodyParticlesRateOverTime, m_currentSpeed * 10f);
		}
	}

	private void FixedUpdate()
	{
		Vector3 vector = base.transform.position.ToWorld();
		m_velocity = (vector - m_prevPosition) / Time.fixedDeltaTime;
		m_prevPosition = vector;
	}

	private static quaternion CalculateClockwiseAngleFromDirection(float3 direction)
	{
		float num = Mathf.Atan2(direction.x, direction.z) * 57.29578f;
		return Quaternion.Euler(0f, num - 90f, 0f);
	}

	private void UpdateRotations()
	{
		int num = Mathf.FloorToInt(Time.time * (float)rollFps);
		float num2 = MathF.PI * 2f * rollRadius;
		m_currentRotation = Quaternion.Euler(Vector3.Cross(Vector3.up, m_velocity * 360f * 2f / num2) * Time.deltaTime) * m_currentRotation;
		if (num != m_prevAnimationFrame || rollFps == 0)
		{
			mainSegment.rotation = m_currentRotation;
			for (int i = 0; i < animationBones.Length; i++)
			{
				float num3 = math.pow(1.2f, i);
				Transform obj = animationBones[i];
				float num4 = 1f + Mathf.Cos((Time.time * 0.25f * num3 + m_timeOffsets[i]) * 2f * MathF.PI) * 0.2f;
				obj.localScale = new Vector3(num4, num4, num4);
			}
		}
		m_prevAnimationFrame = num;
		waterAffector.transform.rotation = Quaternion.identity;
	}

	private void UpdatePositions(WallBossCD wallBossCD)
	{
		XScaler.transform.localPosition = Vector3.zero;
		mainSegment.localPosition = m_startLocalPosition;
		mainSegment.position = mainSegment.position.RoundToMultiple(0.0625f);
		WallBoss monoT = null;
		if (wallBossCD.leftEntity != Entity.Null)
		{
			Manager.memory.TryGetEntityMono(wallBossCD.leftEntity, out monoT);
		}
		if ((bool)monoT)
		{
			supportSegment.gameObject.SetActive(value: true);
			supportSegment.position = ((base.transform.position + monoT.transform.position) * 0.5f + Vector3.up * 1.5f).RoundToMultiple(0.0625f);
		}
		else
		{
			supportSegment.gameObject.SetActive(value: false);
		}
		for (int i = 0; i < animationBones.Length; i++)
		{
			Transform obj = animationBones[i];
			Vector3 position = obj.parent.position;
			position.y -= 0.05f;
			obj.position = position;
		}
	}

	private void UpdateEarthquakeAudio(WallBossCD wallBossCD)
	{
		if (_earthquakeAudioLoop != null && audioLoopUpdateTimer.isRunning && audioLoopUpdateTimer.isTimerElapsed)
		{
			EntityMonoBehaviour entityMonoBehaviour = ((wallBossCD.leftEntity != Entity.Null) ? Manager.memory.GetEntityMono(wallBossCD.leftEntity) : null);
			EntityMonoBehaviour entityMonoBehaviour2 = ((wallBossCD.rightEntity != Entity.Null) ? Manager.memory.GetEntityMono(wallBossCD.rightEntity) : null);
			int distanceToPlayer = GetDistanceToPlayer();
			bool num = entityMonoBehaviour != null && ((WallBoss)entityMonoBehaviour).GetDistanceToPlayer() < distanceToPlayer;
			bool flag = entityMonoBehaviour2 != null && ((WallBoss)entityMonoBehaviour2).GetDistanceToPlayer() < distanceToPlayer;
			if (!num && !flag)
			{
				float volume = math.clamp(m_currentSpeed / 3f, 0f, 1f);
				_earthquakeAudioLoop.SetVolume(volume);
			}
			else
			{
				_earthquakeAudioLoop.SetVolume(0f);
			}
			audioLoopUpdateTimer.Start();
		}
	}

	private void UpdateScreenShake()
	{
		if (!(Manager.main.player == null) && (!screenShakeUpdateTimer.isRunning || screenShakeUpdateTimer.isTimerElapsed))
		{
			float num = 60f;
			float time = Mathf.Clamp((Manager.main.player.transform.position - base.transform.position).magnitude, 0f, num) / num;
			float num2 = math.clamp(m_currentSpeed / 3f, 0f, 1f);
			float num3 = shakeIntensityCurve.Evaluate(time) * 1.5f * num2;
			if (num3 > 0.1f)
			{
				Manager.camera.ShakeCameraNow(0.2f, num3, num3, null, null, 0, 0.7f);
			}
			screenShakeUpdateTimer.Start();
		}
	}

	public int GetDistanceToPlayer()
	{
		if (Manager.main.player == null)
		{
			return int.MaxValue;
		}
		return (int)(Manager.main.player.transform.position - base.transform.position).magnitude;
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.DrawWireSphere(base.transform.position, rollRadius);
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		m_isDead = true;
		if (TryGetHeadEntityMono(out var headEntityMono))
		{
			headEntityMono.Die();
		}
		if (m_segmentNumber.HasValue)
		{
			StartCoroutine(DeathSequence());
		}
	}

	protected override void OnTakeDamage()
	{
		base.OnTakeDamage();
		if (TryGetHeadEntityMono(out var headEntityMono))
		{
			headEntityMono.TakeDamage();
		}
	}

	private bool TryGetHeadEntityMono(out WallBossHead headEntityMono)
	{
		if (EntityUtility.TryGetComponentData<WallBossHeadRefCD>(base.entity, base.world, out var value) && value.headEntity != Entity.Null)
		{
			return Manager.memory.TryGetEntityMono(value.headEntity, out headEntityMono);
		}
		headEntityMono = null;
		return false;
	}

	private IEnumerator DeathSequence()
	{
		yield return new WaitForSeconds(deathInitialPause);
		AudioManager.Sfx(SfxTableID.wallBossDeathScream, base.transform.position);
		yield return new WaitForSeconds(deathWaitForHead);
		if ((bool)deathParticles)
		{
			deathParticles.Play();
		}
		float deflateStartTime = Time.time;
		while (Time.time < deflateStartTime + deathDeflateDuration)
		{
			float num = math.smoothstep(0f, 1f, (Time.time - deflateStartTime) / deathDeflateDuration);
			XScaler.transform.localPosition = new Vector3(0f, -4f * num, 0f);
			yield return 0;
		}
		if ((bool)deathParticles)
		{
			deathParticles.Stop();
		}
		float fadeStartTime = Time.time;
		while (Time.time < fadeStartTime + deathFadeDuration)
		{
			float num2 = math.smoothstep(0f, 1f, (Time.time - fadeStartTime) / deathFadeDuration);
			SetRenderersAlpha(1f - num2);
			yield return 0;
		}
	}

	private void SetRenderersAlpha(float alpha)
	{
		for (int i = 0; i < m_fadeableMaterials.Count; i++)
		{
			m_fadeableMaterials[i].SetFloat(_Alpha, alpha);
		}
	}
}
