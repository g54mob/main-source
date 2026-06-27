using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DistantLands.Cozy.Data;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

namespace DistantLands.Cozy
{
	[ExecuteAlways]
	public class CozyWeather : CozySystem
	{
		public enum LockToCameraStyle
		{
			useMainCamera = 0,
			useCustomCamera = 1,
			DontLockToCamera = 2
		}

		public delegate void RefreshModules();

		[Serializable]
		public class Events
		{
			public delegate void OnEvening();

			public delegate void OnMorning();

			public delegate void OnNewHour();

			public delegate void OnMinutePass();

			public delegate void OnNight();

			public delegate void OnDay();

			public delegate void OnDawn();

			public delegate void OnAfternoon();

			public delegate void OnTwilight();

			public delegate void OnWeatherChange();

			public delegate void OnDayChange();

			public delegate void OnYearChange();

			public float timeToCheckFor;

			public int currentMinute;

			public int currentHour;

			public static event OnEvening onEvening;

			public static event OnMorning onMorning;

			public static event OnNewHour onNewHour;

			public static event OnMinutePass onNewMinute;

			public static event OnNight onNight;

			public static event OnDay onDay;

			public static event OnDawn onDawn;

			public static event OnAfternoon onAfternoon;

			public static event OnTwilight onTwilight;

			public static event OnWeatherChange onWeatherChange;

			public static event OnDayChange onNewDay;

			public static event OnYearChange onNewYear;

			public void RaiseOnEvening()
			{
				Events.onEvening?.Invoke();
			}

			public void RaiseOnMorning()
			{
				Events.onMorning?.Invoke();
			}

			public void RaiseOnNewHour()
			{
				Events.onNewHour?.Invoke();
			}

			public void RaiseOnMinutePass()
			{
				Events.onNewMinute?.Invoke();
			}

			public void RaiseOnNight()
			{
				Events.onNight?.Invoke();
			}

			public void RaiseOnDay()
			{
				Events.onDay?.Invoke();
			}

			public void RaiseOnDawn()
			{
				Events.onDawn?.Invoke();
			}

			public void RaiseOnAfternoon()
			{
				Events.onAfternoon?.Invoke();
			}

			public void RaiseOnTwilight()
			{
				Events.onTwilight?.Invoke();
			}

			public void RaiseOnWeatherChange()
			{
				Events.onWeatherChange?.Invoke();
			}

			public void RaiseOnDayChange()
			{
				Events.onNewDay?.Invoke();
			}

			public void RaiseOnYearChange()
			{
				Events.onNewYear?.Invoke();
			}
		}

		public delegate void FrameResetDelegate();

		public delegate void UpdateWeatherWeightsDelegate();

		public delegate void UpdateFXWeightsDelegate();

		public delegate void PropogateVariablesDelegate();

		public delegate void CozyUpdateLoopDelegate();

		public enum ControlMethod
		{
			native = 0,
			profile = 1
		}

		public enum SkyStyle
		{
			desktop = 0,
			mobile = 1,
			off = 2
		}

		public enum CloudStyle
		{
			cozyDesktop = 0,
			cozyMobile = 1,
			soft = 2,
			paintedSkies = 3,
			luxury = 4,
			ghibliDesktop = 5,
			ghibliMobile = 6,
			singleTexture = 7,
			off = 8
		}

		public enum FogStyle
		{
			unity = 0,
			stylized = 1,
			heightFog = 2,
			steppedFog = 3,
			off = 4
		}

		public float cumulus;

		public float cirrus;

		public float altocumulus;

		public float cirrostratus;

		public float chemtrails;

		public float nimbus;

		public float nimbusHeightEffect;

		public float nimbusVariation;

		public float borderHeight;

		public float borderEffect;

		public float borderVariation;

		public float fogDensity;

		[Tooltip("Should the atmosphere be set using the physical sun height or the time of day")]
		public bool usePhysicalSunHeight;

		public float sunDirection;

		public float sunPitch;

		public Vector3 moonDirection;

		[ColorUsage(true, true)]
		public Color skyZenithColor;

		[ColorUsage(true, true)]
		public Color skyHorizonColor;

		[ColorUsage(true, true)]
		public Color cloudColor;

		[ColorUsage(true, true)]
		public Color cloudHighlightColor;

		[ColorUsage(true, true)]
		public Color highAltitudeCloudColor;

		[ColorUsage(true, true)]
		public Color sunlightColor;

		[ColorUsage(true, true)]
		public Color starColor;

		[ColorUsage(true, true)]
		public Color ambientLightHorizonColor;

		[ColorUsage(true, true)]
		public Color ambientLightZenithColor;

		public float ambientLightMultiplier;

		public float galaxyIntensity;

		[ColorUsage(true, true)]
		public Color fogColor1;

		[ColorUsage(true, true)]
		public Color fogColor2;

		[ColorUsage(true, true)]
		public Color fogColor3;

		[ColorUsage(true, true)]
		public Color fogColor4;

		[ColorUsage(true, true)]
		public Color fogColor5;

		[ColorUsage(true, true)]
		public Color fogFlareColor;

		[ColorUsage(true, true)]
		public Color fogMoonFlareColor;

		[ColorUsage(true, true)]
		public Color fogShadowColor;

		[ColorUsage(true, true)]
		public Color fogLitColor;

		public float gradientExponent = 0.364f;

		public float sunSize = 0.7f;

		[ColorUsage(true, true)]
		public Color sunColor;

		[ColorUsage(true, true)]
		public Color moonColor;

		public float sunFalloff = 43.7f;

		[ColorUsage(true, true)]
		public Color sunFlareColor;

