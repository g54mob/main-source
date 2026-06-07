using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings.Physics
{
	[BurstCompile]
	internal struct EvaluateAndCollectJob : IJob
	{
		public float3x3 wingRotation;

		public float3 wingPosition;

		public float forceScale;

		public NativeArray<WingInputData> wingData;

		[ReadOnly]
		public NativeArray<SliceData> sliceData;

		public NativeArray<SliceAeroData> sliceAero;

		public NativeArray<SlicePolar> slicePolars;

		public NativeArray<ForceJacobian> sliceOutputForces;

		public NativeArray<ForceJacobian> wingOutputForces;

		public float ViscousLiftDragMultiplier;

		public float LiftScale;

		public float ZeroLiftDragScale;

		void IJob.Execute()
		{
			ApplyScaling();
			EvaluateAndCollect();
		}

		public void ApplyScaling()
		{
			if (!math.all(math.float3(LiftScale, ZeroLiftDragScale, ViscousLiftDragMultiplier) == 1f))
			{
				for (int i = 0; i < slicePolars.Length; i++)
				{
					SlicePolar value = slicePolars[i];
					value.liftGradient *= LiftScale;
					value.stallPositive.liftMax *= LiftScale;
					value.stallNegative.liftMax *= LiftScale;
					value.dragCurve.viscousDragDueToLift *= ViscousLiftDragMultiplier;
					value.dragCurve.zeroLiftDrag *= ZeroLiftDragScale;
					slicePolars[i] = value;
				}
			}
		}

		public void EvaluateAndCollect()
		{
			ForceJacobian wingAccumulator = default(ForceJacobian);
			WingInputData wingInput = wingData[0];
			for (int i = 0; i < sliceData.Length; i++)
			{
				SliceData slice = sliceData[i];
				RuntimeFunctions.EvaluatePolar(in wingInput, in slice, slicePolars[i], sliceAero[i], out var sliceOutput);
				sliceOutputForces[i] = sliceOutput;
				RuntimeFunctions.AccumulateSectionForce(ref wingAccumulator, ref sliceOutput, in slice);
			}
			RuntimeFunctions.TransformToBodySpace(ref wingAccumulator, in wingPosition, in wingRotation, forceScale);
			wingOutputForces[0] = wingAccumulator;
		}
	}
}
