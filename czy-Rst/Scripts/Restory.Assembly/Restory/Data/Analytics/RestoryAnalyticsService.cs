using System;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;
using Zenject;

namespace Restory.Data.Analytics
{
	public class RestoryAnalyticsService : IAnalyticsService, IInitializable, IDisposable
	{
		private bool isActive;

		private bool isInitialized;

		public bool IsActive
		{
			get
			{
				return isActive;
			}
			set
			{
				if (isActive == value)
				{
					return;
				}
				isActive = value;
				if (isInitialized)
				{
					if (isActive)
					{
						StartDataCollection();
					}
					else
					{
						StopDataCollection();
					}
				}
			}
		}

		public async void Initialize()
		{
			await UnityServices.InitializeAsync();
			isInitialized = true;
			if (isActive)
			{
				StartDataCollection();
			}
		}

		public void Dispose()
		{
			if (isActive)
			{
				StopDataCollection();
			}
		}

		private void StartDataCollection()
		{
			Debug.Log("[RestoryAnalyticsService] Starting analytics data collection.");
			AnalyticsService.Instance.StartDataCollection();
		}

		private void StopDataCollection()
		{
			Debug.Log("[RestoryAnalyticsService] Stopping analytics data collection.");
			AnalyticsService.Instance.StopDataCollection();
		}

		public void RequestDataDeletion()
		{
			Debug.Log("[RestoryAnalyticsService] Requesting analytics data deletion.");
			AnalyticsService.Instance.RequestDataDeletion();
		}

		public void SendCustomEvent(string eventName)
		{
			Debug.Log("[RestoryAnalyticsService] Sending custom event: " + eventName);
			AnalyticsService.Instance.RecordEvent(eventName);
		}

		public void SendCustomEvent(string eventName, params IAnalyticsParameter[] parameters)
		{
			Debug.Log("[RestoryAnalyticsService] Sending custom event: " + eventName);
			AnalyticsCustomEvent e = new AnalyticsCustomEvent(eventName, parameters);
			AnalyticsService.Instance.RecordEvent(e);
		}
	}
}
