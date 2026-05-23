using System;
using System.Collections.Generic;
using Events.Integrations;
using Integrations.Data;

namespace Integrations.Interfaces
{
	public interface ICloudServiceHandler
	{
		bool Ready { get; set; }

		bool LoggedIn { get; set; }

		Action OnCloudServiceReady { get; set; }

		Action OnCloudServiceLoggedIn { get; set; }

		Action OnCloudServiceLoginFailed { get; set; }

		Action<bool> OnCloudServiceDataReceived { get; set; }

		Action OnScreenShotInfoAvailable { get; set; }

		void SetServiceConnector(IPlatformCloudServiceConnector serviceConnector);

		void SetTitleDataAvailableEvent(TitleDataAvailableEvent titleDataAvailable);

		void Login();

		string GetCloudServiceUserId();

		void ClearCredentials();

		TitleData GetTitleData();

		List<DownloadQueue> GetDownloadQueues();
	}
}