		public float moonFalloff = 24.4f;

		[ColorUsage(true, true)]
		public Color moonlightColor;

		[ColorUsage(true, true)]
		public Color moonFlareColor;

		[ColorUsage(true, true)]
		public Color galaxy1Color;

		[ColorUsage(true, true)]
		public Color galaxy2Color;

		[ColorUsage(true, true)]
		public Color galaxy3Color;

		[ColorUsage(true, true)]
		public Color lightScatteringColor;

		public float lightScatteringPosition;

		public float lightScatteringHeight;

		public float constellationIntensity;

		public float rainbowPosition = 78.7f;

		public float rainbowWidth = 11f;

		public Texture rainbowTexture;

		public float rainbowIntensity;

		public bool useRainbow;

		public float fogStart1 = 2f;

		public float fogStart2 = 5f;

		public float fogStart3 = 10f;

		public float fogStart4 = 30f;

		public float fogHeight = 0.85f;

		public float fogDensityMultiplier;

		public float fogLightFlareIntensity = 1f;

		public float fogLightFlareFalloff = 21f;

		public float fogLightFlareSquish = 1f;

		public float fogSmoothness;

		public float fogVariationAmount;

		public Vector3 fogVariationDirection;

		public float fogVariationDistance;

		public float fogVariationScale;

		public float heightFogIntensity;

		public float heightFogVariationScale = 150f;

		public float heightFogVariationAmount = 150f;

		public float fogBase;

		public float heightFogTransition;

		public float heightFogDistance = 1000f;

		[ColorUsage(true, true)]
		public Color heightFogColor;

		[ColorUsage(true, true)]
		public Color cloudMoonColor;

		public float cloudSunHighlightFalloff = 14.1f;

		public float cloudMoonHighlightFalloff = 22.9f;

		public float cloudWindSpeed = 3f;

		public float clippingThreshold = 0.5f;

		public float cloudMainScale = 20f;

		public float cloudDetailScale = 2.3f;

		public float cloudDetailAmount = 30f;

		public float acScale = 1f;

		public float cirroMoveSpeed = 0.5f;

		public float cirrusMoveSpeed = 0.5f;

		public float chemtrailsMoveSpeed = 0.5f;

		[ColorUsage(true, true)]
		public Color cloudTextureColor = Color.white;

		public float cloudCohesion = 0.75f;

		public float spherize = 0.361f;

		public float shadowDistance = 0.0288f;

		public float cloudThickness = 2f;

		public float textureAmount = 1f;

		public Texture cloudTexture;

		public Texture chemtrailsTexture;

		public Texture cirrusCloudTexture;

		public Texture altocumulusCloudTexture;

		public Texture cirrostratusCloudTexture;

		public Texture starMap;

		public Texture starDomeTexture;

		public Texture galaxyDomeTexture;

		public Texture constellationDomeTexture;

		public Texture galaxyMap;

		public Texture galaxyStarMap;

		public Texture galaxyVariationMap;

		public Texture lightScatteringMap;

		public Vector3 texturePanDirection;

		public Texture partlyCloudyLuxuryClouds;

		public Texture mostlyCloudyLuxuryClouds;

		public Texture overcastLuxuryClouds;

		public Texture lowBorderLuxuryClouds;

		public Texture highBorderLuxuryClouds;

		public Texture lowNimbusLuxuryClouds;

		public Texture midNimbusLuxuryClouds;

		public Texture highNimbusLuxuryClouds;

		public Texture luxuryVariation;

		public float skyFogAmount = 1f;

		public float cloudsFogAmount = 1f;

		public float cloudsFogLightAmount = 1f;

		public bool separateSunLightAndTransform;

		public float sunAngle = 0.5f;

		public LightShadows sunlightShadows = LightShadows.Soft;

		public LightShadows moonlightShadows = LightShadows.Soft;

		public AtmosphereProfile.SRPFlare sunFlare;

		public AtmosphereProfile.SRPFlare moonFlare;

		public float filterSaturation;

		public float filterValue;

		public Color filterColor;

		public Color sunFilter;

		public Color cloudFilter;

		private float adjustedScale;

		[Tooltip("Should the weather sphere always follow the camera and automatically rescale to the scene size?")]
		public LockToCameraStyle lockToCamera;

		public static bool FreezeUpdateInEditMode = false;

		public static bool DisplayGizmos = true;

		public static bool SceneFogRendering = true;

		public static bool FollowEditorCamera = true;

		public bool disableSunAtNight = true;

		public bool handleSceneLighting = true;

		public bool dontDestroyOnLoad;

		[SerializeField]
		[Tooltip("Set the color of these particle systems to the star color of the weather system.")]
		private List<ParticleSystem> m_Stars = new List<ParticleSystem>();

		[Tooltip("Set the color of these particle systems to the cloud color of the weather system.")]
		[SerializeField]
		private List<ParticleSystem> m_CloudParticles = new List<ParticleSystem>();

		public Light sunLight;

		public Transform sunTransform;

		public bool centerAroundCustomObject;

		public Transform customPivot;

		public MeshRenderer cloudMesh;

		public MeshRenderer skyMesh;

		public MeshRenderer fogMesh;

		public Camera cozyCamera;

		public LensFlareComponentSRP sunLensFlare;

		public List<Type> activeModules;

		public CozyInteractionsModule interactionsModule;

		public CozyClimateModule climateModule;

		public CozyWeatherModule weatherModule;

		public CozyTimeModule timeModule;

		public CozyAtmosphereModule atmosphereModule;

		public CozyWindModule windModule;

		public Events events;

