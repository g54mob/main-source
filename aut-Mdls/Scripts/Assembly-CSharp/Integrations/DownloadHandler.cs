using System;
using System.Collections;
using System.IO;
using Integrations.Interfaces;
using UnityEngine;
using UnityEngine.Networking;

namespace Integrations
{
	public class DownloadHandler : MonoBehaviour, IDownloadHandler
	{
		public void ProcessDownloadQueue(DownloadQueue downloadQueue)
		{
			for (int i = 0; i < downloadQueue.Length; i++)
			{
				StartCoroutine(DownloadAsset(downloadQueue, i));
			}
		}

		private IEnumerator DownloadAsset(DownloadQueue downloadQueue, int index)
		{
			UnityWebRequest request = downloadQueue.GetWebRequest(index);
			yield return request.SendWebRequest();
			if (request.isNetworkError || request.isHttpError)
			{
				downloadQueue.Failure(index, request.error);
			}
			else
			{
				downloadQueue.Success(index, request.downloadHandler.data);
			}
			downloadQueue.AssessCompleteness();
		}

		public static bool GetFileNameFromUri(string uriString, out string fileName)
		{
			fileName = string.Empty;
			int num;
			if (Uri.TryCreate(uriString, UriKind.Absolute, out var result))
			{
				if (!(result.Scheme == Uri.UriSchemeHttp))
				{
					num = ((result.Scheme == Uri.UriSchemeHttps) ? 1 : 0);
					if (num == 0)
					{
						goto IL_004a;
					}
				}
				else
				{
					num = 1;
				}
				fileName = Path.GetFileName(result.LocalPath);
			}
			else
			{
				num = 0;
			}
			goto IL_004a;
			IL_004a:
			return (byte)num != 0;
		}
	}
}
