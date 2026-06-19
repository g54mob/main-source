using System.Collections.Generic;
using Pug.RP;
using Pug.Sprite;
using Unity.Profiling;
using UnityEngine;

public class ManagedLight : MonoBehaviour
{
	private struct ManagedLightObject
	{
		public ManagedLight light;

		public Transform transform;

		public ManagedLightObject(ManagedLight light)
		{
			this.light = light;
			transform = light.transform;
		}
	}

	private static readonly ProfilerMarker OptimizeLightSourcesMarker = new ProfilerMarker("OptimizeLightSources");

	[ClearOnReload(true)]
	private static List<ManagedLightObject> allLights = new List<ManagedLightObject>();

	public static float optimizationBucketSize = 2f;

	public static bool forceFallbacks = false;

	public bool neverOptimize;

	public GameObject lightContainer;

	public Light lightToOptimize;

	public SpriteObject fallbackRenderer;

	private static Dictionary<Vector2Int, ManagedLight> s_bucketDominantLight = new Dictionary<Vector2Int, ManagedLight>();

	private static int s_activitionIndexPool = int.MinValue;

	private int m_activationIndex;

	private Vector2Int m_bucket;

	private bool m_wantToOptimize;

	private PugLight m_pugLight;

	private bool m_hasFallbackRenderer;

	private ManagedLightObject thisLight;

	public bool isLightEnabled
	{
		get
		{
			if (lightToOptimize.gameObject.activeSelf)
			{
				return lightToOptimize.enabled;
			}
			return false;
		}
	}

	private void Awake()
	{
		lightToOptimize.TryGetPugLight(out m_pugLight);
		m_hasFallbackRenderer = fallbackRenderer != null;
	}

	private void OnEnable()
	{
		thisLight = new ManagedLightObject(this);
		allLights.Add(thisLight);
		m_activationIndex = s_activitionIndexPool;
		s_activitionIndexPool++;
		if (m_hasFallbackRenderer)
		{
			fallbackRenderer.gameObject.SetActive(value: false);
		}
		lightToOptimize.enabled = true;
	}

	private void OnDisable()
	{
		allLights.Remove(thisLight);
	}

	public static void UpdateOptimization()
	{
		if (allLights.Count < 1)
		{
			return;
		}
		s_bucketDominantLight.Clear();
		for (int i = 0; i < allLights.Count; i++)
		{
			ManagedLight light = allLights[i].light;
			Vector3 vector = allLights[i].transform.position + Manager.camera.RenderOrigo;
			if (light.neverOptimize || !light.isLightEnabled)
			{
				continue;
			}
			light.m_bucket.x = Mathf.FloorToInt(vector.x / optimizationBucketSize);
			light.m_bucket.y = Mathf.FloorToInt(vector.z / optimizationBucketSize);
			if (s_bucketDominantLight.TryGetValue(light.m_bucket, out var value))
			{
				if (value.m_activationIndex > light.m_activationIndex)
				{
					light.m_wantToOptimize = true;
					continue;
				}
				value.m_wantToOptimize = true;
				light.m_wantToOptimize = false;
				s_bucketDominantLight[light.m_bucket] = light;
			}
			else
			{
				s_bucketDominantLight.Add(light.m_bucket, light);
				light.m_wantToOptimize = false;
			}
		}
		for (int j = 0; j < allLights.Count; j++)
		{
			ManagedLight light2 = allLights[j].light;
			light2.SetOptimized(light2.m_wantToOptimize || forceFallbacks);
		}
	}

	private void SetOptimized(bool state)
	{
		if (neverOptimize || !m_hasFallbackRenderer)
		{
			state = false;
		}
		m_pugLight.quality = (state ? Manager.lights.optimizedLightsQuality : Manager.lights.lightsQuality);
		if (lightContainer.activeInHierarchy != !state)
		{
			lightContainer.SetActive(!state);
		}
		bool flag = state;
		if (!m_pugLight.shouldRender)
		{
			flag = true;
		}
		if (!lightToOptimize.gameObject.activeSelf || !lightToOptimize.enabled)
		{
			flag = false;
		}
		if (m_hasFallbackRenderer)
		{
			if (flag)
			{
				Color color = lightToOptimize.color;
				color.a = 1f;
				color *= lightToOptimize.intensity * lightToOptimize.range * Manager.lights.optimizedLightsWeight;
				fallbackRenderer.emissiveColor = color;
			}
			if (fallbackRenderer.gameObject.activeInHierarchy != flag)
			{
				fallbackRenderer.gameObject.SetActive(flag);
			}
		}
	}
}
