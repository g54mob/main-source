using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using UnityEngine;

namespace GUPS.EasyPerformanceMonitor.Provider
{
	public class DownloadSpeedProvider : APerformanceProvider
	{
		public const string CName = "Download";

		private long lastTotalBytesReceived;

		private float lastBytesReceived;

		public override string Name => "Download";

		public override bool IsSupported => true;

		public override string Unit => "B";

		protected override void Awake()
		{
			base.Awake();
			lastTotalBytesReceived = SumTotalBytesReceived();
			InvokeRepeating("UpdateReceivedBytes", 0f, 0.5f);
		}

		private List<NetworkInterface> GetNetworkInterfaces()
		{
			List<NetworkInterface> list = new List<NetworkInterface>();
			try
			{
				NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
				if (allNetworkInterfaces != null)
				{
					list.AddRange(allNetworkInterfaces);
				}
			}
			catch
			{
			}
			return list;
		}

		private long SumTotalBytesReceived()
		{
			List<NetworkInterface> networkInterfaces = GetNetworkInterfaces();
			long num = 0L;
			foreach (NetworkInterface item in networkInterfaces)
			{
				if (item == null)
				{
					continue;
				}
				try
				{
					if (item.NetworkInterfaceType == NetworkInterfaceType.Loopback || item.OperationalStatus != OperationalStatus.Up)
					{
						continue;
					}
					try
					{
						IPInterfaceStatistics iPStatistics = item.GetIPStatistics();
						if (iPStatistics != null)
						{
							num += iPStatistics.BytesReceived;
						}
					}
					catch
					{
						IPv4InterfaceStatistics iPv4Statistics = item.GetIPv4Statistics();
						if (iPv4Statistics != null)
						{
							num += iPv4Statistics.BytesReceived;
						}
					}
				}
				catch
				{
				}
			}
			return num;
		}

		private void UpdateReceivedBytes()
		{
			Task.Run(delegate
			{
				long num = SumTotalBytesReceived();
				lastBytesReceived = Mathf.Max(0f, num - lastTotalBytesReceived);
				lastTotalBytesReceived = num;
			});
		}

		protected override float GetNextValue()
		{
			return lastBytesReceived;
		}
	}
}