		[Tooltip("The tag that contains all triggers that stop weather FX from playing.")]
		public string cozyTriggerTag = "FX Block Zone";

		[HideInInspector]
		public List<Collider> cozyTriggers;

		public Dictionary<int, List<Collider>> triggersPerScene = new Dictionary<int, List<Collider>>();

		public List<CozySystem> systems;

		public Transform audioFXParent;

		public Transform particleFXParent;

		public Transform thunderFXParent;

		public Transform visualFXParent;

		public SkyStyle skyStyle;

		public CloudStyle cloudStyle;

		public FogStyle fogStyle = FogStyle.stylized;

		public CozyModule overrideWeather;

		public GameObject moduleHolder;

		public List<CozyModule> modules = new List<CozyModule>();

		private static CozyWeather cachedInstance;

		public float cloudCoverage => cumulus;

		public static bool Tooltips
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool Graphs
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public IEnumerable<CozyModule> ActiveAndEnabledModules => modules.Where((CozyModule module) => module.isActiveAndEnabled);

		public float dayPercentage
		{
			get
			{
				float result = sunAngle;
				if ((bool)timeModule)
				{
					result = timeModule.currentTime;
				}
				return result;
			}
		}

		public float yearPercentage
		{
			get
			{
				float result = 0.5f;
				if ((bool)timeModule)
				{
					result = timeModule.yearPercentage;
				}
				return result;
			}
		}

		public float modifiedDayPercentage
		{
			get
			{
				float result = sunAngle;
				if ((bool)timeModule)
				{
					result = timeModule.modifiedDayPercentage;
				}
				return result;
			}
		}

		public Vector3 North => Vector3.Cross(sunTransform.parent.forward, Vector3.up);

		public Vector3 West => sunTransform.parent.forward;

		public static CozyWeather instance
		{
			get
			{
				if ((bool)cachedInstance)
				{
					return cachedInstance;
				}
				cachedInstance = UnityEngine.Object.FindObjectOfType<CozyWeather>();
				return cachedInstance;
			}
		}

		public static event RefreshModules refreshModules;

		public static event FrameResetDelegate OnFrameReset;

		public static event UpdateWeatherWeightsDelegate UpdateWeatherWeights;

		public static event UpdateFXWeightsDelegate UpdateFXWeights;

		public static event PropogateVariablesDelegate PropogateVariables;

		public static event CozyUpdateLoopDelegate CozyUpdateLoop;

		public void RaiseOnFrameReset()
		{
			CozyWeather.OnFrameReset?.Invoke();
		}

		public void RaiseUpdateWeatherWeights()
		{
			CozyWeather.UpdateWeatherWeights?.Invoke();
		}

		public void RaiseUpdateFXWeights()
		{
			CozyWeather.UpdateFXWeights?.Invoke();
		}

		public void RaisePropogateVariables()
		{
			CozyWeather.PropogateVariables?.Invoke();
		}

		public void RaiseCozyUpdateLoop()
		{
			CozyWeather.CozyUpdateLoop?.Invoke();
		}

		public void SetupReferences()
		{
			if (!separateSunLightAndTransform)
			{
				sunLight = GetChild<Light>("Sun Light");
				if (sunLight == null)
				{
					sunLight = GetChild<Light>("Sun");
				}
				sunTransform = sunLight.transform;
			}
			skyMesh = GetChild("Skydome").GetComponent<MeshRenderer>();
			cloudMesh = GetChild("Foreground Clouds").GetComponent<MeshRenderer>();
			fogMesh = GetChild("Fog").GetComponent<MeshRenderer>();
			audioFXParent = GetChild("Audio FX");
			particleFXParent = GetChild("Particle FX");
			visualFXParent = GetChild("Visual FX");
			thunderFXParent = GetChild("Thunder FX");
			if (sunFlare.flare != null)
			{
				if ((bool)sunTransform.GetComponent<LensFlareComponentSRP>())
				{
					sunLensFlare = sunTransform.GetComponent<LensFlareComponentSRP>();
				}
				else
				{
					sunLensFlare = sunTransform.gameObject.AddComponent<LensFlareComponentSRP>();
				}
			}
			if (cozyTriggers.Count == 0)
			{
				ResetFXTriggers();
			}
			if (handleSceneLighting)
			{
				RenderSettings.ambientMode = AmbientMode.Trilight;
			}
		}

		private new void OnEnable()
		{
			base.OnEnable();
			SceneManager.sceneLoaded += UpdateOnSceneLoaded;
			SceneManager.sceneUnloaded += UpdateOnSceneUnLoaded;
		}

		private void OnDisable()
		{
			SceneManager.sceneLoaded -= UpdateOnSceneLoaded;
			SceneManager.sceneUnloaded -= UpdateOnSceneUnLoaded;
		}

		private void Awake()
		{
			SetupReferences();
			ResetModules();
			ResetVariables();
			ResetQuality();
			UpdateShaderVariables();
			CozyShaderIDs.GrabShaderIDs();
			if (Application.isPlaying)
			{
				if (dontDestroyOnLoad)
				{
					UnityEngine.Object.DontDestroyOnLoad(this);
				}
				ResetFXTriggers();
			}
		}

		public void SetupSystems()
		{
			systems = new List<CozySystem> { this };
			systems.AddRange(from x in UnityEngine.Object.FindObjectsByType<CozySystem>(FindObjectsSortMode.None)
				where x != this
				select x);
		}

		public void ResetFXTriggers()
		{
			cozyTriggers.Clear();
			Collider[] array = UnityEngine.Object.FindObjectsByType<Collider>(FindObjectsSortMode.None);
			foreach (Collider collider in array)
			{
				if (collider.gameObject.tag == cozyTriggerTag)
				{
					cozyTriggers.Add(collider);
				}
			}
		}

