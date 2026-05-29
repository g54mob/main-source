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

			public JobDensityCheck(int size, float deltaTime)
			{
				SimulatorBurst simulator = RVOSimulator.active.GetSimulator();
				agentPosition = simulator.simulationData.position;
				agentTargetPoint = simulator.simulationData.targetPoint;
				agentRadius = simulator.simulationData.radius;
				agentDesiredSpeed = simulator.simulationData.desiredSpeed;
				agentOutputTargetPoint = simulator.outputData.targetPoint;
				agentOutputSpeed = simulator.outputData.speed;
				quadtree = simulator.quadtree;
				data = new NativeArray<QueryData>(size, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				outThresholdResult = new NativeArray<bool>(size, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				progressAverage = new NativeArray<float>(size, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				this.deltaTime = deltaTime;
			}

			public void Dispose()
			{
				data.Dispose();
				outThresholdResult.Dispose();
				progressAverage.Dispose();
			}

			public void Set(int index, int rvoAgentIndex, float3 destination, float densityThreshold, float progressAverage)
			{
				data[index] = new QueryData
				{
					agentDestination = destination,
					densityThreshold = densityThreshold,
					agentIndex = rvoAgentIndex
				};
				this.progressAverage[index] = progressAverage;
			}

			void IJobParallelForBatched.Execute(int start, int count)
			{
				for (int i = start; i < start + count; i++)
				{
					Execute(i);
				}
			}

			private float AgentDensityInCircle(float3 position, float radius)
			{
				return quadtree.QueryArea(position, radius) / (radius * radius * MathF.PI);
			}

			private void Execute(int i)
			{
				QueryData queryData = data[i];
				float3 float5 = agentPosition[queryData.agentIndex];
				float num = agentRadius[queryData.agentIndex];
				float3 x = math.normalizesafe(agentTargetPoint[queryData.agentIndex] - float5);
				float x2;
				if (agentDesiredSpeed[queryData.agentIndex] > 0.01f)
				{
					x2 = math.dot(x, math.normalizesafe(agentOutputTargetPoint[queryData.agentIndex] - float5) * agentOutputSpeed[queryData.agentIndex]) / math.max(0.001f, math.min(agentDesiredSpeed[queryData.agentIndex], agentRadius[queryData.agentIndex]));
					x2 = math.clamp(x2, -1f, 1f);
				}
				else
				{
					x2 = 1f;
				}
				progressAverage[i] = math.lerp(progressAverage[i], x2, 2f * deltaTime);
				if (math.any(math.isinf(queryData.agentDestination)))
				{
					outThresholdResult[i] = true;
					return;
				}
				float num2 = math.length(queryData.agentDestination - float5);
				float num3 = num * 5f;
				if (num2 > num3 && AgentDensityInCircle(queryData.agentDestination, num3) < 0.9069f * queryData.densityThreshold)
				{
					outThresholdResult[i] = false;
				}
				else
				{
					outThresholdResult[i] = AgentDensityInCircle(queryData.agentDestination, num2) > 0.9069f * queryData.densityThreshold;
				}
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
			bool flag = jobResult.outThresholdResult[index];
			progressAverage = jobResult.progressAverage[index];
			lastJobDensityResult = flag;
			shouldStopDelayTimer = Mathf.Lerp(shouldStopDelayTimer, flag ? 1 : 0, Time.deltaTime);
			flag = flag && shouldStopDelayTimer > 0.1f;
			lastShouldStopResult = flag;
			lastShouldStopDestination = jobResult.data[index].agentDestination;
		}

		public RVODestinationCrowdedBehavior(bool enabled, float densityFraction, bool returnAfterBeingPushedAway)
		{
			this.enabled = (wasEnabled = enabled);
			densityThreshold = densityFraction;
			this.returnAfterBeingPushedAway = returnAfterBeingPushedAway;
			lastJobDensityResult = false;
			progressAverage = 0f;
			wasStopped = false;
			lastShouldStopDestination = new Vector3(float.NaN, float.NaN, float.NaN);
			reachedDestinationPoint = new Vector3(float.NaN, float.NaN, float.NaN);
			timer1 = 0f;
			shouldStopDelayTimer = 0f;
			reachedDestination = false;
			lastShouldStopResult = false;
		}

		public void ClearDestinationReached()
		{
			wasStopped = false;
			progressAverage = 1f;
			reachedDestination = false;
		}

		public void OnDestinationChanged(Vector3 newDestination, bool reachedDestination)
		{
			timer1 = float.PositiveInfinity;
			this.reachedDestination = reachedDestination;
		}

		public void Update(bool rvoControllerEnabled, bool reachedDestination, ref bool isStopped, ref float rvoPriorityMultiplier, ref float rvoFlowFollowingStrength, Vector3 agentPosition)
		{
			if (!(enabled && rvoControllerEnabled))
			{
				if (wasEnabled)
				{
					wasEnabled = false;
					rvoPriorityMultiplier = 1f;
					rvoFlowFollowingStrength = 0f;
					timer1 = float.PositiveInfinity;
					progressAverage = 1f;
				}
				return;
			}
			wasEnabled = true;
			if (reachedDestination)
			{
				float sqrMagnitude = (agentPosition - reachedDestinationPoint).sqrMagnitude;
				if ((lastShouldStopDestination - reachedDestinationPoint).sqrMagnitude > sqrMagnitude)
				{
					this.reachedDestination = false;
				}
			}
			if (reachedDestination || lastShouldStopResult)
			{
				timer1 = 0f;
				this.reachedDestination = true;
				reachedDestinationPoint = lastShouldStopDestination;
				rvoPriorityMultiplier = Mathf.Lerp(rvoPriorityMultiplier, 0.1f, Time.deltaTime * 2f);
				rvoFlowFollowingStrength = Mathf.Lerp(rvoFlowFollowingStrength, 1f, Time.deltaTime * 4f);
				wasStopped |= math.abs(progressAverage) < 0.1f;
				isStopped |= wasStopped;
			}
			else if (isStopped)
			{
				timer1 = 0f;
				this.reachedDestination = false;
				rvoPriorityMultiplier = Mathf.Lerp(rvoPriorityMultiplier, 0.1f, Time.deltaTime * 2f);
				rvoFlowFollowingStrength = Mathf.Lerp(rvoFlowFollowingStrength, 1f, Time.deltaTime * 4f);
				wasStopped |= math.abs(progressAverage) < 0.1f;
			}
			else if (this.reachedDestination)
			{
				timer1 += Time.deltaTime;
				if (timer1 > 3f && returnAfterBeingPushedAway)
				{
					rvoPriorityMultiplier = Mathf.Lerp(rvoPriorityMultiplier, 0.5f, Time.deltaTime * 2f);
					rvoFlowFollowingStrength = 0f;
					isStopped = false;
					wasStopped = false;
				}
				else
				{
					rvoPriorityMultiplier = Mathf.Lerp(rvoPriorityMultiplier, 0.1f, Time.deltaTime * 2f);
					rvoFlowFollowingStrength = Mathf.Lerp(rvoFlowFollowingStrength, 1f, Time.deltaTime * 4f);
					wasStopped |= math.abs(progressAverage) < 0.1f;
					isStopped = wasStopped;
				}
			}
			else
			{
				rvoPriorityMultiplier = Mathf.Lerp(rvoPriorityMultiplier, 1f, Time.deltaTime * 4f);
				rvoFlowFollowingStrength = 0f;
				isStopped = false;
				wasStopped = false;
			}
		}
	}
}
