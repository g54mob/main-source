using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace Gh.Tk
{
	[BurstCompile]
	public struct AtmosphereCalculationJob : IJobParallelFor
	{
		public NativeArray<float> _writeBuffer;

		[ReadOnly]
		public NativeArray<float> _readBuffer;

		[ReadOnly]
		public NativeArray<Neighbours> neighbours;

		[ReadOnly]
		public NativeArray<sbyte> outputs;

		[ReadOnly]
		public NativeArray<sbyte> equilibriumValues;

		[ReadOnly]
		public NativeArray<float> passThroughFactors;

		public float loss;

		[ReadOnly]
		public SampledAnimationCurve curve;

		public float flowFactor;

		private const float NegativeRange = 10f;

		public float equilibriumBlend;

		private const float _epsilon = 1E-06f;

		public void Execute(int index)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private float TransferFromNeighbour(float value, float ourEquilibrium, NeighbourInfo neighbour)
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private float ApplyLoss(float value, sbyte equilibrium)
		{
			return 0f;
		}
	}
}
