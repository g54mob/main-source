using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Muna.Services;
using Newtonsoft.Json;
using UnityEngine;

namespace Muna.Internal
{
	internal static class PredictionCache
	{
		[Serializable]
		[Preserve]
		internal class CachedPrediction : Prediction
		{
			public string? clientId;

			public string? configurationId;

			[Preserve]
			public CachedPrediction()
			{
			}
		}

		private static string? cacheRoot;

		internal static string ResourceCachePath => Path.Combine(cacheRoot, "cache");

		internal static string PredictorCachePath => Path.Combine(cacheRoot, "predictors");

		public static void Add(CachedPrediction prediction)
		{
			string cachedPath = GetCachedPath(prediction);
			string contents = JsonConvert.SerializeObject(prediction, Formatting.Indented);
			File.WriteAllText(cachedPath, contents);
		}

		public static bool Get(string tag, string clientId, string configurationId, PredictionResource[]? embeddedResources, out CachedPrediction? prediction)
		{
			prediction = null;
			string cachedPath = GetCachedPath(tag, clientId, configurationId);
			if (!File.Exists(cachedPath))
			{
				return false;
			}
			CachedPrediction cachedPrediction = JsonConvert.DeserializeObject<CachedPrediction>(File.ReadAllText(cachedPath));
			if (!ResourcesAreValid(cachedPrediction.resources, embeddedResources))
			{
				File.Delete(cachedPath);
				return false;
			}
			prediction = cachedPrediction;
			return true;
		}

		public static void Remove(CachedPrediction prediction)
		{
			string cachedPath = GetCachedPath(prediction);
			if (File.Exists(cachedPath))
			{
				File.Delete(cachedPath);
			}
		}

		public static CachedPrediction AsCached(this Prediction prediction, string? clientId = null, string? configurationId = null)
		{
			return new CachedPrediction
			{
				id = prediction.id,
				tag = prediction.tag,
				created = prediction.created,
				results = prediction.results,
				latency = prediction.latency,
				error = prediction.error,
				logs = prediction.logs,
				resources = prediction.resources,
				configuration = prediction.configuration,
				clientId = clientId,
				configurationId = configurationId
			};
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
		private static void OnInitialize()
		{
			cacheRoot = (Application.isEditor ? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".fxn") : Path.Combine(Application.persistentDataPath, "fxn"));
		}

		private static string GetCachedPath(CachedPrediction prediction)
		{
			return GetCachedPath(prediction.tag, prediction.clientId, prediction.configurationId);
		}

		private static string GetCachedPath(string tag, string clientId, string configurationId)
		{
			if (!Directory.Exists(PredictorCachePath))
			{
				Directory.CreateDirectory(PredictorCachePath);
			}
			using SHA256Managed sHA256Managed = new SHA256Managed();
			string s = tag + "::" + clientId + "::" + configurationId;
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			string text = BitConverter.ToString(sHA256Managed.ComputeHash(bytes)).Replace("-", "").ToLower();
			return Path.Combine(PredictorCachePath, text + ".json");
		}

		private static bool ResourcesAreValid(PredictionResource[] cachedResources, PredictionResource[]? embeddedResources)
		{
			if (embeddedResources != null && cachedResources.Length != embeddedResources.Length)
			{
				return false;
			}
			for (int i = 0; i < cachedResources.Length; i++)
			{
				string localPath = new Uri(cachedResources[i].url).LocalPath;
				string text = ((embeddedResources != null) ? PredictionService.GetResourcePath(embeddedResources[i], ResourceCachePath) : null);
				if (!File.Exists(localPath))
				{
					return false;
				}
				if (text != null && localPath != text)
				{
					return false;
				}
			}
			return true;
		}
	}
}
