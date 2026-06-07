using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using UnityEngine;

namespace Simulator
{
	public static class CSVImporter
	{
		[Serializable]
		public struct GoogleSheetID
		{
			public string sheetID;

			public string tabID;
		}

		private struct GoogleSheetDownloadable : IDownloadable
		{
			public GoogleSheetRef googleSheetRef;

			public Action<GoogleSheetRef, bool, List<List<string>>> completionCallback;

			public string GetURL()
			{
				return "https://docs.google.com/spreadsheets/d/" + googleSheetRef.ID.sheetID + "/export?format=csv&gid=" + googleSheetRef.ID.tabID;
			}

			public void TriggerCallback(bool success, List<List<string>> content)
			{
				completionCallback?.Invoke(googleSheetRef, success, content);
			}
		}

		private interface IDownloadable
		{
			string GetURL();

			void TriggerCallback(bool success, List<List<string>> content);
		}

		private static Queue<IDownloadable> _downloadableQueue = new Queue<IDownloadable>();

		public static bool IsImporting { get; private set; }

		public static void TryImportGoogleSheet(GoogleSheetRef googleSheetRef, Action<GoogleSheetRef, bool, List<List<string>>> onComplete)
		{
			GoogleSheetDownloadable googleSheetDownloadable = new GoogleSheetDownloadable
			{
				googleSheetRef = googleSheetRef,
				completionCallback = onComplete
			};
			if (IsImporting)
			{
				_downloadableQueue.Enqueue(googleSheetDownloadable);
			}
			else
			{
				DownloadStringAtURL(googleSheetDownloadable);
			}
		}

		private static async void DownloadStringAtURL(IDownloadable downloadable)
		{
			IsImporting = true;
			using WebClient webClient = new WebClient();
			Task<string> task = webClient.DownloadStringTaskAsync(downloadable.GetURL());
			try
			{
				await task;
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				IsImporting = false;
			}
			if (task.IsCompletedSuccessfully)
			{
				Debug.Log("Import successful : " + downloadable.GetURL());
				List<List<string>> content = CSVParser.ParseFromString(task.Result, hasHeader: false, removeHeader: true, Delimiter.Comma);
				downloadable.TriggerCallback(success: true, content);
			}
			else
			{
				Debug.LogError(task.Status);
				downloadable.TriggerCallback(success: false, null);
			}
			if (_downloadableQueue.Count > 0)
			{
				DownloadStringAtURL(_downloadableQueue.Dequeue());
			}
			else
			{
				IsImporting = false;
			}
		}
	}
}
