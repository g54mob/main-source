using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Loxodon.Framework.Asynchronous;
using Loxodon.Framework.Execution;
using Loxodon.Log;
using UnityEngine.Networking;

namespace Loxodon.Framework.Net.Http
{
	public class UnityWebRequestFileDownloader : FileDownloaderBase
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(UnityWebRequestFileDownloader));

		public UnityWebRequestFileDownloader()
		{
		}

		public UnityWebRequestFileDownloader(Uri baseUri, int maxTaskCount)
			: base(baseUri, maxTaskCount)
		{
		}

		public override IProgressResult<ProgressInfo, FileInfo> DownloadFileAsync(Uri path, FileInfo fileInfo)
		{
			return Executors.RunOnCoroutine((IProgressPromise<ProgressInfo, FileInfo> promise) => DoDownloadFileAsync(path, fileInfo, promise));
		}

		protected virtual IEnumerator DoDownloadFileAsync(Uri path, FileInfo fileInfo, IProgressPromise<ProgressInfo> promise)
		{
			if (!fileInfo.Directory.Exists)
			{
				fileInfo.Directory.Create();
			}
			ProgressInfo progressInfo = new ProgressInfo
			{
				TotalCount = 1
			};
			using UnityWebRequest www = new UnityWebRequest(GetAbsoluteUri(path).AbsoluteUri);
			DownloadFileHandler downloadHandler = (DownloadFileHandler)(www.downloadHandler = new DownloadFileHandler(www, fileInfo));
			www.SendWebRequest();
			while (!www.isDone)
			{
				if (downloadHandler.DownloadProgress > 0f)
				{
					if (progressInfo.TotalSize <= 0)
					{
						progressInfo.TotalSize = downloadHandler.TotalSize;
					}
					progressInfo.CompletedSize = downloadHandler.DownloadedSize;
					promise.UpdateProgress(progressInfo);
				}
				yield return null;
			}
			if (www.isNetworkError)
			{
				promise.SetException(www.error);
				yield break;
			}
			progressInfo.CompletedCount = 1;
			progressInfo.CompletedSize = progressInfo.TotalSize;
			promise.UpdateProgress(progressInfo);
			promise.SetResult(fileInfo);
		}

		public override IProgressResult<ProgressInfo, ResourceInfo[]> DownloadFileAsync(ResourceInfo[] infos)
		{
			return Executors.RunOnCoroutine((IProgressPromise<ProgressInfo, ResourceInfo[]> promise) => DoDownloadFileAsync(infos, promise));
		}

		protected virtual IEnumerator DoDownloadFileAsync(ResourceInfo[] infos, IProgressPromise<ProgressInfo> promise)
		{
			long totalSize = 0L;
			long downloadedSize = 0L;
			List<ResourceInfo> downloadList = new List<ResourceInfo>();
			foreach (ResourceInfo info in infos)
			{
				FileInfo fileInfo = info.FileInfo;
				if (info.FileSize < 0)
				{
					if (fileInfo.Exists)
					{
						info.FileSize = fileInfo.Length;
					}
					else
					{
						using UnityWebRequest www = UnityWebRequest.Head(GetAbsoluteUri(info.Path).AbsoluteUri);
						yield return www.SendWebRequest();
						string responseHeader = www.GetResponseHeader("Content-Length");
						info.FileSize = long.Parse(responseHeader);
					}
				}
				totalSize += info.FileSize;
				if (fileInfo.Exists)
				{
					downloadedSize += info.FileSize;
				}
				else
				{
					downloadList.Add(info);
				}
			}
			ProgressInfo progressInfo = new ProgressInfo
			{
				TotalCount = infos.Length,
				CompletedCount = infos.Length - downloadList.Count,
				TotalSize = totalSize,
				CompletedSize = downloadedSize
			};
			yield return null;
			List<KeyValuePair<ResourceInfo, UnityWebRequest>> tasks = new List<KeyValuePair<ResourceInfo, UnityWebRequest>>();
			for (int i = 0; i < downloadList.Count; i++)
			{
				ResourceInfo resourceInfo = downloadList[i];
				Uri path = resourceInfo.Path;
				FileInfo fileInfo2 = resourceInfo.FileInfo;
				if (!fileInfo2.Directory.Exists)
				{
					fileInfo2.Directory.Create();
				}
				UnityWebRequest unityWebRequest = new UnityWebRequest(GetAbsoluteUri(path).AbsoluteUri);
				unityWebRequest.downloadHandler = new DownloadFileHandler(unityWebRequest, fileInfo2);
				unityWebRequest.SendWebRequest();
				tasks.Add(new KeyValuePair<ResourceInfo, UnityWebRequest>(resourceInfo, unityWebRequest));
				while (tasks.Count >= MaxTaskCount || (i == downloadList.Count - 1 && tasks.Count > 0))
				{
					long num = 0L;
					for (int num2 = tasks.Count - 1; num2 >= 0; num2--)
					{
						KeyValuePair<ResourceInfo, UnityWebRequest> keyValuePair = tasks[num2];
						ResourceInfo key = keyValuePair.Key;
						UnityWebRequest value = keyValuePair.Value;
						if (!value.isDone)
						{
							num += Math.Max(0L, ((DownloadFileHandler)value.downloadHandler).DownloadedSize);
						}
						else
						{
							progressInfo.CompletedCount++;
							tasks.RemoveAt(num2);
							downloadedSize += key.FileSize;
							if (value.isNetworkError)
							{
								promise.SetException(new Exception(value.error));
								if (log.IsErrorEnabled)
								{
									log.ErrorFormat("Downloads file '{0}' failure from the address '{1}'.Reason:{2}", key.FileInfo.FullName, GetAbsoluteUri(key.Path), value.error);
								}
								value.Dispose();
								try
								{
									foreach (KeyValuePair<ResourceInfo, UnityWebRequest> item in tasks)
									{
										item.Value.Dispose();
									}
									yield break;
								}
								catch (Exception)
								{
									yield break;
								}
							}
							value.Dispose();
						}
					}
					progressInfo.CompletedSize = downloadedSize + num;
					promise.UpdateProgress(progressInfo);
					yield return null;
				}
			}
			promise.SetResult(infos);
		}
	}
}
