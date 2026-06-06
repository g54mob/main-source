using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

namespace MyStuff.Graphics
{
	[DefaultExecutionOrder(-450)]
	public sealed class GraphicsManager : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CBlendPresetRoutine_003Ed__44 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GraphicsManager _003C_003E4__this;

			public GraphicsPreset targetPreset;

			public float duration;

			private float _003Celapsed_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CBlendPresetRoutine_003Ed__44(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[Header("=== Configuration ===")]
		[Tooltip("Graphics preset library")]
		[SerializeField]
		private GraphicsLibrary library;

		[Tooltip("Default quality tier")]
		[SerializeField]
		private GraphicsQuality defaultQuality;

		[Tooltip("Quality tiers array [Low, Medium, High, Ultra]. If assigned (4 elements), these are used instead of auto-generated defaults.")]
		[SerializeField]
		private GraphicsQuality[] qualityTiers;

		[Tooltip("Global volume for post-processing")]
		[SerializeField]
		private Volume globalVolume;

		[Header("=== Runtime Settings ===")]
		[Tooltip("Show debug logs")]
		[SerializeField]
		private bool showDebugLogs;

		private GraphicsPreset _activePreset;

		private GraphicsQuality _activeQuality;

		private VolumeProfile _runtimeProfile;

		private Coroutine _blendCoroutine;

		private GraphicsPreset _blendFrom;

		private GraphicsPreset _blendTo;

		private Light _sunLight;

		private Component _lensFlare;

		private GraphicsPreset _lastQualityCopy;

		private ScriptableRendererFeature _ssaoFeature;

		private int _activeQualityLevel;

		private GraphicsQuality[] _runtimeQualityTiers;

		private bool _runtimeTiersCreatedAtRuntime;

		private const float GAUSSIAN_END_DAY = 100f;

		private const float GAUSSIAN_END_NIGHT = 70f;

		private const float GAUSSIAN_START_DAY = 40f;

		private const float GAUSSIAN_START_NIGHT = 25f;

		public static GraphicsManager Instance { get; private set; }

		public GraphicsPreset ActivePreset => null;

		public GraphicsQuality ActiveQuality => null;

		public Volume GlobalVolume => null;

		public GraphicsLibrary Library => null;

		public event Action<GraphicsPreset> OnPresetApplied
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<GraphicsQuality> OnQualityChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<float> OnBlendProgress
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public void ApplyPresetImmediate(GraphicsPreset preset)
		{
		}

		public void ApplyPresetByName(string presetName, float blendSeconds = 0f)
		{
		}

		public void ApplyPresetBlended(GraphicsPreset preset, float blendSeconds)
		{
		}

		[IteratorStateMachine(typeof(_003CBlendPresetRoutine_003Ed__44))]
		private IEnumerator BlendPresetRoutine(GraphicsPreset targetPreset, float duration)
		{
			return null;
		}

		public void SetQuality(GraphicsQuality quality)
		{
		}

		private GraphicsPreset ApplyQualityToPreset(GraphicsPreset preset)
		{
			return null;
		}

		public void ApplyQualityPreset(int level)
		{
		}

		private void ApplyQualityPresetToVolume(int level)
		{
		}

		public AtmosphereState PauseAtmosphere()
		{
			return default(AtmosphereState);
		}

		public void ResumeAtmosphere(AtmosphereState savedState, float blendDuration = 0.5f)
		{
		}

		public DepthOfField GetDepthOfField()
		{
			return null;
		}

		public void SetBloomEnabled(bool enabled)
		{
		}

		public void SetBloomIntensity(float intensity)
		{
		}

		public void ApplyTimeBasedBloomModifier(float intensityMultiplier, float thresholdOffset)
		{
		}

		public void ApplyTimeBasedDOFModifier(float normalizedTime)
		{
		}

		public static float GetDayFactor(float normalizedTime)
		{
			return 0f;
		}

		public static float GetTimeBasedGaussianEnd(float normalizedTime)
		{
			return 0f;
		}

		public static float GetTimeBasedGaussianStart(float normalizedTime)
		{
			return 0f;
		}

		public void RestoreTimeBasedAtmosphere()
		{
		}

		public void SetDepthOfFieldEnabled(bool enabled)
		{
		}

		public void SetSSAOEnabled(bool enabled)
		{
		}

		public void SetMotionBlurEnabled(bool enabled)
		{
		}

		public void SetMotionBlurIntensity(float intensity)
		{
		}

		public void SetExposureCompensation(float ev)
		{
		}

		private void ApplyRenderSettings(GraphicsPreset preset)
		{
		}

		private void ApplyFogSettings(GraphicsPreset preset)
		{
		}

		private void LerpRenderSettings(GraphicsPreset from, GraphicsPreset to, float t)
		{
		}

		private void LerpFogSettings(GraphicsPreset from, GraphicsPreset to, float t)
		{
		}

		private void ApplyLensFlare(GraphicsPreset preset)
		{
		}

		private void EnsureGlobalVolume()
		{
		}

		private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
		}

