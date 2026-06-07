using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Gley.TrafficSystem.Internal;
using Gley.TrafficSystem.Scripts.ToUse;
using Gley.UrbanSystem.Internal;
using Photon.Pun;
using UnityEngine;

namespace Gley.TrafficSystem
{
	[HelpURL("https://gley.gitbook.io/mobile-traffic-system/setup-guide/vehicle-implementation")]
	public class VehicleComponent : MonoBehaviour, ITrafficParticipant, IPunInstantiateMagicCallback
	{
		private readonly struct Obstacle
		{
			private readonly Collider _collider;

			private readonly bool _isConvex;

			internal Collider Collider => null;

			internal bool IsConvex => false;

			public Obstacle(Collider collider, bool isConvex)
			{
				_collider = null;
				_isConvex = false;
			}
		}

		[CompilerGenerated]
		private sealed class _003CClearInvalidCollidersDelayed_003Ed__70 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public VehicleComponent _003C_003E4__this;

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
			public _003CClearInvalidCollidersDelayed_003Ed__70(int _003C_003E1__state)
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

		[SerializeField]
		private MultiplayerVehicleBroadcast multiplayerVehicleBroadcast;

		[Space]
		[Header("Object References")]
		[Tooltip("RigidBody of the vehicle")]
		public Rigidbody rb;

		[Tooltip("Empty GameObject used to rotate the vehicle from the correct point")]
		public Transform carHolder;

		[Tooltip("Front trigger used to detect obstacle. It is automatically generated")]
		public Transform frontTrigger;

		[Tooltip("Assign this object if you need a hard shadow on your vehicle, leave it black otherwise")]
		public Transform shadowHolder;

		[Header("Wheels")]
		[Tooltip("All vehicle wheels and their properties")]
		public Wheel[] allWheels;

		[Tooltip("Max wheel turn amount in degrees")]
		public float maxSteer;

		[Tooltip("If suspension is set to 0, the value of suspension will be half of the wheel radius")]
		public float maxSuspension;

		[Tooltip("How rigid the suspension will be. Higher the value -> more rigid the suspension")]
		public float springStiffness;

		[Header("Car Properties")]
		[Tooltip("Vehicle type used for making custom paths")]
		public VehicleTypes vehicleType;

		[Tooltip("Min vehicle speed. Actual vehicle speed is picked random between min and max")]
		public int minPossibleSpeed;

		[Tooltip("Max vehicle speed")]
		public int maxPossibleSpeed;

		[Tooltip("Time in seconds to reach max speed (acceleration)")]
		public float accelerationTime;

		[Tooltip("Distance to keep from an obstacle/vehicle")]
		public float distanceToStop;

		[Tooltip("Car starts braking when an obstacle enters trigger. Total length of the trigger = distanceToStop+minTriggerLength")]
		public float triggerLength;

		[HideInInspector]
		public bool updateTrigger;

		[HideInInspector]
		public float maxTriggerLength;

		[HideInInspector]
		public TrailerComponent trailer;

		[HideInInspector]
		public Transform trailerConnectionPoint;

		[HideInInspector]
		public float length;

		[HideInInspector]
		public float coliderHeight;

		[HideInInspector]
		public float wheelDistance;

		[HideInInspector]
		public VisibilityScript visibilityScript;

		[HideInInspector]
		public bool excluded;

		private List<ITrafficParticipant> _vehiclesToFollow;

		private Collider[] _allColliders;

		private List<Obstacle> _obstacleList;

		private Transform _frontAxle;

		private BoxCollider _frontCollider;

		private ModifyTriggerSize _modifyTriggerSize;

		private EngineSoundComponent _engineSound;

		private LayerMask _buildingLayers;

		private LayerMask _obstacleLayers;

		private LayerMask _playerLayers;

		private LayerMask _roadLayers;

		private IVehicleLightsComponent _vehicleLights;

		private DriveActions _currentAction;

		private float _springForce;

		private float _maxSpeed;

		private float _storedMaxSpeed;

		private float _minTriggerLength;

		private float _colliderWidth;

		private int _listIndex;

		private bool _lightsOn;

		private int m_ObstLayer;

		public Collider[] AllColliders => null;

		public DriveActions CurrentAction => default(DriveActions);

		public float ColliderWidth => 0f;

		public float MaxSpeed => 0f;

