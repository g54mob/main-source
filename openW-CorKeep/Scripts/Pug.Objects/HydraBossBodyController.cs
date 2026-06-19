using System;
using System.Collections;
using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;
using UnityEngine.Rendering;

public class HydraBossBodyController : MonoBehaviour
{
	private class Segment
	{
		public static int positionSnaps;

		public static int degreeSnaps;

		public GameObject gameObject;

		public Transform transform => gameObject.transform;

		public Vector3 position
		{
			get
			{
				return transform.position;
			}
			set
			{
				if (positionSnaps > 0)
				{
					value.x = Mathf.Round(value.x * (float)positionSnaps) / (float)positionSnaps;
					value.y = Mathf.Round(value.y * (float)positionSnaps) / (float)positionSnaps;
					value.z = Mathf.Round(value.z * (float)positionSnaps) / (float)positionSnaps;
				}
				transform.position = value;
			}
		}

		public Quaternion rotation
		{
			get
			{
				return transform.rotation;
			}
			set
			{
				transform.rotation = value;
				if (degreeSnaps > 0)
				{
					Vector3 eulerAngles = transform.eulerAngles;
					eulerAngles.x = Mathf.Round(eulerAngles.x / (float)degreeSnaps) * (float)degreeSnaps;
					eulerAngles.y = Mathf.Round(eulerAngles.y / (float)degreeSnaps) * (float)degreeSnaps;
					eulerAngles.z = Mathf.Round(eulerAngles.z / (float)degreeSnaps) * (float)degreeSnaps;
					transform.eulerAngles = eulerAngles;
				}
			}
		}

		public float scale
		{
			get
			{
				return transform.localScale.x;
			}
			set
			{
				transform.localScale = new Vector3(value, value, value);
			}
		}
	}

	[SerializeField]
	private GameObject m_segmentPrefab;

	[SerializeField]
	private GameObject m_headPrefab;

	[SerializeField]
	private Material m_depthOnlyMaterial;

	[SerializeField]
	private Shader m_opaqueShader;

	[SerializeField]
	private int m_segmentCount = 10;

	[SerializeField]
	private float m_segmentSpacing = 1f;

	[SerializeField]
	private float m_segmentOvershoot;

	[SerializeField]
	[Range(1f, 8f)]
	private int m_distanceIterations = 4;

	[SerializeField]
	private AnimationCurve m_segmentSize = AnimationCurve.Linear(0f, 1f, 1f, 1f);

	[SerializeField]
	private WaterSimAffector m_waterAffector;

	[Space(10f)]
	[SerializeField]
	private List<Transform> m_controlPoints = new List<Transform>();

	[Space(10f)]
	[SerializeField]
	private MeshRenderer m_screamShockwave;

	[Min(0f)]
	public float appearDuration = 1f;

	public bool isVisible;

	public bool snapPosition = true;

	[Min(0f)]
	public int degreeSnaps = 5;

	[Space(10f)]
	public float pulseFrequency = 1f;

	public float pulseSpeed = 8f;

	public float pulseAmplitude = 0.1f;

	public bool instantiateMaterials = true;

	[Space(10f)]
	[Range(0f, 1f)]
	public float alpha = 1f;

	public Color flashColor = Color.clear;

	public bool isGhost;

	public bool isVoid;

	[HideInInspector]
	public bool inWater;

	[HideInInspector]
	public bool inPit;

	private float m_visibility;

	private Segment[] m_segments;

	private float[] m_pointDistances;

	private float m_totalDistance;

	private Vector3 m_startPoint;

	private Vector3 m_endPoint;

	private bool m_wasGhost;

	private Vector3[] m_controlPointPositions;

	private HydraBossHeadController m_headController;

	private float m_screamTime = -1f;

	private bool showScreamShockwaveDuringScream;

	private Material m_screamMaterial;

	private List<Material> m_materials = new List<Material>();

	private static int _Hash4 = Shader.PropertyToID("_Hash4");

	private static int _Color = Shader.PropertyToID("_Color");

	private static int _Alpha = Shader.PropertyToID("_Alpha");

	private static int _FlashColor = Shader.PropertyToID("_FlashColor");

	private static int _IsGhost = Shader.PropertyToID("_IsGhost");

	private static int _IsVoid = Shader.PropertyToID("_IsVoid");

	private List<Renderer> m_depthOnlyRenderers = new List<Renderer>();

	[NonSerialized]
	[HideInInspector]
	public Vector3 lookAtPointWorld;

