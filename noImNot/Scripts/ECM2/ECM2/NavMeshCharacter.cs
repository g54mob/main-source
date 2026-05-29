using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

namespace ECM2
{
	[RequireComponent(typeof(Character))]
	[RequireComponent(typeof(NavMeshAgent))]
	public class NavMeshCharacter : MonoBehaviour
	{
		public delegate void DestinationReachedEventHandler();

		[Space(15f)]
		[Tooltip("Should the agent brake automatically to avoid overshooting the destination point? \nIf true, the agent will brake automatically as it nears the destination.")]
		[SerializeField]
		private bool _autoBraking;

		[Tooltip("Distance from target position to start braking.")]
		[SerializeField]
		private float _brakingDistance;

		[Tooltip("Stop within this distance from the target position.")]
		[SerializeField]
		private float _stoppingDistance;

		private NavMeshAgent _agent;

		private Character _character;

		public NavMeshAgent agent => null;

		public Character character => null;

		public bool autoBraking
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float brakingDistance
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float brakingRatio => 0f;

		public float stoppingDistance
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public event DestinationReachedEventHandler DestinationReached
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

		public virtual void OnDestinationReached()
		{
		}

		protected virtual void CacheComponents()
		{
		}

		public virtual bool HasPath()
		{
			return false;
		}

		public virtual bool IsPathFollowing()
		{
			return false;
		}

		public virtual Vector3 GetDestination()
		{
			return default(Vector3);
		}

		public virtual void MoveToDestination(Vector3 destination)
		{
		}

		public virtual void PauseMovement(bool pause)
		{
		}

		public virtual void StopMovement()
		{
		}

		protected virtual float ComputeAnalogInputModifier(Vector3 desiredVelocity)
		{
			return 0f;
		}

		protected virtual Vector3 CalcMovementDirection(Vector3 desiredVelocity)
		{
			return default(Vector3);
		}

		protected virtual void DoPathFollowing()
		{
		}

		protected virtual void SyncNavMeshAgent()
		{
		}

		protected virtual void OnMovementModeChanged(Character.MovementMode prevMovementMode, int prevCustomMovementMode)
		{
		}

		protected virtual void OnBeforeSimulationUpdated(float deltaTime)
		{
		}

		private void Reset()
		{
		}

		private void OnValidate()
		{
		}

		protected virtual void Awake()
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual void LateUpdate()
		{
		}
	}
}
