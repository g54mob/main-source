using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Craft.Wings
{
	public struct ColliderInfo
	{
		public MeshCollider Collider;

		public float3 RootSlicePos;

		public float3 TipSlicePos;

		public float2 SpanPositionRange;
	}
}
