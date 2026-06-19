using Pug.Conversion;
using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace PugWorldGen
{
	public class SingleCustomSceneDungeonConverter : SingleAuthoringComponentConverter<SingleCustomSceneDungeonAuthoring>
	{
		private const int PLACEMENT_PADDING = 2;

		protected override void Convert(SingleCustomSceneDungeonAuthoring authoring)
		{
			Resources.Load<CustomScenesDataTable>("Scenes/CustomScenesDataTable").TryFindSceneByName(authoring.scene.SceneName, out var sceneData);
			int num = (int)math.ceil(sceneData.radius);
			int num2 = authoring.reservedRadiusDuringDungeonPlacement + 2;
			AddComponentData(new DungeonAreaCD
			{
				seed = 0u,
				radius = num2,
				placementRadius = num2,
				shapeFreq = 1f,
				shapeAmp = 0f,
				blockSpawns = true
			});
			EnsureHasBuffer<DungeonRoomPlacementBuffer>();
			EnsureHasBuffer<DungeonRoomBuffer>();
			AddToBuffer(new DungeonRoomPlacementBuffer
			{
				Value = new DungeonRoomPlacement
				{
					algorithm = RoomPlacementAlgorithm.Center,
					roomType = RoomFlags.Main,
					amount = new Pug.UnityExtensions.RangeInt
					{
						min = 1,
						max = 1
					},
					size = new Pug.UnityExtensions.RangeInt
					{
						min = num,
						max = num
					}
				}
			});
			FixedList4096Bytes<DungeonCustomScene> customScenes = default(FixedList4096Bytes<DungeonCustomScene>);
			DungeonCustomScene item = new DungeonCustomScene
			{
				name = authoring.GetPersistentSceneName().ToString(),
				size = (sceneData.boundsSize + 1) / 2
			};
			customScenes.Add(in item);
			EnsureHasBuffer<DungeonCustomSceneGroupBuffer>();
			AddToBuffer(new DungeonCustomSceneGroupBuffer
			{
				roomType = RoomFlags.Main,
				minSpawns = 1,
				maxSpawns = 1,
				customScenes = customScenes
			});
			EnsureHasBuffer<DungeonPathBuffer>();
			EnsureHasBuffer<DungeonSpawnedObjectBuffer>();
			EnsureHasComponent<BlockSaveCD>();
			EnsureHasComponent<DungeonGenerationInitializationCD>();
			EnsureHasComponent<SpawnAreaEntityRefCD>();
		}
	}
}
