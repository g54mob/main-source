using System;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.AI;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("NavMesh Agent")]
	[Image(typeof(IconCharacterWalk), ColorTheme.Type.Red, typeof(OverlayArrowRight))]
	[Category("NavMesh Agent")]
	[Description("Moves the Character using Unity's Navigation Mesh Agent. Requires a scene with a baked navigation mesh")]
	public class UnitDriverNavmesh : TUnitDriver
	{
		private const ObstacleAvoidanceType DEFAULT_QUALITY = ObstacleAvoidanceType.HighQualityObstacleAvoidance;

		[SerializeField]
		private ObstacleAvoidanceType m_AvoidQuality = ObstacleAvoidanceType.HighQualityObstacleAvoidance;

		[SerializeField]
		private int m_AvoidPriority = 50;

		[SerializeField]
		private bool m_AutoMeshLink = true;

		[SerializeField]
		private DriverNavmeshAgentType m_AgentType = new DriverNavmeshAgentType();

		[NonSerialized]
		protected NavMeshAgent m_Agent;

		[NonSerialized]
		protected INavMeshTraverseLink m_Link;

		[NonSerialized]
		protected CapsuleCollider m_Capsule;

		[NonSerialized]
		protected Vector3 m_MoveDirection;

		[NonSerialized]
		private Vector3 m_Velocity = Vector3.zero;

		[NonSerialized]
		private Vector3 m_PreviousPosition = Vector3.zero;

		[NonSerialized]
		private DriverAdditionalTranslation m_AddTranslation;

		public override Vector3 WorldMoveDirection => m_Velocity;

		public override Vector3 LocalMoveDirection => base.Transform.InverseTransformDirection(WorldMoveDirection);

		public override float SkinWidth => 0.08f;

		public override bool IsGrounded
		{
			get
			{
				if (!m_ForceGrounded)
				{
					return m_Agent.isOnNavMesh;
				}
				return true;
			}
		}

		public override Vector3 FloorNormal => Vector3.up;

		public override bool Collision
		{
			get
			{
				return m_Capsule.enabled;
			}
			set
			{
				m_Capsule.enabled = value;
			}
		}

		public override Axonometry Axonometry
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public UnitDriverNavmesh()
		{
			m_MoveDirection = Vector3.zero;
		}

		public override void OnDispose(Character character)
		{
			base.OnDispose(character);
			UnityEngine.Object.Destroy(m_Agent);
		}

		public override void OnStartup(Character character)
		{
			base.OnStartup(character);
			m_Agent = base.Character.GetComponent<NavMeshAgent>();
			if (m_Agent == null)
			{
				GameObject gameObject = base.Character.gameObject;
				m_Agent = gameObject.AddComponent<NavMeshAgent>();
				m_Agent.hideFlags = HideFlags.HideInInspector;
			}
			m_Agent.updatePosition = true;
			m_Agent.updateRotation = false;
			m_Agent.updateUpAxis = false;
			m_Agent.autoBraking = false;
			m_Agent.autoRepath = false;
			m_Agent.agentTypeID = m_AgentType.AgentType;
			m_Capsule = base.Character.GetComponent<CapsuleCollider>();
			if (m_Capsule == null)
			{
				GameObject gameObject2 = base.Character.gameObject;
				m_Capsule = gameObject2.AddComponent<CapsuleCollider>();
				m_Capsule.hideFlags = HideFlags.HideInInspector;
			}
		}

		public override void OnUpdate()
		{
			if (base.Character.IsDead)
			{
				return;
			}
			if (m_Agent.isOnOffMeshLink && m_Agent.currentOffMeshLinkData.owner is INavMeshTraverseLink navMeshTraverseLink)
			{
				if (m_Link == null)
				{
					m_Link = navMeshTraverseLink;
					m_Agent.isStopped = true;
					m_Agent.velocity = Vector3.zero;
					navMeshTraverseLink.Traverse(base.Character, OnTraverseComplete);
				}
				Vector3 vector = (m_AddTranslation.HasValue ? m_AddTranslation.Consume() : base.Character.Animim.RootMotionDeltaPosition);
				if (vector != Vector3.zero)
				{
					m_Agent.Move(vector);
				}
			}
			else
			{
				UpdateProperties(base.Character.Motion);
				UpdateTranslation(base.Character.Motion);
			}
		}

		protected virtual void UpdateProperties(IUnitMotion motion)
		{
			m_MoveDirection = Vector3.zero;
			m_Agent.speed = motion.LinearSpeed;
			m_Agent.angularSpeed = ((motion.AngularSpeed >= 0f) ? motion.AngularSpeed : float.MaxValue);
			NavMeshAgent agent = m_Agent;
			float acceleration = ((!motion.UseAcceleration) ? 9999f : ((motion.Acceleration + motion.Deceleration) / 2f));
			agent.acceleration = acceleration;
			m_Agent.radius = motion.Radius;
			m_Agent.height = motion.Height;
			if (Math.Abs(m_Capsule.height - motion.Height) > float.Epsilon)
			{
				m_Capsule.height = motion.Height;
			}
			if (Math.Abs(m_Capsule.radius - motion.Radius) > float.Epsilon)
			{
				m_Capsule.radius = motion.Radius;
			}
			if (m_Capsule.center != Vector3.zero)
			{
				m_Capsule.center = Vector3.zero;
			}
			m_Agent.baseOffset = m_Agent.height / 2f;
			m_Agent.autoTraverseOffMeshLink = m_AutoMeshLink;
			m_Agent.obstacleAvoidanceType = m_AvoidQuality;
			m_Agent.avoidancePriority = m_AvoidPriority;
		}

		protected virtual void UpdateTranslation(IUnitMotion motion)
		{
			if (!m_Agent.isOnNavMesh)
			{
				Debug.LogWarning("No Navigation Mesh bound to Agent", base.Character.gameObject);
				return;
			}
			if (base.Character.RootMotionPosition > 0.9f)
			{
				m_Agent.autoBraking = false;
				m_Agent.autoRepath = false;
				m_Agent.velocity = Vector3.zero;
				m_Agent.isStopped = true;
				m_MoveDirection = base.Character.Animim.RootMotionDeltaPosition;
				m_Agent.Move(m_MoveDirection);
			}
			else if (base.UpdateKinematics)
			{
				switch (motion.MovementType)
				{
				case Character.MovementType.MoveToDirection:
				{
					m_Agent.autoBraking = false;
					m_Agent.velocity = Vector3.zero;
					Vector3 offset = UpdateMoveToDirection(motion);
					m_Agent.Move(offset);
					break;
				}
				case Character.MovementType.MoveToPosition:
					m_Agent.autoBraking = true;
					UpdateMoveToPosition(motion);
					break;
				case Character.MovementType.None:
					m_Agent.autoBraking = true;
					m_Agent.autoRepath = false;
					m_Agent.isStopped = true;
					break;
				default:
					throw new ArgumentOutOfRangeException();
				}
			}
			else
			{
				m_Agent.autoBraking = true;
				m_Agent.autoRepath = false;
				m_Agent.isStopped = true;
			}
			Vector3 vector = m_AddTranslation.Consume();
			if (vector != Vector3.zero)
			{
				m_Agent.Move(vector);
			}
			Vector3 position = base.Transform.position;
			m_Velocity = Vector3.Normalize(position - m_PreviousPosition) * m_MoveDirection.magnitude;
			m_PreviousPosition = position;
		}

		protected virtual Vector3 UpdateMoveToDirection(IUnitMotion motion)
		{
			m_Agent.autoRepath = false;
			m_Agent.isStopped = true;
			m_MoveDirection = motion.MoveDirection;
			return m_MoveDirection * base.Character.Time.DeltaTime;
		}

		protected virtual void UpdateMoveToPosition(IUnitMotion motion)
		{
			m_Agent.autoRepath = true;
			m_Agent.isStopped = false;
			m_Agent.SetDestination(motion.MovePosition);
			m_MoveDirection = m_Agent.velocity;
		}

		public override void SetPosition(Vector3 position)
		{
			position += Vector3.up * (base.Character.Motion.Height * 0.5f);
			m_Agent.Warp(position);
		}

		public override void SetRotation(Quaternion rotation)
		{
			base.Transform.rotation = rotation;
		}

		public override void SetScale(Vector3 scale)
		{
			base.Transform.localScale = scale;
		}

		public override void AddPosition(Vector3 amount)
		{
			m_AddTranslation.Add(amount);
		}

		public override void AddRotation(Quaternion amount)
		{
			base.Transform.rotation *= amount;
		}

		public override void AddScale(Vector3 scale)
		{
			base.Transform.localScale += scale;
		}

		public void ChangeHeight(float height)
		{
			m_Agent.height = height;
		}

		private void OnTraverseComplete()
		{
			m_Agent.updatePosition = true;
			m_Agent.updateRotation = false;
			m_Agent.isStopped = false;
			m_Agent.autoRepath = true;
			m_Agent.CompleteOffMeshLink();
			m_Link = null;
			m_Agent.autoTraverseOffMeshLink = m_AutoMeshLink;
		}

		public override void ResetVerticalVelocity()
		{
		}

		public override void OnDrawGizmos(Character character)
		{
			if (Application.isPlaying && character.Motion.MovementType == Character.MovementType.MoveToPosition)
			{
				OnDrawGizmosToTarget();
			}
		}

		protected void OnDrawGizmosToTarget()
		{
			if (m_Agent == null || !m_Agent.hasPath || m_Agent.isPathStale)
			{
				return;
			}
			switch (m_Agent.path.status)
			{
			case NavMeshPathStatus.PathComplete:
				Gizmos.color = Color.yellow;
				break;
			case NavMeshPathStatus.PathPartial:
				Gizmos.color = Color.red;
				break;
			case NavMeshPathStatus.PathInvalid:
				Gizmos.color = Color.grey;
				break;
			}
			Vector3[] corners = m_Agent.path.corners;
			if (corners.Length > 1)
			{
				for (int i = 1; i < corners.Length; i++)
				{
					Gizmos.DrawLine(corners[i - 1], corners[i]);
				}
			}
		}

		public override string ToString()
		{
			return "Navmesh Agent";
		}
	}
}
