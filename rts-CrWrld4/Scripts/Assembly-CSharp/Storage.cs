using Galaxy.Api;
using UnityEngine;

public class Storage : MonoBehaviour
{
	public class FileShareListener : GlobalFileShareListener
	{
		public override void OnFileShareSuccess(string fileName, ulong sharedFileID)
		{
		}

		public override void OnFileShareFailure(string fileName, FailureReason failureReason)
		{
		}
	}

	public class SharedFileDownloadListener : GlobalSharedFileDownloadListener
	{
		public string userID;

		public override void OnSharedFileDownloadSuccess(ulong sharedFileID, string fileName)
		{
		}

		public override void OnSharedFileDownloadFailure(ulong sharedFileID, FailureReason failureReason)
		{
		}
	}

	public class SpecificUserDataListener : ISpecificUserDataListener
	{
		public string fileName;

		private ulong sharedFileID;

		public override void OnSpecificUserDataUpdated(GalaxyID userID)
		{
		}
	}

	private FileShareListener fileShareListener;

	private SharedFileDownloadListener sharedFileDownloadListener;

	private SpecificUserDataListener specificUserDataListener;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void ListenersInit()
	{
	}

	private void ListenersDispose()
	{
	}

	public void CopyFileToLocalStorage(string absoluteInputPath)
	{
	}

	public void RemoveFileFromLocalStorage(string fileName)
	{
	}

	public void ShareFileFromLocalStorage(string fileName)
	{
	}

	public void ShareAllFilesFromLocalStorage()
	{
	}

	public string[] ListAllFilesFromOnlineStorage()
	{
		return null;
	}

	public ulong GetSharedFileIDFromUser(GalaxyID userID, string fileName)
	{
		return 0uL;
	}

	public void DownloadSharedFileByUserIdAndFileName(GalaxyID userID, string fileName)
	{
	}

	public void DownloadSharedFileBySharedFileID(ulong sharedFileID)
	{
	}
}
