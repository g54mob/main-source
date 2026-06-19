using NaughtyAttributes;
using Pug.UnityExtensions;
using Unity.Mathematics;
using UnityEngine;

namespace PugWorldGen
{
	public class PugWorldGenAuthoring : MonoBehaviour
	{
		public DataBlockRef<ContentBundleDataBlock> contentBundle;

		public OptionalValue<DataBlockRef<ContentBundleDataBlock>> replacedByBundle;

		public bool spawnImmediatelyOnLoad;

		public bool destroyMarkerAfterSpawn;

		public WorldGenerationTypeDependentValue<Biome> biome;

		public UniqueScenePlacementType placementType;

		[AllowNesting]
		[Tooltip("Has no effect in classic worlds")]
		[HideIf("placementType", UniqueScenePlacementType.ExactPosition)]
		public UniqueScenePositionSampling positionSampling;

		[AllowNesting]
		[Tooltip("Has no effect in classic worlds")]
		[HideIf("placementType", UniqueScenePlacementType.ExactPosition)]
		public bool allowOverlappingSpawnCellBorders;

		[AllowNesting]
		[ShowIf("placementType", UniqueScenePlacementType.DistanceFromCoreInBiome)]
		public WorldGenerationTypeDependentValue<int> targetDistanceFromCore;

		[AllowNesting]
		[ShowIf("placementType", UniqueScenePlacementType.ExactPosition)]
		public WorldGenerationTypeDependentValue<int2> spawnPosition;

		public GameObject prefab;

		public GameObject markerPrefab;

		[Header("Increment this for new prefabs")]
		public int sortIndex;
	}
}
