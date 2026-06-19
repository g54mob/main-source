using System;
using Pug.UnityExtensions;
using UnityEngine;

namespace PugWorldGen
{
	public class SingleCustomSceneDungeonAuthoring : MonoBehaviour
	{
		private const int MAX_RADIUS = 120;

		public SceneReference scene;

		[Range(0f, 120f)]
		public int reservedRadiusDuringDungeonPlacement;

		public ReadOnlySpan<char> GetPersistentSceneName()
		{
			return DungeonCustomScenesAuthoring.GetPersistentName(scene);
		}

		public bool TrySetRadiusFromScene()
		{
			if (scene == null || !scene.SceneIsAssigned())
			{
				return false;
			}
			InitializeRadiusFromScene();
			return true;
		}

		private void InitializeRadiusFromScene()
		{
			CustomScenesDataTable customScenesDataTable = Resources.Load<CustomScenesDataTable>("Scenes/CustomScenesDataTable");
			if (!(customScenesDataTable == null) && customScenesDataTable.TryFindSceneByName(GetPersistentSceneName(), out var sceneData))
			{
				int num = Mathf.CeilToInt(sceneData.radius);
				if (num > 120)
				{
					Debug.LogWarning($"Scene {scene.ScenePath} has a radius of {num}, which exceeds the maximum of {120}. Clamping to {120}.");
					num = 120;
				}
				reservedRadiusDuringDungeonPlacement = num;
			}
		}
	}
}
