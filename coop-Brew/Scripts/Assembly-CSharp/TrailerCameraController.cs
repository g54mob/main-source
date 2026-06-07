using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BrewGame.Player;
using MyStuff.Player;
using Synty.AnimationBaseLocomotion.Samples;
using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class TrailerCameraController : NetworkBehaviour
{
	public enum CameraMode
	{
		FreeFly = 0,
		Follow = 1,
		Orbit = 2
	}

	public enum SmoothingLevel
	{
		Responsive = 0,
		Smooth = 1,
		Cinematic = 2
	}

	public enum LifecycleState
	{
		Inactive = 0,
		Entering = 1,
		Active = 2,
		Exiting = 3
	}

	[CompilerGenerated]
	private sealed class _003CPeriodicUIDocSweep_003Ed__164 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TrailerCameraController _003C_003E4__this;

		private WaitForSeconds _003Cwait_003E5__2;

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
		public _003CPeriodicUIDocSweep_003Ed__164(int _003C_003E1__state)
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
	private sealed class _003CVerifyEnterAfterFrame_003Ed__156 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TrailerCameraController _003C_003E4__this;

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
		public _003CVerifyEnterAfterFrame_003Ed__156(int _003C_003E1__state)
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

	private NetworkVariable<bool> _isInCameraMode;

	private static bool _secretUnlocked;

	private CameraMode _currentMode;

	private bool _horizontalLock;

	private bool _invertPan;

	private Vector3 _startPosition;

	private float _startYaw;

	private float _startPitch;

	private InputReader _inputReader;

	private CharacterController _characterController;

	private SampleCameraController _cameraController;

	private SamplePlayerAnimationController _animController;

	private Camera _camera;

	private Renderer[] _playerRenderers;

	private PlayerBoundsRecovery _boundsRecovery;

	private StuckRecoveryController _stuckRecovery;

	private PlayerFallDamageController _fallDamage;

	private PlayerVehicleStateGuard _vehicleStateGuard;

	private Vector3 _frozenPlayerPosition;

	[Header("Raycast Targeting")]
	[Tooltip("Layers the raycast can hit for Follow/Orbit targeting")]
	[SerializeField]
	private LayerMask _targetLayerMask;

	private float _normalSpeed;

	private float _fastSpeed;

	private float _slowSpeed;

	private float _currentSpeed;

	private Vector3 _smoothVelocity;

	private float _smoothTime;

	private Vector3 _currentVelocity;

	private float _yaw;

	private float _pitch;

	private float _targetYaw;

	private float _targetPitch;

	private float _rotSmoothTime;

	private float _yawVelocity;

	private SmoothingLevel _smoothingLevel;

	private float _autoPanSpeed;

	private float _pitchVelocity;

	private float _mouseSensitivity;

	private float _currentFov;

	private float _targetFov;

	private float _fovVelocity;

	private float _minFov;

	private float _maxFov;

	private Volume _ppVolume;

	private VolumeProfile _ppProfile;

	private DepthOfField _dof;

	private Vignette _vignette;

	private MotionBlur _motionBlur;

	private bool _dofEnabled;

	private bool _vignetteEnabled;

	private bool _motionBlurEnabled;

	private float _dofStart;

	private float _dofEnd;

	private float _vignetteIntensity;

	private Transform _targetTransform;

	private string _targetName;

	private Vector3 _followOffset;

	private float _followSmoothTime;

	private Vector3 _followVelocity;

	private float _orbitRadius;

	private float _orbitSpeed;

	private float _orbitAngle;

	private float _orbitHeight;

	private TrailerCamUI _ui;

	private LifecycleState _state;

	private bool _ownerInitialized;

	private bool _remoteHidden;

	private float _lastToggleTime;

	private const float TOGGLE_DEBOUNCE = 0.2f;

	private GameObject _flyRoot;

	private Transform _flyTransform;

	private Camera _flyCamera;

	private AudioListener _flyAudioListener;

	private Camera _playerMainCameraRef;

	private AudioListener _playerAudioListenerRef;

	private List<(UIDocument doc, DisplayStyle prevStyle)> _hiddenUIDocs;

	private Coroutine _uiDocSweepCo;

	public static bool IsAnyActive { get; private set; }

	public bool IsActive => false;

	public CameraMode CurrentMode => default(CameraMode);

	public float CurrentFov => 0f;

	public float CurrentSpeed => 0f;

	public string TargetName => null;

	public bool DofEnabled => false;

	public float DofStart => 0f;

	public float DofEnd => 0f;

	public bool VignetteEnabled => false;

	public float VignetteIntensity => 0f;

	public bool MotionBlurEnabled => false;

	public bool HorizontalLock => false;

	public bool InvertPan => false;

	public SmoothingLevel Smoothing => default(SmoothingLevel);

	public LayerMask TargetLayerMask
	{
		get
		{
			return default(LayerMask);
		}
		set
		{
		}
	}

	public static event Action<bool> OnAnyActiveChanged
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

	public static void SetSecretUnlocked(bool unlocked)
	{
	}

	private void Update()
	{
	}

	private void UpdateFreeFly()
	{
	}

	private void UpdateFollow()
	{
	}

	private void UpdateOrbit()
	{
	}

	private void HandleModeSwitch()
	{
	}

	private bool RaycastForTarget()
	{
		return false;
	}

	private void CreatePostProcessingVolume()
	{
	}

	private void DestroyPostProcessingVolume()
	{
	}

	private void HandlePostProcessingInput()
	{
	}

	private void HandleFovInput()
	{
	}

	private void UpdateFov()
	{
	}

	private Vector3 GetMovementInput()
	{
		return default(Vector3);
	}

	private float GetMovementSpeed()
	{
		return 0f;
	}

	private void CacheReferences()
	{
	}

	private void CacheRenderers()
	{
	}

	private void SetPlayerRenderersVisible(bool visible)
	{
	}

	private void RecaptureRotation()
	{
	}

	public void RequestAddHours(float hours)
	{
	}

	public void RequestSetTimeClock(int hours, int minutes)
	{
	}

	public void RequestPauseTime()
	{
	}

	public void RequestResumeTime()
	{
	}

	[ServerRpc]
	private void AddHoursServerRpc(float hours)
	{
	}

	[ServerRpc]
	private void SetTimeClockServerRpc(int hours, int minutes)
	{
	}

	[ServerRpc]
	private void PauseTimeServerRpc()
	{
	}

	[ServerRpc]
	private void ResumeTimeServerRpc()
	{
	}

	private void GetSmoothingParams(out float rotSmooth, out float moveSmooth, out float sensitivity)
	{
		rotSmooth = default(float);
		moveSmooth = default(float);
		sensitivity = default(float);
	}

	public void Initialize()
	{
	}

	public override void OnNetworkSpawn()
	{
	}

	public override void OnNetworkDespawn()
	{
	}

	private void OnDisable()
	{
	}

	public override void OnDestroy()
	{
	}

	private void OnSceneUnloaded(Scene s)
	{
	}

	private void OnTrailerCamToggled()
	{
	}

	private void BeginEnter()
	{
	}

	private void DoEnterSteps()
	{
	}

	private void BeginExit()
	{
	}

	private void DoExitSteps()
	{
	}

	private void ForceExitNow()
	{
	}

	[IteratorStateMachine(typeof(_003CVerifyEnterAfterFrame_003Ed__156))]
	private IEnumerator VerifyEnterAfterFrame()
	{
		return null;
	}

	private void SpawnFlyRig(Vector3 pos, Quaternion rot)
	{
	}

	private void DestroyFlyRig()
	{
	}

	private void SetPlayerSystemsEnabled(bool enabled)
	{
	}

	private void ApplyRemoteHide(bool hidden)
	{
	}

	private void OnCameraModeChanged(bool prev, bool current)
	{
	}

	private void DisableAllUIDocuments()
	{
	}

	private void RestoreAllUIDocuments()
	{
	}

	[IteratorStateMachine(typeof(_003CPeriodicUIDocSweep_003Ed__164))]
	private IEnumerator PeriodicUIDocSweep()
	{
		return null;
	}

	protected override void __initializeVariables()
	{
	}

	protected override void __initializeRpcs()
	{
	}

	private static void __rpc_handler_3578559553(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
	{
	}

	private static void __rpc_handler_4034626652(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
	{
	}

	private static void __rpc_handler_2528940999(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
	{
	}

	private static void __rpc_handler_3166971030(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
	{
	}

	protected internal override string __getTypeName()
	{
		return null;
	}
}
