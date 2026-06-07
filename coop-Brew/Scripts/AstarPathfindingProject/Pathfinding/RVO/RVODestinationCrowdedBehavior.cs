using System;
using Pathfinding.Jobs;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.RVO
{
	[Serializable]
	public struct RVODestinationCrowdedBehavior
	{
		[BurstCompile(CompileSynchronously = false, FloatMode = FloatMode.Fast)]
		public struct JobDensityCheck : IJobParallelForBatched
		{
			public struct QueryData
			{
				public float3 agentDestination;

				public int agentIndex;

				public float densityThreshold;
			}

			[ReadOnly]
			private RVOQuadtreeBurst quadtree;

			[ReadOnly]
			public NativeArray<QueryData> data;

			[ReadOnly]
			public NativeArray<float3> agentPosition;

			[ReadOnly]
			private NativeArray<float3> agentTargetPoint;

			[ReadOnly]
			private NativeArray<float> agentRadius;

			[ReadOnly]
			private NativeArray<float> agentDesiredSpeed;

			[ReadOnly]
			private NativeArray<float3> agentOutputTargetPoint;

			[ReadOnly]
			private NativeArray<float> agentOutputSpeed;

			[WriteOnly]
			public NativeArray<bool> outThresholdResult;

			public NativeArray<float> progressAverage;

			public float deltaTime;

			public bool allowBoundsChecks => false;

			public JobDensityCheck(int size, float deltaTime, SimulatorBurst simulator)
			{
				quadtree = default(RVOQuadtreeBurst);
				data = default(NativeArray<QueryData>);
				agentPosition = default(NativeArray<float3>);
				agentTargetPoint = default(NativeArray<float3>);
				agentRadius = default(NativeArray<float>);
				agentDesiredSpeed = default(NativeArray<float>);
				agentOutputTargetPoint = default(NativeArray<float3>);
				agentOutputSpeed = default(NativeArray<float>);
				outThresholdResult = default(NativeArray<bool>);
				progressAverage = default(NativeArray<float>);
				this.deltaTime = 0f;
			}

			public void Dispose()
			{
			}

			public void Set(int index, int rvoAgentIndex, float3 destination, float densityThreshold, float progressAverage)
			{
			}

			void IJobParallelForBatched.Execute(int start, int count)
			{
			}

			private float AgentDensityInCircle(float3 position, float radius)
			{
				return 0f;
			}

			private void Execute(int i)
			{
			}
		}

		public bool enabled;

		[Range(0f, 1f)]
		public float densityThreshold;

		public bool returnAfterBeingPushedAway;

		public float progressAverage;

		private bool wasEnabled;

		private float timer1;

		private float shouldStopDelayTimer;

		private bool lastShouldStopResult;

		private Vector3 lastShouldStopDestination;

		private Vector3 reachedDestinationPoint;

		public bool lastJobDensityResult;

		private const float MaximumCirclePackingDensity = 0.9069f;

		private bool wasStopped;

		private const float DefaultPriority = 1f;

		private const float StoppedPriority = 0.1f;

		private const float MoveBackPriority = 0.5f;

		public bool reachedDestination { get; private set; }

		public void ReadJobResult(ref JobDensityCheck jobResult, int index)
		{
		}

		public RVODestinationCrowdedBehavior(bool enabled, float densityFraction, bool returnAfterBeingPushedAway)
		{
			this.enabled = false;
			densityThreshold = 0f;
			this.returnAfterBeingPushedAway = false;
			progressAverage = 0f;
			wasEnabled = false;
			timer1 = 0f;
			shouldStopDelayTimer = 0f;
			lastShouldStopResult = false;
			lastShouldStopDestination = default(Vector3);
			reachedDestinationPoint = default(Vector3);
			lastJobDensityResult = false;
			reachedDestination = false;
			wasStopped = false;
		}

		public void ClearDestinationReached()
		{
		}

		public void OnDestinationChanged(Vector3 newDestination, bool reachedDestination)
		{
		}

		public void Update(bool rvoControllerEnabled, bool reachedDestination, ref bool isStopped, ref float rvoPriorityMultiplier, ref float rvoFlowFollowingStrength, Vector3 agentPosition)
		{
		}
	}
}
