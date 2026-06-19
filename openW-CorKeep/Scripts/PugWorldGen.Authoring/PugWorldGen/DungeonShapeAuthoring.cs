using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace PugWorldGen
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(DungeonAuthoring))]
	public class DungeonShapeAuthoring : MonoBehaviour
	{
		public bool disable;

		[Range(0f, 10f)]
		public float shapeAmplitude;

		[Range(1f, 20f)]
		public float shapeFrequency = 1f;

		[Range(0f, 10f)]
		public float roomFillSize;

		[Range(0f, 10f)]
		public float pathFillSize;

		public bool defineShapeByRooms;

		public bool rectShaped;

		public List<ObjectID> tiles = new List<ObjectID>();

		[FormerlySerializedAs("spawnTemplate")]
		public SpawnTemplate roomShapeSpawnTemplate;

		public SpawnTemplate pathShapeSpawnTemplate;
	}
}
