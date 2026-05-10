using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding.RVO.Sampled
{
	public class Agent : IAgent
	{
		internal struct VO
		{
			private Vector2 line1;

			private Vector2 line2;

			private Vector2 dir1;

			private Vector2 dir2;

			private Vector2 cutoffLine;

			private Vector2 cutoffDir;

			private Vector2 circleCenter;

			private bool colliding;

			private float radius;

			private float weightFactor;

			private float weightBonus;

			private Vector2 segmentStart;

			private Vector2 segmentEnd;

			private bool segment;

			public VO(Vector2 center, Vector2 offset, float radius, float inverseDt, float inverseDeltaTime)
			{
				line1 = default(Vector2);
				line2 = default(Vector2);
				dir1 = default(Vector2);
				dir2 = default(Vector2);
				cutoffLine = default(Vector2);
				cutoffDir = default(Vector2);
				circleCenter = default(Vector2);
				colliding = false;
				this.radius = 0f;
				weightFactor = 0f;
				weightBonus = 0f;
				segmentStart = default(Vector2);
				segmentEnd = default(Vector2);
				segment = false;
			}

			public static VO SegmentObstacle(Vector2 segmentStart, Vector2 segmentEnd, Vector2 offset, float radius, float inverseDt, float inverseDeltaTime)
			{
				return default(VO);
			}

			public static float SignedDistanceFromLine(Vector2 a, Vector2 dir, Vector2 p)
			{
				return 0f;
			}

			public Vector2 ScaledGradient(Vector2 p, out float weight)
			{
				weight = default(float);
				return default(Vector2);
			}

			public Vector2 Gradient(Vector2 p, out float weight)
			{
				weight = default(float);
				return default(Vector2);
			}
		}

		internal class VOBuffer
		{
			public VO[] buffer;

			public int length;

			public void Clear()
			{
			}

			public VOBuffer(int n)
			{
			}

			public void Add(VO vo)
			{
			}
		}

		internal float radius;

		internal float height;

		internal float desiredSpeed;

		internal float maxSpeed;

		internal float agentTimeHorizon;

		internal float obstacleTimeHorizon;

		internal bool locked;

		private RVOLayer layer;

		private RVOLayer collidesWith;

		private int maxNeighbours;

		internal Vector2 position;

		private float elevationCoordinate;

		private Vector2 currentVelocity;

		private Vector2 desiredTargetPointInVelocitySpace;

		private Vector2 desiredVelocity;

		private Vector2 nextTargetPoint;

		private float nextDesiredSpeed;

		private float nextMaxSpeed;

		private Vector2 collisionNormal;

		private bool manuallyControlled;

		private bool debugDraw;

		internal Agent next;

		private float calculatedSpeed;

		private Vector2 calculatedTargetPoint;

		internal Simulator simulator;

		private List<Agent> neighbours;

		private List<float> neighbourDists;

		private List<ObstacleVertex> obstaclesBuffered;

		private List<ObstacleVertex> obstacles;

		private const float DesiredVelocityWeight = 0.1f;

		private const float WallWeight = 5f;

		public Vector2 Position { get; set; }

		public float ElevationCoordinate { get; set; }

		public Vector2 CalculatedTargetPoint { get; private set; }

		public float CalculatedSpeed { get; private set; }

		public bool Locked { get; set; }

		public float Radius { get; set; }

		public float Height { get; set; }

		public float AgentTimeHorizon { get; set; }

		public float ObstacleTimeHorizon { get; set; }

		public int MaxNeighbours { get; set; }

		public int NeighbourCount { get; private set; }

		public RVOLayer Layer { get; set; }

		public RVOLayer CollidesWith { get; set; }

		public bool DebugDraw
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float Priority { get; set; }

		public Action PreCalculationCallback { private get; set; }

		public List<ObstacleVertex> NeighbourObstacles => null;

		public void SetTarget(Vector2 targetPoint, float desiredSpeed, float maxSpeed)
		{
		}

		public void SetCollisionNormal(Vector2 normal)
		{
		}

		public void ForceSetVelocity(Vector2 velocity)
		{
		}

		public Agent(Vector2 pos, float elevationCoordinate)
		{
		}

		public void BufferSwitch()
		{
		}

		public void PreCalculation()
		{
		}

		public void PostCalculation()
		{
		}

		public void CalculateNeighbours()
		{
		}

		private static float Sqr(float x)
		{
			return 0f;
		}

		internal float InsertAgentNeighbour(Agent agent, float rangeSq)
		{
			return 0f;
		}

		private static Vector3 FromXZ(Vector2 p)
		{
			return default(Vector3);
		}

		private static Vector2 ToXZ(Vector3 p)
		{
			return default(Vector2);
		}

		private Vector2 To2D(Vector3 p, out float elevation)
		{
			elevation = default(float);
			return default(Vector2);
		}

		private static void DrawVO(Vector2 circleCenter, float radius, Vector2 origin)
		{
		}

		internal void CalculateVelocity(Simulator.WorkerContext context)
		{
		}

		private static Color Rainbow(float v)
		{
			return default(Color);
		}

		private void GenerateObstacleVOs(VOBuffer vos)
		{
		}

		private void GenerateNeighbourAgentVOs(VOBuffer vos)
		{
		}

		private Vector2 GradientDescent(VOBuffer vos, Vector2 sampleAround1, Vector2 sampleAround2)
		{
			return default(Vector2);
		}

		private static bool BiasDesiredVelocity(VOBuffer vos, ref Vector2 desiredVelocity, ref Vector2 targetPointInVelocitySpace, float maxBiasRadians)
		{
			return false;
		}

		private Vector2 EvaluateGradient(VOBuffer vos, Vector2 p, out float value)
		{
			value = default(float);
			return default(Vector2);
		}

		private Vector2 Trace(VOBuffer vos, Vector2 p, out float score)
		{
			score = default(float);
			return default(Vector2);
		}
	}
}
