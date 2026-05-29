using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Gley.UrbanSystem.Internal;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Jobs;

namespace Gley.TrafficSystem.Internal
{
	internal class TrafficManager : NoktaSingleton<TrafficManager>
	{
		[CompilerGenerated]
		private sealed class _003CUpdateCameraCoroutine_003Ed__159 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TrafficManager _003C_003E4__this;

			public Transform[] activeCameras;

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
			public _003CUpdateCameraCoroutine_003Ed__159(int _003C_003E1__state)
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

		private TransformAccessArray _vehicleTrigger;

		private TransformAccessArray _suspensionConnectPoints;

		private TransformAccessArray _wheelsGraphics;

		private NativeArray<float3> _activeCameraPositions;

		private NativeArray<DriveActions> _vehicleSpecialDriveAction;

		private NativeArray<VehicleTypes> _vehicleType;

		private Rigidbody[] _vehicleRigidbody;

		private Dictionary<int, Rigidbody> _trailerRigidbody;

		private NativeArray<float3> _vehicleDownDirection;

		private NativeArray<float3> _vehicleForwardDirection;

		private NativeArray<float3> _trailerForwardDirection;

		private NativeArray<float3> _triggerForwardDirection;

		private NativeArray<float3> _vehicleRightDirection;

		private NativeArray<float3> _trailerRightDirection;

		private NativeArray<float3> _vehicleTargetWaypointPosition;

		private NativeArray<float3> _vehiclePosition;

		private NativeArray<float3> _vehicleGroundDirection;

		private NativeArray<float3> _vehicleForwardForce;

		private NativeArray<float3> _trailerForwardForce;

		private NativeArray<float3> _vehicleVelocity;

		private NativeArray<float3> _trailerVelocity;

		private NativeArray<float3> _closestObstacle;

		private NativeArray<float> _wheelSpringForce;

		private NativeArray<float> _vehicleMaxSteer;

		private NativeArray<float> _vehicleRotationAngle;

		private NativeArray<float> _vehiclePowerStep;

		private NativeArray<float> _vehicleBrakeStep;

		private NativeArray<float> _vehicleActionValue;

		private NativeArray<float> _vehicleDrag;

		private NativeArray<float> _massDifference;

		private NativeArray<float> _trailerDrag;

		private NativeArray<float> _vehicleMaxSpeed;

		private NativeArray<float> _vehicleLength;

		private NativeArray<float> _vehicleWheelDistance;

		private NativeArray<float> _vehicleSteeringStep;

		private NativeArray<float> _vehicleDistanceToStop;

		private NativeArray<int> _vehicleStartWheelIndex;

		private NativeArray<int> _vehicleEndWheelIndex;

		private NativeArray<int> _vehicleNrOfWheels;

		private NativeArray<int> _vehicleListIndex;

		private NativeArray<int> _vehicleGear;

		private NativeArray<int> _trailerNrWheels;

		private NativeArray<bool> _vehicleReadyToRemove;

		private NativeArray<bool> _vehicleIsBraking;

		private NativeArray<bool> _vehicleNeedWaypoint;

		private NativeArray<bool> _ignoreVehicle;

		private NativeArray<bool> _excludedVehicles;

		private NativeArray<bool> _addExcludedVehicle;

		private NativeArray<RaycastHit> _wheelRaycatsResult;

		private NativeArray<RaycastCommand> _wheelRaycastCommand;

		private NativeArray<float3> _wheelSuspensionPosition;

		private NativeArray<float3> _wheelGroundPosition;

		private NativeArray<float3> _wheelVelocity;

		private NativeArray<float3> _wheelRightDirection;

		private NativeArray<float3> _wheelNormalDirection;

		private NativeArray<float3> _wheelSuspensionForce;

		private NativeArray<float3> _wheelSideForce;

		private NativeArray<float> _wheelRotation;

		private NativeArray<float> _wheelRadius;

		private NativeArray<float> _wheelRaycatsDistance;

		private NativeArray<float> _wheelMaxSuspension;

		private NativeArray<float> _wheelSpringStiffness;

		private NativeArray<int> _wheelSign;

		private NativeArray<int> _wheelAssociatedCar;

		private NativeArray<bool> _wheelCanSteer;

		private NativeArray<bool> _excludedWheels;

		private NativeArray<float> _turnAngle;

		private NativeArray<float> _raycastLengths;

		private NativeArray<float> _wCircumferences;

		private UpdateWheelJob _updateWheelJob;

		private UpdateTriggerJob _updateTriggerJob;

		private DriveJob _driveJob;

		private WheelJob _wheelJob;

		private JobHandle _raycastJobHandle;

		private JobHandle _updateWheelJobHandle;

		private JobHandle _updateTriggerJobHandle;

		private JobHandle _driveJobHandle;

		private JobHandle _wheelJobHandle;

		private Transform[] _activeCameras;

		private LayerMask _roadLayers;

		private Vector3 _forward;

		private Vector3 _up;

