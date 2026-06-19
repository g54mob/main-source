using System;
using System.Collections;
using Pug.UnityExtensions;
using Unity.Mathematics;
using UnityEngine;

public class WallBossHead : EntityMonoBehaviour
{
	[Space]
	[SerializeField]
	private GameObject m_segmentPrefab;

	[SerializeField]
	private int m_maxSegmentCount = 5;

	[SerializeField]
	private GameObject m_endSegmentPrefab;

	[SerializeField]
	private Transform[] m_controlPoints;

	[SerializeField]
	private ParticleSystem m_emergeParticles;

	[SerializeField]
	private ParticleSystem m_emergedParticles;

	[SerializeField]
	private ParticleSystem m_retractParticles;

	[SerializeField]
	public Transform ParticlePosition;

	public float segmentSpacing = 0.2f;

	[Min(0.01f)]
	public float emergeDuration = 0.8f;

	[Min(0.01f)]
	public float emergeExponent = 2f;

	[Header("Bobbing")]
	public float bobSpeed = 1f;

	[Range(0f, 1f)]
	public float bobFrequency = 0.2f;

	[Range(0f, 1f)]
	public float bobAmplitude = 0.5f;

	public float bobSpeedY = 1f;

	[Range(0f, 1f)]
	public float bobFrequencyY = 1f;

	[Range(0f, 1f)]
	public float bobAmplitudeY = 1f;

	public float bobOffsetY = 0.5f;

	[Header("Death Effects")]
	[Min(0f)]
	public float deathBobbingFadeSpeed = 2f;

	[Min(0f)]
	public float deathRattleDuration = 4f;

	[Min(0f)]
	public float deathRattleStrength = 0.5f;

	[Min(0f)]
	public float deathDelayBeforeExplosions = 3f;

	[Min(0f)]
	public float segmentExplosionInterval = 0.12f;

	public PuffID deathExplosionID = PuffID.HydraDeathNature;

	public PuffID deathExplosionHeadID = PuffID.HydraDeathNature;

	private bool m_isEmerged;

	private Vector3[] m_controlPointPositions;

	private float[] m_controlPointDistances;

	private float m_totalCurveLength;

	private Vector3 m_startPoint;

	private Vector3 m_endPoint;

	private Transform[] m_segments;

	private Transform m_endSegment;

	private Transform m_segmentContainer;

	private float m_emergeFactor;

	private float m_damageTime;

	private float m_bobTime;

	private float m_deathTime;

	private WallBossPupilController m_pupil;

	public ParticleSystem DeadThumpParticles;

	private float m_bobWeight;

	public bool isEmerged => m_isEmerged;

	public float emergeFactor => m_emergeFactor;

	public override Vector3 combatTextPosition
	{
		get
		{
			if (!(m_endSegment != null))
			{
				return base.RenderPosition;
			}
			return m_endSegment.position;
		}
	}

	protected override bool hideDirectlyOnDeath => false;

	public void Emerge()
	{
		if (!m_isEmerged)
		{
			m_emergeParticles.Play();
			m_emergedParticles.Play();
			m_isEmerged = true;
			AudioManager.Sfx(SfxTableID.wallBossHeadEmerge, base.transform.position);
		}
	}

