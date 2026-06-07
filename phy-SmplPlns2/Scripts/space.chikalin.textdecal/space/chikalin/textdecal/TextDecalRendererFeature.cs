using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering.Universal.Internal;

namespace space.chikalin.textdecal
{
	[SupportedOnRenderer(typeof(UniversalRendererData))]
	[DisallowMultipleRendererFeature("Text Decal")]
	[Tooltip("With this Renderer Feature, Unity can project TextMeshPro objects onto other objects in the Scene.")]
	public class TextDecalRendererFeature : ScriptableRendererFeature
	{
		public enum DecalTechnique
		{
			Invalid = 0,
			DBuffer = 1,
			ScreenSpace = 2,
			GBuffer = 3
		}

		public enum DecalTechniqueOption
		{
			[Tooltip("Renders decals into DBuffer and then applied during opaque rendering. Requires DepthNormal prepass which makes not viable solution for the tile based renderers common on mobile.")]
			[InspectorName("DBuffer")]
			DBuffer = 0,
			[Tooltip("Renders decals after opaque objects with normal reconstructed from depth. The decals are simply rendered as mesh on top of opaque ones, as result does not support blending per single surface data (etc. normal blending only).")]
			ScreenSpace = 1
		}

		public enum DecalNormalBlend
		{
			[Tooltip("Low quality of normal reconstruction (Uses 1 sample).")]
			Low = 0,
			[Tooltip("Medium quality of normal reconstruction (Uses 5 samples).")]
			Medium = 1,
			[Tooltip("High quality of normal reconstruction (Uses 9 samples).")]
			High = 2
		}

		[Serializable]
		public class DecalScreenSpaceSettings
		{
			public DecalNormalBlend normalBlend;
		}

		[Serializable]
		public class DecalSettings
		{
			public DecalTechniqueOption technique;

			public DecalScreenSpaceSettings screenSpaceSettings;
		}

		internal const string CompatibilityScriptingAPIObsolete = "This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.";

		private CopyDepthPass _copyPass;

		private TextDecalDBufferRenderPass _dBufferPass;

		private TextDecalScreenSpaceRenderPass _screenSpacePass;

		private TextDecalForwardEmissivePass _forwardEmissivePass;

		public DecalSettings settings;

		public bool decalLayers;

		private bool _recreate = true;

		private DecalTechniqueOption _technique = DecalTechniqueOption.ScreenSpace;

		public override void Create()
		{
			_recreate = true;
		}

		private void Recreate()
		{
			if (_technique != settings.technique)
			{
				_recreate = true;
			}
			if (_recreate)
			{
				_recreate = false;
				_technique = settings.technique;
				switch (settings.technique)
				{
				case DecalTechniqueOption.DBuffer:
				{
					_dBufferPass = new TextDecalDBufferRenderPass((RenderPassEvent)202);
					_forwardEmissivePass = new TextDecalForwardEmissivePass();
					UniversalRendererResources renderPipelineSettings = GraphicsSettings.GetRenderPipelineSettings<UniversalRendererResources>();
					_copyPass = new TextDecalDBufferCopyDepthPass((RenderPassEvent)202, renderPipelineSettings.copyDepthPS, shouldClear: false, copyToDepth: true);
					break;
				}
				case DecalTechniqueOption.ScreenSpace:
					_screenSpacePass = new TextDecalScreenSpaceRenderPass(settings.screenSpaceSettings);
					break;
				default:
					throw new ArgumentOutOfRangeException();
				}
			}
		}

		public override void SetupRenderPasses(ScriptableRenderer renderer, in RenderingData renderingData)
		{
			if (settings.technique != DecalTechniqueOption.DBuffer)
			{
				_ = 1;
				return;
			}
			_dBufferPass.Setup(renderingData.cameraData);
			if (renderer is UniversalRenderer universalRenderer)
			{
				_copyPass.Setup(universalRenderer.cameraDepthTargetHandle, _dBufferPass._dBufferDepthHandle);
			}
		}

		public override void OnCameraPreCull(ScriptableRenderer renderer, in CameraData cameraData)
		{
			Recreate();
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			Recreate();
			switch (settings.technique)
			{
			case DecalTechniqueOption.DBuffer:
				renderer.EnqueuePass(_copyPass);
				renderer.EnqueuePass(_dBufferPass);
				renderer.EnqueuePass(_forwardEmissivePass);
				break;
			case DecalTechniqueOption.ScreenSpace:
				renderer.EnqueuePass(_screenSpacePass);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		protected override void Dispose(bool disposing)
		{
			_dBufferPass?.Dispose();
			_copyPass?.Dispose();
		}
	}
}
