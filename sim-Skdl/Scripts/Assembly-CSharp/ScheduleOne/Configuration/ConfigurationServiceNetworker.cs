using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;

namespace ScheduleOne.Configuration
{
	public class ConfigurationServiceNetworker : NetworkBehaviour
	{
		private bool NetworkInitialize___EarlyScheduleOne_002EConfiguration_002EConfigurationServiceNetworkerAssembly_002DCSharp_002Edll_Excuted;

		private bool NetworkInitialize__LateScheduleOne_002EConfiguration_002EConfigurationServiceNetworkerAssembly_002DCSharp_002Edll_Excuted;

		private ConfigurationService _configurationService => null;

		public override void OnStartServer()
		{
		}

		private void OnDestroy()
		{
		}

		public override void OnSpawnServer(NetworkConnection connection)
		{
		}

		private void OnConfigChanged(BaseConfiguration changedConfig)
		{
		}

		[ObserversRpc]
		[TargetRpc]
		private void ApplySettingsJson(NetworkConnection conn, string configName, string settingsJson)
		{
		}

		public virtual void NetworkInitialize___Early()
		{
		}

		public virtual void NetworkInitialize__Late()
		{
		}

		public override void NetworkInitializeIfDisabled()
		{
		}

		private void RpcWriter___Observers_ApplySettingsJson_3895153758(NetworkConnection conn, string configName, string settingsJson)
		{
		}

		private void RpcLogic___ApplySettingsJson_3895153758(NetworkConnection conn, string configName, string settingsJson)
		{
		}

		private void RpcReader___Observers_ApplySettingsJson_3895153758(PooledReader PooledReader0, Channel channel)
		{
		}

		private void RpcWriter___Target_ApplySettingsJson_3895153758(NetworkConnection conn, string configName, string settingsJson)
		{
		}

		private void RpcReader___Target_ApplySettingsJson_3895153758(PooledReader PooledReader0, Channel channel)
		{
		}

		public virtual void Awake()
		{
		}
	}
}
