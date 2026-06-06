using System.Collections.Generic;
using UnityEngine;

namespace Brewery.Skills
{
	public static class SkillIconDatabase
	{
		private const string ItemIconsPath = "Assets/Assets2/Brewery/Prefabs/Items/Icons/";

		private const string TraderIconsPath = "Assets/MyStuff/Prefabs/NPCs/NPCsWithRequest/TraderNPCIcons/";

		private const string BarNPCIconsPath = "Assets/MyStuff/Prefabs/NPCs/BarNPCs/BarNPCsIcons/";

		private const string EpicToonFXPath = "Assets/Epic Toon FX/Textures/";

		private const string PolygonPropsPath = "Assets/PolygonGangWarfare/Prefabs/Props/";

		private const string PolygonIconsPath = "Assets/PolygonIcons/Prefabs/";

		private static Dictionary<SkillType, Sprite> s_IconCache;

		private static Dictionary<SkillType, Sprite> s_BadgeCache;

		private static bool s_Initialized;

		public static Sprite GetIcon(SkillType skillType)
		{
			return null;
		}

		public static string GetIconPath(SkillType skillType)
		{
			return null;
		}

		public static Sprite GetBadgeIcon(SkillType skillType)
		{
			return null;
		}

		public static string GetBadgePath(SkillType skillType)
		{
			return null;
		}

		public static bool NeedsBadge(SkillType skillType)
		{
			return false;
		}

		private static Sprite LoadSpriteFromPath(string assetPath)
		{
			return null;
		}

		private static string ConvertToResourcesPath(string assetPath)
		{
			return null;
		}

		public static void PreloadAllIcons()
		{
		}

		public static void ClearCache()
		{
		}
	}
}