		private float _distanceToRemove;

		private float _minDistanceToAdd;

		private int _nrOfVehicles;

		private int _nrOfJobs;

		private int _indexToRemove;

		private int _totalWheels;

		private int _activeSquaresLevel;

		private int _activeCameraIndex;

		private bool _initialized;

		private bool _clearPath;

		private RoadSide _side;

		private static TrafficManager _instance;

		private AllVehiclesDataHandler _allVehiclesDataHandler;

		private DensityManager _densityManager;

		private SoundManager _soundManager;

		private DrivingAI _drivingAI;

		private WaypointManager _waypointManager;

		private TrafficWaypointsDataHandler _trafficWaypointsDataHandler;

		private TrafficModules _trafficModules;

		private IntersectionManager _intersectionManager;

		private AllIntersectionsDataHandler _allIntersectionsHandler;

		private VehiclePositioningSystem _vehiclePositioningSystem;

		private PathFindingManager _pathFindingManager;

		private IntersectionsDataHandler _intersectionsDataHandler;

		private ActiveCellsManager _activeCellsManager;

		private GridDataHandler _gridDataHandler;

		private PathFindingDataHandler _pathFindingDataHandler;

		private TimeManager _timeManager;

		private DebugManager _debugManager;

		public Rigidbody[] VehicleRigidbody => null;

		internal new static TrafficManager Instance => null;

		public static bool Exists => false;

		internal AllVehiclesDataHandler AllVehiclesDataHandler => null;

		internal DensityManager DensityManager => null;

		internal SoundManager SoundManager => null;

		internal DrivingAI DrivingAI => null;

		internal WaypointManager WaypointManager => null;

		internal TrafficWaypointsDataHandler TrafficWaypointsDataHandler => null;

		internal TrafficModules TrafficModules => null;

		internal IntersectionManager IntersectionManager => null;

		internal AllIntersectionsDataHandler AllIntersectionsHandler => null;

		internal VehiclePositioningSystem VehiclePositioningSystem => null;

		internal PathFindingManager PathFindingManager => null;

		internal IntersectionsDataHandler IntersectionsDataHandler => null;

		internal ActiveCellsManager ActiveCellsManager => null;

		internal GridDataHandler GridDataHandler => null;

		internal TimeManager TimeManager => null;

		internal DebugManager DebugManager => null;

		private T ReturnError<T>()
		{
			return default(T);
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnLocalPlayerUpdated(PlayerInstance _instance)
		{
		}

		internal void Initialize(Transform[] activeCameras, int nrOfVehicles, VehiclePool vehiclePool, TrafficOptions trafficOptions)
		{
		}

		internal bool IsInitialized()
		{
			return false;
		}

		internal void ClearPathForSpecialVehicles(bool active, RoadSide side)
		{
		}

		internal void ClearTrafficOnArea(Vector3 center, float radius)
		{
		}

		internal void RemoveVehicle(GameObject vehicle)
		{
		}

		internal void UpdateCamera(Transform[] activeCameras)
		{
		}

		[IteratorStateMachine(typeof(_003CUpdateCameraCoroutine_003Ed__159))]
		internal IEnumerator UpdateCameraCoroutine(Transform[] activeCameras)
		{
			return null;
		}

		internal void SetActiveSquaresLevel(int activeSquaresLevel)
		{
		}

		internal void StopVehicleDriving(GameObject vehicle)
		{
		}

		internal void AddVehicleWithPath(Vector3 position, VehicleTypes vehicleType, Vector3 destination, UnityAction<VehicleComponent, int> completeMethod)
		{
		}

		internal void SetDestination(int vehicleIndex, Vector3 position)
		{
		}

		internal void RemoveVehicleControl(int vehicleIndex)
		{
		}

		internal void AddVehicleControl(int vehicleIndex)
		{
		}

		internal void InstantiateTrafficVehicle(int vehicleIndex, Vector3 vehiclePosition, Quaternion vehicleRotation, Vector3 initialVelocity, Vector3 initialAngularVelocity, int nextWaypointIndex)
		{
		}

		internal int GetClosestWaypoint(Vector3 position, Vector3 direction)
		{
			return 0;
		}

		private bool CheckOrientation(TrafficWaypoint waypoint, Vector3 direction)
		{
			return false;
		}

		private void NewVehicleAdded(int vehicleIndex)
		{
		}

		public void SetVelocity(int vehicleIndex, Vector3 initialVelocity, Vector3 angularVelocity)
		{
		}

		internal void RemoveVehicle(int vehicleIndex, bool force)
		{
		}

		private void UpdateDrivingState(int vehicleIndex, DriveActions action, float actionValue)
		{
		}

		private void DestinationChanged(int vehicleIndex)
		{
		}

		private Vector3 GetTargetWaypointPosition(int vehicleIndex, bool clearPath, RoadSide side)
		{
			return default(Vector3);
		}

		private void FixedUpdate()
		{
		}

		private void Update()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