	[NonSerialized]
	[HideInInspector]
	public float lookAtWeight;

	[NonSerialized]
	[HideInInspector]
	public float lastDamageTime;

	private readonly List<AudioManager.RunningSfxReference> _laserBeamLoop = new List<AudioManager.RunningSfxReference>();

	public List<Transform> controlPoints => m_controlPoints;

	public HydraBossHeadController head => m_headController;

	public Animator animator { get; private set; }

	public void ResetVisibility()
	{
		isVisible = false;
		m_visibility = 0f;
	}

	private void Awake()
	{
		m_segments = new Segment[m_segmentCount];
		for (int i = 0; i < m_segmentCount; i++)
		{
			bool flag = i == m_segmentCount - 1;
			m_segments[i] = new Segment
			{
				gameObject = UnityEngine.Object.Instantiate(flag ? m_headPrefab : m_segmentPrefab, base.transform.position, base.transform.rotation, base.transform)
			};
			if (flag)
			{
				m_headController = m_segments[i].gameObject.GetComponent<HydraBossHeadController>();
				continue;
			}
			Transform child = m_segments[i].transform.GetChild(0);
			Vector3 localScale = child.localScale;
			localScale.x *= ((i % 2 == 0) ? 1 : (-1));
			child.localScale = localScale;
		}
		m_pointDistances = new float[m_controlPoints.Count - 1];
		UpdateControlPointPositions();
		animator = GetComponent<Animator>();
		m_depthOnlyRenderers.Clear();
		MeshRenderer[] componentsInChildren = GetComponentsInChildren<MeshRenderer>(includeInactive: true);
		MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
		int layer = LayerMask.NameToLayer("ShadowsOnly");
		foreach (MeshRenderer meshRenderer in componentsInChildren)
		{
			if (meshRenderer.sharedMaterial.shader == m_opaqueShader)
			{
				Renderer renderer = InitializeChildRenderer(meshRenderer, "DepthOnlyRenderer", base.gameObject.layer, m_depthOnlyMaterial);
				m_depthOnlyRenderers.Add(renderer);
				renderer.enabled = isGhost;
			}
			if (instantiateMaterials)
			{
				InstantiateMaterialsForRenderer(meshRenderer, setRandomHash: true);
			}
			else
			{
				materialPropertyBlock.SetVector(_Hash4, new Vector4(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value));
				meshRenderer.SetPropertyBlock(materialPropertyBlock);
			}
			if (meshRenderer.shadowCastingMode != ShadowCastingMode.Off)
			{
				InitializeChildRenderer(meshRenderer, "ShadowRenderer", layer);
			}
		}
		m_screamMaterial = UnityEngine.Object.Instantiate(m_screamShockwave.sharedMaterial);
		m_screamMaterial.SetColor(_Color, new Color(1f, 1f, 1f, 0f));
		m_screamShockwave.material = m_screamMaterial;
		SetForwardRenderModeEnabled(isGhost);
	}

	private Renderer InitializeChildRenderer(Renderer renderer, string name, int layer, Material overrideMaterial = null)
	{
		Renderer component = UnityEngine.Object.Instantiate(renderer.gameObject, renderer.transform).GetComponent<Renderer>();
		foreach (Transform item in component.transform)
		{
			UnityEngine.Object.Destroy(item.gameObject);
		}
		component.name = name;
		component.transform.localPosition = Vector3.zero;
		component.transform.localRotation = Quaternion.identity;
		component.transform.localScale = Vector3.one;
		component.gameObject.layer = layer;
		if (overrideMaterial != null)
		{
			Material[] array = new Material[component.materials.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = overrideMaterial;
			}
			component.materials = array;
		}
		return component;
	}

	private void InstantiateMaterialsForRenderer(Renderer renderer, bool setRandomHash)
	{
		List<Material> list = new List<Material>();
		renderer.GetSharedMaterials(list);
		for (int i = 0; i < list.Count; i++)
		{
			Material material = UnityEngine.Object.Instantiate(list[i]);
			if (setRandomHash)
			{
				material.SetVector(_Hash4, new Vector4(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value));
			}
			list[i] = material;
		}
		renderer.SetMaterials(list);
		m_materials.AddRange(list);
	}

	public void EnableSegments()
	{
		for (int i = 0; i < m_segments.Length; i++)
		{
			m_segments[i].gameObject.transform.GetChild(0).gameObject.SetActive(value: true);
		}
	}

