using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Synty.AnimationBaseLocomotion.Samples;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace MyStuff.Sleep
{
	public class SleepCameraController : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CFadeMelodyCoroutine_003Ed__79 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float duration;

			public SleepCameraController _003C_003E4__this;

			public float fromVolume;

			public float toVolume;

			public bool stopOnComplete;

			private float _003CstartTime_003E5__2;

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
			public _003CFadeMelodyCoroutine_003Ed__79(int _003C_003E1__state)
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
		private sealed class _003CQuickRestoreCamera_003Ed__73 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SleepCameraController _003C_003E4__this;

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
			public _003CQuickRestoreCamera_003Ed__73(int _003C_003E1__state)
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
		private sealed class _003CReturnCameraCoroutine_003Ed__72 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SleepCameraController _003C_003E4__this;

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
			public _003CReturnCameraCoroutine_003Ed__72(int _003C_003E1__state)
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
		private sealed class _003CSleepCameraSequenceCoroutine_003Ed__68 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SleepCameraController _003C_003E4__this;

			public Transform windowExit;

			public Transform skyView;

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
			public _003CSleepCameraSequenceCoroutine_003Ed__68(int _003C_003E1__state)
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
		private sealed class _003CTransitionRig_003Ed__74 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float duration;

			public SleepCameraController _003C_003E4__this;

			public Vector3 fromPos;

			public Vector3 toPos;

			public Quaternion fromRot;

			public Quaternion toRot;

			private float _003CstartTime_003E5__2;

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
			public _003CTransitionRig_003Ed__74(int _003C_003E1__state)
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
		private sealed class _003CTransitionRigThroughPath_003Ed__69 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SleepCameraController _003C_003E4__this;

			public Vector3 middlePos;

			public Vector3 startPos;

			public Vector3 endPos;

			public float totalDuration;

			public Quaternion startRot;

			public Quaternion endRot;

			private Vector3 _003CcontrolPoint_003E5__2;

			private float _003CstartTime_003E5__3;

			private float _003CpreviousFrameTime_003E5__4;

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
			public _003CTransitionRigThroughPath_003Ed__69(int _003C_003E1__state)
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
		private sealed class _003CTransitionRigThroughPathWithLookAt_003Ed__70 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Vector3 startPos;

			public Vector3 middlePos;

			public Vector3 endPos;

			public SleepCameraController _003C_003E4__this;

			public Quaternion startRot;

			public float totalDuration;

			public Quaternion endRot;

			private Vector3 _003CpBefore_003E5__2;

			private Vector3 _003CpAfter_003E5__3;

			private float _003Ct_mid_003E5__4;

			private Quaternion _003ClookAtWindowRot_003E5__5;

			private float _003CstartTime_003E5__6;

			private float _003CpreviousFrameTime_003E5__7;

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
			public _003CTransitionRigThroughPathWithLookAt_003Ed__70(int _003C_003E1__state)
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
		private sealed class _003CWaitForNetworkSpawnThenInitialize_003Ed__55 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public NetworkObject networkObject;

			public SleepCameraController _003C_003E4__this;

			private float _003Ctimeout_003E5__2;

			private float _003Celapsed_003E5__3;

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
			public _003CWaitForNetworkSpawnThenInitialize_003Ed__55(int _003C_003E1__state)
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

		[Header("Transition Settings")]
		[Tooltip("Total duration for camera to travel from player through window to sky view")]
		[SerializeField]
		private float outwardJourneyDuration;

		[Tooltip("Duration of camera return to player")]
		[SerializeField]
		private float returnDuration;

		[Tooltip("Animation curve for camera transitions (eases in/out)")]
		[SerializeField]
		private AnimationCurve transitionCurve;

		[Tooltip("Where along the path the window point is (0-1). 0.4 = 40% of the way")]
		[Range(0.2f, 0.8f)]
		[SerializeField]
		private float windowPointRatio;

		[Header("Sleep Melody")]
		[Tooltip("Subtle background melody that plays during sleep sequence")]
		[SerializeField]
		private AudioClip sleepMelody;

		[Tooltip("Volume for the sleep melody (keep very low for subtlety)")]
		[Range(0f, 0.5f)]
		[SerializeField]
		private float melodyVolume;

		[Tooltip("Fade in duration for the melody")]
		[SerializeField]
		private float melodyFadeInDuration;

		[Tooltip("Fade out duration for the melody")]
		[SerializeField]
		private float melodyFadeOutDuration;

		[Header("═══ CINEMATIC EFFECTS ═══")]
		[Tooltip("Enable cinematic post-processing effects during sleep")]
		[SerializeField]
		private bool enableCinematicEffects;

		[Header("Vignette")]
		[Tooltip("Vignette intensity during sleep (dreamy tunnel vision)")]
		[Range(0f, 0.6f)]
		[SerializeField]
		private float sleepVignetteIntensity;

		[Tooltip("Vignette smoothness")]
		[Range(0.1f, 1f)]
		[SerializeField]
		private float vignetteSmoothness;

		[Header("Chromatic Aberration")]
		[Tooltip("Chromatic aberration during camera transitions")]
		[Range(0f, 0.5f)]
		[SerializeField]
		private float chromaticAberrationIntensity;

		[Header("Field of View")]
		[Tooltip("FOV change during transitions (0.05 = 5% zoom effect)")]
		[Range(0f, 0.15f)]
		[SerializeField]
		private float fovPunchAmount;

		[Header("Motion Blur")]
		[Tooltip("Enable motion blur during camera movement")]
		[SerializeField]
		private bool useMotionBlur;

		[Tooltip("Motion blur intensity during transitions")]
		[Range(0f, 1f)]
		[SerializeField]
		private float motionBlurIntensity;

		[Header("Effect Timing")]
		[Tooltip("How fast effects fade in/out")]
		[SerializeField]
		private float effectFadeSpeed;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private AudioSource melodySource;

		private Volume sleepVolume;

		private VolumeProfile sleepVolumeProfile;

		private Vignette sleepVignette;

		private ChromaticAberration sleepChromaticAberration;

		private MotionBlur sleepMotionBlur;

		private float currentVignetteIntensity;

		private float currentChromaticAberration;

		private float currentMotionBlur;

		private float targetVignetteIntensity;

		private float targetChromaticAberration;

		private float targetMotionBlur;

		private float originalFov;

		private SampleCameraController cameraController;

		private Transform actualCameraTransform;

		private Transform cameraRig;

		private bool wasCameraControllerEnabled;

		private Vector3 originalCameraWorldPosition;

		private Quaternion originalCameraWorldRotation;

		private Vector3 originalCameraLocalPosition;

		private Quaternion originalCameraLocalRotation;

		private Transform originalRigParent;

		private Vector3 originalRigLocalPosition;

		private Quaternion originalRigLocalRotation;

		private bool isCameraUnparented;

		private Coroutine sequenceCoroutine;

		private bool isSequenceActive;

		private Vector3 windowPosition;

		private Quaternion windowRotation;

		private Coroutine melodyFadeCoroutine;

		public static SleepCameraController Instance { get; private set; }

		private void Awake()
		{
		}

		private void CreateMelodySource()
		{
		}

		private void CreateSleepVolume()
		{
		}

		private void CleanupSleepVolume()
		{
		}

		private void Start()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitForNetworkSpawnThenInitialize_003Ed__55))]
		private IEnumerator WaitForNetworkSpawnThenInitialize(NetworkObject networkObject)
		{
			return null;
		}

		private void StoreOriginalFov()
		{
		}

		private void ResetStateOnLoad()
		{
		}

		private void InitializeCameraReferences()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnDisable()
		{
		}

		private bool PrepareForTransition()
		{
			return false;
		}

		private bool RestoreCamera()
		{
			return false;
		}

		private bool RestoreCameraExact()
		{
			return false;
		}

		private void ForceImmediateRestore()
		{
		}

		public void StartSleepSequence(Transform windowExit, Transform skyView)
		{
		}

		public void EndSleepSequence()
		{
		}

		public void AbortSequence()
		{
		}

		[IteratorStateMachine(typeof(_003CSleepCameraSequenceCoroutine_003Ed__68))]
		private IEnumerator SleepCameraSequenceCoroutine(Transform windowExit, Transform skyView)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CTransitionRigThroughPath_003Ed__69))]
		private IEnumerator TransitionRigThroughPath(Vector3 startPos, Quaternion startRot, Vector3 middlePos, Quaternion middleRot, Vector3 endPos, Quaternion endRot, float totalDuration)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CTransitionRigThroughPathWithLookAt_003Ed__70))]
		private IEnumerator TransitionRigThroughPathWithLookAt(Vector3 startPos, Quaternion startRot, Vector3 middlePos, Vector3 endPos, Quaternion endRot, float totalDuration)
		{
			return null;
		}

		private Vector3 CatmullRom(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
		{
			return default(Vector3);
		}

		[IteratorStateMachine(typeof(_003CReturnCameraCoroutine_003Ed__72))]
		private IEnumerator ReturnCameraCoroutine()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CQuickRestoreCamera_003Ed__73))]
		private IEnumerator QuickRestoreCamera()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CTransitionRig_003Ed__74))]
		private IEnumerator TransitionRig(Vector3 fromPos, Quaternion fromRot, Vector3 toPos, Quaternion toRot, float duration)
		{
			return null;
		}

		private bool IsLocalPlayer()
		{
			return false;
		}

		private void StartSleepMelody()
		{
		}

		private void StopSleepMelody()
		{
		}

		[IteratorStateMachine(typeof(_003CFadeMelodyCoroutine_003Ed__79))]
		private IEnumerator FadeMelodyCoroutine(float fromVolume, float toVolume, float duration, bool stopOnComplete = false)
		{
			return null;
		}

		private void ForceStopMelody()
		{
		}

		private void EnableSleepEffects()
		{
		}

		private void DisableSleepEffects()
		{
		}

		private void ForceResetEffects()
		{
		}

		private void UpdateSleepEffects(float realtimeDelta)
		{
		}

		private void ApplyFovPunch(float t)
		{
		}

		private void ResetFov()
		{
		}
	}
}
