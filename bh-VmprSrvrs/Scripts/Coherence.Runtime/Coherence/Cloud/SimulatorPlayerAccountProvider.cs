using System;

namespace Coherence.Cloud
{
	internal sealed class SimulatorPlayerAccountProvider : IPlayerAccountProvider, IDisposable
	{
		private static readonly CloudUniqueId SimulatorInCloudUniqueId;

		private CloudService services;

		private readonly Func<CloudService> getServices;

		private string projectId;

		public bool IsReady => false;

		public string ProjectId => null;

		public CloudUniqueId CloudUniqueId => default(CloudUniqueId);

		private CloudService Services => null;

		public SimulatorPlayerAccountProvider(Func<CloudService> getServices)
		{
		}

		public SimulatorPlayerAccountProvider(CloudService services)
		{
		}

		public PlayerAccount GetPlayerAccount(LoginInfo loginInfo)
		{
			return null;
		}

		public void Dispose()
		{
		}
	}
}