	private void OnEnable()
	{
		m_visibility = (isVisible ? 1 : 0);
	}

	private void LateUpdate()
	{
		Segment.positionSnaps = (snapPosition ? 16 : 0);
		Segment.degreeSnaps = degreeSnaps;
		Segment segment = m_segments[m_segments.Length - 1];
		UpdateControlPointPositions();
		UpdateCurveEnds();
		UpdateDistances();
		m_visibility = Mathf.Clamp01(m_visibility + (float)(isVisible ? 1 : (-1)) * Time.deltaTime / appearDuration);
		alpha = Mathf.Clamp01(m_visibility * 3f);
		float num = m_visibility * m_visibility * m_visibility * (m_visibility * (6f * m_visibility - 15f) + 10f);
		float num2 = 1f - Mathf.Clamp01((Time.time - lastDamageTime) * 2f);
		float num3 = 0f;
		for (int num4 = m_segments.Length - 1; num4 >= 0; num4--)
		{
			Segment segment2 = m_segments[num4];
			float num5 = 1f - num3 / m_totalDistance;
			if (num5 > 0f)
			{
				Vector3 normal;
				Vector3 binormal;
				Vector3 positionOnCurve = GetPositionOnCurve(num5 - (1f - num), out normal, out binormal);
				if (!Mathf.Approximately(0f, normal.sqrMagnitude))
				{
					Vector3 normalized = Vector3.Cross(binormal, normal).normalized;
					segment2.position = positionOnCurve + GetBobbing(normalized, binormal, num5, pulseSpeed, pulseAmplitude) + GetBobbing(normalized, binormal, num5, 30f, num2 * 0.2f);
					segment2.rotation = Quaternion.LookRotation(normal, binormal);
					segment2.scale = m_segmentSize.Evaluate(num5);
					segment2.gameObject.SetActive(value: true);
				}
				else
				{
					segment2.gameObject.SetActive(value: false);
				}
			}
			else
			{
				segment2.gameObject.SetActive(value: false);
			}
			num3 += m_segmentSpacing;
		}
		Transform transform = m_controlPoints[m_controlPoints.Count - 1];
		Quaternion b = Quaternion.identity;
		if (!Mathf.Approximately(0f, lookAtWeight))
		{
			Vector3 vector = lookAtPointWorld.ToRender() - transform.position;
			float magnitude = vector.magnitude;
			if (!Mathf.Approximately(0f, magnitude))
			{
				b = Quaternion.LookRotation(vector / magnitude, Vector3.up) * Quaternion.Euler(-20f, 0f, 0f);
			}
		}
		Quaternion b2 = Quaternion.Lerp(transform.rotation, b, lookAtWeight);
		segment.rotation = Quaternion.Lerp(segment.rotation, b2, Mathf.Pow(num, 4f));
		float num6 = ((m_screamTime > 0f) ? Mathf.Clamp01(1f - (Time.time - m_screamTime) * 0.5f) : 0f);
		num6 = ((num6 > Mathf.Epsilon) ? Mathf.Sqrt(num6) : 0f);
		m_screamMaterial.SetColor(_Color, new Color(1f, 1f, 1f, num6));
		m_screamShockwave.enabled = num6 > Mathf.Epsilon && showScreamShockwaveDuringScream;
		m_screamShockwave.transform.position = m_headController.screamEffectReferencePoint.position;
		m_waterAffector.bobAmplitudeStill = 100f * num6;
		for (int i = 0; i < m_materials.Count; i++)
		{
			m_materials[i].SetFloat(_Alpha, alpha);
			m_materials[i].SetColor(_FlashColor, flashColor);
			m_materials[i].SetFloat(_IsGhost, isGhost ? 1 : 0);
			m_materials[i].SetFloat(_IsVoid, isVoid ? 1 : 0);
		}
		m_headController.normalEyes.SetActive(!isGhost);
		m_headController.ghostEyes.SetActive(isGhost);
		if (isGhost != m_wasGhost)
		{
			SetForwardRenderModeEnabled(isGhost);
			for (int j = 0; j < m_depthOnlyRenderers.Count; j++)
			{
				m_depthOnlyRenderers[j].enabled = isGhost;
			}
		}
		m_wasGhost = isGhost;
	}

	private void SetForwardRenderModeEnabled(bool value)
	{
		for (int i = 0; i < m_materials.Count; i++)
		{
			Material material = m_materials[i];
			material.SetShaderPassEnabled("UniversalGBuffer", !value);
			material.SetShaderPassEnabled("UniversalForward", value);
			material.renderQueue = (value ? 2805 : 2000);
		}
	}

