using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public class CameraManager : SingletonMonoBehaviour<CameraManager>
	{
		public const string CAMERA_TRANSITION_SKIP = "SkipTransition";

		public const string CAMERA_TRANSITION_IN = "InTransition";

		public const string CAMERA_TRANSITION_OUT = "OutTransition";

		public const string TRANSITION_EVENT_IN_FINISHED = "enteringTransitionFinished";

		public const string TRANSITION_EVENT_OUT_FINISHED = "leavingTransitionFinished";

		private Dictionary<string, CameraTransformData> _cameraTransforms;

		private CameraRigBase _activeCamera;

		[SerializeField]
		private float _worldMapFogFadeInTime;

		[SerializeField]
		private float _tavernFogFadeInTime;

		[SerializeField]
		private float _worldMapFogFadeOutTime;

		[SerializeField]
		private float _tavernFogFadeOutTime;

		private Action _transitionCallback;

		private const string CAMERA_CONTROLS_STORYKEY = "CameraControlMode";

		public CameraRigBase ActiveCamera
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		[field: SerializeField]
		public StandardCameraRig TavernCamera { get; private set; }

		[field: SerializeField]
		public FreeCameraRig TavernFreeCamera { get; private set; }

		[field: SerializeField]
		public StandardCameraRig WorldMapCamera { get; private set; }

		[field: SerializeField]
		public FreeCameraRig WorldMapFreeCamera { get; private set; }

		[field: SerializeField]
		public SpriteRendererTransition Fog { get; private set; }

		public bool IsTransitioning { get; private set; }

		public bool ShowFreeCamOrbitVisual => false;

		private static event EventHandler CameraTransitionInFinished
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

		private static event EventHandler CameraTransitionOutFinished
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

		public static event EventHandler BeforeActiveCameraChanged
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

		public static event EventHandler ActiveCameraChanged
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

		public static string CreateCameraPresetKey(int presetIndex)
		{
			return null;
		}

		public static CameraRigBase GetActiveCamera()
		{
			return null;
		}

		public static void EnsureCorrectCamera(bool useFreeCam, bool useTavernCamera = true)
		{
		}

		public void ClearCache()
		{
		}

		public override void Awake()
		{
		}

		private void OnDisableFreeCameraMovementParticlesChanged(object sender, EventArgs e)
		{
		}

		private void OnResetUI(object sender, EventArgs e)
		{
		}

		private void OnAnimEvent(object sender, AnimationEventArgs e)
		{
		}

		public void SetTransformData(string id, CameraTransformData cameraTransformData)
		{
		}

		public CameraTransformData GetTransformData(string id)
		{
			return null;
		}

		private void OnActiveCameraChanged()
		{
		}

		public void EnableWorldMapCamera(Action onCompleteCallback, bool skipTransition)
		{
		}

		public void EnableTavernCamera(Action onCompleteCallback, bool skipTransition)
		{
		}

		public void UpdateRotationTargetVisualState()
		{
		}

		public void EnableCamera(CameraRigBase cameraRig, Action onCameraSwitchedCallback, bool skipTransition)
		{
		}

		public void TransitionIn(Action transitionCallback)
		{
		}

		private void OnTransitionInFinished(object sender, EventArgs eventArgs)
		{
		}

		public void TransitionOut(Action transitionCallback)
		{
		}

		private void OnTransitionOutFinished(object sender, EventArgs eventArgs)
		{
		}

		private void OnTransitionFinished()
		{
		}

		public void ToggleFreeCam()
		{
		}

		public void EnableFreeCamera(bool skipTransition = false)
		{
		}

		public void EnableFreeCamera(FreeCameraRig freeCameraRig, bool skipTransition = false, bool resetPosition = true, bool resetFOV = true)
		{
		}

		public void DisableFreeCam(bool skipTransition = false)
		{
		}

		public bool IsTavernCameraActive()
		{
			return false;
		}

		public bool IsFreeCameraActive()
		{
			return false;
		}

		public void SetAudioListeners(bool enabled)
		{
		}

		public void SetAllCameraControlModes(CameraRigBase.ControlMode controlMode, bool isStoryDriven = false)
		{
		}

		public void SetCinematicLock(bool isLocked, bool isStoryDriven = true, bool skipTransition = false)
		{
		}

		public void SetFollowTarget(Transform transformRoot, float heightOffset = 0f)
		{
		}
	}
}
