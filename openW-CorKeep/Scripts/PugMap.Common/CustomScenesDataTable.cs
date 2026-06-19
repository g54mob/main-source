using System;
using System.Collections.Generic;
using Pug.UnityExtensions;
using Unity.Mathematics;
using UnityEngine;

[CreateAssetMenu(fileName = "CustomScenesDataTable", menuName = "Pug/PugMap/CustomScenesDataTable", order = 1)]
public class CustomScenesDataTable : ScriptableObject
{
	[Serializable]
	public class Scene
	{
		public string sceneName;

		public int maxOccurrences;

		public OptionalValue<DataBlockRef<ContentBundleDataBlock>> replacedByContentBundle;

		public WorldGenerationTypeDependentValue<List<Biome>> biomesToSpawnIn;

		public int minDistanceFromCoreInClassicWorlds;

		public bool canFlipX;

		public bool canFlipY;

		public bool hasCenter;

		public int2 center;

		public int2 boundsSize;

		public float radius;

		public List<Map> maps = new List<Map>();

		public List<GameObject> prefabs = new List<GameObject>();

		public List<Vector3> prefabPositions = new List<Vector3>();

		public List<OptionalValue<float3>> prefabDirections = new List<OptionalValue<float3>>();

		public List<OptionalValue<PaintableColor>> prefabColors = new List<OptionalValue<PaintableColor>>();

		public List<InventoryOverride> prefabInventoryOverrides = new List<InventoryOverride>();
	}

	[Serializable]
	public class Map
	{
		public int2 localPosition;

		public PugMapData mapData;
	}

	[Serializable]
	public struct InventoryOverride
	{
		public bool hasAnyInventoryOverride;

		public bool hasLootTableOverride;

		public bool hasItemsOverride;

		public LootTableID lootTableOverride;

		public int itemsToRemove;

		public List<InitialInventoryItem> itemsOverride;
	}

	public List<Scene> scenes;

	public bool TryFindSceneByName(ReadOnlySpan<char> sceneName, out Scene sceneData)
	{
		foreach (Scene scene in scenes)
		{
			if (scene.sceneName.AsSpan().Equals(sceneName, StringComparison.Ordinal))
			{
				sceneData = scene;
				return true;
			}
		}
		sceneData = null;
		return false;
	}
}
