using System;
using System.Collections;
using Jundroo.Common.Coroutines;
using UnityEngine;
using UnityEngine.Networking;

namespace Jundroo.Common.Cache
{
	public class WebCacheScript : MonoBehaviour
	{
		public long BytesFromCache { get; private set; }

		public long BytesFromWeb { get; private set; }

		public FileCache FileCache { get; private set; }

		public long SizeInBytes => FileCache.SizeInBytes;

		public long SizeInBytesPinned => FileCache.SizeInBytesPinned;

		public void Clear()
		{
			FileCache.Clear();
		}

		public void ClearAllTextEntries()
		{
			FileCache.ClearAllTextEntries();
		}

		public bool ContainsKey(string key)
		{
			return FileCache.ContainsFile(key);
		}

		public WebYieldRequest<byte[]> GetBinary(string url, int expirationInMinutes, Action<WebYieldRequest<byte[]>> callback = null)
		{
			WebYieldRequest<byte[]> webYieldRequest = new WebYieldRequest<byte[]>();
			StartCoroutine(GetBinaryCoroutine(url, expirationInMinutes, webYieldRequest, callback));
			return webYieldRequest;
		}

		public WebYieldRequest<string> GetText(string url, int expirationInMinutes, Action<WebYieldRequest<string>> callback = null, float delay = 0f)
		{
			WebYieldRequest<string> webYieldRequest = new WebYieldRequest<string>(delay);
			StartCoroutine(GetTextCoroutine(url, expirationInMinutes, webYieldRequest, callback));
			return webYieldRequest;
		}

		public void Initialize(string rootPath, long maxSize)
		{
			FileCache = new FileCache(rootPath, maxSize);
		}

		public void PinCacheItem(string cacheKey, string pinKey)
		{
			FileCache.PinCacheItem(cacheKey, pinKey);
		}

		public void RemoveCacheItem(string key)
		{
			FileCache.RemoveCacheItem(key);
		}

		public void SaveCacheMetaData()
		{
			FileCache.SaveMetaData();
		}

		public void UnpinCacheItems(string pinKey)
		{
			FileCache.UnpinCacheItems(pinKey);
		}

		protected virtual void OnDestroy()
		{
			SaveCacheMetaData();
		}

		private IEnumerator GetBinaryCoroutine(string url, int expirationInMinutes, WebYieldRequest<byte[]> request, Action<WebYieldRequest<byte[]>> callback)
		{
			if (request.Delay > 0f)
			{
				yield return new WaitForSeconds(request.Delay);
			}
			if (!request.Canceled)
			{
				byte[] binary = FileCache.GetBinary(url);
				if (binary != null)
				{
					BytesFromCache += binary.Length;
					request.Complete(binary);
				}
				else
				{
					using UnityWebRequest r = UnityWebRequest.Get(url);
					yield return r.SendWebRequest();
					if (r.result == UnityWebRequest.Result.Success)
					{
						BytesFromWeb += r.downloadHandler.data.Length;
						request.Complete(r.downloadHandler.data);
						FileCache.AddOrUpdateBinary(url, request.Data, expirationInMinutes);
					}
					else
					{
						request.Error(r.error);
					}
				}
			}
			else
			{
				request.Error("Request was canceled");
			}
			callback?.Invoke(request);
		}

		private IEnumerator GetTextCoroutine(string url, int expirationInMinutes, WebYieldRequest<string> request, Action<WebYieldRequest<string>> callback)
		{
			if (request.Delay > 0f)
			{
				yield return new WaitForSeconds(request.Delay);
			}
			if (!request.Canceled)
			{
				string text = FileCache.GetText(url);
				if (text != null)
				{
					BytesFromCache += text.Length;
					request.Complete(text);
				}
				else
				{
					using UnityWebRequest r = UnityWebRequest.Get(url);
					yield return r.SendWebRequest();
					if (r.result == UnityWebRequest.Result.Success)
					{
						BytesFromWeb += r.downloadHandler.text.Length;
						request.Complete(r.downloadHandler.text);
						FileCache.AddOrUpdateText(url, request.Data, expirationInMinutes);
					}
					else
					{
						request.Error(r.error);
					}
				}
			}
			else
			{
				request.Error("Request was canceled");
			}
			callback?.Invoke(request);
		}
	}
}