	private Vector3 GetBobbing(Vector3 tangent, Vector3 binormal, float t, float speed, float amplitude)
	{
		if (amplitude < Mathf.Epsilon)
		{
			return Vector3.zero;
		}
		return tangent * Mathf.Cos(Time.time * speed + t * m_totalDistance * pulseFrequency) * amplitude * t + binormal * Mathf.Sin(Time.time * speed + t * m_totalDistance * pulseFrequency) * amplitude * t;
	}

	public void SetTrigger(int animId)
	{
		animator.SetTrigger(animId);
	}

	public void OpenMouth()
	{
		m_headController.mouthOpen = 2f;
	}

	public void BiteAnticipation()
	{
		if (isVoid)
		{
			AudioManager.Sfx(SfxTableID.voidHydraBiteAnticipationSfx, base.transform.position);
		}
		else
		{
			AudioManager.Sfx(SfxTableID.hydraBossBiteAnticipation, base.transform.position);
		}
	}

	public void Bite()
	{
		m_headController.mouthOpen = 0f;
		m_headController.PlayBiteEffect();
		if (isVoid)
		{
			AudioManager.Sfx(SfxTableID.voidHydraBiteAttackSfx, base.transform.position);
		}
		else
		{
			AudioManager.Sfx(SfxTableID.hydraBossBiteAttack, base.transform.position);
		}
	}

	public void ProjectileAnticipation()
	{
		m_headController.PlayAnticipationEffect();
	}

	public void Vulnerable()
	{
		m_headController.PlayVulnerableEffect();
		WaterSim.AddImpulse(base.transform.position, 2f, 30f);
	}

	public void ImpactGround()
	{
		AudioManager.Sfx(inWater ? SfxTableID.hydraBossImpactWater : SfxTableID.hydraBossImpactGround, base.transform.position);
	}

	public void EnterVulnerableState()
	{
		if (isVoid)
		{
			AudioManager.Sfx(SfxTableID.voidHydraEnterVulnerableStateSfx, base.transform.position);
		}
		else
		{
			AudioManager.Sfx(SfxTableID.hydraBossVulnerableEnterState, base.transform.position);
		}
	}

	public void ExitVulnerableState()
	{
		if (isVoid)
		{
			AudioManager.Sfx(SfxTableID.voidHydraExitVulnerableStateSfx, base.transform.position);
		}
		else
		{
			AudioManager.Sfx(SfxTableID.hydraBossVulnerableExitState, base.transform.position);
		}
	}

	public void ResetMouth()
	{
		m_headController.mouthOpen = 0.5f;
	}

	public void LaserBeamAnticipation()
	{
		if (isVoid)
		{
			AudioManager.Sfx(SfxTableID.voidHydraLaserBeamAnticipationSfx, base.transform.position);
		}
		else
		{
			AudioManager.Sfx(SfxTableID.hydraBossLaserBeamAnticipation, base.transform.position);
		}
	}

	public void LaserBeamAttack()
	{
		StopAnyBeamLoop();
		if (isVoid)
		{
			AudioManager.Sfx(SfxTableID.voidHydraLaserBeamAttackSfx, base.transform.position, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, _laserBeamLoop);
		}
		else
		{
			AudioManager.Sfx(SfxTableID.hydraBossLaserBeamAttack, base.transform.position, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, _laserBeamLoop);
		}
	}

	public void LaserBeamAttackEnd()
	{
		StopAnyBeamLoop();
	}

	public void StopAnyBeamLoop()
	{
		foreach (AudioManager.RunningSfxReference item in _laserBeamLoop)
		{
			item.FadeOutAndStop(0.5f);
		}
		_laserBeamLoop.Clear();
	}

	public void ScreamNoShockwave()
	{
		Scream();
		showScreamShockwaveDuringScream = false;
	}

	public void Scream()
	{
		m_screamTime = Time.time;
		Manager.camera.ShakeCameraNow(0.3f);
		showScreamShockwaveDuringScream = true;
	}

	public void ScreamSound()
	{
		if (isVoid)
		{
			AudioManager.Sfx(SfxTableID.voidHydraScreamSfx, base.transform.position);
		}
		else
		{
			AudioManager.Sfx(SfxTableID.hydraBossScream, base.transform.position);
		}
	}

