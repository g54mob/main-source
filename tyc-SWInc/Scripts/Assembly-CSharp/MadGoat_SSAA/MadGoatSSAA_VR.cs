using System;
using UnityEngine;
using UnityEngine.XR;

namespace MadGoat_SSAA
{
	public class MadGoatSSAA_VR : MadGoatSSAA
	{
		[SerializeField]
		private Shader _bilinearshader;

		[SerializeField]
		private Shader _bicubicshader;

		[SerializeField]
		private Shader _neighborshader;

		private Material material_bl;

		private Material material_bc;

		private Material material_nn;

		private Material material_current;

		public Shader bilinearshader
		{
			get
			{
				if (_bilinearshader == null)
				{
					_bilinearshader = Shader.Find("Hidden/SSAA_Bilinear");
				}
				return _bilinearshader;
			}
		}

		public Shader bicubicshader
		{
			get
			{
				if (_bicubicshader == null)
				{
					_bicubicshader = Shader.Find("Hidden/SSAA_Bicubic");
				}
				return _bicubicshader;
			}
		}

		public Shader neighborshader
		{
			get
			{
				if (_neighborshader == null)
				{
					_neighborshader = Shader.Find("Hidden/SSAA_Nearest");
				}
				return _neighborshader;
			}
		}

		private void OnEnable()
		{
			if (dbgData == null)
			{
				dbgData = new DebugData(this);
			}
			Init();
			StartCoroutine(AdaptiveTask());
		}

		private void Update()
		{
			FpsData.Update();
			SendDbgInfo();
		}

		private void OnDisable()
		{
			XRSettings.eyeTextureResolutionScale = 1f;
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			RenderTexture temporary = RenderTexture.GetTemporary(source.width, source.height, 24, source.format);
			temporary.vrUsage = VRTextureUsage.TwoEyes;
			if (renderMode == Mode.SSAA && ssaaUltra && (ssaaMode == SSAAMode.SSAA_X2 || ssaaMode == SSAAMode.SSAA_X4))
			{
				DoFSS(source, temporary);
			}
			else if (renderMode == Mode.ResolutionScale && ssaaUltra && multiplier > 1f)
			{
				DoFSS(source, temporary);
			}
			else if (renderMode == Mode.Custom && ssaaUltra && multiplier > 1f)
			{
				DoFSS(source, temporary);
			}
			else
			{
				Graphics.Blit(source, temporary);
			}
			if (!useShader || multiplier == 1f)
			{
				Graphics.Blit(temporary, destination);
			}
			else
			{
				material_current.SetFloat("_ResizeWidth", Screen.width);
				material_current.SetFloat("_ResizeHeight", Screen.height);
				material_current.SetFloat("_Sharpness", sharpness);
				material_current.SetFloat("_SampleDistance", sampleDistance);
				Graphics.Blit(source, destination, material_current, 0);
			}
			temporary.Release();
			temporary = null;
		}

		private void OnPostRender()
		{
		}

		private void OnPreRender()
		{
			try
			{
				if (!XRDevice.isPresent)
				{
					throw new Exception("VRDevice not present or not detected");
				}
				XRSettings.eyeTextureResolutionScale = multiplier;
				ChangeMaterial(filterType);
			}
			catch (Exception message)
			{
				Debug.LogError("Something went wrong. SSAA has been set to off and plugin was disabled");
				Debug.LogError(message);
				SetAsSSAA(SSAAMode.SSAA_OFF);
				base.enabled = false;
			}
		}

		private void ChangeMaterial(Filter Type)
		{
			switch (Type)
			{
			case Filter.NEAREST_NEIGHBOR:
				material_current = material_nn;
				break;
			case Filter.BILINEAR:
				material_current = material_bl;
				break;
			case Filter.BICUBIC:
				material_current = material_bc;
				break;
			}
		}

		public override void Init()
		{
			if (currentCamera == null)
			{
				currentCamera = GetComponent<Camera>();
			}
			XRSettings.eyeTextureResolutionScale = multiplier;
			if (material_bl == null)
			{
				material_bl = new Material(bilinearshader);
			}
			if (material_bc == null)
			{
				material_bc = new Material(bicubicshader);
			}
			if (material_nn == null)
			{
				material_nn = new Material(neighborshader);
			}
			material_current = material_bc;
		}

		public override void SetAsAxisBased(float MultiplierX, float MultiplierY)
		{
			Debug.LogWarning("NOT SUPPORTED IN VR MODE.\nX axis will be used as global multiplier instead.");
			base.SetAsAxisBased(MultiplierX, MultiplierY);
		}

		public override void SetAsAxisBased(float MultiplierX, float MultiplierY, Filter FilterType, float sharpnessfactor, float sampledist)
		{
			Debug.LogWarning("NOT SUPPORTED IN VR MODE.\nX axis will be used as global multiplier instead.");
			base.SetAsAxisBased(MultiplierX, MultiplierY, FilterType, sharpnessfactor, sampledist);
		}

		public override Ray ScreenPointToRay(Vector3 position)
		{
			return currentCamera.ScreenPointToRay(position);
		}

		public override Vector3 ScreenToWorldPoint(Vector3 position)
		{
			return currentCamera.ScreenToWorldPoint(position);
		}

		public override Vector3 ScreenToViewportPoint(Vector3 position)
		{
			return currentCamera.ScreenToViewportPoint(position);
		}

		public override Vector3 WorldToScreenPoint(Vector3 position)
		{
			return currentCamera.WorldToScreenPoint(position);
		}

		public override Vector3 ViewportToScreenPoint(Vector3 position)
		{
			return currentCamera.ViewportToScreenPoint(position);
		}

		public override void TakeScreenshot(string path, Vector2 Size, int multiplier)
		{
			Debug.LogWarning("Not available in VR mode");
		}

		public override void TakeScreenshot(string path, Vector2 Size, int multiplier, float sharpness)
		{
			Debug.LogWarning("Not available in VR mode");
		}

		public override void TakePanorama(string path, int size)
		{
			Debug.LogWarning("Not available in VR mode");
		}

		public override void TakePanorama(string path, int size, int multiplier)
		{
			Debug.LogWarning("Not available in VR mode");
		}

		public override void TakePanorama(string path, int size, int multiplier, float sharpness)
		{
			Debug.LogWarning("Not available in VR mode");
		}

		public override void SetScreenshotModuleToPNG()
		{
			Debug.LogWarning("Not available in VR mode");
		}

		public override void SetScreenshotModuleToJPG(int quality)
		{
			Debug.LogWarning("Not available in VR mode");
		}

		public override void SetScreenshotModuleToEXR(bool EXR32)
		{
			Debug.LogWarning("Not available in VR mode");
		}
	}
}
