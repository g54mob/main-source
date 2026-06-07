using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SSAA
{
	public class internal_SSAA : MonoBehaviour
	{
		private static GameObject renderTargetCam;

		private static TextureRenderer textureRenderer;

		private static RenderTexture renderTexture;

		public static SSAAFilter filter;

		private Shader[] SamplingShader = new Shader[4];

		public static float scale;

		public static bool UseDynamicOutputResolution = false;

		private Camera mainCam;

		private int screenX;

		private int screenY;

		private int targetX = 100;

		private int targetY = 100;

		public static int outputWidth = 0;

		public static int outputHeight = 0;

		private int hideFlagDontShowSave = 61;

		public bool restart;

		private bool active;

		private static List<internal_SSAA> SSAAInstances = new List<internal_SSAA>();

		public static GameObject RenderTargetCamera
		{
			get
			{
				return renderTargetCam;
			}
		}

		public static RenderTexture RenderTexture
		{
			get
			{
				return renderTexture;
			}
		}

		public static SSAAFilter Filter
		{
			get
			{
				return filter;
			}
			set
			{
				if (value == filter)
				{
					return;
				}
				filter = value;
				foreach (internal_SSAA sSAAInstance in SSAAInstances)
				{
					if (sSAAInstance.active)
					{
						sSAAInstance.restart = true;
					}
				}
			}
		}

		public Camera RenderingCamera
		{
			get
			{
				return mainCam;
			}
		}

		public static List<internal_SSAA> InstancesList
		{
			get
			{
				return SSAAInstances;
			}
		}

		private void OnEnable()
		{
			mainCam = GetComponent<Camera>();
			if (mainCam == null)
			{
				Debug.LogError("Missing Camera on GameObject!");
				base.enabled = false;
				return;
			}
			hideFlagDontShowSave = 61;
			SamplingShader[0] = Resources.Load("BilinearSharper") as Shader;
			SamplingShader[1] = Resources.Load("BilinearDefault") as Shader;
			SamplingShader[2] = Resources.Load("BilinearHigh") as Shader;
			SamplingShader[3] = Resources.Load("LanczosHigh") as Shader;
			targetX = Screen.width;
			targetY = Screen.height;
			new Shader();
			if (Application.isEditor)
			{
				restart = true;
			}
			else
			{
				StartSSAA();
			}
		}

		private void OnDisable()
		{
			StopSSAA();
		}

		private void Update()
		{
			if (!UseDynamicOutputResolution && (screenX != Screen.width || screenY != Screen.height))
			{
				restart = true;
			}
			if (restart)
			{
				Restart();
			}
		}

		private void Restart()
		{
			StopSSAA();
			StartSSAA();
			restart = false;
		}

		private void OnPreCull()
		{
			if (active && UseDynamicOutputResolution && (screenX != Screen.width || screenY != Screen.height))
			{
				targetX = Screen.width;
				targetY = Screen.height;
				restart = true;
			}
			if (active)
			{
				mainCam.targetTexture = renderTexture;
			}
			if (mainCam.stereoEnabled && textureRenderer.stereoFirstPass)
			{
				textureRenderer.stereoFirstPass = false;
			}
			else
			{
				StartCoroutine("ResetCam");
			}
		}

		private IEnumerator ResetCam()
		{
			yield return new WaitForEndOfFrame();
			if (active)
			{
				mainCam.targetTexture = null;
			}
		}

		public static void ChangeScale(float newScale)
		{
			scale = newScale;
			foreach (internal_SSAA instances in InstancesList)
			{
				instances.restart = true;
			}
		}

		public void StartSSAA()
		{
			if (mainCam == null)
			{
				Debug.LogError("Missing Camera on Object!");
				return;
			}
			int num = 0;
			int num2 = 0;
			if (!UseDynamicOutputResolution)
			{
				screenX = Screen.width;
				screenY = Screen.height;
				num = (int)((float)Screen.width * scale);
				num2 = (int)((float)Screen.height * scale);
			}
			else
			{
				screenX = targetX;
				screenY = targetY;
				num = (int)((float)targetX * scale);
				num2 = (int)((float)targetY * scale);
				if (num <= 0)
				{
					num = 100;
				}
				if (num2 <= 0)
				{
					num2 = 100;
				}
			}
			if (renderTexture == null || renderTexture.width != num || renderTexture.height != num2)
			{
				if (renderTexture != null)
				{
					renderTexture.Release();
				}
				renderTexture = new RenderTexture(num, num2, 24, RenderTextureFormat.ARGB32);
				renderTexture.name = "SSAARenderTarget";
				renderTexture.hideFlags = (HideFlags)hideFlagDontShowSave;
			}
			if (!SSAAInstances.Contains(this))
			{
				SSAAInstances.Add(this);
			}
			if (renderTargetCam == null)
			{
				renderTargetCam = new GameObject("SSAARenderTargetCamera");
				renderTargetCam.hideFlags = (HideFlags)hideFlagDontShowSave;
				Camera camera = renderTargetCam.AddComponent<Camera>();
				camera.CopyFrom(mainCam);
				camera.cullingMask = 0;
				camera.targetTexture = null;
				textureRenderer = renderTargetCam.AddComponent<TextureRenderer>();
				textureRenderer.hideFlags = (HideFlags)hideFlagDontShowSave;
				if (SamplingShader != null)
				{
					switch (filter)
					{
					case SSAAFilter.BilinearSharper:
						textureRenderer.SamplingMaterial = new Material(SamplingShader[0]);
						break;
					case SSAAFilter.BilinearDefault:
						textureRenderer.SamplingMaterial = new Material(SamplingShader[1]);
						break;
					case SSAAFilter.BilinearHigh:
						textureRenderer.SamplingMaterial = new Material(SamplingShader[2]);
						break;
					case SSAAFilter.LanczosHigh:
						textureRenderer.SamplingMaterial = new Material(SamplingShader[3]);
						break;
					}
				}
			}
			active = true;
		}

		public void StopSSAA()
		{
			if (mainCam != null && mainCam.targetTexture != null)
			{
				mainCam.targetTexture = null;
			}
			active = false;
			SSAAInstances.Remove(this);
			if (SSAAInstances.Count == 0)
			{
				if (renderTargetCam != null)
				{
					Object.Destroy(renderTargetCam);
					renderTargetCam = null;
				}
				if (renderTexture != null)
				{
					renderTexture.Release();
					renderTexture = null;
				}
			}
		}

		public static void SaveSuperSampledToPNG(string pathname)
		{
			ScreenCapture.CaptureScreenshot(pathname, 1);
		}
	}
}