		private void CreateRuntimeProfile()
		{
		}

		private void InitializeQualityTiers()
		{
		}

		private void ApplyDisplaySettings(GraphicsPreset preset)
		{
		}

		private void ApplyQualitySettings(GraphicsPreset preset)
		{
		}

		private void ApplyShadowSettings(GraphicsPreset preset)
		{
		}

		private void ApplyURPAssetSettings(GraphicsPreset preset)
		{
		}

		private Camera GetLocalCamera()
		{
			return null;
		}

		private void ApplyCameraSettings(GraphicsPreset preset)
		{
		}

		private void ApplyPerformanceSettings(GraphicsPreset preset)
		{
		}

		public void SetResolution(int width, int height, FullScreenMode mode, int refreshRate = 0)
		{
		}

		private static RefreshRate ToRefreshRate(int refreshRate)
		{
			return default(RefreshRate);
		}

		public void SetVSync(int count)
		{
		}

		public void SetTargetFrameRate(int fps)
		{
		}

		public void SetAnisotropicFiltering(AnisotropicFiltering mode)
		{
		}

		public void SetTextureQuality(int quality)
		{
		}

		public void SetLODBias(float bias)
		{
		}

		public void SetShadowDistance(float distance)
		{
		}

		public void SetShadowCascades(int cascades)
		{
		}

		public void SetSoftShadows(bool enabled)
		{
		}

		public void SetFieldOfView(float fov)
		{
		}

		public void SetOcclusionCulling(bool enabled)
		{
		}

		public void SetBrightness(float brightness)
		{
		}

		public void ApplyShadowQualityOverride(int level)
		{
		}

		public void ApplyAntiAliasingOverride(int mode)
		{
		}

		public void ApplyRenderScaleOverride(float scale)
		{
		}

		public void ApplySSAOOverride(int mode)
		{
		}

		private ScriptableRendererFeature FindSSAOFeature()
		{
			return null;
		}

		public void ApplySSAORuntimeToggle(bool enabled)
		{
		}

		public void ApplyBloomOverride(int mode)
		{
		}

		public void ApplyDepthOfFieldOverride(int mode)
		{
		}

		public void ApplyMotionBlurOverride(int mode)
		{
		}

		public void ApplyFilmGrainOverride(int mode)
		{
		}

		public void ApplyVignetteOverride(int mode)
		{
		}

		public void ApplyChromaticAberrationOverride(int mode)
		{
		}

		public void SetGamma(float gamma)
		{
		}

		public void SetShadowLift(float lift)
		{
		}

		private float EaseInOutCubic(float t)
		{
			return 0f;
		}

		[ContextMenu("Presets/Apply Cinematic (ACES)")]
		private void ApplyPresetCinematic()
		{
		}

		[ContextMenu("Presets/Apply Realistic Neutral")]
		private void ApplyPresetRealistic()
		{
		}

		[ContextMenu("Presets/Apply Vibrant Stylized")]
		private void ApplyPresetVibrant()
		{
		}

		[ContextMenu("Presets/Apply Moody Horror")]
		private void ApplyPresetMoody()
		{
		}

		[ContextMenu("Presets/Apply Toon/Low-Poly")]
		private void ApplyPresetToon()
		{
		}

		[ContextMenu("Presets/Apply Performance/Esports")]
		private void ApplyPresetPerformance()
		{
		}

		[ContextMenu("Quality/Re-apply Current Quality")]
		private void ReapplyCurrentQuality()
		{
		}

		[ContextMenu("Quality/Apply Low")]
		private void ApplyQualityLow()
		{
		}

		[ContextMenu("Quality/Apply Medium")]
		private void ApplyQualityMedium()
		{
		}

		[ContextMenu("Quality/Apply High")]
		private void ApplyQualityHigh()
		{
		}

		[ContextMenu("Quality/Apply Ultra")]
		private void ApplyQualityUltra()
		{
		}

		[ContextMenu("Quality/Apply Cinematic")]
		private void ApplyQualityCinematic()
		{
		}
	}
}
