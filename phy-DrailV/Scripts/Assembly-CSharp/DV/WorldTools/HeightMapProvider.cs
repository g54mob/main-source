using System;
using System.IO;
using DV.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DV.WorldTools
{
	public static class HeightMapProvider
	{
		public enum MapType
		{
			TerrainHeightmap = 0
		}

		private static LevelInfo _lastLevelInfo = null;

		private static ushort[][] _maps = null;

		private static int[] _size = null;

		private static bool _eventRegistered = false;

		private static float _waterLevel = 0f;

		private static float _worldHeight = 0f;

		private static readonly MapType[] MapTypes = (MapType[])Enum.GetValues(typeof(MapType));

		private static void CheckInit(MapType t)
		{
			if (!_eventRegistered)
			{
				SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
				_eventRegistered = true;
				_lastLevelInfo = SingletonBehaviour<LevelInfo>.Instance;
				ReinitParameters();
			}
			if (_maps == null)
			{
				_maps = new ushort[Enum.GetValues(typeof(MapType)).Length][];
				_size = new int[_maps.Length];
			}
			if (_maps[(int)t] != null)
			{
				return;
			}
			if (_lastLevelInfo != null && !string.IsNullOrEmpty(_lastLevelInfo.terrainHeightmapName))
			{
				try
				{
					if (t != MapType.TerrainHeightmap)
					{
						throw new NotImplementedException("Heightmap types other than TerrainHeightmap are not supported in LevelInfo yet!");
					}
					byte[] array = File.ReadAllBytes(Path.Combine(Application.streamingAssetsPath, "w3", _lastLevelInfo.terrainHeightmapName));
					_maps[(int)t] = new ushort[(array.Length + 1) / 2];
					Buffer.BlockCopy(array, 0, _maps[(int)t], 0, array.Length);
					_size[(int)t] = Mathf.RoundToInt(Mathf.Sqrt(_maps[(int)t].Length));
					return;
				}
				catch (Exception exception)
				{
					Debug.LogError(string.Concat("Couldn't load heightmap of type ", t, " (", Path.Combine(Application.streamingAssetsPath, "w3", _lastLevelInfo.terrainHeightmapName), ")"));
					Debug.LogException(exception);
					_maps[(int)t] = new ushort[0];
					_size[(int)t] = 0;
					return;
				}
			}
			_maps[(int)t] = new ushort[0];
			_size[(int)t] = 0;
		}

		private static void ReinitParameters()
		{
			_waterLevel = ((_lastLevelInfo != null) ? _lastLevelInfo.waterLevel : 0f);
			_worldHeight = ((_lastLevelInfo != null) ? _lastLevelInfo.worldTerrainHeight : 1000f);
		}

		private static void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
		{
			LevelInfo instance = SingletonBehaviour<LevelInfo>.Instance;
			if (_lastLevelInfo != instance)
			{
				_lastLevelInfo = instance;
				_maps = null;
				_size = null;
				ReinitParameters();
				MapType[] mapTypes = MapTypes;
				for (int i = 0; i < mapTypes.Length; i++)
				{
					CheckInit(mapTypes[i]);
				}
			}
		}

		public static float GetPointSample(Vector3 position, bool usingWorldShift = true, MapType mapType = MapType.TerrainHeightmap)
		{
			CheckInit(mapType);
			if (_size[(int)mapType] == 0)
			{
				return _waterLevel;
			}
			if (usingWorldShift)
			{
				position -= WorldMover.currentMove;
			}
			position *= (float)_size[(int)mapType] / LevelInfo.WorldSize.x;
			return GetSample(Mathf.FloorToInt(position.x), Mathf.FloorToInt(position.z), mapType);
		}

		public static float GetInterpolated(Vector3 position, bool usingWorldShift = true, MapType mapType = MapType.TerrainHeightmap)
		{
			CheckInit(mapType);
			if (_size[(int)mapType] == 0)
			{
				return _waterLevel;
			}
			if (usingWorldShift)
			{
				position -= WorldMover.currentMove;
			}
			position *= (float)_size[(int)mapType] / LevelInfo.WorldSize.x;
			position.x -= 0.5f;
			position.z -= 0.5f;
			int num = Mathf.Clamp(Mathf.FloorToInt(position.x), 0, _size[(int)mapType] - 1);
			int x = Mathf.Clamp(num + 1, 0, _size[(int)mapType] - 1);
			int num2 = Mathf.Clamp(Mathf.FloorToInt(position.z), 0, _size[(int)mapType] - 1);
			int y = Mathf.Clamp(num2 + 1, 0, _size[(int)mapType] - 1);
			float t = Mathf.Clamp01(position.x - (float)num);
			float t2 = Mathf.Clamp01(position.z - (float)num2);
			float sample = GetSample(num, num2, mapType);
			float sample2 = GetSample(num, y, mapType);
			float sample3 = GetSample(x, num2, mapType);
			return Mathf.Lerp(b: Mathf.Lerp(sample3, GetSample(x, y, mapType), t2), a: Mathf.Lerp(sample, sample2, t2), t: t);
		}

		public static float GetSample(int x, int y, MapType mapType = MapType.TerrainHeightmap)
		{
			CheckInit(mapType);
			if (_size[(int)mapType] == 0)
			{
				return _waterLevel;
			}
			if (_maps[(int)mapType].Length == 0)
			{
				return 0f;
			}
			x = Mathf.Abs(x) % _size[(int)mapType];
			y = _size[(int)mapType] - Mathf.Abs(y) % _size[(int)mapType] - 1;
			return (float)(int)_maps[(int)mapType][y * _size[(int)mapType] + x] * (_worldHeight / 65535f);
		}

		public static Vector3 GetNormalPointSampled(Vector3 position, bool usingWorldShift = true, MapType mapType = MapType.TerrainHeightmap)
		{
			CheckInit(mapType);
			if (_size[(int)mapType] == 0)
			{
				return Vector3.up;
			}
			if (usingWorldShift)
			{
				position -= WorldMover.currentMove;
			}
			position *= (float)_size[(int)mapType] / LevelInfo.WorldSize.x;
			int num = Mathf.FloorToInt(position.x);
			int num2 = Mathf.FloorToInt(position.z);
			float sample = GetSample(Mathf.Clamp(num - 1, 0, _size[(int)mapType] - 1), Mathf.Clamp(num2, 0, _size[(int)mapType] - 1), mapType);
			float sample2 = GetSample(Mathf.Clamp(num + 1, 0, _size[(int)mapType] - 1), Mathf.Clamp(num2, 0, _size[(int)mapType] - 1), mapType);
			float sample3 = GetSample(Mathf.Clamp(num, 0, _size[(int)mapType] - 1), Mathf.Clamp(num2 - 1, 0, _size[(int)mapType] - 1), mapType);
			float sample4 = GetSample(Mathf.Clamp(num, 0, _size[(int)mapType] - 1), Mathf.Clamp(num2 + 1, 0, _size[(int)mapType] - 1), mapType);
			float num3 = LevelInfo.WorldSize.x / (float)_size[(int)mapType];
			Vector3 normalized = (new Vector3(position.x + num3, sample2, position.z) - new Vector3(position.x - num3, sample, position.z)).normalized;
			Vector3 normalized2 = (new Vector3(position.x, sample4, position.z + num3) - new Vector3(position.x, sample3, position.z - num3)).normalized;
			return -Vector3.Cross(normalized, normalized2).normalized;
		}

		public static Vector3 GetNormalInterpolated(Vector3 position, bool usingWorldShift = true, MapType mapType = MapType.TerrainHeightmap)
		{
			CheckInit(mapType);
			if (_size[(int)mapType] == 0)
			{
				return Vector3.up;
			}
			if (usingWorldShift)
			{
				position -= WorldMover.currentMove;
			}
			float num = LevelInfo.WorldSize.x / (float)_size[(int)mapType];
			Vector3 vector = new Vector3(position.x - num, position.y, position.z);
			Vector3 vector2 = new Vector3(position.x + num, position.y, position.z);
			Vector3 vector3 = new Vector3(position.x, position.y, position.z - num);
			Vector3 vector4 = new Vector3(position.x, position.y, position.z + num);
			vector.y = GetInterpolated(vector, usingWorldShift: false, mapType);
			vector2.y = GetInterpolated(vector2, usingWorldShift: false, mapType);
			vector3.y = GetInterpolated(vector3, usingWorldShift: false, mapType);
			vector4.y = GetInterpolated(vector4, usingWorldShift: false, mapType);
			Vector3 normalized = (vector2 - vector).normalized;
			Vector3 normalized2 = (vector4 - vector3).normalized;
			return -Vector3.Cross(normalized, normalized2).normalized;
		}
	}
}
