using System;
using System.Collections.Generic;
using Events.Integrations;
using Integrations.Data;
using Integrations.Interfaces;

namespace Integrations
{
	public class DefaultCloudServiceHandler : ICloudServiceHandler
	{
		public bool Ready { get; set; }

		public bool LoggedIn { get; set; }

		public bool CloudServiceDataReceived { get; set; }

		public Action OnCloudServiceReady { get; set; }

		public Action OnCloudServiceLoggedIn { get; set; }

		public Action OnCloudServiceLoginFailed { get; set; }

		public Action<bool> OnCloudServiceDataReceived { get; set; }

		public Action OnScreenShotInfoAvailable { get; set; }

		private void Start()
		{
			Ready = true;
			OnCloudServiceReady?.Invoke();
		}

		public void SetServiceConnector(IPlatformCloudServiceConnector serviceConnector)
		{
		}

		public void SetTitleDataAvailableEvent(TitleDataAvailableEvent titleDataAvailable)
		{
		}

		public void Login()
		{
			LoggedIn = true;
			OnCloudServiceLoggedIn?.Invoke();
		}

		public string GetCloudServiceUserId()
		{
			return string.Empty;
		}

		public void ClearCredentials()
		{
		}

		public TitleData GetTitleData()
		{
			return null;
		}

		public List<DownloadQueue> GetDownloadQueues()
		{
			return new List<DownloadQueue>();
		}
	}
}