		public void UpdateTriggersInScene(Scene scene)
		{
			GameObject[] rootGameObjects = scene.GetRootGameObjects();
			if (GetBlockZonesFromObjects(rootGameObjects, out var blockZones))
			{
				triggersPerScene.Add(scene.handle, blockZones);
				RefreshTriggers();
			}
		}

		public void RemoveTriggersInScene(Scene scene)
		{
			triggersPerScene.Remove(scene.handle);
			RefreshTriggers();
		}

		public bool GetBlockZonesFromObjects(IEnumerable<GameObject> gameObjects, out List<Collider> blockZones)
		{
			blockZones = gameObjects.SelectMany((GameObject item) => FindChildrenComponentsByTag<Collider>(item.transform, cozyTriggerTag)).ToList();
			return blockZones.Count > 0;
		}

		public void RefreshTriggers()
		{
			IEnumerable<Collider> collection = triggersPerScene.Values.SelectMany((List<Collider> trigger) => trigger);
			cozyTriggers.Clear();
			cozyTriggers.AddRange(collection);
			CozyParticles[] componentsInChildren = particleFXParent.GetComponentsInChildren<CozyParticles>();
			for (int num = 0; num < componentsInChildren.Length; num++)
			{
				componentsInChildren[num].SetupTriggers();
			}
		}

		public void ResetQuality()
		{
			SetupReferences();
			switch (cloudStyle)
			{
			case CloudStyle.cozyDesktop:
				cloudMesh.sharedMaterial.shader = ((Material)Resources.Load("Materials/Desktop Clouds Reference")).shader;
				break;
			case CloudStyle.cozyMobile:
				cloudMesh.sharedMaterial.shader = ((Material)Resources.Load("Materials/Mobile Clouds Reference")).shader;
				break;
			case CloudStyle.ghibliDesktop:
				cloudMesh.sharedMaterial.shader = ((Material)Resources.Load("Materials/Desktop Ghibli Clouds Reference")).shader;
				break;
			case CloudStyle.ghibliMobile:
				cloudMesh.sharedMaterial.shader = ((Material)Resources.Load("Materials/Mobile Ghibli Clouds Reference")).shader;
				break;
			case CloudStyle.paintedSkies:
				cloudMesh.sharedMaterial.shader = ((Material)Resources.Load("Materials/Painted Clouds Reference")).shader;
				break;
			case CloudStyle.luxury:
				cloudMesh.sharedMaterial.shader = ((Material)Resources.Load("Materials/Luxury Clouds Reference")).shader;
				break;
			case CloudStyle.soft:
				cloudMesh.sharedMaterial.shader = ((Material)Resources.Load("Materials/Soft Clouds Reference")).shader;
				break;
			case CloudStyle.singleTexture:
				cloudMesh.sharedMaterial.shader = ((Material)Resources.Load("Materials/Single Texture Reference")).shader;
				break;
			case CloudStyle.off:
				cloudMesh.sharedMaterial.shader = ((Material)Resources.Load("Materials/Disabled")).shader;
				break;
			}
			switch (skyStyle)
			{
			case SkyStyle.desktop:
				skyMesh.sharedMaterial.shader = ((Material)Resources.Load("Materials/Desktop Sky Reference")).shader;
				break;
			case SkyStyle.mobile:
				skyMesh.sharedMaterial.shader = ((Material)Resources.Load("Materials/Mobile Sky Reference")).shader;
				break;
			case SkyStyle.off:
				skyMesh.sharedMaterial.shader = ((Material)Resources.Load("Materials/Disabled")).shader;
				break;
			}
			switch (fogStyle)
			{
			case FogStyle.stylized:
				fogMesh.sharedMaterial.shader = ((Material)Resources.Load("Materials/Default Fog Reference")).shader;
				RenderSettings.fog = false;
				break;
			case FogStyle.heightFog:
				fogMesh.sharedMaterial.shader = ((Material)Resources.Load("Materials/Height Fog Reference")).shader;
				RenderSettings.fog = false;
				break;
			case FogStyle.steppedFog:
				fogMesh.sharedMaterial.shader = ((Material)Resources.Load("Materials/Stepped Fog Reference")).shader;
				RenderSettings.fog = false;
				break;
			case FogStyle.unity:
				fogMesh.sharedMaterial.shader = ((Material)Resources.Load("Materials/Disabled")).shader;
				RenderSettings.fog = true;
				break;
			case FogStyle.off:
				fogMesh.sharedMaterial.shader = ((Material)Resources.Load("Materials/Disabled")).shader;
				break;
			}
		}

		private void Update()
		{
			RaiseOnFrameReset();
			RaiseUpdateWeatherWeights();
			RaiseUpdateFXWeights();
			RaisePropogateVariables();
			RaiseCozyUpdateLoop();
		}

		private void LateUpdate()
		{
			if (Application.isPlaying)
			{
				UpdateSkydomePositionAndScale();
			}
			else if (Application.isFocused)
			{
				UpdateSkydomePositionAndScale();
			}
		}

		public void UpdateSkydomePositionAndScale()
		{
			if (lockToCamera != LockToCameraStyle.DontLockToCamera || centerAroundCustomObject)
			{
				if (lockToCamera == LockToCameraStyle.useMainCamera && cozyCamera == null)
				{
					cozyCamera = Camera.main;
				}
				if (cozyCamera != null)
				{
					adjustedScale = cozyCamera.farClipPlane / 1000f;
					base.transform.GetChild(0).localScale = Vector3.one * adjustedScale;
				}
				if (centerAroundCustomObject && (bool)customPivot)
				{
					base.transform.position = customPivot.position;
				}
				else if ((bool)cozyCamera)
				{
					base.transform.position = cozyCamera.transform.position;
				}
			}
		}