	public void ShootIceProjectile()
	{
		AudioManager.Sfx(SfxTableID.hydraBossIceShardShoot, base.transform.position);
	}

	public void ShootLavaProjectile()
	{
		AudioManager.Sfx(SfxTableID.hydraBossLavaShoot, base.transform.position);
	}

	public void PlayDeathExplosions(PuffID burstId)
	{
		StartCoroutine(DeathCoroutine(burstId));
	}

	private IEnumerator DeathCoroutine(PuffID burstId)
	{
		int index = 5;
		while (index < m_segments.Length)
		{
			DeathBurst(index, burstId);
			index++;
			yield return new WaitForSeconds(0.12f);
		}
	}

	public void CloseEyes()
	{
		head.forceEyesClosed = true;
	}

	public void OpenEyes()
	{
		head.forceEyesClosed = false;
	}

	public void Blink()
	{
		head.Blink();
	}

	public void DeathBurst(int index, PuffID puff)
	{
		Vector3 position = m_segments[index].position;
		Manager.camera.ShakeCameraNow(0.3f);
		Manager.effects.PlayPuff(puff, position);
		Manager.effects.PlayPuff(PuffID.BossExplosionMini, position);
		AudioManager.Sfx(SfxTableID.slimeBigSplat, position);
		m_segments[index].gameObject.transform.GetChild(0).gameObject.SetActive(value: false);
		if (index == 5)
		{
			for (int i = 0; i < 5; i++)
			{
				m_segments[i].gameObject.transform.GetChild(0).gameObject.SetActive(value: false);
			}
		}
	}

	private Vector3 GetPositionOnCurve(float t, out Vector3 normal, out Vector3 binormal)
	{
		t = Mathf.Clamp01(t);
		float num = t * m_totalDistance;
		float num2 = 0f;
		for (int i = 0; i < m_pointDistances.Length; i++)
		{
			float num3 = m_pointDistances[i];
			if (num2 + num3 > num || i == m_pointDistances.Length - 1)
			{
				return GetPositionBetweenPoints(i, (num - num2) / num3, out normal, out binormal);
			}
			num2 += num3;
		}
		Debug.LogError("Out of bounds");
		normal = Vector3.zero;
		binormal = Vector3.zero;
		return Vector3.zero;
	}

	private Vector3 GetPositionBetweenPoints(int i, float t, out Vector3 normal, out Vector3 binormal)
	{
		Vector3 p = ((i > 0) ? m_controlPointPositions[i - 1] : m_startPoint);
		Vector3 p2 = m_controlPointPositions[i];
		Vector3 p3 = m_controlPointPositions[i + 1];
		Vector3 p4 = ((i < m_controlPointPositions.Length - 2) ? m_controlPointPositions[i + 2] : m_endPoint);
		Vector3 vector = MathUtilities.CatmullRom(p, p2, p3, p4, t);
		if (t < 0.5f)
		{
			normal = MathUtilities.CatmullRom(p, p2, p3, p4, t + 0.01f) - vector;
		}
		else
		{
			normal = vector - MathUtilities.CatmullRom(p, p2, p3, p4, t - 0.01f);
		}
		binormal = Vector3.Slerp(m_controlPoints[i].up, m_controlPoints[i + 1].up, t);
		return vector;
	}

	private void UpdateDistances()
	{
		m_totalDistance = 0f;
		Vector3 b = m_controlPointPositions[0];
		for (int i = 0; i < m_pointDistances.Length; i++)
		{
			float num = 0f;
			for (int j = 0; j < m_distanceIterations; j++)
			{
				float t = (j + 1) / m_distanceIterations;
				Vector3 normal;
				Vector3 binormal;
				Vector3 positionBetweenPoints = GetPositionBetweenPoints(i, t, out normal, out binormal);
				num += Vector3.Distance(positionBetweenPoints, b);
				b = positionBetweenPoints;
			}
			m_pointDistances[i] = num;
			m_totalDistance += num;
		}
	}

	private void UpdateCurveEnds()
	{
		MathUtilities.GetAutoCurveEnds(m_controlPointPositions, out m_startPoint, out m_endPoint);
	}

	private void UpdateControlPointPositions()
	{
		if (m_controlPointPositions == null || m_controlPointPositions.Length != m_controlPoints.Count)
		{
			m_controlPointPositions = new Vector3[m_controlPoints.Count];
		}
		for (int i = 0; i < m_controlPoints.Count; i++)
		{
			m_controlPointPositions[i] = m_controlPoints[i].position;
		}
	}
}
