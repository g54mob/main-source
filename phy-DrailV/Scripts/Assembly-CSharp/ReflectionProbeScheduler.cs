using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DV.Utils;
using DV.WeatherSystem;
using UnityEngine;
using UnityEngine.Rendering;

public class ReflectionProbeScheduler : SingletonBehaviour<ReflectionProbeScheduler>
{
	private List<DynamicReflectionProbe> allProbes = new List<DynamicReflectionProbe>();

	private DynamicReflectionProbe currentRenderer;

	private int roundRobin;

	private bool firstUpdate = true;

	public DynamicReflectionProbe BaseProbe { get; private set; }

	public DynamicReflectionProbe FullEnvironmentProbe { get; private set; }

	public new static string AllowAutoCreate()
	{
		return "[ReflectionProbeScheduler]";
	}

	protected override void Awake()
	{
		base.Awake();
		GamePreferences.RegisterToPreferenceUpdated(Preferences.ReflectionQualityIndex, OnReflectionQualityUpdated);
	}

	private void Start()
	{
		OnReflectionQualityUpdated();
	}

	private new void OnDestroy()
	{
		base.OnDestroy();
		GamePreferences.UnregisterFromPreferenceUpdated(Preferences.ReflectionQualityIndex, OnReflectionQualityUpdated);
	}

	private void OnReflectionQualityUpdated()
	{
		GraphicsOptions.WaterReflectionQuality waterReflectionQualityLevel = SingletonBehaviour<GraphicsOptions>.Instance.WaterReflectionQualityLevel;
		ReflectionProbeTimeSlicingMode reflectionProbeTimeSlicingMode = ReflectionProbeTimeSlicingMode.IndividualFaces;
		ReflectionProbeTimeSlicingMode reflectionProbeTimeSlicingMode2 = ReflectionProbeTimeSlicingMode.NoTimeSlicing;
		int num = 32;
		int num2 = 0;
		int num3 = 0;
		bool flag = false;
		switch (waterReflectionQualityLevel)
		{
		case GraphicsOptions.WaterReflectionQuality.VERY_LOW:
			reflectionProbeTimeSlicingMode = ReflectionProbeTimeSlicingMode.IndividualFaces;
			reflectionProbeTimeSlicingMode2 = ReflectionProbeTimeSlicingMode.IndividualFaces;
			num = 32;
			num2 = 0;
			num3 = 0;
			flag = false;
			break;
		case GraphicsOptions.WaterReflectionQuality.LOW:
			reflectionProbeTimeSlicingMode = ReflectionProbeTimeSlicingMode.IndividualFaces;
			reflectionProbeTimeSlicingMode2 = ReflectionProbeTimeSlicingMode.IndividualFaces;
			num = 256;
			num2 = LayerMask.GetMask("Terrain");
			num3 = 0;
			flag = true;
			break;
		case GraphicsOptions.WaterReflectionQuality.MEDIUM:
			reflectionProbeTimeSlicingMode = ReflectionProbeTimeSlicingMode.IndividualFaces;
			reflectionProbeTimeSlicingMode2 = ReflectionProbeTimeSlicingMode.IndividualFaces;
			num = 128;
			num2 = LayerMask.GetMask("Terrain");
			num3 = 0;
			flag = true;
			break;
		case GraphicsOptions.WaterReflectionQuality.HIGH:
			reflectionProbeTimeSlicingMode = ReflectionProbeTimeSlicingMode.IndividualFaces;
			reflectionProbeTimeSlicingMode2 = ReflectionProbeTimeSlicingMode.IndividualFaces;
			num = 256;
			num2 = LayerMask.GetMask("Terrain");
			num3 = LayerMask.GetMask("Reflection_Probe_Only");
			flag = true;
			break;
		case GraphicsOptions.WaterReflectionQuality.VERY_HIGH:
			reflectionProbeTimeSlicingMode = ReflectionProbeTimeSlicingMode.IndividualFaces;
			reflectionProbeTimeSlicingMode2 = ReflectionProbeTimeSlicingMode.NoTimeSlicing;
			num = 512;
			num2 = LayerMask.GetMask("Terrain");
			num3 = LayerMask.GetMask("Reflection_Probe_Only");
			flag = true;
			break;
		default:
			Debug.LogError($"Unhandled water quality level '{waterReflectionQualityLevel}'");
			return;
		}
		if (TOD_Sky.Instance != null)
		{
			TOD_Sky.Instance.UpdateSkybox = num2 == 0;
		}
		StartCoroutine(FirstWaveUpdate(num2, num, reflectionProbeTimeSlicingMode, flag, num3, reflectionProbeTimeSlicingMode2));
	}

