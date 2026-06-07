using DV.PointSet;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace DV
{
	[BurstCompile]
	public struct PlaceSleepersAppendJob : IJob
	{
		[WriteOnly]
		public NativeList<float> indirectData;

		[WriteOnly]
		public NativeList<Vector3> allPositions;

		[ReadOnly]
		[DeallocateOnJobCompletion]
		private NativeArray<Vector3> positions;

		[DeallocateOnJobCompletion]
		[ReadOnly]
		private NativeArray<Vector3> forwards;

		[DeallocateOnJobCompletion]
		[ReadOnly]
		private NativeArray<Vector3> ups;

		private int randomizeSleeperOrientation;

		private float sleeperVerticalOffset;

		private const float randomizeXPos = 0.05f;

		private const string PROF_ctor = "PlaceSleepersJob constructor";

		public PlaceSleepersAppendJob(NativeList<float> indirectData, NativeList<Vector3> allPositions, EquiPointSet pSet, int fromIndex, int toIndex, bool randomizeSleeperOrientation, float sleeperVerticalOffset)
		{
			this.indirectData = indirectData;
			this.allPositions = allPositions;
			this.randomizeSleeperOrientation = (randomizeSleeperOrientation ? 1 : 0);
			this.sleeperVerticalOffset = sleeperVerticalOffset;
			int num = toIndex - fromIndex + 1;
			positions = new NativeArray<Vector3>(num, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
			forwards = new NativeArray<Vector3>(num, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
			ups = new NativeArray<Vector3>(num, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
			for (int i = 0; i < num; i++)
			{
				EquiPointSet.Point point = pSet.points[i + fromIndex];
				positions[i] = (Vector3)point.position;
				forwards[i] = point.forward;
				ups[i] = point.up;
			}
		}

		public void Execute()
		{
			new Vector3(1.7f, 1.7f, 1.7f);
			for (int i = 0; i < positions.Length; i++)
			{
				Vector3 vector = positions[i];
				Vector3 vector2 = forwards[i];
				Vector3 upwards = ups[i];
				Quaternion quaternion = Quaternion.LookRotation((randomizeSleeperOrientation != 0 && (int)(vector.x * 100f) % 2 == 0) ? vector2 : (-vector2), upwards);
				Vector3 vector3 = Vector3.up * sleeperVerticalOffset;
				Matrix4x4 matrix4x = Matrix4x4.TRS(vector + quaternion * vector3, quaternion, Vector3.one);
				indirectData.Add(matrix4x.m00);
				indirectData.Add(matrix4x.m01);
				indirectData.Add(matrix4x.m02);
				indirectData.Add(matrix4x.m03);
				indirectData.Add(matrix4x.m10);
				indirectData.Add(matrix4x.m11);
				indirectData.Add(matrix4x.m12);
				indirectData.Add(matrix4x.m13);
				indirectData.Add(matrix4x.m20);
				indirectData.Add(matrix4x.m21);
				indirectData.Add(matrix4x.m22);
				indirectData.Add(matrix4x.m23);
				allPositions.Add(vector);
			}
		}
	}
}
