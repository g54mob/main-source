#define ENABLE_DEBUG_LOGS
using System;
using System.Collections.Generic;
using System.Linq;
using Integrations.Data;
using UnityEngine.Networking;
using Utils;

namespace Integrations
{
	public class DownloadQueue
	{
		private List<DownloadableAsset> _assetList = new List<DownloadableAsset>();

		private Action _onQueueComplete;

		public int Length => _assetList.Count;

		public DownloadQueue()
		{
			_assetList = new List<DownloadableAsset>();
			_onQueueComplete = null;
		}

		public DownloadQueue(List<DownloadableAsset> assetList, Action onQueueComplete)
		{
			_assetList = assetList;
			_onQueueComplete = onQueueComplete;
		}

		public void Add(List<DownloadableAsset> assetList)
		{
			_assetList.AddRange(assetList);
		}

		public UnityWebRequest GetWebRequest(int index)
		{
			return UnityWebRequestTexture.GetTexture(_assetList[index].Url);
		}

		public void Success(int index, byte[] data)
		{
			this.Log("IntegrationHandler succesfully downloaded image from " + _assetList[index].Url, "Success", 44);
			StorageHandler.StoreCachedAsset(_assetList[index].Location, data);
			_assetList[index].Available = true;
			_assetList[index].Complete = true;
		}

		public void Failure(int index, string error)
		{
			this.Log(error, "Failure", 52);
			_assetList[index].Available = false;
			_assetList[index].Complete = true;
		}

		public void AssessCompleteness()
		{
			if (_assetList.All((DownloadableAsset a) => a.Complete))
			{
				_onQueueComplete?.Invoke();
			}
		}
	}
}
