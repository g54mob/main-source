using System;
using TH20;

public abstract class BaseOnlineDataFile
{
	public Action<BaseOnlineDataFile, DownloadResult, EOnlineResult> OnFileDownloadFinished;

	public Action<BaseOnlineDataFile> OnFileUploadFailed;

	public Action<BaseOnlineDataFile> OnFileUploadCompleted;

	public Action<BaseOnlineDataFile> OnFileDeletionFailed;

	public Action<BaseOnlineDataFile> OnFileDeletionCompleted;

	public abstract string GetFilename();

	public abstract OnlinePlayerID GetPlayerID();

	public abstract bool IsUploading();

	public abstract bool IsDownloading();

	public abstract DownloadResult GetLastDownloadResult();

	public abstract uint GetLastTimeUpdated();

	public abstract EOnlineResult GetLastOnlineResult();

	public abstract void Download(bool forceTry = false);

	public abstract EOnlineResult Deserialize<T>(out T obj) where T : OnlineManager.IOnlineSerializable;

	public abstract void TryUpload();

	public abstract void ForceUpload();

	public abstract void Delete();

	public abstract void Serialize<T>(T obj) where T : OnlineManager.IOnlineSerializable;

	public virtual void OnDownloadCompleted(object obj, DownloadResult result, EOnlineResult onlineResult)
	{
		if (OnFileDownloadFinished != null)
		{
			OnFileDownloadFinished(this, result, onlineResult);
		}
	}

	public virtual void OnUploadCompleted(object obj)
	{
		OnFileUploadCompleted.InvokeSafe(this);
	}

	public virtual void OnUploadFailed(object obj)
	{
		OnFileUploadFailed.InvokeSafe(this);
	}

	public virtual void OnDeleteCompleted(object obj)
	{
		OnFileDeletionCompleted.InvokeSafe(this);
	}

	public virtual void OnDeleteFailed(object obj)
	{
		OnFileDeletionFailed.InvokeSafe(this);
	}
}
