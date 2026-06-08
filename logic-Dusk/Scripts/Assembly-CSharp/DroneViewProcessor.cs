using System;
using System.Collections.Generic;
using UnityEngine;

public class DroneViewProcessor
{
	private List<IProcessor> processorList;

	private CameraDistortionScroller scrollerShader;

	private Camera lightCamera;

	private Camera colorCamera;

	private Camera depthCamera;

	private Camera pixelCamera;

	private RenderTexture lightRT;

	private RenderTexture colorRT;

	private RenderTexture depthRT;

	private RenderTexture pixelRT;

	private string pixelTextureName = string.Empty;

	public Camera dvpCameraSetup { get; private set; }

	public int seed { get; private set; }

	public bool staleData { get; set; }

	public int staleDataLifetimeSeconds { get; set; }

	public int staleDataMaxLights { get; set; }

	public bool staleDataEnableDelayBetweenLights { get; set; }

	public int staleDataDelayBetweenLightDropsMS { get; set; }

	public float colorCameraBrightness { get; set; }

	public bool depthCameraDisableBanding { get; set; }

	public Camera cameraGroup { get; set; }

	public string dvpName { get; private set; }

	private DroneViewProcessor()
	{
	}

	public DroneViewProcessor(string dvpName)
	{
		this.dvpName = dvpName;
	}

	~DroneViewProcessor()
	{
	}

	public void Unload()
	{
		if (pixelTextureName != string.Empty)
		{
			ResourceManager.UnloadAsset(string.Format("Textures/Shaders/{0}", pixelTextureName));
		}
		lightRT = null;
		colorRT = null;
		depthRT = null;
		pixelRT = null;
		if (processorList != null)
		{
			processorList.Clear();
			processorList = null;
		}
		scrollerShader = null;
		lightCamera = null;
		colorCamera = null;
		depthCamera = null;
		pixelCamera = null;
	}

	public void Initialize(int seed)
	{
		this.seed = seed;
		UnityEngine.Random.seed = seed;
		staleData = DVPConfigurationManager.GetBool(dvpName, "staleData", "enabled", true);
		if (staleData)
		{
			staleData = GameSaveFile.Get("Q_STALE", staleData);
		}
		staleDataLifetimeSeconds = DVPConfigurationManager.GetRandomNumeric(dvpName, "staleData", "lifetimeSec", 1);
		staleDataMaxLights = DVPConfigurationManager.GetNumeric(dvpName, "staleData", "maxLights", 40);
		staleDataEnableDelayBetweenLights = DVPConfigurationManager.GetBool(dvpName, "staleData", "enableDelayBetweenLights", true);
		staleDataDelayBetweenLightDropsMS = DVPConfigurationManager.GetNumeric(dvpName, "staleData", "delayBetweenLightsMS", 60);
		colorCameraBrightness = 1f;
		depthCameraDisableBanding = false;
		processorList = new List<IProcessor>();
	}

	public void BringOnline()
	{
		UnityEngine.Random.seed = seed;
		foreach (IProcessor processor in processorList)
		{
			processor.BringOnline();
		}
		pixelTextureName = "PixelPaletteTiny";
		pixelTextureName = DVPConfigurationManager.GetString(dvpName, "pixelData", "pixelTexture", pixelTextureName);
		Texture2D sourceTexture = ResourceManager.LoadAsset<Texture2D>(string.Format("Textures/Shaders/{0}", pixelTextureName));
		Transform transform = cameraGroup.gameObject.transform.Find("PixelDataCamera");
		if (transform != null)
		{
			CameraTextureBomb component = transform.gameObject.GetComponent<CameraTextureBomb>();
			component.sourceTexture = sourceTexture;
			DroneManager.Instance.EnablePixelRender();
			pixelCamera = transform.GetComponent<Camera>();
		}
		transform = cameraGroup.gameObject.transform.Find("LightDataCamera");
		if (transform != null)
		{
			lightCamera = transform.GetComponent<Camera>();
		}
		transform = cameraGroup.gameObject.transform.Find("ColorDataCamera");
		if (transform != null)
		{
			colorCamera = transform.GetComponent<Camera>();
		}
		transform = cameraGroup.gameObject.transform.Find("DepthDataCamera");
		if (transform != null)
		{
			depthCamera = transform.GetComponent<Camera>();
		}
		RefreshRenderTexture();
	}

