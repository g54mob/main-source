using AwesomeTechnologies.Utility.BVHTree;
using Unity.Collections;

namespace AwesomeTechnologies.MeshTerrains
{
	public struct BVHRaycastContainer
	{
		public NativeArray<HitInfo> RaycastHits;

		public NativeList<HitInfo> RaycastHitList;

		public NativeArray<BVHRay> Rays;

		public NativeArray<HitInfo> TempHi;
	}
}
