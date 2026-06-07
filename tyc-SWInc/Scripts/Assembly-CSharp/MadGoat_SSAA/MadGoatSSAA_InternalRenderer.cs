using System;
using System.IO;
using UnityEngine;

namespace MadGoat_SSAA
{
	[ExecuteInEditMode]
	public class MadGoatSSAA_InternalRenderer : MonoBehaviour
	{
		[HideInInspector]
		public float multiplier;

		[HideInInspector]
		public float sharpness;

		[HideInInspector]
		public bool useShader;

		[HideInInspector]
		public float sampleDistance;

		[HideInInspector]
		public Camera main;

		[HideInInspector]
		public Camera current;

		[SerializeField]
		private Shader _bilinearshader;

		[SerializeField]
		private Shader _bicubicshader;

		[SerializeField]
		private Shader _neighborshader;

		[SerializeField]
		private Shader _defshader;

		private Material material_bl;

		private Material material_bc;

		private Material material_nn;

		private Material material_def;

		private Material material_current;

		private MadGoatSSAA mainComponent;

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

		public Shader defshader
		{
			get
			{
				if (_defshader == null)
				{
					_defshader = Shader.Find("Hidden/SSAA_Def");
				}
				return _defshader;
			}
		}

		public Material bicubicMaterial
		{
			get
			{
				return material_bc;
			}
		}

		public Material bilinearMaterial
		{
			get
			{
				return material_bl;
			}
		}

		public string getName
		{
			get
			{
				return (mainComponent.useProductName ? Application.productName : mainComponent.namePrefix) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmssff") + "_" + mainComponent.screenshotSettings.outputResolution.y + "p";
			}
		}

		private void Start()
		{
			mainComponent = main.GetComponent<MadGoatSSAA>();
			material_bl = new Material(bilinearshader);
			material_bc = new Material(bicubicshader);
			material_nn = new Material(neighborshader);
			material_def = new Material(defshader);
			material_current = material_bc;
		}

		public void ChangeMaterial(Filter Type)
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

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			if (mainComponent.screenshotSettings.takeScreenshot)
			{
				Material material = new Material(bicubicshader);
				RenderTexture renderTexture = new RenderTexture((int)mainComponent.screenshotSettings.outputResolution.x, (int)mainComponent.screenshotSettings.outputResolution.y, 24, RenderTextureFormat.ARGB32);
				if (mainComponent.screenshotSettings.useFilter)
				{
					material.SetFloat("_ResizeWidth", (int)mainComponent.screenshotSettings.outputResolution.x);
					material.SetFloat("_ResizeHeight", (int)mainComponent.screenshotSettings.outputResolution.y);
					material.SetFloat("_Sharpness", 0.85f);
					Graphics.Blit(main.targetTexture, renderTexture, material, 0);
				}
				else
				{
					Graphics.Blit(main.targetTexture, renderTexture);
				}
				UnityEngine.Object.DestroyImmediate(material);
				RenderTexture.active = renderTexture;
				Texture2D texture2D = new Texture2D(RenderTexture.active.width, RenderTexture.active.height, TextureFormat.RGB24, false);
				texture2D.ReadPixels(new Rect(0f, 0f, RenderTexture.active.width, RenderTexture.active.height), 0, 0);
				new FileInfo(mainComponent.screenshotPath).Directory.Create();
				if (mainComponent.imageFormat == ImageFormat.PNG)
				{
					File.WriteAllBytes(mainComponent.screenshotPath + getName + ".png", texture2D.EncodeToPNG());
				}
				else if (mainComponent.imageFormat == ImageFormat.JPG)
				{
					File.WriteAllBytes(mainComponent.screenshotPath + getName + ".jpg", texture2D.EncodeToJPG(mainComponent.JPGQuality));
				}
				else
				{
					File.WriteAllBytes(mainComponent.screenshotPath + getName + ".exr", texture2D.EncodeToEXR(mainComponent.EXR32 ? Texture2D.EXRFlags.OutputAsFloat : Texture2D.EXRFlags.None));
				}
				RenderTexture.active = null;
				renderTexture.Release();
				UnityEngine.Object.DestroyImmediate(texture2D);
				mainComponent.screenshotSettings.takeScreenshot = false;
			}
			if (!useShader || multiplier == 1f)
			{
				Graphics.Blit(main.targetTexture, destination, material_def, 0);
				return;
			}
			material_current.SetFloat("_ResizeWidth", Screen.width);
			material_current.SetFloat("_ResizeHeight", Screen.height);
			material_current.SetFloat("_Sharpness", sharpness);
			material_current.SetFloat("_SampleDistance", sampleDistance);
			Graphics.Blit(main.targetTexture, destination, material_current, 0);
		}
	}
}