		public void UpdateShaderVariables()
		{
			if (CozyShaderIDs.CZY_FogColor1ID == 0)
			{
				CozyShaderIDs.GrabShaderIDs();
			}
			if (FreezeUpdateInEditMode && !Application.isPlaying)
			{
				return;
			}
			FogStyle fogStyle = this.fogStyle;
			if (fogStyle == FogStyle.stylized || fogStyle == FogStyle.heightFog || fogStyle == FogStyle.steppedFog)
			{
				Shader.SetGlobalColor(CozyShaderIDs.CZY_FogColor1ID, fogColor1);
				Shader.SetGlobalColor(CozyShaderIDs.CZY_FogColor2ID, fogColor2);
				Shader.SetGlobalColor(CozyShaderIDs.CZY_FogColor3ID, fogColor3);
				Shader.SetGlobalColor(CozyShaderIDs.CZY_FogColor4ID, fogColor4);
				Shader.SetGlobalColor(CozyShaderIDs.CZY_FogColor5ID, fogColor5);
				Shader.SetGlobalColor(CozyShaderIDs.CZY_FogLitColorID, fogShadowColor);
				Shader.SetGlobalColor(CozyShaderIDs.CZY_FogShadowColorID, fogLitColor);
				Shader.SetGlobalFloat(CozyShaderIDs.CZY_FogColorStart1ID, fogStart1);
				Shader.SetGlobalFloat(CozyShaderIDs.CZY_FogColorStart2ID, fogStart2);
				Shader.SetGlobalFloat(CozyShaderIDs.CZY_FogColorStart3ID, fogStart3);
				Shader.SetGlobalFloat(CozyShaderIDs.CZY_FogColorStart4ID, fogStart4);
				Shader.SetGlobalFloat(CozyShaderIDs.CZY_FogIntensityID, fogDensity);
				Shader.SetGlobalFloat(CozyShaderIDs.CZY_FogOffsetID, fogHeight);
				Shader.SetGlobalFloat(CozyShaderIDs.CZY_LightFlareSquishID, fogLightFlareSquish);
				Shader.SetGlobalFloat(CozyShaderIDs.CZY_FogSmoothnessID, fogSmoothness);
				Shader.SetGlobalFloat(CozyShaderIDs.CZY_FogDepthMultiplierID, fogDensityMultiplier * fogDensity);
				Shader.SetGlobalColor(CozyShaderIDs.CZY_LightColorID, fogFlareColor);
				Shader.SetGlobalColor(CozyShaderIDs.CZY_FogMoonFlareColorID, fogMoonFlareColor);
				Shader.SetGlobalFloat(CozyShaderIDs.CZY_VariationAmountID, fogVariationAmount);
				Shader.SetGlobalFloat(CozyShaderIDs.CZY_VariationScaleID, fogVariationScale);
				Shader.SetGlobalVector(CozyShaderIDs.CZY_VariationWindDirectionID, fogVariationDirection);
				Shader.SetGlobalFloat(CozyShaderIDs.CZY_VariationDistanceID, fogVariationDistance);
				Shader.SetGlobalFloat(CozyShaderIDs.CZY_LightFalloffID, fogLightFlareFalloff);
				Shader.SetGlobalFloat(CozyShaderIDs.CZY_LightIntensityID, fogLightFlareIntensity);
				Shader.SetGlobalFloat(CozyShaderIDs.CZY_HeightFogBaseID, fogBase);
				Shader.SetGlobalFloat(CozyShaderIDs.CZY_HeightFogBaseVariationScaleID, heightFogVariationScale);
				Shader.SetGlobalFloat(CozyShaderIDs.CZY_HeightFogBaseVariationAmountID, heightFogVariationAmount);
				Shader.SetGlobalFloat(CozyShaderIDs.CZY_HeightFogTransitionID, heightFogTransition);
				Shader.SetGlobalFloat(CozyShaderIDs.CZY_HeightFogDistanceID, heightFogDistance);
				Shader.SetGlobalFloat(CozyShaderIDs.CZY_HeightFogIntensityID, heightFogIntensity);
				Shader.SetGlobalColor(CozyShaderIDs.CZY_HeightFogColorID, heightFogColor);
			}
			Shader.SetGlobalColor(CozyShaderIDs.CZY_FilterColorID, filterColor);
			Shader.SetGlobalColor(CozyShaderIDs.CZY_SunFilterColorID, sunFilter);
			Shader.SetGlobalColor(CozyShaderIDs.CZY_CloudFilterColorID, cloudFilter);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_FilterSaturationID, filterSaturation);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_FilterValueID, filterValue);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_CumulusCoverageMultiplierID, cumulus);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_NimbusMultiplierID, nimbus);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_NimbusHeightID, nimbusHeightEffect);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_NimbusVariationID, nimbusVariation);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_BorderHeightID, borderHeight);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_BorderEffectID, borderEffect);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_BorderVariationID, borderVariation);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_AltocumulusMultiplierID, altocumulus);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_CirrostratusMultiplierID, cirrostratus);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_ChemtrailsMultiplierID, chemtrails);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_CirrusMultiplierID, cirrus);
			Shader.SetGlobalTexture(CozyShaderIDs.CZY_CloudTextureID, cloudTexture);
			Shader.SetGlobalTexture(CozyShaderIDs.CZY_ChemtrailsTextureID, chemtrailsTexture);
			Shader.SetGlobalTexture(CozyShaderIDs.CZY_CirrusTextureID, cirrusCloudTexture);
			Shader.SetGlobalTexture(CozyShaderIDs.CZY_CirrostratusTextureID, cirrostratusCloudTexture);
			Shader.SetGlobalTexture(CozyShaderIDs.CZY_AltocumulusTextureID, altocumulusCloudTexture);
			Shader.SetGlobalTexture(CozyShaderIDs.CZY_StarMapID, starMap);
			Shader.SetGlobalTexture(CozyShaderIDs.CZY_GalaxyStarMapID, galaxyStarMap);
			Shader.SetGlobalTexture(CozyShaderIDs.CZY_GalaxyVariationMapID, galaxyVariationMap);
			Shader.SetGlobalTexture(CozyShaderIDs.CZY_LightColumnsTextureID, lightScatteringMap);
			Shader.SetGlobalTexture(CozyShaderIDs.CZY_GalaxyMapID, galaxyMap);
			Shader.SetGlobalVector(CozyShaderIDs.CZY_TexturePanDirectionID, texturePanDirection);
			Shader.SetGlobalColor(CozyShaderIDs.CZY_ZenithColorID, skyZenithColor);
			Shader.SetGlobalColor(CozyShaderIDs.CZY_HorizonColorID, skyHorizonColor);
			Shader.SetGlobalColor(CozyShaderIDs.CZY_StarColorID, starColor);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_GalaxyMultiplierID, galaxyIntensity);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_RainbowIntensityID, rainbowIntensity);
			Shader.SetGlobalTexture(CozyShaderIDs.CZY_PartlyCloudyLuxuryCloudsTextureID, partlyCloudyLuxuryClouds);
			Shader.SetGlobalTexture(CozyShaderIDs.CZY_MostlyCloudyLuxuryCloudsTextureID, mostlyCloudyLuxuryClouds);
			Shader.SetGlobalTexture(CozyShaderIDs.CZY_OvercastLuxuryCloudsTextureID, overcastLuxuryClouds);
			Shader.SetGlobalTexture(CozyShaderIDs.CZY_LowBorderLuxuryCloudsTextureID, lowBorderLuxuryClouds);
			Shader.SetGlobalTexture(CozyShaderIDs.CZY_HighBorderLuxuryCloudsTextureID, highBorderLuxuryClouds);
			Shader.SetGlobalTexture(CozyShaderIDs.CZY_LowNimbusLuxuryCloudsTextureID, lowNimbusLuxuryClouds);
			Shader.SetGlobalTexture(CozyShaderIDs.CZY_MidNimbusLuxuryCloudsTextureID, midNimbusLuxuryClouds);
			Shader.SetGlobalTexture(CozyShaderIDs.CZY_HighNimbusLuxuryCloudsTextureID, highNimbusLuxuryClouds);
			Shader.SetGlobalTexture(CozyShaderIDs.CZY_LuxuryVariationTextureID, luxuryVariation);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_PowerID, gradientExponent);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_SunSizeID, sunSize);
			Shader.SetGlobalColor(CozyShaderIDs.CZY_SunColorID, sunColor);
			Shader.SetGlobalColor(CozyShaderIDs.CZY_MoonColorID, moonColor);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_SunHaloFalloffID, sunFalloff);
			Shader.SetGlobalColor(CozyShaderIDs.CZY_SunHaloColorID, sunFlareColor);
			Shader.SetGlobalColor(CozyShaderIDs.CZY_MoonFlareColorID, moonFlareColor);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_MoonFlareFalloffID, moonFalloff);
			Shader.SetGlobalColor(CozyShaderIDs.CZY_GalaxyColor1ID, galaxy1Color);
			Shader.SetGlobalColor(CozyShaderIDs.CZY_GalaxyColor2ID, galaxy2Color);
			Shader.SetGlobalColor(CozyShaderIDs.CZY_GalaxyColor3ID, galaxy3Color);
			Shader.SetGlobalColor(CozyShaderIDs.CZY_LightColumnColorID, lightScatteringColor);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_RainbowSizeID, rainbowPosition);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_RainbowWidthID, rainbowWidth);
			if ((bool)windModule)
			{
				Shader.SetGlobalVector(CozyShaderIDs.CZY_StormDirectionID, windModule.WindDirection);
			}
			else
			{
				Shader.SetGlobalVector(CozyShaderIDs.CZY_StormDirectionID, -Vector3.right);
			}
			Shader.SetGlobalColor(CozyShaderIDs.CZY_CloudColorID, cloudColor);
			Shader.SetGlobalColor(CozyShaderIDs.CZY_CloudHighlightColorID, cloudHighlightColor);
			Shader.SetGlobalColor(CozyShaderIDs.CZY_AltoCloudColorID, highAltitudeCloudColor);
			Shader.SetGlobalColor(CozyShaderIDs.CZY_CloudTextureColorID, cloudTextureColor);
			Shader.SetGlobalColor(CozyShaderIDs.CZY_CloudMoonColorID, cloudMoonColor);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_SunFlareFalloffID, cloudSunHighlightFalloff);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_CloudMoonFalloffID, cloudMoonHighlightFalloff);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_WindSpeedID, cloudWindSpeed);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_CloudCohesionID, cloudCohesion);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_SpherizeID, spherize);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_ShadowingDistanceID, shadowDistance);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_ClippingThresholdID, clippingThreshold);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_CloudThicknessID, cloudThickness);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_MainCloudScaleID, cloudMainScale);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_DetailScaleID, cloudDetailScale);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_DetailAmountID, cloudDetailAmount);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_TextureAmountID, textureAmount);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_AltocumulusScaleID, acScale);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_CirrostratusMoveSpeedID, cirroMoveSpeed);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_CirrusMoveSpeedID, cirrusMoveSpeed);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_ChemtrailsMoveSpeedID, chemtrailsMoveSpeed);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_ConstellationIntensityID, constellationIntensity);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_LightColumnsPositionID, lightScatteringPosition);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_LightColumnsHeightID, lightScatteringHeight);
			Shader.SetGlobalTexture(CozyShaderIDs.CZY_StarDomeTextureID, starDomeTexture);
			Shader.SetGlobalTexture(CozyShaderIDs.CZY_ConstellationDomeTextureID, constellationDomeTexture);
			Shader.SetGlobalTexture(CozyShaderIDs.CZY_GalaxyDomeTextureID, galaxyDomeTexture);
			Shader.SetGlobalTexture(CozyShaderIDs.CZY_LightColumnsTextureID, lightScatteringMap);
			Shader.SetGlobalTexture(CozyShaderIDs.CZY_RainbowTextureID, rainbowTexture);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_SkyFogAmountID, skyFogAmount);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_CloudsFogAmountID, cloudsFogAmount);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_CloudsFogLightAmountID, cloudsFogLightAmount);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_DayPercentageID, modifiedDayPercentage);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_YearPercentageID, yearPercentage);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_YearPercentageID, yearPercentage);
			Shader.SetGlobalVector(CozyShaderIDs.CZY_NorthID, North);
			Shader.SetGlobalVector(CozyShaderIDs.CZY_WestID, West);
			Shader.SetGlobalVector(CozyShaderIDs.CZY_SunDirectionParamsID, new Vector4(sunDirection, sunPitch));
			if (this.fogStyle == FogStyle.unity)
			{
				RenderSettings.fogColor = FilterColor(fogColor5);
				RenderSettings.fogDensity = 0.003f * fogDensity * fogDensityMultiplier;
			}
			sunTransform.parent.eulerAngles = new Vector3(0f, sunDirection, sunPitch);
			sunTransform.localEulerAngles = new Vector3(modifiedDayPercentage * 360f - 90f, 0f, 0f);
			Shader.SetGlobalVector(CozyShaderIDs.CZY_SunDirectionID, -sunTransform.forward);
			if ((bool)sunLensFlare)
			{
				sunLensFlare.intensity = (sunFlare.flare ? ((sunlightColor * sunFilter).grayscale * sunFlare.intensity) : 0f);
				sunLensFlare.lensFlareData = sunFlare.flare;
				sunLensFlare.allowOffScreen = sunFlare.allowOffscreen;
				sunLensFlare.radialScreenAttenuationCurve = sunFlare.screenAttenuation;
				sunLensFlare.distanceAttenuationCurve = sunFlare.screenAttenuation;
				sunLensFlare.scale = sunFlare.scale;
				sunLensFlare.occlusionRadius = sunFlare.occlusionRadius;
				sunLensFlare.useOcclusion = sunFlare.useOcclusion;
			}
			if (handleSceneLighting)
			{
				sunLight.color = sunlightColor * sunFilter;
				if (disableSunAtNight)
				{
					sunLight.enabled = sunLight.color.r + sunLight.color.g + sunLight.color.b > 0f;
				}
			}
			else
			{
				sunLight.enabled = false;
			}
			sunLight.shadows = (sunLight.enabled ? sunlightShadows : LightShadows.None);
			if ((bool)climateModule)
			{
				if (useRainbow)
				{
					rainbowIntensity = climateModule.groundwaterAmount * (1f - galaxyIntensity);
				}
				else
				{
					rainbowIntensity = 0f;
				}
			}
			if (handleSceneLighting)
			{
				RenderSettings.sun = sunLight;
				RenderSettings.defaultReflectionMode = DefaultReflectionMode.Custom;
				RenderSettings.ambientMode = AmbientMode.Trilight;
				RenderSettings.ambientSkyColor = ambientLightZenithColor * ambientLightMultiplier;
				RenderSettings.ambientEquatorColor = ambientLightHorizonColor * (1f - cumulus / 2f) * ambientLightMultiplier;
				RenderSettings.ambientGroundColor = ambientLightHorizonColor * Color.gray * (1f - cumulus / 2f) * ambientLightMultiplier;
			}
			SetStarColors(starColor);
			SetCloudColors(cloudColor);
		}

		public T GetFXRuntimeRef<T>(string name) where T : Component
		{
			if (this == null)
			{
				return null;
			}
			return GetComponentsInChildren<T>().ToList().Find((T x) => x.transform.name == name);
		}

		public Color FilterColor(Color color)
		{
			float a = color.a;
			Color.RGBToHSV(color, out var H, out var S, out var V);
			S = Mathf.Clamp(S + filterSaturation, 0f, 10f);
			V = Mathf.Clamp(V + filterValue, 0f, 10f);
			Color result = Color.HSVToRGB(H, S, V);
			result *= filterColor;
			result.a = a;
			return result;
		}

		public void ResetVariables()
		{
			rainbowIntensity = ((!climateModule) ? 0f : (useRainbow ? (climateModule.groundwaterAmount * (1f - starColor.a)) : 0f));
			ambientLightHorizonColor = FilterColor(ambientLightHorizonColor);
			ambientLightZenithColor = FilterColor(ambientLightZenithColor);
		}

		public void ResetModules()
		{
			moduleHolder = GetChild("Modules").gameObject;
			modules = moduleHolder.GetComponents<CozyModule>().ToList();
			if (!interactionsModule)
			{
				interactionsModule = GetModule<CozyInteractionsModule>();
			}
			if (!timeModule)
			{
				timeModule = GetModule<CozyTimeModule>();
			}
			if (!weatherModule)
			{
				weatherModule = GetModule<CozyWeatherModule>();
			}
			modules.RemoveAll((CozyModule x) => x == null);
			CozyWeather.refreshModules?.Invoke();
		}

		public void InitializeModule(Type module)
		{
			if ((bool)GetModule(module))
			{
				Debug.LogWarning("Cannot add " + module.Name + " because the current COZY instance already contains this module.");
				return;
			}
			CozyModule cozyModule = (CozyModule)moduleHolder.AddComponent(module);
			if (!cozyModule.CheckIfModuleCanBeAdded(out var warning))
			{
				Debug.LogWarning("Cannot add " + module.Name + " due to a conflict with " + warning + ".");
				UnityEngine.Object.DestroyImmediate(cozyModule);
			}
			else
			{
				modules.Add(cozyModule);
				ResetModules();
			}
		}

		public void ResetModule(CozyModule module)
		{
			StartCoroutine(ResetModuleRoutine(module));
		}

		public IEnumerator ResetModuleRoutine(CozyModule module)
		{
			Type savedType = module.GetType();
			if (!module.CheckIfModuleCanBeRemoved(out var warning))
			{
				Debug.LogWarning("Module cannot be reset as it has dependencies on the weather sphere. Please remove the " + warning + " before resetting this module!");
				yield break;
			}
			modules.Remove(module);
			UnityEngine.Object.DestroyImmediate(module);
			ResetModules();
			yield return null;
			CozyModule item = (CozyModule)moduleHolder.AddComponent(savedType);
			modules.Add(item);
			ResetModules();
		}

		public void DeintitializeModule(CozyModule module)
		{
			if (!module.CheckIfModuleCanBeRemoved(out var warning))
			{
				Debug.LogWarning("Module cannot be removed as it has dependencies on the weather sphere. Please remove the " + warning + " before removing this module!");
				return;
			}
			modules.Remove(module);
			UnityEngine.Object.DestroyImmediate(module);
			ResetModules();
		}

		public T GetModule<T>() where T : CozyModule
		{
			Type typeFromHandle = typeof(T);
			if (!moduleHolder.GetComponent(typeFromHandle))
			{
				return null;
			}
			return moduleHolder.GetComponent(typeFromHandle) as T;
		}

		public T GetModule<T>(out T module) where T : CozyModule
		{
			Type typeFromHandle = typeof(T);
			module = (moduleHolder.GetComponent(typeFromHandle) ? (moduleHolder.GetComponent(typeFromHandle) as T) : null);
			return module;
		}

		public CozyModule GetModule(Type type)
		{
			if (!moduleHolder.GetComponent(type))
			{
				return null;
			}
			return moduleHolder.GetComponent(type) as CozyModule;
		}

		public void UpdateOnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
			UpdateTriggersInScene(scene);
			foreach (CozyModule activeAndEnabledModule in ActiveAndEnabledModules)
			{
				activeAndEnabledModule.OnSceneLoaded();
			}
		}

		public void UpdateOnSceneUnLoaded(Scene scene)
		{
			RemoveTriggersInScene(scene);
			foreach (CozyModule activeAndEnabledModule in ActiveAndEnabledModules)
			{
				activeAndEnabledModule.OnSceneUnloaded();
			}
		}

		public Transform GetChild(string name)
		{
			Transform[] componentsInChildren = base.transform.GetComponentsInChildren<Transform>();
			foreach (Transform transform in componentsInChildren)
			{
				if (transform.name == name)
				{
					return transform;
				}
			}
			return null;
		}

		public T GetChild<T>(string name) where T : Component
		{
			T[] componentsInChildren = base.transform.GetComponentsInChildren<T>();
			foreach (T val in componentsInChildren)
			{
				if (val.name == name)
				{
					return val;
				}
			}
			return null;
		}

		public List<T> FindChildrenComponentsByTag<T>(Transform parentTransform, string tag) where T : Component
		{
			List<T> list = new List<T>();
			foreach (Transform item in parentTransform)
			{
				if ((bool)item && item.CompareTag(tag))
				{
					T component = item.GetComponent<T>();
					if ((bool)component)
					{
						list.Add(component);
					}
				}
				list.AddRange(FindChildrenComponentsByTag<T>(item, tag));
			}
			return list;
		}

		private void SetStarColors(Color color)
		{
			if (m_Stars.Count == 0)
			{
				return;
			}
			foreach (ParticleSystem star in m_Stars)
			{
				if (!(star == null))
				{
					ParticleSystem.MainModule main = star.main;
					main.startColor = color;
				}
			}
		}

		private void SetCloudColors(Color color)
		{
			if (m_CloudParticles.Count == 0)
			{
				return;
			}
			foreach (ParticleSystem cloudParticle in m_CloudParticles)
			{
				if (!(cloudParticle == null))
				{
					ParticleSystem.MainModule main = cloudParticle.main;
					main.startColor = color;
					ParticleSystem.TrailModule trails = cloudParticle.trails;
					trails.colorOverLifetime = color;
				}
			}
		}

		public void SetStyle(SkyStyle style)
		{
			skyStyle = style;
		}

		public void SetStyle(FogStyle style)
		{
			fogStyle = style;
		}

		public void SetStyle(CloudStyle style)
		{
			cloudStyle = style;
		}
	}
}
