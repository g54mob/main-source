using System;
using System.Collections;
using DV;
using DV.ECS.Components;
using DV.Utils;
using Unity.Mathematics;
using UnityEngine;

public abstract class ItemFlameBase : MonoBehaviour
{
	protected const float SIDE_SCALE_PERCENTAGE = 0.1f;

	protected const float DOT_OFFSET = 0.8f;

	protected const float FLAME_WIGGLE_FACTOR = 0.22f;

	public float perlinFactorY = 1.5f;

	public float perlinFactorZ = 1.5f;

	public float perlinFactorL = 2f;

	[SerializeField]
	protected Light flameLight;

	[SerializeField]
	protected Transform lightAnchor;

	[SerializeField]
	protected Transform glareAnchor;

	[SerializeField]
	protected Transform glareTransform;

	[SerializeField]
	[ColorUsage(true, true)]
	private Color glareColorMin;

	[ColorUsage(true, true)]
	[SerializeField]
	private Color glareColorMax;

	[SerializeField]
	private float glareScaleMin = 0.01f;

	[SerializeField]
	private float glareScaleMax = 1f;

	[SerializeField]
	private float glareScaleMaxDistance = 50f;

	[SerializeField]
	protected float ignitionTime = 0.06f;

	[SerializeField]
	protected float extinguishTime;

	[SerializeField]
	protected float maxSpeed;

	[SerializeField]
	protected float staticStabilizationTime = 0.25f;

	[SerializeField]
	protected float dynamicStabilizationTime = 0.25f;

	[SerializeField]
	protected float scaleThresholdMultiplier = 0.2f;

	[SerializeField]
	protected float lightIntensityMin;

	[SerializeField]
	protected float lightIntensityMax = 1f;

	[SerializeField]
	protected float lightRangeMin;

	[SerializeField]
	protected float lightRangeMax;

	[SerializeField]
	protected float lightVariation = 0.3f;

	[SerializeField]
	protected Vector3 flameMinScale;

	[SerializeField]
	protected Vector3 flameMaxScale;

	[SerializeField]
	protected AudioClip ignitionSound;

	[SerializeField]
	protected AudioClip environmentalExtinguishSound;

	protected IIgnitable ignitable;

	protected float lightIntensity;

	protected float lightRange;

	protected float currentFlameIntensity;

	protected float requestedFlameIntensity;

	protected Vector3 flameScaleVelocity = Vector3.one;

	protected Vector3 flameCurrentScale;

	protected Vector3 flameRequestedScale;

	protected Vector3 prevPos;

	protected float elapsedStaticStabilizationTime;

	protected float elapsedDynamicStabilizationTime;

	protected float noiseOffset;

	protected bool hasGlare;

	protected Renderer glareRenderer;

	protected MaterialPropertyBlock glarePropertyBlock;

	protected Coroutine ignitionCoroutine;

	protected Coroutine extinguishCoroutine;

	private static readonly int tintColor = Shader.PropertyToID("_TintColor");

	private DVConvertToEntity convertEntity;

	public bool IsLit { get; protected set; }

	public bool IsIgniting { get; protected set; }

	public event Action FlameIgnited;

	public event Action FlameExtinguished;

	protected abstract IEnumerator FlameExtinguishCoroutine();

	protected abstract IEnumerator FlameIgniteCoroutine(float intensity);

	protected virtual void Awake()
	{
		ignitable = base.gameObject.GetComponentInParentIncludingInactive<IIgnitable>();
		if (!(ignitable is Component))
		{
			Debug.LogError("Could not find 'IIgnitable' reference. Flame cannot be initialized. Destroying self.", base.gameObject);
			UnityEngine.Object.Destroy(this);
			return;
		}
		IsLit = false;
		if ((bool)glareAnchor && (bool)glareTransform && glareTransform.TryGetComponent<Renderer>(out glareRenderer))
		{
			hasGlare = true;
			glarePropertyBlock = new MaterialPropertyBlock();
		}
		base.gameObject.SetActive(value: false);
		flameLight.gameObject.SetActive(value: false);
		if (glareAnchor != null)
		{
			glareAnchor.gameObject.SetActive(value: false);
		}
		prevPos = ignitable.GetTransform().localPosition;
		noiseOffset = UnityEngine.Random.value * 10f;
	}

