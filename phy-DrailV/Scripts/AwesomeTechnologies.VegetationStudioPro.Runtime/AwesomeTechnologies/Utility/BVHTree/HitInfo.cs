using Unity.Mathematics;

namespace AwesomeTechnologies.Utility.BVHTree
{
	public struct HitInfo
	{
		public float3 HitPoint;

		public float3 HitNormal;

		public float HitDistance;

		public byte TerrainSourceID;

		public HitInfo(HitInfo hitInfo)
		{
			HitPoint = hitInfo.HitPoint;
			HitNormal = hitInfo.HitNormal;
			HitDistance = hitInfo.HitDistance;
			TerrainSourceID = hitInfo.TerrainSourceID;
		}

		public void Clear()
		{
			HitDistance = float.MaxValue;
		}
	}
}
