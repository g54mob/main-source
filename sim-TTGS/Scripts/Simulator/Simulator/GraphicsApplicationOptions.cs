using System;
using Dhs5.Utility.Settings;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Simulator
{
	[Settings("Application Settings/Graphics", Scope.Project)]
	public class GraphicsApplicationOptions : CustomApplicationOptions<GraphicsApplicationOptions>
	{
		[Serializable]
		private struct ShadowsSettings
		{
			[SerializeField]
			private float m_maxDistance;

			[SerializeField]
			private int m_cascadeCount;

			[SerializeField]
			private float m_depthBias;

			[SerializeField]
			private float m_normalBias;

			public void AssignSettings()
			{
				UniversalRenderPipelineAsset universalRenderPipelineAsset = GraphicsSettings.currentRenderPipeline as UniversalRenderPipelineAsset;
				if (!(universalRenderPipelineAsset == null))
				{
					universalRenderPipelineAsset.shadowDistance = m_maxDistance;
					universalRenderPipelineAsset.shadowCascadeCount = m_cascadeCount;
					universalRenderPipelineAsset.shadowDepthBias = m_depthBias;
					universalRenderPipelineAsset.shadowNormalBias = m_normalBias;
				}
			}

			public static bool TryGetCurrentURPSettings(out ShadowsSettings settings)
			{
				UniversalRenderPipelineAsset universalRenderPipelineAsset = GraphicsSettings.currentRenderPipeline as UniversalRenderPipelineAsset;
				if (universalRenderPipelineAsset == null)
				{
					settings = default(ShadowsSettings);
					return false;
				}
				settings = new ShadowsSettings
				{
					m_maxDistance = universalRenderPipelineAsset.shadowDistance,
					m_cascadeCount = universalRenderPipelineAsset.shadowCascadeCount,
					m_depthBias = universalRenderPipelineAsset.shadowDepthBias,
					m_normalBias = universalRenderPipelineAsset.shadowNormalBias
				};
				return true;
			}
		}

		[Header("Options")]
		[SerializeField]
		private FramerateOption m_framerateOption;

		[SerializeField]
		private QualityOptions m_qualityOptions;

		[SerializeField]
		private PlayerPrefFloat m_fieldOfView;

		[SerializeField]
		private PlayerPrefBool m_crosshair;

		[SerializeField]
		[ReadOnly(false, false)]
		public FullScreenMode playerSettingsFullscreenMode;

		[SerializeField]
		[ReadOnly(false, false)]
		public bool playerSettingsUseNativeResolution;

		[SerializeField]
		[ReadOnly(false, false)]
		public int playerSettingsResolutionWidth;

		[SerializeField]
		[ReadOnly(false, false)]
		public int playerSettingsResolutionHeight;

		[Header("Shadows")]
		[SerializeField]
		private ShadowsSettings m_wargameShadowSettings;

		private static ShadowsSettings _cachedShadowSettings;

		public static FramerateOption FramerateOption => CustomSettings<GraphicsApplicationOptions>.I.m_framerateOption;

		public static QualityOptions QualityOptions => CustomSettings<GraphicsApplicationOptions>.I.m_qualityOptions;

		public static PlayerPrefFloat FieldOfView => CustomSettings<GraphicsApplicationOptions>.I.m_fieldOfView;

		public static PlayerPrefBool Crosshair => CustomSettings<GraphicsApplicationOptions>.I.m_crosshair;

		public override void Load()
		{
			m_framerateOption.Load();
			m_qualityOptions.Load();
			m_fieldOfView.Load();
			m_crosshair.Load();
		}

		public override void ResetSettings()
		{
			int systemWidth;
			int systemHeight;
			if (playerSettingsUseNativeResolution)
			{
				systemWidth = Display.main.systemWidth;
				systemHeight = Display.main.systemHeight;
			}
			else
			{
				systemWidth = playerSettingsResolutionWidth;
				systemHeight = playerSettingsResolutionHeight;
			}
			Screen.SetResolution(systemWidth, systemHeight, playerSettingsFullscreenMode);
			m_framerateOption.Reset();
			m_qualityOptions.Reset();
			m_fieldOfView.Reset();
			m_crosshair.Reset();
		}

		public static void TemporarilyApplyWargameShadowSettings()
		{
			TemporarilyApplyShadowSettings(CustomSettings<GraphicsApplicationOptions>.I.m_wargameShadowSettings);
		}

		private static void TemporarilyApplyShadowSettings(ShadowsSettings settings)
		{
			if (ShadowsSettings.TryGetCurrentURPSettings(out _cachedShadowSettings))
			{
				settings.AssignSettings();
			}
		}

		public static void ApplyDefaultShadowSettings()
		{
			_cachedShadowSettings.AssignSettings();
		}
	}
}