	private void Start()
	{
		convertEntity = GetComponentInParent<DVConvertToEntity>();
	}

	private void OnEnable()
	{
		if (IsLit || IsIgniting)
		{
			IsIgniting = false;
			currentFlameIntensity = requestedFlameIntensity;
			UpdateFlameIntensity(requestedFlameIntensity);
			UpdateGlare();
		}
	}

	private void OnDisable()
	{
		StopAndClearToggleCoroutines();
	}

	private void Update()
	{
		Vector3 localPosition = ignitable.GetTransform().localPosition;
		VelocityParent value;
		float3 float5 = (convertEntity.TryGetComponentData<VelocityParent>().IsSome(out value) ? value.relativeToParentVelocity.globalVelocity : convertEntity.GetComponentData<VelocityEstimate>().globalVelocity);
		float5 *= 0.001f;
		UpdateFlame(float5, forced: false);
		UpdateGlare();
		prevPos = localPosition;
	}

	private void UpdateGlare()
	{
		if (!hasGlare)
		{
			return;
		}
		glareAnchor.gameObject.SetActive(IsLit);
		Camera activeCamera = PlayerManager.ActiveCamera;
		if (!(activeCamera == null))
		{
			Vector3 vector = activeCamera.transform.position - glareAnchor.position;
			float sqrMagnitude = vector.sqrMagnitude;
			Vector3 vector2 = vector.normalized;
			if (vector2 == Vector3.zero)
			{
				vector2 = glareAnchor.forward;
			}
			Quaternion rotation = Quaternion.LookRotation(vector2, base.transform.up);
			glareAnchor.rotation = rotation;
			float t = Mathf.Clamp01(sqrMagnitude / (glareScaleMaxDistance * glareScaleMaxDistance));
			float num = Mathf.Lerp(glareScaleMin, glareScaleMax, t);
			glareTransform.localScale = Vector3.one * num;
			Color value = Color.Lerp(glareColorMin, glareColorMax, currentFlameIntensity);
			glarePropertyBlock.SetColor(tintColor, value);
			glareRenderer.SetPropertyBlock(glarePropertyBlock);
		}
	}

	protected void FireEvent(bool ignited)
	{
		if (ignited)
		{
			this.FlameIgnited?.Invoke();
		}
		else
		{
			this.FlameExtinguished?.Invoke();
		}
	}

	public virtual void UpdateFlameIntensity(float intensity, bool forced = false)
	{
		requestedFlameIntensity = Mathf.Clamp01(intensity);
		bool flag = IsUnderWater();
		bool flag2 = !flag && requestedFlameIntensity > float.Epsilon;
		if (flag2 == IsLit && !forced)
		{
			return;
		}
		bool shouldExtinguishByEnvironment = flag && IsLit;
		IsLit = flag2;
		UpdateGlare();
		IsIgniting = false;
		StopAndClearToggleCoroutines();
		if (ignitable.GetTransform().gameObject.activeInHierarchy && !forced)
		{
			base.gameObject.SetActive(value: true);
			if (flag2)
			{
				ignitionCoroutine = StartCoroutine(FlameIgniteCoroutine(intensity));
			}
			else
			{
				extinguishCoroutine = StartCoroutine(FlameExtinguishCoroutine());
			}
		}
		else
		{
			HandleForcedIntensityChange(flag2, shouldExtinguishByEnvironment);
			FireEvent(flag2);
		}
	}

	protected virtual void HandleForcedIntensityChange(bool shouldBeLit, bool shouldExtinguishByEnvironment)
	{
		if (!shouldBeLit)
		{
			currentFlameIntensity = (requestedFlameIntensity = 0f);
		}
		UpdateFlame(Vector3.zero, forced: true);
		flameLight.gameObject.SetActive(shouldBeLit);
		if (shouldExtinguishByEnvironment && environmentalExtinguishSound != null)
		{
			environmentalExtinguishSound.Play(base.transform.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform.parent);
		}
		base.gameObject.SetActive(shouldBeLit);
	}

