using Assets.Scripts.Craft.Wings.Physics;
using Unity.Collections;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings.Runtime
{
	public struct ControlSurfaceRuntimeArgs
	{
		public float dt;

		public float firstSliceCoverage;

		public float lastSliceCoverage;

		[ReadOnly]
		public NativeSlice<float> controls;

		public NativeSlice<RigidTransform> baseTransforms;

		public NativeSlice<RigidTransform> inverseBaseTransforms;

		public NativeSlice<RigidTransform> transforms;

		[ReadOnly]
		public NativeSlice<SliceData> sliceData;

		public NativeSlice<SliceAeroData> sliceAero;

		public NativeSlice<SlicePolar> slicePolar;

		public readonly int SliceCount => sliceData.Length;

		public float Coverage(int sliceIndex)
		{
			if (sliceIndex != 0)
			{
				if (sliceIndex != sliceData.Length - 1)
				{
					return 1f;
				}
				return lastSliceCoverage;
			}
			return firstSliceCoverage;
		}

		public RigidTransform ConvertDeflectionToWingspace(int meshIndex, RigidTransform deflection)
		{
			deflection = math.mul(baseTransforms[meshIndex], math.mul(deflection, inverseBaseTransforms[meshIndex]));
			return deflection;
		}

		public RigidTransform ConvertDeflectionFromWingspace(int meshIndex, RigidTransform deflection)
		{
			return math.mul(inverseBaseTransforms[meshIndex], math.mul(deflection, baseTransforms[meshIndex]));
		}
	}
}
