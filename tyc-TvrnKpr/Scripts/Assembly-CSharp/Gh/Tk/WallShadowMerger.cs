using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public static class WallShadowMerger
	{
		private static List<string> _dirtyShadows;

		private static Dictionary<string, GameObject> _wallShadowsCache;

		private static bool _isWallShadowMeshPrefabSet;

		private static GameObject _wallShadowMeshPrefab;

		private static GameObject WallShadowMeshPrefab => null;

		static WallShadowMerger()
		{
		}

		public static void InitWallShadowCache()
		{
		}

		private static void OnWallChanged(object sender, EventArgs<Wall> e)
		{
		}

		private static void MarkWallAsDirty(Wall wall)
		{
		}

		private static void ClearWallShadowCache(string id)
		{
		}

		public static void UpdateWallShadowCache()
		{
		}

		private static void GenerateWallShadowCache(string id, IEnumerable<Wall> walls)
		{
		}

		private static void CombineWallShadowInstances(string id, CombineInstance[] combineInstances)
		{
		}
	}
}