	private void StopAndClearToggleCoroutines()
	{
		if (ignitionCoroutine != null)
		{
			StopCoroutine(ignitionCoroutine);
		}
		if (extinguishCoroutine != null)
		{
			StopCoroutine(extinguishCoroutine);
		}
		ignitionCoroutine = null;
		extinguishCoroutine = null;
	}

	protected virtual void UpdateFlame(Vector3 vel, bool forced)
	{
		if (SingletonBehaviour<AppUtil>.Instance.IsTimePausedSafer)
		{
			return;
		}
		if (!forced && IsUnderWater())
		{
			UpdateFlameIntensity(0f, forced: true);
			return;
		}
		currentFlameIntensity = Mathf.Lerp(currentFlameIntensity, requestedFlameIntensity, 0.2f);
		flameRequestedScale = Vector3.Lerp(flameMinScale, flameMaxScale, currentFlameIntensity);
		lightRange = Mathf.Lerp(lightRangeMin, lightRangeMax, currentFlameIntensity);
		lightIntensity = Mathf.Lerp(lightIntensityMin, lightIntensityMax, currentFlameIntensity);
		float num = 0f;
		Transform transform = ignitable.GetTransform();
		float y = -0.22f + 0.44f * Mathf.PerlinNoise(Time.time * perlinFactorY, noiseOffset);
		float z = -0.22f + 0.44f * Mathf.PerlinNoise(noiseOffset, Time.time * perlinFactorZ);
		Vector3 normalized = new Vector3(1f, y, z).normalized;
		if (vel.sqrMagnitude > Mathf.Epsilon)
		{
			elapsedStaticStabilizationTime = 0f;
			elapsedDynamicStabilizationTime += Time.deltaTime;
			if (elapsedDynamicStabilizationTime > dynamicStabilizationTime)
			{
				elapsedDynamicStabilizationTime = dynamicStabilizationTime;
			}
			float x = 85f * Mathf.Clamp01(Mathf.Abs(vel.z) / maxSpeed) * (0f - Mathf.Sign(vel.z));
			float z2 = 85f * Mathf.Clamp01(Mathf.Abs(vel.x) / maxSpeed) * Mathf.Sign(vel.x);
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.Euler(x, 0f + num, z2) * Quaternion.LookRotation(normalized, Vector3.up), elapsedDynamicStabilizationTime / dynamicStabilizationTime);
		}
		else
		{
			elapsedDynamicStabilizationTime = 0f;
			elapsedStaticStabilizationTime += Time.deltaTime;
			if (elapsedStaticStabilizationTime > staticStabilizationTime)
			{
				elapsedStaticStabilizationTime = staticStabilizationTime;
			}
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.LookRotation(normalized, Vector3.up), elapsedStaticStabilizationTime / staticStabilizationTime);
		}
		float t = Mathf.Clamp01(Vector3.Dot(base.transform.up, transform.up) + 0.8f);
		flameCurrentScale = flameRequestedScale;
		float num2 = Mathf.Sign(vel.y);
		Vector3 normalized2 = vel.normalized;
		if (Mathf.Max(Mathf.Max(Mathf.Abs(normalized2.x), Mathf.Abs(normalized2.y)), Mathf.Abs(normalized2.z)) - Mathf.Abs(normalized2.y) > 0.001f)
		{
			flameCurrentScale.y *= Mathf.Lerp(0.1f, 1f, t) * (1f + num2 * Mathf.Clamp01(vel.sqrMagnitude / (scaleThresholdMultiplier * maxSpeed)));
		}
		else
		{
			flameCurrentScale.y *= Mathf.Lerp(0.1f, 1f, t) * (1f - num2 * Mathf.Clamp01(vel.sqrMagnitude / (scaleThresholdMultiplier * maxSpeed)));
		}
		if (!IsIgniting)
		{
			base.transform.localScale = Vector3.SmoothDamp(base.transform.localScale, flameCurrentScale, ref flameScaleVelocity, 0.1f);
		}
		flameLight.transform.position = lightAnchor.position;
		float num3 = 1f + (Mathf.PerlinNoise(noiseOffset, Time.time * perlinFactorL) - 0.5f) * lightVariation;
		flameLight.intensity = lightIntensity * num3;
		flameLight.range = lightRange * num3;
	}

	public bool IsUnderWater()
	{
		return LevelInfo.IsUnderWater(base.transform.position);
	}
}
