using Unity.Burst;
using Unity.Jobs;
using Unity.Mathematics;

namespace DV.PointSet.MeshUtils
{
	[BurstCompile]
	public struct PlaceMeshAtSpanJob : IJob
	{
		public NativeMeshContainer sourceMesh;

		public NativeMeshContainer destMesh;

		public NativeEquiPointSet pointSet;

		public float placementSpan;

		public float skewDistance;

		public bool bendToPointSet;

		public bool mirrorX;

		public float2 offsetPos;

		public PlaceMeshAtSpanJob(NativeMeshContainer sourceMesh, NativeMeshContainer destMesh, NativeEquiPointSet pointSet, float placementSpan, bool bendToPointSet = true, float skewDistance = 0f)
		{
			this.sourceMesh = sourceMesh;
			this.destMesh = destMesh;
			this.pointSet = pointSet;
			this.placementSpan = placementSpan;
			this.bendToPointSet = bendToPointSet;
			this.skewDistance = skewDistance;
			mirrorX = false;
			offsetPos = default(float2);
		}

		public void Execute()
		{
			int length = destMesh.vertices.Length;
			for (int i = 0; i < sourceMesh.vertices.Length; i++)
			{
				NativeMeshContainer.Vertex vert = sourceMesh.vertices[i];
				if (mirrorX)
				{
					vert.normal.x = 0f - vert.normal.x;
					vert.pos.x = 0f - vert.pos.x;
				}
				float z = vert.pos.z;
				float3 position;
				float3 forward;
				float3 up;
				if (bendToPointSet)
				{
					pointSet.Sample(placementSpan + z, out position, out forward, out up);
				}
				else
				{
					pointSet.Sample(placementSpan, out position, out forward, out up);
					position += forward * z;
				}
				quaternion q = quaternion.LookRotation(forward, up);
				float3 float5 = math.cross(up, forward);
				position += float5 * (vert.pos.x + offsetPos.x);
				position += up * (vert.pos.y + offsetPos.y);
				position += forward * skewDistance * vert.pos.x;
				vert.pos = position;
				vert.normal = math.mul(q, vert.normal);
				AddVertex(vert);
			}
			int num = (mirrorX ? 1 : 0);
			for (int j = 0; j < sourceMesh.indices.Length; j += 3)
			{
				destMesh.indices.Add(sourceMesh.indices[j] + length);
				destMesh.indices.Add(sourceMesh.indices[j + 1 + num] + length);
				destMesh.indices.Add(sourceMesh.indices[j + 2 - num] + length);
			}
		}

		private int AddVertex(NativeMeshContainer.Vertex vert)
		{
			int length = destMesh.vertices.Length;
			destMesh.vertices.Add(vert);
			return length;
		}
	}
}
