using Unity.Burst;
using Unity.Jobs;
using Unity.Mathematics;

namespace DV.PointSet.MeshUtils
{
	[BurstCompile]
	public struct RampEdgesAtSpanJob : IJob
	{
		public NativeMeshContainer mesh;

		public NativeEquiPointSet pointSet;

		public float startSpan;

		public float endSpan;

		public float dropPerMeters;

		public float4x4 meshToWorld;

		public float4x4 worldToMesh;

		public void Execute()
		{
			for (int i = 0; i < mesh.vertices.Length; i++)
			{
				NativeMeshContainer.Vertex value = mesh.vertices[i];
				float3 xyz = math.mul(meshToWorld, new float4(value.pos, 1f)).xyz;
				float spanAtPos = GetSpanAtPos(xyz);
				float num = ((spanAtPos > endSpan) ? (spanAtPos - endSpan) : ((spanAtPos < startSpan) ? (startSpan - spanAtPos) : 0f));
				xyz.y -= num * dropPerMeters;
				value.pos = math.mul(worldToMesh, new float4(xyz, 1f)).xyz;
				mesh.vertices[i] = value;
			}
		}

		private float GetSpanAtPos(float3 position)
		{
			int num = -1;
			float num2 = float.PositiveInfinity;
			for (int i = 0; i < pointSet.positions.Length; i++)
			{
				float num3 = math.distancesq(pointSet.positions[i], position);
				if (num3 < num2)
				{
					num2 = num3;
					num = i;
				}
			}
			if (num == 0 && math.dot(pointSet.forwards[0], position - pointSet.positions[0]) < 0f)
			{
				return math.mul(math.inverse(quaternion.LookRotation(pointSet.forwards[0], pointSet.ups[0])), position - pointSet.positions[0]).z;
			}
			int num4 = pointSet.positions.Length - 1;
			if (num == num4 && math.dot(pointSet.forwards[num4], position - pointSet.positions[num4]) > (float)num4)
			{
				quaternion q = quaternion.LookRotation(pointSet.forwards[num4], pointSet.ups[num4]);
				return pointSet.Span + math.mul(math.inverse(q), position - pointSet.positions[num4]).z;
			}
			return pointSet.spans[num];
		}
	}
}
