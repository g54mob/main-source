using System;
using Pug.Conversion;
using Unity.Collections;

namespace PugWorldGen
{
	public class DungeonCustomScenesConverter : SingleAuthoringComponentConverter<DungeonCustomScenesAuthoring>
	{
		protected override void Convert(DungeonCustomScenesAuthoring authoring)
		{
			EnsureHasBuffer<DungeonCustomSceneGroupBuffer>();
			if (authoring.groups == null || authoring.scenesTable == null)
			{
				return;
			}
			foreach (DungeonCustomScenesAuthoring.SceneGroup group in authoring.groups)
			{
				DungeonCustomSceneGroupBuffer elementData = new DungeonCustomSceneGroupBuffer
				{
					roomType = group.roomType,
					minSpawns = group.numberToSpawn.min,
					maxSpawns = group.numberToSpawn.max
				};
				foreach (DungeonCustomScenesAuthoring.Scene scene in group.scenes)
				{
					ReadOnlySpan<char> persistentName = scene.GetPersistentName();
					foreach (CustomScenesDataTable.Scene scene2 in authoring.scenesTable.scenes)
					{
						if (persistentName.Equals(scene2.sceneName.AsSpan(), StringComparison.Ordinal))
						{
							ref FixedList4096Bytes<DungeonCustomScene> customScenes = ref elementData.customScenes;
							DungeonCustomScene item = new DungeonCustomScene
							{
								name = scene2.sceneName,
								size = (scene2.boundsSize + 1) / 2
							};
							customScenes.Add(in item);
							break;
						}
					}
				}
				AddToBuffer(elementData);
			}
		}
	}
}
