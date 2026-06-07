using System;
using System.Collections;
using System.IO;
using UnityEngine;

namespace MadGoat_SSAA
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Camera))]
	public class MadGoatSSAA : MonoBehaviour
	{
		public Mode renderMode;

		public float multiplier = 1f;

		public float multiplierVertical = 1f;

		public bool fssaaAlpha;

		public SsaaProfile SSAA_X2 = new SsaaProfile(1.5f, true, Filter.BILINEAR, 0.8f, 0.5f);

		public SsaaProfile SSAA_X4 = new SsaaProfile(2f, true, Filter.BICUBIC, 0.725f, 0.95f);

		public SsaaProfile SSAA_HALF = new SsaaProfile(0.5f, true, Filter.NEAREST_NEIGHBOR, 0f, 0f);

		public SSAAMode ssaaMode;

		public bool ssaaUltra;

		[Range(0f, 1f)]
		public float fssaaIntensity = 1f;

		public RenderTextureFormat textureFormat = RenderTextureFormat.ARGBHalf;

		public bool useShader = true;

		public Filter filterType = Filter.BILINEAR;

		public float sharpness = 0.8f;

		public float sampleDistance = 1f;

		public bool useVsyncTarget;

		public int targetFramerate = 60;

		public float minMultiplier = 0.5f;

		public float maxMultiplier = 1.5f;

		public string screenshotPath = "Assets/SuperSampledSceenshots/";

		public string namePrefix = "SSAA";

		public bool useProductName;

		public ImageFormat imageFormat;

		[Range(0f, 100f)]
		public int JPGQuality = 90;

		public bool EXR32;

		private Shader _FXAA_FSS;

		private Material _FXAA_FSS_Mat;

		[SerializeField]
		protected Camera currentCamera;

		protected Camera renderCamera;

		protected GameObject renderCameraObject;

		protected MadGoatSSAA_InternalRenderer SSAA_Internal;

		private Rect tempRect;

		private Texture2D _sphereTemp;

		protected FramerateSampler FpsData = new FramerateSampler();

		public DebugData dbgData;

		public bool mouseCompatibilityMode;

		public RenderTexture targetTexture;

		public GameObject madGoatDebugger;

		public ScreenshotSettings screenshotSettings = new ScreenshotSettings();

		public PanoramaSettings panoramaSettings = new PanoramaSettings(1024, 1);

		protected Shader FXAA_FSS
		{
			get
			{
				if (_FXAA_FSS == null)
				{
					_FXAA_FSS = Shader.Find("Hidden/SSAA/FSS");
				}
				return _FXAA_FSS;
			}
		}

		protected Material FXAA_FSS_Mat
		{
			get
			{
				if (_FXAA_FSS_Mat == null)
				{
					_FXAA_FSS_Mat = new Material(FXAA_FSS);
				}
				return _FXAA_FSS_Mat;
			}
		}

		private Texture2D sphereTemp
		{
			get
			{
				if (_sphereTemp != null)
				{
					return _sphereTemp;
				}
				_sphereTemp = new Texture2D(2, 2);
				return _sphereTemp;
			}
		}

		private string getName
		{
			get
			{
				return (useProductName ? Application.productName : namePrefix) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmssff") + "_" + panoramaSettings.panoramaSize + "p";
			}
		}

		public virtual void Init()
		{
			if (renderCameraObject == null)
			{
				renderCameraObject = new GameObject("RenderCameraObject");
				renderCameraObject.transform.SetParent(base.transform);
				renderCameraObject.transform.position = Vector3.zero;
				renderCameraObject.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
				renderCameraObject.hideFlags = HideFlags.HideInHierarchy | HideFlags.HideInInspector;
				renderCamera = renderCameraObject.AddComponent<Camera>();
				SSAA_Internal = renderCameraObject.AddComponent<MadGoatSSAA_InternalRenderer>();
				SSAA_Internal.current = renderCamera;
				SSAA_Internal.main = currentCamera;
				SSAA_Internal.enabled = true;
				renderCamera.CopyFrom(currentCamera);
				renderCamera.cullingMask = 0;
				renderCamera.clearFlags = CameraClearFlags.Nothing;
			}
			else
			{
				SSAA_Internal.enabled = true;
			}
			currentCamera.targetTexture = new RenderTexture(1024, 1024, 24, textureFormat);
			currentCamera.targetTexture.Create();
		}

		private void OnEnable()
		{
			if (dbgData == null)
			{
				dbgData = new DebugData(this);
			}
			currentCamera = GetComponent<Camera>();
			Init();
			StartCoroutine(AdaptiveTask());
		}

		private void Update()
		{
			currentCamera.targetTexture.filterMode = ((filterType != Filter.NEAREST_NEIGHBOR || !useShader) ? FilterMode.Trilinear : FilterMode.Point);
			renderCamera.enabled = currentCamera.enabled;
			renderCamera.CopyFrom(currentCamera, null);
			renderCamera.cullingMask = (mouseCompatibilityMode ? (-1) : 0);
			renderCamera.clearFlags = CameraClearFlags.Color;
			renderCamera.targetTexture = targetTexture;
			SSAA_Internal.multiplier = multiplier;
			SSAA_Internal.sharpness = sharpness;
			SSAA_Internal.useShader = useShader;
			SSAA_Internal.sampleDistance = sampleDistance;
			SSAA_Internal.ChangeMaterial(filterType);
			FpsData.Update();
			SendDbgInfo();
		}

		private void OnDisable()
		{
			SSAA_Internal.enabled = false;
			currentCamera.targetTexture.Release();
			currentCamera.targetTexture = null;
		}

		private void OnPreRender()
		{
			currentCamera.aspect = (float)Screen.width * currentCamera.rect.width / ((float)Screen.height * currentCamera.rect.height);
			if (screenshotSettings.takeScreenshot)
			{
				SetupScreenshotRender(screenshotSettings.screenshotMultiplier, false);
				return;
			}
			if ((float)Screen.width * multiplier != (float)currentCamera.targetTexture.width || (float)Screen.height * ((renderMode == Mode.PerAxisScale) ? multiplierVertical : multiplier) != (float)currentCamera.targetTexture.height)
			{
				SetupRender();
			}
			tempRect = currentCamera.rect;
			currentCamera.rect = new Rect(0f, 0f, 1f, 1f);
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			if (renderMode == Mode.SSAA && ssaaUltra && (ssaaMode == SSAAMode.SSAA_X2 || ssaaMode == SSAAMode.SSAA_X4))
			{
				DoFSS(source, destination);
			}
			else if (renderMode == Mode.ResolutionScale && ssaaUltra && multiplier > 1f)
			{
				DoFSS(source, destination);
			}
			else if (renderMode == Mode.Custom && ssaaUltra && multiplier > 1f)
			{
				DoFSS(source, destination);
			}
			else
			{
				Graphics.Blit(source, destination);
			}
		}

		private void OnPostRender()
		{
			currentCamera.rect = tempRect;
		}

		public void Refresh()
		{
			base.enabled = false;
			base.enabled = true;
			currentCamera.rect = new Rect(0f, 0f, 1f, 1f);
		}

		protected void SendDbgInfo()
		{
			if (Application.isPlaying && (bool)madGoatDebugger)
			{
				string value = string.Concat("SSAA: Render Res:", GetResolution(), " [x", dbgData.multiplier, "] [FSSAA:", dbgData.fssaa.ToString(), "] [Mode: ", dbgData.renderMode, "]");
				madGoatDebugger.SendMessage("SsaaListener", value);
			}
		}

		public virtual void DoFSS(RenderTexture source, RenderTexture destination)
		{
			FXAA_FSS_Mat.SetVector("_QualitySettings", new Vector3(1f, 0.063f, 0.0312f));
			FXAA_FSS_Mat.SetVector("_ConsoleSettings", new Vector4(0.5f, 2f, 0.125f, 0.04f));
			FXAA_FSS_Mat.SetFloat("_Intensity", fssaaIntensity);
			Graphics.Blit(source, destination, FXAA_FSS_Mat, 0);
		}

		private void RenderPanorama()
		{
			base.enabled = false;
			int num = panoramaSettings.panoramaSize * panoramaSettings.panoramaMultiplier;
			Cubemap cubemap = new Cubemap(num, TextureFormat.ARGB32, false);
			RenderTexture temporary = RenderTexture.GetTemporary(panoramaSettings.panoramaSize, panoramaSettings.panoramaSize, 24, RenderTextureFormat.ARGB32);
			renderCamera.CopyFrom(currentCamera, null);
			SSAA_Internal.enabled = false;
			currentCamera.RenderToCubemap(cubemap);
			string text = screenshotPath + "\\" + getName + "\\";
			new FileInfo(text).Directory.Create();
			for (int i = 0; i < 6; i++)
			{
				sphereTemp.Resize(num, num);
				sphereTemp.SetPixels(Rotate90(Rotate90(cubemap.GetPixels((CubemapFace)i), num), num));
				sphereTemp.Apply();
				if (panoramaSettings.panoramaMultiplier == 1)
				{
					if (imageFormat == ImageFormat.PNG)
					{
						File.WriteAllBytes(string.Concat(text, "Face_", (CubemapFace)i, ".png"), sphereTemp.EncodeToPNG());
					}
					else if (imageFormat == ImageFormat.JPG)
					{
						File.WriteAllBytes(string.Concat(text, "Face_", (CubemapFace)i, ".jpg"), sphereTemp.EncodeToJPG(JPGQuality));
					}
					else
					{
						File.WriteAllBytes(string.Concat(text, "Face_", (CubemapFace)i, ".exr"), sphereTemp.EncodeToEXR(EXR32 ? Texture2D.EXRFlags.OutputAsFloat : Texture2D.EXRFlags.None));
					}
					continue;
				}
				bool sRGBWrite = GL.sRGBWrite;
				GL.sRGBWrite = true;
				if (!panoramaSettings.useFilter)
				{
					Graphics.Blit(sphereTemp, temporary);
				}
				else
				{
					SSAA_Internal.bicubicMaterial.SetFloat("_ResizeWidth", num);
					SSAA_Internal.bicubicMaterial.SetFloat("_ResizeHeight", num);
					SSAA_Internal.bicubicMaterial.SetFloat("_Sharpness", panoramaSettings.sharpness);
					Graphics.Blit(sphereTemp, temporary, SSAA_Internal.bicubicMaterial, 0);
				}
				RenderTexture.active = temporary;
				Texture2D texture2D = new Texture2D(RenderTexture.active.width, RenderTexture.active.height, TextureFormat.ARGB32, true, true);
				texture2D.ReadPixels(new Rect(0f, 0f, RenderTexture.active.width, RenderTexture.active.height), 0, 0);
				if (imageFormat == ImageFormat.PNG)
				{
					File.WriteAllBytes(string.Concat(text, "\\Face_", (CubemapFace)i, ".png"), texture2D.EncodeToPNG());
				}
				else if (imageFormat == ImageFormat.JPG)
				{
					File.WriteAllBytes(string.Concat(text, "\\Face_", (CubemapFace)i, ".jpg"), texture2D.EncodeToJPG(JPGQuality));
				}
				else
				{
					File.WriteAllBytes(string.Concat(text, "\\Face_", (CubemapFace)i, ".exr"), texture2D.EncodeToEXR(EXR32 ? Texture2D.EXRFlags.OutputAsFloat : Texture2D.EXRFlags.None));
				}
				GL.sRGBWrite = sRGBWrite;
			}
			sphereTemp.Resize(2, 2);
			sphereTemp.Apply();
			RenderTexture.ReleaseTemporary(temporary);
			SSAA_Internal.enabled = true;
			base.enabled = true;
		}

		private void SetupAdaptive(int fps)
		{
			int num = (useVsyncTarget ? Screen.currentResolution.refreshRate : targetFramerate);
			if (fps < num - 5)
			{
				multiplier = Mathf.Clamp(multiplier - 0.1f, minMultiplier, maxMultiplier);
			}
			else if (fps > num + 10)
			{
				multiplier = Mathf.Clamp(multiplier + 0.1f, minMultiplier, maxMultiplier);
			}
		}

		private void SetupRender()
		{
			try
			{
				currentCamera.targetTexture.Release();
				currentCamera.targetTexture.width = (int)((float)Screen.width * multiplier);
				currentCamera.targetTexture.height = (int)((float)Screen.height * ((renderMode == Mode.PerAxisScale) ? multiplierVertical : multiplier));
				currentCamera.targetTexture.Create();
			}
			catch (Exception message)
			{
				Debug.LogError("Something went wrong. SSAA has been set to off");
				Debug.LogError(message);
				SetAsSSAA(SSAAMode.SSAA_OFF);
			}
		}

		private void SetupScreenshotRender(float mul, bool compatibilityMode)
		{
			try
			{
				currentCamera.aspect = screenshotSettings.outputResolution.x / screenshotSettings.outputResolution.y;
				currentCamera.targetTexture.Release();
				currentCamera.targetTexture.width = (int)(screenshotSettings.outputResolution.x * mul);
				currentCamera.targetTexture.height = (int)(screenshotSettings.outputResolution.y * mul);
				currentCamera.targetTexture.Create();
			}
			catch (Exception ex)
			{
				Debug.LogError(ex.ToString());
			}
		}

		protected IEnumerator AdaptiveTask()
		{
			yield return new WaitForSeconds(2f);
			if (renderMode == Mode.AdaptiveResolution)
			{
				SetupAdaptive(FpsData.CurrentFps);
			}
			if (base.enabled)
			{
				StartCoroutine(AdaptiveTask());
			}
		}

		private Color[] Rotate90(Color[] source, int n)
		{
			Color[] array = new Color[n * n];
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					array[i * n + j] = source[(n - j - 1) * n + i];
				}
			}
			return array;
		}

		public void SetAsSSAA(SSAAMode mode)
		{
			renderMode = Mode.SSAA;
			ssaaMode = mode;
			switch (mode)
			{
			case SSAAMode.SSAA_OFF:
				multiplier = 1f;
				useShader = false;
				break;
			case SSAAMode.SSAA_HALF:
				multiplier = SSAA_HALF.multiplier;
				useShader = SSAA_HALF.useFilter;
				sharpness = SSAA_HALF.sharpness;
				filterType = SSAA_HALF.filterType;
				sampleDistance = SSAA_HALF.sampleDistance;
				break;
			case SSAAMode.SSAA_X2:
				multiplier = SSAA_X2.multiplier;
				useShader = SSAA_X2.useFilter;
				sharpness = SSAA_X2.sharpness;
				filterType = SSAA_X2.filterType;
				sampleDistance = SSAA_X2.sampleDistance;
				break;
			case SSAAMode.SSAA_X4:
				multiplier = SSAA_X4.multiplier;
				useShader = SSAA_X4.useFilter;
				sharpness = SSAA_X4.sharpness;
				filterType = SSAA_X4.filterType;
				sampleDistance = SSAA_X4.sampleDistance;
				break;
			}
		}

		public void SetAsScale(int percent)
		{
			percent = Mathf.Clamp(percent, 0, 100);
			renderMode = Mode.ResolutionScale;
			multiplier = (float)percent / 100f;
			SetDownsamplingSettings(false);
		}

		public void SetAsScale(int percent, Filter FilterType, float sharpnessfactor, float sampledist)
		{
			percent = Mathf.Clamp(percent, 0, 100);
			renderMode = Mode.ResolutionScale;
			multiplier = (float)percent / 100f;
			SetDownsamplingSettings(FilterType, sharpnessfactor, sampledist);
		}

		public void SetAsAdaptive(float minMultiplier, float maxMultiplier, int targetFramerate)
		{
			if (minMultiplier < 0.1f)
			{
				minMultiplier = 0.1f;
			}
			if (maxMultiplier < minMultiplier)
			{
				maxMultiplier = minMultiplier + 0.1f;
			}
			this.minMultiplier = minMultiplier;
			this.maxMultiplier = maxMultiplier;
			this.targetFramerate = targetFramerate;
			useVsyncTarget = false;
			SetDownsamplingSettings(false);
		}

		public void SetAsAdaptive(float minMultiplier, float maxMultiplier)
		{
			if (minMultiplier < 0.1f)
			{
				minMultiplier = 0.1f;
			}
			if (maxMultiplier < minMultiplier)
			{
				maxMultiplier = minMultiplier + 0.1f;
			}
			this.minMultiplier = minMultiplier;
			this.maxMultiplier = maxMultiplier;
			useVsyncTarget = true;
			SetDownsamplingSettings(false);
		}

		public void SetAsAdaptive(float minMultiplier, float maxMultiplier, int targetFramerate, Filter FilterType, float sharpnessfactor, float sampledist)
		{
			if (minMultiplier < 0.1f)
			{
				minMultiplier = 0.1f;
			}
			if (maxMultiplier < minMultiplier)
			{
				maxMultiplier = minMultiplier + 0.1f;
			}
			this.minMultiplier = minMultiplier;
			this.maxMultiplier = maxMultiplier;
			this.targetFramerate = targetFramerate;
			useVsyncTarget = false;
			SetDownsamplingSettings(FilterType, sharpnessfactor, sampledist);
		}

		public void SetAsAdaptive(float minMultiplier, float maxMultiplier, Filter FilterType, float sharpnessfactor, float sampledist)
		{
			if (minMultiplier < 0.1f)
			{
				minMultiplier = 0.1f;
			}
			if (maxMultiplier < minMultiplier)
			{
				maxMultiplier = minMultiplier + 0.1f;
			}
			this.minMultiplier = minMultiplier;
			this.maxMultiplier = maxMultiplier;
			useVsyncTarget = true;
			SetDownsamplingSettings(FilterType, sharpnessfactor, sampledist);
		}

		public void SetAsCustom(float Multiplier)
		{
			if (Multiplier < 0.1f)
			{
				Multiplier = 0.1f;
			}
			renderMode = Mode.Custom;
			multiplier = Multiplier;
			SetDownsamplingSettings(false);
		}

		public void SetAsCustom(float Multiplier, Filter FilterType, float sharpnessfactor, float sampledist)
		{
			if (Multiplier < 0.1f)
			{
				Multiplier = 0.1f;
			}
			renderMode = Mode.Custom;
			multiplier = Multiplier;
			SetDownsamplingSettings(FilterType, sharpnessfactor, sampledist);
		}

		public virtual void SetAsAxisBased(float MultiplierX, float MultiplierY)
		{
			if (MultiplierX < 0.1f)
			{
				MultiplierX = 0.1f;
			}
			if (MultiplierY < 0.1f)
			{
				MultiplierY = 0.1f;
			}
			renderMode = Mode.PerAxisScale;
			multiplier = MultiplierX;
			multiplierVertical = MultiplierY;
			SetDownsamplingSettings(false);
		}

		public virtual void SetAsAxisBased(float MultiplierX, float MultiplierY, Filter FilterType, float sharpnessfactor, float sampledist)
		{
			if (MultiplierX < 0.1f)
			{
				MultiplierX = 0.1f;
			}
			if (MultiplierY < 0.1f)
			{
				MultiplierY = 0.1f;
			}
			renderMode = Mode.PerAxisScale;
			multiplier = MultiplierX;
			multiplierVertical = MultiplierY;
			SetDownsamplingSettings(FilterType, sharpnessfactor, sampledist);
		}

		public void SetDownsamplingSettings(bool use)
		{
			useShader = use;
			filterType = (use ? Filter.BILINEAR : Filter.NEAREST_NEIGHBOR);
			sharpness = (use ? 0.85f : 0f);
			sampleDistance = (use ? 0.9f : 0f);
		}

		public void SetDownsamplingSettings(Filter FilterType, float sharpnessfactor, float sampledist)
		{
			useShader = true;
			filterType = FilterType;
			sharpness = Mathf.Clamp(sharpnessfactor, 0f, 1f);
			sampleDistance = Mathf.Clamp(sampledist, 0.5f, 1.5f);
		}

		public void SetUltra(bool enabled)
		{
			ssaaUltra = enabled;
		}

		public void SetUltraIntensity(float intensity)
		{
			fssaaIntensity = Mathf.Clamp01(intensity);
		}

		public virtual void TakeScreenshot(string path, Vector2 Size, int multiplier)
		{
			screenshotSettings.takeScreenshot = true;
			screenshotSettings.outputResolution = Size;
			screenshotSettings.screenshotMultiplier = multiplier;
			screenshotPath = path;
			screenshotSettings.useFilter = false;
		}

		public virtual void TakeScreenshot(string path, Vector2 Size, int multiplier, float sharpness)
		{
			screenshotSettings.takeScreenshot = true;
			screenshotSettings.outputResolution = Size;
			screenshotSettings.screenshotMultiplier = multiplier;
			screenshotPath = path;
			screenshotSettings.useFilter = true;
			screenshotSettings.sharpness = Mathf.Clamp(sharpness, 0f, 1f);
		}

		public virtual void TakePanorama(string path, int size)
		{
			panoramaSettings.useFilter = false;
			panoramaSettings.panoramaSize = size;
			panoramaSettings.panoramaMultiplier = 1;
			screenshotPath = path;
			RenderPanorama();
		}

		public virtual void TakePanorama(string path, int size, int multiplier)
		{
			panoramaSettings.useFilter = false;
			panoramaSettings.panoramaSize = size;
			panoramaSettings.panoramaMultiplier = multiplier;
			screenshotPath = path;
			RenderPanorama();
		}

		public virtual void TakePanorama(string path, int size, int multiplier, float sharpness)
		{
			panoramaSettings.useFilter = true;
			panoramaSettings.panoramaSize = size;
			panoramaSettings.panoramaMultiplier = multiplier;
			panoramaSettings.sharpness = sharpness;
			screenshotPath = path;
			RenderPanorama();
		}

		public virtual void SetScreenshotModuleToPNG()
		{
			imageFormat = ImageFormat.PNG;
		}

		public virtual void SetScreenshotModuleToJPG(int quality)
		{
			imageFormat = ImageFormat.JPG;
			JPGQuality = Mathf.Clamp(1, 100, quality);
		}

		public virtual void SetScreenshotModuleToEXR(bool EXR32)
		{
			imageFormat = ImageFormat.EXR;
			this.EXR32 = EXR32;
		}

		public virtual string GetResolution()
		{
			return (int)((float)Screen.width * multiplier) + "x" + (int)((float)Screen.height * multiplier);
		}

		public static void SetAllAsSSAA(SSAAMode mode)
		{
			MadGoatSSAA[] array = UnityEngine.Object.FindObjectsOfType<MadGoatSSAA>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetAsSSAA(mode);
			}
		}

		public static void SetAllAsScale(int percent)
		{
			MadGoatSSAA[] array = UnityEngine.Object.FindObjectsOfType<MadGoatSSAA>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetAsScale(percent);
			}
		}

		public static void SetAllAsScale(int percent, Filter FilterType, float sharpnessfactor, float sampledist)
		{
			MadGoatSSAA[] array = UnityEngine.Object.FindObjectsOfType<MadGoatSSAA>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetAsScale(percent, FilterType, sharpnessfactor, sampledist);
			}
		}

		public static void SetAllAsAdaptive(float minMultiplier, float maxMultiplier, int targetFramerate)
		{
			MadGoatSSAA[] array = UnityEngine.Object.FindObjectsOfType<MadGoatSSAA>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetAsAdaptive(minMultiplier, maxMultiplier, targetFramerate);
			}
		}

		public static void SetAllAsAdaptive(float minMultiplier, float maxMultiplier)
		{
			MadGoatSSAA[] array = UnityEngine.Object.FindObjectsOfType<MadGoatSSAA>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetAsAdaptive(minMultiplier, maxMultiplier);
			}
		}

		public static void SetAllAsAdaptive(float minMultiplier, float maxMultiplier, int targetFramerate, Filter FilterType, float sharpnessfactor, float sampledist)
		{
			MadGoatSSAA[] array = UnityEngine.Object.FindObjectsOfType<MadGoatSSAA>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetAsAdaptive(minMultiplier, maxMultiplier, targetFramerate, FilterType, sharpnessfactor, sampledist);
			}
		}

		public static void SetAllAsAdaptive(float minMultiplier, float maxMultiplier, Filter FilterType, float sharpnessfactor, float sampledist)
		{
			MadGoatSSAA[] array = UnityEngine.Object.FindObjectsOfType<MadGoatSSAA>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetAsAdaptive(minMultiplier, maxMultiplier, FilterType, sharpnessfactor, sampledist);
			}
		}

		public static void SetAllAsCustom(float Multiplier)
		{
			MadGoatSSAA[] array = UnityEngine.Object.FindObjectsOfType<MadGoatSSAA>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetAsCustom(Multiplier);
			}
		}

		public static void SetAllAsCustom(float Multiplier, Filter FilterType, float sharpnessfactor, float sampledist)
		{
			MadGoatSSAA[] array = UnityEngine.Object.FindObjectsOfType<MadGoatSSAA>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetAsCustom(Multiplier, FilterType, sharpnessfactor, sampledist);
			}
		}

		public static void SetAllAsAxisBased(float MultiplierX, float MultiplierY)
		{
			MadGoatSSAA[] array = UnityEngine.Object.FindObjectsOfType<MadGoatSSAA>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetAsAxisBased(MultiplierX, MultiplierY);
			}
		}

		public static void SetAllAsAxisBased(float MultiplierX, float MultiplierY, Filter FilterType, float sharpnessfactor, float sampledist)
		{
			MadGoatSSAA[] array = UnityEngine.Object.FindObjectsOfType<MadGoatSSAA>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetAsAxisBased(MultiplierX, MultiplierY, FilterType, sharpnessfactor, sampledist);
			}
		}

		public static void SetAllDownsamplingSettings(bool use)
		{
			MadGoatSSAA[] array = UnityEngine.Object.FindObjectsOfType<MadGoatSSAA>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetDownsamplingSettings(use);
			}
		}

		public static void SetAllDownsamplingSettings(Filter FilterType, float sharpnessfactor, float sampledist)
		{
			MadGoatSSAA[] array = UnityEngine.Object.FindObjectsOfType<MadGoatSSAA>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetDownsamplingSettings(FilterType, sharpnessfactor, sampledist);
			}
		}

		public static void SetAllUltra(bool enabled)
		{
			MadGoatSSAA[] array = UnityEngine.Object.FindObjectsOfType<MadGoatSSAA>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetUltra(enabled);
			}
		}

		public static void SetAllUltraIntensity(float intensity)
		{
			MadGoatSSAA[] array = UnityEngine.Object.FindObjectsOfType<MadGoatSSAA>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetUltraIntensity(intensity);
			}
		}

		public virtual Ray ScreenPointToRay(Vector3 position)
		{
			if (!base.enabled)
			{
				return currentCamera.ScreenPointToRay(position);
			}
			return renderCamera.ScreenPointToRay(position);
		}

		public virtual Vector3 ScreenToViewportPoint(Vector3 position)
		{
			return renderCamera.ScreenToViewportPoint(position);
		}

		public virtual Vector3 ScreenToWorldPoint(Vector3 position)
		{
			return renderCamera.ScreenToWorldPoint(position);
		}

		public virtual Vector3 WorldToScreenPoint(Vector3 position)
		{
			if (!base.enabled)
			{
				return currentCamera.WorldToScreenPoint(position);
			}
			return renderCamera.WorldToScreenPoint(position);
		}

		public virtual Vector3 ViewportToScreenPoint(Vector3 position)
		{
			return renderCamera.ViewportToScreenPoint(position);
		}
	}
}
