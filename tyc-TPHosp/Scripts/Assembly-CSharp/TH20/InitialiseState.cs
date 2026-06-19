using System;

namespace TH20
{
	public class InitialiseState : OnlineChallengeState
	{
		private BaseOnlineDataFile _correctFile;

		private BaseOnlineDataFile _oldFile;

		private BaseOnlineDataFile _correctScreenshotFile;

		private BaseOnlineDataFile _oldScreenshotFile;

		private int _fileDownloadCount;

		private bool _bypass;

		private bool _screenshotsEnabled;

		public override void ConnectionEstablished()
		{
			if (!_connectionEstablished)
			{
				Enter();
			}
		}

		public override void Enter()
		{
			if (!OnlineManager.IsInitializedAndLoggedOn())
			{
				return;
			}
			_connectionEstablished = true;
			_fileDownloadCount = 0;
			_screenshotsEnabled = PlatformFeatureSupport.IsFeatureSupported(PlatformFeatureSupport.FeatureType.OnlineChallengeScreenshots);
			string uniqueBrokenChallengeName = OnlineChallengeObjective.GetUniqueBrokenChallengeName(Level.Config, Owner.Definition);
			_bypass = uniqueBrokenChallengeName.Equals(Owner.ObjectiveUniqueID);
			if (!_bypass)
			{
				_oldFile = OnlineManager.DataFiles.GetFriendDataFile(OnlineFileClass.OnlineChallenge, uniqueBrokenChallengeName, OnlineManager.GetLocalPlayerID(), createIfNone: true);
				_correctFile = OnlineManager.DataFiles.GetFriendDataFile(OnlineFileClass.OnlineChallenge, Owner.ObjectiveUniqueID, OnlineManager.GetLocalPlayerID(), createIfNone: true);
				BaseOnlineDataFile oldFile = _oldFile;
				oldFile.OnFileDownloadFinished = (Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>)Delegate.Combine(oldFile.OnFileDownloadFinished, new Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>(OnFileDownloaded));
				BaseOnlineDataFile correctFile = _correctFile;
				correctFile.OnFileDownloadFinished = (Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>)Delegate.Combine(correctFile.OnFileDownloadFinished, new Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>(OnFileDownloaded));
				_oldFile.Download(forceTry: true);
				_correctFile.Download(forceTry: true);
				if (_screenshotsEnabled)
				{
					string fileID = uniqueBrokenChallengeName + "Screenshot";
					_oldScreenshotFile = OnlineManager.DataFiles.GetFriendDataFile(OnlineFileClass.OnlineChallenge, fileID, OnlineManager.GetLocalPlayerID(), createIfNone: true);
					_correctScreenshotFile = OnlineManager.DataFiles.GetFriendDataFile(OnlineFileClass.OnlineChallenge, Owner.ObjectiveScreenshotUniqueID, OnlineManager.GetLocalPlayerID(), createIfNone: true);
					BaseOnlineDataFile correctScreenshotFile = _correctScreenshotFile;
					correctScreenshotFile.OnFileDownloadFinished = (Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>)Delegate.Combine(correctScreenshotFile.OnFileDownloadFinished, new Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>(OnFileDownloaded));
					BaseOnlineDataFile oldScreenshotFile = _oldScreenshotFile;
					oldScreenshotFile.OnFileDownloadFinished = (Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>)Delegate.Combine(oldScreenshotFile.OnFileDownloadFinished, new Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>(OnFileDownloaded));
					_correctScreenshotFile.Download(forceTry: true);
					_oldScreenshotFile.Download(forceTry: true);
				}
			}
		}

		private void OnFileDownloaded(BaseOnlineDataFile file, DownloadResult result, EOnlineResult onlineResult)
		{
			_fileDownloadCount++;
		}

		public override void Update(float timeDelta)
		{
			if (_fileDownloadCount >= 4 || _bypass)
			{
				Owner.StartStateMachine();
			}
		}

		public override void Exit()
		{
			if (!OnlineManager.IsInitializedAndLoggedOn() || _bypass)
			{
				return;
			}
			if (_oldFile.GetLastDownloadResult() >= DownloadResult.FileNotUpdated && (_correctFile.GetLastDownloadResult() <= DownloadResult.FileNotFound || _correctFile.GetLastTimeUpdated() < _oldFile.GetLastTimeUpdated()))
			{
				OnlineChallengeData obj = null;
				if (_oldFile.Deserialize<OnlineChallengeData>(out obj) == EOnlineResult.EOnlineResultOk && obj != null)
				{
					OnlineManager.DataFiles.WriteFile(OnlineFileClass.OnlineChallenge, Owner.ObjectiveUniqueID, obj);
				}
			}
			if (_correctFile != null)
			{
				BaseOnlineDataFile correctFile = _correctFile;
				correctFile.OnFileDownloadFinished = (Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>)Delegate.Remove(correctFile.OnFileDownloadFinished, new Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>(OnFileDownloaded));
			}
			if (_oldFile != null)
			{
				BaseOnlineDataFile oldFile = _oldFile;
				oldFile.OnFileDownloadFinished = (Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>)Delegate.Remove(oldFile.OnFileDownloadFinished, new Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>(OnFileDownloaded));
			}
			if (!_screenshotsEnabled)
			{
				return;
			}
			if (_oldScreenshotFile.GetLastDownloadResult() >= DownloadResult.FileNotUpdated && (_correctScreenshotFile.GetLastDownloadResult() <= DownloadResult.FileNotFound || _correctScreenshotFile.GetLastTimeUpdated() < _oldScreenshotFile.GetLastTimeUpdated()))
			{
				OnlineScreenshotData obj2 = null;
				if (_oldScreenshotFile.Deserialize<OnlineScreenshotData>(out obj2) == EOnlineResult.EOnlineResultOk && obj2 != null)
				{
					OnlineManager.DataFiles.WriteFile(OnlineFileClass.OnlineChallenge, Owner.ObjectiveScreenshotUniqueID, obj2);
				}
			}
			if (_correctScreenshotFile != null)
			{
				BaseOnlineDataFile correctScreenshotFile = _correctScreenshotFile;
				correctScreenshotFile.OnFileDownloadFinished = (Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>)Delegate.Remove(correctScreenshotFile.OnFileDownloadFinished, new Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>(OnFileDownloaded));
			}
			if (_oldScreenshotFile != null)
			{
				BaseOnlineDataFile oldScreenshotFile = _oldScreenshotFile;
				oldScreenshotFile.OnFileDownloadFinished = (Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>)Delegate.Remove(oldScreenshotFile.OnFileDownloadFinished, new Action<BaseOnlineDataFile, DownloadResult, EOnlineResult>(OnFileDownloaded));
			}
		}
	}
}
