using System;
using Unity.Collections;
using Unity.Core;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine.Scripting;

namespace Pathfinding.ECS
{
	[UpdateAfter(typeof(TransformSystemGroup))]
	public class AIMovementSystemGroup : ComponentSystemGroup
	{
		public class TimeScaledRateManager : IRateManager, IDisposable
		{
			private int numUpdatesThisFrame;

			private int updateIndex;

			private float stepDt;

			private float maximumDt;

			private float ownProcessingTimePerIteration;

			private NativeList<TimeData> cheapTimeDataQueue;

			private NativeList<TimeData> timeDataQueue;

			private double lastFullSimulation;

			private double lastCheapSimulation;

			private static bool cheapSimulationOnly;

			private static bool isLastSubstep;

			private static bool isFirstSubstep;

			private static bool inGroup;

			private static TimeData cheapTimeData;

			public double CustomTimeScale;

			public static bool CheapSimulationOnly => false;

			public static float CheapStepDeltaTime => 0f;

			public static bool IsLastSubstep => false;

			public static bool IsFirstSubstep => false;

			public int NumUpdatesThisFrame => 0;

			public float Timestep
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public void Dispose()
			{
			}

			public void OnSimulationStepsFinished(float totalSimulationProcessingTime)
			{
			}

			public bool ShouldGroupUpdate(ComponentSystemGroup group)
			{
				return false;
			}
		}

		public double CustomTimeScale
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		[Preserve]
		protected override void OnUpdate()
		{
		}

		[Preserve]
		protected override void OnDestroy()
		{
		}

		[Preserve]
		protected override void OnCreate()
		{
		}

		[Preserve]
		public AIMovementSystemGroup()
		{
		}
	}
}
