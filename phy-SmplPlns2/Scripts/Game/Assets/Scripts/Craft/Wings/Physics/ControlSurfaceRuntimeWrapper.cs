using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Wings.Runtime;
using Unity.Collections;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings.Physics
{
	public struct ControlSurfaceRuntimeWrapper
	{
		private int _controlCount;

		private int _controlStart;

		private float _firstSliceCoverage;

		private float _lastSliceCoverage;

		private int _sliceCount;

		private int _sliceStart;

		private int _transformCount;

		private int _transformStart;

		private ControlSurfaceRuntimeUpdateFunction _updateFunction;

		public static ControlSurfaceRuntimeWrapper Create(IControlSurfaceRuntimeData data, List<IntPtr> mallocPtrs, int sliceStart, int sliceCount, int controlStart, int controlCount, int transformStart, int transformCount, float firstSliceCoverage, float lastSliceCoverage)
		{
			return new ControlSurfaceRuntimeWrapper
			{
				_updateFunction = data.GetUpdateFunction(mallocPtrs),
				_sliceStart = sliceStart,
				_sliceCount = sliceCount,
				_controlStart = controlStart,
				_controlCount = controlCount,
				_transformStart = transformStart,
				_transformCount = transformCount,
				_firstSliceCoverage = firstSliceCoverage,
				_lastSliceCoverage = lastSliceCoverage
			};
		}

		public readonly void Update(float deltaTime, bool flipped, NativeArray<RigidTransform> surfaceTransforms, NativeArray<RigidTransform> baseTransforms, NativeArray<RigidTransform> inverseBaseTransforms, NativeArray<float> controls, NativeArray<SliceData> sliceData, NativeArray<SliceAeroData> sliceAero, NativeArray<SlicePolar> slicePolar)
		{
			ControlSurfaceRuntimeArgs args = new ControlSurfaceRuntimeArgs
			{
				dt = deltaTime,
				firstSliceCoverage = _firstSliceCoverage,
				lastSliceCoverage = _lastSliceCoverage,
				transforms = surfaceTransforms.Slice(_transformStart, _transformCount),
				baseTransforms = baseTransforms.Slice(_transformStart, _transformCount),
				inverseBaseTransforms = inverseBaseTransforms.Slice(_transformStart, _transformCount),
				controls = controls.Slice(_controlStart, _controlCount),
				sliceData = sliceData.Slice(_sliceStart, _sliceCount),
				sliceAero = sliceAero.Slice(_sliceStart, _sliceCount),
				slicePolar = slicePolar.Slice(_sliceStart, _sliceCount)
			};
			_updateFunction.Invoke(ref args);
		}
	}
}
