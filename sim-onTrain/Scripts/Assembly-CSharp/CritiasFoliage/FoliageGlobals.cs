using UnityEngine;

namespace CritiasFoliage
{
	public class FoliageGlobals
	{
		public const float EDITOR_DELAY_PAINT_FOLIAGE = 0.02f;

		public const float EDITOR_DELAY_REQUEST_UPDATE = 0.5f;

		public const string DISK_FILENAME = "FoliageData";

		public const ulong DISK_IDENTIFIER = 4851020374937128009uL;

		public const int DISK_VERSION = 1;

		public const float CELL_SIZE = 100f;

		public const float CELL_SIZE_HALF = 50f;

		public const int CELL_SUBDIVISIONS = 5;

		public const float FOLIAGE_MAX_GRASS_DISTANCE = 500f;

		public const float FOLIAGE_MAX_TREE_DISTANCE = 1000f;

		public const string LABEL_PAINTED = "Hand Painted";

		public const string LABEL_TERRAIN_EXTRACTED = "[TERRAIN]";

		public const string LABEL_TERRAIN_DETAILS_EXTRACTED = "[TERRAIN DETAILS]";

		public const string LABEL_TERRAIN_HAND_PAINTED = "[TERRAIN HAND PAINTED]";

		public const int RENDER_BATCH_SIZE = 1000;

		public const int RENDER_MAX_LOD_COUNT = 6;

		public const int RENDER_MAX_GPU_INDIRECT_BATCH_COUNT = 1250;

		public const int RENDER_MAX_GPU_INDIRECT_EVICTION_COUNT = 125;

		public static readonly Vector3 CELL_SIZE3 = new Vector3(100f, 100f, 100f);

		public static readonly Vector3 CELL_SIZE3_HALF = new Vector3(50f, 50f, 50f);

		public const float CELL_SUBDIVIDED_SIZE = 20f;

		public const float CELL_SUBDIVIDED_SIZE_HALF = 10f;

		public static readonly Vector3 CELL_SUBDIVIDED_SIZE3 = new Vector3(20f, 20f, 20f);

		public static readonly Vector3 CELL_SUBDIVIDED_SIZE3_HALF = new Vector3(10f, 10f, 10f);

		public static void Config()
		{
			Debug.LogWarning("Remove this config if you don't  want any foliage logs and delete the 'DEBUG_MODE_FOLIAGE' define from the build settings or set 'DEBUG_LEVEL' to 0!");
		}

		public static float ClampDistance(EFoliageType type, float maxViewDistance)
		{
			switch (type)
			{
			case EFoliageType.SPEEDTREE_GRASS:
			case EFoliageType.OTHER_GRASS:
				return Mathf.Clamp(maxViewDistance, 0f, 500f);
			case EFoliageType.SPEEDTREE_TREE:
			case EFoliageType.SPEEDTREE_TREE_BILLBOARD:
			case EFoliageType.OTHER_TREE:
				return Mathf.Clamp(maxViewDistance, 0f, 1000f);
			default:
				return Mathf.Clamp(maxViewDistance, 0f, 500f);
			}
		}

		public static float GetMaxDistance(EFoliageType type)
		{
			switch (type)
			{
			case EFoliageType.SPEEDTREE_GRASS:
			case EFoliageType.OTHER_GRASS:
				return 500f;
			case EFoliageType.SPEEDTREE_TREE:
			case EFoliageType.SPEEDTREE_TREE_BILLBOARD:
			case EFoliageType.OTHER_TREE:
				return 1000f;
			default:
				return 500f;
			}
		}
	}
}
