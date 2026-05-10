using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DayNightCycle : MonoBehaviour, ISavable
{
	public enum EDayNightCycleState
	{
		FirstDay = 0,
		Day = 1,
		DayToSunset = 2,
		SunsetToNight = 3,
		Night = 4,
		NightToSunrise = 5,
		SunriseToDay = 6
	}

	[Header("Common")]
	[SerializeField]
	private float environmentUpdateTimeTreshold = 0.5f;

	[SerializeField]
	private bool isMainMenu;

	[Header("Cycle Durations")]
	[SerializeField]
	private float firstDayDuration = 5f;

	[SerializeField]
	private float dayToSunsetDuration = 5f;

	[SerializeField]
	private float sunsetToNightDuration = 5f;

	[SerializeField]
	private float nightToSunriseDuration = 5f;

	[SerializeField]
	private float sunriseToDayDuration = 5f;

	[SerializeField]
	private float dayPercentage = 0.1f;

	[SerializeField]
	private float sunsetPercentage = 0.4f;

	[SerializeField]
	private float nightPercentage = 0.8f;

	[SerializeField]
	private float sunrisePercentage = 0.8f;

	[Header("Directional Light")]
	[SerializeField]
	private Light directionalLight;

	[SerializeField]
	private float directionalLightYaw;

	[SerializeField]
	private float directionalLightPitch = 60f;

	[SerializeField]
	private Gradient lightGradient;

	[SerializeField]
	private AnimationCurve lightIntensity;

	[SerializeField]
	private AnimationCurve shadowsStrength;

	[Header("Ambient light")]
	[SerializeField]
	private Material skybox;

	[SerializeField]
	[GradientUsage(true)]
	private Gradient ambientLightGradient;

	[Header("Fog")]
	[SerializeField]
	private bool fogEnabled = true;

	[SerializeField]
	private FullScreenPassRendererFeature fogRendererFeature;

	[SerializeField]
	private Material fogMaterial;

	[SerializeField]
	private AnimationCurve fogDensity;

	[SerializeField]
	private Gradient baseFogColor;

	[SerializeField]
	private Gradient sunFogColor;

	[Header("Debug")]
	[SerializeField]
	private bool disableCycle;

	private float extraFogDensity;

	private float currentFogDensity;

	private float currentExtraFogDensity;

	private Material tempSkybox;

	private ReflectionProbe globalReflectionProbe;

	private float lastTimeEnvironmentUpdate;

	private Coroutine currentCycleCoroutine;

	private Tween extraFogDensityTween;

	[Savable("currentCycleState", true, false)]
	private EDayNightCycleState currentCycleState;

	[Savable("timer", true, false)]
	private float timer;

	public bool FogEnabled
	{
		get
		{
			return fogEnabled;
		}
		set
		{
			fogEnabled = value;
			OnFogEnabledChanged();
		}
	}

	public float ExtraFogDensity
	{
		get
		{
			return extraFogDensity;
		}
		set
		{
			extraFogDensity = value;
			if ((bool)fogMaterial)
			{
				if (extraFogDensityTween.IsActive() && extraFogDensityTween.IsPlaying())
				{
					extraFogDensityTween.Kill();
				}
				extraFogDensityTween = DOTween.To(() => currentExtraFogDensity, delegate(float x)
				{
					currentExtraFogDensity = x;
				}, extraFogDensity, 4f);
				Tween tween = extraFogDensityTween;
				tween.onUpdate = (TweenCallback)Delegate.Combine(tween.onUpdate, (TweenCallback)delegate
				{
					UpdateFogDensity();
				});
			}
		}
	}

	public EDayNightCycleState CurrentCycleState
	{
		get
		{
			return currentCycleState;
		}
		private set
		{
			currentCycleState = value;
		}
	}

	public event Action<EDayNightCycleState, float> onCycleStateChanged;

	private void Start()
	{
		tempSkybox = new Material(skybox);
		OnLevelWasLoaded(-1);
		if (!fogRendererFeature || !fogMaterial)
		{
			FogEnabled = false;
		}
		if (isMainMenu)
		{
			StartDayNightCycle();
			return;
		}
		SetupGlobalReflectionProbe();
		if ((bool)LTFunctionLibrary.GetLTGameManager())
		{
			if (LTFunctionLibrary.GetLTGameManager().GameState == LTGameManager.EGameState.Playing)
			{
				StartDayNightCycle();
				return;
			}
			LTGameManager lTGameManager = LTFunctionLibrary.GetLTGameManager();
			lTGameManager.onGameStarted = (Action)Delegate.Combine(lTGameManager.onGameStarted, new Action(OnGameStarted));
		}
	}

	private void OnLevelWasLoaded(int level)
	{
		RenderSettings.skybox = tempSkybox;
		DynamicGI.synchronousMode = false;
		DynamicGI.updateThreshold = 1f;
		OnFogEnabledChanged();
	}

	private void OnDestroy()
	{
		RenderSettings.skybox = skybox;
		fogRendererFeature?.SetActive(active: false);
	}

	private void OnGameStarted()
	{
		StartDayNightCycle();
		LTGameManager lTGameManager = LTFunctionLibrary.GetLTGameManager();
		lTGameManager.onGameStarted = (Action)Delegate.Remove(lTGameManager.onGameStarted, new Action(OnGameStarted));
	}

	private void StartDayNightCycle()
	{
		switch (CurrentCycleState)
		{
		case EDayNightCycleState.FirstDay:
			this.StartCoroutineCheckingVar(FirstDayCoroutine(), ref currentCycleCoroutine);
			break;
		case EDayNightCycleState.Day:
			this.StartCoroutineCheckingVar(DayCoroutine(), ref currentCycleCoroutine);
			break;
		case EDayNightCycleState.DayToSunset:
			this.StartCoroutineCheckingVar(DayToSunsetCoroutine(), ref currentCycleCoroutine);
			break;
		case EDayNightCycleState.SunsetToNight:
			this.StartCoroutineCheckingVar(SunsetToNightCoroutine(), ref currentCycleCoroutine);
			break;
		case EDayNightCycleState.Night:
			DoCycle(nightPercentage);
			UpdateEnvirontment(forceUpdate: true);
			break;
		case EDayNightCycleState.NightToSunrise:
			this.StartCoroutineCheckingVar(NightToSunriseCoroutine(), ref currentCycleCoroutine);
			break;
		case EDayNightCycleState.SunriseToDay:
			this.StartCoroutineCheckingVar(SunriseToDayCoroutine(), ref currentCycleCoroutine);
			break;
		}
		if ((bool)LTFunctionLibrary.GetLTGameManager() && (bool)LTFunctionLibrary.GetCyclesManager())
		{
			CyclesManager cyclesManager = LTFunctionLibrary.GetCyclesManager();
			cyclesManager.onCycleChanged = (Action<int, ECycleMode>)Delegate.Combine(cyclesManager.onCycleChanged, new Action<int, ECycleMode>(OnCycleChanged));
		}
	}

	public float GetCurrentTransitionRemainingDuration()
	{
		return CurrentCycleState switch
		{
			EDayNightCycleState.FirstDay => firstDayDuration - timer, 
			EDayNightCycleState.Day => 0f, 
			EDayNightCycleState.DayToSunset => dayToSunsetDuration - timer, 
			EDayNightCycleState.SunsetToNight => sunsetToNightDuration - timer, 
			EDayNightCycleState.Night => 0f, 
			EDayNightCycleState.NightToSunrise => nightToSunriseDuration - timer, 
			EDayNightCycleState.SunriseToDay => sunriseToDayDuration - timer, 
			_ => 0f, 
		};
	}

	private IEnumerator FirstDayCoroutine()
	{
		CurrentCycleState = EDayNightCycleState.FirstDay;
		this.onCycleStateChanged?.Invoke(CurrentCycleState, GetCurrentTransitionRemainingDuration());
		currentExtraFogDensity = ExtraFogDensity;
		DoCycle(Mathf.Lerp(0f, dayPercentage, timer / firstDayDuration));
		UpdateEnvirontment(forceUpdate: true);
		while (timer <= firstDayDuration)
		{
			timer += Time.deltaTime;
			DoCycle(Mathf.Lerp(0f, dayPercentage, timer / firstDayDuration));
			yield return null;
		}
		timer = 0f;
		UpdateEnvirontment(forceUpdate: true);
		if (!isMainMenu)
		{
			this.StartCoroutineCheckingVar(DayCoroutine(), ref currentCycleCoroutine, stopCoroutineIfRunning: true);
		}
	}

	private IEnumerator DayCoroutine()
	{
		CurrentCycleState = EDayNightCycleState.Day;
		this.onCycleStateChanged?.Invoke(CurrentCycleState, GetCurrentTransitionRemainingDuration());
		timer = 0f;
		DoCycle(dayPercentage);
		UpdateEnvirontment(forceUpdate: true);
		while (!((float)LTFunctionLibrary.GetDayRemainingMilliseconds() <= (dayToSunsetDuration + sunsetToNightDuration) * 1000f))
		{
			yield return null;
		}
		this.StartCoroutineCheckingVar(DayToSunsetCoroutine(), ref currentCycleCoroutine, stopCoroutineIfRunning: true);
	}

	private IEnumerator DayToSunsetCoroutine()
	{
		CurrentCycleState = EDayNightCycleState.DayToSunset;
		this.onCycleStateChanged?.Invoke(CurrentCycleState, GetCurrentTransitionRemainingDuration());
		while (timer <= dayToSunsetDuration)
		{
			timer += Time.deltaTime;
			DoCycle(Mathf.Lerp(dayPercentage, sunsetPercentage, timer / dayToSunsetDuration));
			yield return null;
		}
		timer = 0f;
		UpdateEnvirontment(forceUpdate: true);
		this.StartCoroutineCheckingVar(SunsetToNightCoroutine(), ref currentCycleCoroutine, stopCoroutineIfRunning: true);
	}

	private IEnumerator SunsetToNightCoroutine()
	{
		CurrentCycleState = EDayNightCycleState.SunsetToNight;
		this.onCycleStateChanged?.Invoke(CurrentCycleState, GetCurrentTransitionRemainingDuration());
		while (timer <= sunsetToNightDuration)
		{
			timer += Time.deltaTime;
			DoCycle(Mathf.Lerp(sunsetPercentage, nightPercentage, timer / sunsetToNightDuration));
			yield return null;
		}
		timer = 0f;
		CurrentCycleState = EDayNightCycleState.Night;
		UpdateEnvirontment(forceUpdate: true);
		currentCycleCoroutine = null;
	}

	private IEnumerator NightToSunriseCoroutine()
	{
		CurrentCycleState = EDayNightCycleState.NightToSunrise;
		this.onCycleStateChanged?.Invoke(CurrentCycleState, GetCurrentTransitionRemainingDuration());
		float auxSunrisePercentage = ((sunrisePercentage < nightPercentage) ? (sunrisePercentage + 1f) : sunrisePercentage);
		while (timer <= nightToSunriseDuration)
		{
			timer += Time.deltaTime;
			DoCycle(Mathf.Repeat(Mathf.Lerp(nightPercentage, auxSunrisePercentage, timer / nightToSunriseDuration), 1f));
			yield return null;
		}
		timer = 0f;
		UpdateEnvirontment(forceUpdate: true);
		this.StartCoroutineCheckingVar(SunriseToDayCoroutine(), ref currentCycleCoroutine, stopCoroutineIfRunning: true);
	}

	private IEnumerator SunriseToDayCoroutine()
	{
		CurrentCycleState = EDayNightCycleState.SunriseToDay;
		this.onCycleStateChanged?.Invoke(CurrentCycleState, GetCurrentTransitionRemainingDuration());
		float auxDayPercentage = ((sunrisePercentage > dayPercentage) ? (dayPercentage + 1f) : dayPercentage);
		while (timer <= sunriseToDayDuration)
		{
			timer += Time.deltaTime;
			DoCycle(Mathf.Repeat(Mathf.Lerp(sunrisePercentage, auxDayPercentage, timer / sunriseToDayDuration), 1f));
			yield return null;
		}
		timer = 0f;
		UpdateEnvirontment(forceUpdate: true);
		this.StartCoroutineCheckingVar(DayCoroutine(), ref currentCycleCoroutine, stopCoroutineIfRunning: true);
	}

	private void DoCycle(float cyclePercentage)
	{
		directionalLight.transform.rotation = Quaternion.Euler(0f, directionalLightYaw, 0f) * Quaternion.Euler(0f, 0f, Mathf.Repeat(cyclePercentage * 360f, 180f) - 90f) * Quaternion.Euler(directionalLightPitch, 0f, 0f);
		directionalLight.color = lightGradient.Evaluate(cyclePercentage);
		directionalLight.intensity = lightIntensity.Evaluate(cyclePercentage);
		directionalLight.shadowStrength = shadowsStrength.Evaluate(cyclePercentage);
		tempSkybox.SetColor("_SkyColor", ambientLightGradient.Evaluate(cyclePercentage));
		UpdateFog(cyclePercentage);
		UpdateEnvirontment();
	}

	private void UpdateFog(float cyclePercentage)
	{
		if (FogEnabled)
		{
			currentFogDensity = fogDensity.Evaluate(cyclePercentage);
			UpdateFogDensity();
			fogMaterial.SetColor("_BaseFogColor", baseFogColor.Evaluate(cyclePercentage));
			fogMaterial.SetColor("_SunFogColor", sunFogColor.Evaluate(cyclePercentage));
		}
	}

	private void UpdateFogDensity()
	{
		fogMaterial.SetFloat("_FogDensity", currentFogDensity + currentExtraFogDensity);
	}

	private void OnCycleChanged(int currentCycle, ECycleMode mode)
	{
		if (mode == ECycleMode.Neutral)
		{
			this.StartCoroutineCheckingVar(NightToSunriseCoroutine(), ref currentCycleCoroutine);
		}
	}

	private void UpdateEnvirontment(bool forceUpdate = false)
	{
		if (forceUpdate || Time.time > lastTimeEnvironmentUpdate + environmentUpdateTimeTreshold)
		{
			lastTimeEnvironmentUpdate = Time.time;
			DynamicGI.UpdateEnvironment();
			if ((bool)globalReflectionProbe)
			{
				globalReflectionProbe.RenderProbe();
			}
		}
	}

	private void SetupGlobalReflectionProbe()
	{
		globalReflectionProbe = new GameObject("GlobalReflectionProbe").AddComponent<ReflectionProbe>();
		globalReflectionProbe.transform.parent = base.transform;
		globalReflectionProbe.mode = ReflectionProbeMode.Realtime;
		globalReflectionProbe.refreshMode = ReflectionProbeRefreshMode.ViaScripting;
		globalReflectionProbe.timeSlicingMode = ReflectionProbeTimeSlicingMode.IndividualFaces;
		globalReflectionProbe.hdr = false;
		globalReflectionProbe.resolution = 32;
		globalReflectionProbe.intensity = 0.5f;
		globalReflectionProbe.cullingMask = 0;
		int levelSizeX = LTFunctionLibrary.GetLTLevelController().LevelSizeX;
		int levelSizeZ = LTFunctionLibrary.GetLTLevelController().LevelSizeZ;
		globalReflectionProbe.transform.position = new Vector3((float)levelSizeX * 0.5f, 5f, (float)levelSizeZ * 0.5f);
		globalReflectionProbe.size = new Vector3(levelSizeX + 15, 25f, levelSizeZ + 15);
		globalReflectionProbe.RenderProbe();
	}

	private void OnFogEnabledChanged()
	{
		if ((bool)fogRendererFeature)
		{
			fogRendererFeature.SetActive(FogEnabled);
			if ((bool)fogMaterial)
			{
				fogRendererFeature.passMaterial = fogMaterial;
			}
			UpdateFog(0f);
		}
	}

	public void OnSave()
	{
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
	}
}
