using Pug.Conversion;
using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace PugWorldGen
{
	public class PugWorldGenConverter : SingleAuthoringComponentConverter<PugWorldGenAuthoring>
	{
		private const int PLACEMENT_PADDING = 2;

		protected override void Convert(PugWorldGenAuthoring authoring)
		{
			int num = 0;
			if (TryGetActiveComponent<DungeonRoomAuthoring>(authoring, out var component))
			{
				foreach (DungeonRoomAuthoring.RoomConfiguration roomConfiguration in component.roomConfigurations)
				{
					num = math.max(num, roomConfiguration.size.max);
				}
			}
			Entity prefabDependency = GetPrefabDependency(authoring.prefab);
			Entity markerEntity = ((authoring.markerPrefab == null) ? Entity.Null : GetPrefabDependency(authoring.markerPrefab));
			int radius;
			if (TryGetActiveComponent<DungeonAuthoring>(authoring.prefab, out var component2))
			{
				radius = component2.radius + num + 2;
			}
			else
			{
				if (!TryGetActiveComponent<SingleCustomSceneDungeonAuthoring>(authoring.prefab, out var component3))
				{
					Debug.LogError(authoring.name + " does not have a component specifying the radius of the dungeon.");
					return;
				}
				radius = component3.reservedRadiusDuringDungeonPlacement;
			}
			AddComponentData(new PugWorldGenCD
			{
				contentBundle = authoring.contentBundle.address,
				replacedByBundle = (authoring.replacedByBundle.TryGetValue(out var output) ? new OptionalValue<DataBlockAddress>(output.address) : default(OptionalValue<DataBlockAddress>)),
				spawnImmediatelyOnLoad = authoring.spawnImmediatelyOnLoad,
				destroyMarkerAfterSpawn = authoring.destroyMarkerAfterSpawn,
				biome = authoring.biome,
				placementType = authoring.placementType,
				positionSampling = authoring.positionSampling,
				allowOverlappingSpawnCellBorders = authoring.allowOverlappingSpawnCellBorders,
				targetDistanceFromCore = authoring.targetDistanceFromCore,
				spawnPosition = authoring.spawnPosition,
				entity = prefabDependency,
				markerEntity = markerEntity,
				name = authoring.name,
				sortIndex = authoring.sortIndex,
				radius = radius
			});
		}
	}
}
