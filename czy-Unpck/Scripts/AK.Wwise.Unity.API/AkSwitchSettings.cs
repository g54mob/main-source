public class AkSwitchSettings : AkWwiseInitializationSettings.CommonPlatformSettings
{
	public AkSwitchSettings()
	{
		SetUseGlobalPropertyValue("CommsSettings.m_CommandPort", use: false);
		SetUseGlobalPropertyValue("CommsSettings.m_NotificationPort", use: false);
		IgnorePropertyValue("CommsSettings.m_InitializeSystemComms");
		IgnorePropertyValue("AdvancedSettings.m_RenderDuringFocusLoss");
		IgnorePropertyValue("AdvancedSettings.m_SoundBankPersistentDataPath");
		CommsSettings = new AkCommonCommSettings
		{
			m_DiscoveryBroadcastPort = AkCommonCommSettings.DefaultDiscoveryBroadcastPort,
			m_CommandPort = (ushort)(AkCommonCommSettings.DefaultDiscoveryBroadcastPort + 1),
			m_NotificationPort = (ushort)(AkCommonCommSettings.DefaultDiscoveryBroadcastPort + 2),
			m_InitializeSystemComms = false
		};
	}
}
