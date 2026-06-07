using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace OffroadExplorer.Lobby
{
	public class LobbyCameraController : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CDelayedIntroStart_003Ed__82 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LobbyCameraController _003C_003E4__this;

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
			public _003CDelayedIntroStart_003Ed__82(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CIntroSequenceCoroutine_003Ed__83 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LobbyCameraController _003C_003E4__this;

			public Action onComplete;

			private Vector3 _003CstartPos_003E5__2;

			private Quaternion _003CstartRot_003E5__3;

			private Vector3 _003CendPosition_003E5__4;

			private Quaternion _003CendRotation_003E5__5;

			private float _003CstartTime_003E5__6;

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
			public _003CIntroSequenceCoroutine_003Ed__83(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CTransitionCoroutine_003Ed__84 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LobbyCameraController _003C_003E4__this;

			public Vector3 targetPos;

			public Quaternion targetRot;

			private Vector3 _003CstartPos_003E5__2;

			private Quaternion _003CstartRot_003E5__3;

			private float _003CstartTime_003E5__4;

			private float _003CendTime_003E5__5;

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
			public _003CTransitionCoroutine_003Ed__84(int _003C_003E1__state)
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

		[Header("Camera Reference")]
		[Tooltip("The camera to control. If not set, will use Camera.main")]
		[SerializeField]
		private Camera targetCamera;

		[Header("═══ INTRO SEQUENCE ═══")]
		[Tooltip("Starting position for the intro camera sweep")]
		[SerializeField]
		private Transform introStartPosition;

		[Tooltip("End position for intro (if null, uses Main Menu position)")]
		[SerializeField]
		private Transform introEndPosition;

		[Tooltip("Duration of the intro camera movement in seconds")]
		[SerializeField]
		private float introDuration;

		[Tooltip("Easing curve for the intro animation")]
		[SerializeField]
		private AnimationCurve introEaseCurve;

		[Tooltip("Whether to play intro automatically on scene load")]
		[SerializeField]
		private bool playIntroOnStart;

		[Tooltip("Delay before starting intro (for scene loading)")]
		[SerializeField]
		private float introStartDelay;

		[Header("═══ SCREEN POSITIONS ═══")]
		[Tooltip("Camera position for Main Menu screen")]
		[SerializeField]
		private Transform mainMenuPosition;

		[Tooltip("Camera position for Host Settings screen")]
		[SerializeField]
		private Transform hostSettingsPosition;

		[Tooltip("Camera position for Join Lobby screen")]
		[SerializeField]
		private Transform joinLobbyPosition;

		[Tooltip("Camera position for Lobby Room screen")]
		[SerializeField]
		private Transform lobbyRoomPosition;

		[Tooltip("Camera position for Save Selection screen")]
		[SerializeField]
		private Transform saveSelectionPosition;

		[Tooltip("Camera position for Profile screen")]
		[SerializeField]
		private Transform profilePosition;

		[Header("═══ TRANSITION SETTINGS ═══")]
		[Tooltip("Duration of screen-to-screen transitions")]
		[SerializeField]
		private float transitionDuration;

		[Tooltip("Easing curve for transitions")]
		[SerializeField]
		private AnimationCurve transitionEaseCurve;

		[Tooltip("Use spherical interpolation for rotation (smoother arcs)")]
		[SerializeField]
		private bool useSlerpRotation;

		[Header("═══ MOTION BLUR ═══")]
		[Tooltip("URP Post Processing Volume (must have Motion Blur override)")]
		[SerializeField]
		private Volume postProcessVolume;

		[Tooltip("Motion blur intensity during camera transitions")]
		[Range(0f, 1f)]
		[SerializeField]
		private float motionBlurIntensityDuringTransition;

		[Tooltip("Motion blur intensity during intro sequence")]
		[Range(0f, 1f)]
		[SerializeField]
		private float motionBlurIntensityDuringIntro;

		[Tooltip("How fast motion blur fades in/out")]
		[SerializeField]
		private float motionBlurFadeSpeed;

		[Header("═══ DEPTH OF FIELD (Optional) ═══")]
		[Tooltip("Enable depth of field effect")]
		[SerializeField]
		private bool useDepthOfField;

		[Tooltip("Focus distance for depth of field")]
		[SerializeField]
		private float dofFocusDistance;

		[Tooltip("Aperture (lower = more blur)")]
		[Range(1f, 32f)]
		[SerializeField]
		private float dofAperture;

		[Header("═══ CHROMATIC ABERRATION ═══")]
		[Tooltip("Enable chromatic aberration during transitions")]
		[SerializeField]
		private bool useChromaticAberration;

		[Tooltip("Chromatic aberration intensity during transitions")]
		[Range(0f, 1f)]
		[SerializeField]
		private float chromaticAberrationIntensity;

		[Header("═══ VIGNETTE ═══")]
		[Tooltip("Enable vignette effect during transitions")]
		[SerializeField]
		private bool useVignette;

		[Tooltip("Base vignette intensity (always on)")]
		[Range(0f, 1f)]
		[SerializeField]
		private float baseVignetteIntensity;

		[Tooltip("Additional vignette intensity during transitions")]
		[Range(0f, 1f)]
		[SerializeField]
		private float transitionVignetteIntensity;

		[Header("═══ FILM GRAIN ═══")]
		[Tooltip("Enable film grain effect")]
		[SerializeField]
		private bool useFilmGrain;

		[Tooltip("Film grain intensity")]
		[Range(0f, 1f)]
		[SerializeField]
		private float filmGrainIntensity;

		[Header("═══ BLOOM ═══")]
		[Tooltip("Enable bloom intensity variation during transitions")]
		[SerializeField]
		private bool useBloomPulse;

		[Tooltip("Base bloom intensity")]
		[SerializeField]
		private float baseBloomIntensity;

		[Tooltip("Additional bloom during transitions")]
		[SerializeField]
		private float transitionBloomBoost;

		[Header("═══ ADVANCED ═══")]
		[Tooltip("Enable camera shake during transitions")]
		[SerializeField]
		private bool enableCameraShake;

		[Tooltip("Camera shake intensity")]
		[SerializeField]
		private float shakeIntensity;

		[Tooltip("Field of view change during transitions (0 = disabled)")]
		[SerializeField]
		private float fovPunchAmount;

		[Tooltip("FOV punch during intro (separate from transitions)")]
		[SerializeField]
		private float introFovPunchAmount;

		[Tooltip("Overall effect smoothing speed")]
		[SerializeField]
		private float effectFadeSpeed;

		private bool _introPlayed;

		private bool _isTransitioning;

		private Coroutine _currentTransition;

		private MotionBlur _motionBlur;

		private DepthOfField _depthOfField;

		private ChromaticAberration _chromaticAberration;

		private Vignette _vignette;

		private FilmGrain _filmGrain;

		private Bloom _bloom;

		private float _targetMotionBlurIntensity;

		private float _targetChromaticAberration;

		private float _targetVignetteIntensity;

		private float _targetBloomIntensity;

		private float _currentMotionBlurIntensity;

		private float _currentChromaticAberration;

		private float _currentVignetteIntensity;

		private float _currentBloomIntensity;

		private float _baseFov;

		private Dictionary<string, Transform> _screenPositions;

		public static LobbyCameraController Instance { get; private set; }

		public bool IsTransitioning => false;

		public bool IntroPlayed => false;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void OnDestroy()
		{
		}

		private void InitializeScreenPositions()
		{
		}

		private void InitializePostProcessing()
		{
		}

		private void UpdatePostProcessingEffects()
		{
		}

		private void EnableTransitionEffects()
		{
		}

		private void DisableTransitionEffects()
		{
		}

		private void EnableIntroEffects()
		{
		}

		public void PlayIntroSequence(Action onComplete = null)
		{
		}

		public void MoveToScreen(string screenName, bool instant = false)
		{
		}

		public void TransitionTo(Transform target)
		{
		}

		public void TransitionTo(Vector3 position, Quaternion rotation)
		{
		}

		public void SetCameraTransform(Transform target)
		{
		}

		public void SkipIntro()
		{
		}

		public void ResetIntro()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedIntroStart_003Ed__82))]
		private IEnumerator DelayedIntroStart()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CIntroSequenceCoroutine_003Ed__83))]
		private IEnumerator IntroSequenceCoroutine(Action onComplete)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CTransitionCoroutine_003Ed__84))]
		private IEnumerator TransitionCoroutine(Vector3 targetPos, Quaternion targetRot)
		{
			return null;
		}

		private void StopCurrentTransition()
		{
		}
	}
}
