#define LOG_LEVEL_VERBOSE
using System;
using System.Collections;
using MessagePack;
using UnityConsole;
using UnityEngine;
using UnityEngine.Networking;

namespace TH20
{
	[DontSave]
	public class CloudDataManager : MustCallDestroy
	{
		private enum CloudFileType
		{
			Debug = 0,
			Testing = 1,
			Release = 2
		}

		public Action<CloudData> OnCloudDataFileReceived;

		private readonly App _app;

		private readonly CloudFileType _cloudFileType;

		private const string _cloudDataUrl = "https://cdn.assets.twopointstudios.com/cloud_data/release.cdf";

		private const string _cloudTestingDataUrl = "https://cdn.assets.twopointstudios.com/cloud_data/testing.cdf";

		private const string _cloudDebugDataUrl = "https://cdn.assets.twopointstudios.com/cloud_data/debug.cdf";

		private Coroutine _getDataCoroutine;

		private CloudData _downloadedDebugCloudData;

		private CloudData _downloadedTestingCloudData;

		private CloudData _downloadedCloudData;

		public CloudData DownloadedCloudData
		{
			get
			{
				return _cloudFileType switch
				{
					CloudFileType.Debug => _downloadedDebugCloudData, 
					CloudFileType.Testing => _downloadedTestingCloudData, 
					CloudFileType.Release => _downloadedCloudData, 
					_ => _downloadedCloudData, 
				};
			}
			private set
			{
				switch (_cloudFileType)
				{
				case CloudFileType.Debug:
					_downloadedDebugCloudData = value;
					break;
				case CloudFileType.Testing:
					_downloadedTestingCloudData = value;
					break;
				case CloudFileType.Release:
					_downloadedCloudData = value;
					break;
				default:
					_downloadedCloudData = value;
					break;
				}
			}
		}

		public bool IsInitialised { get; private set; }

		public ErrorCode Error { get; private set; }

		private string CloudDataUrl => _cloudFileType switch
		{
			CloudFileType.Debug => "https://cdn.assets.twopointstudios.com/cloud_data/debug.cdf", 
			CloudFileType.Testing => "https://cdn.assets.twopointstudios.com/cloud_data/testing.cdf", 
			CloudFileType.Release => "https://cdn.assets.twopointstudios.com/cloud_data/release.cdf", 
			_ => "https://cdn.assets.twopointstudios.com/cloud_data/release.cdf", 
		};

		public CloudDataManager(App app)
		{
			_app = app;
			_cloudFileType = CloudFileType.Release;
			Initialise();
		}

		public override void Destroy()
		{
			if (OnlineManagerInitialised())
			{
				ConsoleCommandsDatabase.UnRegisterCommand("ForceGetCloudData");
			}
			base.Destroy();
		}

		public void RefreshCloudData()
		{
			if (_getDataCoroutine == null)
			{
				_getDataCoroutine = OnlineManager.BehaviourToRunCoroutinesOn.StartCoroutine(GetLatestCloudData());
			}
		}

		private void Initialise()
		{
			if (OnlineManagerInitialised())
			{
				IsInitialised = false;
				if (_getDataCoroutine != null)
				{
					OnlineManager.BehaviourToRunCoroutinesOn.StopCoroutine(_getDataCoroutine);
					_getDataCoroutine = null;
				}
				RefreshCloudData();
				ConsoleCommandsDatabase.RegisterCommand("ForceGetCloudData", "Forces a download of the superbug project data", "ForceGetCloudData", Debug_ForceGetCloudData);
			}
		}

		private bool OnlineManagerInitialised()
		{
			return OnlineManager.IsInitializedAndLoggedOn();
		}

		private IEnumerator GetLatestCloudData()
		{
			if (Application.internetReachability != NetworkReachability.NotReachable)
			{
				while (!OnlineManagerInitialised())
				{
					yield return null;
				}
				UnityWebRequest webRequest = UnityWebRequest.Get(CloudDataUrl);
				yield return webRequest.SendWebRequest();
				ProcessDownloadResults(webRequest);
				if (DownloadedCloudData == null)
				{
					Logging.Info("[GetCloudData] DownloadedCloudData was null");
				}
				else
				{
					Logging.Info("[GetCloudData] has processed download results");
					OnCloudDataFileReceived.InvokeSafe(DownloadedCloudData);
				}
				IsInitialised = true;
				_getDataCoroutine = null;
			}
		}

		private void ProcessDownloadResults(UnityWebRequest webRequest, bool deleteOldDataOnError = false)
		{
			Error = ErrorCode.NoError;
			CloudData cloudData = null;
			if (webRequest != null && cloudData == null)
			{
				if (webRequest.error.IsNullOrEmpty())
				{
					try
					{
						cloudData = MessagePackSerializer.Deserialize<CloudData>(webRequest.downloadHandler.data);
					}
					catch (Exception)
					{
						Error = ErrorCode.FileDoesNotDeserialize;
						cloudData = null;
						Logging.Warning("[GetCloudData] could not deserialize the cloud data file from the web request.");
					}
				}
				else if (webRequest.error.Contains("404 Not Found"))
				{
					Error = ErrorCode.FileNotFound;
					Logging.Info("[GetCloudData] checked for cloud data file. This is fine if we haven't got one set in the cloud.");
				}
				else
				{
					Error = ErrorCode.FileWWWRequestError;
					Logging.Warning("[GetCloudData] received an error from the web request. Message: " + webRequest.error);
				}
			}
			if (cloudData == null || Error == ErrorCode.FileDoesNotDeserialize || Error == ErrorCode.FileNotFound || Error == ErrorCode.FileWWWRequestError)
			{
				DownloadedCloudData = (deleteOldDataOnError ? null : DownloadedCloudData);
				return;
			}
			DownloadedCloudData = cloudData;
			Error = ErrorCode.NoError;
		}

		private ConsoleCommandResult Debug_ForceGetCloudData(string[] args)
		{
			if (_getDataCoroutine != null)
			{
				OnlineManager.BehaviourToRunCoroutinesOn.StopCoroutine(_getDataCoroutine);
				_getDataCoroutine = null;
			}
			RefreshCloudData();
			return ConsoleCommandResult.Succeeded();
		}
	}
}
