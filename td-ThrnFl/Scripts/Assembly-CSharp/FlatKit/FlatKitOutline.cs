using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace FlatKit
{
	public class FlatKitOutline : ScriptableRendererFeature
	{
		[Tooltip("To create new settings use 'Create > FlatKit > Outline Settings'.")]
		public OutlineSettings settings;

		[SerializeField]
		[HideInInspector]
		private Material _effectMaterial;

		private BlitTexturePass _blitTexturePass;

		private static readonly string OutlineShaderName = "Hidden/FlatKit/OutlineFilter";

		private static readonly int EdgeColor = Shader.PropertyToID("_EdgeColor");

		private static readonly int Thickness = Shader.PropertyToID("_Thickness");

		private static readonly int DepthThresholdMin = Shader.PropertyToID("_DepthThresholdMin");

		private static readonly int DepthThresholdMax = Shader.PropertyToID("_DepthThresholdMax");

		private static readonly int NormalThresholdMin = Shader.PropertyToID("_NormalThresholdMin");

		private static readonly int NormalThresholdMax = Shader.PropertyToID("_NormalThresholdMax");

		private static readonly int ColorThresholdMin = Shader.PropertyToID("_ColorThresholdMin");

		private static readonly int ColorThresholdMax = Shader.PropertyToID("_ColorThresholdMax");

		public override void Create()
		{
			if (settings == null)
			{
				Debug.LogWarning("[FlatKit] Missing Outline Settings");
			}
			else if (_blitTexturePass == null)
			{
				_blitTexturePass = new BlitTexturePass
				{
					renderPassEvent = settings.renderEvent
				};
			}
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			if (settings == null)
			{
				Debug.LogWarning("[FlatKit] Missing Outline Settings");
			}
			else if (CreateMaterials())
			{
				SetMaterialProperties();
				_blitTexturePass.Setup(_effectMaterial, settings.useDepth, settings.useNormals, useColor: true);
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
				Shader shader = Shader.Find(OutlineShaderName);
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
				if (settings.useDepth)
				{
					_effectMaterial.EnableKeyword("OUTLINE_USE_DEPTH");
				}
				else
				{
					_effectMaterial.DisableKeyword("OUTLINE_USE_DEPTH");
				}
				if (settings.useNormals)
				{
					_effectMaterial.EnableKeyword("OUTLINE_USE_NORMALS");
				}
				else
				{
					_effectMaterial.DisableKeyword("OUTLINE_USE_NORMALS");
				}
				if (settings.useColor)
				{
					_effectMaterial.EnableKeyword("OUTLINE_USE_COLOR");
				}
				else
				{
					_effectMaterial.DisableKeyword("OUTLINE_USE_COLOR");
				}
				if (settings.outlineOnly)
				{
					_effectMaterial.EnableKeyword("OUTLINE_ONLY");
				}
				else
				{
					_effectMaterial.DisableKeyword("OUTLINE_ONLY");
				}
				if (settings.resolutionInvariant)
				{
					_effectMaterial.EnableKeyword("RESOLUTION_INVARIANT_THICKNESS");
				}
				else
				{
					_effectMaterial.DisableKeyword("RESOLUTION_INVARIANT_THICKNESS");
				}
				_effectMaterial.SetColor(EdgeColor, settings.edgeColor);
				_effectMaterial.SetFloat(Thickness, settings.thickness);
				_effectMaterial.SetFloat(DepthThresholdMin, settings.minDepthThreshold);
				_effectMaterial.SetFloat(DepthThresholdMax, settings.maxDepthThreshold);
				_effectMaterial.SetFloat(NormalThresholdMin, settings.minNormalsThreshold);
				_effectMaterial.SetFloat(NormalThresholdMax, settings.maxNormalsThreshold);
				_effectMaterial.SetFloat(ColorThresholdMin, settings.minColorThreshold);
				_effectMaterial.SetFloat(ColorThresholdMax, settings.maxColorThreshold);
			}
		}
	}
}
