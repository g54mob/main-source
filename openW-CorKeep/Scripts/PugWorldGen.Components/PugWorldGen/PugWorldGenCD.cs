using System;
using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

namespace PugWorldGen
{
	public struct PugWorldGenCD : IComponentData, IQueryTypeParameter, IComparable<PugWorldGenCD>
	{
		public DataBlockAddress contentBundle;

		public OptionalValue<DataBlockAddress> replacedByBundle;

		public bool spawnImmediatelyOnLoad;

		public bool destroyMarkerAfterSpawn;

		public WorldGenerationTypeDependentValue<Biome> biome;

		public UniqueScenePlacementType placementType;

		public UniqueScenePositionSampling positionSampling;

		public WorldGenerationTypeDependentValue<int> targetDistanceFromCore;

		public bool allowOverlappingSpawnCellBorders;

		public WorldGenerationTypeDependentValue<int2> spawnPosition;

		public Entity entity;

		public Entity markerEntity;

		public FixedString32Bytes name;

		public int sortIndex;

		public int radius;

		public int CompareTo(PugWorldGenCD other)
		{
			return sortIndex.CompareTo(other.sortIndex);
		}
	}
}
