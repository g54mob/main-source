using System.Collections.Generic;
using System.Linq;
using Eflatun.SceneReference.Utility;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Scripting;

namespace Eflatun.SceneReference
{
	[PublicAPI]
	public static class SceneGuidToPathMapProvider
	{
		private static Dictionary<string, string> _sceneGuidToPathMap;

		private static Dictionary<string, string> _scenePathToGuidMap;

		public static IReadOnlyDictionary<string, string> SceneGuidToPathMap => GetSceneGuidToPathMap(errorIfMissingDuringLoad: true);

		public static IReadOnlyDictionary<string, string> ScenePathToGuidMap => GetScenePathToGuidMap(errorIfMissingDuringLoad: true);

		[Preserve]
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void RuntimeInit()
		{
			LoadIfNotAlready(errorIfMissing: true);
		}

		internal static IReadOnlyDictionary<string, string> GetSceneGuidToPathMap(bool errorIfMissingDuringLoad)
		{
			LoadIfNotAlready(errorIfMissingDuringLoad);
			return _sceneGuidToPathMap;
		}

		internal static IReadOnlyDictionary<string, string> GetScenePathToGuidMap(bool errorIfMissingDuringLoad)
		{
			LoadIfNotAlready(errorIfMissingDuringLoad);
			return _scenePathToGuidMap;
		}

		internal static void FillWith(Dictionary<string, string> sceneGuidToPathMap)
		{
			_sceneGuidToPathMap = sceneGuidToPathMap;
			_scenePathToGuidMap = sceneGuidToPathMap.ToDictionary((KeyValuePair<string, string> x) => x.Value, (KeyValuePair<string, string> x) => x.Key);
		}

		private static void LoadIfNotAlready(bool errorIfMissing)
		{
			if (_sceneGuidToPathMap != null)
			{
				return;
			}
			string value = _LoadJson();
			if (string.IsNullOrWhiteSpace(value))
			{
				if (errorIfMissing)
				{
					Logger.Error("Scene GUID to path map not found!");
				}
				FillWith(new Dictionary<string, string>());
			}
			else
			{
				FillWith(JsonConvert.DeserializeObject<Dictionary<string, string>>(value));
			}
			static string _LoadJson()
			{
				TextAsset textAsset = Resources.Load<TextAsset>(Paths.RelativeToResources.SceneGuidToPathMapFile.WithoutExtension());
				if (!(textAsset == null))
				{
					return textAsset.text;
				}
				return null;
			}
		}
	}
}
