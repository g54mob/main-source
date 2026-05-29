using System.Collections.Generic;
using UnityEngine;

namespace CTS
{
	public static class SurfaceDataLoader
	{
		private static Dictionary<string, SurfaceData> _loadedFlooring;

		private static Dictionary<string, SurfaceData> _loadedWalls;

		public static IEnumerable<SurfaceData> GetLoadedFloors => _loadedFlooring.Values;

		public static IEnumerable<SurfaceData> GetLoadedWalls => _loadedWalls.Values;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Initialize()
		{
			_loadedFlooring = new Dictionary<string, SurfaceData>();
			_loadedWalls = new Dictionary<string, SurfaceData>();
			SurfaceData[] array = Resources.LoadAll<SurfaceData>("Scriptables/SurfaceData/Flooring");
			foreach (SurfaceData surfaceData in array)
			{
				_loadedFlooring.TryAdd(surfaceData.name, surfaceData);
			}
			array = Resources.LoadAll<SurfaceData>("Scriptables/SurfaceData/WallSurfaces");
			foreach (SurfaceData surfaceData2 in array)
			{
				_loadedWalls.TryAdd(surfaceData2.name, surfaceData2);
			}
		}

		public static bool TryGetFloor(string id, out SurfaceData outData)
		{
			return _loadedFlooring.TryGetValue(id, out outData);
		}

		public static bool TryGetWall(string id, out SurfaceData outData)
		{
			return _loadedWalls.TryGetValue(id, out outData);
		}
	}
}
