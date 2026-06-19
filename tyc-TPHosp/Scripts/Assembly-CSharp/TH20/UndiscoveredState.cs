#define LOG_LEVEL_VERBOSE
using System.Collections.Generic;

namespace TH20
{
	public class UndiscoveredState : OnlineChallengeState
	{
		private Dictionary<OnlinePlayerID, BaseOnlineDataFile> _cachedDataFiles;

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
			Logging.Info("UndiscoveredState Enter");
			_cachedDataFiles = OnlineManager.DataFiles.GatherDataFiles(OnlineFileClass.OnlineChallenge, Owner.ObjectiveUniqueID, OnlineManager.GetFriendPlayerIDs(), createIfNone: true);
			foreach (KeyValuePair<OnlinePlayerID, BaseOnlineDataFile> cachedDataFile in _cachedDataFiles)
			{
				cachedDataFile.Value.Download(forceTry: true);
			}
		}

		public override void Exit()
		{
			if (_connectionEstablished && OnlineManager.IsInitializedAndLoggedOn())
			{
				_cachedDataFiles.Clear();
			}
		}
	}
}
