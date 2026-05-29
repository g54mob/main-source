using System;
using Pathfinding.Drawing;
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
		internal float radiusBackingField = 0.5f;

		[SerializeField]
		[FormerlySerializedAs("height")]
		private float heightBackingField = 2f;

		[SerializeField]
		[FormerlySerializedAs("center")]
		private float centerBackingField = 1f;

		[Tooltip("A locked unit cannot move. Other units will still avoid it. But avoidance quality is not the best")]
		public bool locked;

		[Tooltip("Automatically set #locked to true when desired velocity is approximately zero")]
		public bool lockWhenNotMoving;

		[Tooltip("How far into the future to look for collisions with other agents (in seconds)")]
		public float agentTimeHorizon = 2f;

		[Tooltip("How far into the future to look for collisions with obstacles (in seconds)")]
		public float obstacleTimeHorizon = 0.5f;

		[Tooltip("Max number of other agents to take into account.\nA smaller value can reduce CPU load, a higher value can lead to better local avoidance quality.")]
		public int maxNeighbours = 10;

		public RVOLayer layer = RVOLayer.DefaultAgent;

		[EnumFlag]
		public RVOLayer collidesWith = (RVOLayer)(-1);

		[HideInInspector]
		[Obsolete]
		public float wallAvoidForce = 1f;

		[HideInInspector]
		[Obsolete]
		public float wallAvoidFalloff = 1f;

		[Tooltip("How strongly other agents will avoid this agent")]
		[Range(0f, 1f)]
		public float priority = 0.5f;

		[NonSerialized]
		public float priorityMultiplier = 1f;

		[NonSerialized]
		public float flowFollowingStrength;

		private GraphNode obstacleQuery;

		protected Transform tr;

		[SerializeField]
		[FormerlySerializedAs("ai")]
		private IAstarAI aiBackingField;

		internal SimpleMovementPlane movementPlaneBackingField = GraphTransform.xzPlane.ToSimpleMovementPlane();

		public AgentDebugFlags debug;

		public float radius
		{
			get
			{
				if (ai != null)
				{
					return ai.radius;
				}
				return radiusBackingField;
			}
			set
			{
				if (ai != null)
				{
					ai.radius = value;
				}
				radiusBackingField = value;
			}
		}

		public float height
		{
			get
			{
				if (ai != null)
				{
					return ai.height;
				}
				return heightBackingField;
			}
			set
			{
				if (ai != null)
				{
					ai.height = value;
				}
				heightBackingField = value;
			}
		}

		public float center
		{
			get
			{
				if (ai != null)
				{
					return ai.height / 2f;
				}
				return centerBackingField;
			}
			set
			{
				centerBackingField = value;
			}
		}

		[Obsolete("This field is obsolete in version 4.0 and will not affect anything. Use the LegacyRVOController if you need the old behaviour")]
		public LayerMask mask
		{
			get
			{
				return 0;
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

		public MovementPlane movementPlaneMode => simulator?.MovementPlane ?? RVOSimulator.active?.movementPlane ?? MovementPlane.XZ;

		public SimpleMovementPlane movementPlane
		{
			get
			{
				SimulatorBurst simulatorBurst = simulator;
				MovementPlane? movementPlane = ((simulatorBurst != null) ? new MovementPlane?(simulatorBurst.MovementPlane) : RVOSimulator.active?.movementPlane);
				if (movementPlane.HasValue)
				{
					if (movementPlane.Value == MovementPlane.Arbitrary)
					{
						return movementPlaneBackingField;
					}
					if (movementPlane.Value == MovementPlane.XY)
					{
						return SimpleMovementPlane.XYPlane;
					}
				}
				return SimpleMovementPlane.XZPlane;
			}
			set
			{
				SimulatorBurst simulatorBurst = simulator;
				MovementPlane? movementPlane = ((simulatorBurst != null) ? new MovementPlane?(simulatorBurst.MovementPlane) : RVOSimulator.active?.movementPlane);
				if (movementPlane.HasValue && movementPlane.Value != MovementPlane.Arbitrary)
				{
					throw new InvalidOperationException("Cannot set the movement plane unless the RVOSimulator's movement plane setting is set to Arbitrary.");
				}
				movementPlaneBackingField = value;
			}
		}

		public IAgent rvoAgent { get; private set; }

		private SimulatorBurst simulator { get; set; }

		protected IAstarAI ai
		{
			get
			{
				if (aiBackingField as MonoBehaviour == null)
				{
					aiBackingField = null;
				}
				return aiBackingField;
			}
			set
			{
				aiBackingField = value;
			}
		}

		public Vector3 position
		{
			get
			{
				simulator.BlockUntilSimulationStepDone();
				return rvoAgent.Position;
			}
		}

		public Vector3 velocity
		{
			get
			{
				float num = ((Time.deltaTime > 0.0001f) ? Time.deltaTime : 0.02f);
				return CalculateMovementDelta(num) / num;
			}
			set
			{
				simulator.BlockUntilSimulationStepDone();
				rvoAgent.ForceSetVelocity(value);
			}
		}

		public bool AvoidingAnyAgents
		{
			get
			{
				if (rvoAgent == null)
				{
					return false;
				}
				return rvoAgent.AvoidingAnyAgents;
			}
		}

		public Vector3 CalculateMovementDelta(float deltaTime)
		{
			return CalculateMovementDelta((ai != null) ? ai.position : tr.position, deltaTime);
		}

		public Vector3 CalculateMovementDelta(Vector3 position, float deltaTime)
		{
			if (rvoAgent == null)
			{
				return Vector3.zero;
			}
			Vector2 vector = movementPlane.ToPlane(rvoAgent.CalculatedTargetPoint - position);
			return movementPlane.ToWorld(Vector2.ClampMagnitude(vector, rvoAgent.CalculatedSpeed * deltaTime));
		}

		public void SetCollisionNormal(Vector3 normal)
		{
			simulator.BlockUntilSimulationStepDone();
			rvoAgent.SetCollisionNormal(normal);
		}

		public void SetObstacleQuery(GraphNode sourceNode)
		{
			obstacleQuery = sourceNode;
		}

		[Obsolete("Set the 'velocity' property instead")]
		public void ForceSetVelocity(Vector3 velocity)
		{
			this.velocity = velocity;
		}

		public Vector2 To2D(Vector3 p)
		{
			return movementPlane.ToPlane(p);
		}

		public Vector2 To2D(Vector3 p, out float elevation)
		{
			return movementPlane.ToPlane(p, out elevation);
		}

		public Vector3 To3D(Vector2 p, float elevationCoordinate)
		{
			return movementPlane.ToWorld(p, elevationCoordinate);
		}

		private void OnDisable()
		{
			if (simulator != null)
			{
				simulator.RemoveAgent(rvoAgent);
				simulator = null;
				rvoAgent = null;
			}
		}

		private void OnEnable()
		{
			tr = base.transform;
			ai = GetComponent<IAstarAI>();
			if (ai is AIBase aIBase)
			{
				aIBase.FindComponents();
			}
			if (RVOSimulator.active == null)
			{
				Debug.LogError("No RVOSimulator component found in the scene. Please add one.");
				base.enabled = false;
				return;
			}
			simulator = RVOSimulator.active.GetSimulator();
			rvoAgent = simulator.AddAgent(Vector3.zero);
			rvoAgent.PreCalculationCallback = UpdateAgentProperties;
			rvoAgent.DestroyedCallback = OnAgentDestroyed;
		}

		private void OnAgentDestroyed()
		{
			if (base.gameObject.activeInHierarchy)
			{
				simulator = null;
				rvoAgent = null;
				base.enabled = false;
			}
		}

		protected void UpdateAgentProperties()
		{
			Vector3 localScale = tr.localScale;
			rvoAgent.Radius = Mathf.Max(0.001f, radius * Mathf.Abs(localScale.x));
			rvoAgent.AgentTimeHorizon = agentTimeHorizon;
			rvoAgent.ObstacleTimeHorizon = obstacleTimeHorizon;
			rvoAgent.Locked = locked;
			rvoAgent.MaxNeighbours = maxNeighbours;
			rvoAgent.DebugFlags = debug;
			rvoAgent.Layer = layer;
			rvoAgent.CollidesWith = collidesWith;
			SimpleMovementPlane simpleMovementPlane = movementPlane;
			rvoAgent.MovementPlane = simpleMovementPlane;
			float elevation;
			Vector2 point = simpleMovementPlane.ToPlane((ai != null) ? ai.position : tr.position, out elevation);
			if (movementPlaneMode == MovementPlane.XY)
			{
				rvoAgent.Height = 1f;
				rvoAgent.Position = simpleMovementPlane.ToWorld(point);
			}
			else
			{
				rvoAgent.Height = height * localScale.y;
				rvoAgent.Position = simpleMovementPlane.ToWorld(point, elevation + (center - 0.5f * height) * localScale.y);
			}
			ReachedEndOfPath calculatedEffectivelyReachedDestination = rvoAgent.CalculatedEffectivelyReachedDestination;
			float num = priority * priorityMultiplier;
			float num2 = flowFollowingStrength;
			switch (calculatedEffectivelyReachedDestination)
			{
			case ReachedEndOfPath.Reached:
				num2 = 1f;
				num *= 0.3f;
				break;
			case ReachedEndOfPath.ReachedSoon:
				num2 = 1f;
				num *= 0.45f;
				break;
			}
			rvoAgent.Priority = num;
			rvoAgent.FlowFollowingStrength = num2;
			rvoAgent.SetObstacleQuery(obstacleQuery);
			obstacleQuery = null;
		}

		public void SetTarget(Vector3 pos, float speed, float maxSpeed, Vector3 endOfPath)
		{
			if (rvoAgent != null)
			{
				simulator.BlockUntilSimulationStepDone();
				rvoAgent.SetTarget(pos, speed, maxSpeed, endOfPath);
				if (lockWhenNotMoving)
				{
					locked = speed < 0.001f;
				}
			}
		}

		public void Move(Vector3 velocity)
		{
			if (rvoAgent != null)
			{
				simulator.BlockUntilSimulationStepDone();
				float magnitude = movementPlane.ToPlane(velocity).magnitude;
				rvoAgent.SetTarget(((ai != null) ? ai.position : tr.position) + velocity, magnitude, magnitude, new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity));
				if (lockWhenNotMoving)
				{
					locked = magnitude < 0.001f;
				}
			}
		}

		[Obsolete("Use transform.position instead, the RVOController can now handle that without any issues.")]
		public void Teleport(Vector3 pos)
		{
			tr.position = pos;
		}

		public override void DrawGizmos()
		{
			tr = base.transform;
			if (ai == null)
			{
				Color color = AIBase.ShapeGizmoColor * (locked ? 0.5f : 1f);
				Vector3 vector = base.transform.position;
				Vector3 localScale = tr.localScale;
				if (movementPlaneMode == MovementPlane.XY)
				{
					Draw.WireCylinder(vector, Vector3.forward, 0f, radius * localScale.x, color);
				}
				else
				{
					Draw.WireCylinder(vector + To3D(Vector2.zero, center - height * 0.5f) * localScale.y, To3D(Vector2.zero, 1f), height * localScale.y, radius * localScale.x, color);
				}
			}
		}

		protected override void OnUpgradeSerializedData(ref Migrations migrations, bool unityThread)
		{
			if (migrations.TryMigrateFromLegacyFormat(out var legacyVersion) && legacyVersion > 1)
			{
				migrations.MarkMigrationFinished(0);
			}
			if (migrations.AddAndMaybeRunMigration(0, unityThread))
			{
				if (base.transform.localScale.y != 0f)
				{
					centerBackingField /= Mathf.Abs(base.transform.localScale.y);
				}
				if (base.transform.localScale.y != 0f)
				{
					heightBackingField /= Mathf.Abs(base.transform.localScale.y);
				}
				if (base.transform.localScale.x != 0f)
				{
					radiusBackingField /= Mathf.Abs(base.transform.localScale.x);
				}
			}
		}
	}
}
