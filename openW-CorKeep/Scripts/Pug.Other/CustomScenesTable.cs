using System;
using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

[CreateAssetMenu(fileName = "CustomScenesTable", menuName = "Pug/PugMap/CustomScenesTable", order = 1)]
public class CustomScenesTable : ScriptableObject
{
	[Serializable]
	public class SceneInfo
	{
		public SceneReference scene;

		public int maxOccurrences;

		[Tooltip("Scene won't spawn if this content bundle is active.")]
		public OptionalValue<DataBlockRef<ContentBundleDataBlock>> replacedByContentBundle;

		public WorldGenerationTypeDependentValue<List<Biome>> biomesToSpawnIn;

		public int minDistanceFromCoreInClassicWorlds;

		public bool canFlipX;

		public bool canFlipY;
	}

	public class SceneData
	{
		public int sceneInfoIndex;

		public int occurences;

		public SceneData(int sceneInfoIndex, int occurences)
		{
			this.sceneInfoIndex = sceneInfoIndex;
			this.occurences = occurences;
		}
	}

	[ArrayElementTitle("scene, biomesToSpawnIn.fullRelease, maxOccurrences")]
	public List<SceneInfo> scenes;
}
