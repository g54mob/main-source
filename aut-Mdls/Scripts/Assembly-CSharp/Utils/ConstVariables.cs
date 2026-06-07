using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
	public static class ConstVariables
	{
		public static class FactoryFloor
		{
			public const string DEFAULT_LEVEL_NAME = "DefaultLevel";

			public const string DEFAULT_LEVEL_NAME_FREEBUILD = "FreeBuildMap";

			public const string DEFAULT_LEVEL_NAME_CREATIVE = "DefaultLevelCreative";

			public const string LEVEL_NAME = "Level";

			public const string LEVELS_FOLDER = "Levels";

			public const string FACTORY_SAVE_NAME = "level.json";

			public const string SHAPES_SAVE_NAME = "shapes.json";

			public const string MAP_SAVE_NAME = "map.json";

			public const string THUMBNAIL_NAME = "Thumbnail.png";

			public const string AUTOSAVE_FOLDER = "AutoSave";

			public static readonly List<string> CAMPAIGN_MAPS = new List<string> { "DefaultLevel", "FreeBuildMap" };
		}

		public static class PersistentSONames
		{
			public const string FOLDER = "PersistentSOs";
		}

		public static class Buildings
		{
			public const float BUILDING_SCALE = 1.2f;

			public static float BuildingGridSize => 1.2f;

			public static Vector3Int WorldPosToBuildingGridPos(Vector3 worldPos)
			{
				return new Vector3Int(Mathf.FloorToInt(worldPos.x * 1.2f + 0.05f), 0, Mathf.FloorToInt(worldPos.z * 1.2f + 0.05f));
			}

			public static Vector3 GridPosToBuildingWorldPos(Vector3Int gridPos)
			{
				return new Vector3(((float)gridPos.x - 0.05f) / 1.2f, 0f, ((float)gridPos.z - 0.05f) / 1.2f);
			}
		}
	}
}
