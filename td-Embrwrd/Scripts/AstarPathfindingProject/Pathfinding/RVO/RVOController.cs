using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pathfinding.RVO
{
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_r_v_o_1_1_r_v_o_controller.php")]
	[AddComponentMenu("Pathfinding/Local Avoidance/RVO Controller")]
	public class RVOController : VersionedMonoBehaviour
	{
		[FormerlySerializedAs("radius")]
		[SerializeField]
		internal float radiusBackingField;

		[SerializeField]
		[FormerlySerializedAs("height")]
		private float heightBackingField;

		[SerializeField]
		[FormerlySerializedAs("center")]
		private float centerBackingField;

		[Tooltip("A locked unit cannot move. Other units will still avoid it. But avoidance quality is not the best")]
		public bool locked;

		[Tooltip("Automatically set #locked to true when desired velocity is approximately zero")]
		public bool lockWhenNotMoving;

		[Tooltip("How far into the future to look for collisions with other agents (in seconds)")]
		public float agentTimeHorizon;

		[Tooltip("How far into the future to look for collisions with obstacles (in seconds)")]
		public float obstacleTimeHorizon;

		[Tooltip("Max number of other agents to take into account.\nA smaller value can reduce CPU load, a higher value can lead to better local avoidance quality.")]
		public int maxNeighbours;

		public RVOLayer layer;

		[EnumFlag]
		public RVOLayer collidesWith;

		[Obsolete]
		[HideInInspector]
		public float wallAvoidForce;

		[Obsolete]
		[HideInInspector]
		public float wallAvoidFalloff;

		[Tooltip("How strongly other agents will avoid this agent")]
		[Range(0f, 1f)]
		public float priority;

		protected Transform tr;

		[SerializeField]
		[FormerlySerializedAs("ai")]
		private IAstarAI aiBackingField;

		public bool debug;

		public float radius
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float height
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float center
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[Obsolete("This field is obsolete in version 4.0 and will not affect anything. Use the LegacyRVOController if you need the old behaviour")]
		public LayerMask mask
		{
			get
			{
				return default(LayerMask);
			}
			set
			{
			}
		}

		[Obsolete("This field is obsolete in version 4.0 and will not affect anything. Use the LegacyRVOController if you need the old behaviour")]
		public bool enableRotation
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Obsolete("This field is obsolete in version 4.0 and will not affect anything. Use the LegacyRVOController if you need the old behaviour")]
		public float rotationSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[Obsolete("This field is obsolete in version 4.0 and will not affect anything. Use the LegacyRVOController if you need the old behaviour")]
		public float maxSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public MovementPlane movementPlane => default(MovementPlane);

		public IAgent rvoAgent { get; private set; }

		public Simulator simulator { get; private set; }

		protected IAstarAI ai
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector3 position => default(Vector3);

		public Vector3 velocity
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 CalculateMovementDelta(float deltaTime)
		{
			return default(Vector3);
		}

		public Vector3 CalculateMovementDelta(Vector3 position, float deltaTime)
		{
			return default(Vector3);
		}

		public void SetCollisionNormal(Vector3 normal)
		{
		}

		[Obsolete("Set the 'velocity' property instead")]
		public void ForceSetVelocity(Vector3 velocity)
		{
		}

		public Vector2 To2D(Vector3 p)
		{
			return default(Vector2);
		}

		public Vector2 To2D(Vector3 p, out float elevation)
		{
			elevation = default(float);
			return default(Vector2);
		}

		public Vector3 To3D(Vector2 p, float elevationCoordinate)
		{
			return default(Vector3);
		}

		private void OnDisable()
		{
		}

		private void OnEnable()
		{
		}

		protected void UpdateAgentProperties()
		{
		}

		public void SetTarget(Vector3 pos, float speed, float maxSpeed)
		{
		}

		public void Move(Vector3 vel)
		{
		}

		[Obsolete("Use transform.position instead, the RVOController can now handle that without any issues.")]
		public void Teleport(Vector3 pos)
		{
		}

		private void OnDrawGizmos()
		{
		}

		protected override int OnUpgradeSerializedData(int version, bool unityThread)
		{
			return 0;
		}
	}
}
