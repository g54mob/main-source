using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace AwesomeTechnologies.Utility.Culling
{
	[BurstCompile(CompileSynchronously = true)]
	internal struct BoundingSphereCullJob : IJobParallelFor
	{
		public NativeArray<BoundingSphereInfo> BoundingSphereInfoList;

		[ReadOnly]
		public NativeList<float> DistancesList;

		[ReadOnly]
		public NativeArray<Plane> FrustumPlanes;

		public Vector3 DistanceReferencePoint;

		public bool NoFrustumCulling;

		public bool AddShadowCells;

		public Vector3 FloatingOriginOffset;

		public void Execute(int index)
		{
			BoundingSphereInfo value = BoundingSphereInfoList[index];
			value.BoundingSphere.position += FloatingOriginOffset;
			if (value.Enabled == 0)
			{
				return;
			}
			value.Visibility = (NoFrustumCulling ? 1 : SphereInFrustum(value.BoundingSphere));
			float num = math.distance(value.BoundingSphere.position, DistanceReferencePoint);
			value.CurrentDistanceBand = -1;
			for (int i = 0; i <= DistancesList.Length - 1; i++)
			{
				if (num < DistancesList[i])
				{
					value.CurrentDistanceBand = i;
					break;
				}
			}
			AddShadowCells = true;
			if (AddShadowCells && !NoFrustumCulling && value.Visibility == -1 && value.CurrentDistanceBand == 0)
			{
				value.Visibility = 1;
				value.CurrentDistanceBand = 1;
			}
			if (value.CurrentDistanceBand == -1)
			{
				value.Visibility = -1;
			}
			value.BoundingSphere.position -= FloatingOriginOffset;
			BoundingSphereInfoList[index] = value;
		}

		private int SphereInFrustum(BoundingSphere boundingSphere)
		{
			for (int i = 0; i <= FrustumPlanes.Length - 1; i++)
			{
				if (FrustumPlanes[i].normal.x * boundingSphere.position.x + FrustumPlanes[i].normal.y * boundingSphere.position.y + FrustumPlanes[i].normal.z * boundingSphere.position.z + FrustumPlanes[i].distance < 0f - boundingSphere.radius)
				{
					return -1;
				}
			}
			return 1;
		}
	}
}
