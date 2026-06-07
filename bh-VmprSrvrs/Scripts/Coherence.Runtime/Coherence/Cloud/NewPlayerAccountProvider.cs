using System;
using System.Collections.Generic;
using Coherence.Common;

namespace Coherence.Cloud
{
	internal sealed class NewPlayerAccountProvider : IPlayerAccountProvider, IDisposable
	{
		private string projectId;

		private CloudUniqueId uniqueId;

		private CloudService services;

		private readonly Func<CloudService> getServices;

		private bool shouldReleaseGuid;

		private readonly List<PlayerAccount> createdPlayerAccounts;

		public bool IsReady => false;

		public CloudUniqueId CloudUniqueId => default(CloudUniqueId);

		public string ProjectId => null;

		private CloudService Services => null;

		public NewPlayerAccountProvider(Func<CloudService> getServices, CloudUniqueId uniqueId = default(CloudUniqueId), IRuntimeSettings runtimeSettings = null)
		{
		}

		public NewPlayerAccountProvider(CloudService services, CloudUniqueId uniqueId = default(CloudUniqueId), IRuntimeSettings runtimeSettings = null)
		{
		}

		public NewPlayerAccountProvider(CloudUniqueId uniqueId = default(CloudUniqueId), IRuntimeSettings runtimeSettings = null)
		{
		}

		public NewPlayerAccountProvider(string projectId, CloudUniqueId uniqueId)
		{
		}

		public NewPlayerAccountProvider(Func<CloudService> getServices, string projectId)
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
