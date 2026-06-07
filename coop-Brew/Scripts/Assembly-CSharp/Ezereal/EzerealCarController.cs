using System;
using System.Runtime.CompilerServices;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Ezereal
{
	public class EzerealCarController : NetworkBehaviour
	{
		private IEzerealVehicleInputSource aiInputSource;

		private bool aiControlEnabled;

		[Header("Ezereal References")]
		[SerializeField]
		private EzerealLightController ezerealLightController;

		[SerializeField]
		private EzerealSoundController ezerealSoundController;

		[SerializeField]
		private EzerealWheelFrictionController ezerealWheelFrictionController;

		[Header("References")]
		public Rigidbody vehicleRB;

		public WheelCollider frontLeftWheelCollider;

		public WheelCollider frontRightWheelCollider;

		public WheelCollider rearLeftWheelCollider;

		public WheelCollider rearRightWheelCollider;

		private WheelCollider[] wheels;

		[SerializeField]
		private Transform frontLeftWheelMesh;

		[SerializeField]
		private Transform frontRightWheelMesh;

		[SerializeField]
		private Transform rearLeftWheelMesh;

		[SerializeField]
		private Transform rearRightWheelMesh;

		[Header("Optional Middle Wheels (for 6-wheel vehicles)")]
		public WheelCollider middleLeftWheelCollider;

		public WheelCollider middleRightWheelCollider;

		[SerializeField]
		private Transform middleLeftWheelMesh;

		[SerializeField]
		private Transform middleRightWheelMesh;

		[SerializeField]
		private Transform steeringWheel;

		[Tooltip("Which local axis the steering wheel rotates around. Y = green axis, Z = blue axis, X = red axis (in Pivot+Local mode)")]
		[SerializeField]
		private SteeringWheelAxis steeringWheelAxis;

		private Quaternion steeringWheelInitialRotation;

		[Header("Seat Configuration")]
		[Tooltip("Transform positions for vehicle seats. First seat is always the driver seat.")]
		public Transform[] seatPositions;

		private bool hasDriver;

		private ulong driverClientId;

		[Header("Settings")]
		public bool isStarted;

		[Header("Vehicle Tuning (Editable at Runtime)")]
		[Range(50f, 300f)]
		public float maxForwardSpeed;

		[Range(10f, 100f)]
		public float maxReverseSpeed;

		[Range(500f, 5000f)]
		public float horsePower;

		[Range(500f, 5000f)]
		public float brakePower;

		[Range(1000f, 10000f)]
		public float handbrakeForce;

		[Range(15f, 45f)]
		public float maxSteerAngle;

		[Range(1f, 15f)]
		public float steeringSpeed;

		[Range(0.1f, 5f)]
		public float stopThreshold;

		[Range(0.1f, 2f)]
		public float decelerationSpeed;

		[Range(45f, 720f)]
		public float maxSteeringWheelRotation;

		[Header("Drift Tuning (Editable at Runtime)")]
		[Tooltip("How much the rear wheels slip when handbrake is pulled. Higher = more slidy/drifty.")]
		[Range(1f, 6f)]
		public float driftSlipMultiplier;

		[Tooltip("Grip level during drift. Lower = more slidy. Higher = more controlled drift.")]
		[Range(0.2f, 1.5f)]
		public float driftGripMultiplier;

		[Tooltip("How quickly grip recovers after releasing handbrake. Lower = longer drift tails.")]
		[Range(0.1f, 2f)]
		public float driftRecoveryDuration;

		[Tooltip("Rear wheel sideways stiffness. Lower = more tail-happy at all times.")]
		[Range(0.3f, 2f)]
		public float rearWheelSidewaysStiffness;

		[Tooltip("How much throttle causes oversteer. Higher = more power slides.")]
		[Range(0f, 1f)]
		public float throttleOversteerAmount;

		[Tooltip("Grip reduction when counter-steering during a slide. Higher = easier drift transitions.")]
		[Range(0.1f, 0.9f)]
		public float counterSteerGripReduction;

		[Header("Hill Climb / Anti-Drift Tuning")]
		[Tooltip("Anti-burnout: wheel torque is scaled by this floor at standstill, ramping to 1 at launchRampSpeed. Lower = less wheel spin / drift on launch (recommended 0.15-0.3 with high horsepower).")]
		[Range(0.05f, 1f)]
		public float launchTorqueFloor;

		[Tooltip("Speed (km/h) at which torque reaches its full value. Below this it ramps up from launchTorqueFloor.")]
		[Range(1f, 40f)]
		public float launchRampSpeed;

		[Tooltip("Direct forward force (m/s^2) ONLY at low speed — lets vehicles start moving on hills without dumping torque into spinning wheels. Tapers to zero at lowSpeedAssistCutoff. Default 0 (opt-in) — only raise if you find the vehicle can't climb a hill from a stop.")]
		[Range(0f, 20f)]
		public float lowSpeedForceAssist;

		[Tooltip("Speed (km/h) at which lowSpeedForceAssist fades out completely. Keep this below cruising speeds so the assist can't add to top speed.")]
		[Range(2f, 40f)]
		public float lowSpeedAssistCutoff;

		[Tooltip("Direct rearward force when braking (m/s^2). Default 0 — only useful on very steep downhills.")]
		[Range(0f, 20f)]
		public float brakeForceAssist;

		[Tooltip("Direct reverse force when reversing (m/s^2). Default 0.")]
		[Range(0f, 20f)]
		public float reverseForceAssist;

		[Header("Stuck Detection (Driver-Only Notification)")]
		[Tooltip("If on, notifies the local driver (only) when the wheels are spinning hard but the vehicle isn't moving — telling them they can hold left-click on the map to reset.")]
		[SerializeField]
		private bool enableStuckNotification;

		[Tooltip("Vehicle counts as 'not moving' below this speed (km/h).")]
		[Range(0f, 5f)]
		[SerializeField]
		private float stuckSpeedThreshold;

		[Tooltip("A wheel is 'spinning hard' above this absolute RPM.")]
		[Range(50f, 1000f)]
		[SerializeField]
		private float stuckWheelRpmThreshold;

		[Tooltip("Stuck-with-spinning-wheels: how long the wheels must spin while not moving before the notification fires (clear-cut stuck signal, can be short).")]
		[Range(1f, 15f)]
		[SerializeField]
		private float stuckDetectionTime;

		[Tooltip("Stuck-without-spinning-wheels (wedged/upside down): how long to wait before notifying. Longer than the spinning case so we don't false-positive at intersections or behind blocked traffic.")]
		[Range(2f, 30f)]
		[SerializeField]
		private float stuckDetectionTimeWedged;

		[Tooltip("Cooldown between stuck notifications (seconds).")]
		[Range(5f, 120f)]
		[SerializeField]
		private float stuckNotificationCooldown;

		private float _stuckStartTime;

		private float _lastStuckNotificationTime;

		[Header("Drive Type")]
		public DriveTypes driveType;

		[Header("Debug Info")]
		[SerializeField]
		private bool showDebugLogs;

		public bool stationary;

		[SerializeField]
		private float currentSpeed;

		[SerializeField]
		private float currentAccelerationValue;

		[SerializeField]
		private float currentBrakeValue;

		[SerializeField]
		private float currentHandbrakeValue;

		[SerializeField]
		private float currentSteerAngle;

		[SerializeField]
		private float targetSteerAngle;

		[SerializeField]
		private float FrontLeftWheelRPM;

		[SerializeField]
		private float FrontRightWheelRPM;

		[SerializeField]
		private float RearLeftWheelRPM;

		[SerializeField]
		private float RearRightWheelRPM;

		[SerializeField]
		private float speedFactor;

		private NetworkVariable<bool> netIsStarted;

		private NetworkVariable<bool> netBrakeLights;

		private NetworkVariable<bool> netReverseLights;

		private NetworkVariable<bool> netHandbrakeLights;

		private NetworkVariable<bool> netHasDriver;

		private NetworkVariable<float> netFrontLeftWheelRotation;

		private NetworkVariable<float> netFrontRightWheelRotation;

		private NetworkVariable<float> netRearLeftWheelRotation;

		private NetworkVariable<float> netRearRightWheelRotation;

		private NetworkVariable<float> netSteerAngle;

		private NetworkVariable<float> netFrontLeftSuspension;

		private NetworkVariable<float> netFrontRightSuspension;

		private NetworkVariable<float> netRearLeftSuspension;

		private NetworkVariable<float> netRearRightSuspension;

		private NetworkVariable<Vector3> netVelocity;

		private NetworkVariable<Vector3> netAngularVelocity;

		private float localFrontLeftRotation;

		private float localFrontRightRotation;

		private float localRearLeftRotation;

		private float localRearRightRotation;

		private float smoothedFLRotation;

		private float smoothedFRRotation;

		private float smoothedRLRotation;

		private float smoothedRRRotation;

		private float smoothedFLSuspension;

		private float smoothedFRSuspension;

		private float smoothedRLSuspension;

		private float smoothedRRSuspension;

		private float smoothedSteerAngle;

		[Header("Wheel Smoothing (Non-Owner)")]
		[SerializeField]
		private float wheelRotationSmoothSpeed;

		[SerializeField]
		private float wheelSuspensionSmoothSpeed;

		[SerializeField]
		private float wheelSteerSmoothSpeed;

		[Header("Custom Position Smoothing (Non-Owner)")]
		[Tooltip("Adds extra smoothing layer on top of CNT interpolation")]
		[SerializeField]
		private bool useCustomPositionSmoothing;

		[Tooltip("Time to reach target position (lower = faster response, higher = smoother). 0.05-0.15 recommended.")]
		[SerializeField]
		private float positionSmoothTime;

		[Tooltip("Time to reach target rotation (lower = faster response). 0.05-0.15 recommended.")]
		[SerializeField]
		private float rotationSmoothTime;

		[Tooltip("How far ahead to predict vehicle position (compensates for smoothing lag). 0 = no prediction.")]
		[SerializeField]
		private float predictionTime;

		[Tooltip("Smoothing time for vertical axis. 0 = no vertical smoothing (eliminates float).")]
		[SerializeField]
		private float verticalSmoothTime;

		[Tooltip("Apply prediction to vertical axis. Disable to reduce hovering.")]
		[SerializeField]
		private bool predictVertical;

		[Header("Velocity Sync (Experimental)")]
		[Tooltip("Enable velocity-based synchronization for non-owners. When enabled, non-owners use synced velocity for prediction instead of calculating from position delta. This makes impacts/collisions more visible to non-owners.")]
		[SerializeField]
		private bool useVelocitySync;

		[Tooltip("How quickly non-owners blend to synced velocity. Higher = more responsive to impacts, lower = smoother.")]
		[SerializeField]
		private float velocitySyncBlendSpeed;

		private Vector3 customSmoothedPosition;

		private Quaternion customSmoothedRotation;

		private Vector3 positionSmoothVelocity;

		private float rotVelX;

		private float rotVelY;

		private float rotVelZ;

		private bool customSmoothingInitialized;

		private Vector3 lastTargetPosition;

		private Vector3 targetVelocity;

		private Quaternion lastTargetRotation;

		private Vector3 targetAngularVelocity;

		private bool _isLocalOwner;

		private bool _exitAcknowledgedByClient;

		private float _originalDrag;

		private const float PARKED_DRAG = 2f;

		private float _prefabDrag;

		private float _lastDiagSnapshotTime;

		private int _entryLogSeq;

		private float _lastVehiclePushTime;

		private const float VEHICLE_PUSH_COOLDOWN = 0.5f;

		private Vector3 _clientExitPosition;

		private Quaternion _clientExitRotation;

		private bool _hasClientExitPosition;

		public float CurrentSpeed => 0f;

		public float NetworkedSpeed => 0f;

		public float GetFrontLeftWheelRPM => 0f;

		public float GetFrontRightWheelRPM => 0f;

		public float GetRearLeftWheelRPM => 0f;

		public float GetRearRightWheelRPM => 0f;

		public float GetBrakeValue => 0f;

		public float GetHandbrakeValue => 0f;

		public bool IsReversing => false;

		public float NetworkedSteerAngle => 0f;

		public float PrefabDrag => 0f;

		public bool ExitAcknowledged => false;

		public Vector3 ClientExitPosition => default(Vector3);

		public Quaternion ClientExitRotation => default(Quaternion);

		public bool HasClientExitPosition => false;

		public event Action<bool> OnHandbrakeStateChanged
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

		public void EnableAIControl(IEzerealVehicleInputSource inputSource)
		{
		}

		public void DisableAIControl()
		{
		}

		private void Update()
		{
		}

		public void ResetExitAcknowledgment()
		{
		}

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnGainedOwnership()
		{
		}

		public override void OnLostOwnership()
		{
		}

		private void OnDriverStateChanged(bool previousValue, bool newValue)
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		private void StartCar()
		{
		}

		private void StopCar()
		{
		}

		private void OnBrakeLightsChanged(bool oldValue, bool newValue)
		{
		}

		private void OnReverseLightsChanged(bool oldValue, bool newValue)
		{
		}

		private void OnHandbrakeLightsChanged(bool oldValue, bool newValue)
		{
		}

		private void OnIsStartedChanged(bool oldValue, bool newValue)
		{
		}

		private void OnStartCar()
		{
		}

		private void OnAccelerate(InputValue accelerationValue)
		{
		}

		private void OnBrake(InputValue brakeValue)
		{
		}

		private void OnHandbrake(InputValue handbrakeValue)
		{
		}

		private void OnSteer(InputValue turnValue)
		{
		}

		[Rpc(SendTo.Server, RequireOwnership = false)]
		private void UpdateBrakeLightsServerRpc(bool value)
		{
		}

		[Rpc(SendTo.Server, RequireOwnership = false)]
		private void UpdateReverseLightsServerRpc(bool value)
		{
		}

		[Rpc(SendTo.Server, RequireOwnership = false)]
		private void UpdateHandbrakeLightsServerRpc(bool value)
		{
		}

		[Rpc(SendTo.Server, RequireOwnership = false)]
		private void UpdateIsStartedServerRpc(bool value)
		{
		}

		private void Acceleration()
		{
		}

		private void Braking()
		{
		}

		private void Handbraking()
		{
		}

		private void Steering()
		{
		}

		private void Slowdown()
		{
		}

		private void TickStuckDetection()
		{
		}

		private void ApplyMotorTorqueByDriveType(float torque)
		{
		}

		private void ClearMotorTorque()
		{
		}

		private void ApplyBrakesToFrontWheels(float brakeForce)
		{
		}

		private void ApplyBrakesToAllWheels(float brakeForce)
		{
		}

		private void UpdateReverseLights(bool on)
		{
		}

		private void FixedUpdate()
		{
		}

		private void UpdateWheelMeshes()
		{
		}

		private void UpdateAuthorityState()
		{
		}

		public void SetWheelCollidersEnabled(bool enabled)
		{
		}

		public void ApplyFullBrakes()
		{
		}

		private float GetWheelSuspensionOffset(WheelCollider col)
		{
			return 0f;
		}

		private void UpdateWheelFromCollider(WheelCollider col, Transform mesh)
		{
		}

		private void UpdateWheelFromNetwork(Transform mesh, WheelCollider col, float rotationAngle, float steerAngle, float suspensionOffset)
		{
		}

		private float GetLocalWheelSuspensionOffset(WheelCollider col)
		{
			return 0f;
		}

		private void SmoothWheelValuesForNonOwner()
		{
		}

		private void LateUpdate()
		{
		}

		private void ApplyCustomPositionSmoothing()
		{
		}

		private void RotateSteeringWheel()
		{
		}

		public bool InAir()
		{
			return false;
		}

		[Rpc(SendTo.Server, RequireOwnership = false)]
		public void SetDriverRpc(ulong clientId, bool isDriver)
		{
		}

		[ClientRpc]
		public void PrepareToExitVehicleClientRpc(ulong targetClientId)
		{
		}

		[Rpc(SendTo.Server, RequireOwnership = false)]
		private void AcknowledgeExitReadyServerRpc(Vector3 clientPosition, Quaternion clientRotation, RpcParams rpcParams = default(RpcParams))
		{
		}

		public bool HasDriver()
		{
			return false;
		}

		public void NotifyLocalPlayerEntered()
		{
		}

		private string BuildDiagnosticSnapshot(string tag)
		{
			return null;
		}

		private void LogDiag(string tag)
		{
		}

		private void ResetPhysicsForNewDriver()
		{
		}

		public ulong GetDriverClientId()
		{
			return 0uL;
		}

		public Transform[] GetSeatPositions()
		{
			return null;
		}

		public Transform[] GetWheelMeshTransforms()
		{
			return null;
		}

		public float GetCurrentAcceleration()
		{
			return 0f;
		}

		private bool ValidateInput(string inputType)
		{
			return false;
		}

		private void ValidatePhysicsSettings()
		{
		}

		public void ForceNonKinematic()
		{
		}

		private void OnCollisionEnter(Collision collision)
		{
		}

		[Rpc(SendTo.Server, RequireOwnership = false)]
		private void RequestVehiclePushRpc(ulong targetVehicleNetId, Vector3 impactVelocity, float hitterMass)
		{
		}

		[ContextMenu("Debug: Log Network Component Settings")]
		public void DebugLogNetworkSettings()
		{
		}

		[ContextMenu("Debug: Log Network Settings (Runtime Comparison)")]
		public void DebugLogRuntimeComparison()
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_955408765(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3813887523(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1413630695(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2328852376(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_497113830(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1390681011(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_4213567133(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1435048729(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
