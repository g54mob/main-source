using AwesomeTechnologies.VegetationSystem;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace AwesomeTechnologies.Utility
{
	[BurstCompile]
	public struct AddInstancesJob : IJob
	{
		public NativeList<ItemSelectorInstanceInfo> InstanceList;

		public NativeList<MatrixInstance> MatrixInstanceList;

		public int VegetationCellIndex;

		public void Execute()
		{
			for (int num = MatrixInstanceList.Length - 1; num >= 0; num--)
			{
				MatrixInstance matrixInstance = MatrixInstanceList[num];
				ItemSelectorInstanceInfo value = new ItemSelectorInstanceInfo
				{
					VegetationCellIndex = VegetationCellIndex,
					VegetationCellItemIndex = num,
					Position = ExtractTranslationFromMatrix(matrixInstance.Matrix),
					Scale = ExtractScaleFromMatrix(matrixInstance.Matrix),
					Rotation = ExtractRotationFromMatrix(matrixInstance.Matrix),
					LastVisible = -1,
					Visible = -1
				};
				InstanceList.Add(value);
			}
		}

		private static float3 ExtractTranslationFromMatrix(Matrix4x4 matrix)
		{
			float3 result = default(float3);
			result.x = matrix.m03;
			result.y = matrix.m13;
			result.z = matrix.m23;
			return result;
		}

		private static Quaternion ExtractRotationFromMatrix(Matrix4x4 matrix)
		{
			Vector3 vector = default(Vector3);
			vector.x = matrix.m02;
			vector.y = matrix.m12;
			vector.z = matrix.m22;
			if (vector == Vector3.zero)
			{
				return Quaternion.identity;
			}
			Vector3 upwards = default(Vector3);
			upwards.x = matrix.m01;
			upwards.y = matrix.m11;
			upwards.z = matrix.m21;
			return Quaternion.LookRotation(vector, upwards);
		}

		private static float3 ExtractScaleFromMatrix(Matrix4x4 matrix)
		{
			return new float3(matrix.GetColumn(0).magnitude, matrix.GetColumn(1).magnitude, matrix.GetColumn(2).magnitude);
		}
	}
}
