using System.Collections.Generic;
using UnityEngine;

namespace Brewery.ZoneDecorator
{
	[CreateAssetMenu(fileName = "ZoneDatabase", menuName = "Brewery/Zone Decorator/Zone Database")]
	public class ZoneDatabase : ScriptableObject
	{
		[Tooltip("All zone prefab lists - one per zone type")]
		public List<ZonePrefabList> zoneLists;

		[Header("Global Settings")]
		[Tooltip("Layer mask for ground detection")]
		public LayerMask groundLayerMask;

		[Tooltip("Raycast distance for ground checks")]
		[Range(10f, 100f)]
		public float groundRaycastDistance;

		[Tooltip("Layer mask for overlap checks (things to avoid)")]
		public LayerMask overlapCheckMask;

		[Tooltip("Global minimum spacing between ALL decorations")]
		[Range(0.3f, 3f)]
		public float globalMinSpacing;

		public ZonePrefabList GetListForZone(ZoneType zoneType)
		{
			return null;
		}

		public bool HasZoneType(ZoneType zoneType)
		{
			return false;
		}
	}
}