	private IEnumerator FirstWaveUpdate(int baseLayers, int desiredProbeRes, ReflectionProbeTimeSlicingMode baseRefresh, bool crossfade, int envLayers, ReflectionProbeTimeSlicingMode envRefresh)
	{
		yield return null;
		for (int i = 0; i < allProbes.Count; i++)
		{
			if (allProbes[i].probeType == DynamicReflectionProbe.ProbeType.SkyboxBase)
			{
				allProbes[i].SetOptions((baseLayers == 0) ? ReflectionProbeClearFlags.Skybox : ReflectionProbeClearFlags.SolidColor, baseLayers, desiredProbeRes, baseRefresh);
				allProbes[i].crossfadeEnabled = crossfade;
			}
		}
		StartCoroutine(SecondWaveResolutionUpdate(desiredProbeRes, envLayers, envRefresh, crossfade));
	}

	private IEnumerator SecondWaveResolutionUpdate(int desiredResolution, int envMask, ReflectionProbeTimeSlicingMode mode, bool crossfade)
	{
		for (int i = 0; i < 3; i++)
		{
			yield return null;
		}
		for (int j = 0; j < allProbes.Count; j++)
		{
			if (allProbes[j].probeType != DynamicReflectionProbe.ProbeType.SkyboxBase)
			{
				allProbes[j].SetOptions(ReflectionProbeClearFlags.Skybox, envMask, desiredResolution, mode);
				allProbes[j].crossfadeEnabled = crossfade;
			}
		}
	}

	private bool CheckIfSafeToRender()
	{
		if (!WorldStreamingInit.IsLoaded || UnloadWatcher.isUnloading)
		{
			return false;
		}
		if ((bool)SingletonBehaviour<WeatherDriver>.Instance && SingletonBehaviour<WeatherDriver>.Instance.IsLightningFlashing)
		{
			return false;
		}
		return true;
	}

	public void RegisterProbe(DynamicReflectionProbe probe)
	{
		allProbes.Add(probe);
		allProbes.Sort((DynamicReflectionProbe a, DynamicReflectionProbe b) => a.probeType.CompareTo(b.probeType));
		if (probe.probeType == DynamicReflectionProbe.ProbeType.SkyboxBase && BaseProbe == null)
		{
			BaseProbe = probe;
		}
		if (probe.probeType == DynamicReflectionProbe.ProbeType.FullEnvironment && FullEnvironmentProbe == null)
		{
			FullEnvironmentProbe = probe;
		}
	}

	public void UnregisterProbe(DynamicReflectionProbe probe)
	{
		allProbes.Remove(probe);
		if (BaseProbe == probe)
		{
			BaseProbe = allProbes.FirstOrDefault((DynamicReflectionProbe p) => p.probeType == DynamicReflectionProbe.ProbeType.SkyboxBase);
		}
		if (FullEnvironmentProbe == probe)
		{
			FullEnvironmentProbe = allProbes.FirstOrDefault((DynamicReflectionProbe p) => p.probeType == DynamicReflectionProbe.ProbeType.FullEnvironment);
		}
	}

	private void Update()
	{
		if (!CheckIfSafeToRender())
		{
			return;
		}
		if (firstUpdate)
		{
			firstUpdate = false;
			for (int i = 0; i < allProbes.Count; i++)
			{
				if (allProbes[i].probeType == DynamicReflectionProbe.ProbeType.SkyboxBase)
				{
					roundRobin = i;
					allProbes[i].TurnProbeOn();
				}
			}
			for (int j = 0; j < allProbes.Count; j++)
			{
				if (allProbes[j].probeType != DynamicReflectionProbe.ProbeType.SkyboxBase)
				{
					allProbes[j].TurnProbeOn();
				}
			}
			return;
		}
		if (currentRenderer != null)
		{
			if (!currentRenderer.IsRendering)
			{
				currentRenderer = null;
				roundRobin = (roundRobin + 1) % allProbes.Count;
			}
			return;
		}
		if (roundRobin >= allProbes.Count)
		{
			roundRobin = 0;
		}
		if (roundRobin < allProbes.Count)
		{
			if (allProbes[roundRobin].WantsToUpdate && !allProbes[roundRobin].IsRendering && allProbes[roundRobin].IsReady)
			{
				currentRenderer = allProbes[roundRobin];
				allProbes[roundRobin].DispatchRender();
			}
			else
			{
				roundRobin++;
			}
		}
	}
}
