using System;
using UnityEngine;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	[Serializable]
	public class NetworkServicesUnitySettings : SettingsPropertyGroup
	{
		[Serializable]
		public class Address
		{
			[SerializeField]
			[DefaultValue("8.8.8.8")]
			[Tooltip("IPV4 format address.")]
			private string m_ipv4;

			[SerializeField]
			[DefaultValue("0:0:0:0:0:FFFF:0808:0808")]
			[Tooltip("IPV6 format address.")]
			private string m_ipv6;

			public string IpV4 => null;

			public string IpV6 => null;

			public Address(string ipv4 = null, string ipv6 = null)
			{
			}
		}

		[Serializable]
		public class PingTestSettings
		{
			[SerializeField]
			[Tooltip("The number of retries to be performed for failed tests.")]
			private int m_maxRetryCount;

			[SerializeField]
			[Tooltip("The time interval between consecutive polling.")]
			private float m_timeGapBetweenPolling;

			[SerializeField]
			[Tooltip("The time out period.")]
			private float m_timeOutPeriod;

			[SerializeField]
			[Tooltip("The connection port of the host. For DNS IP, it will be 53 or else 80.")]
			private int m_port;

			public int MaxRetryCount => 0;

			public float TimeGapBetweenPolling => 0f;

			public float TimeOutPeriod => 0f;

			public int Port => 0;

			public PingTestSettings(int maxRetryCount = 3, float timeGapBetweenPolling = 2f, float timeOutPeriod = 60f, int port = 53)
			{
			}
		}

		[SerializeField]
		[Tooltip("Host address.")]
		private Address m_hostAddress;

		[SerializeField]
		[Tooltip("If enabled, rechability trackers are activated on launch.")]
		private bool m_autoStartNotifier;

		[SerializeField]
		[Tooltip("Ping test configuration.")]
		private PingTestSettings m_pingSettings;

		public Address HostAddress => null;

		public bool AutoStartNotifier => false;

		public PingTestSettings PingSettings => null;

		public NetworkServicesUnitySettings(bool isEnabled = true, Address hostAddress = null, bool autoStartNotifier = true, PingTestSettings pingSettings = null)
			: base(null, isEnabled: false)
		{
		}
	}
}
