using System;
using System.Collections;
using System.Collections.Generic;
using Pug.Sprite;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class SnakeBossSegment : EntityMonoBehaviour
{
	public ElectricBeamFX energyBeam;

	public ElectricBeamFX energyBeamThorns1;

	public ElectricBeamFX energyBeamThorns2;

	public MeshRenderer energySphere;

	[Range(0f, 1f)]
	public float energyCharge;

	public AnimationCurve headChargeReleaseAnimation = AnimationCurve.Linear(0f, 1f, 1f, 1f);

	[ColorUsage(false, true)]
	public Color chargeColor;

	public ParticleSystem deathParticleSystems;

	public ParticleSystem waterParticlesL;

	public ParticleSystem waterParticlesR;

	public Transform spriteParent;

	public float beneathWaterHeight;

	public float aboveWaterHeight;

	public WaterSimAffector waterSimAffector;

	public PlatformFlags disableWaterSimAffectorOnPlatforms;

	public Transform waterSimSpherePoint;

	public float waterSimSphereRadius;

	public PugText nameObject;

	public GameObject spriteParentDeath;

	public Color vulnerableSegmentEmissiveColor;

	public float vulnerableSegmentPulseFrequency;

	public Color enrageColor;

	[SerializeField]
	private SnakeBossSegmentSpriteController m_headController;

	[SerializeField]
	private SnakeBossSegmentSpriteController m_mandiblesController;

	[SerializeField]
	private SnakeBossSegmentSpriteController m_segmentController;

	[SerializeField]
	private SnakeBossSegmentSpriteController m_vulnerableController;

	[SerializeField]
	private SnakeBossSegmentSpriteController m_tailController;

	[SerializeField]
	private SpriteObject m_headSpriteObject;

	[SerializeField]
	private SpriteObject m_mandiblesSpriteObject;

	[SerializeField]
	private SpriteObject m_segmentSpriteObject;

	[SerializeField]
	private SpriteObject m_tailSpriteObject;

	private float m_heightAlpha;

	private DynamicBuffer<SnakeSegmentsBuffer> m_segments;

	private int m_segmentIndex;

	private float m_groundAvoidance;

	private float m_prevChargeAlpha = -1f;

	private readonly float sqDistanceToRender = 6400f;

	private readonly List<AudioManager.RunningSfxReference> m_waterAudioLoop = new List<AudioManager.RunningSfxReference>();

	private readonly List<AudioManager.RunningSfxReference> m_GrowlAudioLoop = new List<AudioManager.RunningSfxReference>();

	private readonly List<AudioManager.RunningSfxReference> m_GrowlUnderwaterAudioLoop = new List<AudioManager.RunningSfxReference>();

	private float m_currentWaterAudioVolume;

	private float m_energyChargeReleaseTime;

	private static int _Multiplier = Shader.PropertyToID("_Multiplier");

	private bool isPlayingChargeSound;

	public Vector4 wavePattern = new Vector4(0.35f, 1.5f, 0.15f, 1f);

	public float m_headOffset;

	public float m_dirDot;

	public float m_zOffset;

	private Vector3 m_headPos;

	private float3 m_prevTargetDirection;

	private bool m_hasPrevDirection;

	protected override bool hideDirectlyOnDeath => false;

	public bool isHead { get; private set; }

	public bool isTail { get; private set; }

	protected override void Awake()
	{
		base.Awake();
		float num = UnityEngine.Random.value * 100f;
		energyBeamThorns1.renderer.material.SetFloat("_TimeOffset", num);
		energyBeamThorns2.renderer.material.SetFloat("_TimeOffset", num * 1.5f);
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		spriteParentDeath.SetActive(currentHealth > 0);
		m_currentWaterAudioVolume = 0f;
		m_energyChargeReleaseTime = -1f;
		isPlayingChargeSound = false;
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		nameObject.gameObject.SetActive(value: false);
		PlayerController player = Manager.main.player;
		if (player == null)
		{
			return;
		}
		if (math.distancesq(player.RenderPosition, base.RenderPosition) > sqDistanceToRender)
		{
			spriteParent.gameObject.SetActive(value: false);
			ReleaseAudioLoops();
			return;
		}
		spriteParent.gameObject.SetActive(value: true);
		SnakeMovementStateCD componentData = EntityUtility.GetComponentData<SnakeMovementStateCD>(base.entity, base.world);
		if (!EntityUtility.HasComponentData<SnakeSegmentsBuffer>(componentData.headRef, base.world))
		{
			ReleaseAudioLoops();
			return;
		}
		SnakeMovementStateCD componentData2 = EntityUtility.GetComponentData<SnakeMovementStateCD>(componentData.headRef, base.world);
		if (currentHealth <= 0)
		{
			ReleaseAudioLoops();
			return;
		}
		m_segments = EntityUtility.GetBuffer<SnakeSegmentsBuffer>(componentData.headRef, base.world);
		if (m_segments.Length == 0)
		{
			ReleaseAudioLoops();
			return;
		}
		m_segmentIndex = -1;
		for (int i = 0; i < m_segments.Length; i++)
		{
			if (m_segments[i].segment == base.entity)
			{
				m_segmentIndex = i;
				break;
			}
		}
		isHead = m_segmentIndex == 0;
		isTail = m_segmentIndex == m_segments.Length - 1;
		ImmuneToDamageCD componentData3 = EntityUtility.GetComponentData<ImmuneToDamageCD>(base.entity, base.world);
		m_headController.gameObject.SetActive(isHead);
		m_mandiblesController.gameObject.SetActive(isHead);
		m_segmentController.gameObject.SetActive(!isHead && !isTail);
		m_vulnerableController.gameObject.SetActive(!isHead && !isTail && componentData3.Value == ImmuneToDamageState.Vulnerable);
		m_tailController.gameObject.SetActive(isTail);
		float f = m_headController.clockwiseAngle * (MathF.PI / 180f);
		Vector3 vector = -new Vector3(Mathf.Cos(f), 0f, Mathf.Sin(f));
		Vector3 vector2 = Vector3.Cross(vector, Vector3.up);
		float num = componentData.spread + componentData.additionalHorizontalSpread * Mathf.Abs(vector2.x);
		if (m_segmentIndex < m_segments.Length - 1 && m_segmentIndex >= 0)
		{
			LocalTransform value;
			float3 obj = (EntityUtility.TryGetComponentData<LocalTransform>(m_segments[m_segmentIndex].segment, base.world, out value) ? value.Position : default(float3));
			LocalTransform value2;
			float3 float5 = (EntityUtility.TryGetComponentData<LocalTransform>(m_segments[m_segmentIndex + 1].segment, base.world, out value2) ? value2.Position : default(float3));
			float t = Mathf.Abs(Vector3.Distance(obj, float5) - num) / num;
			Debug.DrawLine(obj.ToRender(), float5.ToRender(), Color.Lerp(Color.green, Color.red, t));
		}
		SnakeBossCD componentData4 = EntityUtility.GetComponentData<SnakeBossCD>(base.entity, base.world);
		bool isAboveWater = componentData4.isAboveWater;
		nameObject.gameObject.SetActive(isAboveWater && isHead);
		optionalHealthBar.gameObject.SetActive(isAboveWater && componentData3.Value == ImmuneToDamageState.Vulnerable);
		if (isAboveWater)
		{
			m_heightAlpha += Time.deltaTime * 0.5f;
		}
		else
		{
			m_heightAlpha -= Time.deltaTime;
		}
		m_heightAlpha = Mathf.Clamp01(m_heightAlpha);
		float num2 = math.lerp(beneathWaterHeight, aboveWaterHeight, m_heightAlpha);
		bool flag = false;
		if (m_segments.Length > 0 && componentData.initialLength > 0 && EntityUtility.HasComponentData<SnakeBossCD>(componentData.headRef, base.world))
		{
			float projectileCooldownTimer = EntityUtility.GetComponentData<SnakeBossCD>(componentData.headRef, base.world).projectileCooldownTimer;
			flag = m_segments.Length <= componentData4.amountOfSegmentsRemainingToEnrage;
			float num3 = 1f - math.min(projectileCooldownTimer, 3f) / 3f;
			if (num3 > 0f && num3 < 0.9f && !isPlayingChargeSound)
			{
				AudioManager.SfxFollowTransform(SfxTableID.snakeBossElectricChargeUp, base.transform);
				isPlayingChargeSound = true;
			}
			else if (num3 >= 0.9f)
			{
				isPlayingChargeSound = false;
			}
			energyCharge = num3;
			float num4 = 0.9f;
			if (num3 >= num4 && m_prevChargeAlpha < num4)
			{
				ReleaseEnergyCharge();
			}
			m_prevChargeAlpha = num3;
		}
		float num5 = 0f;
		if (!disableWaterSimAffectorOnPlatforms.MatchesCurrentPlatform() && GetSphereWaterIntersection(waterSimSpherePoint.position, waterSimSphereRadius, out var intersectionPosition, out var intersectionRadius))
		{
			waterSimAffector.gameObject.SetActive(value: true);
			waterSimAffector.transform.position = intersectionPosition;
			waterSimAffector.transform.localScale = Vector3.one * intersectionRadius * 2f;
			num5 = Mathf.Clamp01(intersectionRadius / waterSimSphereRadius);
			waterParticlesL.transform.rotation = Quaternion.LookRotation(vector2, Vector3.up);
			waterParticlesR.transform.rotation = waterParticlesL.transform.rotation;
			waterParticlesL.transform.position = intersectionPosition - vector * intersectionRadius;
			waterParticlesR.transform.position = intersectionPosition + vector * intersectionRadius;
			if (!waterParticlesL.isPlaying)
			{
				waterParticlesL.Play();
				waterParticlesR.Play();
			}
		}
		else
		{
			waterSimAffector.gameObject.SetActive(value: false);
			if (waterParticlesL.isPlaying)
			{
				waterParticlesL.Stop();
				waterParticlesR.Stop();
			}
		}
		Vector3 vec = base.WorldPosition + vector2;
		bool flag2 = Manager.multiMap.GetTileLayerLookup().HasTile(vec.RoundToInt2(), TileType.water);
		float num6 = ((!isAboveWater && !flag2) ? 1f : (-0.35f));
		m_groundAvoidance = Mathf.Clamp01(m_groundAvoidance + num6 * Time.deltaTime * 2f);
		num2 -= m_groundAvoidance * 2f;
		num2 -= (float)m_segmentIndex * 0.05f;
		spriteParent.localPosition = new Vector3(0f, num2, 0f);
		spriteParent.position += vector * Mathf.Sin((float)m_segmentIndex * wavePattern.x - Time.time * MathF.PI * wavePattern.y) * (1f - Mathf.Exp((float)(-m_segmentIndex) * wavePattern.z)) * wavePattern.w * num5;
		UpdateRotation(componentData, componentData2);
		Vector3 forward = Manager.camera.gameCamera.transform.forward;
		float num7 = ((m_energyChargeReleaseTime > 0f) ? ((Time.time - m_energyChargeReleaseTime) * 2f) : 999f);
		bool flag3 = num7 < 1f;
		if (isHead && m_mandiblesController.activeDirectionalObject != null && (energyCharge > Mathf.Epsilon || flag3))
		{
			float num8 = (flag3 ? 1f : energyCharge);
			energyBeam.isOn = !flag3 || num7 < 0.5f;
			energyBeam.isConnected = num8 > 0.5f;
			Vector3 vector3 = m_mandiblesController.activeDirectionalObject.transform.GetChild(0).position;
			Vector3 vector4 = m_mandiblesController.activeDirectionalObject.transform.GetChild(1).position;
			if (vector3.y < 0f)
			{
				vector3 = ProjectToPlane(vector3, -forward, 0f);
			}
			if (vector4.y < 0f)
			{
				vector4 = ProjectToPlane(vector4, -forward, 0f);
			}
			Vector3 vector5 = vector4 - vector3;
			float magnitude = vector5.magnitude;
			energyBeam.transform.position = vector3;
			energyBeam.transform.rotation = Quaternion.LookRotation(vector5 / magnitude, Vector3.up);
			energyBeam.transform.localScale = new Vector3(1f, 1f, magnitude);
			energySphere.gameObject.SetActive(value: true);
			energySphere.transform.position = (vector3 + vector4) / 2f;
			float b = (flag3 ? headChargeReleaseAnimation.Evaluate(num7) : 1f);
			energySphere.transform.localScale = new Vector3(1f, 0.5f, 1f) * (0.1f + (Mathf.Cos(Time.time * 40f) + 0.5f) * 0.1f + num8) * Mathf.Max(Mathf.Epsilon, b);
			energySphere.material.SetFloat(_Multiplier, num8 * 2f);
			m_mandiblesSpriteObject.emissiveColor = chargeColor * num8;
		}
		else
		{
			energyBeam.isOn = false;
			energySphere.gameObject.SetActive(value: false);
			m_mandiblesSpriteObject.emissiveColor = Color.black;
		}
		bool flag4 = false;
		if (flag)
		{
			bool num9 = m_segments.Length > 0 && m_segmentIndex < m_segments.Length - 1;
			int num10 = 10;
			int num11 = (int)nfmod((0f - Time.time) * 10f, num10);
			m_headSpriteObject.emissiveColor = chargeColor;
			m_segmentSpriteObject.emissiveColor = chargeColor;
			m_tailSpriteObject.emissiveColor = chargeColor;
			if (num9 && m_segmentIndex % num10 == num11)
			{
				Entity segment = m_segments[m_segmentIndex + 1].segment;
				if (Manager.memory.TryGetEntityMono(segment, out SnakeBossSegment monoT))
				{
					flag4 = TryGetThornPoint(otherSide: false, forward, out var position, out var isUnderwater);
					flag4 &= TryGetThornPoint(otherSide: true, forward, out var position2, out var isUnderwater2);
					flag4 &= monoT.TryGetThornPoint(otherSide: false, forward, out var position3, out var isUnderwater3);
					flag4 &= monoT.TryGetThornPoint(otherSide: true, forward, out var position4, out var isUnderwater4);
					energyBeamThorns1.originPointWorld = EntityMonoBehaviour.ToWorldFromRender(position);
					energyBeamThorns1.endPointWorld = EntityMonoBehaviour.ToWorldFromRender(position3);
					energyBeamThorns2.originPointWorld = EntityMonoBehaviour.ToWorldFromRender(position2);
					energyBeamThorns2.endPointWorld = EntityMonoBehaviour.ToWorldFromRender(position4);
					energyBeamThorns1.isConnected = !isUnderwater && !isUnderwater3;
					energyBeamThorns2.isConnected = !isUnderwater2 && !isUnderwater4;
				}
			}
		}
		else
		{
			m_headSpriteObject.emissiveColor = Color.black;
			m_segmentSpriteObject.emissiveColor = Color.black;
			m_tailSpriteObject.emissiveColor = Color.black;
		}
		energyBeamThorns1.gameObject.SetActive(flag4);
		energyBeamThorns2.gameObject.SetActive(flag4);
		if (flag4)
		{
			energyBeamThorns1.UpdatePosition();
			energyBeamThorns2.UpdatePosition();
		}
		UpdateAudioLoops(num5);
	}

	private float nfmod(float a, float b)
	{
		return a - b * Mathf.Floor(a / b);
	}

	public bool TryGetThornPoint(bool otherSide, Vector3 cameraForward, out Vector3 position, out bool isUnderwater)
	{
		SnakeBossSegmentSpriteController activeSpriteController = GetActiveSpriteController();
		position = Vector3.zero;
		isUnderwater = false;
		if (activeSpriteController == null)
		{
			Debug.LogError("Null sprite controller");
			return false;
		}
		if (activeSpriteController.activeDirectionalObject == null)
		{
			Debug.LogError("Null active directional object");
			return false;
		}
		if (activeSpriteController.ShouldFlipChildren())
		{
			otherSide = !otherSide;
		}
		position = activeSpriteController.activeDirectionalObject.transform.GetChild(otherSide ? 1 : 0).position;
		isUnderwater = position.y < 0f;
		position = ProjectToPlane(position, -cameraForward, 0f);
		return true;
	}

	public SnakeBossSegmentSpriteController GetActiveSpriteController()
	{
		if (m_headController.gameObject.activeSelf)
		{
			return m_headController;
		}
		if (m_segmentController.gameObject.activeSelf)
		{
			return m_segmentController;
		}
		if (m_tailController.gameObject.activeSelf)
		{
			return m_tailController;
		}
		return null;
	}

	public void ReleaseEnergyCharge()
	{
		m_energyChargeReleaseTime = Time.time;
		energyCharge = 0f;
	}

	private Vector3 ProjectToPlane(Vector3 position, Vector3 direction, float planeHeight)
	{
		float num = planeHeight - position.y;
		return position + direction * num / direction.y;
	}

	private void UpdateAudioLoops(float intersectionDelta)
	{
		m_currentWaterAudioVolume = Mathf.Max(m_currentWaterAudioVolume, intersectionDelta);
		m_currentWaterAudioVolume = Mathf.Lerp(m_currentWaterAudioVolume, intersectionDelta, Time.deltaTime);
		if (m_waterAudioLoop.Count == 0 && m_segmentIndex % 3 == 0)
		{
			AudioManager.SfxFollowTransform(SfxTableID.waterLoop, base.transform, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, m_waterAudioLoop);
			for (int i = 0; i < m_waterAudioLoop.Count; i++)
			{
				m_waterAudioLoop[i].SetTime(UnityEngine.Random.value * m_waterAudioLoop[i].ClipLength);
			}
		}
		foreach (AudioManager.RunningSfxReference item in m_waterAudioLoop)
		{
			item.SetVolume(m_currentWaterAudioVolume * 0.55f);
		}
		if (!isHead)
		{
			return;
		}
		if (m_GrowlAudioLoop.Count == 0)
		{
			AudioManager.SfxFollowTransform(SfxTableID.snakeBossGrowlLoop, base.transform, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, m_GrowlAudioLoop);
		}
		foreach (AudioManager.RunningSfxReference item2 in m_GrowlAudioLoop)
		{
			item2.SetVolume(m_currentWaterAudioVolume * 0.6f);
		}
		if (m_GrowlUnderwaterAudioLoop.Count == 0)
		{
			AudioManager.SfxFollowTransform(SfxTableID.snakeBossGrowlUnderwaterLoop, base.transform, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, m_GrowlUnderwaterAudioLoop);
		}
		foreach (AudioManager.RunningSfxReference item3 in m_GrowlUnderwaterAudioLoop)
		{
			item3.SetVolume(1f - m_currentWaterAudioVolume);
		}
	}

	private void ReleaseAudioLoops()
	{
		foreach (AudioManager.RunningSfxReference item in m_waterAudioLoop)
		{
			item.FadeOutAndStop();
		}
		foreach (AudioManager.RunningSfxReference item2 in m_GrowlAudioLoop)
		{
			item2.FadeOutAndStop();
		}
		foreach (AudioManager.RunningSfxReference item3 in m_GrowlUnderwaterAudioLoop)
		{
			item3.FadeOutAndStop();
		}
		m_waterAudioLoop.Clear();
		m_GrowlAudioLoop.Clear();
		m_GrowlUnderwaterAudioLoop.Clear();
	}

	private void UpdateRotation(SnakeMovementStateCD snakeMovement, SnakeMovementStateCD snakeHeadMovement)
	{
		int index = Mathf.Clamp(m_segmentIndex - 1, 0, m_segments.Length - 1);
		int index2 = Mathf.Clamp(m_segmentIndex + 1, 0, m_segments.Length - 1);
		LocalTransform value;
		float3 float5 = (EntityUtility.TryGetComponentData<LocalTransform>(m_segments[index].segment, base.world, out value) ? value.Position : default(float3));
		LocalTransform value2;
		float3 float6 = (EntityUtility.TryGetComponentData<LocalTransform>(m_segments[index2].segment, base.world, out value2) ? value2.Position : default(float3));
		float num = math.distance(float5, float6);
		if (num < 1E-05f)
		{
			return;
		}
		float3 float7 = (float5 - float6) / num;
		Mathf.Exp((float)(-m_segmentIndex) * 0.25f);
		if (Vector3.Angle(float7, m_prevTargetDirection) > 2f || !m_hasPrevDirection)
		{
			if (m_segmentIndex > 0 && m_segmentIndex < m_segments.Length - 1)
			{
				LocalTransform value3;
				float3 float8 = (EntityUtility.TryGetComponentData<LocalTransform>(m_segments[m_segmentIndex].segment, base.world, out value3) ? value3.Position : default(float3));
				if (float8.z < float6.z && float8.z < float5.z)
				{
					float7.z = 0f;
					float7 = math.normalizesafe(float7);
				}
			}
			float clockwiseAngle = Mathf.Atan2(float7.z, float7.x) * 57.29578f + 90f;
			m_headController.clockwiseAngle = clockwiseAngle;
			m_mandiblesController.clockwiseAngle = clockwiseAngle;
			m_segmentController.clockwiseAngle = clockwiseAngle;
			m_vulnerableController.clockwiseAngle = clockwiseAngle;
			m_tailController.clockwiseAngle = clockwiseAngle;
			m_prevTargetDirection = float7;
			m_hasPrevDirection = true;
		}
		if (EntityUtility.HasComponentData<LocalTransform>(snakeMovement.headRef, base.world))
		{
			m_headPos = EntityMonoBehaviour.ToRenderFromWorld(EntityUtility.GetComponentData<LocalTransform>(snakeMovement.headRef, base.world).Position);
			if (float.IsNaN(m_headPos.x) || float.IsNaN(m_headPos.y) || float.IsNaN(m_headPos.z))
			{
				Debug.LogError("m_headPos was NaN");
				m_headPos = base.transform.position;
			}
			m_headOffset = m_headPos.z - base.transform.position.z;
			m_dirDot = 1f + Vector2.Dot(new Vector2(float7.x, float7.z), Vector2.down);
			m_zOffset = m_headOffset + m_dirDot * 0.5f;
			spriteParent.localPosition += new Vector3(0f, 1f, 1f) * m_zOffset * 0.001f;
		}
	}

	private void OnDrawGizmosSelected()
	{
	}

	public static bool GetSphereWaterIntersection(Vector3 position, float radius, out Vector3 intersectionPosition, out float intersectionRadius)
	{
		intersectionPosition = position;
		intersectionRadius = -1f;
		float num = Mathf.Abs(-0.2f - position.y);
		float num2 = radius * radius - num * num;
		if (num2 < Mathf.Epsilon)
		{
			return false;
		}
		intersectionPosition.y = 0f;
		intersectionRadius = Mathf.Sqrt(num2);
		return true;
	}

	public void AE_StartDeathExplosion()
	{
		if (deathParticleSystems != null)
		{
			deathParticleSystems.Play(withChildren: true);
			AudioManager.Sfx(SfxTableID.bossDeathAnticipation, deathParticleSystems.transform.position);
		}
	}

	public void AE_DeathBurst()
	{
		Vector3 position = base.RenderPosition + Vector3.up * 1f;
		Manager.effects.PlayPuff(PuffID.SnakeDeathCarapace, position);
		Manager.effects.PlayPuff(PuffID.SnakeDeathFlesh, position);
		AudioManager.Sfx(SfxTableID.slimeBigSplat, position);
	}

	protected override void OnTakeDamage()
	{
		if (hasFlashable)
		{
			flashable.FlashLinearNoCurve(0.5f);
		}
		AudioManager.SfxFollowTransform(soundOptions.takeDamageSfx.value, base.transform);
	}

	protected override void OnDeath()
	{
		StartCoroutine(Death_Coroutine());
	}

	private void AE_EnrageSound()
	{
		AudioManager.Sfx(SfxID.slimeBossEnrage, base.transform.position, 1f, 1f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 42f);
	}

	private IEnumerator Death_Coroutine()
	{
		AudioManager.SfxFollowTransform(soundOptions.deathSfx.value, base.transform);
		if (hasFlashable)
		{
			flashable.Flash(flashable.curve, Color.white, 2.15f);
		}
		yield return new WaitForSeconds(1.45f);
		AE_StartDeathExplosion();
		yield return new WaitForSeconds(0.617f);
		spriteParentDeath.SetActive(value: false);
		AE_DeathBurst();
	}

	protected override void OnHide()
	{
		base.OnHide();
		ReleaseAudioLoops();
	}

	protected override void DeathEffect()
	{
	}

	protected override void TakeDamageEffect(Vector3 offset)
	{
	}
}
