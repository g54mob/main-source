using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;

namespace PlayerEquipment
{
	public struct ColliderCacheCD : IComponentData, IQueryTypeParameter
	{
		public NativeParallelHashMap<float3x2, BlobAssetReference<Collider>> sphereColliderCache;

		public NativeParallelHashMap<float3x3, BlobAssetReference<Collider>> boxColliderCache;
	}
}
