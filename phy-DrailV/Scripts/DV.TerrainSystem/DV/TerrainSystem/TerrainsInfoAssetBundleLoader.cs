using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

namespace DV.TerrainSystem
{
	public class TerrainsInfoAssetBundleLoader
	{
		private string worldName;

		private Func<IEnumerator, Coroutine> _StartCoroutine;

		private TerrainsInfoFromAssetBundle assBunInfo;

		private Dictionary<Vector2Int, TerrainInfoLoadWrapper> loadingWrappers = new Dictionary<Vector2Int, TerrainInfoLoadWrapper>();

		public int TerrainsPerAxis => assBunInfo.TerrainsPerAxis;

		public float TerrainSizeInWorld => assBunInfo.terrainSizeInWorld;

		public TerrainsInfoAssetBundleLoader(string worldName, Func<IEnumerator, Coroutine> StartCoroutineMethod)
		{
			this.worldName = worldName;
			_StartCoroutine = StartCoroutineMethod;
			UnityEngine.Object[] array = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, worldName, "info")).LoadAllAssets();
			assBunInfo = (TerrainsInfoFromAssetBundle)array[0];
		}

		public TerrainInfoLoadWrapper Load(Vector2Int coord)
		{
			if (!loadingWrappers.TryGetValue(coord, out var value))
			{
				value = new TerrainInfoLoadWrapper(GetAssetBundleFilePath(coord), _StartCoroutine);
				loadingWrappers[coord] = value;
			}
			value.Load();
			return value;
		}

		public void Unload(Vector2Int coord)
		{
			if (loadingWrappers.TryGetValue(coord, out var value))
			{
				value.Unload();
			}
		}

		private string GetAssetBundleFilePath(Vector2Int coord)
		{
			return Path.Combine(Application.streamingAssetsPath, worldName, $"terraindata_{ToIndex(coord)}");
		}

		private int ToIndex(Vector2Int coords)
		{
			return coords.y * TerrainsPerAxis + coords.x;
		}

		[Conditional("LOGGING")]
		internal static void Log(string msg, UnityEngine.Object context = null)
		{
			UnityEngine.Debug.Log(msg, context);
		}

		[Conditional("LOGGING")]
		internal static void LogWarning(string msg, UnityEngine.Object context = null)
		{
			UnityEngine.Debug.LogWarning(msg, context);
		}

		[Conditional("LOGGING")]
		internal static void LogError(string msg, UnityEngine.Object context = null)
		{
			UnityEngine.Debug.LogError(msg, context);
		}
	}
}
