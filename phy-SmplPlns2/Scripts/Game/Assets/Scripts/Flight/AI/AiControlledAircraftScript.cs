using System;
using System.Collections.Generic;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers.Weapons;
using Assets.Scripts.Flight.AI.ControlSystems;
using Assets.Scripts.Input;
using Assets.Scripts.Misc.SimpleBehaviours;
using Assets.Scripts.Multiplayer;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Flight.AI
{
	public class AiControlledAircraftScript : MonoBehaviour
	{
		public bool InputOverrideEnabled = true;

		public bool ShowDebugInfo;

		public bool ShowDebugInfoWaterAvoidance;

		protected const int GizmoRayLength = 10;

		private AiControlSystem _aiControlSystem;

		private int _angleCount;

		private int _angleIndexPosition;

		private float _angleTotal;

		private int _damagedPartCount;

		private GameObject _debugTargetObject;

		private float _distToTargetLastFrame;

		private float _endWaterDangerZoneAltitudeAbsolute;

		private bool _firstFrame = true;

		private bool _isTargetDummyRigidbody;

		private AircraftScript _mainTargetAircraft;

		private Vector3? _mainTargetPosition;

		private Func<Vector3> _mainTargetPositionFunc;

		private Rigidbody _mainTargetRigidbody;

		private Vector3 _perfBenchmarkAngularVelocityTotal = Vector3.zero;

		private float _perfTestEndTime;

		private Vector3 _perfTestStartVelocityMag;

		private (bool IsTarget, bool IsFriendly) _playerTargetInfo = (IsTarget: false, IsFriendly: false);

		private float[] _previousAnglesToTarget;

		private bool _runningPerfTest;

		private float _startingAltitude;

		private Vector3 _startingDirection;

		private Rigidbody _targetDummyRigidbody;

		private Func<Vector3> _targetPositionFunc;

		private Rigidbody _targetRigidbody;

		private int _totalPartCount;

		[SerializeField]
		[Range(0f, 1f)]
		private float _trackingAgressiveness;

		public AiAircraftInfo AiAircraftInfo { get; private set; }

		public AircraftScript AiAircraftScript { get; private set; }

		public float AircraftDamagePercent => (float)_damagedPartCount / (float)_totalPartCount;

		public float AircraftFirstDamagedTime { get; private set; }

		public bool AircraftHasBeenDamaged { get; private set; }

		public Rigidbody AiRigidbody { get; private set; }

		public float AngleToTarget { get; private set; }

		public bool AutoDespawn { get; set; }

		public float AverageAngleToTarget => _angleTotal / (float)_angleCount;

		public bool BehindTarget => TargetRelativePosition.z > 0f;

		public float ClosingSpeed { get; private set; }

		public AiControlSystem CurrentControlSystem => _aiControlSystem;

		public Vector3 CurrentTargetPosition { get; private set; }

		public AnimationCurve DefaultPitchSensitivityCurve { get; private set; }

		public float DistanceToFinalTarget { get; private set; }

		public float DistanceToTarget { get; private set; }

		public float DistanceToTargetOnHorizontalPlane { get; private set; }

		public bool GoUpToAvoidWater { get; private set; }

		public float HeightRelativeToTarget { get; private set; }

		public bool IsFlightTargetDestructible => !_isTargetDummyRigidbody;

		public AircraftScript MainTargetAircraft => _mainTargetAircraft;

		public NetworkAircraftScript NetworkAircraft => AiAircraftScript?.NetworkAircraft as NetworkAircraftScript;

		public Transform OrientedTargetTransform { get; private set; }

		public float PointingAtTargetPercent { get; private set; }

		public bool PreparingForDespawn { get; private set; }

		public bool TargetIsPlayer { get; private set; }

		public Vector3 TargetRelativePosition { get; private set; }

		public Transform TargetRigidbodyTransform => _targetRigidbody.transform;

		public Vector3 TargetRigidbodyVelocity
		{
			get
			{
				if (PauseManager.Paused)
				{
					return Vector3.zero;
				}
				return _targetRigidbody.linearVelocity;
			}
		}

		public float TrackingAgressiveness
		{
			get
			{
				return _trackingAgressiveness;
			}
			private set
			{
				_trackingAgressiveness = value;
			}
		}

		public bool UseGroundAvoidance { get; set; }

		public bool UseWaterAvoidance { get; set; }

		public Vector3 VecToTarget { get; private set; }

		public Vector3 VecToTargetLocal { get; private set; }

		public Vector3 VelocityOfAi { get; private set; }

		private bool TargetIsStaticPosition => _isTargetDummyRigidbody;

		private Rigidbody TargetRigidBody => _targetRigidbody;

		public void AbortDespawn()
		{
			PreparingForDespawn = false;
		}

		public void Initialize(AircraftScript aircraftToTrack, AiAircraftInfo aircraftInfo)
		{
			if (aircraftToTrack != null)
			{
				SetTarget(aircraftToTrack, mainTarget: true);
			}
			Initialize(aircraftInfo);
		}

		public void Initialize(AiAircraftInfo aircraftInfo)
		{
			AiAircraftInfo = aircraftInfo;
			if (AiAircraftScript == null)
			{
				AiAircraftScript = base.transform.GetComponentInParent<AircraftScript>(includeInactive: true);
			}
			if (AiAircraftScript != null)
			{
				AiRigidbody = AiAircraftScript.MainCockpit.Body.GetComponent<Rigidbody>();
				DefaultPitchSensitivityCurve = Resources.Load<GameObject>("Data/AiControlledAircraft/AiPitchControlCurve").GetComponent<AnimationCurveScript>().AnimationCurve;
				EnableInputOverrides();
				AiAircraftScript.OnAircraftDamaged += OnAircraftDamaged;
				if (AiAircraftInfo == null)
				{
					AiAircraftInfo = new AiAircraftInfo(AiAircraftScript.Aircraft.Name);
				}
				_totalPartCount = AiAircraftScript.Parts.Count;
			}
			else
			{
				Debug.LogError("AiControlledAircraft script must be added to, or as a child of an aircraft.");
				UnityEngine.Object.Destroy(this);
			}
		}

		public void PreInitialize(AircraftScript aircraftScript)
		{
			AiAircraftScript = aircraftScript;
		}

		public void PrepareForDespawn()
		{
			PreparingForDespawn = true;
		}

		public void RegisterAsPlayerTarget(bool isFriendly = false)
		{
			_playerTargetInfo.IsTarget = true;
			_playerTargetInfo.IsFriendly = isFriendly;
			if (_playerTargetInfo.IsTarget && AiAircraftScript == null)
			{
				Debug.LogError("Unable to register the AI aircraft as a player target because the aircraft script doesn't exist or has been destroyed.");
			}
		}

		public void ResetTargetToMainTarget()
		{
			if (_mainTargetPosition.HasValue)
			{
				SetTarget(_mainTargetPosition.Value, mainTarget: true);
			}
			else if (_mainTargetAircraft != null)
			{
				SetTarget(_mainTargetAircraft, mainTarget: true);
			}
			else if (_mainTargetRigidbody != null)
			{
				SetTarget(_mainTargetRigidbody, mainTarget: true);
			}
			else if (_targetPositionFunc != null)
			{
				SetTarget(_targetPositionFunc, mainTarget: true);
			}
		}

		public void SetAiControlSystem(AiControlSystem aiControlSystem)
		{
			if (_aiControlSystem != null)
			{
				DisableInputOverrides();
				_aiControlSystem.Unload();
			}
			_aiControlSystem = aiControlSystem;
			_aiControlSystem.Initialize(this);
			EnableInputOverrides();
		}

		public void SetTarget(AircraftScript targetAircraft, bool mainTarget, float? targetLeadSuggestion = null)
		{
			if (mainTarget)
			{
				_mainTargetAircraft = targetAircraft;
				_mainTargetRigidbody = null;
				_mainTargetPosition = null;
				_mainTargetPositionFunc = null;
				_targetPositionFunc = null;
			}
			TargetIsPlayer = targetAircraft.IsPrimaryLocalPlayer;
			_isTargetDummyRigidbody = false;
			_targetRigidbody = targetAircraft.MainCockpit.Body.GetComponent<Rigidbody>();
			OrientedTargetTransform = targetAircraft.OrientedCenterOfMassRigidBodies;
		}

		public void SetTarget(Rigidbody targetRigidbody, bool mainTarget)
		{
			if (_isTargetDummyRigidbody && _targetRigidbody != null)
			{
				UnityEngine.Object.Destroy(_targetRigidbody.gameObject);
			}
			if (mainTarget)
			{
				_mainTargetRigidbody = targetRigidbody;
				_mainTargetAircraft = null;
				_mainTargetRigidbody = null;
				_mainTargetPositionFunc = null;
				_targetPositionFunc = null;
			}
			_isTargetDummyRigidbody = false;
			_targetRigidbody = targetRigidbody;
			if (_targetRigidbody != null)
			{
				OrientedTargetTransform = targetRigidbody.transform;
			}
		}

		public void SetTarget(Func<Vector3> positionFunc, bool mainTarget)
		{
			_targetPositionFunc = positionFunc;
			if (mainTarget)
			{
				_mainTargetPositionFunc = positionFunc;
				_mainTargetPosition = null;
				_mainTargetAircraft = null;
				_mainTargetRigidbody = null;
			}
			_isTargetDummyRigidbody = false;
		}

		public void SetTarget(Vector3 targetPositionFloatingOrigin, bool mainTarget)
		{
			if (_targetDummyRigidbody == null)
			{
				_targetDummyRigidbody = new GameObject().AddComponent<Rigidbody>();
				_targetDummyRigidbody.useGravity = false;
				_targetDummyRigidbody.name = "DummyRigidbodyForAi";
				_targetDummyRigidbody.transform.parent = FlightSceneScript.Instance.AircraftContainer;
			}
			_targetRigidbody = _targetDummyRigidbody;
			_targetRigidbody.transform.position = targetPositionFloatingOrigin;
			_targetRigidbody.transform.up = Vector3.up;
			OrientedTargetTransform = _targetRigidbody.transform;
			if (mainTarget)
			{
				_mainTargetPosition = targetPositionFloatingOrigin;
				_mainTargetAircraft = null;
				_mainTargetRigidbody = null;
				_mainTargetPositionFunc = null;
				_targetPositionFunc = null;
			}
			_isTargetDummyRigidbody = true;
		}

		protected virtual void Awake()
		{
			UseGroundAvoidance = false;
			UseWaterAvoidance = false;
			ShowDebugInfo = false;
			ShowDebugInfoWaterAvoidance = false;
			TrackingAgressiveness = 1f;
			PreparingForDespawn = false;
			_previousAnglesToTarget = new float[Mathf.RoundToInt(3f / Time.fixedDeltaTime)];
		}

		protected virtual void FixedUpdate()
		{
			_aiControlSystem.OnFixedUpdate();
			MonitorAircraftPerformance(Time.fixedTime, Time.fixedDeltaTime);
		}

		protected virtual void LateUpdate()
		{
			_aiControlSystem.OnLateUpdate();
			if (_firstFrame && AiAircraftScript.IsPrimaryLocalPlayer)
			{
				_firstFrame = false;
				EnableDopplar();
			}
		}

		protected virtual void OnDestroy()
		{
			_aiControlSystem?.Unload();
			_aiControlSystem = null;
			if (_targetDummyRigidbody != null)
			{
				UnityEngine.Object.Destroy(_targetDummyRigidbody.gameObject);
			}
		}

		protected virtual void OnDisable()
		{
			if (_aiControlSystem != null)
			{
				DisableInputOverrides();
			}
		}

		protected virtual void OnDrawGizmos()
		{
			if (AiRigidbody != null && TargetRigidBody != null)
			{
				Gizmos.color = Color.blue;
				Gizmos.DrawRay(AiRigidbody.position, VecToTarget);
				Gizmos.color = Color.gray;
				Gizmos.DrawRay(AiRigidbody.position, VelocityOfAi);
				Gizmos.color = Color.red;
				Gizmos.DrawRay(AiRigidbody.position, TargetRigidBody.transform.position - AiRigidbody.position);
				_aiControlSystem.OnDrawGizmos();
			}
		}

		protected virtual void OnEnable()
		{
			if (_aiControlSystem != null && _targetRigidbody != null && OrientedTargetTransform != null)
			{
				EnableInputOverrides();
			}
		}

		protected virtual void Start()
		{
			if (_aiControlSystem == null)
			{
				SetAiControlSystem(new AiCsFlyToLocationAndEngage());
				SetTarget(AiAircraftScript, mainTarget: true);
			}
		}

		protected virtual void Update()
		{
			MonitorInputOverrides();
			UpdateTargetInfo();
			CalculateInfoForControlSystems();
			_aiControlSystem.OnUpdate();
		}

		private void ActivateGunGroups()
		{
			List<int> list = new List<int>();
			foreach (PartData part in AiAircraftScript.Parts)
			{
				GunData modifier = part.GetModifier<GunData>();
				if (modifier != null && int.TryParse(modifier.ActivationGroup, out var result) && !list.Contains(result))
				{
					list.Add(result);
				}
			}
			foreach (int item in list)
			{
				AiAircraftScript.Controls.ActivateGroup(item);
			}
		}

		private void CalculateAverageAngleToTarget()
		{
			if (_angleCount >= _previousAnglesToTarget.Length)
			{
				_angleTotal -= _previousAnglesToTarget[_angleIndexPosition];
			}
			else
			{
				_angleCount++;
			}
			_previousAnglesToTarget[_angleIndexPosition] = AngleToTarget;
			_angleTotal += AngleToTarget;
			if (++_angleIndexPosition >= _previousAnglesToTarget.Length)
			{
				_angleIndexPosition = 0;
			}
		}

		private void CalculateInfoForControlSystems()
		{
			Vector3? targetOverridePosition = _aiControlSystem.GetTargetOverridePosition();
			Vector3 vector = ((!targetOverridePosition.HasValue) ? Utilities.GetTargetLeadPrediction(AiRigidbody.transform.position, _aiControlSystem.LeadTargetSourceVelocity(), _targetRigidbody.transform.position, _targetRigidbody.linearVelocity, _aiControlSystem.LeadTarget()).Position : targetOverridePosition.Value);
			if (UseGroundAvoidance || UseWaterAvoidance)
			{
				float objectAvoidanceDangerZoneDistance = AiAircraftInfo.GetObjectAvoidanceDangerZoneDistance(AiAircraftScript);
				if (UseGroundAvoidance)
				{
					vector = GetGroundAvoidanceTarget(AiRigidbody.position, vector, objectAvoidanceDangerZoneDistance);
				}
				if (UseWaterAvoidance)
				{
					DoWaterAvoidance(objectAvoidanceDangerZoneDistance);
				}
			}
			CurrentTargetPosition = vector;
			VecToTarget = vector - AiRigidbody.position;
			VecToTargetLocal = AiRigidbody.transform.InverseTransformDirection(VecToTarget);
			DistanceToFinalTarget = Vector3.Distance(TargetRigidBody.transform.position, AiRigidbody.position);
			DistanceToTarget = Vector3.Distance(vector, AiRigidbody.position);
			DistanceToTargetOnHorizontalPlane = Vector3.Distance(new Vector3(vector.x, 0f, vector.z), new Vector3(AiRigidbody.position.x, 0f, AiRigidbody.position.z));
			PointingAtTargetPercent = Vector3.Dot(AiRigidbody.linearVelocity.normalized, VecToTarget.normalized);
			HeightRelativeToTarget = vector.y - AiRigidbody.position.y;
			TargetRelativePosition = AiRigidbody.transform.InverseTransformPoint(vector);
			float num = Vector3.Distance(vector, AiRigidbody.position);
			ClosingSpeed = (_distToTargetLastFrame - num) * (1f / Time.deltaTime);
			_distToTargetLastFrame = num;
			VelocityOfAi = AiAircraftScript.Velocity;
			AngleToTarget = Vector3.Angle(AiRigidbody.linearVelocity.normalized, VecToTarget.normalized);
			CalculateAverageAngleToTarget();
		}

		private void DisableInputOverrides()
		{
			if (AiAircraftScript != null)
			{
				AiAircraftScript.Controls.RemoveInputOverrides();
				AiAircraftScript.Controls.ShowInputStatusMessages = true;
				if (AiAircraftScript.IsPrimaryLocalPlayer)
				{
					AiAircraftScript.Controls.TargetingModeSelectionEnabled = true;
				}
			}
		}

		private void DoDebugStuff()
		{
			if (ShowDebugInfo)
			{
				if (_debugTargetObject == null)
				{
					_debugTargetObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
					_debugTargetObject.GetComponent<Collider>().enabled = false;
					_debugTargetObject.transform.localScale = Vector3.one * 50f;
				}
				_debugTargetObject.transform.position = CurrentTargetPosition;
			}
		}

		private void DoWaterAvoidance(float watereDangerZoneAltitude)
		{
			if (GoUpToAvoidWater)
			{
				GoUpToAvoidWater = AiAircraftScript.Altitude < _endWaterDangerZoneAltitudeAbsolute;
				if (ShowDebugInfoWaterAvoidance && !GoUpToAvoidWater)
				{
					Debug.LogFormat("Stopping water avoidance: {0}", AiAircraftInfo.AircraftId);
				}
			}
			else
			{
				GoUpToAvoidWater = AiAircraftScript.Altitude < watereDangerZoneAltitude;
				if (GoUpToAvoidWater)
				{
					float endWaterDangerZoneAltitudeAbsolute = watereDangerZoneAltitude * 1.5f;
					_endWaterDangerZoneAltitudeAbsolute = endWaterDangerZoneAltitudeAbsolute;
					if (ShowDebugInfoWaterAvoidance)
					{
						Debug.LogFormat("Starting water avoidance({0}): current alt: {1}m, avoid water alt: {2}m, climbing to {3}m", AiAircraftInfo.AircraftId, AiAircraftScript.Altitude, watereDangerZoneAltitude, _endWaterDangerZoneAltitudeAbsolute);
					}
				}
			}
			if (GoUpToAvoidWater && TargetIsStaticPosition)
			{
				float y = Utility.ConvertAbsoluteToFloatingOriginPosition(new Vector3(0f, _endWaterDangerZoneAltitudeAbsolute, 0f)).y;
				Vector3 targetPositionFloatingOrigin = new Vector3(CurrentTargetPosition.x, y, CurrentTargetPosition.z);
				SetTarget(targetPositionFloatingOrigin, mainTarget: true);
				if (ShowDebugInfoWaterAvoidance)
				{
					Debug.LogFormat("Detected using water avoidance while flying to a static target...the target must be too low to avoid water...raising it up to {0}m", y);
				}
			}
		}

		private void EnableDopplar()
		{
			AudioSource[] componentsInChildren = base.transform.GetComponentsInChildren<AudioSource>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].dopplerLevel = 0.25f;
			}
		}

		private void EnableInputOverrides()
		{
			if (AiAircraftScript != null)
			{
				AircraftControls controls = AiAircraftScript.Controls;
				GameInputs instance = GameInputs.Instance;
				controls.DisableAllControls();
				controls.ShowInputStatusMessages = false;
				if (AiAircraftScript.IsPrimaryLocalPlayer)
				{
					controls.SetInputOverride(instance.Throttle, null);
					controls.SetInputOverride(instance.Brake, null);
				}
				else
				{
					controls.SetInputOverride(instance.Throttle, () => _aiControlSystem.GetThrottle());
					controls.SetInputOverride(instance.Brake, () => _aiControlSystem.GetBrake());
				}
				controls.SetInputOverride(instance.Pitch, () => _aiControlSystem.GetPitch() * TrackingAgressiveness);
				controls.SetInputOverride(instance.Roll, () => _aiControlSystem.GetRoll());
				controls.SetInputOverride(instance.Yaw, () => _aiControlSystem.GetYaw());
				controls.SetInputOverride(instance.Vtol, () => _aiControlSystem.GetVtol());
				controls.SetInputOverride(instance.LandingGear, () => _aiControlSystem.LandingGearDown() ? 1 : 0);
				controls.SetInputOverride(instance.LaunchCountermeasures, () => _aiControlSystem.GetLaunchCountermeasures() ? 1 : 0);
				controls.SetInputOverride(instance.FireGuns, () => _aiControlSystem.GetFireGuns() ? 1 : 0);
				controls.SetInputOverride(instance.FireWeapons, () => _aiControlSystem.GetFireWeapons() ? 1 : 0);
				controls.SetInputOverride(instance.NextTarget, () => _aiControlSystem.GetSwitchNextTarget() ? 1 : 0);
				controls.SetInputOverride(instance.PreviousTarget, () => _aiControlSystem.GetSwitchPrevTarget() ? 1 : 0);
				controls.SetInputOverride(instance.NextWeapon, () => _aiControlSystem.GetSwitchNextWeapon() ? 1 : 0);
				controls.SetInputOverride(instance.PreviousWeapon, () => _aiControlSystem.GetSwitchPrevWeapon() ? 1 : 0);
				controls.SetInputOverride(instance.CycleTargetingMode, () => _aiControlSystem.CycleTargetingMode() ? 1 : 0);
				if (AiAircraftScript.IsPrimaryLocalPlayer)
				{
					controls.TargetingModeSelectionEnabled = false;
				}
				_startingAltitude = AiAircraftScript.Altitude;
				_startingDirection = AiAircraftScript.OrientedCenterOfMassRigidBodies.forward;
			}
			else
			{
				Debug.LogError("Could not enable input overrides for AI controlled aircraft: AircraftScript is null");
			}
		}

		private Vector3 GetGroundAvoidanceTarget(Vector3 aiPosition, Vector3 targetPosition, float objectAvoidanceDangerZoneDistance)
		{
			Vector3 normalized = (targetPosition - aiPosition).normalized;
			Vector3 endWorldPosition = ((!(Vector3.Distance(targetPosition, aiPosition) > 15000f)) ? targetPosition : (aiPosition + normalized * 15000f));
			Vector3? optimalTargetBetween = AiManagerScript.Instance.GetOptimalTargetBetween(aiPosition, endWorldPosition);
			Vector3 vector = ((!optimalTargetBetween.HasValue) ? targetPosition : optimalTargetBetween.Value);
			float? heightAboveTerrain = Utility.GetHeightAboveTerrain(vector);
			if (heightAboveTerrain.HasValue && heightAboveTerrain < objectAvoidanceDangerZoneDistance)
			{
				vector += new Vector3(0f, objectAvoidanceDangerZoneDistance - heightAboveTerrain.Value, 0f);
			}
			return vector;
		}

		private void MonitorAircraftPerformance(float time, float deltaTime)
		{
			Vector3 vector = Utilities.Abs(AiRigidbody.transform.InverseTransformDirection(AiRigidbody.angularVelocity));
			if (_perfTestEndTime < time)
			{
				if (_runningPerfTest)
				{
					if (!AircraftHasBeenDamaged)
					{
						_perfBenchmarkAngularVelocityTotal += vector;
						Vector3 vector2 = _perfBenchmarkAngularVelocityTotal / (1f / deltaTime);
						bool flag = false;
						if (vector2.x > AiAircraftInfo.MaxAngularVelocities.x)
						{
							AiAircraftInfo.MaxAngularVelocities.x = vector2.x;
							AiAircraftInfo.MaxAngularVelocitySpeeds.x = (_perfTestStartVelocityMag.x + AiRigidbody.linearVelocity.magnitude) / 2f;
							flag = true;
						}
						bool flag2 = false;
						if (vector2.y > AiAircraftInfo.MaxAngularVelocities.y)
						{
							AiAircraftInfo.MaxAngularVelocities.y = vector2.y;
							AiAircraftInfo.MaxAngularVelocitySpeeds.y = (_perfTestStartVelocityMag.y + AiRigidbody.linearVelocity.magnitude) / 2f;
							flag2 = true;
						}
						bool flag3 = false;
						if (vector2.z > AiAircraftInfo.MaxAngularVelocities.z)
						{
							AiAircraftInfo.MaxAngularVelocities.z = vector2.z;
							AiAircraftInfo.MaxAngularVelocitySpeeds.z = (_perfTestStartVelocityMag.z + AiRigidbody.linearVelocity.magnitude) / 2f;
							flag3 = true;
						}
						if (flag || flag3 || flag2)
						{
							AiAircraftInfo.HasBeenPerformanceChecked = true;
							AiAircraftInfo.Save();
						}
						_runningPerfTest = false;
					}
				}
				else if (!_aiControlSystem.AiControlledAircraft.AircraftHasBeenDamaged && (vector.x > AiAircraftInfo.MaxAngularVelocities.x || vector.y > AiAircraftInfo.MaxAngularVelocities.y || vector.z > AiAircraftInfo.MaxAngularVelocities.z))
				{
					_perfTestEndTime = time + 1f;
					_runningPerfTest = true;
					_perfTestStartVelocityMag = Vector3.one * AiRigidbody.linearVelocity.magnitude;
					_perfBenchmarkAngularVelocityTotal = vector;
				}
			}
			else if (_runningPerfTest)
			{
				_perfBenchmarkAngularVelocityTotal += vector;
			}
		}

		private void MonitorInputOverrides()
		{
			if (InputOverrideEnabled != AiAircraftScript.HasInputOverrides)
			{
				if (InputOverrideEnabled)
				{
					EnableInputOverrides();
				}
				else
				{
					DisableInputOverrides();
				}
			}
		}

		private void OnAircraftDamaged(PartScript damagedPart)
		{
			if (!AircraftHasBeenDamaged)
			{
				AircraftFirstDamagedTime = Time.time;
			}
			_damagedPartCount++;
			AircraftHasBeenDamaged = true;
		}

		private void UpdateTargetInfo()
		{
			AiRigidbody = AiAircraftScript.MainCockpit.Body.GetComponent<Rigidbody>();
			if (_mainTargetAircraft != null)
			{
				_targetRigidbody = _mainTargetAircraft.MainCockpit.Body.GetComponent<Rigidbody>();
			}
			if (_targetRigidbody == null)
			{
				SetTarget(delegate
				{
					Vector3 vector = AiAircraftScript.OrientedCenterOfMassRigidBodies.transform.position + Vector3.Scale(_startingDirection, new Vector3(1f, 0f, 1f) * 10000f);
					return new Vector3(vector.x, Utility.ConvertAbsoluteToFloatingOriginPosition(Vector3.one * _startingAltitude).y, vector.z);
				}, mainTarget: true);
			}
			if (_targetPositionFunc != null)
			{
				SetTarget(_targetPositionFunc(), mainTarget: false);
			}
		}
	}
}
