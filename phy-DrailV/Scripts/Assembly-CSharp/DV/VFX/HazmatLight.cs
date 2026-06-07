using UnityEngine;

namespace DV.VFX
{
	public class HazmatLight
	{
		public Vector3 originPoint;

		public float multiplier = 1f;

		private Light light;

		private float wiggleRange = 2f;

		private float wiggleSpeed = 1.5f;

		private float intensityRange = 1.2f;

		private float intensitySpeed = 2f;

		private float intensity;

		private float targetIntensity;

		private MeshRenderer[] renderers;

		private MaterialPropertyBlock props;

		private const float INTENSITY_TO_DENSITY_SCALE = 0.1f;

		private float positionPhase = 1f;

		private Vector3 startPosition = Vector3.zero;

		private Vector3 targetPosition = Vector3.zero;

		private static readonly int spDensity = Shader.PropertyToID("_Density");

		private static readonly int spColor = Shader.PropertyToID("_Color");

		public Transform Transform { get; private set; }

		public bool IsOn
		{
			get
			{
				if (!(intensity > 0f))
				{
					return targetIntensity > 0f;
				}
				return true;
			}
		}

		public HazmatLight(GameObject rootObject)
		{
			Transform = rootObject.transform;
			light = rootObject.GetComponent<Light>();
			renderers = rootObject.GetComponentsInChildren<MeshRenderer>();
			props = new MaterialPropertyBlock();
			light.enabled = false;
			light.intensity = 0f;
			MeshRenderer[] array = renderers;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enabled = false;
			}
		}

		public void Replicate(HazmatLight other)
		{
			intensity = other.intensity;
			originPoint = other.originPoint;
			light.enabled = other.light.enabled;
			light.intensity = other.light.intensity;
			targetIntensity = other.targetIntensity;
			positionPhase = other.positionPhase;
			startPosition = other.startPosition;
			targetPosition = other.targetPosition;
			bool flag = light.intensity > 0f;
			if (flag)
			{
				props.SetFloat(spDensity, light.intensity * 0.1f);
				props.SetColor(spColor, light.color);
			}
			MeshRenderer[] array = renderers;
			foreach (MeshRenderer meshRenderer in array)
			{
				if (flag)
				{
					meshRenderer.SetPropertyBlock(props);
				}
				meshRenderer.enabled = flag;
			}
			Transform.localPosition = other.Transform.localPosition;
		}

		public void Reset()
		{
			intensity = 0f;
			Transform.localPosition = originPoint;
			light.enabled = false;
			light.intensity = 0f;
			targetIntensity = 0f;
			positionPhase = 1f;
			startPosition = originPoint;
			targetPosition = originPoint;
			MeshRenderer[] array = renderers;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enabled = false;
			}
		}

		public void Tick(float deltaTime)
		{
			if (positionPhase < 1f)
			{
				positionPhase = Mathf.Clamp01(positionPhase + deltaTime);
				originPoint = Vector3.Lerp(startPosition, targetPosition, Mathf.SmoothStep(0f, 1f, positionPhase));
			}
			Vector3 vector = originPoint;
			if (deltaTime > 0f && intensity > 0f)
			{
				Transform.localPosition = originPoint + new Vector3(Mathf.PerlinNoise(Time.realtimeSinceStartup * wiggleSpeed, 1f) * wiggleRange, Mathf.PerlinNoise(Time.realtimeSinceStartup * wiggleSpeed, vector.x + vector.z) * 0.5f * wiggleRange, Mathf.PerlinNoise(Time.realtimeSinceStartup * wiggleSpeed, vector.x + vector.z + 3f) * wiggleRange);
				light.intensity = multiplier * Mathf.Lerp(intensity, intensity * intensityRange, Mathf.PerlinNoise(Time.realtimeSinceStartup * intensitySpeed, 5f));
			}
			if (targetIntensity > intensity)
			{
				intensity = Mathf.Min(targetIntensity, intensity + deltaTime);
			}
			else if (targetIntensity < intensity)
			{
				intensity = Mathf.Max(targetIntensity, intensity - deltaTime * 0.1f);
			}
			bool flag = multiplier * intensity > 0f;
			light.enabled = flag;
			if (flag)
			{
				props.SetFloat(spDensity, light.intensity * 0.1f);
				props.SetColor(spColor, light.color);
			}
			MeshRenderer[] array = renderers;
			foreach (MeshRenderer meshRenderer in array)
			{
				if (flag)
				{
					meshRenderer.SetPropertyBlock(props);
				}
				meshRenderer.enabled = flag;
			}
		}

		public void SetIntensity(float newIntensity)
		{
			targetIntensity = newIntensity;
		}

		public void TransitionPosition(Vector3 position)
		{
			startPosition = originPoint;
			targetPosition = position;
			positionPhase = 0f;
		}
	}
}
