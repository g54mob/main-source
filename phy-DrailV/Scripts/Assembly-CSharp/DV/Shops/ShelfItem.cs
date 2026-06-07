using Unity.Mathematics;
using UnityEngine;

namespace DV.Shops
{
	public class ShelfItem : MonoBehaviour
	{
		public float2 size = new float2(0.1f, 0.387f);

		public float height = 0.1f;

		public float Width => size.x;

		public float Depth => size.y;

		private void Awake()
		{
			BoxCollider boxCollider = base.gameObject.AddComponent<BoxCollider>();
			boxCollider.center = new float3(0f, height * 0.5f, size.y * -0.5f);
			boxCollider.size = new float3(size.x, height, size.y);
		}

		private void Place()
		{
			Object.FindObjectOfType<ShelfPlacer>().TryPlaceOnAnyShelf(this, new Unity.Mathematics.Random(123u));
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.matrix = base.transform.localToWorldMatrix;
			Gizmos.DrawCube(new float3(0f, height * 0.5f, size.y * -0.5f), new float3(size.x, height, size.y));
		}
	}
}
