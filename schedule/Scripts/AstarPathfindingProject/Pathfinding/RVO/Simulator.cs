using System;
using System.Collections.Generic;
using System.Threading;
using Pathfinding.RVO.Sampled;
using UnityEngine;

namespace Pathfinding.RVO
{
	public class Simulator
	{
		internal class WorkerContext
		{
			public Agent.VOBuffer vos;

			public const int KeepCount = 3;

			public Vector2[] bestPos;

			public float[] bestSizes;

			public float[] bestScores;

			public Vector2[] samplePos;

			public float[] sampleSize;
		}

		private class Worker
		{
			public int start;

			public int end;

			private readonly ManualResetEventSlim runFlag;

			private readonly ManualResetEventSlim waitFlag;

			private readonly Simulator simulator;

			private int task;

			private bool terminate;

			private WorkerContext context;

			public Worker(Simulator sim)
			{
			}

			public void Execute(int task)
			{
			}

			public void WaitOne()
			{
			}

			public void Terminate()
			{
			}

			public void Run()
			{
			}
		}

		private readonly bool doubleBuffering;

		private float desiredDeltaTime;

		private readonly Worker[] workers;

		private List<Agent> agents;

		public List<ObstacleVertex> obstacles;

		private float deltaTime;

		private float lastStep;

		private bool doUpdateObstacles;

		private bool doCleanObstacles;

		public float symmetryBreakingBias;

		public readonly MovementPlane movementPlane;

		private WorkerContext coroutineWorkerContext;

		public RVOQuadtree Quadtree { get; private set; }

		public float DeltaTime => 0f;

		public bool Multithreading => false;

		public float DesiredDeltaTime
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public List<Agent> GetAgents()
		{
			return null;
		}

		public List<ObstacleVertex> GetObstacles()
		{
			return null;
		}

		public Simulator(int workers, bool doubleBuffering, MovementPlane movementPlane)
		{
		}

		public void ClearAgents()
		{
		}

		public void OnDestroy()
		{
		}

		public IAgent AddAgent(IAgent agent)
		{
			return null;
		}

		[Obsolete("Use AddAgent(Vector2,float) instead")]
		public IAgent AddAgent(Vector3 position)
		{
			return null;
		}

		public IAgent AddAgent(Vector2 position, float elevationCoordinate)
		{
			return null;
		}

		public void RemoveAgent(IAgent agent)
		{
		}

		public ObstacleVertex AddObstacle(ObstacleVertex v)
		{
			return null;
		}

		public ObstacleVertex AddObstacle(Vector3[] vertices, float height, bool cycle = true)
		{
			return null;
		}

		public ObstacleVertex AddObstacle(Vector3[] vertices, float height, Matrix4x4 matrix, RVOLayer layer = RVOLayer.DefaultObstacle, bool cycle = true)
		{
			return null;
		}

		public ObstacleVertex AddObstacle(Vector3 a, Vector3 b, float height)
		{
			return null;
		}

		public void UpdateObstacle(ObstacleVertex obstacle, Vector3[] vertices, Matrix4x4 matrix)
		{
		}

		private void ScheduleCleanObstacles()
		{
		}

		private void CleanObstacles()
		{
		}

		public void RemoveObstacle(ObstacleVertex v)
		{
		}

		public void UpdateObstacles()
		{
		}

		private void BuildQuadtree()
		{
		}

		private void BlockUntilSimulationStepIsDone()
		{
		}

		private void PreCalculation()
		{
		}

		private void CleanAndUpdateObstaclesIfNecessary()
		{
		}

		public void Update()
		{
		}
	}
}
