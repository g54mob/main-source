using System;
using UnityEngine;

[Serializable]
public class AkCommonCommSettings
{
	[Tooltip("Size of the communication pool.")]
	public uint m_PoolSize;

	public static ushort DefaultDiscoveryBroadcastPort;

	[Tooltip("The port where the authoring application broadcasts \"Game Discovery\" requests to discover games running on the network. Default value: 24024. (Cannot be set to 0)")]
	public ushort m_DiscoveryBroadcastPort;

	[Tooltip("The \"command\" channel port. Set to 0 to request a dynamic/ephemeral port.")]
	public ushort m_CommandPort;

	[Tooltip("The \"notification\" channel port. Set to 0 to request a dynamic/ephemeral port.")]
	public ushort m_NotificationPort;

	[Tooltip("Indicates whether or not to initialize the communication system. Some consoles have critical requirements for initialization of their communications system. Set to false only if your game already uses sockets before sound engine initialization.")]
	public bool m_InitializeSystemComms;

	[Tooltip("The name used to identify this game within the authoring application. Leave empty to use \"UnityEngine.Application.productName\".")]
	public string m_NetworkName;

	[Tooltip("HTCS communication can only be used with a Nintendo Switch Development Build")]
	public AkCommunicationSettings.AkCommSystem m_commSystem;

	public virtual void CopyTo(AkCommunicationSettings settings)
	{
	}

	public virtual void Validate()
	{
	}
}
