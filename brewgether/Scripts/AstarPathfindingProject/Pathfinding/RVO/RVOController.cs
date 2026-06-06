using System;
using Pathfinding.Serialization;
using Pathfinding.Util;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pathfinding.RVO
{
	[AddComponentMenu("Pathfinding/Local Avoidance/RVO Controller")]
	[UniqueComponent(tag = "rvo")]
	[HelpURL("https://arongranberg.com/astar/documentation/stable/rvocontroller.html")]
	public class RVOController : VersionedMonoBehaviour
	{
		[Flags]
		private enum RVOControllerMigrations
		{
			MigrateScale = 0
		}

		[SerializeField]
		[FormerlySerializedAs("radius")]
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

		[HideInInspector]
		[Obsolete]
		public float wallAvoidForce;

		[HideInInspector]
		[Obsolete]
		public float wallAvoidFalloff;

		[Tooltip("How strongly other agents will avoid this agent")]
		[Range(0f, 1f)]
		public float priority;

		[NonSerialized]
		public float priorityMultiplier;

		[NonSerialized]
		public float flowFollowingStrength;

		private GraphNode obstacleQuery;

		protected Transform tr;

		[SerializeField]
		[FormerlySerializedAs("ai")]
		private IAstarAI aiBackingField;

		internal SimpleMovementPlane movementPlaneBackingField;

		public AgentDebugFlags debug;

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

		public MovementPlane movementPlaneMode => default(MovementPlane);

		public SimpleMovementPlane movementPlane
		{
			get
			{
				return default(SimpleMovementPlane);
			}
			set
			{
			}
		}

		public IAgent rvoAgent { get; private set; }

		private SimulatorBurst simulator { get; set; }

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

		public bool AvoidingAnyAgents => false;

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

		public void SetObstacleQuery(GraphNode sourceNode)
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

		private void OnAgentDestroyed()
		{
		}

		protected void UpdateAgentProperties()
		{
		}

		public void SetTarget(Vector3 pos, float speed, float maxSpeed, Vector3 endOfPath)
		{
		}

		public void Move(Vector3 velocity)
		{
		}

		public override void DrawGizmos()
		{
		}

		protected override void OnUpgradeSerializedData(ref Migrations migrations, bool unityThread)
		{
		}
	}
}
