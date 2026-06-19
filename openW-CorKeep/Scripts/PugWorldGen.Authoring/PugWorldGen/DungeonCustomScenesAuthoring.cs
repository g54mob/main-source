using System;
using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

namespace PugWorldGen
{
	[DisallowMultipleComponent]
	public class DungeonCustomScenesAuthoring : MonoBehaviour
	{
		[Serializable]
		public class SceneGroup
		{
			public RoomFlags roomType;

			[MinMax(0f, 50f)]
			public Pug.UnityExtensions.RangeInt numberToSpawn;

			public List<Scene> scenes;
		}

		[Serializable]
		public class Scene
		{
			public SceneReference scene;

			public ReadOnlySpan<char> GetPersistentName()
			{
				return DungeonCustomScenesAuthoring.GetPersistentName(scene);
			}
		}

		public List<SceneGroup> groups;

		public CustomScenesDataTable scenesTable;

		public static ReadOnlySpan<char> GetPersistentName(SceneReference scene)
		{
			string scenePath = scene.ScenePath;
			int num = scenePath.LastIndexOf('/') + 1;
			int num2 = scenePath.LastIndexOf('.');
			if (num2 < 0)
			{
				num2 = scenePath.Length;
			}
			return scenePath.AsSpan(num, num2 - num);
		}
	}
}
