using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace FlatKit
{
	public class FlatKitFog : ScriptableRendererFeature
	{
		[Tooltip("To create new settings use 'Create > FlatKit > Fog Settings'.")]
		public FogSettings settings;

		[SerializeField]
		[HideInInspector]
		private Material _effectMaterial;

		private BlitTexturePass _blitTexturePass;

		private RenderTargetHandle _fogTexture;

		private Texture2D _lutDepth;

		private Texture2D _lutHeight;

		private static readonly string FogShaderName = "Hidden/FlatKit/FogFilter";

		private static readonly int DistanceLut = Shader.PropertyToID("_DistanceLUT");

		private static readonly int Near = Shader.PropertyToID("_Near");

		private static readonly int Far = Shader.PropertyToID("_Far");

		private static readonly int UseDistanceFog = Shader.PropertyToID("_UseDistanceFog");

		private static readonly int UseDistanceFogOnSky = Shader.PropertyToID("_UseDistanceFogOnSky");

		private static readonly int DistanceFogIntensity = Shader.PropertyToID("_DistanceFogIntensity");

		private static readonly int HeightLut = Shader.PropertyToID("_HeightLUT");

		private static readonly int LowWorldY = Shader.PropertyToID("_LowWorldY");

		private static readonly int HighWorldY = Shader.PropertyToID("_HighWorldY");

		private static readonly int UseHeightFog = Shader.PropertyToID("_UseHeightFog");

		private static readonly int UseHeightFogOnSky = Shader.PropertyToID("_UseHeightFogOnSky");

		private static readonly int HeightFogIntensity = Shader.PropertyToID("_HeightFogIntensity");

		private static readonly int DistanceHeightBlend = Shader.PropertyToID("_DistanceHeightBlend");

		public override void Create()
		{
			if (settings == null)
			{
				Debug.LogWarning("[FlatKit] Missing Fog Settings");
				return;
			}
			_blitTexturePass = new BlitTexturePass
			{
				renderPassEvent = settings.renderEvent
			};
			_fogTexture.Init("_EffectTexture");
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			if (settings == null)
			{
				Debug.LogWarning("[FlatKit] Missing Fog Settings");
			}
			else if (CreateMaterials())
			{
				SetMaterialProperties();
				_blitTexturePass.Setup(_effectMaterial, useDepth: true, useNormals: false, useColor: false);
				renderer.EnqueuePass(_blitTexturePass);
			}
		}

		protected override void Dispose(bool disposing)
		{
			CoreUtils.Destroy(_effectMaterial);
		}

		private bool CreateMaterials()
		{
			if (_effectMaterial == null)
			{
				Shader shader = Shader.Find(FogShaderName);
				Shader shader2 = Shader.Find(BlitTexturePass.CopyEffectShaderName);
				if (shader == null || shader2 == null)
				{
					return false;
				}
				_effectMaterial = CoreUtils.CreateEngineMaterial(shader);
			}
			return true;
		}

		private void SetMaterialProperties()
		{
			if (!(_effectMaterial == null))
			{
				UpdateDistanceLut();
				_effectMaterial.SetTexture(DistanceLut, _lutDepth);
				_effectMaterial.SetFloat(Near, settings.near);
				_effectMaterial.SetFloat(Far, settings.far);
				_effectMaterial.SetFloat(UseDistanceFog, settings.useDistance ? 1f : 0f);
				_effectMaterial.SetFloat(UseDistanceFogOnSky, settings.useDistanceFogOnSky ? 1f : 0f);
				_effectMaterial.SetFloat(DistanceFogIntensity, settings.distanceFogIntensity);
				UpdateHeightLut();
				_effectMaterial.SetTexture(HeightLut, _lutHeight);
				_effectMaterial.SetFloat(LowWorldY, settings.low);
				_effectMaterial.SetFloat(HighWorldY, settings.high);
				_effectMaterial.SetFloat(UseHeightFog, settings.useHeight ? 1f : 0f);
				_effectMaterial.SetFloat(UseHeightFogOnSky, settings.useHeightFogOnSky ? 1f : 0f);
				_effectMaterial.SetFloat(HeightFogIntensity, settings.heightFogIntensity);
				_effectMaterial.SetFloat(DistanceHeightBlend, settings.distanceHeightBlend);
			}
		}

		private void UpdateDistanceLut()
		{
			if (settings.distanceGradient == null)
			{
				return;
			}
			if (_lutDepth != null)
			{
				Object.DestroyImmediate(_lutDepth);
			}
			_lutDepth = new Texture2D(256, 1, TextureFormat.RGBA32, mipChain: false)
			{
				wrapMode = TextureWrapMode.Clamp,
				hideFlags = HideFlags.HideAndDontSave,
				filterMode = FilterMode.Bilinear
			};
			for (float num = 0f; num < 256f; num += 1f)
			{
				Color color = settings.distanceGradient.Evaluate(num / 255f);
				for (float num2 = 0f; num2 < 1f; num2 += 1f)
				{
					_lutDepth.SetPixel(Mathf.CeilToInt(num), Mathf.CeilToInt(num2), color);
				}
			}
			_lutDepth.Apply();
		}

		private void UpdateHeightLut()
		{
			if (settings.heightGradient == null)
			{
				return;
			}
			if (_lutHeight != null)
			{
				Object.DestroyImmediate(_lutHeight);
			}
			_lutHeight = new Texture2D(256, 1, TextureFormat.RGBA32, mipChain: false)
			{
				wrapMode = TextureWrapMode.Clamp,
				hideFlags = HideFlags.HideAndDontSave,
				filterMode = FilterMode.Bilinear
			};
			for (float num = 0f; num < 256f; num += 1f)
			{
				Color color = settings.heightGradient.Evaluate(num / 255f);
				for (float num2 = 0f; num2 < 1f; num2 += 1f)
				{
					_lutHeight.SetPixel(Mathf.CeilToInt(num), Mathf.CeilToInt(num2), color);
				}
			}
			_lutHeight.Apply();
		}
	}
}
