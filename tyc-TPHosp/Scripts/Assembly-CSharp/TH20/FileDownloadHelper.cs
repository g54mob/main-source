#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class FileDownloadHelper : MustCallDestroy
	{
		public List<BaseOnlineDataFile> SuccessfulDownloadResults = new List<BaseOnlineDataFile>();

		public List<BaseOnlineDataFile> FailedDownloadResults = new List<BaseOnlineDataFile>();

		private List<BaseOnlineDataFile> _downloadList;

		public bool IsDownloading
		{
			get
			{
				if (_downloadList != null)
				{
					return _downloadList.Count > 0;
				}
				return false;
			}
		}

		public void Reset()
		{
			if (_downloadList != null)
			{
				foreach (BaseOnlineDataFile download in _downloadList)
				{
					if (download == null)
					{
						Logging.Warning("Trying to download null file in FileDownloadHelper.Reset()");
					}
					else
					{
						download.OnFileDownloadFinished = (Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>)Delegate.Remove(download.OnFileDownloadFinished, new Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>(OnFileDownloadFinished));
					}
				}
				_downloadList.Clear();
			}
			SuccessfulDownloadResults.Clear();
			FailedDownloadResults.Clear();
		}

		public override void Destroy()
		{
			Reset();
			base.Destroy();
		}

		public void Download(BaseOnlineDataFile file)
		{
			Download(new List<BaseOnlineDataFile> { file });
		}

		public void Download(List<BaseOnlineDataFile> targetFiles)
		{
			if (IsDownloading)
			{
				UnityEngine.Debug.LogError("already downloading, current Download ignored \nTrying to download File: " + targetFiles[0].GetFilename() + " playerID:" + targetFiles[0].GetPlayerID().ToString() + "\n while still downloading File: " + _downloadList[0].GetFilename() + " playerID:" + _downloadList[0].GetPlayerID().ToString());
				return;
			}
			SuccessfulDownloadResults.Clear();
			FailedDownloadResults.Clear();
			_downloadList = targetFiles;
			if (_downloadList == null)
			{
				return;
			}
			for (int num = _downloadList.Count - 1; num >= 0; num--)
			{
				if (_downloadList[num] == null)
				{
					Logging.Warning("Trying to download null file in FileDownloadHelper.Download()");
				}
				else
				{
					BaseOnlineDataFile baseOnlineDataFile = _downloadList[num];
					baseOnlineDataFile.OnFileDownloadFinished = (Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>)Delegate.Combine(baseOnlineDataFile.OnFileDownloadFinished, new Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>(OnFileDownloadFinished));
					_downloadList[num].Download(forceTry: true);
				}
			}
		}

		private void OnFileDownloadFinished(BaseOnlineDataFile file, DownloadResult result, EOnlineResult onlineResult)
		{
			_downloadList.Remove(file);
			if (result == DownloadResult.FileFailed || result == DownloadResult.FileNotAccessedYet)
			{
				FailedDownloadResults.Add(file);
			}
			else
			{
				SuccessfulDownloadResults.Add(file);
			}
			file.OnFileDownloadFinished = (Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>)Delegate.Remove(file.OnFileDownloadFinished, new Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>(OnFileDownloadFinished));
		}
	}
}
