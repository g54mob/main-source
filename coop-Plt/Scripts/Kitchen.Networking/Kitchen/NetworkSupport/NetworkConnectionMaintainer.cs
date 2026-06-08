using UnityEngine;

namespace Kitchen.NetworkSupport
{
	public class NetworkConnectionMaintainer
	{
		private INetworkService Service;

		private float RetryIntervalBase = 1f;

		private float RetryInterval = 1f;

		private float LastConnectionAttempt;

		public NetworkConnectionMaintainer(INetworkService service)
		{
			Service = service;
		}

		public bool ShouldTimeout()
		{
			return false;
		}

		public bool ShouldReconnect()
		{
			if (Service.State == PlatformState.Failed)
			{
				float realtimeSinceStartup = Time.realtimeSinceStartup;
				if (realtimeSinceStartup > LastConnectionAttempt + RetryInterval)
				{
					RetryInterval *= 2f;
					RetryInterval = Mathf.Min(RetryInterval, 30f);
					LastConnectionAttempt = realtimeSinceStartup;
					return true;
				}
			}
			if (Service.State == PlatformState.Ready)
			{
				RetryInterval = RetryIntervalBase;
			}
			return false;
		}
	}
}
