using System;
using UnityEngine;

namespace Brewery.ZoneDecorator
{
	[ExecuteInEditMode]
	public class DecorationZone : MonoBehaviour
	{
		[Header("Zone Configuration")]
		[Tooltip("What type of zone is this?")]
		public ZoneType zoneType;

		[Tooltip("Size of the zone (if no BoxCollider)")]
		public Vector3 size;

		[Tooltip("Override density for this specific zone (-1 = use default)")]
		[Range(-1f, 100f)]
		public int densityOverride;

		[Tooltip("Override bundle chance for this zone (-1 = use default)")]
		[Range(-1f, 1f)]
		public float bundleChanceOverride;

		[Header("Runtime")]
		[Tooltip("Has this zone been populated?")]
		[HideInInspector]
		public bool isPopulated;

		[Tooltip("Number of items spawned in this zone")]
		[HideInInspector]
		public int spawnedCount;

		private BoxCollider _boxCollider;

		public Bounds GetWorldBounds()
		{
			return default(Bounds);
		}

		public Vector3 GetRandomPointInZone(System.Random rng)
		{
			return default(Vector3);
		}

		public bool ContainsPoint(Vector3 point)
		{
			return false;
		}

		public float GetAreaSquareMeters()
		{
			return 0f;
		}

		public void MarkAsCleared()
		{
		}
	}
}