		public float SpringForce => 0f;

		public int ListIndex => 0;

		public VehicleTypes VehicleType => default(VehicleTypes);

		public float MaxSteer => 0f;

		private bool IsOnlyClient => false;

		private bool IsOnlyMaster => false;

		private void Initialize(LayerMask buildingLayers, LayerMask obstacleLayers, LayerMask playerLayers, LayerMask roadLayers, bool lightsOn, ModifyTriggerSize modifyTriggerSize)
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnPlayerVehicleRemoved()
		{
		}

		[IteratorStateMachine(typeof(_003CClearInvalidCollidersDelayed_003Ed__70))]
		private IEnumerator ClearInvalidCollidersDelayed()
		{
			return null;
		}

		public void VehicleInitialize(int vehicleIndex, LayerMask buildingLayers, LayerMask obstacleLayers, LayerMask playerLayers, LayerMask roadLayers, bool excluded, bool lightsOn, ModifyTriggerSize modifyTriggerSize)
		{
		}

		private void OnTriggerEnter(Collider other)
		{
		}

		private void OnCollisionEnter(Collision collision)
		{
		}

		public virtual void OnTriggerExit(Collider other)
		{
		}

		internal void SetTriggerSizeModifierDelegate(ModifyTriggerSize triggerSizeModifier)
		{
		}

		public virtual void ActivateVehicle(Vector3 position, Quaternion vehicleRotation, Quaternion trailerRotation)
		{
		}

		public virtual void DeactivateVehicle()
		{
		}

		public Vector3 GetGroundDirection()
		{
			return default(Vector3);
		}

		public float GetPowerStep()
		{
			return 0f;
		}

		public float GetSteeringStep()
		{
			return 0f;
		}

		public float GetBrakeStep()
		{
			return 0f;
		}

		public float GetRaycastLength()
		{
			return 0f;
		}

		public float GetWheelCircumference()
		{
			return 0f;
		}

		public Vector3 GetVelocity()
		{
			return default(Vector3);
		}

		public float GetCurrentSpeed()
		{
			return 0f;
		}

		public float GetCurrentSpeedMS()
		{
			return 0f;
		}

		public Collider GetCollider()
		{
			return null;
		}

		public Vector3 GetHeading()
		{
			return default(Vector3);
		}

		public Vector3 GetForwardVector()
		{
			return default(Vector3);
		}

		public void SetIndex(int index)
		{
		}

		public bool CanBeRemoved()
		{
			return false;
		}

		public void CurrentVehicleActionDone()
		{
		}

		public Transform GetFrontAxle()
		{
			return null;
		}

		public int GetNrOfWheels()
		{
			return 0;
		}

		public int GetTrailerWheels()
		{
			return 0;
		}

		public void SetCurrentAction(DriveActions currentAction)
		{
		}

		public Vector3 GetClosestObstacle()
		{
			return default(Vector3);
		}

		internal bool AlreadyCollidingWith(Collider[] colliders)
		{
			return false;
		}

		public void ColliderRemoved(Collider collider)
		{
		}

		public void ColliderRemoved(Collider[] colliders)
		{
		}

		internal void SetMainLights(bool on)
		{
		}

		public void SetReverseLights(bool active)
		{
		}

		public void SetBrakeLights(bool active)
		{
		}

		public virtual void SetBlinker(BlinkType blinkType)
		{
		}

		public void UpdateLights(float realtimeSinceStartup)
		{
		}

		public void UpdateEngineSound(float masterVolume)
		{
		}

		internal float GetTriggerSize()
		{
			return 0f;
		}

		internal void UpdateColliderSize()
		{
		}

		internal float GetFollowSpeed()
		{
			return 0f;
		}

		internal void SetMaxSpeed(float speed)
		{
		}

		internal void ResetMaxSpeed()
		{
		}

		internal float GetSpringStiffness()
		{
			return 0f;
		}

		private void AddVehichleToFollow(Collider other)
		{
		}

		private ObstacleTypes GetObstacleTypes(Collider other)
		{
			return default(ObstacleTypes);
		}

		private void NewColliderHit(Collider other)
		{
		}

		private void AVehicleChengedState(int vehicleIndex, Collider collider)
		{
		}

		private void OnDestroy()
		{
		}

		public void OnPhotonInstantiate(PhotonMessageInfo info)
		{
		}
	}
}
