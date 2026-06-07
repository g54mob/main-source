using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using UnityEngine;

namespace GUPS.EasyPerformanceMonitor.Provider
{
	public class UploadSpeedProvider : APerformanceProvider
	{
		public const string CName = "Upload";

		private long lastTotalBytesSent;

		private float lastBytesSent;

		public override string Name => "Upload";

		public override bool IsSupported => true;

		public override string Unit => "B";

		protected override void Awake()
		{
			base.Awake();
			lastTotalBytesSent = SumTotalBytesSent();
			InvokeRepeating("UpdateSentBytes", 0f, 0.5f);
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

		private long SumTotalBytesSent()
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
							num += iPStatistics.BytesSent;
						}
					}
					catch
					{
						IPv4InterfaceStatistics iPv4Statistics = item.GetIPv4Statistics();
						if (iPv4Statistics != null)
						{
							num += iPv4Statistics.BytesSent;
						}
					}
				}
				catch
				{
				}
			}
			return num;
		}

		private void UpdateSentBytes()
		{
			Task.Run(delegate
			{
				long num = SumTotalBytesSent();
				lastBytesSent = Mathf.Max(0f, num - lastTotalBytesSent);
				lastTotalBytesSent = num;
			});
		}

		protected override float GetNextValue()
		{
			return lastBytesSent;
		}
	}
}
