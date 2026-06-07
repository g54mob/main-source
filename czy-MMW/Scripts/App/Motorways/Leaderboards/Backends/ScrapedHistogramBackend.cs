using System.Collections;
using System.Collections.Generic;
using Factory;
using UnityEngine;
using UnityEngine.Networking;

namespace Motorways.Leaderboards.Backends
{
	public abstract class ScrapedHistogramBackend : IHistogramBackend, IReleasedFromScopeHandler
	{
		public class CoroutineHost : MonoBehaviour
		{
		}

		private CoroutineHost _coroutineHost;

		private static readonly LeaderboardError UnknownError = new LeaderboardError(LeaderboardErrorCode.Unknown, StringId.LeaderboardError_Generic);

		private static readonly LeaderboardError NoDataError = new LeaderboardError(LeaderboardErrorCode.NoData);

		private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("ScrapedHistogramBackend");

		protected abstract string ServiceId { get; }

		public virtual void RequestHistogram(LeaderboardId leaderboardId, HistogramRequestCompleted histogramRequestCompleted)
		{
			if (_coroutineHost == null)
			{
				GameObject gameObject = new GameObject();
				_coroutineHost = gameObject.AddComponent<CoroutineHost>();
			}
			_coroutineHost.StartCoroutine(DownloadHistogram(leaderboardId, histogramRequestCompleted));
		}

		private IEnumerator DownloadHistogram(LeaderboardId leaderboardId, HistogramRequestCompleted histogramRequestCompleted)
		{
			string backendLeaderboardId = SteamworksLeaderboardBackend.GetBackendLeaderboardId(leaderboardId);
			string histogramUrl = "https://api.dinopoloclub.com/1/minimotorways/leaderboards/" + ServiceId + "/" + backendLeaderboardId + "/";
			UnityWebRequest headRequest = UnityWebRequest.Head(histogramUrl);
			yield return headRequest.SendWebRequest();
			if (headRequest.result != UnityWebRequest.Result.Success)
			{
				Log.Warn("Failed to download header data for histogram file at {0}! Aborting!", histogramUrl);
				histogramRequestCompleted(null, 0, UnknownError);
				yield break;
			}
			if (!int.TryParse(headRequest.GetResponseHeader("Content-Length"), out var contentLength) || contentLength > 20000)
			{
				Log.Error("Histogram data at {0} too large or header malformed! Is {1} characters. Allowed {2} characters. Aborting!", histogramUrl, contentLength, 20000);
				histogramRequestCompleted(null, 0, NoDataError);
				yield break;
			}
			UnityWebRequest www = UnityWebRequest.Get(histogramUrl);
			yield return www.SendWebRequest();
			if (www.result != UnityWebRequest.Result.Success)
			{
				Log.Warn("Failed to get histogram data.\n{0}", www.error);
				histogramRequestCompleted(null, 0, UnknownError);
			}
			else if (www.downloadHandler.text.Length > 20000)
			{
				Log.Error("Even though header said data would be {0} long, we've got {1} characters! Aborting!", contentLength, www.downloadHandler.text.Length);
				histogramRequestCompleted(null, 0, NoDataError);
			}
			else
			{
				LoadHistogramDataFromJson(www.downloadHandler.text, out var buckets, out var bucketSize);
				if (buckets != null && bucketSize > 0)
				{
					histogramRequestCompleted(buckets, bucketSize, null);
				}
				else
				{
					histogramRequestCompleted(null, 0, NoDataError);
				}
			}
		}

		protected void LoadHistogramDataFromJson(string dictionaryString, out List<int> buckets, out int bucketSize)
		{
			buckets = null;
			bucketSize = 0;
			JSON.Dictionary dictionary = (JSON.Dictionary)(JSON.ToDictionary(JSON.LoadFromString(dictionaryString))?["histogram"]);
			if (dictionary == null || !dictionary.GetBool("can_be_graphed", defaultValue: true))
			{
				return;
			}
			JSON.Array array = dictionary.GetArray("buckets");
			if (array != null)
			{
				buckets = new List<int>(array.Count);
				for (int i = 0; i < array.Count; i++)
				{
					buckets.Add(array.GetInt(i));
				}
			}
			bucketSize = dictionary.GetInt("bucket_size");
		}

		public void OnReleasedFromScope(IScope scope)
		{
			if (_coroutineHost != null)
			{
				Object.Destroy(_coroutineHost);
			}
		}
	}
}
