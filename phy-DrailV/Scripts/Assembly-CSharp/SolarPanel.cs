using System.Collections;
using System.Collections.Generic;
using DV.Utils;
using DV.WeatherSystem;
using UnityEngine;

public class SolarPanel : BatteryPowerProviderBase
{
	private const string TRANSPARENT_TAG = "Windows";

	private const float MINIMUM_DAY_LIGHT_INTENSITY = 0.2f;

	private const float DAY_START_TIME = 0.25f;

	private const float DAY_END_TIME = 0.83f;

	private const float SHADOW_CHECK_DISTANCE = 1500f;

	[SerializeField]
	private Transform solarPanelTransform;

	[SerializeField]
	private AnimationCurve timeToIntensityCurve;

	[SerializeField]
	private bool useCurve = true;

	private float currentTimeOfDay;

	private float previousTimeOfDay;

	private Light sunLight;

	private Transform sunTransform;

	private float currentLightIntensity;

	private float previousLightIntensity;

	private WeatherPresetManager weatherPresetManager;

	private float elapsedUpdateTime;

	private float averageLightIntensity;

	private bool isDay;

	private int sunBlockingLayers;

	private RaycastHit[] sunBlockHits = new RaycastHit[16];

	private HashSet<Collider> ignoredBlockingColliders = new HashSet<Collider>();

	private Coroutine initCoro;

	public bool Initialized { get; private set; }

	private void Start()
	{
		initCoro = SingletonBehaviour<CoroutineManager>.Instance.Run(Initialize());
	}

	private void OnDisable()
	{
		StopPowerUpdate();
	}

	private void OnDestroy()
	{
		if (!UnloadWatcher.isUnloading && initCoro != null)
		{
			SingletonBehaviour<CoroutineManager>.Instance.Stop(initCoro);
		}
	}

	private void OnEnable()
	{
		if (Initialized)
		{
			UpdateTime();
			StartPowerUpdate();
		}
	}

	private IEnumerator Initialize()
	{
		if (solarPanelTransform == null)
		{
			solarPanelTransform = base.transform;
		}
		sunBlockingLayers = LayerMask.GetMask("Terrain", "Default", "Train_Interior", "Interactable", "Grabbed_Item", "World_Item");
		while (SingletonBehaviour<WeatherDriver>.Instance == null)
		{
			yield return null;
		}
		weatherPresetManager = SingletonBehaviour<WeatherDriver>.Instance.manager;
		yield return null;
		sunLight = weatherPresetManager.LightSource;
		sunTransform = sunLight.transform;
		previousTimeOfDay = (currentTimeOfDay = weatherPresetManager.timeOfDay);
		elapsedUpdateTime = 0f;
		isDay = !(currentTimeOfDay < 0.25f) && !(currentTimeOfDay > 0.83f);
		Initialized = true;
		if (base.gameObject.activeInHierarchy)
		{
			StartPowerUpdate();
		}
		initCoro = null;
	}

	private void UpdateTime()
	{
		previousTimeOfDay = currentTimeOfDay;
		currentTimeOfDay = weatherPresetManager.timeOfDay;
		elapsedUpdateTime = currentTimeOfDay - previousTimeOfDay;
		if (elapsedUpdateTime < 0f)
		{
			elapsedUpdateTime = 1f + elapsedUpdateTime;
		}
	}

	private void CalculateEffectiveLightIntensity()
	{
		if (currentTimeOfDay < 0.25f || currentTimeOfDay > 0.83f)
		{
			isDay = false;
			currentLightIntensity = 0f;
		}
		else
		{
			isDay = true;
			if (useCurve)
			{
				float time = (currentTimeOfDay - 0.25f) / 0.58f;
				currentLightIntensity = timeToIntensityCurve.Evaluate(time);
			}
			else
			{
				currentLightIntensity = sunLight.intensity * Mathf.Clamp01(Vector3.Dot(solarPanelTransform.up, -sunTransform.forward));
			}
			currentLightIntensity *= 1f - SingletonBehaviour<WeatherDriver>.Instance.GetFogginess(base.transform.position);
		}
		averageLightIntensity = (currentLightIntensity + previousLightIntensity) * 0.5f;
		previousLightIntensity = currentLightIntensity;
	}

	private bool SurfaceInShade(Vector3 surfacePosition)
	{
		int num = Physics.RaycastNonAlloc(new Ray(surfacePosition, -sunTransform.forward), sunBlockHits, 1500f, sunBlockingLayers);
		RaycastUtils.ExtendOnCacheFull(ref sunBlockHits, num);
		bool result = false;
		for (int i = 0; i < num; i++)
		{
			Collider collider = sunBlockHits[i].collider;
			if (!ignoredBlockingColliders.Contains(collider) && !collider.CompareTag("Windows"))
			{
				result = true;
				break;
			}
		}
		return result;
	}

	protected override float GenerateBatteryPower()
	{
		if (!Initialized)
		{
			return 0f;
		}
		UpdateTime();
		CalculateEffectiveLightIntensity();
		if (!isDay || Mathf.Approximately(elapsedUpdateTime, 0f))
		{
			return 0f;
		}
		float num = averageLightIntensity;
		if (num < 0.2f || SurfaceInShade(solarPanelTransform.position))
		{
			num = 0.2f;
		}
		return num * elapsedUpdateTime * outputPerUnitTime;
	}

	public void IgnoreSunBlocking(Collider collider)
	{
		ignoredBlockingColliders.Add(collider);
	}
}
