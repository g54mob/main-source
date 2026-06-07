using System;
using JetBrains.Annotations;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Profiling;
using Zenject;

namespace VampireSurvivors.Framework
{
	[UsedImplicitly]
	public class EnemiesManager : GameTickable, IInitializable, IDisposable
	{
		[BurstCompile]
		private struct EnemyVelocityCalcJob : IJobParallelFor
		{
			public NativeArray<float3> _positionArray;

			public NativeArray<float3> _velocityArray;

			public NativeArray<float> _speedArray;

			public NativeArray<bool> _fixedDirectionArray;

			public NativeArray<float3> _currentDirectionArray;

			public NativeArray<float3> _targetArray;

			public bool _isPaused;

			public void Execute(int index)
			{
			}

			private void HandleTargetVelocityCalc(int index)
			{
			}
		}

		[Inject]
		private GameManager _gameManager;

		private static readonly ProfilerMarker s_onTickMarker;

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		protected override void OnTick()
		{
		}

		private void RunMovementJob()
		{
		}
	}
}
