using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Jobs;

namespace GPUInstancerPro.PrefabModule
{
	[BurstCompile]
	internal struct GPUIAutoUpdateTransformsJob : IJobParallelForTransform
	{
		[ReadOnly]
		public int instanceCount;

		[ReadOnly]
		public Matrix4x4 zeroMatrix;

		[NativeDisableUnsafePtrRestriction]
		internal unsafe void* p_matrixArray;

		[NativeDisableUnsafePtrRestriction]
		internal unsafe void* p_isModifiedArray;

		public unsafe void Execute(int index, TransformAccess transform)
		{
			if (index >= instanceCount)
			{
				return;
			}
			Matrix4x4 b = UnsafeUtility.ReadArrayElementWithStride<Matrix4x4>(p_matrixArray, index, 64);
			if (transform.isValid)
			{
				Matrix4x4 localToWorldMatrix = transform.localToWorldMatrix;
				if (!GPUIUtility.EqualsMatrix4x4(localToWorldMatrix, b))
				{
					UnsafeUtility.WriteArrayElementWithStride(p_isModifiedArray, index, 4, 1);
					UnsafeUtility.WriteArrayElementWithStride(p_matrixArray, index, 64, localToWorldMatrix);
				}
				else
				{
					UnsafeUtility.WriteArrayElementWithStride(p_isModifiedArray, index, 4, 0);
				}
			}
			else if (!GPUIUtility.EqualsMatrix4x4(zeroMatrix, b))
			{
				UnsafeUtility.WriteArrayElementWithStride(p_isModifiedArray, index, 4, 1);
				UnsafeUtility.WriteArrayElementWithStride(p_matrixArray, index, 64, zeroMatrix);
			}
			else
			{
				UnsafeUtility.WriteArrayElementWithStride(p_isModifiedArray, index, 4, 0);
			}
		}
	}
}
