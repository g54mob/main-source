using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Entities;

namespace PugWorldGen
{
	public struct SpawnEntryCD : IComponentData, IQueryTypeParameter
	{
		public bool disabled;

		public ObjectDataWithRange objectToSpawn;

		public float chanceToAppearAtAll;

		public FixedList64Bytes<ObjectID> canSpawnOn;

		public bool cannotSpawnOnAnyPreviousObject;

		public FixedList64Bytes<ObjectID> canSpawnNextTo;

		public FixedList64Bytes<ObjectID> canNotSpawnOn;

		public LootTableID containLoot;

		public SpawnAlgorithm algorithm;

		public PlacementAlignment placementAlignment;

		public Range shapeSize;

		public RangeInt amount;

		public Range placement;

		public Range tilt;

		public bool rotateTowardsCenter;

		public float randomChance;

		public Range oblongness;
	}
}
