using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Muna.Internal;
using Muna.Services;

namespace Muna.API
{
	internal sealed class PredictionCacheClient : UnityClient
	{
		public PredictionCacheClient(string url, string? accessKey)
			: base(url, accessKey)
		{
		}

		public override async Task<T?> Request<T>(string method, string path, Dictionary<string, object?>? payload = null)
		{
			string tag = GetValue<string>(payload, "tag");
			string clientId = GetValue<string>(payload, "clientId");
			string configurationId = GetValue<string>(payload, "configurationId");
			if (method != "POST" || path != "/predictions" || string.IsNullOrEmpty(tag) || string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(configurationId))
			{
				return await base.Request<T>(method, path, payload);
			}
			PredictionCache.CachedPrediction cachedPrediction = MunaSettings.Instance.cache.FirstOrDefault((PredictionCache.CachedPrediction p) => p.tag == tag && MatchClientIds(p.clientId, clientId));
			if (PredictionCache.Get(tag, clientId, configurationId, cachedPrediction?.resources, out PredictionCache.CachedPrediction prediction))
			{
				return prediction as T;
			}
			Prediction prediction2 = await base.Request<Prediction>("POST", "/predictions", new Dictionary<string, object>
			{
				["tag"] = tag,
				["clientId"] = clientId,
				["configurationId"] = configurationId,
				["predictionId"] = cachedPrediction?.id
			});
			PredictionResource[] resources = new PredictionResource[prediction2.resources.Length];
			int i = 0;
			while (i < resources.Length)
			{
				PredictionResource[] array = resources;
				int num = i;
				array[num] = await GetCachedResource(prediction2.resources[i]);
				int num2 = i + 1;
				i = num2;
			}
			prediction2.resources = resources;
			PredictionCache.Add(prediction2.AsCached(clientId, configurationId));
			return prediction2 as T;
		}

		private async Task<PredictionResource> GetCachedResource(PredictionResource resource)
		{
			string path = PredictionService.GetResourcePath(resource, PredictionCache.ResourceCachePath);
			if (!File.Exists(path))
			{
				Directory.CreateDirectory(Path.GetDirectoryName(path));
				using Stream stream = await Download(resource.url);
				using FileStream destination = File.Create(path);
				stream.CopyTo(destination);
			}
			return new PredictionResource
			{
				type = resource.type,
				url = "file://" + path
			};
		}

		private static T? GetValue<T>(Dictionary<string, object?>? payload, string key)
		{
			if (payload != null && payload.TryGetValue(key, out object value))
			{
				return (T)value;
			}
			return default(T);
		}

		private static bool MatchClientIds(string a, string b)
		{
			if (a == b)
			{
				return true;
			}
			if (a.Contains("android") && b.Contains("android"))
			{
				string[] source = new string[3] { "armeabi-v7a", "armv7l", "armv8l" };
				string[] source2 = new string[3] { "arm64", "aarch64", "armv8" };
				if (source.Any((string s) => a.Contains(s)) && source.Any((string s) => b.Contains(s)))
				{
					return true;
				}
				if (source2.Any((string s) => a.Contains(s)) && source2.Any((string s) => b.Contains(s)))
				{
					return true;
				}
			}
			return false;
		}
	}
}
