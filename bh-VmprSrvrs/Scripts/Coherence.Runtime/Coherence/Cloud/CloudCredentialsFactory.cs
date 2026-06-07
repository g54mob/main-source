using Coherence.Common;

namespace Coherence.Cloud
{
	internal static class CloudCredentialsFactory
	{
		private static CloudCredentialsPair sharedSimulatorCredentials;

		internal static CloudCredentialsPair ForClient(IRuntimeSettings runtimeSettings, IPlayerAccountProvider playerAccountProvider)
		{
			return null;
		}

		internal static CloudCredentialsPair ForClient(IRuntimeSettings runtimeSettings, CloudUniqueId uniqueId = default(CloudUniqueId))
		{
			return null;
		}

		internal static CloudCredentialsPair ForClient(IRuntimeSettings runtimeSettings, CloudUniqueId uniqueId, IPlayerAccountProvider playerAccountProvider)
		{
			return null;
		}

		internal static CloudCredentialsPair ForSimulator(IRuntimeSettings runtimeSettings, SimulatorPlayerAccountProvider playerAccountProvider)
		{
			return null;
		}
	}
}
