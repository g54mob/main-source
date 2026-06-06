using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MyStuff.Environment;
using UnityEngine;

namespace MyStuff.Graphics
{
	[DefaultExecutionOrder(-440)]
	public sealed class SkyboxDriver : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CBlendPresetRoutine_003Ed__67 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SkyboxDriver _003C_003E4__this;

			public SkyboxPreset targetPreset;

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
			public _003CBlendPresetRoutine_003Ed__67(int _003C_003E1__state)
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
		[Tooltip("Stylized/Sky material (skybox)")]
		[SerializeField]
		private Material stylizedSkyMaterial;

		[Tooltip("Skybox preset library")]
		[SerializeField]
		private SkyboxLibrary library;

		[Tooltip("Default preset to apply on startup")]
		[SerializeField]
		private SkyboxPreset defaultPreset;

		[Header("=== Update Settings ===")]
		[Tooltip("Update rate in Hz (5-10 recommended to prevent flickering)")]
		[Range(1f, 60f)]
		[SerializeField]
		private float updateRateHz;

		[Tooltip("Clamp sun disc multiplier range")]
		[SerializeField]
		private Vector2 sunMultiplierClamp;

		[Tooltip("Clamp sun disc exponent range")]
		[SerializeField]
		private Vector2 sunExponentClamp;

		[Header("=== Time-of-Day Binding ===")]
		[Tooltip("Auto-bind to TimeOfDayManager on startup")]
		[SerializeField]
		private bool autoBindToTimeOfDay;

		[Tooltip("Manual time override for cutscenes/testing")]
		[SerializeField]
		private bool useManualTimeOverride;

		[Tooltip("Manual normalized time (0-1) when override is enabled")]
		[Range(0f, 1f)]
		[SerializeField]
		private float manualTimeOverride;

		[Header("=== Debug ===")]
		[Tooltip("Show debug logs")]
		[SerializeField]
		private bool showDebugLogs;

		private TimeOfDayManager _timeOfDayManager;

		private SkyboxPreset _activePreset;

		private float _lastUpdateTime;

		private float _updateInterval;

		private float _previousNormalizedTime;

		private Coroutine _blendCoroutine;

		private SkyboxPreset _blendFrom;

		private SkyboxPreset _blendTo;

		private bool _isBlending;

		private static readonly int _SunDiscColor;

		private static readonly int _SunDiscMultiplier;

		private static readonly int _SunDiscExponent;

		private static readonly int _SunHaloColor;

		private static readonly int _SunHaloExponent;

		private static readonly int _SunHaloContribution;

		private static readonly int _HorizonLineColor;

		private static readonly int _HorizonLineExponent;

		private static readonly int _HorizonLineContribution;

		private static readonly int _SkyGradientTop;

		private static readonly int _SkyGradientBottom;

		private static readonly int _SkyGradientExponent;

		private static readonly int _Exposure;

		public static SkyboxDriver Instance { get; private set; }

		public static bool IsControllingAtmosphere { get; private set; }

		public static bool IsFogPaused { get; set; }

		public static bool IsDoFPaused { get; set; }

		public SkyboxPreset ActivePreset => null;

		public Material SkyboxMaterial => null;

		public SkyboxLibrary Library => null;

		public float CurrentNormalizedTime => 0f;

		public event Action<SkyboxPreset> OnPresetApplied
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

		private void Update()
		{
		}

		private void OnDestroy()
		{
		}

		public void BindToTimeOfDay()
		{
		}

		public void Unbind()
		{
		}

		public void ApplyPreset(SkyboxPreset preset, float blendSeconds = 0f)
		{
		}

		public void ApplyPresetByName(string presetName, float blendSeconds = 0f)
		{
		}

		public void BlendPresetsManual(SkyboxPreset a, SkyboxPreset b, float t01, float blendFactor)
		{
		}

		[IteratorStateMachine(typeof(_003CBlendPresetRoutine_003Ed__67))]
		private IEnumerator BlendPresetRoutine(SkyboxPreset targetPreset, float duration)
		{
			return null;
		}

		private void ApplyStateToRendering(SkyboxState state)
		{
		}

		private void ApplyAmbientAndFog(SkyboxState state)
		{
		}

		private void ApplyAmbientWithMinBrightness(SkyboxState state)
		{
		}

		private Color EnforceMinBrightness(Color color, float minBrightness, Color nightTint)
		{
			return default(Color);
		}

		private void ApplyTimeBasedBloom(SkyboxState state)
		{
		}

		private void ApplyTimeBasedDOF(SkyboxState state)
		{
		}

		private float CalculateExposureFromTime(float normalizedTime)
		{
			return 0f;
		}

		public void SetManualTimeOverride(bool enabled)
		{
		}

		public void SetManualTime(float normalizedTime)
		{
		}

		private void ResolveAtmosphereConflict()
		{
		}

		public void ManuallyResolveAtmosphereConflict()
		{
		}

		public void EnsureSunLight()
		{
		}

		public void ForceUpdate()
		{
		}
	}
}
