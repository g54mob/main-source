using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings.Physics
{
	[BurstCompile]
	internal struct GeneratePolarsJob : IJob
	{
		public float deltaTime;

		public bool wingFlipped;

		public NativeArray<WingInputData> wingData;

		public NativeArray<ControlSurfaceRuntimeWrapper> controlSurfaces;

		public NativeArray<RigidTransform> baseTransforms;

		public NativeArray<RigidTransform> inverseBaseTransforms;

		public NativeArray<RigidTransform> surfaceTransforms;

		public NativeArray<float> controls;

		[ReadOnly]
		public NativeArray<SliceData> sliceData;

		public NativeArray<SliceAeroData> sliceAero;

		public NativeArray<SlicePolar> slicePolars;

		public float ViscousLiftDragMultiplier;

		public float LiftScale;

		public float ZeroLiftDragScale;

		void IJob.Execute()
		{
			GeneratePolars();
			ApplyControlSurfaces();
		}

		public void GeneratePolars()
		{
			WingInputData data = wingData[0];
			RuntimeFunctions.CalculateAtmosphere(ref data);
			wingData[0] = data;
			for (int i = 0; i < sliceData.Length; i++)
			{
				SliceData slice = sliceData[i];
				RuntimeFunctions.FillAeroData(in data, in slice, out var res);
				RuntimeFunctions.EvaluateAirfoil(in slice, in res, out var polar);
				sliceAero[i] = res;
				slicePolars[i] = polar;
			}
		}

		public void ApplyControlSurfaces()
		{
			for (int i = 0; i < controlSurfaces.Length; i++)
			{
				controlSurfaces[i].Update(deltaTime, wingFlipped, surfaceTransforms, baseTransforms, inverseBaseTransforms, controls, sliceData, sliceAero, slicePolars);
			}
		}
	}
}
