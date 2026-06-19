using Pug.Conversion;
using Unity.Mathematics;
using UnityEngine;

namespace PugWorldGen
{
	public class DungeonConverter : SingleAuthoringComponentConverter<DungeonAuthoring>
	{
		private const int PLACEMENT_PADDING = 2;

		protected override void Convert(DungeonAuthoring authoring)
		{
			int num = 0;
			if (TryGetActiveComponent<DungeonRoomAuthoring>(authoring, out var component))
			{
				foreach (DungeonRoomAuthoring.RoomConfiguration roomConfiguration in component.roomConfigurations)
				{
					num = math.max(num, roomConfiguration.size.max);
				}
			}
			DungeonAreaCD component2 = new DungeonAreaCD
			{
				seed = authoring.seed,
				radius = authoring.radius,
				shapeFreq = 1f,
				blockSpawns = !authoring.dontBlockOtherSpawns
			};
			if (TryGetActiveComponent<DungeonShapeAuthoring>(authoring, out var component3))
			{
				if (Application.isPlaying || !component3.disable)
				{
					float roomSize = component3.roomFillSize;
					if (component3.defineShapeByRooms && component3.roomFillSize == 0f)
					{
						roomSize = component3.shapeAmplitude;
					}
					AddComponentData(new DungeonFillCD
					{
						defineShapeByRooms = component3.defineShapeByRooms,
						roomSize = roomSize,
						pathSize = component3.pathFillSize
					});
				}
				component2.shapeAmp = component3.shapeAmplitude;
				component2.shapeFreq = component3.shapeFrequency;
				component2.defineShapeByRooms = component3.defineShapeByRooms;
			}
			component2.placementRadius = (int)math.ceil(component2.GetMaxRadiusIncludingShape() + (float)num + 2f);
			AddComponentData(component2);
			EnsureHasBuffer<DungeonRoomBuffer>();
			EnsureHasBuffer<DungeonSpawnedObjectBuffer>();
			EnsureHasComponent<BlockSaveCD>();
			EnsureHasComponent<DungeonGenerationInitializationCD>();
			EnsureHasComponent<SpawnAreaEntityRefCD>();
		}
	}
}