	public void SetDVPCamera(Camera camera)
	{
		processorList.Clear();
		dvpCameraSetup = camera;
		ImageEffectBase[] components = dvpCameraSetup.GetComponents<ImageEffectBase>();
		int num = components.Length;
		for (int i = 0; i < num; i++)
		{
			ImageEffectBase imageEffectBase = components[i];
			if (imageEffectBase.enabled)
			{
				Type type = imageEffectBase.GetType();
				if (type == typeof(CameraEdgeDetectionAndColorEffect))
				{
					processorList.Add(new ProcessorEdgeDetection((CameraEdgeDetectionAndColorEffect)imageEffectBase, dvpName));
				}
				else if (type == typeof(CameraDistanceColorization))
				{
					processorList.Add(new ProcessorDistanceColor((CameraDistanceColorization)imageEffectBase, dvpName));
				}
				else if (type == typeof(CameraReplacementTest))
				{
					processorList.Add(new ProcessorMultiShader((CameraReplacementTest)imageEffectBase, dvpName));
				}
				else if (type == typeof(CameraDistortionScroller))
				{
					scrollerShader = (CameraDistortionScroller)imageEffectBase;
				}
			}
		}
		RefreshPostSetting();
	}

	private void RefreshRenderTexture()
	{
		if (!(lightRT == null) || !(colorRT == null) || !(depthRT == null) || !(pixelRT == null))
		{
			SetRenderTextures(lightRT, colorRT, depthRT, pixelRT);
		}
	}

	private void RefreshRenderTexture(Camera camera)
	{
		ImageEffectBase[] components = camera.GetComponents<ImageEffectBase>();
		ImageEffectBase[] array = components;
		foreach (ImageEffectBase imageEffectBase in array)
		{
			if (imageEffectBase.enabled)
			{
				Type type = imageEffectBase.GetType();
				if (type == typeof(CameraEdgeDetectionAndColorEffect))
				{
					CameraEdgeDetectionAndColorEffect cameraEdgeDetectionAndColorEffect = (CameraEdgeDetectionAndColorEffect)imageEffectBase;
					cameraEdgeDetectionAndColorEffect.lightMaskRT = lightRT;
					cameraEdgeDetectionAndColorEffect.colorMaskRT = colorRT;
					cameraEdgeDetectionAndColorEffect.pixelRT = pixelRT;
				}
				else if (type == typeof(CameraColorMaskEffect))
				{
					CameraColorMaskEffect cameraColorMaskEffect = (CameraColorMaskEffect)imageEffectBase;
					cameraColorMaskEffect.lightMaskRT = lightRT;
				}
				else if (type == typeof(CameraReplacementTest))
				{
					CameraReplacementTest cameraReplacementTest = (CameraReplacementTest)imageEffectBase;
					cameraReplacementTest.lightRT = lightRT;
					cameraReplacementTest.pixelRT = pixelRT;
					cameraReplacementTest.depthRT = depthRT;
				}
			}
		}
	}

	public void SetRenderTextures(RenderTexture lightRT, RenderTexture colorRT, RenderTexture depthRT, RenderTexture pixelRT)
	{
		this.lightRT = lightRT;
		this.colorRT = colorRT;
		this.depthRT = depthRT;
		this.pixelRT = pixelRT;
		RefreshRenderTexture(cameraGroup);
		if (lightCamera != null)
		{
			RefreshRenderTexture(lightCamera);
			lightCamera.targetTexture = lightRT;
		}
		if (colorCamera != null)
		{
			RefreshRenderTexture(colorCamera);
			colorCamera.targetTexture = colorRT;
		}
		if (depthCamera != null)
		{
			RefreshRenderTexture(depthCamera);
			depthCamera.targetTexture = depthRT;
		}
		if (pixelCamera != null)
		{
			RefreshRenderTexture(pixelCamera);
			pixelCamera.targetTexture = pixelRT;
		}
	}

	public void Update()
	{
		if (dvpCameraSetup != null)
		{
			DroneManager.Instance.DroneCamera = dvpCameraSetup;
		}
		if (staleData != DroneManager.Instance.EnableStaleData)
		{
			DroneManager.Instance.EnableStaleData = staleData;
			if (!staleData)
			{
				DroneManager.Instance.ClearCurrentDroneDroppedLights();
			}
		}
		DroneManager.Instance.StaleDataLifetimeSeconds = staleDataLifetimeSeconds;
		DroneManager.Instance.StaleDataMaxLightsPerDrone = staleDataMaxLights;
		DroneManager.Instance.EnableDelayBetweenLightDrops = staleDataEnableDelayBetweenLights;
		DroneManager.Instance.DelayStaleDataLightMS = staleDataDelayBetweenLightDropsMS;
		int count = processorList.Count;
		for (int i = 0; i < count; i++)
		{
			processorList[i].Update();
		}
	}

	public void RefreshPostSetting()
	{
		staleData = DVPConfigurationManager.GetBool(dvpName, "staleData", "enabled", true);
		if (staleData)
		{
			staleData = GameSaveFile.Get("Q_STALE", staleData);
		}
		if (scrollerShader != null)
		{
			bool flag = GameSaveFile.Get("Q_DIST", true);
			if (scrollerShader.enabled != flag)
			{
				scrollerShader.enabled = flag;
			}
		}
	}
}
