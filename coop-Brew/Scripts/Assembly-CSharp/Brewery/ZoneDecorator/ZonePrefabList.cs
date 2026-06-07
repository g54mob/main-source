using System;
using System.Collections.Generic;
using UnityEngine;

namespace Brewery.ZoneDecorator
{
	[CreateAssetMenu(fileName = "ZonePrefabs_", menuName = "Brewery/Zone Decorator/Zone Prefab List")]
	public class ZonePrefabList : ScriptableObject
	{
		[Tooltip("Which zone type this list is for")]
		public ZoneType zoneType;

		[Tooltip("Description of what should spawn in this zone")]
		[TextArea(2, 4)]
		public string description;

		[Tooltip("Color for gizmo visualization")]
		public Color gizmoColor;

		[Tooltip("All prefabs that can spawn in this zone")]
		public List<ZonePrefabEntry> prefabs;

		[Header("Zone Settings")]
		[Tooltip("Target density - items per 10 square meters")]
		[Range(1f, 50f)]
		public int density;

		[Tooltip("Minimum spacing between any items in this zone")]
		[Range(0.5f, 5f)]
		public float minSpacing;

		[Tooltip("Chance (0-1) that a bundleable item spawns as bundle")]
		[Range(0f, 1f)]
		public float bundleChance;

		public float GetTotalWeight()
		{
			return 0f;
		}

		public ZonePrefabEntry PickRandomPrefab(System.Random rng)
		{
			return null;
		}
	}
}