	public void Retract()
	{
		if (m_isEmerged)
		{
			m_emergedParticles.Stop();
			m_retractParticles.Play();
			m_isEmerged = false;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		m_segmentContainer = new GameObject("Segments").transform;
		m_segmentContainer.parent = XScaler;
		m_segmentContainer.localPosition = Vector3.zero;
		m_segmentContainer.localRotation = Quaternion.identity;
		m_segmentContainer.localScale = Vector3.one;
		m_segments = new Transform[m_maxSegmentCount];
		for (int i = 0; i < m_maxSegmentCount; i++)
		{
			m_segments[i] = InstantiateSegment(m_segmentPrefab).transform;
			m_segments[i].GetChild(0).localEulerAngles = new Vector3(0f, 0f, UnityEngine.Random.value * 360f);
		}
		m_endSegment = InstantiateSegment(m_endSegmentPrefab).transform;
		m_pupil = m_endSegment.GetComponent<WallBossPupilController>();
	}

	private GameObject InstantiateSegment(GameObject prefab)
	{
		GameObject obj = UnityEngine.Object.Instantiate(prefab, m_segmentContainer);
		obj.hideFlags = HideFlags.DontSave;
		obj.SetActive(value: false);
		MeshRenderer[] componentsInChildren = obj.GetComponentsInChildren<MeshRenderer>();
		if (componentsInChildren.Length != 0)
		{
			flashable.renderers.AddRange(componentsInChildren);
		}
		return obj;
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		m_isEmerged = false;
		m_emergeFactor = 0f;
		animator.SetBool(-316323548, value: false);
		m_deathTime = -1f;
		m_pupil.deathTime = -1f;
		ShowAllSegments();
	}

	public override void ManagedLateUpdate()
	{
		if (EntityUtility.HasComponentData<DisablePhysicsCD>(base.entity, base.world))
		{
			if (EntityUtility.IsComponentEnabled<DisablePhysicsCD>(base.entity, base.world))
			{
				Retract();
			}
			else
			{
				Emerge();
			}
		}
		bool flag = false;
		if (m_deathTime > 0f)
		{
			m_isEmerged = true;
			flag = true;
		}
		m_emergeFactor = Mathf.Clamp01(m_emergeFactor + Time.deltaTime * (float)(m_isEmerged ? 1 : (-1)) / emergeDuration);
		m_bobTime += Time.deltaTime * (float)(m_isEmerged ? 1 : (-1));
		m_pupil.centerPupil = !m_isEmerged || flag;
		Vector3 normalized = EntityMonoBehaviour.ToWorldFromRender(base.transform.position).normalized;
		base.transform.rotation = Quaternion.LookRotation(Vector3.Cross(Vector3.up, normalized), Vector3.up);
		UpdateControlPointCache();
		UpdateCurveEnds();
		UpdateSegments();
		m_pupil.UpdateAnimation();
		if (!(optionalHealthBar.gameObject != null))
		{
			return;
		}
		optionalHealthBar.gameObject.SetActive(m_isEmerged);
		if (m_isEmerged)
		{
			optionalHealthBar.transform.localPosition = m_endSegment.localPosition;
			optionalHealthBar.transform.rotation = quaternion.identity;
			if (EntityUtility.TryGetComponentData<WallBossHeadCD>(base.entity, base.world, out var value) && EntityUtility.TryGetComponentData<HealthCD>(value.mainEntity, base.world, out var value2))
			{
				optionalHealthBar.UpdateHealthBar(value2.Normalized, 0, 0);
			}
		}
	}

	public void TakeDamage()
	{
		OnTakeDamage();
	}

	protected override void OnTakeDamage()
	{
		base.OnTakeDamage();
		if (hasFlashable)
		{
			flashable.FlashLinearNoCurve(Color.red, 0.5f);
		}
		if (Manager.prefs.particleQuality != 0)
		{
			Manager.effects.PlayPuff(PuffID.WallBossHit, ParticlePosition.position, 8);
		}
		m_damageTime = Time.time;
	}

	private void UpdateControlPointCache()
	{
		if (m_controlPointPositions == null || m_controlPointPositions.Length != m_controlPoints.Length)
		{
			m_controlPointPositions = new Vector3[m_controlPoints.Length];
		}
		for (int i = 0; i < m_controlPoints.Length; i++)
		{
			m_controlPointPositions[i] = m_controlPoints[i].position;
		}
		if (m_controlPointDistances == null || m_controlPointDistances.Length != m_controlPoints.Length - 1)
		{
			m_controlPointDistances = new float[m_controlPoints.Length - 1];
		}
		m_totalCurveLength = 0f;
		for (int j = 0; j < m_controlPointDistances.Length; j++)
		{
			float magnitude = (m_controlPoints[j + 1].position - m_controlPoints[j].position).magnitude;
			m_controlPointDistances[j] = magnitude;
			m_totalCurveLength += magnitude;
		}
	}

	private void UpdateCurveEnds()
	{
		MathUtilities.GetAutoCurveEnds(m_controlPointPositions, out m_startPoint, out m_endPoint);
	}

	private float GetEmergeTime()
	{
		return Mathf.Pow(1f - m_emergeFactor, emergeExponent);
	}

	private void UpdateSegments()
	{
		float emergeTime = GetEmergeTime();
		float a = 1f - math.saturate((Time.time - m_damageTime) * 2f);
		float b = (1f - math.saturate((Time.time - m_deathTime) / deathRattleDuration)) * deathRattleStrength;
		a = Mathf.Max(a, b);
		bool flag = m_deathTime < 0f;
		m_bobWeight = 1f;
		if (!flag)
		{
			m_bobWeight = Mathf.Exp((0f - (Time.time - m_deathTime)) * deathBobbingFadeSpeed);
		}
		int i;
		Vector3 normal;
		Vector3 tangent;
		Vector3 binormal;
		for (i = 1; i < m_segments.Length; i++)
		{
			float num = emergeTime + (float)i * segmentSpacing / m_totalCurveLength;
			if (num > 1f)
			{
				break;
			}
			Transform transform = m_segments[i];
			transform.position = GetPointOnCurve(num, out normal, out tangent, out binormal);
			if (a > Mathf.Epsilon)
			{
				transform.position += GetBobbing(tangent, binormal, num, 10f, a * 0.35f);
			}
			transform.position = transform.transform.position.RoundToMultiple(0.0625f);
			if (flag)
			{
				transform.gameObject.SetActive(value: true);
			}
		}
		if (flag)
		{
			for (; i < m_segments.Length; i++)
			{
				m_segments[i].gameObject.SetActive(value: false);
			}
		}
		m_endSegment.position = GetPointOnCurve(emergeTime, out normal, out tangent, out binormal);
		if (a > Mathf.Epsilon)
		{
			m_endSegment.position += GetBobbing(tangent, binormal, emergeTime, 10f, a * 0.35f);
		}
		m_endSegment.position = m_endSegment.transform.position.RoundToMultiple(0.0625f);
		m_endSegment.rotation = Quaternion.LookRotation(-normal, binormal);
		if (flag)
		{
			m_endSegment.gameObject.SetActive(!Mathf.Approximately(emergeTime, 1f));
		}
	}

	private Vector3 GetPointOnCurve(float t, out Vector3 normal, out Vector3 tangent, out Vector3 binormal)
	{
		float num = t - 0.001f;
		Vector3 pointOnCurve = MathUtilities.GetPointOnCurve(m_controlPointPositions, m_controlPointDistances, m_totalCurveLength, m_startPoint, m_endPoint, t);
		Vector3 pointOnCurve2 = MathUtilities.GetPointOnCurve(m_controlPointPositions, m_controlPointDistances, m_totalCurveLength, m_startPoint, m_endPoint, num);
		normal = (pointOnCurve - pointOnCurve2).normalized;
		tangent = Vector3.Cross(Vector3.up, normal).normalized;
		binormal = Vector3.Cross(normal, tangent);
		pointOnCurve += GetBobbing(tangent, binormal, t, bobSpeed, bobAmplitude * m_bobWeight * (1f - t));
		pointOnCurve2 += GetBobbing(tangent, binormal, num, bobSpeed, bobAmplitude * m_bobWeight * (1f - num));
		pointOnCurve.y += (Mathf.Sin((m_bobTime * bobSpeedY + t * m_totalCurveLength * bobFrequencyY + bobOffsetY) * 2f * MathF.PI) * 0.5f + 0.5f) * bobAmplitudeY * m_bobWeight * (1f - t);
		pointOnCurve2.y += (Mathf.Sin((m_bobTime * bobSpeedY + num * m_totalCurveLength * bobFrequencyY + bobOffsetY) * 2f * MathF.PI) * 0.5f + 0.5f) * bobAmplitudeY * m_bobWeight * (1f - num);
		normal = (pointOnCurve - pointOnCurve2).normalized;
		tangent = Vector3.Cross(Vector3.up, normal).normalized;
		binormal = Vector3.Cross(normal, tangent);
		return pointOnCurve;
	}

	private Vector3 GetBobbing(Vector3 tangent, Vector3 binormal, float t, float speed, float amplitude)
	{
		if (amplitude < Mathf.Epsilon)
		{
			return Vector3.zero;
		}
		float num = Mathf.Cos((m_bobTime * speed + t * m_totalCurveLength * bobFrequency) * 2f * MathF.PI);
		Mathf.Sin((m_bobTime * speed * bobSpeedY + t * m_totalCurveLength * bobFrequencyY) * 2f * MathF.PI);
		return tangent * num * amplitude;
	}

	public void Die()
	{
		OnDeath();
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		m_deathTime = Time.time;
		m_pupil.deathTime = m_deathTime;
		StartCoroutine(DeathSequence());
	}

	private IEnumerator DeathSequence()
	{
		animator.SetBool(-316323548, value: true);
		yield return new WaitForSeconds(deathDelayBeforeExplosions);
		m_emergedParticles.Stop();
		for (int index = 0; index < m_segments.Length + 1; index++)
		{
			Transform transform = m_endSegment;
			PuffID puff = deathExplosionHeadID;
			if (index < m_segments.Length)
			{
				transform = m_segments[m_segments.Length - 1 - index];
				puff = deathExplosionID;
			}
			if (transform.gameObject.activeInHierarchy)
			{
				DeathBurst(transform, puff);
				yield return new WaitForSeconds(segmentExplosionInterval);
			}
		}
	}

	private void DeathBurst(Transform segment, PuffID puff)
	{
		Vector3 position = segment.position;
		Manager.camera.ShakeCameraNow(0.3f);
		Manager.effects.PlayPuff(puff, position);
		Manager.effects.PlayPuff(PuffID.BossExplosionMiniHorizontal, position);
		AudioManager.Sfx(SfxTableID.slimeBigSplat, position);
		SetSegmentVisible(segment, value: false);
	}

	private void SetSegmentVisible(Transform segment, bool value)
	{
		segment.GetChild(0).gameObject.SetActive(value);
	}

	private void ShowAllSegments()
	{
		for (int i = 0; i < m_segments.Length; i++)
		{
			SetSegmentVisible(m_segments[i], value: true);
		}
		SetSegmentVisible(m_endSegment, value: true);
	}

	public void PlayDeadThumpEffect()
	{
		DeadThumpParticles.Play();
		AudioManager.Sfx(SfxTableID.wallBossDeathThud, base.transform.position);
		Manager.camera.ShakeCameraNow(0.3f, 0.3f, 1.3f);
	}
}
