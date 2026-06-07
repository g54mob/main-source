using System;
using Coherence.Cloud;
using Coherence.Common;

namespace Coherence.Toolkit
{
	internal sealed class CoherenceBridgePlayerAccountProvider : IPlayerAccountProvider, IDisposable
	{
		private readonly CoherenceBridge bridge;

		private PlayerAccount playerAccount;

		private CloudUniqueId uniqueId;

		private string projectId;

		private bool shouldReleaseUniqueId;

		public bool IsReady => false;

		public string ProjectId => null;

		public CloudUniqueId CloudUniqueId => default(CloudUniqueId);

		private IRuntimeSettings RuntimeSettings => null;

		public CoherenceBridgePlayerAccountProvider(CoherenceBridge bridge)
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
